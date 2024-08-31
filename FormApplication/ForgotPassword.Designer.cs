namespace FormApplication
{
    partial class ForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPassword));
            labelUsername = new Label();
            labelSecretQuestion = new Label();
            labelAnswer = new Label();
            labelNewPassword = new Label();
            tbUsernameInput = new TextBox();
            tbPasswordInput = new TextBox();
            pbSeeImage = new PictureBox();
            cbSecretQuestion = new ComboBox();
            tbSQAnswer = new TextBox();
            btnConfirm = new Button();
            btnUpdate = new Button();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbSeeImage).BeginInit();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.BackColor = Color.Transparent;
            labelUsername.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUsername.ForeColor = SystemColors.ButtonHighlight;
            labelUsername.Location = new Point(38, 170);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(224, 59);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Username:";
            // 
            // labelSecretQuestion
            // 
            labelSecretQuestion.AutoSize = true;
            labelSecretQuestion.BackColor = Color.Transparent;
            labelSecretQuestion.Font = new Font("Segoe UI", 16.125F);
            labelSecretQuestion.ForeColor = SystemColors.ButtonHighlight;
            labelSecretQuestion.Location = new Point(38, 298);
            labelSecretQuestion.Name = "labelSecretQuestion";
            labelSecretQuestion.Size = new Size(333, 59);
            labelSecretQuestion.TabIndex = 1;
            labelSecretQuestion.Text = "Secret Question:";
            // 
            // labelAnswer
            // 
            labelAnswer.AutoSize = true;
            labelAnswer.BackColor = Color.Transparent;
            labelAnswer.Font = new Font("Segoe UI", 16.125F);
            labelAnswer.ForeColor = SystemColors.ButtonHighlight;
            labelAnswer.Location = new Point(38, 371);
            labelAnswer.Name = "labelAnswer";
            labelAnswer.Size = new Size(172, 59);
            labelAnswer.TabIndex = 2;
            labelAnswer.Text = "Answer:";
            // 
            // labelNewPassword
            // 
            labelNewPassword.AutoSize = true;
            labelNewPassword.BackColor = Color.Transparent;
            labelNewPassword.Font = new Font("Segoe UI", 16.125F);
            labelNewPassword.ForeColor = SystemColors.ButtonHighlight;
            labelNewPassword.Location = new Point(38, 233);
            labelNewPassword.Name = "labelNewPassword";
            labelNewPassword.Size = new Size(308, 59);
            labelNewPassword.TabIndex = 3;
            labelNewPassword.Text = "New Password:";
            // 
            // tbUsernameInput
            // 
            tbUsernameInput.BackColor = SystemColors.ScrollBar;
            tbUsernameInput.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbUsernameInput.Location = new Point(377, 174);
            tbUsernameInput.Name = "tbUsernameInput";
            tbUsernameInput.ReadOnly = true;
            tbUsernameInput.Size = new Size(620, 57);
            tbUsernameInput.TabIndex = 4;
            tbUsernameInput.TextAlign = HorizontalAlignment.Center;
            // 
            // tbPasswordInput
            // 
            tbPasswordInput.BackColor = SystemColors.ScrollBar;
            tbPasswordInput.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPasswordInput.Location = new Point(377, 237);
            tbPasswordInput.MaxLength = 14;
            tbPasswordInput.Name = "tbPasswordInput";
            tbPasswordInput.PasswordChar = '*';
            tbPasswordInput.Size = new Size(464, 57);
            tbPasswordInput.TabIndex = 5;
            tbPasswordInput.TextAlign = HorizontalAlignment.Center;
            // 
            // pbSeeImage
            // 
            pbSeeImage.BackColor = SystemColors.ScrollBar;
            pbSeeImage.Image = (Image)resources.GetObject("pbSeeImage.Image");
            pbSeeImage.Location = new Point(847, 242);
            pbSeeImage.Name = "pbSeeImage";
            pbSeeImage.Size = new Size(50, 50);
            pbSeeImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSeeImage.TabIndex = 6;
            pbSeeImage.TabStop = false;
            pbSeeImage.Click += pbSeeImage_Click;
            // 
            // cbSecretQuestion
            // 
            cbSecretQuestion.BackColor = SystemColors.ScrollBar;
            cbSecretQuestion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSecretQuestion.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbSecretQuestion.FormattingEnabled = true;
            cbSecretQuestion.Location = new Point(377, 298);
            cbSecretQuestion.Name = "cbSecretQuestion";
            cbSecretQuestion.Size = new Size(620, 58);
            cbSecretQuestion.TabIndex = 7;
            // 
            // tbSQAnswer
            // 
            tbSQAnswer.BackColor = SystemColors.ScrollBar;
            tbSQAnswer.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSQAnswer.Location = new Point(377, 373);
            tbSQAnswer.Name = "tbSQAnswer";
            tbSQAnswer.Size = new Size(620, 57);
            tbSQAnswer.TabIndex = 8;
            tbSQAnswer.TextAlign = HorizontalAlignment.Center;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.PaleGreen;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Location = new Point(377, 486);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(179, 70);
            btnConfirm.TabIndex = 9;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.CadetBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(813, 486);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(179, 70);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1004, 598);
            Controls.Add(btnUpdate);
            Controls.Add(btnConfirm);
            Controls.Add(tbSQAnswer);
            Controls.Add(cbSecretQuestion);
            Controls.Add(pbSeeImage);
            Controls.Add(tbPasswordInput);
            Controls.Add(tbUsernameInput);
            Controls.Add(labelNewPassword);
            Controls.Add(labelAnswer);
            Controls.Add(labelSecretQuestion);
            Controls.Add(labelUsername);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(1030, 669);
            MinimumSize = new Size(1030, 669);
            Name = "ForgotPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Forgot Password";
            FormClosing += AnyForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pbSeeImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUsername;
        private Label labelSecretQuestion;
        private Label labelAnswer;
        private Label labelNewPassword;
        private TextBox tbUsernameInput;
        private TextBox tbPasswordInput;
        private PictureBox pbSeeImage;
        private ComboBox cbSecretQuestion;
        private TextBox tbSQAnswer;
        private Button btnConfirm;
        private Button btnUpdate;
        private System.Windows.Forms.Timer timer;
    }
}