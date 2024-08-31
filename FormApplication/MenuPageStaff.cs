using Classes;
using LogicLayer.InterfacesLL;
using System;
using Logic_layer.Enumerations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.CustomExceptions;

namespace FormApplication
{
    public partial class MenuPageStaff : Form
    {
        private readonly IVehicleAdvancedInterfaceLogicLayer _vehicleManager;
        private readonly IPeopleInterfaceLogicLayer _peopleManager;
        private readonly IStatisticsInterfaceLogicLayer _statisticsManager;
        private readonly IReceiptsInterfaceLogicLayer _receiptsManager;
        private Form1 logInPage;
        private bool close_application;
        private Person loggedInUser;

        public MenuPageStaff(Form1 logIn, Person loggedInUser, IVehicleAdvancedInterfaceLogicLayer vehicleManager, IPeopleInterfaceLogicLayer peopleManager, IStatisticsInterfaceLogicLayer statisticsManager, IReceiptsInterfaceLogicLayer receiptsManager)
        {
            InitializeComponent();
            _vehicleManager = vehicleManager;
            _peopleManager = peopleManager;
            _statisticsManager = statisticsManager;
            _receiptsManager = receiptsManager;
            close_application = true;
            this.logInPage = logIn;
            this.loggedInUser = loggedInUser;
            if (((StaffMember)loggedInUser).GetStaffRole.Equals(StaffMemberRoles.Manager))
            {
                btnCustomers.Visible = false;
                btnManageVehicles.Visible = false;
                btnSalesAndAchive.Visible = false;
            }
            else if (((StaffMember)loggedInUser).GetStaffRole.Equals(StaffMemberRoles.Employee))
            {
                btnSeeStatistics.Visible = false;
                btnEmployees.Visible = false;
            }
        }

        private void btnManageVehicles_Click(object sender, EventArgs e)
        {
            try
            {
                ManageVehiclesPage manageVehiclesPage = new ManageVehiclesPage(_vehicleManager, _peopleManager, this,_receiptsManager);
                manageVehiclesPage.Show();
                this.Hide();
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSeeStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticsPage statisticsPage = new StatisticsPage(this,_statisticsManager);
                statisticsPage.Show();
                this.Hide();
            }
            catch (DALException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
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

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                ManageCustomersPage customersPage = new ManageCustomersPage(this, _peopleManager);
                customersPage.Show();
                this.Hide();
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

        private void btnSalesAndAchive_Click(object sender, EventArgs e)
        {
            try
            {
                ArchivePage archivePage = new ArchivePage(this, _receiptsManager);
                archivePage.Show();
                this.Hide();
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (DALException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }

        private void pbLogOut_Click(object sender, EventArgs e)
        {
            DialogResult[] results = { DialogResult.Yes, DialogResult.Cancel };
            string userResponse = "";
            string message = "Are you sure you want to log out?";
            if (results.Contains(ConfirmationBox(ref userResponse, message)))
            {
                if (userResponse.Equals("Yes"))
                {
                    logInPage.Show();
                    this.Hide();
                }
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ManageEmployeesPage employeesPage = new ManageEmployeesPage(this, _peopleManager,loggedInUser);
                employeesPage.Show();
                this.Hide();
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

        private void pbAccountIcon_Click(object sender, EventArgs e)
        {
            try
            {
                MyProfile myProfile = new MyProfile(this, _peopleManager, loggedInUser);
                myProfile.ShowDialog();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (UserNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
            catch (DALException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }
    }
}
