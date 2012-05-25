using System.Runtime.InteropServices;
using System.Text;
namespace System.Shell
{
	[ComImport, Guid("000214fa-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IExtractIconW
	{
		[PreserveSig]
		int GetIconLocation(IconLocationInputFlags uFlags, [Out, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 2)] StringBuilder pszIconFile, int cchMax, [Out] out int piIndex, [Out] out IconLocationReturnFlags pwFlags);
		/// <param name="nIconSize">The desired size of the icon, in pixels. The low word contains the size of the large icon, and the high word contains the size of the small icon. The size specified can be the width or height. The width of an icon always equals its height.</param>
		unsafe void Extract([MarshalAs(UnmanagedType.LPWStr)] string pszFile, int nIconIndex, [Out, Optional] IntPtr* phiconLarge, [Out, Optional] IntPtr* phiconSmall, int nIconSize);
	}
}