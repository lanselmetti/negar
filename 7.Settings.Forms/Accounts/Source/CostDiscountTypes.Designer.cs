namespace Sepehr.Settings.Accounts
{
    partial class frmCostDiscountTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCostDiscountTypes));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnApply = new DevComponents.DotNetBar.ButtonX();
            this.cBoxWithInActives = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsCost = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.btnAdd);
            this.FormPanel.Controls.Add(this.btnApply);
            this.FormPanel.Controls.Add(this.cBoxWithInActives);
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnAccept);
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
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Image = global::Sepehr.Settings.Accounts.Properties.Resources.AddMed;
            this.btnAdd.Location = new System.Drawing.Point(426, 385);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnAdd.Size = new System.Drawing.Size(95, 57);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "افزودن ردیف (F6)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnApply
            // 
            this.btnApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApply.Image = global::Sepehr.Settings.Accounts.Properties.Resources.Apply;
            this.btnApply.Location = new System.Drawing.Point(214, 385);
            this.btnApply.Name = "btnApply";
            this.btnApply.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnApply.Size = new System.Drawing.Size(95, 57);
            this.btnApply.TabIndex = 8;
            this.btnApply.TabStop = false;
            this.btnApply.Text = "اعمال\r\n(F4)";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
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
            this.cBoxWithInActives.Location = new System.Drawing.Point(397, 363);
            this.cBoxWithInActives.Name = "cBoxWithInActives";
            this.cBoxWithInActives.Size = new System.Drawing.Size(226, 16);
            this.cBoxWithInActives.TabIndex = 7;
            this.cBoxWithInActives.Text = "نمایش تخفیف ها و هزینه های غیر فعال";
            this.cBoxWithInActives.TextColor = System.Drawing.Color.MediumVioletRed;
            this.cBoxWithInActives.CheckedChanged += new System.EventHandler(this.cBoxWithInActives_CheckedChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
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
            this.ColName,
            this.ColIsCost,
            this.ColLimit,
            this.ColDescription});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 12);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(610, 345);
            this.dgvData.TabIndex = 6;
            this.dgvData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValueChanged);
            this.dgvData.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvData_UserAddedRow);
            this.dgvData.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvData_CellValidating_1);
            this.dgvData.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvData_DefaultValuesNeeded);
            // 
            // ColIsActive
            // 
            this.ColIsActive.DataPropertyName = "IsActive";
            this.ColIsActive.HeaderText = "فعال";
            this.ColIsActive.Name = "ColIsActive";
            this.ColIsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColIsActive.Width = 35;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColName.DataPropertyName = "Name";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.ColName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColName.HeaderText = "عنوان";
            this.ColName.Name = "ColName";
            // 
            // ColIsCost
            // 
            this.ColIsCost.DataPropertyName = "IsCost";
            this.ColIsCost.HeaderText = "هزینه";
            this.ColIsCost.Name = "ColIsCost";
            this.ColIsCost.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIsCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColIsCost.ToolTipText = "تعیین هزینه بودن سرفصل یا تخفیف بودن آن";
            this.ColIsCost.Width = 50;
            // 
            // ColLimit
            // 
            this.ColLimit.DataPropertyName = "Limitation";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.ColLimit.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColLimit.HeaderText = "سقف (ریال)";
            this.ColLimit.Name = "ColLimit";
            this.ColLimit.ToolTipText = "در صورت تعیین سقف ، هیچ مراجعه ای نمی تواند مجموع مبلغ تخفیفی بیش از سقف نوع مورد" +
                " نظر داشته باشد.";
            this.ColLimit.Width = 90;
            // 
            // ColDescription
            // 
            this.ColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDescription.DataPropertyName = "Description";
            this.ColDescription.HeaderText = "توضیحات";
            this.ColDescription.Name = "ColDescription";
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Accounts.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(527, 385);
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
            this.btnCancel.Image = global::Sepehr.Settings.Accounts.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Sepehr.Settings.Accounts.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 385);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تایید\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmCostDiscountTypes
            // 
            this.AcceptButton = this.btnAccept;
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
            this.Name = "frmCostDiscountTypes";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - حساب مراجعات - مدیریت انواع هزینه ها و تخفیف ها";
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
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxWithInActives;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        internal DevComponents.DotNetBar.ButtonX btnApply;
        internal DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
    }
}