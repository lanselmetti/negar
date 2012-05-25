using System.Runtime.InteropServices;
namespace System.Shell
{
	[ComImport, Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IShellItem
	{
		void BindToHandler([In, MarshalAs(UnmanagedType.Interface)] IntPtr pbc, [In] ref Guid bhid, [In] ref Guid riid, [Out, MarshalAs(UnmanagedType.Interface)] out object ppv);
		void GetParent([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);
		void GetDisplayName([In] ShellItemGetDisplayName sigdnName, [MarshalAs(UnmanagedType.LPWStr)] out string ppszName);
		void GetAttributes([In] uint sfgaoMask, out uint psfgaoAttribs);
		void Compare([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi, [In] uint hint, out int piOrder);
	}

}