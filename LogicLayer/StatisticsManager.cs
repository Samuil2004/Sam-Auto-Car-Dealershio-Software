using DataAccessLayer.InterfacesDAL;
using LogicLayer.InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class StatisticsManager : IStatisticsInterfaceLogicLayer
    {
        private readonly IStatisticsInterfaceDataAccessLayer _statisticsDataManager;
        public StatisticsManager(IStatisticsInterfaceDataAccessLayer statisticsDataManager)
        {
            _statisticsDataManager = statisticsDataManager;
        }

        public List<int> GetAboveAndBelowAverageRatings()
        {
            return _statisticsDataManager.GetAboveAndBelowAverageRatings();
        }

        public Dictionary<int, int> GetCarsProductionYear()
        {
            return _statisticsDataManager.GetCarsProductionYear();
        }

        public Dictionary<int, decimal> GetMontlyRevenue(DateTime currentYear)
        {
            return _statisticsDataManager.GetMontlyRevenue(currentYear);
        }

        public List<int> GetNumberOfVehiclePerCategory()
        {
            return _statisticsDataManager.GetNumberOfVehiclePerCategory();
        }
    }
}
