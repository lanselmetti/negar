using System;
using System.Windows.Forms;

namespace Negar
{
    /// <summary>
    /// كلاس نمایش راهنمای برنامه ها در مرورگر وب
    /// </summary>
    public partial class HelpViewer : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده كلاس
        /// </summary>
        /// <param name="Path">آدرس فایل اجرایی</param>
        public HelpViewer(String Path)
        {
            InitializeComponent();
            HelpBrowser.Navigate(Path);
            Show();
        }
        #endregion

        #region HelpViewer_Shown
        private void HelpViewer_Shown(object sender, EventArgs e)
        {
            if (HelpBrowser.Document != null) Text += " - " + HelpBrowser.Document.Title;
        }
        #endregion

    }
}