using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ACCESS_MASK = System.Int32;
using BOOL = System.Boolean;
using BYTE = System.Byte;
using CHAR = System.Byte;
using COLORREF = System.Int32;
using DWORD = System.Int32;
using DWORD_PTR = System.IntPtr;
using GUID = System.Guid;
using HACCEL = System.IntPtr;
using HANDLE = System.IntPtr;
using HBITMAP = System.IntPtr;
using HBRUSH = System.IntPtr;
using HCURSOR = System.IntPtr;
using HDC = System.IntPtr;
using HDESK = System.IntPtr;
using HDEVNOTIFY = System.IntPtr;
using HDWP = System.IntPtr;
using HHOOK = System.IntPtr;
using HICON = System.IntPtr;
using HIMAGELIST = System.IntPtr;
using HKL = System.IntPtr;
using HMENU = System.IntPtr;
using HMONITOR = System.IntPtr;
using HPOWERNOTIFY = System.IntPtr;
using HWINSTA = System.IntPtr;
using HWND = System.IntPtr;
using INT = System.Int32;
using INT_PTR = System.IntPtr;
using LONG = System.Int32;
using LONG_PTR = System.IntPtr;
using LPARAM = System.IntPtr;
using LPCTSTR = System.String;
using LPTSTR = System.Text.StringBuilder;
using LRESULT = System.IntPtr;
using RECT = Helper.Forms.Rect;
using SHORT = System.Int16;
using UINT = System.Int32;
using UINT_PTR = System.IntPtr;
using ULONG = System.Int32;
using ULONG_PTR = System.IntPtr;
using WORD = System.Int16;
using WPARAM = System.IntPtr;
using System.Drawing;
using System.Diagnostics;

namespace Helper.Forms
{
	[DebuggerStepThrough]
	internal static partial class WinHelper
	{
		private delegate void SetLastWin32ErrorDelegate(int error);
		private static SetLastWin32ErrorDelegate __SetLastWin32ErrorDelegate;
		private static void SetLastWin32Error(int error) { if (__SetLastWin32ErrorDelegate == null) { Interlocked.CompareExchange<SetLastWin32ErrorDelegate>(ref __SetLastWin32ErrorDelegate, (SetLastWin32ErrorDelegate)Delegate.CreateDelegate(typeof(SetLastWin32ErrorDelegate), typeof(Marshal).GetMethod("SetLastWin32Error", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static), true), null); } __SetLastWin32ErrorDelegate(error); }
		[DebuggerHidden, DebuggerNonUserCode]
		private static void ThrowLastWin32Error() { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
		private static HandleRef MakeRef(IWin32Window window) { return new HandleRef(window, window != null ? window.Handle : IntPtr.Zero); }

		public static IntPtr GetFocus() { return UnsafeNativeMethods.GetFocus(); }
		public static int GetWindowLong(HandleRef window, int index) { SetLastWin32Error(0); var prev = UnsafeNativeMethods.GetWindowLong(window, index); if (prev == 0 && Marshal.GetLastWin32Error() != 0) { ThrowLastWin32Error(); } return prev; }
		public static int GetWindowLong(this IWin32Window window, int index) { return GetWindowLong(MakeRef(window), index); }
		public static IntPtr GetWindowLongPtr(HandleRef window, int index) { SetLastWin32Error(0); var prev = UnsafeNativeMethods.GetWindowLongPtr(window, index); if (prev == IntPtr.Zero && Marshal.GetLastWin32Error() != 0) { ThrowLastWin32Error(); } return prev; }
		public static IntPtr GetWindowLongPtr(this IWin32Window window, int index) { return GetWindowLongPtr(MakeRef(window), index); }
		public static bool IsChild(HandleRef parent, HandleRef child) { return UnsafeNativeMethods.IsChild(parent, child); }
		public static bool IsChild(this IWin32Window parent, IWin32Window child) { return IsChild(MakeRef(parent), MakeRef(child)); }
		public static IntPtr SetFocus(HandleRef window) { return UnsafeNativeMethods.SetFocus(window); }
		public static IntPtr SetFocus(this IWin32Window window) { return SetFocus(MakeRef(window)); }
		public static IntPtr SendMessage(HandleRef window, int msg, IntPtr wParam, IntPtr lParam, bool throwIfZero) { if (throwIfZero) { SetLastWin32Error(0); } var result = UnsafeNativeMethods.SendMessage(window, msg, wParam, lParam); if (throwIfZero && result == IntPtr.Zero) { ThrowLastWin32Error(); } return result; }
		public static IntPtr SendMessage(this IWin32Window window, int msg, IntPtr wParam, IntPtr lParam, bool throwIfZero) { return SendMessage(MakeRef(window), msg, wParam, lParam, throwIfZero); }
		public static int SetWindowLong(HandleRef window, int index, int newValue) { SetLastWin32Error(0); var prev = UnsafeNativeMethods.SetWindowLong(window, index, newValue); if (prev == 0 && Marshal.GetLastWin32Error() != 0) { ThrowLastWin32Error(); } return prev; }
		public static int SetWindowLong(this IWin32Window window, int index, int newValue) { return SetWindowLong(MakeRef(window), index, newValue); }
		public static IntPtr SetWindowLongPtr(HandleRef window, int index, IntPtr newValue) { SetLastWin32Error(0); var prev = UnsafeNativeMethods.SetWindowLongPtr(window, index, newValue); if (prev == IntPtr.Zero && Marshal.GetLastWin32Error() != 0) { ThrowLastWin32Error(); } return prev; }
		public static IntPtr SetWindowLongPtr(this IWin32Window window, int index, IntPtr newValue) { return SetWindowLongPtr(MakeRef(window), index, newValue); }
		public static void SetWindowPos(HandleRef window, HandleRef windowInsertAfter, int x, int y, int width, int height, int flags) { if (!UnsafeNativeMethods.SetWindowPos(window, windowInsertAfter, x, y, width, height, flags)) { ThrowLastWin32Error(); } }
		public static void SetWindowPos(this IWin32Window window, IWin32Window windowInsertAfter, int x, int y, int width, int height, int flags) { SetWindowPos(MakeRef(window), MakeRef(windowInsertAfter), x, y, width, height, flags); }


		[System.Security.SuppressUnmanagedCodeSecurity]
		public static partial class UnsafeNativeMethods
		{
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HKL LoadKeyboardLayout([In] LPCTSTR pwszKLID, [In] UINT Flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HKL ActivateKeyboardLayout([In] /*HKL*/ HandleRef hkl, [In] UINT Flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int ToUnicodeEx([In] UINT wVirtKey, [In] UINT wScanCode, [In] /*_bcount(256)*/ /*const*/ byte[] lpKeyState, [Out] /*_ecount(cchBuff)*/ LPTSTR pwszBuff, [In] int cchBuff, [In] UINT wFlags, [In, Optional] /*HKL*/ HandleRef dwhkl);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL UnloadKeyboardLayout([In] /*HKL*/ HandleRef hkl);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetKeyboardLayoutName([Out] /*_ecount(KL_NAMELENGTH)*/ LPTSTR pwszKLID);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe int GetKeyboardLayoutList([In] int nBuff, [Out, Optional] /*_ecount_part(nBuff, return)*/ HKL[] lpList);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HKL GetKeyboardLayout([In] DWORD idThread);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern int GetMouseMovePointsEx([In] UINT cbSize, [In] ref MOUSEMOVEPOINT lppt, [Out] /*_ecount(nBufPoints)*/ out MOUSEMOVEPOINT lpptBuf, [In] int nBufPoints, [In] DWORD resolution);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HDESK CreateDesktop([In] LPCTSTR lpszDesktop, /*__reserved*/ LPCTSTR lpszDevice, /*__reserved*/ ref DEVMODE pDevmode, [In] DWORD dwFlags, [In] ACCESS_MASK dwDesiredAccess, [In, Optional] /*SECURITY_ATTRIBUTES**/ IntPtr lpSecurityAttributes);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HDESK CreateDesktopEx([In] LPCTSTR lpszDesktop, /*__reserved*/ LPCTSTR lpszDevice, /*__reserved*/ ref DEVMODE pDevmode, [In] DWORD dwFlags, [In] ACCESS_MASK dwDesiredAccess, [In, Optional] /*SECURITY_ATTRIBUTES**/ IntPtr lpSecurityAttributes, [In] ULONG ulHeapSize, /*__reserved*/ IntPtr p);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HDESK OpenDesktop([In] LPCTSTR lpszDesktop, [In] DWORD dwFlags, [In] BOOL fInherit, [In] ACCESS_MASK dwDesiredAccess);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HDESK OpenInputDesktop([In] DWORD dwFlags, [In] BOOL fInherit, [In] ACCESS_MASK dwDesiredAccess);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL EnumDesktops([In, Optional] /*HWINSTA*/ HandleRef hwinsta, [In] DESKTOPENUMPROC lpEnumFunc, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EnumDesktopWindows([In, Optional] /*HDESK*/ HandleRef hDesktop, [In] WNDENUMPROC lpfn, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SwitchDesktop([In] /*HDESK*/ HandleRef hDesktop);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetThreadDesktop([In] /*HDESK*/ HandleRef hDesktop);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CloseDesktop([In] /*HDESK*/ HandleRef hDesktop);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HDESK GetThreadDesktop([In] DWORD dwThreadId);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWINSTA CreateWindowStation([In, Optional] LPCTSTR lpwinsta, [In] DWORD dwFlags, [In] ACCESS_MASK dwDesiredAccess, [In, Optional] /*SECURITY_ATTRIBUTES**/ IntPtr lpSecurityAttributes);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWINSTA OpenWindowStation([In] LPCTSTR lpszWinSta, [In] BOOL fInherit, [In] ACCESS_MASK dwDesiredAccess);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL EnumWindowStations([In] WINSTAENUMPROC lpEnumFunc, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CloseWindowStation([In] /*HWINSTA*/ HandleRef hWinSta);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetProcessWindowStation([In] /*HWINSTA*/ HandleRef hWinSta);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWINSTA GetProcessWindowStation();
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL SetUserObjectSecurity([In] /*HANDLE*/ HandleRef hObj, [In] ref SECURITY_INFORMATION pSIRequested, [In] ref SECURITY_DESCRIPTOR pSID);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetUserObjectSecurity([In] /*HANDLE*/ HandleRef hObj, [In] ref SECURITY_INFORMATION pSIRequested, [Out, Optional] /*_bcount(nLength)*/ /*SECURITY_DESCRIPTOR**/ IntPtr pSID, [In] DWORD nLength, [Out] out DWORD lpnLengthNeeded);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetUserObjectInformation([In] /*HANDLE*/ HandleRef hObj, [In] int nIndex, [Out, Optional] /*_bcount(nLength)*/ IntPtr pvInfo, [In] DWORD nLength, [Out, Optional] out DWORD lpnLengthNeeded);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetUserObjectInformation([In] /*HANDLE*/ HandleRef hObj, [In] int nIndex, [In] /*_bcount(nLength)*/ IntPtr pvInfo, [In] DWORD nLength);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsHungAppWindow([In] /*HWND*/ HandleRef hwnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern void DisableProcessWindowsGhosting();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DrawEdge([In] /*HDC*/ HandleRef hdc, [In, Out] ref RECT qrc, [In] UINT edge, [In] UINT grfFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DrawCaption([In] /*HWND*/ HandleRef hwnd, [In] /*HDC*/ HandleRef hdc, [In] /*const*/ ref RECT lprect, [In] UINT flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DrawAnimatedRects([In, Optional] /*HWND*/ HandleRef hwnd, [In] int idAni, [In] /*const*/ ref RECT lprcFrom, [In] /*const*/ ref RECT lprcTo);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetMessage([Out] out MSG lpMsg, [In, Optional] /*HWND*/ HandleRef hWnd, [In] UINT wMsgFilterMin, [In] UINT wMsgFilterMax);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL TranslateMessage([In] /*const*/ ref MSG lpMsg);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LRESULT DispatchMessage([In] /*const*/ ref MSG lpMsg);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetMessageQueue([In] int cMessagesMax);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL RegisterHotKey([In, Optional] /*HWND*/ HandleRef hWnd, [In] int id, [In] UINT fsModifiers, [In] UINT vk);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL UnregisterHotKey([In, Optional] /*HWND*/ HandleRef hWnd, [In] int id);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ExitWindowsEx([In] UINT uFlags, [In] DWORD dwReason);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SwapMouseButton([In] BOOL fSwap);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD GetMessagePos();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LONG GetMessageTime();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LPARAM GetMessageExtraInfo();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsWow64Message();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LPARAM SetMessageExtraInfo([In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LRESULT SendMessage([In] /*HWND*/ HandleRef hWnd, [In] UINT Msg, [In, Out] WPARAM wParam, [In, Out] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LRESULT SendMessageTimeout([In] /*HWND*/ HandleRef hWnd, [In] UINT Msg, [In] WPARAM wParam, [In] LPARAM lParam, [In] UINT fuFlags, [In] UINT uTimeout, [Out, Optional] out DWORD_PTR lpdwResult);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SendNotifyMessage([In] /*HWND*/ HandleRef hWnd, [In] UINT Msg, [In] WPARAM wParam, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SendMessageCallback([In] /*HWND*/ HandleRef hWnd, [In] UINT Msg, [In] WPARAM wParam, [In] LPARAM lParam, [In] SENDASYNCPROC lpResultCallBack, [In] ULONG_PTR dwData);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern unsafe long BroadcastSystemMessageEx([In] DWORD flags, [In, Out, Optional] DWORD* lpInfo, [In] UINT Msg, [In] WPARAM wParam, [In] LPARAM lParam, [Out, Optional] out BSMINFO pbsmInfo);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe long BroadcastSystemMessage([In] DWORD flags, [In, Out, Optional] DWORD* lpInfo, [In] UINT Msg, [In] WPARAM wParam, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HDEVNOTIFY RegisterDeviceNotification([In] /*HANDLE*/ HandleRef hRecipient, [In] IntPtr NotificationFilter, [In] DWORD Flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL UnregisterDeviceNotification([In] /*HDEVNOTIFY*/ HandleRef Handle);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HPOWERNOTIFY RegisterPowerSettingNotification([In] /*HANDLE*/ HandleRef hRecipient, [In] /*const*/ ref GUID PowerSettingGuid, [In] DWORD Flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL UnregisterPowerSettingNotification([In] /*HPOWERNOTIFY*/ HandleRef Handle);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL PostMessage([In, Optional] /*HWND*/ HandleRef hWnd, [In] UINT Msg, [In] WPARAM wParam, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL PostThreadMessage([In] DWORD idThread, [In] UINT Msg, [In] WPARAM wParam, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL AttachThreadInput([In] DWORD idAttach, [In] DWORD idAttachTo, [In] BOOL fAttach);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ReplyMessage([In] LRESULT lResult);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL WaitMessage();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD WaitForInputIdle([In] /*HANDLE*/ HandleRef hProcess, [In] DWORD dwMilliseconds);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LRESULT DefWindowProc([In] /*HWND*/ HandleRef hWnd, [In] UINT Msg, [In] WPARAM wParam, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern void PostQuitMessage([In] int nExitCode);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LRESULT CallWindowProc([In] WNDPROC lpPrevWndFunc, [In] /*HWND*/ HandleRef hWnd, [In] UINT Msg, [In] WPARAM wParam, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL InSendMessage();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD InSendMessageEx( /*__reserved*/ IntPtr lpReserved);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT GetDoubleClickTime();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetDoubleClickTime([In] UINT uInterval);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern ATOM RegisterClass([In] /*const*/ ref WNDCLASS lpWndClass);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL UnregisterClass([In] LPCTSTR lpClassName, [In] /*HINSTANCE*/ HandleRef hInstance);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetClassInfo([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] LPCTSTR lpClassName, [Out] out WNDCLASS lpWndClass);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern ATOM RegisterClassEx([In] /*const*/ ref WNDCLASSEX lpwcx);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetClassInfoEx([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] LPCTSTR lpszClass, [Out] out WNDCLASSEX lpwcx);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND CreateWindowEx([In] DWORD dwExStyle, [In, Optional] LPCTSTR lpClassName, [In, Optional] LPCTSTR lpWindowName, [In] DWORD dwStyle, [In] int X, [In] int Y, [In] int nWidth, [In] int nHeight, [In, Optional] /*HWND*/ HandleRef hWndParent, [In, Optional] /*HMENU*/ HandleRef hMenu, [In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In, Optional] IntPtr lpParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsWindow([In, Optional] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsMenu([In] /*HMENU*/ HandleRef hMenu);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsChild([In] /*HWND*/ HandleRef hWndParent, [In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DestroyWindow([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ShowWindow([In] /*HWND*/ HandleRef hWnd, [In] int nCmdShow);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL AnimateWindow([In] /*HWND*/ HandleRef hWnd, [In] DWORD dwTime, [In] DWORD dwFlags);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern unsafe BOOL UpdateLayeredWindow([In] /*HWND*/ HandleRef hWnd, [In, Optional] /*HDC*/ HandleRef hdcDst, [In, Optional] POINT* pptDst, [In, Optional] SIZE* psize, [In, Optional] /*HDC*/ HandleRef hdcSrc, [In, Optional] POINT* pptSrc, [In] COLORREF crKey, [In, Optional] BLENDFUNCTION* pblend, [In] DWORD dwFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetLayeredWindowAttributes([In] /*HWND*/ HandleRef hwnd, [Out, Optional] out COLORREF pcrKey, [Out, Optional] out BYTE pbAlpha, [Out, Optional] out DWORD pdwFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL PrintWindow([In] /*HWND*/ HandleRef hwnd, [In] /*HDC*/ HandleRef hdcBlt, [In] UINT nFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetLayeredWindowAttributes([In] /*HWND*/ HandleRef hwnd, [In] COLORREF crKey, [In] BYTE bAlpha, [In] DWORD dwFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ShowWindowAsync([In] /*HWND*/ HandleRef hWnd, [In] int nCmdShow);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL FlashWindow([In] /*HWND*/ HandleRef hWnd, [In] BOOL bInvert);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL FlashWindowEx([In] ref FLASHWINFO pfwi);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ShowOwnedPopups([In] /*HWND*/ HandleRef hWnd, [In] BOOL fShow);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL OpenIcon([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CloseWindow([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL MoveWindow([In] /*HWND*/ HandleRef hWnd, [In] int X, [In] int Y, [In] int nWidth, [In] int nHeight, [In] BOOL bRepaint);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetWindowPos([In] /*HWND*/ HandleRef hWnd, [In, Optional] /*HWND*/ HandleRef hWndInsertAfter, [In] int X, [In] int Y, [In] int cx, [In] int cy, [In] UINT uFlags);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetWindowPlacement([In] /*HWND*/ HandleRef hWnd, [In, Out] ref WINDOWPLACEMENT lpwndpl);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL SetWindowPlacement([In] /*HWND*/ HandleRef hWnd, [In] /*const*/ ref WINDOWPLACEMENT lpwndpl);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HDWP BeginDeferWindowPos([In] int nNumWindows);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HDWP DeferWindowPos([In] /*HDWP*/ HandleRef hWinPosInfo, [In] /*HWND*/ HandleRef hWnd, [In, Optional] /*HWND*/ HandleRef hWndInsertAfter, [In] int x, [In] int y, [In] int cx, [In] int cy, [In] UINT uFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EndDeferWindowPos([In] /*HDWP*/ HandleRef hWinPosInfo);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsWindowVisible([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsIconic([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL AnyPopup();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL BringWindowToTop([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsZoomed([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND CreateDialogParam([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] LPCTSTR lpTemplateName, [In, Optional] /*HWND*/ HandleRef hWndParent, [In, Optional] DLGPROC lpDialogFunc, [In] LPARAM dwInitParam);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern HWND CreateDialogIndirectParam([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] /*const*/ ref DLGTEMPLATE lpTemplate, [In, Optional] /*HWND*/ HandleRef hWndParent, [In, Optional] DLGPROC lpDialogFunc, [In] LPARAM dwInitParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern INT_PTR DialogBoxParam([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] LPCTSTR lpTemplateName, [In, Optional] /*HWND*/ HandleRef hWndParent, [In, Optional] DLGPROC lpDialogFunc, [In] LPARAM dwInitParam);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern INT_PTR DialogBoxIndirectParam([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] /*const*/ ref DLGTEMPLATE hDialogTemplate, [In, Optional] /*HWND*/ HandleRef hWndParent, [In, Optional] DLGPROC lpDialogFunc, [In] LPARAM dwInitParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EndDialog([In] /*HWND*/ HandleRef hDlg, [In] INT_PTR nResult);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetDlgItem([In, Optional] /*HWND*/ HandleRef hDlg, [In] int nIDDlgItem);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetDlgItemInt([In] /*HWND*/ HandleRef hDlg, [In] int nIDDlgItem, [In] UINT uValue, [In] BOOL bSigned);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT GetDlgItemInt([In] /*HWND*/ HandleRef hDlg, [In] int nIDDlgItem, [Out, Optional] out BOOL lpTranslated, [In] BOOL bSigned);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetDlgItemText([In] /*HWND*/ HandleRef hDlg, [In] int nIDDlgItem, [In] LPCTSTR lpString);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT GetDlgItemText([In] /*HWND*/ HandleRef hDlg, [In] int nIDDlgItem, [Out] /*_ecount(cchMax)*/ LPTSTR lpString, [In] int cchMax);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CheckDlgButton([In] /*HWND*/ HandleRef hDlg, [In] int nIDButton, [In] UINT uCheck);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CheckRadioButton([In] /*HWND*/ HandleRef hDlg, [In] int nIDFirstButton, [In] int nIDLastButton, [In] int nIDCheckButton);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT IsDlgButtonChecked([In] /*HWND*/ HandleRef hDlg, [In] int nIDButton);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LRESULT SendDlgItemMessage([In] /*HWND*/ HandleRef hDlg, [In] int nIDDlgItem, [In] UINT Msg, [In] WPARAM wParam, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetNextDlgGroupItem([In] /*HWND*/ HandleRef hDlg, [In, Optional] /*HWND*/ HandleRef hCtl, [In] BOOL bPrevious);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetNextDlgTabItem([In] /*HWND*/ HandleRef hDlg, [In, Optional] /*HWND*/ HandleRef hCtl, [In] BOOL bPrevious);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetDlgCtrlID([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern long GetDialogBaseUnits();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LRESULT DefDlgProc([In] /*HWND*/ HandleRef hDlg, [In] UINT Msg, [In] WPARAM wParam, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CallMsgFilter([In] ref MSG lpMsg, [In] int nCode);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL OpenClipboard([In, Optional] /*HWND*/ HandleRef hWndNewOwner);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CloseClipboard();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD GetClipboardSequenceNumber();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetClipboardOwner();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND SetClipboardViewer([In] /*HWND*/ HandleRef hWndNewViewer);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetClipboardViewer();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ChangeClipboardChain([In] /*HWND*/ HandleRef hWndRemove, [In] /*HWND*/ HandleRef hWndNewNext);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HANDLE SetClipboardData([In] UINT uFormat, [In, Optional] /*HANDLE*/ HandleRef hMem);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HANDLE GetClipboardData([In] UINT uFormat);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT RegisterClipboardFormat([In] LPCTSTR lpszFormat);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int CountClipboardFormats();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT EnumClipboardFormats([In] UINT format);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetClipboardFormatName([In] UINT format, [Out] /*_ecount(cchMaxCount)*/ LPTSTR lpszFormatName, [In] int cchMaxCount);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EmptyClipboard();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsClipboardFormatAvailable([In] UINT format);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetPriorityClipboardFormat([In] /*_ecount(cFormats)*/ UINT[] paFormatPriorityList, [In] int cFormats);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetOpenClipboardWindow();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL AddClipboardFormatListener([In] /*HWND*/ HandleRef hwnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL RemoveClipboardFormatListener([In] /*HWND*/ HandleRef hwnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetUpdatedClipboardFormats([Out] /*_ecount(cFormats)*/ UINT[] lpuiFormats, [In] UINT cFormats, [Out] out UINT pcFormatsOut);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CharToOem([In] /*_xcount(strlen(pSrc) + 1)*/ LPCTSTR pSrc, [Out] /*_xcount(strlen(pSrc) + 1)*/ LPTSTR pDst);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL OemToChar([In] /*_xcount(strlen(pSrc) + 1)*/ LPCTSTR pSrc, [Out] /*_xcount(strlen(pSrc) + 1)*/ LPTSTR pDst);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CharToOemBuff([In] LPCTSTR lpszSrc, [Out] /*_ecount(cchDstLength)*/ LPTSTR lpszDst, [In] DWORD cchDstLength);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL OemToCharBuff([In] LPCTSTR lpszSrc, [Out] /*_ecount(cchDstLength)*/ LPTSTR lpszDst, [In] DWORD cchDstLength);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LPTSTR CharUpper([In, Out] StringBuilder lpsz);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD CharUpperBuff([In, Out] /*_ecount(cchLength)*/ LPTSTR lpsz, [In] DWORD cchLength);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LPTSTR CharLower([In, Out] StringBuilder lpsz);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD CharLowerBuff([In, Out] /*_ecount(cchLength)*/ LPTSTR lpsz, [In] DWORD cchLength);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LPTSTR CharNext([In] LPCTSTR lpsz);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LPTSTR CharPrev([In] LPCTSTR lpszStart, [In] LPCTSTR lpszCurrent);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LPTSTR CharNextEx([In] WORD CodePage, [In] LPCTSTR lpCurrentChar, [In] DWORD dwFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LPTSTR CharPrevEx([In] WORD CodePage, [In] LPCTSTR lpStart, [In] LPCTSTR lpCurrentChar, [In] DWORD dwFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsCharAlpha([In] CHAR ch);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsCharAlphaNumeric([In] CHAR ch);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsCharUpper([In] CHAR ch);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsCharLower([In] CHAR ch);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND SetFocus([In, Optional] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetActiveWindow();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT GetKBCodePage();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern SHORT GetKeyState([In] int nVirtKey);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern SHORT GetAsyncKeyState([In] int vKey);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetKeyboardState([Out] /*_ecount(256)*/ byte[] lpKeyState);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetKeyboardState([In] /*_ecount(256)*/ byte[] lpKeyState);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetKeyNameText([In] LONG lParam, [Out] /*_ecount(cchSize)*/ LPTSTR lpString, [In] int cchSize);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetKeyboardType([In] int nTypeFlag);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int ToAscii([In] UINT uVirtKey, [In] UINT uScanCode, [In, Optional] /*_ecount(256)*/ /*const*/ byte[] lpKeyState, [Out] out WORD lpChar, [In] UINT uFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int ToAsciiEx([In] UINT uVirtKey, [In] UINT uScanCode, [In, Optional] /*_ecount(256)*/ /*const*/ byte[] lpKeyState, [Out] out WORD lpChar, [In] UINT uFlags, [In, Optional] /*HKL*/ HandleRef dwhkl);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int ToUnicode([In] UINT wVirtKey, [In] UINT wScanCode, [In, Optional] /*_bcount(256)*/ /*const*/ byte[] lpKeyState, [Out] /*_ecount(cchBuff)*/ LPTSTR pwszBuff, [In] int cchBuff, [In] UINT wFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD OemKeyScan([In] WORD wOemChar);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern SHORT VkKeyScan([In] CHAR ch);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern SHORT VkKeyScanEx([In] CHAR ch, [In] /*HKL*/ HandleRef dwhkl);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern void keybd_event([In] BYTE bVk, [In] BYTE bScan, [In] DWORD dwFlags, [In] ULONG_PTR dwExtraInfo);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern void mouse_event([In] DWORD dwFlags, [In] DWORD dx, [In] DWORD dy, [In] DWORD dwData, [In] ULONG_PTR dwExtraInfo);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetLastInputInfo([Out] out LASTINPUTINFO plii);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT MapVirtualKey([In] UINT uCode, [In] UINT uMapType);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT MapVirtualKeyEx([In] UINT uCode, [In] UINT uMapType, [In, Optional] /*HKL*/ HandleRef dwhkl);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetInputState();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD GetQueueStatus([In] UINT flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetCapture();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND SetCapture([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ReleaseCapture();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD MsgWaitForMultipleObjects([In] DWORD nCount, [In, Optional] /*_ecount(nCount)*/ /*const*/ HANDLE[] pHandles, [In] BOOL fWaitAll, [In] DWORD dwMilliseconds, [In] DWORD dwWakeMask);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD MsgWaitForMultipleObjectsEx([In] DWORD nCount, [In, Optional] /*_ecount(nCount)*/ /*const*/ HANDLE[] pHandles, [In] DWORD dwMilliseconds, [In] DWORD dwWakeMask, [In] DWORD dwFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT_PTR SetTimer([In, Optional] /*HWND*/ HandleRef hWnd, [In] UINT_PTR nIDEvent, [In] UINT uElapse, [In, Optional] TIMERPROC lpTimerFunc);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL KillTimer([In, Optional] /*HWND*/ HandleRef hWnd, [In] UINT_PTR uIDEvent);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsWindowUnicode([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EnableWindow([In] /*HWND*/ HandleRef hWnd, [In] BOOL bEnable);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsWindowEnabled([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HACCEL LoadAccelerators([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] LPCTSTR lpTableName);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern HACCEL CreateAcceleratorTable([In] /*_ecount(cAccel)*/ ACCEL[] paccel, [In] int cAccel);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DestroyAcceleratorTable([In] /*HACCEL*/ HandleRef hAccel);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern int CopyAcceleratorTable([In] /*HACCEL*/ HandleRef hAccelSrc, [Out, Optional] /*_ecount_part(cAccelEntries, return)*/ ACCEL[] lpAccelDst, [In] int cAccelEntries);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int TranslateAccelerator([In] /*HWND*/ HandleRef hWnd, [In] /*HACCEL*/ HandleRef hAccTable, [In] ref MSG lpMsg);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetSystemMetrics([In] int nIndex);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HMENU LoadMenu([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] LPCTSTR lpMenuName);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern HMENU LoadMenuIndirect([In] /*const*/ ref MENUTEMPLATE lpMenuTemplate);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HMENU GetMenu([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetMenu([In] /*HWND*/ HandleRef hWnd, [In, Optional] /*HMENU*/ HandleRef hMenu);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ChangeMenu([In] /*HMENU*/ HandleRef hMenu, [In] UINT cmd, [In, Optional] LPCTSTR lpszNewItem, [In] UINT cmdInsert, [In] UINT flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL HiliteMenuItem([In] /*HWND*/ HandleRef hWnd, [In] /*HMENU*/ HandleRef hMenu, [In] UINT uIDHiliteItem, [In] UINT uHilite);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetMenuString([In] /*HMENU*/ HandleRef hMenu, [In] UINT uIDItem, [Out, Optional] /*_ecount(cchMax)*/ LPTSTR lpString, [In] int cchMax, [In] UINT flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT GetMenuState([In] /*HMENU*/ HandleRef hMenu, [In] UINT uId, [In] UINT uFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DrawMenuBar([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HMENU GetSystemMenu([In] /*HWND*/ HandleRef hWnd, [In] BOOL bRevert);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HMENU CreateMenu();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HMENU CreatePopupMenu();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DestroyMenu([In] /*HMENU*/ HandleRef hMenu);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD CheckMenuItem([In] /*HMENU*/ HandleRef hMenu, [In] UINT uIDCheckItem, [In] UINT uCheck);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EnableMenuItem([In] /*HMENU*/ HandleRef hMenu, [In] UINT uIDEnableItem, [In] UINT uEnable);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HMENU GetSubMenu([In] /*HMENU*/ HandleRef hMenu, [In] int nPos);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT GetMenuItemID([In] /*HMENU*/ HandleRef hMenu, [In] int nPos);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetMenuItemCount([In, Optional] /*HMENU*/ HandleRef hMenu);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL InsertMenu([In] /*HMENU*/ HandleRef hMenu, [In] UINT uPosition, [In] UINT uFlags, [In] UINT_PTR uIDNewItem, [In, Optional] LPCTSTR lpNewItem);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL AppendMenu([In] /*HMENU*/ HandleRef hMenu, [In] UINT uFlags, [In] UINT_PTR uIDNewItem, [In, Optional] LPCTSTR lpNewItem);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ModifyMenu([In] /*HMENU*/ HandleRef hMnu, [In] UINT uPosition, [In] UINT uFlags, [In] UINT_PTR uIDNewItem, [In, Optional] LPCTSTR lpNewItem);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL RemoveMenu([In] /*HMENU*/ HandleRef hMenu, [In] UINT uPosition, [In] UINT uFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DeleteMenu([In] /*HMENU*/ HandleRef hMenu, [In] UINT uPosition, [In] UINT uFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetMenuItemBitmaps([In] /*HMENU*/ HandleRef hMenu, [In] UINT uPosition, [In] UINT uFlags, [In, Optional] /*HBITMAP*/ HandleRef hBitmapUnchecked, [In, Optional] /*HBITMAP*/ HandleRef hBitmapChecked);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LONG GetMenuCheckMarkDimensions();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe BOOL TrackPopupMenu([In] /*HMENU*/ HandleRef hMenu, [In] UINT uFlags, [In] int x, [In] int y, [In] int nReserved, [In] /*HWND*/ HandleRef hWnd, [In, Optional] /*const*/ RECT* prcRect);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe BOOL TrackPopupMenuEx([In] /*HMENU*/ HandleRef hmenu, [In] UINT fuFlags, [In] int x, [In] int y, [In] /*HWND*/ HandleRef hwnd, [In, Optional] TPMPARAMS* lptpm);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetMenuInfo([In] /*HMENU*/ HandleRef hmenu, [In, Out] ref MENUINFO lpcmi);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL SetMenuInfo([In] /*HMENU*/ HandleRef hmenu, [In] /*const*/ ref MENUINFO lpcmi);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EndMenu();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL InsertMenuItem([In] /*HMENU*/ HandleRef hmenu, [In] UINT item, [In] BOOL fByPosition, [In] /*const*/ ref MENUITEMINFO lpmi);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetMenuItemInfo([In] /*HMENU*/ HandleRef hmenu, [In] UINT item, [In] BOOL fByPosition, [In, Out] ref MENUITEMINFO lpmii);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetMenuItemInfo([In] /*HMENU*/ HandleRef hmenu, [In] UINT item, [In] BOOL fByPositon, [In] /*const*/ ref MENUITEMINFO lpmii);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT GetMenuDefaultItem([In] /*HMENU*/ HandleRef hMenu, [In] UINT fByPos, [In] UINT gmdiFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetMenuDefaultItem([In] /*HMENU*/ HandleRef hMenu, [In] UINT uItem, [In] UINT fByPos);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetMenuItemRect([In, Optional] /*HWND*/ HandleRef hWnd, [In] /*HMENU*/ HandleRef hMenu, [In] UINT uItem, [Out] out RECT lprcItem);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int MenuItemFromPoint([In, Optional] /*HWND*/ HandleRef hWnd, [In] /*HMENU*/ HandleRef hMenu, [In] POINT ptScreen);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD DragObject([In] /*HWND*/ HandleRef hwndParent, [In] /*HWND*/ HandleRef hwndFrom, [In] UINT fmt, [In] ULONG_PTR data, [In, Optional] /*HCURSOR*/ HandleRef hcur);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DragDetect([In] /*HWND*/ HandleRef hwnd, [In] POINT pt);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DrawIcon([In] /*HDC*/ HandleRef hDC, [In] int X, [In] int Y, [In] /*HICON*/ HandleRef hIcon);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int DrawText([In] /*HDC*/ HandleRef hdc, [In, Out, Optional] /*_ecount(cchText)*/ LPCTSTR lpchText, [In] int cchText, [In, Out] ref RECT lprc, [In] UINT format);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern unsafe int DrawTextEx([In] /*HDC*/ HandleRef hdc, [In, Out, Optional] /*_ecount(cchText)*/ LPTSTR lpchText, [In] int cchText, [In, Out] ref RECT lprc, [In] UINT format, [In, Optional] DRAWTEXTPARAMS* lpdtp);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GrayString([In] /*HDC*/ HandleRef hDC, [In, Optional] /*HBRUSH*/ HandleRef hBrush, [In, Optional] GRAYSTRINGPROC lpOutputFunc, [In] LPARAM lpData, [In] int nCount, [In] int X, [In] int Y, [In] int nWidth, [In] int nHeight);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DrawState([In] /*HDC*/ HandleRef hdc, [In, Optional] /*HBRUSH*/ HandleRef hbrFore, [In, Optional] DRAWSTATEPROC qfnCallBack, [In] LPARAM lData, [In] WPARAM wData, [In] int x, [In] int y, [In] int cx, [In] int cy, [In] UINT uFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LONG TabbedTextOut([In] /*HDC*/ HandleRef hdc, [In] int x, [In] int y, [In] /*_ecount(chCount)*/ LPCTSTR lpString, [In] int chCount, [In] int nTabPositions, [In, Optional] /*_ecount(nTabPositions)*/ /*const*/ INT[] lpnTabStopPositions, [In] int nTabOrigin);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD GetTabbedTextExtent([In] /*HDC*/ HandleRef hdc, [In] /*_ecount(chCount)*/ LPCTSTR lpString, [In] int chCount, [In] int nTabPositions, [In, Optional] /*_ecount(nTabPositions)*/ /*const*/ INT[] lpnTabStopPositions);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL UpdateWindow([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND SetActiveWindow([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetForegroundWindow();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL PaintDesktop([In] /*HDC*/ HandleRef hdc);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern void SwitchToThisWindow([In] /*HWND*/ HandleRef hwnd, [In] BOOL fUnknown);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetForegroundWindow([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL AllowSetForegroundWindow([In] DWORD dwProcessId);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL LockSetForegroundWindow([In] UINT uLockCode);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND WindowFromDC([In] /*HDC*/ HandleRef hDC);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HDC GetDC([In, Optional] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HDC GetDCEx([In, Optional] /*HWND*/ HandleRef hWnd, [In, Optional] /*HRGN*/ HandleRef hrgnClip, [In] DWORD flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HDC GetWindowDC([In, Optional] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int ReleaseDC([In, Optional] /*HWND*/ HandleRef hWnd, [In] /*HDC*/ HandleRef hDC);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern HDC BeginPaint([In] /*HWND*/ HandleRef hWnd, [Out] out PAINTSTRUCT lpPaint);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL EndPaint([In] /*HWND*/ HandleRef hWnd, [In] /*const*/ ref PAINTSTRUCT lpPaint);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetUpdateRect([In] /*HWND*/ HandleRef hWnd, [Out, Optional] out RECT lpRect, [In] BOOL bErase);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetUpdateRgn([In] /*HWND*/ HandleRef hWnd, [In] /*HRGN*/ HandleRef hRgn, [In] BOOL bErase);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int SetWindowRgn([In] /*HWND*/ HandleRef hWnd, [In, Optional] /*HRGN*/ HandleRef hRgn, [In] BOOL bRedraw);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetWindowRgn([In] /*HWND*/ HandleRef hWnd, [In] /*HRGN*/ HandleRef hRgn);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetWindowRgnBox([In] /*HWND*/ HandleRef hWnd, [Out] out RECT lprc);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int ExcludeUpdateRgn([In] /*HDC*/ HandleRef hDC, [In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe BOOL InvalidateRect([In, Optional] /*HWND*/ HandleRef hWnd, [In, Optional] /*const*/ RECT* lpRect, [In] BOOL bErase);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe BOOL ValidateRect([In, Optional] /*HWND*/ HandleRef hWnd, [In, Optional] /*const*/ RECT* lpRect);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL InvalidateRgn([In] /*HWND*/ HandleRef hWnd, [In, Optional] /*HRGN*/ HandleRef hRgn, [In] BOOL bErase);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ValidateRgn([In] /*HWND*/ HandleRef hWnd, [In, Optional] /*HRGN*/ HandleRef hRgn);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe BOOL RedrawWindow([In, Optional] /*HWND*/ HandleRef hWnd, [In, Optional] /*const*/ RECT* lprcUpdate, [In, Optional] /*HRGN*/ HandleRef hrgnUpdate, [In] UINT flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL LockWindowUpdate([In, Optional] /*HWND*/ HandleRef hWndLock);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe BOOL ScrollWindow([In] /*HWND*/ HandleRef hWnd, [In] int XAmount, [In] int YAmount, [In, Optional] /*const*/ RECT* lpRect, [In, Optional] /*const*/ RECT* lpClipRect);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe BOOL ScrollDC([In] /*HDC*/ HandleRef hDC, [In] int dx, [In] int dy, [In, Optional] /*const*/ RECT* lprcScroll, [In, Optional] /*const*/ RECT* lprcClip, [In, Optional] /*HRGN*/ HandleRef hrgnUpdate, [Out, Optional] out RECT lprcUpdate);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe int ScrollWindowEx([In] /*HWND*/ HandleRef hWnd, [In] int dx, [In] int dy, [In, Optional] /*const*/ RECT* prcScroll, [In, Optional] /*const*/ RECT* prcClip, [In, Optional] /*HRGN*/ HandleRef hrgnUpdate, [Out, Optional] out RECT prcUpdate, [In] UINT flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int SetScrollPos([In] /*HWND*/ HandleRef hWnd, [In] int nBar, [In] int nPos, [In] BOOL bRedraw);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetScrollPos([In] /*HWND*/ HandleRef hWnd, [In] int nBar);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetScrollRange([In] /*HWND*/ HandleRef hWnd, [In] int nBar, [In] int nMinPos, [In] int nMaxPos, [In] BOOL bRedraw);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetScrollRange([In] /*HWND*/ HandleRef hWnd, [In] int nBar, [Out] out INT lpMinPos, [Out] out INT lpMaxPos);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ShowScrollBar([In] /*HWND*/ HandleRef hWnd, [In] int wBar, [In] BOOL bShow);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EnableScrollBar([In] /*HWND*/ HandleRef hWnd, [In] UINT wSBflags, [In] UINT wArrows);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetProp([In] /*HWND*/ HandleRef hWnd, [In] LPCTSTR lpString, [In, Optional] /*HANDLE*/ HandleRef hData);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HANDLE GetProp([In] /*HWND*/ HandleRef hWnd, [In] LPCTSTR lpString);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HANDLE RemoveProp([In] /*HWND*/ HandleRef hWnd, [In] LPCTSTR lpString);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int EnumPropsEx([In] /*HWND*/ HandleRef hWnd, [In] PROPENUMPROCEX lpEnumFunc, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int EnumProps([In] /*HWND*/ HandleRef hWnd, [In] PROPENUMPROC lpEnumFunc);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetWindowText([In] /*HWND*/ HandleRef hWnd, [In, Optional] LPCTSTR lpString);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetWindowText([In] /*HWND*/ HandleRef hWnd, [Out] /*_ecount(nMaxCount)*/ LPTSTR lpString, [In] int nMaxCount);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetWindowTextLength([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetClientRect([In] /*HWND*/ HandleRef hWnd, [Out] out RECT lpRect);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetWindowRect([In] /*HWND*/ HandleRef hWnd, [Out] out RECT lpRect);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL AdjustWindowRect([In, Out] ref RECT lpRect, [In] DWORD dwStyle, [In] BOOL bMenu);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL AdjustWindowRectEx([In, Out] ref RECT lpRect, [In] DWORD dwStyle, [In] BOOL bMenu, [In] DWORD dwExStyle);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetWindowContextHelpId([In] /*HWND*/ HandleRef hwnd, [In] DWORD dwContextHelpId);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD GetWindowContextHelpId([In] /*HWND*/ HandleRef hwnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetMenuContextHelpId([In] /*HMENU*/ HandleRef hmenu, [In] DWORD dwContextHelpId);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD GetMenuContextHelpId([In] /*HMENU*/ HandleRef hmenu);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int MessageBox([In, Optional] /*HWND*/ HandleRef hWnd, [In, Optional] LPCTSTR lpText, [In, Optional] LPCTSTR lpCaption, [In] UINT uType);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int MessageBoxEx([In, Optional] /*HWND*/ HandleRef hWnd, [In, Optional] LPCTSTR lpText, [In, Optional] LPCTSTR lpCaption, [In] UINT uType, [In] WORD wLanguageId);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern int MessageBoxIndirect([In] /*const*/ ref MSGBOXPARAMS lpmbp);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL MessageBeep([In] UINT uType);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int ShowCursor([In] BOOL bShow);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetCursorPos([In] int X, [In] int Y);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetPhysicalCursorPos([In] int X, [In] int Y);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HCURSOR SetCursor([In, Optional] /*HCURSOR*/ HandleRef hCursor);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetCursorPos([Out] out POINT lpPoint);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetPhysicalCursorPos([Out] out POINT lpPoint);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe BOOL ClipCursor([In, Optional] /*const*/ RECT* lpRect);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetClipCursor([Out] out RECT lpRect);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HCURSOR GetCursor();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CreateCaret([In] /*HWND*/ HandleRef hWnd, [In, Optional] /*HBITMAP*/ HandleRef hBitmap, [In] int nWidth, [In] int nHeight);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT GetCaretBlinkTime();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetCaretBlinkTime([In] UINT uMSeconds);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DestroyCaret();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL HideCaret([In, Optional] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ShowCaret([In, Optional] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetCaretPos([In] int X, [In] int Y);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetCaretPos([Out] out POINT lpPoint);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ClientToScreen([In] /*HWND*/ HandleRef hWnd, [In, Out] ref POINT lpPoint);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ScreenToClient([In] /*HWND*/ HandleRef hWnd, [In, Out] ref POINT lpPoint);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL LogicalToPhysicalPoint([In] /*HWND*/ HandleRef hWnd, [In, Out] ref POINT lpPoint);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL PhysicalToLogicalPoint([In] /*HWND*/ HandleRef hWnd, [In, Out] ref POINT lpPoint);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe int MapWindowPoints([In, Optional] /*HWND*/ HandleRef hWndFrom, [In, Optional] /*HWND*/ HandleRef hWndTo, [In, Out] /*_ecount(cPoints)*/ POINT[] lpPoints, [In] UINT cPoints);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND WindowFromPoint([In] POINT Point);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND WindowFromPhysicalPoint([In] POINT Point);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND ChildWindowFromPoint([In] /*HWND*/ HandleRef hWndParent, [In] POINT Point);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND ChildWindowFromPointEx([In] /*HWND*/ HandleRef hwnd, [In] POINT pt, [In] UINT flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD GetSysColor([In] int nIndex);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HBRUSH GetSysColorBrush([In] int nIndex);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetSysColors([In] int cElements, [In] /*_ecount(cElements)*/ /*const*/ INT[] lpaElements, [In] /*_ecount(cElements)*/ /*const*/ COLORREF[] lpaRgbValues);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DrawFocusRect([In] /*HDC*/ HandleRef hDC, [In] /*const*/ ref RECT lprc);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int FillRect([In] /*HDC*/ HandleRef hDC, [In] /*const*/ ref RECT lprc, [In] /*HBRUSH*/ HandleRef hbr);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int FrameRect([In] /*HDC*/ HandleRef hDC, [In] /*const*/ ref RECT lprc, [In] /*HBRUSH*/ HandleRef hbr);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL InvertRect([In] /*HDC*/ HandleRef hDC, [In] /*const*/ ref RECT lprc);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetRect([Out] out RECT lprc, [In] int xLeft, [In] int yTop, [In] int xRight, [In] int yBottom);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetRectEmpty([Out] out RECT lprc);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CopyRect([Out] out RECT lprcDst, [In] /*const*/ ref RECT lprcSrc);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL InflateRect([In, Out] ref RECT lprc, [In] int dx, [In] int dy);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IntersectRect([Out] out RECT lprcDst, [In] /*const*/ ref RECT lprcSrc1, [In] /*const*/ ref RECT lprcSrc2);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL UnionRect([Out] out RECT lprcDst, [In] /*const*/ ref RECT lprcSrc1, [In] /*const*/ ref RECT lprcSrc2);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SubtractRect([Out] out RECT lprcDst, [In] /*const*/ ref RECT lprcSrc1, [In] /*const*/ ref RECT lprcSrc2);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL OffsetRect([In, Out] ref RECT lprc, [In] int dx, [In] int dy);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsRectEmpty([In] /*const*/ ref RECT lprc);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EqualRect([In] /*const*/ ref RECT lprc1, [In] /*const*/ ref RECT lprc2);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL PtInRect([In] /*const*/ ref RECT lprc, [In] POINT pt);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern WORD GetWindowWord([In] /*HWND*/ HandleRef hWnd, [In] int nIndex);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern WORD SetWindowWord([In] /*HWND*/ HandleRef hWnd, [In] int nIndex, [In] WORD wNewWord);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LONG GetWindowLong([In] /*HWND*/ HandleRef hWnd, [In] int nIndex);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LONG SetWindowLong([In] /*HWND*/ HandleRef hWnd, [In] int nIndex, [In] LONG dwNewLong);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LONG_PTR GetWindowLongPtr([In] /*HWND*/ HandleRef hWnd, [In] int nIndex);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LONG_PTR SetWindowLongPtr([In] /*HWND*/ HandleRef hWnd, [In] int nIndex, [In] LONG_PTR dwNewLong);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern WORD GetClassWord([In] /*HWND*/ HandleRef hWnd, [In] int nIndex);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern WORD SetClassWord([In] /*HWND*/ HandleRef hWnd, [In] int nIndex, [In] WORD wNewWord);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD GetClassLong([In] /*HWND*/ HandleRef hWnd, [In] int nIndex);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD SetClassLong([In] /*HWND*/ HandleRef hWnd, [In] int nIndex, [In] LONG dwNewLong);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern ULONG_PTR GetClassLongPtr([In] /*HWND*/ HandleRef hWnd, [In] int nIndex);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern ULONG_PTR SetClassLongPtr([In] /*HWND*/ HandleRef hWnd, [In] int nIndex, [In] LONG_PTR dwNewLong);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL GetProcessDefaultLayout([Out] out DWORD pdwDefaultLayout);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetProcessDefaultLayout([In] DWORD dwDefaultLayout);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetDesktopWindow();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetParent([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND SetParent([In] /*HWND*/ HandleRef hWndChild, [In, Optional] /*HWND*/ HandleRef hWndNewParent);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EnumChildWindows([In, Optional] /*HWND*/ HandleRef hWndParent, [In] WNDENUMPROC lpEnumFunc, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND FindWindow([In, Optional] LPCTSTR lpClassName, [In, Optional] LPCTSTR lpWindowName);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND FindWindowEx([In, Optional] /*HWND*/ HandleRef hWndParent, [In, Optional] /*HWND*/ HandleRef hWndChildAfter, [In, Optional] LPCTSTR lpszClass, [In, Optional] LPCTSTR lpszWindow);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetShellWindow();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL RegisterShellHookWindow([In] /*HWND*/ HandleRef hwnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DeregisterShellHookWindow([In] /*HWND*/ HandleRef hwnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EnumWindows([In] WNDENUMPROC lpEnumFunc, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EnumThreadWindows([In] DWORD dwThreadId, [In] WNDENUMPROC lpfn, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int GetClassName([In] /*HWND*/ HandleRef hWnd, [Out] StringBuilder lpClassName, [In] int nMaxCount);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetTopWindow([In, Optional] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD GetWindowThreadProcessId([In] /*HWND*/ HandleRef hWnd, [Out, Optional] out DWORD lpdwProcessId);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsGUIThread([In] BOOL bConvert);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetLastActivePopup([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetWindow([In] /*HWND*/ HandleRef hWnd, [In] UINT uCmd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HHOOK SetWindowsHook([In] int nFilterType, [In] /*HOOKPROC*/ HandleRef pfnFilterProc);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL UnhookWindowsHook([In] int nCode, [In] /*HOOKPROC*/ HandleRef pfnFilterProc);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HHOOK SetWindowsHookEx([In] int idHook, [In] /*HOOKPROC*/ HandleRef lpfn, [In, Optional] /*HINSTANCE*/ HandleRef hmod, [In] DWORD dwThreadId);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL UnhookWindowsHookEx([In] /*HHOOK*/ HandleRef hhk);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LRESULT CallNextHookEx([In, Optional] /*HHOOK*/ HandleRef hhk, [In] int nCode, [In] WPARAM wParam, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CheckMenuRadioItem([In] /*HMENU*/ HandleRef hmenu, [In] UINT first, [In] UINT last, [In] UINT check, [In] UINT flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HBITMAP LoadBitmap([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] LPCTSTR lpBitmapName);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HCURSOR LoadCursor([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] LPCTSTR lpCursorName);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HCURSOR LoadCursorFromFile([In] LPCTSTR lpFileName);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HCURSOR CreateCursor([In, Optional] /*HINSTANCE*/ HandleRef hInst, [In] int xHotSpot, [In] int yHotSpot, [In] int nWidth, [In] int nHeight, [In] /*const*/ IntPtr pvANDPlane, [In] /*const*/ IntPtr pvXORPlane);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DestroyCursor([In] /*HCURSOR*/ HandleRef hCursor);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HCURSOR CopyCursor([In] /*HCURSOR*/ HandleRef hCursor);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetSystemCursor([In] /*HCURSOR*/ HandleRef hcur, [In] DWORD id);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HICON LoadIcon([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] LPCTSTR lpIconName);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT PrivateExtractIcons([In] LPCTSTR szFileName, [In] int nIconIndex, [In] int cxIcon, [In] int cyIcon, [Out, Optional] /*_ecount_part(nIcons, return)*/ HICON[] phicon, [Out, Optional] /*_ecount_part(nIcons, return)*/ UINT[] piconid, [In] UINT nIcons, [In] UINT flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HICON CreateIcon([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] int nWidth, [In] int nHeight, [In] BYTE cPlanes, [In] BYTE cBitsPixel, [In] /*const*/ byte[] lpbANDbits, [In] /*const*/ byte[] lpbXORbits);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int LookupIconIdFromDirectory([In] ref BYTE presbits, [In] BOOL fIcon);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int LookupIconIdFromDirectoryEx([In] ref BYTE presbits, [In] BOOL fIcon, [In] int cxDesired, [In] int cyDesired, [In] UINT Flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HICON CreateIconFromResource([In] ref BYTE presbits, [In] DWORD dwResSize, [In] BOOL fIcon, [In] DWORD dwVer);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HICON CreateIconFromResourceEx([In] ref BYTE presbits, [In] DWORD dwResSize, [In] BOOL fIcon, [In] DWORD dwVer, [In] int cxDesired, [In] int cyDesired, [In] UINT Flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HANDLE CopyImage([In] /*HANDLE*/ HandleRef h, [In] UINT type, [In] int cx, [In] int cy, [In] UINT flags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DrawIconEx([In] /*HDC*/ HandleRef hdc, [In] int xLeft, [In] int yTop, [In] /*HICON*/ HandleRef hIcon, [In] int cxWidth, [In] int cyWidth, [In] UINT istepIfAniCur, [In, Optional] /*HBRUSH*/ HandleRef hbrFlickerFreeDraw, [In] UINT diFlags);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern HICON CreateIconIndirect([In] ref ICONINFO piconinfo);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HICON CopyIcon([In] /*HICON*/ HandleRef hIcon);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetIconInfo([In] /*HICON*/ HandleRef hIcon, [Out] out ICONINFO piconinfo);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetIconInfoEx([In] /*HICON*/ HandleRef hicon, [In, Out] ref ICONINFOEX piconinfo);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int LoadString([In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] UINT uID, [Out] /*_ecount_part(cchBufferMax, return + 1)*/ LPTSTR lpBuffer, [In] int cchBufferMax);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsDialogMessage([In] /*HWND*/ HandleRef hDlg, [In] ref MSG lpMsg);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL MapDialogRect([In] /*HWND*/ HandleRef hDlg, [In, Out] ref RECT lpRect);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int DlgDirList([In] /*HWND*/ HandleRef hDlg, [In, Out] StringBuilder lpPathSpec, [In] int nIDListBox, [In] int nIDStaticPath, [In] UINT uFileType);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DlgDirSelectEx([In] /*HWND*/ HandleRef hwndDlg, [Out] /*_ecount(chCount)*/ LPTSTR lpString, [In] int chCount, [In] int idListBox);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int DlgDirListComboBox([In] /*HWND*/ HandleRef hDlg, [In, Out] StringBuilder lpPathSpec, [In] int nIDComboBox, [In] int nIDStaticPath, [In] UINT uFiletype);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL DlgDirSelectComboBoxEx([In] /*HWND*/ HandleRef hwndDlg, [Out] /*_ecount(cchOut)*/ LPTSTR lpString, [In] int cchOut, [In] int idComboBox);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern int SetScrollInfo([In] /*HWND*/ HandleRef hwnd, [In] int nBar, [In] /*const*/ ref SCROLLINFO lpsi, [In] BOOL redraw);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetScrollInfo([In] /*HWND*/ HandleRef hwnd, [In] int nBar, [In, Out] ref SCROLLINFO lpsi);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LRESULT DefFrameProc([In] /*HWND*/ HandleRef hWnd, [In, Optional] /*HWND*/ HandleRef hWndMDIClient, [In] UINT uMsg, [In] WPARAM wParam, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LRESULT DefMDIChildProc([In] /*HWND*/ HandleRef hWnd, [In] UINT uMsg, [In] WPARAM wParam, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL TranslateMDISysAccel([In] /*HWND*/ HandleRef hWndClient, [In] ref MSG lpMsg);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT ArrangeIconicWindows([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND CreateMDIWindow([In] LPCTSTR lpClassName, [In] LPCTSTR lpWindowName, [In] DWORD dwStyle, [In] int X, [In] int Y, [In] int nWidth, [In] int nHeight, [In, Optional] /*HWND*/ HandleRef hWndParent, [In, Optional] /*HINSTANCE*/ HandleRef hInstance, [In] LPARAM lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe WORD TileWindows([In, Optional] /*HWND*/ HandleRef hwndParent, [In] UINT wHow, [In, Optional] /*const*/ RECT* lpRect, [In] UINT cKids, [In, Optional] /*_ecount(cKids)*/ /*const*/ HWND[] lpKids);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern unsafe WORD CascadeWindows([In, Optional] /*HWND*/ HandleRef hwndParent, [In] UINT wHow, [In, Optional] /*const*/ RECT* lpRect, [In] UINT cKids, [In, Optional] /*_ecount(cKids)*/ /*const*/ HWND[] lpKids);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL WinHelp([In, Optional] /*HWND*/ HandleRef hWndMain, [In, Optional] LPCTSTR lpszHelp, [In] UINT uCommand, [In] ULONG_PTR dwData);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD GetGuiResources([In] /*HANDLE*/ HandleRef hProcess, [In] DWORD uiFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LONG ChangeDisplaySettings([In, Optional] IntPtr lpDevMode, [In] DWORD dwFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LONG ChangeDisplaySettings([In, Optional] ref DEVMODE lpDevMode, [In] DWORD dwFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LONG ChangeDisplaySettingsEx([In, Optional] LPCTSTR lpszDeviceName, [In, Optional] IntPtr lpDevMode, /*__reserved*/ HWND hwnd, [In] DWORD dwflags, [In, Optional] IntPtr lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern LONG ChangeDisplaySettingsEx([In, Optional] LPCTSTR lpszDeviceName, [In, Optional] ref DEVMODE lpDevMode, /*__reserved*/ HWND hwnd, [In] DWORD dwflags, [In, Optional] IntPtr lParam);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EnumDisplaySettings([In, Optional] LPCTSTR lpszDeviceName, [In] DWORD iModeNum, [In, Out] ref DEVMODE lpDevMode);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EnumDisplaySettingsEx([In, Optional] LPCTSTR lpszDeviceName, [In] DWORD iModeNum, [In, Out] ref DEVMODE lpDevMode, [In] DWORD dwFlags);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL EnumDisplayDevices([In, Optional] LPCTSTR lpDevice, [In] DWORD iDevNum, [In, Out] ref DISPLAY_DEVICE lpDisplayDevice, [In] DWORD dwFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SystemParametersInfo([In] UINT uiAction, [In] UINT uiParam, [In, Out, Optional] IntPtr pvParam, [In] UINT fWinIni);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SoundSentry();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern void SetDebugErrorLevel([In] DWORD dwLevel);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern void SetLastErrorEx([In] DWORD dwErrCode, [In] DWORD dwType);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern int InternalGetWindowText([In] /*HWND*/ HandleRef hWnd, [Out] /*_ecount_part(cchMaxCount, return + 1)*/ LPTSTR pString, [In] int cchMaxCount);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL EndTask([In] /*HWND*/ HandleRef hWnd, [In] BOOL fShutDown, [In] BOOL fForce);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL CancelShutdown();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HMONITOR MonitorFromPoint([In] POINT pt, [In] DWORD dwFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HMONITOR MonitorFromRect([In] /*const*/ ref RECT lprc, [In] DWORD dwFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HMONITOR MonitorFromWindow([In] /*HWND*/ HandleRef hwnd, [In] DWORD dwFlags);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetMonitorInfo([In] /*HMONITOR*/ HandleRef hMonitor, [In, Out] ref MONITORINFO lpmi);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL EnumDisplayMonitors([In, Optional] /*HDC*/ HandleRef hdc, [In, Optional] /*const*/ ref RECT lprcClip, [In] MONITORENUMPROC lpfnEnum, [In] LPARAM dwData);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern void NotifyWinEvent([In] DWORD @event, [In] /*HWND*/ HandleRef hwnd, [In] LONG idObject, [In] LONG idChild);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern HWINEVENTHOOK SetWinEventHook([In] DWORD eventMin, [In] DWORD eventMax, [In, Optional] /*HMODULE*/ HandleRef hmodWinEventProc, [In] WINEVENTPROC pfnWinEventProc, [In] DWORD idProcess, [In] DWORD idThread, [In] DWORD dwFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsWinEventHookInstalled([In] DWORD @event);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL UnhookWinEvent([In] /*HWINEVENTHOOK*/ HandleRef hWinEventHook);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetGUIThreadInfo([In] DWORD idThread, [In, Out] ref GUITHREADINFO pgui);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL BlockInput(BOOL fBlockIt);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL SetProcessDPIAware();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL IsProcessDPIAware();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT GetWindowModuleFileName([In] /*HWND*/ HandleRef hwnd, [Out] StringBuilder pszFileName, [In] UINT cchFileNameMax);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetCursorInfo([In, Out] ref CURSORINFO pci);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetWindowInfo([In] /*HWND*/ HandleRef hwnd, [In, Out] ref WINDOWINFO pwi);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetTitleBarInfo([In] /*HWND*/ HandleRef hwnd, [Out] out TITLEBARINFO pti);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetMenuBarInfo([In] /*HWND*/ HandleRef hwnd, [In] LONG idObject, [In] LONG idItem, [In, Out] ref MENUBARINFO pmbi);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetScrollBarInfo([In] /*HWND*/ HandleRef hwnd, [In] LONG idObject, [In, Out] ref SCROLLBARINFO psbi);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetComboBoxInfo([In] /*HWND*/ HandleRef hwndCombo, [In, Out] ref COMBOBOXINFO pcbi);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND GetAncestor([In] /*HWND*/ HandleRef hwnd, [In] UINT gaFlags);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern HWND RealChildWindowFromPoint([In] /*HWND*/ HandleRef hwndParent, [In] POINT ptParentClientCoords);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT RealGetWindowClass([In] /*HWND*/ HandleRef hwnd, [Out] StringBuilder ptszClassName, [In] UINT cchClassNameMax);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL GetAltTabInfo([In, Optional] /*HWND*/ HandleRef hwnd, [In] int iItem, [In, Out] ref ALTTABINFO pati, [Out, Optional] /*_ecount(cchItemText)*/ LPTSTR pszItemText, [In] UINT cchItemText);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern DWORD GetListBoxInfo([In] /*HWND*/ HandleRef hwnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL LockWorkStation();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL UserHandleGrantAccess([In] /*HANDLE*/ HandleRef hUserHandle, [In] /*HANDLE*/ HandleRef hJob, [In] BOOL bGrant);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT GetRawInputData([In] /*HRAWINPUT*/ HandleRef hRawInput, [In] UINT uiCommand, [Out, Optional] /*_bcount_part(*pcbSize, return)*/ IntPtr pData, [In, Out] ref UINT pcbSize, [In] UINT cbSizeHeader);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern UINT GetRawInputDeviceInfo([In, Optional] /*HANDLE*/ HandleRef hDevice, [In] UINT uiCommand, [In, Out, Optional] /*_bcount_part(*pcbSize, return)*/ IntPtr pData, [In, Out] ref UINT pcbSize);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern UINT GetRawInputBuffer([Out, Optional] /*_bcount(*pcbSize)*/ RAWINPUT[] pData, [In, Out] ref UINT pcbSize, [In] UINT cbSizeHeader);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern BOOL RegisterRawInputDevices([In] /*_ecount(uiNumDevices)*/ /*const*/ RAWINPUTDEVICE[] pRawInputDevices, [In] UINT uiNumDevices, [In] UINT cbSize);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern UINT GetRegisteredRawInputDevices([Out, Optional] /*_ecount( *puiNumDevices)*/ RAWINPUTDEVICE[] pRawInputDevices, [In, Out] ref UINT puiNumDevices, [In] UINT cbSize);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern UINT GetRawInputDeviceList([Out, Optional] /*_ecount(*puiNumDevices)*/ RAWINPUTDEVICELIST[] pRawInputDeviceList, [In, Out] ref UINT puiNumDevices, [In] UINT cbSize);
			//[DllImport("User32.dll", SetLastError = true)]
			//public static extern LRESULT DefRawInputProc([In] /*_ecount(nInput)*/ ref RAWINPUT[] paRawInput, [In] INT nInput, [In] UINT cbSizeHeader);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ChangeWindowMessageFilter([In] UINT message, [In] DWORD dwFlag);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ShutdownBlockReasonCreate([In] /*HWND*/ HandleRef hWnd, [In] LPCTSTR pwszReason);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ShutdownBlockReasonQuery([In] /*HWND*/ HandleRef hWnd, [Out, Optional] /*_ecount(*pcchBuff)*/ LPTSTR pwszBuff, [In, Out] ref DWORD pcchBuff);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern BOOL ShutdownBlockReasonDestroy([In] /*HWND*/ HandleRef hWnd);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern IntPtr GetFocus();
			[DllImport("User32.dll", SetLastError = true)]
			public static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, int wMsgFilterMin, int wMsgFilterMax, int wRemoveMsg);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern bool DestroyIcon(IntPtr hIcon);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern bool DrawFrameControl(HandleRef hDC, ref Rect rect, FrameControlType type, int state);
			[DllImport("User32.dll", SetLastError = true)]
			public static extern IntPtr LoadImage(IntPtr hinst, IntPtr lpszName, ImageType uType, int cxDesired, int cyDesired, LoadOptions fuLoad);
		}
	}

	public struct MENUITEMINFO
	{
		public int cbSize;
		public MenuItemInfoMask fMask;
		public int fType;
		public int fState;
		public int wID;
		public IntPtr hSubMenu;
		public IntPtr hbmpChecked;
		public IntPtr hbmpUnchecked;
		public IntPtr dwItemData;
		public IntPtr dwTypeData;
		public int cch;
		public IntPtr hbmpItem;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DEVMODE
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dmDeviceName;
		public WORD dmSpecVersion;
		public WORD dmDriverVersion;
		public WORD dmSize;
		public WORD dmDriverExtra;
		public DWORD dmFields;
		public short dmOrientation;
		public short dmPaperSize;
		public short dmPaperLength;
		public short dmPaperWidth;
		public short dmScale;
		public short dmCopies;
		public short dmDefaultSource;
		public short dmPrintQuality;
		public short dmColor;
		public short dmDuplex;
		public short dmYResolution;
		public short dmTTOption;
		public short dmCollate;
		public unsafe fixed byte dmFormName[32];
		public WORD dmLogPixels;
		public DWORD dmBitsPerPel;
		public DWORD dmPelsWidth;
		public DWORD dmPelsHeight;
		public DWORD dmDisplayFlags;
		public DWORD dmDisplayFrequency;
		public DWORD dmICMMethod;
		public DWORD dmICMIntent;
		public DWORD dmMediaType;
		public DWORD dmDitherType;
		public DWORD dmReserved1;
		public DWORD dmReserved2;
		public DWORD dmPanningWidth;
		public DWORD dmPanningHeight;
	}

	public struct MSG { public IntPtr hWnd; public int Message; public IntPtr wParam; public IntPtr lParam; public int Time; public int X; public int Y; }
	public struct Rect { public Rect(int left, int top, int right, int bottom) { this.left = left; this.top = top; this.right = right; this.bottom = bottom; } public int left; public int top; public int right; public int bottom; internal static Rect FromRectangle(Rectangle rectangle) { return new Rect(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom); } public Rectangle ToRectangle() { return new Rectangle(this.left, this.top, this.right - this.left, this.bottom - this.top); } }
	public struct TPMPARAMS { public UINT cbSize; public RECT rcExclude; }
	public struct POINT { public int x; public int y; }
	public struct SIZE { public int cx; public int cy; }
	[Flags]
	public enum DrawFrameControlStyles { None = 0, Inactive = 0x0100, Pushed = 0x0200, Checked = 0x0400, Transparent = 0x0800, Hot = 0x1000, AdjustRect = 0x2000, Flat = 0x4000, Mono = 0x8000 }
	[Flags]
	public enum MenuItemInfoMask { None = 0, State = 0x0001, Id = 0x0002, SubMenu = 0x0004, CheckMarks = 0x0008, Type = 0x0010, Data = 0x0020, String = 0x0040, Bitmap = 0x0080, FType = 0x0100 }
	public enum ImageType { Bitmap = 0, Cursor = 2, EnhancedMetafile = 3, Icon = 1 }
	public enum LoadOptions { None = 0, Color = 2, CopyDeleteORG = 8, CopyFromResource = 0x4000, CopyReturnORG = 4, CreateDIBSection = 0x2000, DefaultColor = 0, DefaultSize = 0x40, LoadFromFile = 0x10, LoadMAP3DColors = 0x1000, Monochrome = 1, Shared = 0x8000, Transparent = 0x20, VGAColor = 0x80 }
	public enum FrameControlType { Caption = 1, Menu = 2, Scroll = 3, Button = 4, PopupMenu = 5 }
	public delegate LRESULT WNDPROC(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam);
	public delegate INT_PTR DLGPROC(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam);
	public delegate void TIMERPROC(HWND hWnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime);
	public delegate BOOL GRAYSTRINGPROC(HDC hDC, LPARAM lpData, int nCount);
	public delegate BOOL WNDENUMPROC(HWND hWnd, LPARAM lParam);
	public delegate LRESULT HOOKPROC(int code, WPARAM wParam, LPARAM lParam);
	public delegate void SENDASYNCPROC(HWND hWnd, UINT uMsg, ULONG_PTR dwData, LRESULT lResult);
	public delegate BOOL PROPENUMPROC(HWND hWnd, string lpszString, HANDLE hData);
	public delegate BOOL PROPENUMPROCEX(HWND hWnd, string lpszString, HANDLE hData, ULONG_PTR dwData);
	public delegate int EDITWORDBREAKPROC(string lpch, int ichCurrent, int cch, int code);
	public delegate BOOL DRAWSTATEPROC(HDC hdc, LPARAM lData, WPARAM wData, int cx, int cy);


	[Flags]
	public enum ReBarInfoMask { None = 0, RBIM_IMAGELIST = 0x00000001 }

	[Flags]
	public enum ReBarStyles
	{
		None = 0,
		ToolTips = 0x00000100,
		VarHeight = 0x00000200,
		BandBorders = 0x00000400,
		FixedOrder = 0x00000800,
		RegisterDrop = 0x00001000,
		AutoSize = 0x00002000,
		VerticalGripper = 0x00004000,  // this always has the vertical gripper (default for horizontal mode)
		DblClkToggle = 0x00008000,
	}

	[Flags]
	public enum ReBarBandStyles
	{
		None = 0,
		Break = 0x00000001,  // break to new line
		FixedSize = 0x00000002,  // band can't be sized
		ChildEdge = 0x00000004,  // edge around top & bottom of child window
		Hidden = 0x00000008,  // don't show
		NoVert = 0x00000010,  // don't show when vertical
		FixedBmp = 0x00000020,  // bitmap doesn't move during band resize
		VariableHeight = 0x00000040,  // allow autosizing of this child vertically
		GripperAlways = 0x00000080,  // always show the gripper
		NoGrippper= 0x00000100,  // never show the gripper
		UseChevron = 0x00000200,  // display drop-down button for this band if it's sized smaller than ideal width
		HideTitle = 0x00000400,  // keep band title hidden
		TopAlign = 0x00000800,  // keep band in top row
	}

	[Flags]
	public enum ReBarBandInfoMask
	{
		None = 0,
		Style = 0x00000001,
		Colors = 0x00000002,
		Text = 0x00000004,
		Image = 0x00000008,
		Child = 0x00000010,
		ChildSize = 0x00000020,
		Size = 0x00000040,
		Background = 0x00000080,
		Id = 0x00000100,
		IdealSize = 0x00000200,
		LParam = 0x00000400,
		HeaderSize = 0x00000800,  // control the size of the header
		ChevronLocation = 0x00001000,
		ChevronState = 0x00002000,
		All = ~0,
	}

	public enum ReBarMessage
	{
		INSERTBANDA = (0x400 /*WM_USER*/ + 1),
		DELETEBAND = (0x400 /*WM_USER*/ + 2),
		GETBARINFO = (0x400 /*WM_USER*/ + 3),
		SETBARINFO = (0x400 /*WM_USER*/ + 4),
		//GETBANDINFO = (0x400 /*WM_USER*/ + 5),
		SETBANDINFOA = (0x400 /*WM_USER*/ + 6),
		SETPARENT = (0x400 /*WM_USER*/ + 7),
		HITTEST = (0x400 /*WM_USER*/ + 8),
		GETRECT = (0x400 /*WM_USER*/ + 9),
		INSERTBANDW = (0x400 /*WM_USER*/ + 10),
		SETBANDINFOW = (0x400 /*WM_USER*/ + 11),
		GETBANDCOUNT = (0x400 /*WM_USER*/ + 12),
		GETROWCOUNT = (0x400 /*WM_USER*/ + 13),
		GETROWHEIGHT = (0x400 /*WM_USER*/ + 14),
		IDTOINDEX = (0x400 /*WM_USER*/ + 16), // wParam == id
		GETTOOLTIPS = (0x400 /*WM_USER*/ + 17),
		SETTOOLTIPS = (0x400 /*WM_USER*/ + 18),
		SETBKCOLOR = (0x400 /*WM_USER*/ + 19), // sets the default BK color
		GETBKCOLOR = (0x400 /*WM_USER*/ + 20), // defaults to CLR_NONE
		SETTEXTCOLOR = (0x400 /*WM_USER*/ + 21),
		GETTEXTCOLOR = (0x400 /*WM_USER*/ + 22), // defaults to 0x00000000
		RBSTR_CHANGERECT = 0x0001,   // flags for SIZETORECT
		SIZETORECT = (0x400 /*WM_USER*/ + 23), // resize the rebar/break bands and such to this rect (lparam)
		SETCOLORSCHEME = 0x2000 /*CCM_FIRST*/ + 2, // lParam is color scheme
		GETCOLORSCHEME = 0x2000 /*CCM_FIRST*/ + 3, // fills in COLORSCHEME pointed to by lParam
		BEGINDRAG = (0x400 /*WM_USER*/ + 24),
		ENDDRAG = (0x400 /*WM_USER*/ + 25),
		DRAGMOVE = (0x400 /*WM_USER*/ + 26),
		GETBARHEIGHT = (0x400 /*WM_USER*/ + 27),
		GETBANDINFOW = (0x400 /*WM_USER*/ + 28),
		GETBANDINFOA = (0x400 /*WM_USER*/ + 29),
		MINIMIZEBAND = (0x400 /*WM_USER*/ + 30),
		MAXIMIZEBAND = (0x400 /*WM_USER*/ + 31),
		GETDROPTARGET = (0x2000 /*CCM_FIRST*/ + 4),
		GETBANDBORDERS = (0x400 /*WM_USER*/ + 34), // returns in lparam = lprc the amount of edges added to band wparam
		SHOWBAND = (0x400 /*WM_USER*/ + 35), // show/hide band
		SETPALETTE = (0x400 /*WM_USER*/ + 37),
		GETPALETTE = (0x400 /*WM_USER*/ + 38),
		MOVEBAND = (0x400 /*WM_USER*/ + 39),
		SETUNICODEFORMAT = 0x2000 /*CCM_FIRST*/ + 5,
		GETUNICODEFORMAT = 0x2000 /*CCM_FIRST*/ + 6,
		GETBANDMARGINS = (0x400 /*WM_USER*/ + 40),
		SETWINDOWTHEME = 0x2000 /*CCM_FIRST*/ + 0xB,
		SETEXTENDEDSTYLE = (0x400 /*WM_USER*/ + 41),
		GETEXTENDEDSTYLE = (0x400 /*WM_USER*/ + 42),
		PUSHCHEVRON = (0x400 /*WM_USER*/ + 43),
		/// <summary>Only valid in Windows Vista and later.</summary>
		SETBANDWIDTH = (0x400 /*WM_USER*/ + 44), // set width for docked band
	}

	public enum ReBarNotificationMessage
	{
		HEIGHTCHANGE = (-831 /*RBN_FIRST*/ - 0),
		GETOBJECT = (-831 /*RBN_FIRST*/ - 1),
		LAYOUTCHANGED = (-831 /*RBN_FIRST*/ - 2),
		AUTOSIZE = (-831 /*RBN_FIRST*/ - 3),
		BEGINDRAG = (-831 /*RBN_FIRST*/ - 4),
		ENDDRAG = (-831 /*RBN_FIRST*/ - 5),
		DELETINGBAND = (-831 /*RBN_FIRST*/ - 6), // Uses NMREBAR
		DELETEDBAND = (-831 /*RBN_FIRST*/ - 7), // Uses NMREBAR
		CHILDSIZE = (-831 /*RBN_FIRST*/ - 8),
		CHEVRONPUSHED = (-831 /*RBN_FIRST*/ - 10),
		SPLITTERDRAG = (-831 /*RBN_FIRST*/ - 11),
		MINMAX = (-831 /*RBN_FIRST*/ - 21),
		AUTOBREAK = (-831 /*RBN_FIRST*/ - 22),
	}

	[Flags]
	public enum ReBarNotificationMask
	{
		None = 0,
		ID = 0x00000001,
		STYLE = 0x00000002,
		LPARAM = 0x00000004,
	}

	[Flags]
	public enum ReBarAddBandFlags
	{
		None = 0,
		AUTOSIZE = 0x0001,   // These are not flags and are all mutually exclusive
		ADDBAND = 0x0002,
	}

	public enum ReBarHitTest
	{
		None = 0,
		NOWHERE = 0x0001,
		CAPTION = 0x0002,
		CLIENT = 0x0003,
		GRABBER = 0x0004,
		CHEVRON = 0x0008,
		SPLITTER = 0x0010,
	}

	[Flags]
	public enum CommonControlStyles
	{
		None = 0,
		Top = 0x00000001,
		NoMoveY = 0x00000002,
		Bottom = 0x00000003,
		NoResize = 0x00000004,
		NoParentAlign = 0x00000008,
		Adjustable = 0x00000020,
		NoDivider = 0x00000040,
		Vertical = 0x00000080,
		Left = (Vertical | Top),
		Right = (Vertical | Bottom),
		NoMoveX = (Vertical | NoMoveY),
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public class ReBarBandInfo
	{
		private UINT cbSize = Marshal.SizeOf(typeof(ReBarBandInfo));
		public ReBarBandInfoMask Mask;
		public ReBarBandStyles Style;
		public COLORREF ForeColor;
		public COLORREF BackColor;
		[MarshalAs(UnmanagedType.LPTStr)]
		private string lpText;
		private UINT cch;
		public string Text { get { return this.lpText; } set { this.lpText = value; this.cch = value != null ? value.Length : 0; } }
		public int ImageIndex;
		public HWND Child;
		public UINT MinChildWidth;
		public UINT MinChildHeight;
		public UINT Width;
		public HBITMAP BackImage;
		public UINT Id;
		public UINT ChildHeight;
		public UINT MaxChildHeight;
		public UINT IntegralHeight;
		public UINT IdealWidth;
		public LPARAM lParam;
		public UINT HeaderWidth;
	}

	public class ReBarInfo
	{
		private UINT cbSize = Marshal.SizeOf(typeof(ReBarInfo));
		public ReBarInfoMask fMask;
		public HIMAGELIST himl;
	}

	public struct NotificationMessageHeader
	{
		public HWND hwndFrom;
		public IntPtr idFrom;
		public UINT code;
	}

	public struct NotificationMessageReBarChildSize
	{
		public NotificationMessageHeader hdr;
		public UINT uBand;
		public UINT wID;
		public RECT rcChild;
		public RECT rcBand;
	}

	public struct NotificationMessageReBar
	{
		public NotificationMessageHeader hdr;
		public ReBarNotificationMask dwMask;
		public UINT uBand;
		public ReBarBandStyles fStyle;
		public UINT wID;
		public LPARAM lParam;
	}

	public struct NotificationMessageReBarAutoSize
	{
		public NotificationMessageHeader hdr;
		[MarshalAs(UnmanagedType.Bool)]
		public BOOL fChanged;
		public RECT rcTarget;
		public RECT rcActual;
	}

	public struct NotificationMessageReBarChevron
	{
		public NotificationMessageHeader hdr;
		public UINT uBand;
		public UINT wID;
		public LPARAM lParam;
		public RECT rc;
		public LPARAM lParamNM;
	}

	public struct NotificationMessageReBarSplitter
	{
		public NotificationMessageHeader hdr;
		public RECT rcSizing;
	}

	public struct NotificationMessageReBarAutoBreak
	{
		public NotificationMessageHeader hdr;
		public UINT uBand;
		public UINT wID;
		public LPARAM lParam;
		public UINT uMsg;
		public ReBarBandStyles fStyleCurrent;
		[MarshalAs(UnmanagedType.Bool)]
		public BOOL fAutoBreak;
	}

	public struct NotificationMessageReBarHitTestInfo
	{
		public POINT pt;
		public UINT flags;
		public int iBand;
	}
}