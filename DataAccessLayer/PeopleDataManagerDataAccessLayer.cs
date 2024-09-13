using Classes;
using DataAccessLayer.CustomExceptions;
using DataAccessLayer.InterfacesDAL;
using Logic_layer;
using Logic_layer.Enumerations;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// A class responsible for communicating with the database only about all people related data
    /// </summary>
    public class PeopleDataManagerDataAccessLayer : IPeopleInterfaceDataManagerDataAccessLayer
    {
        private readonly DataBaseConnection _databaseConnection;

        public PeopleDataManagerDataAccessLayer(DataBaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        /// <summary>
        /// This method checks if the email is known to the Person table in the database. No duplicate email should be present in the database
        /// </summary>
        /// <param name="email"></param>
        /// <returns>A boolean (true or false) if the email is already present in the Person table</returns>
        /// <exception cref="SqlException">Translates it to a DALException</exception>
        public bool IsEmailAvailable(string email)
        {
            string query = "SELECT COUNT(*) AS email FROM Person WHERE email = @email; SELECT SCOPE_IDENTITY();";
            SqlConnection connection = null;
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);
                int counter = Convert.ToInt32(command.ExecuteScalar());
                return counter == 0;
            }
            catch (SqlException ex)
            {
                throw new DALException("Database issue has occured with checking if email is free. \nPlease Try again later");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }


        /// <summary>
        /// This method identifies a new person to the database. By executing the query it add the new person to the main (parent) table and then based on the person role
        /// it adds it to the corresponding table
        /// </summary>
        /// <param name="person"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <param name="secretQuestionId"></param>
        /// <param name="secretQuestionAnswer"></param>
        /// <returns>Returns the id of the newly created person</returns>
        /// <exception cref="ArgumentNullException">An exception thrown by the method in case either the salt, hash, or the secretQuestionId is empty or invalid (data fields that are generated in the logic layer)</exception>
        /// <exception cref="DALException"></exception>
        /// <exception cref="SqlException">Translates it to a DALException</exception>

        public int CreatePerson(Person person, string salt, string hash, int secretQuestionId, string secretQuestionAnswer)
        {
            string query = "INSERT INTO Person(firstName, lastName, email, phoneNumber, roleId,secretQuestionId) " +
                           "VALUES (@firstName, @lastName, @email, @phoneNumber, @roleId, @secretQuestionId);" +
                           "SELECT SCOPE_IDENTITY();";

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            int personId;
            try
            {
                if(string.IsNullOrEmpty(salt) || string.IsNullOrEmpty(hash) || secretQuestionId < 0)
                {
                    throw new ArgumentNullException("A null value has been passed. \nNull values are not allowed.");
                }
                connection = _databaseConnection.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand command = new SqlCommand(query, connection,transaction);
                command.Parameters.AddWithValue("@firstName", person.GetFirstName);
                command.Parameters.AddWithValue("@lastName", person.GetLastName);
                command.Parameters.AddWithValue("@email", person.GetEmail);
                command.Parameters.AddWithValue("@phoneNumber", person.GetPhoneNumber);
                command.Parameters.AddWithValue("@secretQuestionId", secretQuestionId);
                if (person is Customer)
                {
                    command.Parameters.AddWithValue("@roleId", 1);
                }
                else if (person is StaffMember staffMember)
                {
                    command.Parameters.AddWithValue("@roleId", 0);
                }

                object result = command.ExecuteScalar();
                if (result == null || Convert.ToInt32(result) == 0)
                {
                    throw new DALException("There is a database error. Adding person failed. \nPlease, try again later!");
                }
                else
                {
                    personId = Convert.ToInt32(result);
                }

                if (person is Customer)
                {
                    CreateCustomer(personId, connection, transaction);
                }
                else if(person is StaffMember staffMember)
                {
                    if (staffMember.GetStaffRole == StaffMemberRoles.Employee)
                    {
                        CreateStaffMember(personId, staffMember.GetStartedDate, 2, connection, transaction);
                    }
                    else
                    {
                        CreateStaffMember(personId, staffMember.GetStartedDate, 1, connection, transaction);
                    }
                }
                AddPassword(personId, salt, hash, connection,transaction);
                AddSecretQuestionAnswer(personId, secretQuestionAnswer,connection,transaction);
                transaction.Commit();
                return personId;
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
                throw new DALException("There is a database error. Adding person failed. \nPlease try again later.");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }


        /// <summary>
        /// This method adds a new customer to the Customer table in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void CreateCustomer(int id, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "Insert into Customer(personId, isLoyalClient) Values(@personId, 0);";

            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@personId", id);
            command.ExecuteNonQuery();
        }


        /// <summary>
        /// This method adds a new staff member to the StaffMember table in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateStarted"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void CreateStaffMember(int id, DateTime dateStarted, int staffMemberRoleId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "Insert into StaffMember(personId,dateStarted,staffMemberRoleId) values (@personId,@dateStarted,@staffMemberRoleId);";

            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@personId", id);
            command.Parameters.AddWithValue("@dateStarted", dateStarted.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@staffMemberRoleId", staffMemberRoleId);
            command.ExecuteNonQuery();
        }


        /// <summary>
        /// This method adds a password (hash and salt) for a person to the Password table in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void AddPassword(int id, string salt, string hash,SqlConnection connection,SqlTransaction transaction)
        {
            string query = $"INSERT INTO PasswordsSecurity " +
                           $"(personId, passwordSalt, passwordHash) " +
                           $"VALUES (@id, @salt, @hash);";

            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@salt", salt);
            command.Parameters.AddWithValue("@hash", hash);
            command.ExecuteNonQuery();
        }


        /// <summary>
        /// This method adds a secret question answer for a person to the Secret Question Answer table in the database
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="secretQuestionAnswer"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void AddSecretQuestionAnswer(int personId, string secretQuestionAnswer, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "Insert into SecretQuestionAnswer (personId,secretQuestionAnswer) values (@personId,@secretQuestionAnswer)";

            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@personId", personId);
            command.Parameters.AddWithValue("@secretQuestionAnswer", secretQuestionAnswer);
            command.ExecuteNonQuery();
        }





        /// <summary>
        /// This method updates the information of an already identified person in the database
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="hash"></param>
        /// <param name="salt"></param>
        /// <param name="secretQuestionId"></param>
        /// <param name="secretQuestionAnswer"></param>
        /// <exception cref="ArgumentNullException">An exception thrown by the method in case either the salt, hash, or the secretQuestionId is empty or invalid (data fields that are generated in the logic layer)</exception>
        /// <exception cref="DALException"></exception>
        /// <exception cref="SqlException">Translates it to a DALException</exception>
        public void UpdatePerson(int personId, string email, string phoneNumber, string hash, string salt, int secretQuestionId, string secretQuestionAnswer)
        {
            string query = $"Update Person set email = @email, phoneNumber = @phoneNumber, secretQuestionId = @secretQuestionId where personId = @personId";

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            try
            {
                if (string.IsNullOrEmpty(salt) || string.IsNullOrEmpty(hash) || secretQuestionId < 0)
                {
                    throw new ArgumentNullException("A null value has been passed. \n Null values are not allowed");
                }
                connection = _databaseConnection.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand command = new SqlCommand(query, connection, transaction);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@personId", personId);
                command.Parameters.AddWithValue("@secretQuestionId", secretQuestionId);

                int affectedNumOfRows = command.ExecuteNonQuery();
                {
                    if (affectedNumOfRows == 0)
                    {
                        throw new DALException("Person failed to be updated");
                    }
                }
                UpdatePassword(personId,hash,salt,connection,transaction);
                UpdateSecretQuestionAnswer(personId,secretQuestionAnswer,connection,transaction);
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
        /// This method updates the password of an already existing user in the database
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="hash"></param>
        /// <param name="salt"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>

        private void UpdatePassword(int personId, string hash, string salt,SqlConnection connection, SqlTransaction transaction) 
        {
            string query = $"Update PasswordsSecurity set passwordSalt = @salt, passwordHash = @hash where personId = @personId";

            SqlCommand command = new SqlCommand(query, connection,transaction);
            command.Parameters.AddWithValue("@hash", hash);
            command.Parameters.AddWithValue("@salt", salt);
            command.Parameters.AddWithValue("@personId", personId);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// This method updates the secreqt question answer of an already existing user in the database
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="secretQuestionAnswer"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        private void UpdateSecretQuestionAnswer(int personId, string secretQuestionAnswer, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "Update SecretQuestionAnswer set secretQuestionAnswer = @secretQuestionAnswer where personId = @personId";

            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@secretQuestionAnswer", secretQuestionAnswer);
            command.Parameters.AddWithValue("@personId", personId);
            command.ExecuteNonQuery();
        }






        /// <summary>
        /// This method deletes an already existing person from all tables he/she is a part of
        /// </summary>
        /// <param name="person_id"></param>
        /// <exception cref="DALException"></exception>
        /// <exception cref="SqlException">Translates it into a DALException</exception>
        public void DeletePerson(int person_id)
        {
            string query = $"DELETE from Person where personId = @personId";

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand command = new SqlCommand(query, connection, transaction);
                command.Parameters.AddWithValue("@personId", person_id);

                DeleteFromSecretQuestionAnswer(person_id, connection, transaction);
                DeleteFromStaffMember(person_id,connection, transaction);
                DeleteFromPassword(person_id, connection, transaction);
                int affectedNumOfRows = command.ExecuteNonQuery();
                {
                    if (affectedNumOfRows == 0)
                    {
                        throw new DALException("Person failed to be deleted");
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
        /// This method deletes the secret question answer for a given person_id
        /// </summary>
        /// <param name="person_id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <exception cref="DALException"></exception>
        private void DeleteFromSecretQuestionAnswer(int person_id, SqlConnection connection,SqlTransaction transaction)
        {
            string query = $"DELETE from SecretQuestionAnswer where personId = @personId";

            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@personId", person_id);
            int affectedNumOfRows = command.ExecuteNonQuery();
            {
                if (affectedNumOfRows == 0)
                {
                    throw new DALException("Secret question answer failed to be deleted");
                }
            }
        }

        /// <summary>
        /// This method deletes the records from the staff member table that are related to the given person_id
        /// </summary>
        /// <param name="person_id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <exception cref="DALException"></exception>

        private void DeleteFromStaffMember(int person_id, SqlConnection connection, SqlTransaction transaction)
        {
            string query = $"DELETE from StaffMember where personId = @personId";

            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@personId", person_id);
            int affectedNumOfRows = command.ExecuteNonQuery();
            {
                if (affectedNumOfRows == 0)
                {
                    throw new DALException("Staff member failed to be deleted");
                }
            }
        }

        /// <summary>
        /// This method deletes the password details from the Password table for a given person_id
        /// </summary>
        /// <param name="person_id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <exception cref="DALException"></exception>
        private void DeleteFromPassword(int person_id, SqlConnection connection, SqlTransaction transaction)
        {
            string query = $"DELETE from PasswordsSecurity where personId = @personId";

            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@personId", person_id);
            //command.ExecuteNonQuery();
            int affectedNumOfRows = command.ExecuteNonQuery();
            {
                if (affectedNumOfRows == 0)
                {
                    throw new DALException("Password answer failed to be deleted");
                }
            }
        }




        /// <summary>
        /// This method reads the salt and the hash for a given email. It is used for log in purposes
        /// </summary>
        /// <param name="email"></param>
        /// <returns>A tupple containing the hasn and the salt corresponding to the given email</returns>
        /// <exception cref="UserNotFound">An exception thrown in case there is an error identifying the user and reading its password details</exception>
        /// <exception cref="SqlException">Translates to DALException</exception>
        public Tuple<string, string> ReadSaltAndHash(string email)
        {
            string query = $"SELECT passwordSalt, passwordHash FROM PasswordsSecurity WHERE personId = @id";
            Tuple<string, string> ContainerForSaltHash;
            SqlConnection connection = null;

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", GetPersonId(email, connection));

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ContainerForSaltHash = Tuple.Create((string)reader["passwordHash"], (string)reader["passwordSalt"]);
                    return ContainerForSaltHash;
                }
                throw new UserNotFound("An error occured finding user data");
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

        public Person ReadPerson(int personId, string email, SqlConnection? connection)
        {
            string query = $"Select roleId as 'role' from Person where";
            if (string.IsNullOrEmpty(email))
            {
                query += " personId = @personId;";
            }
            else if (!string.IsNullOrEmpty(email))
            {
                query += " email = @email;";
            }
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
                if (string.IsNullOrEmpty(email))
                {
                    command.Parameters.AddWithValue("@personId", personId);
                }
                else if (!string.IsNullOrEmpty(email))
                {
                    command.Parameters.AddWithValue("@email", email);
                }

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int role = (int)reader["role"];
                    if (string.IsNullOrEmpty(email))
                    {
                        if (role == 1)
                        {
                            return ReadCustomer(personId, connection);
                        }
                        else if (role == 0)
                        {
                            return ReadStaffMember(personId, connection);
                        }
                    }
                    else
                    {
                        if (role == 1)
                        {
                            return ReadCustomer(GetPersonId(email, connection), connection);
                        }
                        else if (role == 0)
                        {
                            return ReadStaffMember(GetPersonId(email, connection), connection);
                        }
                    }
                }
                throw new UserNotFound("User could not be found at the moment. \nPlease, try again later!");
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
        /// This method reads all the information for a customer based on a given personId (of a customer)
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="connection"></param>
        /// <returns>A person object that corresponds to the given person id</returns>
        /// <exception cref="UserNotFound">This exception occurs if there is an issue with reading customers information</exception>
        /// <exception cref="SqlException"></exception>

        private Person ReadCustomer(int personId, SqlConnection connection)
        {
            string query = $"Select P.personId, P.firstName,p.lastName,p.email,p.phoneNumber, C.isLoyalClient " +
                $"from Person as P " +
                $"join Customer as C on P.personId = C.personId " +
                $"where P.personId = @personId";

            Person newCustomer = null;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personId", personId);
            VehiclesDataManagerDataAccessLayer vehicleDataManager = new VehiclesDataManagerDataAccessLayer(_databaseConnection);
            ReceiptsDataAccessLayer receiptDataManager = new ReceiptsDataAccessLayer(_databaseConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int personID = Convert.ToInt32(reader["personId"]);
                string firstName = reader["firstName"].ToString();
                string lastName = reader["lastName"].ToString();
                string email = reader["email"].ToString();
                string phoneNumber = reader["phoneNumber"].ToString();
                bool isLoyalClient = Convert.ToBoolean(reader["isLoyalClient"]);
                newCustomer = new Customer(personID, firstName, lastName, email, phoneNumber, isLoyalClient, new CustomerBoughtVehicles(receiptDataManager.GetCustomerBoughtVehicles(personID, connection)), new CustomerFavoriteVehicles(vehicleDataManager.GetCustomerBookmarkedVehicles(personID, connection)), new CustomerSavedVehicles(vehicleDataManager.GetCustomerSavedVehicles(personID, connection)));
                return newCustomer;
            }
            throw new UserNotFound("Customer could not be found. \nPlease, try again later!");
        }

        /// <summary>
        /// This method reads all the information for a staff member based on a given personId (of a member)
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="connection"></param>
        /// <returns>A person object that corresponds to the given person id</returns>
        /// <exception cref="UserNotFound">This exception occurs if there is an issue with reading staff member information</exception>
        /// <exception cref="SqlException"></exception>
        private Person ReadStaffMember(int personId, SqlConnection connection)
        {
            string query = $"Select P.personId, P.firstName,p.lastName,p.email,p.phoneNumber, S.dateStarted, r.roleType " +
                $"from Person as P " +
                $"join StaffMember as S on P.personId = S.personId " +
                $"join StaffMemberRole as r on S.staffMemberRoleId = r.roleId " +
                $"where P.personId = @personId";

            Person newStaffMember = null;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personId", personId);

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                int personID = Convert.ToInt32(reader["personId"]);
                string firstName = reader["firstName"].ToString();
                string lastName = reader["lastName"].ToString();
                string email = reader["email"].ToString();
                string phoneNumber = reader["phoneNumber"].ToString();
                DateTime startingDate = Convert.ToDateTime(reader["dateStarted"]);
                StaffMemberRoles staffRole = (StaffMemberRoles)Enum.Parse(typeof(StaffMemberRoles), reader["roleType"].ToString());
                newStaffMember = new StaffMember(personID, firstName, lastName, email, phoneNumber, startingDate, staffRole);
                return newStaffMember;
            }

            throw new UserNotFound("Staff member could not be found. \nPlease, try again later!");
        }


        /// <summary>
        /// This method reads a person id baed on a given email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="connection"></param>
        /// <returns>A person id that corresponds to a given email</returns>
        /// <exception cref="UserNotFound"></exception>
        private int GetPersonId(string email, SqlConnection connection)
        {
            string query = $"Select personId from Person where email = @email";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", email);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return Convert.ToInt32(reader["personId"]);
            }
            throw new UserNotFound("User could not be found. \nPlease, try again later!");
        }


        /// <summary>
        /// This method promotes a customer from a non loyal client to a loyal client
        /// </summary>
        /// <param name="person_id"></param>
        /// <exception cref="SqlException">Translates into DALException</exception>
        public void PromoteCustomer(int person_id)
        {
            string query = $"Update Customer set isLoyalClient = 1 where personId = @person_id";

            SqlConnection connection = null;
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@person_id", person_id);
                int affectedNumOfRows = command.ExecuteNonQuery();
                {
                    if (affectedNumOfRows == 0)
                    {
                        throw new DALException("Promoting failed");
                    }
                }
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
        /// This method bookmarks a specific vehicle for a given person id
        /// </summary>
        /// <param name="person_id"></param>
        /// <param name="vehicle_id"></param>
        /// <exception cref="SqlException">Translates into a DALException</exception>
        public void BookmarkVehicle(int person_id, int vehicle_id)
        {
            string query = "Insert into BookmarkedVehicle(vehicleId,personId) values(@personId,@vehicleId)";

            SqlConnection connection = null;
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@personId", person_id);
                command.Parameters.AddWithValue("@vehicleId", vehicle_id);
                command.ExecuteNonQuery();
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
        /// This method unbookmarks a sepcific vehicle for a given person id
        /// </summary>
        /// <param name="person_id"></param>
        /// <param name="vehicle_id"></param>
        /// <exception cref="SqlException">Translates into a DALException</exception>
        public void UnBookmarkVehicle(int person_id, int vehicle_id)
        {
            string query = "Delete from BookmarkedVehicle where vehicleId = @vehicleId and personId = @personId";

            SqlConnection connection = null;
            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@vehicleId", vehicle_id);
                command.Parameters.AddWithValue("@personId", person_id);
                command.ExecuteNonQuery();
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
        /// This method reads all secret questions and the corresponding to them id numbers. Mostly is used for combo boxe references
        /// </summary>
        /// <returns>A dictionary containing couples of a secret question id and secret question</returns>
        /// <exception cref="SqlException">Translates into a DALException</exception>
        public Dictionary<int, string> ReadSecretQuestions()
        {
            string query = $"Select * from SecretQuestions";
            Dictionary<int, string> containerForSecretQuestions = new Dictionary<int, string>();
            SqlConnection connection = null;

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    containerForSecretQuestions.Add((int)reader["questionId"], (string)reader["secretQuestion"]);
                }
                return containerForSecretQuestions;
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
        /// This method reads the secret question and the answer to it for a given email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>A tuple containing the secret question and the person's answer to it</returns>
        /// <exception cref="UserNotFound">This exception is thrown if there is an error finding person's secret question and its answer</exception>
        /// <exception cref="SqlException">Translates into a DALException</exception>
        public Tuple<string, string> ReadPersonSecretQuestion(string email)
        {
            string query = $"SELECT sq.secretQuestion AS secret_question, " +
                $"sqa.secretQuestionAnswer AS secret_question_answer " +
                $"FROM Person p " +
                $"JOIN SecretQuestions sq ON p.secretQuestionId = sq.questionId " +
                $"JOIN SecretQuestionAnswer sqa ON p.personId = sqa.personId " +
                $"WHERE p.email = @email; ";
            Tuple<string, string> containerForSecretQuestion;
            SqlConnection connection = null;

            try
            {
                connection = _databaseConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    containerForSecretQuestion = Tuple.Create((string)reader["secret_question"], (string)reader["secret_question_answer"]);
                    return containerForSecretQuestion;
                }
                throw new UserNotFound("User could not be found. \nPlease, try again later.");
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
        /// This method reads up to ten people based on a given page number and role. Filtering criateria can also be provided (used for first anme, last name and email)
        /// </summary>
        /// <param name="role"></param>
        /// <param name="pageNum"></param>
        /// <param name="filteringCriteria"></param>
        /// <returns>A list of people that correspond to the given page number, role and filtering criteria</returns>
        /// <exception cref="SqlException">Translates into a DALException</exception>
        public List<Person> ReadPeopleForPage(string role, int pageNum, string filteringCriteria)
        {
            string query;
            string tableName = role;
            if (string.IsNullOrEmpty(filteringCriteria))
            {
                query = $"Select personId " +
                           $"from {tableName} " +
                           $"ORDER BY personId " +
                           $"OFFSET (@pageNum - 1) * 10 ROWS " +
                           $"FETCH NEXT 11 ROWS ONLY";
            }
            else
            {
                query = $"SELECT p.personId " +
                            $"FROM Person p " +
                            $"WHERE (p.firstName LIKE '%' + @filteringCriteria + '%' " +
                            $"OR p.lastName LIKE '%' + @filteringCriteria + '%' " +
                            $"OR p.email LIKE '%' + @filteringCriteria + '%') " +
                            $"AND EXISTS (" +
                            $"    SELECT 1 " +
                            $"    FROM {tableName} c " +
                            $"    WHERE c.personId = p.personId" +
                            $") " +
                            $"ORDER BY p.personId " +
                            $"OFFSET (@pageNum - 1) * 10 ROWS " +
                            $"FETCH NEXT 11 ROWS ONLY;";
            }
            List<Person> peopleForPage = new List<Person>();
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
                    int personId = (int)reader["personId"];
                    peopleForPage.Add(ReadPerson(personId, null, connection));
                }
                return peopleForPage;
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

    }
}
