namespace Negar.Security.Classes
{
    partial class ChangeUserPassword
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUserPassword));
            this.txtPass2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPass1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl2 = new DevComponents.DotNetBar.LabelX();
            this.lbl1 = new DevComponents.DotNetBar.LabelX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtOldPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblOldPass = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPass2
            // 
            this.txtPass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPass2.Border.Class = "TextBoxBorder";
            this.txtPass2.ForeColor = System.Drawing.Color.Black;
            this.txtPass2.Location = new System.Drawing.Point(12, 142);
            this.txtPass2.MaxLength = 50;
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPass2.Size = new System.Drawing.Size(296, 21);
            this.txtPass2.TabIndex = 3;
            this.txtPass2.UseSystemPasswordChar = true;
            this.txtPass2.Validating += new System.ComponentModel.CancelEventHandler(this.txtPass2_Validating);
            this.txtPass2.Enter += new System.EventHandler(this.Controls_Enter);
            // 
            // txtPass1
            // 
            this.txtPass1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPass1.Border.Class = "TextBoxBorder";
            this.txtPass1.ForeColor = System.Drawing.Color.Black;
            this.txtPass1.Location = new System.Drawing.Point(12, 97);
            this.txtPass1.MaxLength = 50;
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPass1.Size = new System.Drawing.Size(296, 21);
            this.txtPass1.TabIndex = 0;
            this.txtPass1.UseSystemPasswordChar = true;
            this.txtPass1.Enter += new System.EventHandler(this.Controls_Enter);
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl2.Location = new System.Drawing.Point(195, 122);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(113, 16);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "تكرار كلمه عبور جدید:";
            this.lbl2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl1.Location = new System.Drawing.Point(222, 77);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(86, 16);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "كلمه عبور جدید:";
            this.lbl1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Negar.Security.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 171);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تاييد\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Negar.Security.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // FormErrorProvider
            // 
            this.FormErrorProvider.ContainerControl = this;
            // 
            // txtOldPass
            // 
            this.txtOldPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldPass.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtOldPass.Border.Class = "TextBoxBorder";
            this.txtOldPass.ForeColor = System.Drawing.Color.Black;
            this.txtOldPass.Location = new System.Drawing.Point(12, 52);
            this.txtOldPass.MaxLength = 50;
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOldPass.Size = new System.Drawing.Size(296, 21);
            this.txtOldPass.TabIndex = 0;
            this.txtOldPass.UseSystemPasswordChar = true;
            this.txtOldPass.Enter += new System.EventHandler(this.Controls_Enter);
            // 
            // lblOldPass
            // 
            this.lblOldPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOldPass.AutoSize = true;
            this.lblOldPass.BackColor = System.Drawing.Color.Transparent;
            this.lblOldPass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblOldPass.ForeColor = System.Drawing.Color.Red;
            this.lblOldPass.Location = new System.Drawing.Point(220, 32);
            this.lblOldPass.Name = "lblOldPass";
            this.lblOldPass.Size = new System.Drawing.Size(88, 16);
            this.lblOldPass.TabIndex = 1;
            this.lblOldPass.Text = "كلمه عبور قبلی:";
            this.lblOldPass.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ChangeUserPassword
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.CancelButton = this.btnCancel;
            this.CaptionColor = System.Drawing.Color.Navy;
            this.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CaptionIcon = ((System.Drawing.Icon)(resources.GetObject("$this.CaptionIcon")));
            this.CaptionText = "تغییر كلمه عبور";
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblOldPass);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtPass1);
            this.Controls.Add(this.txtPass2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(55)))), ((int)(((byte)(114)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ChangeUserPassword";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style = DevComponents.DotNetBar.eBallonStyle.Office2007Alert;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        internal DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.LabelX lbl2;
        private DevComponents.DotNetBar.LabelX lbl1;
        public DevComponents.DotNetBar.Controls.TextBoxX txtPass2;
        public DevComponents.DotNetBar.Controls.TextBoxX txtPass1;
        private System.Windows.Forms.ErrorProvider FormErrorProvider;
        private DevComponents.DotNetBar.LabelX lblOldPass;
        public DevComponents.DotNetBar.Controls.TextBoxX txtOldPass;
    }
}