namespace Sepehr.Forms.Schedules
{
    partial class frmAppsSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppsSearch));
            this.MainPanel = new DevComponents.DotNetBar.PanelEx();
            this.ProgressBarSearch = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.txtSearchFrom = new DevComponents.Editors.IntegerInput();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDayOfWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEmpty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchTo = new DevComponents.Editors.IntegerInput();
            this.cboSchedulesPrograms = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblDayAfterThat = new DevComponents.DotNetBar.LabelX();
            this.lblDayTo = new DevComponents.DotNetBar.LabelX();
            this.lblSearchFrom = new DevComponents.DotNetBar.LabelX();
            this.lblAppToSearch = new DevComponents.DotNetBar.LabelX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.BWFormThread = new System.ComponentModel.BackgroundWorker();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchTo)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.MainPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.MainPanel.Controls.Add(this.ProgressBarSearch);
            this.MainPanel.Controls.Add(this.txtSearchFrom);
            this.MainPanel.Controls.Add(this.btnClose);
            this.MainPanel.Controls.Add(this.btnSelect);
            this.MainPanel.Controls.Add(this.btnSearch);
            this.MainPanel.Controls.Add(this.dgvData);
            this.MainPanel.Controls.Add(this.txtSearchTo);
            this.MainPanel.Controls.Add(this.cboSchedulesPrograms);
            this.MainPanel.Controls.Add(this.lblDayAfterThat);
            this.MainPanel.Controls.Add(this.lblDayTo);
            this.MainPanel.Controls.Add(this.lblSearchFrom);
            this.MainPanel.Controls.Add(this.lblAppToSearch);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(784, 562);
            this.MainPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.MainPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.MainPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.MainPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.MainPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.MainPanel.Style.GradientAngle = 90;
            this.MainPanel.TabIndex = 0;
            // 
            // ProgressBarSearch
            // 
            this.ProgressBarSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBarSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ProgressBarSearch.Location = new System.Drawing.Point(68, 35);
            this.ProgressBarSearch.Maximum = 2;
            this.ProgressBarSearch.Name = "ProgressBarSearch";
            this.ProgressBarSearch.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
            this.ProgressBarSearch.Size = new System.Drawing.Size(254, 23);
            this.ProgressBarSearch.TabIndex = 9;
            this.ProgressBarSearch.TabStop = false;
            this.ProgressBarSearch.Text = "در حال جستجوی برنامه ها";
            this.ProgressBarSearch.TextVisible = true;
            this.ProgressBarSearch.Visible = false;
            // 
            // txtSearchFrom
            // 
            this.txtSearchFrom.AllowEmptyState = false;
            this.txtSearchFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSearchFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSearchFrom.ButtonCustom.Visible = true;
            this.txtSearchFrom.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtSearchFrom.Location = new System.Drawing.Point(617, 37);
            this.txtSearchFrom.MaxValue = 30;
            this.txtSearchFrom.MinValue = 0;
            this.txtSearchFrom.Name = "txtSearchFrom";
            this.txtSearchFrom.ShowUpDown = true;
            this.txtSearchFrom.Size = new System.Drawing.Size(64, 21);
            this.txtSearchFrom.TabIndex = 3;
            this.txtSearchFrom.ButtonCustomClick += new System.EventHandler(this.txtSearchFrom_ButtonCustomClick);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnClose.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(113, 490);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 60);
            this.btnClose.TabIndex = 11;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج\r\n(Esc)";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSelect.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Accept;
            this.btnSelect.Location = new System.Drawing.Point(12, 490);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSelect.Size = new System.Drawing.Size(95, 60);
            this.btnSelect.TabIndex = 10;
            this.btnSelect.TabStop = false;
            this.btnSelect.Text = "انتخاب (F8)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Find;
            this.btnSearch.Location = new System.Drawing.Point(328, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnSearch.Size = new System.Drawing.Size(89, 48);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "جستجو (F4)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAppName,
            this.ColDayOfWeek,
            this.ColPDate,
            this.ColCapacity,
            this.ColUsed,
            this.ColEmpty,
            this.ColInActive});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 64);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvData.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(760, 420);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 7;
            this.dgvData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSearchResult_CellMouseDoubleClick);
            // 
            // ColAppName
            // 
            this.ColAppName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColAppName.DataPropertyName = "AppName";
            this.ColAppName.HeaderText = "عنوان برنامه";
            this.ColAppName.Name = "ColAppName";
            this.ColAppName.ReadOnly = true;
            // 
            // ColDayOfWeek
            // 
            this.ColDayOfWeek.DataPropertyName = "DayOfWeek";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ColDayOfWeek.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColDayOfWeek.HeaderText = "روز هفته";
            this.ColDayOfWeek.Name = "ColDayOfWeek";
            this.ColDayOfWeek.ReadOnly = true;
            this.ColDayOfWeek.Width = 80;
            // 
            // ColPDate
            // 
            this.ColPDate.DataPropertyName = "PDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColPDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColPDate.HeaderText = "تاریخ";
            this.ColPDate.Name = "ColPDate";
            this.ColPDate.ReadOnly = true;
            this.ColPDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColCapacity
            // 
            this.ColCapacity.DataPropertyName = "Capacity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColCapacity.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColCapacity.HeaderText = "ظرفیت";
            this.ColCapacity.Name = "ColCapacity";
            this.ColCapacity.ReadOnly = true;
            this.ColCapacity.Width = 60;
            // 
            // ColUsed
            // 
            this.ColUsed.DataPropertyName = "Used";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColUsed.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColUsed.HeaderText = "اشغال";
            this.ColUsed.Name = "ColUsed";
            this.ColUsed.ReadOnly = true;
            this.ColUsed.Width = 60;
            // 
            // ColEmpty
            // 
            this.ColEmpty.DataPropertyName = "Empty";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColEmpty.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColEmpty.HeaderText = "خالی";
            this.ColEmpty.Name = "ColEmpty";
            this.ColEmpty.ReadOnly = true;
            this.ColEmpty.Width = 60;
            // 
            // ColInActive
            // 
            this.ColInActive.DataPropertyName = "InActive";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColInActive.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColInActive.HeaderText = "غیر فعال";
            this.ColInActive.Name = "ColInActive";
            this.ColInActive.ReadOnly = true;
            this.ColInActive.Width = 80;
            // 
            // txtSearchTo
            // 
            this.txtSearchTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSearchTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSearchTo.ButtonCustom.Visible = true;
            this.txtSearchTo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtSearchTo.Location = new System.Drawing.Point(496, 37);
            this.txtSearchTo.MaxValue = 100;
            this.txtSearchTo.MinValue = 0;
            this.txtSearchTo.Name = "txtSearchTo";
            this.txtSearchTo.ShowUpDown = true;
            this.txtSearchTo.Size = new System.Drawing.Size(64, 21);
            this.txtSearchTo.TabIndex = 5;
            this.txtSearchTo.Value = 7;
            this.txtSearchTo.ButtonCustomClick += new System.EventHandler(this.txtSearchTo_ButtonCustomClick);
            // 
            // cboSchedulesPrograms
            // 
            this.cboSchedulesPrograms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSchedulesPrograms.DisplayMember = "Text";
            this.cboSchedulesPrograms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchedulesPrograms.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboSchedulesPrograms.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboSchedulesPrograms.FormattingEnabled = true;
            this.cboSchedulesPrograms.ItemHeight = 13;
            this.cboSchedulesPrograms.Location = new System.Drawing.Point(423, 10);
            this.cboSchedulesPrograms.Name = "cboSchedulesPrograms";
            this.cboSchedulesPrograms.Size = new System.Drawing.Size(258, 21);
            this.cboSchedulesPrograms.TabIndex = 0;
            // 
            // lblDayAfterThat
            // 
            this.lblDayAfterThat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDayAfterThat.AutoSize = true;
            this.lblDayAfterThat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDayAfterThat.Location = new System.Drawing.Point(423, 39);
            this.lblDayAfterThat.Name = "lblDayAfterThat";
            this.lblDayAfterThat.Size = new System.Drawing.Size(69, 16);
            this.lblDayAfterThat.TabIndex = 6;
            this.lblDayAfterThat.Text = "روز بعد از آن.";
            // 
            // lblDayTo
            // 
            this.lblDayTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDayTo.AutoSize = true;
            this.lblDayTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDayTo.Location = new System.Drawing.Point(562, 39);
            this.lblDayTo.Name = "lblDayTo";
            this.lblDayTo.Size = new System.Drawing.Size(52, 16);
            this.lblDayTo.TabIndex = 4;
            this.lblDayTo.Text = "روز قبل تا";
            // 
            // lblSearchFrom
            // 
            this.lblSearchFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchFrom.AutoSize = true;
            this.lblSearchFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSearchFrom.Location = new System.Drawing.Point(685, 39);
            this.lblSearchFrom.Name = "lblSearchFrom";
            this.lblSearchFrom.Size = new System.Drawing.Size(58, 16);
            this.lblSearchFrom.TabIndex = 2;
            this.lblSearchFrom.Text = "جستجو از:";
            // 
            // lblAppToSearch
            // 
            this.lblAppToSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppToSearch.AutoSize = true;
            this.lblAppToSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppToSearch.Location = new System.Drawing.Point(685, 12);
            this.lblAppToSearch.Name = "lblAppToSearch";
            this.lblAppToSearch.Size = new System.Drawing.Size(92, 16);
            this.lblAppToSearch.TabIndex = 1;
            this.lblAppToSearch.Text = "انتخاب نام برنامه:";
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // BWFormThread
            // 
            this.BWFormThread.WorkerReportsProgress = true;
            this.BWFormThread.WorkerSupportsCancellation = true;
            this.BWFormThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BWFormThread_DoWork);
            this.BWFormThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BWFormThread_RunWorkerCompleted);
            // 
            // frmAppsSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "frmAppsSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - نوبت دهی - جستجوی وضعیت نوبت های برنامه ها";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchTo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx MainPanel;
        private DevComponents.Editors.IntegerInput txtSearchFrom;
        internal DevComponents.DotNetBar.ButtonX btnSelect;
        internal DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.Editors.IntegerInput txtSearchTo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSchedulesPrograms;
        private DevComponents.DotNetBar.LabelX lblDayAfterThat;
        private DevComponents.DotNetBar.LabelX lblDayTo;
        private DevComponents.DotNetBar.LabelX lblSearchFrom;
        private DevComponents.DotNetBar.LabelX lblAppToSearch;
        internal DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        internal DevComponents.DotNetBar.Controls.ProgressBarX ProgressBarSearch;
        private System.ComponentModel.BackgroundWorker BWFormThread;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDayOfWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCapacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEmpty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInActive;

    }
}