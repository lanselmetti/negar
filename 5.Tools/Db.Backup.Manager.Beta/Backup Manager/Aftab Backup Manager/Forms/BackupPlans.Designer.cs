namespace Aftab
{
    partial class frmBackupPlans
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackupPlans));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.cmsForm = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsMenu = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditApp = new DevComponents.DotNetBar.ButtonItem();
            this.btnRemove = new DevComponents.DotNetBar.ButtonItem();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.cBoxWithInActives = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStartDate = new AftabCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.ColEndDate = new AftabCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.ColTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSavePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.cmsForm);
            this.FormPanel.Controls.Add(this.btnAdd);
            this.FormPanel.Controls.Add(this.cBoxWithInActives);
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.btnClose);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(794, 572);
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
            this.FormPanel.TabIndex = 1;
            // 
            // cmsForm
            // 
            this.cmsForm.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.cmsForm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsForm.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsMenu});
            this.cmsForm.Location = new System.Drawing.Point(626, 503);
            this.cmsForm.Name = "cmsForm";
            this.cmsForm.Size = new System.Drawing.Size(55, 25);
            this.cmsForm.Stretch = true;
            this.cmsForm.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsForm.TabIndex = 11;
            this.cmsForm.TabStop = false;
            // 
            // cmsMenu
            // 
            this.cmsMenu.AutoExpandOnClick = true;
            this.cmsMenu.ImagePaddingHorizontal = 8;
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnEditApp,
            this.btnRemove});
            this.cmsMenu.Text = "منو";
            // 
            // btnEditApp
            // 
            this.btnEditApp.Image = global::Aftab.Properties.Resources.EditSmall;
            this.btnEditApp.ImagePaddingHorizontal = 8;
            this.btnEditApp.Name = "btnEditApp";
            this.btnEditApp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnEditApp.Text = "<b>ویرایش برنامه</b>\r\n<div></div>\r\n<font color=\"#000000\">ویرایش ساختار برنامه انت" +
                "خاب شده.</font>";
            this.btnEditApp.Click += new System.EventHandler(this.btnEditApp_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Image = global::Aftab.Properties.Resources.DeleteMed;
            this.btnRemove.ImagePaddingHorizontal = 8;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnRemove.Text = "<b>حذف برنامه</b>\r\n<div></div>\r\n<font color=\"#000000\">حذف برنامه انتخاب شده از با" +
                "نك.</font>";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Image = global::Aftab.Properties.Resources.AddMed;
            this.btnAdd.Location = new System.Drawing.Point(687, 503);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnAdd.Size = new System.Drawing.Size(95, 57);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "افزودن\r\n(F6)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cBoxWithInActives
            // 
            this.cBoxWithInActives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxWithInActives.AutoSize = true;
            this.cBoxWithInActives.BackColor = System.Drawing.Color.Transparent;
            this.cBoxWithInActives.Checked = true;
            this.cBoxWithInActives.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxWithInActives.CheckValue = "Y";
            this.cBoxWithInActives.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxWithInActives.Location = new System.Drawing.Point(617, 481);
            this.cBoxWithInActives.Name = "cBoxWithInActives";
            this.cBoxWithInActives.Size = new System.Drawing.Size(166, 16);
            this.cBoxWithInActives.TabIndex = 6;
            this.cBoxWithInActives.Text = "نمایش برنامه های غیر فعال";
            this.cBoxWithInActives.TextColor = System.Drawing.Color.MediumVioletRed;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
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
            this.ColID,
            this.ColIsActive,
            this.ColAppName,
            this.ColStartDate,
            this.ColEndDate,
            this.ColTime,
            this.ColSavePath});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 12);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(770, 463);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 0;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Aftab.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 503);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 57);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج\r\n(Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "ID";
            this.ColID.HeaderText = "شناسه";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColID.Visible = false;
            this.ColID.Width = 50;
            // 
            // ColIsActive
            // 
            this.ColIsActive.DataPropertyName = "IsActive";
            this.ColIsActive.HeaderText = "فعال";
            this.ColIsActive.Name = "ColIsActive";
            this.ColIsActive.ReadOnly = true;
            this.ColIsActive.ToolTipText = "فعال بودن";
            this.ColIsActive.Width = 35;
            // 
            // ColAppName
            // 
            this.ColAppName.DataPropertyName = "AppName";
            this.ColAppName.HeaderText = "نام برنامه";
            this.ColAppName.Name = "ColAppName";
            this.ColAppName.ReadOnly = true;
            this.ColAppName.Width = 160;
            // 
            // ColStartDate
            // 
            this.ColStartDate.DataPropertyName = "DateAppStart";
            this.ColStartDate.HeaderText = "تاریخ آغاز";
            this.ColStartDate.Name = "ColStartDate";
            this.ColStartDate.ReadOnly = true;
            this.ColStartDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColStartDate.ShowTime = true;
            this.ColStartDate.Width = 85;
            // 
            // ColEndDate
            // 
            this.ColEndDate.DataPropertyName = "DateAppEnd";
            this.ColEndDate.HeaderText = "تاریخ پایان";
            this.ColEndDate.Name = "ColEndDate";
            this.ColEndDate.ReadOnly = true;
            this.ColEndDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColEndDate.ShowTime = true;
            this.ColEndDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColEndDate.Width = 85;
            // 
            // ColTime
            // 
            this.ColTime.DataPropertyName = "TimeStart";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "HH:mm";
            this.ColTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColTime.HeaderText = "ساعت";
            this.ColTime.Name = "ColTime";
            this.ColTime.ReadOnly = true;
            this.ColTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColTime.Width = 60;
            // 
            // ColSavePath
            // 
            this.ColSavePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColSavePath.DataPropertyName = "FirstPath";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColSavePath.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColSavePath.HeaderText = "مسیر ذخیره سازی";
            this.ColSavePath.Name = "ColSavePath";
            this.ColSavePath.ReadOnly = true;
            // 
            // frmBackupPlans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.FormPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmBackupPlans";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت برنامه های پشتیبان گیری";
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.ContextMenuBar cmsForm;
        private DevComponents.DotNetBar.ButtonItem cmsMenu;
        private DevComponents.DotNetBar.ButtonItem btnEditApp;
        private DevComponents.DotNetBar.ButtonItem btnRemove;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxWithInActives;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAppName;
        private AftabCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColStartDate;
        private AftabCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSavePath;
    }
}