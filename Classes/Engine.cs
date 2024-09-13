using Azure;
using Logic_layer.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Engine
    {
        private EngineType engineType;
        private string fuelType;

        public Engine(EngineType engineType, string fuelType)
        {
            this.engineType = engineType;
            this.fuelType = fuelType;
        }

        public EngineType GetEngineType
        {
            get { return engineType; }
        }

        public string GetFuelType
        {
            get { return fuelType; }
        }
    }
}
