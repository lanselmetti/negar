namespace Sepehr.Settings.Services
{
    partial class frmServices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServices));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.cBoxWithInActives = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnServiceColumns = new DevComponents.DotNetBar.ButtonX();
            this.btnChangeAllServices = new DevComponents.DotNetBar.ButtonX();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.btnApply = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryIX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Col1FreePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col2GovPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.btnAdd);
            this.FormPanel.Controls.Add(this.cBoxWithInActives);
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnServiceColumns);
            this.FormPanel.Controls.Add(this.btnChangeAllServices);
            this.FormPanel.Controls.Add(this.btnPrint);
            this.FormPanel.Controls.Add(this.btnApply);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnSave);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(792, 570);
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
            this.btnAdd.Image = global::Sepehr.Settings.Services.Properties.Resources.AddMed;
            this.btnAdd.Location = new System.Drawing.Point(586, 496);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnAdd.Size = new System.Drawing.Size(95, 57);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "افزودن ردیف\r\n (F6)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cBoxWithInActives
            // 
            this.cBoxWithInActives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxWithInActives.AutoSize = true;
            this.cBoxWithInActives.BackColor = System.Drawing.Color.Transparent;
            this.cBoxWithInActives.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxWithInActives.Location = new System.Drawing.Point(637, 474);
            this.cBoxWithInActives.Name = "cBoxWithInActives";
            this.cBoxWithInActives.Size = new System.Drawing.Size(144, 16);
            this.cBoxWithInActives.TabIndex = 9;
            this.cBoxWithInActives.Text = "نمایش خدمات غیر فعال";
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
            this.Column1,
            this.ColCode,
            this.Column3,
            this.CategoryIX,
            this.ColumnCategory,
            this.Col1FreePrice,
            this.Col2GovPrice,
            this.ColDescription});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 12);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(770, 456);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValueChanged);
            this.dgvData.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvData_UserAddedRow);
            this.dgvData.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvData_CellValidating);
            this.dgvData.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvData_DefaultValuesNeeded);
            this.dgvData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvData_DataError);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Services.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(687, 496);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(96, 57);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnServiceColumns
            // 
            this.btnServiceColumns.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnServiceColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServiceColumns.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnServiceColumns.Location = new System.Drawing.Point(462, 528);
            this.btnServiceColumns.Name = "btnServiceColumns";
            this.btnServiceColumns.Size = new System.Drawing.Size(118, 25);
            this.btnServiceColumns.TabIndex = 7;
            this.btnServiceColumns.TabStop = false;
            this.btnServiceColumns.Text = "مدیریت عناوین قیمت";
            this.btnServiceColumns.Click += new System.EventHandler(this.btnServiceColumns_Click);
            // 
            // btnChangeAllServices
            // 
            this.btnChangeAllServices.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChangeAllServices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeAllServices.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChangeAllServices.Location = new System.Drawing.Point(462, 496);
            this.btnChangeAllServices.Name = "btnChangeAllServices";
            this.btnChangeAllServices.Size = new System.Drawing.Size(118, 26);
            this.btnChangeAllServices.TabIndex = 6;
            this.btnChangeAllServices.TabStop = false;
            this.btnChangeAllServices.Text = "تغییر جمعی قیمتها";
            this.btnChangeAllServices.Click += new System.EventHandler(this.btnChangeAllServices_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Image = global::Sepehr.Settings.Services.Properties.Resources.PrintGrid;
            this.btnPrint.Location = new System.Drawing.Point(360, 496);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlP);
            this.btnPrint.Size = new System.Drawing.Size(96, 57);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "چاپ جدول\r\n(Ctrl+P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnApply
            // 
            this.btnApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApply.Image = global::Sepehr.Settings.Services.Properties.Resources.Apply;
            this.btnApply.Location = new System.Drawing.Point(214, 496);
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
            this.btnCancel.Image = global::Sepehr.Settings.Services.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 496);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = global::Sepehr.Settings.Services.Properties.Resources.Accept;
            this.btnSave.Location = new System.Drawing.Point(12, 496);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSave.Size = new System.Drawing.Size(95, 57);
            this.btnSave.TabIndex = 1;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "تایید\r\n(F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IsActive";
            this.Column1.HeaderText = "فعال";
            this.Column1.Name = "Column1";
            this.Column1.ToolTipText = "تعیین فعال بودن یا نبودن خدمت";
            this.Column1.Width = 35;
            // 
            // ColCode
            // 
            this.ColCode.DataPropertyName = "Code";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColCode.HeaderText = "كد";
            this.ColCode.MaxInputLength = 5;
            this.ColCode.MinimumWidth = 40;
            this.ColCode.Name = "ColCode";
            this.ColCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCode.ToolTipText = "كد دسترسی به خدمت";
            this.ColCode.Width = 40;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Name";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "نام خدمت";
            this.Column3.MaxInputLength = 255;
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.ToolTipText = "نام خدمت مورد نظر";
            this.Column3.Width = 58;
            // 
            // CategoryIX
            // 
            this.CategoryIX.DataPropertyName = "CategoryIX";
            this.CategoryIX.HeaderText = "كلید طبقه بندی";
            this.CategoryIX.Name = "CategoryIX";
            this.CategoryIX.Visible = false;
            // 
            // ColumnCategory
            // 
            this.ColumnCategory.DataPropertyName = "CategoryIX";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColumnCategory.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnCategory.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColumnCategory.HeaderText = "طبقه بندی";
            this.ColumnCategory.Name = "ColumnCategory";
            this.ColumnCategory.ToolTipText = "نوع خدمت انتخاب شده";
            this.ColumnCategory.Width = 170;
            // 
            // Col1FreePrice
            // 
            this.Col1FreePrice.DataPropertyName = "PriceFree";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.Col1FreePrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.Col1FreePrice.HeaderText = "تعرفه بدون بیمه";
            this.Col1FreePrice.MaxInputLength = 10;
            this.Col1FreePrice.Name = "Col1FreePrice";
            this.Col1FreePrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Col1FreePrice.ToolTipText = "قیمت بدون بیمه خدمت. (ریال) قیمت بدون بیمه به معنی قیمت خدمات در حالتی است كه بیم" +
                "ه برای مراجعه انتخاب نشده.";
            this.Col1FreePrice.Width = 70;
            // 
            // Col2GovPrice
            // 
            this.Col2GovPrice.DataPropertyName = "PriceGov";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            this.Col2GovPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.Col2GovPrice.HeaderText = "تعرفه دولتی";
            this.Col2GovPrice.MaxInputLength = 10;
            this.Col2GovPrice.Name = "Col2GovPrice";
            this.Col2GovPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Col2GovPrice.ToolTipText = "قیمت دولتی خدمت. (ریال) قیمت دولتی مصوب سال جاری خدمت.";
            this.Col2GovPrice.Width = 70;
            // 
            // ColDescription
            // 
            this.ColDescription.DataPropertyName = "Description";
            this.ColDescription.HeaderText = "توضیحات";
            this.ColDescription.MaxInputLength = 300;
            this.ColDescription.MinimumWidth = 60;
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDescription.ToolTipText = "توضیحاتی پیرامون خدمت.";
            this.ColDescription.Width = 60;
            // 
            // frmServices
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(792, 570);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmServices";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - خدمات و بیمه ها - مدیریت خدمات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        internal DevComponents.DotNetBar.ButtonX btnSave;
        internal DevComponents.DotNetBar.ButtonX btnHelp;
        internal DevComponents.DotNetBar.ButtonX btnApply;
        private System.Windows.Forms.DataGridView dgvData;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxWithInActives;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        internal DevComponents.DotNetBar.ButtonX btnPrint;
        internal DevComponents.DotNetBar.ButtonX btnChangeAllServices;
        internal DevComponents.DotNetBar.ButtonX btnServiceColumns;
        internal DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryIX;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col1FreePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col2GovPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
    }
}