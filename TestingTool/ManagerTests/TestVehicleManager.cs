using Classes;
using DataAccessLayer.CustomExceptions;
using Logic_layer;
using Logic_layer.Enumerations;
using Logic_layer.Payment_Strategies;
using LogicLayer;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TestingTool.TestDB;

namespace TestingTool.ManagerTests
{
    [TestClass]
    public class TestVehicleManager
    {
        [TestMethod]
        public void CreateVehicle_Success()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            Vehicle vehicle = new Car(9999, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
                "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 100, DateTime.Today, 1,
                "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                new Engine(EngineType.Electric, "Battery"), "Coupe");

            vehicleManager.CreateVehicle(vehicle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateVehicle_Unsuccessfull_EmptyObject()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            Vehicle vehicle = null;

            vehicleManager.CreateVehicle(vehicle);
        }

        [TestMethod]
        public void UpdateVehicle_Success()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            Vehicle updatedVehicle = new Car(1, 200000, TransmissionType.Automatic, "grey", DateTime.Today.AddDays(-1),
                        "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 100, DateTime.Today, 1,
                        "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                        new Engine(EngineType.Internal_Combustion, "Gas"), "Coupe");

            vehicleManager.UpdateVehicle(updatedVehicle);

            Assert.AreEqual(updatedVehicle, vehicleManager.ReadVehicle(1));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateVehicle_Unsuccessfull_EmptyObject()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            Vehicle vehicle = null;

            vehicleManager.UpdateVehicle(vehicle);

        }

        [TestMethod]
        public void DeleteVehicle_Success()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());

            vehicleManager.DeleteVehicle(vehicleManager.ReadVehicle(1));
            List<Vehicle> vehiclesForFirstPage = new List<Vehicle>() { vehicleManager.ReadVehicle(2), vehicleManager.ReadVehicle(3), vehicleManager.ReadVehicle(4), vehicleManager.ReadVehicle(5), vehicleManager.ReadVehicle(6), vehicleManager.ReadVehicle(7), vehicleManager.ReadVehicle(8), vehicleManager.ReadVehicle(9), vehicleManager.ReadVehicle(10), vehicleManager.ReadVehicle(11) };

            Assert.IsTrue(vehiclesForFirstPage.SequenceEqual(vehicleManager.ReadAvailableVehiclesForSelectedPage(1, null, false)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteVehicle_Unsuccessfull_EmptyObject()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            Vehicle vehicle = null;

            vehicleManager.DeleteVehicle(vehicle);
        }


        //Searching for a non-existing vehicle
        [TestMethod]
        [ExpectedException(typeof(VehicleNotFound))]
        public void ReadVehicle_UnSuccess_SearchingForNonExistingVehicle()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            vehicleManager.ReadVehicle(999);
        }

        //Trying to search for a vehicle with a negative id (impossible)
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReadVehicle_UnSuccess_VehicleLessThan0()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            vehicleManager.ReadVehicle(-10);
        }

        [TestMethod]
        public void ReadNumberOfVehicles_Success()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            Assert.IsTrue(27 == vehicleManager.ReadNumberOfVehicles());
        }

        [TestMethod]
        public void FindVehicle_Success()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            Vehicle vehicle1 = new Car(2, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
                 "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 100, DateTime.Today, 1,
                 "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                 new Engine(EngineType.Electric, "Battery"), "Coupe");
            Vehicle vehicle26 = new Car(27, 240000, TransmissionType.Automatic, "White", DateTime.Today.AddDays(-7),
               "Lexus", "LS", Condition.Used, false, false, 450, SteeringWheelType.Left_Hand, 4, 120, DateTime.Today, 2,
               "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gasoline"), "Sedan");

            List<Vehicle> vehicles = new List<Vehicle>() { vehicle1, vehicle26 };

            Assert.AreEqual(vehicle1, vehicleManager.FindVehicle(vehicle1.GetIDBrandAndModel, vehicles));
        }

        //Trying to find a vehicle within an empty list
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindVehicle_UnSuccessEmptyListGiven()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            Vehicle vehicle1 = new Car(2, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
                 "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 100, DateTime.Today, 1,
                 "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                 new Engine(EngineType.Electric, "Battery"), "Coupe");
            Vehicle vehicle26 = new Car(27, 240000, TransmissionType.Automatic, "White", DateTime.Today.AddDays(-7),
               "Lexus", "LS", Condition.Used, false, false, 450, SteeringWheelType.Left_Hand, 4, 120, DateTime.Today, 2,
               "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gasoline"), "Sedan");

            List<Vehicle> vehicles = null;
            vehicleManager.FindVehicle(vehicle1.GetIDBrandAndModel, vehicles);
            //Assert.AreEqual(vehicle1, vehicleManager.FindVehicle(vehicle1.GetIDBrandAndModel, vehicles));
        }

        //Trying to find a null identifying within a list
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindVehicle_UnSuccessEmptyObjectGiven()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            Vehicle vehicle1 = new Car(2, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
                 "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 100, DateTime.Today, 1,
                 "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                 new Engine(EngineType.Electric, "Battery"), "Coupe");
            Vehicle vehicle26 = new Car(27, 240000, TransmissionType.Automatic, "White", DateTime.Today.AddDays(-7),
               "Lexus", "LS", Condition.Used, false, false, 450, SteeringWheelType.Left_Hand, 4, 120, DateTime.Today, 2,
               "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gasoline"), "Sedan");
            string identifyingInfo = null;
            List<Vehicle> vehicles = new List<Vehicle>() { vehicle1, vehicle26 };

            vehicleManager.FindVehicle(identifyingInfo, vehicles);
            //Assert.AreEqual(vehicle3, vehicleManager.FindVehicle(vehicle1.GetIDBrandAndModel, vehicles));
        }

        [TestMethod]
        public void InsertionSortByPublicationDate_Success()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            List<Vehicle> firstTenSortedByPublicationDate = new List<Vehicle>() { vehicleManager.ReadVehicle(1), vehicleManager.ReadVehicle(2), vehicleManager.ReadVehicle(3), vehicleManager.ReadVehicle(5), vehicleManager.ReadVehicle(23), vehicleManager.ReadVehicle(24), vehicleManager.ReadVehicle(25), vehicleManager.ReadVehicle(26), vehicleManager.ReadVehicle(27), vehicleManager.ReadVehicle(4) };

            CollectionAssert.AreEqual(firstTenSortedByPublicationDate, vehicleManager.InsertionSortByPublicationDate());
        }

        [TestMethod]
        public void InsertionSortByRating_Success()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            List<Vehicle> firstTenSortedByRating = new List<Vehicle>() { vehicleManager.ReadVehicle(12), vehicleManager.ReadVehicle(19), vehicleManager.ReadVehicle(11), vehicleManager.ReadVehicle(18), vehicleManager.ReadVehicle(3), vehicleManager.ReadVehicle(10), vehicleManager.ReadVehicle(17), vehicleManager.ReadVehicle(9), vehicleManager.ReadVehicle(16), vehicleManager.ReadVehicle(8) };

            CollectionAssert.AreEqual(firstTenSortedByRating, vehicleManager.InsertionSortByRating());
        }


        [TestMethod]
        public void ReadAvailableVehiclesForSelectedPage_SuccessWithFilteringCriteria()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());

            List<Vehicle> vehiclesForFirstPage = new List<Vehicle>() { vehicleManager.ReadVehicle(1), vehicleManager.ReadVehicle(2), vehicleManager.ReadVehicle(6), vehicleManager.ReadVehicle(13), vehicleManager.ReadVehicle(20) };
            string filteringCriteria = "BMW";

            Assert.IsTrue(vehiclesForFirstPage.SequenceEqual(vehicleManager.ReadAvailableVehiclesForSelectedPage(1, filteringCriteria, false)));
        }

        [TestMethod]
        public void ReadAvailableVehiclesForSelectedPage_SuccessWithoutFilteringCriteria()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());

            string filteringCriteria = null;
            List<Vehicle> vehiclesForFirstPage = new List<Vehicle>() { vehicleManager.ReadVehicle(1), vehicleManager.ReadVehicle(2), vehicleManager.ReadVehicle(3), vehicleManager.ReadVehicle(4), vehicleManager.ReadVehicle(5), vehicleManager.ReadVehicle(6), vehicleManager.ReadVehicle(7), vehicleManager.ReadVehicle(8), vehicleManager.ReadVehicle(9), vehicleManager.ReadVehicle(10) };

            Assert.IsTrue(vehiclesForFirstPage.SequenceEqual(vehicleManager.ReadAvailableVehiclesForSelectedPage(1, filteringCriteria, false)));
        }


        //Looking for vehicles from a negative page number
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReadAvailableVehiclesForSelectedPage_UnSuccessPassingNegativePageNum()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            Vehicle vehicle1 = new Car(12345, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
                 "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 100, DateTime.Today, 1,
                 "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                 new Engine(EngineType.Electric, "Battery"), "Coupe");
            Truck vehicle2 = new Truck(123456, 400000, TransmissionType.Manual, "green", DateTime.Today.AddDays(-1),
               "Scania", "P-12", Condition.Used, true, false, 700, 6, 20000, SteeringWheelType.Left_Hand, 50000, DateTime.Today, 10,
               "https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Box");
            Motorcycle vehicle3 = new Motorcycle(12345, 8000, TransmissionType.Manual, "Red", DateTime.Today.AddYears(-1), "Honda", "CBR600RR",
               Condition.Used, false, false, 600, 5000, false, false, DateTime.Today.AddMonths(-6), 6,
               "https://img.freepik.com/free-photo/black-motorcycle-white_1398-276.jpg?t=st=1717153305~exp=1717156905~hmac=9f457fd83b40bd50d02b63536645510157d885c2e7ce4ebf0631ad1b260efae0&w=2000",
               new Engine(EngineType.Hybrid, "Gas"), "Sport");
            Vehicle vehicle4 = new Car(345, 200000, TransmissionType.Manual, "white", DateTime.Today.AddDays(-1),
                 "Mercedes", "ML", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 100, DateTime.Today, 1,
                 "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                 new Engine(EngineType.Electric, "Battery"), "Coupe");
            Motorcycle vehicle5 = new Motorcycle(939, 8000, TransmissionType.Manual, "Red", DateTime.Today.AddYears(-1), "BMW", "R320",
               Condition.Used, false, false, 600, 5000, false, false, DateTime.Today.AddMonths(-6), 6,
               "https://img.freepik.com/free-photo/black-motorcycle-white_1398-276.jpg?t=st=1717153305~exp=1717156905~hmac=9f457fd83b40bd50d02b63536645510157d885c2e7ce4ebf0631ad1b260efae0&w=2000",
               new Engine(EngineType.Hybrid, "Gas"), "Sport");

            List<Vehicle> vehiclesContainingFilteringCriteria = new List<Vehicle>() { vehicle1, vehicle2, vehicle2, vehicle3, vehicle4, vehicle5 };
            string filteringCriteria = null;

            vehicleManager.CreateVehicle(vehicle1);
            vehicleManager.CreateVehicle(vehicle2);
            vehicleManager.CreateVehicle(vehicle3);
            vehicleManager.CreateVehicle(vehicle4);
            vehicleManager.CreateVehicle(vehicle5);

            vehicleManager.ReadAvailableVehiclesForSelectedPage(-100, filteringCriteria, false);
            //Assert.IsTrue(vehiclesContainingFilteringCriteria.SequenceEqual(vehicleManager.ReadAvailableVehiclesForSelectedPage(1, filteringCriteria, false)));
        }

        [TestMethod]
        public void FindSearchResults_Success()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            string year = "2024";
            string engine = "Electric";
            int maxPrice = 100000;

            //These cahracteristics are met only by vehicle 5 and 26 
            List<Vehicle> vehiclesThatMeetFilteringCriteria = new List<Vehicle>() { vehicleManager.ReadVehicle(5), vehicleManager.ReadVehicle(26) };

            CollectionAssert.AreEquivalent(vehiclesThatMeetFilteringCriteria, vehicleManager.FindSearchResults(null, year, engine, maxPrice, 1, 10));
        }

        [TestMethod]
        public void CountSearchResults_Success()
        {
            VehicleManager vehicleManager = new VehicleManager(createTestRepo());
            string year = "2024";
            string engine = "Electric";
            int maxPrice = 100000;

            //These cahracteristics are met only by vehicle 5 and 26 
            Assert.IsTrue(2 == vehicleManager.CountResults(null, year, engine, maxPrice));
        }
        [TestMethod]
        [ExpectedException(typeof(UserNotFound))]

        public void GetCustomerBookmarkedVehicles_Success()
        {
            VehicleManager vehiclemanager = new VehicleManager(createTestRepo());
            vehiclemanager.GetCustomerBookmarkedVehicles(-10);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFound))]
        public void GetCustomerSavedVehicles_Success()
        {
            VehicleManager vehiclemanager = new VehicleManager(new TestDBVehicle());
            vehiclemanager.GetCustomerSavedVehicles(-10);

        }

        private TestDBVehicle createTestRepo()
        {
            return new TestDBVehicle();
        }
    }
}
