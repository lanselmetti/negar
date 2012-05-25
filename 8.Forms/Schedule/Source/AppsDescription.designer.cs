namespace Sepehr.Forms.Schedules
{
    partial class frmAppsDescription
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppsDescription));
            this.FormPanel = new DevComponents.DotNetBar.PanelEx();
            this.txtTitle = new DevComponents.DotNetBar.LabelX();
            this.EndDate = new DevComponents.DotNetBar.LabelX();
            this.StartDate = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.lblEndDate = new DevComponents.DotNetBar.LabelX();
            this.lblBeginDate = new DevComponents.DotNetBar.LabelX();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.txtDescription = new DevComponents.DotNetBar.LabelX();
            this.lblAppType = new DevComponents.DotNetBar.LabelX();
            this.lblScheduleType = new DevComponents.DotNetBar.LabelX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.DayNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.txtTitle);
            this.FormPanel.Controls.Add(this.EndDate);
            this.FormPanel.Controls.Add(this.StartDate);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.lblEndDate);
            this.FormPanel.Controls.Add(this.lblBeginDate);
            this.FormPanel.Controls.Add(this.lblDescription);
            this.FormPanel.Controls.Add(this.txtDescription);
            this.FormPanel.Controls.Add(this.lblAppType);
            this.FormPanel.Controls.Add(this.lblScheduleType);
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(500, 341);
            this.FormPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.FormPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FormPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FormPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.FormPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.FormPanel.Style.GradientAngle = 90;
            this.FormPanel.TabIndex = 0;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTitle.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtTitle.BackgroundStyle.BorderBottomWidth = 1;
            this.txtTitle.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.txtTitle.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.txtTitle.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtTitle.BackgroundStyle.BorderLeftWidth = 1;
            this.txtTitle.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtTitle.BackgroundStyle.BorderRightWidth = 1;
            this.txtTitle.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtTitle.BackgroundStyle.BorderTopWidth = 1;
            this.txtTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTitle.ForeColor = System.Drawing.Color.Green;
            this.txtTitle.Location = new System.Drawing.Point(137, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PaddingLeft = 2;
            this.txtTitle.PaddingRight = 2;
            this.txtTitle.Size = new System.Drawing.Size(268, 21);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Text = "عنوان برنامه";
            // 
            // EndDate
            // 
            this.EndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EndDate.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.EndDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.EndDate.BackgroundStyle.BorderBottomWidth = 1;
            this.EndDate.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.EndDate.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.EndDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.EndDate.BackgroundStyle.BorderLeftWidth = 1;
            this.EndDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.EndDate.BackgroundStyle.BorderRightWidth = 1;
            this.EndDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.EndDate.BackgroundStyle.BorderTopWidth = 1;
            this.EndDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.EndDate.ForeColor = System.Drawing.Color.Green;
            this.EndDate.Location = new System.Drawing.Point(139, 39);
            this.EndDate.Name = "EndDate";
            this.EndDate.PaddingLeft = 2;
            this.EndDate.PaddingRight = 2;
            this.EndDate.Size = new System.Drawing.Size(98, 20);
            this.EndDate.TabIndex = 3;
            this.EndDate.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // StartDate
            // 
            this.StartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartDate.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.StartDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.StartDate.BackgroundStyle.BorderBottomWidth = 1;
            this.StartDate.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.StartDate.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.StartDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.StartDate.BackgroundStyle.BorderLeftWidth = 1;
            this.StartDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.StartDate.BackgroundStyle.BorderRightWidth = 1;
            this.StartDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.StartDate.BackgroundStyle.BorderTopWidth = 1;
            this.StartDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.StartDate.ForeColor = System.Drawing.Color.Green;
            this.StartDate.Location = new System.Drawing.Point(307, 39);
            this.StartDate.Name = "StartDate";
            this.StartDate.PaddingLeft = 2;
            this.StartDate.PaddingRight = 2;
            this.StartDate.Size = new System.Drawing.Size(98, 20);
            this.StartDate.TabIndex = 2;
            this.StartDate.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(411, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(70, 16);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "عنوان برنامه:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblEndDate.Location = new System.Drawing.Point(243, 41);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(58, 16);
            this.lblEndDate.TabIndex = 6;
            this.lblEndDate.Text = "تاریخ پایان:";
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBeginDate.AutoSize = true;
            this.lblBeginDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBeginDate.Location = new System.Drawing.Point(411, 41);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(66, 16);
            this.lblBeginDate.TabIndex = 5;
            this.lblBeginDate.Text = "تاریخ شروع:";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.Location = new System.Drawing.Point(432, 272);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 16);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "توضیحات:";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDescription.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtDescription.BackgroundStyle.BorderBottomWidth = 1;
            this.txtDescription.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.txtDescription.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.txtDescription.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtDescription.BackgroundStyle.BorderLeftWidth = 1;
            this.txtDescription.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtDescription.BackgroundStyle.BorderRightWidth = 1;
            this.txtDescription.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.txtDescription.BackgroundStyle.BorderTopWidth = 1;
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDescription.ForeColor = System.Drawing.Color.Green;
            this.txtDescription.Location = new System.Drawing.Point(113, 269);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PaddingBottom = 2;
            this.txtDescription.PaddingLeft = 2;
            this.txtDescription.PaddingRight = 2;
            this.txtDescription.PaddingTop = 2;
            this.txtDescription.Size = new System.Drawing.Size(317, 60);
            this.txtDescription.TabIndex = 10;
            this.txtDescription.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.txtDescription.WordWrap = true;
            // 
            // lblAppType
            // 
            this.lblAppType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppType.AutoSize = true;
            this.lblAppType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppType.ForeColor = System.Drawing.Color.Green;
            this.lblAppType.Location = new System.Drawing.Point(18, 14);
            this.lblAppType.Name = "lblAppType";
            this.lblAppType.Size = new System.Drawing.Size(25, 16);
            this.lblAppType.TabIndex = 8;
            this.lblAppType.Text = "ثابت";
            // 
            // lblScheduleType
            // 
            this.lblScheduleType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScheduleType.AutoSize = true;
            this.lblScheduleType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblScheduleType.Location = new System.Drawing.Point(49, 14);
            this.lblScheduleType.Name = "lblScheduleType";
            this.lblScheduleType.Size = new System.Drawing.Size(82, 16);
            this.lblScheduleType.TabIndex = 7;
            this.lblScheduleType.Text = "نوع نوبت دهی:";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeColumns = false;
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
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DayNo,
            this.DayName,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn15});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 67);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(476, 195);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 9;
            // 
            // DayNo
            // 
            this.DayNo.DataPropertyName = "DayNo";
            this.DayNo.HeaderText = "DayNo";
            this.DayNo.Name = "DayNo";
            this.DayNo.ReadOnly = true;
            this.DayNo.Visible = false;
            // 
            // DayName
            // 
            this.DayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.DayName.DefaultCellStyle = dataGridViewCellStyle2;
            this.DayName.HeaderText = "روز هفته";
            this.DayName.Name = "DayName";
            this.DayName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "BeginTime";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "HH:mm";
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn16.HeaderText = "شروع";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.ToolTipText = "شروع شیفت";
            this.dataGridViewTextBoxColumn16.Width = 80;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "EndTime";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "HH:mm";
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn17.HeaderText = "پایان";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.ToolTipText = "پایان شیفت";
            this.dataGridViewTextBoxColumn17.Width = 80;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Capacity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn13.HeaderText = "ظرفیت";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 60;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "RoundingMinute";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn15.HeaderText = "مبنای گرد";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 70;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmAppsDescription
            // 
            this.AcceptButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(500, 341);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppsDescription";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نوبت دهی - خلاصه تنظیمات برنامه نوبت دهی";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx FormPanel;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.LabelX lblEndDate;
        private DevComponents.DotNetBar.LabelX lblBeginDate;
        private DevComponents.DotNetBar.LabelX lblDescription;
        private DevComponents.DotNetBar.LabelX lblScheduleType;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX txtDescription;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.LabelX EndDate;
        private DevComponents.DotNetBar.LabelX StartDate;
        private DevComponents.DotNetBar.LabelX txtTitle;
        private DevComponents.DotNetBar.LabelX lblAppType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;


    }
}