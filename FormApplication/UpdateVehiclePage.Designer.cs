namespace FormApplication
{
    partial class UpdateVehiclePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateVehiclePage));
            cbFuelType1 = new ComboBox();
            label2 = new Label();
            nbPrice = new NumericUpDown();
            labelPrice = new Label();
            btnUpdateVehicle = new Button();
            nbNumberOfDoors = new NumericUpDown();
            chbHasBox = new CheckBox();
            chbHasWindShield = new CheckBox();
            rb7Axles = new RadioButton();
            rb6Axles = new RadioButton();
            rb5Axles = new RadioButton();
            rb4Axles = new RadioButton();
            rb3Axles = new RadioButton();
            rb2Axles = new RadioButton();
            nbPlayloadCapacity = new NumericUpDown();
            cbCondition = new ComboBox();
            cbSteeringWheelType = new ComboBox();
            cbEngine1Type = new ComboBox();
            nmMileage = new NumericUpDown();
            cbBodyType = new ComboBox();
            cbTransmission = new ComboBox();
            nbEnginePower = new NumericUpDown();
            dateOfProduction = new DateTimePicker();
            tbModel = new TextBox();
            tbBrand = new TextBox();
            labelModel = new Label();
            labelBrand = new Label();
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
            label3 = new Label();
            label4 = new Label();
            pbVehicleIcon = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            pbVehicleImage = new PictureBox();
            labelPreview = new Label();
            btnTestImage = new Button();
            tbImageURL = new TextBox();
            labelImageURL = new Label();
            cbColor = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nbPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbNumberOfDoors).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbPlayloadCapacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmMileage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbEnginePower).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbVehicleIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbVehicleImage).BeginInit();
            SuspendLayout();
            // 
            // cbFuelType1
            // 
            cbFuelType1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuelType1.FormattingEnabled = true;
            cbFuelType1.Items.AddRange(new object[] { "Internal_Combustion", "Electric" });
            cbFuelType1.Location = new Point(312, 874);
            cbFuelType1.Name = "cbFuelType1";
            cbFuelType1.Size = new Size(245, 40);
            cbFuelType1.TabIndex = 184;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 13.875F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(28, 872);
            label2.Name = "label2";
            label2.Size = new Size(195, 42);
            label2.TabIndex = 183;
            label2.Text = "Fuel Type:";
            // 
            // nbPrice
            // 
            nbPrice.Location = new Point(1385, 210);
            nbPrice.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            nbPrice.Name = "nbPrice";
            nbPrice.Size = new Size(299, 39);
            nbPrice.TabIndex = 180;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.BackColor = Color.Transparent;
            labelPrice.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelPrice.ForeColor = SystemColors.ButtonHighlight;
            labelPrice.Location = new Point(961, 203);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(113, 42);
            labelPrice.TabIndex = 179;
            labelPrice.Text = "Price:";
            // 
            // btnUpdateVehicle
            // 
            btnUpdateVehicle.BackColor = Color.FromArgb(4, 232, 36);
            btnUpdateVehicle.FlatStyle = FlatStyle.Flat;
            btnUpdateVehicle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateVehicle.Location = new Point(1608, 1119);
            btnUpdateVehicle.Name = "btnUpdateVehicle";
            btnUpdateVehicle.Size = new Size(229, 86);
            btnUpdateVehicle.TabIndex = 178;
            btnUpdateVehicle.Text = "Update";
            btnUpdateVehicle.UseVisualStyleBackColor = false;
            btnUpdateVehicle.Click += btnUpdateVehicle_Click;
            // 
            // nbNumberOfDoors
            // 
            nbNumberOfDoors.Location = new Point(1527, 383);
            nbNumberOfDoors.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nbNumberOfDoors.Name = "nbNumberOfDoors";
            nbNumberOfDoors.Size = new Size(157, 39);
            nbNumberOfDoors.TabIndex = 177;
            // 
            // chbHasBox
            // 
            chbHasBox.AutoSize = true;
            chbHasBox.BackColor = Color.Transparent;
            chbHasBox.ForeColor = Color.White;
            chbHasBox.Location = new Point(1382, 445);
            chbHasBox.Name = "chbHasBox";
            chbHasBox.Size = new Size(28, 27);
            chbHasBox.TabIndex = 176;
            chbHasBox.UseVisualStyleBackColor = false;
            // 
            // chbHasWindShield
            // 
            chbHasWindShield.AutoSize = true;
            chbHasWindShield.BackColor = Color.Transparent;
            chbHasWindShield.Location = new Point(1382, 389);
            chbHasWindShield.Name = "chbHasWindShield";
            chbHasWindShield.Size = new Size(28, 27);
            chbHasWindShield.TabIndex = 175;
            chbHasWindShield.UseVisualStyleBackColor = false;
            // 
            // rb7Axles
            // 
            rb7Axles.AutoSize = true;
            rb7Axles.BackColor = Color.Transparent;
            rb7Axles.ForeColor = Color.White;
            rb7Axles.Location = new Point(1626, 439);
            rb7Axles.Name = "rb7Axles";
            rb7Axles.Size = new Size(58, 36);
            rb7Axles.TabIndex = 174;
            rb7Axles.Text = "7";
            rb7Axles.UseVisualStyleBackColor = false;
            // 
            // rb6Axles
            // 
            rb6Axles.AutoSize = true;
            rb6Axles.BackColor = Color.Transparent;
            rb6Axles.ForeColor = Color.White;
            rb6Axles.Location = new Point(1562, 439);
            rb6Axles.Name = "rb6Axles";
            rb6Axles.Size = new Size(58, 36);
            rb6Axles.TabIndex = 173;
            rb6Axles.Text = "6";
            rb6Axles.UseVisualStyleBackColor = false;
            // 
            // rb5Axles
            // 
            rb5Axles.AutoSize = true;
            rb5Axles.BackColor = Color.Transparent;
            rb5Axles.ForeColor = Color.White;
            rb5Axles.Location = new Point(1498, 439);
            rb5Axles.Name = "rb5Axles";
            rb5Axles.Size = new Size(58, 36);
            rb5Axles.TabIndex = 172;
            rb5Axles.Text = "5";
            rb5Axles.UseVisualStyleBackColor = false;
            // 
            // rb4Axles
            // 
            rb4Axles.AutoSize = true;
            rb4Axles.BackColor = Color.Transparent;
            rb4Axles.ForeColor = Color.White;
            rb4Axles.Location = new Point(1434, 439);
            rb4Axles.Name = "rb4Axles";
            rb4Axles.Size = new Size(58, 36);
            rb4Axles.TabIndex = 171;
            rb4Axles.Text = "4";
            rb4Axles.UseVisualStyleBackColor = false;
            // 
            // rb3Axles
            // 
            rb3Axles.AutoSize = true;
            rb3Axles.BackColor = Color.Transparent;
            rb3Axles.ForeColor = Color.White;
            rb3Axles.Location = new Point(1370, 439);
            rb3Axles.Name = "rb3Axles";
            rb3Axles.Size = new Size(58, 36);
            rb3Axles.TabIndex = 170;
            rb3Axles.Text = "3";
            rb3Axles.UseVisualStyleBackColor = false;
            // 
            // rb2Axles
            // 
            rb2Axles.AutoSize = true;
            rb2Axles.BackColor = Color.Transparent;
            rb2Axles.Checked = true;
            rb2Axles.ForeColor = Color.White;
            rb2Axles.Location = new Point(1306, 439);
            rb2Axles.Name = "rb2Axles";
            rb2Axles.Size = new Size(58, 36);
            rb2Axles.TabIndex = 169;
            rb2Axles.TabStop = true;
            rb2Axles.Text = "2";
            rb2Axles.UseVisualStyleBackColor = false;
            // 
            // nbPlayloadCapacity
            // 
            nbPlayloadCapacity.Location = new Point(1382, 383);
            nbPlayloadCapacity.Maximum = new decimal(new int[] { 500000, 0, 0, 0 });
            nbPlayloadCapacity.Name = "nbPlayloadCapacity";
            nbPlayloadCapacity.Size = new Size(302, 39);
            nbPlayloadCapacity.TabIndex = 168;
            // 
            // cbCondition
            // 
            cbCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondition.FormattingEnabled = true;
            cbCondition.Items.AddRange(new object[] { "New", "Used" });
            cbCondition.Location = new Point(1385, 322);
            cbCondition.Name = "cbCondition";
            cbCondition.Size = new Size(299, 40);
            cbCondition.TabIndex = 166;
            // 
            // cbSteeringWheelType
            // 
            cbSteeringWheelType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSteeringWheelType.FormattingEnabled = true;
            cbSteeringWheelType.Items.AddRange(new object[] { "Left_Hand", "Right_Hand", "Centered" });
            cbSteeringWheelType.Location = new Point(1385, 259);
            cbSteeringWheelType.Name = "cbSteeringWheelType";
            cbSteeringWheelType.Size = new Size(299, 40);
            cbSteeringWheelType.TabIndex = 165;
            // 
            // cbEngine1Type
            // 
            cbEngine1Type.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEngine1Type.FormattingEnabled = true;
            cbEngine1Type.Items.AddRange(new object[] { "Internal_Combustion", "Electric", "Hybrid" });
            cbEngine1Type.Location = new Point(312, 808);
            cbEngine1Type.Name = "cbEngine1Type";
            cbEngine1Type.Size = new Size(304, 40);
            cbEngine1Type.TabIndex = 156;
            cbEngine1Type.SelectedIndexChanged += cbEngine1Type_SelectedIndexChanged_1;
            // 
            // nmMileage
            // 
            nmMileage.Location = new Point(312, 682);
            nmMileage.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nmMileage.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmMileage.Name = "nmMileage";
            nmMileage.Size = new Size(299, 39);
            nmMileage.TabIndex = 153;
            nmMileage.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cbBodyType
            // 
            cbBodyType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBodyType.FormattingEnabled = true;
            cbBodyType.Location = new Point(312, 621);
            cbBodyType.Name = "cbBodyType";
            cbBodyType.Size = new Size(302, 40);
            cbBodyType.TabIndex = 152;
            // 
            // cbTransmission
            // 
            cbTransmission.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTransmission.FormattingEnabled = true;
            cbTransmission.Items.AddRange(new object[] { "Manual", "Automatic" });
            cbTransmission.Location = new Point(312, 554);
            cbTransmission.Name = "cbTransmission";
            cbTransmission.Size = new Size(299, 40);
            cbTransmission.TabIndex = 145;
            // 
            // nbEnginePower
            // 
            nbEnginePower.Location = new Point(312, 490);
            nbEnginePower.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nbEnginePower.Name = "nbEnginePower";
            nbEnginePower.Size = new Size(299, 39);
            nbEnginePower.TabIndex = 144;
            // 
            // dateOfProduction
            // 
            dateOfProduction.CustomFormat = "dd/MM/yyyy";
            dateOfProduction.Location = new Point(393, 436);
            dateOfProduction.MaxDate = new DateTime(2024, 5, 2, 0, 0, 0, 0);
            dateOfProduction.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dateOfProduction.Name = "dateOfProduction";
            dateOfProduction.Size = new Size(412, 39);
            dateOfProduction.TabIndex = 143;
            dateOfProduction.Value = new DateTime(2024, 3, 21, 0, 0, 0, 0);
            // 
            // tbModel
            // 
            tbModel.Location = new Point(312, 371);
            tbModel.Name = "tbModel";
            tbModel.Size = new Size(299, 39);
            tbModel.TabIndex = 142;
            // 
            // tbBrand
            // 
            tbBrand.Location = new Point(312, 315);
            tbBrand.Name = "tbBrand";
            tbBrand.Size = new Size(299, 39);
            tbBrand.TabIndex = 141;
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.BackColor = Color.Transparent;
            labelModel.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelModel.ForeColor = SystemColors.ButtonHighlight;
            labelModel.Location = new Point(-262, 205);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(130, 42);
            labelModel.TabIndex = 140;
            labelModel.Text = "Model:";
            // 
            // labelBrand
            // 
            labelBrand.AutoSize = true;
            labelBrand.BackColor = Color.Transparent;
            labelBrand.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelBrand.ForeColor = SystemColors.ButtonHighlight;
            labelBrand.Location = new Point(-262, 149);
            labelBrand.Name = "labelBrand";
            labelBrand.Size = new Size(128, 42);
            labelBrand.TabIndex = 139;
            labelBrand.Text = "Brand:";
            // 
            // labelDateOfProduction
            // 
            labelDateOfProduction.AutoSize = true;
            labelDateOfProduction.BackColor = Color.Transparent;
            labelDateOfProduction.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelDateOfProduction.ForeColor = SystemColors.ButtonHighlight;
            labelDateOfProduction.Location = new Point(28, 436);
            labelDateOfProduction.Name = "labelDateOfProduction";
            labelDateOfProduction.Size = new Size(337, 42);
            labelDateOfProduction.TabIndex = 122;
            labelDateOfProduction.Text = "Date of Production:";
            // 
            // labelAxles
            // 
            labelAxles.AutoSize = true;
            labelAxles.BackColor = Color.Transparent;
            labelAxles.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelAxles.ForeColor = SystemColors.ButtonHighlight;
            labelAxles.Location = new Point(960, 437);
            labelAxles.Name = "labelAxles";
            labelAxles.Size = new Size(120, 42);
            labelAxles.TabIndex = 138;
            labelAxles.Text = "Axles:";
            // 
            // labelEngine
            // 
            labelEngine.AutoSize = true;
            labelEngine.BackColor = Color.Transparent;
            labelEngine.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelEngine.ForeColor = SystemColors.ButtonHighlight;
            labelEngine.Location = new Point(-265, 784);
            labelEngine.Name = "labelEngine";
            labelEngine.Size = new Size(145, 42);
            labelEngine.TabIndex = 123;
            labelEngine.Text = "Engine:";
            // 
            // labelSteeringWheel
            // 
            labelSteeringWheel.AutoSize = true;
            labelSteeringWheel.BackColor = Color.Transparent;
            labelSteeringWheel.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelSteeringWheel.ForeColor = SystemColors.ButtonHighlight;
            labelSteeringWheel.Location = new Point(960, 253);
            labelSteeringWheel.Name = "labelSteeringWheel";
            labelSteeringWheel.Size = new Size(283, 42);
            labelSteeringWheel.TabIndex = 137;
            labelSteeringWheel.Text = "Steering Wheel:";
            // 
            // labelPlayLoadCapacity
            // 
            labelPlayLoadCapacity.AutoSize = true;
            labelPlayLoadCapacity.BackColor = Color.Transparent;
            labelPlayLoadCapacity.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelPlayLoadCapacity.ForeColor = SystemColors.ButtonHighlight;
            labelPlayLoadCapacity.Location = new Point(961, 380);
            labelPlayLoadCapacity.Name = "labelPlayLoadCapacity";
            labelPlayLoadCapacity.Size = new Size(402, 42);
            labelPlayLoadCapacity.TabIndex = 136;
            labelPlayLoadCapacity.Text = "Playload Capacity (kg):";
            // 
            // labelCondition
            // 
            labelCondition.AutoSize = true;
            labelCondition.BackColor = Color.Transparent;
            labelCondition.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelCondition.ForeColor = SystemColors.ButtonHighlight;
            labelCondition.Location = new Point(960, 316);
            labelCondition.Name = "labelCondition";
            labelCondition.Size = new Size(186, 42);
            labelCondition.TabIndex = 133;
            labelCondition.Text = "Condition:";
            // 
            // labelEnginePower
            // 
            labelEnginePower.AutoSize = true;
            labelEnginePower.BackColor = Color.Transparent;
            labelEnginePower.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelEnginePower.ForeColor = SystemColors.ButtonHighlight;
            labelEnginePower.Location = new Point(28, 494);
            labelEnginePower.Name = "labelEnginePower";
            labelEnginePower.Size = new Size(261, 42);
            labelEnginePower.TabIndex = 127;
            labelEnginePower.Text = "Engine Power:";
            // 
            // labelTransmission
            // 
            labelTransmission.AutoSize = true;
            labelTransmission.BackColor = Color.Transparent;
            labelTransmission.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelTransmission.ForeColor = SystemColors.ButtonHighlight;
            labelTransmission.Location = new Point(28, 552);
            labelTransmission.Name = "labelTransmission";
            labelTransmission.Size = new Size(250, 42);
            labelTransmission.TabIndex = 128;
            labelTransmission.Text = "Transmission:";
            // 
            // labelMileage
            // 
            labelMileage.AutoSize = true;
            labelMileage.BackColor = Color.Transparent;
            labelMileage.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelMileage.ForeColor = SystemColors.ButtonHighlight;
            labelMileage.Location = new Point(28, 685);
            labelMileage.Name = "labelMileage";
            labelMileage.Size = new Size(242, 42);
            labelMileage.TabIndex = 131;
            labelMileage.Text = "Mileage (km):";
            // 
            // labelBodyType
            // 
            labelBodyType.AutoSize = true;
            labelBodyType.BackColor = Color.Transparent;
            labelBodyType.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelBodyType.ForeColor = SystemColors.ButtonHighlight;
            labelBodyType.Location = new Point(28, 625);
            labelBodyType.Name = "labelBodyType";
            labelBodyType.Size = new Size(208, 42);
            labelBodyType.TabIndex = 129;
            labelBodyType.Text = "Body Type:";
            // 
            // labelColor
            // 
            labelColor.AutoSize = true;
            labelColor.BackColor = Color.Transparent;
            labelColor.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelColor.ForeColor = SystemColors.ButtonHighlight;
            labelColor.Location = new Point(-262, 667);
            labelColor.Name = "labelColor";
            labelColor.Size = new Size(117, 42);
            labelColor.TabIndex = 130;
            labelColor.Text = "Color:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 13.875F);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(28, 376);
            label3.Name = "label3";
            label3.Size = new Size(130, 42);
            label3.TabIndex = 187;
            label3.Text = "Model:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft Sans Serif", 13.875F);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(28, 320);
            label4.Name = "label4";
            label4.Size = new Size(128, 42);
            label4.TabIndex = 186;
            label4.Text = "Brand:";
            // 
            // pbVehicleIcon
            // 
            pbVehicleIcon.BackColor = Color.Transparent;
            pbVehicleIcon.InitialImage = (Image)resources.GetObject("pbVehicleIcon.InitialImage");
            pbVehicleIcon.Location = new Point(468, 109);
            pbVehicleIcon.Name = "pbVehicleIcon";
            pbVehicleIcon.Size = new Size(200, 200);
            pbVehicleIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pbVehicleIcon.TabIndex = 182;
            pbVehicleIcon.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Microsoft Sans Serif", 13.875F);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(28, 747);
            label5.Name = "label5";
            label5.Size = new Size(117, 42);
            label5.TabIndex = 188;
            label5.Text = "Color:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Microsoft Sans Serif", 13.875F);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(26, 808);
            label6.Name = "label6";
            label6.Size = new Size(145, 42);
            label6.TabIndex = 189;
            label6.Text = "Engine:";
            // 
            // pbVehicleImage
            // 
            pbVehicleImage.ErrorImage = (Image)resources.GetObject("pbVehicleImage.ErrorImage");
            pbVehicleImage.Image = (Image)resources.GetObject("pbVehicleImage.Image");
            pbVehicleImage.InitialImage = (Image)resources.GetObject("pbVehicleImage.InitialImage");
            pbVehicleImage.Location = new Point(1184, 707);
            pbVehicleImage.Name = "pbVehicleImage";
            pbVehicleImage.Size = new Size(229, 229);
            pbVehicleImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbVehicleImage.TabIndex = 194;
            pbVehicleImage.TabStop = false;
            // 
            // labelPreview
            // 
            labelPreview.AutoSize = true;
            labelPreview.BackColor = Color.Transparent;
            labelPreview.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelPreview.ForeColor = SystemColors.ButtonHighlight;
            labelPreview.Location = new Point(961, 704);
            labelPreview.Name = "labelPreview";
            labelPreview.Size = new Size(161, 42);
            labelPreview.TabIndex = 193;
            labelPreview.Text = "Preview:";
            // 
            // btnTestImage
            // 
            btnTestImage.BackColor = Color.FromArgb(112, 193, 179);
            btnTestImage.FlatStyle = FlatStyle.Flat;
            btnTestImage.Location = new Point(1672, 695);
            btnTestImage.Name = "btnTestImage";
            btnTestImage.Size = new Size(120, 75);
            btnTestImage.TabIndex = 192;
            btnTestImage.Text = "Test Image";
            btnTestImage.UseVisualStyleBackColor = false;
            btnTestImage.Click += btnTestImage_Click_1;
            // 
            // tbImageURL
            // 
            tbImageURL.Location = new Point(961, 631);
            tbImageURL.Name = "tbImageURL";
            tbImageURL.Size = new Size(831, 39);
            tbImageURL.TabIndex = 191;
            tbImageURL.TextChanged += tbImageURL_TextChanged;
            // 
            // labelImageURL
            // 
            labelImageURL.AutoSize = true;
            labelImageURL.BackColor = Color.Transparent;
            labelImageURL.Font = new Font("Microsoft Sans Serif", 13.875F);
            labelImageURL.ForeColor = SystemColors.ButtonHighlight;
            labelImageURL.Location = new Point(960, 576);
            labelImageURL.Name = "labelImageURL";
            labelImageURL.Size = new Size(215, 42);
            labelImageURL.TabIndex = 190;
            labelImageURL.Text = "Image URL:";
            // 
            // cbColor
            // 
            cbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColor.FormattingEnabled = true;
            cbColor.Items.AddRange(new object[] { "Red", "Green", "Blue", "Yellow", "Orange", "Purple", "Pink", "Cyan", "Brown", "Black", "White", "Gray", "Magenta", "Turquoise", "Lavender", "Silver" });
            cbColor.Location = new Point(312, 747);
            cbColor.Name = "cbColor";
            cbColor.Size = new Size(304, 40);
            cbColor.TabIndex = 195;
            // 
            // UpdateVehiclePage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1849, 1217);
            Controls.Add(cbColor);
            Controls.Add(pbVehicleImage);
            Controls.Add(labelPreview);
            Controls.Add(btnTestImage);
            Controls.Add(tbImageURL);
            Controls.Add(labelImageURL);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(cbFuelType1);
            Controls.Add(label2);
            Controls.Add(pbVehicleIcon);
            Controls.Add(nbPrice);
            Controls.Add(labelPrice);
            Controls.Add(btnUpdateVehicle);
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
            DoubleBuffered = true;
            MaximumSize = new Size(1875, 1288);
            MinimumSize = new Size(1875, 1288);
            Name = "UpdateVehiclePage";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update Vehicle";
            //Load += UpdateVehiclePage_Load;
            ((System.ComponentModel.ISupportInitialize)nbPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbNumberOfDoors).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbPlayloadCapacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmMileage).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbEnginePower).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbVehicleIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbVehicleImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cbFuelType1;
        private Label label2;
        private NumericUpDown nbPrice;
        private Label labelPrice;
        private Button btnUpdateVehicle;
        private NumericUpDown nbNumberOfDoors;
        private CheckBox chbHasBox;
        private CheckBox chbHasWindShield;
        private RadioButton rb7Axles;
        private RadioButton rb6Axles;
        private RadioButton rb5Axles;
        private RadioButton rb4Axles;
        private RadioButton rb3Axles;
        private RadioButton rb2Axles;
        private NumericUpDown nbPlayloadCapacity;
        private ComboBox cbCondition;
        private ComboBox cbSteeringWheelType;
        private ComboBox cbEngine1Type;
        private NumericUpDown nmMileage;
        private ComboBox cbBodyType;
        private ComboBox cbTransmission;
        private NumericUpDown nbEnginePower;
        private DateTimePicker dateOfProduction;
        private TextBox tbModel;
        private TextBox tbBrand;
        private Label labelModel;
        private Label labelBrand;
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
        private Label label3;
        private Label label4;
        private PictureBox pbVehicleIcon;
        private Label label5;
        private Label label6;
        private PictureBox pbVehicleImage;
        private Label labelPreview;
        private Button btnTestImage;
        private TextBox tbImageURL;
        private Label labelImageURL;
        private ComboBox cbColor;
    }
}