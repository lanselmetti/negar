using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Negar.PersianCalendar.UI.PersianPopup;

namespace Negar.PersianCalendar.UI.PersianPopup
{

    internal class PersianWinPopupController : IPopupServiceControl
    {
        #region Constants

        private const Int32 HWND_TOPMOST = -1;
        protected const Int32 MA_NOACTIVATE = 3;

        private const Int32 SWP_NOACTIVATE = 0x0010;

        private const Int32 SWP_NOMOVE = 0x0002;
        private const Int32 SWP_NOSIZE = 0x0001;

        private const Int32 SWP_SHOWWINDOW = 0x0040;

        protected const Int32 WM_LBUTTONDOWN = 0x0201;
        protected const Int32 WM_MOUSEACTIVATE = 0x0021;

        #endregion

        #region IPopupServiceControl

        public void UpdateTopMost(IntPtr handle)
        {
            SetWindowPos(handle, (IntPtr)HWND_TOPMOST, 0, 0, 0, 0,
                         SWP_NOACTIVATE | SWP_SHOWWINDOW | SWP_NOSIZE | SWP_NOMOVE);
        }

        public Boolean SetVisibleCore(IntPtr handle, Boolean newVisible)
        {
            if (!newVisible)
            {
                return false;
            }
            else
            {
                UpdateTopMost(handle);
                ShowWindow(handle, 8);
                return true;
            }
        }

        public Boolean SetSimpleVisibleCore(IntPtr handle, IntPtr parentForm, Boolean newVisible)
        {
            if (!newVisible)
            {
                return false;
            }
            else
            {
                SetWindowPos(handle, parentForm, 0, 0, 100, 100,
                             SWP_NOACTIVATE | SWP_SHOWWINDOW | SWP_NOMOVE | SWP_NOSIZE);
                ShowWindow(handle, 8);
                return true;
            }
        }

        public void EmulateFormFocus(IntPtr formHandle)
        {
            SendMessage(formHandle, 0x86, 1, 0);
        }

        public Boolean WndProc(ref Message m)
        {
            Control control = Control.FromHandle(m.HWnd);
            switch (m.Msg)
            {
                case WM_MOUSEACTIVATE:
                    m.Result = (IntPtr)MA_NOACTIVATE;
                    return true;
                case WM_LBUTTONDOWN:
                    if (control is ListBox) return true;
                    break;
            }
            return false;
        }

        public Boolean IsDummy
        {
            get { return false; }
        }

        #endregion

        #region Methods

        public virtual void PopupClosed(IPopupControl popup)
        {
        }

        public virtual void PopupShowing(IPopupControl popup)
        {
        }

        #endregion

        #region Native Methods

        [DllImport("USER32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 cmdShow);

        [DllImport("USER32.dll")]
        private static extern Boolean SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, Int32 X, Int32 Y, Int32 cx,
                                                   Int32 cy,
                                                   uint uFlags);

        [DllImport("user32.dll")]
        private static extern Int32 SendMessage(IntPtr hWnd, Int32 Msg, uint wParam, uint lParam);

        #endregion
    }

    internal class PersianHookPopupController : PersianWinPopupController
    {
        #region Fields

        private readonly ArrayList Popups;

        #endregion

        #region Ctor

        public PersianHookPopupController()
        {
            Popups = new ArrayList();
        }

        #endregion

        #region Methods

        protected virtual PersianHookPopup FindPopup(IPopupControl popup)
        {
            for (Int32 n = 0; n < Popups.Count; n++)
            {
                var ppp = Popups[n] as PersianHookPopup;
                if (ppp.Popup == popup) return ppp;
            }

            return null;
        }

        public override void PopupClosed(IPopupControl popup)
        {
            PersianHookPopup ppp = FindPopup(popup);
            if (ppp != null)
            {
                Popups.Remove(ppp);
                ppp.Dispose();
            }
        }

        public override void PopupShowing(IPopupControl popup)
        {
            Popups.Add(new PersianHookPopup(popup));
        }

        #endregion
    }
}