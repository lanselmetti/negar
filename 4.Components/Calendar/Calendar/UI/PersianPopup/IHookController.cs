using System;
using System.Windows.Forms;

namespace Negar.PersianCalendar.UI.PersianPopup
{
    internal interface IHookController
    {
        IntPtr OwnerHandle { get; }
        Boolean InternalPreFilterMessage(Int32 Msg, Control wnd, IntPtr HWnd, IntPtr WParam, IntPtr LParam);
        Boolean InternalPostFilterMessage(Int32 Msg, Control wnd, IntPtr HWnd, IntPtr WParam, IntPtr LParam);
    }

    internal interface IHookController2 : IHookController
    {
        void WndGetMessage(ref Message msg);
    }
}