namespace FormApplication
{
    partial class StatisticsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsPage));
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            btnCategoryAvailability = new Button();
            btnMonthsRevenue = new Button();
            CarsYearsofProduction = new Button();
            button234 = new Button();
            pbBackToMenu = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbBackToMenu).BeginInit();
            SuspendLayout();
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // plotView1
            // 
            plotView1.BackColor = Color.FromArgb(94, 94, 94);
            plotView1.Location = new Point(612, 148);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(1149, 967);
            plotView1.TabIndex = 0;
            plotView1.Text = "Graph Here";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // btnCategoryAvailability
            // 
            btnCategoryAvailability.BackColor = Color.FromArgb(159, 160, 255);
            btnCategoryAvailability.FlatAppearance.BorderSize = 0;
            btnCategoryAvailability.FlatStyle = FlatStyle.Flat;
            btnCategoryAvailability.Location = new Point(313, 148);
            btnCategoryAvailability.Name = "btnCategoryAvailability";
            btnCategoryAvailability.Size = new Size(303, 82);
            btnCategoryAvailability.TabIndex = 1;
            btnCategoryAvailability.Text = "Category Availability";
            btnCategoryAvailability.UseVisualStyleBackColor = false;
            btnCategoryAvailability.Click += btnCategoryAvailability_Click;
            // 
            // btnMonthsRevenue
            // 
            btnMonthsRevenue.BackColor = Color.FromArgb(159, 160, 255);
            btnMonthsRevenue.FlatStyle = FlatStyle.Flat;
            btnMonthsRevenue.Location = new Point(313, 306);
            btnMonthsRevenue.Name = "btnMonthsRevenue";
            btnMonthsRevenue.Size = new Size(303, 82);
            btnMonthsRevenue.TabIndex = 4;
            btnMonthsRevenue.Text = "Months Revenue";
            btnMonthsRevenue.UseVisualStyleBackColor = false;
            btnMonthsRevenue.Click += button2_Click;
            // 
            // CarsYearsofProduction
            // 
            CarsYearsofProduction.BackColor = Color.FromArgb(159, 160, 255);
            CarsYearsofProduction.FlatStyle = FlatStyle.Flat;
            CarsYearsofProduction.Location = new Point(313, 385);
            CarsYearsofProduction.Name = "CarsYearsofProduction";
            CarsYearsofProduction.Size = new Size(303, 82);
            CarsYearsofProduction.TabIndex = 5;
            CarsYearsofProduction.Text = "Cars Production Year";
            CarsYearsofProduction.UseVisualStyleBackColor = false;
            CarsYearsofProduction.Click += button3_Click;
            // 
            // button234
            // 
            button234.BackColor = Color.FromArgb(159, 160, 255);
            button234.FlatStyle = FlatStyle.Flat;
            button234.Location = new Point(313, 227);
            button234.Name = "button234";
            button234.Size = new Size(303, 82);
            button234.TabIndex = 7;
            button234.Text = "Vehicle's rating";
            button234.UseVisualStyleBackColor = false;
            button234.Click += button234_Click;
            // 
            // pbBackToMenu
            // 
            pbBackToMenu.BackColor = Color.Transparent;
            pbBackToMenu.Image = (Image)resources.GetObject("pbBackToMenu.Image");
            pbBackToMenu.Location = new Point(12, 12);
            pbBackToMenu.Name = "pbBackToMenu";
            pbBackToMenu.Size = new Size(135, 135);
            pbBackToMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBackToMenu.TabIndex = 55;
            pbBackToMenu.TabStop = false;
            pbBackToMenu.Click += pbBackToMenu_Click;
            // 
            // StatisticsPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1849, 1217);
            Controls.Add(pbBackToMenu);
            Controls.Add(button234);
            Controls.Add(CarsYearsofProduction);
            Controls.Add(btnMonthsRevenue);
            Controls.Add(btnCategoryAvailability);
            Controls.Add(plotView1);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(1875, 1288);
            MinimumSize = new Size(1875, 1288);
            Name = "StatisticsPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Statistics";
            FormClosing += AnyForm_FormClosing;
            //Load += StatisticsPage_Load;
            ((System.ComponentModel.ISupportInitialize)pbBackToMenu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private Button btnCategoryAvailability;
        private Button btnMonthsRevenue;
        private Button CarsYearsofProduction;
        private Button button234;
        private PictureBox pbBackToMenu;
    }
}