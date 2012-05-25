#region using
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using Negar.PersianCalendar.UI.PersianPopup;
#endregion

namespace Negar.PersianCalendar.UI.PersianPopup
{
    [UIPermission(SecurityAction.Assert, Window = UIPermissionWindow.AllWindows, Clipboard = UIPermissionClipboard.OwnClipboard)]
    [ReflectionPermission(SecurityAction.Assert, Flags = ReflectionPermissionFlag.AllFlags)]
    [SecurityPermission(SecurityAction.Assert, Flags =
        SecurityPermissionFlag.UnmanagedCode | SecurityPermissionFlag.ControlAppDomain | SecurityPermissionFlag.ControlThread)]
    internal class HookManager
    {
        #region Fields

        private static readonly HookManager defaultManager = new HookManager();
        private readonly Hashtable hookHash;
        public ArrayList HookControllers;

        #endregion

        #region Ctor & Dtor
        /// <summary>
        /// سازنده پیش فرض كلاس
        /// </summary>
        public HookManager()
        {
            Application.ApplicationExit += OnApplicationExit;
            Application.ThreadExit += OnThreadExit;
            hookHash = new Hashtable();
            HookControllers = new ArrayList();
        }

        ~HookManager()
        {
            RemoveHooks();
            Application.ApplicationExit -= OnApplicationExit;
            Application.ThreadExit -= OnThreadExit;
        }
        #endregion

        #region Properties

        #region static HookManager DefaultManager
        public static HookManager DefaultManager
        {
            get { return defaultManager; }
        }
        #endregion

        #region Hashtable HookHash
        public Hashtable HookHash
        {
            get { return hookHash; }
        }
        #endregion

        #region static Int32 CurrentThread
        public static Int32 CurrentThread
        {
            get { return GetCurrentThreadId(); }
        }
        #endregion

        #endregion

        #region Methods

        #region public void CheckController(IHookController ctrl)
        public void CheckController(IHookController ctrl)
        {
            HookInfo hInfo = GetInfoByThread();
            if (hInfo.HookControllers.Contains(ctrl)) return;
            AddController(ctrl);
        }
        #endregion

        #region public void AddController(IHookController ctrl)
        public void AddController(IHookController ctrl)
        {
            HookInfo hInfo = GetInfoByThread();
            hInfo.HookControllers.Add(ctrl);
            if (hInfo.HookControllers.Count == 1) InstallHook(hInfo);
        }
        #endregion

        #region public void RemoveController(IHookController ctrl)
        public void RemoveController(IHookController ctrl)
        {
            HookInfo hInfo = GetInfoByThread();
            hInfo.HookControllers.Remove(ctrl);
            if (hInfo.HookControllers.Count == 0) RemoveHook(hInfo, false);
        }
        #endregion

        #region protected virtual HookInfo GetInfoByThread()
        protected virtual HookInfo GetInfoByThread()
        {
            Int32 thId = CurrentThread;
            HookInfo hInfo = HookHash[thId] as HookInfo;
            if (hInfo == null)
            {
                hInfo = new HookInfo(); //(this);
                HookHash[thId] = hInfo;
            }
            return hInfo;
        }
        #endregion

        #region internal void InstallHook(HookInfo hInfo)
        internal void InstallHook(HookInfo hInfo)
        {
            if (hInfo.wndHookHandle != IntPtr.Zero) return;
            hInfo.mouseHookProc = MouseHook;
            hInfo.wndHookProc = WndHook;
            hInfo.getMessageHookProc = GetMessageHook;
            hInfo.wndHookHandle = SetWindowsHookEx(4, hInfo.wndHookProc, 0, hInfo.ThreadId);
            hInfo.mouseHookHandle = SetWindowsHookEx(7, hInfo.mouseHookProc, 0, hInfo.ThreadId);
            hInfo.getMessageHookHandle = IntPtr.Zero;
        }
        #endregion

        #region internal void RemoveHook(HookInfo hInfo, Boolean disposing)
        internal void RemoveHook(HookInfo hInfo, Boolean disposing)
        {
            if (hInfo.wndHookHandle != IntPtr.Zero)
            {
                UnhookWindowsHookEx(hInfo.wndHookHandle);
                hInfo.wndHookHandle = IntPtr.Zero;
                hInfo.wndHookProc = null;

                hInfo.getMessageHookHandle = IntPtr.Zero;
                hInfo.getMessageHookProc = null;
                UnhookWindowsHookEx(hInfo.mouseHookHandle);
                hInfo.mouseHookHandle = IntPtr.Zero;
                hInfo.mouseHookProc = null;
                HookHash.Remove(hInfo.ThreadId);
            }
        }
        #endregion

        #region private void OnThreadExit(object sender, EventArgs e)
        private void OnThreadExit(object sender, EventArgs e)
        {
            RemoveHook(GetInfoByThread(), true);
        }
        #endregion

        #region private void OnApplicationExit(object sender, EventArgs e)
        private void OnApplicationExit(object sender, EventArgs e)
        {
            Application.ThreadExit -= OnThreadExit;
            Application.ApplicationExit -= OnApplicationExit;
            RemoveHooks();
        }
        #endregion

        #region protected virtual void RemoveHooks()
        protected virtual void RemoveHooks()
        {
            ArrayList list = new ArrayList();
            foreach (HookInfo h in HookHash.Values) list.Add(h);
            HookHash.Clear();
            for (Int32 n = 0; n < list.Count; n++)
                RemoveHook(list[n] as HookInfo, true);
        }
        #endregion

        #region protected Int32 WndHook(Int32 ncode, IntPtr wParam, IntPtr lParam)
        protected Int32 WndHook(Int32 ncode, IntPtr wParam, IntPtr lParam)
        {
            HookInfo hInfo = GetInfoByThread();
            Int32 res;
            CWPSTRUCT hookStr = (CWPSTRUCT)Marshal.PtrToStructure(lParam, typeof(CWPSTRUCT));
            Control ctrl = null;

            try
            {
                if (!hInfo.inHook && lParam != IntPtr.Zero)
                {
                    try
                    {
                        ctrl = Control.FromHandle(hookStr.hwnd);
                        hInfo.inHook = true;
                    }
                    finally { hInfo.inHook = false; }
                }
                else return CallNextHookEx(hInfo.wndHookHandle, ncode, wParam, lParam);
                res = CallNextHookEx(hInfo.wndHookHandle, ncode, wParam, lParam);
            }
            finally
            { InternalPostFilterMessage(hInfo, hookStr.message, ctrl, hookStr.hwnd, hookStr.wParam, hookStr.lParam); }
            return res;
        }
        #endregion

        #region protected Int32 GetMessageHook(Int32 ncode, IntPtr wParam, IntPtr lParam)
        protected Int32 GetMessageHook(Int32 ncode, IntPtr wParam, IntPtr lParam)
        {
            HookInfo hInfo = GetInfoByThread();
            API_MSG hookStr = (API_MSG)Marshal.PtrToStructure(lParam, typeof(API_MSG));
            if (!hInfo.inHook && lParam != IntPtr.Zero)
            {
                try
                {
                    hInfo.inHook = true;
                    InternalGetMessage(ref hookStr);
                }
                finally
                {
                    hInfo.inHook = false;
                }
            }
            return CallNextHookEx(hInfo.wndHookHandle, ncode, wParam, lParam);
        }
        #endregion

        #region protected Int32 MouseHook(Int32 ncode, IntPtr wParam, IntPtr lParam)
        protected Int32 MouseHook(Int32 ncode, IntPtr wParam, IntPtr lParam)
        {
            HookInfo hInfo = GetInfoByThread();
            Boolean allowFutureProcess = true;
            if (ncode == 0)
            {
                MOUSEHOOKSTRUCT hookStr = (MOUSEHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MOUSEHOOKSTRUCT));
                if (!hInfo.inMouseHook && lParam != IntPtr.Zero)
                {
                    try
                    {
                        Control ctrl = Control.FromHandle(hookStr.hwnd);
                        hInfo.inMouseHook = true;
                        allowFutureProcess = !InternalPreFilterMessage(hInfo, wParam.ToInt32(), ctrl, hookStr.hwnd, IntPtr.Zero,
                            new IntPtr((hookStr.Pt.X << 16) | hookStr.Pt.Y));
                    }
                    finally
                    {
                        hInfo.inMouseHook = false;
                    }
                }
                else return CallNextHookEx(hInfo.mouseHookHandle, ncode, wParam, lParam);
            }
            Int32 res = CallNextHookEx(hInfo.mouseHookHandle, ncode, wParam, lParam);
            if (!allowFutureProcess) res = -1;
            return res;
        }
        #endregion

        #region internal static Boolean InternalPreFilterMessage(...)
        internal static Boolean InternalPreFilterMessage(HookInfo hInfo, Int32 Msg,
            Control wnd, IntPtr HWnd, IntPtr WParam, IntPtr LParam)
        {
            Boolean result = false;
            for (Int32 n = 0; n < hInfo.HookControllers.Count; n++)
            {
                IHookController ctrl = hInfo.HookControllers[n] as IHookController;
                if (ctrl != null)
                    result |=
                        ctrl.InternalPreFilterMessage(Msg, wnd, HWnd, WParam, LParam);
            }
            return result;
        }
        #endregion

        #region internal Boolean InternalPostFilterMessage(...)
        internal Boolean InternalPostFilterMessage(HookInfo hInfo, Int32 Msg, Control wnd, IntPtr HWnd, IntPtr WParam, IntPtr LParam)
        {
            Boolean result = false;
            for (Int32 n = hInfo.HookControllers.Count - 1; n >= 0; n--)
            {
                IHookController ctrl = hInfo.HookControllers[n] as IHookController;
                if (ctrl != null)
                    result |= ctrl.InternalPostFilterMessage(Msg, wnd, HWnd, WParam, LParam);
                if (Msg == 0x2 && ctrl != null && ctrl.OwnerHandle == HWnd) RemoveController(ctrl);
            }
            return result;
        }
        #endregion

        #region internal void InternalGetMessage(ref API_MSG msg)
        internal void InternalGetMessage(ref API_MSG msg)
        {
            HookInfo hInfo = GetInfoByThread();
            for (Int32 n = 0; n < hInfo.HookControllers.Count; n++)
            {
                IHookController2 ctrl = hInfo.HookControllers[n] as IHookController2;
                if (ctrl != null)
                {
                    Message m = msg.ToMessage();
                    ctrl.WndGetMessage(ref m);
                    msg.FromMessage(ref m);
                }
            }
        }
        #endregion

        #endregion

        #region Native Methods

        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern Int32 GetCurrentThreadId();

        [DllImport("USER32.dll", CharSet = CharSet.Auto)]
        protected static extern IntPtr SetWindowsHookEx(Int32 idHook, Hook lpfn, Int32 hMod, Int32 dwThreadId);

        [DllImport("USER32.dll", CharSet = CharSet.Auto)]
        protected static extern Int32 CallNextHookEx(IntPtr hhk, Int32 nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("USER32.dll", CharSet = CharSet.Auto)]
        protected static extern Boolean UnhookWindowsHookEx(IntPtr hhk);

        #region Nested type: internal struct API_MSG
        [StructLayout(LayoutKind.Sequential)]
        internal struct API_MSG
        {
            public IntPtr Hwnd;
            public Int32 Msg;
            public IntPtr WParam;
            public IntPtr LParam;
            public Int32 Time;
            public POINT Pt;

            public Message ToMessage()
            {
                var res = new Message();
                res.HWnd = Hwnd;
                res.Msg = Msg;
                res.WParam = WParam;
                res.LParam = LParam;
                return res;
            }

            public void FromMessage(ref Message msg)
            {
                Hwnd = msg.HWnd;
                Msg = msg.Msg;
                WParam = msg.WParam;
                LParam = msg.LParam;
            }
        }

        #endregion

        #region Nested type: internal struct CWPRETSTRUCT

        [StructLayout(LayoutKind.Sequential)]
        internal struct CWPRETSTRUCT
        {
            public IntPtr lResult;
            public IntPtr lParam;
            public IntPtr wParam;
            public Int32 message;
            public IntPtr hwnd;
        }

        #endregion

        #region Nested type: internal struct CWPSTRUCT
        [StructLayout(LayoutKind.Sequential)]
        internal struct CWPSTRUCT
        {
            public IntPtr lParam;
            public IntPtr wParam;
            public Int32 message;
            public IntPtr hwnd;
        }
        #endregion

        #region Nested type: internal struct MOUSEHOOKSTRUCT
        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEHOOKSTRUCT
        {
            public POINT Pt;
            public IntPtr hwnd;
            public uint wHitTestCode;
            public IntPtr dwExtraInfo;
        }
        #endregion

        #region Nested type: internal struct POINT
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public Int32 X;
            public Int32 Y;
        }
        #endregion

        #endregion
    }
}