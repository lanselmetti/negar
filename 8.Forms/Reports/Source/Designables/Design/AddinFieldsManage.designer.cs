
namespace Sepehr.Forms.Reports.Designables.Design
{
    partial class frmAddinFieldsManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddinFieldsManage));
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblParam = new DevComponents.DotNetBar.LabelX();
            this.cBoxFields = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.txtResult = new Sepehr.Forms.Reports.Designables.Design.NegarSyntaxHighlighter();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCheck = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblName.Location = new System.Drawing.Point(515, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(36, 16);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "عنوان:";
            this.lblName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Location = new System.Drawing.Point(12, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(497, 21);
            this.txtName.TabIndex = 0;
            this.txtName.Enter += new System.EventHandler(this.FarsiTextBoxes_Enter);
            // 
            // lblParam
            // 
            this.lblParam.AutoSize = true;
            this.lblParam.BackColor = System.Drawing.Color.Transparent;
            this.lblParam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblParam.ForeColor = System.Drawing.Color.Green;
            this.lblParam.Location = new System.Drawing.Point(500, 45);
            this.lblParam.Name = "lblParam";
            this.lblParam.Size = new System.Drawing.Size(51, 16);
            this.lblParam.TabIndex = 2;
            this.lblParam.Text = "پارامترها:";
            this.lblParam.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cBoxFields
            // 
            this.cBoxFields.DisplayMember = "Text";
            this.cBoxFields.DropDownHeight = 100;
            this.cBoxFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxFields.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cBoxFields.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxFields.IntegralHeight = false;
            this.cBoxFields.ItemHeight = 13;
            this.cBoxFields.Location = new System.Drawing.Point(94, 43);
            this.cBoxFields.Name = "cBoxFields";
            this.cBoxFields.Size = new System.Drawing.Size(400, 21);
            this.cBoxFields.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnAdd.Image = global::Sepehr.Forms.Reports.Properties.Resources.AddMed;
            this.btnAdd.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAdd.Location = new System.Drawing.Point(12, 39);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 29);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "افزودن";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtResult.Location = new System.Drawing.Point(12, 74);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(539, 93);
            this.txtResult.TabIndex = 5;
            this.txtResult.Text = "";
            this.txtResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormulas_KeyDown);
            this.txtResult.Enter += new System.EventHandler(this.FarsiTextBoxes_Enter);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Forms.Reports.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(456, 173);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            // 
            // btnCheck
            // 
            this.btnCheck.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCheck.Image = global::Sepehr.Forms.Reports.Properties.Resources.SelectAll;
            this.btnCheck.Location = new System.Drawing.Point(349, 173);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(101, 57);
            this.btnCheck.TabIndex = 8;
            this.btnCheck.Text = "بررسی درستی";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Sepehr.Forms.Reports.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(113, 173);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 57);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "خروج\r\n(Esc)";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSave.Image = global::Sepehr.Forms.Reports.Properties.Resources.Accept;
            this.btnSave.Location = new System.Drawing.Point(12, 173);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSave.Size = new System.Drawing.Size(95, 57);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "ثبت\r\n(F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.txtName);
            this.panelEx1.Controls.Add(this.lblName);
            this.panelEx1.Controls.Add(this.btnSave);
            this.panelEx1.Controls.Add(this.btnClose);
            this.panelEx1.Controls.Add(this.lblParam);
            this.panelEx1.Controls.Add(this.btnCheck);
            this.panelEx1.Controls.Add(this.cBoxFields);
            this.panelEx1.Controls.Add(this.btnHelp);
            this.panelEx1.Controls.Add(this.btnAdd);
            this.panelEx1.Controls.Add(this.txtResult);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(564, 243);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // frmAddinFieldsManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(564, 243);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddinFieldsManage";
            this.Opacity = 0.01;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش ها - گزارش های قابل طراحی - فرم  مدیریت ستون اطلاعاتی اختصاصی";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx cBoxFields;
        private DevComponents.DotNetBar.ButtonX btnCheck;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private NegarSyntaxHighlighter txtResult;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.LabelX lblParam;
        private DevComponents.DotNetBar.PanelEx panelEx1;
    }
}