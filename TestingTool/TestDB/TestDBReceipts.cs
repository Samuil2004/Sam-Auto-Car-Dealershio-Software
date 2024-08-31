using Classes;
using DataAccessLayer.InterfacesDAL;
using Logic_layer;
using Logic_layer.Payment_Strategies;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTool.TestDB
{
    public class TestDBReceipts : IReceiptsInterfaceDataAccessLayer
    {
        private List<Receipt> receipts;
        private VehicleManager vehicleManager = new VehicleManager(new TestDBVehicle());
        public TestDBReceipts()
        {
            receipts = new List<Receipt>();
            receipts.Add(new Receipt(vehicleManager.ReadVehicle(1), new BankTransferPaymentStrategy(), DateTime.Today, 1989));
            receipts.Add(new Receipt(vehicleManager.ReadVehicle(2), new CreditCardPaymentStrategy(), DateTime.Today, 2343));
            receipts.Add(new Receipt(vehicleManager.ReadVehicle(3), new DebitPaymentStrategy(), DateTime.Today, 23543));
            receipts.Add(new Receipt(vehicleManager.ReadVehicle(4), new CashPaymentStrategy(), DateTime.Today, 345345));
        }

        public Dictionary<DateTime, string> GetSoldVehicleDetails(int vehicle_id)
        {
            throw new NotImplementedException();
        }

        public List<Receipt> ReadSoldVehiclesForSelectedPage(int pageNum, string filteringCriteria)
        {
            List<Receipt> receiptsForPAgewithFilteringCriteria = new List<Receipt>();
            if (string.IsNullOrEmpty(filteringCriteria))
            {
                return receipts.Skip((pageNum - 1) * 10).Take(10).ToList();
            }
            else
            {
                foreach (Receipt receipt in receipts)
                {
                    if (receipt.GetVehicle.GetIDBrandAndModel.Contains(filteringCriteria))
                    {
                        receiptsForPAgewithFilteringCriteria.Add(receipt);
                    }
                }
                return receiptsForPAgewithFilteringCriteria.Skip((pageNum - 1) * 10).Take(10).ToList();
            }

        }

        public void SellVehicle(Receipt receipt, Person buyer, decimal price)
        {
            receipts.Add(receipt);
        }
    }
}
