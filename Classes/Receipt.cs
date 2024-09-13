using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer
{
    public class Receipt
    {
        private Vehicle selectedVehicle;
        private PaymentStrategy paymentStrategy;
        private DateTime dateOfSelling;
        private decimal sellingPrice;

        public Receipt(Vehicle SelectedVehicle, PaymentStrategy SelectedPaymentMethod,DateTime DateOfSelling, decimal SellingPrice)
        {
            this.selectedVehicle = SelectedVehicle;
            this.paymentStrategy = SelectedPaymentMethod;
            this.dateOfSelling = DateOfSelling;
            this.sellingPrice = SellingPrice;
        }
        public decimal GetCheckoutPrice()
        {
            return paymentStrategy.CalculateTotalPrice(sellingPrice);
        }
        public Vehicle GetVehicle
        {
            get { return selectedVehicle; }
        }

        public decimal GetSellingPrice
        {
            get { return sellingPrice; }
        }

        public PaymentStrategy GetPaymentStrategy
        {
            get { return paymentStrategy; }
        }

        public DateTime GetSellingDate
        {
            get { return dateOfSelling; }
        }
    }
}
