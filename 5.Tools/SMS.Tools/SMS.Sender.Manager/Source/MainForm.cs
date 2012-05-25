#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Negar.DBLayerPMS;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
#endregion

namespace Negar
{
    /// <summary>
    /// فرم اصلی مدیریت ارسال پیام به مقاصد
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        #region String _ServiceName
        private const String _ServiceName = "Negar.SMS.Service.exe";
        #endregion

        #endregion

        #region Ctor
        public MainForm()
        {
            InitializeComponent();
            dgvQueue.AutoGenerateColumns = false;
            dgvSents.AutoGenerateColumns = false;
            dgvFaileds.AutoGenerateColumns = false;
            String[] PortList = SerialPort.GetPortNames();
            Array.Sort(PortList, 0, PortList.Length);
            cboPortName.DataSource = PortList;
        }
        #endregion

        #region Event Handlers

        #region MainForm_Shown
        private void MainForm_Shown(object sender, EventArgs e)
        {
            Text += " - نسخه: " + Assembly.GetExecutingAssembly().GetName().Version;
            btnRefresh_Click(null, null);
        }
        #endregion

        #region btnRefresh_Click
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshServiceStatus();
            List<SendQueue> QueueList = SMS.GetQueueList();
            if (QueueList == null) return;
            lblCount1.Text = "تعداد: " + QueueList.Count;
            List<SendSucceed> SentItems = SMS.GetTodaySucceedMessages();
            if (SentItems == null) return;
            lblCount2.Text = "تعداد: " + SentItems.Count;
            List<SendFailed> Faileds = SMS.GetTodayFailedMessages();
            if (Faileds == null) return;
            lblCount3.Text = "تعداد: " + Faileds.Count;
            // وقتی روال به این خط برسد ، قطعاً با خطایی مواجه نشده است
            dgvSents.DataSource = SentItems;
            dgvFaileds.DataSource = Faileds;
            dgvQueue.DataSource = QueueList;
        }
        #endregion

        #region btnSaveSettings_Click
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (cboPortName.Items.Count == 0)
            {
                PMBox.Show("هیچ پورتی برای سیستم جاری تعریف نشده!", "خطا!");
                return;
            }
            String PortName = cboPortName.SelectedValue.ToString();
            String CurrentConnection = CSManager.CurrentSetting;
            try
            {
                IQueryable<SMSSettings> ResultPort = Manager.DBML.SMSSettings.
                    Where(Data => Data.ID == 100);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, ResultPort);
                if (ResultPort.Count() == 0)
                {
                    var NewItem = new SMSSettings();
                    NewItem.ID = 100;
                    NewItem.Data = PortName;
                    Manager.DBML.SMSSettings.InsertOnSubmit(NewItem);
                    Manager.DBML.SubmitChanges();
                }
                else
                {
                    ResultPort.First().ID = 100;
                    ResultPort.First().Data = PortName;
                    Manager.DBML.SubmitChanges();
                }
                IQueryable<SMSSettings> ResultCS = Manager.DBML.SMSSettings.
                    Where(Data => Data.ID == 200);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, ResultCS);
                if (ResultCS.Count() == 0)
                {
                    var NewItem = new SMSSettings();
                    NewItem.ID = 200;
                    NewItem.Data = CurrentConnection;
                    Manager.DBML.SMSSettings.InsertOnSubmit(NewItem);
                    Manager.DBML.SubmitChanges();
                }
                else
                {
                    ResultCS.First().ID = 200;
                    ResultCS.First().Data = CurrentConnection;
                    Manager.DBML.SubmitChanges();
                }
            }
                #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "SMS Sender Service", Ex.Message + "\n" + Ex.StackTrace +
                                                                       "\nvoid SendCurrentQueueMessages()",
                                        EventLogEntryType.Error);
                PMBox.Show("خطا در ثبت تنظیمات!", "خطا!");
                return;
            }
            #endregion

            PMBox.Show("تنظیمات با موفقیت ثبت گردید.\n" +
                       "برای اعمال تغییرات یكبار سرویس را خاموش و سپس روشن كنید.", "اتمام ذخیره سازی");
        }
        #endregion

        #region dgvQueue_CellFormatting
        private void dgvQueue_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                Int64 MessageID = 0;
                if (sender.Equals(dgvQueue))
                    MessageID = ((SendQueue) ((DataGridViewX) sender).Rows[e.RowIndex].DataBoundItem).MessageIX;
                else if (sender.Equals(dgvSents))
                    MessageID = ((SendSucceed) ((DataGridViewX) sender).Rows[e.RowIndex].DataBoundItem).MessageIX;
                else if (sender.Equals(dgvFaileds))
                    MessageID = ((SendFailed) ((DataGridViewX) sender).Rows[e.RowIndex].DataBoundItem).MessageIX;

                if (e.ColumnIndex == ColQueueRecieverNum.Index)
                    e.Value = Manager.DBML.SMSMessages.
                        Where(Data => Data.ID == MessageID).First().RecieverNumber;
                else if (e.ColumnIndex == ColQueueMessage.Index)
                    e.Value = Manager.DBML.SMSMessages.
                        Where(Data => Data.ID == MessageID).First().MessageText;
                else if (e.ColumnIndex == ColQueueSendDateTime.Index)
                {
                    DateTime? EnDateTime = null;
                    if (sender.Equals(dgvQueue))
                        EnDateTime = ((SendQueue) ((DataGridViewX) sender).Rows[e.RowIndex].DataBoundItem).SendDateTime;
                    else if (sender.Equals(dgvSents))
                        EnDateTime =
                            ((SendSucceed) ((DataGridViewX) sender).Rows[e.RowIndex].DataBoundItem).SendDateTime;
                    else if (sender.Equals(dgvFaileds))
                        EnDateTime = ((SendFailed) ((DataGridViewX) sender).Rows[e.RowIndex].DataBoundItem).SendDateTime;
                    if (EnDateTime == null) return;
                    PersianDate PDate = EnDateTime.Value.ToPersianDate();
                    e.Value = PDate.Year + "/" + PDate.Month + "/" + PDate.Day + "-" +
                              PDate.Hour + ":" + PDate.Minute + ":" + PDate.Second;
                }
            }
            catch
            {
            }
        }
        #endregion

        #region btnRetryFaileds_Click
        private void btnRetryFaileds_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFaileds.Rows)
                SMS.AddMessageToSendQueueFromFailedMessages(
                    ((SendFailed) row.DataBoundItem).ID);
            btnRefresh_Click(null, null);
        }
        #endregion

        #region btnRefreshServiceStatus_Click
        private void btnRefreshServiceStatus_Click(object sender, EventArgs e)
        {
            RefreshServiceStatus();
        }
        #endregion

        #region btnInstallService_Click
        private void btnInstallService_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\" + _ServiceName) &&
                File.Exists(Application.StartupPath + "\\InstallUtil.exe"))
            {
                try
                {
                    var MyProcess = new Process();
                    MyProcess.StartInfo.FileName = Application.StartupPath + "\\InstallUtil.exe";
                    MyProcess.StartInfo.Arguments = _ServiceName;
                    MyProcess.StartInfo.WorkingDirectory = Application.StartupPath;
                    MyProcess.StartInfo.CreateNoWindow = false;
                    MyProcess.StartInfo.ErrorDialog = false;
                    MyProcess.Start();
                }
                    #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Negar", "SMS Sender Service", Ex.Message + "\n" + Ex.StackTrace +
                                                                           "\nbtnInstallService_Click()",
                                            EventLogEntryType.Error);
                    PMBox.Show("خطا در نصب سرویس!", "خطا!");
                    return;
                }
                #endregion
            }
            else PMBox.Show("ابزارهای لازم برای نصب سرویس موجود نیست.", "خطا!");
            RefreshServiceStatus();
        }
        #endregion

        #region btnUninstallService_Click
        private void btnUninstallService_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\" + _ServiceName) &&
                File.Exists(Application.StartupPath + "\\InstallUtil.exe"))
            {
                try
                {
                    var MyProcess = new Process();
                    MyProcess.StartInfo.FileName = Application.StartupPath + "\\InstallUtil.exe";
                    MyProcess.StartInfo.Arguments = _ServiceName + " /u";
                    MyProcess.StartInfo.WorkingDirectory = Application.StartupPath;
                    MyProcess.StartInfo.CreateNoWindow = true;
                    MyProcess.StartInfo.ErrorDialog = false;
                    MyProcess.Start();
                }
                    #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Negar", "SMS Sender Service", Ex.Message + "\n" + Ex.StackTrace +
                                                                           "\btnUninstallService_Click()",
                                            EventLogEntryType.Error);
                    PMBox.Show("خطا در حذف سرویس!", "خطا!");
                    return;
                }
                #endregion
            }
            else PMBox.Show("ابزارهای لازم برای حذف سرویس موجود نیست.", "خطا!");
            RefreshServiceStatus();
        }
        #endregion

        #region btnStartService_Click
        private void btnStartService_Click(object sender, EventArgs e)
        {
            try
            {
                var MyService = new ServiceController("Negar SMS Sender");
                if (MyService.Status != ServiceControllerStatus.Stopped)
                    MyService.Stop();
                MyService.Start();
            }
            catch
            {
            }
            RefreshServiceStatus();
        }
        #endregion

        #region btnStopService_Click
        private void btnStopService_Click(object sender, EventArgs e)
        {
            try
            {
                var MyService = new ServiceController("Negar SMS Sender");
                MyService.Stop();
            }
            catch
            {
            }
            RefreshServiceStatus();
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
        }
        #endregion

        #endregion

        #region Methods

        #region void RefreshServiceStatus()
        private void RefreshServiceStatus()
        {
            try
            {
                var MyService = new ServiceController("Negar SMS Sender");
                if (MyService.Status == ServiceControllerStatus.Stopped)
                    txtServiceStatus.Text = "متوقف شده.";
                else if (MyService.Status == ServiceControllerStatus.Running)
                    txtServiceStatus.Text = "فعال.";
                else if (MyService.Status == ServiceControllerStatus.StartPending)
                    txtServiceStatus.Text = "در حال فعال شدن.";
                else if (MyService.Status == ServiceControllerStatus.StopPending)
                    txtServiceStatus.Text = "در حال متوقف شدن.";
            }
            catch
            {
                txtServiceStatus.Text = "نصب نشده.";
            }
        }
        #endregion

        #endregion
    }
}