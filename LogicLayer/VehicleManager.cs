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
    /// <summary>
    /// Manages vehicle operations including creation, updates, deletions, and various vehicle-related queries.
    /// </summary>
    public class VehicleManager : IVehicleAdvancedInterfaceLogicLayer, IVehicleBasicInterfaceLogicLayer
    {
        private readonly IVehicleInterfaceDataAccessLayer _vehicleDataManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleManager"/> class.
        /// </summary>
        public VehicleManager(IVehicleInterfaceDataAccessLayer vehicleDataManager)
        {
            _vehicleDataManager = vehicleDataManager;
        }

        /// <summary>
        /// Creates a new vehicle record.
        /// </summary>
        /// <param name="vehicle">The vehicle to be created.</param>
        /// <exception cref="ArgumentNullException">Thrown when the vehicle is null.</exception>
        public void CreateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException("A null value has been passed.\n Null values are not allowed");
            }
            _vehicleDataManager.CreateVehicle(vehicle);
        }

        /// <summary>
        /// Updates an existing vehicle record.
        /// </summary>
        /// <param name="vehicle">The vehicle with updated information.</param>
        /// <exception cref="ArgumentNullException">Thrown when the vehicle is null.</exception>
        public void UpdateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException("A null value has been passed.\n Null values are not allowed");
            }
            _vehicleDataManager.UpdateVehicle(vehicle);
        }

        /// <summary>
        /// Deletes an existing vehicle record.
        /// </summary>
        /// <param name="vehicle">The vehicle to be deleted.</param>
        /// <exception cref="ArgumentNullException">Thrown when the vehicle is null.</exception>
        public void DeleteVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException("A null value has been passed.\n Null values are not allowed");
            }
            _vehicleDataManager.DeleteVehicle(vehicle);
        }

        /// <summary>
        /// Finds a vehicle from a given list based on a selected string identifier.
        /// </summary>
        /// <param name="selectedString">The string identifier for the vehicle.</param>
        /// <param name="givenList">The list of vehicles to search within.</param>
        /// <returns>The matching vehicle, or null if no match is found.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the selected string or list is null.</exception>
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

        /// <summary>
        /// Retrieves the ten most recently added available vehicles, sorted by publication date.
        /// </summary>
        /// <returns>A list of the ten most recently added vehicles.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the retrieval of vehicles fails.</exception>
        public List<Vehicle> InsertionSortByPublicationDate()
        {
            if(_vehicleDataManager.GetTenMostRecentlyAddedAvailableVehicles() == null)
            {
                throw new ArgumentNullException("Retrieval of vehicles failed.");
            }
            return _vehicleDataManager.GetTenMostRecentlyAddedAvailableVehicles();
        }

        /// <summary>
        /// Retrieves the ten top-rated available vehicles, sorted by rating.
        /// </summary>
        /// <returns>A list of the ten top-rated vehicles.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the retrieval of vehicles fails.</exception>
        public List<Vehicle> InsertionSortByRating()
        {
            if( _vehicleDataManager.GetTenTopRatedAvailableVehicles() == null)
            {
                throw new ArgumentNullException("Retrieval of vehicles failed.");
            }
            return _vehicleDataManager.GetTenTopRatedAvailableVehicles();
        }

        /// <summary>
        /// Retrieves the name of the person who saved a specific vehicle.
        /// </summary>
        /// <param name="vehicle_id">The ID of the vehicle.</param>
        /// <returns>The name of the person who saved the vehicle.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the vehicle ID is less than 0.</exception>
        public string GetWhoSavedTheVehicle(int vehicle_id)
        {
            if (vehicle_id < 0)
            {
                throw new ArgumentNullException("An invalid vehicle id has been passed.");
            }
            return _vehicleDataManager.GetWhoSavedTheVehicle(vehicle_id);
        }

        /// <summary>
        /// Retrieves available vehicles for a specific page number with optional filtering criteria.
        /// </summary>
        /// <param name="pageNum">The page number of vehicles to retrieve.</param>
        /// <param name="filteringCriteria">Optional filtering criteria for the vehicles.</param>
        /// <param name="isWeb">Indicates whether the request is from a web interface.</param>
        /// <returns>A list of available vehicles for the specified page.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the page number is less than 0.</exception>
        public List<Vehicle> ReadAvailableVehiclesForSelectedPage(int pageNum, string filteringCriteria, bool isWeb)
        {
            if (pageNum < 0)
            {
                throw new ArgumentOutOfRangeException("A non existing page num has been inserted");
            }
            return _vehicleDataManager.ReadAvailableVehiclesForSelectedPage(pageNum, filteringCriteria, isWeb);
        }

        /// <summary>
        /// Retrieves the total number of vehicles.
        /// </summary>
        /// <returns>The total number of vehicles.</returns>
        public int ReadNumberOfVehicles()
        {
            return _vehicleDataManager.ReadNumberOfVehicles();
        }

        /// <summary>
        /// Retrieves a vehicle by its ID.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to retrieve.</param>
        /// <returns>The vehicle with the specified ID.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the vehicle ID is less than 0.</exception>
        public Vehicle ReadVehicle(int vehicleId)
        {
            if(vehicleId < 0)
            {
                throw new ArgumentOutOfRangeException("A non existing id was passed");
            }
            return _vehicleDataManager.ReadVehicle(vehicleId,null);
        }

        /// <summary>
        /// Reserves a vehicle for a specific person.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to reserve.</param>
        /// <param name="personId">The ID of the person reserving the vehicle.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when either ID is less than 0.</exception>
        public void ReserveVehicle(int vehicleId, int personId)
        {
            if (vehicleId < 0 || personId < 0)
            {
                throw new ArgumentOutOfRangeException("A non existing id was passed");
            }
            _vehicleDataManager.ReserveVehicle(vehicleId, personId);
        }

        /// <summary>
        /// Checks for expired reservations and unreserves the corresponding vehicles.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the retrieval of expired reservations fails.</exception>
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

        /// <summary>
        /// Rates a vehicle given its ID, the ID of the person rating it, and the rating value.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle being rated.</param>
        /// <param name="personId">The ID of the person giving the rating.</param>
        /// <param name="rating">The rating value.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when any of the IDs or the rating value is less than 0.</exception>
        public void RateVehicle(int vehicleId, int personId, int rating)
        {
            if (vehicleId < 0 || personId < 0 || rating < 0)
            {
                throw new ArgumentOutOfRangeException("A non existing value was passed");
            }
            _vehicleDataManager.RateVehicle(vehicleId, personId, rating);
        }

        /// <summary>
        /// Finds search results for vehicles based on various criteria and retrieves the matching vehicles.
        /// </summary>
        /// <param name="category">The category of the vehicle.</param>
        /// <param name="year">The year of the vehicle.</param>
        /// <param name="engine">The engine type of the vehicle.</param>
        /// <param name="maxPrice">The maximum price for the vehicle.</param>
        /// <param name="pageNum">The page number of search results to retrieve.</param>
        /// <param name="pageSize">The number of results per page.</param>
        /// <returns>A list of vehicles matching the search criteria, or null if no results are found.</returns>
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

        /// <summary>
        /// Counts the number of vehicles matching the search criteria. Used for calculating the number of pages
        /// </summary>
        /// <param name="category">The category of the vehicle.</param>
        /// <param name="year">The year of the vehicle.</param>
        /// <param name="engine">The engine type of the vehicle.</param>
        /// <param name="maxPrice">The maximum price for the vehicle.</param>
        /// <returns>The count of vehicles matching the search criteria.</returns>
        public int CountResults(string category, string year, string engine, int maxPrice)
        {
            return _vehicleDataManager.CountResults(category, year, engine, maxPrice);
        }


        /// <summary>
        /// Retrieves vehicle types based on the specified vehicle type.
        /// </summary>
        /// <param name="vehicleType">The type of the vehicle.</param>
        /// <returns>A dictionary of vehicle types and their descriptions.</returns>
        public Dictionary<int, string> ReadVehicleTypes(string vehicleType)
        {
            return _vehicleDataManager.ReadVehicleTypes(vehicleType);
        }

        /// <summary>
        /// Reads the bookmarked as favourite vehicles for a given user
        /// </summary>
        /// <param name="personId">The Id of the user</param>
        /// <returns>A list of bookmarked as favourite vehicles by the user</returns>
        /// <exception cref="UserNotFound">In case a non existing user id is passed</exception>
        public List<Vehicle> GetCustomerBookmarkedVehicles(int personId)
        {
            if (personId < 1)
            {
                throw new UserNotFound("User could not be found \nTry again!");
            }
            return _vehicleDataManager.GetCustomerBookmarkedVehicles(personId, null);
        }

        /// <summary>
        /// Reads the saved for buying vehicles for a given user
        /// </summary>
        /// <param name="personId">The Id of the user</param>
        /// <returns>A list of saved for buying vehicles by the user</returns>
        /// <exception cref="UserNotFound">In case a non existing user id is passed</exception>
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

