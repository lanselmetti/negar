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
    /// كلاس مدیریت اطلاعات پیام كوتاه
    /// </summary>
    public static class SMS
    {

        #region Properties

        #region String ConnectionString
        public static String ConnectionString { get; set; }
        #endregion

        #endregion

        #region Int64? InsertNewSMS(...)
        /// <summary>
        /// تابعی برای ثبت یك پیام جدید و قراردادن آن در لیست ارسال ها
        /// </summary>
        /// <param name="SenderNum">تلفن فرستنده</param>
        /// <param name="RecieverNum">تلفن گیرنده</param>
        /// <param name="Message">متن پیام</param>
        /// <param name="SendDateTime">زمان ارسال</param>
        /// <param name="RefID">كلید مراجعه بیمار</param>
        /// <remarks>این تابع ابتدا ردیف جدیدی برای ارسال پیام ایجاد كرده
        /// و سپس تابع ثبت پیام در لیست انتظار ارسال را فراخوانی می كند</remarks>
        /// <returns>كلید پیام ثبت شده یا تهی برای وقوع خطا</returns>
        public static Int64? InsertNewSMS(String SenderNum, String RecieverNum, String Message, DateTime? SendDateTime, Int32? RefID)
        {
            SMSMessage NewRow = new SMSMessage();
            if (!String.IsNullOrEmpty(SenderNum)) NewRow.SenderNumber = SenderNum;
            NewRow.RecieverNumber = RecieverNum;
            NewRow.MessageText = Message;
            NewRow.RefIX = RefID;
            DbLayer DBML;
            if (String.IsNullOrEmpty(ConnectionString))
                DBML = new DbLayer(CSManager.GetConnectionString("PatientsSystem"));
            else DBML = new DbLayer(ConnectionString);
            DBML.DeferredLoadingEnabled = false;
            DBML.CommandTimeout = 0;
            DBML.SMSMessages.InsertOnSubmit(NewRow);
            try { DBML.SubmitChanges(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ثبت پیام جدید در لیست پیام ها وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer Manager - SMS", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            if (AddMessageToSendQueue(NewRow.ID, SendDateTime) == null) return null;
            return NewRow.ID;
        }
        #endregion

        #region Int64? AddMessageToSendQueue(Int64 MessageID, DateTime? SendDateTime)
        /// <summary>
        /// تابعی برای ثبت یك پیام در لیست انتظار ارسال ها
        /// </summary>
        /// <param name="MessageID">كلید پیام</param>
        /// <param name="SendDateTime">تاریخی كه باید پیام ارسال شود</param>
        /// <remarks>این تابع ابتدا ردیف جدیدی برای ارسال پیام ایجاد كرده
        /// و سپس تابع ثبت پیام در لیست انتظار ارسال را فراخوانی می كند</remarks>
        /// <returns>كلید پیام ثبت شده یا تهی برای وقوع خطا</returns>
        public static Int64? AddMessageToSendQueue(Int64 MessageID, DateTime? SendDateTime)
        {
            SendQueue NewRow = new SendQueue();
            NewRow.MessageIX = MessageID;
            NewRow.SaveDateTime = DateTime.Now;
            NewRow.MessageIX = MessageID;
            NewRow.SendDateTime = SendDateTime;
            DbLayer DBML;
            if (String.IsNullOrEmpty(ConnectionString))
                DBML = new DbLayer(CSManager.GetConnectionString("PatientsSystem"));
            else DBML = new DbLayer(ConnectionString);
            DBML.DeferredLoadingEnabled = false;
            DBML.CommandTimeout = 0;
            DBML.SendQueues.InsertOnSubmit(NewRow);
            try { DBML.SubmitChanges(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ثبت پیام در لیست انتظار پیام ها وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer Manager - SMS", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            return NewRow.ID;
        }
        #endregion

        #region Int64? AddMessageToSendFailed(Int64 SendQueueID)
        /// <summary>
        /// تابعی برای ثبت یك پیام در لیست پیام های ارسال نشده
        /// </summary>
        /// <param name="SendQueueID">كلید پیام در لیست انتظار</param>
        /// <returns>كلید پیام ثبت شده در لیست خطاها یا تهی برای وقوع خطا</returns>
        public static Int64? AddMessageToSendFailed(Int64 SendQueueID)
        {
            try
            {
                DbLayer DBML;
                if (String.IsNullOrEmpty(ConnectionString))
                    DBML = new DbLayer(CSManager.GetConnectionString("PatientsSystem"));
                else DBML = new DbLayer(ConnectionString);
                DBML.DeferredLoadingEnabled = false;
                DBML.CommandTimeout = 0;
                IQueryable<SendQueue> TempData = DBML.SendQueues.Where(Data => Data.ID == SendQueueID);
                if (TempData.Count() == 0) return null;
                SendQueue NewSendQueue = TempData.First();
                SendFailed FailRow = new SendFailed();
                FailRow.MessageIX = NewSendQueue.MessageIX;
                FailRow.SendDateTime = NewSendQueue.QueueDateTime.Value;
                FailRow.SavedDateTime = DateTime.Now;
                DBML.SendFaileds.InsertOnSubmit(FailRow);
                DBML.SendQueues.DeleteOnSubmit(NewSendQueue);
                DBML.SubmitChanges();
                return FailRow.ID;
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "DB Layer - SMS", Ex.Message + "\n" + Ex.StackTrace +
                    "\nSMS.cs - Int64? AddMessageToSendFailed(Int64 SendQueueID)", EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region Int64? AddMessageToSendSucceed(Int64 SendQueueID)
        /// <summary>
        /// تابعی برای ثبت یك پیام در لیست پیام های ارسال شده
        /// </summary>
        /// <param name="SendQueueID">كلید پیام در لیست انتظار</param>
        /// <returns>كلید پیام ثبت شده در لیست ارسال شده ها یا تهی برای وقوع خطا</returns>
        public static Int64? AddMessageToSendSucceed(Int64 SendQueueID)
        {
            try
            {
                DbLayer DBML;
                if (String.IsNullOrEmpty(ConnectionString))
                    DBML = new DbLayer(CSManager.GetConnectionString("PatientsSystem"));
                else DBML = new DbLayer(ConnectionString);
                DBML.DeferredLoadingEnabled = false;
                DBML.CommandTimeout = 0;
                IQueryable<SendQueue> TempData = DBML.SendQueues.Where(Data => Data.ID == SendQueueID);
                if (TempData.Count() == 0) return null;
                SendQueue NewSendQueue = TempData.First();
                SendSucceed SucceedRow = new SendSucceed();
                SucceedRow.MessageIX = NewSendQueue.MessageIX;
                SucceedRow.SendDateTime = NewSendQueue.QueueDateTime.Value;
                SucceedRow.SavedDateTime = DateTime.Now;
                DBML.SendSucceeds.InsertOnSubmit(SucceedRow);
                DBML.SendQueues.DeleteOnSubmit(NewSendQueue);
                DBML.SubmitChanges();
                return SucceedRow.ID;
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "DB Layer - SMS", Ex.Message + "\n" + Ex.StackTrace +
                    "\nSMS.cs - Int64? AddMessageToSendSucceed(Int64 SendQueueID)", EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region Int64? AddMessageToSendQueueFromFailedMessages(Int64 FailedID)
        /// <summary>
        /// تابعی برای ثبت یك پیام در لیست پیام های در انتظار ارسال از لیست پیام های ارسال نشده
        /// </summary>
        /// <param name="FailedID">كلید پیام در لیست ارسال نشده ها</param>
        /// <returns>كلید پیام ثبت شده در لیست در انتظار ارسال یا تهی برای وقوع خطا</returns>
        public static Int64? AddMessageToSendQueueFromFailedMessages(Int64 FailedID)
        {
            try
            {
                DbLayer DBML;
                if (String.IsNullOrEmpty(ConnectionString))
                    DBML = new DbLayer(CSManager.GetConnectionString("PatientsSystem"));
                else DBML = new DbLayer(ConnectionString);
                DBML.DeferredLoadingEnabled = false;
                DBML.CommandTimeout = 0;
                IQueryable<SendFailed> TempData = DBML.SendFaileds.Where(Data => Data.ID == FailedID);
                if (TempData.Count() == 0) return null;
                SendFailed SendFailedRow = TempData.First();
                SendQueue QueueRow = new SendQueue();
                QueueRow.MessageIX = SendFailedRow.MessageIX;
                QueueRow.SaveDateTime = DateTime.Now;
                DBML.SendQueues.InsertOnSubmit(QueueRow);
                DBML.SendFaileds.DeleteOnSubmit(SendFailedRow);
                DBML.SubmitChanges();
                return QueueRow.ID;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ثبت پیام انتخاب شده در لیست پیام های در انتظار ارسال وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - SMS", Ex.Message + "\n" + Ex.StackTrace +
                    "\nSMS.cs - Int64? AddMessageToSendQueueFromFailedMessages(Int64 FailedID)",
                    EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region List<SendQueue> GetQueueMessages(Int32 PeekCount)
        /// <summary>
        /// تابعی برای خواندن لیستی از پیام های در حال انتظار برای ارسال پیام
        /// </summary>
        /// <param name="PeekCount">تعداد پیام هایی كه خوانده می شود</param>
        /// <remarks>این تابع لیستی از پیام ها را بر اساس محدودیت تعیین شده و همچنین پیام هایی كه محدودیت 
        /// زمانی برای ارسال ندارند یا در بازه محدودیت نیستند را می خواند و سپس زمان انتظار آنها را به زمان حال تغییر می دهد</remarks>
        /// <returns>شیء لیست پیام ها</returns>
        public static List<SendQueue> GetQueueMessages(Int32 PeekCount)
        {
            try
            {
                DbLayer DBML;
                if (String.IsNullOrEmpty(ConnectionString))
                    DBML = new DbLayer(CSManager.GetConnectionString("PatientsSystem"));
                else DBML = new DbLayer(ConnectionString);
                DBML.DeferredLoadingEnabled = false;
                DBML.CommandTimeout = 0;
                // ابتدا پیامهای قدیمی به لیست ارسال نشده ها منتقل می شوند
                IQueryable<Int64> OldMessages = DBML.SendQueues.
                    Where(Data => Data.QueueDateTime.Value < DateTime.Now.AddHours(-2))
                    .Select(Data => Data.ID);
                foreach (Int64 QueueID in OldMessages) AddMessageToSendFailed(QueueID);
                IQueryable<SendQueue> TempData = DBML.SendQueues.
                    Where(Data => (Data.SendDateTime == null || // پیام هایی كه زمان ارسال آنها تهی است كه یعنی هر زمانی
                        // یا آنهایی كه زمان ارسال آنها قبل از زمان حال می باشد
                        Data.SendDateTime <= DateTime.Now) &&
                        // آنهایی كه تا كنون ارسال نشده اند
                        (Data.QueueDateTime == null)).Take(PeekCount);
                DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                List<SendQueue> ReturnValue = TempData.ToList();
                foreach (SendQueue queue in TempData) queue.QueueDateTime = DateTime.Now;
                DBML.SubmitChanges();
                return ReturnValue;
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "DB Layer - SMS",
                    "SMS.cs - List<SendQueue> GetQueueMessages(Int32 PeekCount)\n" +
                Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region List<SendQueue> GetQueueList()
        /// <summary>
        /// تابعی برای خواندن لیستی كاملی از پیام های در حال انتظار برای ارسال پیام
        /// </summary>
        /// <returns>شیء لیست پیام ها</returns>
        public static List<SendQueue> GetQueueList()
        {
            try
            {
                DbLayer DBML;
                if (String.IsNullOrEmpty(ConnectionString))
                    DBML = new DbLayer(CSManager.GetConnectionString("PatientsSystem"));
                else DBML = new DbLayer(ConnectionString);
                DBML.DeferredLoadingEnabled = false;
                DBML.CommandTimeout = 0;
                IQueryable<SendQueue> TempData = DBML.SendQueues;
                List<SendQueue> ReturnValue = TempData.ToList();
                return ReturnValue;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات پیام های در لیست انتظار وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - SMS", Ex.Message + "\n" + Ex.StackTrace +
                    "\nSMS.cs - List<SendQueue> GetQueueList()", EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region Int32? GetQueueListCount(Int32 PeekCount)
        /// <summary>
        /// تابعی برای خواندن تعداد پیام های در حال انتظار برای ارسال پیام
        /// </summary>
        public static Int32? GetQueueListCount(Int32 PeekCount)
        {
            try
            {
                DbLayer DBML;
                if (String.IsNullOrEmpty(ConnectionString))
                    DBML = new DbLayer(CSManager.GetConnectionString("PatientsSystem"));
                else DBML = new DbLayer(ConnectionString);
                DBML.DeferredLoadingEnabled = false;
                DBML.CommandTimeout = 0;
                return DBML.SendQueues.
                  Where(Data => (Data.SendDateTime == null || // پیام هایی كه زمان ارسال آنها تهی است كه یعنی هر زمانی
                      // یا آنهایی كه زمان ارسال آنها قبل از زمان حال می باشد
                      Data.SendDateTime <= DateTime.Now) &&
                      (Data.QueueDateTime == null || // آنهایی كه تا كنون ارسال نشده اند
                      // یا آنهایی كه بیش از یك ساعت از ارسال آنها گذشته است
                      Data.QueueDateTime.Value < DateTime.Now.AddHours(-1))).Take(PeekCount).Count();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن تعداد پیام های در لیست انتظار وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - SMS", Ex.Message + "\n" + Ex.StackTrace +
                    "\nSMS.cs - Int32? GetQueueListCount(Int32 PeekCount)", EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region List<SendSucceed> GetTodaySucceedMessages()
        /// <summary>
        /// تابعی برای خواندن لیستی از پیام های ارسال شده امروز
        /// </summary>
        /// <returns>شیء لیست پیام ها</returns>
        public static List<SendSucceed> GetTodaySucceedMessages()
        {
            try
            {
                DbLayer DBML;
                if (String.IsNullOrEmpty(ConnectionString))
                    DBML = new DbLayer(CSManager.GetConnectionString("PatientsSystem"));
                else DBML = new DbLayer(ConnectionString);
                DBML.DeferredLoadingEnabled = false;
                DBML.CommandTimeout = 0;
                IQueryable<SendSucceed> TempData = DBML.SendSucceeds.
                    Where(Data => Data.SendDateTime.Date == DateTime.Now.Date);
                return TempData.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات پیام های ارسال شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - SMS", Ex.Message + "\n" + Ex.StackTrace +
                    "\nSMS.cs - List<SendSucceed> GetTodaySucceedMessages()", EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region List<SendFailed> GetTodayFailedMessages()
        /// <summary>
        /// تابعی برای خواندن لیستی از پیام های ارسال نشده امروز
        /// </summary>
        /// <returns>شیء لیست پیام ها</returns>
        public static List<SendFailed> GetTodayFailedMessages()
        {
            try
            {
                DbLayer DBML;
                if (String.IsNullOrEmpty(ConnectionString))
                    DBML = new DbLayer(CSManager.GetConnectionString("PatientsSystem"));
                else DBML = new DbLayer(ConnectionString);
                DBML.DeferredLoadingEnabled = false;
                DBML.CommandTimeout = 0;
                IQueryable<SendFailed> TempData = DBML.SendFaileds.
                    Where(Data => Data.SendDateTime.Date == DateTime.Now.Date);
                return TempData.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات پیام های ارسال نشده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - SMS", Ex.Message + "\n" + Ex.StackTrace +
                    "\nSMS.cs - List<SendFailed> GetTodayFailedMessages()", EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

    }
}