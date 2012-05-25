#region using

using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

#endregion

namespace Negar.PersianCalendar.UI
{
    /// <summary>
    /// كلاس مدیریت قالب های تقویم
    /// </summary>
    internal class PersianThemeManager
    {

        #region Fields
        public static event EventHandler ManagerThemeChanged;
        #endregion

        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        private PersianThemeManager()
        {
        }

        #endregion

        #region Properties
        /// <summary>
        /// Checks if the control can paint itself using styles. Styles are only available on WindowsXP or 
        /// greater, and should be enabled by the developer, 
        /// using <see cref="Application.RenderWithVisualStyles">RenderWithVisualStyles</see> 
        /// property of <see cref="Application">Application</see> class.
        /// </summary>
        public static Boolean UseThemes
        {
            get { return VisualStyleInformation.IsSupportedByOS && Application.RenderWithVisualStyles; }
        }

        #endregion

        #region Methods

        protected internal static void OnManagerThemeChanged(EventArgs e)
        {
            if (ManagerThemeChanged != null)
                ManagerThemeChanged(null, e);
        }

        #endregion
    }
}