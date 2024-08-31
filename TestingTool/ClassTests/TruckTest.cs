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
    public class TruckTest
    {
        private Truck truck;
        [TestInitialize]
        public void Setup()
        {
            truck = new Truck(12345, 500000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
                "Scania", "P-310", Condition.New, false, false, 700, 6, 60000, SteeringWheelType.Left_Hand, 10000, DateTime.Today, 10, 
                "https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Tracktor_Trailer");
        }

        [TestMethod]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            Assert.AreEqual(12345, truck.GetVehicleId);
            Assert.AreEqual(500000, truck.GetPrice);
            Assert.AreEqual(TransmissionType.Automatic, truck.GetTransmissionType);
            Assert.AreEqual("white", truck.GetColor);
            Assert.AreEqual(DateTime.Today.AddDays(-1), truck.GetYearOfProduction);
            Assert.AreEqual("Scania", truck.GetBrand);
            Assert.AreEqual("P-310", truck.GetModel);
            Assert.AreEqual(Condition.New, truck.GetCondition);
            Assert.IsFalse(truck.GetIsBought);
            Assert.IsFalse(truck.GetIsReserved);
            Assert.AreEqual("Tracktor_Trailer", truck.GetBodyType);
            Assert.AreEqual(700, truck.GetHorsePower);
            Assert.AreEqual(SteeringWheelType.Left_Hand, truck.GetSteeeringWheelType);
            Assert.AreEqual(60000, truck.GetPlayLoadCapacity);
            Assert.AreEqual(6, truck.GetNumberOfAxles);
            Assert.AreEqual(10000, truck.GetMileage);
            Assert.AreEqual("https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800", truck.GetImage);
            Assert.AreEqual(10, truck.GetAverageRating);
            Assert.AreEqual(EngineType.Internal_Combustion, truck.GetEngine.GetEngineType);
            Assert.AreEqual("Gas", truck.GetEngine.GetFuelType);
            Assert.AreEqual("Tracktor_Trailer", truck.GetBodyType);
        }


        //Polymorphism test
        [TestMethod]
        public void LowestPriceVehicleCanGo_ReturnsCorrectPrice()
        {
            Truck testTruck1 = new Truck(123456, 400000, TransmissionType.Manual, "green", DateTime.Today.AddDays(-1),
                "Scania", "P-12", Condition.Used, true, false, 700, 6, 20000, SteeringWheelType.Left_Hand, 50000, DateTime.Today, 10, 
                "https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Box");
            Truck testTruck2 = new Truck(123456, 400000, TransmissionType.Manual, "green", DateTime.Today.AddDays(-1),
                "Scania", "P-12", Condition.Used, true, false, 700, 6, 20000, SteeringWheelType.Left_Hand, 120000, DateTime.Today, 10,
                "https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Box");
            Truck testTruck3 = new Truck(123456, 400000, TransmissionType.Manual, "green", DateTime.Today.AddDays(-1),
                "Scania", "P-12", Condition.Used, true, false, 700, 6, 20000, SteeringWheelType.Left_Hand, 160000, DateTime.Today, 10,
                "https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Box");
            Truck testTruck4 = new Truck(123456, 400000, TransmissionType.Manual, "green", DateTime.Today.AddDays(-1),
                "Scania", "P-12", Condition.Used, true, false, 700, 6, 20000, SteeringWheelType.Left_Hand, 5000, DateTime.Today, 10,
                "https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Box");
            Truck testTruck5 = new Truck(123456, 400000, TransmissionType.Manual, "green", DateTime.Today.AddDays(-1),
                "Scania", "P-12", Condition.Used, true, false, 700, 6, 20000, SteeringWheelType.Left_Hand, 10000, DateTime.Today, 10,
                "https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Box");

            // Test mileage between 10,000 and 100,000 for Concrete type truck
            Assert.AreEqual(400000 * 0.95, testTruck1.LowestPriceVehicleCanGo());

            // Test mileage between 100,000 and 150,000 for Concrete type truck
            Assert.AreEqual(400000 * 0.9, testTruck2.LowestPriceVehicleCanGo());

            // Test mileage over 150,000 for Concrete type truck
            Assert.AreEqual(400000 * 0.85, testTruck3.LowestPriceVehicleCanGo());

            // Test mileage less than 10,000 for Concrete type truck
            Assert.AreEqual(400000, testTruck4.LowestPriceVehicleCanGo());

            // Test mileage equal to 10,000 for Concrete type truck
            Assert.AreEqual(400000, testTruck5.LowestPriceVehicleCanGo());

            Truck testTruck6 = new Truck(123456, 400000, TransmissionType.Manual, "green", DateTime.Today.AddDays(-1),
                "Scania", "P-12", Condition.Used, true, false, 700, 6, 20000, SteeringWheelType.Left_Hand, 200000, DateTime.Today, 10,
                "https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Tracktor_Trailer");
            Truck testTruck7 = new Truck(123456, 400000, TransmissionType.Manual, "green", DateTime.Today.AddDays(-1),
                "Scania", "P-12", Condition.Used, true, false, 700, 6, 20000, SteeringWheelType.Left_Hand, 600000, DateTime.Today, 10,
                "https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Tracktor_Trailer");
            Truck testTruck8 = new Truck(123456, 400000, TransmissionType.Manual, "green", DateTime.Today.AddDays(-1),
                "Scania", "P-12", Condition.Used, true, false, 700, 6, 20000, SteeringWheelType.Left_Hand, 1100000, DateTime.Today, 10,
                "https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Tracktor_Trailer");
            Truck testTruck9 = new Truck(123456, 400000, TransmissionType.Manual, "green", DateTime.Today.AddDays(-1),
                "Scania", "P-12", Condition.Used, true, false, 700, 6, 20000, SteeringWheelType.Left_Hand, 10000, DateTime.Today, 10,
                "https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Tracktor_Trailer");

            // Test for mileage between 100,000 and 500,000 for Other types of truck
            Assert.AreEqual(400000 * 0.95, testTruck6.LowestPriceVehicleCanGo());

            // Test for mileage between 500,000 and 1,000,000 for Other types of truck
            Assert.AreEqual(400000 * 0.9, testTruck7.LowestPriceVehicleCanGo());

            // Test for mileage over 1,000,000 for Other types of truck
            Assert.AreEqual(400000 * 0.85, testTruck8.LowestPriceVehicleCanGo());
        }
    }
}

