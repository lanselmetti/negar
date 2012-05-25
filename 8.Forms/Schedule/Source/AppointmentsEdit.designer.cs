namespace Sepehr.Forms.Schedules
{
    partial class frmAppointmentsEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppointmentsEdit));
            this.MainPanel = new DevComponents.DotNetBar.PanelEx();
            this.PanelAdditionalData = new System.Windows.Forms.Panel();
            this.Panel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtAppDate = new DevComponents.DotNetBar.LabelX();
            this.lblAppDate = new DevComponents.DotNetBar.LabelX();
            this.cboSchedulders = new System.Windows.Forms.ComboBox();
            this.txtTitle = new DevComponents.DotNetBar.LabelX();
            this.TimeInputShiftTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtOrderNo = new DevComponents.Editors.IntegerInput();
            this.lblShiftLenght = new DevComponents.DotNetBar.LabelX();
            this.lblTime = new DevComponents.DotNetBar.LabelX();
            this.lblAppRow = new DevComponents.DotNetBar.LabelX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.Panel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.PanelGender = new System.Windows.Forms.Panel();
            this.cboxMale = new System.Windows.Forms.RadioButton();
            this.cBoxFemale = new System.Windows.Forms.RadioButton();
            this.txtAge = new DevComponents.Editors.IntegerInput();
            this.lblFirstName = new DevComponents.DotNetBar.LabelX();
            this.txtFirstName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblLastName = new DevComponents.DotNetBar.LabelX();
            this.txtLastName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblGender = new DevComponents.DotNetBar.LabelX();
            this.txtTel1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTel2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTel2 = new DevComponents.DotNetBar.LabelX();
            this.lblTel1 = new DevComponents.DotNetBar.LabelX();
            this.lblAge = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.MainPanel.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeInputShiftTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo)).BeginInit();
            this.Panel2.SuspendLayout();
            this.PanelGender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.MainPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.MainPanel.Controls.Add(this.PanelAdditionalData);
            this.MainPanel.Controls.Add(this.Panel1);
            this.MainPanel.Controls.Add(this.Panel2);
            this.MainPanel.Controls.Add(this.btnCancel);
            this.MainPanel.Controls.Add(this.btnAccept);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(527, 401);
            this.MainPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.MainPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.MainPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.MainPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.MainPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.MainPanel.Style.GradientAngle = 90;
            this.MainPanel.TabIndex = 0;
            // 
            // PanelAdditionalData
            // 
            this.PanelAdditionalData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelAdditionalData.AutoScroll = true;
            this.PanelAdditionalData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelAdditionalData.ForeColor = System.Drawing.Color.Black;
            this.PanelAdditionalData.Location = new System.Drawing.Point(12, 161);
            this.PanelAdditionalData.Name = "PanelAdditionalData";
            this.PanelAdditionalData.Size = new System.Drawing.Size(502, 159);
            this.PanelAdditionalData.TabIndex = 1;
            this.PanelAdditionalData.Text = "فیلد های پویا";
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.Panel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.Panel1.Controls.Add(this.txtAppDate);
            this.Panel1.Controls.Add(this.lblAppDate);
            this.Panel1.Controls.Add(this.cboSchedulders);
            this.Panel1.Controls.Add(this.txtTitle);
            this.Panel1.Controls.Add(this.TimeInputShiftTime);
            this.Panel1.Controls.Add(this.txtOrderNo);
            this.Panel1.Controls.Add(this.lblShiftLenght);
            this.Panel1.Controls.Add(this.lblTime);
            this.Panel1.Controls.Add(this.lblAppRow);
            this.Panel1.Controls.Add(this.lblTitle);
            this.Panel1.DrawTitleBox = false;
            this.Panel1.Location = new System.Drawing.Point(12, 12);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(502, 66);
            // 
            // 
            // 
            this.Panel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor;
            this.Panel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground;
            this.Panel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderBottomWidth = 1;
            this.Panel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Panel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderLeftWidth = 1;
            this.Panel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderRightWidth = 1;
            this.Panel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderTopWidth = 1;
            this.Panel1.Style.CornerDiameter = 4;
            this.Panel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.Panel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.Panel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.Panel1.TabIndex = 2;
            // 
            // txtAppDate
            // 
            this.txtAppDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppDate.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAppDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtAppDate.BackgroundStyle.BorderBottomWidth = 2;
            this.txtAppDate.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.txtAppDate.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.txtAppDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtAppDate.BackgroundStyle.BorderLeftWidth = 2;
            this.txtAppDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtAppDate.BackgroundStyle.BorderRightWidth = 2;
            this.txtAppDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtAppDate.BackgroundStyle.BorderTopWidth = 2;
            this.txtAppDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAppDate.ForeColor = System.Drawing.Color.Black;
            this.txtAppDate.Location = new System.Drawing.Point(293, 35);
            this.txtAppDate.Name = "txtAppDate";
            this.txtAppDate.PaddingLeft = 2;
            this.txtAppDate.PaddingRight = 2;
            this.txtAppDate.Size = new System.Drawing.Size(131, 21);
            this.txtAppDate.TabIndex = 5;
            this.txtAppDate.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblAppDate
            // 
            this.lblAppDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppDate.ForeColor = System.Drawing.Color.Black;
            this.lblAppDate.Location = new System.Drawing.Point(430, 37);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(32, 16);
            this.lblAppDate.TabIndex = 4;
            this.lblAppDate.Text = "تاریخ:";
            // 
            // cboSchedulders
            // 
            this.cboSchedulders.AccessibleDescription = "";
            this.cboSchedulders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSchedulders.BackColor = System.Drawing.Color.White;
            this.cboSchedulders.DisplayMember = "FullName";
            this.cboSchedulders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchedulders.DropDownWidth = 121;
            this.cboSchedulders.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboSchedulders.ForeColor = System.Drawing.Color.Black;
            this.cboSchedulders.FormattingEnabled = true;
            this.cboSchedulders.IntegralHeight = false;
            this.cboSchedulders.ItemHeight = 13;
            this.cboSchedulders.Location = new System.Drawing.Point(9, 8);
            this.cboSchedulders.MaxDropDownItems = 10;
            this.cboSchedulders.Name = "cboSchedulders";
            this.cboSchedulders.Size = new System.Drawing.Size(147, 21);
            this.cboSchedulders.TabIndex = 3;
            this.cboSchedulders.TabStop = false;
            this.cboSchedulders.Tag = "RefData";
            this.cboSchedulders.ValueMember = "ID";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTitle.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTitle.BackgroundStyle.BorderBottomWidth = 2;
            this.txtTitle.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.txtTitle.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.txtTitle.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTitle.BackgroundStyle.BorderLeftWidth = 2;
            this.txtTitle.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTitle.BackgroundStyle.BorderRightWidth = 2;
            this.txtTitle.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTitle.BackgroundStyle.BorderTopWidth = 2;
            this.txtTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTitle.ForeColor = System.Drawing.Color.Black;
            this.txtTitle.Location = new System.Drawing.Point(225, 8);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PaddingLeft = 2;
            this.txtTitle.PaddingRight = 2;
            this.txtTitle.Size = new System.Drawing.Size(199, 21);
            this.txtTitle.TabIndex = 1;
            // 
            // TimeInputShiftTime
            // 
            this.TimeInputShiftTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TimeInputShiftTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TimeInputShiftTime.CustomFormat = "HH:mm";
            this.TimeInputShiftTime.ForeColor = System.Drawing.Color.Black;
            this.TimeInputShiftTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.TimeInputShiftTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TimeInputShiftTime.Location = new System.Drawing.Point(11, 35);
            // 
            // 
            // 
            this.TimeInputShiftTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeInputShiftTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.TimeInputShiftTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.TimeInputShiftTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.TimeInputShiftTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeInputShiftTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.TimeInputShiftTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.TimeInputShiftTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.TimeInputShiftTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.TimeInputShiftTime.MonthCalendar.DisplayMonth = new System.DateTime(2009, 5, 1, 0, 0, 0, 0);
            this.TimeInputShiftTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.TimeInputShiftTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.TimeInputShiftTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeInputShiftTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.TimeInputShiftTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeInputShiftTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.TimeInputShiftTime.MonthCalendar.TodayButtonVisible = true;
            this.TimeInputShiftTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.TimeInputShiftTime.Name = "TimeInputShiftTime";
            this.TimeInputShiftTime.ShowUpDown = true;
            this.TimeInputShiftTime.Size = new System.Drawing.Size(63, 21);
            this.TimeInputShiftTime.TabIndex = 9;
            this.TimeInputShiftTime.TabStop = false;
            this.TimeInputShiftTime.Tag = "Change";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtOrderNo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtOrderNo.ForeColor = System.Drawing.Color.Black;
            this.txtOrderNo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtOrderNo.Location = new System.Drawing.Point(158, 35);
            this.txtOrderNo.MaxValue = 1000;
            this.txtOrderNo.MinValue = -1000;
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.ShowUpDown = true;
            this.txtOrderNo.Size = new System.Drawing.Size(52, 21);
            this.txtOrderNo.TabIndex = 7;
            this.txtOrderNo.TabStop = false;
            this.txtOrderNo.Tag = "Change";
            this.txtOrderNo.Value = 1;
            // 
            // lblShiftLenght
            // 
            this.lblShiftLenght.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShiftLenght.AutoSize = true;
            this.lblShiftLenght.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblShiftLenght.ForeColor = System.Drawing.Color.White;
            this.lblShiftLenght.Location = new System.Drawing.Point(157, 10);
            this.lblShiftLenght.Name = "lblShiftLenght";
            this.lblShiftLenght.Size = new System.Drawing.Size(66, 16);
            this.lblShiftLenght.TabIndex = 2;
            this.lblShiftLenght.Text = "نوبت دهنده:";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(81, 37);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(59, 16);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "زمان نوبت:";
            // 
            // lblAppRow
            // 
            this.lblAppRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppRow.AutoSize = true;
            this.lblAppRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppRow.ForeColor = System.Drawing.Color.White;
            this.lblAppRow.Location = new System.Drawing.Point(212, 37);
            this.lblAppRow.Name = "lblAppRow";
            this.lblAppRow.Size = new System.Drawing.Size(69, 16);
            this.lblAppRow.TabIndex = 6;
            this.lblAppRow.Text = "شماره نوبت:";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(425, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(70, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "عنوان برنامه:";
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.Panel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.Panel2.Controls.Add(this.PanelGender);
            this.Panel2.Controls.Add(this.txtAge);
            this.Panel2.Controls.Add(this.lblFirstName);
            this.Panel2.Controls.Add(this.txtFirstName);
            this.Panel2.Controls.Add(this.lblLastName);
            this.Panel2.Controls.Add(this.txtLastName);
            this.Panel2.Controls.Add(this.lblGender);
            this.Panel2.Controls.Add(this.txtTel1);
            this.Panel2.Controls.Add(this.txtTel2);
            this.Panel2.Controls.Add(this.lblTel2);
            this.Panel2.Controls.Add(this.lblTel1);
            this.Panel2.Controls.Add(this.lblAge);
            this.Panel2.DrawTitleBox = false;
            this.Panel2.Location = new System.Drawing.Point(13, 84);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(502, 71);
            // 
            // 
            // 
            this.Panel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.Panel2.Style.BackColorGradientAngle = 90;
            this.Panel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.Panel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel2.Style.BorderBottomWidth = 1;
            this.Panel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Panel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel2.Style.BorderLeftWidth = 1;
            this.Panel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel2.Style.BorderRightWidth = 1;
            this.Panel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel2.Style.BorderTopWidth = 1;
            this.Panel2.Style.CornerDiameter = 4;
            this.Panel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.Panel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.Panel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.Panel2.TabIndex = 0;
            // 
            // PanelGender
            // 
            this.PanelGender.Controls.Add(this.cboxMale);
            this.PanelGender.Controls.Add(this.cBoxFemale);
            this.PanelGender.Location = new System.Drawing.Point(2, 9);
            this.PanelGender.Name = "PanelGender";
            this.PanelGender.Size = new System.Drawing.Size(95, 21);
            this.PanelGender.TabIndex = 5;
            // 
            // cboxMale
            // 
            this.cboxMale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxMale.AutoSize = true;
            this.cboxMale.BackColor = System.Drawing.Color.Transparent;
            this.cboxMale.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboxMale.Location = new System.Drawing.Point(47, 2);
            this.cboxMale.Name = "cboxMale";
            this.cboxMale.Size = new System.Drawing.Size(44, 17);
            this.cboxMale.TabIndex = 0;
            this.cboxMale.Tag = "Change";
            this.cboxMale.Text = "مرد";
            this.cboxMale.UseVisualStyleBackColor = false;
            // 
            // cBoxFemale
            // 
            this.cBoxFemale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxFemale.AutoSize = true;
            this.cBoxFemale.BackColor = System.Drawing.Color.Transparent;
            this.cBoxFemale.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxFemale.Location = new System.Drawing.Point(4, 2);
            this.cBoxFemale.Name = "cBoxFemale";
            this.cBoxFemale.Size = new System.Drawing.Size(39, 17);
            this.cBoxFemale.TabIndex = 1;
            this.cBoxFemale.Tag = "Change";
            this.cBoxFemale.Text = "زن";
            this.cBoxFemale.UseVisualStyleBackColor = false;
            // 
            // txtAge
            // 
            this.txtAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtAge.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAge.ButtonClear.Visible = true;
            this.txtAge.ButtonCustom.Visible = true;
            this.txtAge.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtAge.Location = new System.Drawing.Point(362, 36);
            this.txtAge.MaxValue = 1000;
            this.txtAge.MinValue = 1;
            this.txtAge.Name = "txtAge";
            this.txtAge.ShowUpDown = true;
            this.txtAge.Size = new System.Drawing.Size(79, 21);
            this.txtAge.TabIndex = 7;
            this.txtAge.Tag = "Change";
            this.txtAge.Value = 1;
            this.txtAge.ButtonCustomClick += new System.EventHandler(this.txtAge_ButtonCustomClick);
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFirstName.Location = new System.Drawing.Point(468, 11);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(21, 16);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "نام:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFirstName.Border.Class = "TextBoxBorder";
            this.txtFirstName.Location = new System.Drawing.Point(362, 9);
            this.txtFirstName.MaxLength = 15;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(106, 21);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Tag = "Change";
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLastName.Location = new System.Drawing.Point(284, 11);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(74, 16);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "نام خانوادگی:";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtLastName.Border.Class = "TextBoxBorder";
            this.txtLastName.Location = new System.Drawing.Point(147, 9);
            this.txtLastName.MaxLength = 25;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(138, 21);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.Tag = "Change";
            // 
            // lblGender
            // 
            this.lblGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblGender.Location = new System.Drawing.Point(96, 11);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(47, 16);
            this.lblGender.TabIndex = 4;
            this.lblGender.Text = "جنسیت:";
            // 
            // txtTel1
            // 
            this.txtTel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTel1.Border.Class = "TextBoxBorder";
            this.txtTel1.Location = new System.Drawing.Point(193, 36);
            this.txtTel1.MaxLength = 15;
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Size = new System.Drawing.Size(120, 21);
            this.txtTel1.TabIndex = 9;
            this.txtTel1.Tag = "Change";
            this.txtTel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTel2
            // 
            this.txtTel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTel2.Border.Class = "TextBoxBorder";
            this.txtTel2.Location = new System.Drawing.Point(8, 36);
            this.txtTel2.MaxLength = 15;
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.Size = new System.Drawing.Size(131, 21);
            this.txtTel2.TabIndex = 11;
            this.txtTel2.Tag = "Change";
            this.txtTel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTel2
            // 
            this.lblTel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTel2.AutoSize = true;
            this.lblTel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTel2.Location = new System.Drawing.Point(145, 38);
            this.lblTel2.Name = "lblTel2";
            this.lblTel2.Size = new System.Drawing.Size(40, 16);
            this.lblTel2.TabIndex = 10;
            this.lblTel2.Text = "تلفن 2:";
            // 
            // lblTel1
            // 
            this.lblTel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTel1.AutoSize = true;
            this.lblTel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTel1.Location = new System.Drawing.Point(315, 38);
            this.lblTel1.Name = "lblTel1";
            this.lblTel1.Size = new System.Drawing.Size(40, 16);
            this.lblTel1.TabIndex = 8;
            this.lblTel1.Text = "تلفن 1:";
            // 
            // lblAge
            // 
            this.lblAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAge.Location = new System.Drawing.Point(440, 38);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(55, 16);
            this.lblAge.TabIndex = 6;
            this.lblAge.Text = "سن بیمار:";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 329);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف (Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 329);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 60);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تایید (F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // frmAppointmentsEdit
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(527, 401);
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppointmentsEdit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نوبت دهی - ویرایش نوبت";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.MainPanel.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeInputShiftTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.PanelGender.ResumeLayout(false);
            this.PanelGender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx MainPanel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX lblGender;
        private DevComponents.DotNetBar.LabelX lblLastName;
        private DevComponents.DotNetBar.LabelX lblFirstName;
        private DevComponents.DotNetBar.LabelX lblTel1;
        private DevComponents.DotNetBar.LabelX lblAge;
        private System.Windows.Forms.RadioButton cBoxFemale;
        private DevComponents.DotNetBar.Controls.GroupPanel Panel1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput TimeInputShiftTime;
        private DevComponents.DotNetBar.LabelX lblAppDate;
        private DevComponents.DotNetBar.LabelX lblTime;
        private DevComponents.DotNetBar.LabelX lblAppRow;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.Controls.GroupPanel Panel2;
        private System.Windows.Forms.RadioButton cboxMale;
        private DevComponents.DotNetBar.LabelX lblTel2;
        private DevComponents.Editors.IntegerInput txtAge;
        private DevComponents.DotNetBar.LabelX txtAppDate;
        private DevComponents.DotNetBar.LabelX txtTitle;
        private DevComponents.Editors.IntegerInput txtOrderNo;
        private System.Windows.Forms.Panel PanelAdditionalData;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLastName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTel2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTel1;
        private DevComponents.DotNetBar.LabelX lblShiftLenght;
        private System.Windows.Forms.ComboBox cboSchedulders;
        private System.Windows.Forms.Panel PanelGender;
    }
}