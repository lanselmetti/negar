namespace Test_Project
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
            this.Account = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Account
            // 
            this.Account.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Account.Font = new System.Drawing.Font("B Titr", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Account.Location = new System.Drawing.Point(234, 51);
            this.Account.Margin = new System.Windows.Forms.Padding(4, 9, 4, 9);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(201, 76);
            this.Account.TabIndex = 1;
            this.Account.Text = "نمایش حساب بر اساس آخرین مراجعه بیمار";
            this.Account.UseVisualStyleBackColor = false;
            this.Account.Click += new System.EventHandler(this.Account_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "شماره بیمار:";
            // 
            // txt1
            // 
            this.txt1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txt1.Location = new System.Drawing.Point(234, 16);
            this.txt1.Margin = new System.Windows.Forms.Padding(4, 9, 4, 9);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(85, 24);
            this.txt1.TabIndex = 3;
            this.txt1.Text = "108986";
            this.txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(113, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "شماره مراجعه:";
            // 
            // txt2
            // 
            this.txt2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txt2.Location = new System.Drawing.Point(18, 16);
            this.txt2.Margin = new System.Windows.Forms.Padding(4, 9, 4, 9);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(85, 24);
            this.txt2.TabIndex = 2;
            this.txt2.Text = "108986";
            this.txt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("B Titr", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.button1.Location = new System.Drawing.Point(18, 51);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 9, 4, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 76);
            this.button1.TabIndex = 0;
            this.button1.Text = "نمایش حساب بر اساس كلید  مراجعه";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 139);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.Account);
            this.Font = new System.Drawing.Font("B Koodak", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ForeColor = System.Drawing.Color.Chocolate;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 9, 4, 9);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم آزمایش حساب مراجعات تصویربرداری";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Account;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Button button1;
    }
}

