namespace FormApplication
{
    partial class SellVehiclePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellVehiclePage));
            rbDefaultPrice = new RadioButton();
            rbOtherPrice = new RadioButton();
            labelSellingPrice = new Label();
            labelDefaultVehiclePrice = new Label();
            nmNewPrice = new NumericUpDown();
            labelSearch = new Label();
            labelResults = new Label();
            lbCustomersList = new ListBox();
            tbSearchBar = new TextBox();
            ResultLabel = new Label();
            SearchLabel = new Label();
            labelCustomerPhoneNumber = new Label();
            labelPhoneNumber = new Label();
            labelCustomerEmail = new Label();
            labelEmail = new Label();
            labelLastName = new Label();
            labelCustomerFirstName = new Label();
            labelFirstName = new Label();
            labelPersonHeader = new Label();
            labelCustomerLastName = new Label();
            btnSellVehicle = new Button();
            pbLoyalClientBadge = new PictureBox();
            gbCustomerInformation = new GroupBox();
            labelSellingPricePrinter = new Label();
            labelFinalPrice = new Label();
            labelChoosePaymentMethod = new Label();
            rbBankTransfer = new RadioButton();
            rbCash = new RadioButton();
            rbCreditCard = new RadioButton();
            rbDebitCard = new RadioButton();
            btnConfirmSellingPrice = new Button();
            btnConfirmPaymentMethod = new Button();
            labelPageNum = new Label();
            btnPrevPage = new Button();
            btnNextPage = new Button();
            pbSearch = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)nmNewPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLoyalClientBadge).BeginInit();
            gbCustomerInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
            SuspendLayout();
            // 
            // rbDefaultPrice
            // 
            rbDefaultPrice.AutoSize = true;
            rbDefaultPrice.BackColor = Color.Transparent;
            rbDefaultPrice.Font = new Font("Segoe UI", 10.125F);
            rbDefaultPrice.ForeColor = Color.White;
            rbDefaultPrice.Location = new Point(291, 131);
            rbDefaultPrice.Name = "rbDefaultPrice";
            rbDefaultPrice.Size = new Size(198, 41);
            rbDefaultPrice.TabIndex = 0;
            rbDefaultPrice.TabStop = true;
            rbDefaultPrice.Text = "Default Price";
            rbDefaultPrice.UseVisualStyleBackColor = false;
            rbDefaultPrice.CheckedChanged += rbDefaultPrice_CheckedChanged;
            // 
            // rbOtherPrice
            // 
            rbOtherPrice.AutoSize = true;
            rbOtherPrice.BackColor = Color.Transparent;
            rbOtherPrice.Font = new Font("Segoe UI", 10.125F);
            rbOtherPrice.ForeColor = Color.White;
            rbOtherPrice.Location = new Point(553, 131);
            rbOtherPrice.Name = "rbOtherPrice";
            rbOtherPrice.Size = new Size(180, 41);
            rbOtherPrice.TabIndex = 1;
            rbOtherPrice.TabStop = true;
            rbOtherPrice.Text = "Other price";
            rbOtherPrice.UseVisualStyleBackColor = false;
            rbOtherPrice.CheckedChanged += rbOtherPrice_CheckedChanged;
            // 
            // labelSellingPrice
            // 
            labelSellingPrice.AutoSize = true;
            labelSellingPrice.BackColor = Color.Transparent;
            labelSellingPrice.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSellingPrice.ForeColor = Color.White;
            labelSellingPrice.Location = new Point(12, 131);
            labelSellingPrice.Name = "labelSellingPrice";
            labelSellingPrice.Size = new Size(271, 37);
            labelSellingPrice.TabIndex = 2;
            labelSellingPrice.Text = "Choose Selling Price:";
            // 
            // labelDefaultVehiclePrice
            // 
            labelDefaultVehiclePrice.AutoSize = true;
            labelDefaultVehiclePrice.BackColor = Color.Transparent;
            labelDefaultVehiclePrice.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDefaultVehiclePrice.ForeColor = Color.White;
            labelDefaultVehiclePrice.Location = new Point(291, 194);
            labelDefaultVehiclePrice.Name = "labelDefaultVehiclePrice";
            labelDefaultVehiclePrice.Size = new Size(238, 37);
            labelDefaultVehiclePrice.TabIndex = 3;
            labelDefaultVehiclePrice.Text = "Default Price Here";
            // 
            // nmNewPrice
            // 
            nmNewPrice.Location = new Point(553, 192);
            nmNewPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nmNewPrice.Name = "nmNewPrice";
            nmNewPrice.Size = new Size(240, 39);
            nmNewPrice.TabIndex = 4;
            nmNewPrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nmNewPrice.ValueChanged += nmNewPrice_ValueChanged;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.BackColor = Color.Transparent;
            labelSearch.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSearch.ForeColor = SystemColors.ButtonHighlight;
            labelSearch.Location = new Point(-129, -45);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(106, 37);
            labelSearch.TabIndex = 64;
            labelSearch.Text = "Search:";
            // 
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.BackColor = Color.Transparent;
            labelResults.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelResults.ForeColor = SystemColors.ButtonHighlight;
            labelResults.Location = new Point(-129, 58);
            labelResults.Name = "labelResults";
            labelResults.Size = new Size(111, 37);
            labelResults.TabIndex = 63;
            labelResults.Text = "Results:";
            // 
            // lbCustomersList
            // 
            lbCustomersList.BackColor = Color.FromArgb(94, 94, 94);
            lbCustomersList.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCustomersList.ForeColor = SystemColors.Info;
            lbCustomersList.FormattingEnabled = true;
            lbCustomersList.ItemHeight = 37;
            lbCustomersList.Location = new Point(12, 572);
            lbCustomersList.Name = "lbCustomersList";
            lbCustomersList.Size = new Size(517, 411);
            lbCustomersList.TabIndex = 65;
            lbCustomersList.SelectedIndexChanged += lbCustomersList_SelectedIndexChanged;
            // 
            // tbSearchBar
            // 
            tbSearchBar.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearchBar.Location = new Point(12, 449);
            tbSearchBar.Name = "tbSearchBar";
            tbSearchBar.Size = new Size(445, 46);
            tbSearchBar.TabIndex = 66;
            //tbSearchBar.TextChanged += tbSearchBar_TextChanged;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.BackColor = Color.Transparent;
            ResultLabel.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ResultLabel.ForeColor = SystemColors.ButtonHighlight;
            ResultLabel.Location = new Point(12, 532);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(111, 37);
            ResultLabel.TabIndex = 68;
            ResultLabel.Text = "Results:";
            // 
            // SearchLabel
            // 
            SearchLabel.AutoSize = true;
            SearchLabel.BackColor = Color.Transparent;
            SearchLabel.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchLabel.ForeColor = SystemColors.ButtonHighlight;
            SearchLabel.Location = new Point(12, 409);
            SearchLabel.Name = "SearchLabel";
            SearchLabel.Size = new Size(106, 37);
            SearchLabel.TabIndex = 69;
            SearchLabel.Text = "Search:";
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
            // labelPhoneNumber
            // 
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.BackColor = Color.Transparent;
            labelPhoneNumber.Location = new Point(17, 398);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new Size(182, 32);
            labelPhoneNumber.TabIndex = 29;
            labelPhoneNumber.Text = "Phone Number:";
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
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.BackColor = Color.Transparent;
            labelEmail.Location = new Point(17, 344);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(76, 32);
            labelEmail.TabIndex = 27;
            labelEmail.Text = "Email:";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.BackColor = Color.Transparent;
            labelLastName.Location = new Point(17, 287);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(131, 32);
            labelLastName.TabIndex = 24;
            labelLastName.Text = "Last Name:";
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
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.BackColor = Color.Transparent;
            labelFirstName.Location = new Point(17, 232);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(134, 32);
            labelFirstName.TabIndex = 10;
            labelFirstName.Text = "First Name:";
            // 
            // labelPersonHeader
            // 
            labelPersonHeader.AutoSize = true;
            labelPersonHeader.BackColor = Color.Transparent;
            labelPersonHeader.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelPersonHeader.Location = new Point(20, 55);
            labelPersonHeader.Name = "labelPersonHeader";
            labelPersonHeader.Size = new Size(317, 50);
            labelPersonHeader.TabIndex = 9;
            labelPersonHeader.Text = "Customer Names";
            // 
            // labelCustomerLastName
            // 
            labelCustomerLastName.AutoSize = true;
            labelCustomerLastName.BackColor = Color.Transparent;
            labelCustomerLastName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCustomerLastName.Location = new Point(205, 287);
            labelCustomerLastName.Name = "labelCustomerLastName";
            labelCustomerLastName.Size = new Size(194, 32);
            labelCustomerLastName.TabIndex = 25;
            labelCustomerLastName.Text = "Last Name Here";
            // 
            // btnSellVehicle
            // 
            btnSellVehicle.BackColor = Color.FromArgb(4, 232, 36);
            btnSellVehicle.FlatStyle = FlatStyle.Flat;
            btnSellVehicle.Location = new Point(712, 567);
            btnSellVehicle.Name = "btnSellVehicle";
            btnSellVehicle.Size = new Size(266, 74);
            btnSellVehicle.TabIndex = 5;
            btnSellVehicle.Text = "Sell";
            btnSellVehicle.UseVisualStyleBackColor = false;
            btnSellVehicle.Click += btnSellVehicle_Click;
            // 
            // pbLoyalClientBadge
            // 
            pbLoyalClientBadge.Image = (Image)resources.GetObject("pbLoyalClientBadge.Image");
            pbLoyalClientBadge.InitialImage = (Image)resources.GetObject("pbLoyalClientBadge.InitialImage");
            pbLoyalClientBadge.Location = new Point(858, 23);
            pbLoyalClientBadge.Name = "pbLoyalClientBadge";
            pbLoyalClientBadge.Size = new Size(120, 120);
            pbLoyalClientBadge.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLoyalClientBadge.TabIndex = 56;
            pbLoyalClientBadge.TabStop = false;
            // 
            // gbCustomerInformation
            // 
            gbCustomerInformation.BackColor = Color.FromArgb(130, 160, 188);
            gbCustomerInformation.Controls.Add(pbLoyalClientBadge);
            gbCustomerInformation.Controls.Add(btnSellVehicle);
            gbCustomerInformation.Controls.Add(labelCustomerLastName);
            gbCustomerInformation.Controls.Add(labelPersonHeader);
            gbCustomerInformation.Controls.Add(labelFirstName);
            gbCustomerInformation.Controls.Add(labelCustomerFirstName);
            gbCustomerInformation.Controls.Add(labelLastName);
            gbCustomerInformation.Controls.Add(labelEmail);
            gbCustomerInformation.Controls.Add(labelCustomerEmail);
            gbCustomerInformation.Controls.Add(labelPhoneNumber);
            gbCustomerInformation.Controls.Add(labelCustomerPhoneNumber);
            gbCustomerInformation.Location = new Point(553, 409);
            gbCustomerInformation.Name = "gbCustomerInformation";
            gbCustomerInformation.Size = new Size(984, 647);
            gbCustomerInformation.TabIndex = 70;
            gbCustomerInformation.TabStop = false;
            gbCustomerInformation.Text = "Customer Information";
            // 
            // labelSellingPricePrinter
            // 
            labelSellingPricePrinter.AutoSize = true;
            labelSellingPricePrinter.BackColor = Color.Transparent;
            labelSellingPricePrinter.Font = new Font("Arial", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSellingPricePrinter.ForeColor = Color.White;
            labelSellingPricePrinter.Location = new Point(1045, 131);
            labelSellingPricePrinter.Name = "labelSellingPricePrinter";
            labelSellingPricePrinter.Size = new Size(220, 44);
            labelSellingPricePrinter.TabIndex = 71;
            labelSellingPricePrinter.Text = "Final Price:";
            // 
            // labelFinalPrice
            // 
            labelFinalPrice.AutoSize = true;
            labelFinalPrice.BackColor = Color.Transparent;
            labelFinalPrice.Font = new Font("Arial", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFinalPrice.ForeColor = Color.White;
            labelFinalPrice.Location = new Point(1271, 131);
            labelFinalPrice.Name = "labelFinalPrice";
            labelFinalPrice.Size = new Size(203, 44);
            labelFinalPrice.TabIndex = 72;
            labelFinalPrice.Text = "Price Here";
            // 
            // labelChoosePaymentMethod
            // 
            labelChoosePaymentMethod.AutoSize = true;
            labelChoosePaymentMethod.BackColor = Color.Transparent;
            labelChoosePaymentMethod.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelChoosePaymentMethod.ForeColor = Color.White;
            labelChoosePaymentMethod.Location = new Point(12, 280);
            labelChoosePaymentMethod.Name = "labelChoosePaymentMethod";
            labelChoosePaymentMethod.Size = new Size(333, 37);
            labelChoosePaymentMethod.TabIndex = 73;
            labelChoosePaymentMethod.Text = "Choose Payment Method:";
            // 
            // rbBankTransfer
            // 
            rbBankTransfer.AutoSize = true;
            rbBankTransfer.BackColor = Color.Transparent;
            rbBankTransfer.Font = new Font("Segoe UI", 10.125F);
            rbBankTransfer.ForeColor = Color.White;
            rbBankTransfer.Location = new Point(380, 280);
            rbBankTransfer.Name = "rbBankTransfer";
            rbBankTransfer.Size = new Size(204, 41);
            rbBankTransfer.TabIndex = 74;
            rbBankTransfer.TabStop = true;
            rbBankTransfer.Text = "Bank Transfer";
            rbBankTransfer.UseVisualStyleBackColor = false;
            rbBankTransfer.CheckedChanged += rbBankTransfer_CheckedChanged;
            // 
            // rbCash
            // 
            rbCash.AutoSize = true;
            rbCash.BackColor = Color.Transparent;
            rbCash.Font = new Font("Segoe UI", 10.125F);
            rbCash.ForeColor = Color.White;
            rbCash.Location = new Point(622, 280);
            rbCash.Name = "rbCash";
            rbCash.Size = new Size(105, 41);
            rbCash.TabIndex = 75;
            rbCash.TabStop = true;
            rbCash.Text = "Cash";
            rbCash.UseVisualStyleBackColor = false;
            rbCash.CheckedChanged += rbCash_CheckedChanged;
            // 
            // rbCreditCard
            // 
            rbCreditCard.AutoSize = true;
            rbCreditCard.BackColor = Color.Transparent;
            rbCreditCard.Font = new Font("Segoe UI", 10.125F);
            rbCreditCard.ForeColor = Color.White;
            rbCreditCard.Location = new Point(380, 336);
            rbCreditCard.Name = "rbCreditCard";
            rbCreditCard.Size = new Size(183, 41);
            rbCreditCard.TabIndex = 76;
            rbCreditCard.TabStop = true;
            rbCreditCard.Text = "Credit Card";
            rbCreditCard.UseVisualStyleBackColor = false;
            rbCreditCard.CheckedChanged += rbCreditCard_CheckedChanged;
            // 
            // rbDebitCard
            // 
            rbDebitCard.AutoSize = true;
            rbDebitCard.BackColor = Color.Transparent;
            rbDebitCard.Font = new Font("Segoe UI", 10.125F);
            rbDebitCard.ForeColor = Color.White;
            rbDebitCard.Location = new Point(622, 336);
            rbDebitCard.Name = "rbDebitCard";
            rbDebitCard.Size = new Size(176, 41);
            rbDebitCard.TabIndex = 77;
            rbDebitCard.TabStop = true;
            rbDebitCard.Text = "Debit Card";
            rbDebitCard.UseVisualStyleBackColor = false;
            rbDebitCard.CheckedChanged += rbDebitCard_CheckedChanged;
            // 
            // btnConfirmSellingPrice
            // 
            btnConfirmSellingPrice.BackColor = Color.FromArgb(112, 193, 179);
            btnConfirmSellingPrice.FlatStyle = FlatStyle.Flat;
            btnConfirmSellingPrice.Location = new Point(848, 158);
            btnConfirmSellingPrice.Name = "btnConfirmSellingPrice";
            btnConfirmSellingPrice.Size = new Size(120, 54);
            btnConfirmSellingPrice.TabIndex = 78;
            btnConfirmSellingPrice.Text = "Confirm";
            btnConfirmSellingPrice.UseVisualStyleBackColor = false;
            btnConfirmSellingPrice.Click += btnConfirmSellingPrice_Click;
            // 
            // btnConfirmPaymentMethod
            // 
            btnConfirmPaymentMethod.BackColor = Color.FromArgb(112, 193, 179);
            btnConfirmPaymentMethod.FlatStyle = FlatStyle.Flat;
            btnConfirmPaymentMethod.Location = new Point(848, 300);
            btnConfirmPaymentMethod.Name = "btnConfirmPaymentMethod";
            btnConfirmPaymentMethod.Size = new Size(120, 54);
            btnConfirmPaymentMethod.TabIndex = 79;
            btnConfirmPaymentMethod.Text = "Confirm";
            btnConfirmPaymentMethod.UseVisualStyleBackColor = false;
            btnConfirmPaymentMethod.Click += btnConfirmPaymentMethod_Click;
            // 
            // labelPageNum
            // 
            labelPageNum.AutoSize = true;
            labelPageNum.BackColor = Color.Transparent;
            labelPageNum.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPageNum.ForeColor = Color.White;
            labelPageNum.Location = new Point(399, 1007);
            labelPageNum.Name = "labelPageNum";
            labelPageNum.Size = new Size(65, 37);
            labelPageNum.TabIndex = 82;
            labelPageNum.Text = "1/10";
            // 
            // btnPrevPage
            // 
            btnPrevPage.BackColor = Color.FromArgb(167, 204, 237);
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrevPage.Location = new Point(329, 995);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(59, 61);
            btnPrevPage.TabIndex = 80;
            btnPrevPage.Text = "<";
            btnPrevPage.UseVisualStyleBackColor = false;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.BackColor = Color.FromArgb(167, 204, 237);
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextPage.Location = new Point(470, 995);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(59, 61);
            btnNextPage.TabIndex = 81;
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
            pbSearch.Location = new Point(464, 430);
            pbSearch.Margin = new Padding(4, 4, 4, 5);
            pbSearch.Name = "pbSearch";
            pbSearch.Size = new Size(65, 65);
            pbSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSearch.TabIndex = 83;
            pbSearch.TabStop = false;
            pbSearch.Click += pbSearch_Click;
            // 
            // SellVehiclePage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1549, 1076);
            Controls.Add(pbSearch);
            Controls.Add(labelPageNum);
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Controls.Add(btnConfirmPaymentMethod);
            Controls.Add(btnConfirmSellingPrice);
            Controls.Add(rbDebitCard);
            Controls.Add(rbCreditCard);
            Controls.Add(rbCash);
            Controls.Add(rbBankTransfer);
            Controls.Add(labelChoosePaymentMethod);
            Controls.Add(labelFinalPrice);
            Controls.Add(labelSellingPricePrinter);
            Controls.Add(gbCustomerInformation);
            Controls.Add(SearchLabel);
            Controls.Add(ResultLabel);
            Controls.Add(tbSearchBar);
            Controls.Add(lbCustomersList);
            Controls.Add(labelSearch);
            Controls.Add(labelResults);
            Controls.Add(nmNewPrice);
            Controls.Add(labelDefaultVehiclePrice);
            Controls.Add(labelSellingPrice);
            Controls.Add(rbOtherPrice);
            Controls.Add(rbDefaultPrice);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(1575, 1147);
            MinimumSize = new Size(1575, 1147);
            Name = "SellVehiclePage";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sell Vehicle";
            //Load += SellVehiclePage_Load;
            ((System.ComponentModel.ISupportInitialize)nmNewPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLoyalClientBadge).EndInit();
            gbCustomerInformation.ResumeLayout(false);
            gbCustomerInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rbDefaultPrice;
        private RadioButton rbOtherPrice;
        private Label labelSellingPrice;
        private Label labelDefaultVehiclePrice;
        private NumericUpDown nmNewPrice;
        private Label labelSearch;
        private Label labelResults;
        private ListBox lbCustomersList;
        private TextBox tbSearchBar;
        private Label ResultLabel;
        private Label SearchLabel;
        private Label labelCustomerPhoneNumber;
        private Label labelPhoneNumber;
        private Label labelCustomerEmail;
        private Label labelEmail;
        private Label labelLastName;
        private Label labelCustomerFirstName;
        private Label labelFirstName;
        private Label labelPersonHeader;
        private Label labelCustomerLastName;
        private Button btnSellVehicle;
        private PictureBox pbLoyalClientBadge;
        private GroupBox gbCustomerInformation;
        private Label labelSellingPricePrinter;
        private Label labelFinalPrice;
        private Label labelChoosePaymentMethod;
        private RadioButton rbBankTransfer;
        private RadioButton rbCash;
        private RadioButton rbCreditCard;
        private RadioButton rbDebitCard;
        private Button btnConfirmSellingPrice;
        private Button btnConfirmPaymentMethod;
        private Label labelPageNum;
        private Button btnPrevPage;
        private Button btnNextPage;
        private PictureBox pbSearch;
    }
}