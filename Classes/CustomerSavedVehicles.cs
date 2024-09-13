using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer
{
    /// <summary>
    /// Represents a collection of vehicles saved for buying by a customer.
    /// </summary>
    public class CustomerSavedVehicles
    {
        private List<Vehicle> savedVehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerSavedVehicles"/> class with a list of saved vehicles.
        /// </summary>
        public CustomerSavedVehicles(List<Vehicle> listOfSavedVehicles)
        {
            this.savedVehicles = listOfSavedVehicles;
        }

        /// <summary>
        /// Gets the list of vehicles saved by the customer.
        /// </summary>
        public List<Vehicle> GetSavedVehicles
        {
            get { return savedVehicles; }
        }
    }
}
