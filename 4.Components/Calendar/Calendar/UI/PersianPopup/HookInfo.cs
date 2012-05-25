using System;
using System.Collections;
using System.Security.Permissions;

namespace Negar.PersianCalendar.UI.PersianPopup
{
    [UIPermission(SecurityAction.Assert, Window = UIPermissionWindow.AllWindows,
        Clipboard = UIPermissionClipboard.OwnClipboard)]
    [ReflectionPermission(SecurityAction.Assert, Flags = ReflectionPermissionFlag.AllFlags)]
    [SecurityPermission(SecurityAction.Assert,
        Flags =
            SecurityPermissionFlag.UnmanagedCode | SecurityPermissionFlag.ControlAppDomain |
            SecurityPermissionFlag.ControlThread)]
    internal class HookInfo
    {
        #region Fields

        private readonly ArrayList hookControllers;
        private readonly Int32 threadId;
        public IntPtr getMessageHookHandle;
        public Hook getMessageHookProc;
        public Boolean inHook, inMouseHook;
        public IntPtr mouseHookHandle;
        public Hook mouseHookProc;
        public IntPtr wndHookHandle;
        public Hook wndHookProc;
        //HookManager manager;

        #endregion

        #region Ctor

        public HookInfo() //(HookManager manager)
        {
            //this.manager = manager;
            inMouseHook = false;
            inHook = false;
            wndHookHandle = getMessageHookHandle = mouseHookHandle = IntPtr.Zero;
            wndHookProc = mouseHookProc = getMessageHookProc = null;
            threadId = HookManager.GetCurrentThreadId();
            hookControllers = new ArrayList();
        }

        #endregion

        #region Props

        public ArrayList HookControllers
        {
            get { return hookControllers; }
        }

        public Int32 ThreadId
        {
            get { return threadId; }
        }

        #endregion
    }
}