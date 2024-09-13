using Logic_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /// <summary>
    /// Represents a customer who interacts with the system, including properties like loyalty status and their collection of vehicles (bought, favorite, and saved).
    /// Inherits from the abstract <see cref="Person"/> class.
    /// </summary>
    public class Customer : Person
    {
        private CustomerBoughtVehicles boughtVehicles;
        private CustomerFavoriteVehicles favoriteVehicles;
        private CustomerSavedVehicles savedVehicles;
        private bool isLoyalClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with basic personal information and loyalty status.
        /// </summary>
        public Customer(string firstName, string lastName, string email, string phoneNumber,bool isLoyalClient) : base(firstName, lastName, email, phoneNumber)
        {
            this.isLoyalClient = isLoyalClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with personal details, loyalty status, and information on bought, favorite, and saved vehicles.
        /// </summary>
        public Customer(int personId, string firstName, string lastName, string email, string phoneNumber, bool isLoyalClient, CustomerBoughtVehicles BoughtVehicles, CustomerFavoriteVehicles CustomerFavoriteVehicles, CustomerSavedVehicles CustomerSavedVehicles) : base(personId, firstName, lastName, email, phoneNumber)
        {
            this.isLoyalClient = isLoyalClient;
            this.boughtVehicles = BoughtVehicles;
            this.favoriteVehicles = CustomerFavoriteVehicles;
            this.savedVehicles = CustomerSavedVehicles;
        }

        /// <summary>
        /// Gets a value indicating whether the customer is a loyal client.
        /// </summary>
        public bool GetIsLoyalClient
        {
            get { return isLoyalClient; }
        }

        /// <summary>
        /// Gets the collection of vehicles the customer has bought.
        /// </summary>
        public CustomerBoughtVehicles GetBoughtVehicles
        {
            get { return boughtVehicles; }
        }

        /// <summary>
        /// Gets the collection of the customer's favorite vehicles.
        /// </summary>
        public CustomerFavoriteVehicles GetFavoriteVehicles
        {
            get { return favoriteVehicles; }
        }

        /// <summary>
        /// Gets the collection of vehicles the customer has saved for later viewing.
        /// </summary>
        public CustomerSavedVehicles GetSavedVehicles
        {
            get { return savedVehicles; }
        }
    }
}
