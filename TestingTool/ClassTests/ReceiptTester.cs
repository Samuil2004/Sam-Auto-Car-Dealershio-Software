using Classes;
using Logic_layer;
using Logic_layer.Enumerations;
using Logic_layer.Payment_Strategies;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTool.TestDB;

namespace TestingTool.ClassTests
{
    [TestClass]
    public class ReceiptTester
    {
        private Receipt receipt;
        [TestInitialize]
        public void Setup()
        {
            VehicleManager vehicleManager = new VehicleManager(new TestDBVehicle());
            receipt = new Receipt(vehicleManager.ReadVehicle(27), new BankTransferPaymentStrategy(), DateTime.Today, 98998);
        }

        [TestMethod]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            VehicleManager vehicleManager = new VehicleManager(new TestDBVehicle());
            Assert.AreEqual(Convert.ToDecimal(119797.58), receipt.GetCheckoutPrice());
            Assert.AreEqual(98998, receipt.GetSellingPrice);
            Assert.AreEqual(DateTime.Today, receipt.GetSellingDate);
        }

        [TestMethod]
        public void StrategiesPriceCalculations()
        {
            VehicleManager vehicleManager = new VehicleManager(new TestDBVehicle());
            Receipt receipt1 = new Receipt(vehicleManager.ReadVehicle(27), new BankTransferPaymentStrategy(), DateTime.Today, 98998);
            Receipt receipt2 = new Receipt(vehicleManager.ReadVehicle(27), new CashPaymentStrategy(), DateTime.Today, 98998);
            Receipt receipt3 = new Receipt(vehicleManager.ReadVehicle(27), new DebitPaymentStrategy(), DateTime.Today, 98998);
            Receipt receipt4 = new Receipt(vehicleManager.ReadVehicle(27), new CreditCardPaymentStrategy(), DateTime.Today, 98998);

            Assert.AreEqual(Convert.ToDecimal(119797.58), receipt1.GetCheckoutPrice());
            Assert.AreEqual(Convert.ToDecimal(118797.6), receipt2.GetCheckoutPrice());
            Assert.AreEqual(Convert.ToDecimal(121470.846), receipt3.GetCheckoutPrice());
            Assert.AreEqual(Convert.ToDecimal(120778.06), receipt4.GetCheckoutPrice());
        }
    }
}
