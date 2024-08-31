namespace FormApplication
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tbUsernameInput = new TextBox();
            tbPasswordInput = new TextBox();
            btnLogIn = new Button();
            Timer = new System.Windows.Forms.Timer(components);
            pbSeeImage = new PictureBox();
            labelMessage = new Label();
            linkToForgetPassword = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pbSeeImage).BeginInit();
            SuspendLayout();
            // 
            // tbUsernameInput
            // 
            tbUsernameInput.BackColor = SystemColors.ScrollBar;
            tbUsernameInput.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbUsernameInput.Location = new Point(126, 477);
            tbUsernameInput.Name = "tbUsernameInput";
            tbUsernameInput.Size = new Size(464, 57);
            tbUsernameInput.TabIndex = 2;
            tbUsernameInput.TextAlign = HorizontalAlignment.Center;
            // 
            // tbPasswordInput
            // 
            tbPasswordInput.BackColor = SystemColors.ScrollBar;
            tbPasswordInput.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPasswordInput.Location = new Point(126, 640);
            tbPasswordInput.Name = "tbPasswordInput";
            tbPasswordInput.PasswordChar = '*';
            tbPasswordInput.Size = new Size(464, 57);
            tbPasswordInput.TabIndex = 3;
            tbPasswordInput.TextAlign = HorizontalAlignment.Center;
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.FromArgb(125, 100, 231);
            btnLogIn.FlatAppearance.BorderColor = Color.FromArgb(125, 100, 231);
            btnLogIn.FlatAppearance.BorderSize = 5;
            btnLogIn.FlatAppearance.MouseDownBackColor = Color.FromArgb(125, 100, 231);
            btnLogIn.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 40, 171);
            btnLogIn.FlatStyle = FlatStyle.Flat;
            btnLogIn.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogIn.ForeColor = SystemColors.ActiveCaptionText;
            btnLogIn.Location = new Point(245, 779);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(215, 88);
            btnLogIn.TabIndex = 4;
            btnLogIn.Text = "Log In";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // Timer
            // 
            Timer.Tick += Timer_Tick;
            // 
            // pbSeeImage
            // 
            pbSeeImage.BackColor = SystemColors.ScrollBar;
            pbSeeImage.Image = (Image)resources.GetObject("pbSeeImage.Image");
            pbSeeImage.Location = new Point(540, 647);
            pbSeeImage.Name = "pbSeeImage";
            pbSeeImage.Size = new Size(50, 50);
            pbSeeImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSeeImage.TabIndex = 5;
            pbSeeImage.TabStop = false;
            pbSeeImage.Click += pbSeeImage_Click;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.BackColor = Color.Transparent;
            labelMessage.ForeColor = Color.Red;
            labelMessage.Location = new Point(126, 355);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(0, 32);
            labelMessage.TabIndex = 6;
            //labelMessage.Click += label1_Click;
            // 
            // linkToForgetPassword
            // 
            linkToForgetPassword.ActiveLinkColor = Color.Purple;
            linkToForgetPassword.AutoSize = true;
            linkToForgetPassword.BackColor = Color.Transparent;
            linkToForgetPassword.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkToForgetPassword.LinkColor = Color.CadetBlue;
            linkToForgetPassword.Location = new Point(117, 711);
            linkToForgetPassword.Name = "linkToForgetPassword";
            linkToForgetPassword.Size = new Size(226, 37);
            linkToForgetPassword.TabIndex = 7;
            linkToForgetPassword.TabStop = true;
            linkToForgetPassword.Text = "Forgot Password?";
            linkToForgetPassword.LinkClicked += linkToForgetPassword_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(724, 879);
            Controls.Add(linkToForgetPassword);
            Controls.Add(labelMessage);
            Controls.Add(pbSeeImage);
            Controls.Add(btnLogIn);
            Controls.Add(tbPasswordInput);
            Controls.Add(tbUsernameInput);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(750, 950);
            MinimizeBox = false;
            MinimumSize = new Size(750, 950);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogIn ";
            ((System.ComponentModel.ISupportInitialize)pbSeeImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbUsernameInput;
        private TextBox tbPasswordInput;
        private Button btnLogIn;
        private System.Windows.Forms.Timer Timer;
        private PictureBox pbSeeImage;
        private Label labelMessage;
        private LinkLabel linkToForgetPassword;
    }
}
