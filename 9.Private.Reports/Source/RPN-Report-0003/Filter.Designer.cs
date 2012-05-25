namespace Negar.Customers.Reports0003
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilter));
            this.cBoxServiceCat = new System.Windows.Forms.CheckBox();
            this.dgvServiceCat = new System.Windows.Forms.DataGridView();
            this.ColServSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColServName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHeader1 = new System.Windows.Forms.Label();
            this.txtHeader1 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.PanelRefDateTimeFilter = new System.Windows.Forms.GroupBox();
            this.ToTimeRef = new System.Windows.Forms.DateTimePicker();
            this.FromTimeRef = new System.Windows.Forms.DateTimePicker();
            this.lblToRefTime = new System.Windows.Forms.Label();
            this.lblFromRefTime = new System.Windows.Forms.Label();
            this.lblToRefDate = new System.Windows.Forms.Label();
            this.lblFromRefDate = new System.Windows.Forms.Label();
            this.ToDateRef = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDateRef = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.cBoxService = new System.Windows.Forms.CheckBox();
            this.ColPerformerSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColPerformerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsExpert = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColIsPhysician = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvPhysician = new System.Windows.Forms.DataGridView();
            this.ColPhysSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColPhysName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBoxServPhysician = new System.Windows.Forms.CheckBox();
            this.cBoxRefPhysician = new System.Windows.Forms.CheckBox();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblPhysician = new System.Windows.Forms.Label();
            this.PanelPercent = new System.Windows.Forms.GroupBox();
            this.cBoxCalcByPatientPayablePrice = new System.Windows.Forms.CheckBox();
            this.txtUniversity = new System.Windows.Forms.NumericUpDown();
            this.txtPhysician = new System.Windows.Forms.NumericUpDown();
            this.txtTax = new System.Windows.Forms.NumericUpDown();
            this.lblUniversity = new System.Windows.Forms.Label();
            this.cBoxIns1 = new System.Windows.Forms.CheckBox();
            this.dgvInsFilter = new System.Windows.Forms.DataGridView();
            this.ColInsSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColInsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBoxJustIns = new System.Windows.Forms.CheckBox();
            this.cBoxHideUniversityPercent = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceCat)).BeginInit();
            this.PanelRefDateTimeFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhysician)).BeginInit();
            this.PanelPercent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUniversity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhysician)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // cBoxServiceCat
            // 
            this.cBoxServiceCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxServiceCat.AutoSize = true;
            this.cBoxServiceCat.BackColor = System.Drawing.Color.Transparent;
            this.cBoxServiceCat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxServiceCat.Location = new System.Drawing.Point(616, 93);
            this.cBoxServiceCat.Name = "cBoxServiceCat";
            this.cBoxServiceCat.Size = new System.Drawing.Size(274, 17);
            this.cBoxServiceCat.TabIndex = 2;
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
            this.dgvServiceCat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiceCat.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvServiceCat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiceCat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiceCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceCat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColServSelection,
            this.ColServName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiceCat.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServiceCat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvServiceCat.Location = new System.Drawing.Point(603, 139);
            this.dgvServiceCat.MultiSelect = false;
            this.dgvServiceCat.Name = "dgvServiceCat";
            this.dgvServiceCat.RowHeadersVisible = false;
            this.dgvServiceCat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiceCat.Size = new System.Drawing.Size(287, 310);
            this.dgvServiceCat.TabIndex = 4;
            // 
            // ColServSelection
            // 
            this.ColServSelection.HeaderText = "اضافه";
            this.ColServSelection.Name = "ColServSelection";
            this.ColServSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColServSelection.Width = 35;
            // 
            // ColServName
            // 
            this.ColServName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColServName.DataPropertyName = "Name";
            this.ColServName.HeaderText = "عنوان";
            this.ColServName.Name = "ColServName";
            this.ColServName.ReadOnly = true;
            // 
            // lblHeader1
            // 
            this.lblHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader1.AutoSize = true;
            this.lblHeader1.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHeader1.Location = new System.Drawing.Point(850, 457);
            this.lblHeader1.Name = "lblHeader1";
            this.lblHeader1.Size = new System.Drawing.Size(40, 13);
            this.lblHeader1.TabIndex = 11;
            this.lblHeader1.Text = "عنوان:";
            // 
            // txtHeader1
            // 
            this.txtHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader1.Location = new System.Drawing.Point(383, 455);
            this.txtHeader1.Name = "txtHeader1";
            this.txtHeader1.Size = new System.Drawing.Size(461, 21);
            this.txtHeader1.TabIndex = 10;
            this.txtHeader1.Text = "گزارش كاركرد كادر پزشكی";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Negar.Customers.Reports0003.Properties.Resources.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(113, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Image = global::Negar.Customers.Reports0003.Properties.Resources.Accept;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(12, 455);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(95, 57);
            this.btnReport.TabIndex = 8;
            this.btnReport.TabStop = false;
            this.btnReport.Text = "گزارش";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
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
            this.PanelRefDateTimeFilter.Location = new System.Drawing.Point(603, 12);
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
            this.ProgressBar.Location = new System.Drawing.Point(214, 482);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(676, 23);
            this.ProgressBar.TabIndex = 12;
            // 
            // cBoxService
            // 
            this.cBoxService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxService.AutoSize = true;
            this.cBoxService.BackColor = System.Drawing.Color.Transparent;
            this.cBoxService.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxService.Location = new System.Drawing.Point(743, 116);
            this.cBoxService.Name = "cBoxService";
            this.cBoxService.Size = new System.Drawing.Size(147, 17);
            this.cBoxService.TabIndex = 3;
            this.cBoxService.Text = "فقط خدمات مراجعه زیر:";
            this.cBoxService.UseVisualStyleBackColor = false;
            this.cBoxService.CheckedChanged += new System.EventHandler(this.cBoxServiceCat_CheckedChanged);
            // 
            // ColPerformerSelection
            // 
            this.ColPerformerSelection.HeaderText = "اضافه";
            this.ColPerformerSelection.Name = "ColPerformerSelection";
            this.ColPerformerSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPerformerSelection.Width = 35;
            // 
            // ColPerformerName
            // 
            this.ColPerformerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColPerformerName.DataPropertyName = "FullName";
            this.ColPerformerName.HeaderText = "نام";
            this.ColPerformerName.Name = "ColPerformerName";
            this.ColPerformerName.ReadOnly = true;
            // 
            // ColIsExpert
            // 
            this.ColIsExpert.HeaderText = "كارشناس";
            this.ColIsExpert.Name = "ColIsExpert";
            this.ColIsExpert.Width = 50;
            // 
            // ColIsPhysician
            // 
            this.ColIsPhysician.HeaderText = "پزشك";
            this.ColIsPhysician.Name = "ColIsPhysician";
            this.ColIsPhysician.Width = 40;
            // 
            // dgvPhysician
            // 
            this.dgvPhysician.AllowUserToAddRows = false;
            this.dgvPhysician.AllowUserToDeleteRows = false;
            this.dgvPhysician.AllowUserToOrderColumns = true;
            this.dgvPhysician.AllowUserToResizeColumns = false;
            this.dgvPhysician.AllowUserToResizeRows = false;
            this.dgvPhysician.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhysician.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvPhysician.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhysician.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhysician.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhysician.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPhysSelection,
            this.ColPhysName});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhysician.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPhysician.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPhysician.Location = new System.Drawing.Point(308, 139);
            this.dgvPhysician.MultiSelect = false;
            this.dgvPhysician.Name = "dgvPhysician";
            this.dgvPhysician.RowHeadersVisible = false;
            this.dgvPhysician.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhysician.Size = new System.Drawing.Size(289, 310);
            this.dgvPhysician.TabIndex = 7;
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
            this.ColPhysName.HeaderText = "نام و نام خانوادگی";
            this.ColPhysName.Name = "ColPhysName";
            this.ColPhysName.ReadOnly = true;
            // 
            // cBoxServPhysician
            // 
            this.cBoxServPhysician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxServPhysician.AutoSize = true;
            this.cBoxServPhysician.BackColor = System.Drawing.Color.Transparent;
            this.cBoxServPhysician.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxServPhysician.ForeColor = System.Drawing.Color.Purple;
            this.cBoxServPhysician.Location = new System.Drawing.Point(456, 93);
            this.cBoxServPhysician.Name = "cBoxServPhysician";
            this.cBoxServPhysician.Size = new System.Drawing.Size(141, 17);
            this.cBoxServPhysician.TabIndex = 5;
            this.cBoxServPhysician.Text = "فقط پزشكان مركز زیر:";
            this.cBoxServPhysician.UseVisualStyleBackColor = false;
            this.cBoxServPhysician.CheckedChanged += new System.EventHandler(this.cBoxServPhysician_CheckedChanged);
            // 
            // cBoxRefPhysician
            // 
            this.cBoxRefPhysician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxRefPhysician.AutoSize = true;
            this.cBoxRefPhysician.BackColor = System.Drawing.Color.Transparent;
            this.cBoxRefPhysician.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxRefPhysician.ForeColor = System.Drawing.Color.Purple;
            this.cBoxRefPhysician.Location = new System.Drawing.Point(400, 116);
            this.cBoxRefPhysician.Name = "cBoxRefPhysician";
            this.cBoxRefPhysician.Size = new System.Drawing.Size(197, 17);
            this.cBoxRefPhysician.TabIndex = 6;
            this.cBoxRefPhysician.Text = "فقط پزشكان درخواست كننده زیر:";
            this.cBoxRefPhysician.UseVisualStyleBackColor = false;
            this.cBoxRefPhysician.CheckedChanged += new System.EventHandler(this.cBoxServPhysician_CheckedChanged);
            // 
            // lblTax
            // 
            this.lblTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTax.AutoSize = true;
            this.lblTax.BackColor = System.Drawing.Color.Transparent;
            this.lblTax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTax.Location = new System.Drawing.Point(210, 23);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(73, 13);
            this.lblTax.TabIndex = 1;
            this.lblTax.Text = "درصد مالیات:";
            // 
            // lblPhysician
            // 
            this.lblPhysician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhysician.AutoSize = true;
            this.lblPhysician.BackColor = System.Drawing.Color.Transparent;
            this.lblPhysician.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPhysician.Location = new System.Drawing.Point(211, 49);
            this.lblPhysician.Name = "lblPhysician";
            this.lblPhysician.Size = new System.Drawing.Size(72, 13);
            this.lblPhysician.TabIndex = 4;
            this.lblPhysician.Text = "درصد پزشك:";
            // 
            // PanelPercent
            // 
            this.PanelPercent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelPercent.BackColor = System.Drawing.Color.Transparent;
            this.PanelPercent.Controls.Add(this.cBoxCalcByPatientPayablePrice);
            this.PanelPercent.Controls.Add(this.txtUniversity);
            this.PanelPercent.Controls.Add(this.txtPhysician);
            this.PanelPercent.Controls.Add(this.txtTax);
            this.PanelPercent.Controls.Add(this.lblUniversity);
            this.PanelPercent.Controls.Add(this.lblPhysician);
            this.PanelPercent.Controls.Add(this.lblTax);
            this.PanelPercent.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelPercent.ForeColor = System.Drawing.Color.Green;
            this.PanelPercent.Location = new System.Drawing.Point(308, 12);
            this.PanelPercent.Name = "PanelPercent";
            this.PanelPercent.Size = new System.Drawing.Size(289, 75);
            this.PanelPercent.TabIndex = 1;
            this.PanelPercent.TabStop = false;
            this.PanelPercent.Text = "درصد های كسورات و سهم پزشك";
            // 
            // cBoxCalcByPatientPayablePrice
            // 
            this.cBoxCalcByPatientPayablePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxCalcByPatientPayablePrice.AutoSize = true;
            this.cBoxCalcByPatientPayablePrice.BackColor = System.Drawing.Color.Transparent;
            this.cBoxCalcByPatientPayablePrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxCalcByPatientPayablePrice.ForeColor = System.Drawing.Color.Red;
            this.cBoxCalcByPatientPayablePrice.Location = new System.Drawing.Point(1, 47);
            this.cBoxCalcByPatientPayablePrice.Name = "cBoxCalcByPatientPayablePrice";
            this.cBoxCalcByPatientPayablePrice.Size = new System.Drawing.Size(153, 17);
            this.cBoxCalcByPatientPayablePrice.TabIndex = 13;
            this.cBoxCalcByPatientPayablePrice.Text = "بر مبنای پرداختی واقعی";
            this.cBoxCalcByPatientPayablePrice.UseVisualStyleBackColor = false;
            // 
            // txtUniversity
            // 
            this.txtUniversity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUniversity.Location = new System.Drawing.Point(18, 18);
            this.txtUniversity.Name = "txtUniversity";
            this.txtUniversity.Size = new System.Drawing.Size(44, 22);
            this.txtUniversity.TabIndex = 3;
            this.txtUniversity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUniversity.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // txtPhysician
            // 
            this.txtPhysician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhysician.Location = new System.Drawing.Point(162, 44);
            this.txtPhysician.Name = "txtPhysician";
            this.txtPhysician.Size = new System.Drawing.Size(44, 22);
            this.txtPhysician.TabIndex = 5;
            this.txtPhysician.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPhysician.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.txtPhysician.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // txtTax
            // 
            this.txtTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTax.Location = new System.Drawing.Point(162, 18);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(44, 22);
            this.txtTax.TabIndex = 0;
            this.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTax.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // lblUniversity
            // 
            this.lblUniversity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUniversity.AutoSize = true;
            this.lblUniversity.BackColor = System.Drawing.Color.Transparent;
            this.lblUniversity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUniversity.Location = new System.Drawing.Point(70, 23);
            this.lblUniversity.Name = "lblUniversity";
            this.lblUniversity.Size = new System.Drawing.Size(84, 13);
            this.lblUniversity.TabIndex = 2;
            this.lblUniversity.Text = "درصد دانشگاه:";
            // 
            // cBoxIns1
            // 
            this.cBoxIns1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxIns1.AutoSize = true;
            this.cBoxIns1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIns1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxIns1.Location = new System.Drawing.Point(220, 12);
            this.cBoxIns1.Name = "cBoxIns1";
            this.cBoxIns1.Size = new System.Drawing.Size(83, 17);
            this.cBoxIns1.TabIndex = 13;
            this.cBoxIns1.TabStop = false;
            this.cBoxIns1.Text = "با بیمه اول:";
            this.cBoxIns1.UseVisualStyleBackColor = false;
            this.cBoxIns1.CheckedChanged += new System.EventHandler(this.cBoxIns1_CheckedChanged);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsFilter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInsFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColInsSelection,
            this.ColInsName});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsFilter.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInsFilter.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvInsFilter.Location = new System.Drawing.Point(12, 34);
            this.dgvInsFilter.MultiSelect = false;
            this.dgvInsFilter.Name = "dgvInsFilter";
            this.dgvInsFilter.RowHeadersVisible = false;
            this.dgvInsFilter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsFilter.Size = new System.Drawing.Size(290, 415);
            this.dgvInsFilter.StandardTab = true;
            this.dgvInsFilter.TabIndex = 14;
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
            // cBoxJustIns
            // 
            this.cBoxJustIns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxJustIns.AutoSize = true;
            this.cBoxJustIns.BackColor = System.Drawing.Color.Transparent;
            this.cBoxJustIns.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxJustIns.Location = new System.Drawing.Point(69, 12);
            this.cBoxJustIns.Name = "cBoxJustIns";
            this.cBoxJustIns.Size = new System.Drawing.Size(145, 17);
            this.cBoxJustIns.TabIndex = 15;
            this.cBoxJustIns.TabStop = false;
            this.cBoxJustIns.Text = "فقط بیماران دارای بیمه";
            this.cBoxJustIns.UseVisualStyleBackColor = false;
            this.cBoxJustIns.CheckedChanged += new System.EventHandler(this.cBoxJustIns_CheckedChanged);
            // 
            // cBoxHideUniversityPercent
            // 
            this.cBoxHideUniversityPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxHideUniversityPercent.AutoSize = true;
            this.cBoxHideUniversityPercent.BackColor = System.Drawing.Color.Transparent;
            this.cBoxHideUniversityPercent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxHideUniversityPercent.ForeColor = System.Drawing.Color.Red;
            this.cBoxHideUniversityPercent.Location = new System.Drawing.Point(216, 457);
            this.cBoxHideUniversityPercent.Name = "cBoxHideUniversityPercent";
            this.cBoxHideUniversityPercent.Size = new System.Drawing.Size(161, 17);
            this.cBoxHideUniversityPercent.TabIndex = 16;
            this.cBoxHideUniversityPercent.Text = "عدم نمایش درصد دانشگاه";
            this.cBoxHideUniversityPercent.UseVisualStyleBackColor = false;
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(902, 524);
            this.Controls.Add(this.cBoxHideUniversityPercent);
            this.Controls.Add(this.cBoxJustIns);
            this.Controls.Add(this.cBoxIns1);
            this.Controls.Add(this.dgvInsFilter);
            this.Controls.Add(this.PanelPercent);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.PanelRefDateTimeFilter);
            this.Controls.Add(this.cBoxRefPhysician);
            this.Controls.Add(this.cBoxServPhysician);
            this.Controls.Add(this.cBoxService);
            this.Controls.Add(this.cBoxServiceCat);
            this.Controls.Add(this.dgvPhysician);
            this.Controls.Add(this.dgvServiceCat);
            this.Controls.Add(this.lblHeader1);
            this.Controls.Add(this.txtHeader1);
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
            this.Text = "گزارش های اختصاصی مشتریان - گزارش كاركرد كادر پزشكی - كلینیك سهند قزوین";
            this.Shown += new System.EventHandler(this.frmInsurancesFilter_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceCat)).EndInit();
            this.PanelRefDateTimeFilter.ResumeLayout(false);
            this.PanelRefDateTimeFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhysician)).EndInit();
            this.PanelPercent.ResumeLayout(false);
            this.PanelPercent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUniversity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhysician)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReport;
        private PersianCalendar.UI.Controls.PersianDatePicker FromDateRef;
        private PersianCalendar.UI.Controls.PersianDatePicker ToDateRef;
        private System.Windows.Forms.GroupBox PanelRefDateTimeFilter;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblToRefTime;
        private System.Windows.Forms.Label lblFromRefTime;
        private System.Windows.Forms.Label lblToRefDate;
        private System.Windows.Forms.Label lblFromRefDate;
        private System.Windows.Forms.CheckBox cBoxServiceCat;
        private System.Windows.Forms.DataGridView dgvServiceCat;
        private System.Windows.Forms.Label lblHeader1;
        private System.Windows.Forms.TextBox txtHeader1;
        private System.Windows.Forms.DateTimePicker FromTimeRef;
        private System.Windows.Forms.DateTimePicker ToTimeRef;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.CheckBox cBoxService;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColPerformerSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPerformerName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsExpert;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsPhysician;
        private System.Windows.Forms.DataGridView dgvPhysician;
        private System.Windows.Forms.CheckBox cBoxServPhysician;
        private System.Windows.Forms.CheckBox cBoxRefPhysician;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblPhysician;
        private System.Windows.Forms.GroupBox PanelPercent;
        private System.Windows.Forms.NumericUpDown txtTax;
        private System.Windows.Forms.NumericUpDown txtUniversity;
        private System.Windows.Forms.NumericUpDown txtPhysician;
        private System.Windows.Forms.Label lblUniversity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColServSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColPhysSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhysName;
        private System.Windows.Forms.CheckBox cBoxCalcByPatientPayablePrice;
        private System.Windows.Forms.CheckBox cBoxIns1;
        private System.Windows.Forms.DataGridView dgvInsFilter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColInsSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInsName;
        private System.Windows.Forms.CheckBox cBoxJustIns;
        private System.Windows.Forms.CheckBox cBoxHideUniversityPercent;
    }
}