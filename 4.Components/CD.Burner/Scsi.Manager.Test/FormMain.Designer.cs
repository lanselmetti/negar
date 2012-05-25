namespace BurnApp
{
	partial class FormMain
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
            this.cmDirectories = new System.Windows.Forms.ContextMenu();
            this.miDirectoriesNewFolder = new System.Windows.Forms.MenuItem();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.miRecorder = new System.Windows.Forms.MenuItem();
            this.miRecorderBlank = new System.Windows.Forms.MenuItem();
            this.miRecorderReadWriteErrorRecoveryParameters = new System.Windows.Forms.MenuItem();
            this.miRecorderReadWriteSpeeds = new System.Windows.Forms.MenuItem();
            this.miRecorderGetFeatures = new System.Windows.Forms.MenuItem();
            this.scFiles = new BurnApp.FormMain.MySplitContainer();
            this.tvDirectories = new BurnApp.FormMain.MyTreeView();
            this.imgListNodes = new System.Windows.Forms.ImageList(this.components);
            this.lvFiles = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colPath = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.imgListFiles = new System.Windows.Forms.ImageList(this.components);
            this.shellBrowser = new System.Shell.ShellBrowser();
            this.scMain = new BurnApp.FormMain.MySplitContainer();
            this.cmSplitter = new System.Windows.Forms.ContextMenu();
            this.miSplitterRotate = new System.Windows.Forms.MenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbShowExplorer = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenImage = new System.Windows.Forms.ToolStripButton();
            this.tsbBurn = new System.Windows.Forms.ToolStripButton();
            this.tscmbDevice = new System.Windows.Forms.ToolStripComboBox();
            this.capacityBar = new BurnApp.CapacityBar();
            this.sbInfo = new System.Windows.Forms.StatusBar();
            this.sbPnlStage = new System.Windows.Forms.StatusBarPanel();
            this.sbPnlDescription = new System.Windows.Forms.StatusBarPanel();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.ttpMain = new System.Windows.Forms.ToolTip(this.components);
            this.sfdSaveImage = new System.Windows.Forms.SaveFileDialog();
            this.fbdAddFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdAddFile = new System.Windows.Forms.OpenFileDialog();
            this.scFiles.Panel1.SuspendLayout();
            this.scFiles.Panel2.SuspendLayout();
            this.scFiles.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbPnlStage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbPnlDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // cmDirectories
            // 
            this.cmDirectories.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miDirectoriesNewFolder});
            // 
            // miDirectoriesNewFolder
            // 
            this.miDirectoriesNewFolder.Index = 0;
            this.miDirectoriesNewFolder.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.miDirectoriesNewFolder.Text = "New &Folder";
            this.miDirectoriesNewFolder.Click += new System.EventHandler(this.miDirectoriesNewFolder_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miRecorder});
            // 
            // miRecorder
            // 
            this.miRecorder.Index = 0;
            this.miRecorder.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miRecorderBlank,
            this.miRecorderReadWriteErrorRecoveryParameters,
            this.miRecorderReadWriteSpeeds,
            this.miRecorderGetFeatures});
            this.miRecorder.Text = "&Recorder";
            // 
            // miRecorderBlank
            // 
            this.miRecorderBlank.Index = 0;
            this.miRecorderBlank.Text = "Erase Re&writable Disc";
            this.miRecorderBlank.Click += new System.EventHandler(this.miRecorderBlank_Click);
            // 
            // miRecorderReadWriteErrorRecoveryParameters
            // 
            this.miRecorderReadWriteErrorRecoveryParameters.Index = 1;
            this.miRecorderReadWriteErrorRecoveryParameters.Text = "Read/Write Error Recovery Parameters";
            this.miRecorderReadWriteErrorRecoveryParameters.Click += new System.EventHandler(this.miRecorderReadWriteErrorRecoveryParameters_Click);
            // 
            // miRecorderReadWriteSpeeds
            // 
            this.miRecorderReadWriteSpeeds.Enabled = false;
            this.miRecorderReadWriteSpeeds.Index = 2;
            this.miRecorderReadWriteSpeeds.Text = "Read/Write Speeds";
            // 
            // miRecorderGetFeatures
            // 
            this.miRecorderGetFeatures.Index = 3;
            this.miRecorderGetFeatures.Text = "View Supported &Features";
            this.miRecorderGetFeatures.Click += new System.EventHandler(this.miRecorderGetFeatures_Click);
            // 
            // scFiles
            // 
            this.scFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scFiles.Location = new System.Drawing.Point(0, 25);
            this.scFiles.Name = "scFiles";
            // 
            // scFiles.Panel1
            // 
            this.scFiles.Panel1.Controls.Add(this.tvDirectories);
            // 
            // scFiles.Panel2
            // 
            this.scFiles.Panel2.Controls.Add(this.lvFiles);
            this.scFiles.Size = new System.Drawing.Size(461, 289);
            this.scFiles.SplitterDistance = 131;
            this.scFiles.SplitterWidth = 2;
            this.scFiles.TabIndex = 0;
            this.scFiles.TabStop = false;
            // 
            // tvDirectories
            // 
            this.tvDirectories.AllowDrop = true;
            this.tvDirectories.ContextMenu = this.cmDirectories;
            this.tvDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDirectories.HideSelection = false;
            this.tvDirectories.ImageIndex = 0;
            this.tvDirectories.ImageList = this.imgListNodes;
            this.tvDirectories.LabelEdit = true;
            this.tvDirectories.Location = new System.Drawing.Point(0, 0);
            this.tvDirectories.Name = "tvDirectories";
            this.tvDirectories.SelectedImageIndex = 0;
            this.tvDirectories.ShowNodeToolTips = true;
            this.tvDirectories.Size = new System.Drawing.Size(131, 289);
            this.tvDirectories.TabIndex = 0;
            this.tvDirectories.DragLeave += new System.EventHandler(this.tvDirectories_DragLeave);
            this.tvDirectories.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvDirectories_AfterLabelEdit);
            this.tvDirectories.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvDirectories_DragDrop);
            this.tvDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDirectories_AfterSelect);
            this.tvDirectories.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvDirectories_DragEnter);
            this.tvDirectories.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvDirectories_BeforeLabelEdit);
            this.tvDirectories.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvDirectories_KeyDown);
            this.tvDirectories.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvDirectories_ItemDrag);
            this.tvDirectories.DragOver += new System.Windows.Forms.DragEventHandler(this.tvDirectories_DragOver);
            // 
            // imgListNodes
            // 
            this.imgListNodes.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListNodes.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListNodes.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lvFiles
            // 
            this.lvFiles.AllowColumnReorder = true;
            this.lvFiles.AllowDrop = true;
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colPath,
            this.colSize});
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFiles.LabelEdit = true;
            this.lvFiles.Location = new System.Drawing.Point(0, 0);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.ShowItemToolTips = true;
            this.lvFiles.Size = new System.Drawing.Size(328, 289);
            this.lvFiles.SmallImageList = this.imgListFiles;
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.VirtualMode = true;
            this.lvFiles.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvFiles_DrawColumnHeader);
            this.lvFiles.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvFiles_DrawItem);
            this.lvFiles.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvFiles_AfterLabelEdit);
            this.lvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragDrop);
            this.lvFiles.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvFiles_RetrieveVirtualItem);
            this.lvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragEnter);
            this.lvFiles.DragLeave += new System.EventHandler(this.lvFiles_DragLeave);
            this.lvFiles.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvFiles_BeforeLabelEdit);
            this.lvFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvFiles_KeyDown);
            this.lvFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvFiles_ItemDrag);
            this.lvFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragOver);
            this.lvFiles.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvFiles_DrawSubItem);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 133;
            // 
            // colPath
            // 
            this.colPath.Text = "Path";
            this.colPath.Width = 230;
            // 
            // colSize
            // 
            this.colSize.Text = "Size (Bytes)";
            this.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSize.Width = 74;
            // 
            // imgListFiles
            // 
            this.imgListFiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListFiles.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListFiles.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // shellBrowser
            // 
            this.shellBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellBrowser.Location = new System.Drawing.Point(0, 0);
            this.shellBrowser.Name = "shellBrowser";
            this.shellBrowser.Size = new System.Drawing.Size(479, 368);
            this.shellBrowser.TabIndex = 0;
            this.shellBrowser.ItemFilter += new System.EventHandler<System.Shell.ItemFilterEventArgs>(this.shellBrowser_ItemFilter);
            // 
            // scMain
            // 
            this.scMain.ContextMenu = this.cmSplitter;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(3, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.scFiles);
            this.scMain.Panel1.Controls.Add(this.tsMain);
            this.scMain.Panel1.Controls.Add(this.capacityBar);
            this.scMain.Panel1.Controls.Add(this.sbInfo);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.shellBrowser);
            this.scMain.Size = new System.Drawing.Size(944, 368);
            this.scMain.SplitterDistance = 461;
            this.scMain.TabIndex = 0;
            this.scMain.TabStop = false;
            // 
            // cmSplitter
            // 
            this.cmSplitter.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSplitterRotate});
            // 
            // miSplitterRotate
            // 
            this.miSplitterRotate.Index = 0;
            this.miSplitterRotate.Text = "&Rotate Panes";
            this.miSplitterRotate.Click += new System.EventHandler(this.miSplitterRotate_Click);
            // 
            // tsMain
            // 
            this.tsMain.AllowItemReorder = true;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbShowExplorer,
            this.tsbOpenImage,
            this.tsbBurn,
            this.tscmbDevice});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(0, 0, 1, 3);
            this.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMain.Size = new System.Drawing.Size(461, 25);
            this.tsMain.TabIndex = 1;
            // 
            // tsbShowExplorer
            // 
            this.tsbShowExplorer.Checked = true;
            this.tsbShowExplorer.CheckOnClick = true;
            this.tsbShowExplorer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbShowExplorer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowExplorer.Name = "tsbShowExplorer";
            this.tsbShowExplorer.Size = new System.Drawing.Size(80, 19);
            this.tsbShowExplorer.Text = "Show &Explorer";
            this.tsbShowExplorer.ToolTipText = "Shows an explorer window to the right of the file system, from which you can drag" +
                " and drop files and folders.";
            this.tsbShowExplorer.CheckedChanged += new System.EventHandler(this.tsbShowExplorer_CheckedChanged);
            // 
            // tsbOpenImage
            // 
            this.tsbOpenImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenImage.Name = "tsbOpenImage";
            this.tsbOpenImage.Size = new System.Drawing.Size(70, 19);
            this.tsbOpenImage.Text = "&Open Image";
            this.tsbOpenImage.ToolTipText = "Open an image file and burn it";
            this.tsbOpenImage.Click += new System.EventHandler(this.tsbOpenImage_Click);
            // 
            // tsbBurn
            // 
            this.tsbBurn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBurn.Name = "tsbBurn";
            this.tsbBurn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbBurn.Size = new System.Drawing.Size(33, 19);
            this.tsbBurn.Text = "&Burn";
            this.tsbBurn.ToolTipText = "Burns the data to the disc.";
            this.tsbBurn.Click += new System.EventHandler(this.tsbBurn_Click);
            // 
            // tscmbDevice
            // 
            this.tscmbDevice.AutoToolTip = true;
            this.tscmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbDevice.Name = "tscmbDevice";
            this.tscmbDevice.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tscmbDevice.Size = new System.Drawing.Size(100, 22);
            this.tscmbDevice.ToolTipText = "Select the recorder to use for burning.";
            // 
            // capacityBar
            // 
            this.capacityBar.Capacity = ((long)(10));
            this.capacityBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.capacityBar.Location = new System.Drawing.Point(0, 314);
            this.capacityBar.Markers = null;
            this.capacityBar.Name = "capacityBar";
            this.capacityBar.Size = new System.Drawing.Size(461, 32);
            this.capacityBar.TabIndex = 2;
            // 
            // sbInfo
            // 
            this.sbInfo.Location = new System.Drawing.Point(0, 346);
            this.sbInfo.Name = "sbInfo";
            this.sbInfo.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbPnlStage,
            this.sbPnlDescription});
            this.sbInfo.ShowPanels = true;
            this.sbInfo.Size = new System.Drawing.Size(461, 22);
            this.sbInfo.SizingGrip = false;
            this.sbInfo.TabIndex = 1;
            // 
            // sbPnlStage
            // 
            this.sbPnlStage.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbPnlStage.Name = "sbPnlStage";
            this.sbPnlStage.Text = "Drag-and-drop files from Explorer to the left.";
            this.sbPnlStage.Width = 230;
            // 
            // sbPnlDescription
            // 
            this.sbPnlDescription.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbPnlDescription.Name = "sbPnlDescription";
            this.sbPnlDescription.Width = 230;
            // 
            // ofdMain
            // 
            this.ofdMain.DefaultExt = "iso";
            this.ofdMain.Filter = "User Data Image Files (*.iso, *.udf, *.tao, *.sao, *.dao, *.bin)|*.iso;*.udf;*.ta" +
                "o;*.sao;*.dao;*.bin|All files (*.*)|*";
            this.ofdMain.RestoreDirectory = true;
            this.ofdMain.SupportMultiDottedExtensions = true;
            this.ofdMain.Title = "Open Image...";
            // 
            // sfdSaveImage
            // 
            this.sfdSaveImage.DefaultExt = "iso";
            this.sfdSaveImage.Filter = "ISO Image Files (*.iso)|*.iso|UDF Image Files (*.udf)|*.udf|All files (*.*)|*";
            this.sfdSaveImage.Title = "Save Image As...";
            // 
            // fbdAddFolder
            // 
            this.fbdAddFolder.Description = "Select the folder that you would like to add.";
            // 
            // ofdAddFile
            // 
            this.ofdAddFile.AddExtension = false;
            this.ofdAddFile.Filter = "All files (*.*)|*";
            this.ofdAddFile.Multiselect = true;
            this.ofdAddFile.Title = "Add Files...";
            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(950, 368);
            this.Controls.Add(this.scMain);
            this.Menu = this.mainMenu;
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.scFiles.Panel1.ResumeLayout(false);
            this.scFiles.Panel2.ResumeLayout(false);
            this.scFiles.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbPnlStage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbPnlDescription)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog ofdMain;
		private System.Windows.Forms.ToolTip ttpMain;
		private MyTreeView tvDirectories;
		private System.Windows.Forms.ListView lvFiles;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ImageList imgListNodes;
		private System.Windows.Forms.ColumnHeader colPath;
		private System.Windows.Forms.ColumnHeader colSize;
		private System.Windows.Forms.SaveFileDialog sfdSaveImage;
		private System.Windows.Forms.ImageList imgListFiles;
		private System.Windows.Forms.FolderBrowserDialog fbdAddFolder;
		private System.Windows.Forms.OpenFileDialog ofdAddFile;
		private System.Windows.Forms.MenuItem miDirectoriesNewFolder;
		private System.Windows.Forms.MenuItem miRecorderBlank;
		private System.Windows.Forms.MenuItem miRecorderGetFeatures;
		private System.Shell.ShellBrowser shellBrowser;
		private System.Windows.Forms.ContextMenu cmSplitter;
		private System.Windows.Forms.MenuItem miSplitterRotate;
		private FormMain.MySplitContainer scFiles;
		private FormMain.MySplitContainer scMain;
		private System.Windows.Forms.StatusBar sbInfo;
		private System.Windows.Forms.StatusBarPanel sbPnlStage;
		private System.Windows.Forms.StatusBarPanel sbPnlDescription;
		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.ToolStripButton tsbShowExplorer;
		private System.Windows.Forms.ToolStripButton tsbOpenImage;
		private System.Windows.Forms.ToolStripButton tsbBurn;
		private System.Windows.Forms.ToolStripComboBox tscmbDevice;
		private CapacityBar capacityBar;
		private System.Windows.Forms.ContextMenu cmDirectories;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem miRecorder;
		private System.Windows.Forms.MenuItem miRecorderReadWriteSpeeds;
		private System.Windows.Forms.MenuItem miRecorderReadWriteErrorRecoveryParameters;
	}
}

