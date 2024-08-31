namespace FormApplication
{
    partial class ManageCustomersPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCustomersPage));
            pbBackToMenu = new PictureBox();
            gbCustomerInformation = new GroupBox();
            btnChangeLoyality = new Button();
            lbBoughtVehicles = new ListBox();
            lbSavedForBuyingVehicles = new ListBox();
            pbSaved = new PictureBox();
            pbBought = new PictureBox();
            pbLoyalClientBadge = new PictureBox();
            labelCustomerLastName = new Label();
            labelCustomerHeader = new Label();
            labelFirstName = new Label();
            labelCustomerFirstName = new Label();
            labelLastName = new Label();
            labelEmail = new Label();
            labelCustomerEmail = new Label();
            labelPhoneNumber = new Label();
            labelCustomerPhoneNumber = new Label();
            labelSearch = new Label();
            labelResults = new Label();
            tbSearchBar = new TextBox();
            lbCustomersList = new ListBox();
            labelPageNum = new Label();
            btnPrevPage = new Button();
            btnNextPage = new Button();
            pbSearch = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbBackToMenu).BeginInit();
            gbCustomerInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSaved).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBought).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLoyalClientBadge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
            SuspendLayout();
            // 
            // pbBackToMenu
            // 
            pbBackToMenu.BackColor = Color.Transparent;
            pbBackToMenu.Image = (Image)resources.GetObject("pbBackToMenu.Image");
            pbBackToMenu.Location = new Point(11, 19);
            pbBackToMenu.Name = "pbBackToMenu";
            pbBackToMenu.Size = new Size(135, 134);
            pbBackToMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBackToMenu.TabIndex = 61;
            pbBackToMenu.TabStop = false;
            pbBackToMenu.Click += pbBackToMenu_Click;
            // 
            // gbCustomerInformation
            // 
            gbCustomerInformation.BackColor = Color.FromArgb(130, 160, 188);
            gbCustomerInformation.Controls.Add(btnChangeLoyality);
            gbCustomerInformation.Controls.Add(lbBoughtVehicles);
            gbCustomerInformation.Controls.Add(lbSavedForBuyingVehicles);
            gbCustomerInformation.Controls.Add(pbSaved);
            gbCustomerInformation.Controls.Add(pbBought);
            gbCustomerInformation.Controls.Add(pbLoyalClientBadge);
            gbCustomerInformation.Controls.Add(labelCustomerLastName);
            gbCustomerInformation.Controls.Add(labelCustomerHeader);
            gbCustomerInformation.Controls.Add(labelFirstName);
            gbCustomerInformation.Controls.Add(labelCustomerFirstName);
            gbCustomerInformation.Controls.Add(labelLastName);
            gbCustomerInformation.Controls.Add(labelEmail);
            gbCustomerInformation.Controls.Add(labelCustomerEmail);
            gbCustomerInformation.Controls.Add(labelPhoneNumber);
            gbCustomerInformation.Controls.Add(labelCustomerPhoneNumber);
            gbCustomerInformation.Location = new Point(578, 150);
            gbCustomerInformation.Name = "gbCustomerInformation";
            gbCustomerInformation.Size = new Size(1251, 1054);
            gbCustomerInformation.TabIndex = 60;
            gbCustomerInformation.TabStop = false;
            gbCustomerInformation.Text = "Customer Information";
            // 
            // btnChangeLoyality
            // 
            btnChangeLoyality.BackColor = Color.FromArgb(251, 176, 59);
            btnChangeLoyality.FlatAppearance.BorderColor = Color.FromArgb(0, 59, 112);
            btnChangeLoyality.FlatAppearance.BorderSize = 2;
            btnChangeLoyality.FlatStyle = FlatStyle.Flat;
            btnChangeLoyality.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangeLoyality.ForeColor = Color.FromArgb(0, 59, 112);
            btnChangeLoyality.Location = new Point(822, 22);
            btnChangeLoyality.Name = "btnChangeLoyality";
            btnChangeLoyality.Size = new Size(154, 74);
            btnChangeLoyality.TabIndex = 63;
            btnChangeLoyality.Text = "Promote";
            btnChangeLoyality.UseVisualStyleBackColor = false;
            btnChangeLoyality.Click += btnChangeLoyality_Click;
            // 
            // lbBoughtVehicles
            // 
            lbBoughtVehicles.BackColor = Color.FromArgb(94, 94, 94);
            lbBoughtVehicles.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbBoughtVehicles.ForeColor = SystemColors.Info;
            lbBoughtVehicles.FormattingEnabled = true;
            lbBoughtVehicles.ItemHeight = 40;
            lbBoughtVehicles.Location = new Point(666, 610);
            lbBoughtVehicles.Name = "lbBoughtVehicles";
            lbBoughtVehicles.Size = new Size(568, 324);
            lbBoughtVehicles.TabIndex = 62;
            // 
            // lbSavedForBuyingVehicles
            // 
            lbSavedForBuyingVehicles.BackColor = Color.FromArgb(94, 94, 94);
            lbSavedForBuyingVehicles.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbSavedForBuyingVehicles.ForeColor = SystemColors.Info;
            lbSavedForBuyingVehicles.FormattingEnabled = true;
            lbSavedForBuyingVehicles.ItemHeight = 40;
            lbSavedForBuyingVehicles.Location = new Point(20, 610);
            lbSavedForBuyingVehicles.Name = "lbSavedForBuyingVehicles";
            lbSavedForBuyingVehicles.Size = new Size(568, 324);
            lbSavedForBuyingVehicles.TabIndex = 61;
            // 
            // pbSaved
            // 
            pbSaved.Image = (Image)resources.GetObject("pbSaved.Image");
            pbSaved.InitialImage = (Image)resources.GetObject("pbSaved.InitialImage");
            pbSaved.Location = new Point(20, 533);
            pbSaved.Name = "pbSaved";
            pbSaved.Size = new Size(70, 70);
            pbSaved.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSaved.TabIndex = 58;
            pbSaved.TabStop = false;
            // 
            // pbBought
            // 
            pbBought.Image = (Image)resources.GetObject("pbBought.Image");
            pbBought.InitialImage = (Image)resources.GetObject("pbBought.InitialImage");
            pbBought.Location = new Point(666, 533);
            pbBought.Name = "pbBought";
            pbBought.Size = new Size(70, 70);
            pbBought.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBought.TabIndex = 57;
            pbBought.TabStop = false;
            // 
            // pbLoyalClientBadge
            // 
            pbLoyalClientBadge.Image = (Image)resources.GetObject("pbLoyalClientBadge.Image");
            pbLoyalClientBadge.InitialImage = (Image)resources.GetObject("pbLoyalClientBadge.InitialImage");
            pbLoyalClientBadge.Location = new Point(507, 19);
            pbLoyalClientBadge.Name = "pbLoyalClientBadge";
            pbLoyalClientBadge.Size = new Size(120, 120);
            pbLoyalClientBadge.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLoyalClientBadge.TabIndex = 56;
            pbLoyalClientBadge.TabStop = false;
            // 
            // labelCustomerLastName
            // 
            labelCustomerLastName.AutoSize = true;
            labelCustomerLastName.BackColor = Color.Transparent;
            labelCustomerLastName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCustomerLastName.Location = new Point(205, 286);
            labelCustomerLastName.Name = "labelCustomerLastName";
            labelCustomerLastName.Size = new Size(194, 32);
            labelCustomerLastName.TabIndex = 25;
            labelCustomerLastName.Text = "Last Name Here";
            // 
            // labelCustomerHeader
            // 
            labelCustomerHeader.AutoSize = true;
            labelCustomerHeader.BackColor = Color.Transparent;
            labelCustomerHeader.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelCustomerHeader.Location = new Point(20, 54);
            labelCustomerHeader.Name = "labelCustomerHeader";
            labelCustomerHeader.Size = new Size(317, 50);
            labelCustomerHeader.TabIndex = 9;
            labelCustomerHeader.Text = "Customer Names";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.BackColor = Color.Transparent;
            labelFirstName.Location = new Point(16, 232);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(134, 32);
            labelFirstName.TabIndex = 10;
            labelFirstName.Text = "First Name:";
            // 
            // labelCustomerFirstName
            // 
            labelCustomerFirstName.AutoSize = true;
            labelCustomerFirstName.BackColor = Color.Transparent;
            labelCustomerFirstName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCustomerFirstName.Location = new Point(205, 232);
            labelCustomerFirstName.Name = "labelCustomerFirstName";
            labelCustomerFirstName.Size = new Size(198, 32);
            labelCustomerFirstName.TabIndex = 11;
            labelCustomerFirstName.Text = "First Name Here";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.BackColor = Color.Transparent;
            labelLastName.Location = new Point(16, 286);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(131, 32);
            labelLastName.TabIndex = 24;
            labelLastName.Text = "Last Name:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.BackColor = Color.Transparent;
            labelEmail.Location = new Point(16, 344);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(76, 32);
            labelEmail.TabIndex = 27;
            labelEmail.Text = "Email:";
            // 
            // labelCustomerEmail
            // 
            labelCustomerEmail.AutoSize = true;
            labelCustomerEmail.BackColor = Color.Transparent;
            labelCustomerEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCustomerEmail.Location = new Point(205, 344);
            labelCustomerEmail.Name = "labelCustomerEmail";
            labelCustomerEmail.Size = new Size(137, 32);
            labelCustomerEmail.TabIndex = 28;
            labelCustomerEmail.Text = "Email Here";
            // 
            // labelPhoneNumber
            // 
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.BackColor = Color.Transparent;
            labelPhoneNumber.Location = new Point(16, 398);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new Size(182, 32);
            labelPhoneNumber.TabIndex = 29;
            labelPhoneNumber.Text = "Phone Number:";
            // 
            // labelCustomerPhoneNumber
            // 
            labelCustomerPhoneNumber.AutoSize = true;
            labelCustomerPhoneNumber.BackColor = Color.Transparent;
            labelCustomerPhoneNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCustomerPhoneNumber.Location = new Point(205, 398);
            labelCustomerPhoneNumber.Name = "labelCustomerPhoneNumber";
            labelCustomerPhoneNumber.Size = new Size(248, 32);
            labelCustomerPhoneNumber.TabIndex = 30;
            labelCustomerPhoneNumber.Text = "Phone Number Here";
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.BackColor = Color.Transparent;
            labelSearch.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSearch.ForeColor = SystemColors.ButtonHighlight;
            labelSearch.Location = new Point(31, 170);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(106, 37);
            labelSearch.TabIndex = 59;
            labelSearch.Text = "Search:";
            // 
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.BackColor = Color.Transparent;
            labelResults.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelResults.ForeColor = SystemColors.ButtonHighlight;
            labelResults.Location = new Point(31, 274);
            labelResults.Name = "labelResults";
            labelResults.Size = new Size(111, 37);
            labelResults.TabIndex = 58;
            labelResults.Text = "Results:";
            // 
            // tbSearchBar
            // 
            tbSearchBar.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearchBar.Location = new Point(31, 210);
            tbSearchBar.Name = "tbSearchBar";
            tbSearchBar.Size = new Size(469, 46);
            tbSearchBar.TabIndex = 56;
            //tbSearchBar.TextChanged += tbSearchBar_TextChanged;
            // 
            // lbCustomersList
            // 
            lbCustomersList.BackColor = Color.FromArgb(94, 94, 94);
            lbCustomersList.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCustomersList.ForeColor = SystemColors.Info;
            lbCustomersList.FormattingEnabled = true;
            lbCustomersList.ItemHeight = 37;
            lbCustomersList.Location = new Point(31, 314);
            lbCustomersList.Name = "lbCustomersList";
            lbCustomersList.Size = new Size(542, 744);
            lbCustomersList.TabIndex = 55;
            lbCustomersList.SelectedIndexChanged += lbCustomersList_SelectedIndexChanged;
            // 
            // labelPageNum
            // 
            labelPageNum.AutoSize = true;
            labelPageNum.BackColor = Color.Transparent;
            labelPageNum.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPageNum.ForeColor = Color.White;
            labelPageNum.Location = new Point(444, 1112);
            labelPageNum.Name = "labelPageNum";
            labelPageNum.Size = new Size(65, 37);
            labelPageNum.TabIndex = 64;
            labelPageNum.Text = "1/10";
            // 
            // btnPrevPage
            // 
            btnPrevPage.BackColor = Color.FromArgb(167, 204, 237);
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrevPage.Location = new Point(374, 1101);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(58, 61);
            btnPrevPage.TabIndex = 62;
            btnPrevPage.Text = "<";
            btnPrevPage.UseVisualStyleBackColor = false;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.BackColor = Color.FromArgb(167, 204, 237);
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextPage.Location = new Point(514, 1101);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(58, 61);
            btnNextPage.TabIndex = 63;
            btnNextPage.Text = ">";
            btnNextPage.UseVisualStyleBackColor = false;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // pbSearch
            // 
            pbSearch.BackColor = Color.FromArgb(94, 94, 94);
            pbSearch.ErrorImage = (Image)resources.GetObject("pbSearch.ErrorImage");
            pbSearch.Image = (Image)resources.GetObject("pbSearch.Image");
            pbSearch.InitialImage = (Image)resources.GetObject("pbSearch.InitialImage");
            pbSearch.Location = new Point(506, 191);
            pbSearch.Margin = new Padding(4, 4, 4, 5);
            pbSearch.Name = "pbSearch";
            pbSearch.Size = new Size(65, 65);
            pbSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSearch.TabIndex = 66;
            pbSearch.TabStop = false;
            pbSearch.Click += pbSearch_Click;
            // 
            // ManageCustomersPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1844, 1203);
            Controls.Add(pbSearch);
            Controls.Add(labelPageNum);
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Controls.Add(pbBackToMenu);
            Controls.Add(gbCustomerInformation);
            Controls.Add(labelSearch);
            Controls.Add(labelResults);
            Controls.Add(tbSearchBar);
            Controls.Add(lbCustomersList);
            DoubleBuffered = true;
            MaximumSize = new Size(1870, 1274);
            MinimumSize = new Size(1870, 1274);
            Name = "ManageCustomersPage";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Customers";
            FormClosing += AnyForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pbBackToMenu).EndInit();
            gbCustomerInformation.ResumeLayout(false);
            gbCustomerInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSaved).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBought).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLoyalClientBadge).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbBackToMenu;
        private GroupBox gbCustomerInformation;
        private Label labelCustomerLastName;
        private Label labelCustomerHeader;
        private Label labelFirstName;
        private Label labelCustomerFirstName;
        private Label labelLastName;
        private Label labelEmail;
        private Label labelCustomerEmail;
        private Label labelPhoneNumber;
        private Label labelCustomerPhoneNumber;
        private Label labelSearch;
        private Label labelResults;
        private TextBox tbSearchBar;
        private ListBox lbCustomersList;
        private PictureBox pbLoyalClientBadge;
        private PictureBox pbSaved;
        private PictureBox pbBought;
        private ListBox lbBoughtVehicles;
        private ListBox lbSavedForBuyingVehicles;
        private Button btnChangeLoyality;
        private Label labelPageNum;
        private Button btnPrevPage;
        private Button btnNextPage;
        private PictureBox pbSearch;
    }
}