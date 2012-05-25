using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;
using System.Threading;

namespace System.Shell
{
	[DebuggerTypeProxy(typeof(ShellItemIdListDebugView))]
	public class ShellItemIdList : SafeHandleZeroOrMinusOneIsInvalid
	{
		private static ShellItemIdList __Desktop;
		private static ShellItemIdList __Computer;

		private ShellItemIdList() : this(IntPtr.Zero, true) { }

		public static ShellItemIdList Computer { get { if (__Computer == null) { Interlocked.CompareExchange(ref __Computer, ShellUtil.SHGetSpecialFolderLocation(IntPtr.Zero, Environment.SpecialFolder.MyComputer), null); } return __Computer; } }
		public static ShellItemIdList Desktop { get { if (__Desktop == null) { Interlocked.CompareExchange(ref __Desktop, ShellItemIdList.CreateDesktop(), null); } return __Desktop; } }

		public ShellItemIdList(IntPtr pItemIdList, bool ownsHandle) : base(ownsHandle) { this.SetHandle(pItemIdList); }
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected override bool ReleaseHandle() { if (!this.IsInvalid) { Marshal.FreeCoTaskMem(this.handle); this.handle = IntPtr.Zero; } return true; }
		public bool IsParentOf(ShellItemIdList child, bool immediate) { this.CheckOpen(); return UnsafeNativeMethods.ILIsParent(this, child, immediate); }
		public ShellItemIdList GetNext() { this.CheckOpen(); var next = UnsafeNativeMethods.ILGetNext(this); return next != IntPtr.Zero ? new ShellItemIdList(next, false) : null; }
		public ShellItemIdList FindLastID() { this.CheckOpen(); var next = UnsafeNativeMethods.ILFindLastID(this); return next != IntPtr.Zero ? new ShellItemIdList(next, false) : null; }
		public static ShellItemIdList CreateDesktop() { var ptr = Marshal.AllocHGlobal(2); Marshal.WriteInt16(ptr, 0); return new ShellItemIdList(ptr, true); }
		public static ShellItemIdList operator +(ShellItemIdList left, ShellItemIdList right) { return UnsafeNativeMethods.ILCombine(left, right); }
		public int Size { get { this.CheckOpen(); return UnsafeNativeMethods.ILGetSize(this); } }
		public ShellItemIdList FindChildRelative(ShellItemIdList childAbsoluteID) { this.CheckOpen(); return UnsafeNativeMethods.ILFindChild(this, childAbsoluteID); }
		public override bool Equals(object obj) { this.CheckOpen(); var asID = obj as ShellItemIdList; return asID != null && UnsafeNativeMethods.ILIsEqual(this, asID); }
		public override int GetHashCode() { this.CheckOpen(); return this.Size; }
		public static ShellItemIdList TryCreateFromPath(string path) { var result = UnsafeNativeMethods.ILCreateFromPath(path); return result.IsInvalid ? null : result; }
		public static ShellItemIdList Clone(ShellItemIdList pidl) { return UnsafeNativeMethods.ILClone(pidl); }
		public static ShellItemIdList SHTrySimpleIDListFromPath(string path) { var result = UnsafeNativeMethods.SHSimpleIDListFromPath(path); return result.IsInvalid ? null : result; }
		public override string ToString() { this.CheckOpen(); string s; var sb = new StringBuilder(260); UnsafeNativeMethods.ILGetDisplayName(this, sb); s = sb.ToString(); return s; }
		protected void CheckOpen() { if (this.IsClosed) { throw new InvalidOperationException(); } }

		public unsafe ShellItemId* FirstItemId { get { return (ShellItemId*)this.DangerousGetHandle(); } }

		public static ShellItemIdList CloneLast(ShellItemIdList pidl)
		{
			unsafe
			{
				pidl = pidl.FindLastID();
				bool success = false;
				try
				{
					pidl.DangerousAddRef(ref success);
					Trace.Assert(success);
					var ptr = (ShellItemId*)pidl.DangerousGetHandle();
					var pResult = (ShellItemId*)Marshal.AllocCoTaskMem(ptr->cb + sizeof(short));
					for (int i = 0; i < sizeof(short) + ptr->cb; i++) { ((byte*)pResult)[i] = ((byte*)ptr)[i]; }
					*(short*)&((byte*)pResult)[pResult->cb] = 0;
					return new ShellItemIdList((IntPtr)pResult, true);
				}
				finally { if (success) { pidl.DangerousRelease(); } }
			}
		}
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		private static class UnsafeNativeMethods
		{
			[DllImport("Shell32.dll")]
			public static extern ShellItemIdList ILCreateFromPath(string pszPath);

			[DllImport("Shell32.dll", EntryPoint = "#15")]
			public static extern bool ILGetDisplayName(ShellItemIdList pidl, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder pszPath);

			[DllImport("Shell32.dll", EntryPoint = "#186")]
			public static extern bool ILGetDisplayNameEx(IShellFolder psf, ShellItemIdList pidl, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder pszPath, int type);

			[DllImport("Shell32.dll" /*, EntryPoint = "#28"*/)]
			public static extern bool SHILCreateFromPath(string path, out ShellItemIdList ppidl, ref SFGAO attributes);

			[DllImport("Shell32.dll" /*, EntryPoint = "#162"*/)]
			public static extern ShellItemIdList SHSimpleIDListFromPath(string path);

			[DllImport("Shell32.dll")]
			public static extern ShellItemIdList ILCombine(ShellItemIdList pidl1, ShellItemIdList pidl2);

			[DllImport("Shell32.dll")]
			public static extern IntPtr ILGetNext(ShellItemIdList pidl);

			[DllImport("Shell32.dll")]
			public static extern ShellItemIdList ILClone(ShellItemIdList pidl);

			[DllImport("Shell32.dll")]
			public static extern IntPtr ILFindLastID(ShellItemIdList pidl);

			[DllImport("Shell32.dll")]
			public static extern ShellItemIdList ILFindChild(ShellItemIdList pidlParent, ShellItemIdList pidlChild);

			[DllImport("Shell32.dll")]
			public static extern bool ILIsEqual(ShellItemIdList left, ShellItemIdList right);

			[DllImport("Shell32.dll")]
			public static extern bool ILIsParent(ShellItemIdList pidl1, ShellItemIdList pidl2, bool immediate);

			[DllImport("Shell32.dll")]
			public static extern int ILGetSize(ShellItemIdList pidl);
		}
	}

	internal sealed class ShellItemIdListDebugView
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ShellItemIdList list;
		public ShellItemIdListDebugView(ShellItemIdList list) { this.list = list; }

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public ShellItemIdList[] Items { get { var result = new List<ShellItemIdList>(); var item = this.list; while (item != null) { result.Add(item); item = item.GetNext(); } return result.ToArray(); } }
	}
}