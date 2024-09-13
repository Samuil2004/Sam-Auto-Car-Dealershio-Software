using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer
{
    /// <summary>
    /// Payment strategy main class, which holds the common fields and methods
    /// </summary>
    public abstract class PaymentStrategy
    {
        protected const decimal VAT = 0.2m;

        public abstract decimal CalculateTotalPrice(decimal vehiclePrice);
    }
}
