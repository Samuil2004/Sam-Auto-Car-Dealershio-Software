using Classes;
using DataAccessLayer.InterfacesDAL;
using Logic_layer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTool.TestDB
{
    public class TestDBStatistics : IStatisticsInterfaceDataAccessLayer
    {
        private VehicleManager vehicleManager = new VehicleManager(new TestDBVehicle());
        private ReceiptsManager receiptsManager = new ReceiptsManager(new TestDBReceipts());

        public List<int> GetAboveAndBelowAverageRatings()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.AddRange(vehicleManager.ReadAvailableVehiclesForSelectedPage(1, null, false));
            vehicles.AddRange(vehicleManager.ReadAvailableVehiclesForSelectedPage(2, null, false));
            vehicles.AddRange(vehicleManager.ReadAvailableVehiclesForSelectedPage(3, null, false));

            int totalRating = 0;
            foreach (var vehicle in vehicles)
            {
                totalRating += vehicle.GetAverageRating;
            }
            double averageRating = (double)totalRating / vehicles.Count;

            int aboveAverageCount = 0;
            int belowAverageCount = 0;

            foreach (var vehicle in vehicles)
            {
                if (vehicle.GetAverageRating > averageRating)
                {
                    aboveAverageCount++;
                }
                else if (vehicle.GetAverageRating < averageRating)
                {
                    belowAverageCount++;
                }
            }
            List<int> averageRatings = new List<int>();
            averageRatings.Add(aboveAverageCount);
            averageRatings.Add(belowAverageCount);
            return averageRatings;
        }

        public Dictionary<int, int> GetCarsProductionYear()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.AddRange(vehicleManager.ReadAvailableVehiclesForSelectedPage(1, null, false));
            vehicles.AddRange(vehicleManager.ReadAvailableVehiclesForSelectedPage(2, null, false));
            vehicles.AddRange(vehicleManager.ReadAvailableVehiclesForSelectedPage(3, null, false));
            Dictionary<int, int> productionYearCount = new Dictionary<int, int>();

            foreach (var vehicle in vehicles)
            {
                int year = vehicle.GetYearOfProduction.Year;
                if (productionYearCount.ContainsKey(year))
                {
                    productionYearCount[year]++;
                }
                else
                {
                    productionYearCount[year] = 1;
                }
            }
            return productionYearCount;
        }

        public Dictionary<int, decimal> GetMontlyRevenue(DateTime currentYear)
        {
            List<Receipt> receipts = receiptsManager.GetSoldVehiclesForSelectedPage(1, null);
            Dictionary<int, decimal> monthlyRevenue = new Dictionary<int, decimal>();

            foreach (Receipt receipt in receipts)
            {
                int month = receipt.GetSellingDate.Month;
                decimal revenue = receipt.GetSellingPrice;

                if (monthlyRevenue.ContainsKey(month))
                {
                    monthlyRevenue[month] += revenue;
                }
                else
                {
                    monthlyRevenue[month] = revenue;
                }
            }
            return monthlyRevenue;
        }

        public List<int> GetNumberOfVehiclePerCategory()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.AddRange(vehicleManager.ReadAvailableVehiclesForSelectedPage(1, null, false));
            vehicles.AddRange(vehicleManager.ReadAvailableVehiclesForSelectedPage(2, null, false));
            vehicles.AddRange(vehicleManager.ReadAvailableVehiclesForSelectedPage(3, null, false));
            int carCount = 0;
            int motorcycleCount = 0;
            int truckCount = 0;
            List<int> numberOfVehiclesPerCategory = new List<int>();
            foreach (var vehicle in vehicles)
            {
                if (vehicle is Car)
                {
                    carCount++;
                }
                else if (vehicle is Motorcycle)
                {
                    motorcycleCount++;
                }
                else if (vehicle is Truck)
                {
                    truckCount++;
                }
            }
            numberOfVehiclesPerCategory.Add(carCount);
            numberOfVehiclesPerCategory.Add(motorcycleCount);
            numberOfVehiclesPerCategory.Add(truckCount);
            return numberOfVehiclesPerCategory;
        }
    }
}
