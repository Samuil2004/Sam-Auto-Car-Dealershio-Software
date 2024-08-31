namespace FormApplication
{
    partial class AddEmployePage
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmployePage));
            pbSeeImage = new PictureBox();
            btnSave = new Button();
            tbCPassword = new TextBox();
            label1 = new Label();
            tbPassword = new TextBox();
            labelPassword = new Label();
            tbAnswer = new TextBox();
            labelAnswerSQ = new Label();
            cbSecretQuestion = new ComboBox();
            labelSecretQuestion = new Label();
            tbPhoneNumber = new TextBox();
            tbEmail = new TextBox();
            tbLName = new TextBox();
            tbFName = new TextBox();
            labelPhoneNumber = new Label();
            labelEmail = new Label();
            labelLastName = new Label();
            labelFirstName = new Label();
            labelStartingDate = new Label();
            startingDate = new DateTimePicker();
            timer = new System.Windows.Forms.Timer(components);
            cbAddManager = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pbSeeImage).BeginInit();
            SuspendLayout();
            // 
            // pbSeeImage
            // 
            pbSeeImage.BackColor = Color.White;
            pbSeeImage.Image = (Image)resources.GetObject("pbSeeImage.Image");
            pbSeeImage.Location = new Point(1436, 341);
            pbSeeImage.Name = "pbSeeImage";
            pbSeeImage.Size = new Size(50, 50);
            pbSeeImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSeeImage.TabIndex = 35;
            pbSeeImage.TabStop = false;
            pbSeeImage.Click += pbSeeImage_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LightGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(1297, 547);
            btnSave.Margin = new Padding(5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(190, 78);
            btnSave.TabIndex = 34;
            btnSave.Text = "Add";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // tbCPassword
            // 
            tbCPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbCPassword.Location = new Point(1133, 435);
            tbCPassword.Margin = new Padding(5);
            tbCPassword.Name = "tbCPassword";
            tbCPassword.PasswordChar = '*';
            tbCPassword.Size = new Size(352, 50);
            tbCPassword.TabIndex = 33;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(795, 435);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(327, 50);
            label1.TabIndex = 32;
            label1.Text = "Confirm Password:";
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPassword.Location = new Point(1133, 339);
            tbPassword.Margin = new Padding(5);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(352, 50);
            tbPassword.TabIndex = 31;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.BackColor = Color.Transparent;
            labelPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPassword.ForeColor = SystemColors.ButtonHighlight;
            labelPassword.Location = new Point(936, 341);
            labelPassword.Margin = new Padding(5, 0, 5, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(185, 50);
            labelPassword.TabIndex = 30;
            labelPassword.Text = "Password:";
            // 
            // tbAnswer
            // 
            tbAnswer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbAnswer.Location = new Point(323, 438);
            tbAnswer.Margin = new Padding(5);
            tbAnswer.Name = "tbAnswer";
            tbAnswer.Size = new Size(352, 50);
            tbAnswer.TabIndex = 29;
            // 
            // labelAnswerSQ
            // 
            labelAnswerSQ.AutoSize = true;
            labelAnswerSQ.BackColor = Color.Transparent;
            labelAnswerSQ.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAnswerSQ.ForeColor = SystemColors.ButtonHighlight;
            labelAnswerSQ.Location = new Point(161, 440);
            labelAnswerSQ.Margin = new Padding(5, 0, 5, 0);
            labelAnswerSQ.Name = "labelAnswerSQ";
            labelAnswerSQ.Size = new Size(150, 50);
            labelAnswerSQ.TabIndex = 28;
            labelAnswerSQ.Text = "Answer:";
            // 
            // cbSecretQuestion
            // 
            cbSecretQuestion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSecretQuestion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbSecretQuestion.FormattingEnabled = true;
            cbSecretQuestion.ItemHeight = 32;
            cbSecretQuestion.Location = new Point(323, 350);
            cbSecretQuestion.Margin = new Padding(5);
            cbSecretQuestion.Name = "cbSecretQuestion";
            cbSecretQuestion.Size = new Size(530, 40);
            cbSecretQuestion.TabIndex = 27;
            // 
            // labelSecretQuestion
            // 
            labelSecretQuestion.AutoSize = true;
            labelSecretQuestion.BackColor = Color.Transparent;
            labelSecretQuestion.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSecretQuestion.ForeColor = SystemColors.ButtonHighlight;
            labelSecretQuestion.Location = new Point(26, 346);
            labelSecretQuestion.Margin = new Padding(5, 0, 5, 0);
            labelSecretQuestion.Name = "labelSecretQuestion";
            labelSecretQuestion.Size = new Size(284, 50);
            labelSecretQuestion.TabIndex = 26;
            labelSecretQuestion.Text = "Secret question:";
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPhoneNumber.Location = new Point(1133, 253);
            tbPhoneNumber.Margin = new Padding(5);
            tbPhoneNumber.MaxLength = 15;
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(352, 50);
            tbPhoneNumber.TabIndex = 25;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbEmail.Location = new Point(1133, 162);
            tbEmail.Margin = new Padding(5);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(352, 50);
            tbEmail.TabIndex = 24;
            // 
            // tbLName
            // 
            tbLName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbLName.Location = new Point(323, 253);
            tbLName.Margin = new Padding(5);
            tbLName.Name = "tbLName";
            tbLName.Size = new Size(360, 50);
            tbLName.TabIndex = 23;
            // 
            // tbFName
            // 
            tbFName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbFName.Location = new Point(323, 163);
            tbFName.Margin = new Padding(5);
            tbFName.Name = "tbFName";
            tbFName.Size = new Size(360, 50);
            tbFName.TabIndex = 22;
            // 
            // labelPhoneNumber
            // 
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.BackColor = Color.Transparent;
            labelPhoneNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPhoneNumber.ForeColor = SystemColors.ButtonHighlight;
            labelPhoneNumber.Location = new Point(848, 254);
            labelPhoneNumber.Margin = new Padding(5, 0, 5, 0);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new Size(272, 50);
            labelPhoneNumber.TabIndex = 21;
            labelPhoneNumber.Text = "Phone number:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.BackColor = Color.Transparent;
            labelEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEmail.ForeColor = SystemColors.ButtonHighlight;
            labelEmail.Location = new Point(1001, 163);
            labelEmail.Margin = new Padding(5, 0, 5, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(118, 50);
            labelEmail.TabIndex = 20;
            labelEmail.Text = "Email:";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.BackColor = Color.Transparent;
            labelLastName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLastName.ForeColor = SystemColors.ButtonHighlight;
            labelLastName.Location = new Point(114, 258);
            labelLastName.Margin = new Padding(5, 0, 5, 0);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(196, 50);
            labelLastName.TabIndex = 19;
            labelLastName.Text = "Last name:";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.BackColor = Color.Transparent;
            labelFirstName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFirstName.ForeColor = SystemColors.ButtonHighlight;
            labelFirstName.Location = new Point(110, 162);
            labelFirstName.Margin = new Padding(5, 0, 5, 0);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(200, 50);
            labelFirstName.TabIndex = 18;
            labelFirstName.Text = "First name:";
            // 
            // labelStartingDate
            // 
            labelStartingDate.AutoSize = true;
            labelStartingDate.BackColor = Color.Transparent;
            labelStartingDate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStartingDate.ForeColor = SystemColors.ButtonHighlight;
            labelStartingDate.Location = new Point(65, 531);
            labelStartingDate.Margin = new Padding(5, 0, 5, 0);
            labelStartingDate.Name = "labelStartingDate";
            labelStartingDate.Size = new Size(246, 50);
            labelStartingDate.TabIndex = 36;
            labelStartingDate.Text = "Starting Date:";
            // 
            // startingDate
            // 
            startingDate.CalendarFont = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startingDate.Location = new Point(323, 538);
            startingDate.Margin = new Padding(5);
            startingDate.Name = "startingDate";
            startingDate.Size = new Size(404, 39);
            startingDate.TabIndex = 37;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // cbAddManager
            // 
            cbAddManager.AutoSize = true;
            cbAddManager.BackColor = Color.Transparent;
            cbAddManager.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbAddManager.ForeColor = Color.White;
            cbAddManager.Location = new Point(795, 538);
            cbAddManager.Name = "cbAddManager";
            cbAddManager.Size = new Size(224, 44);
            cbAddManager.TabIndex = 38;
            cbAddManager.Text = "Add Manager";
            cbAddManager.UseVisualStyleBackColor = false;
            // 
            // AddEmployePage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1518, 629);
            Controls.Add(cbAddManager);
            Controls.Add(startingDate);
            Controls.Add(labelStartingDate);
            Controls.Add(pbSeeImage);
            Controls.Add(btnSave);
            Controls.Add(tbCPassword);
            Controls.Add(label1);
            Controls.Add(tbPassword);
            Controls.Add(labelPassword);
            Controls.Add(tbAnswer);
            Controls.Add(labelAnswerSQ);
            Controls.Add(cbSecretQuestion);
            Controls.Add(labelSecretQuestion);
            Controls.Add(tbPhoneNumber);
            Controls.Add(tbEmail);
            Controls.Add(tbLName);
            Controls.Add(tbFName);
            Controls.Add(labelPhoneNumber);
            Controls.Add(labelEmail);
            Controls.Add(labelLastName);
            Controls.Add(labelFirstName);
            DoubleBuffered = true;
            Margin = new Padding(5);
            MaximizeBox = false;
            MaximumSize = new Size(1544, 700);
            MinimumSize = new Size(1544, 700);
            Name = "AddEmployePage";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Employe";
            FormClosing += AnyForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pbSeeImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbSeeImage;
        private Button btnSave;
        private TextBox tbCPassword;
        private Label label1;
        private TextBox tbPassword;
        private Label labelPassword;
        private TextBox tbAnswer;
        private Label labelAnswerSQ;
        private ComboBox cbSecretQuestion;
        private Label labelSecretQuestion;
        private TextBox tbPhoneNumber;
        private TextBox tbEmail;
        private TextBox tbLName;
        private TextBox tbFName;
        private Label labelPhoneNumber;
        private Label labelEmail;
        private Label labelLastName;
        private Label labelFirstName;
        private Label labelStartingDate;
        private DateTimePicker startingDate;
        private System.Windows.Forms.Timer timer;
        private CheckBox cbAddManager;
    }
}