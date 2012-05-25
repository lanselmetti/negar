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
    /// كلاس مدیریت اطلاعات بیمه های تصویربرداری
    /// </summary>
    public static class Insurance
    {

        #region Fields
        private static List<SP_SelectInsFullDataResult> _InsFullList;
        private static List<SP_SelectIns2FormulasResult> _Ins2FormulaList;
        #endregion

        #region Properties

        #region List<SP_SelectInsFullDataResult> InsFullList
        /// <summary>
        /// لیست بیمه های تعریف شده برای سیستم تصویربرداری در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. همراه با آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectInsFullDataResult> InsFullList
        {
            get
            {
                if (_InsFullList == null)
                    try { _InsFullList = Manager.DBML.SP_SelectInsFullData().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست بیمه های تعریف شده از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Insurance",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _InsFullList;
            }
            set { _InsFullList = value; }
        }
        #endregion

        #region List<SP_SelectIns2FormulasResult> Ins2FormulaList
        /// <summary>
        /// لیست فرمول های بیمه دوم تعریف شده برای سیستم تصویربرداری در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. همراه با آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectIns2FormulasResult> Ins2FormulaList
        {
            get
            {
                if (_Ins2FormulaList == null)
                    try { _Ins2FormulaList = Manager.DBML.SP_SelectIns2Formulas().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست فرمول های بیمه دوم تعریف شده ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Insurance",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _Ins2FormulaList;
            }
            set { _Ins2FormulaList = value; }
        }
        #endregion

        #region IQueryable<InsuranceService> InsServiceFullList
        /// <summary>
        /// لیست ارتباط بیمه ها با خدمات تصویربرداری
        /// </summary>
        public static IQueryable<InsuranceService> InsServiceFullList
        {
            get
            {
                    try
                    {
                        InsuranceService TempData = Manager.DBML.InsuranceServices.Take(1).First();
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست ارتباط بیمه ها با خدمات از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Insurance",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                    return Manager.DBML.InsuranceServices;
            }
        }
        #endregion

        #endregion

    }
}