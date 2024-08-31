using Classes;
using Logic_layer;

namespace LogicLayer.InterfacesLL
{
    public interface IVehicleAdvancedInterfaceLogicLayer
    {
        void CreateVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(Vehicle vehicle);
        Vehicle FindVehicle(string selectedString, List<Vehicle> givenList);
        string GetWhoSavedTheVehicle(int vehicle_id);
        List<Vehicle> ReadAvailableVehiclesForSelectedPage(int pageNum, string filteringCriteria, bool isWeb);
        Vehicle ReadVehicle(int vehicleId);
        void ExpiredReservationsChecker();
        Dictionary<int, string> ReadVehicleTypes(string vehicleType);
    }
}
