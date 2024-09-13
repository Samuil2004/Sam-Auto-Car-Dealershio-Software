using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer
{
    /// <summary>
    /// Represents a collection of vehicles marked as favorite by a customer.
    /// </summary>
    public class CustomerFavoriteVehicles
    {
        private List<Vehicle> favoriteVehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerFavoriteVehicles"/> class with a list of favorite vehicles.
        /// </summary>
        public CustomerFavoriteVehicles(List<Vehicle> listOfFavoriteVehicles)
        {
            this.favoriteVehicles = listOfFavoriteVehicles;
        }

        /// <summary>
        /// Gets the list of vehicles marked as favorite by the customer.
        /// </summary>
        public List<Vehicle> GetFavoriteVehicles
        {
            get { return  favoriteVehicles; }
        }
    }
}
