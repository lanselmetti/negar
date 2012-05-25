#region using
using System;
using mCore;

#endregion

namespace Negar.SMSManager
{
    /// <summary>
    /// كلاس نگاهدارنده اشیاء اطلاعات پیام ارسال شده
    /// </summary>
    public class SMSSentResultData
    {

        #region Fields

        #region String _DestinationPhoneNumber
        /// <summary>
        /// فیلد نگدارنده شماره تلفن همراه جهت ارسال پیام كوتاه
        /// </summary>
        private String _DestinationPhoneNumber;
        #endregion

        #region Int32 _MessageReference
        /// <summary>
        /// فیلد نگدارنده مرجع پیام
        /// </summary>
        private Int32 _MessageReference;
        #endregion

        #region Boolean _IsSent
        /// <summary>
        /// فیلد نگهدارنده  ارسال شدن یا نشدن پیام
        /// </summary>
        private Boolean _IsSent;
        #endregion

        #region DateTime _SendDate
        /// <summary>
        /// فیلد نگهدارنده زمان ارسال شدن پیام
        /// </summary>
        private DateTime _SendDate;
        #endregion

        #endregion

        #region Properties

        #region String DestinationPhoneNumber
        /// <summary>
        /// خصوصیت نگاه دارنده شماره تلفن همراه جهت ارسال پیام كوتاه
        /// </summary>
        public String DestinationPhoneNumber
        {
            get { return _DestinationPhoneNumber; }
            set { _DestinationPhoneNumber = value; }
        }
        #endregion

        #region Int32 MessageReference
        /// <summary>
        /// خصوصیت نگدارنده مرجع پیام
        /// </summary>
        public Int32 MessageReference
        {
            get { return _MessageReference; }
            set { _MessageReference = value; }
        }
        #endregion

        #region Boolean IsSent
        /// <summary>
        /// خصوصیت نگهدارنده ارسال شدن یا نشدن پیام
        /// </summary>
        public Boolean IsSent
        {
            get { return _IsSent; }
            set { _IsSent = value; }
        }
        #endregion

        #region DateTime SendDate
        /// <summary>
        /// خصوصیت نگهدارنده زمان ارسال شدن پیام
        /// </summary>
        public DateTime SendDate
        {
            get { return _SendDate; }
            set { _SendDate = value; }
        }
        #endregion

        #endregion

        #region Ctor

        #region SMSSentResultData(IDeliveryReportEventArgs Data)
        /// <summary>
        /// سازنده كلاس برای دریافت اطلاعات لازم
        /// </summary>
        /// <param name="Data">اطلاعات پیام ارسال شده</param>
        public SMSSentResultData(IDeliveryReportEventArgs Data)
        {
            DestinationPhoneNumber = Data.Phone;
            MessageReference = Data.MessageReference;
            IsSent = Data.Status;
            SendDate = DateTime.Now;
        }
        #endregion

        #endregion

    }
}