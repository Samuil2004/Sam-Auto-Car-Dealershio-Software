using Classes;
using Logic_layer.Enumerations;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestingTool.ClassTests
{
    [TestClass]
    public class CarTester
    {
        private Car car;
        [TestInitialize]
        public void Setup()
        {
            car = new Car(12345, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
                "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 100, DateTime.Today, 1,
                "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                new Engine(EngineType.Electric, "Battery"), "Coupe");
        }

        [TestMethod]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            Assert.AreEqual(12345, car.GetVehicleId);
            Assert.AreEqual(200000, car.GetPrice);
            Assert.AreEqual(TransmissionType.Automatic, car.GetTransmissionType);
            Assert.AreEqual("white", car.GetColor);
            Assert.AreEqual(DateTime.Today.AddDays(-1), car.GetYearOfProduction);
            Assert.AreEqual("BMW", car.GetBrand);
            Assert.AreEqual("i4M", car.GetModel);
            Assert.AreEqual(Condition.New, car.GetCondition);
            Assert.IsFalse(car.GetIsReserved);
            Assert.IsFalse(car.GetIsBought);
            Assert.AreEqual("Coupe", car.GetBodyType);
            Assert.AreEqual(450, car.GetHorsePower);
            Assert.AreEqual(SteeringWheelType.Left_Hand, car.GetSteeringWheel);
            Assert.AreEqual(4, car.GetNumberOfDoors);
            Assert.AreEqual(100, car.GetMileage);
            Assert.AreEqual(DateTime.Today, car.GetPublicationDate);
            Assert.AreEqual(1, car.GetAverageRating);
            Assert.AreEqual("https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800", car.GetImage);
            Assert.AreEqual(EngineType.Electric, car.GetEngine.GetEngineType);
            Assert.AreEqual("Battery", car.GetEngine.GetFuelType);

        }

        //Polymorphism test
        [TestMethod]
        public void LowestPriceVehicleCanGo_ReturnsCorrectPrice()
        {
            Car testCar1 = new Car(12345, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
                "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 20000, DateTime.Today, 4, 
                "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                new Engine(EngineType.Electric, "Battery"), "Coupe");
            Car testCar2 = new Car(12345, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
               "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 50000, DateTime.Today, 4,
               "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
               new Engine(EngineType.Electric, "Battery"), "Coupe");
            Car testCar3 = new Car(12345, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
              "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 120000, DateTime.Today, 4,
              "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
              new Engine(EngineType.Electric, "Battery"), "Coupe");
            Car testCar4 = new Car(12345, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
              "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 5000, DateTime.Today, 4,
              "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
              new Engine(EngineType.Electric, "Battery"), "Coupe");
            Car testCar5 = new Car(12345, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
              "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 10000, DateTime.Today, 4,
              "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
              new Engine(EngineType.Electric, "Battery"), "Coupe");

            // Test for mileage between 10,000 and 30,000
            Assert.AreEqual(200000 * 0.95, testCar1.LowestPriceVehicleCanGo());

            // Test for mileage between 30,000 and 100,000
            Assert.AreEqual(200000 * 0.9, testCar2.LowestPriceVehicleCanGo());

            // Test mileage over 100,000
            Assert.AreEqual(200000 * 0.85, testCar3.LowestPriceVehicleCanGo());

            // Test for mileage less than 10,000
            Assert.AreEqual(200000, testCar4.LowestPriceVehicleCanGo());

            // Test for mileage equal to 10,000
            Assert.AreEqual(200000, testCar5.LowestPriceVehicleCanGo());
        }

    }
}
