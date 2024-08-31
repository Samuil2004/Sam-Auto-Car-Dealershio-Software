using Classes;
using DataAccessLayer.CustomExceptions;
using DataAccessLayer.InterfacesDAL;
using Logic_layer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReceiptsDataAccessLayer : IReceiptsInterfaceDataAccessLayer
    {
        private readonly DataBaseConnection _databaseConnection;
        public ReceiptsDataAccessLayer(DataBaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        /// <summary>
        /// This method is responsible for inserting the sale in the database
        /// </summary>
        /// <param name="receipt"></param>
        /// <param name="buyer"></param>
        /// <param name="price"></param>
        /// <exception cref="DALException"></exception>
        public void SellVehicle(Receipt receipt, Person buyer, decimal price)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;

            string query = "Insert into Sales (vehicle_id,person_id,saleDate,price) values (@vehicle_id,@person_id, @saleDate, @price);";

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();
                VehiclesDataManagerDataAccessLayer vehicleDataManager = new VehiclesDataManagerDataAccessLayer(_databaseConnection);

                SqlCommand command = new SqlCommand(query, connection, transaction);
                command.Parameters.AddWithValue("@vehicle_id", receipt.GetVehicle.GetVehicleId);
                command.Parameters.AddWithValue("@person_id", buyer.GetId);
                command.Parameters.AddWithValue("@saleDate", DateTime.Today);
                command.Parameters.AddWithValue("@price", price);

                int affectedNumOfRows = command.ExecuteNonQuery();
                {
                    if (affectedNumOfRows == 0)
                    {
                        throw new DALException("Vehicle failed to be sold");
                    }
                }
                ChangeVehicleStatus(receipt.GetVehicle.GetVehicleId, connection, transaction);
                vehicleDataManager.DeleteFromSavedVehiclesTable(receipt.GetVehicle.GetVehicleId, connection, transaction);
                vehicleDataManager.DeleteFromBookmarkedVehiclesTable(receipt.GetVehicle.GetVehicleId, connection, transaction);
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
        /// This method is responsible for changing the vehicle status in the main table (the availability status)
        /// </summary>
        /// <param name="vehicle_id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <exception cref="DALException"></exception>
        private void ChangeVehicleStatus(int vehicle_id, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "UPDATE Vehicle SET isAvailable = 1 WHERE vehicleId = @vehicleId;";

            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@vehicleId", vehicle_id);
            int affectedNumOfRows = command.ExecuteNonQuery();
            {
                if (affectedNumOfRows == 0)
                {
                    throw new DALException("Failed to update status");
                }
            }
        }
        /// <summary>
        /// This method is responsible for reading additional information about the buyer of a sold vehicle
        /// </summary>
        /// <param name="vehicle_id"></param>
        /// <returns></returns>
        /// <exception cref="VehicleNotFound"></exception>
        /// <exception cref="DALException"></exception>
        public Dictionary<DateTime, string> GetSoldVehicleDetails(int vehicle_id)
        {
            SqlConnection connection = null;

            string query = "Select S.saleDate, P.email " +
                "From Sales as S " +
                "Join Person as P on S.person_id = P.personId " +
                "where vehicle_id = @vehicle_id;";
            Dictionary<DateTime, string> VehicleSalesData = new Dictionary<DateTime, string>();
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@vehicle_id", vehicle_id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    VehicleSalesData.Add(Convert.ToDateTime(reader["saleDate"]), (string)reader["email"]);
                    return VehicleSalesData;
                }
                throw new VehicleNotFound($"Taking sale data of vehicle {vehicle_id} failed. \nPlease, try again later");
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
        /// This method is responsible for reading sales for a given page based on pageNumber and filtering criteria
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="filteringCriteria"></param>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public List<Receipt> ReadSoldVehiclesForSelectedPage(int pageNum, string filteringCriteria)
        {
            string query;
            if (string.IsNullOrEmpty(filteringCriteria))
            {
                query = $"SELECT s.vehicle_id, s.saleDate, s.price, ps.strategy " +
                    $"FROM Sales as s " +
                    $"join PaymentStrategy ps on s.paymentStrategyId = ps.strategyId " +
                    $"ORDER BY vehicle_id " +
                    $"OFFSET(@pageNum - 1) * 10 ROWS " +
                    $"FETCH NEXT 11 ROWS ONLY;";
            }
            else
            {
                query = $"SELECT s.vehicle_id, s.saleDate, s.price, ps.strategy " +
                    $"FROM Sales as s " +
                    $"join PaymentStrategy ps on s.paymentStrategyId = ps.strategyId " +
                    $"join Vehicle v on s.vehicle_id = v.vehicleId " +
                    $"Where " +
                    $"v.vehicleId LIKE '%' + @filteringCriteria + '%' " +
                    $"OR v.brand LIKE '%' + @filteringCriteria + '%' " +
                    $"OR v.model LIKE '%' + @filteringCriteria + '%' " +
                    $"ORDER BY vehicleId " +
                    $"OFFSET (@pageNum - 1) * 10 ROWS " +
                    $"FETCH NEXT 11 ROWS ONLY;";
            }
            List<Receipt> containerForSoldVehicles = new List<Receipt>();
            FactoryReceipt factoryReceipt = new FactoryReceipt();
            Receipt newReceipt;
            SqlConnection connection = null;
            VehiclesDataManagerDataAccessLayer vehicleDataManager = new VehiclesDataManagerDataAccessLayer(_databaseConnection);
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
                    int vehicleId = (int)reader["vehicle_id"];
                    DateTime sellingDate = Convert.ToDateTime(reader["saleDate"]);
                    decimal sellingPrice = Convert.ToDecimal(reader["price"]);
                    string strategy = reader["strategy"].ToString();
                    if (strategy.Equals("Bank Transfer"))
                    {
                        newReceipt = factoryReceipt.CreateReceiptBank(vehicleDataManager.ReadVehicle(vehicleId, connection), sellingDate, sellingPrice);
                    }
                    else if (strategy.Equals("Cash"))
                    {
                        newReceipt = factoryReceipt.CreateReceiptCash(vehicleDataManager.ReadVehicle(vehicleId, connection), sellingDate, sellingPrice);
                    }
                    else if (strategy.Equals("Credit card"))
                    {
                        newReceipt = factoryReceipt.CreateReceiptCreditCard(vehicleDataManager.ReadVehicle(vehicleId, connection), sellingDate, sellingPrice);
                    }
                    else
                    {
                        newReceipt = factoryReceipt.CreateReceiptDebit(vehicleDataManager.ReadVehicle(vehicleId, connection), sellingDate, sellingPrice);
                    }
                    containerForSoldVehicles.Add(newReceipt);
                }
                return containerForSoldVehicles;
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
        /// This method reads the bought vehicles by a given person id
        /// </summary>
        /// <param name="person_id"></param>
        /// <param name="connection"></param>
        /// <returns>A list of vehicles that are bought by a given person id</returns>
        public List<Receipt> GetCustomerBoughtVehicles(int person_id, SqlConnection connection)
        {
            string query = "Select * from Sales where person_id = @person_id";
            List<Receipt> boughVehicles = new List<Receipt>();
            VehiclesDataManagerDataAccessLayer vehicleDataManager = new VehiclesDataManagerDataAccessLayer(_databaseConnection);
            FactoryReceipt factoryReceipt = new FactoryReceipt();
            Vehicle vehicle;
            Receipt receipt;

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@person_id", person_id);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                vehicle = vehicleDataManager.ReadVehicle(Convert.ToInt32(reader["vehicle_id"]), connection);
                DateTime dateOfSelling = Convert.ToDateTime(reader["saleDate"]);
                int paymentStrategyId = (int)reader["paymentStrategyId"];
                decimal sellingPrice = (decimal)reader["price"];
                if (paymentStrategyId == 1)
                {
                    receipt = factoryReceipt.CreateReceiptBank(vehicle, dateOfSelling, sellingPrice);
                }
                else if (paymentStrategyId == 2)
                {
                    receipt = factoryReceipt.CreateReceiptCash(vehicle, dateOfSelling, sellingPrice);
                }
                else if (paymentStrategyId == 3)
                {
                    receipt = factoryReceipt.CreateReceiptCreditCard(vehicle, dateOfSelling, sellingPrice);
                }
                else
                {
                    receipt = factoryReceipt.CreateReceiptDebit(vehicle, dateOfSelling, sellingPrice);
                }
                boughVehicles.Add(receipt);
            }
            return boughVehicles;
        }
    }
}
