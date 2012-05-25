#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.DBLayerIMS
{
    /// <summary>
    /// كلاس مدیریت اطلاعات صندوق های تصویربرداری
    /// </summary>
    public static class Cash
    {

        #region Fields
        private static List<SP_SelectCashesResult> _CashFullList;
        #endregion

        #region Properties

        #region List<SP_SelectInsFullDataResult> CashFullList
        /// <summary>
        /// لیست صندوق های تعریف شده برای سیستم تصویربرداری در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. همراه با آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectCashesResult> CashFullList
        {
            get
            {
                if (_CashFullList == null)
                    try { _CashFullList = Manager.DBML.SP_SelectCashes().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست صندوق های تعریف شده از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Cash",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _CashFullList;
            }
            set { _CashFullList = value; }
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean OpenCash(Int16 CashID, Int32 SupplyBegin)
        /// <summary>
        /// تابع باز كردن صندوق مشخص با موجودی ابتدایی تعیین شده توسط كاربر جاری
        /// </summary>
        /// <param name="CashID">كلید صندوق</param>
        /// <param name="SupplyBegin">مبلغ آغاز صندوق</param>
        /// <returns>صحت انجام كار</returns>
        public static Boolean OpenCash(Int16 CashID, Int32 SupplyBegin)
        {
            CashLog NewItem = new CashLog();
            NewItem.CashIX = CashID;
            NewItem.IsClosed = false;
            NewItem.StartDateTime = DateTime.Now;
            NewItem.FinishDateTime = null;
            NewItem.SupplyBegin = SupplyBegin;
            NewItem.SupplyEnd = null;
            NewItem.OpenerCashierIX = SecurityManager.CurrentUserID;
            NewItem.CloserCashierIX = null;
            Manager.DBML.CashLogs.InsertOnSubmit(NewItem);
            if (!Manager.Submit())
            {
                const String ErrorMessage = "امكان باز كردن صندوق انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region Boolean CloseCash(Int16 CashID, Int32 SupplyEnd)
        /// <summary>
        /// تابع بستن صندوق مشخص با موجودی نهایی تعیین شده توسط كاربر جاری
        /// </summary>
        /// <param name="CashID">كلید صندوق</param>
        /// <param name="SupplyEnd">مبلغ نهایی</param>
        /// <returns>صحت انجام كار</returns>
        public static Boolean CloseCash(Int16 CashID, Int32 SupplyEnd)
        {
            try
            {
                IQueryable<CashLog> CashLogData = Manager.DBML.CashLogs.
                    Where(Data => Data.CashIX == CashID && Data.FinishDateTime == null);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, CashLogData);
                foreach (CashLog log in CashLogData)
                {
                    log.IsClosed = true;
                    log.FinishDateTime = DateTime.Now;
                    log.SupplyEnd = SupplyEnd;
                    log.CloserCashierIX = SecurityManager.CurrentUserID;
                }
                Manager.DBML.SubmitChanges();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان بستن صندوق انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Db Layer - Cash", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Int32? GetCashLogOrderedPrice(Int32 CashLogID)
        /// <summary>
        /// تابعی برای بدست آوردن مبلغ موجودی مقرر یك لاگ صندوق
        /// </summary>
        /// <param name="CashLogID">كلید لاگ صندوق</param>
        /// <returns>مبلغ موجودی مقرر</returns>
        public static Int32? GetCashLogOrderedPrice(Int32 CashLogID)
        {
            try { return Manager.DBML.FK_GetCashLogStatutorySypply(CashLogID).Value; }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان محاسبه مبلغ موجودی مقرر صندوق انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Db Layer - Cash", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #endregion



    }
}