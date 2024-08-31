using Classes;
using DataAccessLayer;
using DataAccessLayer.CustomExceptions;
using Logic_layer;
using Logic_layer.Enumerations;
using Logic_layer.Payment_Strategies;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTool.TestDB;

namespace TestingTool.ManagerTests
{
    [TestClass]
    public class TestPeopleManager
    {

        [TestMethod]
        public void CheckUserForDesktop_Success()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            Person newPerson = new StaffMember(6, "Jecki", "Ricardo", "jecki.jackie@example.com", "345678901", DateTime.Today, StaffMemberRoles.Manager);

            int personId = peopleManager.CreatePerson(newPerson, "Password1", "What's the name of you rfirst pet", "Rockie");
            Person persosn = peopleManager.CheckForUserDesktop("jecki.jackie@example.com", "Password1");
            Assert.AreEqual(newPerson, persosn);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        //Null email and password are given
        public void CheckUserForDesktop_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());

            Person persosn = peopleManager.CheckForUserDesktop(null, null);
        }

        [TestMethod]
        public void CheckUserForWeb_Success()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());

            CustomerBoughtVehicles cutomerBoughtVehicles5 = new CustomerBoughtVehicles(new List<Receipt>() { });
            CustomerFavoriteVehicles customerFavoriteVehicles5 = new CustomerFavoriteVehicles(new List<Vehicle>());
            CustomerSavedVehicles customerSavedVehicles5 = new CustomerSavedVehicles(new List<Vehicle>());
            Person newPerson = new Customer(6, "Rockie", "Jackie", "jecki.jackie@example.com", "345678901", true, cutomerBoughtVehicles5, customerFavoriteVehicles5, customerSavedVehicles5);

            int personId = peopleManager.CreatePerson(newPerson, "Password1", "What's the name of you rfirst pet", "Rockie");

            Person persosn = peopleManager.CheckForUserWeb("jecki.jackie@example.com", "Password1");
            Assert.AreEqual(newPerson, persosn);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        //Null email and password are given
        public void CheckUserForWeb_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());

            Person persosn = peopleManager.CheckForUserWeb(null, null);
        }

        [TestMethod]
        public void CreatePerson_Success()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());

            CustomerBoughtVehicles cutomerBoughtVehicles5 = new CustomerBoughtVehicles(new List<Receipt>() { });
            CustomerFavoriteVehicles customerFavoriteVehicles5 = new CustomerFavoriteVehicles(new List<Vehicle>());
            CustomerSavedVehicles customerSavedVehicles5 = new CustomerSavedVehicles(new List<Vehicle>());
            Person newPerson = new Customer(6, "Rockie", "Jackie", "rockie.jackie@example.com", "345678901", true, cutomerBoughtVehicles5, customerFavoriteVehicles5, customerSavedVehicles5);

            int personId = peopleManager.CreatePerson(newPerson, "Password1", "What's the name of you rfirst pet", "Rockie");
            Assert.AreEqual(6, personId);
        }

        [TestMethod]
        [ExpectedException(typeof(DALException))]
        //Such user already exists
        public void CreatePerson_UserAlreadyExists()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());

            CustomerBoughtVehicles cutomerBoughtVehicles5 = new CustomerBoughtVehicles(new List<Receipt>() { });
            CustomerFavoriteVehicles customerFavoriteVehicles5 = new CustomerFavoriteVehicles(new List<Vehicle>());
            CustomerSavedVehicles customerSavedVehicles5 = new CustomerSavedVehicles(new List<Vehicle>());
            Person newPerson = new Customer(5, "Aretha", "Franklin", "aretha.franklin@example.com", "345678901", true, cutomerBoughtVehicles5, customerFavoriteVehicles5, customerSavedVehicles5);

            peopleManager.CreatePerson(newPerson, "Password1", "What's the name of you rfirst pet", "Rockie");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        //Null values are passed for passowrd and secret question and object
        public void CreatePerson_NullValuesPassed()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());

            Person newPerson = null;
            string password = "";
            string secretQuestion = "";
            string secretQuestionAnswer = "";

            peopleManager.CreatePerson(newPerson, password, secretQuestion, secretQuestionAnswer);
        }


        [TestMethod]
        public void DeletePerson_Success()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());

            peopleManager.DeletePerson(1);
            List<Person> restOfPeople = new List<Person>() { peopleManager.GetUserById(2), peopleManager.GetUserById(3), peopleManager.GetUserById(4), peopleManager.GetUserById(5) };
            CollectionAssert.AreEqual(restOfPeople, peopleManager.GetPeopleForSelectedPage("Customer", 1, null));
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFound))]
        //Negative value for user id is passed
        public void DeletePerson_UnSuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());

            peopleManager.DeletePerson(-10);
        }


        [TestMethod]
        public void IsEmailAvailable_Success()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            bool result = peopleManager.IsEmailAvailable("non@existing.com");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsEmailAvailable_Unsucessfull()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            bool result = peopleManager.IsEmailAvailable("m.jackson@gmail.com");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        //Null value has been passed as email
        public void IsEmailAvailable_NullValuePassed()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            bool result = peopleManager.IsEmailAvailable("");
        }

        [TestMethod]
        public void GetPeopleForSelectedPage_Success()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());

            List<Person> people = new List<Person>() { peopleManager.GetUserById(1), peopleManager.GetUserById(2), peopleManager.GetUserById(3), peopleManager.GetUserById(4), peopleManager.GetUserById(5) };
            CollectionAssert.AreEqual(people, peopleManager.GetPeopleForSelectedPage("Customer", 1, null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        //Null value has been passed and a negative page number
        public void GetPeopleForSelectedPage_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            peopleManager.GetPeopleForSelectedPage("", -10, null);
        }


        [TestMethod]
        [ExpectedException(typeof(UserNotFound))]
        //Null negative id value has been passed
        public void GetCustomerBookmarkedVehicles_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            VehicleManager vehiclemanager = new VehicleManager(new TestDBVehicle());

            vehiclemanager.GetCustomerBookmarkedVehicles(-100);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFound))]
        //Null negative id value has been passed
        public void GetCustomerSavedVehicles_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            VehicleManager vehiclemanager = new VehicleManager(new TestDBVehicle());

            vehiclemanager.GetCustomerSavedVehicles(-100);
        }
        [TestMethod]
        public void GetUserByUsername_Success()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());

            Assert.AreEqual(peopleManager.GetUserById(5), peopleManager.GetUserByUsername("aretha.franklin@example.com"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        //Null value has been passed for email
        public void GetUserByUsername_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());

            Assert.AreEqual(peopleManager.GetUserById(5), peopleManager.GetUserByUsername(null));
        }

        [TestMethod]
        public void GetUserById_Success()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            CustomerBoughtVehicles cutomerBoughtVehicles5 = new CustomerBoughtVehicles(new List<Receipt>() { });
            CustomerFavoriteVehicles customerFavoriteVehicles5 = new CustomerFavoriteVehicles(new List<Vehicle>());
            CustomerSavedVehicles customerSavedVehicles5 = new CustomerSavedVehicles(new List<Vehicle>());
            Person newPerson = new Customer(6, "Rockie", "Jackie", "rockie.jackie@example.com", "345678901", true, cutomerBoughtVehicles5, customerFavoriteVehicles5, customerSavedVehicles5);

            int personId = peopleManager.CreatePerson(newPerson, "Password1", "What's the name of you rfirst pet", "Rockie");

            Assert.AreEqual(peopleManager.GetUserById(6), newPerson);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFound))]
        //A negative id value has been passed
        public void GetUserById_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());

            Assert.AreEqual(peopleManager.GetUserById(-10), peopleManager.GetUserByUsername("aretha.franklin@example.com"));
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFound))]
        //A negative id value for person id has been passed
        public void BookmarkVehicleNegativeUserId_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            peopleManager.BookmarkVehicle(-100, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleNotFound))]
        //A negative id value fore vehicle id has been passed
        public void BookmarkVehicleNegativeVehicleId_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            peopleManager.BookmarkVehicle(10, -10);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFound))]
        //A negative id value for person id has been passed
        public void UnBookmarkVehicleNegativeUserId_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            peopleManager.UnBookmarkVehicle(-100, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleNotFound))]
        //A negative id value fore vehicle id has been passed
        public void UnBookmarkVehicleNegativeVehicleId_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            peopleManager.UnBookmarkVehicle(10, -10);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFound))]
        //A negative id value fore person id has been passed
        public void UpdatePersonNegativePersonId_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            peopleManager.UpdatePerson(-10, "asd", "2343", "asd", "asddd", "asddd");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        //A negative id value fore person id has been passed
        public void UpdatePersonNullValue_Unsuccess()
        {
            PeopleManager peopleManager = new PeopleManager(createTestRepo());
            peopleManager.UpdatePerson(10, "", null, "asd", "asddd", "asddd");
        }

        private TestDBPeople createTestRepo()
        {
            return new TestDBPeople();
        }
    }
}
