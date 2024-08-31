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
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FormApplication
{
    public partial class AddVehiclePage : Form
    {
        private readonly IVehicleAdvancedInterfaceLogicLayer _vehicleManager;
        private bool close_application;
        private ManageVehiclesPage manageVehiclesPage;
        private Dictionary<int, string> vehicleTypes;
        public AddVehiclePage(IVehicleAdvancedInterfaceLogicLayer vehicleManager, ManageVehiclesPage manageVehiclesPage)
        {
            InitializeComponent();
            _vehicleManager = vehicleManager;
            DisableEnableAllControls(false);
            close_application = true;
            this.manageVehiclesPage = manageVehiclesPage;
            nbEnginePower.Value = 5;
            nmMileage.Value = 0;
            nbPrice.Value = 10;
            nbNumberOfDoors.Value = 1;
            nbPlayloadCapacity.Value = 500;
            pbVehicleImage.Visible = false;
            dateOfProduction.MaxDate = DateTime.Today;
            btnAddVehicle.Enabled = false;
            btnTestImage.Enabled = false;
            this.FormClosing += AddVehiclePage_Closing;
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
            labelSelectVehicleType.Visible = true;
            cbSelectedVehicle.Visible = true;
        }

        public void ResetDataValues()
        {
            foreach (Control control in this.Controls)
            {
                if ((control is TextBox ||
                     control is ComboBox ||
                     control is NumericUpDown ||
                     control is DateTimePicker) &&
                    control != cbSelectedVehicle)
                {
                    control.ResetText();
                }
            }
        }
        private void cbSelectedVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSelectedVehicle.SelectedItem != null)
                {
                    cbBodyType.Items.Clear();
                    ResetDataValues();
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
                    pbVehicleImage.Visible = true;

                    if (cbSelectedVehicle.SelectedIndex == 0)
                    {
                        AddBodytypes("Car");
                        CarSelected();
                        ChangeIcon("CarIcon");
                    }
                    else if (cbSelectedVehicle.SelectedIndex == 1)
                    {
                        AddBodytypes("Truck");
                        TruckSelected();
                        ChangeIcon("TruckIcon");
                    }
                    else if (cbSelectedVehicle.SelectedIndex == 2)
                    {
                        AddBodytypes("Motorcycle");
                        MotorcycleSelected();
                        ChangeIcon("MotorcycleIcon");
                    }
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

        private void btnAddVehicle_Click(object sender, EventArgs e)
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
                        bool isReserved = false;
                        int horsePower = Convert.ToInt32(nbEnginePower.Value);
                        int mileage = Convert.ToInt32(nmMileage.Value);
                        EngineType selected_engineType1 = (EngineType)Enum.Parse(typeof(EngineType), cbEngine1Type.SelectedItem.ToString());
                        string fuelType1 = cbFuelType1.SelectedItem.ToString();
                        //For Car
                        if (cbSelectedVehicle.SelectedIndex == 0)
                        {
                            SteeringWheelType seleced_SteeringWheelType = (SteeringWheelType)Enum.Parse(typeof(SteeringWheelType), cbSteeringWheelType.SelectedItem.ToString());
                            int numberOfDoors = Convert.ToInt32(nbNumberOfDoors.Value);
                            newVehicle = new Car(price, seleced_transmission, color, vehicleProductionDate, brand, model, seleced_condition, isBought, isReserved,
                            horsePower, seleced_SteeringWheelType, numberOfDoors, mileage, DateTime.Today, 3, tbImageURL.Text, new Engine(selected_engineType1, fuelType1), cbBodyType.SelectedItem.ToString());
                        }
                        //For Truck
                        else if (cbSelectedVehicle.SelectedIndex == 1)
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
                            newVehicle = new Truck(price, seleced_transmission, color, vehicleProductionDate, brand, model, seleced_condition, isBought, isReserved,
                            horsePower, numOfAxles, playLoadCapacity, seleced_SteeringWheelType, mileage, DateTime.Today, 3, tbImageURL.Text, new Engine(selected_engineType1, fuelType1), cbBodyType.SelectedItem.ToString());
                        }
                        //For Motorcycle
                        else if (cbSelectedVehicle.SelectedIndex == 2)
                        {
                            bool hasWindShield = chbHasWindShield.Checked;
                            bool hasBox = chbHasBox.Checked;
                            newVehicle = new Motorcycle(price, seleced_transmission, color, vehicleProductionDate, brand, model, seleced_condition, isBought, isReserved,
                                horsePower, mileage, hasWindShield, hasBox, DateTime.Today, 3, tbImageURL.Text, new Engine(selected_engineType1, fuelType1), cbBodyType.SelectedItem.ToString());
                        }
                        _vehicleManager.CreateVehicle(newVehicle);
                        ResetDataValues();
                        MessageBox.Show("Success");
                        manageVehiclesPage.Show();
                        manageVehiclesPage.ResetPage();
                        this.FormClosing -= AddVehiclePage_Closing;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult[] results = { DialogResult.Yes, DialogResult.Cancel };
            string userResponse = "";
            string message = "If you go back, vehicle will not be added \nand changes will not be saved";
            if (results.Contains(ConfirmationBox(ref userResponse, message)))
            {
                if (userResponse.Equals("Yes"))
                {
                    close_application = false;
                    manageVehiclesPage.Show();
                    manageVehiclesPage.ResetPage();
                    this.FormClosing -= AddVehiclePage_Closing;
                    this.Close();
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

        private void cbEngine1Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFuelType1.Items.Clear();
            if (cbEngine1Type.SelectedIndex == 0)
            {
                cbFuelType1.Items.Add("Diesel");
                cbFuelType1.Items.Add("Gas");
                cbFuelType1.Items.Add("Petrol");
            }
            if (cbEngine1Type.SelectedIndex == 01)
            {
                cbFuelType1.Items.Add("Battery");
            }
            if (cbEngine1Type.SelectedIndex == 02)
            {
                cbFuelType1.Items.Add("Diesel");
                cbFuelType1.Items.Add("Gas");
                cbFuelType1.Items.Add("Petrol");
            }
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
                MessageBox.Show("Imagge error occured. Image can not be found.");
            }
        }

        private void btnTestImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (RemoteFileExists(tbImageURL.Text))
                {
                    OpenImage(tbImageURL.Text);
                    btnAddVehicle.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Image can not be accessed");
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Invalid link");
            }
        }

        private void tbImageURL_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbImageURL.Text))
            {
                btnTestImage.Enabled = true;
            }
        }
        private void AddVehiclePage_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult[] results = { DialogResult.Yes, DialogResult.Cancel };
            string userResponse = "";
            string message = "Are you sure you want to close the tab? \n Vehicle will not be added and changes will be saved";
            if (results.Contains(ConfirmationBox(ref userResponse, message)))
            {
                if (userResponse.Equals("Yes"))
                {
                    close_application = false;
                    manageVehiclesPage.Show();
                    this.FormClosing -= AddVehiclePage_Closing;
                    this.Close();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
