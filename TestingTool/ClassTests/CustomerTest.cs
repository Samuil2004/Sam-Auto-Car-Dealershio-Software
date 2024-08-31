using Classes;
using Logic_layer.Payment_Strategies;
using Logic_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTool.TestDB;
using LogicLayer;

namespace TestingTool.ClassTests
{
    [TestClass]
    public class CustomerTest
    {

        [TestMethod]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            VehicleManager vehicleManager = new VehicleManager(new TestDBVehicle());
            CustomerBoughtVehicles cutomerBoughtVehicles1 = new CustomerBoughtVehicles(new List<Receipt>() { new Receipt(vehicleManager.ReadVehicle(27), new BankTransferPaymentStrategy(), DateTime.Today, 9898) });
            CustomerFavoriteVehicles customerFavoriteVehicles1 = new CustomerFavoriteVehicles(new List<Vehicle>() { vehicleManager.ReadVehicle(1), vehicleManager.ReadVehicle(2), vehicleManager.ReadVehicle(3), vehicleManager.ReadVehicle(4), vehicleManager.ReadVehicle(5), vehicleManager.ReadVehicle(6), vehicleManager.ReadVehicle(7), vehicleManager.ReadVehicle(8), vehicleManager.ReadVehicle(9), vehicleManager.ReadVehicle(10) });
            CustomerSavedVehicles customerSavedVehicles1 = new CustomerSavedVehicles(new List<Vehicle>() { vehicleManager.ReadVehicle(25) });
            Customer person = new Customer(1, "Michael", "Jackson", "m.jackson@gmail.com", "098765465", true, cutomerBoughtVehicles1, customerFavoriteVehicles1, customerSavedVehicles1);

            Assert.AreEqual(1, person.GetId);
            Assert.AreEqual("Michael", person.GetFirstName);
            Assert.AreEqual("Jackson", person.GetLastName);
            Assert.AreEqual("m.jackson@gmail.com", person.GetEmail);
            Assert.AreEqual("098765465", person.GetPhoneNumber);
            Assert.IsTrue(person.GetIsLoyalClient);
            CollectionAssert.AreEqual(cutomerBoughtVehicles1.GetBoughVehicles, person.GetBoughtVehicles.GetBoughVehicles);
            CollectionAssert.AreEqual(customerFavoriteVehicles1.GetFavoriteVehicles, person.GetFavoriteVehicles.GetFavoriteVehicles);
            CollectionAssert.AreEqual(customerSavedVehicles1.GetSavedVehicles, person.GetSavedVehicles.GetSavedVehicles);
        }
        [TestMethod]
        public void GetInfo_ReturnsCorrectInfo()
        {
            Customer person = new Customer("Michael", "Jackson", "m.jackson@gmail.com", "098765465", true);

            string info = person.GetIdentifyingInfo;

            string expectedInfo = "m.jackson@gmail.com - Michael Jackson";
            Assert.AreEqual(expectedInfo, info);
        }
    }
}

