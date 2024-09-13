using Logic_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer.Payment_Strategies
{
    public class DebitPaymentStrategy : PaymentStrategy
    {
        public override decimal CalculateTotalPrice(decimal vehiclePrice)
        {
            decimal fee = vehiclePrice * 0.027m + 0.30m;
            decimal totalPrice = vehiclePrice + fee + vehiclePrice * VAT;
            return totalPrice;
        }
    }
}

