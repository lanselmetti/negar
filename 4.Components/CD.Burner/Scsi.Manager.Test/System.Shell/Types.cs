using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Helper.Forms;

namespace System.Shell
{
	public class ItemFilterEventArgs : CancelEventArgs
	{
		public ItemFilterEventArgs(ShellItemIdList parentFolder, ShellItemIdList relativeID) { this.ParentId = parentFolder; this.RelativeId = relativeID; }
		public ShellItemIdList ParentId { get; private set; }
		public ShellItemIdList RelativeId { get; private set; }
	}

	internal struct CursorChange : IDisposable
	{
		private Control control;
		private Cursor oldCursor;

		public CursorChange(Control control, Cursor newCursor)
		{
			this.control = control;
			this.oldCursor = control == null ? Cursor.Current : control.Cursor;
			var p = Cursor.Position;
			if (control != null)
			{
				var child = control;
				for (; ; )
				{
					var c = child.GetChildAtPoint(child.PointToClient(p));
					if (c == null) { break; }
					child = c;
				}
				if (child.Cursor == Cursors.Default)
				{ control.Cursor = newCursor; }
				else { this.oldCursor = null; }
			}
			else { if (Cursor.Current == Cursors.Default) { Cursor.Current = newCursor; } else { this.oldCursor = null; } }
		}

		public void Dispose() { if (this.oldCursor != null) { if (control != null) { control.Cursor = this.oldCursor; } else { Cursor.Current = this.oldCursor; } } this.oldCursor = null; }
	}

	public enum CommonDialogBrowserStateChange
	{
		SETFOCUS = 0x00000000,
		KILLFOCUS = 0x00000001,
		SELCHANGE = 0x00000002,
		RENAME = 0x00000003,
		STATECHANGE = 0x00000004,
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ShellFileInfo
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public const ushort DISPLAY_NAME_LENGTH = 260;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public const ushort TYPE_NAME_LENGTH = 260;
		public IntPtr hIcon;
		public int iIcon;
		public uint dwAttributes;
		//[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		private unsafe fixed char szDisplayName[DISPLAY_NAME_LENGTH];
		//[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		private unsafe fixed char szTypeName[TYPE_NAME_LENGTH];
		public string DisplayName
		{
			get
			{
				unsafe
				{
					fixed (char* pName = this.szDisplayName)
					{
						if (pName[DISPLAY_NAME_LENGTH - 1] != '\0') { return Marshal.PtrToStringUni((IntPtr)pName, DISPLAY_NAME_LENGTH); }
						else { return Marshal.PtrToStringUni((IntPtr)pName); }
					}
				}
			}
		}
		public string TypeName
		{
			get
			{
				unsafe
				{
					fixed (char* pName = this.szTypeName)
					{
						if (pName[DISPLAY_NAME_LENGTH - 1] != '\0') { return Marshal.PtrToStringUni((IntPtr)pName, DISPLAY_NAME_LENGTH); }
						else { return Marshal.PtrToStringUni((IntPtr)pName); }
					}
				}
			}
		}
	}

	public enum ShellIdentifierComparison
	{
		Default = 0,
	}

	public enum ShellViewUIActivation
	{
		Deactivate = 0,
		ActivateNoFocus = 1,
		ActivateFocus = 2,
		InPlaceActivate = 3
	}

	public enum ShellIdentifierComparisonModifier
	{
		None = 0,
		AllFields = unchecked((int)0x80000000),
		CanonicalOnly = 0x10000000,
	}

	[Flags]
	public enum ShellFileInformationType : int
	{
		LargeIcon = 0x000000000,     // get large icon
		Icon = 0x000000100,     // get icon
		DisplayName = 0x000000200,     // get display name
		TypeName = 0x000000400,     // get type name
		Attributes = 0x000000800,     // get attributes
		IconLocation = 0x000001000,     // get icon location
		ExeType = 0x000002000,     // return exe type
		SysIconIndex = 0x000004000,     // get system icon index
		LinkOverlay = 0x000008000,     // put a link overlay on icon
		Selected = 0x000010000,     // show icon in selected state
		AttrSpecified = 0x000020000,     // get only specified attributes
		SmallIcon = 0x000000001,     // get small icon
		OpenIcon = 0x000000002,     // get open icon
		ShellIconSize = 0x000000004,     // get shell size icon
		Pidl = 0x000000008,     // pszPath is a pidl
		UseFileAttributes = 0x000000010,     // use passed dwFileAttribute
		AddOverlays = 0x000000020,     // apply the appropriate overlays
		OverlayIndex = 0x000000040,     // Get the index of the overlay
	}

	[Flags]
	public enum IconLocationInputFlags
	{
		None = 0,
		OpenIcon = 0x0001,            // allows containers to specify an "open" look
		ForShell = 0x0002,            // icon is to be displayed in a ShellFolder
		Async = 0x0020,            // this is an async extract, return E_PENDING
		DefaultIcon = 0x0040,            // get the default icon location if the final one takes too long to get
		ForShortcut = 0x0080,            // the icon is for a shortcut to the object
		CheckShield = 0x0200,            // return GIL_SHIELD or GIL_FORCENOSHIELD, don't block if GIL_ASYNC is set
	}

	[Flags]
	public enum IconLocationReturnFlags
	{
		None = 0,
		SimulateDoc = 0x0001,      // simulate this document icon for this
		PerInstance = 0x0002,      // icons from this class are per instance (each file has its own)
		PerClass = 0x0004,      // icons from this class per class (shared for all files of this type)
		NotFileName = 0x0008,      // location is not a filename, must call ::ExtractIcon
		DontCache = 0x0010,      // this icon should not be cached
		Shield = 0x0200,      // icon should be "stamped" with the LUA shield
		ForceNoShield = 0x0400,      // icon must *not* be "stamped" with the LUA shield
	}

	public struct SHChangeNotifyEntry { public unsafe ShellItemId* pidl; /*[MarshalAs(UnmanagedType.Bool)] public bool fRecursive;*/ public int fRecursive; }

	[Flags]
	public enum ShellChangeNotificationEvents
	{
		RenameItem = 0x00000001,
		Create = 0x00000002,
		Delete = 0x00000004,
		MakeDir = 0x00000008,
		RemoveDir = 0x00000010,
		MediaInserted = 0x00000020,
		MediaRemoved = 0x00000040,
		DriveRemoved = 0x00000080,
		DriveAdd = 0x00000100,
		NetShare = 0x00000200,
		NetUnshare = 0x00000400,
		Attributes = 0x00000800,
		UpdateDir = 0x00001000,
		UpdateItem = 0x00002000,
		ServerDisconnect = 0x00004000,
		UpdateImage = 0x00008000,
		DriveAddGui = 0x00010000,
		RenameFolder = 0x00020000,
		FreeSpace = 0x00040000,
		ExtendedEvent = 0x04000000,
		AssocChanged = 0x08000000,
		DiskEvents = 0x0002381F,
		GlobalEvents = 0x0C0581E0, // Events that dont match pidls first
		AllEvents = 0x7FFFFFFF,
		Interrupt = unchecked((int)0x80000000), // The presence of this flag indicates that the event was generated by an interrupt.  It is stripped out before the clients of SHCNNotify_ see it.
	}

	[Flags]
	public enum ShellNotifySource
	{
		None = 0,
		InterruptLevel = 0x0001,
		ShellLevel = 0x0002,
		RecursiveInterrupt = 0x1000,
		NewDelivery = 0x8000,
	}

	public enum SHCNE
	{
		RENAMEITEM = 0x00000001,
		CREATE = 0x00000002,
		DELETE = 0x00000004,
		MKDIR = 0x00000008,
		RMDIR = 0x00000010,
		MEDIAINSERTED = 0x00000020,
		MEDIAREMOVED = 0x00000040,
		DRIVEREMOVED = 0x00000080,
		DRIVEADD = 0x00000100,
		NETSHARE = 0x00000200,
		NETUNSHARE = 0x00000400,
		ATTRIBUTES = 0x00000800,
		UPDATEDIR = 0x00001000,
		UPDATEITEM = 0x00002000,
		SERVERDISCONNECT = 0x00004000,
		UPDATEIMAGE = 0x00008000,
		DRIVEADDGUI = 0x00010000,
		RENAMEFOLDER = 0x00020000,
		FREESPACE = 0x00040000,
	}

	public enum FolderControlWindow
	{
		Status = 0x0001,
		ToolBar = 0x0002,
		TreeView = 0x0003,
		InternetBar = 0x0006,
		ProgressBar = 0x0008,
	}

	public enum ConstantIdList
	{
		DESKTOP = 0x0000,        // <desktop>
		INTERNET = 0x0001,        // Internet Explorer (icon on desktop)
		PROGRAMS = 0x0002,        // Start Menu\Programs
		CONTROLS = 0x0003,        // My Computer\Control Panel
		PRINTERS = 0x0004,        // My Computer\Printers
		PERSONAL = 0x0005,        // My Documents
		FAVORITES = 0x0006,        // <user name>\Favorites
		STARTUP = 0x0007,        // Start Menu\Programs\Startup
		RECENT = 0x0008,        // <user name>\Recent
		SENDTO = 0x0009,        // <user name>\SendTo
		BITBUCKET = 0x000a,        // <desktop>\Recycle Bin
		STARTMENU = 0x000b,        // <user name>\Start Menu
		MYDOCUMENTS = PERSONAL, //  Personal was just a silly name for My Documents
		MYMUSIC = 0x000d,        // "My Music" folder
		MYVIDEO = 0x000e,        // "My Videos" folder
		DESKTOPDIRECTORY = 0x0010,        // <user name>\Desktop
		DRIVES = 0x0011,        // My Computer
		NETWORK = 0x0012,        // Network Neighborhood (My Network Places)
		NETHOOD = 0x0013,        // <user name>\nethood
		FONTS = 0x0014,        // windows\fonts
		TEMPLATES = 0x0015,
		COMMON_STARTMENU = 0x0016,        // All Users\Start Menu
		COMMON_PROGRAMS = 0X0017,        // All Users\Start Menu\Programs
		COMMON_STARTUP = 0x0018,        // All Users\Startup
		COMMON_DESKTOPDIRECTORY = 0x0019,        // All Users\Desktop
		APPDATA = 0x001a,        // <user name>\Application Data
		PRINTHOOD = 0x001b,        // <user name>\PrintHood
		LOCAL_APPDATA = 0x001c,        // <user name>\Local Settings\Applicaiton Data (non roaming)
		ALTSTARTUP = 0x001d,        // non localized startup
		COMMON_ALTSTARTUP = 0x001e,        // non localized common startup
		COMMON_FAVORITES = 0x001f,
		INTERNET_CACHE = 0x0020,
		COOKIES = 0x0021,
		HISTORY = 0x0022,
		COMMON_APPDATA = 0x0023,        // All Users\Application Data
		WINDOWS = 0x0024,        // GetWindowsDirectory()
		SYSTEM = 0x0025,        // GetSystemDirectory()
		PROGRAM_FILES = 0x0026,        // C:\Program Files
		MYPICTURES = 0x0027,        // C:\Program Files\My Pictures
		PROFILE = 0x0028,        // USERPROFILE
		SYSTEMX86 = 0x0029,        // x86 system directory on RISC
		PROGRAM_FILESX86 = 0x002a,        // x86 C:\Program Files on RISC
		PROGRAM_FILES_COMMON = 0x002b,        // C:\Program Files\Common
		PROGRAM_FILES_COMMONX86 = 0x002c,        // x86 Program Files\Common on RISC
		COMMON_TEMPLATES = 0x002d,        // All Users\Templates
		COMMON_DOCUMENTS = 0x002e,        // All Users\Documents
		COMMON_ADMINTOOLS = 0x002f,        // All Users\Start Menu\Programs\Administrative Tools
		ADMINTOOLS = 0x0030,        // <user name>\Start Menu\Programs\Administrative Tools
		CONNECTIONS = 0x0031,        // Network and Dial-up Connections
		COMMON_MUSIC = 0x0035,        // All Users\My Music
		COMMON_PICTURES = 0x0036,        // All Users\My Pictures
		COMMON_VIDEO = 0x0037,        // All Users\My Video
		RESOURCES = 0x0038,        // Resource Direcotry
		RESOURCES_LOCALIZED = 0x0039,        // Localized Resource Direcotry
		COMMON_OEM_LINKS = 0x003a,        // Links to All Users OEM specific apps
		CDBURN_AREA = 0x003b,        // USERPROFILE\Local Settings\Application Data\Microsoft\CD Burning
		COMPUTERSNEARME = 0x003d,        // Computers Near Me (computered from Workgroup membership)
	}

	public enum ConstantIdListFlags
	{
		None = 0,
		CREATE = 0x8000,        // combine with CSIDL_ value to force folder creation in SHGetFolderPath()
		DONT_VERIFY = 0x4000,        // combine with CSIDL_ value to return an unverified folder path
		DONT_UNEXPAND = 0x2000,        // combine with CSIDL_ value to avoid unexpanding environment variables
		NO_ALIAS = 0x1000,        // combine with CSIDL_ value to insure non-alias versions of the pidl
		PER_USER_INIT = 0x0800,        // combine with CSIDL_ value to indicate per-user init (eg. upgrade)
	}

	public enum FCT
	{
		MERGE = 0x0001,
		CONFIGABLE = 0x0002,
		ADDTOEND = 0x0004,
	}

	[Flags]
	public enum SBSP : int
	{
		DefaultBrowser = 0x0000,
		SameBrowser = 0x0001,
		NewBrowser = 0x0002,
		DefaultMode = 0x0000,
		OpenMode = 0x0010,
		ExplorerMode = 0x0020,
		HelpMode = 0x0040,
		NoTransferHistory = 0x0080,
		Absolute = 0x0000,
		Relative = 0x1000,
		Parent = 0x2000,
		NavigateBack = 0x4000,
		NavigateForward = 0x8000,
		AllowAutonavigate = 0x00010000,
		KeepSameTemplate = 0x00020000,
		KeepWordWheelText = 0x00040000,
		ActivateNoFocus = 0x00080000,
		CallerUntrusted = 0x00800000,
		TrustFirstDownload = 0x01000000,
		UntrustedForDownload = 0x02000000,
		NoAutoSelect = 0x04000000,
		WriteNoHistory = 0x08000000,
		TrustedForActiveX = 0x10000000,
		FeedNavigation = 0x20000000,
		Redirect = 0x40000000,
		InitiatedByHLinkFrame = unchecked((int)0x80000000),
	}

	public enum CommandStringInformation
	{
		VERBA = 0x00000000,     // canonical verb
		HELPTEXTA = 0x00000001,     // help text (for status bar)
		VALIDATEA = 0x00000002,     // validate command exists
		VERBW = 0x00000004,     // canonical verb (unicode)
		HELPTEXTW = 0x00000005,     // help text (unicode version)
		VALIDATEW = 0x00000006,     // validate command exists (unicode)
		VERBICONW = 0x00000014,     // icon string (unicode)
	}

	public enum CMIC
	{
		HOTKEY = 0x00000020,
		ICON = 0x00000010,
		NOASYNC = 0x00000100,
		FLAG_NO_UI = 0x00000400,
		UNICODE = 0x00004000,
		NO_CONSOLE = 0x00008000,
		ASYNCOK = 0x00100000,
		SHIFT_DOWN = 0x10000000,
		CONTROL_DOWN = 0x40000000,
		FLAG_LOG_USAGE = 0x04000000,
		NOZONECHECKS = 0x00800000,
		PTINVOKE = 0x20000000,
	}

	[Flags]
	public enum ContextMenuFlags
	{
		NORMAL = 0x00000000,
		DEFAULTONLY = 0x00000001,
		VERBSONLY = 0x00000002,
		EXPLORE = 0x00000004,
		NOVERBS = 0x00000008,
		CANRENAME = 0x00000010,
		NODEFAULT = 0x00000020,
		INCLUDESTATIC = 0x00000040,
		ITEMMENU = 0x00000080,
		EXTENDEDVERBS = 0x00000100,
		DISABLEDVERBS = 0x00000200,
	}


	[StructLayout(LayoutKind.Sequential)]
	public class CMINVOKECOMMANDINFO
	{
		public CMINVOKECOMMANDINFO() { this.cbSize = Marshal.SizeOf(this); }
		private int cbSize;
		public CMIC fMask;
		public IntPtr hwnd;
		public IntPtr lpVerbA;
		public IntPtr lpParametersA;
		public IntPtr lpDirectoryA;
		public int nShow;
		public int dwHotKey;
		public IntPtr hIcon;
	}

	[StructLayout(LayoutKind.Sequential)]
	public class CMINVOKECOMMANDINFOEX : CMINVOKECOMMANDINFO
	{
		public CMINVOKECOMMANDINFOEX() : base() { }
		[MarshalAs(UnmanagedType.LPStr)]
		public string lpTitle;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpVerbW;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpParametersW;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpDirectoryW;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpTitleW;
		public POINT ptInvoke;
	}

	[Flags]
	public enum SFGAO : int
	{
		None = 0,
		CanCopy = 0x1, // Objects can be copied    (0x1)
		CanMove = 0x2, // Objects can be moved     (0x2)
		CanLink = 0x4, // Objects can be linked    (0x4)
		Storage = 0x00000008,     // supports BindToObject(IID_IStorage)
		CanRename = 0x00000010,     // Objects can be renamed
		CanDelete = 0x00000020,     // Objects can be deleted
		HasPropSheet = 0x00000040,     // Objects have property sheets
		DropTarget = 0x00000100,     // Objects are drop target
		Encrypted = 0x00002000,     // Object is encrypted (use alt color)
		IsSlow = 0x00004000,     // 'Slow' object
		Ghosted = 0x00008000,     // Ghosted icon
		Link = 0x00010000,     // Shortcut (link)
		Share = 0x00020000,     // Shared
		ReadOnly = 0x00040000,     // Read-only
		Hidden = 0x00080000,     // Hidden object
		FileSystemAncestor = 0x10000000,     // May contain children with SFGAO_FILESYSTEM
		Folder = 0x20000000,     // Support BindToObject(IID_IShellFolder)
		FileSystem = 0x40000000,     // Is a win32 file system object (file/folder/root)
		HasSubfolder = unchecked((int)0x80000000),     // May contain children with SFGAO_FOLDER (may be slow)
		ContentsMask = unchecked((int)0x80000000),
		Validate = 0x01000000,     // Invalidate cached information (may be slow)
		Removable = 0x02000000,     // Is this removeable media?
		Compressed = 0x04000000,     // Object is compressed (use alt color)
		Browsable = 0x08000000,     // Supports IShellFolder, but only implements CreateViewObject() (non-folder view)
		NonEnumerated = 0x00100000,     // Is a non-enumerated object (should be hidden)
		NewContent = 0x00200000,     // Should show bold in explorer tree
		CanMoniker = 0x00400000,     // Obsolete
		HasStorage = 0x00400000,     // Obsolete
		Stream = 0x00400000,     // Supports BindToObject(IID_IStream)
		StorageAncestor = 0x00800000,     // May contain children with SFGAO_STORAGE or SFGAO_STREAM
	}

	public struct STRRET
	{
		public StrRetType uType;
		public IntPtr Value;

		public override string ToString()
		{
			unsafe
			{
				switch (this.uType)
				{
					case StrRetType.WSTR:
						return Marshal.PtrToStringUni(this.Value);
					case StrRetType.OFFSET:
						fixed (STRRET* pThis = &this)
						{ return Marshal.PtrToStringUni((IntPtr)((byte*)pThis + (int)this.Value)); }
					case StrRetType.CSTR:
						fixed (IntPtr* pCStr = &this.Value)
						{ return Marshal.PtrToStringUni((IntPtr)pCStr); }
					default:
						throw new NotSupportedException();
				}
			}
		}
	}

	public delegate int ShellFolderViewCallback(IShellView psvOuter, IShellFolder psf, IntPtr hwndMain, int uMsg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential)]
	public class CreateShellFolderViewOptions
	{
		private int cbSize;
		public CreateShellFolderViewOptions(IShellFolder folder, IShellView outer) { this.cbSize = Marshal.SizeOf(this); }
		public IShellFolder pshf;
		public IShellView psvOuter;
		public unsafe ShellItemId* pidl;
		public int lEvents;
		public ShellFolderViewCallback pfnCallback;
		private int fvm = 0;
	}

	public enum StrRetType
	{
		WSTR = 0,
		OFFSET = 0x1,
		CSTR = 0x2
	}

	[Flags]
	public enum SHCONTF
	{
		None = 0,
		Folders = 0x20,
		NonFolders = 0x40,
		IncludeHidden = 0x80,
		InitializeOnFirstNext = 0x100,
		NetworkPrinterSearch = 0x200,
		Shareable = 0x400,
		Storage = 0x800,
		FastItems = 0x2000,
		FlatList = 0x4000,
		EnableAsync = 0x8000
	}

	public struct SHDRAGIMAGE
	{
		public SIZE sizeDragImage;
		public POINT ptOffset;
		public IntPtr hbmpDragImage;
		public int /*0x00BBGGRR*/ crColorKey;
	}

	public enum ShellLinkGetPathFlags
	{
		Default = 0x0,
		SHORTPATH = 0x1,
		UNCPRIORITY = 0x2,
		RAWPATH = 0x4,
		RELATIVEPRIORITY = 0x8
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
	public struct Win32FindData
	{
		public System.IO.FileAttributes FileAttributes;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long _CreationTime;
		public DateTime CreationTime { get { return DateTime.FromFileTime(this._CreationTime); } set { this._CreationTime = value.ToFileTime(); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long _LastAccessTime;
		public DateTime LastAccessTime { get { return DateTime.FromFileTime(this._LastAccessTime); } set { this._LastAccessTime = value.ToFileTime(); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long _LastWriteTime;
		public DateTime LastWriteTime { get { return DateTime.FromFileTime(this._LastWriteTime); } set { this._LastWriteTime = value.ToFileTime(); } }
		public long FileSize;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int Reserved0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int Reserved1;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string FileName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
		public string AlternateFileName;
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct ShellItemId
	{
		[FieldOffset(0)]
		public ushort cb;
		[FieldOffset(sizeof(ushort))]
		public unsafe fixed byte abID[1]; /*00*/

		[FieldOffset(sizeof(ushort))]
		public PidlType Type; /*00*/
		[FieldOffset(sizeof(ushort) + sizeof(PidlType))]
		public unsafe fixed byte InternalData[1];
		[FieldOffset(sizeof(ushort) + sizeof(PidlType))]
		public ShellItemIdGuidData GuidData;
		[FieldOffset(sizeof(ushort) + sizeof(PidlType))]
		public ShellItemIdFileData FileData;
		[FieldOffset(sizeof(ushort) + sizeof(PidlType))]
		public ShellItemIdFileDataW FileDataW;
	}

	[DebuggerDisplay("{Guid} (Dummy: {Dummy})")]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ShellItemIdGuidData { [DebuggerBrowsable(DebuggerBrowsableState.Never)] public byte Dummy; [DebuggerBrowsable(DebuggerBrowsableState.Never)] public Guid Guid; public override string ToString() { return this.Guid.ToString(); } }
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ShellItemIdDriveData { public unsafe fixed byte szDriveName[20]; public short Unknown; public override string ToString() { unsafe { fixed (byte* pStr = this.szDriveName) { return Marshal.PtrToStringAnsi((IntPtr)pStr); } } } }

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ShellItemIdFileData
	{
		public byte Dummy;
		public int FileSize;
		public short FileData;
		public short FileTime;
		public short FileAttributes;
		public unsafe fixed byte Names[1];
		public string LongName { get { unsafe { fixed (byte* pName = this.Names) { return Marshal.PtrToStringAnsi((IntPtr)pName); } } } }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ShellItemIdFileDataW
	{
	}

	public enum PidlType : byte
	{
		ControlPanelApplet = 0x00,
		Guid = 0x1F,
		Drive = 0x23,
		Drive2 = 0x25,
		Drive3 = 0x29,
		ShellExtension = 0x2E,
		Drive1 = 0x2F,
		Folder1 = 0x30,
		Folder = 0x31,
		Value = 0x32,
		ValueW = 0x34,
		Workgroup = 0x41,
		Computer = 0x42,
		NetworkProvider = 0x46,
		Network = 0x47,
		IESpecial1 = 0x61,
		YetAnotherGuid = 0x70, /* yet another guid.. */
		IESpecial2 = 0xb1,
		Share = 0xc3,
	}

	public struct ITEMSPACING
	{
		public int cxSmall;
		public int cySmall;
		public int cxLarge;
		public int cyLarge;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ShellFolderViewCreate
	{
		public ShellFolderViewCreate(IShellFolder folder, IShellView viewOuter, IShellFolderViewCB callback)
		{
			this.cbSize = Marshal.SizeOf(typeof(ShellFolderViewCreate));
			this.ShellFolder = folder;
			this.ShellViewOuter = viewOuter;
			this.ShellFolderViewCB = callback;
		}

		public int cbSize;
		[MarshalAs(UnmanagedType.Interface)]
		public IShellFolder ShellFolder;       // IShellFolder the IShellView will use
		[MarshalAs(UnmanagedType.Interface)]
		public IShellView ShellViewOuter;   // optional: IShellView to pass to psfvcb
		[MarshalAs(UnmanagedType.Interface)]
		public IShellFolderViewCB ShellFolderViewCB; // No callback if NULL
	}

	internal enum ShellItemGetDisplayName : int
	{
		DESKTOPABSOLUTEEDITING = unchecked((int)0x8004c000),
		DESKTOPABSOLUTEPARSING = unchecked((int)0x80028000),
		FILESYSPATH = unchecked((int)0x80058000),
		NORMALDISPLAY = 0,
		PARENTRELATIVE = unchecked((int)0x80080001),
		PARENTRELATIVEEDITING = unchecked((int)0x80031001),
		PARENTRELATIVEFORADDRESSBAR = unchecked((int)0x8007c001),
		PARENTRELATIVEPARSING = unchecked((int)0x80018001),
		URL = unchecked((int)0x80068000),
	}

	public delegate bool AddPropSheetPageProcDelegate(IntPtr hpage, IntPtr lParam);

	public struct FolderSettings { public FolderViewMode ViewMode; public FolderFlags fFlags; }

	[Flags]
	public enum FolderFlags
	{
		AutoArrange = 0x00000001,
		AbbreviatedNames = 0x00000002,
		SnapToGrid = 0x00000004,
		BestFitWindow = 0x00000008,
		Desktop = 0x00000020,
		SingleSelect = 0x00000040,
		NoSubfolders = 0x00000080,
		Transparent = 0x00000100,
		NoClientEdge = 0x00000200,
		NoScroll = 0x00000400,
		AlignLeft = 0x00000800,
		NoIcons = 0x00001000,
		ShowSelAlways = 0x00002000,
		NoVisible = 0x00004000,
		SingleClickActivate = 0x00008000,
		NoWebView = 0x00010000,
		HideFileNames = 0x00020000,
		CheckSelect = 0x00040000,
		NoEnumRefresh = 0x00080000,
		NoGrouping = 0x00100000,
		FullRowSelect = 0x00200000,
		NoFilters= 0x00400000,
		NoColumnHeader = 0x01000000,
		NoHeaderInAllViews = 0x02000000,
		ExtendedTiles = 0x01000000,
		TriCheckSelect = 0x02000000,
		AutoCheckSelect = 0x04000000,
		NoBrowserViewState = 0x08000000,
		SubsetGroups = 0x10000000,
		UseSearchFolder = 0x40000000,
		AllowRtlReading = unchecked((int)0x80000000),
	}

	public enum FolderViewMode
	{
		Auto = -1,
		None = 0,
		Icon = 1,
		SmallIcon = 2,
		List = 3,
		Details = 4,
		Thumbnail = 5,
		Tile = 6,
		Thumbstrip = 7,
		Content = 8,
	}

	[Flags]
	public enum ShellViewSelectItemFlags : uint
	{
		Deselect = 0x00000000,
		Select = 0x00000001,
		Edit = 0x00000003,  // includes select
		DeselectOthers = 0x00000004,
		EnsureVisible = 0x00000008,
		Focused = 0x00000010,
		TranslatePt = 0x00000020,
		SelectionMark = 0x00000040,
		PositionItem = 0x00000080,
		Check = 0x00000100,
		Check2 = 0x00000200,
		KeyboardSelect = 0x00000401,  // includes select
		NoTakeFocus = 0x40000000,
		NoStateChange = 0x80000000,
	}

	[Flags]
	public enum ToolBarButtonState : byte
	{
		Checked = 0x01,
		PRESSED = 0x02,
		ENABLED = 0x04,
		HIDDEN = 0x08,
		INDETERMINATE = 0x10,
		WRAP = 0x20,
		ELLIPSES = 0x40,
		MARKED = 0x80,
	}

	[Flags]
	public enum ToolBarButtonStyle : byte
	{
		BUTTON = 0x0000,
		SEP = 0x0001,
		CHECK = 0x0002,
		GROUP = 0x0004,
		CHECKGROUP = GROUP | CHECK,
		DROPDOWN = 0x0008,
		AUTOSIZE = 0x0010,
		NOPREFIX = 0x0020,
#if false
		TOOLTIPS = 0x0100,
		WRAPABLE = 0x0200,
		ALTDRAG = 0x0400,
		FLAT = 0x0800,
		LIST = 0x1000,
		CUSTOMERASE = 0x2000,
		REGISTERDROP = 0x4000,
		TRANSPARENT = 0x8000,
#endif
	}

	public struct OleMenuGroupWidths
	{
		public unsafe fixed int width[6];
	}

	public struct TBBUTTON
	{
		public int iBitmap;
		public int idCommand;
		public ToolBarButtonState fsState;
		public ToolBarButtonStyle fsStyle;
#if X64
		public unsafe fixed byte bReserved[6];     // padding for alignment
#else
		public unsafe fixed byte bReserved[2];     // padding for alignment
#endif
		public IntPtr dwData;
		public IntPtr iString;
	}

	public enum SHGDN
	{
		Normal,
		InFolder,
		ForEditing,
		ForAddressBar,
		ForParsing,
	}
}