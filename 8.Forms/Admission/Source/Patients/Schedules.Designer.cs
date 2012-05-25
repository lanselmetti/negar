namespace Sepehr.Forms.Admission.Patients
{
    partial class frmPatientSchedules
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatientSchedules));
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.ColAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOccuredDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSex = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = global::Sepehr.Forms.Admission.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(14, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 60);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(794, 572);
            // 
            // 
            // 
            this.FormPanel.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.FormPanel.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.FormPanel.Style.BackColorGradientAngle = 90;
            this.FormPanel.Style.BorderBottomWidth = 1;
            this.FormPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.FormPanel.Style.BorderLeftWidth = 1;
            this.FormPanel.Style.BorderRightWidth = 1;
            this.FormPanel.Style.BorderTopWidth = 1;
            this.FormPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.FormPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.FormPanel.TabIndex = 0;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.PeachPuff;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 35;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAppName,
            this.ColDate,
            this.ColOrderNo,
            this.ColOccuredDateTime,
            this.ColFirstName,
            this.ColLastName,
            this.ColSex,
            this.ColAge});
            this.dgvData.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvData.Location = new System.Drawing.Point(14, 73);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvData.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvData.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvData.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(768, 421);
            this.dgvData.TabIndex = 0;
            this.dgvData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.Purple;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(794, 67);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "لیست نوبت های ارائه شده به بیمار";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // ColAppName
            // 
            this.ColAppName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColAppName.HeaderText = "برنامه نوبت دهی";
            this.ColAppName.Name = "ColAppName";
            this.ColAppName.ReadOnly = true;
            // 
            // ColDate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColDate.HeaderText = "تاریخ شیفت";
            this.ColDate.MinimumWidth = 100;
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            this.ColDate.Width = 170;
            // 
            // ColOrderNo
            // 
            this.ColOrderNo.DataPropertyName = "OrderNo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColOrderNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColOrderNo.HeaderText = "#";
            this.ColOrderNo.MinimumWidth = 45;
            this.ColOrderNo.Name = "ColOrderNo";
            this.ColOrderNo.ReadOnly = true;
            this.ColOrderNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColOrderNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColOrderNo.ToolTipText = "شماره نوبت";
            this.ColOrderNo.Width = 45;
            // 
            // ColOccuredDateTime
            // 
            this.ColOccuredDateTime.DataPropertyName = "OccuredDateTime";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "HH:mm";
            dataGridViewCellStyle4.NullValue = null;
            this.ColOccuredDateTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColOccuredDateTime.HeaderText = "زمان";
            this.ColOccuredDateTime.MaxInputLength = 10;
            this.ColOccuredDateTime.MinimumWidth = 60;
            this.ColOccuredDateTime.Name = "ColOccuredDateTime";
            this.ColOccuredDateTime.ReadOnly = true;
            this.ColOccuredDateTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColOccuredDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColOccuredDateTime.ToolTipText = "زمان حضور بیمار";
            this.ColOccuredDateTime.Width = 60;
            // 
            // ColFirstName
            // 
            this.ColFirstName.DataPropertyName = "FirstName";
            this.ColFirstName.HeaderText = "نام";
            this.ColFirstName.MaxInputLength = 15;
            this.ColFirstName.MinimumWidth = 60;
            this.ColFirstName.Name = "ColFirstName";
            this.ColFirstName.ReadOnly = true;
            this.ColFirstName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColFirstName.ToolTipText = "نام بیمار";
            this.ColFirstName.Width = 70;
            // 
            // ColLastName
            // 
            this.ColLastName.DataPropertyName = "LastName";
            this.ColLastName.HeaderText = "نام خانوادگی";
            this.ColLastName.MaxInputLength = 25;
            this.ColLastName.MinimumWidth = 110;
            this.ColLastName.Name = "ColLastName";
            this.ColLastName.ReadOnly = true;
            this.ColLastName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColLastName.ToolTipText = "نام خانوادگی بیمار";
            this.ColLastName.Width = 110;
            // 
            // ColSex
            // 
            this.ColSex.DataPropertyName = "IsMale";
            this.ColSex.FalseValue = "";
            this.ColSex.HeaderText = "مرد";
            this.ColSex.MinimumWidth = 40;
            this.ColSex.Name = "ColSex";
            this.ColSex.ReadOnly = true;
            this.ColSex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColSex.ToolTipText = "تعیین جنسیت بیمار. مرد یا زن";
            this.ColSex.TrueValue = "";
            this.ColSex.Width = 40;
            // 
            // ColAge
            // 
            this.ColAge.DataPropertyName = "Age";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColAge.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColAge.HeaderText = "سن";
            this.ColAge.MaxInputLength = 3;
            this.ColAge.MinimumWidth = 50;
            this.ColAge.Name = "ColAge";
            this.ColAge.ReadOnly = true;
            this.ColAge.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColAge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColAge.ToolTipText = "سن بیمار";
            this.ColAge.Width = 50;
            // 
            // frmPatientSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(670, 400);
            this.Name = "frmPatientSchedules";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - نمایش لیست نوبت های ارائه شده به بیمار";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOccuredDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLastName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAge;

    }
}