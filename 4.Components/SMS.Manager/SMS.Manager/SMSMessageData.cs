#region using
using System;
#endregion

namespace Negar.SMSManager
{
    /// <summary>
    /// كلاس نگاهدارنده اشیاء لازم برای ارسال یك پیام
    /// </summary>
    public class SMSMessageData
    {

        #region Fields

        #region String _DestinationPhoneNumber
        /// <summary>
        /// فیلد نگدارنده شماره تلفن همراه جهت ارسال پیام كوتاه
        /// </summary>
        private String _DestinationPhoneNumber;
        #endregion

        #region String _Message
        /// <summary>
        /// فیلد نگدارنده متن پیام كوتاه
        /// </summary>
        private String _Message;
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
            set
            {
                if (value.Length == 10) _DestinationPhoneNumber += "+98" + value;
                else if (value.Length == 11) _DestinationPhoneNumber += "+98" + value.Substring(1, 10);
                else _DestinationPhoneNumber = value;
            }
        }
        #endregion

        #region String MessageReference
        /// <summary>
        /// فیلد نگدارنده متن پیام كوتاه
        /// </summary>
        public String Message
        {
            get { return _Message; }
            set { _Message = value.Trim(); }
        }
        #endregion

        #region Boolean IsAlert
        /// <summary>
        /// آیا پیام یك هشدار است یا پیام عادی
        /// </summary>
        public Boolean IsAlert { get; set; }
        #endregion

        #region Boolean RequestDelivery
        /// <summary>
        /// آیا دریافت توسط دریافت كننده اعلام شود؟
        /// </summary>
        public Boolean RequestDelivery { get; set; }
        #endregion

        #endregion

        #region Ctors

        #region SMSMessageData()
        /// <summary>
        /// سازنده پیش فرض
        /// </summary>
        public SMSMessageData() { }
        #endregion

        #region SMSMessageData(String destinationPhoneNumber, String message)
        /// <summary>
        /// سازنده كلاس برای دریافت اطلاعات لازم
        /// </summary>
        /// <param name="destinationPhoneNumber">تلفن مقصد</param>
        /// <param name="message">پیام</param>
        public SMSMessageData(String destinationPhoneNumber, String message)
        {
            DestinationPhoneNumber = destinationPhoneNumber;
            Message = message;
        }
        #endregion

        #endregion

    }
}