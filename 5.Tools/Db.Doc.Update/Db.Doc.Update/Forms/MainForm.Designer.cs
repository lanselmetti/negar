namespace Sepehr.Forms
{
    partial class frmMainForm 
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.TabData = new DevComponents.DotNetBar.TabItem(this.components);
            this.TabFile = new DevComponents.DotNetBar.TabItem(this.components);
            this.TabFilter = new DevComponents.DotNetBar.TabItem(this.components);
            this.TLPInsurance = new System.Windows.Forms.TableLayoutPanel();
            this.cBoxPhysician = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblCategory = new DevComponents.DotNetBar.LabelX();
            this.lblInsurances = new DevComponents.DotNetBar.LabelX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.btnRegister = new DevComponents.DotNetBar.ButtonX();
            this.PanelFooter = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.pBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.BGWorkerSearchData = new System.ComponentModel.BackgroundWorker();
            this.PanelMain = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnSelectBankPath = new DevComponents.DotNetBar.ButtonX();
            this.lblBankPath = new DevComponents.DotNetBar.LabelX();
            this.txtFolderPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ofdAccess = new System.Windows.Forms.OpenFileDialog();
            this.PanelFooter.SuspendLayout();
            this.PanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabData
            // 
            this.TabData.Name = "TabData";
            this.TabData.Text = "فهرست مراجعات";
            // 
            // TabFile
            // 
            this.TabFile.Name = "TabFile";
            this.TabFile.Text = "ذخیره فایل";
            // 
            // TabFilter
            // 
            this.TabFilter.Name = "TabFilter";
            this.TabFilter.Text = "مشخصات كلی";
            // 
            // TLPInsurance
            // 
            this.TLPInsurance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TLPInsurance.BackColor = System.Drawing.Color.Transparent;
            this.TLPInsurance.ColumnCount = 3;
            this.TLPInsurance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPInsurance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPInsurance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPInsurance.Location = new System.Drawing.Point(0, 143);
            this.TLPInsurance.Name = "TLPInsurance";
            this.TLPInsurance.RowCount = 1;
            this.TLPInsurance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPInsurance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.TLPInsurance.Size = new System.Drawing.Size(783, 318);
            this.TLPInsurance.TabIndex = 166;
            // 
            // cBoxPhysician
            // 
            this.cBoxPhysician.AutoSize = true;
            this.cBoxPhysician.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxPhysician.Location = new System.Drawing.Point(157, 3);
            this.cBoxPhysician.Name = "cBoxPhysician";
            this.cBoxPhysician.Size = new System.Drawing.Size(95, 16);
            this.cBoxPhysician.TabIndex = 165;
            this.cBoxPhysician.Text = "پزشك مراجعه";
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.AutoSize = true;
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCategory.Location = new System.Drawing.Point(186, 3);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(0, 0);
            this.lblCategory.TabIndex = 153;
            this.lblCategory.Text = "نوع خدمات:";
            this.lblCategory.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblInsurances
            // 
            this.lblInsurances.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInsurances.AutoSize = true;
            this.lblInsurances.BackColor = System.Drawing.Color.Transparent;
            this.lblInsurances.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblInsurances.Location = new System.Drawing.Point(199, 3);
            this.lblInsurances.Name = "lblInsurances";
            this.lblInsurances.Size = new System.Drawing.Size(0, 0);
            this.lblInsurances.TabIndex = 153;
            this.lblInsurances.Text = "بیمه ها:";
            this.lblInsurances.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // btnRegister
            // 
            this.btnRegister.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRegister.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRegister.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRegister.Image = global::Sepehr.Properties.Resources.Accept_Logo;
            this.btnRegister.Location = new System.Drawing.Point(13, 9);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(95, 57);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.TabStop = false;
            this.btnRegister.Text = "ثبت در بانك";
            this.btnRegister.Click += new System.EventHandler(this.btnMakeReport_Click);
            // 
            // PanelFooter
            // 
            this.PanelFooter.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelFooter.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelFooter.Controls.Add(this.pBar);
            this.PanelFooter.Controls.Add(this.btnRegister);
            this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelFooter.Location = new System.Drawing.Point(0, 57);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(415, 75);
            // 
            // 
            // 
            this.PanelFooter.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.PanelFooter.Style.BackColorGradientAngle = 90;
            this.PanelFooter.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.PanelFooter.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile;
            this.PanelFooter.Style.BorderBottomWidth = 1;
            this.PanelFooter.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.PanelFooter.Style.BorderLeftWidth = 1;
            this.PanelFooter.Style.BorderRightWidth = 1;
            this.PanelFooter.Style.BorderTopWidth = 1;
            this.PanelFooter.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelFooter.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.PanelFooter.TabIndex = 1;
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBar.Location = new System.Drawing.Point(114, 26);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(289, 23);
            this.pBar.TabIndex = 2;
            this.pBar.TextVisible = true;
            // 
            // BGWorkerSearchData
            // 
            this.BGWorkerSearchData.WorkerReportsProgress = true;
            this.BGWorkerSearchData.WorkerSupportsCancellation = true;
            this.BGWorkerSearchData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorkerSearchData_DoWork);
            this.BGWorkerSearchData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorkerSearchData_RunWorkerCompleted);
            this.BGWorkerSearchData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWorkerSearchData_ProgressChanged);
            // 
            // PanelMain
            // 
            this.PanelMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelMain.Controls.Add(this.btnSelectBankPath);
            this.PanelMain.Controls.Add(this.lblBankPath);
            this.PanelMain.Controls.Add(this.txtFolderPath);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(415, 132);
            // 
            // 
            // 
            this.PanelMain.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.PanelMain.Style.BackColorGradientAngle = 90;
            this.PanelMain.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.PanelMain.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile;
            this.PanelMain.Style.BorderBottomWidth = 1;
            this.PanelMain.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.PanelMain.Style.BorderLeftWidth = 1;
            this.PanelMain.Style.BorderRightWidth = 1;
            this.PanelMain.Style.BorderTopWidth = 1;
            this.PanelMain.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelMain.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.PanelMain.TabIndex = 0;
            // 
            // btnSelectBankPath
            // 
            this.btnSelectBankPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectBankPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectBankPath.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnSelectBankPath.Image = global::Sepehr.Properties.Resources.Browse;
            this.btnSelectBankPath.Location = new System.Drawing.Point(15, 8);
            this.btnSelectBankPath.Name = "btnSelectBankPath";
            this.btnSelectBankPath.Size = new System.Drawing.Size(40, 40);
            this.btnSelectBankPath.TabIndex = 0;
            this.btnSelectBankPath.Click += new System.EventHandler(this.btnSelectBankPath_Click);
            // 
            // lblBankPath
            // 
            this.lblBankPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBankPath.AutoSize = true;
            this.lblBankPath.BackColor = System.Drawing.Color.Transparent;
            this.lblBankPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBankPath.Location = new System.Drawing.Point(300, 20);
            this.lblBankPath.Name = "lblBankPath";
            this.lblBankPath.Size = new System.Drawing.Size(102, 16);
            this.lblBankPath.TabIndex = 2;
            this.lblBankPath.Text = "آدرس پوشه انتقال:";
            this.lblBankPath.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderPath.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFolderPath.Border.Class = "TextBoxBorder";
            this.txtFolderPath.Location = new System.Drawing.Point(61, 18);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFolderPath.Size = new System.Drawing.Size(233, 21);
            this.txtFolderPath.TabIndex = 1;
            this.txtFolderPath.Text = "C:\\DocServer\\";
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(415, 132);
            this.Controls.Add(this.PanelFooter);
            this.Controls.Add(this.PanelMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "رایان پرتونگار - انتقال مدارك بیماران به هارد - جهت ارتقاء";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelFooter.ResumeLayout(false);
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabItem TabFilter;
        private DevComponents.DotNetBar.TabItem TabFile;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxPhysician;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.LabelX lblCategory;
        private DevComponents.DotNetBar.LabelX lblInsurances;
        private System.Windows.Forms.TableLayoutPanel TLPInsurance;
        private DevComponents.DotNetBar.TabItem TabData;
        internal DevComponents.DotNetBar.ButtonX btnRegister;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelFooter;
        private System.ComponentModel.BackgroundWorker BGWorkerSearchData;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelMain;
        private DevComponents.DotNetBar.ButtonX btnSelectBankPath;
        private DevComponents.DotNetBar.LabelX lblBankPath;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFolderPath;
        private System.Windows.Forms.OpenFileDialog ofdAccess;
        private DevComponents.DotNetBar.Controls.ProgressBarX pBar;
    }
}