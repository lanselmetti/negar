namespace Sepehr.Settings.PACSIntegration
{
    partial class frmServicesSelection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServicesSelection));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnNone = new DevComponents.DotNetBar.ButtonX();
            this.btnAll = new DevComponents.DotNetBar.ButtonX();
            this.lblCategory = new DevComponents.DotNetBar.LabelX();
            this.cboCategory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cBoxWithInActives = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.ColSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.btnNone);
            this.FormPanel.Controls.Add(this.btnAll);
            this.FormPanel.Controls.Add(this.lblCategory);
            this.FormPanel.Controls.Add(this.cboCategory);
            this.FormPanel.Controls.Add(this.cBoxWithInActives);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnAccept);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(792, 573);
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
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
            this.ColSelection,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column8});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 39);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(770, 437);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 34;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            // 
            // btnNone
            // 
            this.btnNone.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNone.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnNone.Image = global::Sepehr.Settings.PACSIntegration.Properties.Resources.SelectNone;
            this.btnNone.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnNone.Location = new System.Drawing.Point(483, 504);
            this.btnNone.Name = "btnNone";
            this.btnNone.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnNone.Size = new System.Drawing.Size(95, 57);
            this.btnNone.TabIndex = 33;
            this.btnNone.TabStop = false;
            this.btnNone.Text = "عدم پوشش";
            this.btnNone.Click += new System.EventHandler(this.btnAllAndNone_Click);
            // 
            // btnAll
            // 
            this.btnAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAll.Image = global::Sepehr.Settings.PACSIntegration.Properties.Resources.SelectAll;
            this.btnAll.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnAll.Location = new System.Drawing.Point(585, 504);
            this.btnAll.Name = "btnAll";
            this.btnAll.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnAll.Size = new System.Drawing.Size(95, 57);
            this.btnAll.TabIndex = 32;
            this.btnAll.TabStop = false;
            this.btnAll.Text = "پوشش همه";
            this.btnAll.Click += new System.EventHandler(this.btnAllAndNone_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCategory.Location = new System.Drawing.Point(656, 12);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(125, 21);
            this.lblCategory.TabIndex = 7;
            this.lblCategory.Text = " فیلتر گذاری طبقه بندی:";
            this.lblCategory.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboCategory
            // 
            this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategory.DisplayMember = "Name";
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.ItemHeight = 13;
            this.cboCategory.Location = new System.Drawing.Point(391, 12);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(257, 21);
            this.cboCategory.TabIndex = 6;
            this.cboCategory.ValueMember = "ID";
            this.cboCategory.WatermarkText = "یك گروه از لیست انتخاب نمایید...";
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
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
            this.cBoxWithInActives.Location = new System.Drawing.Point(635, 482);
            this.cBoxWithInActives.Name = "cBoxWithInActives";
            this.cBoxWithInActives.Size = new System.Drawing.Size(144, 16);
            this.cBoxWithInActives.TabIndex = 4;
            this.cBoxWithInActives.Text = "نمایش خدمات غیر فعال";
            this.cBoxWithInActives.TextColor = System.Drawing.Color.MediumVioletRed;
            this.cBoxWithInActives.CheckedChanged += new System.EventHandler(this.cBoxWithInActives_CheckedChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.PACSIntegration.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(687, 504);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Settings.PACSIntegration.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 504);
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
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Image = global::Sepehr.Settings.PACSIntegration.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 504);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تایید\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // ColSelection
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.NullValue = false;
            this.ColSelection.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColSelection.HeaderText = "انتخاب";
            this.ColSelection.Name = "ColSelection";
            this.ColSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSelection.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColSelection.Width = 40;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IsActive";
            this.Column1.HeaderText = "فعال";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.ToolTipText = "تعیین فعال بودن یا نبودن خدمت";
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Code";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "كد";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.ToolTipText = "كد دسترسی به خدمت";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "Name";
            this.Column3.HeaderText = "نام خدمت";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.ToolTipText = "نام خدمت مورد نظر";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Description";
            this.Column8.HeaderText = "توضیحات";
            this.Column8.MaxInputLength = 300;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.ToolTipText = "توضیحاتی پیرامون خدمت.";
            this.Column8.Width = 150;
            // 
            // frmServicesSelection
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmServicesSelection";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - خدمات مراجعات - طبقه بندی خدمات مراجعات";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        internal DevComponents.DotNetBar.ButtonX btnAccept;
        internal DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxWithInActives;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.LabelX lblCategory;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCategory;
        internal DevComponents.DotNetBar.ButtonX btnNone;
        internal DevComponents.DotNetBar.ButtonX btnAll;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelection;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}