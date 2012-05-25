#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;
#endregion

namespace Aftab.Forms
{
    public partial class frmServiceSetup : Form
    {
        #region Fields

        #region Byte _Indicator
        /// <summary>
        /// مجزا كننده ای برای تفاوت فراخوانی بك گراند وركر
        /// </summary>
        private Byte _Indicator;
        #endregion

        #endregion

        #region Ctor
        public frmServiceSetup()
        {
            InitializeComponent();
            _Indicator = 0;
            btnInstall.Enabled = !IsServiceInstalled();
            btnUnInstall.Enabled = IsServiceInstalled();
            if (IsServiceInstalled())
            {
                btnStop.Enabled = IsServiceStarted();
                btnStart.Enabled = !btnStop.Enabled;
            }
            ShowDialog();
        }
        #endregion

        #region EventHandlers

        #region btnInstall_Click
        private void btnInstall_Click(object sender, EventArgs e)
        {
            btnUnInstall.Enabled = false;
            btnInstall.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            _Indicator = 1;
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region btnUnInstall_Click
        private void btnUnInstall_Click(object sender, EventArgs e)
        {
            btnUnInstall.Enabled = false;
            btnInstall.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            _Indicator = 2;
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region btnStart_Click
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnUnInstall.Enabled = false;
            btnInstall.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            _Indicator = 3;
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region btnStop_Click
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnUnInstall.Enabled = false;
            btnInstall.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            _Indicator = 4;
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region btnEventLog_Click
        private void btnEventLog_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            #region btnInstall
            if (_Indicator == 1)
            {
                if (e.Cancelled)
                {
                    btnInstall.Enabled = true;
                    return;
                }
                btnUnInstall.Enabled = true;
                btnStart.Enabled = true;
            }
            #endregion

            #region btnUnInstall
            else if (_Indicator == 2)
            {
                if (e.Cancelled)
                {
                    btnUnInstall.Enabled = true;
                    btnStart.Enabled = !IsServiceStarted();
                    btnStop.Enabled = !btnStart.Enabled;
                    return;
                }
                btnInstall.Enabled = true;
            }
            #endregion

            #region btnStart
            else if (_Indicator == 3)
            {
                if (e.Cancelled)
                {
                    btnUnInstall.Enabled = true;
                    btnStart.Enabled = true;
                    return;
                }
                btnUnInstall.Enabled = true;
                btnStop.Enabled = true;
            }
            #endregion

            #region btnStop
            else if (_Indicator == 4)
            {
                if (e.Cancelled)
                {
                    btnUnInstall.Enabled = true;
                    btnStop.Enabled = true;
                    return;
                }
                btnUnInstall.Enabled = true;
                btnStart.Enabled = true;
            }
            #endregion

            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            #region btnInstall
            if (_Indicator == 1)
            {
                if (!File.Exists("AftabBackupService.exe"))
                {
                    PMBox.Show("فایل اجرایی سرویس پشتیبان گیری وجود ندارد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                if (!InstallService()) e.Cancel = true;
            }
            #endregion

            #region btnUnInstall
            else if (_Indicator == 2)
            {
                if (!UnInstallService()) e.Cancel = true;
            }
            #endregion

            #region btnStart
            else if (_Indicator == 3)
            {
                try{ServiceController.Start();}
                #region Catch
                catch (Exception)
                {
                    PMBox.Show("امكان فعال كردن سرویس پشتیبان گیری وجود ندارد!", "خطا!", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                #endregion
            }
            #endregion

            #region btnStop
            else if (_Indicator == 4)
            {
                try{ServiceController.Stop();}
                #region Catch
                catch (Exception)
                {
                    PMBox.Show("امكان غیر فعال كردن سرویس پشتیبان گیری وجود ندارد!", "خطا!", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                #endregion
            }
            #endregion
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean InstallService()
        /// <summary>
        /// تابعی برای اجرای دستور نصب سرویس
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean InstallService()
        {
            try
            {
                ProcessStartInfo ProcessInfo = new ProcessStartInfo("Installutil.exe");
                ProcessInfo.Arguments = "AftabBackupService.exe";
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = false;
                Process MyProcess = Process.Start(ProcessInfo);
                if (MyProcess != null) MyProcess.WaitForExit();
                if (MyProcess != null) MyProcess.Close();
            }
            #region Catch
            catch (Exception)
            {
                PMBox.Show("خطا در نصب سرویس پشتیبان گیری بر روی سیستم!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean UnInstallService()
        /// <summary>
        /// تابعی برای اجرای دستور حذف سرویس 
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean UnInstallService()
        {
            try
            {
                ProcessStartInfo ProcessInfo = new ProcessStartInfo("Installutil.exe");
                ProcessInfo.Arguments = "/u AftabBackupService.exe";
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = false;
                Process MyProcess = Process.Start(ProcessInfo);
                if (MyProcess != null) MyProcess.WaitForExit();
                if (MyProcess != null) MyProcess.Close();
            }
            #region Catch
            catch (Exception)
            {
                PMBox.Show("خطا در حذف سرویس پشتیبان گیری از سیستم!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean IsServiceInstalled()
        /// <summary>
        /// تابعی برای اینكه آیا سرویس نصب است یا خیر
        /// </summary>
        /// <returns>نصب است یا نه</returns>
        private Boolean IsServiceInstalled()
        {
            List<ServiceController> x = ServiceController.GetServices().ToList();
            return x.Any(Data => Data.ServiceName == "AftabBackupService");
        }
        #endregion

        #region Boolean IsServiceStarted()
        /// <summary>
        /// تابعی برای اینكه آیا سرویس فعال است یا خیر
        /// </summary>
        /// <returns>فعال است یا خیر</returns>
        private Boolean IsServiceStarted()
        {
            if (ServiceController.Status == ServiceControllerStatus.Stopped) return false;
            return true;
        }
        #endregion

        #endregion
    }
}
