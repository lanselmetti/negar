using System.Runtime.InteropServices;
using System.Windows.Forms;
using Helper.Forms;

namespace System.Shell
{
	//Use QueryInterface with GUID {4434FF80-EF4C-11CE-AE65-08002B2E1262} to test for DEFAULT view

	[ComImport, Guid("37A378C0-F82D-11CE-AE65-08002B2E1262"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellFolderView
	{
		// *** IShellFolderView methods ***
		void Rearrange(IntPtr lParamSort); // use IFolderView2::SetSortColumns
		void GetArrangeParam(out IntPtr ppSort); // use IFolderView2::GetSortColumns
		void ArrangeGrid(); // select Arrange by Grid
		[PreserveSig]
		int AutoArrange(); // select Auto Arrange
		[PreserveSig]
		int GetAutoArrange(); // use IFolderView::GetAutoArrange
		unsafe void AddObject(ShellItemId* pidl, out uint puItem); // items added here may disappear (the data source is the final arbiter of which items are available to the view)
		unsafe void GetObject(out ShellItemId* ppidl, uint uItem); // use IFolderView::Item
		unsafe void RemoveObject(ShellItemId* pidl, out uint puItem); // items removed here may reappear (the data source is the final arbiter of which items are available to the view)
		void GetObjectCount(out uint puCount); // use IFolderView::ItemCount
		void SetObjectCount(uint uCount, uint dwFlags); // not implemented on Vista.  Sends LVM_SETITEMCOUNT with WPARAM=uCount and IntPtr=dwFlags to listview on XP.
		unsafe void UpdateObject(ShellItemId* pidlOld, ShellItemId* pidlNew, out uint puItem); // swaps ITEMID_CHILDs, returning new index.  Changes may be discarded (the data source is the final arbiter of which items are available to the view)
		unsafe void RefreshObject(ShellItemId* pidl, out uint puItem); // tickles the listview to re-draw the item
		void SetRedraw(bool bRedraw); // sends WM_SETREDRAW to the listview
		void GetSelectedCount(out uint puSelected); // use IFolderView2::GetSelection
		/// <remarks>GetSelectedObjects hands out const pointers to internal ITEMID_CHILD structures. The caller is expected to act on them immediately (and not cache them).  LocalFree the array, but not the items it contains.</remarks>
		unsafe void GetSelectedObjects(ShellItemId*** pppidl, uint* puItems); // use IFolderView2::GetSelection.
		void IsDropOnSource([MarshalAs(UnmanagedType.IUnknown)] object pDropTarget); // use IFolderView2::IsMoveInSameFolder
		void GetDragPoint(out POINT ppt); // returns point corresponding to drag-and-drop operation
		void GetDropPoint(out POINT ppt); // returns point corresponding to drag-and-drop operation
		void MoveIcons([MarshalAs(UnmanagedType.Interface)] IDataObject pDataObject); // not implemented
		unsafe void SetItemPos(ShellItemId* pidl, ref POINT ppt); // use IFolderView::SelectAndPositionItems
		void IsBkDropTarget([MarshalAs(UnmanagedType.IUnknown)] object pDropTarget); // returns S_OK if drag-and-drop is on the background, S_FALSE otherwise
		void SetClipboard(bool bMove); // if bMove is TRUE, this attempts to cut (edit.cut, ctrl-x) the current selection.  bMove of FALSE is not supported.
		void SetPoints([MarshalAs(UnmanagedType.Interface)] IDataObject pDataObject); // copies points of current selection in to data object.  Call is not needed if drag operation was originated by the IShellView.
		unsafe void GetItemSpacing(ITEMSPACING* pSpacing); // use IFolderView::GetSpacing instead.  GetItemSpacing returns the spacing for small and large view modes only, returning S_OK if the current view mode is is positionable, S_FALSE otherwise.
		void SetCallback([MarshalAs(UnmanagedType.Interface)] IShellFolderViewCB pNewCB, [MarshalAs(UnmanagedType.Interface)] out IShellFolderViewCB ppOldCB); // replace the IShellFolderViewCB that the IShellView uses
		void Select(uint dwFlags); // SFVS_ select flags: select all, select none, invert selection
		void QuerySupport(out uint pdwSupport); // does nothing, returns S_OK.
		void SetAutomationObject([MarshalAs(UnmanagedType.IDispatch)] object pdisp); // replaces the IShellView's internal automation object.
	}
}