namespace Negar.Security.ACL
{
    partial class frmManageAccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageAccess));
            this.panel4 = new DevComponents.DotNetBar.PanelEx();
            this.lstGroups = new DevComponents.DotNetBar.ItemPanel();
            this.lstUsers = new DevComponents.DotNetBar.ItemPanel();
            this.lblGroups = new DevComponents.DotNetBar.LabelX();
            this.lblUsers = new DevComponents.DotNetBar.LabelX();
            this.panel5 = new DevComponents.DotNetBar.PanelEx();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.panel3 = new DevComponents.DotNetBar.PanelEx();
            this.lblAccess = new DevComponents.DotNetBar.LabelX();
            this.cBoxIsPremiered = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDeny = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxAllow = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panel2 = new DevComponents.DotNetBar.PanelEx();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.lbl3 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new DevComponents.DotNetBar.PanelEx();
            this.lblAccessPath = new DevComponents.DotNetBar.LabelX();
            this.lblAccessName = new DevComponents.DotNetBar.LabelX();
            this.lbl1 = new DevComponents.DotNetBar.LabelX();
            this.lbl2 = new DevComponents.DotNetBar.LabelX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panel4.Controls.Add(this.lstGroups);
            this.panel4.Controls.Add(this.lstUsers);
            this.panel4.Controls.Add(this.lblGroups);
            this.panel4.Controls.Add(this.lblUsers);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 157);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(421, 242);
            this.panel4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel4.Style.GradientAngle = 90;
            this.panel4.TabIndex = 3;
            // 
            // lstGroups
            // 
            this.lstGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstGroups.AutoScroll = true;
            this.lstGroups.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lstGroups.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.lstGroups.BackgroundStyle.BackColorGradientAngle = 90;
            this.lstGroups.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.lstGroups.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstGroups.BackgroundStyle.BorderBottomWidth = 1;
            this.lstGroups.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.lstGroups.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstGroups.BackgroundStyle.BorderLeftWidth = 1;
            this.lstGroups.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstGroups.BackgroundStyle.BorderRightWidth = 1;
            this.lstGroups.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstGroups.BackgroundStyle.BorderTopWidth = 1;
            this.lstGroups.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstGroups.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.lstGroups.Location = new System.Drawing.Point(13, 21);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(198, 218);
            this.lstGroups.TabIndex = 3;
            this.lstGroups.Text = "itemPanel1";
            // 
            // lstUsers
            // 
            this.lstUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstUsers.AutoScroll = true;
            this.lstUsers.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lstUsers.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.lstUsers.BackgroundStyle.BackColorGradientAngle = 90;
            this.lstUsers.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.lstUsers.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstUsers.BackgroundStyle.BorderBottomWidth = 1;
            this.lstUsers.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.lstUsers.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstUsers.BackgroundStyle.BorderLeftWidth = 1;
            this.lstUsers.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstUsers.BackgroundStyle.BorderRightWidth = 1;
            this.lstUsers.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstUsers.BackgroundStyle.BorderTopWidth = 1;
            this.lstUsers.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstUsers.ItemSpacing = 2;
            this.lstUsers.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.lstUsers.Location = new System.Drawing.Point(217, 21);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(198, 218);
            this.lstUsers.TabIndex = 2;
            // 
            // lblGroups
            // 
            this.lblGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroups.AutoSize = true;
            this.lblGroups.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblGroups.Location = new System.Drawing.Point(162, 3);
            this.lblGroups.Name = "lblGroups";
            this.lblGroups.Size = new System.Drawing.Size(46, 16);
            this.lblGroups.TabIndex = 1;
            this.lblGroups.Text = "گروه ها:";
            this.lblGroups.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblUsers
            // 
            this.lblUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUsers.Location = new System.Drawing.Point(373, 3);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(43, 16);
            this.lblUsers.TabIndex = 0;
            this.lblUsers.Text = "كاربران:";
            this.lblUsers.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // panel5
            // 
            this.panel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panel5.Controls.Add(this.btnHelp);
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Controls.Add(this.btnAccept);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 399);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(421, 75);
            this.panel5.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel5.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel5.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel5.Style.GradientAngle = 90;
            this.panel5.TabIndex = 4;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Negar.Security.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(317, 6);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Negar.Security.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(114, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Image = global::Negar.Security.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(13, 6);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تاييد\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // panel3
            // 
            this.panel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panel3.Controls.Add(this.lblAccess);
            this.panel3.Controls.Add(this.cBoxIsPremiered);
            this.panel3.Controls.Add(this.cBoxDeny);
            this.panel3.Controls.Add(this.cBoxAllow);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 130);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(421, 27);
            this.panel3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel3.Style.GradientAngle = 90;
            this.panel3.TabIndex = 2;
            // 
            // lblAccess
            // 
            this.lblAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAccess.AutoSize = true;
            this.lblAccess.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAccess.Location = new System.Drawing.Point(319, 5);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(100, 16);
            this.lblAccess.TabIndex = 3;
            this.lblAccess.Text = "وضعیت دسترسی:";
            this.lblAccess.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cBoxIsPremiered
            // 
            this.cBoxIsPremiered.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxIsPremiered.AutoSize = true;
            this.cBoxIsPremiered.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxIsPremiered.Location = new System.Drawing.Point(37, 5);
            this.cBoxIsPremiered.Name = "cBoxIsPremiered";
            this.cBoxIsPremiered.Size = new System.Drawing.Size(63, 16);
            this.cBoxIsPremiered.TabIndex = 2;
            this.cBoxIsPremiered.Text = "ارجحیت";
            this.cBoxIsPremiered.TextColor = System.Drawing.Color.Green;
            this.cBoxIsPremiered.CheckedChanged += new System.EventHandler(this.cBoxes_CheckedChanged);
            // 
            // cBoxDeny
            // 
            this.cBoxDeny.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxDeny.AutoSize = true;
            this.cBoxDeny.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxDeny.Checked = true;
            this.cBoxDeny.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxDeny.CheckValue = "Y";
            this.cBoxDeny.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxDeny.Location = new System.Drawing.Point(214, 5);
            this.cBoxDeny.Name = "cBoxDeny";
            this.cBoxDeny.Size = new System.Drawing.Size(100, 16);
            this.cBoxDeny.TabIndex = 0;
            this.cBoxDeny.Text = "فاقد دسترسی";
            this.cBoxDeny.TextColor = System.Drawing.Color.Green;
            this.cBoxDeny.CheckedChanged += new System.EventHandler(this.cBoxes_CheckedChanged);
            // 
            // cBoxAllow
            // 
            this.cBoxAllow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxAllow.AutoSize = true;
            this.cBoxAllow.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxAllow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxAllow.Location = new System.Drawing.Point(103, 5);
            this.cBoxAllow.Name = "cBoxAllow";
            this.cBoxAllow.Size = new System.Drawing.Size(106, 16);
            this.cBoxAllow.TabIndex = 1;
            this.cBoxAllow.Text = "دارای دسترسی";
            this.cBoxAllow.TextColor = System.Drawing.Color.Green;
            this.cBoxAllow.CheckedChanged += new System.EventHandler(this.cBoxes_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.lbl3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(421, 29);
            this.panel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel2.Style.GradientAngle = 90;
            this.panel2.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblName.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblName.BackgroundStyle.BorderBottomWidth = 2;
            this.lblName.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.lblName.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground2;
            this.lblName.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblName.BackgroundStyle.BorderLeftWidth = 2;
            this.lblName.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblName.BackgroundStyle.BorderRightWidth = 2;
            this.lblName.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblName.BackgroundStyle.BorderTopWidth = 1;
            this.lblName.Location = new System.Drawing.Point(10, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(309, 21);
            this.lblName.TabIndex = 1;
            // 
            // lbl3
            // 
            this.lbl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl3.Location = new System.Drawing.Point(323, 6);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(86, 16);
            this.lbl3.TabIndex = 0;
            this.lbl3.Text = "نام كاربر یا گروه:";
            this.lbl3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // panel1
            // 
            this.panel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panel1.Controls.Add(this.lblAccessPath);
            this.panel1.Controls.Add(this.lblAccessName);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 101);
            this.panel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel1.Style.GradientAngle = 90;
            this.panel1.TabIndex = 0;
            // 
            // lblAccessPath
            // 
            this.lblAccessPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAccessPath.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblAccessPath.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblAccessPath.BackgroundStyle.BorderBottomWidth = 1;
            this.lblAccessPath.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.lblAccessPath.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground2;
            this.lblAccessPath.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblAccessPath.BackgroundStyle.BorderLeftWidth = 1;
            this.lblAccessPath.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblAccessPath.BackgroundStyle.BorderRightWidth = 1;
            this.lblAccessPath.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblAccessPath.BackgroundStyle.BorderTopWidth = 1;
            this.lblAccessPath.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAccessPath.Location = new System.Drawing.Point(10, 12);
            this.lblAccessPath.Name = "lblAccessPath";
            this.lblAccessPath.Size = new System.Drawing.Size(309, 56);
            this.lblAccessPath.TabIndex = 1;
            this.lblAccessPath.WordWrap = true;
            // 
            // lblAccessName
            // 
            this.lblAccessName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAccessName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblAccessName.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblAccessName.BackgroundStyle.BorderBottomWidth = 2;
            this.lblAccessName.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.lblAccessName.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground2;
            this.lblAccessName.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblAccessName.BackgroundStyle.BorderLeftWidth = 2;
            this.lblAccessName.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblAccessName.BackgroundStyle.BorderRightWidth = 2;
            this.lblAccessName.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblAccessName.BackgroundStyle.BorderTopWidth = 1;
            this.lblAccessName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAccessName.Location = new System.Drawing.Point(10, 74);
            this.lblAccessName.Name = "lblAccessName";
            this.lblAccessName.Size = new System.Drawing.Size(309, 21);
            this.lblAccessName.TabIndex = 3;
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl1.ForeColor = System.Drawing.Color.Black;
            this.lbl1.Location = new System.Drawing.Point(325, 14);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(91, 16);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "مسیر دسترسی:";
            this.lbl1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl2.ForeColor = System.Drawing.Color.Black;
            this.lbl2.Location = new System.Drawing.Point(324, 75);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(92, 16);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "عنوان دسترسی:";
            this.lbl2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmManageAccess
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(421, 474);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageAccess";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مديريت امنيت سيستم - سطح دسترسی كاربران و گروه ها";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.PanelEx panel1;
        private DevComponents.DotNetBar.LabelX lblAccessName;
        private DevComponents.DotNetBar.LabelX lbl1;
        private DevComponents.DotNetBar.LabelX lbl2;
        private DevComponents.DotNetBar.PanelEx panel2;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.LabelX lbl3;
        private DevComponents.DotNetBar.PanelEx panel5;
        private DevComponents.DotNetBar.PanelEx panel4;
        private DevComponents.DotNetBar.ItemPanel lstGroups;
        private DevComponents.DotNetBar.ItemPanel lstUsers;
        private DevComponents.DotNetBar.LabelX lblGroups;
        private DevComponents.DotNetBar.LabelX lblUsers;
        private DevComponents.DotNetBar.PanelEx panel3;
        private DevComponents.DotNetBar.LabelX lblAccess;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxIsPremiered;
        public DevComponents.DotNetBar.LabelX lblAccessPath;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDeny;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxAllow;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
    }
}