#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.Utilities;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Schedules
{
    /// <summary>
    ///  فرم خلاصه اطلاعات برنامه های نوبت دهی
    /// </summary>
    internal partial class frmAppsDescription : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAppsDescription(Int16 ApplicationID)
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillDataAppWeek(ApplicationID)) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            #region Set DayName
            for (Int32 i = 0; i < dgvData.Rows.Count; i++)
                switch (Convert.ToInt32(dgvData.Rows[i].Cells[0].Value))
                {
                    case 1: dgvData.Rows[i].Cells["DayName"].Value = "شنبه"; break;
                    case 2: dgvData.Rows[i].Cells["DayName"].Value = "یكشنبه"; break;
                    case 3: dgvData.Rows[i].Cells["DayName"].Value = "دوشنبه"; break;
                    case 4: dgvData.Rows[i].Cells["DayName"].Value = "سه شنبه"; break;
                    case 5: dgvData.Rows[i].Cells["DayName"].Value = "چهارشنبه"; break;
                    case 6: dgvData.Rows[i].Cells["DayName"].Value = "پنجشنبه"; break;
                    case 7: dgvData.Rows[i].Cells["DayName"].Value = "جمعه"; break;
                }
            #endregion
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            GC.Collect();
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean FillDataAppWeek(Int16 AppID)
        /// <summary>
        /// روال خواندن اطلاعات برنامه نوبت دهی
        /// </summary>
        /// <param name="AppID">كلید برنامه</param>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillDataAppWeek(Int16 AppID)
        {
            if (DBLayerIMS.Schedules.SchAppList == null) return false;
            SP_SelectApplicationsResult AppData = DBLayerIMS.Schedules.SchAppList.Where(Data => Data.ID == AppID).First();
            txtTitle.Text = AppData.Name;
            txtDescription.Text = AppData.Description;
            if (AppData.IsFixed == true) lblAppType.Text = "ثابت";
            else lblAppType.Text = "شناور";
            PersianDate OccuredDate = PersianDateConverter.ToPersianDate(AppData.StartDate.Value.Date);
            StartDate.Text = OccuredDate.Year + "/" + OccuredDate.Month + "/" + OccuredDate.Day;
            OccuredDate = PersianDateConverter.ToPersianDate(AppData.EndDate.Value.Date);
            EndDate.Text = OccuredDate.Year + "/" + OccuredDate.Month + "/" + OccuredDate.Day;
            try
            {
                List<SchAppWeekPeriods> AppWeekPeriods =
                    DBLayerIMS.Manager.DBML.SchAppWeekPeriods.Where(Data => Data.ApplicationIX == AppID).ToList();
                dgvData.DataSource = AppWeekPeriods.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات بازه های برنامه نوبت دهی از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}