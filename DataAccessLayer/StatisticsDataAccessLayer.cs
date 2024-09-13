using DataAccessLayer.CustomExceptions;
using DataAccessLayer.InterfacesDAL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// A class responsible for communicating with the database only about all data needed for the implemented statistics
    /// </summary>
    public class StatisticsDataAccessLayer : IStatisticsInterfaceDataAccessLayer
    {
        private readonly DataBaseConnection _databaseConnection;

        public StatisticsDataAccessLayer(DataBaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        /// <summary>
        /// This method is responsible for storing the vehicle's production years
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public Dictionary<int, int> GetCarsProductionYear()
        {
            SqlConnection connection = null;

            string query = "SELECT Year(yearOfProduction) AS ProductionYear, " +
                "COUNT(*) AS VehicleCount " +
                "FROM Vehicle " +
                "Where isAvailable = 0 " +
                "GROUP BY " +
                "Year(yearOfProduction) " +
                "ORDER BY " +
                "ProductionYear asc;";
            Dictionary<int, int> YearsOfProduction = new Dictionary<int, int>();
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    YearsOfProduction.Add(Convert.ToInt32(reader["ProductionYear"]), Convert.ToInt32(reader["VehicleCount"]));
                }
                return YearsOfProduction;
            }
            catch (SqlException ex)
            {
                throw new DALException("There is a database error. Adding vehicle failed. \nPlease, try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method is responsible for reading the number of vehicles that have rating below and above average
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public List<int> GetAboveAndBelowAverageRatings()
        {
            string query = $"SELECT Count(*) as 'Ratings'" +
                $"FROM " +
                $"VehicleRating " +
                $"WHERE " +
                $"  rating > (SELECT AVG(rating) FROM VehicleRating ) " +
                $"UNION " +
                $"  SELECT Count(*) " +
                $"  FROM " +
                $"  VehicleRating " +
                $"  WHERE " +
                $"  rating <= (SELECT AVG(rating) FROM VehicleRating);";
            List<int> containerForRating = new List<int>();
            SqlConnection connection = null;

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int rating = (int)reader["Ratings"];
                    containerForRating.Add(rating);
                }
                return containerForRating;
            }
            catch (SqlException ex)
            {
                throw new DALException("There is a database error. Adding vehicle failed. \nPlease, try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method is responsible for reading all monthly revenues for a given year
        /// </summary>
        /// <param name="currentYear"></param>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public Dictionary<int, decimal> GetMontlyRevenue(DateTime currentYear)
        {
            SqlConnection connection = null;

            string query = "SELECT MONTH(saleDate) AS saleMonth, " +
                "SUM(price) AS totalRevenue " +
                "FROM Sales " +
                "WHERE saleDate >= @year + '-01-01' " +
                "GROUP BY MONTH(saleDate) " +
                "ORDER BY saleMonth desc";
            Dictionary<int, decimal> MonthRevenue = new Dictionary<int, decimal>();
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@year", currentYear.Year.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MonthRevenue.Add(Convert.ToInt32(reader["saleMonth"]), Convert.ToDecimal(reader["totalRevenue"]));
                }
                return MonthRevenue;
            }
            catch (SqlException ex)
            {
                throw new DALException("There is a database error. Adding vehicle failed. \nPlease, try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        /// <summary>
        /// This method is repsonsible for reading the avaialbility of vehicles for each category
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public List<int> GetNumberOfVehiclePerCategory()
        {
            string query = $"SELECT vehicleType, COUNT(*) AS NumberOfVehicles " +
                $"FROM Vehicle " +
                $"GROUP BY vehicleType;";
            List<int> containerForNumberOfVehicles = new List<int>();
            SqlConnection connection = null;

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int number = (int)reader["NumberOfVehicles"];
                    containerForNumberOfVehicles.Add(number);
                }
                return containerForNumberOfVehicles;
            }
            catch (SqlException ex)
            {
                throw new DALException("There is a database error. Adding vehicle failed. \nPlease, try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
    }
}
