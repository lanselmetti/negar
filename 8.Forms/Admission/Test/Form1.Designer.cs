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
            this.btnShowPatLastRef = new System.Windows.Forms.Button();
            this.txtRefID1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Referrals = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPatID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.btnShowRef = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowPatLastRef
            // 
            this.btnShowPatLastRef.Location = new System.Drawing.Point(13, 123);
            this.btnShowPatLastRef.Name = "btnShowPatLastRef";
            this.btnShowPatLastRef.Size = new System.Drawing.Size(237, 29);
            this.btnShowPatLastRef.TabIndex = 4;
            this.btnShowPatLastRef.Text = "نمایش آخرین مراجعه با كلید بیمار";
            this.btnShowPatLastRef.UseVisualStyleBackColor = true;
            this.btnShowPatLastRef.Click += new System.EventHandler(this.btnShowPatLastRef_Click);
            // 
            // txtRefID1
            // 
            this.txtRefID1.Location = new System.Drawing.Point(92, 62);
            this.txtRefID1.Name = "txtRefID1";
            this.txtRefID1.Size = new System.Drawing.Size(52, 24);
            this.txtRefID1.TabIndex = 1;
            this.txtRefID1.Text = "193099";
            this.txtRefID1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("B Zar", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(13, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 33);
            this.button2.TabIndex = 0;
            this.button2.Text = "افزودن بیمار";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.buttonAddNewPat_Click);
            // 
            // Referrals
            // 
            this.Referrals.Location = new System.Drawing.Point(13, 88);
            this.Referrals.Name = "Referrals";
            this.Referrals.Size = new System.Drawing.Size(237, 29);
            this.Referrals.TabIndex = 3;
            this.Referrals.Text = "ثبت مراجعه جدید با كلید یك بیمار";
            this.Referrals.UseVisualStyleBackColor = true;
            this.Referrals.Click += new System.EventHandler(this.buttonAddNewRefForPat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "كلید ارسالی:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPatID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Green;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 131);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "فرم بیماران";
            // 
            // txtPatID
            // 
            this.txtPatID.Location = new System.Drawing.Point(92, 60);
            this.txtPatID.Name = "txtPatID";
            this.txtPatID.Size = new System.Drawing.Size(52, 24);
            this.txtPatID.TabIndex = 1;
            this.txtPatID.Text = "1000";
            this.txtPatID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "كلید ارسالی:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 90);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(237, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "مشاهده پرونده یك بیمار";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonModifyPat_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.txtRefID1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Referrals);
            this.groupBox2.Controls.Add(this.btnShowRef);
            this.groupBox2.Controls.Add(this.btnShowPatLastRef);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(0, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 196);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "فرم مراجعات";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button5.Font = new System.Drawing.Font("B Titr", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(13, 23);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(237, 36);
            this.button5.TabIndex = 0;
            this.button5.Text = "ثبت مراجعه بیمار جدید";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnShowRef
            // 
            this.btnShowRef.Location = new System.Drawing.Point(13, 158);
            this.btnShowRef.Name = "btnShowRef";
            this.btnShowRef.Size = new System.Drawing.Size(237, 29);
            this.btnShowRef.TabIndex = 5;
            this.btnShowRef.Text = "نمایش یك مراجعه با كلید مراجعه";
            this.btnShowRef.UseVisualStyleBackColor = true;
            this.btnShowRef.Click += new System.EventHandler(this.btnShowRef_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 327);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم آزمایش مدیریت پذیرش";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowPatLastRef;
        private System.Windows.Forms.TextBox txtRefID1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Referrals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtPatID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnShowRef;
        private System.Windows.Forms.Button button5;
    }
}

