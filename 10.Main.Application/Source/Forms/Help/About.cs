#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
#endregion

namespace Sepehr.Forms.Help
{
    /// <summary>
    /// فرم اسپلش سیستم
    /// </summary>
    public partial class frmAbout : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض كلاس
        /// </summary>
        public frmAbout()
        {
            InitializeComponent();
            lblVersion.Text = "نسخه برنامه: " + Assembly.GetExecutingAssembly().GetName().Version;
            lblCopyright.Text += " " + PersianDateConverter.ToPersianDate(DateTime.Now).Year;
            List<HISApplication> DbData;
            try { DbData = Negar.DBLayerPMS.Manager.DBML.HISApplications.ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات نسخه بانك اطلاعات!" + "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.", "خطا!");
                LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                Close();
                return;
            }
            #endregion
            lblPMSDbVersion.Text += DbData.Where(Data => Data.ID == 1).First().DbVersion;
            lblIMSDbVersion.Text += DbData.Where(Data => Data.ID == 500).First().DbVersion;
            ShowDialog();
        }
        #endregion

        #region Event Hadlers

        #region PictureBoxLogo_MouseClick
        private void PictureBoxLogo_MouseClick(object sender, MouseEventArgs e)
        {
            ClosingTimer.Tick -= ClosingTimer_Tick;
            Close();
        }
        #endregion

        #region ClosingTimer_Tick
        private void ClosingTimer_Tick(object sender, EventArgs e)
        {
            ClosingTimer.Tick -= ClosingTimer_Tick;
            Close();
        }
        #endregion

        #endregion

    }
}