namespace Negar.Customers.Reports0004
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilter));
            this.FormPanel = new System.Windows.Forms.Panel();
            this.lblHeader2 = new System.Windows.Forms.Label();
            this.lblHeader1 = new System.Windows.Forms.Label();
            this.txtHeader2 = new System.Windows.Forms.TextBox();
            this.txtHeader1 = new System.Windows.Forms.TextBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.PanelRefDateTimeFilter = new System.Windows.Forms.GroupBox();
            this.lblToRefTime = new System.Windows.Forms.Label();
            this.lblFromRefTime = new System.Windows.Forms.Label();
            this.lblToRefDate = new System.Windows.Forms.Label();
            this.lblFromRefDate = new System.Windows.Forms.Label();
            this.ToDateRef = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDateRef = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.ToTimeRef = new System.Windows.Forms.DateTimePicker();
            this.FromTimeRef = new System.Windows.Forms.DateTimePicker();
            this.dgvInsFilter = new System.Windows.Forms.DataGridView();
            this.ColInsSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColInsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBoxIns1 = new System.Windows.Forms.CheckBox();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.FormPanel.SuspendLayout();
            this.PanelRefDateTimeFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.Controls.Add(this.lblHeader2);
            this.FormPanel.Controls.Add(this.lblHeader1);
            this.FormPanel.Controls.Add(this.txtHeader2);
            this.FormPanel.Controls.Add(this.txtHeader1);
            this.FormPanel.Controls.Add(this.ProgressBar);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnReport);
            this.FormPanel.Controls.Add(this.PanelRefDateTimeFilter);
            this.FormPanel.Controls.Add(this.dgvInsFilter);
            this.FormPanel.Controls.Add(this.cBoxIns1);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(324, 475);
            this.FormPanel.TabIndex = 0;
            // 
            // lblHeader2
            // 
            this.lblHeader2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader2.AutoSize = true;
            this.lblHeader2.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHeader2.Location = new System.Drawing.Point(265, 115);
            this.lblHeader2.Name = "lblHeader2";
            this.lblHeader2.Size = new System.Drawing.Size(50, 13);
            this.lblHeader2.TabIndex = 11;
            this.lblHeader2.Text = "عنوان 2:";
            // 
            // lblHeader1
            // 
            this.lblHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader1.AutoSize = true;
            this.lblHeader1.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHeader1.Location = new System.Drawing.Point(265, 88);
            this.lblHeader1.Name = "lblHeader1";
            this.lblHeader1.Size = new System.Drawing.Size(50, 13);
            this.lblHeader1.TabIndex = 10;
            this.lblHeader1.Text = "عنوان 1:";
            // 
            // txtHeader2
            // 
            this.txtHeader2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader2.Location = new System.Drawing.Point(12, 113);
            this.txtHeader2.Name = "txtHeader2";
            this.txtHeader2.Size = new System.Drawing.Size(247, 21);
            this.txtHeader2.TabIndex = 12;
            // 
            // txtHeader1
            // 
            this.txtHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader1.Location = new System.Drawing.Point(12, 86);
            this.txtHeader1.Name = "txtHeader1";
            this.txtHeader1.Size = new System.Drawing.Size(247, 21);
            this.txtHeader1.TabIndex = 9;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(13, 377);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(298, 23);
            this.ProgressBar.TabIndex = 15;
            this.ProgressBar.TabStop = false;
            this.ProgressBar.Text = "در انتظار ایجاد گزارش";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Negar.Customers.Reports0004.Properties.Resources.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCancel.Location = new System.Drawing.Point(114, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Image = global::Negar.Customers.Reports0004.Properties.Resources.Accept;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnReport.Location = new System.Drawing.Point(13, 406);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(95, 57);
            this.btnReport.TabIndex = 17;
            this.btnReport.TabStop = false;
            this.btnReport.Text = "گزارش\r\n(F8)";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // PanelRefDateTimeFilter
            // 
            this.PanelRefDateTimeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelRefDateTimeFilter.BackColor = System.Drawing.Color.Transparent;
            this.PanelRefDateTimeFilter.Controls.Add(this.lblToRefTime);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblFromRefTime);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblToRefDate);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblFromRefDate);
            this.PanelRefDateTimeFilter.Controls.Add(this.ToDateRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.FromDateRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.ToTimeRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.FromTimeRef);
            this.PanelRefDateTimeFilter.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelRefDateTimeFilter.Location = new System.Drawing.Point(12, 5);
            this.PanelRefDateTimeFilter.Name = "PanelRefDateTimeFilter";
            this.PanelRefDateTimeFilter.Size = new System.Drawing.Size(300, 75);
            this.PanelRefDateTimeFilter.TabIndex = 0;
            this.PanelRefDateTimeFilter.TabStop = false;
            this.PanelRefDateTimeFilter.Text = "تاریخ پذیرش مراجعه";
            // 
            // lblToRefTime
            // 
            this.lblToRefTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToRefTime.AutoSize = true;
            this.lblToRefTime.BackColor = System.Drawing.Color.Transparent;
            this.lblToRefTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToRefTime.Location = new System.Drawing.Point(89, 50);
            this.lblToRefTime.Name = "lblToRefTime";
            this.lblToRefTime.Size = new System.Drawing.Size(55, 13);
            this.lblToRefTime.TabIndex = 10;
            this.lblToRefTime.Text = "تا ساعت:";
            // 
            // lblFromRefTime
            // 
            this.lblFromRefTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromRefTime.AutoSize = true;
            this.lblFromRefTime.BackColor = System.Drawing.Color.Transparent;
            this.lblFromRefTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromRefTime.Location = new System.Drawing.Point(89, 24);
            this.lblFromRefTime.Name = "lblFromRefTime";
            this.lblFromRefTime.Size = new System.Drawing.Size(56, 13);
            this.lblFromRefTime.TabIndex = 8;
            this.lblFromRefTime.Text = "از ساعت:";
            // 
            // lblToRefDate
            // 
            this.lblToRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToRefDate.AutoSize = true;
            this.lblToRefDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToRefDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToRefDate.Location = new System.Drawing.Point(240, 50);
            this.lblToRefDate.Name = "lblToRefDate";
            this.lblToRefDate.Size = new System.Drawing.Size(47, 13);
            this.lblToRefDate.TabIndex = 9;
            this.lblToRefDate.Text = "تا تاریخ:";
            // 
            // lblFromRefDate
            // 
            this.lblFromRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromRefDate.AutoSize = true;
            this.lblFromRefDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromRefDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromRefDate.Location = new System.Drawing.Point(240, 24);
            this.lblFromRefDate.Name = "lblFromRefDate";
            this.lblFromRefDate.Size = new System.Drawing.Size(48, 13);
            this.lblFromRefDate.TabIndex = 7;
            this.lblFromRefDate.Text = "از تاریخ:";
            // 
            // ToDateRef
            // 
            this.ToDateRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDateRef.IsAllowNullDate = false;
            this.ToDateRef.IsPopupOpen = false;
            this.ToDateRef.Location = new System.Drawing.Point(150, 48);
            this.ToDateRef.Name = "ToDateRef";
            this.ToDateRef.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.ToDateRef.Size = new System.Drawing.Size(84, 20);
            this.ToDateRef.TabIndex = 2;
            // 
            // FromDateRef
            // 
            this.FromDateRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDateRef.IsAllowNullDate = false;
            this.FromDateRef.IsPopupOpen = false;
            this.FromDateRef.Location = new System.Drawing.Point(150, 22);
            this.FromDateRef.Name = "FromDateRef";
            this.FromDateRef.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.FromDateRef.Size = new System.Drawing.Size(84, 20);
            this.FromDateRef.TabIndex = 0;
            // 
            // ToTimeRef
            // 
            this.ToTimeRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToTimeRef.CustomFormat = "ss:mm:HH";
            this.ToTimeRef.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToTimeRef.Location = new System.Drawing.Point(6, 50);
            this.ToTimeRef.Name = "ToTimeRef";
            this.ToTimeRef.RightToLeftLayout = true;
            this.ToTimeRef.ShowUpDown = true;
            this.ToTimeRef.Size = new System.Drawing.Size(80, 22);
            this.ToTimeRef.TabIndex = 11;
            // 
            // FromTimeRef
            // 
            this.FromTimeRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromTimeRef.CustomFormat = "ss:mm:HH";
            this.FromTimeRef.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromTimeRef.Location = new System.Drawing.Point(6, 22);
            this.FromTimeRef.Name = "FromTimeRef";
            this.FromTimeRef.RightToLeftLayout = true;
            this.FromTimeRef.ShowUpDown = true;
            this.FromTimeRef.Size = new System.Drawing.Size(80, 22);
            this.FromTimeRef.TabIndex = 1;
            this.FromTimeRef.Value = new System.DateTime(2012, 5, 11, 0, 0, 0, 0);
            // 
            // dgvInsFilter
            // 
            this.dgvInsFilter.AllowUserToAddRows = false;
            this.dgvInsFilter.AllowUserToDeleteRows = false;
            this.dgvInsFilter.AllowUserToOrderColumns = true;
            this.dgvInsFilter.AllowUserToResizeColumns = false;
            this.dgvInsFilter.AllowUserToResizeRows = false;
            this.dgvInsFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInsFilter.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvInsFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsFilter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInsFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColInsSelection,
            this.ColInsName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsFilter.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInsFilter.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvInsFilter.Location = new System.Drawing.Point(13, 162);
            this.dgvInsFilter.MultiSelect = false;
            this.dgvInsFilter.Name = "dgvInsFilter";
            this.dgvInsFilter.RowHeadersVisible = false;
            this.dgvInsFilter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsFilter.Size = new System.Drawing.Size(299, 209);
            this.dgvInsFilter.StandardTab = true;
            this.dgvInsFilter.TabIndex = 7;
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
            // cBoxIns1
            // 
            this.cBoxIns1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxIns1.AutoSize = true;
            this.cBoxIns1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIns1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxIns1.Location = new System.Drawing.Point(20, 140);
            this.cBoxIns1.Name = "cBoxIns1";
            this.cBoxIns1.Size = new System.Drawing.Size(292, 17);
            this.cBoxIns1.TabIndex = 5;
            this.cBoxIns1.TabStop = false;
            this.cBoxIns1.Text = "مراجعاتی كه بیمه اول آن یكی از بیمه های زیر باشد";
            this.cBoxIns1.UseVisualStyleBackColor = false;
            this.cBoxIns1.CheckedChanged += new System.EventHandler(this.cBoxIns1_CheckedChanged);
            // 
            // BGWorker
            // 
            this.BGWorker.WorkerSupportsCancellation = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(324, 475);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(330, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(330, 500);
            this.Name = "frmFilter";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش اختصاصی شرح مالی - پردیس نور";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.PanelRefDateTimeFilter.ResumeLayout(false);
            this.PanelRefDateTimeFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FormPanel;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DateTimePicker FromTimeRef;
        private System.Windows.Forms.DateTimePicker ToTimeRef;
        private PersianCalendar.UI.Controls.PersianDatePicker FromDateRef;
        private PersianCalendar.UI.Controls.PersianDatePicker ToDateRef;
        private System.Windows.Forms.GroupBox PanelRefDateTimeFilter;
        private System.Windows.Forms.CheckBox cBoxIns1;
        private System.Windows.Forms.DataGridView dgvInsFilter;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColInsSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInsName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblToRefTime;
        private System.Windows.Forms.Label lblFromRefTime;
        private System.Windows.Forms.Label lblToRefDate;
        private System.Windows.Forms.Label lblFromRefDate;
        private System.Windows.Forms.Label lblHeader2;
        private System.Windows.Forms.Label lblHeader1;
        private System.Windows.Forms.TextBox txtHeader2;
        private System.Windows.Forms.TextBox txtHeader1;
    }
}