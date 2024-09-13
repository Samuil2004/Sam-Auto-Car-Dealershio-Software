using DataAccessLayer.InterfacesDAL;
using LogicLayer.InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Manages operations related to statistics, including retrieving vehicle ratings, production years, monthly revenue, and vehicle counts per category.
    /// </summary>
    public class StatisticsManager : IStatisticsInterfaceLogicLayer
    {
        private readonly IStatisticsInterfaceDataAccessLayer _statisticsDataManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsManager"/> class.
        /// </summary>
        public StatisticsManager(IStatisticsInterfaceDataAccessLayer statisticsDataManager)
        {
            _statisticsDataManager = statisticsDataManager;
        }

        /// <summary>
        /// Retrieves a list of vehicle ratings that are above and below the average rating.
        /// </summary>
        /// <returns>A list of two integers representing the ratings that are above and below the average.</returns>
        public List<int> GetAboveAndBelowAverageRatings()
        {
            return _statisticsDataManager.GetAboveAndBelowAverageRatings();
        }

        /// <summary>
        /// Retrieves a dictionary of car production years.
        /// </summary>
        /// <returns>A dictionary where the key is the production year and the value is the count of cars produced in that year.</returns>
        public Dictionary<int, int> GetCarsProductionYear()
        {
            return _statisticsDataManager.GetCarsProductionYear();
        }

        /// <summary>
        /// Retrieves monthly revenue data for the specified year.
        /// </summary>
        /// <param name="currentYear">The year for which to retrieve monthly revenue data.</param>
        /// <returns>A dictionary where the key is the month and the value is the revenue for that month.</returns>
        public Dictionary<int, decimal> GetMontlyRevenue(DateTime currentYear)
        {
            return _statisticsDataManager.GetMontlyRevenue(currentYear);
        }

        /// <summary>
        /// Retrieves the number of vehicles per category.
        /// </summary>
        /// <returns>A list of integers representing the number of vehicles in each category.</returns>
        public List<int> GetNumberOfVehiclePerCategory()
        {
            return _statisticsDataManager.GetNumberOfVehiclePerCategory();
        }
    }
}
