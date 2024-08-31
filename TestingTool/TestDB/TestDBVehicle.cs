using Classes;
using DataAccessLayer.CustomExceptions;
using DataAccessLayer.InterfacesDAL;
using Logic_layer.Enumerations;
using Logic_layer;
using LogicLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TestingTool.TestDB
{
    public class TestDBVehicle : IVehicleInterfaceDataAccessLayer
    {
        private List<Vehicle> vehicles;

        public TestDBVehicle()
        {
            vehicles = new List<Vehicle>();

            Vehicle vehicle = new Car(1, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
                "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 100, DateTime.Today, 1,
                "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                new Engine(EngineType.Electric, "Battery"), "Coupe");
            Vehicle vehicle1 = new Car(2, 200000, TransmissionType.Automatic, "white", DateTime.Today.AddDays(-1),
                 "BMW", "i4M", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 100, DateTime.Today, 1,
                 "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                 new Engine(EngineType.Electric, "Battery"), "Coupe");
            Vehicle vehicle2 = new Truck(3, 400000, TransmissionType.Manual, "green", DateTime.Today.AddDays(-1),
               "Scania", "P-12", Condition.Used, true, false, 700, 6, 20000, SteeringWheelType.Left_Hand, 50000, DateTime.Today, 10,
               "https://img.freepik.com/free-photo/video-cord-wire-computing-rca_1172-384.jpg?t=st=1717153350~exp=1717156950~hmac=935c4fcc97c92be33cc1a9e6b17c2519b0cdf15257aef064409ffcb4e6369831&w=1800",
               new Engine(EngineType.Internal_Combustion, "Gas"), "Box");
            Vehicle vehicle3 = new Motorcycle(4, 8000, TransmissionType.Manual, "Red", DateTime.Today.AddYears(-1), "Honda", "CBR600RR",
               Condition.Used, false, false, 600, 5000, false, false, DateTime.Today.AddMonths(-6), 6,
               "https://img.freepik.com/free-photo/black-motorcycle-white_1398-276.jpg?t=st=1717153305~exp=1717156905~hmac=9f457fd83b40bd50d02b63536645510157d885c2e7ce4ebf0631ad1b260efae0&w=2000",
               new Engine(EngineType.Hybrid, "Gas"), "Sport");
            Vehicle vehicle4 = new Car(5, 20000, TransmissionType.Manual, "white", DateTime.Today.AddDays(-1),
                 "Mercedes", "ML", Condition.New, false, false, 450, SteeringWheelType.Left_Hand, 4, 100, DateTime.Today, 1,
                 "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                 new Engine(EngineType.Electric, "Battery"), "Coupe");
            Vehicle vehicle5 = new Motorcycle(6, 8000, TransmissionType.Manual, "Red", DateTime.Today.AddYears(-1), "BMW", "R320",
               Condition.Used, false, false, 600, 5000, false, false, DateTime.Today.AddMonths(-6), 6,
               "https://img.freepik.com/free-photo/black-motorcycle-white_1398-276.jpg?t=st=1717153305~exp=1717156905~hmac=9f457fd83b40bd50d02b63536645510157d885c2e7ce4ebf0631ad1b260efae0&w=2000",
               new Engine(EngineType.Hybrid, "Gas"), "Sport");
            Vehicle vehicle6 = new Motorcycle(7, 9000, TransmissionType.Manual, "Black", DateTime.Today.AddYears(-2), "Ducati", "Monster",
                Condition.Used, false, false, 650, 6000, false, false, DateTime.Today.AddMonths(-7), 7,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-277.jpg",
                new Engine(EngineType.Internal_Combustion, "Gas"), "Sport");
            Vehicle vehicle7 = new Motorcycle(8, 8500, TransmissionType.Manual, "Blue", DateTime.Today.AddYears(-3), "Yamaha", "R1",
                Condition.Used, false, false, 700, 5500, false, false, DateTime.Today.AddMonths(-8), 8,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-278.jpg",
                new Engine(EngineType.Internal_Combustion, "Gas"), "Sport");
            Vehicle vehicle8 = new Motorcycle(9, 7500, TransmissionType.Manual, "Green", DateTime.Today.AddYears(-4), "Kawasaki", "Ninja",
                Condition.Used, false, false, 750, 6500, false, false, DateTime.Today.AddMonths(-9), 9,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-279.jpg",
                new Engine(EngineType.Hybrid, "Gas"), "Sport");
            Vehicle vehicle9 = new Motorcycle(10, 7000, TransmissionType.Manual, "Yellow", DateTime.Today.AddYears(-5), "Honda", "CBR",
                Condition.Used, false, false, 800, 7000, false, false, DateTime.Today.AddMonths(-10), 10,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-280.jpg",
                new Engine(EngineType.Internal_Combustion, "Gas"), "Sport");
            Vehicle vehicle10 = new Motorcycle(11, 6500, TransmissionType.Manual, "White", DateTime.Today.AddYears(-6), "Suzuki", "GSX-R",
                Condition.Used, false, false, 850, 7500, false, false, DateTime.Today.AddMonths(-11), 11,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-281.jpg",
                new Engine(EngineType.Hybrid, "Gas"), "Sport");
            Vehicle vehicle11 = new Motorcycle(12, 6000, TransmissionType.Manual, "Orange", DateTime.Today.AddYears(-7), "Harley-Davidson", "Sportster",
                Condition.Used, false, false, 900, 8000, false, false, DateTime.Today.AddMonths(-12), 12,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-282.jpg",
                new Engine(EngineType.Hybrid, "Gas"), "Cruiser");
            Vehicle vehicle12 = new Motorcycle(13, 9500, TransmissionType.Manual, "Red", DateTime.Today.AddYears(-1), "BMW", "S1000RR",
                Condition.Used, false, false, 600, 5000, false, false, DateTime.Today.AddMonths(-6), 6,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-283.jpg",
                new Engine(EngineType.Hybrid, "Gas"), "Sport");
            Vehicle vehicle13 = new Motorcycle(14, 10000, TransmissionType.Manual, "Black", DateTime.Today.AddYears(-2), "Ducati", "Panigale",
                Condition.Used, false, false, 650, 6000, false, false, DateTime.Today.AddMonths(-7), 7,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-284.jpg",
                new Engine(EngineType.Internal_Combustion, "Gas"), "Sport");
            Vehicle vehicle14 = new Motorcycle(15, 11000, TransmissionType.Manual, "Blue", DateTime.Today.AddYears(-3), "Yamaha", "MT-09",
                Condition.Used, false, false, 700, 5500, false, false, DateTime.Today.AddMonths(-8), 8,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-285.jpg",
                new Engine(EngineType.Hybrid, "Gas"), "Sport");
            Vehicle vehicle15 = new Motorcycle(16, 12000, TransmissionType.Manual, "Green", DateTime.Today.AddYears(-4), "Kawasaki", "Z1000",
                Condition.Used, false, false, 750, 6500, false, false, DateTime.Today.AddMonths(-9), 9,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-286.jpg",
                new Engine(EngineType.Hybrid, "Gas"), "Sport");
            Vehicle vehicle16 = new Motorcycle(17, 13000, TransmissionType.Manual, "Yellow", DateTime.Today.AddYears(-5), "Honda", "Fireblade",
                Condition.Used, false, false, 800, 7000, false, false, DateTime.Today.AddMonths(-10), 10,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-287.jpg",
                new Engine(EngineType.Internal_Combustion, "Gas"), "Sport");
            Vehicle vehicle17 = new Motorcycle(18, 14000, TransmissionType.Manual, "White", DateTime.Today.AddYears(-6), "Suzuki", "Hayabusa",
                Condition.Used, false, false, 850, 7500, false, false, DateTime.Today.AddMonths(-11), 11,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-288.jpg",
                new Engine(EngineType.Internal_Combustion, "Gas"), "Sport");
            Vehicle vehicle18 = new Motorcycle(19, 15000, TransmissionType.Manual, "Orange", DateTime.Today.AddYears(-7), "Harley-Davidson", "Street Glide",
                Condition.Used, false, false, 900, 8000, false, false, DateTime.Today.AddMonths(-12), 12,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-289.jpg",
                new Engine(EngineType.Hybrid, "Gas"), "Cruiser");
            Vehicle vehicle19 = new Motorcycle(20, 16000, TransmissionType.Manual, "Red", DateTime.Today.AddYears(-1), "BMW", "K1600",
                Condition.Used, false, false, 600, 5000, false, false, DateTime.Today.AddMonths(-6), 6,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-290.jpg",
                new Engine(EngineType.Hybrid, "Gas"), "Sport");
            Vehicle vehicle20 = new Motorcycle(21, 17000, TransmissionType.Manual, "Black", DateTime.Today.AddYears(-2), "Ducati", "Multistrada",
                Condition.Used, false, false, 650, 6000, false, false, DateTime.Today.AddMonths(-7), 7,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-291.jpg",
                new Engine(EngineType.Internal_Combustion, "Gas"), "Sport");
            Vehicle vehicle21 = new Motorcycle(22, 18000, TransmissionType.Manual, "Blue", DateTime.Today.AddYears(-3), "Yamaha", "Tracer",
                Condition.Used, false, false, 700, 5500, false, false, DateTime.Today.AddMonths(-8), 8,
                "https://img.freepik.com/free-photo/black-motorcycle-white_1398-292.jpg",
                new Engine(EngineType.Internal_Combustion, "Gas"), "Sport");
            Vehicle vehicle22 = new Car(23, 220000, TransmissionType.Automatic, "Blue", DateTime.Today.AddDays(-3),
                "Audi", "A6", Condition.Used, false, false, 380, SteeringWheelType.Left_Hand, 4, 110, DateTime.Today, 3,
                "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                new Engine(EngineType.Internal_Combustion, "Gasoline"), "Sedan");
            Vehicle vehicle23 = new Car(24, 190000, TransmissionType.Automatic, "Silver", DateTime.Today.AddDays(-4),
                "Toyota", "Camry", Condition.New, false, false, 400, SteeringWheelType.Left_Hand, 4, 100, DateTime.Today, 1,
                "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                new Engine(EngineType.Internal_Combustion, "Gasoline"), "Sedan");
            Vehicle vehicle24 = new Car(25, 180000, TransmissionType.Automatic, "Gray", DateTime.Today.AddDays(-5),
                "Honda", "Accord", Condition.Used, false, false, 370, SteeringWheelType.Left_Hand, 4, 95, DateTime.Today, 2,
                "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                new Engine(EngineType.Internal_Combustion, "Gasoline"), "Sedan");
            Vehicle vehicle25 = new Car(26, 23000, TransmissionType.Automatic, "Red", DateTime.Today.AddDays(-6),
                "Tesla", "Model S", Condition.New, false, false, 500, SteeringWheelType.Left_Hand, 4, 110, DateTime.Today, 1,
                "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                new Engine(EngineType.Electric, "Battery"), "Sedan");
            Vehicle vehicle26 = new Car(27, 240000, TransmissionType.Automatic, "White", DateTime.Today.AddDays(-7),
                "Lexus", "LS", Condition.Used, false, false, 450, SteeringWheelType.Left_Hand, 4, 120, DateTime.Today, 2,
                "https://img.freepik.com/free-photo/3d-car-with-simple-background_23-2150796880.jpg?t=st=1717077646~exp=1717081246~hmac=e5e3e31866337a6f69ad74c966060145bb9a50ae9bdb4fcac0073783f3c7f28b&w=1800",
                new Engine(EngineType.Internal_Combustion, "Gasoline"), "Sedan");
            vehicles.AddRange(new List<Vehicle>
            {
                vehicle, vehicle1, vehicle2, vehicle3, vehicle4, vehicle5, vehicle6, vehicle7, vehicle8,
                vehicle9, vehicle10, vehicle11, vehicle12, vehicle13, vehicle14, vehicle15, vehicle16,
                vehicle17, vehicle18, vehicle19, vehicle20, vehicle21, vehicle22, vehicle23, vehicle24,
                vehicle25, vehicle26
            });
        }
        public int CountResults(string category, string year, string engine, int maxPrice)
        {
            List<int> vehicleIds = new List<int>();
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.GetYearOfProduction.ToString().Contains(year) && vehicle.GetEngine.GetEngineType.ToString().Equals(engine) && vehicle.GetPrice <= maxPrice)
                {
                    vehicleIds.Add(vehicle.GetVehicleId);
                }
            }
            return vehicleIds.Count();
        }

        public void CreateVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            vehicles.Remove(vehicle);
        }

        public List<int> ExpiredReservationsChecker()
        {
            throw new NotImplementedException();
        }

        public List<int> FindSearchResults(string category, string year, string engine, int maxPrice, int pageNum, int pageSize)
        {
            List<int> vehicleIds = new List<int>();
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.GetYearOfProduction.ToString().Contains(year) && vehicle.GetEngine.GetEngineType.ToString().Equals(engine) && vehicle.GetPrice <= maxPrice)
                {
                    vehicleIds.Add(vehicle.GetVehicleId);
                }
            }
            return vehicleIds;
        }

        public List<Vehicle> GetTenMostRecentlyAddedAvailableVehicles()
        {
            int n = vehicles.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (vehicles[j].GetPublicationDate < vehicles[j + 1].GetPublicationDate)
                    {
                        Vehicle temp = vehicles[j];
                        vehicles[j] = vehicles[j + 1];
                        vehicles[j + 1] = temp;
                    }
                }
            }
            return vehicles.Take(10).ToList();
        }

        public List<Vehicle> GetTenTopRatedAvailableVehicles()
        {
            int n = vehicles.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (vehicles[j].GetAverageRating < vehicles[j + 1].GetAverageRating)
                    {
                        Vehicle temp = vehicles[j];
                        vehicles[j] = vehicles[j + 1];
                        vehicles[j + 1] = temp;
                    }
                }
            }
            return vehicles.Take(10).ToList();
        }

        public string GetWhoSavedTheVehicle(int vehicle_id)
        {
            throw new NotImplementedException();
        }

        public void RateVehicle(int vehicleId, int personId, int rating)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> ReadAvailableVehiclesForSelectedPage(int pageNum, string filteringCriteria, bool isWeb)
        {
            List<Vehicle> vehiclesForPage = new List<Vehicle>();
            int startIndex = (pageNum - 1) * 10;
            int endIndex = pageNum * 10;

            if (string.IsNullOrEmpty(filteringCriteria))
            {
                if(vehicles.Count() < endIndex)
                {
                    endIndex = vehicles.Count();
                }
                for (int i = startIndex; i < endIndex; i++)
                {
                    vehiclesForPage.Add(vehicles[i]);
                }
            }
            else
            {
                List<Vehicle> vehiclesMatchingFilteringCriteria = new List<Vehicle>();
                foreach (Vehicle vehicle in vehicles)
                {
                    if (vehicle.GetVehicleId.ToString() == filteringCriteria || vehicle.GetBrand.Contains(filteringCriteria) || vehicle.GetModel.Contains(filteringCriteria))
                    {
                        vehiclesMatchingFilteringCriteria.Add(ReadVehicle(vehicle.GetVehicleId, null));
                    }
                }
                if (vehiclesMatchingFilteringCriteria.Count() < endIndex)
                {
                    endIndex = vehiclesMatchingFilteringCriteria.Count();
                }
                for (int i = startIndex; i < endIndex; i++)
                {
                    vehiclesForPage.Add(vehiclesMatchingFilteringCriteria[i]);
                }
            }

            return vehiclesForPage;
        }

        public int ReadNumberOfVehicles()
        {
            return vehicles.Count();
        }

        public Vehicle ReadVehicle(int vehicleId, SqlConnection? connection)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.GetVehicleId == vehicleId)
                {
                    return vehicle;
                }
            }
            throw new VehicleNotFound("Vehcile can not be found");
        }

        public Dictionary<int, string> ReadVehicleTypes(string vehicleType)
        {
            throw new NotImplementedException();
        }

        public void ReserveVehicle(int vehicleId, int personId)
        {
            throw new NotImplementedException();
        }

        public void UnReserveVehicle(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            foreach (Vehicle vehicle1 in vehicles)
            {
                if (vehicle1.GetVehicleId == vehicle.GetVehicleId)
                {
                    vehicles.Remove(vehicle1);
                    vehicles.Add(vehicle);
                    break;
                }
            }
        }
        public List<Vehicle> GetCustomerBookmarkedVehicles(int personId, SqlConnection? connection)
        {
            PeopleManager peopleManager = new PeopleManager(new TestDBPeople());
            return ((Customer)peopleManager.GetUserById(personId)).GetFavoriteVehicles.GetFavoriteVehicles;
        }

        public List<Vehicle> GetCustomerSavedVehicles(int person_id, SqlConnection? connection)
        {
            PeopleManager peopleManager = new PeopleManager(new TestDBPeople());

            return ((Customer)(Customer)peopleManager.GetUserById(person_id)).GetSavedVehicles.GetSavedVehicles;
        }
    }
}
