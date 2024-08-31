using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Logic_layer;
using Microsoft.Data.SqlClient;
namespace DataAccessLayer.InterfacesDAL
{
    public interface IVehicleInterfaceDataAccessLayer
    {
        void CreateVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(Vehicle vehicle);
        string GetWhoSavedTheVehicle(int vehicle_id);
        int ReadNumberOfVehicles();
        List<Vehicle> ReadAvailableVehiclesForSelectedPage(int pageNum, string filteringCriteria, bool isWeb);
        List<Vehicle> GetTenMostRecentlyAddedAvailableVehicles();
        List<Vehicle> GetTenTopRatedAvailableVehicles();
        Vehicle ReadVehicle(int vehicleId, SqlConnection? connection);
        void ReserveVehicle(int vehicleId, int personId);
        List<int> ExpiredReservationsChecker();
        void UnReserveVehicle(int vehicleId);
        void RateVehicle(int vehicleId, int personId, int rating);
        List<int> FindSearchResults(string category, string year, string engine, int maxPrice, int pageNum, int pageSize);
        int CountResults(string category, string year, string engine, int maxPrice);
        Dictionary<int, string> ReadVehicleTypes(string vehicleType);
        List<Vehicle> GetCustomerBookmarkedVehicles(int personId, SqlConnection? connection);
        List<Vehicle> GetCustomerSavedVehicles(int person_id, SqlConnection? connection);
    }
}
