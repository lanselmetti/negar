namespace BurnApp
{
	partial class FormMdiParent
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
			System.Windows.Forms.MainMenu mainMenu;
			System.Windows.Forms.MenuItem miFile;
			System.Windows.Forms.MenuItem miHelp;
			this.miFileGC = new System.Windows.Forms.MenuItem();
			this.miFileExit = new System.Windows.Forms.MenuItem();
			this.miHelpAbout = new System.Windows.Forms.MenuItem();
			mainMenu = new System.Windows.Forms.MainMenu(this.components);
			miFile = new System.Windows.Forms.MenuItem();
			miHelp = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            miFile,
            miHelp});
			// 
			// miFile
			// 
			miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFileGC,
            this.miFileExit});
			miFile.Text = "&File";
			// 
			// miFileGC
			// 
			this.miFileGC.Text = "&Garbage Collect";
			this.miFileGC.Click += new System.EventHandler(this.miFileGC_Click);
			// 
			// miFileExit
			// 
			this.miFileExit.Text = "E&xit";
			this.miFileExit.Click += new System.EventHandler(this.miFileExit_Click);
			// 
			// miHelp
			// 
			miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miHelpAbout});
			miHelp.MergeOrder = 1;
			miHelp.Text = "&Help";
			// 
			// miHelpAbout
			// 
			this.miHelpAbout.Text = "&About";
			this.miHelpAbout.Click += new System.EventHandler(this.miHelpAbout_Click);
			// 
			// FormMdiParent
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.IsMdiContainer = true;
			this.Menu = mainMenu;
			this.Name = "FormMdiParent";
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.Text = "ISOBurn";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.ResumeLayout(false);

		}
		#endregion

		private System.Windows.Forms.MenuItem miFileGC;
		private System.Windows.Forms.MenuItem miFileExit;
		private System.Windows.Forms.MenuItem miHelpAbout;

	}
}