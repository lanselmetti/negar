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
    /// كلاس مدیریت اطلاعات خدمات تصویربرداری
    /// </summary>
    public static class Services
    {

        #region Fields
        private static List<SP_SelectCategoriesResult> _ServCategoriesList;
        private static List<SP_SelectServicesListResult> _ServicesList;
        private static List<AdditionalPriceColumn> _ServAddinPriceColsList;
        private static List<SP_SelectGroupsResult> _ServGroupsList;
        private static List<SP_SelectServicesInGroupsResult> _ServicesInGroupsList;
        private static List<DefaultPerformers> _DefaultPerformersList;
        #endregion

        #region Properties

        #region List<SP_SelectCategoriesResult> ServCategoriesList
        /// <summary>
        /// لیست طبقه بندی های خدمات تعریف شده برای سیستم تصویربرداری
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. همراه با آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectCategoriesResult> ServCategoriesList
        {
            get
            {
                if (_ServCategoriesList == null)
                    try { _ServCategoriesList = Manager.DBML.SP_SelectCategories().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست طبقه بندی های خدمات تعریف شده ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Services",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _ServCategoriesList;
            }
            set { _ServCategoriesList = value; }
        }
        #endregion

        #region List<SP_SelectServicesListResult> ServicesList
        /// <summary>
        /// لیست خدمات تعریف شده برای سیستم تصویربرداری
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. همراه با آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectServicesListResult> ServicesList
        {
            get
            {
                if (_ServicesList == null)
                    try { _ServicesList = Manager.DBML.SP_SelectServicesList().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست خدمات تصویربرداری تعریف شده ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Services",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _ServicesList;
            }
            set { _ServicesList = value; }
        }
        #endregion

        #region List<AdditionalPriceColumn> ServAddinPriceColsList
        /// <summary>
        /// لیست ستون های قیمت پایه اضافی خدمات برای سیستم تصویربرداری
        /// </summary>
        public static List<AdditionalPriceColumn> ServAddinPriceColsList
        {
            get
            {
                if (_ServAddinPriceColsList == null)
                    try
                    {
                        Table<AdditionalPriceColumn> TempData = Manager.DBML.AdditionalPriceColumns;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _ServAddinPriceColsList = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست ستون های قیمت پایه اضافی خدمات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Services",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _ServAddinPriceColsList;
            }
            set { _ServAddinPriceColsList = value; }
        }
        #endregion

        #region List<SP_SelectCategoriesResult> ServGroupsList
        /// <summary>
        /// لیست گروه های خدمات تعریف شده برای سیستم تصویربرداری
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. همراه با آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectGroupsResult> ServGroupsList
        {
            get
            {
                if (_ServGroupsList == null)
                    try { _ServGroupsList = Manager.DBML.SP_SelectGroups().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست گروه های خدمات تعریف شده ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Services",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _ServGroupsList;
            }
            set { _ServGroupsList = value; }
        }
        #endregion

        #region List<SP_SelectServicesInGroupsResult> ServicesInGroupsList
        /// <summary>
        /// لیست عضویت خدمات در گروه های خدمات در سیستم تصویربرداری
        /// </summary>
        public static List<SP_SelectServicesInGroupsResult> ServicesInGroupsList
        {
            get
            {
                if (_ServicesInGroupsList == null)
                    try { _ServicesInGroupsList = Manager.DBML.SP_SelectServicesInGroups().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست عضویت خدمات در گروه های خدمات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Services",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _ServicesInGroupsList;
            }
            set { _ServicesInGroupsList = value; }
        }
        #endregion

        #region List<DefaultPerformers> DefaultPerformersList
        /// <summary>
        /// لیست لیست كادر پزشكی پیش فرض خدمات
        /// </summary>
        public static List<DefaultPerformers> DefaultPerformersList
        {
            get
            {
                if (_DefaultPerformersList == null)
                    try
                    {
                        Table<DefaultPerformers> TempData = Manager.DBML.DefaultPerformers;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _DefaultPerformersList = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست كادر پزشكی پیش فرض خدمات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Services",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _DefaultPerformersList;
            }
            set { _DefaultPerformersList = value; }
        }
        #endregion

        #endregion

    }
}