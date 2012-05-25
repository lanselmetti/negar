namespace Sepehr.Settings.Documents
{
    partial class frmDocTemplates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocTemplates));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnPasteRootAll = new DevComponents.DotNetBar.ButtonX();
            this.btnAddNewRootGroup = new DevComponents.DotNetBar.ButtonX();
            this.btnPasteRoot = new DevComponents.DotNetBar.ButtonX();
            this.btnAddNewRootTemplate = new DevComponents.DotNetBar.ButtonX();
            this.cmsACL = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsACLManage = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewGroup = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewTemplate = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnExport = new DevComponents.DotNetBar.ButtonItem();
            this.btnRemove = new DevComponents.DotNetBar.ButtonItem();
            this.btnExpand = new DevComponents.DotNetBar.ButtonItem();
            this.btnColapse = new DevComponents.DotNetBar.ButtonItem();
            this.btnCopy = new DevComponents.DotNetBar.ButtonItem();
            this.btnPaste = new DevComponents.DotNetBar.ButtonItem();
            this.btnPasteAll = new DevComponents.DotNetBar.ButtonItem();
            this.TreeViewTemplates = new System.Windows.Forms.TreeView();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsACL)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.btnPasteRootAll);
            this.FormPanel.Controls.Add(this.btnAddNewRootGroup);
            this.FormPanel.Controls.Add(this.btnPasteRoot);
            this.FormPanel.Controls.Add(this.btnAddNewRootTemplate);
            this.FormPanel.Controls.Add(this.cmsACL);
            this.FormPanel.Controls.Add(this.TreeViewTemplates);
            this.FormPanel.Controls.Add(this.btnClose);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(784, 564);
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
            // btnPasteRootAll
            // 
            this.btnPasteRootAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPasteRootAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPasteRootAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPasteRootAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPasteRootAll.ForeColor = System.Drawing.Color.Green;
            this.btnPasteRootAll.Image = global::Sepehr.Settings.Documents.Properties.Resources.Paste;
            this.btnPasteRootAll.Location = new System.Drawing.Point(273, 495);
            this.btnPasteRootAll.Name = "btnPasteRootAll";
            this.btnPasteRootAll.Size = new System.Drawing.Size(95, 57);
            this.btnPasteRootAll.SubItemsExpandWidth = 15;
            this.btnPasteRootAll.TabIndex = 4;
            this.btnPasteRootAll.TabStop = false;
            this.btnPasteRootAll.Text = "چسباندن همه\r\nدر ریشه";
            this.btnPasteRootAll.Click += new System.EventHandler(this.btnPasteRootAll_Click);
            // 
            // btnAddNewRootGroup
            // 
            this.btnAddNewRootGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNewRootGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewRootGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnAddNewRootGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddNewRootGroup.Image = global::Sepehr.Settings.Documents.Properties.Resources.AddMed;
            this.btnAddNewRootGroup.Location = new System.Drawing.Point(576, 495);
            this.btnAddNewRootGroup.Name = "btnAddNewRootGroup";
            this.btnAddNewRootGroup.Size = new System.Drawing.Size(95, 57);
            this.btnAddNewRootGroup.SubItemsExpandWidth = 15;
            this.btnAddNewRootGroup.TabIndex = 3;
            this.btnAddNewRootGroup.TabStop = false;
            this.btnAddNewRootGroup.Text = "افزودن گروه ریشه";
            this.btnAddNewRootGroup.Click += new System.EventHandler(this.btnAddNewRootGroup_Click);
            // 
            // btnPasteRoot
            // 
            this.btnPasteRoot.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPasteRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPasteRoot.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPasteRoot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPasteRoot.ForeColor = System.Drawing.Color.Green;
            this.btnPasteRoot.Image = global::Sepehr.Settings.Documents.Properties.Resources.Paste;
            this.btnPasteRoot.Location = new System.Drawing.Point(374, 495);
            this.btnPasteRoot.Name = "btnPasteRoot";
            this.btnPasteRoot.Size = new System.Drawing.Size(95, 57);
            this.btnPasteRoot.SubItemsExpandWidth = 15;
            this.btnPasteRoot.TabIndex = 4;
            this.btnPasteRoot.TabStop = false;
            this.btnPasteRoot.Text = "چسباندن\r\nدر ریشه";
            this.btnPasteRoot.Click += new System.EventHandler(this.btnPasteRoot_Click);
            // 
            // btnAddNewRootTemplate
            // 
            this.btnAddNewRootTemplate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNewRootTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewRootTemplate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddNewRootTemplate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddNewRootTemplate.ForeColor = System.Drawing.Color.Crimson;
            this.btnAddNewRootTemplate.Image = global::Sepehr.Settings.Documents.Properties.Resources.DocumentAdd;
            this.btnAddNewRootTemplate.Location = new System.Drawing.Point(475, 495);
            this.btnAddNewRootTemplate.Name = "btnAddNewRootTemplate";
            this.btnAddNewRootTemplate.Size = new System.Drawing.Size(95, 57);
            this.btnAddNewRootTemplate.SubItemsExpandWidth = 15;
            this.btnAddNewRootTemplate.TabIndex = 4;
            this.btnAddNewRootTemplate.TabStop = false;
            this.btnAddNewRootTemplate.Text = "افزودن\r\nقالب\r\nریشه";
            this.btnAddNewRootTemplate.Click += new System.EventHandler(this.btnAddNewRootTemplate_Click);
            // 
            // cmsACL
            // 
            this.cmsACL.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.cmsACL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsACL.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsACLManage});
            this.cmsACL.Location = new System.Drawing.Point(113, 495);
            this.cmsACL.Name = "cmsACL";
            this.cmsACL.Size = new System.Drawing.Size(91, 25);
            this.cmsACL.Stretch = true;
            this.cmsACL.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsACL.TabIndex = 78;
            this.cmsACL.TabStop = false;
            // 
            // cmsACLManage
            // 
            this.cmsACLManage.AutoExpandOnClick = true;
            this.cmsACLManage.FontBold = true;
            this.cmsACLManage.ImagePaddingHorizontal = 8;
            this.cmsACLManage.Name = "cmsACLManage";
            this.cmsACLManage.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNewGroup,
            this.btnNewTemplate,
            this.btnEdit,
            this.btnExport,
            this.btnRemove,
            this.btnExpand,
            this.btnColapse,
            this.btnCopy,
            this.btnPaste,
            this.btnPasteAll});
            this.cmsACLManage.Text = "منوی درخت";
            // 
            // btnNewGroup
            // 
            this.btnNewGroup.ImagePaddingHorizontal = 8;
            this.btnNewGroup.Name = "btnNewGroup";
            this.btnNewGroup.Text = "<b>گروه جدید</b>\r\n<div></div>\r\n<font color=\"#000000\">تعریف گروه جدید زیر گروه جار" +
                "ی.</font>";
            this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);
            // 
            // btnNewTemplate
            // 
            this.btnNewTemplate.ImagePaddingHorizontal = 8;
            this.btnNewTemplate.Name = "btnNewTemplate";
            this.btnNewTemplate.Text = "<b>قالب جدید</b>\r\n<div></div>\r\n<font color=\"#000000\">تعریف قالب جدید زیر گروه جار" +
                "ی.</font>";
            this.btnNewTemplate.Click += new System.EventHandler(this.btnNewTemplate_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImagePaddingHorizontal = 8;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Text = "<b>ویرایش</b>\r\n<div></div>\r\n<font color=\"#000000\">ویرایش اطلاعات آیتم انتخاب شده." +
                "</font>";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnExport
            // 
            this.btnExport.ImagePaddingHorizontal = 8;
            this.btnExport.Name = "btnExport";
            this.btnExport.Text = "<b>ارسال قالب به فایل</b>\r\n<div></div>\r\n<font color=\"#000000\">ذخیره قالب به صورت " +
                "فایل.</font>";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BeginGroup = true;
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.ImagePaddingHorizontal = 8;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Text = "<b>حذف</b>\r\n<div></div>\r\n<font color=\"#000000\">حذف این آیتم و زیرمجموعه های آن.</" +
                "font>";
            this.btnRemove.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.BeginGroup = true;
            this.btnExpand.ForeColor = System.Drawing.Color.Green;
            this.btnExpand.ImagePaddingHorizontal = 8;
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Text = "<b>باز كردن</b>\r\n<div></div>\r\n<font color=\"#000000\">باز كردن زیر شاخه ها.</font>";
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnColapse
            // 
            this.btnColapse.ForeColor = System.Drawing.Color.Green;
            this.btnColapse.ImagePaddingHorizontal = 8;
            this.btnColapse.Name = "btnColapse";
            this.btnColapse.Text = "<b>بستن</b>\r\n<div></div>\r\n<font color=\"#000000\">بستن زیر شاخه ها.</font>";
            this.btnColapse.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BeginGroup = true;
            this.btnCopy.ForeColor = System.Drawing.Color.Teal;
            this.btnCopy.ImagePaddingHorizontal = 8;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Text = "<b>كپی برداری</b>\r\n<div></div>\r\n<font color=\"#000000\">كپی برداری از مورد انتخاب ش" +
                "ده.</font>";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.ForeColor = System.Drawing.Color.Teal;
            this.btnPaste.ImagePaddingHorizontal = 8;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Text = "<b>چسباندن</b>\r\n<div></div>\r\n<font color=\"#000000\">چسباندن زیر این آیتم.</font>";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnPasteAll
            // 
            this.btnPasteAll.ForeColor = System.Drawing.Color.Teal;
            this.btnPasteAll.ImagePaddingHorizontal = 8;
            this.btnPasteAll.Name = "btnPasteAll";
            this.btnPasteAll.Text = "<b>چسباندن با زیر شاخه ها</b>\r\n<div></div>\r\n<font color=\"#000000\">چسباندن با تمام" +
                " زیر شاخه ها.</font>";
            this.btnPasteAll.Click += new System.EventHandler(this.btnPasteAll_Click);
            // 
            // TreeViewTemplates
            // 
            this.TreeViewTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeViewTemplates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.TreeViewTemplates.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TreeViewTemplates.ForeColor = System.Drawing.Color.MidnightBlue;
            this.TreeViewTemplates.HotTracking = true;
            this.TreeViewTemplates.ItemHeight = 25;
            this.TreeViewTemplates.Location = new System.Drawing.Point(12, 12);
            this.TreeViewTemplates.Name = "TreeViewTemplates";
            this.TreeViewTemplates.RightToLeftLayout = true;
            this.TreeViewTemplates.ShowNodeToolTips = true;
            this.TreeViewTemplates.Size = new System.Drawing.Size(760, 477);
            this.TreeViewTemplates.TabIndex = 0;
            this.TreeViewTemplates.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewTemplates_NodeMouseDoubleClick);
            this.TreeViewTemplates.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewTemp_NodeMouseClick);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Sepehr.Settings.Documents.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 495);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 57);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج\r\n(Esc)";
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Documents.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(677, 495);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmDocTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmDocTemplates";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات مدارك - قالب های مدرك - مدیریت قالب ها";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmsACL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ContextMenuBar cmsACL;
        private DevComponents.DotNetBar.ButtonItem cmsACLManage;
        private DevComponents.DotNetBar.ButtonItem btnNewGroup;
        private DevComponents.DotNetBar.ButtonItem btnNewTemplate;
        private DevComponents.DotNetBar.ButtonItem btnRemove;
        private System.Windows.Forms.TreeView TreeViewTemplates;
        private DevComponents.DotNetBar.ButtonX btnAddNewRootTemplate;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonX btnAddNewRootGroup;
        private DevComponents.DotNetBar.ButtonItem btnExpand;
        private DevComponents.DotNetBar.ButtonItem btnColapse;
        private DevComponents.DotNetBar.ButtonItem btnExport;
        private System.Windows.Forms.SaveFileDialog FormSaveFileDialog;
        private DevComponents.DotNetBar.ButtonItem btnPaste;
        private DevComponents.DotNetBar.ButtonItem btnCopy;
        private DevComponents.DotNetBar.ButtonItem btnPasteAll;
        private DevComponents.DotNetBar.ButtonX btnPasteRoot;
        private DevComponents.DotNetBar.ButtonX btnPasteRootAll;
    }
}