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
    /// A class responsible for communicating with the database only about all the recommendation algorithm needed data
    /// </summary>
    public class SuggestionsDataManagerDataAccessLayer : ISuggestionsInterfaceDataAccessLayer
    {
        private readonly DataBaseConnection _databaseConnection;

        public SuggestionsDataManagerDataAccessLayer(DataBaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        /// <summary>
        /// This method calculates the common bookamrks the current user has with other users (only those with whom it has common bookmarks [common bookmarks >= 1])
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public Dictionary<int, int> CalculateCommonBookmarks(int personId)
        {

            string query = $"SELECT bv2.personId, COUNT(*) AS commonBookmarks " +
            $"FROM BookmarkedVehicle bv1 " +
            $"JOIN BookmarkedVehicle bv2 ON bv1.vehicleId = bv2.vehicleId AND bv1.personId != bv2.personId " +
            $"WHERE bv1.personId = @personId " +
            $"GROUP BY bv2.personId " +
            $"ORDER BY commonBookmarks DESC;";

            SqlConnection connection = null;
            Dictionary<int,int> commonBookmarks = new Dictionary<int, int>();
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@personId", personId);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    commonBookmarks.Add(reader.GetInt32(0), reader.GetInt32(1));
                }
                return commonBookmarks;
            }
            catch(SqlException)
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
        /// This method takes the distinct bookmarks of the second user (if A likes vehicle 1 and 2 and B likes 2 and 3, if A is the current user, this method will store vehicle 3 in a list
        /// and suggest it to A)
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <param name="secondUserId"></param>
        /// <returns></returns>
        /// <exception cref="DALException"></exception>
        public List<int> GetDistinctVehiclesFromOtherUsers(int currentUserId, int secondUserId)
        {
            string query = $"SELECT vehicleId FROM BookmarkedVehicle " +
                $"WHERE personId = @secondUserId and vehicleId not in " +
                $"  (SELECT vehicleId FROM BookmarkedVehicle " +
                $"  WHERE personId = @currentUserId)";

            SqlConnection connection = null;
            List<int> results = new List<int>();

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@secondUserId", secondUserId);
                command.Parameters.AddWithValue("@currentUserId", currentUserId);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int vehicleId = Convert.ToInt32(reader["vehicleId"]);
                    results.Add(vehicleId);
                }
                return results;
            }
            catch (SqlException)
            {
                throw new DALException("Database connection failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
    }
}