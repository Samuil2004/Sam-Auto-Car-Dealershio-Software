using Classes;
using Logic_layer.Enumerations;
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
    public class TestStatisticsManager
    {
        [TestMethod]
        public void GetAboveAndBelowAverageRatings_Success()
        {
            StatisticsManager statisticsManager = new StatisticsManager(createTestRepo());
            List<int> numbersToExpect = new List<int>() { 15,12};
            List<int> aboveAndBelowAverage = statisticsManager.GetAboveAndBelowAverageRatings();
            Assert.IsTrue(numbersToExpect.SequenceEqual(aboveAndBelowAverage));
        }

        [TestMethod]
        public void GetCarsProductionYear_Success()
        {
            StatisticsManager statisticsManager = new StatisticsManager(createTestRepo());
            Dictionary<int, int> productionYearCount = new Dictionary<int, int>();
            productionYearCount.Add(2024, 9);
            productionYearCount.Add(2023, 4);
            productionYearCount.Add(2022, 3);
            productionYearCount.Add(2021, 3);
            productionYearCount.Add(2020, 2);
            productionYearCount.Add(2019, 2);
            productionYearCount.Add(2018, 2);
            productionYearCount.Add(2017, 2);

            Dictionary<int,int> productionYears = statisticsManager.GetCarsProductionYear();
            Assert.IsTrue(productionYearCount.SequenceEqual(productionYears));
        }

        [TestMethod]
        public void GetNumberOfVehiclePerCategory_Success()
        {
            StatisticsManager statisticsManager = new StatisticsManager(createTestRepo());
            List<int> numbersToExpect = new List<int>() { 8,18,1 };
            List<int> vehiclesPerCatergory = statisticsManager.GetNumberOfVehiclePerCategory();
            Assert.IsTrue(numbersToExpect.SequenceEqual(vehiclesPerCatergory));
        }

        [TestMethod]
        public void GetMontlyRevenue_Success()
        {
            StatisticsManager statisticsManager = new StatisticsManager(createTestRepo());
            Dictionary<int, decimal> numbersToExpect = new Dictionary<int, decimal>();
            numbersToExpect.Add(6, 373220);
            Dictionary<int,decimal> monthlyrevenue = statisticsManager.GetMontlyRevenue(DateTime.Now);
            Assert.IsTrue(numbersToExpect.SequenceEqual(numbersToExpect));
        }

        private TestDBStatistics createTestRepo()
        {
            return new TestDBStatistics();
        }

    }
}
