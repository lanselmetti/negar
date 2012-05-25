#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using DevComponents.DotNetBar;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms.Administration
{
    /// <summary>
    /// فرم نمایش رخدادهای به وقوع پیوسته در سیستم
    /// </summary>
    public partial class frmEventViewer : Form
    {

        #region Fields

        #region List<SP_SelectUsersResult> _UsersData
        /// <summary>
        /// لیست كاربران ثبت شده در سیستم
        /// </summary>
        private List<SP_SelectUsersResult> _UsersData;
        #endregion

        #region List<SP_SelectCategoriesResult> _CategoriesData
        /// <summary>
        /// لیست طبقه بندی های رخداد های سیستم
        /// </summary>
        private List<SP_SelectCategoriesResult> _CategoriesData;
        #endregion

        #region List<HISApplication> _ApplicationData
        /// <summary>
        /// لیست نرم افزارهای نصب شده بر روی سیستم جاری
        /// </summary>
        private List<HISApplication> _ApplicationData;
        #endregion

        #region List<SP_SelectEventsResult> ReportData
        /// <summary>
        /// لیست رخداد های ثبت شده در سیستم
        /// </summary>
        private List<SP_SelectEventsResult> ReportData;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmEventViewer()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillFormBaseData()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            #region Set Time
            FromDate.SelectedDateTime = DateTime.Now.AddDays(-1);
            ToDate.SelectedDateTime = DateTime.Now;
            FromTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            ToTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            #endregion
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (!GenerateReport()) Close();
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

            #region btnHelp
            String TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnClose
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillFormBaseData()
        /// <summary>
        /// تابع خواندن اطلاعات پایه فرم
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillFormBaseData()
        {
            try
            {
                _ApplicationData = Negar.DBLayerPMS.Manager.DBML.HISApplications.
                    Where(Data => Data.ID == SecurityManager.CurrentApplicationID).ToList();
                _UsersData = Negar.DBLayerPMS.Security.UsersList.OrderBy(Users => Users.ID).ToList();
                _CategoriesData = Negar.DBLayerPMS.Manager.DBML.SP_SelectCategories().ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                PMBox.Show("خطا در خواندن اطلاعات برنامه ها  از بانك اطلاعات!" +
                           "موارد زیر را بررسی نمایید:\n" +
                           "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.", "خطا!");
                LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion

            #region Set Datasources
            cboApp.DataSource = _ApplicationData;
            cboApp.DisplayMember = "LocalizedName";
            cboApp.ValueMember = "ID";

            cboUser.DataSource = _UsersData;
            cboUser.DisplayMember = "FullName";
            cboUser.ValueMember = "ID";

            cboCategory.DataSource = _CategoriesData;
            cboCategory.DisplayMember = "LocaleTitle";
            cboCategory.ValueMember = "ID";
            #endregion

            return true;
        }
        #endregion

        #region Boolean GenerateReport()
        /// <summary>
        /// متدی كه جستجو را براساس فیلتر ها انجام می دهد
        /// </summary>
        private Boolean GenerateReport()
        {
            try
            {
                DateTime StartDate = new DateTime(FromDate.SelectedDateTime.Value.Year,
                    FromDate.SelectedDateTime.Value.Month, FromDate.SelectedDateTime.Value.Day,
                    FromTime.Value.Hour, FromTime.Value.Minute, FromTime.Value.Second);
                DateTime EndDate = new DateTime(ToDate.SelectedDateTime.Value.Year,
                    ToDate.SelectedDateTime.Value.Month, ToDate.SelectedDateTime.Value.Day,
                    ToTime.Value.Hour, ToTime.Value.Minute, ToTime.Value.Second);
                ReportData = Negar.DBLayerPMS.Manager.DBML.SP_SelectEvents(StartDate, EndDate).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات رخداد ها از بانك اطلاعات!" +
                           "موارد زیر را بررسی نمایید:\n" +
                           "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.", "خطا!");
                LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion

            #region Filter
            if (cboUser.SelectedIndex != 0)
                ReportData = ReportData.Where(Data => Data.UserIX == Convert.ToInt16(cboUser.SelectedValue)).ToList();
            if (cboCategory.SelectedIndex != 0)
                ReportData = ReportData.Where(Data => Data.CategoryIX == Convert.ToInt16(cboCategory.SelectedValue)).ToList();
            ReportData = ReportData.Where(Data => Data.ApplicationIX == Convert.ToInt16(cboApp.SelectedValue)).ToList();
            #endregion
            dgvData.DataSource = ReportData;
            return true;
        }
        #endregion

        #endregion

    }
}