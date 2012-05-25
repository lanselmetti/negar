namespace Sepehr.Forms.Admission.Referrals
{
    partial class frmPhysicianManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhysicianManager));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.PanelGender = new System.Windows.Forms.Panel();
            this.cBoxMale = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxFemale = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.LogoImage = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.cboSpecs = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMedicalID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFirstNameEn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLastNameEn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFirstName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLastName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFirstName = new DevComponents.DotNetBar.LabelX();
            this.lblSpecs = new DevComponents.DotNetBar.LabelX();
            this.lblComment = new DevComponents.DotNetBar.LabelX();
            this.lblMedicalID = new DevComponents.DotNetBar.LabelX();
            this.lblLastNameEn = new DevComponents.DotNetBar.LabelX();
            this.lblGenders = new DevComponents.DotNetBar.LabelX();
            this.lblLastName = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            this.PanelGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.PanelGender);
            this.FormPanel.Controls.Add(this.LogoImage);
            this.FormPanel.Controls.Add(this.cboSpecs);
            this.FormPanel.Controls.Add(this.txtDescription);
            this.FormPanel.Controls.Add(this.txtMedicalID);
            this.FormPanel.Controls.Add(this.txtFirstNameEn);
            this.FormPanel.Controls.Add(this.txtLastNameEn);
            this.FormPanel.Controls.Add(this.txtFirstName);
            this.FormPanel.Controls.Add(this.txtLastName);
            this.FormPanel.Controls.Add(this.lblFirstName);
            this.FormPanel.Controls.Add(this.lblSpecs);
            this.FormPanel.Controls.Add(this.lblComment);
            this.FormPanel.Controls.Add(this.lblMedicalID);
            this.FormPanel.Controls.Add(this.lblLastNameEn);
            this.FormPanel.Controls.Add(this.lblGenders);
            this.FormPanel.Controls.Add(this.lblLastName);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnSave);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(394, 269);
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
            // PanelGender
            // 
            this.PanelGender.BackColor = System.Drawing.Color.Transparent;
            this.PanelGender.Controls.Add(this.cBoxMale);
            this.PanelGender.Controls.Add(this.cBoxFemale);
            this.PanelGender.Location = new System.Drawing.Point(226, 96);
            this.PanelGender.Name = "PanelGender";
            this.PanelGender.Size = new System.Drawing.Size(85, 24);
            this.PanelGender.TabIndex = 5;
            // 
            // cBoxMale
            // 
            this.cBoxMale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxMale.AutoSize = true;
            this.cBoxMale.BackColor = System.Drawing.Color.Transparent;
            this.cBoxMale.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxMale.Checked = true;
            this.cBoxMale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxMale.CheckValue = "Y";
            this.cBoxMale.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxMale.Location = new System.Drawing.Point(41, 4);
            this.cBoxMale.Name = "cBoxMale";
            this.cBoxMale.Size = new System.Drawing.Size(41, 16);
            this.cBoxMale.TabIndex = 0;
            this.cBoxMale.Text = "مرد";
            this.cBoxMale.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Controls_PreviewKeyDown);
            // 
            // cBoxFemale
            // 
            this.cBoxFemale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxFemale.AutoSize = true;
            this.cBoxFemale.BackColor = System.Drawing.Color.Transparent;
            this.cBoxFemale.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxFemale.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxFemale.Location = new System.Drawing.Point(3, 4);
            this.cBoxFemale.Name = "cBoxFemale";
            this.cBoxFemale.Size = new System.Drawing.Size(36, 16);
            this.cBoxFemale.TabIndex = 1;
            this.cBoxFemale.TabStop = false;
            this.cBoxFemale.Text = "زن";
            this.cBoxFemale.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Controls_PreviewKeyDown);
            // 
            // LogoImage
            // 
            this.LogoImage.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LogoImage.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.LogoImage.Image = global::Sepehr.Forms.Admission.Properties.Resources.PhysicianLogo;
            this.LogoImage.Location = new System.Drawing.Point(9, 3);
            this.LogoImage.MinimumSize = new System.Drawing.Size(32, 32);
            this.LogoImage.Name = "LogoImage";
            this.LogoImage.Size = new System.Drawing.Size(116, 114);
            this.LogoImage.TabIndex = 17;
            this.LogoImage.TabStop = false;
            // 
            // cboSpecs
            // 
            this.cboSpecs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSpecs.DisplayMember = "Title";
            this.cboSpecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpecs.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboSpecs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboSpecs.ForeColor = System.Drawing.Color.Navy;
            this.cboSpecs.FormattingEnabled = true;
            this.cboSpecs.ItemHeight = 13;
            this.cboSpecs.Location = new System.Drawing.Point(12, 123);
            this.cboSpecs.Name = "cboSpecs";
            this.cboSpecs.Size = new System.Drawing.Size(299, 21);
            this.cboSpecs.TabIndex = 9;
            this.cboSpecs.ValueMember = "ID";
            this.cboSpecs.WatermarkText = "تخصص پزشك متخصص خدمت";
            this.cboSpecs.Enter += new System.EventHandler(this.txtFa_Enter);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.ForeColor = System.Drawing.Color.Navy;
            this.txtDescription.Location = new System.Drawing.Point(12, 150);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(299, 34);
            this.txtDescription.TabIndex = 10;
            this.txtDescription.Enter += new System.EventHandler(this.txtFa_Enter);
            this.txtDescription.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Controls_PreviewKeyDown);
            // 
            // txtMedicalID
            // 
            this.txtMedicalID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtMedicalID.Border.Class = "TextBoxBorder";
            this.txtMedicalID.ForeColor = System.Drawing.Color.Navy;
            this.txtMedicalID.Location = new System.Drawing.Point(131, 19);
            this.txtMedicalID.MaxLength = 15;
            this.txtMedicalID.Name = "txtMedicalID";
            this.txtMedicalID.Size = new System.Drawing.Size(180, 21);
            this.txtMedicalID.TabIndex = 0;
            this.txtMedicalID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMedicalID.Enter += new System.EventHandler(this.txtFa_Enter);
            this.txtMedicalID.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Controls_PreviewKeyDown);
            // 
            // txtFirstNameEn
            // 
            this.txtFirstNameEn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFirstNameEn.Border.Class = "TextBoxBorder";
            this.txtFirstNameEn.ForeColor = System.Drawing.Color.Navy;
            this.txtFirstNameEn.Location = new System.Drawing.Point(214, 234);
            this.txtFirstNameEn.MaxLength = 15;
            this.txtFirstNameEn.Name = "txtFirstNameEn";
            this.txtFirstNameEn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFirstNameEn.Size = new System.Drawing.Size(174, 21);
            this.txtFirstNameEn.TabIndex = 15;
            this.txtFirstNameEn.WatermarkText = "First Name";
            this.txtFirstNameEn.Enter += new System.EventHandler(this.EngTextBox_Enter);
            this.txtFirstNameEn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Controls_PreviewKeyDown);
            // 
            // txtLastNameEn
            // 
            this.txtLastNameEn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtLastNameEn.Border.Class = "TextBoxBorder";
            this.txtLastNameEn.ForeColor = System.Drawing.Color.Navy;
            this.txtLastNameEn.Location = new System.Drawing.Point(214, 207);
            this.txtLastNameEn.MaxLength = 20;
            this.txtLastNameEn.Name = "txtLastNameEn";
            this.txtLastNameEn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLastNameEn.Size = new System.Drawing.Size(174, 21);
            this.txtLastNameEn.TabIndex = 14;
            this.txtLastNameEn.WatermarkText = "Last Name";
            this.txtLastNameEn.Enter += new System.EventHandler(this.EngTextBox_Enter);
            this.txtLastNameEn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Controls_PreviewKeyDown);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFirstName.Border.Class = "TextBoxBorder";
            this.txtFirstName.ForeColor = System.Drawing.Color.Navy;
            this.txtFirstName.Location = new System.Drawing.Point(131, 73);
            this.txtFirstName.MaxLength = 15;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(180, 21);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.WatermarkText = "نام";
            this.txtFirstName.Leave += new System.EventHandler(this.txtNames_Leave);
            this.txtFirstName.Enter += new System.EventHandler(this.txtFa_Enter);
            this.txtFirstName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Controls_PreviewKeyDown);
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtLastName.Border.Class = "TextBoxBorder";
            this.txtLastName.ForeColor = System.Drawing.Color.Navy;
            this.txtLastName.Location = new System.Drawing.Point(131, 46);
            this.txtLastName.MaxLength = 20;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(180, 21);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.WatermarkText = "نام خانوادگی";
            this.txtLastName.Leave += new System.EventHandler(this.txtNames_Leave);
            this.txtLastName.Enter += new System.EventHandler(this.txtFa_Enter);
            this.txtLastName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Controls_PreviewKeyDown);
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFirstName.Location = new System.Drawing.Point(317, 75);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(21, 16);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "نام:";
            this.lblFirstName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblSpecs
            // 
            this.lblSpecs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpecs.AutoSize = true;
            this.lblSpecs.BackColor = System.Drawing.Color.Transparent;
            this.lblSpecs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSpecs.Location = new System.Drawing.Point(317, 125);
            this.lblSpecs.Name = "lblSpecs";
            this.lblSpecs.Size = new System.Drawing.Size(46, 16);
            this.lblSpecs.TabIndex = 8;
            this.lblSpecs.Text = "تخصص:";
            this.lblSpecs.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblComment
            // 
            this.lblComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComment.AutoSize = true;
            this.lblComment.BackColor = System.Drawing.Color.Transparent;
            this.lblComment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblComment.Location = new System.Drawing.Point(317, 152);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(53, 16);
            this.lblComment.TabIndex = 11;
            this.lblComment.Text = "یادداشت:";
            this.lblComment.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblMedicalID
            // 
            this.lblMedicalID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMedicalID.AutoSize = true;
            this.lblMedicalID.BackColor = System.Drawing.Color.Transparent;
            this.lblMedicalID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMedicalID.Location = new System.Drawing.Point(317, 21);
            this.lblMedicalID.Name = "lblMedicalID";
            this.lblMedicalID.Size = new System.Drawing.Size(74, 16);
            this.lblMedicalID.TabIndex = 3;
            this.lblMedicalID.Text = "نظام پزشكی:";
            this.lblMedicalID.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblLastNameEn
            // 
            this.lblLastNameEn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastNameEn.AutoSize = true;
            this.lblLastNameEn.BackColor = System.Drawing.Color.Transparent;
            this.lblLastNameEn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLastNameEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLastNameEn.Location = new System.Drawing.Point(222, 189);
            this.lblLastNameEn.Name = "lblLastNameEn";
            this.lblLastNameEn.Size = new System.Drawing.Size(166, 16);
            this.lblLastNameEn.TabIndex = 16;
            this.lblLastNameEn.Text = "نام و نام خانوادگی به انگلیسی:";
            this.lblLastNameEn.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblLastNameEn.WordWrap = true;
            // 
            // lblGenders
            // 
            this.lblGenders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGenders.AutoSize = true;
            this.lblGenders.BackColor = System.Drawing.Color.Transparent;
            this.lblGenders.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblGenders.Location = new System.Drawing.Point(317, 100);
            this.lblGenders.Name = "lblGenders";
            this.lblGenders.Size = new System.Drawing.Size(47, 16);
            this.lblGenders.TabIndex = 7;
            this.lblGenders.Text = "جنسیت:";
            this.lblGenders.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLastName.Location = new System.Drawing.Point(317, 48);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(74, 16);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "نام خانوادگی:";
            this.lblLastName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Admission.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف (Esc)";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = global::Sepehr.Forms.Admission.Properties.Resources.Accept;
            this.btnSave.Location = new System.Drawing.Point(12, 195);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSave.Size = new System.Drawing.Size(95, 60);
            this.btnSave.TabIndex = 12;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "ثبت (F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmPhysicianManager
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 269);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhysicianManager";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - مراجعات - ثبت یا ویرایش پزشك ارجاع دهنده مراجعه";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.PanelGender.ResumeLayout(false);
            this.PanelGender.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSpecs;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLastName;
        private DevComponents.DotNetBar.LabelX lblLastName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMedicalID;
        private DevComponents.DotNetBar.LabelX lblFirstName;
        private DevComponents.DotNetBar.LabelX lblSpecs;
        private DevComponents.DotNetBar.LabelX lblComment;
        private DevComponents.DotNetBar.LabelX lblMedicalID;
        private DevComponents.DotNetBar.LabelX lblGenders;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstName;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxFemale;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxMale;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private DevComponents.DotNetBar.Controls.ReflectionImage LogoImage;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstNameEn;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLastNameEn;
        private DevComponents.DotNetBar.LabelX lblLastNameEn;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.Panel PanelGender;

    }
}