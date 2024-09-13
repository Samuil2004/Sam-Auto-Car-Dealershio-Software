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
    /// <summary>
    /// Manages operations related to vehicle receipts, including retrieving sold vehicle details, selling vehicles, and managing page-based listings of sold vehicles.
    /// </summary>
    public class ReceiptsManager : IReceiptsInterfaceLogicLayer
    {
        private readonly IReceiptsInterfaceDataAccessLayer _receiptDataManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptsManager"/> class.
        /// </summary>
        public ReceiptsManager(IReceiptsInterfaceDataAccessLayer receiptDataManager)
        {
            _receiptDataManager = receiptDataManager;
        }

        /// <summary>
        /// Retrieves a list of sold vehicles for a specific page, filtered by criteria.
        /// </summary>
        /// <param name="pageNum">The page number to retrieve.</param>
        /// <param name="filteringCriteria">The criteria to filter by.</param>
        /// <returns>A list of <see cref="Receipt"/> objects for the selected page.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the page number is invalid (less than 0).</exception>
        public List<Receipt> GetSoldVehiclesForSelectedPage(int pageNum, string filteringCriteria)
        {
            if (pageNum < 0)
            {
                throw new ArgumentOutOfRangeException("A non existing page num has been inserted");
            }
            return _receiptDataManager.ReadSoldVehiclesForSelectedPage(pageNum, filteringCriteria);
        }

        /// <summary>
        /// Retrieves details of a sold vehicle by its ID.
        /// </summary>
        /// <param name="vehicle_id">The ID of the vehicle.</param>
        /// <returns>A dictionary with the details of the sold vehicle, including date and description.</returns>
        /// <exception cref="VehicleNotFound">Thrown if the vehicle ID is invalid (less than 0).</exception>
        public Dictionary<DateTime, string> GetSoldVehicleDetails(int vehicle_id)
        {
            if (vehicle_id < 0)
            {
                throw new VehicleNotFound("An invalid vehicle id has been passed.");
            }
            return _receiptDataManager.GetSoldVehicleDetails(vehicle_id);
        }


        /// <summary>
        /// Retrieves details of a sold vehicle by its ID.
        /// </summary>
        /// <param name="vehicle_id">The ID of the vehicle.</param>
        /// <returns>A dictionary with the details of the sold vehicle, including date and description.</returns>
        /// <exception cref="VehicleNotFound">Thrown if the vehicle ID is invalid (less than 0).</exception>
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
