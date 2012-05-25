#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using mCore;
using Negar.SMSManager;
#endregion using

namespace Negar
{
    /// <summary>
    /// سرویس مدیریت ارسال پیام های كوتاه
    /// </summary>
    public partial class NegarSMSSender : ServiceBase
    {

        #region Delegates & Events
        private delegate void TheMessageSent(SMSSentResultData SMSData);
        private event TheMessageSent SendComplete;
        #endregion

        #region Fields

        #region Boolean _IsDebugMode
        private static Boolean _IsDebugMode;
        #endregion

        #region String _ConnectionString
        private static String _ConnectionString;
        #endregion

        #region String _PortName
        /// <summary>
        /// پورت انتخاب شده برای اتصال به مودم
        /// </summary>
        private String _PortName;
        #endregion

        #region Timer _SendingTimer
        private Timer _SendingTimer;
        #endregion

        #region List<SendQueue> _QueueList
        private List<SendQueue> _QueueList;
        #endregion

        #region Dictionary<Int32, Int64> _DeliveryQueueKeys
        /// <summary>
        /// لیست پیام های ارسال شده ، در انتظار وصول نتیجه
        /// </summary>
        private Dictionary<Int32, Int64> _DeliveryQueueKeys;
        #endregion

        #endregion

        #region Ctor
        public NegarSMSSender()
        {
            InitializeComponent();
        }
        #endregion Ctor

        #region Main Methods

        #region OnStart(String[] args)
        protected override void OnStart(String[] args)
        {
            _IsDebugMode = true;
            // خواندن پورت انتخاب شده برای اتصال به مودم
            // اتصال به مودم
            // خواندن اتصال به سرور ذخیره شده در تنظیمات برای ارسال پیام كوتاه
            if (!SetDBSetting()) { Stop(); return; }
            if (!ReadSelectedComPort()) { Stop(); return; }
            if (!ConnectToGSMModem()) { Stop(); return; }
            InitSendingTimer();
            _SendingTimer.Start();
            _DeliveryQueueKeys = new Dictionary<Int32, Int64>();
        }
        #endregion

        #region void OnStop()
        protected override void OnStop()
        {
            DisposeSendingTimer();
            DisconnectGSMModem();
            LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                "# SMS Sender Service Stoped. #\n" + "OnStop() Has Called.", EventLogEntryType.Warning);
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean SetDBSetting()
        private static Boolean SetDBSetting()
        {
            _ConnectionString = CSManager.GenerateCS("192.168.1.1\\NegarServer01", "PatientsSystem", 0, "sa", "sudnhdvhk");
            //_ConnectionString = CSManager.GenerateCS(".\\NegarServer01", "PatientsSystem", 0, "sa", "sudnhdvhk");
            //_ConnectionString = CSManager.GenerateCS(".\\SQLDeveloper", "PatientsSystem", 0, "sa", "sudnhdvhk");
            if (_IsDebugMode) LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                "# Boolean SetDBSetting() #\n" + "_ConnectionString Initialized.\n" +
            "Connection String: " + _ConnectionString, EventLogEntryType.Information);
            Negar.DBLayerPMS.Manager.ReleaseCachedFiles();
            if (_IsDebugMode) LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                "# Boolean SetDBSetting() #\n" + "Negar.DBLayerPMS.Manager.ReleaseCachedFiles() Has Called.", EventLogEntryType.Information);
            if (CSManager.CheckConnectionIsAlive(_ConnectionString))
            {
                LogManager.SaveLogEntry("Negar", "SMS Sender Service", "# Boolean SetDBSetting() #\n" +
                    "CSManager.CheckConnectionIsAlive(_ConnectionString) \n" +
                    "Has Called & Returned True.", EventLogEntryType.Information);
            }
            else
            {
                LogManager.SaveLogEntry("Negar", "SMS Sender Service", "# Boolean SetDBSetting() #\n" +
                    "CSManager.CheckConnectionIsAlive(_ConnectionString) \n" +
                    "Has Called & Returned False.", EventLogEntryType.Error);
                return false;
            }
            Negar.DBLayerPMS.Manager.DBML = new DbLayer(_ConnectionString);
            Negar.DBLayerPMS.SMS.ConnectionString = _ConnectionString;
            Negar.DBLayerPMS.Manager.DBML.DeferredLoadingEnabled = false;
            Negar.DBLayerPMS.Manager.DBML.CommandTimeout = 0;
            if (_IsDebugMode) LogManager.SaveLogEntry("Negar", "SMS Sender Service", "# Boolean SetDBSetting() #\n" +
                "Method Returned True.", EventLogEntryType.Information); return true;
        }
        #endregion

        #region Boolean ReadSelectedComPort()
        private Boolean ReadSelectedComPort()
        {
            try
            {
                IQueryable<SMSSettings> ResultPort = Negar.DBLayerPMS.Manager.DBML.SMSSettings.
                    Where(Data => Data.ID == 100);
                Negar.DBLayerPMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, ResultPort);
                _PortName = ResultPort.First().Data;
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "SMS Sender Service", Ex.Message + "\n" + Ex.StackTrace +
                    "\nBoolean ReadSelectedComPort()", EventLogEntryType.Error);
            }
            #endregion
            LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                "# Boolean ReadSelectedComPort() #\n" + "Function Returned True.\n" +
            "PortName Is: " + _PortName, EventLogEntryType.Information);
            return true;
        }
        #endregion

        #region Boolean ConnectToGSMModem()
        private Boolean ConnectToGSMModem()
        {
            DisconnectGSMModem();
            try
            {
                GSMModemManager.StaticSMSObject = GSMModemManager.ConnectGSMModem(_PortName,
                    BaudRate.BaudRate_19200, DataBits.Eight, Parity.None, StopBits.One, FlowControl.None, true);
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "SMS Sender Service", Ex.Message + "\n" + Ex.StackTrace +
                    "\nBoolean ConnectToGSMModem()", EventLogEntryType.Error);
                return false;
            }
            #endregion
            GSMModemManager.SMSMessageSent += SMSMessage_Sent;
            SendComplete += Service_SendComplete;
            LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                "# Boolean ConnectToGSMModem() #\n" + "Function Returned True.", EventLogEntryType.Information);
            return true;
        }
        #endregion

        #region void DisconnectGSMModem()
        private static void DisconnectGSMModem()
        {
            //  در صورتی كه قبلاً شیئ ساخته شده باشد و سیستم بخواهد دوباره آن را بازسازی كند از این بخش استفاده می شود
            try { GSMModemManager.StaticSMSObject.Disconnect(); }
            catch { }
            try { GSMModemManager.DisconnectGSMModem(GSMModemManager.StaticSMSObject); }
            catch { }
            try { GSMModemManager.StaticSMSObject.Dispose(); }
            catch { }
            try { GSMModemManager.StaticSMSObject = null; }
            catch { }
        }
        #endregion

        #region void InitSendingTimer()
        private void InitSendingTimer()
        {
            _SendingTimer = new Timer(3000);
            _SendingTimer.Elapsed += SendingTimer_Elapsed;
            LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                "# void InitSendingTimer() #\n" + "Function Called Successfully.", EventLogEntryType.Information);
        }
        #endregion

        #region void DisposeSendingTimer()
        private void DisposeSendingTimer()
        {
            try { _SendingTimer.Dispose(); }
            catch { }
            try { _SendingTimer = null; }
            catch { }
        }
        #endregion

        #region SendingTimer_Elapsed
        void SendingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_IsDebugMode) LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                 "# SendingTimer_Elapsed # - Event Raised", EventLogEntryType.Information);
            // تایمر متوقف می شود تا پیام های جدید بررسی شود
            _SendingTimer.Stop();
            // خواندن 5 پیام جدید ارسال نشده
            _QueueList = Negar.DBLayerPMS.SMS.GetQueueMessages(5);
            // خطا در خواندن لیست پیام های جدید از بانك
            if (_QueueList == null)
            {
                if (_IsDebugMode) LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                    "# SendingTimer_Elapsed #\n" + "_QueueList == null", EventLogEntryType.Error);
                // دوباره تنظیم اتصال به بانك اعمال می شود تا شاید مشكل برطرف شود
                if (SetDBSetting())
                {
                    // تایمر جستجوی پیام های جدید به 10 ثانیه تغییر میكند تا شاید خطای به وقوع پیوسته رفع شود
                    //if (!_IsDebugMode) 
                    _SendingTimer.Interval = 10000;
                    _SendingTimer.Start();
                }
                else Stop(); // اگر تنظیمات اتصال اعمال نشد ، سرویس متوقف می شود
            }
            else // عدم خطا در خواندن لیست پیام های جدید از بانك
            {
                if (_IsDebugMode) LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                    "# SendingTimer_Elapsed #\n" + "_QueueList != null", EventLogEntryType.Information);
                // وقتی روال به این خط برسد ، قطعاً با خطایی مواجه نشده است
                // اگر آیتمی برای ارسال وجود نداشت ، تایمر فعال شده و دوباره وضعیت پیام ها را بررسی می نماید
                if (_QueueList.Count == 0)
                {
                    if (_IsDebugMode) LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                        "# SendingTimer_Elapsed #\n" + "_QueueList.Count == 0", EventLogEntryType.Information);
                    // تایمر جستجوی پیام های جدید به 5 ثانیه تغییر میكند تا دوباره پیام های جدید بررسی شود
                    if (!_IsDebugMode) _SendingTimer.Interval = 5000;
                    _SendingTimer.Start();
                }
                // در اینجا قطعاً مشخص شده كه آیتمی برای خوانده شدن وجود دارد
                else
                {
                    // تایمر جستجوی پیام های جدید به 15 ثانیه تغییر میكند تا زمانی كه پیام های خوانده شده ارسال شود
                    _SendingTimer.Interval = 15000;
                    // سیستم شروع به ارسال پیام ها میكند
                    SendCurrentQueueMessages();
                }
            }
        }
        #endregion

        #region void SendCurrentQueueMessages()
        /// <summary>
        /// تابعی برای ارسال تك به تك پیام های موجود در لیست پیام های در حال انتظار
        /// </summary>
        private void SendCurrentQueueMessages()
        {
            LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                "# void SendCurrentQueueMessages() #\n" +
                "Function Started For Sending " + _QueueList.Count + " Messages.", EventLogEntryType.Information);
            for (Int32 Index = 0; Index < _QueueList.Count; Index++)
            {
                // خواندن اطلاعات اولین پیام از بانك اطلاعات
                SMSMessage MessageData;
                try
                {
                    MessageData = Negar.DBLayerPMS.Manager.DBML.SMSMessages.
                        Where(Data => Data.ID == _QueueList[Index].MessageIX).First();
                    Negar.DBLayerPMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, MessageData);
                    if (_IsDebugMode) LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                        "# void SendCurrentQueueMessages() #\n" + "MessageData Initialized.", EventLogEntryType.Information);
                }
                #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Negar", "SMS Sender Service", "void SendCurrentQueueMessages()\nPart 1.\n" +
                        Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    Negar.DBLayerPMS.Manager.ReleaseCachedFiles();
                    SetDBSetting();
                    continue;
                }
                #endregion
                // ارسال پیام بر اساس متن پیام و شماره گیرنده
                try
                {
                    SMSMessageData SMSData = new SMSMessageData(MessageData.RecieverNumber, MessageData.MessageText);
                    SMSData.IsAlert = false;
                    SMSData.RequestDelivery = true;
                    // ارسال پیام و دریافت كلید برای بررسی دریافت توسط گیرنده
                    String Key = SMSSender.SendSyncSMS(SMSData);
                    if (_IsDebugMode) LogManager.SaveLogEntry("Negar", "SMS Sender Service", "# void SendCurrentQueueMessages() #\n" +
                        "SMSSender.SendSyncSMS(SMSData); Called", EventLogEntryType.Information);
                    // حذف ویرگول اضافه از كلید ارسال شده
                    for (Int32 i = Key.Length - 1; i >= 0; i--) if (Key[i] == ',') { Key = Key.Substring(i + 1, Key.Length - 1 - i); break; }
                    // افزودن به لیست در انتظار دریافت
                    _DeliveryQueueKeys.Add(Convert.ToInt32(Key), _QueueList[Index].ID);
                    if (_IsDebugMode) LogManager.SaveLogEntry("Negar", "SMS Sender Service", "# void SendCurrentQueueMessages() #\n" +
                        "_DeliveryQueueKeys.Add(Convert.ToInt32(Key), _QueueList[Index].ID); Called.\n" +
                        "Last Key: " + Key, EventLogEntryType.Information);
                }
                #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Negar", "SMS Sender Service", "void SendCurrentQueueMessages()\nPart 2.\n" +
                        Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    ConnectToGSMModem();
                    continue;
                }
                #endregion
            }
            _SendingTimer.Start();
        }
        #endregion

        #region void SMSMessage_Sent(SMSSentResultData SMSData)
        /// <summary>
        /// روالی كه بعد از ارسال یا عدم ارسال یك پیام فراخوانی می شود
        /// </summary>
        /// <param name="SMSData">اطلاعات پیام ارسال شده</param>
        void SMSMessage_Sent(SMSSentResultData SMSData)
        {
            if (SendComplete != null) SendComplete(SMSData);
        }
        #endregion

        #region Service_SendComplete
        void Service_SendComplete(SMSSentResultData SMSData)
        {
            if (_IsDebugMode) LogManager.SaveLogEntry("Negar", "SMS Sender Service",
                "# Service_SendComplete #\nMessage Sent. Delivery Recieved.\nSMSData.MessageReference: " +
                SMSData.MessageReference, EventLogEntryType.Information);
            if (SMSData.IsSent) Negar.DBLayerPMS.SMS.AddMessageToSendSucceed(_DeliveryQueueKeys[SMSData.MessageReference]);
            else Negar.DBLayerPMS.SMS.AddMessageToSendFailed(_DeliveryQueueKeys[SMSData.MessageReference]);
        }
        #endregion

        #endregion

    }
}