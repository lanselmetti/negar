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
            this.button1 = new System.Windows.Forms.Button();
            this.cboPortName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageRefrence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageRecipient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeliverTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReferrenceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "اتصال به پورت";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboPortName
            // 
            this.cboPortName.FormattingEnabled = true;
            this.cboPortName.Location = new System.Drawing.Point(6, 20);
            this.cboPortName.Name = "cboPortName";
            this.cboPortName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboPortName.Size = new System.Drawing.Size(101, 21);
            this.cboPortName.TabIndex = 8;
            this.cboPortName.Text = "COM1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cboPortName);
            this.groupBox1.Location = new System.Drawing.Point(669, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 74);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اتصال";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.txtNumber);
            this.groupBox2.Controls.Add(this.txtText);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 362);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "پیام ها";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PaleGreen;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColKey,
            this.MessageRefrence,
            this.MessageRecipient,
            this.ColStatus,
            this.ColDeliverTime,
            this.ColReferrenceCode});
            this.dataGridView1.Location = new System.Drawing.Point(14, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(756, 167);
            this.dataGridView1.TabIndex = 4;
            // 
            // ColKey
            // 
            this.ColKey.HeaderText = "كلید ارسال";
            this.ColKey.Name = "ColKey";
            this.ColKey.Width = 88;
            // 
            // MessageRefrence
            // 
            this.MessageRefrence.HeaderText = "تلفن";
            this.MessageRefrence.Name = "MessageRefrence";
            this.MessageRefrence.Width = 55;
            // 
            // MessageRecipient
            // 
            this.MessageRecipient.HeaderText = "متن پیام";
            this.MessageRecipient.Name = "MessageRecipient";
            this.MessageRecipient.Width = 74;
            // 
            // ColStatus
            // 
            this.ColStatus.HeaderText = "وضعیت";
            this.ColStatus.Name = "ColStatus";
            this.ColStatus.Width = 69;
            // 
            // ColDeliverTime
            // 
            this.ColDeliverTime.HeaderText = "زمان دریافت";
            this.ColDeliverTime.Name = "ColDeliverTime";
            this.ColDeliverTime.Width = 96;
            // 
            // ColReferrenceCode
            // 
            this.ColReferrenceCode.HeaderText = "مرجع";
            this.ColReferrenceCode.Name = "ColReferrenceCode";
            this.ColReferrenceCode.Width = 60;
            // 
            // txtNumber
            // 
            this.txtNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtNumber.Location = new System.Drawing.Point(535, 20);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNumber.Size = new System.Drawing.Size(128, 21);
            this.txtNumber.TabIndex = 3;
            this.txtNumber.Text = "+989124389435";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(14, 20);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtText.Size = new System.Drawing.Size(515, 74);
            this.txtText.TabIndex = 2;
            this.txtText.Text = "متن پیام.";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(14, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(756, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "ارسال پیام ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(14, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(756, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "ارسال پیام جمعی";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(14, 154);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(756, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "بازخوانی";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 5000);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم تست ارسال SMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboPortName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageRefrence;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageRecipient;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeliverTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReferrenceCode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}

