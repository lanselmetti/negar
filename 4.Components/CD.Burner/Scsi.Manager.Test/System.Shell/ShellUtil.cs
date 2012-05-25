using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Text;
using System.Windows.Forms;
using Helper.Forms;
using System.Diagnostics;

namespace System.Shell
{
	public static class ShellUtil
	{
		public static readonly Guid IID_IShellBrowser = ShellUtil.GetGuid(typeof(IShellBrowser));
		public static readonly Guid IID_ICommDlgBrowser = ShellUtil.GetGuid(typeof(ICommDlgBrowser));
		public static readonly Guid IID_IProfferService = ShellUtil.GetGuid(typeof(IProfferService));
		public static readonly Guid IID_IStream = ShellUtil.GetGuid(typeof(IStream));
		public static readonly Guid IID_IShellFolder = ShellUtil.GetGuid(typeof(IShellFolder));
		public static readonly Guid IID_IShellView = ShellUtil.GetGuid(typeof(IShellView));
		public static readonly Guid IID_IExtractIconW = GetGuid(typeof(IExtractIconW));
		public static readonly Guid IID_IContextMenu = GetGuid(typeof(IContextMenu));
		public static readonly Guid IID_IPersistFolder2 = GetGuid(typeof(IPersistFolder2));
		public static readonly Guid IID_IBindCtx = GetGuid(typeof(IBindCtx));

		private static Guid GetGuid(Type type) { return new Guid(((GuidAttribute)Attribute.GetCustomAttribute(type, typeof(GuidAttribute), false)).Value); }

		public static IShellFolder OpenFolder(ShellItemIdList fullId)
		{
			object folderObj;
			var guid = ShellUtil.IID_IShellFolder;
			if (ShellItemIdList.Desktop.Equals(fullId)) { folderObj = ShellFolders.Desktop; }
			else { ShellFolders.Desktop.BindToObject(fullId, null, ref guid, out folderObj); }
			return (IShellFolder)folderObj;
		}

		public static IShellFolder SHGetDesktopFolder() { IShellFolder result; UnsafeNativeMethods.SHGetDesktopFolder(out result); return result; }

		public static int SHChangeNotifyRegister(IWin32Window window, ShellNotifySource fSources, ShellChangeNotificationEvents fEvents, int wMsg, SHChangeNotifyEntry[] pshcne)
		{
			unsafe
			{
				fixed (SHChangeNotifyEntry* pArr = pshcne)
				{
					int result = UnsafeNativeMethods.SHChangeNotifyRegister(new HandleRef(window, window.Handle), fSources, fEvents, wMsg, pshcne.Length, pArr);
					if (result == 0) { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
					return result;
				}
			}
		}

		public static void SHChangeNotifyDeregister(int ulID) { if (!UnsafeNativeMethods.SHChangeNotifyDeregister(ulID)) { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); } }

		public static Icon SHGetFileIcon(IWin32Window window, IShellFolder parentFolder, ShellItemIdList filePath, FileAttributes? fileAttributes, out int iconIndex, bool smallIcon)
		{
#if true
			ShellItemIdList idChild;
			if (parentFolder == null) { parentFolder = (IShellFolder)SHBindToParent(filePath, IID_IShellFolder, out idChild); }
			else { idChild = filePath; }
			IExtractIconW extractIcon;
			unsafe
			{
				bool success = false;
				try
				{
					idChild.DangerousAddRef(ref success);
					Trace.Assert(success);
					var pidls = new IntPtr[] { idChild.DangerousGetHandle() };
					var guid = IID_IExtractIconW;
					object extractIconObject;
					parentFolder.GetUIObjectOf(window != null ? window.Handle : IntPtr.Zero, pidls.Length, pidls, ref guid, null, out extractIconObject);
					extractIcon = (IExtractIconW)extractIconObject;
				}
				finally { if (success) { idChild.DangerousRelease(); } }

				var sbIconFile = new StringBuilder(260);
				IconLocationReturnFlags flags;
				int hr = extractIcon.GetIconLocation(IconLocationInputFlags.ForShell | IconLocationInputFlags.Async, sbIconFile, sbIconFile.Capacity, out iconIndex, out flags);
				if (hr == unchecked((int)0x8000000A))
				{ hr = extractIcon.GetIconLocation(IconLocationInputFlags.ForShell | IconLocationInputFlags.DefaultIcon, sbIconFile, sbIconFile.Capacity, out iconIndex, out flags); }
				if (hr != 0) { Marshal.ThrowExceptionForHR(hr); }
				IntPtr hIcon = IntPtr.Zero;
				extractIcon.Extract(sbIconFile.ToString(), iconIndex, smallIcon ? null : &hIcon, smallIcon ? &hIcon : null, 0x00100020);

				using (var icon = Icon.FromHandle(hIcon))
				{
					var dup = (Icon)icon.Clone();
					WinHelper.UnsafeNativeMethods.DestroyIcon(hIcon);
					return dup;
				}
			}
#else
			var output = new ShellFileInfo();
			IntPtr result = UnsafeNativeMethods.SHGetFileInfo(filePath, fileAttributes.GetValueOrDefault(), out output, (uint)Marshal.SizeOf(typeof(ShellFileInfo)), ShellFileInformationType.Icon | ShellFileInformationType.Pidl | ShellFileInformationType.ShellIconSize | (smallIcon ? ShellFileInformationType.SmallIcon : ShellFileInformationType.LargeIcon) | (fileAttributes != null ? ShellFileInformationType.UseFileAttributes : 0));
			if (result != IntPtr.Zero)
			{
				if (output.hIcon != IntPtr.Zero)
				{
					iconIndex = output.iIcon;
					using (var icon = Icon.FromHandle(output.hIcon))
					{
						var dup = (Icon)icon.Clone();
						WinHelper.UnsafeNativeMethods.DestroyIcon(output.hIcon);
						return dup;
					}
				}
				else { iconIndex = -1; return null; }
			}
			else { iconIndex = -1; if (Marshal.GetLastWin32Error() != 0) { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); } return null; }
#endif
		}

		public static ShellItemIdList SHParseDisplayName(string name, IBindCtx bindContext, ref SFGAO flags) { ShellItemIdList result; UnsafeNativeMethods.SHParseDisplayName(name, bindContext, out result, flags, out flags); return result; }

		public static string SHTryGetPathFromIDList(ShellItemIdList id) { var sb = new StringBuilder(260); return UnsafeNativeMethods.SHGetPathFromIDList(id, sb) ? sb.ToString() : null; }

		public static ShellItemIdList SHGetRealIDL(IShellFolder folder, ShellItemIdList idlSimple) { ShellItemIdList result; UnsafeNativeMethods.SHGetRealIDL(folder, idlSimple, out result); return result; }

		public static object SHBindToParent(ShellItemIdList pidl, Guid riid, out ShellItemIdList ppidlLast) { object ppv; unsafe { ShellItemId* p; UnsafeNativeMethods.SHBindToParent(pidl, ref riid, out ppv, out p); ppidlLast = new ShellItemIdList((IntPtr)p, false); } return ppv; }

		public static IShellView SHCreateShellFolderView(ref ShellFolderViewCreate pcsfv) { IShellView result; UnsafeNativeMethods.SHCreateShellFolderView(ref pcsfv, out result); return result; }

		public static ShellItemIdList SHGetFolderLocation(IntPtr hwndOwner, Environment.SpecialFolder nFolder, IntPtr hToken, int dwReserved) { ShellItemIdList result; UnsafeNativeMethods.SHGetFolderLocation(hwndOwner, nFolder, hToken, dwReserved, out result); return result; }

		public static ShellItemIdList SHGetSpecialFolderLocation(IntPtr hwndOwner, Environment.SpecialFolder nFolder) { ShellItemIdList result; UnsafeNativeMethods.SHGetSpecialFolderLocation(hwndOwner, nFolder, out result); return result; }

#if OLD
		public static IExtractIconW GetIExtractIconW(IWin32Window owner, IShellFolder folder, ShellItemIdList itemIdList)
		{
			bool success = false;
			if (itemIdList != null) { itemIdList.DangerousAddRef(ref success); }
			try
			{
				unsafe
				{
					object pExtractIcon;
					var guid = IID_IExtractIconW;
					folder.GetUIObjectOf(owner != null ? owner.Handle : IntPtr.Zero, itemIdList != null ? 1 : 0, itemIdList != null ? new IntPtr[1] { itemIdList.DangerousGetHandle() } : null, ref guid, null, out pExtractIcon);
					return (IExtractIconW)pExtractIcon;
				}
			}
			finally { if (itemIdList != null) { if (success) { itemIdList.DangerousRelease(); } } }
		}

		public static IContextMenu GetIContextMenu(IShellFolder parent, ShellItemIdList[] pidls)
		{
			unsafe
			{
				object icontextMenuPtr;
				var idls = pidls != null ? new IntPtr[pidls.Length] : null;
				try
				{
					if (idls != null)
					{
						for (int i = 0; i < idls.Length; i++)
						{
							bool success = false;
							pidls[i].DangerousAddRef(ref success);
							System.Diagnostics.Trace.Assert(success);
							idls[i] = pidls[i].DangerousGetHandle();
						}
					}
					var guid = GetGuid(typeof(IContextMenu));
					parent.GetUIObjectOf(IntPtr.Zero, idls.Length, idls, ref guid, null, out icontextMenuPtr);
					return (IContextMenu)icontextMenuPtr;
				}
				finally { if (idls != null) { for (int i = 0; i < idls.Length; i++) { if (idls[i] != IntPtr.Zero) { pidls[i].DangerousRelease(); } } } }
			}
		}

		public static void QueryContextMenu(Menu menu, int idCmdFirst, int idCmdLast, ContextMenuFlags flags, IShellFolder parent, ShellItemIdList[] pidls)
		{
			int index = menu.MenuItems.Count;
			var handleRef = new HandleRef(menu, menu.Handle);
			int prevItemCount = Menus.GetMenuItemCount(handleRef);
			var iContextMenu = GetIContextMenu(parent, pidls);
			int endOfAssignedID = iContextMenu.QueryContextMenu(menu.Handle, index, idCmdFirst, idCmdLast, flags);
			var insertedItems = new MenuItem[Menus.GetMenuItemCount(handleRef) - prevItemCount];

			for (int i = 0; i < insertedItems.Length; i++)
			{
				var item = Menus.CreateManagedMenuItem(menu, i + index, true);
				item.Click += (s, e) => { iContextMenu.InvokeCommand(new CMINVOKECOMMANDINFOEX() { lpVerbW = item.Text, fMask = CMIC.UNICODE }); };
				insertedItems[i] = item;
			}

			for (int i = insertedItems.Length - 1; i >= 0; i--)
			{ Menus.DeleteMenuItem(handleRef, index + i, true); }

			menu.MenuItems.AddRange(insertedItems);
		}
#endif
		[SuppressUnmanagedCodeSecurity]
		private static class UnsafeNativeMethods
		{
			[DllImport("Shell32.dll", SetLastError = true)]
			public static extern unsafe int SHChangeNotifyRegister(HandleRef hwnd, ShellNotifySource fSources, ShellChangeNotificationEvents fEvents, int wMsg, int cEntries, SHChangeNotifyEntry* pshcne);

			[DllImport("Shell32.dll", SetLastError = true)]
			public static extern bool SHChangeNotifyDeregister(int ulID);

			[DllImport("Shell32.dll", SetLastError = false, PreserveSig = false)]
			public static extern unsafe void SHBindToParent(ShellItemIdList pidl, [In] ref Guid riid, [Out, MarshalAs(UnmanagedType.Interface)] out object ppv, out ShellItemId* ppidlLast);

			[DllImport("Shell32.dll", SetLastError = false, PreserveSig = false)]
			public static extern void SHGetDesktopFolder([Out, MarshalAs(UnmanagedType.Interface)] out IShellFolder ppshf);

			[DllImport("Shell32.dll", SetLastError = false, PreserveSig = false)]
			public static extern void SHParseDisplayName([MarshalAs(UnmanagedType.LPTStr), In] string pszName, [In] IBindCtx pbc, [Out] out ShellItemIdList ppidl, [In] SFGAO sfgaoIn, [Out] out SFGAO psfgaoOut);

			[DllImport("Shell32.dll", SetLastError = true)]
			public static extern IntPtr SHGetFileInfo(ShellItemIdList pszPath, FileAttributes dwFileAttributes, out ShellFileInfo psfi, uint cbFileInfo, ShellFileInformationType uFlags);

			[DllImport("Shell32.dll", SetLastError = false, PreserveSig = false)]
			public static extern void SHGetRealIDL(IShellFolder psf, ShellItemIdList pidlSimple, out ShellItemIdList ppidlReal);

			[DllImport("Shell32.dll", SetLastError = false, PreserveSig = true)]
			public static extern bool SHGetPathFromIDList(ShellItemIdList pidl, [Out] StringBuilder pszPath);

			[DllImport("Shell32.dll", SetLastError = false, PreserveSig = false)]
			public static extern void SHCreateShellFolderView([In] ref ShellFolderViewCreate pcsfv, [Out, MarshalAs(UnmanagedType.Interface)] out IShellView ppsv);

			[DllImport("Shell32.dll", SetLastError = false, PreserveSig = false)]
			public static extern void SHCreateShellFolderViewEx([In, MarshalAs(UnmanagedType.LPStruct)] CreateShellFolderViewOptions pcsfv, [Out, MarshalAs(UnmanagedType.Interface)] out IShellView ppsv);

			[DllImport("Shell32.dll", SetLastError = false, PreserveSig = false)]
			public static extern void SHGetFolderLocation(IntPtr hwndOwner, Environment.SpecialFolder nFolder, IntPtr hToken, int dwReserved, out ShellItemIdList ppidl);

			[DllImport("Shell32.dll", SetLastError = false, PreserveSig = false)]
			public static extern void SHGetSpecialFolderLocation(IntPtr hwndOwner, Environment.SpecialFolder nFolder, out ShellItemIdList ppidl);


#if OLD
			[DllImport("User32.dll", SetLastError = true)]
			public static extern bool DestroyMenu(IntPtr hMenu);

			[DllImport("User32.dll", SetLastError = true)]
			public static extern IntPtr CreatePopupMenu();
#endif
		}
	}
}