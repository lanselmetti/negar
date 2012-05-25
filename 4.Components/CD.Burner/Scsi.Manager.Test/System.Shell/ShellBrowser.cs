#if !DEBUG
#define CATCH
#endif
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Helper.Forms;

namespace System.Shell
{
	public partial class ShellBrowser : Control
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private BorderStyle _BorderStyle = BorderStyle.None;
		private Stack<ShellItemIdList> backward = new Stack<ShellItemIdList>();
		private Stack<ShellItemIdList> forward = new Stack<ShellItemIdList>();
		private bool trackNavigation = true;

		public ShellBrowser()
		{
			this.InitializeComponent();
			this.ResetViewMode();
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, false);
			this.shellListView.StatusBar = this.statusBar;
			var hShell32 = UnsafeNativeMethods.LoadLibrary("Shell32.dll");
			try
			{
				var hBmpStrip = WinHelper.UnsafeNativeMethods.LoadImage(hShell32, (IntPtr)215, ImageType.Bitmap, 0, 0, LoadOptions.DefaultColor);
				Bitmap bmpStrip;
				BITMAP b;
				if (UnsafeNativeMethods.GetObject(hBmpStrip, Marshal.SizeOf(typeof(BITMAP)), out b) == 0)
				{ Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
				bmpStrip = new Bitmap(b.bmWidth, b.bmHeight, PixelFormat.Format32bppArgb);

				var dest = bmpStrip.LockBits(new Rectangle(Point.Empty, bmpStrip.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
				try { UnsafeNativeMethods.GetBitmapBits(hBmpStrip, dest.Stride * dest.Height, dest.Scan0); }
				finally { bmpStrip.UnlockBits(dest); }

				this.imgListToolbar.Images.AddStrip(bmpStrip);
				this.tsbBack.ImageIndex = 0;
				this.tsbForward.ImageIndex = 1;
				this.tsbView.ImageIndex = 22;
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex);

				var styles = DrawFrameControlStyles.None | (this.toolBar.Appearance == ToolBarAppearance.Flat ? DrawFrameControlStyles.Flat : DrawFrameControlStyles.None);

				var bmpLeft = new Bitmap(this.imgListToolbar.ImageSize.Width, this.imgListToolbar.ImageSize.Height, PixelFormat.Format32bppArgb);
				using (var g = Graphics.FromImage(bmpLeft))
				{
					IntPtr hDC = g.GetHdc();
					try
					{
						var rect = new Rect(0, 0, bmpLeft.Width, bmpLeft.Height);
						if (!WinHelper.UnsafeNativeMethods.DrawFrameControl(new HandleRef(g, hDC), ref rect, FrameControlType.Scroll, 2 | (int)styles))
						{ Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
					}
					finally { g.ReleaseHdc(hDC); }
				}
				this.imgListToolbar.Images.Add("LEFT", bmpLeft);
				this.tsbBack.ImageKey = "LEFT";

				var bmpRight = new Bitmap(this.imgListToolbar.ImageSize.Width, this.imgListToolbar.ImageSize.Height, PixelFormat.Format32bppArgb);
				using (var g = Graphics.FromImage(bmpRight))
				{
					IntPtr hDC = g.GetHdc();
					try
					{
						var rect = new Rect(0, 0, bmpRight.Width, bmpRight.Height);
						if (!WinHelper.UnsafeNativeMethods.DrawFrameControl(new HandleRef(g, hDC), ref rect, FrameControlType.Scroll, 3 | (int)styles))
						{ Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
					}
					finally { g.ReleaseHdc(hDC); }
				}
				this.imgListToolbar.Images.Add("RIGHT", bmpRight);
				this.tsbForward.ImageKey = "RIGHT";

				var bmpView = new Bitmap(this.imgListToolbar.ImageSize.Width, this.imgListToolbar.ImageSize.Height, PixelFormat.Format32bppArgb);
				using (var g = Graphics.FromImage(bmpView))
				{
					IntPtr hDC = g.GetHdc();
					try
					{
						var rect = new Rect(0, 0, bmpView.Width, bmpView.Height);
						if (!WinHelper.UnsafeNativeMethods.DrawFrameControl(new HandleRef(g, hDC), ref rect, FrameControlType.Caption, 3 | (int)styles))
						{ Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
					}
					finally { g.ReleaseHdc(hDC); }
				}
				this.imgListToolbar.Images.Add("VIEW", bmpView);
				this.tsbView.ImageKey = "VIEW";
				//MessageBox.Show(this, string.Format("Could not load the explorer toolbar icons because of error:" + Environment.NewLine + "{0}", ex.Message), "Error Loading Toolbar Icons", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			finally { UnsafeNativeMethods.FreeLibrary(hShell32); }
		}

		[DefaultValue(BorderStyle.None)]
		public BorderStyle BorderStyle { get { return this._BorderStyle; } set { this._BorderStyle = value; } }

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				switch (this.BorderStyle)
				{
					case BorderStyle.FixedSingle:
						createParams.Style |= 0x800000;
						break;
					case BorderStyle.Fixed3D:
						createParams.ExStyle |= 0x200;
						break;
				}
				//createParams.ExStyle |= 0x00000200 /*WS_EX_CLIENTEDGE*/;
				return createParams;
			}
		}

		private void cmuBack_Popup(object sender, EventArgs e)
		{
			this.cmuBack.MenuItems.Clear();
			if (this.backward.Count > 0)
			{
				foreach (var item in this.backward)
				{
					var copy = item;
					this.cmuBack.MenuItems.Add(new MenuItem(copy.ToString(), (a, b) =>
					{
						this.forward.Push(this.shellListView.CurrentFolder);
						bool found = false;
						while (!found && this.backward.Count > 0)
						{
							var m = this.backward.Pop();
							found = m == copy;
							if (!found) { this.forward.Push(m); }
							else
							{
								this.trackNavigation = false;
								try { this.shellListView.CurrentFolder = ShellItemIdList.Clone(m); }
								finally
								{
									this.trackNavigation = true;
									this.ResetNavigation();
								}
							}
						}
					}));
				}
				this.cmuBack.MenuItems.Add("-");
				this.cmuBack.MenuItems.Add(new MenuItem("Clear", (a, b) => { while (this.backward.Count > 0) { this.backward.Pop().Close(); } this.ResetNavigation(); }) { });
			}
		}

		private void cmuForward_Popup(object sender, EventArgs e)
		{
			this.cmuForward.MenuItems.Clear();
			if (this.forward.Count > 0)
			{
				foreach (var item in this.forward)
				{
					var copy = item;
					this.cmuForward.MenuItems.Add(new MenuItem(copy.ToString(), (a, b) =>
					{
						this.backward.Push(this.shellListView.CurrentFolder);
						bool found = false;
						while (!found && this.forward.Count > 0)
						{
							var m = this.forward.Pop();
							found = m == copy;
							if (!found) { this.backward.Push(m); }
							else
							{
								this.trackNavigation = false;
								try { this.shellListView.CurrentFolder = ShellItemIdList.Clone(m); }
								finally
								{
									this.trackNavigation = true;
									this.ResetNavigation();
								}
							}
						}
					}));
				}
				this.cmuForward.MenuItems.Add("-");
				this.cmuForward.MenuItems.Add(new MenuItem("Clear", (a, b) => { while (this.forward.Count > 0) { this.forward.Pop().Close(); } this.ResetNavigation(); }) { });
			}
		}

		private void cmuView_Popup(object sender, EventArgs e) { this.ResetViewMode(); }

		private void ResetViewMode()
		{
			MenuItem on;
			switch (this.shellListView.FolderViewMode)
			{
				case FolderViewMode.Icon:
					on = this.cmuViewLargeIcons;
					break;
				case FolderViewMode.List:
					on = this.cmuViewList;
					break;
				case FolderViewMode.Details:
					on = this.cmuViewDetails;
					break;
				case FolderViewMode.Thumbnail:
					on = this.cmuViewThumbnails;
					break;
				case FolderViewMode.Tile:
					on = this.cmuViewTiles;
					break;
				case FolderViewMode.SmallIcon:
					on = this.cmuViewSmallIcons;
					break;
				case FolderViewMode.Thumbstrip:
					on = this.cmuViewThumbstrips;
					break;
				default:
					on = null;
					break;
			}
			for (int i = 0; i < this.cmuView.MenuItems.Count; i++)
			{
				var mi = this.cmuView.MenuItems[i];
				mi.Checked = mi == on;
			}
		}

		private void tsbBackForwardClick(object sender, ToolBarButtonClickEventArgs e)
		{
			if (e.Button == this.tsbBack)
			{
				if (this.backward.Count > 0)
				{
					this.trackNavigation = false;
					try
					{
						var prev = this.backward.Pop();
						var current = this.shellListView.CurrentFolder;
						this.shellListView.CurrentFolder = prev;
						this.forward.Push(ShellItemIdList.Clone(current));
					}
					finally
					{
						this.trackNavigation = true;
						this.ResetNavigation();
					}
				}
			}
			if (e.Button == this.tsbForward)
			{
				if (this.forward.Count > 0)
				{
					this.trackNavigation = false;
					try
					{
						var prev = this.forward.Pop();
						var current = this.shellListView.CurrentFolder;
						this.shellListView.CurrentFolder = prev;
						this.backward.Push(ShellItemIdList.Clone(current));
					}
					finally
					{
						this.trackNavigation = true;
						this.ResetNavigation();
					}
				}
			}
		}

		private void ResetNavigation()
		{
			this.tsbBack.Enabled = this.backward.Count > 0;
			this.tsbBack.ToolTipText = this.backward.Count > 0 ? this.backward.Peek().ToString() : string.Empty;
			this.tsbForward.Enabled = this.forward.Count > 0;
			this.tsbForward.ToolTipText = this.forward.Count > 0 ? this.forward.Peek().ToString() : string.Empty;
		}

		private void browser_ItemFilter(object sender, ItemFilterEventArgs e) { this.OnItemFilter(e); }

		[DebuggerHidden]
		protected virtual void OnItemFilter(ItemFilterEventArgs e) { if (this.ItemFilter != null) { this.ItemFilter(this, e); } }

		public event EventHandler<ItemFilterEventArgs> ItemFilter;

		private void shellTreeView_AfterSelect(object sender, ShellTreeViewEventArgs e)
		{
#if CATCH
			try
#endif
			{ this.shellListView.CurrentFolder = e.ShellFolder; }
#if CATCH
			catch (Exception ex)
			{
				//e.Cancel = true;
				MessageBox.Show(this, ex.ToString(), "Error Opening Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//throw;
			}
#endif
		}

		private void shellTreeView_BeforeSelect(object sender, ShellTreeViewCancelEventArgs e) { }

		private void shellView_Navigated(object sender, ShellBrowserNavigatedEventArgs e) { this.txtAddressBar.Text = e.TargetFolder.ToString(); }

		private ShellItemIdList Search(IShellFolder folder, ShellItemIdList fullFolderId, string displayName)
		{
			ShellItemIdList idList = null;
			bool disposeId = false;
			if (fullFolderId == null) { ((IPersistFolder2)folder).GetCurFolder(out fullFolderId); disposeId = true; }
			try
			{
				if (folder == null) { folder = ShellUtil.OpenFolder(fullFolderId); }
				foreach (var relativeId in ShellFolders.EnumObjects(folder, this.Handle, SHCONTF.Folders | SHCONTF.IncludeHidden))
				{
					using (relativeId)
					using (var fullId = fullFolderId + relativeId)
					{
						if (displayName.Equals(relativeId.ToString(), StringComparison.CurrentCultureIgnoreCase)
							|| displayName.Equals(fullId.ToString(), StringComparison.CurrentCultureIgnoreCase))
						{
							idList = ShellItemIdList.Clone(fullId);
							break;
						}
					}
				}
			}
			finally { if (disposeId) { fullFolderId.Close(); } }
			return idList;
		}

		private void shellView_Navigating(object sender, ShellBrowserNavigatingEventArgs e)
		{
			bool tracking = this.trackNavigation;
			try
			{
				bool pushed = tracking;
				if (pushed)
				{
					this.backward.Push(ShellItemIdList.Clone(this.shellListView.CurrentFolder));

					while (this.forward.Count > 0)
					{
						this.forward.Pop().Close();
					}
				}
				try
				{
					this.shellTreeView.GotoNode(e.TargetFolder, true);
				}
				finally
				{
					if (e.Cancel) { if (pushed) { this.backward.Pop(); } }
				}
			}
			finally { if (tracking) { this.ResetNavigation(); } }
		}

		private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			if (e.Button == this.tsbBack | e.Button == this.tsbForward) { this.tsbBackForwardClick(sender, e); }
			if (e.Button == this.tsbView)
			{
				bool @continue = true;
				var startMode = this.shellListView.FolderViewMode;
				var current = (FolderViewMode)(((int)startMode + 1) % 8 + 1);
				while (@continue && (int)current <= 8)
				{
					this.shellListView.FolderViewMode = current;
					if (this.shellListView.FolderViewMode == current) { @continue = false; }
					current++;
				}
				current = FolderViewMode.Icon;
				while (@continue && (int)current <= (int)startMode)
				{
					this.shellListView.FolderViewMode = current;
					if (this.shellListView.FolderViewMode == current) { @continue = false; }
					current++;
				}

				//Rect rect;
				//if (UnsafeNativeMethods.SendMessage(new HandleRef(this.toolBar, this.toolBar.Handle), 0x41D, (IntPtr)this.toolBar.Buttons.IndexOf(this.tsbView), out rect) != IntPtr.Zero)
				//{ this.cmuView.Show(this.toolBar, new Point(rect.left, rect.bottom), LeftRightAlignment.Right); }
			}
			//var msg = new MSG() {  };
			//this.shellListView.TranslateViewAccelerator();
		}

		#region Win32Native
		private struct BITMAP
		{
			public int bmType;
			public int bmWidth;
			public int bmHeight;
			public int bmWidthBytes;
			public short bmPlanes;
			public short bmBitsPixel;
			public IntPtr bmBits;
		}

		[System.Security.SuppressUnmanagedCodeSecurity]
		private static class UnsafeNativeMethods
		{
			[DllImport("Gdi32.dll", SetLastError = true)]
			public static extern int GetObject(IntPtr hgdiobj, int cbBuffer, out BITMAP lpvObject);

			[DllImport("Gdi32.dll", SetLastError = true)]
			public static extern int GetBitmapBits(IntPtr hbmp, int cbBuffer, IntPtr lpvBits);

			[DllImport("Kernel32.dll", SetLastError = true)]
			public static extern IntPtr LoadLibrary([In] string lpFileName);

			[DllImport("Kernel32.dll", SetLastError = true)]
			public static extern bool FreeLibrary([In] IntPtr hModule);
		}
		#endregion

		private void txtAddressBar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				try
				{
					ShellItemIdList idList;
					var sfgao = SFGAO.Folder;
					int eaten;
					string path = this.txtAddressBar.Text;
					try { ShellFolders.Desktop.ParseDisplayName(this.Handle, null, path, out eaten, out idList, ref sfgao); }
					catch
					{
						idList = null;
						if (idList == null) { idList = this.Search(null, this.shellListView.CurrentFolder, path); }
						if (idList == null) { idList = this.Search(ShellFolders.Desktop, ShellItemIdList.Desktop, path); }
						if (idList == null) { idList = this.Search(ShellFolders.Computer, ShellItemIdList.Computer, path); }
						if (idList == null) { if (path.Equals(ShellItemIdList.Desktop.ToString(), StringComparison.CurrentCultureIgnoreCase)) { idList = ShellItemIdList.Clone(ShellItemIdList.Desktop); } }
						if (idList == null) { throw; }
					}
					if (idList == null) { throw new System.IO.DirectoryNotFoundException(string.Format("Could not navigate to the given folder." + Environment.NewLine + "Path: {0}", this.txtAddressBar.Text)); }
					using (idList) { this.shellListView.CurrentFolder = idList; }
				}
				catch (Exception ex)
				{ MessageBox.Show(this, string.Format("Invalid path: {0}" + Environment.NewLine + Environment.NewLine + "Internal error: {1}", this.txtAddressBar.Text, ex.Message), "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
			}
			else if (e.KeyCode == Keys.Escape)
			{
				try
				{ this.txtAddressBar.Text = this.shellListView.CurrentFolder.ToString(); }
				catch { }
			}
		}

		private void cmuViewThumbnails_Click(object sender, EventArgs e) { this.shellListView.FolderViewMode = FolderViewMode.Thumbnail; this.ResetViewMode(); }
		private void cmuViewTiles_Click(object sender, EventArgs e) { this.shellListView.FolderViewMode = FolderViewMode.Tile; this.ResetViewMode(); }
		private void cmuViewLargeIcons_Click(object sender, EventArgs e) { this.shellListView.FolderViewMode = FolderViewMode.Icon; this.ResetViewMode(); }
		private void cmuViewList_Click(object sender, EventArgs e) { this.shellListView.FolderViewMode = FolderViewMode.List; this.ResetViewMode(); }
		private void cmuViewDetails_Click(object sender, EventArgs e) { this.shellListView.FolderViewMode = FolderViewMode.Details; this.ResetViewMode(); }
		private void cmuViewThumbstrips_Click(object sender, EventArgs e) { this.shellListView.FolderViewMode = FolderViewMode.Thumbstrip; this.ResetViewMode(); }
		private void cmuViewSmallIcons_Click(object sender, EventArgs e) { this.shellListView.FolderViewMode = FolderViewMode.SmallIcon; this.ResetViewMode(); }
		private void cmuViewContent_Click(object sender, EventArgs e) { this.shellListView.FolderViewMode = FolderViewMode.Content; this.ResetViewMode(); }
	}
}