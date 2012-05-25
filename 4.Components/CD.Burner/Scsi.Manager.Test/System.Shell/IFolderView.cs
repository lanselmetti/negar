using System.Runtime.InteropServices;
using Helper.Forms;

namespace System.Shell
{
	[ComImport, Guid("cde725b0-ccc9-4519-917e-325d72fab4ce"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFolderView
	{
		void GetCurrentViewMode([Out][In] ref FolderViewMode pViewMode);
		void SetCurrentViewMode([In] FolderViewMode ViewMode);
		void GetFolder([In] ref Guid riid, [Out, MarshalAs(UnmanagedType.Interface)] out object ppv);
		void Item([In] int iItemIndex, [Out] out ShellItemIdList ppidl);
		void ItemCount([In] int uFlags, [Out] out int pcItems);
		void Items([In] int uFlags, [In] ref Guid riid, [Out] out IntPtr ppv);
		void GetSelectionMarkedItem([Out] out int piItem);
		void GetFocusedItem([Out] out int piItem);
		void GetItemPosition([In] ShellItemIdList pidl, [Out] out POINT ppt);
		void GetSpacing([Out][In] ref POINT ppt);
		void GetDefaultSpacing([Out] out POINT ppt);
		void GetAutoArrange();
		void SelectItem([In] int iItem, [In] int dwFlags);
		unsafe void SelectAndPositionItems([In] int cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ShellItemId*[] apidl, [In] ref POINT apt, [In] int dwFlags);
	}
}