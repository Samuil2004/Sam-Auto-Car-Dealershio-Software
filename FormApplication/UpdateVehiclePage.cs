using Classes;
using DataAccessLayer.CustomExceptions;
using Logic_layer.Enumerations;
using LogicLayer.InterfacesLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApplication
{
    public partial class UpdateVehiclePage : Form
    {
        private readonly IVehicleAdvancedInterfaceLogicLayer _vehicleManager;
        private ManageVehiclesPage manageVehiclesPage;
        private Vehicle selectedVehicle;
        private Dictionary<int, string> vehicleTypes;

        public UpdateVehiclePage(IVehicleAdvancedInterfaceLogicLayer vehicleManager, Vehicle selectedVehicle,ManageVehiclesPage manageVehiclesPage)
        {
            this._vehicleManager = vehicleManager;
            this.selectedVehicle = selectedVehicle;
            this.manageVehiclesPage = manageVehiclesPage;
            InitializeComponent();
            dateOfProduction.MaxDate = DateTime.Today.AddDays(1);
            ModifyInterface();
            AddInfo();
            btnTestImage.Enabled = false;
            btnUpdateVehicle.Enabled = true;
            this.FormClosing += UpdateVehicle_Closing;
        }

        private void ModifyInterface()
        {
            try
            {
                DisableEnableAllControls(true);
                labelSteeringWheel.Visible = true;
                cbSteeringWheelType.Visible = true;
                labelEnginePower.Text = "Engine Power:";
                rb2Axles.Visible = false;
                rb3Axles.Visible = false;
                rb4Axles.Visible = false;
                rb5Axles.Visible = false;
                rb6Axles.Visible = false;
                rb7Axles.Visible = false;
                nbPlayloadCapacity.Visible = false;
                chbHasWindShield.Visible = false;
                chbHasBox.Visible = false;
                nbNumberOfDoors.Visible = false;
                if (selectedVehicle is Car car)
                {
                    AddBodytypes("Car");
                    CarSelected();
                    ChangeIcon("CarIcon");
                }
                else if (selectedVehicle is Truck truck)
                {
                    AddBodytypes("Truck");
                    TruckSelected();
                    ChangeIcon("TruckIcon");
                }
                else if (selectedVehicle is Motorcycle motorcycle)
                {
                    AddBodytypes("Motorcycle");
                    MotorcycleSelected();
                    ChangeIcon("MotorcycleIcon");
                }
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AddBodytypes(string vehicleType)
        {
            this.vehicleTypes = _vehicleManager.ReadVehicleTypes(vehicleType);
            foreach (string bodyType in vehicleTypes.Values)
            {
                cbBodyType.Items.Add(bodyType);
                if(bodyType.Equals(selectedVehicle.GetBodyType))
                {
                    cbBodyType.SelectedItem = bodyType;
                }
            }
        }
        public void CarSelected()
        {
            labelPlayLoadCapacity.Text = "Doors:";
            nbPlayloadCapacity.Visible = false;
            labelAxles.Visible = false;
            nbNumberOfDoors.Visible = true;
        }
        public void TruckSelected()
        {
            labelPlayLoadCapacity.Text = "Playload Capacity (kg):";
            nbPlayloadCapacity.Visible = true;
            labelAxles.Visible = true;
            labelAxles.Text = "Axles:";
            rb2Axles.Visible = true;
            rb3Axles.Visible = true;
            rb4Axles.Visible = true;
            rb5Axles.Visible = true;
            rb6Axles.Visible = true;
            rb7Axles.Visible = true;
        }
        public void MotorcycleSelected()
        {
            labelPlayLoadCapacity.Text = "Wind Shield:";
            nbPlayloadCapacity.Visible = false;
            chbHasWindShield.Visible = true;
            labelAxles.Text = "Has box:";
            labelAxles.Visible = true;
            chbHasBox.Visible = true;
            labelSteeringWheel.Visible = false;
            cbSteeringWheelType.Visible = false;
            labelEnginePower.Text = "Cubic Capacity";
        }
        private void DisableEnableAllControls(bool decision)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Label ||
                    control is TextBox ||
                    control is ComboBox ||
                    control is NumericUpDown ||
                    control is System.Windows.Forms.RadioButton ||
                    control is System.Windows.Forms.CheckBox ||
                    control is DateTimePicker ||
                    control is Button)
                {
                    control.Visible = decision;
                }
            }
        }
        private void ChangeIcon(string vehicle)
        {
            string parentFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..");
            string subfolderPath = Path.Combine(parentFolderPath, "Pictures", "icons");
            string[] imageFiles = Directory.GetFiles(subfolderPath);
            Image vehicleIcon = null;

            foreach (string icon in imageFiles)
            {
                if (icon.Contains(vehicle))
                {
                    vehicleIcon = Image.FromFile(icon);
                    break; 
                }
            }
            pbVehicleIcon.Image = vehicleIcon;
        }
        private void AddInfo()
        {
            tbBrand.Text = selectedVehicle.GetBrand;
            tbModel.Text = selectedVehicle.GetModel;
            dateOfProduction.Value = selectedVehicle.GetYearOfProduction;
            tbImageURL.Text = selectedVehicle.GetImage;
            OpenImage(selectedVehicle.GetImage);
            foreach (var item in cbTransmission.Items)
            {
                if (selectedVehicle.GetTransmissionType.ToString() == item.ToString())
                {
                    cbTransmission.SelectedItem = item;
                }
            }
            nmMileage.Value = Convert.ToDecimal(selectedVehicle.GetMileage);
            foreach (var item in cbColor.Items)
            {
                if (selectedVehicle.GetColor.ToString() == item.ToString())
                {
                    cbColor.SelectedItem = item;
                }
            }
            foreach (var item in cbEngine1Type.Items)
            {
                if (selectedVehicle.GetEngine.GetEngineType.ToString() == item.ToString())
                {
                    cbEngine1Type.SelectedItem = item;
                }
            }
            cbFuelType1.SelectedItem = selectedVehicle.GetEngine.GetFuelType;
            nbPrice.Value = Convert.ToDecimal(selectedVehicle.GetPrice);
            if (selectedVehicle is Car car)
            {
                nbEnginePower.Value = Convert.ToDecimal(car.GetHorsePower);
                nbNumberOfDoors.Value = Convert.ToDecimal(car.GetNumberOfDoors);
                foreach (var item in cbSteeringWheelType.Items)
                {
                    if (car.GetSteeringWheel.ToString() == item.ToString())
                    {
                        cbSteeringWheelType.SelectedItem = item;
                    }
                }

            }
            if (selectedVehicle is Truck truck)
            {
                foreach (var item in cbSteeringWheelType.Items)
                {
                    if (truck.GetSteeeringWheelType.ToString() == item.ToString())
                    {
                        cbSteeringWheelType.SelectedItem = item;
                    }
                }
                nbPlayloadCapacity.Value = Convert.ToDecimal(truck.GetPlayLoadCapacity);
                nbEnginePower.Value = Convert.ToDecimal(truck.GetHorsePower);
                foreach (Control control in this.Controls)
                {
                    if (control is RadioButton radioButton && control.Text.Equals(truck.GetNumberOfAxles.ToString()))
                    {
                        radioButton.Checked = true;
                    }
                }
            }
            if (selectedVehicle is Motorcycle motorcycle)
            {
                if (motorcycle.GetHasABox)
                {
                    chbHasBox.Checked = true;
                }
                if (motorcycle.GetHasWindShield)
                {
                    chbHasWindShield.Checked = true;
                }
                nbEnginePower.Value = Convert.ToDecimal(motorcycle.GetCubicCapacity);
            }
            foreach (var item in cbCondition.Items)
            {
                if (selectedVehicle.GetCondition.ToString() == item.ToString())
                {
                    cbCondition.SelectedItem = item;
                }
            }
        }

        private void cbEngine1Type_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cbFuelType1.Items.Clear();
            cbFuelType1.ResetText();
            if (cbEngine1Type.SelectedIndex == 0 || cbEngine1Type.SelectedIndex == 02)
            {
                cbFuelType1.Items.Add("Diesel");
                cbFuelType1.Items.Add("Gas");
                cbFuelType1.Items.Add("Petrol");
            }
            if (cbEngine1Type.SelectedIndex == 01)
            {
                cbFuelType1.Items.Add("Battery");
            }
            foreach (var item in cbEngine1Type.Items)
            {
                if (selectedVehicle.GetEngine.GetFuelType.ToString() == item.ToString())
                {
                    cbFuelType1.SelectedItem = item;
                }
            }
        }

        private void btnUpdateVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                if (RemoteFileExists(tbImageURL.Text))
                {
                    Vehicle newVehicle = null;

                    bool areVisibleTextBoxesEmpty = false;
                    bool areVisibleComboBoxesEmpty = false;
                    bool areVisibleNMenuesEmpty = false;

                    foreach (Control control in this.Controls)
                    {
                        if (control is TextBox textBox && textBox.Visible)
                        {
                            if (string.IsNullOrEmpty(textBox.Text))
                            {
                                areVisibleTextBoxesEmpty = true;
                                break;
                            }
                        }
                    }

                    foreach (Control control in this.Controls)
                    {
                        if (control is ComboBox comboBox && comboBox.Visible)
                        {
                            if (comboBox.SelectedItem == null)
                            {
                                areVisibleComboBoxesEmpty = true;
                                break;
                            }
                        }
                    }

                    foreach (Control control in this.Controls)
                    {
                        if (control is NumericUpDown numericalmenu && numericalmenu.Visible)
                        {
                            if (string.IsNullOrEmpty(numericalmenu.Text) || numericalmenu.Value <= numericalmenu.Minimum)
                            {
                                numericalmenu.Text = "";
                                areVisibleNMenuesEmpty = true;
                                break;
                            }
                        }
                    }

                    if (!areVisibleTextBoxesEmpty && !areVisibleComboBoxesEmpty && !areVisibleNMenuesEmpty)
                    {
                        int price = Convert.ToInt32(nbPrice.Value);
                        TransmissionType seleced_transmission = (TransmissionType)Enum.Parse(typeof(TransmissionType), cbTransmission.SelectedItem.ToString());
                        string color = cbColor.SelectedItem.ToString();
                        DateTime vehicleProductionDate = dateOfProduction.Value;
                        string brand = tbBrand.Text;
                        string model = tbModel.Text;
                        Condition seleced_condition = (Condition)Enum.Parse(typeof(Condition), cbCondition.SelectedItem.ToString());
                        bool isBought = false;
                        bool isReserved = selectedVehicle.GetIsReserved;
                        int horsePower = Convert.ToInt32(nbEnginePower.Value);
                        int mileage = Convert.ToInt32(nmMileage.Value);
                        EngineType selected_engineType1 = (EngineType)Enum.Parse(typeof(EngineType), cbEngine1Type.SelectedItem.ToString());
                        string fuelType1 = cbFuelType1.SelectedItem.ToString();
                        //For Car
                        if (selectedVehicle is Car)
                        {
                            SteeringWheelType seleced_SteeringWheelType = (SteeringWheelType)Enum.Parse(typeof(SteeringWheelType), cbSteeringWheelType.SelectedItem.ToString());
                            int numberOfDoors = Convert.ToInt32(nbNumberOfDoors.Value);
                                newVehicle = new Car(selectedVehicle.GetVehicleId, price, seleced_transmission, color, vehicleProductionDate, brand, model, seleced_condition, isBought, isReserved,
                            horsePower, seleced_SteeringWheelType, numberOfDoors, mileage, selectedVehicle.GetPublicationDate, selectedVehicle.GetAverageRating, tbImageURL.Text, new Engine(selected_engineType1, fuelType1), cbBodyType.SelectedItem.ToString());
                        }
                        //For Truck
                        else if (selectedVehicle is Truck)
                        {
                            SteeringWheelType seleced_SteeringWheelType = (SteeringWheelType)Enum.Parse(typeof(SteeringWheelType), cbSteeringWheelType.SelectedItem.ToString());
                            int numOfAxles = 0;
                            foreach (Control control in this.Controls)
                            {
                                if (control is System.Windows.Forms.RadioButton radioButton && radioButton.Checked)
                                {
                                    numOfAxles = Convert.ToInt32(radioButton.Text);
                                    break;
                                }
                            }
                            int playLoadCapacity = Convert.ToInt32(nbPlayloadCapacity.Value);
                            newVehicle = new Truck(selectedVehicle.GetVehicleId, price, seleced_transmission, color, vehicleProductionDate, brand, model, seleced_condition, isBought, isReserved,
                            horsePower, numOfAxles, playLoadCapacity, seleced_SteeringWheelType, mileage, selectedVehicle.GetPublicationDate, selectedVehicle.GetAverageRating, tbImageURL.Text, new Engine(selected_engineType1, fuelType1), cbBodyType.SelectedItem.ToString());
                        }
                        //For Motorcycle
                        else if (selectedVehicle is Motorcycle)
                        {
                            bool hasWindShield = chbHasWindShield.Checked;
                            bool hasBox = chbHasBox.Checked;
                                newVehicle = new Motorcycle(selectedVehicle.GetVehicleId, price, seleced_transmission, color, vehicleProductionDate, brand, model, seleced_condition, isBought, isReserved,
                                    horsePower, mileage, hasWindShield, hasBox, selectedVehicle.GetPublicationDate, selectedVehicle.GetAverageRating, tbImageURL.Text, new Engine(selected_engineType1, fuelType1), cbBodyType.SelectedItem.ToString());
                        }

                        _vehicleManager.UpdateVehicle(newVehicle);
                        MessageBox.Show("Success");
                        manageVehiclesPage.ResetPage();
                        manageVehiclesPage.Show();
                        this.FormClosing -= UpdateVehicle_Closing;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Not all fields are populated with data");
                    }
                }
                else
                {
                    MessageBox.Show("Please add an image");
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
        
        private void OpenImage(string imageURL)
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
                MessageBox.Show("Image could not be accessed");
            }
}
        

        private void tbImageURL_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbImageURL.Text))
            {
                btnTestImage.Enabled = true;
                pbVehicleImage.Image = pbVehicleImage.ErrorImage;
            }
            btnUpdateVehicle.Enabled = false;
        }
        private bool RemoteFileExists(string url)
        {
            try
            {
                var request = WebRequest.Create(url);
                request.Timeout = 5000;
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (!response.ContentType.Contains("text/html"))
                        {
                            using (var br = new BinaryReader(responseStream))
                            {
                                var soi = br.ReadUInt16();
                                var jfif = br.ReadUInt16();
                                return soi == 0xd8ff && jfif == 0xe0ff;
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {

                MessageBox.Show("Imagge error occured. Image can not be found.");
            }
            return false;
        }

        private void btnTestImage_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (RemoteFileExists(tbImageURL.Text))
                {
                    OpenImage(tbImageURL.Text);
                    btnUpdateVehicle.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Invalid link");
                }
            }
            catch (WebException ex)
            {
                pbVehicleImage.Image = pbVehicleImage.ErrorImage;
                MessageBox.Show("Image can not be accessed");
            }
        }
        private void UpdateVehicle_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult[] results = { DialogResult.Yes, DialogResult.Cancel };
            string userResponse = "";
            string message = "Are you sure you want to close the tab? \n No changes will be saved";
            if (results.Contains(ConfirmationBox(ref userResponse, message)))
            {
                if (userResponse.Equals("Yes"))
                {
                    manageVehiclesPage.Show();
                    this.FormClosing -= UpdateVehicle_Closing;
                    this.Close();
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