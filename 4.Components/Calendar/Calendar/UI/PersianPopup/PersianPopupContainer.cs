using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Negar.PersianCalendar.UI.PersianPopup
{
    [ToolboxItem(false)]
    public class PersianPopupContainer : PersianTopFormBase
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style = unchecked((Int32) 0x80000000);
                cp.ClassStyle |= 0x0800;
                return cp;
            }
        }
    }
}