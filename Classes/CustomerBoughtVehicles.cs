using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer
{
    public class CustomerBoughtVehicles
    {
        private List<Receipt> boughtVehicles;

        public CustomerBoughtVehicles(List<Receipt> listOfBoughVehicle)
        {
            this.boughtVehicles = listOfBoughVehicle;
        }

        public List<Receipt> GetBoughVehicles
        {
            get { return boughtVehicles; }
        }
    }
}
