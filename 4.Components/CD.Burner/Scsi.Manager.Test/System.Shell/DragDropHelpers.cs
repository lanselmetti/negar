using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using DragDropEffects = System.Windows.Forms.DragDropEffects;
using Helper.Forms;

namespace System.Shell
{
	[ComImport, Guid("DE5BF786-477A-11D2-839D-00C04FD918D0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDragSourceHelper
	{
		void InitializeFromBitmap([In] ref SHDRAGIMAGE pshdi, [In] IDataObject pDataObject);
		void InitializeFromWindow([In] IntPtr hwnd, [In] ref POINT ppt, [In] IDataObject pDataObject);
	}

	[ComImport, Guid("4657278B-411B-11D2-839A-00C04FD918D0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDropTargetHelper
	{
		void DragEnter([In] IntPtr hwndTarget, [In] IDataObject pDataObject, [In] ref POINT ppt, [In] DragDropEffects dwEffect);
		void DragLeave();
		void DragOver([In] ref POINT ppt, [In] DragDropEffects dwEffect);
		void Drop([In] IDataObject pDataObject, [In] ref POINT ppt, [In] DragDropEffects dwEffect);
		void Show([In] bool fShow);
	}

	[ComImport, Guid("4657278A-411B-11d2-839A-00C04FD918D0")]
	public class DragDropHelper : IDragSourceHelper, IDropTargetHelper
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void InitializeFromBitmap(ref SHDRAGIMAGE pshdi, IDataObject pDataObject);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void InitializeFromWindow(IntPtr hwnd, ref POINT ppt, IDataObject pDataObject);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void DragEnter(IntPtr hwndTarget, IDataObject pDataObject, ref POINT ppt, DragDropEffects dwEffect);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void DragLeave();
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void DragOver(ref POINT ppt, DragDropEffects dwEffect);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void Drop(IDataObject pDataObject, ref POINT ppt, DragDropEffects dwEffect);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void Show(bool fShow);
	}
}