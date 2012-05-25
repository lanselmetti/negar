namespace Sepehr.Forms.Admission.Referrals
{
    partial class frmReferralsAdditionalData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReferralsAdditionalData));
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.dataGridViewPersianDateTimePickerColumn1 = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.PanelAdditionalData = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.PanelBaseData = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtRefDate = new DevComponents.DotNetBar.LabelX();
            this.txtBirthDate = new DevComponents.DotNetBar.LabelX();
            this.txtPatientID = new DevComponents.DotNetBar.LabelX();
            this.txtPatientFullName = new DevComponents.DotNetBar.LabelX();
            this.lblPatientID = new DevComponents.DotNetBar.LabelX();
            this.lblBirthDate = new DevComponents.DotNetBar.LabelX();
            this.lblPatientFullName = new DevComponents.DotNetBar.LabelX();
            this.lblRefDate = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.FormPanel.SuspendLayout();
            this.PanelBaseData.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // dataGridViewPersianDateTimePickerColumn1
            // 
            this.dataGridViewPersianDateTimePickerColumn1.DataPropertyName = "RegisterDate";
            this.dataGridViewPersianDateTimePickerColumn1.HeaderText = "زمان مراجعه";
            this.dataGridViewPersianDateTimePickerColumn1.Name = "dataGridViewPersianDateTimePickerColumn1";
            this.dataGridViewPersianDateTimePickerColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPersianDateTimePickerColumn1.ShowTime = true;
            this.dataGridViewPersianDateTimePickerColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewPersianDateTimePickerColumn1.Width = 140;
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.PanelAdditionalData);
            this.FormPanel.Controls.Add(this.PanelBaseData);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnSave);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(484, 362);
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
            // PanelAdditionalData
            // 
            this.PanelAdditionalData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelAdditionalData.AutoScroll = true;
            this.PanelAdditionalData.BackColor = System.Drawing.Color.Transparent;
            this.PanelAdditionalData.CanvasColor = System.Drawing.Color.Transparent;
            this.PanelAdditionalData.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelAdditionalData.DrawTitleBox = false;
            this.PanelAdditionalData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelAdditionalData.Location = new System.Drawing.Point(12, 92);
            this.PanelAdditionalData.Name = "PanelAdditionalData";
            this.PanelAdditionalData.Size = new System.Drawing.Size(461, 192);
            // 
            // 
            // 
            this.PanelAdditionalData.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.PanelAdditionalData.Style.BackColor2 = System.Drawing.Color.White;
            this.PanelAdditionalData.Style.BackColorGradientAngle = 300;
            this.PanelAdditionalData.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelAdditionalData.Style.BorderBottomWidth = 1;
            this.PanelAdditionalData.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelAdditionalData.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelAdditionalData.Style.BorderLeftWidth = 1;
            this.PanelAdditionalData.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelAdditionalData.Style.BorderRightWidth = 1;
            this.PanelAdditionalData.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelAdditionalData.Style.BorderTopWidth = 1;
            this.PanelAdditionalData.Style.CornerDiameter = 4;
            this.PanelAdditionalData.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelAdditionalData.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelAdditionalData.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelAdditionalData.TabIndex = 0;
            this.PanelAdditionalData.Text = "اطلاعات پویا مراجعه";
            // 
            // PanelBaseData
            // 
            this.PanelBaseData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelBaseData.BackColor = System.Drawing.Color.Transparent;
            this.PanelBaseData.CanvasColor = System.Drawing.Color.Transparent;
            this.PanelBaseData.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelBaseData.Controls.Add(this.txtRefDate);
            this.PanelBaseData.Controls.Add(this.txtBirthDate);
            this.PanelBaseData.Controls.Add(this.txtPatientID);
            this.PanelBaseData.Controls.Add(this.txtPatientFullName);
            this.PanelBaseData.Controls.Add(this.lblPatientID);
            this.PanelBaseData.Controls.Add(this.lblBirthDate);
            this.PanelBaseData.Controls.Add(this.lblPatientFullName);
            this.PanelBaseData.Controls.Add(this.lblRefDate);
            this.PanelBaseData.DrawTitleBox = false;
            this.PanelBaseData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelBaseData.Location = new System.Drawing.Point(12, 6);
            this.PanelBaseData.Name = "PanelBaseData";
            this.PanelBaseData.Size = new System.Drawing.Size(461, 80);
            // 
            // 
            // 
            this.PanelBaseData.Style.BackColor = System.Drawing.Color.CadetBlue;
            this.PanelBaseData.Style.BackColor2 = System.Drawing.Color.White;
            this.PanelBaseData.Style.BackColorGradientAngle = 300;
            this.PanelBaseData.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelBaseData.Style.BorderBottomWidth = 1;
            this.PanelBaseData.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelBaseData.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelBaseData.Style.BorderLeftWidth = 1;
            this.PanelBaseData.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelBaseData.Style.BorderRightWidth = 1;
            this.PanelBaseData.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelBaseData.Style.BorderTopWidth = 1;
            this.PanelBaseData.Style.CornerDiameter = 4;
            this.PanelBaseData.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelBaseData.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelBaseData.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelBaseData.TabIndex = 1;
            this.PanelBaseData.Text = "اطلاعات بیمار و مراجعه تصویربرداری";
            // 
            // txtRefDate
            // 
            this.txtRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRefDate.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRefDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRefDate.BackgroundStyle.BorderBottomWidth = 1;
            this.txtRefDate.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.txtRefDate.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.txtRefDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRefDate.BackgroundStyle.BorderLeftWidth = 1;
            this.txtRefDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRefDate.BackgroundStyle.BorderRightWidth = 1;
            this.txtRefDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRefDate.BackgroundStyle.BorderTopWidth = 1;
            this.txtRefDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtRefDate.ForeColor = System.Drawing.Color.Black;
            this.txtRefDate.Location = new System.Drawing.Point(11, 28);
            this.txtRefDate.Name = "txtRefDate";
            this.txtRefDate.Size = new System.Drawing.Size(172, 21);
            this.txtRefDate.TabIndex = 7;
            this.txtRefDate.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBirthDate.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBirthDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtBirthDate.BackgroundStyle.BorderBottomWidth = 1;
            this.txtBirthDate.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.txtBirthDate.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.txtBirthDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtBirthDate.BackgroundStyle.BorderLeftWidth = 1;
            this.txtBirthDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtBirthDate.BackgroundStyle.BorderRightWidth = 1;
            this.txtBirthDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtBirthDate.BackgroundStyle.BorderTopWidth = 1;
            this.txtBirthDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBirthDate.ForeColor = System.Drawing.Color.Black;
            this.txtBirthDate.Location = new System.Drawing.Point(266, 30);
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.Size = new System.Drawing.Size(127, 21);
            this.txtBirthDate.TabIndex = 5;
            this.txtBirthDate.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtPatientID
            // 
            this.txtPatientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatientID.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPatientID.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPatientID.BackgroundStyle.BorderBottomWidth = 1;
            this.txtPatientID.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.txtPatientID.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.txtPatientID.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPatientID.BackgroundStyle.BorderLeftWidth = 1;
            this.txtPatientID.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPatientID.BackgroundStyle.BorderRightWidth = 1;
            this.txtPatientID.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPatientID.BackgroundStyle.BorderTopWidth = 1;
            this.txtPatientID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPatientID.ForeColor = System.Drawing.Color.Black;
            this.txtPatientID.Location = new System.Drawing.Point(266, 3);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(127, 21);
            this.txtPatientID.TabIndex = 1;
            this.txtPatientID.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtPatientFullName
            // 
            this.txtPatientFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatientFullName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPatientFullName.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPatientFullName.BackgroundStyle.BorderBottomWidth = 1;
            this.txtPatientFullName.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.txtPatientFullName.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.txtPatientFullName.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPatientFullName.BackgroundStyle.BorderLeftWidth = 1;
            this.txtPatientFullName.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPatientFullName.BackgroundStyle.BorderRightWidth = 1;
            this.txtPatientFullName.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPatientFullName.BackgroundStyle.BorderTopWidth = 1;
            this.txtPatientFullName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPatientFullName.ForeColor = System.Drawing.Color.Black;
            this.txtPatientFullName.Location = new System.Drawing.Point(11, 3);
            this.txtPatientFullName.Name = "txtPatientFullName";
            this.txtPatientFullName.Size = new System.Drawing.Size(172, 21);
            this.txtPatientFullName.TabIndex = 3;
            this.txtPatientFullName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblPatientID
            // 
            this.lblPatientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientID.ForeColor = System.Drawing.Color.Black;
            this.lblPatientID.Location = new System.Drawing.Point(398, 3);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(46, 16);
            this.lblPatientID.TabIndex = 0;
            this.lblPatientID.Text = "كد بیمار:";
            this.lblPatientID.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.BackColor = System.Drawing.Color.Transparent;
            this.lblBirthDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBirthDate.ForeColor = System.Drawing.Color.Black;
            this.lblBirthDate.Location = new System.Drawing.Point(398, 30);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(55, 16);
            this.lblBirthDate.TabIndex = 4;
            this.lblBirthDate.Text = "تاریخ تولد:";
            this.lblBirthDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblPatientFullName
            // 
            this.lblPatientFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatientFullName.AutoSize = true;
            this.lblPatientFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientFullName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientFullName.ForeColor = System.Drawing.Color.Black;
            this.lblPatientFullName.Location = new System.Drawing.Point(189, 5);
            this.lblPatientFullName.Name = "lblPatientFullName";
            this.lblPatientFullName.Size = new System.Drawing.Size(49, 16);
            this.lblPatientFullName.TabIndex = 2;
            this.lblPatientFullName.Text = "نام بیمار:";
            this.lblPatientFullName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblRefDate
            // 
            this.lblRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefDate.AutoSize = true;
            this.lblRefDate.BackColor = System.Drawing.Color.Transparent;
            this.lblRefDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRefDate.ForeColor = System.Drawing.Color.Blue;
            this.lblRefDate.Location = new System.Drawing.Point(189, 32);
            this.lblRefDate.Name = "lblRefDate";
            this.lblRefDate.Size = new System.Drawing.Size(71, 16);
            this.lblRefDate.TabIndex = 6;
            this.lblRefDate.Text = "زمان مراجعه:";
            this.lblRefDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Admission.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف (Esc)";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = global::Sepehr.Forms.Admission.Properties.Resources.Accept;
            this.btnSave.Location = new System.Drawing.Point(12, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSave.Size = new System.Drawing.Size(95, 60);
            this.btnSave.TabIndex = 2;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "ثبت (F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmReferralsAdditionalData
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "frmReferralsAdditionalData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - مراجعات - اطلاعات پویا مراجعات";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.PanelBaseData.ResumeLayout(false);
            this.PanelBaseData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn dataGridViewPersianDateTimePickerColumn1;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        internal DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelBaseData;
        private DevComponents.DotNetBar.LabelX lblRefDate;
        private DevComponents.DotNetBar.LabelX lblPatientFullName;
        private DevComponents.DotNetBar.LabelX txtPatientFullName;
        private DevComponents.DotNetBar.LabelX lblBirthDate;
        private DevComponents.DotNetBar.LabelX txtRefDate;
        private DevComponents.DotNetBar.LabelX txtBirthDate;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelAdditionalData;
        private DevComponents.DotNetBar.LabelX txtPatientID;
        private DevComponents.DotNetBar.LabelX lblPatientID;
    }
}