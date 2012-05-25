using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
namespace System.Shell
{
	[ComImport, Guid("000214E6-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellFolder
	{
		void ParseDisplayName([In, Optional] IntPtr hwnd, [In, Optional, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc, [In] string pszDisplayName, [Out] out int pchEaten, [Out, Optional] out ShellItemIdList ppidl, [In, Out] ref SFGAO pdwAttributes);
		/// <param name="grfFlags">SHCONTF</param>
		/// <param name="ppenumIDList">IEnumIDList</param>
		void EnumObjects([In, Optional] IntPtr hWnd, [In] SHCONTF grfFlags, [Out, Optional, MarshalAs(UnmanagedType.Interface)] out IEnumIDList ppenumIDList);
		void BindToObject([In] ShellItemIdList pidl, [In, Optional, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc, [In] ref Guid riid, [Out, Optional, MarshalAs(UnmanagedType.Interface)] out object ppv);
		void BindToStorage([In] ShellItemIdList pidl, [In, Optional, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc, [In] ref Guid riid, [Out, Optional, MarshalAs(UnmanagedType.Interface)] out object ppv);
		[PreserveSig]
		int CompareIDs([In] IntPtr lParam, [In] ShellItemIdList pidl1, [In] ShellItemIdList pidl2);
		void CreateViewObject([In, Optional] IntPtr hWndOwner, [In] ref Guid riid, [Out, Optional, MarshalAs(UnmanagedType.Interface)] out object ppv);
		void GetAttributesOf([In] int cidl, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] apidl, [In, Out] ref SFGAO rgfInOut);
		unsafe void GetUIObjectOf([In, Optional] IntPtr hWndOwner, [In] int cidl, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] apidl, [In] ref Guid riid, [In, Out] int* rgfReserved, [Out, Optional, MarshalAs(UnmanagedType.Interface)] out object ppv);
		/// <param name="pName">out STRRET</param>
		void GetDisplayNameOf([In] ShellItemIdList pidl, [In] SHGDN uFlags, [Out] out STRRET pName);
		void SetNameOf([In, Optional] IntPtr hWnd, [In] ShellItemIdList pidl, [In] string pszName, [In] SHGDN uFlags, [Out, Optional] out ShellItemIdList ppidlOut);
	}

	public static class ShellFolders
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static IShellFolder __Desktop;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static IShellFolder __Computer;

		public static IShellFolder Desktop { get { if (__Desktop == null) { Interlocked.CompareExchange(ref __Desktop, ShellUtil.SHGetDesktopFolder(), null); } return __Desktop; } }

		public static IShellFolder Computer
		{
			get
			{
				if (__Computer == null)
				{
					object computerObj;
					var guid = ShellUtil.IID_IShellFolder;
					Desktop.BindToObject(ShellItemIdList.Computer, null, ref guid, out computerObj);
					Interlocked.CompareExchange(ref __Computer, (IShellFolder)computerObj, null);
				}
				return __Computer;
			}
		}

		public static ShellItemIdList[] EnumObjects(IShellFolder folder, IntPtr hWnd, SHCONTF grfFlags)
		{
			IEnumIDList enumerator;
			folder.EnumObjects(hWnd, grfFlags, out enumerator);
			var items = new System.Collections.Generic.List<ShellItemIdList>();
			var buffer = new IntPtr[1024];
			int fetched;
			for (; ; )
			{
				int hr = enumerator.Next(buffer.Length, buffer, out fetched);
				if (hr != 0 && hr != 1) { Marshal.ThrowExceptionForHR(hr); }
				for (int i = 0; i < fetched; i++) { items.Add(new ShellItemIdList(buffer[i], true)); }
				if (hr != 0) { break; }
				if (fetched == buffer.Length) { buffer = new IntPtr[2 * buffer.Length]; }
			}
			return items.ToArray();
		}

		public static int CompareIDs(IShellFolder folder, ShellItemIdList left, ShellItemIdList right, ShellIdentifierComparison comparison, ShellIdentifierComparisonModifier modifier)
		{
			int c = folder.CompareIDs((IntPtr)((int)comparison | (int)modifier), left, right);
			if (c < 0) { Marshal.ThrowExceptionForHR(c); }
			return unchecked((short)(c & 0x0000FFFF));
		}

		internal static string GetPersistFolderPath(IShellFolder folder) { ShellItemIdList id; ((IPersistFolder2)folder).GetCurFolder(out id); using (id) { return id.ToString(); } }
	}
}