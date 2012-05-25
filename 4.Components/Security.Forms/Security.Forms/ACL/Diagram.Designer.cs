namespace Negar.Security.ACL
{
    partial class frmDiagram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiagram));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblUsers = new DevComponents.DotNetBar.LabelX();
            this.cboUsers = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.TreeViewACL = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.GroupsNodeStyle = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeViewACL)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.lblUsers);
            this.FormPanel.Controls.Add(this.cboUsers);
            this.FormPanel.Controls.Add(this.TreeViewACL);
            this.FormPanel.Controls.Add(this.btnClose);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(792, 573);
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
            // lblUsers
            // 
            this.lblUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsers.AutoSize = true;
            this.lblUsers.BackColor = System.Drawing.Color.Transparent;
            this.lblUsers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUsers.Location = new System.Drawing.Point(648, 508);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(31, 16);
            this.lblUsers.TabIndex = 1;
            this.lblUsers.Text = "كاربر:";
            this.lblUsers.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboUsers
            // 
            this.cboUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUsers.DisplayMember = "Text";
            this.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsers.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboUsers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.ItemHeight = 13;
            this.cboUsers.Location = new System.Drawing.Point(483, 506);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(159, 21);
            this.cboUsers.TabIndex = 0;
            this.cboUsers.WatermarkText = "یك گروه از لیست انتخاب نمایید...";
            // 
            // TreeViewACL
            // 
            this.TreeViewACL.AllowDrop = true;
            this.TreeViewACL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeViewACL.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TreeViewACL.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.TreeViewACL.BackgroundStyle.BorderTopColor = System.Drawing.Color.CornflowerBlue;
            this.TreeViewACL.BackgroundStyle.BorderTopWidth = 1;
            this.TreeViewACL.CellLayout = DevComponents.AdvTree.eCellLayout.Horizontal;
            this.TreeViewACL.CellPartLayout = DevComponents.AdvTree.eCellPartLayout.Horizontal;
            this.TreeViewACL.DragDropEnabled = false;
            this.TreeViewACL.ExpandButtonSize = new System.Drawing.Size(0, 0);
            this.TreeViewACL.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.TreeViewACL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TreeViewACL.HotTracking = true;
            this.TreeViewACL.Location = new System.Drawing.Point(12, 12);
            this.TreeViewACL.Name = "TreeViewACL";
            this.TreeViewACL.NodesConnector = this.nodeConnector2;
            this.TreeViewACL.NodeSpacing = 10;
            this.TreeViewACL.NodeStyle = this.elementStyle2;
            this.TreeViewACL.PathSeparator = ";";
            this.TreeViewACL.Size = new System.Drawing.Size(768, 486);
            this.TreeViewACL.Styles.Add(this.GroupsNodeStyle);
            this.TreeViewACL.Styles.Add(this.elementStyle1);
            this.TreeViewACL.Styles.Add(this.elementStyle2);
            this.TreeViewACL.TabIndex = 2;
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.Color.DodgerBlue;
            // 
            // elementStyle2
            // 
            this.elementStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(213)))));
            this.elementStyle2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.elementStyle2.BackColorGradientAngle = 90;
            this.elementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderBottomWidth = 1;
            this.elementStyle2.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderLeftWidth = 1;
            this.elementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderRightWidth = 1;
            this.elementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderTopWidth = 1;
            this.elementStyle2.CornerDiameter = 4;
            this.elementStyle2.Description = "Yellow";
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.PaddingBottom = 1;
            this.elementStyle2.PaddingLeft = 1;
            this.elementStyle2.PaddingRight = 1;
            this.elementStyle2.PaddingTop = 1;
            this.elementStyle2.TextColor = System.Drawing.Color.Black;
            // 
            // GroupsNodeStyle
            // 
            this.GroupsNodeStyle.BackColor = System.Drawing.Color.Transparent;
            this.GroupsNodeStyle.BackColor2 = System.Drawing.Color.Transparent;
            this.GroupsNodeStyle.BackColorGradientAngle = 90;
            this.GroupsNodeStyle.BorderBottomWidth = 1;
            this.GroupsNodeStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GroupsNodeStyle.BorderLeftWidth = 1;
            this.GroupsNodeStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GroupsNodeStyle.BorderRightWidth = 1;
            this.GroupsNodeStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GroupsNodeStyle.BorderTopWidth = 1;
            this.GroupsNodeStyle.CornerDiameter = 2;
            this.GroupsNodeStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.GroupsNodeStyle.Font = new System.Drawing.Font("B Koodak", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.GroupsNodeStyle.Name = "GroupsNodeStyle";
            this.GroupsNodeStyle.PaddingBottom = 5;
            this.GroupsNodeStyle.PaddingLeft = 5;
            this.GroupsNodeStyle.PaddingRight = 5;
            this.GroupsNodeStyle.PaddingTop = 5;
            this.GroupsNodeStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            // 
            // elementStyle1
            // 
            this.elementStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle1.BackColorGradientAngle = 90;
            this.elementStyle1.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle1.BorderBottomWidth = 1;
            this.elementStyle1.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle1.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle1.BorderLeftWidth = 1;
            this.elementStyle1.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle1.BorderRightWidth = 1;
            this.elementStyle1.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle1.BorderTopWidth = 1;
            this.elementStyle1.CornerDiameter = 4;
            this.elementStyle1.Description = "Blue";
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.PaddingBottom = 1;
            this.elementStyle1.PaddingLeft = 1;
            this.elementStyle1.PaddingRight = 1;
            this.elementStyle1.PaddingTop = 1;
            this.elementStyle1.TextColor = System.Drawing.Color.Black;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Negar.Security.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 504);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 57);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج\r\n(Esc)";
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Negar.Security.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(685, 504);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.Color.Black;
            this.nodeConnector1.LineWidth = 6;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmDiagram";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " تنظيمات - مديريت امنيت سيستم - بررسی سطوح دسترسی كاربران";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeViewACL)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        internal DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        internal DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.AdvTree.AdvTree TreeViewACL;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle GroupsNodeStyle;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboUsers;
        private DevComponents.DotNetBar.LabelX lblUsers;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
    }
}