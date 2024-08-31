using Classes;
using DataAccessLayer.CustomExceptions;
using DataAccessLayer.InterfacesDAL;
using Logic_layer;
using LogicLayer.InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class ReceiptsManager : IReceiptsInterfaceLogicLayer
    {
        private readonly IReceiptsInterfaceDataAccessLayer _receiptDataManager;
        public ReceiptsManager(IReceiptsInterfaceDataAccessLayer receiptDataManager)
        {
            _receiptDataManager = receiptDataManager;
        }
        public List<Receipt> GetSoldVehiclesForSelectedPage(int pageNum, string filteringCriteria)
        {
            if (pageNum < 0)
            {
                throw new ArgumentOutOfRangeException("A non existing page num has been inserted");
            }
            return _receiptDataManager.ReadSoldVehiclesForSelectedPage(pageNum, filteringCriteria);
        }
        public Dictionary<DateTime, string> GetSoldVehicleDetails(int vehicle_id)
        {
            if (vehicle_id < 0)
            {
                throw new VehicleNotFound("An invalid vehicle id has been passed.");
            }
            return _receiptDataManager.GetSoldVehicleDetails(vehicle_id);
        }
        public void SellVehicle(Receipt receipt, Person buyer, decimal price)
        {
            if (receipt == null || buyer == null || price < 0)
            {
                throw new ArgumentNullException("A null value has been passed.\n Null values are not allowed");
            }
            _receiptDataManager.SellVehicle(receipt, buyer, price);
        }
    }
}
