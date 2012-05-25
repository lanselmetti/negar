namespace Sepehr.Settings.Cash
{
    partial class frmCashCashiers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashCashiers));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.cmsForm = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsMenu = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.lblGroup = new DevComponents.DotNetBar.LabelX();
            this.cboCashes = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.cmsForm);
            this.FormPanel.Controls.Add(this.lblGroup);
            this.FormPanel.Controls.Add(this.cboCashes);
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnAdd);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(634, 454);
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
            // cmsForm
            // 
            this.cmsForm.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.cmsForm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsForm.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsMenu});
            this.cmsForm.Location = new System.Drawing.Point(365, 385);
            this.cmsForm.Name = "cmsForm";
            this.cmsForm.Size = new System.Drawing.Size(55, 25);
            this.cmsForm.Stretch = true;
            this.cmsForm.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsForm.TabIndex = 21;
            this.cmsForm.TabStop = false;
            // 
            // cmsMenu
            // 
            this.cmsMenu.AutoExpandOnClick = true;
            this.cmsMenu.ImagePaddingHorizontal = 8;
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnDelete});
            this.cmsMenu.Text = "منو";
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Image = global::Sepehr.Settings.Cash.Properties.Resources.Delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnDelete.Text = "<b>حذف كاربر انتخاب شده</b>\r\n<div></div>\r\n<font color=\"#000000\">حذف از كاربران مج" +
                "از صندوق.</font>";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblGroup
            // 
            this.lblGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroup.AutoSize = true;
            this.lblGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblGroup.Location = new System.Drawing.Point(560, 14);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(62, 16);
            this.lblGroup.TabIndex = 1;
            this.lblGroup.Text = "نام صندوق:";
            this.lblGroup.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboCashes
            // 
            this.cboCashes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCashes.DisplayMember = "Name";
            this.cboCashes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCashes.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboCashes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboCashes.FormattingEnabled = true;
            this.cboCashes.ItemHeight = 13;
            this.cboCashes.Location = new System.Drawing.Point(309, 12);
            this.cboCashes.Name = "cboCashes";
            this.cboCashes.Size = new System.Drawing.Size(245, 21);
            this.cboCashes.TabIndex = 0;
            this.cboCashes.ValueMember = "ID";
            this.cboCashes.WatermarkText = "یك گروه از لیست انتخاب نمایید...";
            this.cboCashes.SelectedIndexChanged += new System.EventHandler(this.cboCashes_SelectedIndexChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
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
            this.ColUserName,
            this.ColLastName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 39);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(610, 340);
            this.dgvData.TabIndex = 2;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
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
            this.ColUserName.Name = "ColUserName";
            this.ColUserName.ReadOnly = true;
            // 
            // ColLastName
            // 
            this.ColLastName.DataPropertyName = "FullName";
            this.ColLastName.HeaderText = "نام و نام خانوادگی كاربر";
            this.ColLastName.Name = "ColLastName";
            this.ColLastName.ReadOnly = true;
            this.ColLastName.Width = 300;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Cash.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(527, 385);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Image = global::Sepehr.Settings.Cash.Properties.Resources.AddMed;
            this.btnAdd.Location = new System.Drawing.Point(426, 385);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.btnAdd.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnAdd.Size = new System.Drawing.Size(95, 57);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "افزودن كاربر\r\n(F6)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Settings.Cash.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmCashCashiers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(634, 454);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmCashCashiers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - صندوق ها - ارتباط صندوق ها و صندوقداران";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        internal DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCashes;
        private DevComponents.DotNetBar.LabelX lblGroup;
        internal DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ContextMenuBar cmsForm;
        private DevComponents.DotNetBar.ButtonItem cmsMenu;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLastName;
    }
}