using System.Runtime.InteropServices;
using Helper.Forms;

namespace System.Shell
{
	[ComImport, Guid("000214E3-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellView
	{
		//From IOleWindow
		void GetWindow([Out] out IntPtr phwnd);
		void ContextSensitiveHelp(int fEnterMode);

		[PreserveSig]
		int TranslateAccelerator([In] ref MSG pmsg);
		void EnableModeless([In, MarshalAs(UnmanagedType.Bool)] bool fEnable);
		void UIActivate([In] ShellViewUIActivation uState);
		void Refresh();
		void CreateViewWindow([In, Optional, MarshalAs(UnmanagedType.Interface)] IShellView psvPrevious, [In] ref FolderSettings pfs, [In, Optional, MarshalAs(UnmanagedType.Interface)] IShellBrowser psb, [In] ref Rect prcView, [Out, Optional] out IntPtr phWnd);
		void DestroyViewWindow();
		void GetCurrentInfo([Out] out FolderSettings pfs);
		void AddPropertySheetPages([In]  uint dwReserved, [In] AddPropSheetPageProcDelegate pfn, [In]  IntPtr lparam);
		void SaveViewState();
		unsafe void SelectItem([In, Optional] ShellItemId* pidlItem, [In] ShellViewSelectItemFlags uFlags);
		unsafe void GetItemObject([In] uint uItem, [In] Guid* riid, [Out, Optional, MarshalAs(UnmanagedType.Interface)] out object ppv);
	}
}