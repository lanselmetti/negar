namespace Sepehr.Settings.Schedules.AppsAddinFields
{
    partial class frmAddinCols
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddinCols));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.cmsForm = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsMenu = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditApp = new DevComponents.DotNetBar.ButtonItem();
            this.btnMultiChoiceFieldItems = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnMultiChoiceItems = new DevComponents.DotNetBar.ButtonX();
            this.btnColsOrder = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
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
            this.FormPanel.Controls.Add(this.btnClose);
            this.FormPanel.Controls.Add(this.btnMultiChoiceItems);
            this.FormPanel.Controls.Add(this.btnColsOrder);
            this.FormPanel.Controls.Add(this.btnAdd);
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(502, 354);
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
            // cmsForm
            // 
            this.cmsForm.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.cmsForm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsForm.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsMenu});
            this.cmsForm.Location = new System.Drawing.Point(435, 254);
            this.cmsForm.Name = "cmsForm";
            this.cmsForm.Size = new System.Drawing.Size(55, 25);
            this.cmsForm.Stretch = true;
            this.cmsForm.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsForm.TabIndex = 13;
            this.cmsForm.TabStop = false;
            // 
            // cmsMenu
            // 
            this.cmsMenu.AutoExpandOnClick = true;
            this.cmsMenu.ImagePaddingHorizontal = 8;
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnEditApp,
            this.btnMultiChoiceFieldItems,
            this.btnDelete});
            this.cmsMenu.Text = "منو";
            // 
            // btnEditApp
            // 
            this.btnEditApp.Image = global::Sepehr.Settings.Schedules.Properties.Resources.EditSmall;
            this.btnEditApp.ImagePaddingHorizontal = 8;
            this.btnEditApp.Name = "btnEditApp";
            this.btnEditApp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnEditApp.Text = "<b>ویرایش فیلد</b>\r\n<div></div>\r\n<font color=\"#000000\">نام و برنامه های تحت پوشش." +
                "</font>";
            this.btnEditApp.Click += new System.EventHandler(this.btnEditApp_Click);
            // 
            // btnMultiChoiceFieldItems
            // 
            this.btnMultiChoiceFieldItems.Image = global::Sepehr.Settings.Schedules.Properties.Resources.AddinFields;
            this.btnMultiChoiceFieldItems.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnMultiChoiceFieldItems.ImagePaddingHorizontal = 8;
            this.btnMultiChoiceFieldItems.Name = "btnMultiChoiceFieldItems";
            this.btnMultiChoiceFieldItems.Text = "<b>آیتم های در دسترس</b>\r\n<div></div>\r\n<font color=\"#000000\">تعیین موارد قابل است" +
                "فاده.</font>";
            this.btnMultiChoiceFieldItems.Click += new System.EventHandler(this.btnMultiChoiceFieldItems_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Delete;
            this.btnDelete.ImagePaddingHorizontal = 8;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnDelete.Text = "<b>حذف فیلد اطلاعاتی</b>\r\n<div></div>\r\n<font color=\"#000000\">ستون اطلاعاتی و داده" +
                " ها.</font>";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 285);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 57);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج\r\n(Esc)";
            // 
            // btnMultiChoiceItems
            // 
            this.btnMultiChoiceItems.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMultiChoiceItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMultiChoiceItems.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnMultiChoiceItems.Image = global::Sepehr.Settings.Schedules.Properties.Resources.AddinFields;
            this.btnMultiChoiceItems.Location = new System.Drawing.Point(107, 285);
            this.btnMultiChoiceItems.Name = "btnMultiChoiceItems";
            this.btnMultiChoiceItems.Size = new System.Drawing.Size(92, 57);
            this.btnMultiChoiceItems.TabIndex = 3;
            this.btnMultiChoiceItems.TabStop = false;
            this.btnMultiChoiceItems.Text = "آیتم های\r\nانتخابی";
            this.btnMultiChoiceItems.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.btnMultiChoiceItems.Click += new System.EventHandler(this.btnMultiChoiceItems_Click);
            // 
            // btnColsOrder
            // 
            this.btnColsOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnColsOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColsOrder.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnColsOrder.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Descending;
            this.btnColsOrder.Location = new System.Drawing.Point(205, 285);
            this.btnColsOrder.Name = "btnColsOrder";
            this.btnColsOrder.Size = new System.Drawing.Size(95, 57);
            this.btnColsOrder.TabIndex = 3;
            this.btnColsOrder.TabStop = false;
            this.btnColsOrder.Text = "ترتیب\r\nستونها";
            this.btnColsOrder.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.btnColsOrder.Click += new System.EventHandler(this.btnColsOrder_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Image = global::Sepehr.Settings.Schedules.Properties.Resources.AddMed;
            this.btnAdd.Location = new System.Drawing.Point(306, 285);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnAdd.Size = new System.Drawing.Size(89, 57);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "افزودن (F6)";
            this.btnAdd.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.ColTitle,
            this.ColDescription});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 12);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(478, 267);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 0;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDoubleClick);
            // 
            // ColTitle
            // 
            this.ColTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColTitle.DataPropertyName = "Title";
            this.ColTitle.HeaderText = "نام ستون";
            this.ColTitle.MaxInputLength = 50;
            this.ColTitle.Name = "ColTitle";
            this.ColTitle.ReadOnly = true;
            // 
            // ColDescription
            // 
            this.ColDescription.DataPropertyName = "Description";
            this.ColDescription.HeaderText = "توضیحات";
            this.ColDescription.MaxInputLength = 300;
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            this.ColDescription.Width = 250;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(401, 285);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(89, 57);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmAddinCols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(502, 354);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(512, 384);
            this.Name = "frmAddinCols";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - نوبت دهی - فیلدهای اطلاعات اضافی نوبت دهی";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        

        

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ContextMenuBar cmsForm;
        private DevComponents.DotNetBar.ButtonItem cmsMenu;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private DevComponents.DotNetBar.ButtonItem btnEditApp;
        private DevComponents.DotNetBar.ButtonX btnMultiChoiceItems;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnColsOrder;
        private DevComponents.DotNetBar.ButtonItem btnMultiChoiceFieldItems;
    }
}