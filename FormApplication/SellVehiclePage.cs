using Classes;
using DataAccessLayer.CustomExceptions;
using Logic_layer;
using Logic_layer.Payment_Strategies;
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
    public partial class SellVehiclePage : Form
    {
        private Vehicle selectedVehicleToSell;
        private Person selectedCustomer;
        private readonly IPeopleInterfaceLogicLayer _peopleManager;
        private readonly IReceiptsInterfaceLogicLayer _receiptManager;
        private int counter;
        private decimal finalPrice;
        private List<Person> listToUse;
        private List<Person> peopleForPage;
        private ManageVehiclesPage manageVehiclespage;
        private int chosenPrice;
        private string filteringCriteria;
        private Receipt receipt;
        private FactoryReceipt factoryReceipt;


        public SellVehiclePage(Vehicle selectedVehicleToSell, IPeopleInterfaceLogicLayer peopleManager, ManageVehiclesPage manageVehiclesPage,IReceiptsInterfaceLogicLayer receiptManager)
        {
            InitializeComponent();
            this.selectedVehicleToSell = selectedVehicleToSell;
            _peopleManager = peopleManager;
            _receiptManager = receiptManager;
            manageVehiclespage = manageVehiclesPage;
            nmNewPrice.Visible = false;
            pbLoyalClientBadge.Visible = false;
            labelDefaultVehiclePrice.Text = $"€ {selectedVehicleToSell.GetPrice.ToString("#,##0.00")}";
            labelChoosePaymentMethod.Enabled = false;
            rbBankTransfer.Enabled = false;
            rbCreditCard.Enabled = false;
            rbCash.Enabled = false;
            rbDebitCard.Enabled = false;
            btnConfirmPaymentMethod.Enabled = false;
            SearchLabel.Enabled = false;
            tbSearchBar.Enabled = false;
            ResultLabel.Enabled = false;
            lbCustomersList.Enabled = false;
            gbCustomerInformation.Enabled = false;
            this.counter = 1;
            FillList();
            labelFinalPrice.Text = $"€ {selectedVehicleToSell.GetPrice.ToString("#,##0.00")}";
            this.finalPrice = 0;
            factoryReceipt = new FactoryReceipt();
        }
        private void FillList()
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
            selectedCustomer = _peopleManager.FindPerson(lbCustomersList.SelectedItem.ToString(), listToUse);
            labelPersonHeader.Text = $"{selectedCustomer.GetFirstName} {selectedCustomer.GetLastName}";
            labelCustomerFirstName.Text = selectedCustomer.GetFirstName;
            labelCustomerLastName.Text = selectedCustomer.GetLastName;
            labelCustomerEmail.Text = selectedCustomer.GetEmail;
            labelCustomerPhoneNumber.Text = selectedCustomer.GetPhoneNumber;
            if (selectedCustomer is Customer customer)
            {
                if (customer.GetIsLoyalClient)
                {
                    pbLoyalClientBadge.Visible = true;
                }
                else
                {
                    pbLoyalClientBadge.Visible = false;
                }
            }
        }

        private void rbOtherPrice_CheckedChanged(object sender, EventArgs e)
        {
            nmNewPrice.Visible = true;
        }

        private void rbDefaultPrice_CheckedChanged(object sender, EventArgs e)
        {
            nmNewPrice.Visible = false;
            nmNewPrice.Value = 0;
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

        private void btnConfirmSellingPrice_Click(object sender, EventArgs e)
        {
            if (rbDefaultPrice.Checked || nmNewPrice.Value != 0)
            {
                labelSellingPrice.Enabled = false;
                rbDefaultPrice.Enabled = false;
                rbOtherPrice.Enabled = false;
                labelDefaultVehiclePrice.Enabled = false;
                nmNewPrice.Enabled = false;
                btnConfirmSellingPrice.Enabled = false;

                labelChoosePaymentMethod.Enabled = true;
                rbBankTransfer.Enabled = true;
                rbCreditCard.Enabled = true;
                rbCash.Enabled = true;
                rbDebitCard.Enabled = true;
                btnConfirmPaymentMethod.Enabled = true;
                chosenPrice = selectedVehicleToSell.GetPrice;
                if (nmNewPrice.Value != 0)
                {
                    chosenPrice = Convert.ToInt32(nmNewPrice.Value);
                    labelFinalPrice.Text = $"€ {chosenPrice.ToString("#,##0.00")}";
                }
            }
        }

        private void nmNewPrice_ValueChanged(object sender, EventArgs e)
        {
            if (nmNewPrice.Value != 0)
            {
                btnConfirmSellingPrice.Enabled = true;
            }
        }

        private void btnConfirmPaymentMethod_Click(object sender, EventArgs e)
        {
            if (rbBankTransfer.Checked || rbCreditCard.Checked || rbCash.Checked || rbDebitCard.Checked)
            {
                labelChoosePaymentMethod.Enabled = false;
                rbBankTransfer.Enabled = false;
                rbCreditCard.Enabled = false;
                rbCash.Enabled = false;
                rbDebitCard.Enabled = false;
                btnConfirmPaymentMethod.Enabled = false;

                SearchLabel.Enabled = true;
                tbSearchBar.Enabled = true;
                ResultLabel.Enabled = true;
                lbCustomersList.Enabled = true;
                gbCustomerInformation.Enabled = true;
            }
        }

        private void rbBankTransfer_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirmPaymentMethod.Enabled = true;
            receipt = factoryReceipt.CreateReceiptBank(selectedVehicleToSell, DateTime.Today, chosenPrice);
            finalPrice = Math.Round(receipt.GetCheckoutPrice(), 2);
            labelFinalPrice.Text = $"€ {finalPrice.ToString("#,##0.00")}";
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirmPaymentMethod.Enabled = true;
            receipt = factoryReceipt.CreateReceiptCash(selectedVehicleToSell, DateTime.Today, chosenPrice);
            finalPrice = Math.Round(receipt.GetCheckoutPrice(), 2);
            labelFinalPrice.Text = $"€ {finalPrice.ToString("#,##0.00")}";
        }

        private void rbCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirmPaymentMethod.Enabled = true;
            receipt = factoryReceipt.CreateReceiptCreditCard(selectedVehicleToSell, DateTime.Today, chosenPrice);
            finalPrice = Math.Round(receipt.GetCheckoutPrice(), 2);
            labelFinalPrice.Text = $"€ {finalPrice.ToString("#,##0.00")}";
        }

        private void rbDebitCard_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirmPaymentMethod.Enabled = true;
            receipt = factoryReceipt.CreateReceiptDebit(selectedVehicleToSell, DateTime.Today, chosenPrice);
            finalPrice = Math.Round(receipt.GetCheckoutPrice(), 2);
            labelFinalPrice.Text = $"€ {finalPrice.ToString("#,##0.00")}";
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                counter--;
                FillList();
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

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                counter++;
                FillList();
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

        private void btnSellVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                _receiptManager.SellVehicle(receipt, selectedCustomer, Convert.ToInt32(finalPrice));
                MessageBox.Show("Successfully sold");
                this.Close();
                manageVehiclespage.ResetPage();
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
        private void pbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                counter = 1;
                if (string.IsNullOrEmpty(tbSearchBar.Text))
                {
                    filteringCriteria = null;
                }
                else if (!string.IsNullOrEmpty(tbSearchBar.Text))
                {
                    filteringCriteria = tbSearchBar.Text;
                }
                FillList();
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
