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
    public static class Settings
    {

        #region Fields
        private static List<UsersSetting> _CurrentUserSettingsFullList;
        #endregion

        #region Properties

        #region List<UsersSetting> CurrentUserSettingsFullList
        /// <summary>
        /// لیست تنظیمات ثبت شده برای كابر جاری در سیستم تصویربرداری
        /// </summary>
        public static List<UsersSetting> CurrentUserSettingsFullList
        {
            get
            {
                if (_CurrentUserSettingsFullList == null)
                    try
                    {
                        IQueryable<UsersSetting> TempList = Manager.DBML.UsersSettings.
                            Where(Data => Data.UserIX == SecurityManager.CurrentUserID);
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempList);
                        _CurrentUserSettingsFullList = TempList.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست تنظیمات ثبت شده برای كابر جاری ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Settings",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _CurrentUserSettingsFullList;
            }
            set { _CurrentUserSettingsFullList = value; }
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean InsertCurrentUserSetting(Int16 SettingID , Boolean? BoolValue , String StringValue)
        /// <summary>
        /// تابعی برای ثبت تنظیمات كاربری برای كاربر جاری
        /// </summary>
        /// <returns>ثبت موفقیت آمیز یا وقوع خطا</returns>
        public static Boolean InsertCurrentUserSetting(Int16 SettingID, Boolean? BoolValue, String StringValue)
        {
            Boolean Result = InsertUserSetting(SecurityManager.CurrentUserID, SettingID, BoolValue, StringValue);
            if (Result) _CurrentUserSettingsFullList = null;
            return Result;
        }
        #endregion

        #region Boolean InsertUserSetting(Int16 UserID, Int16 SettingID, Boolean? BoolValue, String StringValue)
        /// <summary>
        /// تابعی برای ثبت تنظیمات كاربری برای یك كاربر خاص
        /// </summary>
        /// <returns>ثبت موفقیت آمیز یا وقوع خطا</returns>
        public static Boolean InsertUserSetting(Int16 UserID, Int16 SettingID, Boolean? BoolValue, String StringValue)
        {
            try { Manager.DBML.SP_InsertUserSetting(UserID, SettingID, BoolValue, StringValue); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ثبت تنظیمات برای كاربر انتخاب شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DBLayer - Settings",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean ClearUserSettings(Int16 UserID)
        /// <summary>
        /// تابعی برای حذف كلیه تنظیمات كاربری برای یك كاربر خاص
        /// </summary>
        /// <returns>حذف موفقیت آمیز یا وقوع خطا</returns>
        public static Boolean ClearUserSettings(Int16 UserID)
        {
            try
            {
                IQueryable<UsersSetting> DataToDelete = Manager.DBML.UsersSettings.Where(Data => Data.UserIX == UserID);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, DataToDelete);
                Manager.DBML.UsersSettings.DeleteAllOnSubmit(DataToDelete);
                Manager.DBML.SubmitChanges();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان حذف تنظیمات كاربر انتخاب شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DBLayer - Settings",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean InsertSystemSetting(Int16 SettingID , Boolean? BoolValue , String StringValue)
        /// <summary>
        /// تابعی برای ثبت تنظیمات سیستمی
        /// </summary>
        /// <returns>ثبت موفقیت آمیز یا وقوع خطا</returns>
        public static Boolean InsertSystemSetting(Int16 SettingID, Boolean? BoolValue, String StringValue)
        {
            try
            {
                IQueryable<UsersSetting> SettingData =
                    Manager.DBML.UsersSettings.Where(Data => Data.SettingIX == SettingID);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, SettingData);
                if (SettingData.Count() == 0)
                {
                    UsersSetting NewSetting = new UsersSetting();
                    NewSetting.SettingIX = SettingID;
                    NewSetting.Boolean = BoolValue;
                    NewSetting.Value = StringValue;
                    Manager.DBML.UsersSettings.InsertOnSubmit(NewSetting);
                    Manager.DBML.SubmitChanges();
                }
                else
                {
                    SettingData.First().Boolean = BoolValue;
                    SettingData.First().Value = StringValue;
                    Manager.DBML.SubmitChanges();
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ثبت تظیمات انتخاب شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DBLayer - Settings",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region UsersSetting ReadSetting(Int16 SettingID, Int16? UserID)
        /// <summary>
        /// تابعی برای خواندن تنظیمات كاربری یا تنظیمات عمومی
        /// </summary>
        public static UsersSetting ReadSetting(Int16 SettingID, Int16? UserID)
        {
            try
            {
                IQueryable<UsersSetting> SettingData =
                    Manager.DBML.UsersSettings.Where(Data => Data.SettingIX == SettingID);
                if (UserID != null) SettingData = SettingData.Where(Data => Data.UserIX == UserID.Value);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, SettingData);
                if (SettingData.Count() == 0) return null;
                return SettingData.First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن تنظیمات انتخاب شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DBLayer - Settings",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #endregion

    }
}