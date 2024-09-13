using Classes;
using Microsoft.Data.SqlClient;
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
    public interface IStatisticsInterfaceDataAccessLayer
    {
        Dictionary<int, decimal> GetMontlyRevenue(DateTime currentYear);
        Dictionary<int, int> GetCarsProductionYear();
        List<int> GetAboveAndBelowAverageRatings();
        List<int> GetNumberOfVehiclePerCategory();
    }
}
