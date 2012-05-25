using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Negar.PersianCalendar.UI.Win32
{
    internal class User32
    {
        internal static Int32 MakeLong(Int32 lo, Int32 hi)
        {
            return ((lo & 0xffff) | (((short)hi) << 0x10));
        }

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern Boolean SystemParametersInfo(Int32 uiAction,
            Int32 uiParam, ref NONCLIENTMETRICS ncMetrics, Int32 fWinIni);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetSystemMenu(IntPtr hWnd, Boolean bRevert);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        [DllImport("User32.dll")]
        internal static extern Boolean MessageBeep(Int32 beep);

        [DllImport("comctl32.dll")]
        internal static extern void InitCommonControls();

        [DllImport("comctl32.dll")]
        internal static extern Boolean InitCommonControls(INITCOMMONCONTROLSEX iccex);

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        internal static extern Int32 LoadLibraryEx(String lpLibFileName, Int32 hFile, Int32 dwFlags);

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        internal static extern Int32 FreeLibrary(Int32 hLibModule);

        [DllImport("user32")]
        internal static extern Int32 SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32")]
        internal static extern Int32 ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        [DllImport("User32.dll")]
        internal static extern void keybd_event(byte bVk, byte bScan, Int32 dwFlags, Int32 dwExtraInfo);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Int32 GetSysColor(Int32 color);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Int32 SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, Int32 x, Int32 y, Int32 cx,
            Int32 cy, Int32 uFlags);

        [DllImport("USER32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, Int32 X, Int32 Y, Int32 cx,
            Int32 cy, uint uFlags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean PtInRect(ref RECT lpRect, Int32 x, Int32 y);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean ScrollWindow(IntPtr hWnd, Int32 xAmount, Int32 yAmount, ref RECT rectScrollRegion,
                                                 ref RECT rectClip);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean ScrollWindow(IntPtr hWnd, Int32 xAmount, Int32 yAmount, IntPtr rectScrollRegion,
                                                 IntPtr rectClip);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean ScrollWindowEx(IntPtr hWnd, Int32 nXAmount, Int32 nYAmount, IntPtr rectScrollRegion,
                                                   IntPtr rectClip, IntPtr hrgnUpdate, IntPtr prcUpdate, Int32 flags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean LockWindowUpdate(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetWindow(IntPtr hwnd, Int32 wCmd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean SetWindowText(IntPtr hwnd, ref String lpString);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Int32 ShowWindow(IntPtr hWnd, short cmdShow);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
                                                   [MarshalAs(UnmanagedType.LPTStr)] String lpszClass,
                                                   [MarshalAs(UnmanagedType.LPTStr)] String lpszWindow);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean AnimateWindow(IntPtr hWnd, uint dwTime, FlagsAnimateWindow dwFlags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean DragDetect(IntPtr hWnd, Point pt);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetSysColorBrush(Int32 index);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean InvalidateRect(IntPtr hWnd, ref RECT rect, Boolean erase);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SetCursor(IntPtr hCursor);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetFocus();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean ReleaseCapture();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean WaitMessage();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean TranslateMessage(ref MSG msg);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean DispatchMessage(ref MSG msg);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean PostMessage(IntPtr hWnd, Int32 Msg, Int32 wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Int32 SendMessage(IntPtr hWnd, Int32 Msg, Int32 wParam, Int32 lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern uint SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern Int32 SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, String lParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern Int32 SendMessage(HandleRef hWnd, Int32 wMsg, Int32 wParam, Int32 lParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern Int32 SendMessage(HandleRef hWnd, Int32 wMsg, Int32 wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean GetMessage(ref MSG msg, Int32 hWnd, uint wFilterMin, uint wFilterMax);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean PeekMessage(ref MSG msg, Int32 hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, uint flags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean MoveWindow(IntPtr hWnd, Int32 x, Int32 y, Int32 width, Int32 height, Boolean repaint);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Int32 SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, Int32 X, Int32 Y, Int32 Width,
            Int32 Height, FlagsSetWindowPos flags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize,
            IntPtr hdcSrc, ref POINT pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        [DllImport("user32")]
        internal static extern Int32 GetClientRect(IntPtr hwnd, ref RECT rc);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean ClientToScreen(IntPtr hWnd, ref POINT pt);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean ScreenToClient(IntPtr hWnd, ref POINT pt);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean TrackMouseEvent(ref TRACKMOUSEEVENTS tme);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean SetWindowRgn(IntPtr hWnd, IntPtr hRgn, Boolean redraw);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern ushort GetKeyState(Int32 virtKey);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean DrawFocusRect(IntPtr hWnd, ref RECT rect);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean HideCaret(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean ShowCaret(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern Boolean SystemParametersInfo(SystemParametersInfoActions uAction, uint uParam,
            ref uint lpvParam, uint fuWinIni);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr WindowFromPoint(POINT point);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern uint SetWindowLong(IntPtr hWnd, Int32 nIndex, uint dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern uint GetWindowLong(IntPtr hWnd, Int32 nIndex);
    }
}