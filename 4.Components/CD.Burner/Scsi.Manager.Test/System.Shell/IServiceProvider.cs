using System.Runtime.InteropServices;

namespace System.Shell
{
	[ComImport, Guid("6d5140c1-7436-11ce-8034-00aa006009fa"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IServiceProvider
	{
		[PreserveSig]
		int QueryService([In] ref Guid guidService, [In] ref Guid riid, [Out] out IntPtr ppvObject);
	}
}