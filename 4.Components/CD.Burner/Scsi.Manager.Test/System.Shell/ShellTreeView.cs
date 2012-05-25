#define SHOW_ICONS

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Specialized;
using Helper.Forms;

namespace System.Shell
{
	public partial class ShellTreeView : Control, IShellChangeNotify, IServiceProvider
	{
		private static readonly FieldInfo InAddRange_Field = typeof(ImageList).GetField("inAddRange", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		private static readonly char[] PATH_SEP = new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
		private static readonly int WM_SHCHANGENOTIFY = 0x400 + 0xA0;
		private int changeNotifyRegistration;
		private bool monitorSelectionChange = false;

		public ShellTreeView()
		{
			this.InitializeComponent();
			var ilDesktop = ShellItemIdList.CreateDesktop();
			var tag = new NodeTag(ilDesktop);
			var node = new TreeNode("Desktop") { Tag = tag, ImageKey = "DESKTOP_ICON" };
			node.Name = node.Text;
			node.SelectedImageKey = node.ImageKey;

			bool prev = this.monitorSelectionChange;
			this.monitorSelectionChange = false;
			try { this.tvFolders.SelectedNode = node; }
			finally { this.monitorSelectionChange = prev; }

#if SHOW_ICONS
			int index;
			this.imgListSmall.Images.Add(node.ImageKey, ShellUtil.SHGetFileIcon(this, ShellFolders.Desktop, ilDesktop, null, out index, true));
#endif
			this.tvFolders.Nodes.Add(node);
			node.Nodes.Add(GetDummy());
			node.Expand();
		}

		#region Nested Classes

		private class MyTreeView : TreeView
		{
			private static readonly MethodInfo NodeFromHandle_Method = typeof(TreeView).GetMethod("NodeFromHandle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

			public MyTreeView() { }
			[DebuggerStepThrough]
			protected override void WndProc(ref Message m)
			{
				if (m.Msg == 0x111 && ((int)m.WParam >> 8) == 0)
				{
					try
					{
						var cm = ((ShellTreeView)this.Parent).contextMenu;
						unsafe
						{
							short id = (short)((int)m.WParam & 0xFFFF);
							var tag = (IContextMenu)cm.Tag;
							var info = new MENUITEMINFO()
							{
								cbSize = Marshal.SizeOf(typeof(MENUITEMINFO)),
								fMask = MenuItemInfoMask.String,
							};
							if (!WinHelper.UnsafeNativeMethods.GetMenuItemInfo(new HandleRef(cm, cm.Handle), id, false, ref info)) { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
							info.fMask = MenuItemInfoMask.String | MenuItemInfoMask.Bitmap | MenuItemInfoMask.FType | MenuItemInfoMask.Id;

							info.cch++;
							char* pChars = stackalloc char[info.cch + 1];
							info.dwTypeData = (IntPtr)pChars;
							if (!WinHelper.UnsafeNativeMethods.GetMenuItemInfo(new HandleRef(cm, cm.Handle), id, false, ref info)) { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
							var verb = Marshal.PtrToStringAuto(info.dwTypeData, info.cch);
							var cmdInfo = new CMINVOKECOMMANDINFO()
							{
								hwnd = this.Handle,
								lpVerbA = (IntPtr)info.wID,
								nShow = 1,
							};
							tag.InvokeCommand(cmdInfo);
						}
					}
					catch (Exception ex) { MessageBox.Show(this, ex.Message, "Error Executing Item", MessageBoxButtons.OK, MessageBoxIcon.Error); }
				}
				else if (m.Msg != 0x0014)
				{
					base.WndProc(ref m);
				}
			}

			public TreeNode FocusedNode
			{
				get
				{
					IntPtr h = WinHelper.SendMessage(this, 0x110a, (IntPtr)8, (IntPtr)0, false);
					var node = (TreeNode)NodeFromHandle_Method.Invoke(this, new object[] { h });
					if (node == null) { node = this.SelectedNode; }
					return node;
				}
			}

			protected override void OnHandleCreated(EventArgs e)
			{
				base.OnHandleCreated(e);
			}
		}

		private class NodeTag
		{
			public NodeTag(ShellItemIdList fullID) { this.FullId = fullID; }
			public ShellItemIdList FullId;
		}
		#endregion

		//protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified) { base.SetBoundsCore(x, y, width, height, specified); this.tvFolders.SetBounds(x + this.Padding.Left, y + this.Padding.Top, width - this.Padding.Horizontal, height - this.Padding.Vertical); }

		protected override void OnGotFocus(EventArgs e) { base.OnGotFocus(e); this.tvFolders.Focus(); }

		private void tvFolders_ItemDrag(object sender, ItemDragEventArgs e)
		{
			var data = new DataObject();
			var filePaths = new StringCollection();
			filePaths.Add(((NodeTag)((TreeNode)e.Item).Tag).FullId.ToString());
			data.SetFileDropList(filePaths);
			this.tvFolders.DoDragDrop(data, DragDropEffects.Move | DragDropEffects.Copy | DragDropEffects.Scroll);
		}

		private void tvFolders_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (this.monitorSelectionChange)
			{
				var tag = (NodeTag)e.Node.Tag;
				this.OnAfterSelect(new ShellTreeViewEventArgs(e.Action, e.Node.FullPath, tag.FullId));
			}
		}

		private void tvFolders_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			if (this.monitorSelectionChange)
			{
				var tag = (NodeTag)e.Node.Tag;
				var ea = new ShellTreeViewCancelEventArgs(e.Action, e.Node.FullPath, tag.FullId);
				this.OnBeforeSelect(ea);
				e.Cancel = ea.Cancel;
			}
		}

		public event EventHandler<ShellTreeViewCancelEventArgs> BeforeSelect;
		public event EventHandler<ShellTreeViewEventArgs> AfterSelect;
		[DebuggerHidden]
		protected virtual void OnBeforeSelect(ShellTreeViewCancelEventArgs e) { if (this.BeforeSelect != null) { this.BeforeSelect(this, e); } }
		[DebuggerHidden]
		protected virtual void OnAfterSelect(ShellTreeViewEventArgs e) { if (this.AfterSelect != null) { this.AfterSelect(this, e); } }

		public TreeView TreeView { get { return this.tvFolders; } }

		private bool Find(TreeNode root, string path, out TreeNode closestMatch)
		{
			var node = root;
			var pathComponents = path.Split(PATH_SEP, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < pathComponents.Length; i++)
			{
				if (i == 0)
				{
					if (!node.Name.Equals(pathComponents[i]))
					{
						closestMatch = root;
						return false;
					}
				}
				else
				{
					this.EnsurePopulated(node);
					int index = node.Nodes.IndexOfKey(pathComponents[i]);
					if (index < 0)
					{
						closestMatch = node;
						return false;
					}
					node = node.Nodes[index];
				}
			}
			closestMatch = node;
			return true;
		}

		private void miRefresh_Click(object sender, EventArgs e) { this.Reset(this.tvFolders.FocusedNode); }

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (this.changeNotifyRegistration == 0)
			{
				using (var ilDesktop = ShellItemIdList.CreateDesktop())
				{
					unsafe
					{
						bool success = false;
						ilDesktop.DangerousAddRef(ref success);
						try
						{
							Debug.Assert(success);
							this.changeNotifyRegistration = ShellUtil.SHChangeNotifyRegister(this, ShellNotifySource.InterruptLevel | ShellNotifySource.ShellLevel | ShellNotifySource.RecursiveInterrupt, ShellChangeNotificationEvents.AllEvents | ShellChangeNotificationEvents.Interrupt, WM_SHCHANGENOTIFY, new SHChangeNotifyEntry[] { new SHChangeNotifyEntry() { fRecursive = 1, pidl = (ShellItemId*)ilDesktop.DangerousGetHandle() } });
						}
						finally { if (success) { ilDesktop.DangerousRelease(); } }
					}
				}
			}
			this.monitorSelectionChange = true;
		}

		private static int BinarySearch(TreeNode parent, ShellItemIdList relativeId)
		{
			var tag = ((NodeTag)parent.Tag);
			var folder = ShellUtil.OpenFolder(tag.FullId);
			int lo = 0;
			int hi = parent.Nodes.Count - 1;
			while (lo <= hi)
			{
				int i = lo + ((hi - lo) >> 1);
				int order;
				var child = parent.Nodes[i];
				if (child.Name != @"\DUMMY/")
				{
					var id = ((NodeTag)child.Tag).FullId.FindLastID();
					order = ShellFolders.CompareIDs(folder, id, relativeId, ShellIdentifierComparison.Default, ShellIdentifierComparisonModifier.None);
				}
				else { order = 0; }

				if (order == 0) { lo = ~i; break; }
				if (order < 0) { lo = i + 1; }
				else { hi = i - 1; }
			}
			return ~lo;
		}

		private static int Insert(TreeNode parent, TreeNode node, bool sort)
		{
			int targetIndex;
			if (sort)
			{
				var relativeId = ((NodeTag)node.Tag).FullId.FindLastID();
				targetIndex = ~BinarySearch(parent, relativeId);
				Debug.Assert(targetIndex < 0, "Expected not to find the node already there...");
			}
			else { targetIndex = parent.Nodes.Count; }
			parent.Nodes.Insert(targetIndex, node);
			return targetIndex;
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			this.monitorSelectionChange = false;
			ShellUtil.SHChangeNotifyDeregister(this.changeNotifyRegistration);
			this.changeNotifyRegistration = 0;
			base.OnHandleDestroyed(e);
		}

		private static TreeNode GetDummy() { var n = new TreeNode(@"\DUMMY/") { Name = @"\DUMMY/" }; return n; }

		public unsafe int OnChange(SHCNE lEvent, ShellItemId* pidl1, ShellItemId* pidl2) { return unchecked((int)0x80004001); }

		public virtual int QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject) { ppvObject = IntPtr.Zero; return unchecked((int)0x80004001); }

		private void tvFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e) { this.Populate(e); }

		public bool ShowUserInputWhenEnumerating { get; set; }

		private void Populate(TreeViewCancelEventArgs e)
		{
#if !DEBUG
			try
#endif
			{
				using (new CursorChange(this, Cursors.WaitCursor))
				{
					var tag = (NodeTag)e.Node.Tag;
					var folder = ShellUtil.OpenFolder(tag.FullId);

					int dummyIndex = e.Node.Nodes.IndexOfKey(@"\DUMMY/");
					if (dummyIndex >= 0)
					{
						ShellItemIdList[] ids;
						try { ids = ShellFolders.EnumObjects(folder, this.ShowUserInputWhenEnumerating ? this.Handle : IntPtr.Zero, SHCONTF.Folders | SHCONTF.IncludeHidden | SHCONTF.InitializeOnFirstNext); }
						catch { e.Cancel = true; throw; }

						var nodes = new List<TreeNode>();
						var temp = new IntPtr[1];

						try { InAddRange_Field.SetValue(this.imgListSmall, true); }
						catch { }
						try
						{
							foreach (var id in ids)
							{
								var atts = SFGAO.Folder | SFGAO.HasSubfolder;
								bool success = false;
								id.DangerousAddRef(ref success);
								try
								{
									temp[0] = id.DangerousGetHandle();
									Trace.Assert(success);
									folder.GetAttributesOf(1, temp, ref atts);
								}
								finally { id.DangerousRelease(); }

								ItemFilterEventArgs ea;
								ea = new ItemFilterEventArgs(tag.FullId, id);
								this.OnItemFilter(ea);
								if (!ea.Cancel)
								{
									var fullID = tag.FullId + id;
									var node = this.ToNode(folder, new NodeTag(fullID), this.imgListSmall);
									if ((atts & SFGAO.HasSubfolder) == SFGAO.HasSubfolder)
									{ node.Nodes.Add(GetDummy()); }
									nodes.Add(node);
								}
							}
						}
						finally
						{
							try { InAddRange_Field.SetValue(this.imgListSmall, false); }
							catch { }
						}


						e.Node.Nodes.Clear();
						//We HAVE to sort -- otherwise, a lot of searches won't work
						nodes.Sort((a, b) =>
						{
							ShellItemIdList l = ((NodeTag)a.Tag).FullId.FindLastID(), r = ((NodeTag)b.Tag).FullId.FindLastID();
							int c = ShellFolders.CompareIDs(folder, l, r, ShellIdentifierComparison.Default, ShellIdentifierComparisonModifier.None);
							return c;
						});
						e.Node.Nodes.AddRange(nodes.ToArray());
					}
				}
			}
#if !DEBUG
			catch (Exception ex)
			{
				this.Reset(e.Node);
				Trace.WriteLine(ex);
				e.Cancel = true;
				//if (!(ex is COMException) || ((COMException)ex).ErrorCode != unchecked((int)0x800704C7))
				{ MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			}
#endif
		}

		[DebuggerHidden]
		protected virtual void OnItemFilter(ItemFilterEventArgs e) { if (this.ItemFilter != null) { this.ItemFilter(this, e); } }

		public event EventHandler<ItemFilterEventArgs> ItemFilter;

		private TreeNode ToNode(IShellFolder folder, NodeTag tag, ImageList images)
		{
			var relativeId = tag.FullId.FindLastID();
			STRRET relativeNameRet;
			folder.GetDisplayNameOf(relativeId, SHGDN.ForParsing | SHGDN.InFolder, out relativeNameRet);
			string relativeName = relativeNameRet.ToString();
			var node = new TreeNode(relativeName) { Name = relativeName, Tag = tag };
			var key = tag.FullId.ToString();
			if (!string.IsNullOrEmpty(key))
			{
#if SHOW_ICONS
				int index;
				var icon = ShellUtil.SHGetFileIcon(this, folder, relativeId, null, out index, true);
				if (images != null) { if (icon != null) { images.Images.Add(key, icon); } }
				node.ImageKey = node.SelectedImageKey = key;
#endif
			}
			return node;
		}

		[DebuggerStepThrough]
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == WM_SHCHANGENOTIFY)
			{
				var changeType = (ShellChangeNotificationEvents)m.LParam;
				var ea = new ShellChangeNotifyEventArgs(
					(changeType & (ShellChangeNotificationEvents.Attributes | ShellChangeNotificationEvents.Create | ShellChangeNotificationEvents.Delete | ShellChangeNotificationEvents.DriveAdd | ShellChangeNotificationEvents.DriveAddGui | ShellChangeNotificationEvents.DriveRemoved | ShellChangeNotificationEvents.FreeSpace | ShellChangeNotificationEvents.MediaInserted | ShellChangeNotificationEvents.MediaRemoved | ShellChangeNotificationEvents.MakeDir | ShellChangeNotificationEvents.NetShare | ShellChangeNotificationEvents.NetUnshare | ShellChangeNotificationEvents.RemoveDir | ShellChangeNotificationEvents.ServerDisconnect | ShellChangeNotificationEvents.UpdateDir | ShellChangeNotificationEvents.UpdateImage | ShellChangeNotificationEvents.RenameFolder | ShellChangeNotificationEvents.RenameItem | ShellChangeNotificationEvents.UpdateItem)) != 0 ?
					new ShellItemIdList(Marshal.ReadIntPtr(m.WParam, 0 * IntPtr.Size), false) : null,
					(changeType & (ShellChangeNotificationEvents.RenameFolder | ShellChangeNotificationEvents.RenameItem)) != 0 ?
					new ShellItemIdList(Marshal.ReadIntPtr(m.WParam, 1 * IntPtr.Size), false) : null,
					changeType);
				try
				{
					this.OnShellChangeNotify(ea);
				}
				finally
				{
					if (ea.ItemIdList1 != null) { ea.ItemIdList1.Close(); }
					if (ea.ItemIdList2 != null) { ea.ItemIdList2.Close(); }
				}
			}
			else
			{
				base.WndProc(ref m);
			}
		}

		public void GotoNode(ShellItemIdList id, bool expand)
		{
			TreeNode node;
			if (ShellItemIdList.Desktop.Equals(id)) { node = this.tvFolders.Nodes[0]; }
			else
			{
				node = this.FindParentNode(this.tvFolders.Nodes[0], id, expand);
				if (node != null)
				{
					if (expand) { this.EnsurePopulated(node); }
					using (var relativeId = id.FindLastID())
					{
						int i = BinarySearch(node, relativeId);
						if (i >= 0) { node = node.Nodes[i]; }
#if DEBUG
						else { System.Diagnostics.Debugger.Break(); }
#endif
					}
				}
			}
			Debug.Assert(node != null);
			bool prev = this.monitorSelectionChange;
			this.monitorSelectionChange = false;
			try { this.tvFolders.SelectedNode = node; }
			finally { this.monitorSelectionChange = prev; }
		}

		private void EnsurePopulated(TreeNode node) { this.Populate(new TreeViewCancelEventArgs(node, false, TreeViewAction.Unknown)); }

		private TreeNode FindParentNode(TreeNode node, ShellItemIdList id, bool expand)
		{
			if (!((NodeTag)node.Tag).FullId.IsParentOf(id, true))
			{
				do
				{
					if (expand)
					{
						this.EnsurePopulated(node);
					}
					TreeNode found = null;
					for (int i = 0; i < node.Nodes.Count; i++)
					{
						var childNode = node.Nodes[i];
						if (childNode.Name != @"\DUMMY/")
						{
							if (((NodeTag)childNode.Tag).FullId.IsParentOf(id, false))
							{
								found = childNode;
								break;
							}
						}
					}
					node = found;
					if (node != null && ((NodeTag)node.Tag).FullId.IsParentOf(id, true))
					{ break; }
				} while (node != null && ((NodeTag)node.Tag).FullId.IsParentOf(id, false));
			}
			return node;
		}

		public event EventHandler<ShellChangeNotifyEventArgs> ShellChangeNotify;

		protected virtual void OnShellChangeNotify(ShellChangeNotifyEventArgs e)
		{
			var oldParent = e.ItemIdList1 != null ? this.FindParentNode(this.tvFolders.Nodes[0], e.ItemIdList1, false) : null;
			var newParent = e.ItemIdList2 != null ? this.FindParentNode(this.tvFolders.Nodes[0], e.ItemIdList2, false) : null;

			if ((e.ChangeType & (ShellChangeNotificationEvents.RenameFolder)) != 0)
			{
				if ((oldParent != null | newParent != null) && oldParent != newParent)
				{
					int oldFolderIndex;
					using (var oldItemRelative = e.ItemIdList1.FindLastID())
					{ oldFolderIndex = BinarySearch(oldParent, oldItemRelative); }
					if (oldFolderIndex >= 0)
					{
						var oldNode = oldParent.Nodes[oldFolderIndex];
						oldNode.Remove();
						var oldNodeTag = (NodeTag)oldNode.Tag;
						oldNode.Tag = null;
						oldNodeTag.FullId.Close();
					}


					var newItemRelative = e.ItemIdList2.FindLastID();
					var newFolderIndex = ~BinarySearch(newParent, newItemRelative);
					if (newFolderIndex >= 0)
					{
						var folder = ShellUtil.OpenFolder(((NodeTag)newParent.Tag).FullId);
						var realNewItemRelative = ShellUtil.SHGetRealIDL(folder, newItemRelative);
						var node = this.ToNode(folder, new NodeTag(e.ItemIdList2), this.imgListSmall);
						Insert(newParent, node, true);
					}
				}
				else if (oldParent != null | newParent != null)
				{
					TreeNode node;
					using (var oldItemRelative = e.ItemIdList1.FindLastID())
					{
						int i = BinarySearch(oldParent, oldItemRelative);
						if (i >= 0) { node = oldParent.Nodes[i]; }
						else { node = null; }
					}
					if (node != null && node.Name != @"\DUMMY/")
					{
						try
						{
							var tag = (NodeTag)node.Tag;
							STRRET name;
							using (var newItemRelative = e.ItemIdList2.FindLastID())
							{
								ShellUtil.OpenFolder(tag.FullId).GetDisplayNameOf(newItemRelative, SHGDN.ForParsing | SHGDN.InFolder, out name);
								node.Text = node.Name = name.ToString();
								tag.FullId.Close();

								var oldParentTag = (NodeTag)oldParent.Tag;
								//using (var relativeId = ShellUtil.GetRealIDL(oldParenttag.FullId, newItemRelative)) { }
								tag.FullId = oldParentTag.FullId + e.ItemIdList2;
							}
							node.Remove();
							Insert(oldParent, node, true);
						}
						catch (ArgumentException ex) { Trace.WriteLine(ex); }
					}
				}
			}
			else if ((e.ChangeType & ~(ShellChangeNotificationEvents.Create | ShellChangeNotificationEvents.Delete | ShellChangeNotificationEvents.Attributes | ShellChangeNotificationEvents.AssocChanged | ShellChangeNotificationEvents.RenameItem | ShellChangeNotificationEvents.UpdateItem | ShellChangeNotificationEvents.FreeSpace | ShellChangeNotificationEvents.UpdateDir)) != 0)
			{
				string oldPath;
				bool expanded;
				var selected = this.tvFolders.FocusedNode;
				if (selected != null)
				{
					expanded = selected.IsExpanded;
					oldPath = selected.FullPath;
				}
				else
				{
					expanded = false;
					oldPath = null;
				}

				if (oldParent != null)
				{
					this.Reset(oldParent);
				}

				if (newParent != null)
				{
					this.Reset(newParent);
				}
				if (oldPath != null)
				{
					TreeNode closest;
					if (this.Find(this.tvFolders.Nodes[0], oldPath, out closest))
					{ if (expanded) { closest.Expand(); } }
					else { closest.Expand(); }
					this.tvFolders.SelectedNode = closest;
				}
			}

			if (this.ShellChangeNotify != null) { this.ShellChangeNotify(this, e); }
		}

		private void Reset(TreeNode node)
		{
			using (var cursor = new CursorChange(this, Cursors.WaitCursor))
			{
				bool expanded = node.IsExpanded;
				if (node.Name != @"\DUMMY/")
				{
					try
					{
						node.Collapse();
						this.DisposeChildren(node);
					}
					finally
					{
						node.Nodes.Clear();
						node.Nodes.Add(GetDummy());
					}
				}
				if (expanded) { this.EnsurePopulated(node); }
			}
		}

		private void DisposeChildren(TreeNode node)
		{
			for (int i = 0; i < node.Nodes.Count; i++)
			{
				var n = node.Nodes[i];
				if (n.Name != @"\DUMMY/")
				{
					var tag = (NodeTag)n.Tag;
					n.Tag = null;
					n.Name = @"\DISPOSED/";
					tag.FullId.Close();
					this.imgListSmall.Images.RemoveByKey(n.ImageKey);
					this.imgListSmall.Images.RemoveByKey(n.SelectedImageKey);
				}
			}
		}

		private void contextMenu_Popup(object sender, EventArgs e)
		{
			this.contextMenu.Tag = null;
			int c = WinHelper.UnsafeNativeMethods.GetMenuItemCount(new HandleRef(this.contextMenu, this.contextMenu.Handle));
			if (c == -1) { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
			for (int i = c - 1; i >= this.contextMenu.MenuItems.Count; i--) { WinHelper.UnsafeNativeMethods.DeleteMenu(new HandleRef(this.contextMenu, this.contextMenu.Handle), i, 0x00000400); }

			var node = this.tvFolders.FocusedNode;
			if (node != null)
			{
				var tag = (NodeTag)node.Tag;
				var parent = node.Parent != null ? node.Parent : node;
				var parentTag = (NodeTag)parent.Tag;
				var guid = ShellUtil.IID_IContextMenu;
				object obj;
				unsafe
				{
					using (var relative = tag.FullId.FindLastID())
					{
						ShellUtil.OpenFolder(parentTag.FullId).GetUIObjectOf(this.Handle, 1, new IntPtr[] { relative.DangerousGetHandle() }, ref guid, null, out obj);
					}
					var cm = (IContextMenu)obj;
					if (cm != null)
					{
						int hr = cm.QueryContextMenu(this.contextMenu.Handle, this.contextMenu.MenuItems.Count, 0, int.MaxValue, ContextMenuFlags.NORMAL);
						if (hr < 0) { Marshal.ThrowExceptionForHR(hr); }

						this.contextMenu.Tag = cm;
					}
				}
			}

		}

	}

	public class ShellTreeViewEventArgs : EventArgs
	{
		public ShellTreeViewEventArgs(TreeViewAction action, string path, ShellItemIdList folder)
		{
			this.ShellFolder = folder;
			this.Path = path;
			this.Action = action;
		}

		public TreeViewAction Action { get; private set; }
		public ShellItemIdList ShellFolder { get; private set; }
		public string Path { get; private set; }
	}

	public class ShellTreeViewCancelEventArgs : CancelEventArgs
	{
		public ShellTreeViewCancelEventArgs(TreeViewAction action, string path, ShellItemIdList folder)
		{
			this.ShellFolder = folder;
			this.Path = path;
			this.Action = action;
		}

		public TreeViewAction Action { get; private set; }
		public ShellItemIdList ShellFolder { get; private set; }
		public string Path { get; private set; }
	}
}