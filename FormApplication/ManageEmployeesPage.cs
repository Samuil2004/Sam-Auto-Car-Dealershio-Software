using Classes;
using DataAccessLayer.CustomExceptions;
using LogicLayer.InterfacesLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApplication
{
    public partial class ManageEmployeesPage : Form
    {
        private readonly IPeopleInterfaceLogicLayer _peopleManager;
        Person selectedEmployee;
        MenuPageStaff menuPageStaff;
        private List<Person> listToUse;
        private List<Person> peopleForPage;
        private bool close_application;
        Person loggedInUser;
        private int counter;
        private string filteringCriteria;
        public ManageEmployeesPage(MenuPageStaff menuPageStaff, IPeopleInterfaceLogicLayer peopleManager,Person loggedInUser)
        {
            InitializeComponent();

            this.menuPageStaff = menuPageStaff;
            this._peopleManager = peopleManager;
            this.loggedInUser = loggedInUser;
            close_application = true;
            this.counter = 1;
            ListEmployees();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                counter++;
                ListEmployees();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (UserNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (DALException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
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
        private void ListEmployees()
        {
            lbEmployeesList.Items.Clear();
            peopleForPage = _peopleManager.GetPeopleForSelectedPage("StaffMember", counter, filteringCriteria);
            listToUse = peopleForPage.Take(10).ToList();

            foreach (Person person in listToUse)
            {
                if (!person.GetEmail.Equals(loggedInUser.GetEmail))
                {
                    lbEmployeesList.Items.Add(person.GetIdentifyingInfo);
                }
            }

            if (lbEmployeesList.Items.Count > 0)
            {
                lbEmployeesList.SelectedIndex = 0;
            }
            labelPageNum.Text = $"{counter}";
            CheckForNavigationhiding();
        }

        private void PrintEmployeeData()
        {
            selectedEmployee = _peopleManager.FindPerson(lbEmployeesList.SelectedItem.ToString(), listToUse);
            labelCustomerHeader.Text = $"{selectedEmployee.GetFirstName} {selectedEmployee.GetLastName}";
            labelCustomerFirstName.Text = selectedEmployee.GetFirstName;
            labelCustomerLastName.Text = selectedEmployee.GetLastName;
            labelCustomerEmail.Text = selectedEmployee.GetEmail;
            labelCustomerPhoneNumber.Text = selectedEmployee.GetPhoneNumber;
            if (selectedEmployee is StaffMember staffMember)
            {
                labelStartingDateEmployee.Text = staffMember.GetStartedDate.ToString("dd/MM/yyyy");
            }
        }

        private void lbEmployeesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PrintEmployeeData();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                counter--;
                ListEmployees();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (UserNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (DALException ex)
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
        public void ResetPage()
        {
            try
            {
                this.counter = 1;
                filteringCriteria = null;
                ListEmployees();
                tbSearchBar.Text = string.Empty;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (UserNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (DALException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                AddEmployePage addEmployePage = new AddEmployePage(this, _peopleManager);
                addEmployePage.ShowDialog();
            }
            catch (DALException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult[] results = { DialogResult.Yes, DialogResult.Cancel };
                string userResponse = "";
                string message = "Are you sure you want to \n permanently delete this employee?";
                if (results.Contains(ConfirmationBox(ref userResponse, message)))
                {
                    if (userResponse.Equals("Yes"))
                    {
                        _peopleManager.DeletePerson(selectedEmployee.GetId);
                        ResetPage();
                    }
                }
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (UserNotFound ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DialogResult ConfirmationBox(ref string userResponse, string message)
        {
            AlertPage aletPage = new AlertPage(message);
            DialogResult dialogResult = aletPage.ShowDialog();
            if (dialogResult == DialogResult.Yes)
            {
                userResponse = "Yes";
            }

            if (dialogResult == DialogResult.Cancel)
            {
                userResponse = "Cancel";
            }

            return dialogResult;
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
                ListEmployees();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (UserNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (DALException ex)
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
