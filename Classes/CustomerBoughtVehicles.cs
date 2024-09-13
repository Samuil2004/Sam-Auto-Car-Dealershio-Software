using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer
{
    /// <summary>
    /// Represents the collection of vehicles a customer has purchased, encapsulated within receipts.
    /// </summary>
    public class CustomerBoughtVehicles
    {
        private List<Receipt> boughtVehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerBoughtVehicles"/> class with a list of purchased vehicles.
        /// </summary>

        public CustomerBoughtVehicles(List<Receipt> listOfBoughVehicle)
        {
            this.boughtVehicles = listOfBoughVehicle;
        }

        /// <summary>
        /// Gets the list of purchased vehicles represented by receipts.
        /// </summary>
        public List<Receipt> GetBoughVehicles
        {
            get { return boughtVehicles; }
        }
    }
}
