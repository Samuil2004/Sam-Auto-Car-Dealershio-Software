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
    public class PeopleManager : IPeopleInterfaceLogicLayer
    {
        private readonly IPeopleInterfaceDataManagerDataAccessLayer _peopleDataManager;
        private PasswordMaskingManager passwordMasker;

        public PeopleManager(IPeopleInterfaceDataManagerDataAccessLayer peopleDataManager)
        {
            _peopleDataManager = peopleDataManager;
        }

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

        public void DeletePerson(int person_id)
        {
            if (person_id < 0)
            {
                throw new UserNotFound("User could not be found. \nTry again!");
            }
            _peopleDataManager.DeletePerson(person_id);
        }

        public bool IsEmailAvailable(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("Email must not be null");
            }
            return _peopleDataManager.IsEmailAvailable(email);
        }

        public List<Person> GetPeopleForSelectedPage(string role, int pageNum, string filteringCriteria)
        {
            if(pageNum < 1 || string.IsNullOrEmpty(role))
            {
                throw new ArgumentNullException("A non existing value has been inserted.");
            }
            return _peopleDataManager.ReadPeopleForPage(role,pageNum, filteringCriteria);
        }
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


        public void PromoteCustomer(int person_id)
        {
            if(person_id < 1)
            {
                throw new UserNotFound("User could not be found \nTry again!");
            }
            _peopleDataManager.PromoteCustomer(person_id);
        }

        //public List<Vehicle> GetCustomerBookmarkedVehicles(int personId)
        //{
        //    if (personId < 1)
        //    {
        //        throw new UserNotFound("User could not be found \nTry again!");
        //    }
        //    return _peopleDataManager.GetCustomerBookmarkedVehicles(personId,null);
        //}

        //public List<Vehicle> GetCustomerSavedVehicles(int personId)
        //{
        //    if (personId < 1)
        //    {
        //        throw new UserNotFound("User could not be found \nTry again!");
        //    }
        //    return _peopleDataManager.GetCustomerSavedVehicles(personId,null);
        //}

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

        public Person? GetUserByUsername(string givenEmail)
        {
            if(string.IsNullOrEmpty(givenEmail))
            {
                throw new ArgumentNullException("A null value has been inserted");
            }
            return _peopleDataManager.ReadPerson(0,givenEmail,null);
        }
        public Person GetUserById(int personId)
        {
            if (personId < 0)
            {
                throw new UserNotFound("A non existing id has been passed");
            }
            return _peopleDataManager.ReadPerson(personId,null,null);
        }
        public Dictionary<int, string> ReadSecretQuestions()
        {
            return _peopleDataManager.ReadSecretQuestions();
        }
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
