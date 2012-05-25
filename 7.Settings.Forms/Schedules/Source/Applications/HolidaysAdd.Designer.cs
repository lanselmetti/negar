namespace Sepehr.Settings.Schedules.Applications
{
    partial class frmHolidaysAdd
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
            this.components = new System.ComponentModel.Container();
            this.lbl1 = new DevComponents.DotNetBar.LabelX();
            this.lbl2 = new DevComponents.DotNetBar.LabelX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.FormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.cboApplications = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.DateSelected = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl1.Location = new System.Drawing.Point(246, 73);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(68, 16);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "انتخاب تاریخ:";
            this.lbl1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl2.Location = new System.Drawing.Point(246, 46);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(55, 16);
            this.lbl2.TabIndex = 1;
            this.lbl2.Text = "نام برنامه:";
            this.lbl2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(12, 99);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(296, 59);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "با ثبت یك روز تعطیل برای یك برنامه ، نوبت های موجود برای آن برنامه در آن روز نادی" +
                "ده گرفته می شود و نمایش داده نمی شود.\r\nدر صورت تمایل برای مشاهده مجدد روز انتخاب" +
                " شده ، تاریخ تعطیلی را حذف نمایید.";
            this.lblDescription.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.lblDescription.WordWrap = true;
            // 
            // FormErrorProvider
            // 
            this.FormErrorProvider.ContainerControl = this;
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 171);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تاييد\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // cboApplications
            // 
            this.cboApplications.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboApplications.DisplayMember = "Name";
            this.cboApplications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApplications.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboApplications.FormattingEnabled = true;
            this.cboApplications.ItemHeight = 13;
            this.cboApplications.Location = new System.Drawing.Point(63, 44);
            this.cboApplications.Name = "cboApplications";
            this.cboApplications.Size = new System.Drawing.Size(181, 21);
            this.cboApplications.TabIndex = 0;
            this.cboApplications.ValueMember = "ID";
            this.cboApplications.WatermarkText = "یك گروه از لیست انتخاب نمایید...";
            // 
            // DateSelected
            // 
            this.DateSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateSelected.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.DateSelected.IsAllowNullDate = false;
            this.DateSelected.IsPopupOpen = false;
            this.DateSelected.Location = new System.Drawing.Point(143, 71);
            this.DateSelected.Name = "DateSelected";
            this.DateSelected.SelectedDateTime = new System.DateTime(2009, 7, 23, 0, 0, 0, 0);
            this.DateSelected.Size = new System.Drawing.Size(101, 21);
            this.DateSelected.TabIndex = 3;
            // 
            // frmHolidaysAdd
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.CancelButton = this.btnCancel;
            this.CaptionColor = System.Drawing.Color.Navy;
            this.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CaptionImage = global::Sepehr.Settings.Schedules.Properties.Resources.SchHolidays;
            this.CaptionText = "انتخاب روز تعطیلی برنامه نوبت دهی";
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.Controls.Add(this.DateSelected);
            this.Controls.Add(this.cboApplications);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(55)))), ((int)(((byte)(114)))));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmHolidaysAdd";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style = DevComponents.DotNetBar.eBallonStyle.Office2007Alert;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Shown += new System.EventHandler(this.Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.LabelX lbl1;
        private DevComponents.DotNetBar.LabelX lbl2;
        private DevComponents.DotNetBar.LabelX lblDescription;
        private System.Windows.Forms.ErrorProvider FormErrorProvider;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboApplications;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker DateSelected;
    }
}