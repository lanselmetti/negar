#region using
using System;
using System.Collections.Generic;
#endregion

namespace Negar
{
    /// <summary>
    /// كلاس مدیریت امنیت سیستم
    /// </summary>
    /// <remarks>
    /// این كلاس وظیفه مدیریت كاربر جاری برنامه ، سطح دسترسی كاربر و ثبت رویداد ها را بر عهده دارد
    /// </remarks>
    public static class SecurityManager
    {

        #region Fields

        #region Int16 _CurrentApplicationID
        /// <summary>
        /// كد  كاربر جاری
        /// </summary>
        private static Int16 _CurrentApplicationID;
        #endregion

        #region Int16 _CurrentUserID
        /// <summary>
        /// كد  كاربر جاری
        /// </summary>
        private static Int16 _CurrentUserID;

        #endregion

        #region KeyValuePair<Int32, Boolean?> _TempCurrentUserAccesList
        /// <summary>
        /// شیء دسترسی های خوانده شده قبلی از بانك اطلاعات
        /// </summary>
        private static Dictionary<Int32, Boolean?> _TempCurrentUserAccesList;
        #endregion

        #endregion

        #region Properties

        #region Int16 CurrentApplicationID
        /// <summary>
        /// كد  كاربر جاری
        /// </summary>
        public static Int16 CurrentApplicationID
        {
            get { return _CurrentApplicationID; }
            set { _CurrentApplicationID = value; }
        }
        #endregion

        #region Int16 CurrentUserID
        /// <summary>
        /// كد  كاربر جاری
        /// </summary>
        public static Int16 CurrentUserID
        {
            get { return _CurrentUserID; }
            set { _CurrentUserID = value; }
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean? GetCurrentUserPermission(Int32 AccessID)
        /// <summary>
        /// تابع تعیین سطح دسترسی كاربر جاری در برنامه جاری بر اساس نوع دسترسی
        /// </summary>
        /// <param name="AccessID">كد دسترسی</param>
        /// <returns>داشتن یا نداشتن دسترسی</returns>
        public static Boolean GetCurrentUserPermission(Int32 AccessID)
        {
            Boolean? ReturnValue;
            if (_TempCurrentUserAccesList != null && _TempCurrentUserAccesList.TryGetValue(AccessID, out ReturnValue))
                return ReturnValue.Value;
            if (_TempCurrentUserAccesList == null)
                _TempCurrentUserAccesList = new Dictionary<Int32, Boolean?>();
            ReturnValue = DBLayerPMS.Security.GetUserPermission(_CurrentUserID, AccessID);
            _TempCurrentUserAccesList.Add(AccessID, ReturnValue);
            return ReturnValue.Value;
        }
        #endregion

        #region void RenewAccess()
        /// <summary>
        /// تابع تخلیه سطوح دسترسی از حافظه
        /// </summary>
        public static void RenewAccess()
        {
            _TempCurrentUserAccesList = null;
        }
        #endregion

        #endregion

    }
}