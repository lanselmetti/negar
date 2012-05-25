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
    /// كلاس مدیریت اطلاعات حساب تصویربرداری
    /// </summary>
    public static class Account
    {

        #region Fields
        private static List<CostsAndDiscountsType> _CostAndDiscountFullList;
        private static List<SP_SelectBanksResult> _BanksFullList;
        #endregion

        #region Properties

        #region List<CostsAndDiscountsType> CostAndDiscountFullList
        /// <summary>
        /// لیست تخفیف ها و هزینه های تعریف شده تصویربرداری در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. همراه با آیتم انتخاب نشده
        /// </remarks>
        public static List<CostsAndDiscountsType> CostAndDiscountFullList
        {
            get
            {
                if (_CostAndDiscountFullList == null)
                    try
                    {
                        Table<CostsAndDiscountsType> TempData = Manager.DBML.CostsAndDiscountsTypes;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _CostAndDiscountFullList = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست تخفیف ها و هزینه های تعریف شده تصویربرداری ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Account",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return null;
                    }
                    #endregion
                return _CostAndDiscountFullList;
            }
            set { _CostAndDiscountFullList = value; }
        }
        #endregion

        #region List<SP_SelectBanksResult> BanksFullList
        /// <summary>
        /// لیست بانك های تعریف شده تصویربرداری در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. همراه با آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectBanksResult> BanksFullList
        {
            get
            {
                if (_BanksFullList == null)
                    try { _BanksFullList = Manager.DBML.SP_SelectBanks().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست بانك های تعریف شده تصویربرداری ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Account",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return null;
                    }
                    #endregion
                return _BanksFullList;
            }
            set { _BanksFullList = value; }
        }
        #endregion

        #endregion

        #region Methods

        #region Int32? GetRefIDByTransID(Int32 TransID)
        /// <summary>
        /// تابع خواندن شماره مراجعه با كلید تراكنش
        /// </summary>
        /// <param name="TransID">كلید تراكنش</param>
        /// <returns>كلید مراجعه یا تهی برای خطا</returns>
        public static Int32? GetRefIDByTransID(Int32 TransID)
        {
            Int32? ReturnValue;
            try
            {
                List<Int32> TransData = Manager.DBML.RefTransactions.
                    Where(Data => Data.ID == TransID).Select(Data => Data.ReferralIX).Take(1).ToList();
                if (TransData.Count == 0)
                {
                    PMBox.Show("مراجعه ای با تراكنش ارسال شده وجود ندارد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                ReturnValue = TransData.First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات كلید مراجعه بر اساس تراكنش از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Db Layer - Accounts", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            return ReturnValue;
        }
        #endregion

        #region IQueryable<Int16> GetUserExcludedCD(Int16 UserID)
        /// <summary>
        /// تابع خواندن تخفیف ها و هزینه های محدود شده برای یك كاربر
        /// </summary>
        /// <returns>لیست محدودیت ها یا تهی برای خطا</returns>
        public static IQueryable<Int16> GetUserExcludedCD(Int16 UserID)
        {
            try
            {
                IQueryable<Int16> List = Manager.DBML.CostsAndDiscountsUsersExcludes.
                    Where(Data => Data.UserIX == UserID).Select(Data => Data.CDIX);
                return List;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "خواندن اطلاعات دسترسی كاربر به تخفیف ها و هزینه ها ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Db Layer - Accounts", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #endregion

    }
}