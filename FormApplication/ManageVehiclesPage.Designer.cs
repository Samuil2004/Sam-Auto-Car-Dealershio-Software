namespace FormApplication
{
    partial class ManageVehiclesPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageVehiclesPage));
            lbVehiclesList = new ListBox();
            labelCarHeader = new Label();
            labelDateOfProduction = new Label();
            labelVehicleDateOfProduction = new Label();
            labelEngine = new Label();
            labelVehicleEngine = new Label();
            labelEnginePower = new Label();
            labelVehicleEnginePower = new Label();
            labelPrice = new Label();
            labelTransmission = new Label();
            labelVehicleTransmission = new Label();
            labelBodyType = new Label();
            labelVehicleBodyType = new Label();
            labelColor = new Label();
            labelVehicleColor = new Label();
            labelMileage = new Label();
            labelVehicleMileage = new Label();
            labelCondition = new Label();
            labelVehicleCondition = new Label();
            labelPlayLoadCapacity = new Label();
            labelTruckPlayLoadCapacity = new Label();
            labelSteeringWheel = new Label();
            labelVehicleSteeringWheel = new Label();
            labelAxles = new Label();
            labelTruckAxles = new Label();
            labelResults = new Label();
            labelSearch = new Label();
            gbVehicleInformation = new GroupBox();
            btnDeleteVehicle = new Button();
            labelVehicleFloorPrice = new Label();
            FloorPriceHere = new Label();
            labelFuelType = new Label();
            labelFuel = new Label();
            pbVehicleImage = new PictureBox();
            btnSellVehicle = new Button();
            btnUpdateVehicle = new Button();
            btnNextPage = new Button();
            btnPrevPage = new Button();
            pbBackToMenu = new PictureBox();
            btnAddNewVehicle = new Button();
            labelPageNum = new Label();
            tbSearchBar = new TextBox();
            pbSearch = new PictureBox();
            gbVehicleInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbVehicleImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBackToMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
            SuspendLayout();
            // 
            // lbVehiclesList
            // 
            lbVehiclesList.BackColor = Color.FromArgb(94, 94, 94);
            lbVehiclesList.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbVehiclesList.ForeColor = SystemColors.Info;
            lbVehiclesList.FormattingEnabled = true;
            lbVehiclesList.ItemHeight = 40;
            lbVehiclesList.Location = new Point(31, 305);
            lbVehiclesList.Name = "lbVehiclesList";
            lbVehiclesList.Size = new Size(503, 804);
            lbVehiclesList.TabIndex = 0;
            lbVehiclesList.SelectedIndexChanged += lbVehiclesList_SelectedIndexChanged;
            // 
            // labelCarHeader
            // 
            labelCarHeader.AutoSize = true;
            labelCarHeader.BackColor = Color.Transparent;
            labelCarHeader.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelCarHeader.Location = new Point(20, 55);
            labelCarHeader.Name = "labelCarHeader";
            labelCarHeader.Size = new Size(319, 50);
            labelCarHeader.TabIndex = 9;
            labelCarHeader.Text = "Brand and Model";
            // 
            // labelDateOfProduction
            // 
            labelDateOfProduction.AutoSize = true;
            labelDateOfProduction.BackColor = Color.Transparent;
            labelDateOfProduction.Location = new Point(17, 247);
            labelDateOfProduction.Name = "labelDateOfProduction";
            labelDateOfProduction.Size = new Size(221, 32);
            labelDateOfProduction.TabIndex = 10;
            labelDateOfProduction.Text = "Date of Production:";
            // 
            // labelVehicleDateOfProduction
            // 
            labelVehicleDateOfProduction.AutoSize = true;
            labelVehicleDateOfProduction.BackColor = Color.Transparent;
            labelVehicleDateOfProduction.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelVehicleDateOfProduction.Location = new Point(17, 289);
            labelVehicleDateOfProduction.Name = "labelVehicleDateOfProduction";
            labelVehicleDateOfProduction.Size = new Size(128, 32);
            labelVehicleDateOfProduction.TabIndex = 11;
            labelVehicleDateOfProduction.Text = "Date Here";
            // 
            // labelEngine
            // 
            labelEngine.AutoSize = true;
            labelEngine.BackColor = Color.Transparent;
            labelEngine.Location = new Point(20, 623);
            labelEngine.Name = "labelEngine";
            labelEngine.Size = new Size(92, 32);
            labelEngine.TabIndex = 12;
            labelEngine.Text = "Engine:";
            // 
            // labelVehicleEngine
            // 
            labelVehicleEngine.AutoSize = true;
            labelVehicleEngine.BackColor = Color.Transparent;
            labelVehicleEngine.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelVehicleEngine.Location = new Point(187, 623);
            labelVehicleEngine.Name = "labelVehicleEngine";
            labelVehicleEngine.Size = new Size(153, 32);
            labelVehicleEngine.TabIndex = 13;
            labelVehicleEngine.Text = "Engine Here";
            // 
            // labelEnginePower
            // 
            labelEnginePower.AutoSize = true;
            labelEnginePower.BackColor = Color.Transparent;
            labelEnginePower.Location = new Point(17, 330);
            labelEnginePower.Name = "labelEnginePower";
            labelEnginePower.Size = new Size(163, 32);
            labelEnginePower.TabIndex = 24;
            labelEnginePower.Text = "Engine Power:";
            // 
            // labelVehicleEnginePower
            // 
            labelVehicleEnginePower.AutoSize = true;
            labelVehicleEnginePower.BackColor = Color.Transparent;
            labelVehicleEnginePower.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelVehicleEnginePower.Location = new Point(187, 330);
            labelVehicleEnginePower.Name = "labelVehicleEnginePower";
            labelVehicleEnginePower.Size = new Size(231, 32);
            labelVehicleEnginePower.TabIndex = 25;
            labelVehicleEnginePower.Text = "Engine Power Here";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.BackColor = Color.Transparent;
            labelPrice.FlatStyle = FlatStyle.Popup;
            labelPrice.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrice.ForeColor = Color.FromArgb(45, 66, 254);
            labelPrice.Location = new Point(20, 126);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(155, 37);
            labelPrice.TabIndex = 26;
            labelPrice.Text = "Price Here";
            // 
            // labelTransmission
            // 
            labelTransmission.AutoSize = true;
            labelTransmission.BackColor = Color.Transparent;
            labelTransmission.Location = new Point(17, 387);
            labelTransmission.Name = "labelTransmission";
            labelTransmission.Size = new Size(155, 32);
            labelTransmission.TabIndex = 27;
            labelTransmission.Text = "Transmission:";
            // 
            // labelVehicleTransmission
            // 
            labelVehicleTransmission.AutoSize = true;
            labelVehicleTransmission.BackColor = Color.Transparent;
            labelVehicleTransmission.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelVehicleTransmission.Location = new Point(187, 387);
            labelVehicleTransmission.Name = "labelVehicleTransmission";
            labelVehicleTransmission.Size = new Size(285, 32);
            labelVehicleTransmission.TabIndex = 28;
            labelVehicleTransmission.Text = "Transmission Type Here";
            // 
            // labelBodyType
            // 
            labelBodyType.AutoSize = true;
            labelBodyType.BackColor = Color.Transparent;
            labelBodyType.Location = new Point(17, 441);
            labelBodyType.Name = "labelBodyType";
            labelBodyType.Size = new Size(131, 32);
            labelBodyType.TabIndex = 29;
            labelBodyType.Text = "Body Type:";
            // 
            // labelVehicleBodyType
            // 
            labelVehicleBodyType.AutoSize = true;
            labelVehicleBodyType.BackColor = Color.Transparent;
            labelVehicleBodyType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelVehicleBodyType.Location = new Point(187, 441);
            labelVehicleBodyType.Name = "labelVehicleBodyType";
            labelVehicleBodyType.Size = new Size(194, 32);
            labelVehicleBodyType.TabIndex = 30;
            labelVehicleBodyType.Text = "Body Type Here";
            // 
            // labelColor
            // 
            labelColor.AutoSize = true;
            labelColor.BackColor = Color.Transparent;
            labelColor.Location = new Point(20, 569);
            labelColor.Name = "labelColor";
            labelColor.Size = new Size(76, 32);
            labelColor.TabIndex = 31;
            labelColor.Text = "Color:";
            // 
            // labelVehicleColor
            // 
            labelVehicleColor.AutoSize = true;
            labelVehicleColor.BackColor = Color.Transparent;
            labelVehicleColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelVehicleColor.Location = new Point(187, 569);
            labelVehicleColor.Name = "labelVehicleColor";
            labelVehicleColor.Size = new Size(137, 32);
            labelVehicleColor.TabIndex = 32;
            labelVehicleColor.Text = "Color Here";
            // 
            // labelMileage
            // 
            labelMileage.AutoSize = true;
            labelMileage.BackColor = Color.Transparent;
            labelMileage.Location = new Point(17, 505);
            labelMileage.Name = "labelMileage";
            labelMileage.Size = new Size(159, 32);
            labelMileage.TabIndex = 33;
            labelMileage.Text = "Mileage (km):";
            // 
            // labelVehicleMileage
            // 
            labelVehicleMileage.AutoSize = true;
            labelVehicleMileage.BackColor = Color.Transparent;
            labelVehicleMileage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelVehicleMileage.Location = new Point(187, 505);
            labelVehicleMileage.Name = "labelVehicleMileage";
            labelVehicleMileage.Size = new Size(166, 32);
            labelVehicleMileage.TabIndex = 34;
            labelVehicleMileage.Text = "Mileage Here";
            // 
            // labelCondition
            // 
            labelCondition.AutoSize = true;
            labelCondition.BackColor = Color.Transparent;
            labelCondition.Location = new Point(17, 728);
            labelCondition.Name = "labelCondition";
            labelCondition.Size = new Size(124, 32);
            labelCondition.TabIndex = 39;
            labelCondition.Text = "Condition:";
            // 
            // labelVehicleCondition
            // 
            labelVehicleCondition.AutoSize = true;
            labelVehicleCondition.BackColor = Color.Transparent;
            labelVehicleCondition.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelVehicleCondition.Location = new Point(187, 728);
            labelVehicleCondition.Name = "labelVehicleCondition";
            labelVehicleCondition.Size = new Size(188, 32);
            labelVehicleCondition.TabIndex = 40;
            labelVehicleCondition.Text = "Condition Here";
            // 
            // labelPlayLoadCapacity
            // 
            labelPlayLoadCapacity.AutoSize = true;
            labelPlayLoadCapacity.BackColor = Color.Transparent;
            labelPlayLoadCapacity.Location = new Point(467, 789);
            labelPlayLoadCapacity.Name = "labelPlayLoadCapacity";
            labelPlayLoadCapacity.Size = new Size(205, 32);
            labelPlayLoadCapacity.TabIndex = 45;
            labelPlayLoadCapacity.Text = "Playload Capacity:";
            // 
            // labelTruckPlayLoadCapacity
            // 
            labelTruckPlayLoadCapacity.AutoSize = true;
            labelTruckPlayLoadCapacity.BackColor = Color.Transparent;
            labelTruckPlayLoadCapacity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTruckPlayLoadCapacity.Location = new Point(709, 789);
            labelTruckPlayLoadCapacity.Name = "labelTruckPlayLoadCapacity";
            labelTruckPlayLoadCapacity.Size = new Size(277, 32);
            labelTruckPlayLoadCapacity.TabIndex = 46;
            labelTruckPlayLoadCapacity.Text = "Playload Capacity Here";
            // 
            // labelSteeringWheel
            // 
            labelSteeringWheel.AutoSize = true;
            labelSteeringWheel.BackColor = Color.Transparent;
            labelSteeringWheel.Location = new Point(466, 738);
            labelSteeringWheel.Name = "labelSteeringWheel";
            labelSteeringWheel.Size = new Size(182, 32);
            labelSteeringWheel.TabIndex = 47;
            labelSteeringWheel.Text = "Steering Wheel:";
            // 
            // labelVehicleSteeringWheel
            // 
            labelVehicleSteeringWheel.AutoSize = true;
            labelVehicleSteeringWheel.BackColor = Color.Transparent;
            labelVehicleSteeringWheel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelVehicleSteeringWheel.Location = new Point(709, 738);
            labelVehicleSteeringWheel.Name = "labelVehicleSteeringWheel";
            labelVehicleSteeringWheel.Size = new Size(247, 32);
            labelVehicleSteeringWheel.TabIndex = 48;
            labelVehicleSteeringWheel.Text = "Steering Wheel Here";
            // 
            // labelAxles
            // 
            labelAxles.AutoSize = true;
            labelAxles.BackColor = Color.Transparent;
            labelAxles.Location = new Point(465, 846);
            labelAxles.Name = "labelAxles";
            labelAxles.Size = new Size(74, 32);
            labelAxles.TabIndex = 49;
            labelAxles.Text = "Axles:";
            // 
            // labelTruckAxles
            // 
            labelTruckAxles.AutoSize = true;
            labelTruckAxles.BackColor = Color.Transparent;
            labelTruckAxles.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTruckAxles.Location = new Point(709, 846);
            labelTruckAxles.Name = "labelTruckAxles";
            labelTruckAxles.Size = new Size(136, 32);
            labelTruckAxles.TabIndex = 50;
            labelTruckAxles.Text = "Axles Here";
            // 
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.BackColor = Color.Transparent;
            labelResults.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelResults.ForeColor = SystemColors.ButtonHighlight;
            labelResults.Location = new Point(31, 265);
            labelResults.Name = "labelResults";
            labelResults.Size = new Size(111, 37);
            labelResults.TabIndex = 51;
            labelResults.Text = "Results:";
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.BackColor = Color.Transparent;
            labelSearch.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSearch.ForeColor = SystemColors.ButtonHighlight;
            labelSearch.Location = new Point(31, 162);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(106, 37);
            labelSearch.TabIndex = 52;
            labelSearch.Text = "Search:";
            // 
            // gbVehicleInformation
            // 
            gbVehicleInformation.BackColor = Color.FromArgb(130, 160, 188);
            gbVehicleInformation.Controls.Add(btnDeleteVehicle);
            gbVehicleInformation.Controls.Add(labelVehicleFloorPrice);
            gbVehicleInformation.Controls.Add(FloorPriceHere);
            gbVehicleInformation.Controls.Add(labelFuelType);
            gbVehicleInformation.Controls.Add(labelFuel);
            gbVehicleInformation.Controls.Add(pbVehicleImage);
            gbVehicleInformation.Controls.Add(btnSellVehicle);
            gbVehicleInformation.Controls.Add(labelVehicleSteeringWheel);
            gbVehicleInformation.Controls.Add(labelVehicleEnginePower);
            gbVehicleInformation.Controls.Add(btnUpdateVehicle);
            gbVehicleInformation.Controls.Add(labelCarHeader);
            gbVehicleInformation.Controls.Add(labelDateOfProduction);
            gbVehicleInformation.Controls.Add(labelTruckAxles);
            gbVehicleInformation.Controls.Add(labelVehicleDateOfProduction);
            gbVehicleInformation.Controls.Add(labelAxles);
            gbVehicleInformation.Controls.Add(labelEngine);
            gbVehicleInformation.Controls.Add(labelVehicleEngine);
            gbVehicleInformation.Controls.Add(labelSteeringWheel);
            gbVehicleInformation.Controls.Add(labelTruckPlayLoadCapacity);
            gbVehicleInformation.Controls.Add(labelPlayLoadCapacity);
            gbVehicleInformation.Controls.Add(labelVehicleCondition);
            gbVehicleInformation.Controls.Add(labelCondition);
            gbVehicleInformation.Controls.Add(labelEnginePower);
            gbVehicleInformation.Controls.Add(labelPrice);
            gbVehicleInformation.Controls.Add(labelTransmission);
            gbVehicleInformation.Controls.Add(labelVehicleMileage);
            gbVehicleInformation.Controls.Add(labelVehicleTransmission);
            gbVehicleInformation.Controls.Add(labelMileage);
            gbVehicleInformation.Controls.Add(labelBodyType);
            gbVehicleInformation.Controls.Add(labelVehicleColor);
            gbVehicleInformation.Controls.Add(labelVehicleBodyType);
            gbVehicleInformation.Controls.Add(labelColor);
            gbVehicleInformation.Location = new Point(540, 142);
            gbVehicleInformation.Name = "gbVehicleInformation";
            gbVehicleInformation.Size = new Size(1297, 1047);
            gbVehicleInformation.TabIndex = 53;
            gbVehicleInformation.TabStop = false;
            gbVehicleInformation.Text = "Vehicle Information";
            // 
            // btnDeleteVehicle
            // 
            btnDeleteVehicle.BackColor = Color.Black;
            btnDeleteVehicle.FlatStyle = FlatStyle.Flat;
            btnDeleteVehicle.ForeColor = Color.White;
            btnDeleteVehicle.Location = new Point(6, 964);
            btnDeleteVehicle.Name = "btnDeleteVehicle";
            btnDeleteVehicle.Size = new Size(266, 74);
            btnDeleteVehicle.TabIndex = 58;
            btnDeleteVehicle.Text = "Delete";
            btnDeleteVehicle.UseVisualStyleBackColor = false;
            btnDeleteVehicle.Click += btnDeleteVehicle_Click;
            // 
            // labelVehicleFloorPrice
            // 
            labelVehicleFloorPrice.AutoSize = true;
            labelVehicleFloorPrice.BackColor = Color.Transparent;
            labelVehicleFloorPrice.FlatStyle = FlatStyle.Popup;
            labelVehicleFloorPrice.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelVehicleFloorPrice.ForeColor = Color.FromArgb(255, 255, 128);
            labelVehicleFloorPrice.Location = new Point(204, 172);
            labelVehicleFloorPrice.Name = "labelVehicleFloorPrice";
            labelVehicleFloorPrice.Size = new Size(241, 37);
            labelVehicleFloorPrice.TabIndex = 57;
            labelVehicleFloorPrice.Text = "Floor Price Here:";
            // 
            // FloorPriceHere
            // 
            FloorPriceHere.AutoSize = true;
            FloorPriceHere.BackColor = Color.Transparent;
            FloorPriceHere.FlatStyle = FlatStyle.Popup;
            FloorPriceHere.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FloorPriceHere.ForeColor = Color.Black;
            FloorPriceHere.Location = new Point(20, 172);
            FloorPriceHere.Name = "FloorPriceHere";
            FloorPriceHere.Size = new Size(169, 37);
            FloorPriceHere.TabIndex = 56;
            FloorPriceHere.Text = "Floor Price:";
            // 
            // labelFuelType
            // 
            labelFuelType.AutoSize = true;
            labelFuelType.BackColor = Color.Transparent;
            labelFuelType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFuelType.Location = new Point(187, 672);
            labelFuelType.Name = "labelFuelType";
            labelFuelType.Size = new Size(122, 32);
            labelFuelType.TabIndex = 55;
            labelFuelType.Text = "Fuel Here";
            // 
            // labelFuel
            // 
            labelFuel.AutoSize = true;
            labelFuel.BackColor = Color.Transparent;
            labelFuel.Location = new Point(20, 672);
            labelFuel.Name = "labelFuel";
            labelFuel.Size = new Size(64, 32);
            labelFuel.TabIndex = 54;
            labelFuel.Text = "Fuel:";
            // 
            // pbVehicleImage
            // 
            pbVehicleImage.ErrorImage = (Image)resources.GetObject("pbVehicleImage.ErrorImage");
            pbVehicleImage.Image = (Image)resources.GetObject("pbVehicleImage.Image");
            pbVehicleImage.InitialImage = (Image)resources.GetObject("pbVehicleImage.InitialImage");
            pbVehicleImage.Location = new Point(467, 132);
            pbVehicleImage.Name = "pbVehicleImage";
            pbVehicleImage.Size = new Size(824, 566);
            pbVehicleImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbVehicleImage.TabIndex = 51;
            pbVehicleImage.TabStop = false;
            // 
            // btnSellVehicle
            // 
            btnSellVehicle.BackColor = Color.FromArgb(184, 12, 9);
            btnSellVehicle.FlatStyle = FlatStyle.Flat;
            btnSellVehicle.Location = new Point(1025, 964);
            btnSellVehicle.Name = "btnSellVehicle";
            btnSellVehicle.Size = new Size(266, 74);
            btnSellVehicle.TabIndex = 5;
            btnSellVehicle.Text = "Sell";
            btnSellVehicle.UseVisualStyleBackColor = false;
            btnSellVehicle.Click += btnSellVehicle_Click;
            // 
            // btnUpdateVehicle
            // 
            btnUpdateVehicle.BackColor = Color.FromArgb(112, 193, 179);
            btnUpdateVehicle.FlatStyle = FlatStyle.Flat;
            btnUpdateVehicle.Location = new Point(1025, 21);
            btnUpdateVehicle.Name = "btnUpdateVehicle";
            btnUpdateVehicle.Size = new Size(266, 74);
            btnUpdateVehicle.TabIndex = 4;
            btnUpdateVehicle.Text = "Update Vehicle";
            btnUpdateVehicle.UseVisualStyleBackColor = false;
            btnUpdateVehicle.Click += btnUpdateVehicle_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.BackColor = Color.FromArgb(167, 204, 237);
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextPage.Location = new Point(475, 1111);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(59, 61);
            btnNextPage.TabIndex = 53;
            btnNextPage.Text = ">";
            btnNextPage.UseVisualStyleBackColor = false;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPrevPage
            // 
            btnPrevPage.BackColor = Color.FromArgb(167, 204, 237);
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrevPage.Location = new Point(334, 1111);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(59, 61);
            btnPrevPage.TabIndex = 52;
            btnPrevPage.Text = "<";
            btnPrevPage.UseVisualStyleBackColor = false;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // pbBackToMenu
            // 
            pbBackToMenu.BackColor = Color.Transparent;
            pbBackToMenu.Image = (Image)resources.GetObject("pbBackToMenu.Image");
            pbBackToMenu.Location = new Point(12, 12);
            pbBackToMenu.Name = "pbBackToMenu";
            pbBackToMenu.Size = new Size(135, 135);
            pbBackToMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBackToMenu.TabIndex = 54;
            pbBackToMenu.TabStop = false;
            pbBackToMenu.Click += pbBackToMenu_Click;
            // 
            // btnAddNewVehicle
            // 
            btnAddNewVehicle.BackColor = Color.FromArgb(4, 232, 36);
            btnAddNewVehicle.FlatStyle = FlatStyle.Flat;
            btnAddNewVehicle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddNewVehicle.Location = new Point(1565, 12);
            btnAddNewVehicle.Name = "btnAddNewVehicle";
            btnAddNewVehicle.Size = new Size(266, 74);
            btnAddNewVehicle.TabIndex = 3;
            btnAddNewVehicle.Text = "+Add vehicle";
            btnAddNewVehicle.UseVisualStyleBackColor = false;
            btnAddNewVehicle.Click += btnAddNewVehicle_Click;
            // 
            // labelPageNum
            // 
            labelPageNum.AutoSize = true;
            labelPageNum.BackColor = Color.Transparent;
            labelPageNum.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPageNum.ForeColor = Color.White;
            labelPageNum.Location = new Point(404, 1123);
            labelPageNum.Name = "labelPageNum";
            labelPageNum.Size = new Size(65, 37);
            labelPageNum.TabIndex = 56;
            labelPageNum.Text = "1/10";
            // 
            // tbSearchBar
            // 
            tbSearchBar.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearchBar.Location = new Point(31, 202);
            tbSearchBar.Name = "tbSearchBar";
            tbSearchBar.Size = new Size(431, 46);
            tbSearchBar.TabIndex = 57;
            //tbSearchBar.TextChanged += tbSearchBar_TextChanged;
            // 
            // pbSearch
            // 
            pbSearch.BackColor = Color.FromArgb(94, 94, 94);
            pbSearch.ErrorImage = (Image)resources.GetObject("pbSearch.ErrorImage");
            pbSearch.Image = (Image)resources.GetObject("pbSearch.Image");
            pbSearch.InitialImage = (Image)resources.GetObject("pbSearch.InitialImage");
            pbSearch.Location = new Point(469, 183);
            pbSearch.Margin = new Padding(4, 4, 4, 5);
            pbSearch.Name = "pbSearch";
            pbSearch.Size = new Size(65, 65);
            pbSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSearch.TabIndex = 58;
            pbSearch.TabStop = false;
            pbSearch.Click += pbSearch_Click;
            // 
            // ManageVehiclesPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(168, 174, 181);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1849, 1217);
            Controls.Add(pbSearch);
            Controls.Add(tbSearchBar);
            Controls.Add(labelPageNum);
            Controls.Add(pbBackToMenu);
            Controls.Add(gbVehicleInformation);
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Controls.Add(labelSearch);
            Controls.Add(labelResults);
            Controls.Add(btnAddNewVehicle);
            Controls.Add(lbVehiclesList);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(1875, 1288);
            MinimumSize = new Size(1875, 1288);
            Name = "ManageVehiclesPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Vehicles";
            FormClosing += AnyForm_FormClosing;
            gbVehicleInformation.ResumeLayout(false);
            gbVehicleInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbVehicleImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBackToMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbVehiclesList;
        private Label labelCarHeader;
        private Label labelDateOfProduction;
        private Label labelVehicleDateOfProduction;
        private Label labelEngine;
        private Label labelVehicleEngine;
        private Label labelEnginePower;
        private Label labelVehicleEnginePower;
        private Label labelPrice;
        private Label labelTransmission;
        private Label labelVehicleTransmission;
        private Label labelBodyType;
        private Label labelVehicleBodyType;
        private Label labelColor;
        private Label labelVehicleColor;
        private Label labelMileage;
        private Label labelVehicleMileage;
        private Label labelCondition;
        private Label labelVehicleCondition;
        private Label labelPlayLoadCapacity;
        private Label labelTruckPlayLoadCapacity;
        private Label labelSteeringWheel;
        private Label labelVehicleSteeringWheel;
        private Label labelAxles;
        private Label labelTruckAxles;
        private Label labelResults;
        private Label labelSearch;
        private GroupBox gbVehicleInformation;
        private PictureBox pbVehicleImage;
        private Button btnPrevPage;
        private Button btnNextPage;
        private PictureBox pbBackToMenu;
        private Label labelFuel;
        private Label labelFuelType;
        private Button btnSellVehicle;
        private Button btnUpdateVehicle;
        private Button btnAddNewVehicle;
        private Label labelPageNum;
        private Label FloorPriceHere;
        private Label labelVehicleFloorPrice;
        private Button btnDeleteVehicle;
        private TextBox tbSearchBar;
        private PictureBox pbSearch;
    }
}