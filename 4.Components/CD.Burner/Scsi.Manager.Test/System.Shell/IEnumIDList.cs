using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
namespace System.Shell
{
	[ComImport, Guid("000214F2-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumIDList
	{
		/// <returns>Returns S_OK if the method successfully retrieved the requested celt elements. This method only returns S_OK if the full count of requested items are successfully retrieved.  S_FALSE indicates that more items were requested than remained in the enumeration. The value pointed to by the pceltFetched parameter specifies the actual number of items retrieved. Note that the value will be 0 if there are no more items to retrieve. Returns a COM-defined error value otherwise.</returns>
		[PreserveSig]
		int Next([In] int celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] rgelt, [Optional, Out] out int pceltFetched);
		void Skip(int celt);
		void Reset();
		void Clone(out IEnumIDList ppenum);
	}
}