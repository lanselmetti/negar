using System.Runtime.InteropServices;
namespace System.Shell
{
	[ComImport, Guid("D82BE2B1-5764-11D0-A96E-00C04FD705A2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellChangeNotify
	{
		[PreserveSig]
		unsafe int OnChange(SHCNE lEvent, ShellItemId* pidl1, ShellItemId* pidl2);
	}
}