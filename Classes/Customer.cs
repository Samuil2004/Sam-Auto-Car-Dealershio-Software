using Logic_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Customer : Person
    {
        private CustomerBoughtVehicles boughtVehicles;
        private CustomerFavoriteVehicles favoriteVehicles;
        private CustomerSavedVehicles savedVehicles;
        private bool isLoyalClient;

        public Customer(string firstName, string lastName, string email, string phoneNumber,bool isLoyalClient) : base(firstName, lastName, email, phoneNumber)
        {
            this.isLoyalClient = isLoyalClient;
        }
        public Customer(int personId, string firstName, string lastName, string email, string phoneNumber, bool isLoyalClient, CustomerBoughtVehicles BoughtVehicles, CustomerFavoriteVehicles CustomerFavoriteVehicles, CustomerSavedVehicles CustomerSavedVehicles) : base(personId, firstName, lastName, email, phoneNumber)
        {
            this.isLoyalClient = isLoyalClient;
            this.boughtVehicles = BoughtVehicles;
            this.favoriteVehicles = CustomerFavoriteVehicles;
            this.savedVehicles = CustomerSavedVehicles;
        }

        public bool GetIsLoyalClient
        {
            get { return isLoyalClient; }
        }
        public CustomerBoughtVehicles GetBoughtVehicles
        {
            get { return boughtVehicles; }
        }
        public CustomerFavoriteVehicles GetFavoriteVehicles
        {
            get { return favoriteVehicles; }
        }
        public CustomerSavedVehicles GetSavedVehicles
        {
            get { return savedVehicles; }
        }
    }
}
