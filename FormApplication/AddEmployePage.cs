using Classes;
using DataAccessLayer.CustomExceptions;
using LogicLayer.InterfacesLL;
using LogicLayer.Models;
using System;
using Logic_layer.Enumerations;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApplication
{
    public partial class AddEmployePage : Form
    {
        private readonly IPeopleInterfaceLogicLayer _peopleManager;
        private ManageEmployeesPage manageEmployeesPage;
        private int counter;

        public AddEmployePage(ManageEmployeesPage manageEmployeesPage, IPeopleInterfaceLogicLayer peopleManager)
        {
             
            InitializeComponent();
            this.manageEmployeesPage = manageEmployeesPage;
            _peopleManager = peopleManager;
            foreach (var item in _peopleManager.ReadSecretQuestions())
            {
                cbSecretQuestion.Items.Add(item.Value);
            }
            startingDate.MinDate = DateTime.Today;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var signUpModel = new SignUpDTOLL
                {
                    FirstName = tbFName.Text,
                    LastName = tbLName.Text,
                    Email = tbEmail.Text,
                    PhoneNumber = tbPhoneNumber.Text,
                    Password = tbPassword.Text,
                    ConfirmPassword = tbCPassword.Text,
                    SecretQuestion = cbSecretQuestion.SelectedItem?.ToString(),
                    SecretQuestionAnswer = tbAnswer.Text,
                };

                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(signUpModel, serviceProvider: null, items: new Dictionary<object, object> { { "PeopleManager", _peopleManager } });

                if (!Validator.TryValidateObject(signUpModel, context, validationResults, validateAllProperties: true))
                {
                    foreach (var validationResult in validationResults)
                    {
                        MessageBox.Show(validationResult.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                Person newEmployee;
                if (cbAddManager.Checked)
                {
                    newEmployee = new StaffMember(signUpModel.FirstName, signUpModel.LastName, signUpModel.Email, signUpModel.PhoneNumber, startingDate.Value, StaffMemberRoles.Manager);
                }
                else
                {
                    newEmployee = new StaffMember(signUpModel.FirstName, signUpModel.LastName, signUpModel.Email, signUpModel.PhoneNumber, startingDate.Value, StaffMemberRoles.Employee);
                }
                _peopleManager.CreatePerson(newEmployee, signUpModel.Password, signUpModel.SecretQuestion, signUpModel.SecretQuestionAnswer);
                MessageBox.Show("You have succesfully added the new employee! \n*New employee should be informed that Secret question, \nSecret question answer and password must be \nupdated on first log in through the account page!");
                manageEmployeesPage.Show();
                manageEmployeesPage.ResetPage();
                this.FormClosing -= AnyForm_FormClosing;
                this.Close();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbSeeImage_Click(object sender, EventArgs e)
        {
            counter = 0;
            timer.Start();
            pbSeeImage.Visible = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CheckPassword();
            counter = counter + 1;
        }
        private void CheckPassword()
        {
            if (counter < 30)
            {
                tbPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '*';
                timer.Stop();
                counter = 0;
                pbSeeImage.Visible = true;

            }
        }
        private void AnyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult[] results = { DialogResult.Yes, DialogResult.Cancel };
            string userResponse = "";
            string message = "If you havigate back, no changes will be saved!";
            if (results.Contains(ConfirmationBox(ref userResponse, message)))
            {
                if (userResponse.Equals("Yes"))
                {
                    manageEmployeesPage.Show();
                }
                else
                {
                    e.Cancel = true;
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
    }
}
