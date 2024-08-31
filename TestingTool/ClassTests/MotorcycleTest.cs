using Classes;
using Logic_layer.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TestingTool.ClassTests
{
    [TestClass]
    public class MotorcycleTest
    {
        private Motorcycle motorcycle;
        [TestInitialize]
        public void SetUp()
        {
            motorcycle = new Motorcycle(18, 14000, TransmissionType.Manual, "White", DateTime.Today.AddYears(-6), "Suzuki", "Hayabusa",
               Condition.Used, false, false, 850, 7500, false, false, DateTime.Today.AddMonths(-11), 11,
               "https://img.freepik.com/free-photo/black-motorcycle-white_1398-288.jpg",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Sport");

        }

        [TestMethod]
        public void Motorcycle_Properties_InitializedCorrectly()
        {
            Assert.AreEqual(18, motorcycle.GetVehicleId);
            Assert.AreEqual(14000, motorcycle.GetPrice);
            Assert.AreEqual(TransmissionType.Manual, motorcycle.GetTransmissionType);
            Assert.AreEqual("White", motorcycle.GetColor);
            Assert.AreEqual(DateTime.Today.AddYears(-6), motorcycle.GetYearOfProduction);
            Assert.AreEqual("Suzuki", motorcycle.GetBrand);
            Assert.AreEqual("Hayabusa", motorcycle.GetModel);
            Assert.AreEqual(Condition.Used, motorcycle.GetCondition);
            Assert.IsFalse(motorcycle.GetIsBought);
            Assert.IsFalse(motorcycle.GetIsReserved);
            Assert.AreEqual(850, motorcycle.GetCubicCapacity);
            Assert.AreEqual(7500, motorcycle.GetMileage);
            Assert.IsFalse(motorcycle.GetHasWindShield);
            Assert.IsFalse(motorcycle.GetHasABox);
            Assert.AreEqual(DateTime.Today.AddMonths(-11), motorcycle.GetPublicationDate);
            Assert.AreEqual(11, motorcycle.GetAverageRating);
            Assert.AreEqual("https://img.freepik.com/free-photo/black-motorcycle-white_1398-288.jpg", motorcycle.GetImage);
            Assert.AreEqual(EngineType.Internal_Combustion, motorcycle.GetEngine.GetEngineType);
            Assert.AreEqual("Gas", motorcycle.GetEngine.GetFuelType);
            Assert.AreEqual("Sport", motorcycle.GetBodyType);
        }

        //Polymorphism test
        [TestMethod]
        public void LowestPriceVehicleCanGo_ReturnsCorrectPrice()
        {
            Motorcycle testMotorcycle1 = new Motorcycle(12345, 8000, TransmissionType.Manual, "Red", DateTime.Today.AddYears(-1), "Honda", "CBR600RR",
               Condition.Used, false, false, 600, 5000, false, false, DateTime.Today.AddMonths(-6), 6,
               "https://img.freepik.com/free-photo/black-motorcycle-white_1398-288.jpg",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Sport");
            Motorcycle testMotorcycle2 = new Motorcycle(12345, 8000, TransmissionType.Manual, "Red", DateTime.Today.AddYears(-1), "Honda", "CBR600RR",
              Condition.Used, false, false, 600, 12000, false, false, DateTime.Today.AddMonths(-6), 6,
              "https://img.freepik.com/free-photo/black-motorcycle-white_1398-288.jpg",
              new Engine(EngineType.Internal_Combustion, "Gas"), "Sport");
            Motorcycle testMotorcycle3 = new Motorcycle(12345, 8000, TransmissionType.Manual, "Red", DateTime.Today.AddYears(-1), "Honda", "CBR600RR",
              Condition.Used, false, false, 600, 15000, false, false, DateTime.Today.AddMonths(-6), 6,
              "https://img.freepik.com/free-photo/black-motorcycle-white_1398-288.jpg",
              new Engine(EngineType.Internal_Combustion, "Gas"), "Sport");

            // Test for mileage between 2,000 and 10,000 for Sport type motorcycle
            Assert.AreEqual(8000 * 0.95, testMotorcycle1.LowestPriceVehicleCanGo());

            // Test for mileage between 10,000 and 15,000 for Sport type motorcycle
            Assert.AreEqual(8000 * 0.9, testMotorcycle2.LowestPriceVehicleCanGo());

            // Test for mileage over 15,000 for Sport type motorcycle
            Assert.AreEqual(8000 * 0.85, testMotorcycle3.LowestPriceVehicleCanGo());

            Motorcycle testMotorcycle4 = new Motorcycle(12345, 8000, TransmissionType.Manual, "Red", DateTime.Today.AddYears(-1), "Honda", "CBR600RR",
             Condition.Used, false, false, 600, 12000, false, false, DateTime.Today.AddMonths(-6), 6,
             "https://img.freepik.com/free-photo/black-motorcycle-white_1398-288.jpg",
             new Engine(EngineType.Internal_Combustion, "Gas"), "Touring");
            Motorcycle testMotorcycle5 = new Motorcycle(12345, 8000, TransmissionType.Manual, "Red", DateTime.Today.AddYears(-1), "Honda", "CBR600RR",
             Condition.Used, false, false, 600, 16000, false, false, DateTime.Today.AddMonths(-6), 6,
             "https://img.freepik.com/free-photo/black-motorcycle-white_1398-288.jpg",
             new Engine(EngineType.Internal_Combustion, "Gas"), "Touring");
            Motorcycle testMotorcycle6 = new Motorcycle(12345, 8000, TransmissionType.Manual, "Red", DateTime.Today.AddYears(-1), "Honda", "CBR600RR",
            Condition.Used, false, false, 600, 25000, false, false, DateTime.Today.AddMonths(-6), 6,
            "https://img.freepik.com/free-photo/black-motorcycle-white_1398-288.jpg",
            new Engine(EngineType.Internal_Combustion, "Gas"), "Touring");

            // Test for mileage between 2,000 and 15,000 for Touring type of motorcycle
            Assert.AreEqual(8000 * 0.95, testMotorcycle4.LowestPriceVehicleCanGo());

            // Test for mileage between 15,000 and 25,000 for Trouring type of motorcycle
            Assert.AreEqual(8000 * 0.9, testMotorcycle5.LowestPriceVehicleCanGo());

            // Test for mileage over 25,000 for Trouring type of motorcycle
            Assert.AreEqual(8000 * 0.85, testMotorcycle6.LowestPriceVehicleCanGo());
        }
    }
}


