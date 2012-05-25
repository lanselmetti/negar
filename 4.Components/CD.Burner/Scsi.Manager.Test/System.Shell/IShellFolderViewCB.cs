using System.Runtime.InteropServices;
namespace System.Shell
{
	[ComImport, Guid("2047E320-F2A9-11CE-AE65-08002B2E1262"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellFolderViewCB
	{
		[PreserveSig]
		int MessageSFVCB(ShellFolderViewMessage uMsg, UIntPtr wParam, IntPtr lParam);
	}

	public enum ShellFolderViewMessage
	{
		//         uMsg              wParam             lParam
		MERGEMENU = 1,            // -                  LPQCMINFO
		INVOKECOMMAND = 2,        // idCmd              -
		GETHELPTEXT = 3,          // idCmd,cchMax       pszText
		GETTOOLTIPTEXT = 4,       // idCmd,cchMax       pszText
		GETBUTTONINFO = 5,        // -                  LPTBINFO
		GETBUTTONS = 6,           // idCmdFirst,cbtnMax LPTBBUTTON
		INITMENUPOPUP = 7,        // idCmdFirst,nIndex  hmenu
		FSNOTIFY = 14,            // LPCITEMIDLIST*     lEvent
		WINDOWCREATED = 15,       // hwnd               -
		GETDETAILSOF = 23,        // iColumn            DETAILSINFO*
		COLUMNCLICK = 24,         // iColumn            -
		QUERYFSNOTIFY = 25,       // -                  SHChangeNotifyEntry *
		DEFITEMCOUNT = 26,        // -                  UINT*
		DEFVIEWMODE = 27,         // -                  FOLDERVIEWMODE*
		UNMERGEMENU = 28,         // -                  hmenu
		UPDATESTATUSBAR = 31,     // fInitialize        -
		BACKGROUNDENUM = 32,      // -                  -
		DIDDRAGDROP = 36,         // dwEffect           IDataObject *
		SETISFV = 39,             // -                  IShellFolderView*
		THISIDLIST = 41,          // -                  LPITMIDLIST*
		ADDPROPERTYPAGES = 47,    // -                  SFVM_PROPPAGE_DATA *
		BACKGROUNDENUMDONE = 48,  // -                  -
		GETNOTIFY = 49,           // LPITEMIDLIST*      LONG*
		// Note: QUERYSTANDARDVIEWS NOT USED: must use GETVIEWDATA instead
		GETSORTDEFAULTS = 53,     // iDirection         iParamSort
		SIZE = 57,                // -                  -
		GETZONE = 58,             // -                  DWORD*
		GETPANE = 59,             // Pane ID            DWORD*
		GETHELPTOPIC = 63,        // -                  SFVM_HELPTOPIC_DATA *
		GETANIMATION = 68,        // HINSTANCE *        WCHAR *


		SELECTIONCHANGED = 8,
		DRAWMENUITEM = 9,
		MEASUREMENUITEM = 10,
		EXITMENULOOP = 11,
		VIEWRELEASE = 12,
		GETNAMELENGTH = 13,
		WINDOWCLOSING = 16,
		LISTREFRESHED = 17,
		WINDOWFOCUSED = 18,
		REGISTERCOPYHOOK = 20,
		COPYHOOKCALLBACK = 21,
		UNMERGEFROMMENU = 28,
		ADDINGOBJECT = 29,
		REMOVINGOBJECT = 30,
		GETCOMMANDDIR = 33,
		GETCOLUMNSTREAM = 34,
		CANSELECTALL = 35,
		ISSTRICTREFRESH = 37,
		ISCHILDOBJECT = 38,
		GETEXTVIEWS = 40,
		GET_CUSTOMVIEWINFO = 77,
		ENUMERATEDITEMS = 79,
		GET_VIEW_DATA = 80,
		GET_WEBVIEW_LAYOUT = 82,
		GET_WEBVIEW_CONTENT = 83,
		GET_WEBVIEW_TASKS = 84,
		GET_WEBVIEW_THEME = 86,
		GETDEFERREDVIEWSETTINGS = 92,
	}
}