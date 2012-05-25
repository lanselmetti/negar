using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System;
using System.Diagnostics;

namespace Helper.Forms
{
	[SuppressUnmanagedCodeSecurity, ComImport, Guid("EBBC7C04-315E-11d2-B62F-006097DF5BD4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IProgressDialog
	{
		void StartProgressDialog([In, Optional] IntPtr hwndParent, [In, Optional] object punkEnableModless, ProgressDialogStartFlags dwFlags, IntPtr pvResevered);
		void StopProgressDialog();
		void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pwzTitle);
		void SetAnimation(IntPtr hInstAnimation, int idAnimation);
		[PreserveSig]
		int HasUserCancelled();
		void SetProgress(int dwCompleted, int dwTotal);
		void SetProgress64(long ullCompleted, long ullTotal);
		[PreserveSig]
		int SetLine(int dwLineNum, IntPtr pwzString, bool fCompactPath, IntPtr pvResevered);
		void SetCancelMsg([MarshalAs(UnmanagedType.LPWStr)] string pwzCancelMsg, IntPtr pvResevered);
		void Timer(ProgressDialogTimerAction dwTimerAction, IntPtr pvResevered);
	}

	[SuppressUnmanagedCodeSecurity, ComImport, Guid("F8383852-FCD3-11d1-A6B9-006097DF5BD4"), ClassInterface(ClassInterfaceType.AutoDispatch)]
	internal class ProgressDialogInternal : IProgressDialog
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void StartProgressDialog([In, Optional] IntPtr hwndParent, [In, Optional] object punkEnableModless, ProgressDialogStartFlags dwFlags, IntPtr pvResevered);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void StopProgressDialog();
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pwzTitle);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetAnimation(IntPtr hInstAnimation, int idAnimation);
		[PreserveSig]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int HasUserCancelled();
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetProgress(int dwCompleted, int dwTotal);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetProgress64(long ullCompleted, long ullTotal);
		[PreserveSig]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int SetLine(int dwLineNum, IntPtr pwzString, bool fCompactPath, IntPtr pvResevered);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetCancelMsg([MarshalAs(UnmanagedType.LPWStr)] string pwzCancelMsg, IntPtr pvResevered);
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void Timer(ProgressDialogTimerAction dwTimerAction, IntPtr pvResevered);
	}

	public enum ProgressDialogTimerAction
	{
		Reset = 0x00000001, // Reset the timer so the progress will be calculated from now until the first ::SetProgress() is called so those this time will correspond to the values passed to ::SetProgress().  Only do this before ::SetProgress() is called.
		Pause = 0x00000002, // Progress has been suspended
		Resume = 0x00000003, // Progress has resumed
	}

	[Flags]
	public enum ProgressDialogStartFlags : int
	{
		Normal = 0x00000000, // default normal progress dlg behavior
		Modal = 0x00000001, // the dialog is modal to its hwndParent (default is modeless)
		AutoTime = 0x00000002, // automatically updates the "Line3" text with the "time remaining" (you cant call SetLine3 if you passs this!)
		NoTime = 0x00000004, // we dont show the "time remaining" if this is set. We need this if dwTotal < dwCompleted for sparse files
		NoMinimize = 0x00000008, // Do not have a minimize button in the caption bar.
		NoProgressBar = 0x00000010, // Don't display the progress bar
		MarqueeProgressBar = 0x00000020, // Use marquee progress (comctl32 v6 required)
		NoCancel = 0x00000040, // No cancel button (operation cannot be canceled) (use sparingly)
	}

	public class ProgressDialog
	{
		private readonly IProgressDialog obj = new ProgressDialogInternal();
		private long lastCompleted = 0;
		private long lastTotal = 0;
		public void Start(IntPtr hWndParent, object pUnkEnableModless, ProgressDialogStartFlags flags) { this.obj.StartProgressDialog(hWndParent, pUnkEnableModless, flags, IntPtr.Zero); }
		public void Stop() { this.obj.StopProgressDialog(); }
		public void SetAnimation(IntPtr hInstance, int animationID) { this.obj.SetAnimation(hInstance, animationID); }
		public string Title { set { this.obj.SetTitle(value); } }
		public bool Canceled { get { return this.obj.HasUserCancelled() != 0; } }
		
		public void SetProgress(int completed, int total)
		{
			Debug.Assert(this.lastTotal == 0 || this.lastCompleted * total <= completed * this.lastTotal, "Progress went backwards!!!");
			this.lastCompleted = completed;
			this.lastTotal = total;
			this.obj.SetProgress(completed, total);
		}
		
		public void SetProgress(long completed, long total)
		{
			Debug.Assert(this.lastTotal == 0 || this.lastCompleted * total <= completed * this.lastTotal);
			this.lastCompleted = completed;
			this.lastTotal = total;
			this.obj.SetProgress64(completed, total);
		}

		public void SetLine(int lineNumber, string value, bool compactPath) { unsafe { fixed (char* pValue = value) { int result = this.obj.SetLine(lineNumber, (IntPtr)pValue, compactPath, IntPtr.Zero); if (result != 0) { Marshal.ThrowExceptionForHR(result); } } } }
		public string CancelMessage { set { this.obj.SetCancelMsg(value, IntPtr.Zero); } }
		public void SetTimer(ProgressDialogTimerAction action) { this.obj.Timer(action, IntPtr.Zero); }
	}
}