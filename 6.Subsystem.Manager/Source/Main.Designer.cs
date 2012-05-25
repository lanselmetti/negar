namespace Negar
{
    partial class frmMain
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
            System.Windows.Forms.Label lblFooter2;
            System.Windows.Forms.Label lblFooterLast;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cBoxMakeNewConnection = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxUseSavedSettings = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtSettingName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNewServerName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNewServerSQLInstanceName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.WizardControl = new DevComponents.DotNetBar.Wizard();
            this.WPage1 = new DevComponents.DotNetBar.WizardPage();
            this.lblHeaderP1 = new System.Windows.Forms.Label();
            this.lblP1Desc1 = new System.Windows.Forms.Label();
            this.dgvConnections = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ColServerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFooter1 = new System.Windows.Forms.Label();
            this.WPage2 = new DevComponents.DotNetBar.WizardPage();
            this.PanelConnectionChooser = new System.Windows.Forms.Panel();
            this.cBoxUseLocalServer = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxUseServerNameOrIP = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pBoxConnectionSettings = new System.Windows.Forms.PictureBox();
            this.lblHeaderP2 = new System.Windows.Forms.Label();
            this.lblSettingName = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblSQLInstance = new System.Windows.Forms.Label();
            this.WPage3 = new DevComponents.DotNetBar.WizardPage();
            this.btnSubSystemPath = new DevComponents.DotNetBar.ButtonX();
            this.btnDeletePhysicalFile = new DevComponents.DotNetBar.ButtonX();
            this.lblHeaderP3 = new System.Windows.Forms.Label();
            this.lblInstalledSoftwares = new System.Windows.Forms.Label();
            this.cboInstalledApps = new System.Windows.Forms.ComboBox();
            this.lblAppDescription = new System.Windows.Forms.Label();
            this.lblP3Desc1 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.cboUserName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cBoxSaveLastAuthentication = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pBoxLogin = new System.Windows.Forms.PictureBox();
            this.OpenFileDialogForm = new System.Windows.Forms.OpenFileDialog();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            lblFooter2 = new System.Windows.Forms.Label();
            lblFooterLast = new System.Windows.Forms.Label();
            this.WizardControl.SuspendLayout();
            this.WPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConnections)).BeginInit();
            this.WPage2.SuspendLayout();
            this.PanelConnectionChooser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxConnectionSettings)).BeginInit();
            this.WPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormPanel)).BeginInit();
            this.FormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFooter2
            // 
            lblFooter2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            lblFooter2.AutoSize = true;
            lblFooter2.Location = new System.Drawing.Point(218, 188);
            lblFooter2.Name = "lblFooter2";
            lblFooter2.Size = new System.Drawing.Size(219, 13);
            lblFooter2.TabIndex = 8;
            lblFooter2.Text = "برای ادامه ، بر روی دكمه ی بعدی كلیك نمایید.";
            // 
            // lblFooterLast
            // 
            lblFooterLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            lblFooterLast.AutoSize = true;
            lblFooterLast.Location = new System.Drawing.Point(218, 188);
            lblFooterLast.Name = "lblFooterLast";
            lblFooterLast.Size = new System.Drawing.Size(220, 13);
            lblFooterLast.TabIndex = 9;
            lblFooterLast.Text = "برای ادامه ، بر روی دكمه ی خاتمه كلیك نمایید.";
            // 
            // cBoxMakeNewConnection
            // 
            this.cBoxMakeNewConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxMakeNewConnection.AutoSize = true;
            this.cBoxMakeNewConnection.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxMakeNewConnection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxMakeNewConnection.Location = new System.Drawing.Point(334, 67);
            this.cBoxMakeNewConnection.Name = "cBoxMakeNewConnection";
            this.cBoxMakeNewConnection.Size = new System.Drawing.Size(109, 16);
            this.cBoxMakeNewConnection.TabIndex = 0;
            this.cBoxMakeNewConnection.Text = "ایجاد اتصال جدید";
            this.cBoxMakeNewConnection.TextColor = System.Drawing.Color.GreenYellow;
            this.cBoxMakeNewConnection.CheckedChanged += new System.EventHandler(this.cBoxMakeNewConnection_CheckedChanged);
            // 
            // cBoxUseSavedSettings
            // 
            this.cBoxUseSavedSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxUseSavedSettings.AutoSize = true;
            this.cBoxUseSavedSettings.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxUseSavedSettings.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxUseSavedSettings.Location = new System.Drawing.Point(183, 67);
            this.cBoxUseSavedSettings.Name = "cBoxUseSavedSettings";
            this.cBoxUseSavedSettings.Size = new System.Drawing.Size(143, 16);
            this.cBoxUseSavedSettings.TabIndex = 1;
            this.cBoxUseSavedSettings.Text = "استفاده از آخرین اتصال";
            this.cBoxUseSavedSettings.TextColor = System.Drawing.Color.GreenYellow;
            // 
            // txtSettingName
            // 
            this.txtSettingName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSettingName.Border.Class = "TextBoxBorder";
            this.txtSettingName.Location = new System.Drawing.Point(191, 21);
            this.txtSettingName.Name = "txtSettingName";
            this.txtSettingName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSettingName.Size = new System.Drawing.Size(232, 21);
            this.txtSettingName.TabIndex = 0;
            this.txtSettingName.Tag = "";
            this.txtSettingName.Text = "اتصال به سرور محلی";
            // 
            // txtNewServerName
            // 
            this.txtNewServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewServerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNewServerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNewServerName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNewServerName.Border.Class = "TextBoxBorder";
            this.txtNewServerName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNewServerName.Location = new System.Drawing.Point(191, 106);
            this.txtNewServerName.Name = "txtNewServerName";
            this.txtNewServerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNewServerName.Size = new System.Drawing.Size(130, 21);
            this.txtNewServerName.TabIndex = 5;
            this.txtNewServerName.Tag = "ServerName";
            this.txtNewServerName.Text = "Negar01";
            // 
            // txtNewServerSQLInstanceName
            // 
            this.txtNewServerSQLInstanceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewServerSQLInstanceName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNewServerSQLInstanceName.Border.Class = "TextBoxBorder";
            this.txtNewServerSQLInstanceName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNewServerSQLInstanceName.Location = new System.Drawing.Point(191, 133);
            this.txtNewServerSQLInstanceName.Name = "txtNewServerSQLInstanceName";
            this.txtNewServerSQLInstanceName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNewServerSQLInstanceName.Size = new System.Drawing.Size(130, 21);
            this.txtNewServerSQLInstanceName.TabIndex = 7;
            this.txtNewServerSQLInstanceName.Text = "NegarServer01";
            // 
            // WizardControl
            // 
            this.WizardControl.BackButtonText = "< قبلی";
            this.WizardControl.BackColor = System.Drawing.Color.Transparent;
            this.WizardControl.ButtonStyle = DevComponents.DotNetBar.eWizardStyle.Office2007;
            this.WizardControl.CancelButtonText = "انصراف";
            this.WizardControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.WizardControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WizardControl.FinishButtonTabIndex = 3;
            this.WizardControl.FinishButtonText = "خاتمه";
            this.WizardControl.FooterHeight = 40;
            // 
            // 
            // 
            this.WizardControl.FooterStyle.BackColor = System.Drawing.Color.Transparent;
            this.WizardControl.FooterStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.WizardControl.FooterStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WizardControl.ForeColor = System.Drawing.Color.White;
            this.WizardControl.HeaderCaptionFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WizardControl.HeaderDescriptionIndent = 56;
            this.WizardControl.HeaderHeight = 55;
            this.WizardControl.HeaderImage = global::Negar.Properties.Resources.Server_Icon;
            this.WizardControl.HeaderImageAlignment = DevComponents.DotNetBar.eWizardTitleImageAlignment.Left;
            // 
            // 
            // 
            this.WizardControl.HeaderStyle.BackColor = System.Drawing.Color.Transparent;
            this.WizardControl.HeaderStyle.BackColorGradientAngle = 90;
            this.WizardControl.HeaderStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.WizardControl.HeaderStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(157)))), ((int)(((byte)(182)))));
            this.WizardControl.HeaderStyle.BorderBottomWidth = 1;
            this.WizardControl.HeaderStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.WizardControl.HeaderStyle.BorderLeftWidth = 1;
            this.WizardControl.HeaderStyle.BorderRightWidth = 1;
            this.WizardControl.HeaderStyle.BorderTopWidth = 1;
            this.WizardControl.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.WizardControl.HeaderStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.WizardControl.HeaderStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WizardControl.HeaderStyle.TextShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.WizardControl.HeaderTitleIndent = 56;
            this.WizardControl.HelpButtonText = "راهنمایی";
            this.WizardControl.Location = new System.Drawing.Point(0, 0);
            this.WizardControl.Name = "WizardControl";
            this.WizardControl.NextButtonText = "بعدی >";
            this.WizardControl.Size = new System.Drawing.Size(465, 323);
            this.WizardControl.TabIndex = 0;
            this.WizardControl.WizardPages.AddRange(new DevComponents.DotNetBar.WizardPage[] {
            this.WPage1,
            this.WPage2,
            this.WPage3});
            this.WizardControl.CancelButtonClick += new System.ComponentModel.CancelEventHandler(this.WizardControl_CancelButtonClick);
            // 
            // WPage1
            // 
            this.WPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WPage1.BackColor = System.Drawing.Color.Transparent;
            this.WPage1.CanvasColor = System.Drawing.Color.Empty;
            this.WPage1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.WPage1.Controls.Add(this.lblHeaderP1);
            this.WPage1.Controls.Add(this.lblP1Desc1);
            this.WPage1.Controls.Add(this.cBoxMakeNewConnection);
            this.WPage1.Controls.Add(this.cBoxUseSavedSettings);
            this.WPage1.Controls.Add(this.dgvConnections);
            this.WPage1.Controls.Add(this.lblFooter1);
            this.WPage1.Location = new System.Drawing.Point(7, 67);
            this.WPage1.Name = "WPage1";
            this.WPage1.PageDescription = "انتخاب اتصال ذخیره شده یا ایجاد اتصال جدید.";
            this.WPage1.PageTitle = "سیستم مدیریت اتصال به نرم افزارهای پزشكی نگار";
            this.WPage1.Size = new System.Drawing.Size(451, 204);
            this.WPage1.TabIndex = 0;
            this.WPage1.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.WPage1_NextButtonClick);
            // 
            // lblHeaderP1
            // 
            this.lblHeaderP1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderP1.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderP1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHeaderP1.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblHeaderP1.Location = new System.Drawing.Point(0, 1);
            this.lblHeaderP1.Name = "lblHeaderP1";
            this.lblHeaderP1.Size = new System.Drawing.Size(450, 19);
            this.lblHeaderP1.TabIndex = 4;
            this.lblHeaderP1.Text = "این بخش به شما برای اتصال به بانك اطلاعاتی نرم افزار مورد نظرتان كمك می نماید.";
            // 
            // lblP1Desc1
            // 
            this.lblP1Desc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblP1Desc1.BackColor = System.Drawing.Color.Transparent;
            this.lblP1Desc1.ForeColor = System.Drawing.Color.LightCyan;
            this.lblP1Desc1.Location = new System.Drawing.Point(6, 21);
            this.lblP1Desc1.Name = "lblP1Desc1";
            this.lblP1Desc1.Size = new System.Drawing.Size(440, 42);
            this.lblP1Desc1.TabIndex = 5;
            this.lblP1Desc1.Text = resources.GetString("lblP1Desc1.Text");
            // 
            // dgvConnections
            // 
            this.dgvConnections.AllowUserToAddRows = false;
            this.dgvConnections.AllowUserToResizeColumns = false;
            this.dgvConnections.AllowUserToResizeRows = false;
            this.dgvConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConnections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConnections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColServerAddress,
            this.ColSettingName});
            this.dgvConnections.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dgvConnections.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.dgvConnections.HideOuterBorders = true;
            this.dgvConnections.Location = new System.Drawing.Point(6, 89);
            this.dgvConnections.MultiSelect = false;
            this.dgvConnections.Name = "dgvConnections";
            this.dgvConnections.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.dgvConnections.ReadOnly = true;
            this.dgvConnections.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvConnections.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvConnections.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConnections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConnections.Size = new System.Drawing.Size(436, 96);
            this.dgvConnections.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.dgvConnections.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvConnections.StateCommon.HeaderColumn.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.dgvConnections.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.MintCream;
            this.dgvConnections.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.LightSkyBlue;
            this.dgvConnections.StateSelected.DataCell.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounded;
            this.dgvConnections.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.Navy;
            this.dgvConnections.TabIndex = 3;
            this.dgvConnections.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvConnections_UserDeletingRow);
            this.dgvConnections.SelectionChanged += new System.EventHandler(this.dgvConnections_SelectionChanged);
            // 
            // ColServerAddress
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.ColServerAddress.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColServerAddress.HeaderText = "آدرس سرور";
            this.ColServerAddress.Name = "ColServerAddress";
            this.ColServerAddress.ReadOnly = true;
            this.ColServerAddress.Width = 200;
            // 
            // ColSettingName
            // 
            this.ColSettingName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColSettingName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColSettingName.HeaderText = "اتصالات ذخیره شده";
            this.ColSettingName.Name = "ColSettingName";
            this.ColSettingName.ReadOnly = true;
            // 
            // lblFooter1
            // 
            this.lblFooter1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFooter1.AutoSize = true;
            this.lblFooter1.Location = new System.Drawing.Point(218, 188);
            this.lblFooter1.Name = "lblFooter1";
            this.lblFooter1.Size = new System.Drawing.Size(219, 13);
            this.lblFooter1.TabIndex = 6;
            this.lblFooter1.Text = "برای ادامه ، بر روی دكمه ی بعدی كلیك نمایید.";
            // 
            // WPage2
            // 
            this.WPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WPage2.AntiAlias = false;
            this.WPage2.BackColor = System.Drawing.Color.Transparent;
            this.WPage2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.WPage2.Controls.Add(this.PanelConnectionChooser);
            this.WPage2.Controls.Add(this.pBoxConnectionSettings);
            this.WPage2.Controls.Add(this.lblHeaderP2);
            this.WPage2.Controls.Add(this.lblSettingName);
            this.WPage2.Controls.Add(this.txtSettingName);
            this.WPage2.Controls.Add(this.lblServerName);
            this.WPage2.Controls.Add(this.txtNewServerName);
            this.WPage2.Controls.Add(this.lblSQLInstance);
            this.WPage2.Controls.Add(this.txtNewServerSQLInstanceName);
            this.WPage2.Controls.Add(lblFooter2);
            this.WPage2.Location = new System.Drawing.Point(7, 67);
            this.WPage2.Name = "WPage2";
            this.WPage2.PageDescription = "ایجاد تنظیمات اتصال جدید.";
            this.WPage2.PageTitle = "سیستم مدیریت اتصال به نرم افزارهای پزشكی نگار";
            this.WPage2.Size = new System.Drawing.Size(451, 204);
            this.WPage2.TabIndex = 0;
            this.WPage2.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.WPage2_NextButtonClick);
            this.WPage2.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.WPage2_AfterPageDisplayed);
            // 
            // PanelConnectionChooser
            // 
            this.PanelConnectionChooser.Controls.Add(this.cBoxUseLocalServer);
            this.PanelConnectionChooser.Controls.Add(this.cBoxUseServerNameOrIP);
            this.PanelConnectionChooser.Location = new System.Drawing.Point(191, 48);
            this.PanelConnectionChooser.Name = "PanelConnectionChooser";
            this.PanelConnectionChooser.Size = new System.Drawing.Size(255, 52);
            this.PanelConnectionChooser.TabIndex = 3;
            this.PanelConnectionChooser.TabStop = true;
            // 
            // cBoxUseLocalServer
            // 
            this.cBoxUseLocalServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxUseLocalServer.AutoSize = true;
            this.cBoxUseLocalServer.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxUseLocalServer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxUseLocalServer.Location = new System.Drawing.Point(119, 6);
            this.cBoxUseLocalServer.Name = "cBoxUseLocalServer";
            this.cBoxUseLocalServer.Size = new System.Drawing.Size(133, 16);
            this.cBoxUseLocalServer.TabIndex = 0;
            this.cBoxUseLocalServer.Text = "اتصال به سرور محلی";
            this.cBoxUseLocalServer.TextColor = System.Drawing.Color.GreenYellow;
            this.cBoxUseLocalServer.CheckedChanged += new System.EventHandler(this.cBoxUseLocalServer_CheckedChanged);
            // 
            // cBoxUseServerNameOrIP
            // 
            this.cBoxUseServerNameOrIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxUseServerNameOrIP.AutoSize = true;
            this.cBoxUseServerNameOrIP.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxUseServerNameOrIP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxUseServerNameOrIP.Location = new System.Drawing.Point(27, 28);
            this.cBoxUseServerNameOrIP.Name = "cBoxUseServerNameOrIP";
            this.cBoxUseServerNameOrIP.Size = new System.Drawing.Size(225, 16);
            this.cBoxUseServerNameOrIP.TabIndex = 1;
            this.cBoxUseServerNameOrIP.TabStop = false;
            this.cBoxUseServerNameOrIP.Text = "وارد كردن نام كامپیوتر سرور یا آدرس آن";
            this.cBoxUseServerNameOrIP.TextColor = System.Drawing.Color.GreenYellow;
            this.cBoxUseServerNameOrIP.CheckedChanged += new System.EventHandler(this.cBoxUseExternalServer_CheckedChanged);
            // 
            // pBoxConnectionSettings
            // 
            this.pBoxConnectionSettings.Image = global::Negar.Properties.Resources.Server;
            this.pBoxConnectionSettings.Location = new System.Drawing.Point(5, 21);
            this.pBoxConnectionSettings.Name = "pBoxConnectionSettings";
            this.pBoxConnectionSettings.Size = new System.Drawing.Size(180, 180);
            this.pBoxConnectionSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxConnectionSettings.TabIndex = 12;
            this.pBoxConnectionSettings.TabStop = false;
            // 
            // lblHeaderP2
            // 
            this.lblHeaderP2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderP2.AutoSize = true;
            this.lblHeaderP2.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderP2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHeaderP2.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblHeaderP2.Location = new System.Drawing.Point(150, 0);
            this.lblHeaderP2.Name = "lblHeaderP2";
            this.lblHeaderP2.Size = new System.Drawing.Size(293, 13);
            this.lblHeaderP2.TabIndex = 2;
            this.lblHeaderP2.Text = "تنظیمات مربوط به اتصال به بانك اطلاعاتی را وارد نمایید.";
            // 
            // lblSettingName
            // 
            this.lblSettingName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSettingName.AutoSize = true;
            this.lblSettingName.BackColor = System.Drawing.Color.Transparent;
            this.lblSettingName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSettingName.Location = new System.Drawing.Point(424, 25);
            this.lblSettingName.Name = "lblSettingName";
            this.lblSettingName.Size = new System.Drawing.Size(25, 13);
            this.lblSettingName.TabIndex = 1;
            this.lblSettingName.Tag = "";
            this.lblSettingName.Text = "نام:";
            // 
            // lblServerName
            // 
            this.lblServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerName.AutoSize = true;
            this.lblServerName.BackColor = System.Drawing.Color.Transparent;
            this.lblServerName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblServerName.ForeColor = System.Drawing.Color.White;
            this.lblServerName.Location = new System.Drawing.Point(322, 110);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(116, 13);
            this.lblServerName.TabIndex = 4;
            this.lblServerName.Tag = "ServerName";
            this.lblServerName.Text = "نام سرور یا آدرس IP:";
            // 
            // lblSQLInstance
            // 
            this.lblSQLInstance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSQLInstance.AutoSize = true;
            this.lblSQLInstance.BackColor = System.Drawing.Color.Transparent;
            this.lblSQLInstance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSQLInstance.ForeColor = System.Drawing.Color.White;
            this.lblSQLInstance.Location = new System.Drawing.Point(322, 135);
            this.lblSQLInstance.Name = "lblSQLInstance";
            this.lblSQLInstance.Size = new System.Drawing.Size(132, 13);
            this.lblSQLInstance.TabIndex = 6;
            this.lblSQLInstance.Text = "نام نمونه بانك اطلاعاتی:";
            // 
            // WPage3
            // 
            this.WPage3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WPage3.AntiAlias = false;
            this.WPage3.BackColor = System.Drawing.Color.Transparent;
            this.WPage3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.WPage3.Controls.Add(this.btnSubSystemPath);
            this.WPage3.Controls.Add(this.btnDeletePhysicalFile);
            this.WPage3.Controls.Add(this.lblHeaderP3);
            this.WPage3.Controls.Add(this.lblInstalledSoftwares);
            this.WPage3.Controls.Add(this.cboInstalledApps);
            this.WPage3.Controls.Add(this.lblAppDescription);
            this.WPage3.Controls.Add(this.lblP3Desc1);
            this.WPage3.Controls.Add(this.lblUserName);
            this.WPage3.Controls.Add(this.cboUserName);
            this.WPage3.Controls.Add(this.lblPassword);
            this.WPage3.Controls.Add(this.txtPassword);
            this.WPage3.Controls.Add(this.cBoxSaveLastAuthentication);
            this.WPage3.Controls.Add(lblFooterLast);
            this.WPage3.Controls.Add(this.pBoxLogin);
            this.WPage3.Location = new System.Drawing.Point(7, 67);
            this.WPage3.Name = "WPage3";
            this.WPage3.PageDescription = "انتخاب نرم افزار و ورود نام كاربری و رمز عبور.";
            this.WPage3.PageTitle = "سیستم مدیریت اتصال به نرم افزارهای پزشكی نگار";
            this.WPage3.Size = new System.Drawing.Size(451, 204);
            this.WPage3.TabIndex = 0;
            this.WPage3.BackButtonClick += new System.ComponentModel.CancelEventHandler(this.WPage3_BackButtonClick);
            this.WPage3.FinishButtonClick += new System.ComponentModel.CancelEventHandler(this.WPage3_FinishButtonClick);
            this.WPage3.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.WPage3_AfterPageDisplayed);
            // 
            // btnSubSystemPath
            // 
            this.btnSubSystemPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSubSystemPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSubSystemPath.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSubSystemPath.Image = global::Negar.Properties.Resources.HowTo;
            this.btnSubSystemPath.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnSubSystemPath.Location = new System.Drawing.Point(200, 39);
            this.btnSubSystemPath.Name = "btnSubSystemPath";
            this.btnSubSystemPath.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnSubSystemPath.Size = new System.Drawing.Size(21, 21);
            this.btnSubSystemPath.TabIndex = 81;
            this.btnSubSystemPath.TabStop = false;
            this.btnSubSystemPath.Click += new System.EventHandler(this.btnSubSystemPath_Click);
            // 
            // btnDeletePhysicalFile
            // 
            this.btnDeletePhysicalFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeletePhysicalFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeletePhysicalFile.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeletePhysicalFile.Image = global::Negar.Properties.Resources.DeleteSmall;
            this.btnDeletePhysicalFile.Location = new System.Drawing.Point(200, 62);
            this.btnDeletePhysicalFile.Name = "btnDeletePhysicalFile";
            this.btnDeletePhysicalFile.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnDeletePhysicalFile.Size = new System.Drawing.Size(21, 21);
            this.btnDeletePhysicalFile.TabIndex = 81;
            this.btnDeletePhysicalFile.TabStop = false;
            this.btnDeletePhysicalFile.Visible = false;
            this.btnDeletePhysicalFile.Click += new System.EventHandler(this.btnDeletePhysicalFile_Click);
            // 
            // lblHeaderP3
            // 
            this.lblHeaderP3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderP3.AutoSize = true;
            this.lblHeaderP3.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderP3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHeaderP3.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblHeaderP3.Location = new System.Drawing.Point(74, -2);
            this.lblHeaderP3.Name = "lblHeaderP3";
            this.lblHeaderP3.Size = new System.Drawing.Size(369, 13);
            this.lblHeaderP3.TabIndex = 2;
            this.lblHeaderP3.Text = "پس از انتخاب نرم افزار مورد نظر ، نام كاربری و كلمه عبور را وارد نمایید.";
            // 
            // lblInstalledSoftwares
            // 
            this.lblInstalledSoftwares.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstalledSoftwares.AutoSize = true;
            this.lblInstalledSoftwares.BackColor = System.Drawing.Color.Transparent;
            this.lblInstalledSoftwares.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblInstalledSoftwares.Location = new System.Drawing.Point(308, 20);
            this.lblInstalledSoftwares.Name = "lblInstalledSoftwares";
            this.lblInstalledSoftwares.Size = new System.Drawing.Size(138, 13);
            this.lblInstalledSoftwares.TabIndex = 1;
            this.lblInstalledSoftwares.Text = "نرم افزار های نصب شده:";
            // 
            // cboInstalledApps
            // 
            this.cboInstalledApps.DisplayMember = "LocalizedName";
            this.cboInstalledApps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInstalledApps.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboInstalledApps.FormattingEnabled = true;
            this.cboInstalledApps.Location = new System.Drawing.Point(222, 39);
            this.cboInstalledApps.Name = "cboInstalledApps";
            this.cboInstalledApps.Size = new System.Drawing.Size(224, 21);
            this.cboInstalledApps.TabIndex = 0;
            this.cboInstalledApps.ValueMember = "ID";
            this.cboInstalledApps.SelectedIndexChanged += new System.EventHandler(this.cboInstalledApps_SelectedIndexChanged);
            // 
            // lblAppDescription
            // 
            this.lblAppDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblAppDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppDescription.ForeColor = System.Drawing.Color.White;
            this.lblAppDescription.Location = new System.Drawing.Point(192, 62);
            this.lblAppDescription.Name = "lblAppDescription";
            this.lblAppDescription.Size = new System.Drawing.Size(254, 27);
            this.lblAppDescription.TabIndex = 10;
            // 
            // lblP3Desc1
            // 
            this.lblP3Desc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblP3Desc1.AutoSize = true;
            this.lblP3Desc1.BackColor = System.Drawing.Color.Transparent;
            this.lblP3Desc1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblP3Desc1.Location = new System.Drawing.Point(259, 94);
            this.lblP3Desc1.Name = "lblP3Desc1";
            this.lblP3Desc1.Size = new System.Drawing.Size(187, 13);
            this.lblP3Desc1.TabIndex = 3;
            this.lblP3Desc1.Text = "نام كاربری و رمز عبور را وارد نمایید.";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUserName.ForeColor = System.Drawing.Color.Cyan;
            this.lblUserName.Location = new System.Drawing.Point(356, 117);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(64, 13);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.Text = "نام كاربری:";
            // 
            // cboUserName
            // 
            this.cboUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUserName.DisplayMember = "UserName";
            this.cboUserName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboUserName.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboUserName.FormattingEnabled = true;
            this.cboUserName.Location = new System.Drawing.Point(200, 114);
            this.cboUserName.Name = "cboUserName";
            this.cboUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboUserName.Size = new System.Drawing.Size(150, 22);
            this.cboUserName.TabIndex = 4;
            this.cboUserName.ValueMember = "ID";
            this.cboUserName.Leave += new System.EventHandler(this.cboUserName_Leave);
            this.cboUserName.Enter += new System.EventHandler(this.txtAuthentications_Enter);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPassword.ForeColor = System.Drawing.Color.LightSalmon;
            this.lblPassword.Location = new System.Drawing.Point(356, 145);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "رمز عبور:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Location = new System.Drawing.Point(200, 143);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(150, 21);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Enter += new System.EventHandler(this.txtAuthentications_Enter);
            // 
            // cBoxSaveLastAuthentication
            // 
            this.cBoxSaveLastAuthentication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSaveLastAuthentication.AutoSize = true;
            this.cBoxSaveLastAuthentication.Location = new System.Drawing.Point(340, 166);
            this.cBoxSaveLastAuthentication.Name = "cBoxSaveLastAuthentication";
            this.cBoxSaveLastAuthentication.Size = new System.Drawing.Size(98, 16);
            this.cBoxSaveLastAuthentication.TabIndex = 8;
            this.cBoxSaveLastAuthentication.Text = "ذخیره نام كاربری";
            this.cBoxSaveLastAuthentication.TextColor = System.Drawing.Color.GreenYellow;
            // 
            // pBoxLogin
            // 
            this.pBoxLogin.Image = global::Negar.Properties.Resources.Profile;
            this.pBoxLogin.Location = new System.Drawing.Point(5, 23);
            this.pBoxLogin.Name = "pBoxLogin";
            this.pBoxLogin.Size = new System.Drawing.Size(180, 180);
            this.pBoxLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxLogin.TabIndex = 9;
            this.pBoxLogin.TabStop = false;
            this.pBoxLogin.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pBoxLogin_MouseDoubleClick);
            // 
            // OpenFileDialogForm
            // 
            this.OpenFileDialogForm.DefaultExt = "*.exe";
            this.OpenFileDialogForm.Filter = "فایل های اجرایی | *.exe";
            this.OpenFileDialogForm.InitialDirectory = "C:\\";
            this.OpenFileDialogForm.RestoreDirectory = true;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // FormPanel
            // 
            this.FormPanel.Controls.Add(this.WizardControl);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.FormPanel.Size = new System.Drawing.Size(465, 323);
            this.FormPanel.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(465, 323);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Opacity = 0.01;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نگار - نرم افزار مدیریت زیرسیستم های پزشكی";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.WizardControl.ResumeLayout(false);
            this.WPage1.ResumeLayout(false);
            this.WPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConnections)).EndInit();
            this.WPage2.ResumeLayout(false);
            this.WPage2.PerformLayout();
            this.PanelConnectionChooser.ResumeLayout(false);
            this.PanelConnectionChooser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxConnectionSettings)).EndInit();
            this.WPage3.ResumeLayout(false);
            this.WPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormPanel)).EndInit();
            this.FormPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.WizardPage WPage1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxUseSavedSettings;
        private System.Windows.Forms.Label lblHeaderP1;
        private DevComponents.DotNetBar.WizardPage WPage2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNewServerSQLInstanceName;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxUseServerNameOrIP;
        private System.Windows.Forms.Label lblSQLInstance;
        private DevComponents.DotNetBar.WizardPage WPage3;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxSaveLastAuthentication;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassword;
        private System.Windows.Forms.Label lblP3Desc1;
        private System.Windows.Forms.PictureBox pBoxLogin;
        private System.Windows.Forms.Label lblInstalledSoftwares;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNewServerName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblHeaderP2;
        private System.Windows.Forms.PictureBox pBoxConnectionSettings;
        private System.Windows.Forms.Label lblHeaderP3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboUserName;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxUseLocalServer;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblFooter1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxMakeNewConnection;
        private System.Windows.Forms.Label lblP1Desc1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvConnections;
        private System.Windows.Forms.ComboBox cboInstalledApps;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSettingName;
        private System.Windows.Forms.Label lblSettingName;
        private DevComponents.DotNetBar.Wizard WizardControl;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogForm;
        private System.Windows.Forms.Label lblAppDescription;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private System.Windows.Forms.Panel PanelConnectionChooser;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel FormPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServerAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettingName;
        private DevComponents.DotNetBar.ButtonX btnDeletePhysicalFile;
        private DevComponents.DotNetBar.ButtonX btnSubSystemPath;

    }
}