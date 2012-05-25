namespace app5
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbLastName = new System.Windows.Forms.CheckBox();
            this.chbPhone = new System.Windows.Forms.CheckBox();
            this.chbAddress = new System.Windows.Forms.CheckBox();
            this.chbFirstName = new System.Windows.Forms.CheckBox();
            this.chbCode = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.chbLastName);
            this.groupBox1.Controls.Add(this.chbPhone);
            this.groupBox1.Controls.Add(this.chbAddress);
            this.groupBox1.Controls.Add(this.chbFirstName);
            this.groupBox1.Controls.Add(this.chbCode);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 249);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Table";
            // 
            // chbLastName
            // 
            this.chbLastName.AutoSize = true;
            this.chbLastName.Checked = true;
            this.chbLastName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbLastName.Location = new System.Drawing.Point(18, 75);
            this.chbLastName.Name = "chbLastName";
            this.chbLastName.Size = new System.Drawing.Size(77, 17);
            this.chbLastName.TabIndex = 6;
            this.chbLastName.Text = "Last Name";
            this.chbLastName.UseVisualStyleBackColor = true;
            // 
            // chbPhone
            // 
            this.chbPhone.AutoSize = true;
            this.chbPhone.Checked = true;
            this.chbPhone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPhone.Location = new System.Drawing.Point(18, 121);
            this.chbPhone.Name = "chbPhone";
            this.chbPhone.Size = new System.Drawing.Size(57, 17);
            this.chbPhone.TabIndex = 4;
            this.chbPhone.Text = "Phone";
            this.chbPhone.UseVisualStyleBackColor = true;
            // 
            // chbAddress
            // 
            this.chbAddress.AutoSize = true;
            this.chbAddress.Checked = true;
            this.chbAddress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAddress.Location = new System.Drawing.Point(18, 98);
            this.chbAddress.Name = "chbAddress";
            this.chbAddress.Size = new System.Drawing.Size(64, 17);
            this.chbAddress.TabIndex = 3;
            this.chbAddress.Text = "Address";
            this.chbAddress.UseVisualStyleBackColor = true;
            // 
            // chbFirstName
            // 
            this.chbFirstName.AutoSize = true;
            this.chbFirstName.Checked = true;
            this.chbFirstName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbFirstName.Location = new System.Drawing.Point(18, 52);
            this.chbFirstName.Name = "chbFirstName";
            this.chbFirstName.Size = new System.Drawing.Size(76, 17);
            this.chbFirstName.TabIndex = 2;
            this.chbFirstName.Text = "First Name";
            this.chbFirstName.UseVisualStyleBackColor = true;
            // 
            // chbCode
            // 
            this.chbCode.AutoSize = true;
            this.chbCode.Checked = true;
            this.chbCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCode.Location = new System.Drawing.Point(18, 29);
            this.chbCode.Name = "chbCode";
            this.chbCode.Size = new System.Drawing.Size(98, 17);
            this.chbCode.TabIndex = 1;
            this.chbCode.Text = "Customer Code";
            this.chbCode.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "View Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(157, 12);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(366, 410);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(58, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 434);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chbPhone;
        private System.Windows.Forms.CheckBox chbAddress;
        private System.Windows.Forms.CheckBox chbFirstName;
        private System.Windows.Forms.CheckBox chbCode;
        private System.Windows.Forms.CheckBox chbLastName;
        private System.Windows.Forms.Button button2;
    }
}

