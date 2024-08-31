using Classes;
using DataAccessLayer.CustomExceptions;
//using Logic_layer.Models;
using LogicLayer.InterfacesLL;
using LogicLayer.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace FormApplication
{
    public partial class Form1 : Form
    {
        private readonly IPeopleInterfaceLogicLayer _peopleManager;
        private readonly IVehicleAdvancedInterfaceLogicLayer _vehicleManager;
        private readonly IStatisticsInterfaceLogicLayer _statisticsManager;
        private readonly IReceiptsInterfaceLogicLayer _receiptsManager;

        private int counter;
        public Form1(IPeopleInterfaceLogicLayer peopleManager, IVehicleAdvancedInterfaceLogicLayer vehicleManager, IStatisticsInterfaceLogicLayer statisticsManager, IReceiptsInterfaceLogicLayer receiptsManager)
        {
            InitializeComponent();
            _peopleManager = peopleManager;
            _vehicleManager = vehicleManager;
            _statisticsManager = statisticsManager;
            _receiptsManager = receiptsManager;
            labelMessage.Visible = false;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                var loginDTO = new LogInDTOLL
                {
                    Email = tbUsernameInput.Text,
                    Password = tbPasswordInput.Text
                };

                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(loginDTO, serviceProvider: null, items: null);
                if (!Validator.TryValidateObject(loginDTO, context, validationResults, validateAllProperties: true))
                {
                    foreach (var validationResult in validationResults)
                    {
                        MessageBox.Show(validationResult.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                Person? user = _peopleManager.CheckForUserDesktop(tbUsernameInput.Text, tbPasswordInput.Text);
                if (user != null)
                {
                    _vehicleManager.ExpiredReservationsChecker();
                    MenuPageStaff menuPageStaff = new MenuPageStaff(this,user,_vehicleManager, _peopleManager,_statisticsManager,_receiptsManager);
                    menuPageStaff.Show();
                    this.Hide();
                }
                else
                {
                    labelMessage.Visible = true;
                    labelMessage.Text = "User with provided username and password \ndoes not exist";
                }
            }
            catch (UserNotFound ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CheckPassword();
            counter = counter + 1;
        }

        private void pbSeeImage_Click(object sender, EventArgs e)
        {
            counter = 0;
            Timer.Start();
            pbSeeImage.Visible = false;
        }
        private void CheckPassword()
        {
            if (counter < 30)
            {
                tbPasswordInput.PasswordChar = '\0';
            }
            else
            {
                tbPasswordInput.PasswordChar = '*';
                Timer.Stop();
                counter = 0;
                pbSeeImage.Visible = true;
            }
        }

        private void linkToForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUsernameInput.Text))
            {
                try
                {
                    ForgotPassword forgotPassword = new ForgotPassword(this, tbUsernameInput.Text, _peopleManager);
                    forgotPassword.Show();
                    this.Hide();
                }
                catch (DALException ex)
                {
                    MessageBox.Show($"A database error occured: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please input your username before \nupdating you password");
            }
        }
    }
}

