using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer.Payment_Strategies
{
    public class BankTransferPaymentStrategy : PaymentStrategy
    {
        public override decimal CalculateTotalPrice(decimal vehiclePrice)
        {
            decimal totalPrice;
            decimal fee;
            if (vehiclePrice < 1500)
            {
                fee = vehiclePrice * 0.03m + 50;
            }
            else
            {
                fee = vehiclePrice * 0.01m + 10;
            }
            totalPrice = vehiclePrice + fee + vehiclePrice * VAT;
            return totalPrice;
        }
    }
}
