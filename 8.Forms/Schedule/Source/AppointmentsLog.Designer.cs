namespace Sepehr.Forms.Schedules
{
    partial class frmAppointmentsLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppointmentsLog));
            this.PanelSchLog = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.lblSchLog = new DevComponents.DotNetBar.LabelX();
            this.dgvAppointmentLog = new System.Windows.Forms.DataGridView();
            this.ColDate = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.ColCategories = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboSchLog = new System.Windows.Forms.ComboBox();
            this.PanelSchLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentLog)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSchLog
            // 
            this.PanelSchLog.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelSchLog.Controls.Add(this.btnCancel);
            this.PanelSchLog.Controls.Add(this.lblSchLog);
            this.PanelSchLog.Controls.Add(this.dgvAppointmentLog);
            this.PanelSchLog.Controls.Add(this.cboSchLog);
            this.PanelSchLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSchLog.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.PanelSchLog.Location = new System.Drawing.Point(0, 0);
            this.PanelSchLog.Name = "PanelSchLog";
            this.PanelSchLog.Size = new System.Drawing.Size(794, 572);
            // 
            // 
            // 
            this.PanelSchLog.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.PanelSchLog.Style.BackColorGradientAngle = 90;
            this.PanelSchLog.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.PanelSchLog.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile;
            this.PanelSchLog.Style.BorderBottomWidth = 1;
            this.PanelSchLog.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.PanelSchLog.Style.BorderLeftWidth = 1;
            this.PanelSchLog.Style.BorderRightWidth = 1;
            this.PanelSchLog.Style.BorderTopWidth = 1;
            this.PanelSchLog.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelSchLog.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.PanelSchLog.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(7, 506);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف (Esc)";
            // 
            // lblSchLog
            // 
            this.lblSchLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSchLog.AutoSize = true;
            this.lblSchLog.BackColor = System.Drawing.Color.Transparent;
            this.lblSchLog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSchLog.ForeColor = System.Drawing.Color.Black;
            this.lblSchLog.Location = new System.Drawing.Point(687, 8);
            this.lblSchLog.Name = "lblSchLog";
            this.lblSchLog.Size = new System.Drawing.Size(100, 16);
            this.lblSchLog.TabIndex = 6;
            this.lblSchLog.Text = "طبقه بندی نوبت : ";
            // 
            // dgvAppointmentLog
            // 
            this.dgvAppointmentLog.AllowUserToAddRows = false;
            this.dgvAppointmentLog.AllowUserToDeleteRows = false;
            this.dgvAppointmentLog.BackgroundColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppointmentLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppointmentLog.ColumnHeadersHeight = 40;
            this.dgvAppointmentLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDate,
            this.ColCategories,
            this.ColUser,
            this.ColDescription});
            this.dgvAppointmentLog.Location = new System.Drawing.Point(6, 35);
            this.dgvAppointmentLog.MultiSelect = false;
            this.dgvAppointmentLog.Name = "dgvAppointmentLog";
            this.dgvAppointmentLog.ReadOnly = true;
            this.dgvAppointmentLog.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppointmentLog.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAppointmentLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointmentLog.Size = new System.Drawing.Size(781, 465);
            this.dgvAppointmentLog.TabIndex = 5;
            this.dgvAppointmentLog.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAppointmentLog_CellPainting);
            // 
            // ColDate
            // 
            this.ColDate.DataPropertyName = "Date";
            this.ColDate.HeaderText = "زمان";
            this.ColDate.MinimumWidth = 50;
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            this.ColDate.ShowTime = true;
            this.ColDate.Width = 120;
            // 
            // ColCategories
            // 
            this.ColCategories.DataPropertyName = "Name";
            this.ColCategories.HeaderText = "طبقه بندی";
            this.ColCategories.MinimumWidth = 10;
            this.ColCategories.Name = "ColCategories";
            this.ColCategories.ReadOnly = true;
            // 
            // ColUser
            // 
            this.ColUser.DataPropertyName = "FullName";
            this.ColUser.HeaderText = "كاربر";
            this.ColUser.MinimumWidth = 10;
            this.ColUser.Name = "ColUser";
            this.ColUser.ReadOnly = true;
            // 
            // ColDescription
            // 
            this.ColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDescription.DataPropertyName = "Description";
            this.ColDescription.HeaderText = "توضیحات";
            this.ColDescription.MinimumWidth = 10;
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            // 
            // cboSchLog
            // 
            this.cboSchLog.AccessibleDescription = "";
            this.cboSchLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSchLog.BackColor = System.Drawing.Color.White;
            this.cboSchLog.DisplayMember = "Name";
            this.cboSchLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchLog.DropDownWidth = 121;
            this.cboSchLog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboSchLog.ForeColor = System.Drawing.Color.Black;
            this.cboSchLog.FormattingEnabled = true;
            this.cboSchLog.IntegralHeight = false;
            this.cboSchLog.ItemHeight = 13;
            this.cboSchLog.Location = new System.Drawing.Point(516, 6);
            this.cboSchLog.MaxDropDownItems = 10;
            this.cboSchLog.Name = "cboSchLog";
            this.cboSchLog.Size = new System.Drawing.Size(168, 21);
            this.cboSchLog.TabIndex = 4;
            this.cboSchLog.TabStop = false;
            this.cboSchLog.Tag = "";
            this.cboSchLog.ValueMember = "ID";
            this.cboSchLog.SelectedIndexChanged += new System.EventHandler(this.cboSchLog_SelectedIndexChanged);
            // 
            // frmAppointmentsLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.PanelSchLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppointmentsLog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نوبت دهی - سابقه  نوبت";
            this.Shown += new System.EventHandler(this.frmAppointmentsLog_Shown);
            this.PanelSchLog.ResumeLayout(false);
            this.PanelSchLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelSchLog;
        private System.Windows.Forms.ComboBox cboSchLog;
        private System.Windows.Forms.DataGridView dgvAppointmentLog;
        private DevComponents.DotNetBar.LabelX lblSchLog;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;

    }
}