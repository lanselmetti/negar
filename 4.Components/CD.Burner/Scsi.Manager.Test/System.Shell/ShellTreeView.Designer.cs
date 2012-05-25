namespace System.Shell
{
	public partial class ShellTreeView
	{
		private System.Windows.Forms.ImageList imgListSmall;
		private System.ComponentModel.IContainer components;
		private ShellTreeView.MyTreeView tvFolders;
		private System.Windows.Forms.ContextMenu contextMenu;
		private System.Windows.Forms.MenuItem miRefresh;

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.MenuItem miSep1;
			this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
			this.tvFolders = new System.Shell.ShellTreeView.MyTreeView();
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this.miRefresh = new System.Windows.Forms.MenuItem();
			miSep1 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// imgListSmall
			// 
			this.imgListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imgListSmall.ImageSize = new System.Drawing.Size(16, 16);
			this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tvFolders
			// 
			this.tvFolders.ContextMenu = this.contextMenu;
			this.tvFolders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvFolders.HideSelection = false;
			this.tvFolders.HotTracking = true;
			this.tvFolders.ImageIndex = 0;
			this.tvFolders.ImageList = this.imgListSmall;
			this.tvFolders.Location = new System.Drawing.Point(0, 0);
			this.tvFolders.Name = "tvFolders";
			this.tvFolders.SelectedImageIndex = 0;
			this.tvFolders.Size = new System.Drawing.Size(150, 150);
			this.tvFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvFolders_BeforeExpand);
			this.tvFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolders_AfterSelect);
			this.tvFolders.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvFolders_BeforeSelect);
			this.tvFolders.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(tvFolders_ItemDrag);
			// 
			// contextMenu
			// 
			this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miRefresh,
            miSep1});
			this.contextMenu.Popup += new System.EventHandler(this.contextMenu_Popup);
			// 
			// miRefresh
			// 
			this.miRefresh.Click += new EventHandler(miRefresh_Click);
			this.miRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.miRefresh.Text = "&Refresh";
			// 
			// miSep1
			// 
			miSep1.Text = "-";
			// 
			// ShellTreeView
			// 
			this.Controls.Add(this.tvFolders);
			this.Name = "ShellTreeView";
			this.TabStop = false;
			this.ResumeLayout(false);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.DisposeChildren(this.tvFolders.Nodes[0]);
			}
			base.Dispose(disposing);
		}
	}
}