namespace FormApplication
{
    partial class MenuPageStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPageStaff));
            btnManageVehicles = new Button();
            btnSeeStatistics = new Button();
            btnSalesAndAchive = new Button();
            btnCustomers = new Button();
            pbLogOut = new PictureBox();
            btnEmployees = new Button();
            pbAccountIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbLogOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAccountIcon).BeginInit();
            SuspendLayout();
            // 
            // btnManageVehicles
            // 
            btnManageVehicles.BackColor = Color.FromArgb(112, 193, 179);
            btnManageVehicles.FlatStyle = FlatStyle.Flat;
            btnManageVehicles.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageVehicles.Location = new Point(138, 410);
            btnManageVehicles.Name = "btnManageVehicles";
            btnManageVehicles.Size = new Size(332, 331);
            btnManageVehicles.TabIndex = 0;
            btnManageVehicles.Text = "Manage Vehicles";
            btnManageVehicles.UseVisualStyleBackColor = false;
            btnManageVehicles.Click += btnManageVehicles_Click;
            // 
            // btnSeeStatistics
            // 
            btnSeeStatistics.BackColor = Color.FromArgb(112, 193, 179);
            btnSeeStatistics.FlatStyle = FlatStyle.Flat;
            btnSeeStatistics.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSeeStatistics.Location = new Point(1088, 410);
            btnSeeStatistics.Name = "btnSeeStatistics";
            btnSeeStatistics.Size = new Size(332, 331);
            btnSeeStatistics.TabIndex = 1;
            btnSeeStatistics.Text = " Statistics";
            btnSeeStatistics.UseVisualStyleBackColor = false;
            btnSeeStatistics.Click += btnSeeStatistics_Click;
            // 
            // btnSalesAndAchive
            // 
            btnSalesAndAchive.BackColor = Color.FromArgb(112, 193, 179);
            btnSalesAndAchive.FlatStyle = FlatStyle.Flat;
            btnSalesAndAchive.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalesAndAchive.Location = new Point(769, 410);
            btnSalesAndAchive.Name = "btnSalesAndAchive";
            btnSalesAndAchive.Size = new Size(332, 331);
            btnSalesAndAchive.TabIndex = 2;
            btnSalesAndAchive.Text = "Sales and Archive";
            btnSalesAndAchive.UseVisualStyleBackColor = false;
            btnSalesAndAchive.Click += btnSalesAndAchive_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.BackColor = Color.FromArgb(112, 193, 179);
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCustomers.Location = new Point(1410, 410);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(332, 331);
            btnCustomers.TabIndex = 3;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = false;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // pbLogOut
            // 
            pbLogOut.BackColor = Color.Transparent;
            pbLogOut.Image = (Image)resources.GetObject("pbLogOut.Image");
            pbLogOut.Location = new Point(11, 13);
            pbLogOut.Name = "pbLogOut";
            pbLogOut.Size = new Size(107, 114);
            pbLogOut.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogOut.TabIndex = 10;
            pbLogOut.TabStop = false;
            pbLogOut.Click += pbLogOut_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.BackColor = Color.FromArgb(112, 193, 179);
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEmployees.Location = new Point(459, 410);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(332, 331);
            btnEmployees.TabIndex = 11;
            btnEmployees.Text = "Employees";
            btnEmployees.UseVisualStyleBackColor = false;
            btnEmployees.Click += button1_Click;
            // 
            // pbAccountIcon
            // 
            pbAccountIcon.BackColor = Color.Transparent;
            pbAccountIcon.Image = (Image)resources.GetObject("pbAccountIcon.Image");
            pbAccountIcon.Location = new Point(1736, 22);
            pbAccountIcon.Name = "pbAccountIcon";
            pbAccountIcon.Size = new Size(104, 104);
            pbAccountIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pbAccountIcon.TabIndex = 12;
            pbAccountIcon.TabStop = false;
            pbAccountIcon.Click += pbAccountIcon_Click;
            // 
            // MenuPageStaff
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1849, 1217);
            Controls.Add(pbAccountIcon);
            Controls.Add(btnEmployees);
            Controls.Add(pbLogOut);
            Controls.Add(btnCustomers);
            Controls.Add(btnSalesAndAchive);
            Controls.Add(btnSeeStatistics);
            Controls.Add(btnManageVehicles);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(1875, 1288);
            MinimumSize = new Size(1875, 1288);
            Name = "MenuPageStaff";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            FormClosing += AnyForm_FormClosing;
            //Load += MenuPageStaff_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAccountIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageVehicles;
        private Button btnSeeStatistics;
        private Button btnSalesAndAchive;
        private Button btnCustomers;
        private PictureBox pbLogOut;
        private Button btnEmployees;
        private PictureBox pbAccountIcon;
    }
}