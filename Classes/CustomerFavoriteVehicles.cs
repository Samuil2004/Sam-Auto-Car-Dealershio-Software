using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer
{
    public class CustomerFavoriteVehicles
    {
        private List<Vehicle> favoriteVehicles;

        public CustomerFavoriteVehicles(List<Vehicle> listOfFavoriteVehicles)
        {
            this.favoriteVehicles = listOfFavoriteVehicles;
        }

        public List<Vehicle> GetFavoriteVehicles
        {
            get { return  favoriteVehicles; }
        }
    }
}
