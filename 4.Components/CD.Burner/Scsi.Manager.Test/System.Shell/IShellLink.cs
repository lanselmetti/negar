using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;
namespace System.Shell
{
	[ComImport, Guid("000214F9-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IShellLink
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		unsafe void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, [In] int cchMaxPath, [Out] out Win32FindData pFindData, [In] ShellLinkGetPathFlags fFlags);
		[MethodImpl(MethodImplOptions.InternalCall)]
		unsafe void GetIDList([Out] out ShellItemId* ppidl);
		[MethodImpl(MethodImplOptions.InternalCall)]
		unsafe void SetIDList([In] ShellItemId* ppidl);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, [In] int cchMaxName);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, [In] int cchMaxPath);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetWorkingDirectory([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, [In] int cchMaxPath);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetArguments([In, MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetHotKey([Out] out short pwHotKey);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetHotKey([In] short wHotKey);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetShowCmd([Out] out int piShowCmd);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetShowCmd([In] int iShowCmd);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, [In] int cchIconPath, [Out] out int piIcon);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetIconLocation([In, MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, [In] int iIcon);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetRelativePath([In, MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, [In] uint dwReserved);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Resolve([In] IntPtr hwnd, [In] uint fFlags);
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetPath([In, MarshalAs(UnmanagedType.LPWStr)] string pszFile);
	}

	[ComImport, Guid("00021401-0000-0000-C000-000000000046")]
	//Guid = 0AFACED1-E828-11D1-9187-B532F1E9575D ?
	internal class ShellLinkInternal : IShellLink, IPersistFile
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern unsafe void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, [In] int cchMaxPath, [Out] out Win32FindData pFindData, [In] ShellLinkGetPathFlags fFlags);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern unsafe void GetIDList([Out] out ShellItemId* ppidl);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern unsafe void SetIDList([In] ShellItemId* ppidl);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, [In] int cchMaxName);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, [In] int cchMaxPath);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetWorkingDirectory([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, [In] int cchMaxPath);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetArguments([In, MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void GetHotKey([Out] out short pwHotKey);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetHotKey([In] short wHotKey);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void GetShowCmd([Out] out int piShowCmd);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetShowCmd([In] int iShowCmd);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, [In] int cchIconPath, [Out] out int piIcon);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetIconLocation([In, MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, [In] int iIcon);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetRelativePath([In, MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, [In] uint dwReserved);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void Resolve([In] IntPtr hwnd, [In] uint fFlags);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetPath([In, MarshalAs(UnmanagedType.LPWStr)] string pszFile);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void GetClassID(out Guid pClassID);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void GetCurFile(out string ppszFileName);
		[PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
		public extern int IsDirty();
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void Load(string pszFileName, int dwMode);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void Save(string pszFileName, bool fRemember);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SaveCompleted(string pszFileName);
	}

	public class ShellLink
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ShellLinkInternal shortcut = new ShellLinkInternal();

		public unsafe string GetPath(ShellLinkGetPathFlags pathType, out Win32FindData data)
		{
			var sb = new StringBuilder(260);
			this.shortcut.GetPath(sb, sb.Capacity, out data, pathType);
			return sb.ToString();
		}

		public string Path
		{
			get { Win32FindData data; unsafe { return this.GetPath(ShellLinkGetPathFlags.Default, out data); } }
			set { this.shortcut.SetPath(value); }
		}

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public Win32FindData FileInfo { get { Win32FindData result; this.GetPath(ShellLinkGetPathFlags.Default, out result); return result; } }

		public string Arguments { get { var sb = new StringBuilder(1024); this.shortcut.GetArguments(sb, sb.Capacity); return sb.ToString(); } set { this.shortcut.SetArguments(value); } }

		public string Description { get { var sb = new StringBuilder(1024); this.shortcut.GetDescription(sb, sb.Capacity); return sb.ToString(); } set { this.shortcut.SetDescription(value); } }

		public string WorkingDirectory { get { var sb = new StringBuilder(1024); this.shortcut.GetWorkingDirectory(sb, sb.Capacity); return sb.ToString(); } set { this.shortcut.SetWorkingDirectory(value); } }

		public void Save(string name, bool remember) { this.shortcut.Save(name, remember); }

		public void Load(string fileName, int mode) { this.shortcut.Load(fileName, mode); }

		public int ShowCommand { get { int cmd; this.shortcut.GetShowCmd(out cmd); return cmd; } set { this.shortcut.SetShowCmd(value); } }

		public short Hotkey { get { short hkey; this.shortcut.GetHotKey(out hkey); return hkey; } set { this.shortcut.SetHotKey(value); } }

		public void Resolve(IntPtr hWnd, int flags) { this.shortcut.Resolve(hWnd, unchecked((uint)flags)); }

		public void SetRelativePath(string path) { this.shortcut.SetRelativePath(path, 0); }
	}
}