namespace Sepehr.Forms.Cash
{
    partial class frmCashInOutReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashInOutReport));
            this.ribbonBarOrders = new DevComponents.DotNetBar.RibbonBar();
            this.btnClose = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerCashName = new DevComponents.DotNetBar.ItemContainer();
            this.lblCashName = new DevComponents.DotNetBar.LabelItem();
            this.txtCashName = new DevComponents.DotNetBar.LabelItem();
            this.dgvCashes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColCashName = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.ColCashierName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColRealType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashes)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonBarOrders
            // 
            this.ribbonBarOrders.AutoOverflowEnabled = true;
            this.ribbonBarOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonBarOrders.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ribbonBarOrders.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnClose,
            this.iContainerCashName});
            this.ribbonBarOrders.ItemSpacing = 3;
            this.ribbonBarOrders.Location = new System.Drawing.Point(0, 0);
            this.ribbonBarOrders.Name = "ribbonBarOrders";
            this.ribbonBarOrders.ShowShortcutKeysInToolTips = true;
            this.ribbonBarOrders.Size = new System.Drawing.Size(794, 63);
            this.ribbonBarOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBarOrders.TabIndex = 6652;
            this.ribbonBarOrders.Text = "نوار دسترسی";
            this.ribbonBarOrders.TitleVisible = false;
            this.ribbonBarOrders.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // btnClose
            // 
            this.btnClose.BeginGroup = true;
            this.btnClose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClose.ForeColor = System.Drawing.Color.Purple;
            this.btnClose.Image = global::Sepehr.Forms.Cash.Properties.Resources.Cancel;
            this.btnClose.ImagePaddingHorizontal = 8;
            this.btnClose.Name = "btnClose";
            this.btnClose.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.AltF4);
            this.btnClose.SubItemsExpandWidth = 14;
            this.btnClose.Text = "خروج\r\n(Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // iContainerCashName
            // 
            this.iContainerCashName.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerCashName.ItemSpacing = 5;
            this.iContainerCashName.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerCashName.Name = "iContainerCashName";
            this.iContainerCashName.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblCashName,
            this.txtCashName});
            this.iContainerCashName.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // lblCashName
            // 
            this.lblCashName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCashName.Height = 40;
            this.lblCashName.Name = "lblCashName";
            this.lblCashName.PaddingLeft = 2;
            this.lblCashName.PaddingRight = 2;
            this.lblCashName.Text = "نام صندوق:";
            this.lblCashName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtCashName
            // 
            this.txtCashName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCashName.Height = 40;
            this.txtCashName.Name = "txtCashName";
            this.txtCashName.PaddingLeft = 2;
            this.txtCashName.PaddingRight = 2;
            this.txtCashName.Text = "نام صندوق";
            this.txtCashName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // dgvCashes
            // 
            this.dgvCashes.AllowUserToAddRows = false;
            this.dgvCashes.AllowUserToDeleteRows = false;
            this.dgvCashes.AllowUserToOrderColumns = true;
            this.dgvCashes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvCashes.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvCashes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCashes.ColumnHeadersHeight = 25;
            this.dgvCashes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCashes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCashName,
            this.ColCashierName,
            this.ColRealType,
            this.ColPayType,
            this.ColValue,
            this.ColDescription});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashes.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCashes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCashes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCashes.Location = new System.Drawing.Point(0, 63);
            this.dgvCashes.MultiSelect = false;
            this.dgvCashes.Name = "dgvCashes";
            this.dgvCashes.ReadOnly = true;
            this.dgvCashes.RowHeadersVisible = false;
            this.dgvCashes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCashes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashes.Size = new System.Drawing.Size(794, 511);
            this.dgvCashes.TabIndex = 6653;
            this.dgvCashes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCashes_CellFormatting);
            // 
            // ColCashName
            // 
            this.ColCashName.DataPropertyName = "OccuredDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColCashName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColCashName.HeaderText = "زمان اعمال";
            this.ColCashName.Name = "ColCashName";
            this.ColCashName.ReadOnly = true;
            this.ColCashName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCashName.ShowTime = true;
            this.ColCashName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColCashName.Width = 150;
            // 
            // ColCashierName
            // 
            this.ColCashierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColCashierName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColCashierName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColCashierName.HeaderText = "نام صندوقدار";
            this.ColCashierName.Name = "ColCashierName";
            this.ColCashierName.ReadOnly = true;
            // 
            // ColRealType
            // 
            this.ColRealType.DataPropertyName = "IsInput";
            this.ColRealType.HeaderText = "كلید نوع";
            this.ColRealType.Name = "ColRealType";
            this.ColRealType.ReadOnly = true;
            this.ColRealType.Visible = false;
            // 
            // ColPayType
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColPayType.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColPayType.HeaderText = "نوع";
            this.ColPayType.Name = "ColPayType";
            this.ColPayType.ReadOnly = true;
            // 
            // ColValue
            // 
            this.ColValue.DataPropertyName = "Value";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.Format = "N0";
            this.ColValue.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColValue.HeaderText = "مبلغ (ریال)";
            this.ColValue.Name = "ColValue";
            this.ColValue.ReadOnly = true;
            this.ColValue.Width = 120;
            // 
            // ColDescription
            // 
            this.ColDescription.DataPropertyName = "Description";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColDescription.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColDescription.HeaderText = "توضیحات";
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            this.ColDescription.Width = 300;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(5, -56);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 25);
            this.btnExit.TabIndex = 6654;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // frmCashInOutReport
            // 
            this.AcceptButton = this.btnExit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(794, 574);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvCashes);
            this.Controls.Add(this.ribbonBarOrders);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmCashInOutReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صندوق - گزارش ورود و خروج پول در صندوق";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonBar ribbonBarOrders;
        private DevComponents.DotNetBar.ButtonItem btnClose;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvCashes;
        private DevComponents.DotNetBar.ItemContainer iContainerCashName;
        private DevComponents.DotNetBar.LabelItem lblCashName;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.LabelItem txtCashName;
        private System.Windows.Forms.Button btnExit;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColCashName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColCashierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRealType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
    }
}