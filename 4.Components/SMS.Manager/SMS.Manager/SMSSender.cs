#region using
using System;
#endregion

namespace Negar.SMSManager
{
    /// <summary>
    /// كلاسی برای مدیریت ارسال پیام از طریق مودم پیام كوتاه
    /// </summary>
    public static class SMSSender
    {

        #region Public Methods

        #region String SendSyncSMS(SMSMessageData SentSMS)
        /// <summary>
        /// تابعی برای ارسال پیام كوتاه
        /// </summary>
        public static String SendSyncSMS(SMSMessageData SentSMS)
        {
            if (SentSMS == null || GSMModemManager.StaticSMSObject == null) return null;
            GSMModemManager.StaticSMSObject.DeliveryReport = SentSMS.RequestDelivery;
            return GSMModemManager.StaticSMSObject.
                SendSMS(SentSMS.DestinationPhoneNumber, SentSMS.Message, SentSMS.IsAlert);
        }
        #endregion

        #endregion

    }
}