namespace Negar.Security.ACL
{
    partial class frmManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.PanelToDefaultACL = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnToDefaultACL = new DevComponents.DotNetBar.ButtonX();
            this.cboUsers = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnACLDiagram = new DevComponents.DotNetBar.ButtonX();
            this.btnCopyUserACL = new DevComponents.DotNetBar.ButtonX();
            this.cmsACL = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsACLManage = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewAccess = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditAccess = new DevComponents.DotNetBar.ButtonItem();
            this.btnRemoveAccess = new DevComponents.DotNetBar.ButtonItem();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAllowChangePassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMustChangePassword = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.TreeViewACL = new System.Windows.Forms.TreeView();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            this.PanelToDefaultACL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsACL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.PanelToDefaultACL);
            this.FormPanel.Controls.Add(this.btnACLDiagram);
            this.FormPanel.Controls.Add(this.btnCopyUserACL);
            this.FormPanel.Controls.Add(this.cmsACL);
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.btnClose);
            this.FormPanel.Controls.Add(this.TreeViewACL);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(784, 564);
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
            // PanelToDefaultACL
            // 
            this.PanelToDefaultACL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelToDefaultACL.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelToDefaultACL.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelToDefaultACL.Controls.Add(this.btnToDefaultACL);
            this.PanelToDefaultACL.Controls.Add(this.cboUsers);
            this.PanelToDefaultACL.IsShadowEnabled = false;
            this.PanelToDefaultACL.Location = new System.Drawing.Point(257, 495);
            this.PanelToDefaultACL.Name = "PanelToDefaultACL";
            this.PanelToDefaultACL.Size = new System.Drawing.Size(212, 57);
            // 
            // 
            // 
            this.PanelToDefaultACL.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelToDefaultACL.Style.BackColorGradientAngle = 90;
            this.PanelToDefaultACL.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelToDefaultACL.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelToDefaultACL.Style.BorderBottomWidth = 1;
            this.PanelToDefaultACL.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelToDefaultACL.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelToDefaultACL.Style.BorderLeftWidth = 1;
            this.PanelToDefaultACL.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelToDefaultACL.Style.BorderRightWidth = 1;
            this.PanelToDefaultACL.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelToDefaultACL.Style.BorderTopWidth = 1;
            this.PanelToDefaultACL.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelToDefaultACL.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelToDefaultACL.TabIndex = 3;
            // 
            // btnToDefaultACL
            // 
            this.btnToDefaultACL.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnToDefaultACL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToDefaultACL.BackColor = System.Drawing.Color.Transparent;
            this.btnToDefaultACL.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnToDefaultACL.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnToDefaultACL.ForeColor = System.Drawing.Color.Crimson;
            this.btnToDefaultACL.Image = global::Negar.Security.Properties.Resources.DeleteSmall;
            this.btnToDefaultACL.Location = new System.Drawing.Point(6, 3);
            this.btnToDefaultACL.Name = "btnToDefaultACL";
            this.btnToDefaultACL.Size = new System.Drawing.Size(200, 25);
            this.btnToDefaultACL.TabIndex = 2;
            this.btnToDefaultACL.TabStop = false;
            this.btnToDefaultACL.Text = "حذف محدودیت های كاربر زیر:";
            this.btnToDefaultACL.Click += new System.EventHandler(this.btnToDefaultACL_Click);
            // 
            // cboUsers
            // 
            this.cboUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUsers.DisplayMember = "Text";
            this.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsers.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboUsers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.ItemHeight = 13;
            this.cboUsers.Location = new System.Drawing.Point(6, 31);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(200, 21);
            this.cboUsers.TabIndex = 1;
            this.cboUsers.TabStop = false;
            this.cboUsers.WatermarkText = "یك گروه از لیست انتخاب نمایید...";
            // 
            // btnACLDiagram
            // 
            this.btnACLDiagram.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnACLDiagram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnACLDiagram.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnACLDiagram.Image = ((System.Drawing.Image)(resources.GetObject("btnACLDiagram.Image")));
            this.btnACLDiagram.Location = new System.Drawing.Point(576, 495);
            this.btnACLDiagram.Name = "btnACLDiagram";
            this.btnACLDiagram.Size = new System.Drawing.Size(95, 57);
            this.btnACLDiagram.TabIndex = 5;
            this.btnACLDiagram.TabStop = false;
            this.btnACLDiagram.Text = "نمایش دیاگرام دسترسی";
            this.btnACLDiagram.Click += new System.EventHandler(this.btnACLDiagram_Click);
            // 
            // btnCopyUserACL
            // 
            this.btnCopyUserACL.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCopyUserACL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyUserACL.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCopyUserACL.Image = global::Negar.Security.Properties.Resources.Copy;
            this.btnCopyUserACL.Location = new System.Drawing.Point(475, 495);
            this.btnCopyUserACL.Name = "btnCopyUserACL";
            this.btnCopyUserACL.Size = new System.Drawing.Size(95, 57);
            this.btnCopyUserACL.TabIndex = 4;
            this.btnCopyUserACL.TabStop = false;
            this.btnCopyUserACL.Text = "كپی كردن\r\nدسترسی\r\nكاربران";
            this.btnCopyUserACL.Click += new System.EventHandler(this.btnCopyUserACL_Click);
            // 
            // cmsACL
            // 
            this.cmsACL.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.cmsACL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsACL.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsACLManage});
            this.cmsACL.Location = new System.Drawing.Point(113, 495);
            this.cmsACL.Name = "cmsACL";
            this.cmsACL.Size = new System.Drawing.Size(117, 25);
            this.cmsACL.Stretch = true;
            this.cmsACL.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsACL.TabIndex = 3;
            this.cmsACL.TabStop = false;
            // 
            // cmsACLManage
            // 
            this.cmsACLManage.AutoExpandOnClick = true;
            this.cmsACLManage.ImagePaddingHorizontal = 8;
            this.cmsACLManage.Name = "cmsACLManage";
            this.cmsACLManage.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNewAccess,
            this.btnEditAccess,
            this.btnRemoveAccess});
            this.cmsACLManage.Text = "منوی دسترسی ها";
            // 
            // btnNewAccess
            // 
            this.btnNewAccess.FontBold = true;
            this.btnNewAccess.Image = global::Negar.Security.Properties.Resources.AddMed;
            this.btnNewAccess.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnNewAccess.ImagePaddingHorizontal = 8;
            this.btnNewAccess.Name = "btnNewAccess";
            this.btnNewAccess.Text = "دسترسی جدید";
            this.btnNewAccess.Click += new System.EventHandler(this.btnNewAccess_Click);
            // 
            // btnEditAccess
            // 
            this.btnEditAccess.FontBold = true;
            this.btnEditAccess.Image = global::Negar.Security.Properties.Resources.EditSmall;
            this.btnEditAccess.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnEditAccess.ImagePaddingHorizontal = 8;
            this.btnEditAccess.Name = "btnEditAccess";
            this.btnEditAccess.Text = "ویرایش دسترسی";
            this.btnEditAccess.Click += new System.EventHandler(this.btnEditAccess_Click);
            // 
            // btnRemoveAccess
            // 
            this.btnRemoveAccess.FontBold = true;
            this.btnRemoveAccess.ForeColor = System.Drawing.Color.Red;
            this.btnRemoveAccess.Image = global::Negar.Security.Properties.Resources.DeleteMed;
            this.btnRemoveAccess.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnRemoveAccess.ImagePaddingHorizontal = 8;
            this.btnRemoveAccess.Name = "btnRemoveAccess";
            this.btnRemoveAccess.Text = "حذف دسترسی";
            this.btnRemoveAccess.Click += new System.EventHandler(this.btnRemoveAccess_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvData.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.ColDescription,
            this.ColAllowChangePassword,
            this.ColMustChangePassword});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 12);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(398, 477);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 1;
            this.dgvData.TabStop = false;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "FullName";
            this.Column1.HeaderText = "نام كامل";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // ColDescription
            // 
            this.ColDescription.DataPropertyName = "Type";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ColDescription.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColDescription.HeaderText = "نوع";
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            this.ColDescription.Width = 45;
            // 
            // ColAllowChangePassword
            // 
            this.ColAllowChangePassword.DataPropertyName = "IsAllowed";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            this.ColAllowChangePassword.DefaultCellStyle = dataGridViewCellStyle11;
            this.ColAllowChangePassword.HeaderText = "دسترسی";
            this.ColAllowChangePassword.Name = "ColAllowChangePassword";
            this.ColAllowChangePassword.ReadOnly = true;
            this.ColAllowChangePassword.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColAllowChangePassword.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColMustChangePassword
            // 
            this.ColMustChangePassword.DataPropertyName = "IsPremiered";
            this.ColMustChangePassword.HeaderText = "ارجحیت";
            this.ColMustChangePassword.Name = "ColMustChangePassword";
            this.ColMustChangePassword.ReadOnly = true;
            this.ColMustChangePassword.ThreeState = true;
            this.ColMustChangePassword.Width = 50;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Negar.Security.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 495);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 57);
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج\r\n(Esc)";
            // 
            // TreeViewACL
            // 
            this.TreeViewACL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeViewACL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.TreeViewACL.Font = new System.Drawing.Font("B Titr", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TreeViewACL.ForeColor = System.Drawing.Color.MidnightBlue;
            this.TreeViewACL.HotTracking = true;
            this.TreeViewACL.ItemHeight = 35;
            this.TreeViewACL.Location = new System.Drawing.Point(416, 12);
            this.TreeViewACL.Name = "TreeViewACL";
            this.TreeViewACL.PathSeparator = " => ";
            this.TreeViewACL.RightToLeftLayout = true;
            this.TreeViewACL.ShowNodeToolTips = true;
            this.TreeViewACL.Size = new System.Drawing.Size(356, 477);
            this.TreeViewACL.TabIndex = 0;
            this.TreeViewACL.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewACL_AfterSelect);
            this.TreeViewACL.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewACL_NodeMouseClick);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Negar.Security.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(677, 495);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmManage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مديريت امنيت سيستم - مدیریت سطوح دسترسی برای كاربران و گروه ها";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.PanelToDefaultACL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmsACL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        internal DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private System.Windows.Forms.TreeView TreeViewACL;
        internal DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.ContextMenuBar cmsACL;
        private DevComponents.DotNetBar.ButtonItem cmsACLManage;
        private DevComponents.DotNetBar.ButtonItem btnNewAccess;
        private DevComponents.DotNetBar.ButtonItem btnEditAccess;
        private DevComponents.DotNetBar.ButtonItem btnRemoveAccess;
        internal DevComponents.DotNetBar.ButtonX btnACLDiagram;
        internal DevComponents.DotNetBar.ButtonX btnCopyUserACL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAllowChangePassword;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColMustChangePassword;
        private DevComponents.DotNetBar.ButtonX btnToDefaultACL;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboUsers;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelToDefaultACL;
    }
}