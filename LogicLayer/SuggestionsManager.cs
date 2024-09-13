using Classes;
using DataAccessLayer;
using DataAccessLayer.CustomExceptions;
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
    /// Manages vehicle suggestions for users based on their preferences and bookmarks.
    /// </summary>
    public class SuggestionsManager : ISuggestionsInterfaceLogicLayer
    {
        private readonly ISuggestionsInterfaceDataAccessLayer _suggestionnsDataManager;
        private readonly IVehicleBasicInterfaceLogicLayer _vehicleManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SuggestionsManager"/> class.
        /// </summary>
        public SuggestionsManager(IVehicleBasicInterfaceLogicLayer vehicleManager,ISuggestionsInterfaceDataAccessLayer suggestionsManager)
        {
            _vehicleManager = vehicleManager;
            _suggestionnsDataManager = suggestionsManager;
        }

        /// <summary>
        /// Retrieves a list of vehicle suggestions for a specific person and page number.
        /// </summary>
        /// <param name="personId">The ID of the person for whom to get vehicle suggestions.</param>
        /// <param name="pageNum">The page number for the suggestions.</param>
        /// <returns>A list of recommended vehicles.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the page number is less than 1.</exception>
        public List<Vehicle> GetSuggestionsForPerson(int personId, int pageNum)
        { 
            if (pageNum < 1)
            {
                throw new ArgumentOutOfRangeException("This page number does not exist! Please select an already existing page number from the given ones in the navigation bar!");
            }

            // If no personId is provided or the person has no bookmarks, return a default list of available vehicles.
            if (personId < 1)
            {
                return _vehicleManager.ReadAvailableVehiclesForSelectedPage(pageNum, null, true).Take(10).ToList();
            }
            List<Vehicle> userBookmarkedVehicleIds = _vehicleManager.GetCustomerBookmarkedVehicles(personId);

            //In case the current user has no bookmarked vehicles at all
            if (userBookmarkedVehicleIds.Count() <= 0)
            {
                return _vehicleManager.ReadAvailableVehiclesForSelectedPage(pageNum, null, true).Take(10).ToList();
            }

            Dictionary<int, int> CalculateCommonBookrmarksWithOtherUsers = _suggestionnsDataManager.CalculateCommonBookmarks(personId);
            List<int> suggestedVehiclesIds = new List<int>();
            int totalFetched = 0;
            int startIndex = (pageNum - 1) * 10;
            int endIndex = pageNum * 10;


            // Fetch and filter vehicles based on common bookmarks with other users.
            foreach (var bookmark in CalculateCommonBookrmarksWithOtherUsers)
            {
                List<int> distinctVehicleFetched = _suggestionnsDataManager.GetDistinctVehiclesFromOtherUsers(personId, bookmark.Key);

                // Skip vehicles fetched in previous pages
                if (totalFetched + distinctVehicleFetched.Count <= startIndex)
                {
                    totalFetched += distinctVehicleFetched.Count;
                    continue;
                }

                // Add vehicles within the current page range
                for (int i = 0; i < distinctVehicleFetched.Count; i++)
                {
                    if (totalFetched >= startIndex && totalFetched < endIndex)
                    {
                        suggestedVehiclesIds.Add(distinctVehicleFetched[i]);
                        if (suggestedVehiclesIds.Count >= 10)
                        {
                            break;
                        }
                    }
                    totalFetched++;
                }
                if (suggestedVehiclesIds.Count >= 10)
                {
                    break;
                }
            }

            // Retrieve the recommended vehicles from the list of IDs.
            List<Vehicle> listOfReccomendedVehicles = new List<Vehicle>();
            foreach(int id in suggestedVehiclesIds.Take(10))
            {
                listOfReccomendedVehicles.Add(_vehicleManager.ReadVehicle(id));
            }

            // If fewer than 10 vehicles are recommended, add additional available vehicles that are not part of the already recommended vehicles.
            if (listOfReccomendedVehicles.Count() < 10)
            {
                do
                {
                    foreach(Vehicle vehicle in _vehicleManager.ReadAvailableVehiclesForSelectedPage(pageNum, null, true).Take(10).ToList())
                    {
                        if(!listOfReccomendedVehicles.Contains(vehicle))
                        {
                            listOfReccomendedVehicles.Add(vehicle);
                        }
                    }
                }
                while (listOfReccomendedVehicles.Count() < 10);
            }
            return listOfReccomendedVehicles;
        }
    }
}
