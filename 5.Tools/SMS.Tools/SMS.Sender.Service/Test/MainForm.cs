#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar.Controls;
using mCore;
using Negar.SMSManager;
using Parity = mCore.Parity;
using StopBits = mCore.StopBits;
#endregion

namespace Negar.SMSSender
{
    /// <summary>
    /// فرم اصلی مدیریت ارسال پیام به مقاصد
    /// </summary>
    public partial class MainForm : Form
    {

        #region Delegates & Events
        public delegate void TheMessageSent(SMSSentResultData SMSData);
        public event TheMessageSent SendComplete;
        #endregion

        #region Fields

        #region const Int32 _SendLimit = 5
        /// <summary>
        /// تعداد سقف پیام های قابل ارسال در هر بازه زمانی
        /// </summary>
        private const Int32 _SendLimit = 5;
        #endregion

        #region List<SendQueue> _QueueList
        /// <summary>
        /// لیست پیام های در انتظار ارسال
        /// </summary>
        private List<SendQueue> _QueueList;
        #endregion

        #region Dictionary<Int32, Int64> _QueueKeys
        /// <summary>
        /// لیست پیام های ارسال شده ، در انتظار وصول نتیجه
        /// </summary>
        private readonly Dictionary<Int32, Int64> _QueueKeys;
        #endregion

        #endregion

        #region Ctor
        public MainForm()
        {
            InitializeComponent();
            dgvQueue.AutoGenerateColumns = false;
            dgvSents.AutoGenerateColumns = false;
            dgvFaileds.AutoGenerateColumns = false;
            _QueueKeys = new Dictionary<Int32, Int64>();
            String[] PortList = SerialPort.GetPortNames();
            Array.Sort(PortList, 0, PortList.Length);
            cboPortName.DataSource = PortList;
            SendComplete += MainForm_SendComplete;
        }
        #endregion

        #region Event Handlers

        #region MainForm_Shown
        private void MainForm_Shown(object sender, EventArgs e)
        {
            Text += " - نسخه: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        }
        #endregion

        #region btnConnectGSMModem_Click
        private void btnConnectGSMModem_Click(object sender, EventArgs e)
        {
            #region Try Connect To GSM Modem
            btnConnectGSMModem.Enabled = false;
            Cursor = Cursors.WaitCursor;
            cboPortName.Enabled = false;
            try
            {
                GSMModemManager.StaticSMSObject = GSMModemManager.ConnectGSMModem(cboPortName.Text,
                    BaudRate.BaudRate_19200, DataBits.Eight, Parity.None, StopBits.One, FlowControl.None, true);
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "SMS Manager - Connection To GSM Modem", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); GSMModemManager.StaticSMSObject = null;
            }
            #endregion
            Cursor = Cursors.Default;
            cboPortName.Enabled = true;
            #endregion

            #region Connection Failed
            if (GSMModemManager.StaticSMSObject == null)
            {
                PMBox.Show("امكان برقراری اتصال با مودم وجود ندارد. لطفاً موارد زیر را بررسی نمایید:\n" +
                    "1. آیا اتصال مودم با كامپیوتر برقرار است؟\n" +
                    "2. آیا چراغ سیگنال مودم روشن شده است؟\n" +
                    "3. آیا مودم روشن است؟", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TimerDataRefresh.Stop();
                btnConnectGSMModem.Enabled = true;
                dgvQueue.Enabled = false;
                dgvSents.Enabled = false;
                dgvFaileds.Enabled = false;
                btnRetryFaileds.Enabled = false;
                GSMModemManager.SMSMessageSent -= SMSMessage_Sent;
            }
            #endregion

            #region Connection Succeeded
            else
            {
                btnConnectGSMModem.Enabled = false;
                dgvQueue.Enabled = true;
                dgvSents.Enabled = true;
                dgvFaileds.Enabled = true;
                btnRetryFaileds.Enabled = true;
                GSMModemManager.SMSMessageSent += SMSMessage_Sent;
                TimerDataRefresh.Start();
            }
            #endregion
        }
        #endregion

        #region TimerDataRefresh_Tick
        private void TimerDataRefresh_Tick(object sender, EventArgs e)
        {
            TimerDataRefresh.Stop();
            List<SendSucceed> SentItems = Negar.DBLayerPMS.SMS.GetTodaySucceedMessages();
            if (SentItems == null) { Form_Closing(null, null); return; }
            List<SendFailed> Faileds = Negar.DBLayerPMS.SMS.GetTodayFailedMessages();
            if (Faileds == null) { Form_Closing(null, null); return; }
            _QueueList = Negar.DBLayerPMS.SMS.GetQueueMessages(_SendLimit);
            if (_QueueList == null) { Form_Closing(null, null); return; }
            // وقتی روال به این خط برسد ، قطعاً با خطایی مواجه نشده است
            dgvSents.DataSource = SentItems;
            dgvFaileds.DataSource = Faileds;
            dgvQueue.DataSource = _QueueList;
            // اگر آیتمی برای ارسال وجود نداشت ، تایمر فعال شده و بعد از زمان اجرا ، دوباره وضعیت پیام ها را بررسی می نماید
            if (_QueueList.Count == 0) { TimerDataRefresh.Start(); return; }
            // در اینجا قطعاً مشخص شده كه آیتمی برای خوانده شدن وجود دارد بنابر این سیستم شروع به ارسال پیام های میكند
            SendCurrentQueueMessages();
        }
        #endregion

        #region dgvQueue_CellFormatting
        private void dgvQueue_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                Int64 MessageID = 0;
                if (sender.Equals(dgvQueue))
                    MessageID = ((SendQueue)((DataGridViewX)sender).Rows[e.RowIndex].DataBoundItem).MessageIX;
                else if (sender.Equals(dgvSents))
                    MessageID = ((SendSucceed)((DataGridViewX)sender).Rows[e.RowIndex].DataBoundItem).MessageIX;
                else if (sender.Equals(dgvFaileds))
                    MessageID = ((SendFailed)((DataGridViewX)sender).Rows[e.RowIndex].DataBoundItem).MessageIX;

                if (e.ColumnIndex == ColQueueRecieverNum.Index)
                    e.Value = Negar.DBLayerPMS.Manager.DBML.SMSMessages.
                        Where(Data => Data.ID == MessageID).First().RecieverNumber;
                else if (e.ColumnIndex == ColQueueMessage.Index)
                    e.Value = Negar.DBLayerPMS.Manager.DBML.SMSMessages.
                        Where(Data => Data.ID == MessageID).First().MessageText;
                else if (e.ColumnIndex == ColQueueSendDateTime.Index)
                {
                    DateTime? EnDateTime = null;
                    if (sender.Equals(dgvQueue))
                        EnDateTime = ((SendQueue)((DataGridViewX)sender).Rows[e.RowIndex].DataBoundItem).SendDateTime;
                    else if (sender.Equals(dgvSents))
                        EnDateTime = ((SendSucceed)((DataGridViewX)sender).Rows[e.RowIndex].DataBoundItem).SendDateTime;
                    else if (sender.Equals(dgvFaileds))
                        EnDateTime = ((SendFailed)((DataGridViewX)sender).Rows[e.RowIndex].DataBoundItem).SendDateTime;
                    if (EnDateTime == null) return;
                    PersianDate PDate = EnDateTime.Value.ToPersianDate();
                    e.Value = PDate.Year + "/" + PDate.Month + "/" + PDate.Day + "-" +
                        PDate.Hour + ":" + PDate.Minute + ":" + PDate.Second;
                }
            }
            catch { }
        }
        #endregion

        #region SMSMessage_Sent
        /// <summary>
        /// روالی كه بعد از ارسال یا عدم ارسال یك پیام فراخوانی می شود
        /// </summary>
        /// <param name="SMSData">اطلاعات پیام ارسال شده</param>
        void SMSMessage_Sent(SMSSentResultData SMSData)
        {
            if (SendComplete != null) SendComplete(SMSData);
        }
        #endregion

        #region MainForm_SendComplete
        void MainForm_SendComplete(SMSSentResultData SMSData)
        {
            LogManager.SaveLogEntry("Negar", "SMS Sender",
                "SMSData.MessageReference: " + SMSData.MessageReference, EventLogEntryType.Error);
            if (SMSData.IsSent) Negar.DBLayerPMS.SMS.AddMessageToSendSucceed(_QueueKeys[SMSData.MessageReference]);
            else Negar.DBLayerPMS.SMS.AddMessageToSendFailed(_QueueKeys[SMSData.MessageReference]);
        }
        #endregion

        #region btnRetryFaileds_Click
        private void btnRetryFaileds_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFaileds.Rows)
                Negar.DBLayerPMS.SMS.AddMessageToSendQueueFromFailedMessages(((SendFailed)row.DataBoundItem).ID);
            dgvFaileds.DataSource = null;
        }
        #endregion

        #region MainForm_Resize
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            Visible = false;
            FormNotifyIcon.Visible = true;
            FormNotifyIcon.ShowBalloonTip(5000);
        }
        #endregion

        #region FormNotifyIcon_MouseClick
        private void FormNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            FormNotifyIcon.Visible = false;
            Visible = true;
            WindowState = FormWindowState.Normal;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            FormClosing -= Form_Closing;
            if (GSMModemManager.StaticSMSObject != null)
            {
                GSMModemManager.DisconnectGSMModem(GSMModemManager.StaticSMSObject);
                GSMModemManager.StaticSMSObject.Dispose();
                GSMModemManager.StaticSMSObject = null;
            }
            Process.GetCurrentProcess().Kill();
        }
        #endregion

        #endregion

        #region Methods

        #region void SendCurrentQueueMessages()
        /// <summary>
        /// تابعی برای ارسال تك به تك پیام های موجود در لیست پیام های در حال انتظار
        /// </summary>
        private void SendCurrentQueueMessages()
        {
            foreach (DataGridViewRow row in dgvQueue.Rows)
            {
                try
                {
                    Int64 MessageID = ((SendQueue)row.DataBoundItem).MessageIX;
                    SMSMessage MessageData = Negar.DBLayerPMS.Manager.DBML.SMSMessages.
                        Where(Data => Data.ID == MessageID).First();
                    Negar.DBLayerPMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, MessageData);
                    SMSMessageData SMSData = new SMSMessageData(MessageData.RecieverNumber, MessageData.MessageText);
                    SMSData.IsAlert = false;
                    SMSData.RequestDelivery = true;
                    String Key = SMSManager.SMSSender.SendSyncSMS(SMSData);
                    // حذف ویرگول اضافه
                    for (Int32 i = Key.Length - 1; i >= 0; i--) if (Key[i] == ',') { Key = Key.Substring(i + 1, Key.Length - 1 - i); break; }
                    _QueueKeys.Add(Convert.ToInt32(Key), MessageID);
                    LogManager.SaveLogEntry("Negar", "SMS Sender Service", "# void SendCurrentQueueMessages() #\n" +
                        "_QueueKeys.Add(Convert.ToInt32(Key), _QueueList[Index].ID); Called.\n" +
                        "Last Key: " + Key, EventLogEntryType.Information);
                }
                #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Negar", "SMS Sender", Ex.Message + "\n" + Ex.StackTrace +
                        "\nMainForm.cs - void SendCurrentQueueMessages()", EventLogEntryType.Error);
                    Negar.DBLayerPMS.Manager.ReleaseCachedFiles();
                }
                #endregion
            }
            TimerDataRefresh.Start();
        }
        #endregion

        #endregion

    }
}