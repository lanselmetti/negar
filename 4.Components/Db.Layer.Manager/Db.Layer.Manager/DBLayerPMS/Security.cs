#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar.DBLayerPMS.DataLayer;
#endregion

namespace Negar.DBLayerPMS
{
    /// <summary>
    /// كلاس مدیریت اطلاعات امنیتی سیستم بیماران
    /// </summary>
    public static class Security
    {

        #region Fields
        private static List<SP_SelectUsersResult> _UsersList;
        private static List<SP_SelectGroupsResult> _GroupsList;
        private static List<SP_SelectUsersInGroupsResult> _UsersInGroupsList;
        #endregion

        #region Properties

        #region List<SP_SelectUsersResult> UsersList
        /// <summary>
        /// لیست كاربران ثبت شده در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها.
        /// این خصوصیت ، كاربران مدیریت با كلید 1 و 2 را نیز نمایش می دهد
        /// </remarks>
        public static List<SP_SelectUsersResult> UsersList
        {
            get
            {
                if (_UsersList == null)
                    try { _UsersList = Manager.DBML.SP_SelectUsers().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان خواندن اطلاعات كاربران از بانك اطلاعات بیماران ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Negar", "DB Layer - Security",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _UsersList;
            }
            set { _UsersList = value; }
        }
        #endregion

        #region List<SP_SelectGroupsResult> GroupsList
        /// <summary>
        /// لیست گروه های ثبت شده در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها.
        /// </remarks>
        public static List<SP_SelectGroupsResult> GroupsList
        {
            get
            {
                if (_GroupsList == null)
                    try { _GroupsList = Manager.DBML.SP_SelectGroups().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست گروه های كاربری از بانك اطلاعات بیماران ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Negar", "DB Layer - Security",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _GroupsList;
            }
            set { _GroupsList = value; }
        }
        #endregion

        #region List<SP_SelectUsersInGroupsResult> UsersInGroupsList
        /// <summary>
        /// لیست كاربران ثبت شده در سیستم
        /// </summary>
        public static List<SP_SelectUsersInGroupsResult> UsersInGroupsList
        {
            get
            {
                if (_UsersInGroupsList == null)
                    try { _UsersInGroupsList = Manager.DBML.SP_SelectUsersInGroups().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان خواندن اطلاعات كاربران عضو گروه از بانك اطلاعات بیماران ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Negar", "DB Layer - Security",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _UsersInGroupsList;
            }
            set { _UsersInGroupsList = value; }
        }
        #endregion

        #endregion

        #region Methods

        #region UsersList GetUserData(Int16 UserID)
        /// <summary>
        /// تابعی برای خواندن اطلاعات كامل یك كاربر از بانك اطلاعات
        /// </summary>
        /// <param name="UserID">كلید كاربر</param>
        /// <returns>شیء اطلاعات كاربر</returns>
        public static UsersList GetUserData(Int16 UserID)
        {
            try
            {
                UsersList TempData = Manager.DBML.UsersLists.Where(Data => Data.ID == UserID).First();
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                return TempData;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات كاربر انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - Security",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
        }
        #endregion

        #region Boolean GetUserPermission(Int16 UserID , Int32 ACLID)
        /// <summary>
        /// تابعی برای بررسی دسترسی یك كاربر به سطح دسترسی خاص
        /// </summary>
        /// <param name="UserID">كلید كاربر</param>
        /// <param name="ACLID">كلید دسترسی</param>
        /// <returns>دسترسی داشتن یا نداشتن كاربر</returns>
        public static Boolean GetUserPermission(Int16 UserID, Int32 ACLID)
        {
            Boolean? ReturnValue = null;
            try { Manager.DBML.SP_SelectACLPermissionsUsers(UserID, ACLID, ref ReturnValue); }
            #region Catch
            catch (Exception) { return false; }
            #endregion
            if (ReturnValue == null) return true;
            return ReturnValue.Value;
        }
        #endregion

        #region PermissionsUsers GetUserPermissionData(Int16 UserID, Int32 ACLID)
        /// <summary>
        /// تابعی برای خواندن شیء دسترسی یك كاربر به سطح دسترسی خاص
        /// </summary>
        /// <param name="UserID">كلید كاربر</param>
        /// <param name="ACLID">كلید دسترسی</param>
        /// <returns>شیء دسترسی</returns>
        public static PermissionsUsers GetUserPermissionData(Int16 UserID, Int32 ACLID)
        {
            try
            {
                PermissionsUsers ReturnValue =
                    Manager.DBML.PermissionsUsers.Where(Data => Data.ACLIX == ACLID && Data.UserIX == UserID).First();
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, ReturnValue);
                return ReturnValue;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات دسترسی كاربر انتخاب شده به سطح مورد نظر وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - Security",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
        }
        #endregion

        #region PermissionsGroups GetGroupPermissionData(Int16 GroupID, Int32 ACLID)
        /// <summary>
        /// تابعی برای خواندن شیء دسترسی یك گروه به سطح دسترسی خاص
        /// </summary>
        /// <param name="GroupID">كلید گروه</param>
        /// <param name="ACLID">كلید دسترسی</param>
        /// <returns>شیء دسترسی</returns>
        public static PermissionsGroups GetGroupPermissionData(Int16 GroupID, Int32 ACLID)
        {
            try
            {
                PermissionsGroups ReturnValue =
                    Manager.DBML.PermissionsGroups.Where(Data => Data.ACLIX == ACLID && Data.GroupIX == GroupID).First();
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, ReturnValue);
                return ReturnValue;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات دسترسی گروه كاربری انتخاب شده به سطح مورد نظر وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - Security",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
        }
        #endregion

        #region Boolean InsertUsersInGroups(Int16 UserID, Int16 GroupID)
        /// <summary>
        /// تابعی برای بررسی دسترسی یك كاربر به سطح دسترسی خاص
        /// </summary>
        /// <param name="UserID">كلید كاربر</param>
        /// <param name="GroupID">كلید گروه</param>
        /// <returns>انجام موفقیت آمیز ورود اطلاعات</returns>
        public static Boolean InsertUsersInGroups(Int16 UserID, Int16 GroupID)
        {
            try { Manager.DBML.SP_InsertUsersInGroups(UserID, GroupID); }
            #region Catch
            catch (Exception) { return false; }
            #endregion
            return true;
        }
        #endregion

        #region Boolean InsertACLPermissionUser(Int16 UserID, Int32 ACLID,Boolean? IsAllowed,Boolean? IsPremiered)
        /// <summary>
        /// تابعی برای ثبت دسترسی یك كاربر در یك سطح دسترسی معین
        /// </summary>
        /// <param name="UserID">كلید كاربر</param>
        /// <param name="ACLID">كلید دسترسی</param>
        /// <param name="IsAllowed">تعیین مجوز داشتن كاربر</param>
        /// <param name="IsPremiered">تعیین ارجحیت داشتن دسترسی كاربر نسبت به گروه های كاربری</param>
        /// <returns>انجام موفقیت آمیز ورود اطلاعات</returns>
        public static Boolean InsertACLPermissionUser(Int16 UserID, Int32 ACLID, Boolean? IsAllowed, Boolean? IsPremiered)
        {
            try { Manager.DBML.SP_InsertACLPermissionsUsers(UserID, ACLID, IsAllowed, IsPremiered); }
            #region Catch
            catch (Exception) { return false; }
            #endregion
            return true;
        }
        #endregion

        #region Boolean InsertACLPermissionsGroups(Int16? GroupID, Int32? ACLID, Boolean? IsAllowed)
        /// <summary>
        /// تابعی برای بررسی دسترسی یك گروه كاربری به سطح دسترسی خاص
        /// </summary>
        /// <param name="GroupID">كلید گروه</param>
        /// <param name="ACLID"> كلید دسترسی</param>
        /// <param name="IsAllowed"></param>
        /// <returns>انجام موفقیت آمیز ورود اطلاعات</returns>
        public static Boolean InsertACLPermissionsGroups(Int16? GroupID, Int32? ACLID, Boolean? IsAllowed)
        {
            try { Manager.DBML.SP_InsertACLPermissionsGroups(GroupID, ACLID, IsAllowed); }
            #region Catch
            catch (Exception) { return false; }
            #endregion
            return true;
        }
        #endregion

        #region List<SP_SelectACLResult> GetACLList(Int16 ApplicationID)
        /// <summary>
        /// تابعی برای بررسی لیست كامل دسترسی های ثبت شده در سیستم یا برای یك زیر سیستم
        /// </summary>
        /// <param name="ApplicationID">كلید برنامه مورد نظر</param>
        /// <returns>لیست كامل دسترسی های ثبت شده در سیستم یا برای یك زیر سیستم</returns>
        public static List<SP_SelectACLResult> GetACLList(Int16 ApplicationID)
        {
            List<SP_SelectACLResult> _ACLList;
            try { _ACLList = Manager.DBML.SP_SelectACL(ApplicationID).ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                   "خواندن اطلاعات نام دسترسی از بانك اطلاعات ممكن نیست.\n" +
                   "موارد زیر را بررسی نمایید:\n" +
                   "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Security Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return _ACLList;
        }
        #endregion

        #region List<SP_SelectACLPermissionsResult> GetACLAccessList(Int32 ACLID)
        /// <summary>
        /// تابعی برای خواندن لیست دسترسی های ثبت شده برای یك دسترسی مشخص
        /// </summary>
        /// <param name="ACLID">كلید دسترسی مورد نظر</param>
        /// <returns>لیست كامل دسترسی های ثبت شده به تفكیك گروه و كاربر</returns>
        public static List<SP_SelectACLPermissionsResult> GetACLAccessList(Int32 ACLID)
        {
            List<SP_SelectACLPermissionsResult> _ReturnValue;
            try { _ReturnValue = Manager.DBML.SP_SelectACLPermissions(ACLID).ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                   "خواندن اطلاعات دسترسی انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                   "موارد زیر را بررسی نمایید:\n" +
                   "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Security Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return _ReturnValue;
        }
        #endregion

        #endregion

    }
}