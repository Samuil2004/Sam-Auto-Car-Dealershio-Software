using Classes;
using Logic_layer.Enumerations;
using LogicLayer;
using Logic_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic_layer.Payment_Strategies;
using TestingTool.TestDB;

namespace TestingTool.ManagerTests
{
    [TestClass]
    public class TestSuggestionsManager
    {
        [TestMethod]
        //Vehicles should be sucessfully reccomended to the user based on his/her favourites
        public void GetSuggestionsForPerson_Success()
        {
            VehicleManager vehicleManager = new VehicleManager(new TestDBVehicle());
            SuggestionsManager suggestionsManager = new SuggestionsManager(vehicleManager, createTestRepo());

            //Based on the data in the Test Data Base for person with id 1, the reccomended vehicles should be
            //11, 12, 14, 18, 20, 17, 19, 15, 16, 21
            List<int> suggestions = new List<int>() { 11, 12, 14, 18, 20, 17, 19, 15, 16, 21 };
            List<Vehicle> suggestedVehicles = new List<Vehicle>();

            foreach (int vehicleId in suggestions)
            {
                suggestedVehicles.Add(vehicleManager.ReadVehicle(vehicleId));
            }
            Assert.IsTrue(suggestedVehicles.SequenceEqual(suggestionsManager.GetSuggestionsForPerson(1, 1)));
        }

        [TestMethod]
        //Vehicles should be sucessfully reccomended to the user even if he/she has no favourites
        public void GetSuggestionsForPerson_Success2()
        {
            VehicleManager vehicleManager = new VehicleManager(new TestDBVehicle());
            SuggestionsManager suggestionsManager = new SuggestionsManager(vehicleManager, createTestRepo());

            //Based on the data in the Test Data Base for person with id 5, the reccomended vehicles should be
            //1,2,3,4,5,6,7,8,9,10 (because this user has no bookmarked vehicles)
            List<int> suggestions = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<Vehicle> suggestedVehicles = new List<Vehicle>();

            foreach (int vehicleId in suggestions)
            {
                suggestedVehicles.Add(vehicleManager.ReadVehicle(vehicleId));
            }
            Assert.IsTrue(suggestedVehicles.SequenceEqual(suggestionsManager.GetSuggestionsForPerson(5, 1)));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]

        //An exception to be thrown in case a non eixsitng page is inputed (if overriden)
        public void GetSuggestionsForPerson_UnSuccess()
        {
            VehicleManager vehicleManager = new VehicleManager(new TestDBVehicle());
            SuggestionsManager suggestionsManager = new SuggestionsManager(vehicleManager, createTestRepo());

            suggestionsManager.GetSuggestionsForPerson(1, -10);
        }

        [TestMethod]
        //Vehicles should be sucessfully reccomended even if invalid personId is passes (in this case it will print the usual catalogue list)
        public void GetSuggestionsForPersonWithNegativeId_Success2()
        {
            VehicleManager vehicleManager = new VehicleManager(new TestDBVehicle());
            SuggestionsManager suggestionsManager = new SuggestionsManager(vehicleManager, createTestRepo());

            //Based on the data in the Test Data Base the reccomended vehicles should be
            //1,2,3,4,5,6,7,8,9,10 (because this user has a non existing id (it maight be overriden))
            List<int> suggestions = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<Vehicle> suggestedVehicles = new List<Vehicle>();

            foreach (int vehicleId in suggestions)
            {
                suggestedVehicles.Add(vehicleManager.ReadVehicle(vehicleId));
            }
            Assert.IsTrue(suggestedVehicles.SequenceEqual(suggestionsManager.GetSuggestionsForPerson(-1, 1)));
        }


        private TestDBSuggestions createTestRepo()
        {
            return new TestDBSuggestions();
        }
    }
}
