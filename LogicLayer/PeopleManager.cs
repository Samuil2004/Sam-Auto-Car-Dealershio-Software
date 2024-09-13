using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.CustomExceptions;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Drawing.Text;
using DataAccessLayer.InterfacesDAL;
using LogicLayer.InterfacesLL;
using System.Transactions;
namespace LogicLayer
{
    /// <summary>
    /// Manages operations related to people, including user authentication, creation, update, deletion, and other related functions.
    /// </summary>
    public class PeopleManager : IPeopleInterfaceLogicLayer
    {
        private readonly IPeopleInterfaceDataManagerDataAccessLayer _peopleDataManager;
        private PasswordMaskingManager passwordMasker;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleManager"/> class.
        /// </summary>
        public PeopleManager(IPeopleInterfaceDataManagerDataAccessLayer peopleDataManager)
        {
            _peopleDataManager = peopleDataManager;
        }

        /// <summary>
        /// Checks for a user by email and password for desktop applications.
        /// </summary>
        /// <param name="givenEmail">The email of the user.</param>
        /// <param name="givenPassword">The password of the user.</param>
        /// <returns>The <see cref="Person"/> if credentials are valid; otherwise, <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if email or password is null or empty.</exception>
        public Person? CheckForUserDesktop(string givenEmail, string givenPassword)
        {
            if(string.IsNullOrEmpty(givenEmail) || string.IsNullOrEmpty(givenPassword)) 
            {
                throw new ArgumentNullException("A null value has been passed.\n Null values are not allowed");
            }
            Person person = _peopleDataManager.ReadPerson(0,givenEmail,null);
            if (person is StaffMember)
            {
                Tuple<string, string> ContainerForSaltHash = _peopleDataManager.ReadSaltAndHash(givenEmail);
                passwordMasker = new PasswordMaskingManager();
                string testHash = passwordMasker.GenerateSHA256Hash(givenPassword, ContainerForSaltHash.Item2);
                if (ContainerForSaltHash.Item1.Equals(testHash))
                {
                    return person;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Checks for a user by email and password for web applications.
        /// </summary>
        /// <param name="givenEmail">The email of the user.</param>
        /// <param name="givenPassword">The password of the user.</param>
        /// <returns>The <see cref="Person"/> if credentials are valid; otherwise, <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if email or password is null or empty.</exception>
        public Person? CheckForUserWeb(string givenEmail, string givenPassword)
        {
            if (string.IsNullOrEmpty(givenEmail) || string.IsNullOrEmpty(givenPassword))
            {
                throw new ArgumentNullException("A null value has been passed.\n Null values are not allowed");
            }
            Person person = _peopleDataManager.ReadPerson(0,givenEmail,null);
            if (person is Customer)
            {
                Tuple<string, string> ContainerForSaltHash = _peopleDataManager.ReadSaltAndHash(givenEmail);
                passwordMasker = new PasswordMaskingManager();
                string testHash = passwordMasker.GenerateSHA256Hash(givenPassword, ContainerForSaltHash.Item2);
                if (ContainerForSaltHash.Item1.Equals(testHash))
                {
                    return person;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Creates a new person with the specified details and password.
        /// </summary>
        /// <param name="p">The person to create.</param>
        /// <param name="password">The password for the new person.</param>
        /// <param name="secretQuestion">The secret question for password recovery.</param>
        /// <param name="answer">The answer to the secret question.</param>
        /// <returns>The ID of the newly created person.</returns>
        /// <exception cref="ArgumentNullException">Thrown if any of the parameters are null or empty.</exception>
        public int CreatePerson(Person p, string password,string secretQuestion, string answer)
        {
            if(p == null || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(secretQuestion) || string.IsNullOrEmpty(answer)) 
            {
                throw new ArgumentNullException("A null value has been passed.\n Null values are not allowed");
            }
            PasswordMaskingManager passwordMasker = new PasswordMaskingManager();
            int secretQuestionId = 0;
            string salt = passwordMasker.CreateSalt(80);
            string hash = passwordMasker.GenerateSHA256Hash(password, salt);
            foreach (var couple in ReadSecretQuestions())
            {
                if (couple.Value == secretQuestion)
                {
                    secretQuestionId = couple.Key;
                }
            }
            return _peopleDataManager.CreatePerson(p, salt, hash, secretQuestionId, answer);
        }

        /// <summary>
        /// Updates an existing person's details.
        /// </summary>
        /// <param name="personId">The ID of the person to update.</param>
        /// <param name="email">The new email address.</param>
        /// <param name="phoneNumber">The new phone number.</param>
        /// <param name="password">The new password.</param>
        /// <param name="secretQuestion">The new secret question.</param>
        /// <param name="answer">The new answer to the secret question.</param>
        /// <exception cref="UserNotFound">Thrown if the person ID is invalid.</exception>
        /// <exception cref="ArgumentNullException">Thrown if any of the parameters are null or empty.</exception>
        public void UpdatePerson(int personId, string email,string phoneNumber, string password, string secretQuestion, string answer)
        {
            if(personId < 0)
            {
                throw new UserNotFound("User could not be found \nTry again!");
            }
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(secretQuestion) || string.IsNullOrEmpty(answer))
            {
                throw new ArgumentNullException("A null value has been inserted");
            }
            PasswordMaskingManager passwordMasker = new PasswordMaskingManager();
            int secretQuestionId = 0;
            string salt = passwordMasker.CreateSalt(80);
            string hash = passwordMasker.GenerateSHA256Hash(password, salt);
            foreach (var couple in ReadSecretQuestions())
            {
                if (couple.Value == secretQuestion)
                {
                    secretQuestionId = couple.Key;
                }
            }
            _peopleDataManager.UpdatePerson(personId,email,phoneNumber,hash,salt,secretQuestionId, answer);
        }

        /// <summary>
        /// Deletes a person by ID.
        /// </summary>
        /// <param name="person_id">The ID of the person to delete.</param>
        /// <exception cref="UserNotFound">Thrown if the person ID is invalid.</exception>
        public void DeletePerson(int person_id)
        {
            if (person_id < 0)
            {
                throw new UserNotFound("User could not be found. \nTry again!");
            }
            _peopleDataManager.DeletePerson(person_id);
        }

        /// <summary>
        /// Checks if an email address is available for registration.
        /// </summary>
        /// <param name="email">The email address to check.</param>
        /// <returns><c>true</c> if the email is available; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the email is null or empty.</exception>
        public bool IsEmailAvailable(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("Email must not be null");
            }
            return _peopleDataManager.IsEmailAvailable(email);
        }

        /// <summary>
        /// Retrieves a list of people for a specific page, filtered by role and criteria.
        /// </summary>
        /// <param name="role">The role to filter by.</param>
        /// <param name="pageNum">The page number to retrieve.</param>
        /// <param name="filteringCriteria">The criteria to filter by.</param>
        /// <returns>A list of <see cref="Person"/> objects.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the role is null or the page number is invalid.</exception>
        public List<Person> GetPeopleForSelectedPage(string role, int pageNum, string filteringCriteria)
        {
            if(pageNum < 1 || string.IsNullOrEmpty(role))
            {
                throw new ArgumentNullException("A non existing value has been inserted.");
            }
            return _peopleDataManager.ReadPeopleForPage(role,pageNum, filteringCriteria);
        }

        /// <summary>
        /// Finds a person in a given list by their identifier.
        /// </summary>
        /// <param name="Identifier">The identifier of the person to find.</param>
        /// <param name="givenList">The list of people to search through.</param>
        /// <returns>The <see cref="Person"/> if found; otherwise, <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the identifier or list is null.</exception>
        public Person FindPerson(string Identifier,List<Person> givenList)
        {
            if (string.IsNullOrEmpty(Identifier) || givenList == null)
            {
                throw new ArgumentNullException("A null value has been inserted");
            }
            foreach (Person person in givenList)
            {
                if (person.GetIdentifyingInfo.Equals(Identifier))
                {
                    return person;
                }
            }
            return null;
        }


        /// <summary>
        /// Promotes a customer to a loyal customer.
        /// </summary>
        /// <param name="person_id">The ID of the person to promote.</param>
        /// <exception cref="UserNotFound">Thrown if the person ID is invalid.</exception>
        public void PromoteCustomer(int person_id)
        {
            if(person_id < 1)
            {
                throw new UserNotFound("User could not be found \nTry again!");
            }
            _peopleDataManager.PromoteCustomer(person_id);
        }

        /// <summary>
        /// Bookmarks a vehicle as favourite for a user.
        /// </summary>
        /// <param name="person_id">The ID of the user.</param>
        /// <param name="vehicle_id">The ID of the vehicle to bookmark.</param>
        /// <exception cref="UserNotFound">Thrown if the person ID is invalid.</exception>
        /// <exception cref="VehicleNotFound">Thrown if the vehicle ID is invalid.</exception>
        public void BookmarkVehicle(int person_id, int vehicle_id)
        {
            if (person_id < 1)
            {
                throw new UserNotFound("User could not be found \nTry again!");
            }
            if(vehicle_id < 1)
            {
                throw new VehicleNotFound("vehicle could not be found \nTry again!");
            }
            _peopleDataManager.BookmarkVehicle(person_id, vehicle_id);
        }

        /// <summary>
        /// Unbookmarks a vehicle for a user.
        /// </summary>
        /// <param name="person_id">The ID of the user.</param>
        /// <param name="vehicle_id">The ID of the vehicle to unbookmark.</param>
        /// <exception cref="UserNotFound">Thrown if the person ID is invalid.</exception>
        /// <exception cref="VehicleNotFound">Thrown if the vehicle ID is invalid.</exception>
        public void UnBookmarkVehicle(int person_id, int vehicle_id)
        {
            if (person_id < 1)
            {
                throw new UserNotFound("User could not be found \nTry again!");
            }
            if (vehicle_id < 1)
            {
                throw new VehicleNotFound("vehicle could not be found \nTry again!");
            }
            _peopleDataManager.UnBookmarkVehicle(person_id, vehicle_id);
        }


        /// <summary>
        /// Retrieves a user by their email address (username).
        /// </summary>
        /// <param name="givenEmail">The email of the user.</param>
        /// <returns>The <see cref="Person"/> associated with the given email, if found; otherwise, <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the email is null or empty.</exception>
        public Person? GetUserByUsername(string givenEmail)
        {
            if(string.IsNullOrEmpty(givenEmail))
            {
                throw new ArgumentNullException("A null value has been inserted");
            }
            return _peopleDataManager.ReadPerson(0,givenEmail,null);
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <returns>The <see cref="Person"/> associated with the given ID.</returns>
        /// <exception cref="UserNotFound">Thrown if the person ID is invalid.</exception>
        public Person GetUserById(int personId)
        {
            if (personId < 0)
            {
                throw new UserNotFound("A non existing id has been passed");
            }
            return _peopleDataManager.ReadPerson(personId,null,null);
        }

        /// <summary>
        /// Reads the secret questions for password recovery.
        /// </summary>
        /// <returns>A dictionary of secret question IDs and their corresponding questions.</returns>
        public Dictionary<int, string> ReadSecretQuestions()
        {
            return _peopleDataManager.ReadSecretQuestions();
        }


        /// <summary>
        /// Checks a user's secret question and answer for forgotten password recovery.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="secretQuestion">The secret question to check.</param>
        /// <param name="secretAnswer">The answer to the secret question.</param>
        /// <returns>The <see cref="Person"/> if the secret question and answer match; otherwise, <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if email, secret question, or answer is null or empty.</exception>
        public Person? CheckUserSecretQuestionForForgottenPassword(string email, string secretQuestion, string secretAnswer)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(secretQuestion) || string.IsNullOrEmpty(secretAnswer))
            {
                throw new ArgumentNullException("A null value has been inserted");
            }
            Tuple<string, string> realSecretQuestionData = _peopleDataManager.ReadPersonSecretQuestion(email);
            if (secretQuestion.Equals(realSecretQuestionData.Item1))
            {
                if (secretAnswer.Equals(realSecretQuestionData.Item2))
                {
                    return _peopleDataManager.ReadPerson(0,email,null);
                }
            }
            return null;
        }
    }
}
