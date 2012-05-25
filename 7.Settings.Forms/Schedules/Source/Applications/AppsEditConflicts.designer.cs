namespace Sepehr.Settings.Schedules.Applications
{
    partial class frmAppsEditConflicts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppsEditConflicts));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOccuredDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSex = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTel2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.btnAccept);
            this.FormPanel.Controls.Add(this.btnClose);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(790, 568);
            // 
            // 
            // 
            this.FormPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FormPanel.Style.BackColorGradientAngle = 90;
            this.FormPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FormPanel.Style.BorderBottomWidth = 1;
            this.FormPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.FormPanel.Style.BorderLeftWidth = 1;
            this.FormPanel.Style.BorderRightWidth = 1;
            this.FormPanel.Style.BorderTopWidth = 1;
            this.FormPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.FormPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.FormPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("B Koodak", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.Crimson;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(766, 67);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "هشدار! توجه نمایید با تایید این فرمان ، كلیه اطلاعات نوبت های زیر حذف شده و ساختا" +
                "ر تعریف شده ی جدید اعمال میگردد. آیا از این كار اطمینان دارید؟";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 30;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDate,
            this.ColOrderNo,
            this.ColOccuredDateTime,
            this.ColFirstName,
            this.ColLastName,
            this.ColSex,
            this.ColAge,
            this.ColTel1,
            this.ColTel2});
            this.dgvData.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvData.Location = new System.Drawing.Point(12, 79);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvData.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvData.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvData.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvData.RowTemplate.Height = 18;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(766, 414);
            this.dgvData.TabIndex = 3;
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAccept.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 499);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تایید";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(113, 499);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 57);
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "انصراف\r\n(Esc)";
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
            // 
            // ColOrderNo
            // 
            this.ColOrderNo.DataPropertyName = "OrderNo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.NullValue = null;
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
            // ColTel1
            // 
            this.ColTel1.DataPropertyName = "TelNo1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColTel1.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColTel1.HeaderText = "تلفن تماس 1";
            this.ColTel1.MaxInputLength = 15;
            this.ColTel1.MinimumWidth = 100;
            this.ColTel1.Name = "ColTel1";
            this.ColTel1.ReadOnly = true;
            this.ColTel1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColTel1.ToolTipText = "تلفن تماس اول بیمار - تلفن ثابت";
            // 
            // ColTel2
            // 
            this.ColTel2.DataPropertyName = "TelNo2";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColTel2.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColTel2.HeaderText = "تلفن تماس 2";
            this.ColTel2.MaxInputLength = 15;
            this.ColTel2.MinimumWidth = 100;
            this.ColTel2.Name = "ColTel2";
            this.ColTel2.ReadOnly = true;
            this.ColTel2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColTel2.ToolTipText = "تلفن تماس دوم بیمار - تلفن همراه";
            // 
            // frmAppsEditConflicts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(790, 568);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppsEditConflicts";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - نوبت دهی - لیست نوبت های دارای تداخل";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        

        

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        internal DevComponents.DotNetBar.ButtonX btnClose;
        internal DevComponents.DotNetBar.ButtonX btnAccept;
        internal System.Windows.Forms.DataGridView dgvData;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOccuredDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLastName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTel2;
    }
}