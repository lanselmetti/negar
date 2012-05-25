using System;
using System.Drawing;
using System.Windows.Forms;

namespace Negar.PersianCalendar.UI.PersianPopup
{
    public interface IPopupServiceControl
    {
        Boolean IsDummy { get; }
        Boolean SetVisibleCore(IntPtr handle, Boolean newVisible);
        Boolean SetSimpleVisibleCore(IntPtr handle, IntPtr parentForm, Boolean newVisible);
        Boolean WndProc(ref Message m);
        void UpdateTopMost(IntPtr handle);
        void PopupShowing(IPopupControl popup);
        void PopupClosed(IPopupControl popup);
        void EmulateFormFocus(IntPtr formHandle);
    }

    public interface IPopupControl
    {
        Control PopupWindow { get; }
        void ClosePopup();
        void ShowPopup();
        Boolean AllowMouseClick(Control control, Point mousePosition);
    }
}