namespace FormApplication
{
    partial class MyProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyProfile));
            labelFirstName = new Label();
            labelLastName = new Label();
            labelEmail = new Label();
            labelPhoneNumber = new Label();
            tbFName = new TextBox();
            tbLName = new TextBox();
            tbEmail = new TextBox();
            tbPhoneNumber = new TextBox();
            labelSecretQuestion = new Label();
            cbSecretQuestion = new ComboBox();
            labelAnswerSQ = new Label();
            tbAnswer = new TextBox();
            labelPassword = new Label();
            tbPassword = new TextBox();
            label1 = new Label();
            tbCPassword = new TextBox();
            btnSave = new Button();
            pbSeeImage = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbSeeImage).BeginInit();
            SuspendLayout();
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.BackColor = Color.Transparent;
            labelFirstName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFirstName.ForeColor = SystemColors.ButtonHighlight;
            labelFirstName.Location = new Point(117, 157);
            labelFirstName.Margin = new Padding(5, 0, 5, 0);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(200, 50);
            labelFirstName.TabIndex = 0;
            labelFirstName.Text = "First name:";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.BackColor = Color.Transparent;
            labelLastName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLastName.ForeColor = SystemColors.ButtonHighlight;
            labelLastName.Location = new Point(120, 253);
            labelLastName.Margin = new Padding(5, 0, 5, 0);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(196, 50);
            labelLastName.TabIndex = 1;
            labelLastName.Text = "Last name:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.BackColor = Color.Transparent;
            labelEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEmail.ForeColor = SystemColors.ButtonHighlight;
            labelEmail.Location = new Point(1008, 158);
            labelEmail.Margin = new Padding(5, 0, 5, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(118, 50);
            labelEmail.TabIndex = 2;
            labelEmail.Text = "Email:";
            // 
            // labelPhoneNumber
            // 
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.BackColor = Color.Transparent;
            labelPhoneNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPhoneNumber.ForeColor = SystemColors.ButtonHighlight;
            labelPhoneNumber.Location = new Point(855, 250);
            labelPhoneNumber.Margin = new Padding(5, 0, 5, 0);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new Size(272, 50);
            labelPhoneNumber.TabIndex = 3;
            labelPhoneNumber.Text = "Phone number:";
            // 
            // tbFName
            // 
            tbFName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbFName.Location = new Point(330, 158);
            tbFName.Margin = new Padding(5);
            tbFName.Name = "tbFName";
            tbFName.ReadOnly = true;
            tbFName.Size = new Size(360, 50);
            tbFName.TabIndex = 4;
            // 
            // tbLName
            // 
            tbLName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbLName.Location = new Point(330, 248);
            tbLName.Margin = new Padding(5);
            tbLName.Name = "tbLName";
            tbLName.ReadOnly = true;
            tbLName.Size = new Size(360, 50);
            tbLName.TabIndex = 5;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbEmail.Location = new Point(1139, 157);
            tbEmail.Margin = new Padding(5);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(352, 50);
            tbEmail.TabIndex = 6;
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPhoneNumber.Location = new Point(1139, 248);
            tbPhoneNumber.Margin = new Padding(5);
            tbPhoneNumber.MaxLength = 15;
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(352, 50);
            tbPhoneNumber.TabIndex = 7;
            // 
            // labelSecretQuestion
            // 
            labelSecretQuestion.AutoSize = true;
            labelSecretQuestion.BackColor = Color.Transparent;
            labelSecretQuestion.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSecretQuestion.ForeColor = SystemColors.ButtonHighlight;
            labelSecretQuestion.Location = new Point(32, 341);
            labelSecretQuestion.Margin = new Padding(5, 0, 5, 0);
            labelSecretQuestion.Name = "labelSecretQuestion";
            labelSecretQuestion.Size = new Size(284, 50);
            labelSecretQuestion.TabIndex = 8;
            labelSecretQuestion.Text = "Secret question:";
            // 
            // cbSecretQuestion
            // 
            cbSecretQuestion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSecretQuestion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbSecretQuestion.FormattingEnabled = true;
            cbSecretQuestion.ItemHeight = 32;
            cbSecretQuestion.Location = new Point(330, 346);
            cbSecretQuestion.Margin = new Padding(5);
            cbSecretQuestion.Name = "cbSecretQuestion";
            cbSecretQuestion.Size = new Size(530, 40);
            cbSecretQuestion.TabIndex = 9;
            // 
            // labelAnswerSQ
            // 
            labelAnswerSQ.AutoSize = true;
            labelAnswerSQ.BackColor = Color.Transparent;
            labelAnswerSQ.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAnswerSQ.ForeColor = SystemColors.ButtonHighlight;
            labelAnswerSQ.Location = new Point(167, 435);
            labelAnswerSQ.Margin = new Padding(5, 0, 5, 0);
            labelAnswerSQ.Name = "labelAnswerSQ";
            labelAnswerSQ.Size = new Size(150, 50);
            labelAnswerSQ.TabIndex = 10;
            labelAnswerSQ.Text = "Answer:";
            // 
            // tbAnswer
            // 
            tbAnswer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbAnswer.Location = new Point(330, 434);
            tbAnswer.Margin = new Padding(5);
            tbAnswer.Name = "tbAnswer";
            tbAnswer.Size = new Size(352, 50);
            tbAnswer.TabIndex = 11;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.BackColor = Color.Transparent;
            labelPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPassword.ForeColor = SystemColors.ButtonHighlight;
            labelPassword.Location = new Point(942, 336);
            labelPassword.Margin = new Padding(5, 0, 5, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(185, 50);
            labelPassword.TabIndex = 12;
            labelPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPassword.Location = new Point(1139, 334);
            tbPassword.Margin = new Padding(5);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(352, 50);
            tbPassword.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(801, 430);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(327, 50);
            label1.TabIndex = 14;
            label1.Text = "Confirm Password:";
            // 
            // tbCPassword
            // 
            tbCPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbCPassword.Location = new Point(1139, 430);
            tbCPassword.Margin = new Padding(5);
            tbCPassword.Name = "tbCPassword";
            tbCPassword.PasswordChar = '*';
            tbCPassword.Size = new Size(352, 50);
            tbCPassword.TabIndex = 15;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LightGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(1303, 526);
            btnSave.Margin = new Padding(5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(190, 78);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // pbSeeImage
            // 
            pbSeeImage.BackColor = Color.White;
            pbSeeImage.Image = (Image)resources.GetObject("pbSeeImage.Image");
            pbSeeImage.Location = new Point(1443, 336);
            pbSeeImage.Name = "pbSeeImage";
            pbSeeImage.Size = new Size(50, 50);
            pbSeeImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSeeImage.TabIndex = 17;
            pbSeeImage.TabStop = false;
            pbSeeImage.Click += pbSeeImage_Click;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // MyProfile
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1518, 606);
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
            MaximumSize = new Size(1544, 677);
            MinimumSize = new Size(1544, 677);
            Name = "MyProfile";
            StartPosition = FormStartPosition.CenterParent;
            Text = "My Profile";
            FormClosing += AnyForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pbSeeImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelFirstName;
        private Label labelLastName;
        private Label labelEmail;
        private Label labelPhoneNumber;
        private TextBox tbFName;
        private TextBox tbLName;
        private TextBox tbEmail;
        private TextBox tbPhoneNumber;
        private Label labelSecretQuestion;
        private ComboBox cbSecretQuestion;
        private Label labelAnswerSQ;
        private TextBox tbAnswer;
        private Label labelPassword;
        private TextBox tbPassword;
        private Label label1;
        private TextBox tbCPassword;
        private Button btnSave;
        private PictureBox pbSeeImage;
        private System.Windows.Forms.Timer timer;
    }
}