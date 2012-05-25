namespace Sepehr.Forms.Admission.Referrals
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServicesSelection));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblServiceSearch = new DevComponents.DotNetBar.LabelX();
            this.txtServiceSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnNone = new DevComponents.DotNetBar.ButtonX();
            this.btnAll = new DevComponents.DotNetBar.ButtonX();
            this.cmsAddService = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsServicesManage = new DevComponents.DotNetBar.ButtonItem();
            this.SliderItemCount = new DevComponents.DotNetBar.SliderItem();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboCategory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblServiceFiter = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsAddService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.lblServiceSearch);
            this.FormPanel.Controls.Add(this.txtServiceSearch);
            this.FormPanel.Controls.Add(this.btnNone);
            this.FormPanel.Controls.Add(this.btnAll);
            this.FormPanel.Controls.Add(this.cmsAddService);
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.cboCategory);
            this.FormPanel.Controls.Add(this.lblServiceFiter);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnAdd);
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
            // lblServiceSearch
            // 
            this.lblServiceSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServiceSearch.AutoSize = true;
            this.lblServiceSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblServiceSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblServiceSearch.Location = new System.Drawing.Point(338, 14);
            this.lblServiceSearch.Name = "lblServiceSearch";
            this.lblServiceSearch.Size = new System.Drawing.Size(46, 16);
            this.lblServiceSearch.TabIndex = 2;
            this.lblServiceSearch.Text = "جستجو:";
            // 
            // txtServiceSearch
            // 
            this.txtServiceSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceSearch.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtServiceSearch.Border.Class = "TextBoxBorder";
            this.txtServiceSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtServiceSearch.Location = new System.Drawing.Point(12, 12);
            this.txtServiceSearch.MaxLength = 200;
            this.txtServiceSearch.Name = "txtServiceSearch";
            this.txtServiceSearch.Size = new System.Drawing.Size(320, 21);
            this.txtServiceSearch.TabIndex = 3;
            this.txtServiceSearch.Tag = "PatData";
            this.txtServiceSearch.TextChanged += new System.EventHandler(this.txtServiceSearch_TextChanged);
            // 
            // btnNone
            // 
            this.btnNone.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNone.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnNone.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnNone.Image = global::Sepehr.Forms.Admission.Properties.Resources.SelectNone;
            this.btnNone.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnNone.Location = new System.Drawing.Point(582, 504);
            this.btnNone.Name = "btnNone";
            this.btnNone.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnNone.Size = new System.Drawing.Size(96, 57);
            this.btnNone.TabIndex = 7;
            this.btnNone.TabStop = false;
            this.btnNone.Text = "عدم انتخاب";
            this.btnNone.Click += new System.EventHandler(this.btnAllAndNone_Click);
            // 
            // btnAll
            // 
            this.btnAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAll.Image = global::Sepehr.Forms.Admission.Properties.Resources.SelectAll;
            this.btnAll.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnAll.Location = new System.Drawing.Point(684, 504);
            this.btnAll.Name = "btnAll";
            this.btnAll.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnAll.Size = new System.Drawing.Size(96, 57);
            this.btnAll.TabIndex = 8;
            this.btnAll.TabStop = false;
            this.btnAll.Text = "انتخاب همه";
            this.btnAll.Click += new System.EventHandler(this.btnAllAndNone_Click);
            // 
            // cmsAddService
            // 
            this.cmsAddService.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.cmsAddService.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsAddService.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsServicesManage});
            this.cmsAddService.Location = new System.Drawing.Point(449, 504);
            this.cmsAddService.Name = "cmsAddService";
            this.cmsAddService.Size = new System.Drawing.Size(127, 25);
            this.cmsAddService.Stretch = true;
            this.cmsAddService.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsAddService.TabIndex = 75;
            this.cmsAddService.TabStop = false;
            // 
            // cmsServicesManage
            // 
            this.cmsServicesManage.AutoExpandOnClick = true;
            this.cmsServicesManage.FontBold = true;
            this.cmsServicesManage.ImagePaddingHorizontal = 8;
            this.cmsServicesManage.Name = "cmsServicesManage";
            this.cmsServicesManage.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.SliderItemCount});
            this.cmsServicesManage.Text = "منوی جدول خدمات";
            // 
            // SliderItemCount
            // 
            this.SliderItemCount.DecreaseTooltip = "كم كردن";
            this.SliderItemCount.IncreaseTooltip = "زیاد كردن";
            this.SliderItemCount.LabelPosition = DevComponents.DotNetBar.eSliderLabelPosition.Top;
            this.SliderItemCount.Maximum = 10;
            this.SliderItemCount.Minimum = 1;
            this.SliderItemCount.Name = "SliderItemCount";
            this.SliderItemCount.Text = "تعداد خدمت: 1";
            this.SliderItemCount.TrackMarker = false;
            this.SliderItemCount.Value = 1;
            this.SliderItemCount.Width = 130;
            this.SliderItemCount.ValueChanged += new System.EventHandler(this.SliderItemCount_ValueChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelection,
            this.ColCode,
            this.ColName,
            this.ColQuantity,
            this.ColCategory});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 39);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(769, 459);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 4;
            this.dgvData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValueChanged);
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvServices_CellMouseClick);
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            this.dgvData.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvData_CellValidating);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvServices_CellMouseDoubleClick);
            // 
            // ColSelection
            // 
            this.ColSelection.HeaderText = "انتخاب";
            this.ColSelection.Name = "ColSelection";
            this.ColSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSelection.Width = 40;
            // 
            // ColCode
            // 
            this.ColCode.DataPropertyName = "Code";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.ColCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColCode.HeaderText = "كد";
            this.ColCode.Name = "ColCode";
            this.ColCode.ReadOnly = true;
            this.ColCode.Width = 50;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColName.DataPropertyName = "Name";
            this.ColName.HeaderText = "نام خدمت";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColQuantity
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
            this.ColQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColQuantity.HeaderText = "تعداد";
            this.ColQuantity.MaxInputLength = 2;
            this.ColQuantity.Name = "ColQuantity";
            this.ColQuantity.Width = 50;
            // 
            // ColCategory
            // 
            this.ColCategory.DataPropertyName = "CategoryName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            this.ColCategory.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColCategory.HeaderText = "طبقه بندی";
            this.ColCategory.Name = "ColCategory";
            this.ColCategory.ReadOnly = true;
            this.ColCategory.Width = 150;
            // 
            // cboCategory
            // 
            this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategory.DisplayMember = "Name";
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboCategory.ForeColor = System.Drawing.Color.Navy;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.ItemHeight = 13;
            this.cboCategory.Location = new System.Drawing.Point(390, 12);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(257, 21);
            this.cboCategory.TabIndex = 0;
            this.cboCategory.ValueMember = "ID";
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategories_SelectedIndexChanged);
            // 
            // lblServiceFiter
            // 
            this.lblServiceFiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServiceFiter.AutoSize = true;
            this.lblServiceFiter.BackColor = System.Drawing.Color.Transparent;
            this.lblServiceFiter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblServiceFiter.Location = new System.Drawing.Point(653, 14);
            this.lblServiceFiter.Name = "lblServiceFiter";
            this.lblServiceFiter.Size = new System.Drawing.Size(127, 16);
            this.lblServiceFiter.TabIndex = 1;
            this.lblServiceFiter.Text = "فیلتر طبقه بندی خدمات:";
            this.lblServiceFiter.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Admission.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(114, 504);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 57);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdd.Image = global::Sepehr.Forms.Admission.Properties.Resources.AddMed;
            this.btnAdd.Location = new System.Drawing.Point(12, 504);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAdd.Size = new System.Drawing.Size(96, 57);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "افزودن\r\n(F8)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmServicesSelection
            // 
            this.AcceptButton = this.btnAdd;
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
            this.Text = "بیماران - مراجعات - انتخاب خدمات";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsAddService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCategory;
        private DevComponents.DotNetBar.LabelX lblServiceFiter;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.ContextMenuBar cmsAddService;
        private DevComponents.DotNetBar.ButtonItem cmsServicesManage;
        private DevComponents.DotNetBar.SliderItem SliderItemCount;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnNone;
        private DevComponents.DotNetBar.ButtonX btnAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCategory;
        private DevComponents.DotNetBar.LabelX lblServiceSearch;
        private DevComponents.DotNetBar.Controls.TextBoxX txtServiceSearch;
    }
}