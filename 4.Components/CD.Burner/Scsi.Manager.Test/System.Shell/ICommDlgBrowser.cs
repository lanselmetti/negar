using System.Runtime.InteropServices;
namespace System.Shell
{
	[ComImport, Guid("000214F1-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICommDlgBrowser
	{
		[PreserveSig]
        int OnDefaultCommand([In] IShellView ppshv);
		void OnStateChange([In] IShellView ppshv, [In] CommonDialogBrowserStateChange uChange);
		[PreserveSig]
		unsafe int IncludeObject([In] IShellView ppshv, [In] ShellItemId* pidl);
	}
}