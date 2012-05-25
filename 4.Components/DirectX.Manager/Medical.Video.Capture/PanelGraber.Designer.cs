using System;

namespace Negar.Medical.VideoCapture
{
    partial class frmPanelGraber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPanelGraber));
            this.MainPanel = new DevComponents.DotNetBar.PanelEx();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.btnGrab = new DevComponents.DotNetBar.PanelEx();
            this.PreviewPanel = new System.Windows.Forms.Panel();
            this.NavPane = new DevComponents.DotNetBar.NavigationPane();
            this.GrabPanel = new DevComponents.DotNetBar.NavigationPanePanel();
            this.PanelImages = new System.Windows.Forms.Panel();
            this.btnPanel1 = new DevComponents.DotNetBar.ButtonItem();
            this.PanelSettings = new DevComponents.DotNetBar.NavigationPanePanel();
            this.lstVideoDevice = new DevComponents.DotNetBar.ItemPanel();
            this.lstVideoVideoCompressors = new DevComponents.DotNetBar.ItemPanel();
            this.btnNoneCompressor = new DevComponents.DotNetBar.ButtonItem();
            this.btnPanel2 = new DevComponents.DotNetBar.ButtonItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAction = new DevComponents.DotNetBar.ButtonX();
            this.MainPanel.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.NavPane.SuspendLayout();
            this.GrabPanel.SuspendLayout();
            this.PanelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.MainPanel.Controls.Add(this.LeftPanel);
            this.MainPanel.Controls.Add(this.NavPane);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(997, 561);
            this.MainPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.MainPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.MainPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.MainPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.MainPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.MainPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.MainPanel.Style.GradientAngle = 90;
            this.MainPanel.TabIndex = 0;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.btnGrab);
            this.LeftPanel.Controls.Add(this.PreviewPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(540, 561);
            this.LeftPanel.TabIndex = 0;
            // 
            // btnGrab
            // 
            this.btnGrab.CanvasColor = System.Drawing.SystemColors.Control;
            this.btnGrab.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.btnGrab.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGrab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGrab.Font = new System.Drawing.Font("B Titr", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnGrab.Location = new System.Drawing.Point(0, 405);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(540, 156);
            this.btnGrab.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.btnGrab.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.btnGrab.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.btnGrab.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.btnGrab.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.btnGrab.Style.ForeColor.Color = System.Drawing.Color.Crimson;
            this.btnGrab.Style.GradientAngle = 90;
            this.btnGrab.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.btnGrab.StyleMouseDown.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.btnGrab.StyleMouseDown.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.btnGrab.StyleMouseDown.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.btnGrab.StyleMouseDown.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedText;
            this.btnGrab.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.btnGrab.StyleMouseOver.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground;
            this.btnGrab.StyleMouseOver.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground2;
            this.btnGrab.StyleMouseOver.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBorder;
            this.btnGrab.StyleMouseOver.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotText;
            this.btnGrab.TabIndex = 0;
            this.btnGrab.Text = "دریافت تصویر";
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            this.btnGrab.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnGrab_MouseClick);
            // 
            // PreviewPanel
            // 
            this.PreviewPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PreviewPanel.Location = new System.Drawing.Point(0, 0);
            this.PreviewPanel.MaximumSize = new System.Drawing.Size(640, 480);
            this.PreviewPanel.MinimumSize = new System.Drawing.Size(320, 240);
            this.PreviewPanel.Name = "PreviewPanel";
            this.PreviewPanel.Padding = new System.Windows.Forms.Padding(1);
            this.PreviewPanel.Size = new System.Drawing.Size(540, 405);
            this.PreviewPanel.TabIndex = 1;
            // 
            // NavPane
            // 
            this.NavPane.AutoSizeButtonImage = false;
            this.NavPane.CanCollapse = true;
            this.NavPane.ConfigureItemVisible = false;
            this.NavPane.Controls.Add(this.GrabPanel);
            this.NavPane.Controls.Add(this.PanelSettings);
            this.NavPane.Dock = System.Windows.Forms.DockStyle.Right;
            this.NavPane.ItemPaddingBottom = 2;
            this.NavPane.ItemPaddingTop = 2;
            this.NavPane.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPanel1,
            this.btnPanel2});
            this.NavPane.Location = new System.Drawing.Point(540, 0);
            this.NavPane.Name = "NavPane";
            this.NavPane.NavigationBarHeight = 48;
            this.NavPane.Padding = new System.Windows.Forms.Padding(1);
            this.NavPane.Size = new System.Drawing.Size(457, 561);
            this.NavPane.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.NavPane.TabIndex = 1;
            this.NavPane.TitleButtonAlignment = DevComponents.DotNetBar.eTitleButtonAlignment.Left;
            // 
            // 
            // 
            this.NavPane.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.NavPane.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NavPane.TitlePanel.Font = new System.Drawing.Font("B Titr", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.NavPane.TitlePanel.Location = new System.Drawing.Point(1, 1);
            this.NavPane.TitlePanel.Name = "panelTitle";
            this.NavPane.TitlePanel.Size = new System.Drawing.Size(455, 30);
            this.NavPane.TitlePanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.NavPane.TitlePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.NavPane.TitlePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.NavPane.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.NavPane.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.NavPane.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.NavPane.TitlePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.NavPane.TitlePanel.Style.GradientAngle = 90;
            this.NavPane.TitlePanel.Style.MarginLeft = 4;
            this.NavPane.TitlePanel.TabIndex = 0;
            this.NavPane.TitlePanel.Text = "تصاویر ذخیره شده";
            this.NavPane.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.NavPane_ExpandedChanged);
            // 
            // GrabPanel
            // 
            this.GrabPanel.AutoScroll = true;
            this.GrabPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.GrabPanel.Controls.Add(this.PanelImages);
            this.GrabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrabPanel.Location = new System.Drawing.Point(1, 31);
            this.GrabPanel.MinimumSize = new System.Drawing.Size(224, 0);
            this.GrabPanel.Name = "GrabPanel";
            this.GrabPanel.ParentItem = this.btnPanel1;
            this.GrabPanel.Size = new System.Drawing.Size(455, 481);
            this.GrabPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.GrabPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.GrabPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.GrabPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.GrabPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.GrabPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.GrabPanel.Style.GradientAngle = 90;
            this.GrabPanel.TabIndex = 2;
            // 
            // PanelImages
            // 
            this.PanelImages.AutoScroll = true;
            this.PanelImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelImages.Location = new System.Drawing.Point(0, 0);
            this.PanelImages.Name = "PanelImages";
            this.PanelImages.Size = new System.Drawing.Size(455, 481);
            this.PanelImages.TabIndex = 0;
            // 
            // btnPanel1
            // 
            this.btnPanel1.Checked = true;
            this.btnPanel1.Image = global::Negar.Medical.VideoCapture.Properties.Resources.Menu_Main;
            this.btnPanel1.ImagePaddingHorizontal = 8;
            this.btnPanel1.Name = "btnPanel1";
            this.btnPanel1.OptionGroup = "navBar";
            this.btnPanel1.Text = "تصاویر ذخیره شده";
            // 
            // PanelSettings
            // 
            this.PanelSettings.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelSettings.Controls.Add(this.lstVideoDevice);
            this.PanelSettings.Controls.Add(this.lstVideoVideoCompressors);
            this.PanelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSettings.Location = new System.Drawing.Point(1, 1);
            this.PanelSettings.Name = "PanelSettings";
            this.PanelSettings.ParentItem = this.btnPanel2;
            this.PanelSettings.Size = new System.Drawing.Size(455, 511);
            this.PanelSettings.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelSettings.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.PanelSettings.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.PanelSettings.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelSettings.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.PanelSettings.Style.GradientAngle = 90;
            this.PanelSettings.TabIndex = 0;
            // 
            // lstVideoDevice
            // 
            this.lstVideoDevice.AutoScroll = true;
            // 
            // 
            // 
            this.lstVideoDevice.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.lstVideoDevice.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstVideoDevice.BackgroundStyle.BorderBottomWidth = 1;
            this.lstVideoDevice.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.lstVideoDevice.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstVideoDevice.BackgroundStyle.BorderLeftWidth = 1;
            this.lstVideoDevice.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstVideoDevice.BackgroundStyle.BorderRightWidth = 1;
            this.lstVideoDevice.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstVideoDevice.BackgroundStyle.BorderTopWidth = 1;
            this.lstVideoDevice.BackgroundStyle.PaddingBottom = 1;
            this.lstVideoDevice.BackgroundStyle.PaddingLeft = 1;
            this.lstVideoDevice.BackgroundStyle.PaddingRight = 1;
            this.lstVideoDevice.BackgroundStyle.PaddingTop = 1;
            this.lstVideoDevice.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.lstVideoDevice.Location = new System.Drawing.Point(11, 11);
            this.lstVideoDevice.Name = "lstVideoDevice";
            this.lstVideoDevice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstVideoDevice.Size = new System.Drawing.Size(433, 83);
            this.lstVideoDevice.TabIndex = 1;
            // 
            // lstVideoVideoCompressors
            // 
            this.lstVideoVideoCompressors.AutoScroll = true;
            // 
            // 
            // 
            this.lstVideoVideoCompressors.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.lstVideoVideoCompressors.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstVideoVideoCompressors.BackgroundStyle.BorderBottomWidth = 1;
            this.lstVideoVideoCompressors.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.lstVideoVideoCompressors.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstVideoVideoCompressors.BackgroundStyle.BorderLeftWidth = 1;
            this.lstVideoVideoCompressors.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstVideoVideoCompressors.BackgroundStyle.BorderRightWidth = 1;
            this.lstVideoVideoCompressors.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstVideoVideoCompressors.BackgroundStyle.BorderTopWidth = 1;
            this.lstVideoVideoCompressors.BackgroundStyle.PaddingBottom = 1;
            this.lstVideoVideoCompressors.BackgroundStyle.PaddingLeft = 1;
            this.lstVideoVideoCompressors.BackgroundStyle.PaddingRight = 1;
            this.lstVideoVideoCompressors.BackgroundStyle.PaddingTop = 1;
            this.lstVideoVideoCompressors.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNoneCompressor});
            this.lstVideoVideoCompressors.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.lstVideoVideoCompressors.Location = new System.Drawing.Point(11, 100);
            this.lstVideoVideoCompressors.Name = "lstVideoVideoCompressors";
            this.lstVideoVideoCompressors.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstVideoVideoCompressors.Size = new System.Drawing.Size(433, 378);
            this.lstVideoVideoCompressors.TabIndex = 1;
            // 
            // btnNoneCompressor
            // 
            this.btnNoneCompressor.AutoCheckOnClick = true;
            this.btnNoneCompressor.Checked = true;
            this.btnNoneCompressor.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnNoneCompressor.FontBold = true;
            this.btnNoneCompressor.ImagePaddingHorizontal = 8;
            this.btnNoneCompressor.Name = "btnNoneCompressor";
            this.btnNoneCompressor.Text = "(None Compressor)";
            // 
            // btnPanel2
            // 
            this.btnPanel2.Image = global::Negar.Medical.VideoCapture.Properties.Resources.Config;
            this.btnPanel2.ImagePaddingHorizontal = 8;
            this.btnPanel2.Name = "btnPanel2";
            this.btnPanel2.OptionGroup = "navBar";
            this.btnPanel2.Text = "تنظیمات پیش نمایش";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(0, -70);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 45);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "توقف Caprure";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAction
            // 
            this.btnAction.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAction.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAction.Location = new System.Drawing.Point(0, -50);
            this.btnAction.Name = "btnAction";
            this.btnAction.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.btnAction.Size = new System.Drawing.Size(102, 24);
            this.btnAction.TabIndex = 1;
            this.btnAction.Text = "Action";
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // frmPanelGraber
            // 
            this.AcceptButton = this.btnGrab;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(997, 561);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 506);
            this.Name = "frmPanelGraber";
            this.Opacity = 0.01;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نگار - سیستم مدیریت Capture تصاویر پزشكی";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MainPanel.ResumeLayout(false);
            this.LeftPanel.ResumeLayout(false);
            this.NavPane.ResumeLayout(false);
            this.GrabPanel.ResumeLayout(false);
            this.PanelSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx MainPanel;
        private DevComponents.DotNetBar.NavigationPane NavPane;
        private DevComponents.DotNetBar.NavigationPanePanel GrabPanel;
        private DevComponents.DotNetBar.ButtonItem btnPanel1;
        private System.Windows.Forms.Panel PreviewPanel;
        private DevComponents.DotNetBar.NavigationPanePanel PanelSettings;
        private DevComponents.DotNetBar.ButtonItem btnPanel2;
        private DevComponents.DotNetBar.ItemPanel lstVideoDevice;
        private DevComponents.DotNetBar.ItemPanel lstVideoVideoCompressors;
        private DevComponents.DotNetBar.ButtonItem btnNoneCompressor;
        private System.Windows.Forms.Panel LeftPanel;
        private DevComponents.DotNetBar.PanelEx btnGrab;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel PanelImages;
        private DevComponents.DotNetBar.ButtonX btnAction;

    }
}