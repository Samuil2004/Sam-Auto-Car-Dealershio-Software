using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer.Payment_Strategies
{
    public class CashPaymentStrategy : PaymentStrategy
    {
        public override decimal CalculateTotalPrice(decimal vehiclePrice)
        {
            decimal totalPrice = vehiclePrice + vehiclePrice * VAT;
            return totalPrice;
        }
    }
}

