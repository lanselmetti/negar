#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Schedules.Properties;
#endregion

namespace Sepehr.Settings.Schedules.Applications
{
    /// <summary>
    /// فرم افزودن یك روز تعطیل به یك برنامه نوبت دهی
    /// </summary>
    internal partial class frmHolidaysAdd : Balloon
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmHolidaysAdd()
        {
            InitializeComponent();
            if (!FillDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown

        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            DateSelected.SelectedDateTime = DateTime.Now;
        }

        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cboApplications.SelectedIndex == 0)
            {
                DBLayerIMS.Schedules.SchAppList = null;
                List<SP_SelectApplicationsResult> AppsList = DBLayerIMS.Schedules.SchAppList;
                if (AppsList == null) return;
                AppsList = AppsList.Where(Data => Data.ID != null).ToList();
                foreach (SP_SelectApplicationsResult Apps in AppsList)
                    if (!InsertSchHoliday(Apps.ID.Value, DateSelected.SelectedDateTime.Value.Date)) return;
            }
            else if (!InsertSchHoliday(Convert.ToInt16(cboApplications.SelectedValue),
                DateSelected.SelectedDateTime.Value.Date)) return;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
        #endregion

        #endregion

        #region Methods

        #region void SetControlsToolTipTexts()
        /// <summary>
        /// تابع تنظیم متن راهنمای كنترل ها
        /// </summary>
        private void SetControlsToolTipTexts()
        {
            const String TooltipHeader = "راهنمای تنظیمات سیستم";
            const String TooltipFooter = "سیستم مدیریت تصویربرداری سپهر";

            #region btnCancel
            String TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        private Boolean FillDataSource()
        {
            List<SP_SelectApplicationsResult> SchedulesApps = DBLayerIMS.Schedules.SchAppList;
            if (SchedulesApps == null) return false;
            if (SchedulesApps.Count == 1)
            {
                PMBox.Show("برنامه نوبت دهی برای افزودن روز تعطیل به آن وجود ندارد!\n" +
                    "ابتدا برنامه نوبت دهی جدیدی تعریف نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            SchedulesApps[0].Name = "(همه برنامه ها)";
            cboApplications.DataSource = SchedulesApps;
            return true;
        }
        #endregion

        #region Boolean InsertSchHoliday(Int16 ApplicationIX, DateTime HolidayDate)
        /// <summary>
        /// تابعی برای ثبت یك روز تعطیل برای برنامه نوبت دهی در بانك اطلاعات
        /// </summary>
        /// <returns>صحت ثبت اطلاعات یا وقوع خطا</returns>
        private static Boolean InsertSchHoliday(Int16 ApplicationIX, DateTime HolidayDate)
        {
            try { Manager.DBML.SP_InsertHolidays(ApplicationIX, HolidayDate); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = 
                    "امكان ثبت روز تعطیل انتخاب شده برای برنامه ی نوبت دهی مورد نظر در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}