#region using

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace Negar.PersianCalendar.UI.Helpers
{
    internal class ControlUtils
    {
        #region Native Methods

        [DllImport("USER32.dll")]
        private static extern Int16 GetAsyncKeyState(Int32 vKey);

        #endregion

        #region Properties

        #region public static MouseButtons MouseButtons
        public static MouseButtons MouseButtons
        {
            get
            {
                MouseButtons ms = MouseButtons.None;
                if (GetAsyncKeyState(1) != 0) ms |= MouseButtons.Left;
                if (GetAsyncKeyState(2) != 0) ms |= MouseButtons.Right;
                if (GetAsyncKeyState(4) != 0) ms |= MouseButtons.Middle;
                return ms;
            }
        }

        #endregion
        
        #endregion

        #region Methods

        #region public static Point CalcLocation(Point bottomLocation, Point topLocation, Size popupSize)
        public static Point CalcLocation(Point bottomLocation, Point topLocation, Size popupSize)
        {
            Point location = bottomLocation;
            Rectangle rect = SystemInformation.WorkingArea;
            if (SystemInformation.MonitorCount > 1)
            {
                Screen scrBottom = Screen.FromPoint(bottomLocation), scrTop = Screen.FromPoint(topLocation);
                if (scrBottom.Equals(scrTop)) rect = scrTop.WorkingArea;
                else rect = scrBottom.WorkingArea;
            }
            Int32 bottom = bottomLocation.Y + popupSize.Height;
            Int32 top = topLocation.Y - popupSize.Height;
            Int32 maxBottomOutsize = bottom - rect.Bottom;
            Int32 maxTopOutsize = rect.Top - top;
            if (maxBottomOutsize > 0 && maxBottomOutsize > maxTopOutsize)
            {
                location = topLocation;
                location.Y -= popupSize.Height;
            }
            if (location.X + popupSize.Width > rect.Right)
            {
                location.X = (rect.Right - popupSize.Width);
            }
            if (location.X < rect.Left) location.X = rect.Left;
            return location;
        }
        #endregion

        #endregion
    }
}