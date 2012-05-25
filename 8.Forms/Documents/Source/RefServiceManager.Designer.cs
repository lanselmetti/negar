namespace Sepehr.Forms.Documents
{
    partial class frmRefServiceManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRefServiceManager));
            this.dgvRefServices = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExpert = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColPhysician = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PanelMainForm = new DevComponents.DotNetBar.PanelEx();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefServices)).BeginInit();
            this.PanelMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRefServices
            // 
            this.dgvRefServices.AllowUserToAddRows = false;
            this.dgvRefServices.AllowUserToDeleteRows = false;
            this.dgvRefServices.AllowUserToOrderColumns = true;
            this.dgvRefServices.AllowUserToResizeRows = false;
            this.dgvRefServices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvRefServices.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvRefServices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRefServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColServiceName,
            this.ColQuantity,
            this.ColExpert,
            this.ColPhysician});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefServices.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRefServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRefServices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvRefServices.Location = new System.Drawing.Point(0, 0);
            this.dgvRefServices.MultiSelect = false;
            this.dgvRefServices.Name = "dgvRefServices";
            this.dgvRefServices.RowHeadersVisible = false;
            this.dgvRefServices.Size = new System.Drawing.Size(634, 134);
            this.dgvRefServices.StandardTab = true;
            this.dgvRefServices.TabIndex = 0;
            this.dgvRefServices.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRefServices_CellFormatting);
            // 
            // ColServiceName
            // 
            this.ColServiceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColServiceName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColServiceName.HeaderText = "نام خدمت بیمار";
            this.ColServiceName.Name = "ColServiceName";
            this.ColServiceName.ReadOnly = true;
            this.ColServiceName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColServiceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ColQuantity
            // 
            this.ColQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColQuantity.HeaderText = "تعداد";
            this.ColQuantity.MaxInputLength = 3;
            this.ColQuantity.Name = "ColQuantity";
            this.ColQuantity.ReadOnly = true;
            this.ColQuantity.Width = 40;
            // 
            // ColExpert
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Purple;
            this.ColExpert.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColExpert.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColExpert.DisplayStyleForCurrentCellOnly = true;
            this.ColExpert.HeaderText = "كارشناس";
            this.ColExpert.Name = "ColExpert";
            this.ColExpert.ReadOnly = true;
            this.ColExpert.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColExpert.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColExpert.Width = 130;
            // 
            // ColPhysician
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Purple;
            this.ColPhysician.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColPhysician.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColPhysician.DisplayStyleForCurrentCellOnly = true;
            this.ColPhysician.HeaderText = "پزشك";
            this.ColPhysician.Name = "ColPhysician";
            this.ColPhysician.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPhysician.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColPhysician.Width = 130;
            // 
            // PanelMainForm
            // 
            this.PanelMainForm.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelMainForm.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelMainForm.Controls.Add(this.btnCancel);
            this.PanelMainForm.Controls.Add(this.btnSave);
            this.PanelMainForm.Controls.Add(this.dgvRefServices);
            this.PanelMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMainForm.Location = new System.Drawing.Point(0, 0);
            this.PanelMainForm.Name = "PanelMainForm";
            this.PanelMainForm.Size = new System.Drawing.Size(634, 212);
            this.PanelMainForm.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelMainForm.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelMainForm.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelMainForm.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelMainForm.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelMainForm.Style.GradientAngle = 90;
            this.PanelMainForm.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Documents.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف (Esc)";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = global::Sepehr.Forms.Documents.Properties.Resources.Accept;
            this.btnSave.Location = new System.Drawing.Point(12, 140);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSave.Size = new System.Drawing.Size(95, 60);
            this.btnSave.TabIndex = 1;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "ثبت (F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmRefServiceManager
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(634, 212);
            this.Controls.Add(this.PanelMainForm);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRefServiceManager";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مشاهده خدمات مراجعه بیمار";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefServices)).EndInit();
            this.PanelMainForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvRefServices;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColExpert;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColPhysician;
        private DevComponents.DotNetBar.PanelEx PanelMainForm;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
    }
}