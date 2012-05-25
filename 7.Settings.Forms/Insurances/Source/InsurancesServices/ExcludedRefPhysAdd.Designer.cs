namespace Sepehr.Settings.Insurances.InsurancesServices
{
    partial class frmExcludedRefPhysAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExcludedRefPhysAdd));
            this.PanelCostDiscount = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblPerformers = new DevComponents.DotNetBar.LabelX();
            this.btnNone = new DevComponents.DotNetBar.ButtonX();
            this.btnAll = new DevComponents.DotNetBar.ButtonX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColServiceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCategories = new DevComponents.DotNetBar.LabelX();
            this.cboCategories = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.cboRefPhysician = new Sepehr.Settings.Insurances.IMSComboBox();
            this.PanelCostDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelCostDiscount
            // 
            this.PanelCostDiscount.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelCostDiscount.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelCostDiscount.Controls.Add(this.lblPerformers);
            this.PanelCostDiscount.Controls.Add(this.cboRefPhysician);
            this.PanelCostDiscount.Controls.Add(this.btnNone);
            this.PanelCostDiscount.Controls.Add(this.btnAll);
            this.PanelCostDiscount.Controls.Add(this.dgvData);
            this.PanelCostDiscount.Controls.Add(this.lblCategories);
            this.PanelCostDiscount.Controls.Add(this.cboCategories);
            this.PanelCostDiscount.Controls.Add(this.btnHelp);
            this.PanelCostDiscount.Controls.Add(this.btnCancel);
            this.PanelCostDiscount.Controls.Add(this.btnAccept);
            this.PanelCostDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCostDiscount.Location = new System.Drawing.Point(0, 0);
            this.PanelCostDiscount.Name = "PanelCostDiscount";
            this.PanelCostDiscount.Size = new System.Drawing.Size(794, 572);
            // 
            // 
            // 
            this.PanelCostDiscount.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelCostDiscount.Style.BackColorGradientAngle = 90;
            this.PanelCostDiscount.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelCostDiscount.Style.BorderBottomWidth = 1;
            this.PanelCostDiscount.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelCostDiscount.Style.BorderLeftWidth = 1;
            this.PanelCostDiscount.Style.BorderRightWidth = 1;
            this.PanelCostDiscount.Style.BorderTopWidth = 1;
            this.PanelCostDiscount.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelCostDiscount.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelCostDiscount.TabIndex = 0;
            // 
            // lblPerformers
            // 
            this.lblPerformers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPerformers.AutoSize = true;
            this.lblPerformers.BackColor = System.Drawing.Color.Transparent;
            this.lblPerformers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPerformers.Location = new System.Drawing.Point(379, 11);
            this.lblPerformers.Name = "lblPerformers";
            this.lblPerformers.Size = new System.Drawing.Size(87, 16);
            this.lblPerformers.TabIndex = 2;
            this.lblPerformers.Text = "پزشك متخصص:";
            this.lblPerformers.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnNone
            // 
            this.btnNone.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNone.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnNone.Image = global::Sepehr.Settings.Insurances.Properties.Resources.SelectNone;
            this.btnNone.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnNone.Location = new System.Drawing.Point(484, 500);
            this.btnNone.Name = "btnNone";
            this.btnNone.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnNone.Size = new System.Drawing.Size(95, 57);
            this.btnNone.TabIndex = 7;
            this.btnNone.TabStop = false;
            this.btnNone.Text = "عدم\r\nانتخاب";
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // btnAll
            // 
            this.btnAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAll.Image = global::Sepehr.Settings.Insurances.Properties.Resources.SelectAll;
            this.btnAll.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnAll.Location = new System.Drawing.Point(586, 500);
            this.btnAll.Name = "btnAll";
            this.btnAll.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnAll.Size = new System.Drawing.Size(95, 57);
            this.btnAll.TabIndex = 8;
            this.btnAll.TabStop = false;
            this.btnAll.Text = "انتخاب\r\nهمه";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
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
            this.ColServiceCode,
            this.ColServiceName});
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
            this.dgvData.Size = new System.Drawing.Size(770, 455);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 4;
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
            // ColServiceCode
            // 
            this.ColServiceCode.DataPropertyName = "Code";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColServiceCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColServiceCode.HeaderText = "كد";
            this.ColServiceCode.Name = "ColServiceCode";
            this.ColServiceCode.ReadOnly = true;
            this.ColServiceCode.ToolTipText = "كد دسترسی به خدمت";
            this.ColServiceCode.Width = 50;
            // 
            // ColServiceName
            // 
            this.ColServiceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColServiceName.DataPropertyName = "Name";
            this.ColServiceName.HeaderText = "نام خدمت";
            this.ColServiceName.Name = "ColServiceName";
            this.ColServiceName.ReadOnly = true;
            this.ColServiceName.ToolTipText = "نام خدمت مورد نظر";
            // 
            // lblCategories
            // 
            this.lblCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategories.AutoSize = true;
            this.lblCategories.BackColor = System.Drawing.Color.Transparent;
            this.lblCategories.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCategories.Location = new System.Drawing.Point(686, 11);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(97, 16);
            this.lblCategories.TabIndex = 1;
            this.lblCategories.Text = "طبقه بندی خدمت:";
            this.lblCategories.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboCategories
            // 
            this.cboCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategories.DisplayMember = "Name";
            this.cboCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategories.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboCategories.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboCategories.FormattingEnabled = true;
            this.cboCategories.ItemHeight = 13;
            this.cboCategories.Location = new System.Drawing.Point(475, 9);
            this.cboCategories.Name = "cboCategories";
            this.cboCategories.Size = new System.Drawing.Size(206, 21);
            this.cboCategories.TabIndex = 0;
            this.cboCategories.ValueMember = "ID";
            this.cboCategories.WatermarkText = "یك گروه از لیست انتخاب نمایید...";
            this.cboCategories.SelectedIndexChanged += new System.EventHandler(this.cboCategories_SelectedIndexChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(687, 500);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 60);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "انصراف (Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAccept.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 500);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 60);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "تائید (F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // cboRefPhysician
            // 
            this.cboRefPhysician.AccessibleDescription = "DropDown";
            this.cboRefPhysician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRefPhysician.AutoComplete = true;
            this.cboRefPhysician.AutoDropdown = true;
            this.cboRefPhysician.BackColorEven = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboRefPhysician.BackColorOdd = System.Drawing.Color.White;
            this.cboRefPhysician.ColumnNames = "";
            this.cboRefPhysician.ColumnWidthDefault = 25;
            this.cboRefPhysician.ColumnWidths = "0;0;0;0;0;200;0;0;25;50;0;345;0";
            this.cboRefPhysician.DisplayMember = "FullName";
            this.cboRefPhysician.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboRefPhysician.DropDownHeight = 200;
            this.cboRefPhysician.DropDownWidth = 250;
            this.cboRefPhysician.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboRefPhysician.ForeColor = System.Drawing.Color.Green;
            this.cboRefPhysician.FormattingEnabled = true;
            this.cboRefPhysician.IntegralHeight = false;
            this.cboRefPhysician.ItemHeight = 15;
            this.cboRefPhysician.LinkedColumnIndex = 1;
            this.cboRefPhysician.Location = new System.Drawing.Point(12, 9);
            this.cboRefPhysician.MaxDropDownItems = 10;
            this.cboRefPhysician.Name = "cboRefPhysician";
            this.cboRefPhysician.ReadOnly = false;
            this.cboRefPhysician.Size = new System.Drawing.Size(361, 21);
            this.cboRefPhysician.TabIndex = 3;
            this.cboRefPhysician.ValueMember = "ID";
            this.cboRefPhysician.Enter += new System.EventHandler(this.cboExcludedSpecs_Enter);
            this.cboRefPhysician.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboRefPhysician_KeyPress);
            this.cboRefPhysician.NoDataFound += new System.EventHandler(this.cboRefPhysician_NoDataFound);
            // 
            // frmExcludedRefPhysAdd
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.PanelCostDiscount);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmExcludedRefPhysAdd";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "افزودن پزشكان ارجاع دهنده مجاز ";
            this.PanelCostDiscount.ResumeLayout(false);
            this.PanelCostDiscount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelCostDiscount;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.LabelX lblCategories;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCategories;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServiceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServiceName;
        internal DevComponents.DotNetBar.ButtonX btnNone;
        internal DevComponents.DotNetBar.ButtonX btnAll;
        private DevComponents.DotNetBar.LabelX lblPerformers;
        private IMSComboBox cboRefPhysician;
    }
}