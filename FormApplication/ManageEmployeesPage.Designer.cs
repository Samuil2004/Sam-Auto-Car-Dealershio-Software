namespace FormApplication
{
    partial class ManageEmployeesPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageEmployeesPage));
            labelPageNum = new Label();
            btnPrevPage = new Button();
            btnNextPage = new Button();
            pbBackToMenu = new PictureBox();
            gbCustomerInformation = new GroupBox();
            btnDeleteEmployee = new Button();
            labelStartingDateEmployee = new Label();
            labelStartingDate = new Label();
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
            lbEmployeesList = new ListBox();
            btnAddNewEmployee = new Button();
            pbSearch = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbBackToMenu).BeginInit();
            gbCustomerInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
            SuspendLayout();
            // 
            // labelPageNum
            // 
            labelPageNum.AutoSize = true;
            labelPageNum.BackColor = Color.Transparent;
            labelPageNum.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPageNum.ForeColor = Color.White;
            labelPageNum.Location = new Point(446, 1070);
            labelPageNum.Name = "labelPageNum";
            labelPageNum.Size = new Size(65, 37);
            labelPageNum.TabIndex = 73;
            labelPageNum.Text = "1/10";
            // 
            // btnPrevPage
            // 
            btnPrevPage.BackColor = Color.FromArgb(167, 204, 237);
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrevPage.Location = new Point(376, 1059);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(58, 61);
            btnPrevPage.TabIndex = 71;
            btnPrevPage.Text = "<";
            btnPrevPage.UseVisualStyleBackColor = false;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.BackColor = Color.FromArgb(167, 204, 237);
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextPage.Location = new Point(518, 1059);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(58, 61);
            btnNextPage.TabIndex = 72;
            btnNextPage.Text = ">";
            btnNextPage.UseVisualStyleBackColor = false;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // pbBackToMenu
            // 
            pbBackToMenu.BackColor = Color.Transparent;
            pbBackToMenu.Image = (Image)resources.GetObject("pbBackToMenu.Image");
            pbBackToMenu.Location = new Point(15, 16);
            pbBackToMenu.Name = "pbBackToMenu";
            pbBackToMenu.Size = new Size(135, 134);
            pbBackToMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBackToMenu.TabIndex = 70;
            pbBackToMenu.TabStop = false;
            pbBackToMenu.Click += pbBackToMenu_Click;
            // 
            // gbCustomerInformation
            // 
            gbCustomerInformation.BackColor = Color.FromArgb(130, 160, 188);
            gbCustomerInformation.Controls.Add(btnDeleteEmployee);
            gbCustomerInformation.Controls.Add(labelStartingDateEmployee);
            gbCustomerInformation.Controls.Add(labelStartingDate);
            gbCustomerInformation.Controls.Add(labelCustomerLastName);
            gbCustomerInformation.Controls.Add(labelCustomerHeader);
            gbCustomerInformation.Controls.Add(labelFirstName);
            gbCustomerInformation.Controls.Add(labelCustomerFirstName);
            gbCustomerInformation.Controls.Add(labelLastName);
            gbCustomerInformation.Controls.Add(labelEmail);
            gbCustomerInformation.Controls.Add(labelCustomerEmail);
            gbCustomerInformation.Controls.Add(labelPhoneNumber);
            gbCustomerInformation.Controls.Add(labelCustomerPhoneNumber);
            gbCustomerInformation.Location = new Point(582, 146);
            gbCustomerInformation.Name = "gbCustomerInformation";
            gbCustomerInformation.Size = new Size(1251, 995);
            gbCustomerInformation.TabIndex = 69;
            gbCustomerInformation.TabStop = false;
            gbCustomerInformation.Text = "Employee Information";
            // 
            // btnDeleteEmployee
            // 
            btnDeleteEmployee.BackColor = Color.Black;
            btnDeleteEmployee.FlatStyle = FlatStyle.Flat;
            btnDeleteEmployee.ForeColor = Color.White;
            btnDeleteEmployee.Location = new Point(16, 907);
            btnDeleteEmployee.Name = "btnDeleteEmployee";
            btnDeleteEmployee.Size = new Size(266, 74);
            btnDeleteEmployee.TabIndex = 59;
            btnDeleteEmployee.Text = "Delete";
            btnDeleteEmployee.UseVisualStyleBackColor = false;
            btnDeleteEmployee.Click += btnDeleteEmployee_Click;
            // 
            // labelStartingDateEmployee
            // 
            labelStartingDateEmployee.AutoSize = true;
            labelStartingDateEmployee.BackColor = Color.Transparent;
            labelStartingDateEmployee.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelStartingDateEmployee.Location = new Point(205, 458);
            labelStartingDateEmployee.Name = "labelStartingDateEmployee";
            labelStartingDateEmployee.Size = new Size(226, 32);
            labelStartingDateEmployee.TabIndex = 32;
            labelStartingDateEmployee.Text = "Starting Date Here";
            // 
            // labelStartingDate
            // 
            labelStartingDate.AutoSize = true;
            labelStartingDate.BackColor = Color.Transparent;
            labelStartingDate.Location = new Point(16, 458);
            labelStartingDate.Name = "labelStartingDate";
            labelStartingDate.Size = new Size(158, 32);
            labelStartingDate.TabIndex = 31;
            labelStartingDate.Text = "Starting Date:";
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
            labelSearch.Location = new Point(34, 166);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(106, 37);
            labelSearch.TabIndex = 68;
            labelSearch.Text = "Search:";
            // 
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.BackColor = Color.Transparent;
            labelResults.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelResults.ForeColor = SystemColors.ButtonHighlight;
            labelResults.Location = new Point(34, 269);
            labelResults.Name = "labelResults";
            labelResults.Size = new Size(111, 37);
            labelResults.TabIndex = 67;
            labelResults.Text = "Results:";
            // 
            // tbSearchBar
            // 
            tbSearchBar.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearchBar.Location = new Point(34, 206);
            tbSearchBar.Name = "tbSearchBar";
            tbSearchBar.Size = new Size(470, 46);
            tbSearchBar.TabIndex = 66;
            //tbSearchBar.TextChanged += tbSearchBar_TextChanged;
            // 
            // lbEmployeesList
            // 
            lbEmployeesList.BackColor = Color.FromArgb(94, 94, 94);
            lbEmployeesList.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbEmployeesList.ForeColor = SystemColors.Info;
            lbEmployeesList.FormattingEnabled = true;
            lbEmployeesList.ItemHeight = 37;
            lbEmployeesList.Location = new Point(34, 309);
            lbEmployeesList.Name = "lbEmployeesList";
            lbEmployeesList.Size = new Size(542, 744);
            lbEmployeesList.TabIndex = 65;
            lbEmployeesList.SelectedIndexChanged += lbEmployeesList_SelectedIndexChanged;
            // 
            // btnAddNewEmployee
            // 
            btnAddNewEmployee.BackColor = Color.FromArgb(4, 232, 36);
            btnAddNewEmployee.FlatStyle = FlatStyle.Flat;
            btnAddNewEmployee.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddNewEmployee.Location = new Point(1566, 16);
            btnAddNewEmployee.Name = "btnAddNewEmployee";
            btnAddNewEmployee.Size = new Size(266, 74);
            btnAddNewEmployee.TabIndex = 74;
            btnAddNewEmployee.Text = "+Add Employee";
            btnAddNewEmployee.UseVisualStyleBackColor = false;
            btnAddNewEmployee.Click += btnAddNewEmployee_Click;
            // 
            // pbSearch
            // 
            pbSearch.BackColor = Color.FromArgb(94, 94, 94);
            pbSearch.ErrorImage = (Image)resources.GetObject("pbSearch.ErrorImage");
            pbSearch.Image = (Image)resources.GetObject("pbSearch.Image");
            pbSearch.InitialImage = (Image)resources.GetObject("pbSearch.InitialImage");
            pbSearch.Location = new Point(511, 187);
            pbSearch.Margin = new Padding(4, 4, 4, 5);
            pbSearch.Name = "pbSearch";
            pbSearch.Size = new Size(65, 65);
            pbSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSearch.TabIndex = 75;
            pbSearch.TabStop = false;
            pbSearch.Click += pbSearch_Click;
            // 
            // ManageEmployeesPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1849, 1217);
            Controls.Add(pbSearch);
            Controls.Add(btnAddNewEmployee);
            Controls.Add(labelPageNum);
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Controls.Add(pbBackToMenu);
            Controls.Add(gbCustomerInformation);
            Controls.Add(labelSearch);
            Controls.Add(labelResults);
            Controls.Add(tbSearchBar);
            Controls.Add(lbEmployeesList);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(1875, 1288);
            MinimumSize = new Size(1875, 1288);
            Name = "ManageEmployeesPage";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Employees";
            FormClosing += AnyForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pbBackToMenu).EndInit();
            gbCustomerInformation.ResumeLayout(false);
            gbCustomerInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPageNum;
        private Button btnPrevPage;
        private Button btnNextPage;
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
        private ListBox lbEmployeesList;
        private Label labelStartingDate;
        private Label labelStartingDateEmployee;
        private Button btnAddNewEmployee;
        private Button btnDeleteEmployee;
        private PictureBox pbSearch;
    }
}