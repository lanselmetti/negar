namespace Test_Project
{
    partial class Form1
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
            this.btnSaPass = new System.Windows.Forms.Button();
            this.txtSaPass = new System.Windows.Forms.TextBox();
            this.lstLicenseList = new System.Windows.Forms.ListBox();
            this.btnLicenseList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaPass
            // 
            this.btnSaPass.Location = new System.Drawing.Point(169, 13);
            this.btnSaPass.Name = "btnSaPass";
            this.btnSaPass.Size = new System.Drawing.Size(103, 23);
            this.btnSaPass.TabIndex = 0;
            this.btnSaPass.Text = "دریافت كلمه عبور";
            this.btnSaPass.UseVisualStyleBackColor = true;
            this.btnSaPass.Click += new System.EventHandler(this.btnSaPass_Click);
            // 
            // txtSaPass
            // 
            this.txtSaPass.Location = new System.Drawing.Point(12, 14);
            this.txtSaPass.Name = "txtSaPass";
            this.txtSaPass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSaPass.Size = new System.Drawing.Size(151, 21);
            this.txtSaPass.TabIndex = 1;
            // 
            // lstLicenseList
            // 
            this.lstLicenseList.FormattingEnabled = true;
            this.lstLicenseList.Location = new System.Drawing.Point(12, 41);
            this.lstLicenseList.Name = "lstLicenseList";
            this.lstLicenseList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstLicenseList.Size = new System.Drawing.Size(151, 199);
            this.lstLicenseList.TabIndex = 2;
            // 
            // btnLicenseList
            // 
            this.btnLicenseList.Location = new System.Drawing.Point(169, 42);
            this.btnLicenseList.Name = "btnLicenseList";
            this.btnLicenseList.Size = new System.Drawing.Size(103, 39);
            this.btnLicenseList.TabIndex = 3;
            this.btnLicenseList.Text = "دریافت لیست لایسنس ها";
            this.btnLicenseList.UseVisualStyleBackColor = true;
            this.btnLicenseList.Click += new System.EventHandler(this.btnLicenseList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 249);
            this.Controls.Add(this.btnLicenseList);
            this.Controls.Add(this.lstLicenseList);
            this.Controls.Add(this.txtSaPass);
            this.Controls.Add(this.btnSaPass);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم تست قفل سخت افزاری";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaPass;
        private System.Windows.Forms.TextBox txtSaPass;
        private System.Windows.Forms.ListBox lstLicenseList;
        private System.Windows.Forms.Button btnLicenseList;
    }
}

