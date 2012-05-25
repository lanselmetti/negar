#region using
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Negar.Customers.Reports0003;
#endregion

namespace Negar.Customers.StartReports0003
{
    /// <summary>
    /// كلاس عمومی برای خواندن اطلاعات گزارش و فراخوانی فیلتر گزارش
    /// </summary>
    public static class ReportStartClass
    {

        #region Fields
        private const String _ReportName = "گزارش كاركرد كادر پزشكی";
        private const String _CustomerName = "مركز تصویربرداری سهند قزوین";
        private const String _ReleaseDate = "89/08/09";
        private const String _Version = "11";
        private const String _LastDeveloper = "سعید پورنجاتی";
        #endregion

        #region Properties
        public static String ReportName
        { get { return _ReportName; } }
        public static String CustomerName
        { get { return _CustomerName; } }
        public static String ReleaseDate
        { get { return _ReleaseDate; } }
        public static String Version
        { get { return _Version; } }
        public static String LastDeveloper
        { get { return _LastDeveloper; } }
        #endregion

        #region Methods

        #region public static void StartReport(String ConnectionName)
        public static void StartReport(String ConnectionName)
        {
            CSManager.CurrentSetting = ConnectionName;
            try { new frmFilter(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان فراخوانی گزارش انتخاب شده وجود ندارد.\n" +
                    "لطفا با واحد پشتیبانی نرم افزار تماس حاصل نمایید.";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Customers Report0003",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return;
            }
            #endregion
        }
        #endregion

        #endregion

    }
}