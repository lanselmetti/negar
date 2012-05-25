namespace WindowsFormsApplication1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.WB = new System.Windows.Forms.WebBrowser();
            this.btnRegStart = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TimerInsertData = new System.Windows.Forms.Timer(this.components);
            this.btnRetry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WB
            // 
            this.WB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WB.IsWebBrowserContextMenuEnabled = false;
            this.WB.Location = new System.Drawing.Point(0, 0);
            this.WB.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB.Name = "WB";
            this.WB.ScriptErrorsSuppressed = true;
            this.WB.Size = new System.Drawing.Size(531, 411);
            this.WB.TabIndex = 0;
            // 
            // btnRegStart
            // 
            this.btnRegStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegStart.Location = new System.Drawing.Point(537, 12);
            this.btnRegStart.Name = "btnRegStart";
            this.btnRegStart.Size = new System.Drawing.Size(75, 23);
            this.btnRegStart.TabIndex = 1;
            this.btnRegStart.Text = "ثبت نسخه";
            this.btnRegStart.UseVisualStyleBackColor = true;
            this.btnRegStart.Click += new System.EventHandler(this.btnRegStart_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(537, 70);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "تست";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(0, 412);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(624, 30);
            this.textBox1.TabIndex = 3;
            // 
            // TimerInsertData
            // 
            this.TimerInsertData.Interval = 500;
            this.TimerInsertData.Tick += new System.EventHandler(this.TimerInsertData_Tick);
            // 
            // btnRetry
            // 
            this.btnRetry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetry.Location = new System.Drawing.Point(537, 41);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(75, 23);
            this.btnRetry.TabIndex = 4;
            this.btnRetry.Text = "ثبت مجدد";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnRegStart);
            this.Controls.Add(this.WB);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم تست اولیه پروژه تاییدیه مستقیم سپهر";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser WB;
        private System.Windows.Forms.Button btnRegStart;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer TimerInsertData;
        private System.Windows.Forms.Button btnRetry;
    }
}

