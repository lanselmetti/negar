namespace System.Shell
{
	public partial class ShellBrowser
	{
		private System.ComponentModel.IContainer components = null;
		private ShellTreeView shellTreeView;
		private ShellListView shellListView;
		private System.Windows.Forms.SplitContainer scMain;
		private System.Windows.Forms.ToolBar toolBar;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.ImageList imgListToolbar;
		private System.Windows.Forms.ToolBarButton tsbBack;
		private System.Windows.Forms.ToolBarButton tsbForward;
		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.TextBox txtAddressBar;
		private System.Windows.Forms.ToolBarButton tsbView;
		private System.Windows.Forms.ContextMenu cmuBack;
		private System.Windows.Forms.ContextMenu cmuForward;
		private System.Windows.Forms.ContextMenu cmuView;
		private System.Windows.Forms.MenuItem cmuViewThumbnails;
		private System.Windows.Forms.MenuItem cmuViewThumbstrips;
		private System.Windows.Forms.MenuItem cmuViewTiles;
		private System.Windows.Forms.MenuItem cmuViewLargeIcons;
		private System.Windows.Forms.MenuItem cmuViewSmallIcons;
		private System.Windows.Forms.MenuItem cmuViewList;
		private System.Windows.Forms.MenuItem cmuViewDetails;
		private System.Windows.Forms.MenuItem cmuViewContent;
		
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.scMain = new System.Windows.Forms.SplitContainer();
			this.shellTreeView = new System.Shell.ShellTreeView();
			this.shellListView = new System.Shell.ShellListView();
			this.toolBar = new System.Windows.Forms.ToolBar();
			this.tsbBack = new System.Windows.Forms.ToolBarButton();
			this.cmuBack = new System.Windows.Forms.ContextMenu();
			this.tsbForward = new System.Windows.Forms.ToolBarButton();
			this.cmuForward = new System.Windows.Forms.ContextMenu();
			this.tsbView = new System.Windows.Forms.ToolBarButton();
			this.cmuView = new System.Windows.Forms.ContextMenu();
			this.cmuViewThumbnails = new System.Windows.Forms.MenuItem();
			this.cmuViewThumbstrips = new System.Windows.Forms.MenuItem();
			this.cmuViewTiles = new System.Windows.Forms.MenuItem();
			this.cmuViewLargeIcons = new System.Windows.Forms.MenuItem();
			this.cmuViewSmallIcons = new System.Windows.Forms.MenuItem();
			this.cmuViewList = new System.Windows.Forms.MenuItem();
			this.cmuViewDetails = new System.Windows.Forms.MenuItem();
			this.cmuViewContent = new System.Windows.Forms.MenuItem();
			this.imgListToolbar = new System.Windows.Forms.ImageList(this.components);
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.txtAddressBar = new System.Windows.Forms.TextBox();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			this.tlpMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// scMain
			// 
			this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scMain.Location = new System.Drawing.Point(0, 22);
			this.scMain.Margin = new System.Windows.Forms.Padding(0);
			this.scMain.Name = "scMain";
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.shellTreeView);
			// 
			// scMain.Panel2
			// 
			this.scMain.Panel2.Controls.Add(this.shellListView);
			this.scMain.Size = new System.Drawing.Size(720, 394);
			this.scMain.SplitterDistance = 240;
			this.scMain.SplitterWidth = 2;
			this.scMain.TabIndex = 1;
			this.scMain.TabStop = false;
			// 
			// shellTreeView
			// 
			this.shellTreeView.Cursor = System.Windows.Forms.Cursors.Default;
			this.shellTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.shellTreeView.Location = new System.Drawing.Point(0, 0);
			this.shellTreeView.Name = "shellTreeView";
			this.shellTreeView.ShowUserInputWhenEnumerating = false;
			this.shellTreeView.Size = new System.Drawing.Size(240, 394);
			this.shellTreeView.TabIndex = 0;
			this.shellTreeView.TabStop = false;
			this.shellTreeView.Text = "shellTreeView1";
			this.shellTreeView.AfterSelect += new System.EventHandler<System.Shell.ShellTreeViewEventArgs>(this.shellTreeView_AfterSelect);
			this.shellTreeView.ItemFilter += new System.EventHandler<System.Shell.ItemFilterEventArgs>(this.browser_ItemFilter);
			this.shellTreeView.BeforeSelect += new System.EventHandler<System.Shell.ShellTreeViewCancelEventArgs>(this.shellTreeView_BeforeSelect);
			// 
			// shellListView
			// 
			this.shellListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.shellListView.FolderViewMode = System.Shell.FolderViewMode.Details;
			this.shellListView.Location = new System.Drawing.Point(0, 0);
			this.shellListView.Name = "shellListView";
			this.shellListView.Size = new System.Drawing.Size(478, 394);
			this.shellListView.TabIndex = 0;
			this.shellListView.Navigated += new System.EventHandler<System.Shell.ShellBrowserNavigatedEventArgs>(this.shellView_Navigated);
			this.shellListView.Navigating += new System.EventHandler<System.Shell.ShellBrowserNavigatingEventArgs>(this.shellView_Navigating);
			this.shellListView.ItemFilter += new System.EventHandler<System.Shell.ItemFilterEventArgs>(this.browser_ItemFilter);
			// 
			// toolBar
			// 
			this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tsbBack,
            this.tsbForward,
            this.tsbView});
			this.toolBar.Divider = false;
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.imgListToolbar;
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new System.Drawing.Size(720, 42);
			this.toolBar.TabIndex = 2;
			this.toolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar.Wrappable = false;
			this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
			// 
			// tsbBack
			// 
			this.tsbBack.DropDownMenu = this.cmuBack;
			this.tsbBack.Enabled = false;
			this.tsbBack.Name = "tsbBack";
			this.tsbBack.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tsbBack.Text = "&Back";
			// 
			// cmuBack
			// 
			this.cmuBack.Popup += new System.EventHandler(this.cmuBack_Popup);
			// 
			// tsbForward
			// 
			this.tsbForward.DropDownMenu = this.cmuForward;
			this.tsbForward.Enabled = false;
			this.tsbForward.Name = "tsbForward";
			this.tsbForward.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tsbForward.Text = "&Forward";
			// 
			// cmuForward
			// 
			this.cmuForward.Popup += new System.EventHandler(this.cmuForward_Popup);
			// 
			// tsbView
			// 
			this.tsbView.DropDownMenu = this.cmuView;
			this.tsbView.Name = "tsbView";
			this.tsbView.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tsbView.Text = "&View";
			// 
			// cmuView
			// 
			this.cmuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmuViewThumbnails,
            this.cmuViewThumbstrips,
            this.cmuViewTiles,
            this.cmuViewLargeIcons,
            this.cmuViewSmallIcons,
            this.cmuViewList,
            this.cmuViewDetails,
            this.cmuViewContent});
			this.cmuView.Popup += new System.EventHandler(this.cmuView_Popup);
			// 
			// cmuViewThumbnails
			// 
			this.cmuViewThumbnails.Index = 0;
			this.cmuViewThumbnails.Text = "T&humbnails";
			this.cmuViewThumbnails.Click += new System.EventHandler(this.cmuViewThumbnails_Click);
			// 
			// cmuViewThumbstrips
			// 
			this.cmuViewThumbstrips.Index = 1;
			this.cmuViewThumbstrips.Text = "Thumbstri&ps";
			this.cmuViewThumbstrips.Click += new System.EventHandler(this.cmuViewThumbstrips_Click);
			// 
			// cmuViewTiles
			// 
			this.cmuViewTiles.Index = 2;
			this.cmuViewTiles.Text = "Tile&s";
			this.cmuViewTiles.Click += new System.EventHandler(this.cmuViewTiles_Click);
			// 
			// cmuViewLargeIcons
			// 
			this.cmuViewLargeIcons.Index = 3;
			this.cmuViewLargeIcons.Text = "Large Ico&ns";
			this.cmuViewLargeIcons.Click += new System.EventHandler(this.cmuViewLargeIcons_Click);
			// 
			// cmuViewSmallIcons
			// 
			this.cmuViewSmallIcons.Index = 4;
			this.cmuViewSmallIcons.Text = "Small &Icons";
			this.cmuViewSmallIcons.Click += new System.EventHandler(this.cmuViewSmallIcons_Click);
			// 
			// cmuViewList
			// 
			this.cmuViewList.Index = 5;
			this.cmuViewList.Text = "&List";
			this.cmuViewList.Click += new System.EventHandler(this.cmuViewList_Click);
			// 
			// cmuViewDetails
			// 
			this.cmuViewDetails.Index = 6;
			this.cmuViewDetails.Text = "&Details";
			this.cmuViewDetails.Click += new System.EventHandler(this.cmuViewDetails_Click);
			// 
			// cmuViewDetails
			// 
			this.cmuViewContent.Index = 7;
			this.cmuViewContent.Text = "&Content";
			this.cmuViewContent.Click += new System.EventHandler(this.cmuViewContent_Click);
			// 
			// imgListToolbar
			// 
			this.imgListToolbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imgListToolbar.ImageSize = new System.Drawing.Size(24, 24);
			this.imgListToolbar.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 458);
			this.statusBar.Name = "statusBar";
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(720, 22);
			this.statusBar.SizingGrip = false;
			this.statusBar.TabIndex = 1;
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 1;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.Controls.Add(this.txtAddressBar, 0, 0);
			this.tlpMain.Controls.Add(this.scMain, 0, 1);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 42);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.RowCount = 2;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.Size = new System.Drawing.Size(720, 416);
			this.tlpMain.TabIndex = 0;
			// 
			// txtAddressBar
			// 
			this.txtAddressBar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtAddressBar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
			this.txtAddressBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtAddressBar.Location = new System.Drawing.Point(0, 0);
			this.txtAddressBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.txtAddressBar.Name = "txtAddressBar";
			this.txtAddressBar.Size = new System.Drawing.Size(720, 20);
			this.txtAddressBar.TabIndex = 0;
			this.txtAddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddressBar_KeyDown);
			// 
			// ShellBrowser
			// 
			this.Controls.Add(this.tlpMain);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.toolBar);
			this.Name = "ShellBrowser";
			this.Size = new System.Drawing.Size(720, 480);
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel2.ResumeLayout(false);
			this.scMain.ResumeLayout(false);
			this.tlpMain.ResumeLayout(false);
			this.tlpMain.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}