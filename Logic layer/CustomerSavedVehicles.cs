using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer
{
    public class CustomerSavedVehicles
    {
        private List<Vehicle> savedVehicles;

        public CustomerSavedVehicles(List<Vehicle> listOfSavedVehicles)
        {
            this.savedVehicles = listOfSavedVehicles;
        }

        public List<Vehicle> GetSavedVehicles
        {
            get { return savedVehicles; }
        }
    }
}
