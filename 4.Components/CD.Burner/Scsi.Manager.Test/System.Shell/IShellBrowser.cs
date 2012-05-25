using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Helper.Forms;

namespace System.Shell
{
	[ComImport, Guid("000214E2-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellBrowser
	{
		//From IOleWindow
		[PreserveSig]
		int GetWindow([Out] out IntPtr phwnd);
		[PreserveSig]
		int ContextSensitiveHelp(int fEnterMode);

		[PreserveSig]
		int InsertMenusSB([In] IntPtr hmenuShared, [In, Out] ref OleMenuGroupWidths lpMenuWidths);
		[PreserveSig]
		int SetMenuSB([In, Optional] IntPtr hmenuShared, [In, Optional] IntPtr holemenuRes, [In, Optional] IntPtr hwndActiveObject);
		[PreserveSig]
		int RemoveMenusSB([In] IntPtr hmenuShared);
		[PreserveSig]
		int SetStatusTextSB([In, Optional] string pszStatusText);
		[PreserveSig]
		int EnableModelessSB([In] bool fEnable);
		[PreserveSig]
		int TranslateAcceleratorSB([In] ref MSG pmsg, [In] short wID);
		[PreserveSig]
		unsafe int BrowseObject([In, Optional] ShellItemId* pidl, [In] SBSP wFlags);
		[PreserveSig]
		int GetViewStateStream([In] int grfMode, [Out, Optional, MarshalAs(UnmanagedType.Interface)] out IStream ppStrm);
		[PreserveSig]
		int GetControlWindow([In] FolderControlWindow id, [Out, Optional] out IntPtr phwnd);
		[PreserveSig]
		unsafe int SendControlMsg([In] FolderControlWindow id, [In] int uMsg, [In] IntPtr wParam, [In] IntPtr lParam, [Out] IntPtr* pret);
		[PreserveSig]
		int QueryActiveShellView([Out, Optional, MarshalAs(UnmanagedType.Interface)] out IShellView ppshv);
		[PreserveSig]
		int OnViewWindowActive([In, Optional, MarshalAs(UnmanagedType.Interface)] IShellView pshv);
		[PreserveSig]
		int SetToolbarItems([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TBBUTTON[] lpButtons, [In] int nButtons, [In] FCT uFlags);
	}
}