using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;
using System.Diagnostics.Metrics;
using System.Printing;
using System.Net;
using DataAccessLayer.CustomExceptions;
using LogicLayer.InterfacesLL;


namespace FormApplication
{
    public partial class ManageVehiclesPage : Form
    {
        private readonly IVehicleAdvancedInterfaceLogicLayer _vehicleManager;
        private readonly IPeopleInterfaceLogicLayer _peopleManager;
        private readonly IReceiptsInterfaceLogicLayer _receiptsManager;

        private Vehicle selectedVehicle;
        private bool close_application;
        private MenuPageStaff menuPageStaff;
        private List<Vehicle> listToUse;
        private List<Vehicle> vehiclesForPage;
        private int counter;
        private string filteringCriteria;

        public ManageVehiclesPage(IVehicleAdvancedInterfaceLogicLayer vehicleManager, IPeopleInterfaceLogicLayer peopleManager, MenuPageStaff menuPageStaff, IReceiptsInterfaceLogicLayer receiptsManager)
        {
            InitializeComponent();
            _vehicleManager = vehicleManager;
            _peopleManager = peopleManager;
            _receiptsManager = receiptsManager;
            this.menuPageStaff = menuPageStaff;
            close_application = true;
            this.counter = 1;
            ListVehicles();
        }


        private void lbVehiclesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbVehiclesList.SelectedItem.ToString()) && listToUse != null)
            {
                try
                {
                    selectedVehicle = _vehicleManager.FindVehicle(lbVehiclesList.SelectedItem.ToString(), listToUse);
                    UpdateInformationBox();
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void ListVehicles()
        {
            lbVehiclesList.Items.Clear();
            vehiclesForPage = _vehicleManager.ReadAvailableVehiclesForSelectedPage(counter, filteringCriteria,false);
            listToUse = vehiclesForPage.Take(10).ToList();
            foreach (Vehicle vehicle in listToUse)
            {
                lbVehiclesList.Items.Add(vehicle.GetIDBrandAndModel);
            }
            if (lbVehiclesList.Items.Count > 0)
            {
                lbVehiclesList.SelectedIndex = 0;
            }
            labelPageNum.Text = $"{counter}";
            CheckForNavigationhiding();
        }

        private void UpdateInformationBox()
        {
            labelAxles.Visible = false;
            labelTruckAxles.Visible = false;
            labelSteeringWheel.Visible = false;
            labelVehicleSteeringWheel.Visible = false;
            labelEnginePower.Text = "Engine Power";
            //common
            labelCarHeader.Text = selectedVehicle.GetIDBrandAndModel;
            labelPrice.Text = $"{selectedVehicle.GetPrice.ToString("#,##0.00")}€";
            labelVehicleFloorPrice.Text = $"{selectedVehicle.LowestPriceVehicleCanGo().ToString("#,##0.00")}€";
            labelVehicleDateOfProduction.Text = selectedVehicle.GetYearOfProduction.ToString("dd/MM/yyyy");
            labelVehicleEngine.Text = selectedVehicle.GetEngine.GetEngineType.ToString();
            labelVehicleTransmission.Text = selectedVehicle.GetTransmissionType.ToString();
            labelVehicleBodyType.Text = selectedVehicle.GetBodyType;
            labelVehicleMileage.Text = selectedVehicle.GetMileage.ToString();
            labelVehicleColor.Text = selectedVehicle.GetColor;
            labelFuelType.Text = selectedVehicle.GetEngine.GetFuelType.ToString();
            if (selectedVehicle is Truck truck)
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
            if (selectedVehicle is Car car)
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
            if (selectedVehicle is Motorcycle motorcycle)
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
            labelVehicleCondition.Text = selectedVehicle.GetCondition.ToString();
            ChangeImage(selectedVehicle.GetImage);
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



        private void btnAddNewVehicle_Click(object sender, EventArgs e)
        {
            AddVehiclePage addVehiclePage = new AddVehiclePage(_vehicleManager, this);
            addVehiclePage.Show();
            this.Hide();
        }


        private void btnSellVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedVehicle.GetIsReserved)
                {
                    DialogResult[] results = { DialogResult.Yes, DialogResult.Cancel };
                    string userResponse = "";
                    string message = $"This vehicle is saved by {_vehicleManager.GetWhoSavedTheVehicle(selectedVehicle.GetVehicleId)} \n Would you like to move further?";
                    if (results.Contains(ConfirmationBox(ref userResponse, message)))
                    {
                        if (userResponse.Equals("Yes"))
                        {
                            SellVehiclePage sellVehiclePage = new SellVehiclePage(selectedVehicle, _peopleManager, this,_receiptsManager);
                            sellVehiclePage.ShowDialog();
                        }
                    }
                }
                else
                {
                    SellVehiclePage sellVehiclePage = new SellVehiclePage(selectedVehicle, _peopleManager, this, _receiptsManager);
                    sellVehiclePage.ShowDialog();
                }
            }
            catch (UserNotFound ex)
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
            catch (DALException ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
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

        private void btnUpdateVehicle_Click(object sender, EventArgs e)
        {
            UpdateVehiclePage updateVehiclePage = new UpdateVehiclePage(_vehicleManager, selectedVehicle, this);
            updateVehiclePage.ShowDialog();

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

        private void pbBackToMenu_Click(object sender, EventArgs e)
        {
            close_application = false;
            menuPageStaff.Show();
            this.Close();
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
        public void ResetPage()
        {
            try
            {
                this.counter = 1;
                filteringCriteria = null;
                ListVehicles();
                tbSearchBar.Text = string.Empty;
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

        private void btnDeleteVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult[] results = { DialogResult.Yes, DialogResult.Cancel };
                string userResponse = "";
                string message = "Are you sure you want to \n permanently delete this vehicle?";
                if (results.Contains(ConfirmationBox(ref userResponse, message)))
                {
                    if (userResponse.Equals("Yes"))
                    {
                        _vehicleManager.DeleteVehicle(selectedVehicle);
                        ResetPage();
                    }
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
