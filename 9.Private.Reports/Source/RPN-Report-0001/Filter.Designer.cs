namespace Negar.Customers.Reports0001
{
    partial class frmFilter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilter));
            this.cBoxPhys = new System.Windows.Forms.CheckBox();
            this.dgvPhysicians = new System.Windows.Forms.DataGridView();
            this.ColPhysSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColPhysName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBoxServiceCat = new System.Windows.Forms.CheckBox();
            this.dgvServiceCat = new System.Windows.Forms.DataGridView();
            this.ColServSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHeader2 = new System.Windows.Forms.Label();
            this.lblHeader1 = new System.Windows.Forms.Label();
            this.txtHeader2 = new System.Windows.Forms.TextBox();
            this.txtHeader1 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.PanelTransDateTimeFilter = new System.Windows.Forms.GroupBox();
            this.TransTimeTo = new System.Windows.Forms.DateTimePicker();
            this.lblTransTimeTo = new System.Windows.Forms.Label();
            this.TransTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTransTimeFrom = new System.Windows.Forms.Label();
            this.lblTransDateTo = new System.Windows.Forms.Label();
            this.lblTransDateFrom = new System.Windows.Forms.Label();
            this.TransDateTo = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.TransDateFrom = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.PanelRefDateTimeFilter = new System.Windows.Forms.GroupBox();
            this.ToTimeRef = new System.Windows.Forms.DateTimePicker();
            this.FromTimeRef = new System.Windows.Forms.DateTimePicker();
            this.lblToRefTime = new System.Windows.Forms.Label();
            this.lblFromRefTime = new System.Windows.Forms.Label();
            this.lblToRefDate = new System.Windows.Forms.Label();
            this.lblFromRefDate = new System.Windows.Forms.Label();
            this.ToDateRef = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDateRef = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.dgvRefPhys = new System.Windows.Forms.DataGridView();
            this.ColRefPhysSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColRefPhysName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInsFilter = new System.Windows.Forms.DataGridView();
            this.ColInsSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColInsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBoxRefPhys = new System.Windows.Forms.CheckBox();
            this.cBoxTransDateFilter = new System.Windows.Forms.CheckBox();
            this.cBoxIns1 = new System.Windows.Forms.CheckBox();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.cBoxService = new System.Windows.Forms.CheckBox();
            this.cBoxDiscountOnly = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhysicians)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceCat)).BeginInit();
            this.PanelTransDateTimeFilter.SuspendLayout();
            this.PanelRefDateTimeFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefPhys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // cBoxPhys
            // 
            this.cBoxPhys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxPhys.AutoSize = true;
            this.cBoxPhys.BackColor = System.Drawing.Color.Transparent;
            this.cBoxPhys.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxPhys.Location = new System.Drawing.Point(287, 268);
            this.cBoxPhys.Name = "cBoxPhys";
            this.cBoxPhys.Size = new System.Drawing.Size(272, 17);
            this.cBoxPhys.TabIndex = 7;
            this.cBoxPhys.Text = "خدماتی كه پزشك آنها یكی از پزشكان زیر باشد:";
            this.cBoxPhys.UseVisualStyleBackColor = false;
            this.cBoxPhys.CheckedChanged += new System.EventHandler(this.cBoxPhys_CheckedChanged);
            // 
            // dgvPhysicians
            // 
            this.dgvPhysicians.AllowUserToAddRows = false;
            this.dgvPhysicians.AllowUserToDeleteRows = false;
            this.dgvPhysicians.AllowUserToOrderColumns = true;
            this.dgvPhysicians.AllowUserToResizeColumns = false;
            this.dgvPhysicians.AllowUserToResizeRows = false;
            this.dgvPhysicians.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhysicians.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvPhysicians.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhysicians.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhysicians.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhysicians.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPhysSelection,
            this.ColPhysName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhysicians.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhysicians.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPhysicians.Location = new System.Drawing.Point(272, 290);
            this.dgvPhysicians.MultiSelect = false;
            this.dgvPhysicians.Name = "dgvPhysicians";
            this.dgvPhysicians.RowHeadersVisible = false;
            this.dgvPhysicians.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhysicians.Size = new System.Drawing.Size(287, 156);
            this.dgvPhysicians.TabIndex = 8;
            // 
            // ColPhysSelection
            // 
            this.ColPhysSelection.HeaderText = "اضافه";
            this.ColPhysSelection.Name = "ColPhysSelection";
            this.ColPhysSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPhysSelection.Width = 35;
            // 
            // ColPhysName
            // 
            this.ColPhysName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColPhysName.DataPropertyName = "FullName";
            this.ColPhysName.HeaderText = "نام پزشك";
            this.ColPhysName.Name = "ColPhysName";
            this.ColPhysName.ReadOnly = true;
            // 
            // cBoxServiceCat
            // 
            this.cBoxServiceCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxServiceCat.AutoSize = true;
            this.cBoxServiceCat.BackColor = System.Drawing.Color.Transparent;
            this.cBoxServiceCat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxServiceCat.Location = new System.Drawing.Point(285, 12);
            this.cBoxServiceCat.Name = "cBoxServiceCat";
            this.cBoxServiceCat.Size = new System.Drawing.Size(274, 17);
            this.cBoxServiceCat.TabIndex = 5;
            this.cBoxServiceCat.Text = "فقط خدمات مراجعه در طبقه بندی های زیر باشد:";
            this.cBoxServiceCat.UseVisualStyleBackColor = false;
            this.cBoxServiceCat.CheckedChanged += new System.EventHandler(this.cBoxServiceCat_CheckedChanged);
            // 
            // dgvServiceCat
            // 
            this.dgvServiceCat.AllowUserToAddRows = false;
            this.dgvServiceCat.AllowUserToDeleteRows = false;
            this.dgvServiceCat.AllowUserToOrderColumns = true;
            this.dgvServiceCat.AllowUserToResizeColumns = false;
            this.dgvServiceCat.AllowUserToResizeRows = false;
            this.dgvServiceCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiceCat.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvServiceCat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiceCat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvServiceCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceCat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColServSelection,
            this.ColCatName});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiceCat.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvServiceCat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvServiceCat.Location = new System.Drawing.Point(272, 60);
            this.dgvServiceCat.MultiSelect = false;
            this.dgvServiceCat.Name = "dgvServiceCat";
            this.dgvServiceCat.RowHeadersVisible = false;
            this.dgvServiceCat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiceCat.Size = new System.Drawing.Size(287, 202);
            this.dgvServiceCat.TabIndex = 6;
            // 
            // ColServSelection
            // 
            this.ColServSelection.HeaderText = "اضافه";
            this.ColServSelection.Name = "ColServSelection";
            this.ColServSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColServSelection.Width = 35;
            // 
            // ColCatName
            // 
            this.ColCatName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColCatName.DataPropertyName = "Name";
            this.ColCatName.HeaderText = "عنوان";
            this.ColCatName.Name = "ColCatName";
            this.ColCatName.ReadOnly = true;
            // 
            // lblHeader2
            // 
            this.lblHeader2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader2.AutoSize = true;
            this.lblHeader2.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHeader2.Location = new System.Drawing.Point(805, 484);
            this.lblHeader2.Name = "lblHeader2";
            this.lblHeader2.Size = new System.Drawing.Size(50, 13);
            this.lblHeader2.TabIndex = 16;
            this.lblHeader2.Text = "عنوان 2:";
            // 
            // lblHeader1
            // 
            this.lblHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader1.AutoSize = true;
            this.lblHeader1.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHeader1.Location = new System.Drawing.Point(805, 457);
            this.lblHeader1.Name = "lblHeader1";
            this.lblHeader1.Size = new System.Drawing.Size(50, 13);
            this.lblHeader1.TabIndex = 15;
            this.lblHeader1.Text = "عنوان 1:";
            // 
            // txtHeader2
            // 
            this.txtHeader2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader2.Location = new System.Drawing.Point(565, 482);
            this.txtHeader2.Name = "txtHeader2";
            this.txtHeader2.Size = new System.Drawing.Size(234, 21);
            this.txtHeader2.TabIndex = 17;
            // 
            // txtHeader1
            // 
            this.txtHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader1.Location = new System.Drawing.Point(565, 455);
            this.txtHeader1.Name = "txtHeader1";
            this.txtHeader1.Size = new System.Drawing.Size(234, 21);
            this.txtHeader1.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Negar.Customers.Reports0001.Properties.Resources.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(113, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Image = global::Negar.Customers.Reports0001.Properties.Resources.Accept;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(12, 455);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(95, 57);
            this.btnReport.TabIndex = 11;
            this.btnReport.TabStop = false;
            this.btnReport.Text = "گزارش";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // PanelTransDateTimeFilter
            // 
            this.PanelTransDateTimeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelTransDateTimeFilter.BackColor = System.Drawing.Color.Transparent;
            this.PanelTransDateTimeFilter.Controls.Add(this.TransTimeTo);
            this.PanelTransDateTimeFilter.Controls.Add(this.lblTransTimeTo);
            this.PanelTransDateTimeFilter.Controls.Add(this.TransTimeFrom);
            this.PanelTransDateTimeFilter.Controls.Add(this.lblTransTimeFrom);
            this.PanelTransDateTimeFilter.Controls.Add(this.lblTransDateTo);
            this.PanelTransDateTimeFilter.Controls.Add(this.lblTransDateFrom);
            this.PanelTransDateTimeFilter.Controls.Add(this.TransDateTo);
            this.PanelTransDateTimeFilter.Controls.Add(this.TransDateFrom);
            this.PanelTransDateTimeFilter.Enabled = false;
            this.PanelTransDateTimeFilter.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelTransDateTimeFilter.ForeColor = System.Drawing.Color.Blue;
            this.PanelTransDateTimeFilter.Location = new System.Drawing.Point(565, 115);
            this.PanelTransDateTimeFilter.Name = "PanelTransDateTimeFilter";
            this.PanelTransDateTimeFilter.Size = new System.Drawing.Size(287, 75);
            this.PanelTransDateTimeFilter.TabIndex = 2;
            this.PanelTransDateTimeFilter.TabStop = false;
            this.PanelTransDateTimeFilter.Text = "تاریخ دریافت یا پرداخت";
            // 
            // TransTimeTo
            // 
            this.TransTimeTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransTimeTo.CustomFormat = "ss:mm:HH";
            this.TransTimeTo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TransTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TransTimeTo.Location = new System.Drawing.Point(7, 47);
            this.TransTimeTo.Name = "TransTimeTo";
            this.TransTimeTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TransTimeTo.RightToLeftLayout = true;
            this.TransTimeTo.ShowUpDown = true;
            this.TransTimeTo.Size = new System.Drawing.Size(75, 20);
            this.TransTimeTo.TabIndex = 7;
            this.TransTimeTo.Value = new System.DateTime(2010, 7, 21, 12, 54, 0, 0);
            // 
            // lblTransTimeTo
            // 
            this.lblTransTimeTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransTimeTo.AutoSize = true;
            this.lblTransTimeTo.BackColor = System.Drawing.Color.Transparent;
            this.lblTransTimeTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTransTimeTo.Location = new System.Drawing.Point(89, 50);
            this.lblTransTimeTo.Name = "lblTransTimeTo";
            this.lblTransTimeTo.Size = new System.Drawing.Size(55, 13);
            this.lblTransTimeTo.TabIndex = 6;
            this.lblTransTimeTo.Text = "تا ساعت:";
            // 
            // TransTimeFrom
            // 
            this.TransTimeFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransTimeFrom.CustomFormat = "ss:mm:HH";
            this.TransTimeFrom.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TransTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TransTimeFrom.Location = new System.Drawing.Point(7, 21);
            this.TransTimeFrom.Name = "TransTimeFrom";
            this.TransTimeFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TransTimeFrom.RightToLeftLayout = true;
            this.TransTimeFrom.ShowUpDown = true;
            this.TransTimeFrom.Size = new System.Drawing.Size(75, 20);
            this.TransTimeFrom.TabIndex = 3;
            this.TransTimeFrom.Value = new System.DateTime(2010, 7, 21, 12, 54, 0, 0);
            // 
            // lblTransTimeFrom
            // 
            this.lblTransTimeFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransTimeFrom.AutoSize = true;
            this.lblTransTimeFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblTransTimeFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTransTimeFrom.Location = new System.Drawing.Point(89, 24);
            this.lblTransTimeFrom.Name = "lblTransTimeFrom";
            this.lblTransTimeFrom.Size = new System.Drawing.Size(56, 13);
            this.lblTransTimeFrom.TabIndex = 2;
            this.lblTransTimeFrom.Text = "از ساعت:";
            // 
            // lblTransDateTo
            // 
            this.lblTransDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransDateTo.AutoSize = true;
            this.lblTransDateTo.BackColor = System.Drawing.Color.Transparent;
            this.lblTransDateTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTransDateTo.Location = new System.Drawing.Point(237, 50);
            this.lblTransDateTo.Name = "lblTransDateTo";
            this.lblTransDateTo.Size = new System.Drawing.Size(47, 13);
            this.lblTransDateTo.TabIndex = 4;
            this.lblTransDateTo.Text = "تا تاریخ:";
            // 
            // lblTransDateFrom
            // 
            this.lblTransDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransDateFrom.AutoSize = true;
            this.lblTransDateFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblTransDateFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTransDateFrom.Location = new System.Drawing.Point(237, 24);
            this.lblTransDateFrom.Name = "lblTransDateFrom";
            this.lblTransDateFrom.Size = new System.Drawing.Size(48, 13);
            this.lblTransDateFrom.TabIndex = 1;
            this.lblTransDateFrom.Text = "از تاریخ:";
            // 
            // TransDateTo
            // 
            this.TransDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransDateTo.IsAllowNullDate = false;
            this.TransDateTo.IsPopupOpen = false;
            this.TransDateTo.Location = new System.Drawing.Point(147, 48);
            this.TransDateTo.Name = "TransDateTo";
            this.TransDateTo.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.TransDateTo.Size = new System.Drawing.Size(84, 20);
            this.TransDateTo.TabIndex = 5;
            // 
            // TransDateFrom
            // 
            this.TransDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransDateFrom.IsAllowNullDate = false;
            this.TransDateFrom.IsPopupOpen = false;
            this.TransDateFrom.Location = new System.Drawing.Point(147, 22);
            this.TransDateFrom.Name = "TransDateFrom";
            this.TransDateFrom.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.TransDateFrom.Size = new System.Drawing.Size(84, 20);
            this.TransDateFrom.TabIndex = 0;
            // 
            // PanelRefDateTimeFilter
            // 
            this.PanelRefDateTimeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelRefDateTimeFilter.BackColor = System.Drawing.Color.Transparent;
            this.PanelRefDateTimeFilter.Controls.Add(this.ToTimeRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.FromTimeRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblToRefTime);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblFromRefTime);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblToRefDate);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblFromRefDate);
            this.PanelRefDateTimeFilter.Controls.Add(this.ToDateRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.FromDateRef);
            this.PanelRefDateTimeFilter.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelRefDateTimeFilter.ForeColor = System.Drawing.Color.Blue;
            this.PanelRefDateTimeFilter.Location = new System.Drawing.Point(565, 12);
            this.PanelRefDateTimeFilter.Name = "PanelRefDateTimeFilter";
            this.PanelRefDateTimeFilter.Size = new System.Drawing.Size(287, 75);
            this.PanelRefDateTimeFilter.TabIndex = 0;
            this.PanelRefDateTimeFilter.TabStop = false;
            this.PanelRefDateTimeFilter.Text = "تاریخ پذیرش مراجعه";
            // 
            // ToTimeRef
            // 
            this.ToTimeRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToTimeRef.CustomFormat = "ss:mm:HH";
            this.ToTimeRef.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ToTimeRef.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToTimeRef.Location = new System.Drawing.Point(7, 45);
            this.ToTimeRef.Name = "ToTimeRef";
            this.ToTimeRef.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToTimeRef.RightToLeftLayout = true;
            this.ToTimeRef.ShowUpDown = true;
            this.ToTimeRef.Size = new System.Drawing.Size(75, 20);
            this.ToTimeRef.TabIndex = 7;
            this.ToTimeRef.Value = new System.DateTime(2010, 7, 21, 12, 54, 0, 0);
            // 
            // FromTimeRef
            // 
            this.FromTimeRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromTimeRef.CustomFormat = "ss:mm:HH";
            this.FromTimeRef.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FromTimeRef.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromTimeRef.Location = new System.Drawing.Point(7, 19);
            this.FromTimeRef.Name = "FromTimeRef";
            this.FromTimeRef.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FromTimeRef.RightToLeftLayout = true;
            this.FromTimeRef.ShowUpDown = true;
            this.FromTimeRef.Size = new System.Drawing.Size(75, 20);
            this.FromTimeRef.TabIndex = 3;
            this.FromTimeRef.Value = new System.DateTime(2010, 7, 21, 12, 54, 0, 0);
            // 
            // lblToRefTime
            // 
            this.lblToRefTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToRefTime.AutoSize = true;
            this.lblToRefTime.BackColor = System.Drawing.Color.Transparent;
            this.lblToRefTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToRefTime.Location = new System.Drawing.Point(89, 48);
            this.lblToRefTime.Name = "lblToRefTime";
            this.lblToRefTime.Size = new System.Drawing.Size(55, 13);
            this.lblToRefTime.TabIndex = 6;
            this.lblToRefTime.Text = "تا ساعت:";
            // 
            // lblFromRefTime
            // 
            this.lblFromRefTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromRefTime.AutoSize = true;
            this.lblFromRefTime.BackColor = System.Drawing.Color.Transparent;
            this.lblFromRefTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromRefTime.Location = new System.Drawing.Point(89, 22);
            this.lblFromRefTime.Name = "lblFromRefTime";
            this.lblFromRefTime.Size = new System.Drawing.Size(56, 13);
            this.lblFromRefTime.TabIndex = 2;
            this.lblFromRefTime.Text = "از ساعت:";
            // 
            // lblToRefDate
            // 
            this.lblToRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToRefDate.AutoSize = true;
            this.lblToRefDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToRefDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToRefDate.Location = new System.Drawing.Point(237, 48);
            this.lblToRefDate.Name = "lblToRefDate";
            this.lblToRefDate.Size = new System.Drawing.Size(47, 13);
            this.lblToRefDate.TabIndex = 4;
            this.lblToRefDate.Text = "تا تاریخ:";
            // 
            // lblFromRefDate
            // 
            this.lblFromRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromRefDate.AutoSize = true;
            this.lblFromRefDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromRefDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromRefDate.Location = new System.Drawing.Point(237, 22);
            this.lblFromRefDate.Name = "lblFromRefDate";
            this.lblFromRefDate.Size = new System.Drawing.Size(48, 13);
            this.lblFromRefDate.TabIndex = 1;
            this.lblFromRefDate.Text = "از تاریخ:";
            // 
            // ToDateRef
            // 
            this.ToDateRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDateRef.IsAllowNullDate = false;
            this.ToDateRef.IsPopupOpen = false;
            this.ToDateRef.Location = new System.Drawing.Point(147, 46);
            this.ToDateRef.Name = "ToDateRef";
            this.ToDateRef.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.ToDateRef.Size = new System.Drawing.Size(84, 20);
            this.ToDateRef.TabIndex = 5;
            // 
            // FromDateRef
            // 
            this.FromDateRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDateRef.IsAllowNullDate = false;
            this.FromDateRef.IsPopupOpen = false;
            this.FromDateRef.Location = new System.Drawing.Point(147, 20);
            this.FromDateRef.Name = "FromDateRef";
            this.FromDateRef.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.FromDateRef.Size = new System.Drawing.Size(84, 20);
            this.FromDateRef.TabIndex = 0;
            // 
            // dgvRefPhys
            // 
            this.dgvRefPhys.AllowUserToAddRows = false;
            this.dgvRefPhys.AllowUserToDeleteRows = false;
            this.dgvRefPhys.AllowUserToOrderColumns = true;
            this.dgvRefPhys.AllowUserToResizeColumns = false;
            this.dgvRefPhys.AllowUserToResizeRows = false;
            this.dgvRefPhys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRefPhys.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvRefPhys.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRefPhys.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRefPhys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefPhys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRefPhysSelection,
            this.ColRefPhysName});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefPhys.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRefPhys.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvRefPhys.Location = new System.Drawing.Point(12, 34);
            this.dgvRefPhys.MultiSelect = false;
            this.dgvRefPhys.Name = "dgvRefPhys";
            this.dgvRefPhys.RowHeadersVisible = false;
            this.dgvRefPhys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefPhys.Size = new System.Drawing.Size(254, 412);
            this.dgvRefPhys.StandardTab = true;
            this.dgvRefPhys.TabIndex = 10;
            // 
            // ColRefPhysSelection
            // 
            this.ColRefPhysSelection.HeaderText = "اضافه";
            this.ColRefPhysSelection.Name = "ColRefPhysSelection";
            this.ColRefPhysSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefPhysSelection.Width = 35;
            // 
            // ColRefPhysName
            // 
            this.ColRefPhysName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColRefPhysName.DataPropertyName = "FullName";
            this.ColRefPhysName.HeaderText = "نام پزشك";
            this.ColRefPhysName.Name = "ColRefPhysName";
            this.ColRefPhysName.ReadOnly = true;
            // 
            // dgvInsFilter
            // 
            this.dgvInsFilter.AllowUserToAddRows = false;
            this.dgvInsFilter.AllowUserToDeleteRows = false;
            this.dgvInsFilter.AllowUserToOrderColumns = true;
            this.dgvInsFilter.AllowUserToResizeColumns = false;
            this.dgvInsFilter.AllowUserToResizeRows = false;
            this.dgvInsFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInsFilter.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvInsFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsFilter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInsFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColInsSelection,
            this.ColInsName});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsFilter.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInsFilter.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvInsFilter.Location = new System.Drawing.Point(565, 218);
            this.dgvInsFilter.MultiSelect = false;
            this.dgvInsFilter.Name = "dgvInsFilter";
            this.dgvInsFilter.RowHeadersVisible = false;
            this.dgvInsFilter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsFilter.Size = new System.Drawing.Size(287, 228);
            this.dgvInsFilter.StandardTab = true;
            this.dgvInsFilter.TabIndex = 4;
            // 
            // ColInsSelection
            // 
            this.ColInsSelection.HeaderText = "اضافه";
            this.ColInsSelection.Name = "ColInsSelection";
            this.ColInsSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColInsSelection.Width = 35;
            // 
            // ColInsName
            // 
            this.ColInsName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColInsName.DataPropertyName = "Name";
            this.ColInsName.HeaderText = "نام بیمه";
            this.ColInsName.Name = "ColInsName";
            this.ColInsName.ReadOnly = true;
            // 
            // cBoxRefPhys
            // 
            this.cBoxRefPhys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxRefPhys.AutoSize = true;
            this.cBoxRefPhys.BackColor = System.Drawing.Color.Transparent;
            this.cBoxRefPhys.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxRefPhys.Location = new System.Drawing.Point(68, 12);
            this.cBoxRefPhys.Name = "cBoxRefPhys";
            this.cBoxRefPhys.Size = new System.Drawing.Size(198, 17);
            this.cBoxRefPhys.TabIndex = 9;
            this.cBoxRefPhys.TabStop = false;
            this.cBoxRefPhys.Text = "فقط با پزشك درخواست كننده زیر:";
            this.cBoxRefPhys.UseVisualStyleBackColor = false;
            this.cBoxRefPhys.CheckedChanged += new System.EventHandler(this.cBoxRefPhys_CheckedChanged);
            // 
            // cBoxTransDateFilter
            // 
            this.cBoxTransDateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxTransDateFilter.AutoSize = true;
            this.cBoxTransDateFilter.BackColor = System.Drawing.Color.Transparent;
            this.cBoxTransDateFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxTransDateFilter.Location = new System.Drawing.Point(602, 94);
            this.cBoxTransDateFilter.Name = "cBoxTransDateFilter";
            this.cBoxTransDateFilter.Size = new System.Drawing.Size(250, 17);
            this.cBoxTransDateFilter.TabIndex = 1;
            this.cBoxTransDateFilter.TabStop = false;
            this.cBoxTransDateFilter.Text = "جستجو بر اساس تاریخ دریافت یا بازپرداخت";
            this.cBoxTransDateFilter.UseVisualStyleBackColor = false;
            this.cBoxTransDateFilter.CheckedChanged += new System.EventHandler(this.cBoxTransDateFilter_CheckedChanged);
            // 
            // cBoxIns1
            // 
            this.cBoxIns1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxIns1.AutoSize = true;
            this.cBoxIns1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIns1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxIns1.Location = new System.Drawing.Point(770, 196);
            this.cBoxIns1.Name = "cBoxIns1";
            this.cBoxIns1.Size = new System.Drawing.Size(83, 17);
            this.cBoxIns1.TabIndex = 3;
            this.cBoxIns1.TabStop = false;
            this.cBoxIns1.Text = "با بیمه اول:";
            this.cBoxIns1.UseVisualStyleBackColor = false;
            this.cBoxIns1.CheckedChanged += new System.EventHandler(this.cBoxIns1_CheckedChanged);
            // 
            // BGWorker
            // 
            this.BGWorker.WorkerSupportsCancellation = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(214, 455);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(345, 23);
            this.ProgressBar.TabIndex = 18;
            // 
            // cBoxService
            // 
            this.cBoxService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxService.AutoSize = true;
            this.cBoxService.BackColor = System.Drawing.Color.Transparent;
            this.cBoxService.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxService.Location = new System.Drawing.Point(412, 35);
            this.cBoxService.Name = "cBoxService";
            this.cBoxService.Size = new System.Drawing.Size(147, 17);
            this.cBoxService.TabIndex = 19;
            this.cBoxService.Text = "فقط خدمات مراجعه زیر:";
            this.cBoxService.UseVisualStyleBackColor = false;
            this.cBoxService.CheckedChanged += new System.EventHandler(this.cBoxServiceCat_CheckedChanged);
            // 
            // cBoxDiscountOnly
            // 
            this.cBoxDiscountOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxDiscountOnly.AutoSize = true;
            this.cBoxDiscountOnly.BackColor = System.Drawing.Color.Transparent;
            this.cBoxDiscountOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxDiscountOnly.ForeColor = System.Drawing.Color.Red;
            this.cBoxDiscountOnly.Location = new System.Drawing.Point(367, 486);
            this.cBoxDiscountOnly.Name = "cBoxDiscountOnly";
            this.cBoxDiscountOnly.Size = new System.Drawing.Size(192, 17);
            this.cBoxDiscountOnly.TabIndex = 9;
            this.cBoxDiscountOnly.TabStop = false;
            this.cBoxDiscountOnly.Text = "تنها نمایش بیماران دارای تخفیف";
            this.cBoxDiscountOnly.UseVisualStyleBackColor = false;
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(864, 524);
            this.Controls.Add(this.cBoxService);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.cBoxPhys);
            this.Controls.Add(this.dgvPhysicians);
            this.Controls.Add(this.PanelRefDateTimeFilter);
            this.Controls.Add(this.cBoxServiceCat);
            this.Controls.Add(this.cBoxIns1);
            this.Controls.Add(this.dgvServiceCat);
            this.Controls.Add(this.cBoxTransDateFilter);
            this.Controls.Add(this.lblHeader2);
            this.Controls.Add(this.cBoxDiscountOnly);
            this.Controls.Add(this.cBoxRefPhys);
            this.Controls.Add(this.lblHeader1);
            this.Controls.Add(this.dgvInsFilter);
            this.Controls.Add(this.txtHeader2);
            this.Controls.Add(this.dgvRefPhys);
            this.Controls.Add(this.txtHeader1);
            this.Controls.Add(this.PanelTransDateTimeFilter);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnCancel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFilter";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش های اختصاصی مشتریان - گزارش حسابداری - كلینیك سهند قزوین";
            this.Shown += new System.EventHandler(this.frmInsurancesFilter_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhysicians)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceCat)).EndInit();
            this.PanelTransDateTimeFilter.ResumeLayout(false);
            this.PanelTransDateTimeFilter.PerformLayout();
            this.PanelRefDateTimeFilter.ResumeLayout(false);
            this.PanelRefDateTimeFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefPhys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReport;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDateRef;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDateRef;
        private System.Windows.Forms.GroupBox PanelRefDateTimeFilter;
        private System.Windows.Forms.CheckBox cBoxIns1;
        private System.Windows.Forms.DataGridView dgvInsFilter;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColInsSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInsName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblToRefTime;
        private System.Windows.Forms.Label lblFromRefTime;
        private System.Windows.Forms.Label lblToRefDate;
        private System.Windows.Forms.Label lblFromRefDate;
        private System.Windows.Forms.CheckBox cBoxServiceCat;
        private System.Windows.Forms.DataGridView dgvServiceCat;
        private System.Windows.Forms.Label lblHeader2;
        private System.Windows.Forms.Label lblHeader1;
        private System.Windows.Forms.TextBox txtHeader2;
        private System.Windows.Forms.TextBox txtHeader1;
        private System.Windows.Forms.CheckBox cBoxPhys;
        private System.Windows.Forms.DataGridView dgvPhysicians;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColPhysSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhysName;
        private System.Windows.Forms.DataGridView dgvRefPhys;
        private System.Windows.Forms.CheckBox cBoxRefPhys;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColRefPhysSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefPhysName;
        private System.Windows.Forms.GroupBox PanelTransDateTimeFilter;
        private System.Windows.Forms.Label lblTransTimeTo;
        private System.Windows.Forms.Label lblTransTimeFrom;
        private System.Windows.Forms.Label lblTransDateTo;
        private System.Windows.Forms.Label lblTransDateFrom;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker TransDateTo;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker TransDateFrom;
        private System.Windows.Forms.CheckBox cBoxTransDateFilter;
        private System.Windows.Forms.DateTimePicker FromTimeRef;
        private System.Windows.Forms.DateTimePicker ToTimeRef;
        private System.Windows.Forms.DateTimePicker TransTimeFrom;
        private System.Windows.Forms.DateTimePicker TransTimeTo;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.CheckBox cBoxService;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColServSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCatName;
        private System.Windows.Forms.CheckBox cBoxDiscountOnly;
    }
}