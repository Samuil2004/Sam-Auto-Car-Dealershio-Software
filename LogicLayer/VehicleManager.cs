using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Classes;
using DataAccessLayer;
using DataAccessLayer.CustomExceptions;
using DataAccessLayer.InterfacesDAL;
using Logic_layer;
using LogicLayer.InterfacesLL;
using Microsoft.Data.SqlClient;

namespace LogicLayer
{
    public class VehicleManager : IVehicleAdvancedInterfaceLogicLayer, IVehicleBasicInterfaceLogicLayer
    {
        private readonly IVehicleInterfaceDataAccessLayer _vehicleDataManager;

        public VehicleManager(IVehicleInterfaceDataAccessLayer vehicleDataManager)
        {
            _vehicleDataManager = vehicleDataManager;
        }
        public void CreateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException("A null value has been passed.\n Null values are not allowed");
            }
            _vehicleDataManager.CreateVehicle(vehicle);
        }


        public void UpdateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException("A null value has been passed.\n Null values are not allowed");
            }
            _vehicleDataManager.UpdateVehicle(vehicle);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException("A null value has been passed.\n Null values are not allowed");
            }
            _vehicleDataManager.DeleteVehicle(vehicle);
        }

        public Vehicle FindVehicle(string selectedString, List<Vehicle> givenList)
        {
            if(string.IsNullOrEmpty(selectedString) || givenList == null) 
            {
                throw new ArgumentNullException("A null value has been passed.");
            }
            foreach (var vehicle in givenList)
            {
                if (vehicle.GetIDBrandAndModel.Equals(selectedString))
                {
                    return vehicle;
                }
            }
            return null;
        }

        public List<Vehicle> InsertionSortByPublicationDate()
        {
            if(_vehicleDataManager.GetTenMostRecentlyAddedAvailableVehicles() == null)
            {
                throw new ArgumentNullException("Retrieval of vehicles failed.");
            }
            return _vehicleDataManager.GetTenMostRecentlyAddedAvailableVehicles();
        }

        public List<Vehicle> InsertionSortByRating()
        {
            if( _vehicleDataManager.GetTenTopRatedAvailableVehicles() == null)
            {
                throw new ArgumentNullException("Retrieval of vehicles failed.");
            }
            return _vehicleDataManager.GetTenTopRatedAvailableVehicles();
        }

        public string GetWhoSavedTheVehicle(int vehicle_id)
        {
            if (vehicle_id < 0)
            {
                throw new ArgumentNullException("An invalid vehicle id has been passed.");
            }
            return _vehicleDataManager.GetWhoSavedTheVehicle(vehicle_id);
        }
        public List<Vehicle> ReadAvailableVehiclesForSelectedPage(int pageNum, string filteringCriteria, bool isWeb)
        {
            if (pageNum < 0)
            {
                throw new ArgumentOutOfRangeException("A non existing page num has been inserted");
            }
            return _vehicleDataManager.ReadAvailableVehiclesForSelectedPage(pageNum, filteringCriteria, isWeb);
        }


        public int ReadNumberOfVehicles()
        {
            return _vehicleDataManager.ReadNumberOfVehicles();
        }

        public Vehicle ReadVehicle(int vehicleId)
        {
            if(vehicleId < 0)
            {
                throw new ArgumentOutOfRangeException("A non existing id was passed");
            }
            return _vehicleDataManager.ReadVehicle(vehicleId,null);
        }

        public void ReserveVehicle(int vehicleId, int personId)
        {
            if (vehicleId < 0 || personId < 0)
            {
                throw new ArgumentOutOfRangeException("A non existing id was passed");
            }
            _vehicleDataManager.ReserveVehicle(vehicleId, personId);
        }

        public void ExpiredReservationsChecker()
        {
            if(_vehicleDataManager.ExpiredReservationsChecker == null)
            {
                throw new ArgumentNullException("Retrieval of vehicles failed.");
            }
            foreach (int id in _vehicleDataManager.ExpiredReservationsChecker())
            {
                _vehicleDataManager.UnReserveVehicle(id);
            }
        }

        public void RateVehicle(int vehicleId, int personId, int rating)
        {
            if (vehicleId < 0 || personId < 0 || rating < 0)
            {
                throw new ArgumentOutOfRangeException("A non existing value was passed");
            }
            _vehicleDataManager.RateVehicle(vehicleId, personId, rating);
        }
        public List<Vehicle> FindSearchResults(string category, string year, string engine, int maxPrice, int pageNum, int pageSize)
        {
            if (_vehicleDataManager.FindSearchResults(category, year, engine, maxPrice, pageNum, pageSize) != null)
            {
                List<Vehicle> results = new List<Vehicle>();
                foreach (int Id in _vehicleDataManager.FindSearchResults(category, year, engine, maxPrice, pageNum, pageSize))
                {
                    results.Add(ReadVehicle(Id));
                }
                return results;
            }
            return null;
        }

        public int CountResults(string category, string year, string engine, int maxPrice)
        {
            return _vehicleDataManager.CountResults(category, year, engine, maxPrice);
        }

        public Dictionary<int, string> ReadVehicleTypes(string vehicleType)
        {
            return _vehicleDataManager.ReadVehicleTypes(vehicleType);
        }

        public List<Vehicle> GetCustomerBookmarkedVehicles(int personId)
        {
            if (personId < 1)
            {
                throw new UserNotFound("User could not be found \nTry again!");
            }
            return _vehicleDataManager.GetCustomerBookmarkedVehicles(personId, null);
        }

        public List<Vehicle> GetCustomerSavedVehicles(int personId)
        {
            if (personId < 1)
            {
                throw new UserNotFound("User could not be found \nTry again!");
            }
            return _vehicleDataManager.GetCustomerSavedVehicles(personId, null);
        }

    }
}

