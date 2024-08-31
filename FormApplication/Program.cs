using Autofac;
using DataAccessLayer;
using DataAccessLayer.InterfacesDAL;
using LogicLayer;
using LogicLayer.InterfacesLL;

namespace FormApplication
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            DataBaseConnection connection = new DataBaseConnection();
            IPeopleInterfaceDataManagerDataAccessLayer peopleDataManager = new PeopleDataManagerDataAccessLayer(connection);
            IPeopleInterfaceLogicLayer peopleManager = new PeopleManager(peopleDataManager);
            IVehicleInterfaceDataAccessLayer vehiclesDataManager = new VehiclesDataManagerDataAccessLayer(connection);
            IVehicleAdvancedInterfaceLogicLayer vehicleManager = new VehicleManager(vehiclesDataManager);
            IStatisticsInterfaceDataAccessLayer statisticsDataManager = new StatisticsDataAccessLayer(connection);
            IStatisticsInterfaceLogicLayer statisticsManager = new StatisticsManager(statisticsDataManager);
            IReceiptsInterfaceDataAccessLayer receiptsDataManager = new ReceiptsDataAccessLayer(connection);
            IReceiptsInterfaceLogicLayer receiptsManager = new ReceiptsManager(receiptsDataManager);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(peopleManager, vehicleManager,statisticsManager,receiptsManager));
        }
    }
}