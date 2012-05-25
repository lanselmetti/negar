using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Helper.Forms;

namespace System.Shell
{
	public class ShellListView : ContainerControl, IShellBrowser, ICommDlgBrowser, IServiceProvider, IProfferService, IShellFolderViewCB
	{
		private IShellView view;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private BorderStyle _BorderStyle = BorderStyle.None;
		private FolderViewMode viewMode = FolderViewMode.Details;
		private ShellItemIdList _CurrentFolder = ShellItemIdList.Desktop;

		public ShellListView() : base() { }

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// ShellListView
			// 
			this.Name = "ShellListView";
			this.ResumeLayout(false);

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

		protected override void OnHandleCreated(EventArgs e)
		{
			this.CurrentFolder = this._CurrentFolder;
			base.OnHandleCreated(e);
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			if (this.view != null)
			{
				IntPtr hWnd;
				this.view.GetWindow(out hWnd);
				WinHelper.SetFocus(new HandleRef(null, hWnd));
			}
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			base.OnHandleDestroyed(e);
			if (this.view != null) { this.view.UIActivate(ShellViewUIActivation.Deactivate); this.view.DestroyViewWindow(); }
		}

		public override bool PreProcessMessage(ref Message msg)
		{
			bool result = false;
			var m = new MSG() { hWnd = msg.HWnd, Message = msg.Msg, wParam = msg.WParam, lParam = msg.LParam };
			if (this.view != null)
			{
				if ((msg.Msg != 0x0100 /*WM_KEYDOWN*/ & msg.Msg != 0x0101 /*WM_KEYUP*/)
					|| (Keys)msg.WParam != Keys.Delete || MessageBox.Show(this, "WARNING: You are deleting an actual file, not removing one from the compilation." + Environment.NewLine + "If this is what you intended, press OK. Otherwise, please click on the file you would like to remove before pressing Delete.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
				{
					int hr = this.view.TranslateAccelerator(ref m);
					if (hr == 0) { result = true; }
				}
			}
			if (!result) { result = base.PreProcessMessage(ref msg); }
			return result;
		}

		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			base.SetBoundsCore(x, y, width, height, specified);
			if (this.view != null)
			{
				IntPtr hWnd;
				this.view.GetWindow(out hWnd);
				WinHelper.SetWindowPos(new HandleRef(null, hWnd), new HandleRef(null, IntPtr.Zero), this.ClientRectangle.X + this.Padding.Left, this.ClientRectangle.Y + this.Padding.Top, Math.Max(0, this.ClientRectangle.Width - this.Padding.Horizontal), Math.Max(0, this.ClientRectangle.Height - this.Padding.Vertical), 0);
			}
		}

		public virtual int InsertMenusSB(IntPtr hmenuShared, ref OleMenuGroupWidths lpMenuWidths) { return unchecked((int)0x80004001); }
		public virtual int SetMenuSB(IntPtr hmenuShared, IntPtr holemenuRes, IntPtr hwndActiveObject) { return unchecked((int)0x80004001); }
		public virtual int RemoveMenusSB(IntPtr hmenuShared) { return unchecked((int)0x80004001); }
		public virtual int SetStatusTextSB(string pszStatusText) { var asSB = this.StatusBar as StatusBar; if (asSB != null) { asSB.Text = pszStatusText; return 0; } else { return unchecked((int)0x80004001); } }
		public virtual int QueryActiveShellView(out IShellView ppshv) { ppshv = this.view; return 0; }
		public virtual int GetWindow(out IntPtr phwnd) { phwnd = this.Handle; return 0; }
		public virtual int OnViewWindowActive(IShellView pshv) { return 0; }
		public virtual int ContextSensitiveHelp(int fEnterMode) { return unchecked((int)0x80004001); }
		public virtual int EnableModelessSB(bool fEnable) { return unchecked((int)0x80004001); }
		public virtual int GetViewStateStream(int grfMode, out System.Runtime.InteropServices.ComTypes.IStream ppStrm) { ppStrm = null; return unchecked((int)0x80004001); }
		public virtual int TranslateAcceleratorSB(ref MSG pmsg, short wID) { /*UnsafeNativeMethods.DispatchMessage(ref pmsg); return 0;*/ return unchecked((int)0x80004001); }

		public virtual int SetToolbarItems(TBBUTTON[] lpButtons, int nButtons, FCT uFlags)
		{
			if (this.Toolbar != null)
			{
				var asToolBar = this.Toolbar as ToolBar;

				if (asToolBar != null)
				{
					for (int i = 0; i < lpButtons.Length; i++)
					{
						var b = lpButtons[i];
						if (!asToolBar.Buttons.ContainsKey(b.idCommand.ToString()))
						{
							var btn = new ToolBarButton() { Name = b.idCommand.ToString() };
							btn.Enabled = (b.fsState & ToolBarButtonState.ENABLED) != 0;
							btn.Visible = (b.fsState & ToolBarButtonState.HIDDEN) == 0;
							btn.PartialPush = (b.fsState & ToolBarButtonState.INDETERMINATE) != 0;
							btn.Pushed = (b.fsState & ToolBarButtonState.PRESSED) != 0;
							btn.Text = (int)b.iString > 0xFFFF ? Marshal.PtrToStringAuto(b.iString) : string.Empty;
							btn.ImageIndex = b.iBitmap;
							if (b.fsStyle == ToolBarButtonStyle.BUTTON) { btn.Style = System.Windows.Forms.ToolBarButtonStyle.PushButton; }
							if ((b.fsStyle & ToolBarButtonStyle.CHECK) != 0) { btn.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton; }
							if ((b.fsStyle & ToolBarButtonStyle.DROPDOWN) != 0) { btn.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton; }
							if ((b.fsStyle & ToolBarButtonStyle.SEP) != 0) { btn.Style = System.Windows.Forms.ToolBarButtonStyle.Separator; }
							asToolBar.Buttons.Add(btn);
						}
					}
				}
				else
				{
					const int TB_ADDBUTTONS = 0x4000 + 20;
					unsafe
					{
						fixed (TBBUTTON* pButtons = lpButtons)
						{
							if (WinHelper.SendMessage(this.Toolbar, TB_ADDBUTTONS, (IntPtr)nButtons, (IntPtr)pButtons, false) == IntPtr.Zero)
							{
								return unchecked((int)0x8000FFFF);
							}
						}
					}
				}
			}
			return 0;
		}

		public override bool Focused { get { if (base.Focused) { return true; } IntPtr focus = WinHelper.GetFocus(); return focus != IntPtr.Zero && WinHelper.IsChild(new HandleRef(this, base.Handle), new HandleRef(null, focus)); } }

		[DefaultValue(null)]
		public ShellItemIdList CurrentFolder
		{
			get { return this._CurrentFolder; }
			set
			{
				if (value == null) { throw new ArgumentNullException("folder"); }
				value = ShellItemIdList.Clone(value);

				if (this.IsHandleCreated)
				{

					var prevView = this.view;
					var prevFolder = this.CurrentFolder;

					if (this.CurrentFolder != null)
					{
						var eBefore = new ShellBrowserNavigatingEventArgs(value);
						this.OnNavigating(eBefore);
						if (eBefore.Cancel) { throw new OperationCanceledException(); }
					}

					bool hadFocus = this.Focused;
					if (!hadFocus && this.view != null)
					{
						IntPtr hWndOldView;
						this.view.GetWindow(out hWndOldView);
						hadFocus |= hWndOldView != IntPtr.Zero && WinHelper.GetFocus() == hWndOldView;
					}

					IShellView newView;
					{
						var guid = ShellUtil.IID_IShellView;
						var folder = ShellUtil.OpenFolder(value);
						//var options = new ShellFolderViewCreate(folder, prevView, this);
						//newView = ShellUtil.SHCreateShellFolderView(ref options);
						object viewObject;
						folder.CreateViewObject(this.Handle, ref guid, out viewObject);
						newView = (IShellView)viewObject;

						var shellFolderView = newView as IShellFolderView;
						if (shellFolderView != null) { IShellFolderViewCB old; shellFolderView.SetCallback(this, out old); }
					}

					FolderSettings folderSettings;
					if (this.view != null) { this.view.GetCurrentInfo(out folderSettings); }
					else { folderSettings = new FolderSettings() { ViewMode = this.viewMode, fFlags = FolderFlags.BestFitWindow | FolderFlags.AutoArrange | FolderFlags.NoWebView /*| FolderFlags.NoClientEdge*/ }; }
					var rect = new Rect(this.Left, this.Top, this.Right, this.Bottom);
					IntPtr hWndView;
					
					this.view = newView;
					this._CurrentFolder = value;
					try
					{
						//System.Diagnostics.Debugger.Break();
						newView.CreateViewWindow(prevView, ref folderSettings, this, ref rect, out hWndView);
						if (prevView != null) { this.view.UIActivate(ShellViewUIActivation.Deactivate); prevView.DestroyViewWindow(); }
						//UnsafeNativeMethods.SetWindowLong(hWndView, -20, UnsafeNativeMethods.GetWindowLong(hWndView, -20) | 0x02000000 /*WM_EX_COMPOSITED*/);
					}
					catch
					{
						this._CurrentFolder = prevFolder;
						this.view = prevView;
						throw;
					}

					this.view.UIActivate(hadFocus ? ShellViewUIActivation.ActivateFocus : ShellViewUIActivation.ActivateNoFocus);
					var eAfter = new ShellBrowserNavigatedEventArgs(value);
					this.OnNavigated(eAfter);
				}
				this._CurrentFolder = value;
			}
		}

		private unsafe delegate int BrowseObjectDelegate(ShellItemId* pidl, SBSP wFlags);

		public unsafe virtual int BrowseObject(ShellItemId* pidl, SBSP wFlags)
		{
			if (this.InvokeRequired) { return (int)this.Invoke((BrowseObjectDelegate)this.BrowseObject, (IntPtr)pidl, wFlags); }
			else
			{
				if ((wFlags & (SBSP)3) == SBSP.SameBrowser | (wFlags & (SBSP)3) == SBSP.DefaultBrowser)
				{
					if ((wFlags & (SBSP)0x3000) != SBSP.Parent)
					{
						using (var id = new ShellItemIdList((IntPtr)pidl, false))
						{
							if ((wFlags & (SBSP)0x3000) == SBSP.Absolute) { this.CurrentFolder = id; }
							else if ((wFlags & (SBSP)0x3000) == SBSP.Relative) { using (var absoluteId = this.CurrentFolder + id) { this.CurrentFolder = absoluteId; } }
							else { throw new InvalidOperationException(); }
						}
						return 0;
					}
					else { /*Go to parent... ignore given pidl...*/ return unchecked((int)0x80004001); }
				}
				else { return unchecked((int)0x80004001); }
			}
		}

		public virtual unsafe int SendControlMsg(FolderControlWindow id, int uMsg, IntPtr wParam, IntPtr lParam, IntPtr* pret)
		{
			IWin32Window target;
			switch (id)
			{
				case FolderControlWindow.Status:
					target = this.StatusBar;
					break;
				case FolderControlWindow.ToolBar:
					target = this.Toolbar;
					break;
				case FolderControlWindow.TreeView:
					target = this.TreeView;
					break;
				case FolderControlWindow.InternetBar:
					target = this.InternetBar;
					break;
				case FolderControlWindow.ProgressBar:
					target = this.ProgressBar;
					break;
				default:
					target = null;
					break;
			}
			if (target != null) { IntPtr ret = WinHelper.SendMessage(target, uMsg, wParam, lParam, false); if (pret != null) { *pret = ret; } return 0; }
			else { return unchecked((int)0x80004001); }
		}

		public virtual int QueryService(ref Guid guidService, ref Guid riid, [Out] out IntPtr ppvObject)
		{
			if (riid == ShellUtil.IID_IShellBrowser) { ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IShellBrowser)); return 0; }
			else if (riid == ShellUtil.IID_ICommDlgBrowser) { ppvObject = Marshal.GetComInterfaceForObject(this, typeof(ICommDlgBrowser)); return 0; }
			else if (riid == ShellUtil.IID_IProfferService) { ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IProfferService)); return 0; }
			else
			{
				ppvObject = IntPtr.Zero;
				return unchecked((int)0x80004001);
			}
		}

		public virtual int ProfferService(ref Guid guidService, IServiceProvider psp, out int pdwCookie) { pdwCookie = 0; return unchecked((int)0x80004001); }

		public virtual int RevokeService(int dwCookie) { return unchecked((int)0x80004001); }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override string Text { get { return base.Text; } set { base.Text = value; } }

		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private IWin32Window _TreeView;
		[DefaultValue(null)]
		public IWin32Window TreeView { get { return this._TreeView; } set { this._TreeView = value; } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private IWin32Window _Toolbar;
		[DefaultValue(null)]
		public IWin32Window Toolbar { get { return this._Toolbar; } set { this._Toolbar = value; } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private IWin32Window _StatusBar;
		[DefaultValue(null)]
		public IWin32Window StatusBar { get { return this._StatusBar; } set { this._StatusBar = value; } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private IWin32Window _ProgressBar;
		[DefaultValue(null)]
		public IWin32Window ProgressBar { get { return this._ProgressBar; } set { this._ProgressBar = value; } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private IWin32Window _InternetBar;
		[DefaultValue(null)]
		public IWin32Window InternetBar { get { return this._InternetBar; } set { this._InternetBar = value; } }

		protected virtual int GetControlWindow(FolderControlWindow id, out IntPtr phwnd)
		{
			switch (id)
			{
				case FolderControlWindow.Status:
					phwnd = this.StatusBar != null ? this.StatusBar.Handle : IntPtr.Zero;
					break;
				case FolderControlWindow.ToolBar:
					phwnd = this.Toolbar != null ? this.Toolbar.Handle : IntPtr.Zero;
					break;
				case FolderControlWindow.TreeView:
					phwnd = this.TreeView != null ? this.TreeView.Handle : IntPtr.Zero;
					break;
				case FolderControlWindow.InternetBar:
					phwnd = this.InternetBar != null ? this.InternetBar.Handle : IntPtr.Zero;
					break;
				case FolderControlWindow.ProgressBar:
					phwnd = this.ProgressBar != null ? this.ProgressBar.Handle : IntPtr.Zero;
					break;
				default:
					phwnd = IntPtr.Zero;
					break;
			}
			if (phwnd == IntPtr.Zero) { return unchecked((int)0x80004001); }
			else { return 0; }
		}

		int IShellBrowser.GetControlWindow(FolderControlWindow id, out IntPtr phwnd) { return this.GetControlWindow(id, out phwnd); }
		int ICommDlgBrowser.OnDefaultCommand(IShellView ppshv) { try { return this.OnDefaultCommand(ppshv) ? 0 : 1; } catch (Exception ex) { return Marshal.GetHRForException(ex); } }

		unsafe int ICommDlgBrowser.IncludeObject(IShellView ppshv, ShellItemId* pidl)
		{
			try
			{
				using (var id = new ShellItemIdList((IntPtr)pidl, false))
				{
					var e = new ItemFilterEventArgs(this.CurrentFolder, id);
					this.OnItemFilter(e);
					return e.Cancel ? 1 : 0;
				}
			}
			catch (Exception ex) { return Marshal.GetHRForException(ex); }
		}

		public event EventHandler<ShellBrowserNavigatingEventArgs> Navigating;
		public event EventHandler<ShellBrowserNavigatedEventArgs> Navigated;

		[DebuggerHidden]
		protected virtual void OnNavigating(ShellBrowserNavigatingEventArgs e) { if (this.Navigating != null) { this.Navigating(this, e); } }
		[DebuggerHidden]
		protected virtual void OnNavigated(ShellBrowserNavigatedEventArgs e) { if (this.Navigated != null) { this.Navigated(this, e); } }

		public virtual void OnStateChange(IShellView ppshv, CommonDialogBrowserStateChange uChange) { }

		/// <returns><c>true</c> if the browser processes the action, or <c>false</c> if the view should handle the action.</returns>
		protected virtual bool OnDefaultCommand(IShellView ppshv) { return false; }

		protected virtual void OnItemFilter(ItemFilterEventArgs e) { if (this.ItemFilter != null) { this.ItemFilter(this, e); } }

		public event EventHandler<ItemFilterEventArgs> ItemFilter;

		public FolderViewMode FolderViewMode
		{
			get
			{
				var view = this.view as IFolderView;
				if (view != null)
				{
					FolderViewMode v = this.viewMode;
					view.GetCurrentViewMode(ref v);
					this.viewMode = v;
					return v;
				}
				else { return this.viewMode; }
			}
			set
			{
				var view = this.view as IFolderView;
				if (view != null) { view.SetCurrentViewMode(value); view.GetCurrentViewMode(ref value); }
				else { this.RecreateHandle(); }
				this.viewMode = value;
			}
		}

		public virtual int MessageSFVCB(ShellFolderViewMessage uMsg, UIntPtr wParam, IntPtr lParam) { return unchecked((int)0x80004001); }
	}

	public class ShellBrowserNavigatedEventArgs : EventArgs { public ShellBrowserNavigatedEventArgs(ShellItemIdList target) { this.TargetFolder = target; } public ShellItemIdList TargetFolder { get; private set; } }
	public class ShellBrowserNavigatingEventArgs : CancelEventArgs { public ShellBrowserNavigatingEventArgs(ShellItemIdList target) { this.TargetFolder = target; } public ShellItemIdList TargetFolder { get; private set; } }
}