using System;
using System.Drawing;
using System.Windows.Forms;

namespace Negar.PersianCalendar.UI.PersianPopup
{
    internal class PersianHookPopup : IHookController, IDisposable
    {
        #region Fields

        private const Int32 WM_ACTIVATEAPP = 0x1C;
        private const Int32 WM_LBUTTONUP = 0x0202;

        private const Int32 WM_MAXCLICK = 0x208;

        private const Int32 WM_MAXNCCLICK = 0x0a9;

        private const Int32 WM_MBUTTONUP = 0x0208;

        private const Int32 WM_MINCLICK = 0x201;
        private const Int32 WM_MINNCCLICK = 0xA1;
        private const Int32 WM_RBUTTONUP = 0x0205;

        private static readonly Int32[] upMessages = new[]
                                                         {
                                                             WM_LBUTTONUP,
                                                             WM_RBUTTONUP,
                                                             WM_MBUTTONUP
                                                         };

        private readonly IPopupControl popup;

        #endregion

        #region Ctor

        public PersianHookPopup(IPopupControl popup)
        {
            this.popup = popup;
            HookManager.DefaultManager.AddController(this);
        }

        #endregion

        #region Dispose

        public virtual void Dispose()
        {
            HookManager.DefaultManager.RemoveController(this);
        }

        #endregion

        #region Methods

        public IPopupControl Popup
        {
            get { return popup; }
        }

        Boolean IHookController.InternalPreFilterMessage(Int32 Msg, Control wnd, IntPtr HWnd, IntPtr WParam, IntPtr LParam)
        {
            Control control = Control.FromHandle(HWnd);
            if ((Msg >= WM_MINCLICK && Msg <= WM_MAXCLICK) || (Msg >= WM_MINNCCLICK && Msg <= WM_MAXNCCLICK))
            {
                if (Array.IndexOf(upMessages, Msg) != -1) return false;
                CheckMouseDown(control, Control.MousePosition);
            }

            if (Msg == WM_ACTIVATEAPP)
            {
                if (WParam.ToInt32() == 0)
                    ClosePopups();
            }

            return false;
        }

        Boolean IHookController.InternalPostFilterMessage(Int32 Msg, Control wnd, IntPtr HWnd, IntPtr WParam, IntPtr LParam)
        {
            return false;
        }

        IntPtr IHookController.OwnerHandle
        {
            get
            {
                var popup = Popup as Control;
                return popup == null || !popup.IsHandleCreated ? IntPtr.Zero : popup.Handle;
            }
        }

        protected Control GetParent(Control control)
        {
            Control parent = control;
            while (parent.Parent != null) parent = parent.Parent;
            return parent;
        }

        protected void CheckMouseDown(Control control, Point mousePosition)
        {
            var popup = Popup as Control;
            IPopupControl pc = Popup;
            if (pc == null || !popup.Created || !popup.Visible || pc.PopupWindow == null || !pc.PopupWindow.Visible)
                return;

            Control parent = GetParent(pc.PopupWindow);
            if (parent.Contains(control) || parent == control || popup == control || popup.Contains(control))
                return;

            if (IsPopupMenu(control))
                return;

            if (!pc.AllowMouseClick(control, mousePosition))
                pc.ClosePopup();
        }

        protected static Boolean IsPopupMenu(Control control)
        {
            if (control is PersianShadow)
                return true;

            //if(control != null && control.GetType().Name == "PopupMenuBarControl") return true; 
            return false;
        }

        protected void ClosePopups()
        {
            Popup.ClosePopup();
        }

        #endregion
    }
}