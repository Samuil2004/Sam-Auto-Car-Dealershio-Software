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
    public class SuggestionsManager : ISuggestionsInterfaceLogicLayer
    {
        private readonly ISuggestionsInterfaceDataAccessLayer _suggestionnsDataManager;
        private readonly IVehicleBasicInterfaceLogicLayer _vehicleManager; 
        public SuggestionsManager(IVehicleBasicInterfaceLogicLayer vehicleManager,ISuggestionsInterfaceDataAccessLayer suggestionsManager)
        {
            _vehicleManager = vehicleManager;
            _suggestionnsDataManager = suggestionsManager;
        }
        public List<Vehicle> GetSuggestionsForPerson(int personId, int pageNum)
        { 
            if (pageNum < 1)
            {
                throw new ArgumentOutOfRangeException("This page number does not exist! Please select an already existing page number from the given ones in the navigation bar!");
            }
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

            List<Vehicle> listOfReccomendedVehicles = new List<Vehicle>();
            foreach(int id in suggestedVehiclesIds.Take(10))
            {
                listOfReccomendedVehicles.Add(_vehicleManager.ReadVehicle(id));
            }
            if(listOfReccomendedVehicles.Count() < 10)
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
