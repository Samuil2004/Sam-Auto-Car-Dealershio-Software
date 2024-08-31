namespace FormApplication
{
    partial class AlertPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertPage));
            labelMessage = new Label();
            btnAgree = new Button();
            btnCancle = new Button();
            SuspendLayout();
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.BackColor = Color.Transparent;
            labelMessage.ForeColor = Color.White;
            labelMessage.Location = new Point(146, 102);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(115, 96);
            labelMessage.TabIndex = 0;
            labelMessage.Text = "Message \r\n\r\nHere";
            // 
            // btnAgree
            // 
            btnAgree.BackColor = Color.FromArgb(4, 232, 36);
            btnAgree.DialogResult = DialogResult.Yes;
            btnAgree.FlatStyle = FlatStyle.Flat;
            btnAgree.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgree.Location = new Point(182, 283);
            btnAgree.Name = "btnAgree";
            btnAgree.Size = new Size(184, 63);
            btnAgree.TabIndex = 4;
            btnAgree.Text = "Yes";
            btnAgree.UseVisualStyleBackColor = false;
            btnAgree.Click += btnAgree_Click;
            // 
            // btnCancle
            // 
            btnCancle.BackColor = Color.FromArgb(255, 128, 128);
            btnCancle.DialogResult = DialogResult.Cancel;
            btnCancle.FlatStyle = FlatStyle.Flat;
            btnCancle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancle.Location = new Point(394, 283);
            btnCancle.Name = "btnCancle";
            btnCancle.Size = new Size(184, 63);
            btnCancle.TabIndex = 5;
            btnCancle.Text = "Cancel";
            btnCancle.UseVisualStyleBackColor = false;
            btnCancle.Click += btnCancle_Click;
            // 
            // AlertPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(748, 358);
            Controls.Add(btnCancle);
            Controls.Add(btnAgree);
            Controls.Add(labelMessage);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(774, 429);
            MinimizeBox = false;
            MinimumSize = new Size(774, 429);
            Name = "AlertPage";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Alert";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMessage;
        private Button btnAgree;
        private Button btnCancle;
    }
}