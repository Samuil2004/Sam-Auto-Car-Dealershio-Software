using Azure;
using Logic_layer.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /// <summary>
    /// Represents an engine object with its type and fuel type.
    /// </summary>
    public class Engine
    {
        private EngineType engineType;
        private string fuelType;

        /// <summary>
        /// Initializes a new instance of the <see cref="Engine"/> class.
        /// </summary>
        public Engine(EngineType engineType, string fuelType)
        {
            this.engineType = engineType;
            this.fuelType = fuelType;
        }

        /// <summary>
        /// Gets the type of the engine.
        /// <see cref="EngineType"/> enumeration
        /// </summary>
        public EngineType GetEngineType
        {
            get { return engineType; }
        }

        /// <summary>
        /// Gets the type of fuel used by the engine.
        /// </summary>
        public string GetFuelType
        {
            get { return fuelType; }
        }
    }
}
