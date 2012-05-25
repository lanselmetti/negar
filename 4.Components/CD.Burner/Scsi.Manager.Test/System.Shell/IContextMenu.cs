using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Shell
{
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214e4-0000-0000-c000-000000000046")]
	public interface IContextMenu
	{
		/// <summary>You MUST check the return value!</summary>
		/// <returns>If successful, returns an HRESULT value that has its severity value set to SEVERITY_SUCCESS and its code value set to the offset of the largest command identifier that was assigned, plus one. For example, if idCmdFirst is set to 5 and you add three items to the menu with command identifiers of 5, 7, and 8, the return value should be MAKE_HRESULT(SEVERITY_SUCCESS, 0, 8 - 5 + 1). Otherwise, it returns a COM error value.</returns>
		[PreserveSig]
		int QueryContextMenu([In] IntPtr hmenu, [In] int indexMenu, [In] int idCmdFirst, [In] int idCmdLast, [In] ContextMenuFlags uFlags);
		void InvokeCommand([In, MarshalAs(UnmanagedType.LPStruct)] CMINVOKECOMMANDINFO pici);
		/// <summary>You MUST check the return value!</summary>
		[PreserveSig]
		int GetCommandString([In] IntPtr idCmd, [In] CommandStringInformation uType, IntPtr pReserved, [Out, MarshalAs(UnmanagedType.AsAny, SizeParamIndex = 4)] object pszName, [In] int cchMax);
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214f4-0000-0000-c000-000000000046")]
	public interface IContextMenu2 : IContextMenu
	{
		void HandleMenuMsg([In] int uMsg, [In] IntPtr wParam, [In] IntPtr lParam);
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("BCFCE0A0-EC17-11d0-8D10-00A0C90F2719")]
	public interface IContextMenu3 : IContextMenu2
	{
		unsafe void HandleMenuMsg2([In] int uMsg, [In] IntPtr wParam, [In] IntPtr lParam, [Out, Optional] IntPtr* plResult);
	}
}