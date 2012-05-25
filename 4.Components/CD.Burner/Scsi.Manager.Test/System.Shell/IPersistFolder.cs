using System.Runtime.InteropServices;
namespace System.Shell
{
	[ComImport, Guid("000214EA-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistFolder : IPersist
    {
		new void GetClassID(out Guid pClassID);
		void Initialize(ShellItemIdList pidl);
    };

	[ComImport, Guid("1AC3D9F0-175C-11d1-95BE-00609797EA4F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPersistFolder2 : IPersistFolder
	{
		new void GetClassID(out Guid pClassID);
		new void Initialize(ShellItemIdList pidl);
		void GetCurFolder(out ShellItemIdList ppidl);
	}
}