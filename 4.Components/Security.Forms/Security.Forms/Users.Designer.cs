namespace Negar.Security
{
    partial class frmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.cmsUsers = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsUsersManage = new DevComponents.DotNetBar.ButtonItem();
            this.btnResetPassword = new DevComponents.DotNetBar.ButtonItem();
            this.cBoxWithInActives = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMustChangePassword = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnApply = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.cmsUsers);
            this.FormPanel.Controls.Add(this.cBoxWithInActives);
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnAdd);
            this.FormPanel.Controls.Add(this.btnApply);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnAccept);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(794, 574);
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
            // cmsUsers
            // 
            this.cmsUsers.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.cmsUsers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsUsers.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsUsersManage});
            this.cmsUsers.Location = new System.Drawing.Point(527, 505);
            this.cmsUsers.Name = "cmsUsers";
            this.cmsUsers.Size = new System.Drawing.Size(55, 25);
            this.cmsUsers.Stretch = true;
            this.cmsUsers.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsUsers.TabIndex = 10;
            this.cmsUsers.TabStop = false;
            // 
            // cmsUsersManage
            // 
            this.cmsUsersManage.AutoExpandOnClick = true;
            this.cmsUsersManage.ImagePaddingHorizontal = 8;
            this.cmsUsersManage.Name = "cmsUsersManage";
            this.cmsUsersManage.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnResetPassword});
            this.cmsUsersManage.Text = "منو";
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Image = ((System.Drawing.Image)(resources.GetObject("btnResetPassword.Image")));
            this.btnResetPassword.ImagePaddingHorizontal = 8;
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.btnResetPassword.Text = "<b>بازنویسی كلمه عبور</b>\r\n<div></div>\r\n<font color=\"#000000\">تغییر كلمه عبور كار" +
                "بر.</font>";
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // cBoxWithInActives
            // 
            this.cBoxWithInActives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxWithInActives.AutoSize = true;
            this.cBoxWithInActives.BackColor = System.Drawing.Color.Transparent;
            this.cBoxWithInActives.Checked = true;
            this.cBoxWithInActives.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxWithInActives.CheckValue = "Y";
            this.cBoxWithInActives.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxWithInActives.Location = new System.Drawing.Point(638, 483);
            this.cBoxWithInActives.Name = "cBoxWithInActives";
            this.cBoxWithInActives.Size = new System.Drawing.Size(145, 16);
            this.cBoxWithInActives.TabIndex = 9;
            this.cBoxWithInActives.Text = "نمایش كاربران غیر فعال";
            this.cBoxWithInActives.TextColor = System.Drawing.Color.MediumVioletRed;
            this.cBoxWithInActives.CheckedChanged += new System.EventHandler(this.cBoxWithInActives_CheckedChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIsActive,
            this.ColUserName,
            this.ColFirstName,
            this.ColLastName,
            this.ColMustChangePassword,
            this.ColDescription,
            this.ColPass});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 12);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(772, 465);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValueChanged);
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvData_UserAddedRow);
            this.dgvData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.dgvData.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvData_CellValidating);
            this.dgvData.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvData_DefaultValuesNeeded);
            this.dgvData.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEnter);
            // 
            // ColIsActive
            // 
            this.ColIsActive.DataPropertyName = "IsActive";
            this.ColIsActive.HeaderText = "فعال";
            this.ColIsActive.Name = "ColIsActive";
            this.ColIsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColIsActive.ToolTipText = "تعیین فعال بودن یا نبودن كاربر. كاربر غیر فعال امكان ورود به سیستم را ندارد.";
            this.ColIsActive.Width = 35;
            // 
            // ColUserName
            // 
            this.ColUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColUserName.DataPropertyName = "UserName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Teal;
            this.ColUserName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColUserName.HeaderText = "نام كاربری";
            this.ColUserName.MaxInputLength = 20;
            this.ColUserName.Name = "ColUserName";
            this.ColUserName.ToolTipText = "نام كاربری. كلمه ای كه كاربر با آن وارد سیستم می شود و به انگلیسی خواهد بود.";
            // 
            // ColFirstName
            // 
            this.ColFirstName.DataPropertyName = "FirstName";
            this.ColFirstName.HeaderText = "نام";
            this.ColFirstName.MaxInputLength = 20;
            this.ColFirstName.Name = "ColFirstName";
            this.ColFirstName.ToolTipText = "نام كوچك كاربر.";
            this.ColFirstName.Width = 120;
            // 
            // ColLastName
            // 
            this.ColLastName.DataPropertyName = "LastName";
            this.ColLastName.HeaderText = "نام خانوادگی";
            this.ColLastName.MaxInputLength = 20;
            this.ColLastName.Name = "ColLastName";
            this.ColLastName.ToolTipText = "نام خانوادگی كاربر.";
            this.ColLastName.Width = 130;
            // 
            // ColMustChangePassword
            // 
            this.ColMustChangePassword.DataPropertyName = "MustChangePassword";
            this.ColMustChangePassword.HeaderText = "اجبار تغییر كلمه عبور";
            this.ColMustChangePassword.Name = "ColMustChangePassword";
            this.ColMustChangePassword.ToolTipText = "اجباری بودن تغییر كلمه عبور در اولین ورود به سیستم.";
            this.ColMustChangePassword.Width = 65;
            // 
            // ColDescription
            // 
            this.ColDescription.DataPropertyName = "Description";
            this.ColDescription.HeaderText = "توضیحات";
            this.ColDescription.MaxInputLength = 300;
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ToolTipText = "توضیحاتی پیرامون كاربر.";
            this.ColDescription.Width = 200;
            // 
            // ColPass
            // 
            this.ColPass.DataPropertyName = "Password";
            this.ColPass.HeaderText = "رمز عبور";
            this.ColPass.Name = "ColPass";
            this.ColPass.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Negar.Security.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(689, 505);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Image = global::Negar.Security.Properties.Resources.AddMed;
            this.btnAdd.Location = new System.Drawing.Point(588, 505);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnAdd.Size = new System.Drawing.Size(95, 57);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "افزودن كاربر\r\n (F6)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnApply
            // 
            this.btnApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApply.Image = global::Negar.Security.Properties.Resources.Apply;
            this.btnApply.Location = new System.Drawing.Point(213, 505);
            this.btnApply.Name = "btnApply";
            this.btnApply.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnApply.Size = new System.Drawing.Size(95, 57);
            this.btnApply.TabIndex = 3;
            this.btnApply.TabStop = false;
            this.btnApply.Text = "اعمال\r\n(F4)";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Negar.Security.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(112, 505);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Negar.Security.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(11, 505);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تاييد\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmUsers
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(794, 574);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmUsers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مديريت امنيت سيستم - ليست كاربران سيستم ";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        

        

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        internal DevComponents.DotNetBar.ButtonX btnAccept;
        internal DevComponents.DotNetBar.ButtonX btnHelp;
        internal DevComponents.DotNetBar.ButtonX btnApply;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxWithInActives;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ContextMenuBar cmsUsers;
        private DevComponents.DotNetBar.ButtonItem cmsUsersManage;
        private DevComponents.DotNetBar.ButtonItem btnResetPassword;
        internal DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLastName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColMustChangePassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPass;
    }
}