#region using
using System;
using System.Diagnostics;
using Negar;
using mCore;
#endregion

namespace Negar.SMSManager
{
    /// <summary>
    /// كلاسی برای مدیریت اتصال به مودم ارسال پیام
    /// </summary>
    public static class GSMModemManager
    {

        #region Delegates & Events
        public delegate void MessageSent(SMSSentResultData ResultData);
        public static event MessageSent SMSMessageSent;
        #endregion

        #region Fields

        #region SMS _StaticSMSObject
        /// <summary>
        /// شیء ثابت اتصال به SMS
        /// </summary>
        private static SMS _StaticSMSObject;
        #endregion

        #endregion

        #region Properties

        #region SMS StaticSMSObject
        /// <summary>
        /// شیء ثابتی برای اتصال به مودم ارسال پیام كه در صورت عدم مقدار دهی خودكار مقدار دهی می شود
        /// </summary>
        public static SMS StaticSMSObject
        {
            get { return _StaticSMSObject; }
            set { _StaticSMSObject = value; }
        }
        #endregion

        #endregion

        #region Public Methods

        #region SMS ConnectGSMModem(...)
        /// <summary>
        /// تابع اتصال به مودم 
        /// </summary>
        /// <returns>تعیین اتصال موفقیت آمیز یا تهی برای عدم اتصال</returns>
        public static SMS ConnectGSMModem(String port, BaudRate baudRate, DataBits dataBits,
            Parity parity, StopBits stopBits, FlowControl flowControl, Boolean DisableCheckPIN)
        {
            SMS SMSObject = new SMS();
            SMSObject.License().Company = "ZURICH INSURANCE GROUP (HK)";
            SMSObject.License().LicenseType = "PRO-DISTRIBUTION";
            SMSObject.License().Key = "FJ4F-C51W-MCER-BRAW";
            SMSObject.BaudRate = baudRate;
            SMSObject.DataBits = dataBits;
            SMSObject.Parity = parity;
            SMSObject.StopBits = stopBits;
            SMSObject.FlowControl = flowControl;
            SMSObject.DisableCheckPIN = DisableCheckPIN;
            SMSObject.Port = port;
            Boolean IsConnected = SMSObject.Connect();
            if (IsConnected)
            {
                SMSObject.Validity = "24H"; // تنظیم مدت اعتبار پیام
                SMSObject.LongMessage = LongMessage.Concatenate;
                SMSObject.Encoding = Encoding.Unicode_16Bit;
                SMSObject.NewDeliveryReport += SMSObject_QueueSMSSent;
                return SMSObject;
            }
            return null;
        }
        #endregion

        #region void DisconnectGSMModem(SMS SMSObject)
        /// <summary>
        /// تابع اتصال به مودم 
        /// </summary>
        /// <returns>تعیین اتصال موفقیت آمیز یا عدم اتصال</returns>
        public static void DisconnectGSMModem(SMS SMSObject)
        {
            if (SMSObject == null) return;
            if (!SMSObject.IsConnected) return;
            try { SMSObject.Disconnect(); }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "SMS Manager - Connection To GSM Modem", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
        }
        #endregion

        #region void DisposeStaticSMSObject()
        /// <summary>
        /// تابعی برای از بین بردن شیء پیام از حافظه
        /// </summary>
        public static void DisposeStaticSMSObject()
        {
            if (_StaticSMSObject != null) _StaticSMSObject.Dispose();
            _StaticSMSObject = null;
        }
        #endregion

        #endregion

        #region Event Handlers

        #region SMSObject_QueueSMSSent
        /// <summary>
        /// رخداد ارسال شدن یك پیام
        /// </summary>
        private static void SMSObject_QueueSMSSent(object sender, NewDeliveryReportEventArgs e)
        {
            if (SMSMessageSent != null) SMSMessageSent(new SMSSentResultData(e));
        }
        #endregion

        #endregion

    }
}