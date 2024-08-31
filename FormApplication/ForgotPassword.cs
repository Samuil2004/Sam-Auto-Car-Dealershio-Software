using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using Classes;
using LogicLayer.InterfacesLL;
using DataAccessLayer.CustomExceptions;

namespace FormApplication
{
    public partial class ForgotPassword : Form
    {
        private readonly IPeopleInterfaceLogicLayer _peopleManager;
        Form1 form1;
        private int counter;
        private bool close_application;

        public ForgotPassword(Form1 logInForm, string username, IPeopleInterfaceLogicLayer peopleManager)
        {
            InitializeComponent();
            this.form1 = logInForm;
            tbUsernameInput.Text = username;
            this._peopleManager = peopleManager;
            labelNewPassword.Visible = false;
            tbPasswordInput.Visible = false;
            pbSeeImage.Visible = false;
            btnUpdate.Visible = false;
            close_application = true;
            foreach (var item in _peopleManager.ReadSecretQuestions())
            {
                cbSecretQuestion.Items.Add(item.Value);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var forgotPasswordDTO = new ForgotPasswordDTOLL
                {
                    Email = tbUsernameInput.Text,
                    SecretQuestion = cbSecretQuestion.SelectedItem?.ToString(),
                    SecretQuestionAnswer = tbSQAnswer.Text,
                };
                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(forgotPasswordDTO, serviceProvider: null, items: null);
                if (!Validator.TryValidateObject(forgotPasswordDTO, context, validationResults, validateAllProperties: true))
                {
                    foreach (var validationResult in validationResults)
                    {
                        MessageBox.Show(validationResult.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                Person? person = _peopleManager.CheckUserSecretQuestionForForgottenPassword(forgotPasswordDTO.Email, forgotPasswordDTO.SecretQuestion, forgotPasswordDTO.SecretQuestionAnswer);

                if (person != null && person is StaffMember staffMember)
                {
                    labelUsername.Visible = false;
                    tbUsernameInput.Visible = false;
                    labelSecretQuestion.Visible = false;
                    cbSecretQuestion.Visible = false;
                    labelAnswer.Visible = false;
                    tbSQAnswer.Visible = false;
                    btnConfirm.Visible = false;

                    labelNewPassword.Visible = true;
                    tbPasswordInput.Visible = true;
                    pbSeeImage.Visible = true;
                    btnUpdate.Visible = true;
                }
                else
                {
                    MessageBox.Show("Incorrect information is provided! \nTry again!");
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (UserNotFound ex)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var passwordChecker = new ResetPasswordDTO
                {
                    Password = tbPasswordInput.Text,
                };
                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(passwordChecker, serviceProvider: null, items: null);
                if (!Validator.TryValidateObject(passwordChecker, context, validationResults, validateAllProperties: true))
                {
                    foreach (var validationResult in validationResults)
                    {
                        MessageBox.Show(validationResult.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                Person? user = _peopleManager.GetUserByUsername(tbUsernameInput.Text);
                if (user != null)
                {
                    _peopleManager.UpdatePerson(user.GetId, user.GetEmail, user.GetPhoneNumber,tbPasswordInput.Text, cbSecretQuestion.SelectedItem.ToString(), tbSQAnswer.Text);
                    this.Close();
                    form1.Show();
                }
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
            catch (VehicleNotFound ex)
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
                tbPasswordInput.PasswordChar = '\0';
            }
            else
            {
                tbPasswordInput.PasswordChar = '*';
                timer.Stop();
                counter = 0;
                pbSeeImage.Visible = true;

            }
        }
        private void AnyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close_application)
            {
                form1.Show();
            }
            else
            {
                return;
            }
        }
    }
}
