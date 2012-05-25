namespace Negar.GridPrinting
{
    partial class frmReportResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportResult));
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnPrinterSettings = new DevComponents.DotNetBar.ButtonX();
            this.btnShow2Page = new DevComponents.DotNetBar.ButtonX();
            this.btnShow1Page = new DevComponents.DotNetBar.ButtonX();
            this.SliderPreviewZoom = new DevComponents.DotNetBar.Controls.Slider();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.txtPageNum = new DevComponents.Editors.IntegerInput();
            this.lblPageNum = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.PrintPreviewControlForm = new System.Windows.Forms.PrintPreviewControl();
            this.PrinterDialog = new System.Windows.Forms.PrintDialog();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNum)).BeginInit();
            this.SuspendLayout();
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.btnPrinterSettings);
            this.FormPanel.Controls.Add(this.btnShow2Page);
            this.FormPanel.Controls.Add(this.btnShow1Page);
            this.FormPanel.Controls.Add(this.SliderPreviewZoom);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.txtPageNum);
            this.FormPanel.Controls.Add(this.lblPageNum);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnPrint);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FormPanel.Location = new System.Drawing.Point(0, 485);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(784, 79);
            // 
            // 
            // 
            this.FormPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FormPanel.Style.BackColorGradientAngle = 90;
            this.FormPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FormPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FormPanel.Style.BorderBottomWidth = 1;
            this.FormPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.FormPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FormPanel.Style.BorderLeftWidth = 1;
            this.FormPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FormPanel.Style.BorderRightWidth = 1;
            this.FormPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FormPanel.Style.BorderTopWidth = 1;
            this.FormPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.FormPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.FormPanel.TabIndex = 0;
            // 
            // btnPrinterSettings
            // 
            this.btnPrinterSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrinterSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrinterSettings.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnPrinterSettings.Image = global::Negar.Properties.Resources.PrintSettings;
            this.btnPrinterSettings.Location = new System.Drawing.Point(283, 10);
            this.btnPrinterSettings.Name = "btnPrinterSettings";
            this.btnPrinterSettings.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnPrinterSettings.Size = new System.Drawing.Size(95, 57);
            this.btnPrinterSettings.TabIndex = 5;
            this.btnPrinterSettings.TabStop = false;
            this.btnPrinterSettings.Text = "تنظیمات چاپگر (F4)";
            this.btnPrinterSettings.Click += new System.EventHandler(this.btnPrinterSettings_Click);
            // 
            // btnShow2Page
            // 
            this.btnShow2Page.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShow2Page.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow2Page.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShow2Page.Location = new System.Drawing.Point(586, 43);
            this.btnShow2Page.Name = "btnShow2Page";
            this.btnShow2Page.PopupSide = DevComponents.DotNetBar.ePopupSide.Bottom;
            this.btnShow2Page.Size = new System.Drawing.Size(85, 24);
            this.btnShow2Page.TabIndex = 2;
            this.btnShow2Page.TabStop = false;
            this.btnShow2Page.Text = "نمایش 2 صفحه";
            this.btnShow2Page.Click += new System.EventHandler(this.btnShowPageColumns_Click);
            // 
            // btnShow1Page
            // 
            this.btnShow1Page.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShow1Page.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow1Page.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShow1Page.Location = new System.Drawing.Point(586, 10);
            this.btnShow1Page.Name = "btnShow1Page";
            this.btnShow1Page.PopupSide = DevComponents.DotNetBar.ePopupSide.Bottom;
            this.btnShow1Page.Size = new System.Drawing.Size(85, 24);
            this.btnShow1Page.TabIndex = 1;
            this.btnShow1Page.TabStop = false;
            this.btnShow1Page.Text = "نمایش 1 ‌صفحه";
            this.btnShow1Page.Click += new System.EventHandler(this.btnShowPageColumns_Click);
            // 
            // SliderPreviewZoom
            // 
            this.SliderPreviewZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SliderPreviewZoom.BackColor = System.Drawing.Color.Transparent;
            this.SliderPreviewZoom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.SliderPreviewZoom.LabelPosition = DevComponents.DotNetBar.eSliderLabelPosition.Top;
            this.SliderPreviewZoom.LabelWidth = 40;
            this.SliderPreviewZoom.Location = new System.Drawing.Point(384, 10);
            this.SliderPreviewZoom.Maximum = 500;
            this.SliderPreviewZoom.Minimum = 30;
            this.SliderPreviewZoom.Name = "SliderPreviewZoom";
            this.SliderPreviewZoom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SliderPreviewZoom.Size = new System.Drawing.Size(122, 57);
            this.SliderPreviewZoom.Step = 10;
            this.SliderPreviewZoom.TabIndex = 4;
            this.SliderPreviewZoom.Text = "بزرگنمایی: %60";
            this.SliderPreviewZoom.TrackMarker = false;
            this.SliderPreviewZoom.Value = 60;
            this.SliderPreviewZoom.ValueChanged += new System.EventHandler(this.SliderPreviewZoom_ValueChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Negar.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(677, 10);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // txtPageNum
            // 
            this.txtPageNum.AllowEmptyState = false;
            this.txtPageNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPageNum.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPageNum.ButtonClear.Enabled = false;
            this.txtPageNum.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPageNum.Location = new System.Drawing.Point(522, 40);
            this.txtPageNum.MaxValue = 10000;
            this.txtPageNum.MinValue = 1;
            this.txtPageNum.Name = "txtPageNum";
            this.txtPageNum.ShowUpDown = true;
            this.txtPageNum.Size = new System.Drawing.Size(51, 21);
            this.txtPageNum.TabIndex = 0;
            this.txtPageNum.Value = 1;
            this.txtPageNum.ValueChanged += new System.EventHandler(this.txtPageNum_ValueChanged);
            // 
            // lblPageNum
            // 
            this.lblPageNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageNum.AutoSize = true;
            this.lblPageNum.BackColor = System.Drawing.Color.Transparent;
            this.lblPageNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPageNum.Location = new System.Drawing.Point(509, 18);
            this.lblPageNum.Name = "lblPageNum";
            this.lblPageNum.Size = new System.Drawing.Size(76, 16);
            this.lblPageNum.TabIndex = 3;
            this.lblPageNum.Text = "شماره صفحه:";
            this.lblPageNum.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Negar.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Image = global::Negar.Properties.Resources.PrintGrid;
            this.btnPrint.Location = new System.Drawing.Point(182, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnPrint.Size = new System.Drawing.Size(95, 57);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "چاپ\r\n(F8)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // PrintPreviewControlForm
            // 
            this.PrintPreviewControlForm.AutoZoom = false;
            this.PrintPreviewControlForm.BackColor = System.Drawing.Color.White;
            this.PrintPreviewControlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrintPreviewControlForm.Location = new System.Drawing.Point(0, 0);
            this.PrintPreviewControlForm.Name = "PrintPreviewControlForm";
            this.PrintPreviewControlForm.Size = new System.Drawing.Size(784, 485);
            this.PrintPreviewControlForm.TabIndex = 7;
            this.PrintPreviewControlForm.Zoom = 0.6;
            // 
            // PrinterDialog
            // 
            this.PrinterDialog.AllowPrintToFile = false;
            this.PrinterDialog.AllowSelection = true;
            this.PrinterDialog.AllowSomePages = true;
            this.PrinterDialog.UseEXDialog = true;
            // 
            // frmReportResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.PrintPreviewControlForm);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmReportResult";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "پیش نمایش چاپ گزارش";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private System.Windows.Forms.PrintPreviewControl PrintPreviewControlForm;
        private DevComponents.DotNetBar.Controls.Slider SliderPreviewZoom;
        private System.Windows.Forms.PrintDialog PrinterDialog;
        private DevComponents.DotNetBar.ButtonX btnShow1Page;
        private DevComponents.DotNetBar.ButtonX btnShow2Page;
        private DevComponents.Editors.IntegerInput txtPageNum;
        private DevComponents.DotNetBar.LabelX lblPageNum;
        private DevComponents.DotNetBar.ButtonX btnPrinterSettings;
    }
}