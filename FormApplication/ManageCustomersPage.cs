using Classes;
using DataAccessLayer.CustomExceptions;
using Logic_layer;
using LogicLayer.InterfacesLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApplication
{
    public partial class ManageCustomersPage : Form
    {
        private readonly IPeopleInterfaceLogicLayer _peopleManager;
        Person selectedCustomer;
        MenuPageStaff menuPageStaff;
        private List<Person> listToUse;
        private List<Person> peopleForPage;
        private bool close_application;
        private int counter;
        private string filteringCriteria;
        private int selectedIndex;


        public ManageCustomersPage(MenuPageStaff menuPageStaff, IPeopleInterfaceLogicLayer peopleManager)
        {
            InitializeComponent();
            this.menuPageStaff = menuPageStaff;
            _peopleManager = peopleManager;
            close_application = true;
            this.counter = 1;
            ListCustomers();
        }

        private void pbBackToMenu_Click(object sender, EventArgs e)
        {
            close_application = false;
            menuPageStaff.Show();
            this.Close();
        }
        private void AnyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close_application)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }
        private void ListCustomers()
        {
            lbCustomersList.Items.Clear();
            peopleForPage = _peopleManager.GetPeopleForSelectedPage("Customer", counter, filteringCriteria);
            listToUse = peopleForPage.Take(10).ToList();

            foreach (Person person in listToUse)
            {
                lbCustomersList.Items.Add(person.GetIdentifyingInfo);
            }

            if (lbCustomersList.Items.Count > 0)
            {
                lbCustomersList.SelectedIndex = 0;
            }
            labelPageNum.Text = $"{counter}";
            CheckForNavigationhiding();
        }
        private void PrintCustomerData()
        {
            lbBoughtVehicles.Items.Clear();
            lbSavedForBuyingVehicles.Items.Clear();
            selectedCustomer = _peopleManager.FindPerson(lbCustomersList.SelectedItem.ToString(), listToUse);
            labelCustomerHeader.Text = $"{selectedCustomer.GetFirstName} {selectedCustomer.GetLastName}";
            labelCustomerFirstName.Text = selectedCustomer.GetFirstName;
            labelCustomerLastName.Text = selectedCustomer.GetLastName;
            labelCustomerEmail.Text = selectedCustomer.GetEmail;
            labelCustomerPhoneNumber.Text = selectedCustomer.GetPhoneNumber;
            CheckCustomersLoyalty();
            PrintBoughtVehicles();
            PrintSavedVehicles();
        }
        private void PrintBoughtVehicles()
        {
            lbBoughtVehicles.Items.Clear();
            if (selectedCustomer is Customer customer)
            {
                if (customer.GetBoughtVehicles != null)
                {
                    foreach (Receipt receipt in customer.GetBoughtVehicles.GetBoughVehicles)
                    {
                        lbBoughtVehicles.Items.Add(receipt.GetVehicle.GetIDBrandAndModel);
                    }
                }
            }
        }
        private void PrintSavedVehicles()
        {
            lbSavedForBuyingVehicles.Items.Clear();
            if (selectedCustomer is Customer customer)
            {
                if (customer.GetSavedVehicles != null)
                {
                    foreach (Vehicle vehicle in customer.GetSavedVehicles.GetSavedVehicles)
                    {
                        lbSavedForBuyingVehicles.Items.Add(vehicle.GetIDBrandAndModel);
                    }
                }
            }
        }
        private void CheckCustomersLoyalty()
        {
            if (selectedCustomer is Customer customer)
            {
                if (customer.GetIsLoyalClient)
                {
                    pbLoyalClientBadge.Visible = true;
                    btnChangeLoyality.Visible = false;
                }
                else
                {
                    pbLoyalClientBadge.Visible = false;
                    btnChangeLoyality.Visible = true;
                }
            }
        }

        private void btnChangeLoyality_Click(object sender, EventArgs e)
        {
            try
            {
                _peopleManager.PromoteCustomer(selectedCustomer.GetId);
                selectedIndex = lbCustomersList.SelectedIndex;
                ListCustomers();
                lbCustomersList.SelectedIndex = selectedIndex;
                PrintCustomerData();
            }
            catch (UserNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (DALException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }

        private void lbCustomersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PrintCustomerData();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                counter++;
                ListCustomers();
            }
            catch (UserNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (DALException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                counter--;
                ListCustomers();
            }
            catch (UserNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (DALException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }

        private void CheckForNavigationhiding()
        {
            if (counter == 1)
            {
                btnPrevPage.Visible = false;
            }
            else
            {
                btnPrevPage.Visible = true;
            }

            if (peopleForPage.Count() > 10)
            {
                btnNextPage.Visible = true;
            }
            else
            {
                btnNextPage.Visible = false;
            }
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                counter = 1;
                if (string.IsNullOrEmpty(tbSearchBar.Text.Trim()))
                {
                    filteringCriteria = null;
                }
                else if (!string.IsNullOrEmpty(tbSearchBar.Text))
                {
                    filteringCriteria = tbSearchBar.Text.Trim();
                }
                ListCustomers();
            }
            catch (UserNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (DALException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }
    }
}
