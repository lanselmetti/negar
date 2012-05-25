namespace Sepehr.Forms.Account
{
    partial class frmManageCostOrDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageCostOrDiscount));
            this.PanelCostDiscount = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.lblType = new DevComponents.DotNetBar.LabelX();
            this.cboType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblValue = new DevComponents.DotNetBar.LabelX();
            this.txtValue = new DevComponents.Editors.IntegerInput();
            this.lblTime = new DevComponents.DotNetBar.LabelX();
            this.lblDate = new DevComponents.DotNetBar.LabelX();
            this.RegDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.RegTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.PanelCostDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegTime)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelCostDiscount
            // 
            this.PanelCostDiscount.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelCostDiscount.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelCostDiscount.Controls.Add(this.lblTitle);
            this.PanelCostDiscount.Controls.Add(this.lblType);
            this.PanelCostDiscount.Controls.Add(this.cboType);
            this.PanelCostDiscount.Controls.Add(this.lblValue);
            this.PanelCostDiscount.Controls.Add(this.txtValue);
            this.PanelCostDiscount.Controls.Add(this.lblTime);
            this.PanelCostDiscount.Controls.Add(this.lblDate);
            this.PanelCostDiscount.Controls.Add(this.RegDate);
            this.PanelCostDiscount.Controls.Add(this.RegTime);
            this.PanelCostDiscount.Controls.Add(this.lblDescription);
            this.PanelCostDiscount.Controls.Add(this.txtDescription);
            this.PanelCostDiscount.Controls.Add(this.btnCancel);
            this.PanelCostDiscount.Controls.Add(this.btnAccept);
            this.PanelCostDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCostDiscount.Location = new System.Drawing.Point(0, 0);
            this.PanelCostDiscount.Name = "PanelCostDiscount";
            this.PanelCostDiscount.Size = new System.Drawing.Size(373, 223);
            // 
            // 
            // 
            this.PanelCostDiscount.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelCostDiscount.Style.BackColorGradientAngle = 90;
            this.PanelCostDiscount.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelCostDiscount.Style.BorderBottomWidth = 1;
            this.PanelCostDiscount.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelCostDiscount.Style.BorderLeftWidth = 1;
            this.PanelCostDiscount.Style.BorderRightWidth = 1;
            this.PanelCostDiscount.Style.BorderTopWidth = 1;
            this.PanelCostDiscount.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelCostDiscount.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelCostDiscount.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(373, 39);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "مدیریت تخفیف حساب بیمار";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblType.Location = new System.Drawing.Point(337, 47);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(24, 16);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "نوع:";
            this.lblType.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboType
            // 
            this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboType.DisplayMember = "Name";
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboType.ItemHeight = 13;
            this.cboType.Location = new System.Drawing.Point(172, 45);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(159, 21);
            this.cboType.TabIndex = 0;
            this.cboType.ValueMember = "ID";
            this.cboType.WatermarkText = "نوع تخفیف اعمالی";
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValue.AutoSize = true;
            this.lblValue.BackColor = System.Drawing.Color.Transparent;
            this.lblValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblValue.Location = new System.Drawing.Point(114, 47);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(53, 16);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "مبلغ: ریال";
            this.lblValue.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtValue
            // 
            this.txtValue.AllowEmptyState = false;
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtValue.DisplayFormat = "N0";
            this.txtValue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtValue.Location = new System.Drawing.Point(12, 44);
            this.txtValue.MaxValue = 10000000;
            this.txtValue.MinValue = 0;
            this.txtValue.Name = "txtValue";
            this.txtValue.ShowUpDown = true;
            this.txtValue.Size = new System.Drawing.Size(95, 22);
            this.txtValue.TabIndex = 3;
            this.txtValue.Tag = "";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTime.Location = new System.Drawing.Point(114, 77);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(75, 16);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "ساعت اعمال:";
            this.lblTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDate.Location = new System.Drawing.Point(300, 77);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(65, 16);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "تاریخ اعمال:";
            this.lblDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // RegDate
            // 
            this.RegDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RegDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegDate.IsAllowNullDate = false;
            this.RegDate.IsPopupOpen = false;
            this.RegDate.Location = new System.Drawing.Point(195, 75);
            this.RegDate.Name = "RegDate";
            this.RegDate.SelectedDateTime = new System.DateTime(2010, 3, 21, 0, 0, 0, 0);
            this.RegDate.Size = new System.Drawing.Size(101, 21);
            this.RegDate.TabIndex = 5;
            this.RegDate.TabStop = false;
            this.RegDate.Tag = "RefData";
            // 
            // RegTime
            // 
            this.RegTime.AllowEmptyState = false;
            this.RegTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.RegTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.RegTime.CustomFormat = "HH:mm:ss";
            this.RegTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.RegTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.RegTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.RegTime.Location = new System.Drawing.Point(12, 75);
            // 
            // 
            // 
            this.RegTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.RegTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.RegTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.RegTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.RegTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.RegTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.RegTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.RegTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.RegTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.RegTime.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.RegTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.RegTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.RegTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.RegTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.RegTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.RegTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.RegTime.MonthCalendar.TodayButtonVisible = true;
            this.RegTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.RegTime.Name = "RegTime";
            this.RegTime.ShowUpDown = true;
            this.RegTime.Size = new System.Drawing.Size(95, 21);
            this.RegTime.TabIndex = 7;
            this.RegTime.TabStop = false;
            this.RegTime.Tag = "RefData";
            this.RegTime.Value = new System.DateTime(((long)(0)));
            this.RegTime.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.Location = new System.Drawing.Point(300, 107);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 16);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "توضیحات:";
            this.lblDescription.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Location = new System.Drawing.Point(12, 102);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(279, 42);
            this.txtDescription.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Account.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف (Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Sepehr.Forms.Account.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 151);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 60);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "اعمال (F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmManageCostOrDiscount
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(373, 223);
            this.Controls.Add(this.PanelCostDiscount);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageCostOrDiscount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - حساب - مدیریت تخفیف ها و هزینه ها";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.PanelCostDiscount.ResumeLayout(false);
            this.PanelCostDiscount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Negar.PersianCalendar.UI.Controls.PersianDatePicker RegDate;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        internal DevComponents.Editors.DateTimeAdv.DateTimeInput RegTime;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cboType;
        internal DevComponents.Editors.IntegerInput txtValue;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelCostDiscount;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.LabelX lblDescription;
        private DevComponents.DotNetBar.LabelX lblType;
        private DevComponents.DotNetBar.LabelX lblValue;
        private DevComponents.DotNetBar.LabelX lblDate;
        private DevComponents.DotNetBar.LabelX lblTime;
    }
}