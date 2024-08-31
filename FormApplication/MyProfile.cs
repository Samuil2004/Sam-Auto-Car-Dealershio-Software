using Classes;
using DataAccessLayer.CustomExceptions;
using LogicLayer.InterfacesLL;
using LogicLayer.Models;
using System;
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
    public partial class MyProfile : Form
    {
        private readonly IPeopleInterfaceLogicLayer _peopleManager;
        private MenuPageStaff menuPageStaff;
        private Person loggedInUser;
        private int counter;

        public MyProfile(MenuPageStaff menuPageStaff, IPeopleInterfaceLogicLayer peopleManager, Person loggedInUser)
        {
            InitializeComponent();
            this.menuPageStaff = menuPageStaff;
            _peopleManager = peopleManager;
            this.loggedInUser = _peopleManager.GetUserById(loggedInUser.GetId);
            FillInData();
            foreach (var item in _peopleManager.ReadSecretQuestions())
            {
                cbSecretQuestion.Items.Add(item.Value);
            }
        }
        private void FillInData()
        {
            tbFName.Text = loggedInUser.GetFirstName;
            tbLName.Text = loggedInUser.GetLastName;
            tbEmail.Text = loggedInUser.GetEmail;
            tbPhoneNumber.Text = loggedInUser.GetPhoneNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var updateAccount = new AccountUpdateDTOLL
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
                var context = new ValidationContext(updateAccount, serviceProvider: null, items: null);
                if (!updateAccount.Email.Equals(loggedInUser.GetEmail, StringComparison.OrdinalIgnoreCase))
                {
                    if (!_peopleManager.IsEmailAvailable(updateAccount.Email))
                    {
                        MessageBox.Show("Email already exists","Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (!Validator.TryValidateObject(updateAccount, context, validationResults, validateAllProperties: true))
                {
                    foreach (var validationResult in validationResults)
                    {
                        MessageBox.Show(validationResult.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                _peopleManager.UpdatePerson(loggedInUser.GetId, updateAccount.Email, updateAccount.PhoneNumber, updateAccount.Password, updateAccount.SecretQuestion, updateAccount.SecretQuestionAnswer);
                MessageBox.Show("You have succesfully updated you account information!");
                menuPageStaff.Show();
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
            catch (UserNotFound ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void pbSeeImage_Click(object sender, EventArgs e)
        {
            counter = 0;
            timer.Start();
            pbSeeImage.Visible = false;
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
                    menuPageStaff.Show();
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
