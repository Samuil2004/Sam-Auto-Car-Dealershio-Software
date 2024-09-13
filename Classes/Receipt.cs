using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer
{
    /// <summary>
    /// Represents a sales receipt for a vehicle transaction.
    /// </summary>
    public class Receipt
    {
        private Vehicle selectedVehicle;
        private PaymentStrategy paymentStrategy;
        private DateTime dateOfSelling;
        private decimal sellingPrice;

        /// <summary>
        /// Initializes a new instance of the <see cref="Receipt"/> class.
        /// </summary>
        public Receipt(Vehicle SelectedVehicle, PaymentStrategy SelectedPaymentMethod,DateTime DateOfSelling, decimal SellingPrice)
        {
            this.selectedVehicle = SelectedVehicle;
            this.paymentStrategy = SelectedPaymentMethod;
            this.dateOfSelling = DateOfSelling;
            this.sellingPrice = SellingPrice;
        }

        /// <summary>
        /// Calculates the final price after applying the payment strategy's calculation to the selling price.
        /// <see cref="PaymentStrategy"/> class
        /// </summary>
        /// <returns>The total price after applying the payment strategy.</returns>
        public decimal GetCheckoutPrice()
        {
            return paymentStrategy.CalculateTotalPrice(sellingPrice);
        }

        /// <summary>
        /// Gets the vehicle associated with the receipt.
        /// </summary>
        public Vehicle GetVehicle
        {
            get { return selectedVehicle; }
        }

        /// <summary>
        /// Gets the selling price of the vehicle before all external taxes.
        /// </summary>
        public decimal GetSellingPrice
        {
            get { return sellingPrice; }
        }

        /// <summary>
        /// Gets the payment strategy used for the transaction.
        /// <see cref="PaymentStrategy"/> class
        /// </summary>
        public PaymentStrategy GetPaymentStrategy
        {
            get { return paymentStrategy; }
        }

        /// <summary>
        /// Gets the date when the vehicle was sold.
        /// </summary>
        public DateTime GetSellingDate
        {
            get { return dateOfSelling; }
        }
    }
}
