namespace Sepehr.Settings.Insurances.InsurancesServices
{
    partial class frmServicesCoverage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServicesCoverage));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblInsName = new DevComponents.DotNetBar.LabelX();
            this.txtInsName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.ColCoverage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CategoryIX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInsPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInsPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPatientPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPatientPayble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col1FreePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col2GovPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnAll = new DevComponents.DotNetBar.ButtonX();
            this.btnNone = new DevComponents.DotNetBar.ButtonX();
            this.btnAutoCalculation = new DevComponents.DotNetBar.ButtonX();
            this.btnPrintGrid = new DevComponents.DotNetBar.ButtonX();
            this.btnApply = new DevComponents.DotNetBar.ButtonX();
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
            this.FormPanel.Controls.Add(this.lblInsName);
            this.FormPanel.Controls.Add(this.txtInsName);
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnAll);
            this.FormPanel.Controls.Add(this.btnNone);
            this.FormPanel.Controls.Add(this.btnAutoCalculation);
            this.FormPanel.Controls.Add(this.btnPrintGrid);
            this.FormPanel.Controls.Add(this.btnApply);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnAccept);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(837, 570);
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
            // lblInsName
            // 
            this.lblInsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInsName.AutoSize = true;
            this.lblInsName.BackColor = System.Drawing.Color.Transparent;
            this.lblInsName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblInsName.Location = new System.Drawing.Point(768, 14);
            this.lblInsName.Name = "lblInsName";
            this.lblInsName.Size = new System.Drawing.Size(47, 16);
            this.lblInsName.TabIndex = 11;
            this.lblInsName.Text = "نام بیمه:";
            this.lblInsName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtInsName
            // 
            this.txtInsName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInsName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtInsName.Border.Class = "TextBoxBorder";
            this.txtInsName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtInsName.Location = new System.Drawing.Point(12, 12);
            this.txtInsName.Name = "txtInsName";
            this.txtInsName.ReadOnly = true;
            this.txtInsName.Size = new System.Drawing.Size(750, 21);
            this.txtInsName.TabIndex = 10;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
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
            this.ColCoverage,
            this.CategoryIX,
            this.Column2,
            this.Column3,
            this.ColInsPrice,
            this.ColInsPart,
            this.ColPatientPart,
            this.ColPatientPayble,
            this.Col1FreePrice,
            this.Col2GovPrice});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 39);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(813, 456);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValueChanged);
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvData_CellBeginEdit);
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            this.dgvData.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvData_CellValidating);
            // 
            // ColCoverage
            // 
            this.ColCoverage.DataPropertyName = "IsCover";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.NullValue = false;
            this.ColCoverage.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColCoverage.HeaderText = "پوشش";
            this.ColCoverage.Name = "ColCoverage";
            this.ColCoverage.ToolTipText = "تعیین تحت پوشش بودن خدمت برای بیمه انتخاب شده.";
            this.ColCoverage.Width = 50;
            // 
            // CategoryIX
            // 
            this.CategoryIX.DataPropertyName = "CategoryIX";
            this.CategoryIX.HeaderText = "كلید طبقه بندی";
            this.CategoryIX.Name = "CategoryIX";
            this.CategoryIX.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Code";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "كد";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Name";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "نام خدمت";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 300;
            // 
            // ColInsPrice
            // 
            this.ColInsPrice.DataPropertyName = "InsPrice";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle5.NullValue = "0";
            this.ColInsPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColInsPrice.HeaderText = "قیمت بیمه";
            this.ColInsPrice.Name = "ColInsPrice";
            this.ColInsPrice.ToolTipText = "قیمتی كه به عنوان قیمت مصوب بیمه اعلام می گردد.";
            this.ColInsPrice.Width = 80;
            // 
            // ColInsPart
            // 
            this.ColInsPart.DataPropertyName = "InsPart";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle6.NullValue = "0";
            this.ColInsPart.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColInsPart.HeaderText = "سهم بیمه";
            this.ColInsPart.Name = "ColInsPart";
            this.ColInsPart.ToolTipText = "قیمتی كه به عنوان سهم بیمه برای خدمت محاسبه می گردد.";
            this.ColInsPart.Width = 80;
            // 
            // ColPatientPart
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColPatientPart.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColPatientPart.HeaderText = "سهم بیمار";
            this.ColPatientPart.Name = "ColPatientPart";
            this.ColPatientPart.ReadOnly = true;
            this.ColPatientPart.ToolTipText = "سهم بیمار قیمتی است كه به بیمه به عنوان سهم پرداختی بیمار اعلام می گردد و برابر ا" +
                "ست با قیمت بیمه منهای سهم بیمه.";
            this.ColPatientPart.Width = 80;
            // 
            // ColPatientPayble
            // 
            this.ColPatientPayble.DataPropertyName = "PatientPayable";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle8.NullValue = "0";
            this.ColPatientPayble.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColPatientPayble.HeaderText = "پرداختنی بیمار";
            this.ColPatientPayble.Name = "ColPatientPayble";
            this.ColPatientPayble.ToolTipText = "مبلغی كه بیمار دارای این بیمه برای این خدمت پرداخت می نماید.";
            this.ColPatientPayble.Width = 80;
            // 
            // Col1FreePrice
            // 
            this.Col1FreePrice.DataPropertyName = "PriceFree";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle9.NullValue = "0";
            this.Col1FreePrice.DefaultCellStyle = dataGridViewCellStyle9;
            this.Col1FreePrice.HeaderText = "تعرفه بدون بیمه";
            this.Col1FreePrice.Name = "Col1FreePrice";
            this.Col1FreePrice.ReadOnly = true;
            this.Col1FreePrice.Width = 80;
            // 
            // Col2GovPrice
            // 
            this.Col2GovPrice.DataPropertyName = "PriceGov";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle10.NullValue = "0";
            this.Col2GovPrice.DefaultCellStyle = dataGridViewCellStyle10;
            this.Col2GovPrice.HeaderText = "تعرفه دولتی";
            this.Col2GovPrice.Name = "Col2GovPrice";
            this.Col2GovPrice.ReadOnly = true;
            this.Col2GovPrice.Width = 80;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(730, 501);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnAll
            // 
            this.btnAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAll.Image = global::Sepehr.Settings.Insurances.Properties.Resources.SelectAll;
            this.btnAll.ImageFixedSize = new System.Drawing.Size(36, 36);
            this.btnAll.Location = new System.Drawing.Point(629, 501);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(95, 57);
            this.btnAll.TabIndex = 7;
            this.btnAll.TabStop = false;
            this.btnAll.Text = "پوشش همه";
            this.btnAll.Click += new System.EventHandler(this.btnAllAndNone_Click);
            // 
            // btnNone
            // 
            this.btnNone.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNone.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnNone.Image = global::Sepehr.Settings.Insurances.Properties.Resources.SelectNone;
            this.btnNone.ImageFixedSize = new System.Drawing.Size(36, 36);
            this.btnNone.Location = new System.Drawing.Point(528, 501);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(95, 57);
            this.btnNone.TabIndex = 6;
            this.btnNone.TabStop = false;
            this.btnNone.Text = "عدم پوشش";
            this.btnNone.Click += new System.EventHandler(this.btnAllAndNone_Click);
            // 
            // btnAutoCalculation
            // 
            this.btnAutoCalculation.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAutoCalculation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoCalculation.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAutoCalculation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAutoCalculation.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Automatic;
            this.btnAutoCalculation.ImageFixedSize = new System.Drawing.Size(36, 36);
            this.btnAutoCalculation.Location = new System.Drawing.Point(426, 501);
            this.btnAutoCalculation.Name = "btnAutoCalculation";
            this.btnAutoCalculation.Size = new System.Drawing.Size(96, 57);
            this.btnAutoCalculation.TabIndex = 5;
            this.btnAutoCalculation.TabStop = false;
            this.btnAutoCalculation.Text = "محاسبه خودكار";
            this.btnAutoCalculation.Click += new System.EventHandler(this.btnAutoCalculation_Click);
            // 
            // btnPrintGrid
            // 
            this.btnPrintGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrintGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintGrid.Image = global::Sepehr.Settings.Insurances.Properties.Resources.PrintGrid;
            this.btnPrintGrid.Location = new System.Drawing.Point(324, 501);
            this.btnPrintGrid.Name = "btnPrintGrid";
            this.btnPrintGrid.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlP);
            this.btnPrintGrid.Size = new System.Drawing.Size(96, 57);
            this.btnPrintGrid.TabIndex = 4;
            this.btnPrintGrid.TabStop = false;
            this.btnPrintGrid.Text = "چاپ جدول (Ctrl+P)";
            this.btnPrintGrid.Click += new System.EventHandler(this.btnPrintGrid_Click);
            // 
            // btnApply
            // 
            this.btnApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApply.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Apply;
            this.btnApply.Location = new System.Drawing.Point(214, 501);
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
            this.btnCancel.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 501);
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
            this.btnAccept.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 501);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تایید\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmServicesCoverage
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(837, 570);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(845, 600);
            this.Name = "frmServicesCoverage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - مراجعات - بیمه ها - فرم مدیریت ارتباط بیمه ی انتخاب شده با خدمات تصویرب" +
                "رداری";
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
        private DevComponents.DotNetBar.LabelX lblInsName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtInsName;
        private System.Windows.Forms.DataGridView dgvData;
        internal DevComponents.DotNetBar.ButtonX btnHelp;
        internal DevComponents.DotNetBar.ButtonX btnNone;
        internal DevComponents.DotNetBar.ButtonX btnAll;
        internal DevComponents.DotNetBar.ButtonX btnPrintGrid;
        internal DevComponents.DotNetBar.ButtonX btnApply;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        internal DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        internal DevComponents.DotNetBar.ButtonX btnAutoCalculation;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCoverage;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryIX;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInsPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInsPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPatientPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPatientPayble;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col1FreePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col2GovPrice;
    }
}