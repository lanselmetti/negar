namespace Negar
{
    partial class frmReadfile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReadfile));
            this.lblUnitName = new DevComponents.DotNetBar.LabelX();
            this.txtPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.PpenFileDialogForm = new System.Windows.Forms.OpenFileDialog();
            this.btnReadData = new DevComponents.DotNetBar.ButtonX();
            this.btnSelectPath = new DevComponents.DotNetBar.ButtonX();
            this.DgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnSaveDataInDb = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUnitName
            // 
            this.lblUnitName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnitName.AutoSize = true;
            this.lblUnitName.BackColor = System.Drawing.Color.Transparent;
            this.lblUnitName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUnitName.Location = new System.Drawing.Point(711, 38);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(61, 16);
            this.lblUnitName.TabIndex = 3;
            this.lblUnitName.Text = "مسیر فایل:";
            this.lblUnitName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPath.Border.Class = "TextBoxBorder";
            this.txtPath.Location = new System.Drawing.Point(243, 36);
            this.txtPath.Name = "txtPath";
            this.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPath.Size = new System.Drawing.Size(462, 21);
            this.txtPath.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(784, 30);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "خواندن فایل خدمات ";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.Location = new System.Drawing.Point(114, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 60);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PpenFileDialogForm
            // 
            this.PpenFileDialogForm.FileName = "Services.xls";
            // 
            // btnReadData
            // 
            this.btnReadData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReadData.Location = new System.Drawing.Point(73, 36);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(79, 21);
            this.btnReadData.TabIndex = 2;
            this.btnReadData.TabStop = false;
            this.btnReadData.Text = "نمایش";
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectPath.Location = new System.Drawing.Point(158, 36);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(79, 21);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.TabStop = false;
            this.btnSelectPath.Text = "انتخاب...";
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // DgvData
            // 
            this.DgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvData.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.DgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DgvData.Location = new System.Drawing.Point(12, 63);
            this.DgvData.Name = "DgvData";
            this.DgvData.Size = new System.Drawing.Size(760, 426);
            this.DgvData.TabIndex = 4;
            // 
            // btnSaveDataInDb
            // 
            this.btnSaveDataInDb.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveDataInDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveDataInDb.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnSaveDataInDb.Location = new System.Drawing.Point(12, 495);
            this.btnSaveDataInDb.Name = "btnSaveDataInDb";
            this.btnSaveDataInDb.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSaveDataInDb.Size = new System.Drawing.Size(96, 57);
            this.btnSaveDataInDb.TabIndex = 6;
            this.btnSaveDataInDb.TabStop = false;
            this.btnSaveDataInDb.Text = "ثبت (F8)";
            this.btnSaveDataInDb.Click += new System.EventHandler(this.btnSaveDataInDb_Click);
            // 
            // frmReadfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.btnSaveDataInDb);
            this.Controls.Add(this.DgvData);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.btnReadData);
            this.Controls.Add(this.lblUnitName);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmReadfile";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblUnitName;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private System.Windows.Forms.OpenFileDialog PpenFileDialogForm;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPath;
        private DevComponents.DotNetBar.Controls.DataGridViewX DgvData;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnReadData;
        private DevComponents.DotNetBar.ButtonX btnSelectPath;
        private DevComponents.DotNetBar.ButtonX btnSaveDataInDb;

    }
}