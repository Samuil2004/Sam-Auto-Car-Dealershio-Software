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
        /// <summary>
        /// A Design strategy pattern for calculating the final price if debit card is used for the payment
        /// </summary>
        /// <param name="vehiclePrice">Price of the vehicle, before taxes from the selected payment industry</param>
        /// <returns>The final price after taxes and fees</returns>
        public override decimal CalculateTotalPrice(decimal vehiclePrice)
        {
            decimal fee = vehiclePrice * 0.027m + 0.30m;
            decimal totalPrice = vehiclePrice + fee + vehiclePrice * VAT;
            return totalPrice;
        }
    }
}

