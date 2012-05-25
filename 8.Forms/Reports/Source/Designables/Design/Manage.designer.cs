namespace Sepehr.Forms.Reports.Designables.Design
{
    partial class frmManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManage));
            this.RCP = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTopic = new DevComponents.DotNetBar.LabelX();
            this.txtTopic = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.PanelSource = new System.Windows.Forms.Panel();
            this.dgvColumnsList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColColumnsSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColColumnsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColColumnsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.PanelDestination = new System.Windows.Forms.Panel();
            this.dgvCurrentReportCols = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEditedHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUp = new DevComponents.DotNetBar.ButtonX();
            this.btnDown = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnManageFields = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.RCP.SuspendLayout();
            this.TLP.SuspendLayout();
            this.PanelSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnsList)).BeginInit();
            this.PanelDestination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentReportCols)).BeginInit();
            this.SuspendLayout();
            // 
            // RCP
            // 
            this.RCP.CanvasColor = System.Drawing.SystemColors.Control;
            this.RCP.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.RCP.Controls.Add(this.lblName);
            this.RCP.Controls.Add(this.txtName);
            this.RCP.Controls.Add(this.lblTopic);
            this.RCP.Controls.Add(this.txtTopic);
            this.RCP.Controls.Add(this.TLP);
            this.RCP.Controls.Add(this.btnHelp);
            this.RCP.Controls.Add(this.btnManageFields);
            this.RCP.Controls.Add(this.btnClose);
            this.RCP.Controls.Add(this.btnSave);
            this.RCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RCP.Location = new System.Drawing.Point(0, 0);
            this.RCP.Name = "RCP";
            this.RCP.Size = new System.Drawing.Size(794, 574);
            // 
            // 
            // 
            this.RCP.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.RCP.Style.BackColorGradientAngle = 90;
            this.RCP.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.RCP.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile;
            this.RCP.Style.BorderBottomWidth = 1;
            this.RCP.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.RCP.Style.BorderLeftWidth = 1;
            this.RCP.Style.BorderRightWidth = 1;
            this.RCP.Style.BorderTopWidth = 1;
            this.RCP.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.RCP.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.RCP.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(722, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 16);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "نام گزارش:";
            this.lblName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Location = new System.Drawing.Point(12, 12);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(704, 21);
            this.txtName.TabIndex = 0;
            // 
            // lblTopic
            // 
            this.lblTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopic.AutoSize = true;
            this.lblTopic.BackColor = System.Drawing.Color.Transparent;
            this.lblTopic.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopic.Location = new System.Drawing.Point(722, 42);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(53, 16);
            this.lblTopic.TabIndex = 2;
            this.lblTopic.Text = "توضیحات:";
            this.lblTopic.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtTopic
            // 
            this.txtTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTopic.Border.Class = "TextBoxBorder";
            this.txtTopic.Location = new System.Drawing.Point(12, 40);
            this.txtTopic.MaxLength = 50;
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(704, 21);
            this.txtTopic.TabIndex = 3;
            // 
            // TLP
            // 
            this.TLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TLP.BackColor = System.Drawing.Color.Transparent;
            this.TLP.ColumnCount = 2;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.19231F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.80769F));
            this.TLP.Controls.Add(this.PanelSource, 0, 0);
            this.TLP.Controls.Add(this.PanelDestination, 1, 0);
            this.TLP.Location = new System.Drawing.Point(0, 70);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 1;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.Size = new System.Drawing.Size(794, 429);
            this.TLP.TabIndex = 4;
            // 
            // PanelSource
            // 
            this.PanelSource.Controls.Add(this.dgvColumnsList);
            this.PanelSource.Controls.Add(this.btnAdd);
            this.PanelSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSource.Location = new System.Drawing.Point(399, 3);
            this.PanelSource.Name = "PanelSource";
            this.PanelSource.Size = new System.Drawing.Size(392, 423);
            this.PanelSource.TabIndex = 0;
            this.PanelSource.Text = "panelEx1";
            // 
            // dgvColumnsList
            // 
            this.dgvColumnsList.AllowUserToAddRows = false;
            this.dgvColumnsList.AllowUserToDeleteRows = false;
            this.dgvColumnsList.AllowUserToOrderColumns = true;
            this.dgvColumnsList.AllowUserToResizeColumns = false;
            this.dgvColumnsList.AllowUserToResizeRows = false;
            this.dgvColumnsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvColumnsList.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvColumnsList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumnsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvColumnsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumnsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColColumnsSelection,
            this.ColColumnsName,
            this.ColColumnsHeader});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColumnsList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvColumnsList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvColumnsList.Location = new System.Drawing.Point(41, 7);
            this.dgvColumnsList.MultiSelect = false;
            this.dgvColumnsList.Name = "dgvColumnsList";
            this.dgvColumnsList.RowHeadersVisible = false;
            this.dgvColumnsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColumnsList.Size = new System.Drawing.Size(343, 411);
            this.dgvColumnsList.StandardTab = true;
            this.dgvColumnsList.TabIndex = 0;
            this.dgvColumnsList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSource_CellMouseClick);
            this.dgvColumnsList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSource_CellMouseDoubleClick);
            // 
            // ColColumnsSelection
            // 
            this.ColColumnsSelection.HeaderText = "انتخاب";
            this.ColColumnsSelection.Name = "ColColumnsSelection";
            this.ColColumnsSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColColumnsSelection.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColColumnsSelection.Width = 45;
            // 
            // ColColumnsName
            // 
            this.ColColumnsName.HeaderText = "ColumnName";
            this.ColColumnsName.Name = "ColColumnsName";
            this.ColColumnsName.Visible = false;
            // 
            // ColColumnsHeader
            // 
            this.ColColumnsHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColColumnsHeader.HeaderText = "نام ستون ها";
            this.ColColumnsHeader.Name = "ColColumnsHeader";
            this.ColColumnsHeader.ReadOnly = true;
            this.ColColumnsHeader.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Image = global::Sepehr.Forms.Reports.Properties.Resources.Left;
            this.btnAdd.ImageFixedSize = new System.Drawing.Size(25, 25);
            this.btnAdd.Location = new System.Drawing.Point(4, 182);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(31, 59);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // PanelDestination
            // 
            this.PanelDestination.Controls.Add(this.dgvCurrentReportCols);
            this.PanelDestination.Controls.Add(this.btnUp);
            this.PanelDestination.Controls.Add(this.btnDown);
            this.PanelDestination.Controls.Add(this.btnDelete);
            this.PanelDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDestination.Location = new System.Drawing.Point(3, 3);
            this.PanelDestination.Name = "PanelDestination";
            this.PanelDestination.Size = new System.Drawing.Size(390, 423);
            this.PanelDestination.TabIndex = 1;
            this.PanelDestination.Text = "panelEx2";
            // 
            // dgvCurrentReportCols
            // 
            this.dgvCurrentReportCols.AllowUserToAddRows = false;
            this.dgvCurrentReportCols.AllowUserToDeleteRows = false;
            this.dgvCurrentReportCols.AllowUserToResizeColumns = false;
            this.dgvCurrentReportCols.AllowUserToResizeRows = false;
            this.dgvCurrentReportCols.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCurrentReportCols.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvCurrentReportCols.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCurrentReportCols.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCurrentReportCols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentReportCols.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColHeader,
            this.ColEditedHeader});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCurrentReportCols.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCurrentReportCols.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCurrentReportCols.Location = new System.Drawing.Point(43, 7);
            this.dgvCurrentReportCols.MultiSelect = false;
            this.dgvCurrentReportCols.Name = "dgvCurrentReportCols";
            this.dgvCurrentReportCols.RowHeadersVisible = false;
            this.dgvCurrentReportCols.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentReportCols.Size = new System.Drawing.Size(341, 411);
            this.dgvCurrentReportCols.StandardTab = true;
            this.dgvCurrentReportCols.TabIndex = 0;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "ColColumnsName";
            this.ColName.HeaderText = "ColumnName";
            this.ColName.Name = "ColName";
            this.ColName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColName.Visible = false;
            // 
            // ColHeader
            // 
            this.ColHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColHeader.HeaderText = "نام ستون ها";
            this.ColHeader.Name = "ColHeader";
            this.ColHeader.ReadOnly = true;
            this.ColHeader.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColEditedHeader
            // 
            this.ColEditedHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColEditedHeader.DataPropertyName = "ColColumnsHeaders";
            this.ColEditedHeader.HeaderText = "نام ویرایش شده ستون ها";
            this.ColEditedHeader.MaxInputLength = 50;
            this.ColEditedHeader.Name = "ColEditedHeader";
            this.ColEditedHeader.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnUp
            // 
            this.btnUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUp.Image = global::Sepehr.Forms.Reports.Properties.Resources.Collapse;
            this.btnUp.ImageFixedSize = new System.Drawing.Size(25, 25);
            this.btnUp.Location = new System.Drawing.Point(7, 7);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(31, 47);
            this.btnUp.TabIndex = 1;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDown.Image = global::Sepehr.Forms.Reports.Properties.Resources.Expand;
            this.btnDown.ImageFixedSize = new System.Drawing.Size(25, 25);
            this.btnDown.Location = new System.Drawing.Point(7, 60);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(31, 47);
            this.btnDown.TabIndex = 2;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Image = global::Sepehr.Forms.Reports.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(7, 113);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(31, 47);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Forms.Reports.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(687, 505);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            // 
            // btnManageFields
            // 
            this.btnManageFields.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnManageFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManageFields.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnManageFields.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnManageFields.ForeColor = System.Drawing.Color.Crimson;
            this.btnManageFields.Image = global::Sepehr.Forms.Reports.Properties.Resources.AddinFields;
            this.btnManageFields.Location = new System.Drawing.Point(586, 505);
            this.btnManageFields.Name = "btnManageFields";
            this.btnManageFields.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnManageFields.Size = new System.Drawing.Size(95, 57);
            this.btnManageFields.TabIndex = 7;
            this.btnManageFields.TabStop = false;
            this.btnManageFields.Text = "فیلدهای اختصاصی";
            this.btnManageFields.Click += new System.EventHandler(this.btnManageFields_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Sepehr.Forms.Reports.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(113, 505);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 57);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "انصراف\r\n(Esc)";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSave.Image = global::Sepehr.Forms.Reports.Properties.Resources.Accept;
            this.btnSave.Location = new System.Drawing.Point(12, 505);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSave.Size = new System.Drawing.Size(95, 57);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "ذخیره\r\n(F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(794, 574);
            this.Controls.Add(this.RCP);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmManage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش ها - گزارش های قابل طراحی - طراحی گزارش";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.RCP.ResumeLayout(false);
            this.RCP.PerformLayout();
            this.TLP.ResumeLayout(false);
            this.PanelSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnsList)).EndInit();
            this.PanelDestination.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentReportCols)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel RCP;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvColumnsList;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvCurrentReportCols;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnDown;
        private DevComponents.DotNetBar.ButtonX btnUp;
        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.Panel PanelSource;
        private System.Windows.Forms.Panel PanelDestination;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTopic;
        private DevComponents.DotNetBar.LabelX lblTopic;
        private DevComponents.DotNetBar.ButtonX btnManageFields;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColColumnsSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColColumnsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColColumnsHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEditedHeader;

    }
}