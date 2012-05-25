using System.Runtime.InteropServices;
namespace System.Shell
{
	[ComImport, Guid("0000010c-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPersist
	{
		void GetClassID(out Guid pClassID);
	}
}