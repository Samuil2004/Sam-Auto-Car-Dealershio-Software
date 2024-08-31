using Classes;
using Logic_layer.Enumerations;
using System;
using Logic_layer.Enumerations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTool.ClassTests
{
    [TestClass]
    public class EngineTest
    {
        private Engine engine;
        [TestInitialize]
        public void Setup()
        {
            engine = new Engine(EngineType.Internal_Combustion,"Petrol");
        }

        [TestMethod]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            Assert.AreEqual(EngineType.Internal_Combustion, engine.GetEngineType);
            Assert.AreEqual("Petrol", engine.GetFuelType);
        }
    }
}
