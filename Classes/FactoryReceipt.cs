using Classes;
using Logic_layer.Payment_Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer
{
    /// <summary>
    /// This is a factory pattern class that holds all possible strategies from the design pattern for payments
    /// </summary>
    public class FactoryReceipt
    {
        public Receipt CreateReceiptBank(Vehicle selectedVehicle, DateTime sellingDate, decimal sellingPrice)
        {
            return new Receipt(selectedVehicle, new BankTransferPaymentStrategy(), sellingDate, sellingPrice);
        }
        public Receipt CreateReceiptCash(Vehicle selectedVehicle, DateTime sellingDate, decimal sellingPrice)
        {
            return new Receipt(selectedVehicle, new CashPaymentStrategy(), sellingDate, sellingPrice);
        }
        public Receipt CreateReceiptCreditCard(Vehicle selectedVehicle, DateTime sellingDate, decimal sellingPrice)
        {
            return new Receipt(selectedVehicle, new CreditCardPaymentStrategy(), sellingDate, sellingPrice);
        }
        public Receipt CreateReceiptDebit(Vehicle selectedVehicle, DateTime sellingDate, decimal sellingPrice)
        {
            return new Receipt(selectedVehicle, new DebitPaymentStrategy(), sellingDate, sellingPrice);
        }
    }
}
