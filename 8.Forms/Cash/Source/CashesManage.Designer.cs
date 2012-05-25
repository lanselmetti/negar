namespace Sepehr.Forms.Cash
{
    partial class frmCashesManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashesManage));
            this.ribbonBarOrders = new DevComponents.DotNetBar.RibbonBar();
            this.btnClose = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnHelp = new DevComponents.DotNetBar.ButtonItem();
            this.dgvCashes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColRowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCashName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCashStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInOutBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCashDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.cmsPatients = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsdgvData = new DevComponents.DotNetBar.ButtonItem();
            this.btnCloseCash = new DevComponents.DotNetBar.ButtonItem();
            this.btnOpenCash = new DevComponents.DotNetBar.ButtonItem();
            this.btnInput = new DevComponents.DotNetBar.ButtonItem();
            this.btnOutput = new DevComponents.DotNetBar.ButtonItem();
            this.btnCashInOutReport = new DevComponents.DotNetBar.ButtonItem();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonBarOrders
            // 
            this.ribbonBarOrders.AutoOverflowEnabled = true;
            this.ribbonBarOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonBarOrders.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ribbonBarOrders.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnClose,
            this.btnRefresh,
            this.btnHelp});
            this.ribbonBarOrders.Location = new System.Drawing.Point(0, 0);
            this.ribbonBarOrders.Name = "ribbonBarOrders";
            this.ribbonBarOrders.ShowShortcutKeysInToolTips = true;
            this.ribbonBarOrders.Size = new System.Drawing.Size(634, 75);
            this.ribbonBarOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBarOrders.TabIndex = 1;
            this.ribbonBarOrders.Text = "نوار دسترسی";
            this.ribbonBarOrders.TitleVisible = false;
            this.ribbonBarOrders.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // btnClose
            // 
            this.btnClose.BeginGroup = true;
            this.btnClose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClose.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnClose.Image = global::Sepehr.Forms.Cash.Properties.Resources.Cancel;
            this.btnClose.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnClose.ImagePaddingHorizontal = 8;
            this.btnClose.ImagePaddingVertical = 10;
            this.btnClose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClose.Name = "btnClose";
            this.btnClose.RibbonWordWrap = false;
            this.btnClose.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnClose.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.AltF4);
            this.btnClose.Text = "خروج\r\n(Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefresh.FontBold = true;
            this.btnRefresh.Image = global::Sepehr.Forms.Cash.Properties.Resources.Refresh;
            this.btnRefresh.ImagePaddingHorizontal = 8;
            this.btnRefresh.ImagePaddingVertical = 12;
            this.btnRefresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.Text = "بازخوانی\r\n(F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnHelp.Image = global::Sepehr.Forms.Cash.Properties.Resources.HelpMed;
            this.btnHelp.ImagePaddingHorizontal = 8;
            this.btnHelp.ImagePaddingVertical = 10;
            this.btnHelp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.RibbonWordWrap = false;
            this.btnHelp.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Text = "راهنمای\r\nفرمان ها";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // dgvCashes
            // 
            this.dgvCashes.AllowUserToAddRows = false;
            this.dgvCashes.AllowUserToDeleteRows = false;
            this.dgvCashes.AllowUserToOrderColumns = true;
            this.dgvCashes.AllowUserToResizeColumns = false;
            this.dgvCashes.AllowUserToResizeRows = false;
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
            this.ColRowNum,
            this.ColCashName,
            this.ColCashStatus,
            this.ColInOutBalance,
            this.ColCashDescription});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCashes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCashes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCashes.Location = new System.Drawing.Point(0, 75);
            this.dgvCashes.MultiSelect = false;
            this.dgvCashes.Name = "dgvCashes";
            this.dgvCashes.ReadOnly = true;
            this.dgvCashes.RowHeadersVisible = false;
            this.dgvCashes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCashes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvCashes.RowTemplate.Height = 30;
            this.dgvCashes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashes.Size = new System.Drawing.Size(634, 379);
            this.dgvCashes.TabIndex = 0;
            this.dgvCashes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCashes_CellMouseClick);
            this.dgvCashes.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvCashes_PreviewKeyDown);
            // 
            // ColRowNum
            // 
            this.ColRowNum.DataPropertyName = "RowNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColRowNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColRowNum.HeaderText = "ردیف";
            this.ColRowNum.Name = "ColRowNum";
            this.ColRowNum.ReadOnly = true;
            this.ColRowNum.Width = 40;
            // 
            // ColCashName
            // 
            this.ColCashName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColCashName.DataPropertyName = "Name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ColCashName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColCashName.HeaderText = "نام صندوق";
            this.ColCashName.MaxInputLength = 50;
            this.ColCashName.Name = "ColCashName";
            this.ColCashName.ReadOnly = true;
            // 
            // ColCashStatus
            // 
            this.ColCashStatus.DataPropertyName = "CashStatus";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.NullValue = "باز نشده";
            this.ColCashStatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColCashStatus.HeaderText = "وضعیت";
            this.ColCashStatus.Name = "ColCashStatus";
            this.ColCashStatus.ReadOnly = true;
            this.ColCashStatus.ToolTipText = "باز نشده - باز - بسته";
            this.ColCashStatus.Width = 80;
            // 
            // ColInOutBalance
            // 
            this.ColInOutBalance.DataPropertyName = "InOutBalance";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "بدون مقدار";
            this.ColInOutBalance.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColInOutBalance.HeaderText = "تراز ورود و خروج";
            this.ColInOutBalance.Name = "ColInOutBalance";
            this.ColInOutBalance.ReadOnly = true;
            this.ColInOutBalance.ToolTipText = "ورودی ها منهای خروجی ها به ریال";
            this.ColInOutBalance.Width = 140;
            // 
            // ColCashDescription
            // 
            this.ColCashDescription.DataPropertyName = "Description";
            this.ColCashDescription.HeaderText = "توضیحات صندوق";
            this.ColCashDescription.Name = "ColCashDescription";
            this.ColCashDescription.ReadOnly = true;
            this.ColCashDescription.Width = 200;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // cmsPatients
            // 
            this.cmsPatients.CanCustomize = false;
            this.cmsPatients.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsPatients.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsdgvData});
            this.cmsPatients.Location = new System.Drawing.Point(467, 110);
            this.cmsPatients.Name = "cmsPatients";
            this.cmsPatients.Size = new System.Drawing.Size(155, 25);
            this.cmsPatients.Stretch = true;
            this.cmsPatients.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsPatients.TabIndex = 6654;
            this.cmsPatients.TabStop = false;
            // 
            // cmsdgvData
            // 
            this.cmsdgvData.AutoExpandOnClick = true;
            this.cmsdgvData.ImagePaddingHorizontal = 8;
            this.cmsdgvData.Name = "cmsdgvData";
            this.cmsdgvData.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCloseCash,
            this.btnOpenCash,
            this.btnInput,
            this.btnOutput,
            this.btnCashInOutReport});
            this.cmsdgvData.Text = "منوی مدیریت صندوق ها";
            // 
            // btnCloseCash
            // 
            this.btnCloseCash.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCloseCash.FontBold = true;
            this.btnCloseCash.ForeColor = System.Drawing.Color.Red;
            this.btnCloseCash.Image = global::Sepehr.Forms.Cash.Properties.Resources.Deny;
            this.btnCloseCash.ImagePaddingHorizontal = 8;
            this.btnCloseCash.Name = "btnCloseCash";
            this.btnCloseCash.Text = "بستن صندوق";
            this.btnCloseCash.Click += new System.EventHandler(this.btnOpenOrCloseCash_Click);
            // 
            // btnOpenCash
            // 
            this.btnOpenCash.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnOpenCash.FontBold = true;
            this.btnOpenCash.Image = global::Sepehr.Forms.Cash.Properties.Resources.Allow;
            this.btnOpenCash.ImagePaddingHorizontal = 8;
            this.btnOpenCash.Name = "btnOpenCash";
            this.btnOpenCash.Text = "بازكردن صندوق";
            this.btnOpenCash.Click += new System.EventHandler(this.btnOpenOrCloseCash_Click);
            // 
            // btnInput
            // 
            this.btnInput.BeginGroup = true;
            this.btnInput.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnInput.FontBold = true;
            this.btnInput.Image = global::Sepehr.Forms.Cash.Properties.Resources.RecieveMoney;
            this.btnInput.ImagePaddingHorizontal = 4;
            this.btnInput.Name = "btnInput";
            this.btnInput.Tag = "Input";
            this.btnInput.Text = "ورود پول";
            this.btnInput.Click += new System.EventHandler(this.btnInputOrOutputMoney_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnOutput.FontBold = true;
            this.btnOutput.Image = global::Sepehr.Forms.Cash.Properties.Resources.PayMoney;
            this.btnOutput.ImagePaddingHorizontal = 4;
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Tag = "Output";
            this.btnOutput.Text = "خروج پول";
            this.btnOutput.Click += new System.EventHandler(this.btnInputOrOutputMoney_Click);
            // 
            // btnCashInOutReport
            // 
            this.btnCashInOutReport.BeginGroup = true;
            this.btnCashInOutReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCashInOutReport.FontBold = true;
            this.btnCashInOutReport.Image = global::Sepehr.Forms.Cash.Properties.Resources.CashReport;
            this.btnCashInOutReport.ImagePaddingHorizontal = 8;
            this.btnCashInOutReport.Name = "btnCashInOutReport";
            this.btnCashInOutReport.Text = "گزارش ورود\r\nو خروج پول";
            this.btnCashInOutReport.Click += new System.EventHandler(this.btnCashInOutReport_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(1, -54);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 25);
            this.btnExit.TabIndex = 6655;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // frmCashesManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(634, 454);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cmsPatients);
            this.Controls.Add(this.dgvCashes);
            this.Controls.Add(this.ribbonBarOrders);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmCashesManage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صندوق - فرم مدیریت صندوق ها";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsPatients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonBar ribbonBarOrders;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvCashes;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ButtonItem btnHelp;
        private DevComponents.DotNetBar.ContextMenuBar cmsPatients;
        private DevComponents.DotNetBar.ButtonItem cmsdgvData;
        private DevComponents.DotNetBar.ButtonItem btnOpenCash;
        private DevComponents.DotNetBar.ButtonItem btnCloseCash;
        private DevComponents.DotNetBar.ButtonItem btnInput;
        private DevComponents.DotNetBar.ButtonItem btnOutput;
        private DevComponents.DotNetBar.ButtonItem btnClose;
        private DevComponents.DotNetBar.ButtonItem btnCashInOutReport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRowNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCashName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCashStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInOutBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCashDescription;
    }
}