using System.Runtime.InteropServices;

namespace System.Shell
{
    [ComImport, Guid("cb728b20-f786-11ce-92ad-00aa00a74cd0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IProfferService
    {
		[PreserveSig]
		int ProfferService([In] ref Guid guidService, [In] IServiceProvider psp, [Out] out int pdwCookie);
		[PreserveSig]
		int RevokeService([In] int dwCookie);
    }
}