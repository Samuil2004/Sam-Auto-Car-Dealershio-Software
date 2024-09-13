using Classes;
using Microsoft.Data.SqlClient;
using System;
using DataAccessLayer.CustomExceptions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Transactions;
using System.Data.Common;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Logic_layer;
using Logic_layer.Enumerations;
using DataAccessLayer.InterfacesDAL;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    /// <summary>
    /// A class responsible for communicating with the database only about all vehicles related data
    /// </summary>
    public class VehiclesDataManagerDataAccessLayer : IVehicleInterfaceDataAccessLayer
    {
        private readonly DataBaseConnection _databaseConnection;

        public VehiclesDataManagerDataAccessLayer(DataBaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        /// <summary>
        /// This method adds a new vehicle to the Vehicle table and based on the vehicle type is calls corresponding method responsible for adding the vehicle in the other tables)
        /// </summary>
        /// <param name="vehicle"></param>
        /// <exception cref="DALException"></exception>
        public void CreateVehicle(Vehicle vehicle)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            int vehicleId;
            string vehicleQuery = "INSERT INTO Vehicle (price, color, yearOfProduction, brand, model, condition, mileage, " +
                "isAvailable, isReserved, engineId, fuelId, publicationDate, vehicleType, transmissionTypeId) " +
                "VALUES (@price, @color, @yearOfProduction, @brand, @model, @condition, @mileage, @isAvailable, @isReserved, " +
                "   (SELECT engineId FROM Engine WHERE engineType = @engineType), " +
                "   (SELECT fuelId FROM Fuel WHERE fuelType = @fuelType), " +
                "@publicationDate, @vehicleType, " +
                "   (SELECT typeId FROM TransmissionType WHERE transmissionType = @transmissionType)) " +
                "SELECT SCOPE_IDENTITY();";

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand vehicleCommand = new SqlCommand(vehicleQuery, connection,transaction);

                vehicleCommand.Parameters.AddWithValue("@price", vehicle.GetPrice);
                vehicleCommand.Parameters.AddWithValue("@color", vehicle.GetColor);
                vehicleCommand.Parameters.AddWithValue("@yearOfProduction", vehicle.GetYearOfProduction);
                vehicleCommand.Parameters.AddWithValue("@brand", vehicle.GetBrand);
                vehicleCommand.Parameters.AddWithValue("@model", vehicle.GetModel);
                vehicleCommand.Parameters.AddWithValue("@condition", vehicle.GetCondition.ToString());
                vehicleCommand.Parameters.AddWithValue("@mileage", vehicle.GetMileage);
                vehicleCommand.Parameters.AddWithValue("@isAvailable", false);
                vehicleCommand.Parameters.AddWithValue("@isReserved", vehicle.GetIsReserved);
                vehicleCommand.Parameters.AddWithValue("@engineType", vehicle.GetEngine.GetEngineType.ToString());
                vehicleCommand.Parameters.AddWithValue("@fuelType", vehicle.GetEngine.GetFuelType.ToString());
                vehicleCommand.Parameters.AddWithValue("@publicationDate", vehicle.GetPublicationDate);
                if (vehicle.GetType() == typeof(Car))
                {
                    vehicleCommand.Parameters.AddWithValue("@vehicleType", 0);
                }
                else if (vehicle.GetType() == typeof(Truck))
                {
                    vehicleCommand.Parameters.AddWithValue("@vehicleType", 2);
                }
                else
                {
                    vehicleCommand.Parameters.AddWithValue("@vehicleType", 1);
                }
                vehicleCommand.Parameters.AddWithValue("@transmissionType", vehicle.GetTransmissionType.ToString());

                object result = vehicleCommand.ExecuteScalar();

                if (result == null || Convert.ToInt32(result) == 0)
                {
                    throw new DALException("There is a database error. Adding vehicle failed. \nPlease, try again later!");
                }
                else
                {
                    vehicleId = Convert.ToInt32(result);
                }
 
                if (vehicle.GetType() == typeof(Car))
                {
                    CreateCar(vehicle, vehicleId, connection,transaction);
                }
                else if (vehicle.GetType() == typeof(Truck))
                {
                    CreateTruck(vehicle, vehicleId, connection,transaction);
                }
                else
                {
                    CreateMotorcycle(vehicle, vehicleId, connection, transaction);
                }
                AddImage(vehicleId, vehicle.GetImage, connection, transaction);
                transaction.Commit();

            }
            catch (DALException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw;
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method is responsile for inserting a car object into the car table in the database
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="vehicle_id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void CreateCar(Vehicle vehicle, int vehicle_id,SqlConnection connection,SqlTransaction transaction)
        {
            string carQuery = "INSERT INTO Car (vehicleId, horsePower, numberOfDoors, steeringWheelId,carTypeId) " +
                "VALUES (@vehicleId,@horsePower,@numberOfDoors, " +
                "   (SELECT steeringWheelId FROM SteeringWheel WHERE steeringWheelType = @steeringWheel), " +
                "   (SELECT typeId FROM CarType WHERE carType = @carType));";

            SqlCommand carCommand = new SqlCommand(carQuery, connection, transaction);
            carCommand.Parameters.AddWithValue("@vehicleId", vehicle_id);
            carCommand.Parameters.AddWithValue("@horsePower", ((Car)vehicle).GetHorsePower);
            carCommand.Parameters.AddWithValue("@steeringWheel", ((Car)vehicle).GetSteeringWheel.ToString());
            carCommand.Parameters.AddWithValue("@numberOfDoors", ((Car)vehicle).GetNumberOfDoors);
            carCommand.Parameters.AddWithValue("@carType", vehicle.GetBodyType);
            carCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// This method is responsile for inserting a truck object into the car table in the database
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="vehicle_id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void CreateTruck(Vehicle vehicle, int vehicle_id,SqlConnection connection,SqlTransaction transaction)
        {
            string truckQuery = "Insert into Truck (vehicleId,numOfAxles,playloadCapacity, horsePower,steeringWheelId,truckTypeId) " +
                "values (@vehicleId,@numOfAxles,@playloadCapacity, @horsePower, " +
                "   (SELECT steeringWheelId FROM SteeringWheel WHERE steeringWheelType = @steeringWheel), " +
                "   (SELECT typeId FROM TruckType WHERE truckType = @truckType));";

            SqlCommand truckCommand = new SqlCommand(truckQuery, connection,transaction);
            truckCommand.Parameters.AddWithValue("@vehicleId", vehicle_id);
            truckCommand.Parameters.AddWithValue("@numOfAxles", ((Truck)vehicle).GetNumberOfAxles);
            truckCommand.Parameters.AddWithValue("@playloadCapacity", ((Truck)vehicle).GetPlayLoadCapacity);
            truckCommand.Parameters.AddWithValue("@horsePower", ((Truck)vehicle).GetHorsePower);
            truckCommand.Parameters.AddWithValue("@steeringWheel", ((Truck)vehicle).GetSteeeringWheelType.ToString());
            truckCommand.Parameters.AddWithValue("@truckType", vehicle.GetBodyType);
            truckCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// This method is responsile for inserting a motorcycle object into the car table in the database
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="vehicle_id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void CreateMotorcycle(Vehicle vehicle, int vehicle_id,SqlConnection connection, SqlTransaction transaction)
        {
            string motorcycleQuery = "Insert into Motorcycle (vehicleId,cubicCapacity,hasWindShield,hasABox,motorcycleTypeId) " +
                "values (@vehicleId,@cubicCapacity,@hasWindShield,@hasABox, " +
                "   (SELECT typeId FROM MotorcycleType WHERE motorcycleType = @motorcycleType));";

            SqlCommand motorcycleCommand = new SqlCommand(motorcycleQuery, connection, transaction);
            motorcycleCommand.Parameters.AddWithValue("@vehicleId", vehicle_id);
            motorcycleCommand.Parameters.AddWithValue("@cubicCapacity", ((Motorcycle)vehicle).GetCubicCapacity);
            motorcycleCommand.Parameters.AddWithValue("@hasWindShield", ((Motorcycle)vehicle).GetHasWindShield);
            motorcycleCommand.Parameters.AddWithValue("@hasABox", ((Motorcycle)vehicle).GetHasABox);
            motorcycleCommand.Parameters.AddWithValue("@motorcycleType", vehicle.GetBodyType);
            motorcycleCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// This method is responsible for inserting a vehicle image in the images table
        /// </summary>
        /// <param name="vehicle_id"></param>
        /// <param name="imageUrl"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void AddImage(int vehicle_id, string imageUrl, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "Insert into Images (vehicleId, imageUrl) values (@vehicle_id, @imageUrl)";

            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@vehicle_id", vehicle_id);
            command.Parameters.AddWithValue("@imageUrl", imageUrl);
            command.ExecuteNonQuery();
        }

    
        /// <summary>
        /// This method deletes vehcile from the main Vehicle table and calls other methods that delete it from the intersection tables
        /// </summary>
        /// <param name="vehicle"></param>
        /// <exception cref="DALException"></exception>
        public void DeleteVehicle(Vehicle vehicle)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            string vehicleQuery = "Delete from Vehicle where vehicleId = @vehicleId;";

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand vehicleCommand = new SqlCommand(vehicleQuery, connection, transaction);
                vehicleCommand.Parameters.AddWithValue("@vehicleId", vehicle.GetVehicleId);
                DeleteFromBookmarkedVehiclesTable(vehicle.GetVehicleId,connection,transaction);
                DeleteImage(vehicle.GetVehicleId, connection,transaction);
                DeleteFromSavedVehiclesTable(vehicle.GetVehicleId, connection,transaction);
                DeleteVehicleRating(vehicle.GetVehicleId, connection,transaction);
                if (vehicle.GetType() == typeof(Car))
                {
                    DeleteCar(vehicle.GetVehicleId, connection,transaction);
                }
                else if (vehicle.GetType() == typeof(Truck))
                {
                    DeleteTruck(vehicle.GetVehicleId, connection,transaction);
                }
                else
                {
                    DeleteMotorcycle(vehicle.GetVehicleId, connection,transaction);
                }
                int affectedNumOfRows = vehicleCommand.ExecuteNonQuery();
                {
                    if(affectedNumOfRows == 0)
                    {
                        throw new DALException("Vehicle failed to be deleted");
                    }
                }
                transaction.Commit();
            }
            catch (DALException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw;
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method deleted a car object from the car table
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void DeleteCar(int vehicleId, SqlConnection connection,SqlTransaction transaction)
        {
            string carQuery = "Delete from Car where vehicleId = @vehicleId;";

            SqlCommand carCommand = new SqlCommand(carQuery, connection, transaction);
            carCommand.Parameters.AddWithValue("@vehicleId", vehicleId);
            carCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// This method deletes truck object from the truck table
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void DeleteTruck(int vehicleId, SqlConnection connection, SqlTransaction transaction)
        {
            string truckQuery = "Delete from Truck where vehicleId = @vehicleId;";

            SqlCommand truckCommand = new SqlCommand(truckQuery, connection, transaction);
            truckCommand.Parameters.AddWithValue("@vehicleId", vehicleId);
            truckCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// This method deletes motorcycle from the motorcycle table
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void DeleteMotorcycle(int vehicleId, SqlConnection connection, SqlTransaction transaction)
        {
            string motorcycleQuery = "Delete from Motorcycle where vehicleId = @vehicleId;";

            SqlCommand motorcycleCommand = new SqlCommand(motorcycleQuery, connection, transaction);
            motorcycleCommand.Parameters.AddWithValue("@vehicleId", vehicleId);
            motorcycleCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// This method deleted an image from the images table
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void DeleteImage(int vehicleId, SqlConnection connection, SqlTransaction transaction)
        {
            string imageQuery = "Delete from Images where vehicleId = @vehicleId;";

            SqlCommand imageCommand = new SqlCommand(imageQuery, connection, transaction);
            imageCommand.Parameters.AddWithValue("@vehicleId", vehicleId);
            imageCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// This method deletes vehicle rating fromt he Rating table
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void DeleteVehicleRating(int vehicleId, SqlConnection connection,SqlTransaction transaction)
        {
            string ratingQuery = "Delete from VehicleRating where vehicleId = @vehicleId;";

            SqlCommand ratingCommand = new SqlCommand(ratingQuery, connection,transaction);
            ratingCommand.Parameters.AddWithValue("@vehicleId", vehicleId);
            ratingCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// This method deletes all savings of a given vehicle
        /// </summary>
        /// <param name="vehicle_id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public void DeleteFromSavedVehiclesTable(int vehicle_id, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "Delete from SavedVehicles where vehicleId = @vehicleId;";

            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@vehicleId", vehicle_id);
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// This method deletes all bookmarks of a given vehicle
        /// </summary>
        /// <param name="vehicle_id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public void DeleteFromBookmarkedVehiclesTable(int vehicle_id, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "Delete from BookmarkedVehicle where vehicleId = @vehicleId;";

            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@vehicleId", vehicle_id);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// This method is responsible for reading the vehicle type by given id and according to the read type to call different object reading methods
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        /// <exception cref="VehicleNotFound"></exception>
        /// <exception cref="DALException"></exception>
        public Vehicle ReadVehicle(int vehicleId, SqlConnection? connection)
        {
            string query = $"Select vehicleType from Vehicle where vehicleId = @vehicleId";
            bool ownConnection = false;

            try
            {
                if (connection == null)
                {
                    connection = _databaseConnection.GetConnection();
                    connection.Open();
                    ownConnection = true;
                }
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@vehicleId", vehicleId);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int vehicleType = (int)reader["vehicleType"];
                    if (vehicleType == 0)
                    {
                        return ReadCar(vehicleId, connection);
                    }
                    else if (vehicleType == 2)
                    {
                        return ReadTruck(vehicleId, connection);
                    }
                    else
                    {
                        return ReadMotorcycle(vehicleId, connection);
                    }
                }
                throw new VehicleNotFound($"Vehicle {vehicleId} could not be found. \nPlease,try again later!");
            }
            catch (SqlException ex)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (ownConnection && connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// This method is responsible for reading a Car object
        /// </summary>
        /// <param name="vehicle_id"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        /// <exception cref="VehicleNotFound"></exception>
        private Vehicle ReadCar(int vehicle_id, SqlConnection connection)
        {
            string query = "SELECT V.vehicleId, price, color, yearOfProduction, brand, model, condition, mileage, isAvailable, isReserved, publicationDate, " +
                "E.engineType, F.fuelType,T.transmissionType,C.horsePower,C.numberOfDoors,S.steeringWheelType,CT.carType, I.imageUrl " +
                "FROM Vehicle AS V " +
                "JOIN Engine AS E ON V.engineId = E.engineId " +
                "JOIN Fuel AS F ON V.fuelId = F.fuelId " +
                "JOIN Car AS C ON V.vehicleId = C.vehicleId " +
                "JOIN TransmissionType AS T ON V.transmissionTypeId = T.typeId " +
                "JOIN SteeringWheel AS S ON C.steeringWheelId = S.steeringWheelId " +
                "JOIN CarType AS CT ON C.carTypeId = CT.typeId " +
                "JOIN Images as I ON V.vehicleId = I.vehicleId " +
                "Where V.vehicleId = @vehicle_id;";
            Vehicle newVehicle;

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@vehicle_id", vehicle_id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int vehicleId = Convert.ToInt32(reader["vehicleId"]);
                int price = Convert.ToInt32(reader["price"]);
                string color = reader["color"].ToString();
                DateTime yearOfProduction = Convert.ToDateTime(reader["yearOfProduction"]);
                string brand = reader["brand"].ToString();
                string model = reader["model"].ToString();
                string condition = reader["condition"].ToString();
                Condition selected_condition = (Condition)Enum.Parse(typeof(Condition), condition);
                int mileage = Convert.ToInt32(reader["mileage"]);
                bool isBought = Convert.ToBoolean(reader["isAvailable"]);
                bool isReserved = Convert.ToBoolean(reader["isReserved"]);
                DateTime publicationDate = Convert.ToDateTime(reader["publicationDate"]);
                string engineType = reader["engineType"].ToString();
                EngineType selected_engine = (EngineType)Enum.Parse(typeof(EngineType), engineType);
                string fuelType = reader["fuelType"].ToString();
                string transmission = reader["transmissionType"].ToString();
                TransmissionType seleced_transmission = (TransmissionType)Enum.Parse(typeof(TransmissionType), transmission);
                int horsePower = Convert.ToInt32(reader["horsePower"]);
                int numberOfDoors = Convert.ToInt32(reader["numberOfDoors"]);
                string steeringWheel = reader["steeringWheelType"].ToString();
                SteeringWheelType selected_steeringWheel = (SteeringWheelType)Enum.Parse(typeof(SteeringWheelType), steeringWheel);
                string vehicleType = reader["carType"].ToString();
                string imageUrl = reader["imageUrl"].ToString();
                newVehicle = new Car(vehicleId,price, seleced_transmission, color, yearOfProduction, brand, model, selected_condition, isBought, isReserved, horsePower,selected_steeringWheel, numberOfDoors,mileage, publicationDate,ReadAverageRating(vehicle_id,connection),imageUrl, new Engine(selected_engine, fuelType), vehicleType);
                return newVehicle;
            }
            throw new VehicleNotFound($"Car {vehicle_id} was not found. \nTry again");
        }
        /// <summary>
        /// This method is responsible for reading a motorcycle object
        /// </summary>
        /// <param name="vehicle_id"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        /// <exception cref="VehicleNotFound"></exception>
        private Vehicle ReadMotorcycle(int vehicle_id,SqlConnection connection)
        {
            string query = "SELECT V.vehicleId, price, color, yearOfProduction, brand, model, condition, mileage, isAvailable, isReserved, publicationDate, " +
                "E.engineType, F.fuelType,T.transmissionType,M.cubicCapacity,M.hasWindShield,M.hasABox,MT.motorcycleType, I.imageUrl " +
                "FROM Vehicle AS V " +
                "JOIN Engine AS E ON V.engineId = E.engineId " +
                "JOIN Fuel AS F ON V.fuelId = F.fuelId " +
                "JOIN Motorcycle AS M ON V.vehicleId = M.vehicleId " +
                "JOIN TransmissionType AS T ON V.transmissionTypeId = T.typeId " +
                "JOIN MotorcycleType AS MT ON M.motorcycleTypeId = MT.typeId " +
                "JOIN Images as I ON V.vehicleId = I.vehicleId " +
                "Where V.vehicleId = @vehicle_id;";
            Vehicle newVehicle;

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@vehicle_id", vehicle_id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int vehicleId = Convert.ToInt32(reader["vehicleId"]);
                int price = Convert.ToInt32(reader["price"]);
                string color = reader["color"].ToString();
                DateTime yearOfProduction = Convert.ToDateTime(reader["yearOfProduction"]);
                string brand = reader["brand"].ToString();
                string model = reader["model"].ToString();
                string condition = reader["condition"].ToString();
                Condition selected_condition = (Condition)Enum.Parse(typeof(Condition), condition);
                int mileage = Convert.ToInt32(reader["mileage"]);
                bool isBought = Convert.ToBoolean(reader["isAvailable"]);
                bool isReserved = Convert.ToBoolean(reader["isReserved"]);
                DateTime publicationDate = Convert.ToDateTime(reader["publicationDate"]);
                string engineType = reader["engineType"].ToString();
                EngineType selected_engine = (EngineType)Enum.Parse(typeof(EngineType), engineType);
                string fuelType = reader["fuelType"].ToString();
                string transmission = reader["transmissionType"].ToString();
                TransmissionType seleced_transmission = (TransmissionType)Enum.Parse(typeof(TransmissionType), transmission);
                int cubicCapacity = Convert.ToInt32(reader["cubicCapacity"]);
                bool hasWindShield = Convert.ToBoolean(reader["hasWindShield"]);
                bool hasABox = Convert.ToBoolean(reader["hasABox"]);
                string vehicleType = reader["motorcycleType"].ToString();
                string imageUrl = reader["imageUrl"].ToString();
                newVehicle = new Motorcycle(vehicleId, price, seleced_transmission, color, yearOfProduction, brand, model, selected_condition, isBought, isReserved, cubicCapacity, mileage,hasWindShield,hasABox, publicationDate,ReadAverageRating(vehicle_id,connection), imageUrl, new Engine(selected_engine, fuelType), vehicleType);
                return newVehicle;
            }
            throw new VehicleNotFound($"Motorcycle {vehicle_id} was not found \nTry again");
        }
        /// <summary>
        /// This method is responsible for reading a truck method
        /// </summary>
        /// <param name="vehicle_id"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        /// <exception cref="VehicleNotFound"></exception>
        private Vehicle ReadTruck(int vehicle_id,SqlConnection connection)
        {
            string query = "SELECT V.vehicleId, price, color, yearOfProduction, brand, model, condition, mileage, isAvailable, isReserved, publicationDate, " +
                "E.engineType, F.fuelType,TR.transmissionType,T.numOfAxles, T.playloadCapacity,T.horsePower,S.steeringWheelType,TT.truckType, I.imageUrl " +
                "FROM Vehicle AS V " +
                "JOIN Engine AS E ON V.engineId = E.engineId " +
                "JOIN Fuel AS F ON V.fuelId = F.fuelId " +
                "JOIN Truck AS T ON V.vehicleId = T.vehicleId " +
                "JOIN TransmissionType AS TR ON V.transmissionTypeId = TR.typeId " +
                "JOIN SteeringWheel AS S ON T.steeringWheelId = S.steeringWheelId " +
                "JOIN TruckType AS TT ON T.truckTypeId = TT.typeId " +
                "JOIN Images as I ON V.vehicleId = I.vehicleId " +
                "Where V.vehicleId = @vehicle_id;";
            Vehicle newVehicle;

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@vehicle_id", vehicle_id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int vehicleId = Convert.ToInt32(reader["vehicleId"]);
                int price = Convert.ToInt32(reader["price"]);
                string color = reader["color"].ToString();
                DateTime yearOfProduction = Convert.ToDateTime(reader["yearOfProduction"]);
                string brand = reader["brand"].ToString();
                string model = reader["model"].ToString();
                string condition = reader["condition"].ToString();
                Condition selected_condition = (Condition)Enum.Parse(typeof(Condition), condition);
                int mileage = Convert.ToInt32(reader["mileage"]);
                bool isBought = Convert.ToBoolean(reader["isAvailable"]);
                bool isReserved = Convert.ToBoolean(reader["isReserved"]);
                DateTime publicationDate = Convert.ToDateTime(reader["publicationDate"]);
                string engineType = reader["engineType"].ToString();
                EngineType selected_engine = (EngineType)Enum.Parse(typeof(EngineType), engineType);
                string fuelType = reader["fuelType"].ToString();
                string transmission = reader["transmissionType"].ToString();
                TransmissionType seleced_transmission = (TransmissionType)Enum.Parse(typeof(TransmissionType), transmission);
                int numOfAxles = Convert.ToInt32(reader["numOfAxles"]);
                int playloadCapacity = Convert.ToInt32(reader["playloadCapacity"]);
                int horsePower = Convert.ToInt32(reader["horsePower"]);
                string steeringWheel = reader["steeringWheelType"].ToString();
                SteeringWheelType selected_steeringWheel = (SteeringWheelType)Enum.Parse(typeof(SteeringWheelType), steeringWheel);
                string vehicleType = reader["truckType"].ToString();
                string imageUrl = reader["imageUrl"].ToString();
                newVehicle = new Truck(vehicleId,price, seleced_transmission, color, yearOfProduction, brand, model, selected_condition, isBought, isReserved, horsePower, numOfAxles, playloadCapacity, selected_steeringWheel, mileage, publicationDate, ReadAverageRating(vehicle_id,connection),imageUrl, new Engine(selected_engine, fuelType), vehicleType);
                return newVehicle;
            }
            throw new VehicleNotFound($"Truck {vehicle_id} was not found \nTry again");
        }
        /// <summary>
        /// This method is responsible for reading the average rating of a vehicle
        /// </summary>
        /// <param name="vehicle_id"></param>
        /// <returns></returns>
        private int ReadAverageRating(int vehicle_id, SqlConnection connection)
        {
            string query = "SELECT AVG(rating) AS AverageRating FROM VehicleRating WHERE vehicleId = @vehicleId;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@vehicleId", vehicle_id);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                if (reader["AverageRating"] != DBNull.Value)
                {
                    return Convert.ToInt32(reader["AverageRating"]);
                }
            }
            return 0;
        }


        /// <summary>
        /// This method is responsible for updating the vehicle object in the vehicle table
        /// </summary>
        /// <param name="vehicle"></param>
        /// <exception cref="DALException"></exception>
        public void UpdateVehicle(Vehicle vehicle)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;

            string vehicleQuery = "Update Vehicle set price = @price,color = @color, yearOfProduction = @yearOfProduction, brand = @brand, model = @model, " +
                "condition = @condition , mileage = @mileage, isAvailable = isAvailable, isReserved = @isReserved, " +
                "engineId = " +
                "   (SELECT engineId FROM Engine WHERE engineType = @engineType), " +
                "fuelId = " +
                "   (SELECT fuelId FROM Fuel WHERE fuelType = @fuelType), " +
                "transmissionTypeId = " +
                "   (SELECT typeId FROM TransmissionType WHERE transmissionType = @transmissionType), " +
                "publicationDate = @publicationDate " +
                "where vehicleId = @vehicleId;";

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand vehicleCommand = new SqlCommand(vehicleQuery, connection,transaction);
                vehicleCommand.Parameters.AddWithValue("@price", vehicle.GetPrice);
                vehicleCommand.Parameters.AddWithValue("@color", vehicle.GetColor);
                vehicleCommand.Parameters.AddWithValue("@yearOfProduction", vehicle.GetYearOfProduction);
                vehicleCommand.Parameters.AddWithValue("@brand", vehicle.GetBrand);
                vehicleCommand.Parameters.AddWithValue("@model", vehicle.GetModel);
                vehicleCommand.Parameters.AddWithValue("@condition", vehicle.GetCondition.ToString());
                vehicleCommand.Parameters.AddWithValue("@mileage", vehicle.GetMileage);
                vehicleCommand.Parameters.AddWithValue("@isAvailable", true);
                vehicleCommand.Parameters.AddWithValue("@isReserved", vehicle.GetIsReserved);
                vehicleCommand.Parameters.AddWithValue("@engineType", vehicle.GetEngine.GetEngineType.ToString());
                vehicleCommand.Parameters.AddWithValue("@fuelType", vehicle.GetEngine.GetFuelType.ToString());
                vehicleCommand.Parameters.AddWithValue("@transmissionType", vehicle.GetTransmissionType.ToString());
                vehicleCommand.Parameters.AddWithValue("@publicationDate", vehicle.GetPublicationDate);
                vehicleCommand.Parameters.AddWithValue("@vehicleId", vehicle.GetVehicleId);

                int affectedNumOfRows = vehicleCommand.ExecuteNonQuery();
                {
                    if (affectedNumOfRows == 0)
                    {
                        throw new DALException("Vehicle failed to be deleted");
                    }
                }

                if (vehicle.GetType() == typeof(Car))
                {
                    UpdateCar(vehicle,connection,transaction);
                }
                else if (vehicle.GetType() == typeof(Truck))
                {
                    UpdateTruck(vehicle,connection,transaction);
                }
                else
                {
                   UpdateMotorcycle(vehicle,connection,transaction);
                }
                UpdateImage(vehicle.GetImage, vehicle.GetVehicleId,connection,transaction);
                transaction.Commit();
            }

            catch (DALException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw;
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }  
        }
        /// <summary>
        /// This method is responsible for updating a car object in the car table
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void UpdateCar(Vehicle vehicle,SqlConnection connection,SqlTransaction transaction)
        {
            string carQuery = "Update Car set horsePower = @horsePower, numberOfDoors = @numberOfDoors, " +
                "steeringWheelId = " +
                "   (SELECT steeringWheelId FROM SteeringWheel WHERE steeringWheelType = @steeringWheel), " +
                "carTypeId = " +
                "   (SELECT typeId FROM CarType WHERE carType = @carType) " +
                "where vehicleId = @vehicleId;";

            SqlCommand carCommand = new SqlCommand(carQuery, connection,transaction);
            carCommand.Parameters.AddWithValue("@horsePower", ((Car)vehicle).GetHorsePower);
            carCommand.Parameters.AddWithValue("@numberOfDoors", ((Car)vehicle).GetNumberOfDoors);
            carCommand.Parameters.AddWithValue("@steeringWheel", ((Car)vehicle).GetSteeringWheel.ToString());
            carCommand.Parameters.AddWithValue("@carType", vehicle.GetBodyType);
            carCommand.Parameters.AddWithValue("@vehicleId", vehicle.GetVehicleId);
            carCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// This method is responsible for updating a truck object in the truck table
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void UpdateTruck(Vehicle vehicle,SqlConnection connection,SqlTransaction transaction)
        {
            string truckQuery = "Update Truck set numOfAxles = @numOfAxles, playloadCapacity = @playloadCapacity, horsePower = @horsePower, " +
                "steeringWheelId = " +
                "   (SELECT steeringWheelId FROM SteeringWheel WHERE steeringWheelType = @steeringWheel), " +
                "truckTypeId = " +
                "   (SELECT typeId FROM TruckType WHERE truckType = @truckType) " +
                "where vehicleId = @vehicleId;";

            SqlCommand truckCommand = new SqlCommand(truckQuery, connection, transaction);
            truckCommand.Parameters.AddWithValue("@numOfAxles", ((Truck)vehicle).GetNumberOfAxles);
            truckCommand.Parameters.AddWithValue("@playloadCapacity", ((Truck)vehicle).GetPlayLoadCapacity);
            truckCommand.Parameters.AddWithValue("@horsePower", ((Truck)vehicle).GetHorsePower);
            truckCommand.Parameters.AddWithValue("@steeringWheel", ((Truck)vehicle).GetSteeeringWheelType.ToString());
            truckCommand.Parameters.AddWithValue("@truckType", vehicle.GetBodyType);
            truckCommand.Parameters.AddWithValue("@vehicleId", vehicle.GetVehicleId);
            truckCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// This method is responsible for updating a motorcycle object in the motorcycle table
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void UpdateMotorcycle(Vehicle vehicle,SqlConnection connection, SqlTransaction transaction)
        {
            string motorcycleQuery = "Update Motorcycle set cubicCapacity = @cubicCapacity, hasWindShield = @hasWindShield, hasABox = @hasABox, " +
                "motorcycleTypeId = " +
                "   (SELECT typeId FROM MotorcycleType WHERE motorcycleType = @motorcycleType) " +
                "where vehicleId = @vehicleId;";

            SqlCommand motorcycleCommand = new SqlCommand(motorcycleQuery, connection, transaction);
            motorcycleCommand.Parameters.AddWithValue("@cubicCapacity", ((Motorcycle)vehicle).GetCubicCapacity);
            motorcycleCommand.Parameters.AddWithValue("@hasWindShield", ((Motorcycle)vehicle).GetHasWindShield);
            motorcycleCommand.Parameters.AddWithValue("@hasABox", ((Motorcycle)vehicle).GetHasABox);
            motorcycleCommand.Parameters.AddWithValue("@motorcycleType", vehicle.GetBodyType);
            motorcycleCommand.Parameters.AddWithValue("@vehicleId", vehicle.GetVehicleId);
            motorcycleCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// This method is responsible for updating an image
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="vehicleId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <exception cref="DALException"></exception>
        private void UpdateImage(string imageUrl, int vehicleId, SqlConnection connection,SqlTransaction transaction)
        {
            string query = "Update Images set imageUrl = @imageUrl where vehicleId = @vehicleId;";

            SqlCommand immageCommand = new SqlCommand(query, connection, transaction);
            immageCommand.Parameters.AddWithValue("@imageUrl", imageUrl);
            immageCommand.Parameters.AddWithValue("@vehicleId", vehicleId);
            int affectedNumOfRows = immageCommand.ExecuteNonQuery();
            {
                if (affectedNumOfRows == 0)
                {
                    throw new DALException("Image failed to be deleted");
                }
            }
        }
        /// <summary>
        /// This method is responsible for reading the username of a person who saved a vehicle for buying
        /// </summary>
        /// <param name="vehicle_id"></param>
        /// <returns></returns>
        /// <exception cref="VehicleNotFound"></exception>
        /// <exception cref="DALException"></exception>

        public string GetWhoSavedTheVehicle(int vehicle_id)
        {
            SqlConnection connection = null;

            string query = "Select P.email " +
                "from SavedVehicles as S " +
                "join Person as P on P.personId = S.personId " +
                "where vehicleId = @vehicleId";
            Dictionary<int, int> YearsOfProduction = new Dictionary<int, int>();
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@vehicleId", vehicle_id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string email = (string)reader["email"];
                    return email;
                }
                throw new VehicleNotFound($"Vehicle information for vehicle {vehicle_id} \ncan not be found at the moment. \nPlease, try again later!");
            }
            catch (SqlException ex)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }


        /// <summary>
        /// This emethod is responsible for reading avaialble vehicles for a given page based on a page number and filtering criteria
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="filteringCriteria"></param>
        /// <param name="isWeb"></param>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public List<Vehicle> ReadAvailableVehiclesForSelectedPage(int pageNum, string filteringCriteria, bool isWeb)
        {
            string query;
            if (string.IsNullOrEmpty(filteringCriteria))
            {
                query = $"SELECT vehicleId FROM Vehicle WHERE isAvailable = 0 ";
                    
                if(isWeb)
                {
                    query += $" and isReserved = 0 ";
                }
                query += $"ORDER BY vehicleId " +
                         $"OFFSET (@pageNum - 1) * 10 ROWS " +
                         $"FETCH NEXT 11 ROWS ONLY;";
            }
            else
            {
                query = $"SELECT vehicleId FROM Vehicle WHERE isAvailable = 0 ";

                if (isWeb)
                {
                    query += $" and isReserved = 0 ";
                }
                query += $"AND ( " +
                           $"vehicleId LIKE '%' + @filteringCriteria + '%' " +
                           $"OR brand LIKE '%' + @filteringCriteria + '%' " +
                           $"OR model LIKE '%' + @filteringCriteria + '%' " +
                           $") " +
                           $"ORDER BY vehicleId " +
                           $"OFFSET (@pageNum - 1) * 10 ROWS " +
                           $"FETCH NEXT 11 ROWS ONLY;";
            }
            List<Vehicle> containerForVehicles = new List<Vehicle>();
            SqlConnection connection = null;

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@pageNum", pageNum);
                if (!string.IsNullOrEmpty(filteringCriteria))
                {
                    command.Parameters.AddWithValue("@filteringCriteria", filteringCriteria);
                }

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int vehicleId = (int)reader["vehicleId"];
                    containerForVehicles.Add(ReadVehicle(vehicleId,connection));
                }
                return containerForVehicles;
            }
            catch (SqlException ex)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method is repsonsible for reading the total number of available vehicles (used for pagination for the web, so the actor can now how many pages are there)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public int ReadNumberOfVehicles()
        {
            string query = $"SELECT COUNT(*) " +
                $"FROM Vehicle " +
                $"WHERE isAvailable = 0 and isReserved = 0";

            SqlConnection connection = null;
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }   
        }
        /// <summary>
        /// This method is used ot read the ten most recently added vehicles
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public List<Vehicle> GetTenMostRecentlyAddedAvailableVehicles()
        {
            string query = $"SELECT TOP 10 vehicleId " +
                $"FROM Vehicle " +
                $"where isAvailable = 0 and isReserved = 0" +
                $"ORDER BY publicationDate desc;";
           
            List<Vehicle> containerForVehicles = new List<Vehicle>();
            SqlConnection connection = null;

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int vehicleId = (int)reader["vehicleId"];
                    containerForVehicles.Add(ReadVehicle(vehicleId, connection));
                }
                if(containerForVehicles == null)
                {
                    throw new DALException("Vehicles failed to be retrieved");
                }
                return containerForVehicles;
            }
            catch (SqlException ex)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method is responsible for reading the ten top rated vehicles
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public List<Vehicle> GetTenTopRatedAvailableVehicles()
        {
            string query = $"SELECT TOP 10 vr.vehicleId, AVG(vr.rating) AS averageRating " +
                $"FROM VehicleRating vr " +
                $"JOIN Vehicle v ON vr.vehicleId = v.vehicleId " +
                $"WHERE v.isAvailable = 0 and isReserved = 0 " +
                $"GROUP BY vr.vehicleId " +
                $"ORDER BY averageRating desc;";

            List<Vehicle> containerForVehicles = new List<Vehicle>();
            SqlConnection connection = null;

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int vehicleId = (int)reader["vehicleId"];
                    containerForVehicles.Add(ReadVehicle(vehicleId, connection));
                }
                return containerForVehicles;
            }
            catch (SqlException ex)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }


        /// <summary>
        /// This method is responsible for reserving a vehicle for buying
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="personId"></param>
        /// <exception cref="DALException"></exception>
        public void ReserveVehicle(int vehicleId, int personId)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;

            string query = "Update Vehicle set isReserved = 1 where vehicleId = @vehicleId";
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand command = new SqlCommand(query, connection, transaction);
                command.Parameters.AddWithValue("@vehicleId", vehicleId);

                int affectedNumOfRows = command.ExecuteNonQuery();
                {
                    if (affectedNumOfRows == 0)
                    {
                        throw new DALException("Vehicle failed to be saved");
                    }
                }
                SaveVehicleForBuying(vehicleId, personId, connection,transaction);
                DeleteFromBookmarkedVehiclesTable(vehicleId, connection, transaction);
                transaction.Commit();
            }
            catch (DALException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw;
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method is respnsible for inserting the reservation information
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="personId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <exception cref="DALException"></exception>
        private void SaveVehicleForBuying(int vehicleId, int personId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "Insert into SavedVehicles (vehicleId,personId,dateOfSaving) values (@vehicleId,@personId,@date)";

            SqlCommand command = new SqlCommand(query, connection,transaction);
            command.Parameters.AddWithValue("@vehicleId", vehicleId);
            command.Parameters.AddWithValue("@personId", personId);
            command.Parameters.AddWithValue("@date", DateTime.Today);
            int affectedNumOfRows = command.ExecuteNonQuery();
            {
                if (affectedNumOfRows == 0)
                {
                    throw new DALException("Vehicle failed to be saved");
                }
            }
        }
        /// <summary>
        /// This method is responsible for checking all vehicles who were saved but the saving expired
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public List<int> ExpiredReservationsChecker()
        {
            SqlConnection connection = null;

            string query = "Select vehicleId from SavedVehicles where dateOfSaving < DATEADD(DAY, -3, GETDATE())";
            List<int> containerForVehicleIDs = new List<int>();
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int vehicleId = (int)reader["vehicleId"];
                    containerForVehicleIDs.Add(vehicleId);
                }
                return containerForVehicleIDs;
            }
            catch (SqlException ex)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method is responsible for unreserving vehicles whose saving time has expired
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <exception cref="DALException"></exception>
        public void UnReserveVehicle(int vehicleId)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;

            string queryForSavedVehiclesTable = "Delete from SavedVehicles where vehicleId = @vehicleId";
            string queryForVehicleTable = "Update Vehicle set isReserved = 0 where vehicleId = @vehicleId";
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand command1 = new SqlCommand(queryForSavedVehiclesTable, connection, transaction);
                SqlCommand command2 = new SqlCommand(queryForVehicleTable, connection, transaction);
                command1.Parameters.AddWithValue("@vehicleId", vehicleId);
                command2.Parameters.AddWithValue("@vehicleId", vehicleId);
                int affectedNumOfRows1 = command1.ExecuteNonQuery();
                {
                    if (affectedNumOfRows1 == 0)
                    {
                        throw new DALException("Vehicle failed to be unreserved");
                    }
                }
                int affectedNumOfRows2 = command2.ExecuteNonQuery();
                {
                    if (affectedNumOfRows2 == 0)
                    {
                        throw new DALException("Vehicle failed to be unreserved");
                    }
                }
                transaction.Commit();
            }
            catch (DALException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw;
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method is resposnible to add rating to a vehicle
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="personId"></param>
        /// <param name="rating"></param>
        /// <exception cref="DALException"></exception>
        public void RateVehicle(int vehicleId,int personId, int rating)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;

            string query = "Insert into VehicleRating(vehicleId,rating,personId) values (@vehicleId,@rating, @personId)";
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand command = new SqlCommand(query, connection, transaction);
                command.Parameters.AddWithValue("@vehicleId", vehicleId);
                command.Parameters.AddWithValue("@rating", rating);
                command.Parameters.AddWithValue("@personId", personId);

                DeleteDuplicateRecords(vehicleId, personId, connection, transaction);
                int affectedNumOfRows = command.ExecuteNonQuery();
                {
                    if (affectedNumOfRows == 0)
                    {
                        throw new DALException("Vehicle failed to be rated");
                    }
                }
                transaction.Commit();
            }
            catch (DALException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw;
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method is responsible for checking if the actor who rates a vehicle has previosly rated the same vehicle and if yes, to delete the previous record
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="personId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void DeleteDuplicateRecords(int vehicleId, int personId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "Delete from VehicleRating where vehicleId = @vehicleId and personId = @personId";

            SqlCommand command = new SqlCommand(query, connection,transaction);
            command.Parameters.AddWithValue("@vehicleId", vehicleId);
            command.Parameters.AddWithValue("@personId", personId);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Searches for vehicles based on specified criteria (by the actor trought he web application) and returns a list of vehicle IDs
        /// corresponding to the current page of results. The criteria include vehicle category,
        /// year of production, engine type, and maximum price.
        /// </summary>
        /// <param name="category">The category of the vehicle (e.g., Car, Motorcycle, Truck). Null or empty for no category filter.</param>
        /// <param name="year">The year of production of the vehicle. Null or empty for no year filter.</param>
        /// <param name="engine">The type of engine (e.g., Internal_Combustion, Electric, Hybrid). Null or empty for no engine filter.</param>
        /// <param name="maxPrice">The maximum price of the vehicle. Zero for no price filter.</param>
        /// <param name="pageNum">The number of the page to retrieve, used for pagination.</param>
        /// <param name="pageSize">The number of results per page, used for pagination. Ussually 10</param>
        /// <returns>A list of vehicle IDs that match the specified criteria.</returns>
        /// <exception cref="SqlException">Translates into a DALException.</exception>
        public List<int> FindSearchResults(string category, string year, string engine, int maxPrice, int pageNum, int pageSize)
        {
            string query = "SELECT v.vehicleId FROM Vehicle v WHERE v.isAvailable = 0 and v.isReserved = 0";

            if (!string.IsNullOrEmpty(category))
            {
                if (category.Equals("car"))
                {
                    query += " AND v.vehicleType = 0";
                }
                else if (category.Equals("motorcycle"))
                {
                    query += " AND v.vehicleType = 1";
                }
                else if (category.Equals("truck"))
                {
                    query += " AND v.vehicleType = 2";
                }
            }

            if (!string.IsNullOrEmpty(engine))
            {

                if (engine.Equals("Internal_Combustion"))
                {
                    query += " AND v.engineId = 1";
                }
                else if (engine.Equals("Electric"))
                {
                    query += " AND v.engineId = 2";
                }
                else if (engine.Equals("Hybrid"))
                {
                    query += " AND v.engineId = 3";
                }
            }

            if (!string.IsNullOrEmpty(year))
            {
                query += $" AND LEFT(v.yearOfProduction, 4) = CAST({Convert.ToInt16(year)} AS NVARCHAR(4))";
            }

            if (maxPrice > 0)
            {
                query += $" AND v.price <= {maxPrice}";
            }
            query += " ORDER BY v.vehicleId " +
                "OFFSET (@pageNum - 1) * @pageSize ROWS " +
                "FETCH NEXT @pageSize ROWS ONLY";

            List<int> containerForVehicleIDs = new List<int>();
            SqlConnection connection = null;
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@pageNum", pageNum);
                command.Parameters.AddWithValue("@pageSize", pageSize);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int vehicleId = (int)reader["vehicleId"];
                    containerForVehicleIDs.Add(vehicleId);
                }
                return containerForVehicleIDs;
            }
            catch (SqlException ex)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method counts the results based on a sepcifies filtering criteria Its used for the web in order ot notify the actor how many pages of resutls there are
        /// </summary>
        /// <param name="category"></param>
        /// <param name="year"></param>
        /// <param name="engine"></param>
        /// <param name="maxPrice"></param>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public int CountResults(string category, string year, string engine, int maxPrice)
        {
            string query = "SELECT COUNT(*) as TotalResults FROM Vehicle v WHERE v.isAvailable = 0 and v.isReserved = 0";

            if (!string.IsNullOrEmpty(category))
            {
                if (category.Equals("car"))
                {
                    query += " AND v.vehicleType = 0";
                }
                else if (category.Equals("motorcycle"))
                {
                    query += " AND v.vehicleType = 1";
                }
                else if (category.Equals("truck"))
                {
                    query += " AND v.vehicleType = 2";
                }
            }

            if (!string.IsNullOrEmpty(engine))
            {

                if (engine.Equals("Internal_Combustion"))
                {
                    query += " AND v.engineId = 1";
                }
                else if (engine.Equals("Electric"))
                {
                    query += " AND v.engineId = 2";
                }
                else if (engine.Equals("Hybrid"))
                {
                    query += " AND v.engineId = 3";
                }
            }

            if (!string.IsNullOrEmpty(year))
            {
                query += $" AND LEFT(v.yearOfProduction, 4) = CAST({Convert.ToInt16(year)} AS NVARCHAR(4))";
            }

            if (maxPrice > 0)
            {
                query += $" AND v.price <= {maxPrice}";
            }
            SqlConnection connection = null;
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int results = (int)reader["TotalResults"];
                    return results;
                }
                throw new DALException("Reading the number of results failed. Please try again later!");
            }
            catch (SqlException ex)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method is responsible to read the different vehicle types
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public Dictionary<int, string> ReadVehicleTypes(string vehicleType)
        {
            string tableName = vehicleType + "Type";
            string query = $"Select * from {tableName}";
            Dictionary<int, string> containerForVehicleType = new Dictionary<int, string>();

            SqlConnection connection = null;
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    containerForVehicleType.Add((int)reader["typeId"], (string)reader[$"{vehicleType.ToLower()}Type"]);
                }
                return containerForVehicleType;
            }
            catch (SqlException ex)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }

        /// <summary>
        /// This method reads the bookmarked as favorite vehicles by a given person id
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="connection"></param>
        /// <returns>A list of vehicles that are bookmarked by a given person id</returns>
        /// <exception cref="SqlException">Translates to a DALException</exception>
        public List<Vehicle> GetCustomerBookmarkedVehicles(int personId, SqlConnection? connection)
        {
            string query = $"SELECT vehicleId " +
                $"FROM BookmarkedVehicle " +
                $"WHERE personId = @personId";
            List<Vehicle> containerForBookmarkedVehicles = new List<Vehicle>();
            bool ownConnection = false;

            try
            {
                if (connection == null)
                {
                    connection = _databaseConnection.GetConnection();
                    connection.Open();
                    ownConnection = true;
                }
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@personId", personId);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int vehicleId = (int)reader["vehicleId"];
                    containerForBookmarkedVehicles.Add(ReadVehicle(vehicleId, connection));
                }
                return containerForBookmarkedVehicles;
            }
            catch (SqlException ex)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (ownConnection && connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// This method reads vehicles that are ssaved for buying by a given person id
        /// </summary>
        /// <param name="person_id"></param>
        /// <param name="connection"></param>
        /// <returns>A list of vehicles that are saved for buying by a given person id</returns>
        /// <exception cref="SqlException">Translates into a DALException</exception>
        public List<Vehicle> GetCustomerSavedVehicles(int person_id, SqlConnection? connection)
        {
            string query = "Select vehicleId from SavedVehicles where personId = @person_id";
            List<Vehicle> savedVehicles = new List<Vehicle>();
            bool ownConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = _databaseConnection.GetConnection();
                    connection.Open();
                    ownConnection = true;
                }
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@person_id", person_id);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int vehicleId = (int)reader["vehicleId"];
                    savedVehicles.Add(ReadVehicle(vehicleId, connection));
                }
                return savedVehicles;
            }
            catch (SqlException ex)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (ownConnection && connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }
}
