namespace OutlookGridApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBoundObjectList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUnboundObjectList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBoundDatasetQuarterly = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBoundDatasetSales = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBoundDatasetInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCollapseAllGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExpandAllGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClearAllGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSkinDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSkinOutlook = new System.Windows.Forms.ToolStripMenuItem();
            this.outlookGrid1 = new OutlookStyleControls.OutlookGrid();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outlookGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 317);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(535, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(292, 17);
            this.toolStripStatusLabel1.Text = "Click any column to start sorting and grouping automatically";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.viewToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(535, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBoundObjectList,
            this.menuUnboundObjectList,
            this.menuBoundDatasetQuarterly,
            this.menuBoundDatasetSales,
            this.menuBoundDatasetInvoices});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.dataToolStripMenuItem.Text = "&Data";
            // 
            // menuBoundObjectList
            // 
            this.menuBoundObjectList.Name = "menuBoundObjectList";
            this.menuBoundObjectList.Size = new System.Drawing.Size(295, 22);
            this.menuBoundObjectList.Text = "Bound Object List - Contacts";
            this.menuBoundObjectList.Click += new System.EventHandler(this.menuBoundContactList_Click);
            // 
            // menuUnboundObjectList
            // 
            this.menuUnboundObjectList.Name = "menuUnboundObjectList";
            this.menuUnboundObjectList.Size = new System.Drawing.Size(295, 22);
            this.menuUnboundObjectList.Text = "Unbound Object List - Contacts";
            this.menuUnboundObjectList.Click += new System.EventHandler(this.menuUnboundContactList_Click);
            // 
            // menuBoundDatasetQuarterly
            // 
            this.menuBoundDatasetQuarterly.Name = "menuBoundDatasetQuarterly";
            this.menuBoundDatasetQuarterly.Size = new System.Drawing.Size(295, 22);
            this.menuBoundDatasetQuarterly.Text = "Bound Dataset - Quarterly orders";
            this.menuBoundDatasetQuarterly.Click += new System.EventHandler(this.menuBoundDatasetQuarterly_Click);
            // 
            // menuBoundDatasetSales
            // 
            this.menuBoundDatasetSales.Name = "menuBoundDatasetSales";
            this.menuBoundDatasetSales.Size = new System.Drawing.Size(295, 22);
            this.menuBoundDatasetSales.Text = "Bound Dataset - Sales by category";
            this.menuBoundDatasetSales.Click += new System.EventHandler(this.menuBoundDatasetSales_Click);
            // 
            // menuBoundDatasetInvoices
            // 
            this.menuBoundDatasetInvoices.Name = "menuBoundDatasetInvoices";
            this.menuBoundDatasetInvoices.Size = new System.Drawing.Size(295, 22);
            this.menuBoundDatasetInvoices.Text = "Bound Dataset - Invoices ( > 2000 entries!)";
            this.menuBoundDatasetInvoices.Click += new System.EventHandler(this.menuBoundDatasetInvoices_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCollapseAllGroups,
            this.menuExpandAllGroups,
            this.menuClearAllGroups});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // menuCollapseAllGroups
            // 
            this.menuCollapseAllGroups.Name = "menuCollapseAllGroups";
            this.menuCollapseAllGroups.Size = new System.Drawing.Size(176, 22);
            this.menuCollapseAllGroups.Text = "Collapse All Groups";
            this.menuCollapseAllGroups.Click += new System.EventHandler(this.menuCollapseAllGroups_Click);
            // 
            // menuExpandAllGroups
            // 
            this.menuExpandAllGroups.Name = "menuExpandAllGroups";
            this.menuExpandAllGroups.Size = new System.Drawing.Size(176, 22);
            this.menuExpandAllGroups.Text = "Expand All Groups";
            this.menuExpandAllGroups.Click += new System.EventHandler(this.menuExpandAllGroups_Click);
            // 
            // menuClearAllGroups
            // 
            this.menuClearAllGroups.Name = "menuClearAllGroups";
            this.menuClearAllGroups.Size = new System.Drawing.Size(176, 22);
            this.menuClearAllGroups.Text = "Clear All Groups";
            this.menuClearAllGroups.Click += new System.EventHandler(this.menuClearAllGroups_Click);
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSkinDefault,
            this.menuSkinOutlook});
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.viewToolStripMenuItem1.Text = "Skins";
            // 
            // menuSkinDefault
            // 
            this.menuSkinDefault.Name = "menuSkinDefault";
            this.menuSkinDefault.Size = new System.Drawing.Size(144, 22);
            this.menuSkinDefault.Text = "Default Skin";
            this.menuSkinDefault.Click += new System.EventHandler(this.menuSkinDefault_Click);
            // 
            // menuSkinOutlook
            // 
            this.menuSkinOutlook.Name = "menuSkinOutlook";
            this.menuSkinOutlook.Size = new System.Drawing.Size(144, 22);
            this.menuSkinOutlook.Text = "Outlook Skin";
            this.menuSkinOutlook.Click += new System.EventHandler(this.menuSkinOutlook_Click);
            // 
            // outlookGrid1
            // 
            this.outlookGrid1.AllowUserToOrderColumns = true;
            this.outlookGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.outlookGrid1.CollapseIcon = ((System.Drawing.Image)(resources.GetObject("outlookGrid1.CollapseIcon")));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.outlookGrid1.DefaultCellStyle = dataGridViewCellStyle1;
            this.outlookGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outlookGrid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.outlookGrid1.ExpandIcon = ((System.Drawing.Image)(resources.GetObject("outlookGrid1.ExpandIcon")));
            this.outlookGrid1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.outlookGrid1.Location = new System.Drawing.Point(0, 24);
            this.outlookGrid1.Name = "outlookGrid1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.outlookGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.outlookGrid1.Size = new System.Drawing.Size(535, 293);
            this.outlookGrid1.TabIndex = 0;
            this.outlookGrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.outlookGrid1_CellClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 339);
            this.Controls.Add(this.outlookGrid1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "OutlookGrid Demo v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outlookGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OutlookStyleControls.OutlookGrid outlookGrid1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuBoundObjectList;
        private System.Windows.Forms.ToolStripMenuItem menuUnboundObjectList;
        private System.Windows.Forms.ToolStripMenuItem menuBoundDatasetQuarterly;
        private System.Windows.Forms.ToolStripMenuItem menuBoundDatasetSales;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuCollapseAllGroups;
        private System.Windows.Forms.ToolStripMenuItem menuExpandAllGroups;
        private System.Windows.Forms.ToolStripMenuItem menuClearAllGroups;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuSkinDefault;
        private System.Windows.Forms.ToolStripMenuItem menuSkinOutlook;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem menuBoundDatasetInvoices;
    }
}

