using System.Windows.Forms;

namespace FormApplication
{
    partial class AddVehiclePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVehiclePage));
            labelSelectVehicleType = new Label();
            cbSelectedVehicle = new ComboBox();
            labelDateOfProduction = new Label();
            labelAxles = new Label();
            labelEngine = new Label();
            labelSteeringWheel = new Label();
            labelPlayLoadCapacity = new Label();
            labelCondition = new Label();
            labelEnginePower = new Label();
            labelTransmission = new Label();
            labelMileage = new Label();
            labelBodyType = new Label();
            labelColor = new Label();
            labelBrand = new Label();
            labelModel = new Label();
            tbBrand = new TextBox();
            tbModel = new TextBox();
            dateOfProduction = new DateTimePicker();
            nbEnginePower = new NumericUpDown();
            cbTransmission = new ComboBox();
            cbBodyType = new ComboBox();
            nmMileage = new NumericUpDown();
            cbEngine1Type = new ComboBox();
            cbSteeringWheelType = new ComboBox();
            cbCondition = new ComboBox();
            nbPlayloadCapacity = new NumericUpDown();
            rb2Axles = new RadioButton();
            rb3Axles = new RadioButton();
            rb4Axles = new RadioButton();
            rb5Axles = new RadioButton();
            rb6Axles = new RadioButton();
            rb7Axles = new RadioButton();
            chbHasWindShield = new CheckBox();
            chbHasBox = new CheckBox();
            nbNumberOfDoors = new NumericUpDown();
            btnAddVehicle = new Button();
            labelPrice = new Label();
            nbPrice = new NumericUpDown();
            labelImageURL = new Label();
            pbNavigateBack = new PictureBox();
            pbVehicleIcon = new PictureBox();
            labelFuelType = new Label();
            cbFuelType1 = new ComboBox();
            tbImageURL = new TextBox();
            btnTestImage = new Button();
            labelPreview = new Label();
            pbVehicleImage = new PictureBox();
            cbColor = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nbEnginePower).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmMileage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbPlayloadCapacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbNumberOfDoors).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNavigateBack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbVehicleIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbVehicleImage).BeginInit();
            SuspendLayout();
            // 
            // labelSelectVehicleType
            // 
            labelSelectVehicleType.AutoSize = true;
            labelSelectVehicleType.BackColor = Color.Transparent;
            labelSelectVehicleType.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelSelectVehicleType.ForeColor = SystemColors.ButtonHighlight;
            labelSelectVehicleType.Location = new Point(37, 179);
            labelSelectVehicleType.Name = "labelSelectVehicleType";
            labelSelectVehicleType.Size = new Size(359, 42);
            labelSelectVehicleType.TabIndex = 0;
            labelSelectVehicleType.Text = "Select Vehicle Type:";
            // 
            // cbSelectedVehicle
            // 
            cbSelectedVehicle.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSelectedVehicle.FormattingEnabled = true;
            cbSelectedVehicle.Items.AddRange(new object[] { "Car", "Truck", "Motorcycle" });
            cbSelectedVehicle.Location = new Point(40, 236);
            cbSelectedVehicle.Name = "cbSelectedVehicle";
            cbSelectedVehicle.Size = new Size(320, 40);
            cbSelectedVehicle.TabIndex = 1;
            cbSelectedVehicle.SelectedIndexChanged += cbSelectedVehicle_SelectedIndexChanged;
            // 
            // labelDateOfProduction
            // 
            labelDateOfProduction.AutoSize = true;
            labelDateOfProduction.BackColor = Color.Transparent;
            labelDateOfProduction.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelDateOfProduction.ForeColor = SystemColors.ButtonHighlight;
            labelDateOfProduction.Location = new Point(37, 421);
            labelDateOfProduction.Name = "labelDateOfProduction";
            labelDateOfProduction.Size = new Size(337, 42);
            labelDateOfProduction.TabIndex = 50;
            labelDateOfProduction.Text = "Date of Production:";
            // 
            // labelAxles
            // 
            labelAxles.AutoSize = true;
            labelAxles.BackColor = Color.Transparent;
            labelAxles.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelAxles.ForeColor = SystemColors.ButtonHighlight;
            labelAxles.Location = new Point(972, 427);
            labelAxles.Name = "labelAxles";
            labelAxles.Size = new Size(120, 42);
            labelAxles.TabIndex = 70;
            labelAxles.Text = "Axles:";
            // 
            // labelEngine
            // 
            labelEngine.AutoSize = true;
            labelEngine.BackColor = Color.Transparent;
            labelEngine.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelEngine.ForeColor = SystemColors.ButtonHighlight;
            labelEngine.Location = new Point(37, 784);
            labelEngine.Name = "labelEngine";
            labelEngine.Size = new Size(145, 42);
            labelEngine.TabIndex = 51;
            labelEngine.Text = "Engine:";
            // 
            // labelSteeringWheel
            // 
            labelSteeringWheel.AutoSize = true;
            labelSteeringWheel.BackColor = Color.Transparent;
            labelSteeringWheel.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelSteeringWheel.ForeColor = SystemColors.ButtonHighlight;
            labelSteeringWheel.Location = new Point(972, 246);
            labelSteeringWheel.Name = "labelSteeringWheel";
            labelSteeringWheel.Size = new Size(283, 42);
            labelSteeringWheel.TabIndex = 69;
            labelSteeringWheel.Text = "Steering Wheel:";
            // 
            // labelPlayLoadCapacity
            // 
            labelPlayLoadCapacity.AutoSize = true;
            labelPlayLoadCapacity.BackColor = Color.Transparent;
            labelPlayLoadCapacity.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelPlayLoadCapacity.ForeColor = SystemColors.ButtonHighlight;
            labelPlayLoadCapacity.Location = new Point(973, 370);
            labelPlayLoadCapacity.Name = "labelPlayLoadCapacity";
            labelPlayLoadCapacity.Size = new Size(402, 42);
            labelPlayLoadCapacity.TabIndex = 68;
            labelPlayLoadCapacity.Text = "Playload Capacity (kg):";
            // 
            // labelCondition
            // 
            labelCondition.AutoSize = true;
            labelCondition.BackColor = Color.Transparent;
            labelCondition.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelCondition.ForeColor = SystemColors.ButtonHighlight;
            labelCondition.Location = new Point(972, 309);
            labelCondition.Name = "labelCondition";
            labelCondition.Size = new Size(186, 42);
            labelCondition.TabIndex = 65;
            labelCondition.Text = "Condition:";
            // 
            // labelEnginePower
            // 
            labelEnginePower.AutoSize = true;
            labelEnginePower.BackColor = Color.Transparent;
            labelEnginePower.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelEnginePower.ForeColor = SystemColors.ButtonHighlight;
            labelEnginePower.Location = new Point(37, 479);
            labelEnginePower.Name = "labelEnginePower";
            labelEnginePower.Size = new Size(261, 42);
            labelEnginePower.TabIndex = 57;
            labelEnginePower.Text = "Engine Power:";
            // 
            // labelTransmission
            // 
            labelTransmission.AutoSize = true;
            labelTransmission.BackColor = Color.Transparent;
            labelTransmission.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelTransmission.ForeColor = SystemColors.ButtonHighlight;
            labelTransmission.Location = new Point(37, 537);
            labelTransmission.Name = "labelTransmission";
            labelTransmission.Size = new Size(250, 42);
            labelTransmission.TabIndex = 58;
            labelTransmission.Text = "Transmission:";
            // 
            // labelMileage
            // 
            labelMileage.AutoSize = true;
            labelMileage.BackColor = Color.Transparent;
            labelMileage.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelMileage.ForeColor = SystemColors.ButtonHighlight;
            labelMileage.Location = new Point(37, 660);
            labelMileage.Name = "labelMileage";
            labelMileage.Size = new Size(242, 42);
            labelMileage.TabIndex = 61;
            labelMileage.Text = "Mileage (km):";
            // 
            // labelBodyType
            // 
            labelBodyType.AutoSize = true;
            labelBodyType.BackColor = Color.Transparent;
            labelBodyType.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelBodyType.ForeColor = SystemColors.ButtonHighlight;
            labelBodyType.Location = new Point(37, 595);
            labelBodyType.Name = "labelBodyType";
            labelBodyType.Size = new Size(208, 42);
            labelBodyType.TabIndex = 59;
            labelBodyType.Text = "Body Type:";
            // 
            // labelColor
            // 
            labelColor.AutoSize = true;
            labelColor.BackColor = Color.Transparent;
            labelColor.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelColor.ForeColor = SystemColors.ButtonHighlight;
            labelColor.Location = new Point(37, 726);
            labelColor.Name = "labelColor";
            labelColor.Size = new Size(117, 42);
            labelColor.TabIndex = 60;
            labelColor.Text = "Color:";
            // 
            // labelBrand
            // 
            labelBrand.AutoSize = true;
            labelBrand.BackColor = Color.Transparent;
            labelBrand.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelBrand.ForeColor = SystemColors.ButtonHighlight;
            labelBrand.Location = new Point(37, 304);
            labelBrand.Name = "labelBrand";
            labelBrand.Size = new Size(128, 42);
            labelBrand.TabIndex = 71;
            labelBrand.Text = "Brand:";
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.BackColor = Color.Transparent;
            labelModel.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelModel.ForeColor = SystemColors.ButtonHighlight;
            labelModel.Location = new Point(37, 357);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(130, 42);
            labelModel.TabIndex = 72;
            labelModel.Text = "Model:";
            // 
            // tbBrand
            // 
            tbBrand.Location = new Point(324, 304);
            tbBrand.Name = "tbBrand";
            tbBrand.Size = new Size(299, 39);
            tbBrand.TabIndex = 73;
            // 
            // tbModel
            // 
            tbModel.Location = new Point(324, 360);
            tbModel.Name = "tbModel";
            tbModel.Size = new Size(299, 39);
            tbModel.TabIndex = 74;
            // 
            // dateOfProduction
            // 
            dateOfProduction.CustomFormat = "dd/MM/yyyy";
            dateOfProduction.Location = new Point(405, 425);
            dateOfProduction.MaxDate = new DateTime(2024, 3, 21, 0, 0, 0, 0);
            dateOfProduction.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dateOfProduction.Name = "dateOfProduction";
            dateOfProduction.Size = new Size(399, 39);
            dateOfProduction.TabIndex = 75;
            dateOfProduction.Value = new DateTime(2024, 3, 21, 0, 0, 0, 0);
            // 
            // nbEnginePower
            // 
            nbEnginePower.Location = new Point(324, 479);
            nbEnginePower.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nbEnginePower.Name = "nbEnginePower";
            nbEnginePower.Size = new Size(299, 39);
            nbEnginePower.TabIndex = 76;
            // 
            // cbTransmission
            // 
            cbTransmission.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTransmission.FormattingEnabled = true;
            cbTransmission.Items.AddRange(new object[] { "Manual", "Automatic" });
            cbTransmission.Location = new Point(324, 543);
            cbTransmission.Name = "cbTransmission";
            cbTransmission.Size = new Size(299, 40);
            cbTransmission.TabIndex = 77;
            // 
            // cbBodyType
            // 
            cbBodyType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBodyType.FormattingEnabled = true;
            cbBodyType.Location = new Point(324, 601);
            cbBodyType.Name = "cbBodyType";
            cbBodyType.Size = new Size(302, 40);
            cbBodyType.TabIndex = 84;
            // 
            // nmMileage
            // 
            nmMileage.Location = new Point(324, 663);
            nmMileage.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nmMileage.Name = "nmMileage";
            nmMileage.Size = new Size(302, 39);
            nmMileage.TabIndex = 85;
            // 
            // cbEngine1Type
            // 
            cbEngine1Type.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEngine1Type.FormattingEnabled = true;
            cbEngine1Type.Items.AddRange(new object[] { "Internal_Combustion", "Electric", "Hybrid" });
            cbEngine1Type.Location = new Point(324, 790);
            cbEngine1Type.Name = "cbEngine1Type";
            cbEngine1Type.Size = new Size(304, 40);
            cbEngine1Type.TabIndex = 88;
            cbEngine1Type.SelectedIndexChanged += cbEngine1Type_SelectedIndexChanged;
            // 
            // cbSteeringWheelType
            // 
            cbSteeringWheelType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSteeringWheelType.FormattingEnabled = true;
            cbSteeringWheelType.Items.AddRange(new object[] { " Left_Hand", " Right_Hand", " Centered" });
            cbSteeringWheelType.Location = new Point(1392, 249);
            cbSteeringWheelType.Name = "cbSteeringWheelType";
            cbSteeringWheelType.Size = new Size(302, 40);
            cbSteeringWheelType.TabIndex = 97;
            // 
            // cbCondition
            // 
            cbCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondition.FormattingEnabled = true;
            cbCondition.Items.AddRange(new object[] { "New", "Used" });
            cbCondition.Location = new Point(1392, 309);
            cbCondition.Name = "cbCondition";
            cbCondition.Size = new Size(302, 40);
            cbCondition.TabIndex = 98;
            // 
            // nbPlayloadCapacity
            // 
            nbPlayloadCapacity.Location = new Point(1392, 373);
            nbPlayloadCapacity.Maximum = new decimal(new int[] { 500000, 0, 0, 0 });
            nbPlayloadCapacity.Name = "nbPlayloadCapacity";
            nbPlayloadCapacity.Size = new Size(302, 39);
            nbPlayloadCapacity.TabIndex = 100;
            // 
            // rb2Axles
            // 
            rb2Axles.AutoSize = true;
            rb2Axles.BackColor = Color.Transparent;
            rb2Axles.Checked = true;
            rb2Axles.ForeColor = Color.White;
            rb2Axles.Location = new Point(1313, 433);
            rb2Axles.Name = "rb2Axles";
            rb2Axles.Size = new Size(58, 36);
            rb2Axles.TabIndex = 101;
            rb2Axles.TabStop = true;
            rb2Axles.Text = "2";
            rb2Axles.UseVisualStyleBackColor = false;
            // 
            // rb3Axles
            // 
            rb3Axles.AutoSize = true;
            rb3Axles.BackColor = Color.Transparent;
            rb3Axles.ForeColor = Color.White;
            rb3Axles.Location = new Point(1377, 433);
            rb3Axles.Name = "rb3Axles";
            rb3Axles.Size = new Size(58, 36);
            rb3Axles.TabIndex = 102;
            rb3Axles.Text = "3";
            rb3Axles.UseVisualStyleBackColor = false;
            // 
            // rb4Axles
            // 
            rb4Axles.AutoSize = true;
            rb4Axles.BackColor = Color.Transparent;
            rb4Axles.ForeColor = Color.White;
            rb4Axles.Location = new Point(1441, 433);
            rb4Axles.Name = "rb4Axles";
            rb4Axles.Size = new Size(58, 36);
            rb4Axles.TabIndex = 103;
            rb4Axles.Text = "4";
            rb4Axles.UseVisualStyleBackColor = false;
            // 
            // rb5Axles
            // 
            rb5Axles.AutoSize = true;
            rb5Axles.BackColor = Color.Transparent;
            rb5Axles.ForeColor = Color.White;
            rb5Axles.Location = new Point(1505, 433);
            rb5Axles.Name = "rb5Axles";
            rb5Axles.Size = new Size(58, 36);
            rb5Axles.TabIndex = 104;
            rb5Axles.Text = "5";
            rb5Axles.UseVisualStyleBackColor = false;
            // 
            // rb6Axles
            // 
            rb6Axles.AutoSize = true;
            rb6Axles.BackColor = Color.Transparent;
            rb6Axles.ForeColor = Color.White;
            rb6Axles.Location = new Point(1569, 433);
            rb6Axles.Name = "rb6Axles";
            rb6Axles.Size = new Size(58, 36);
            rb6Axles.TabIndex = 105;
            rb6Axles.Text = "6";
            rb6Axles.UseVisualStyleBackColor = false;
            // 
            // rb7Axles
            // 
            rb7Axles.AutoSize = true;
            rb7Axles.BackColor = Color.Transparent;
            rb7Axles.ForeColor = Color.White;
            rb7Axles.Location = new Point(1633, 433);
            rb7Axles.Name = "rb7Axles";
            rb7Axles.Size = new Size(58, 36);
            rb7Axles.TabIndex = 106;
            rb7Axles.Text = "7";
            rb7Axles.UseVisualStyleBackColor = false;
            // 
            // chbHasWindShield
            // 
            chbHasWindShield.AutoSize = true;
            chbHasWindShield.Location = new Point(1392, 379);
            chbHasWindShield.Name = "chbHasWindShield";
            chbHasWindShield.Size = new Size(28, 27);
            chbHasWindShield.TabIndex = 107;
            chbHasWindShield.UseVisualStyleBackColor = true;
            // 
            // chbHasBox
            // 
            chbHasBox.AutoSize = true;
            chbHasBox.BackColor = Color.Transparent;
            chbHasBox.ForeColor = Color.White;
            chbHasBox.Location = new Point(1392, 439);
            chbHasBox.Name = "chbHasBox";
            chbHasBox.Size = new Size(28, 27);
            chbHasBox.TabIndex = 108;
            chbHasBox.UseVisualStyleBackColor = false;
            // 
            // nbNumberOfDoors
            // 
            nbNumberOfDoors.Location = new Point(1537, 373);
            nbNumberOfDoors.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nbNumberOfDoors.Name = "nbNumberOfDoors";
            nbNumberOfDoors.Size = new Size(157, 39);
            nbNumberOfDoors.TabIndex = 109;
            // 
            // btnAddVehicle
            // 
            btnAddVehicle.BackColor = Color.FromArgb(4, 232, 36);
            btnAddVehicle.FlatStyle = FlatStyle.Flat;
            btnAddVehicle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddVehicle.Location = new Point(1571, 1131);
            btnAddVehicle.Name = "btnAddVehicle";
            btnAddVehicle.Size = new Size(266, 74);
            btnAddVehicle.TabIndex = 110;
            btnAddVehicle.Text = "Add";
            btnAddVehicle.UseVisualStyleBackColor = false;
            btnAddVehicle.Click += btnAddVehicle_Click;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.BackColor = Color.Transparent;
            labelPrice.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelPrice.ForeColor = SystemColors.ButtonHighlight;
            labelPrice.Location = new Point(973, 192);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(113, 42);
            labelPrice.TabIndex = 112;
            labelPrice.Text = "Price:";
            // 
            // nbPrice
            // 
            nbPrice.Location = new Point(1392, 192);
            nbPrice.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            nbPrice.Name = "nbPrice";
            nbPrice.Size = new Size(299, 39);
            nbPrice.TabIndex = 113;
            // 
            // labelImageURL
            // 
            labelImageURL.AutoSize = true;
            labelImageURL.BackColor = Color.Transparent;
            labelImageURL.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelImageURL.ForeColor = SystemColors.ButtonHighlight;
            labelImageURL.Location = new Point(972, 595);
            labelImageURL.Name = "labelImageURL";
            labelImageURL.Size = new Size(215, 42);
            labelImageURL.TabIndex = 114;
            labelImageURL.Text = "Image URL:";
            // 
            // pbNavigateBack
            // 
            pbNavigateBack.BackColor = Color.Transparent;
            pbNavigateBack.Image = (Image)resources.GetObject("pbNavigateBack.Image");
            pbNavigateBack.Location = new Point(12, 12);
            pbNavigateBack.Name = "pbNavigateBack";
            pbNavigateBack.Size = new Size(135, 135);
            pbNavigateBack.SizeMode = PictureBoxSizeMode.StretchImage;
            pbNavigateBack.TabIndex = 115;
            pbNavigateBack.TabStop = false;
            pbNavigateBack.Click += pictureBox1_Click;
            // 
            // pbVehicleIcon
            // 
            pbVehicleIcon.BackColor = Color.Transparent;
            pbVehicleIcon.InitialImage = (Image)resources.GetObject("pbVehicleIcon.InitialImage");
            pbVehicleIcon.Location = new Point(480, 98);
            pbVehicleIcon.Name = "pbVehicleIcon";
            pbVehicleIcon.Size = new Size(200, 200);
            pbVehicleIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pbVehicleIcon.TabIndex = 116;
            pbVehicleIcon.TabStop = false;
            // 
            // labelFuelType
            // 
            labelFuelType.AutoSize = true;
            labelFuelType.BackColor = Color.Transparent;
            labelFuelType.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelFuelType.ForeColor = SystemColors.ButtonHighlight;
            labelFuelType.Location = new Point(37, 849);
            labelFuelType.Name = "labelFuelType";
            labelFuelType.Size = new Size(195, 42);
            labelFuelType.TabIndex = 117;
            labelFuelType.Text = "Fuel Type:";
            // 
            // cbFuelType1
            // 
            cbFuelType1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuelType1.FormattingEnabled = true;
            cbFuelType1.Items.AddRange(new object[] { "Internal_Combustion", "Electric" });
            cbFuelType1.Location = new Point(324, 849);
            cbFuelType1.Name = "cbFuelType1";
            cbFuelType1.Size = new Size(223, 40);
            cbFuelType1.TabIndex = 118;
            // 
            // tbImageURL
            // 
            tbImageURL.Location = new Point(973, 650);
            tbImageURL.Name = "tbImageURL";
            tbImageURL.Size = new Size(831, 39);
            tbImageURL.TabIndex = 119;
            tbImageURL.TextChanged += tbImageURL_TextChanged;
            // 
            // btnTestImage
            // 
            btnTestImage.BackColor = Color.FromArgb(112, 193, 179);
            btnTestImage.FlatStyle = FlatStyle.Flat;
            btnTestImage.Location = new Point(1684, 714);
            btnTestImage.Name = "btnTestImage";
            btnTestImage.Size = new Size(120, 75);
            btnTestImage.TabIndex = 120;
            btnTestImage.Text = "Test Image";
            btnTestImage.UseVisualStyleBackColor = false;
            btnTestImage.Click += btnTestImage_Click;
            // 
            // labelPreview
            // 
            labelPreview.AutoSize = true;
            labelPreview.BackColor = Color.Transparent;
            labelPreview.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelPreview.ForeColor = SystemColors.ButtonHighlight;
            labelPreview.Location = new Point(973, 723);
            labelPreview.Name = "labelPreview";
            labelPreview.Size = new Size(161, 42);
            labelPreview.TabIndex = 121;
            labelPreview.Text = "Preview:";
            // 
            // pbVehicleImage
            // 
            pbVehicleImage.ErrorImage = (Image)resources.GetObject("pbVehicleImage.ErrorImage");
            pbVehicleImage.Image = (Image)resources.GetObject("pbVehicleImage.Image");
            pbVehicleImage.InitialImage = (Image)resources.GetObject("pbVehicleImage.InitialImage");
            pbVehicleImage.Location = new Point(1196, 726);
            pbVehicleImage.Name = "pbVehicleImage";
            pbVehicleImage.Size = new Size(229, 229);
            pbVehicleImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbVehicleImage.TabIndex = 122;
            pbVehicleImage.TabStop = false;
            // 
            // cbColor
            // 
            cbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColor.FormattingEnabled = true;
            cbColor.Items.AddRange(new object[] { "Red", "Green", "Blue", "Yellow", "Orange", "Purple", "Pink", "Cyan", "Brown", "Black", "White", "Gray", "Magenta", "Turquoise", "Lavender", "Silver" });
            cbColor.Location = new Point(321, 728);
            cbColor.Name = "cbColor";
            cbColor.Size = new Size(307, 40);
            cbColor.TabIndex = 196;
            // 
            // AddVehiclePage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1849, 1217);
            Controls.Add(cbColor);
            Controls.Add(pbVehicleImage);
            Controls.Add(labelPreview);
            Controls.Add(btnTestImage);
            Controls.Add(tbImageURL);
            Controls.Add(cbFuelType1);
            Controls.Add(labelFuelType);
            Controls.Add(pbVehicleIcon);
            Controls.Add(pbNavigateBack);
            Controls.Add(labelImageURL);
            Controls.Add(nbPrice);
            Controls.Add(labelPrice);
            Controls.Add(btnAddVehicle);
            Controls.Add(nbNumberOfDoors);
            Controls.Add(chbHasBox);
            Controls.Add(chbHasWindShield);
            Controls.Add(rb7Axles);
            Controls.Add(rb6Axles);
            Controls.Add(rb5Axles);
            Controls.Add(rb4Axles);
            Controls.Add(rb3Axles);
            Controls.Add(rb2Axles);
            Controls.Add(nbPlayloadCapacity);
            Controls.Add(cbCondition);
            Controls.Add(cbSteeringWheelType);
            Controls.Add(cbEngine1Type);
            Controls.Add(nmMileage);
            Controls.Add(cbBodyType);
            Controls.Add(cbTransmission);
            Controls.Add(nbEnginePower);
            Controls.Add(dateOfProduction);
            Controls.Add(tbModel);
            Controls.Add(tbBrand);
            Controls.Add(labelModel);
            Controls.Add(labelBrand);
            Controls.Add(labelDateOfProduction);
            Controls.Add(labelAxles);
            Controls.Add(labelEngine);
            Controls.Add(labelSteeringWheel);
            Controls.Add(labelPlayLoadCapacity);
            Controls.Add(labelCondition);
            Controls.Add(labelEnginePower);
            Controls.Add(labelTransmission);
            Controls.Add(labelMileage);
            Controls.Add(labelBodyType);
            Controls.Add(labelColor);
            Controls.Add(cbSelectedVehicle);
            Controls.Add(labelSelectVehicleType);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(1875, 1288);
            MinimumSize = new Size(1875, 1288);
            Name = "AddVehiclePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Vehicle";
            ((System.ComponentModel.ISupportInitialize)nbEnginePower).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmMileage).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbPlayloadCapacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbNumberOfDoors).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNavigateBack).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbVehicleIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbVehicleImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSelectVehicleType;
        private ComboBox cbSelectedVehicle;
        private Label labelDateOfProduction;
        private Label labelAxles;
        private Label labelEngine;
        private Label labelSteeringWheel;
        private Label labelPlayLoadCapacity;
        private Label labelCondition;
        private Label labelEnginePower;
        private Label labelTransmission;
        private Label labelMileage;
        private Label labelBodyType;
        private Label labelColor;
        private Label labelBrand;
        private Label labelModel;
        private TextBox tbBrand;
        private TextBox tbModel;
        private DateTimePicker dateOfProduction;
        private NumericUpDown nbEnginePower;
        private ComboBox cbTransmission;
        private ComboBox cbBodyType;
        private NumericUpDown nmMileage;
        private ComboBox cbEngine1Type;
        private ComboBox cbSteeringWheelType;
        private ComboBox cbCondition;
        private NumericUpDown nbPlayloadCapacity;
        private RadioButton rb2Axles;
        private RadioButton rb3Axles;
        private RadioButton rb4Axles;
        private RadioButton rb5Axles;
        private RadioButton rb6Axles;
        private RadioButton rb7Axles;
        private CheckBox chbHasWindShield;
        private CheckBox chbHasBox;
        private NumericUpDown nbNumberOfDoors;
        private Button btnAddVehicle;
        private Label labelPrice;
        private NumericUpDown nbPrice;
        private Label labelImageURL;
        private PictureBox pbNavigateBack;
        private PictureBox pbVehicleIcon;
        private Label labelFuelType;
        private ComboBox cbFuelType1;
        private TextBox tbImageURL;
        private Button btnTestImage;
        private Label labelPreview;
        private PictureBox pbVehicleImage;
        private ComboBox cbColor;
    }
}