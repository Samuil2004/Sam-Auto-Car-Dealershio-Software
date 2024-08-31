using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.InterfacesLL
{
    public interface IVehicleBasicInterfaceLogicLayer
    {
        Vehicle FindVehicle(string selectedString, List<Vehicle> givenList);
        public List<Vehicle> InsertionSortByPublicationDate();
        List<Vehicle> InsertionSortByRating();
        List<Vehicle> ReadAvailableVehiclesForSelectedPage(int pageNum, string filteringCriteria, bool isWeb);
        int ReadNumberOfVehicles();
        Vehicle ReadVehicle(int vehicleId);
        void ReserveVehicle(int vehicleId, int personId);
        void RateVehicle(int vehicleId, int personId, int rating);
        List<Vehicle> FindSearchResults(string category, string year, string engine, int maxPrice, int pageNum, int pageSize);
        int CountResults(string category, string year, string engine, int maxPrice);
        List<Vehicle> GetCustomerBookmarkedVehicles(int personId);
        List<Vehicle> GetCustomerSavedVehicles(int person_id);
    }
}
