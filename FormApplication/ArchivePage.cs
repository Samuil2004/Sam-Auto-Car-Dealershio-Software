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
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApplication
{
    public partial class ArchivePage : Form
    {
        private readonly IReceiptsInterfaceLogicLayer _receiptsManager;

        private MenuPageStaff menuPageStaff;
        private Receipt selectedReceipt;
        private bool close_application;
        private List<Receipt> listToUse;
        private List<Receipt> vehiclesForPage;
        private int counter;
        private string filteringCriteria;


        public ArchivePage(MenuPageStaff menuPageStaff,IReceiptsInterfaceLogicLayer receiptsManager)
        {
            InitializeComponent();
            _receiptsManager = receiptsManager;
            this.menuPageStaff = menuPageStaff;
            close_application = true;
            this.counter = 1;
            ListVehicles();
        }
        private void UpdateInformationBox()
        {
            labelAxles.Visible = false;
            labelTruckAxles.Visible = false;
            labelSteeringWheel.Visible = false;
            labelVehicleSteeringWheel.Visible = false;
            labelCarHeader.Text = selectedReceipt.GetVehicle.GetIDBrandAndModel;
            labelPrice.Text = $"{selectedReceipt.GetSellingPrice}€";
            Dictionary<DateTime, string> saleData = _receiptsManager.GetSoldVehicleDetails(selectedReceipt.GetVehicle.GetVehicleId);
            labelBuyerEmail.Text = saleData.First().Value;
            labelVehicleSellingDate.Text = selectedReceipt.GetSellingDate.ToString("dd/MM/yyyy");
            labelVehicleDateOfProduction.Text = selectedReceipt.GetVehicle.GetYearOfProduction.ToString("dd/MM/yyyy");
            labelVehicleEngine.Text = selectedReceipt.GetVehicle.GetEngine.GetEngineType.ToString();
            labelVehicleTransmission.Text = selectedReceipt.GetVehicle.GetTransmissionType.ToString();
            labelVehicleBodyType.Text = selectedReceipt.GetVehicle.GetBodyType;
            labelVehicleMileage.Text = selectedReceipt.GetVehicle.GetMileage.ToString();
            labelVehicleColor.Text = selectedReceipt.GetVehicle.GetColor;
            labelFuelType.Text = selectedReceipt.GetVehicle.GetEngine.GetFuelType.ToString();
            string strategyUsed = null;
            if (selectedReceipt.GetPaymentStrategy is DebitPaymentStrategy)
            {
                strategyUsed = "Debit card";
            }
            else if (selectedReceipt.GetPaymentStrategy is BankTransferPaymentStrategy)
            {
                strategyUsed = "Bank transfer";
            }
            else if (selectedReceipt.GetPaymentStrategy is CashPaymentStrategy)
            {
                strategyUsed = "Cash";
            }
            else if (selectedReceipt.GetPaymentStrategy is CreditCardPaymentStrategy)
            {
                strategyUsed = "Credit card";
            }
            labelVehiclePayment.Text = strategyUsed;

            if (selectedReceipt.GetVehicle is Truck truck)
            {
                labelPlayLoadCapacity.Visible = true;
                labelPlayLoadCapacity.Text = "Playload Capacity";
                labelTruckPlayLoadCapacity.Visible = true;
                labelAxles.Visible = true;
                labelAxles.Text = "Axles:";
                labelTruckAxles.Visible = true;
                labelSteeringWheel.Visible = true;
                labelVehicleSteeringWheel.Visible = true;
                labelVehicleEnginePower.Text = truck.GetHorsePower.ToString();
                labelTruckPlayLoadCapacity.Text = truck.GetPlayLoadCapacity.ToString();
                labelTruckAxles.Text = truck.GetNumberOfAxles.ToString();
                labelVehicleSteeringWheel.Text = truck.GetSteeeringWheelType.ToString();
            }
            if (selectedReceipt.GetVehicle is Car car)
            {
                labelPlayLoadCapacity.Visible = true;
                labelPlayLoadCapacity.Text = "Number of doors";
                labelTruckPlayLoadCapacity.Visible = true;
                labelTruckPlayLoadCapacity.Text = car.GetNumberOfDoors.ToString();

                labelSteeringWheel.Visible = true;
                labelVehicleSteeringWheel.Visible = true;
                labelVehicleEnginePower.Text = car.GetHorsePower.ToString();
                labelVehicleSteeringWheel.Text = car.GetSteeringWheel.ToString();
            }
            if (selectedReceipt.GetVehicle is Motorcycle motorcycle)
            {
                labelPlayLoadCapacity.Visible = true;
                labelPlayLoadCapacity.Text = "Wind shield:";
                labelTruckPlayLoadCapacity.Visible = true;
                labelTruckPlayLoadCapacity.Text = motorcycle.GetHasWindShield.ToString();

                labelAxles.Visible = true;
                labelTruckAxles.Visible = true;
                labelAxles.Text = "Box attached:";
                labelTruckAxles.Text = motorcycle.GetHasABox.ToString();

                labelEnginePower.Text = "Cubic Capacity";
                labelVehicleEnginePower.Text = motorcycle.GetCubicCapacity.ToString();
            }
            labelVehicleCondition.Text = selectedReceipt.GetVehicle.GetCondition.ToString();
            ChangeImage(selectedReceipt.GetVehicle.GetImage);
        }
        private void ChangeImage(string imageURL)
        {
            try
            {
                var request = WebRequest.Create($"{imageURL}");

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pbVehicleImage.Image = Bitmap.FromStream(stream);
                }
            }
            catch (WebException ex)
            {
                pbVehicleImage.Image = pbVehicleImage.ErrorImage;
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

        private void lbVehiclesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lbVehiclesList.SelectedItem.ToString()) && listToUse != null)
                {
                    foreach (Receipt receipt in listToUse)
                    {
                        if (receipt.GetVehicle.GetIDBrandAndModel.Equals(lbVehiclesList.SelectedItem.ToString()))
                        {
                            selectedReceipt = receipt;
                        }
                    }
                }
                UpdateInformationBox();
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show(ex.Message);
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
        private void ListVehicles()
        {
            lbVehiclesList.Items.Clear();
            vehiclesForPage = _receiptsManager.GetSoldVehiclesForSelectedPage(counter, filteringCriteria);
            listToUse = vehiclesForPage.Take(10).ToList();

            foreach (Receipt receipt in listToUse)
            {
                lbVehiclesList.Items.Add(receipt.GetVehicle.GetIDBrandAndModel);
            }
            if (lbVehiclesList.Items.Count > 0)
            {
                lbVehiclesList.SelectedIndex = 0;
            }
            labelPageNum.Text = $"{counter}";
            CheckForNavigationhiding();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                counter++;
                ListVehicles();
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                counter--;
                ListVehicles();
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
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

            if (vehiclesForPage.Count() > 10)
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
                ListVehicles();
            }
            catch (VehicleNotFound ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
