using Classes;
using Logic_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.InterfacesDAL
{
    /// <summary>
    /// An interface used for Dependency Inversion
    /// </summary>
    public interface IReceiptsInterfaceDataAccessLayer
    {
        List<Receipt> ReadSoldVehiclesForSelectedPage(int pageNum, string filteringCriteria);
        void SellVehicle(Receipt receipt, Person buyer, decimal price);
        Dictionary<DateTime, string> GetSoldVehicleDetails(int vehicle_id);
    }
}
