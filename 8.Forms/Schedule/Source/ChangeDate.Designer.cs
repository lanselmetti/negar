namespace Sepehr.Forms.Schedules
{
    partial class frmChangeDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeDate));
            this.FormMonthView = new Negar.PersianCalendar.UI.Controls.PersianMonthView();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.MainPanel = new DevComponents.DotNetBar.PanelEx();
            this.FormDatePicker = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormMonthView
            // 
            this.FormMonthView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FormMonthView.IsAllowNullDate = false;
            this.FormMonthView.Location = new System.Drawing.Point(12, 44);
            this.FormMonthView.Name = "FormMonthView";
            this.FormMonthView.SelectedDateTime = new System.DateTime(2010, 3, 30, 23, 55, 8, 252);
            this.FormMonthView.ShowFocusRect = false;
            this.FormMonthView.TabIndex = 0;
            this.FormMonthView.TabStop = false;
            this.FormMonthView.DoubleClick += new System.EventHandler(this.FormMonthView_DoubleClick);
            this.FormMonthView.SelectedDateTimeChanged += new System.EventHandler(this.Dates_Changed);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Cancel;
            this.btnClose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClose.Location = new System.Drawing.Point(100, 221);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 77);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج (Esc)";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelect.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Accept;
            this.btnSelect.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSelect.Location = new System.Drawing.Point(12, 221);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSelect.Size = new System.Drawing.Size(78, 77);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.TabStop = false;
            this.btnSelect.Text = "انتخاب (F8)";
            // 
            // MainPanel
            // 
            this.MainPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.MainPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.MainPanel.Controls.Add(this.FormDatePicker);
            this.MainPanel.Controls.Add(this.FormMonthView);
            this.MainPanel.Controls.Add(this.btnSelect);
            this.MainPanel.Controls.Add(this.btnClose);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(191, 310);
            this.MainPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.MainPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.MainPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.MainPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.MainPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.MainPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.MainPanel.Style.GradientAngle = 90;
            this.MainPanel.TabIndex = 0;
            // 
            // FormDatePicker
            // 
            this.FormDatePicker.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.FormDatePicker.IsAllowNullDate = false;
            this.FormDatePicker.IsPopupOpen = false;
            this.FormDatePicker.Location = new System.Drawing.Point(12, 18);
            this.FormDatePicker.Name = "FormDatePicker";
            this.FormDatePicker.SelectedDateTime = new System.DateTime(2010, 3, 30, 23, 55, 16, 35);
            this.FormDatePicker.Size = new System.Drawing.Size(166, 20);
            this.FormDatePicker.TabIndex = 1;
            this.FormDatePicker.TextHorizontalAlignment = Negar.PersianCalendar.UI.TextAlignment.Center;
            this.FormDatePicker.TextVerticalAlignment = Negar.PersianCalendar.UI.TextAlignment.Center;
            this.FormDatePicker.SelectedDateTimeChanged += new System.EventHandler(this.Dates_Changed);
            // 
            // frmChangeDate
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(191, 310);
            this.ControlBox = false;
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChangeDate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انتخاب تاریخ برنامه";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.ButtonX btnClose;
        internal DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.PanelEx MainPanel;
        public Negar.PersianCalendar.UI.Controls.PersianMonthView FormMonthView;
        public Negar.PersianCalendar.UI.Controls.PersianDatePicker FormDatePicker;
    }
}