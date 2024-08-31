﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer.Payment_Strategies
{
    public class CreditCardPaymentStrategy : PaymentStrategy
    {
        public override decimal CalculateTotalPrice(decimal vehiclePrice)
        {
            decimal fee = vehiclePrice * 0.02m + 0.50m;
            decimal totalPrice = vehiclePrice + fee + vehiclePrice * VAT;
            return totalPrice;
        }
    }
}
