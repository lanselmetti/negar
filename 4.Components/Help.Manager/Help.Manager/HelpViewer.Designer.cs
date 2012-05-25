namespace Negar
{
    partial class HelpViewer
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
            this.HelpBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // HelpBrowser
            // 
            this.HelpBrowser.AllowWebBrowserDrop = false;
            this.HelpBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelpBrowser.IsWebBrowserContextMenuEnabled = false;
            this.HelpBrowser.Location = new System.Drawing.Point(0, 0);
            this.HelpBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.HelpBrowser.Name = "HelpBrowser";
            this.HelpBrowser.ScriptErrorsSuppressed = true;
            this.HelpBrowser.Size = new System.Drawing.Size(784, 564);
            this.HelpBrowser.TabIndex = 0;
            // 
            // HelpViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.HelpBrowser);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "HelpViewer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شركت رایان پرتونگار - راهنمای كاربری";
            this.Shown += new System.EventHandler(this.HelpViewer_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser HelpBrowser;
    }
}