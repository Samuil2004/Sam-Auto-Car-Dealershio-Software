using Classes;
using DataAccessLayer.CustomExceptions;
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

namespace TestingTool.ManagerTests
{
    [TestClass]
    public class TestReceiptsManager
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        //A page number lower than 0 is given
        public void GetSoldVehiclesForSelectedPage_UnSuccess()
        {
            ReceiptsManager receiptManager = new ReceiptsManager(createTestRepo());

            receiptManager.GetSoldVehiclesForSelectedPage(-10, null);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleNotFound))]
        //A vehicle id lower than 0 is inputted
        public void GetSoldVehicleDetails_UnSuccess()
        {
            ReceiptsManager receiptManager = new ReceiptsManager(createTestRepo());

            receiptManager.GetSoldVehicleDetails(-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        //A null value has been passed for hte receipt and buyer and a negative price has been inserted
        public void SellVehicle_UnSuccess()
        {
            ReceiptsManager receiptManager = new ReceiptsManager(createTestRepo());

            receiptManager.SellVehicle(null, null, -10);
        }


        private TestDBReceipts createTestRepo()
        {
            return new TestDBReceipts();
        }
    }
}
