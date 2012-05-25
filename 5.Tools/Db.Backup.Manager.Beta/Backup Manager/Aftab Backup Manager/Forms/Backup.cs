#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Aftab.DbLayer;
using AftabCalendar.Utilities;
using Chilkat;
using DevComponents.DotNetBar;
using Microsoft.Win32;

#endregion

namespace Aftab
{
    /// <summary>
    /// فرم ایجاد فایل پشتیبان از بانك اطلاعاتی به صورت موردی
    /// </summary>
    public partial class frmBackup : Form
    {

        #region Fields

        #region DbClassPS _DbClassPS
        /// <summary>
        /// نگهدارنده ای برای شی ارتباط با بانك اطلاعاتی
        /// </summary>
        private DbClassPS _DbClassPS;
        #endregion

        #region String _PSBackupCommand
        /// <summary>
        /// نگهدارنده متن پشتیبان گیری از بانك اطلاعاتی بیماران
        /// </summary>
        private String _PSBackupCommand;
        #endregion

        #region String _ISBackupCommand
        /// <summary>
        /// نگهدارنده متن فرمان پشتیبان گیری از بانك اطلاعاتی تصویربرداری
        /// </summary>
        private String _ISBackupCommand;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmBackup()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("En-Us"));
            InitializeComponent();
            cBoxInstanceName.DataSource = LoadSqlInstaceNames().ToList();
            cBoxInstanceName.ValueMember = "Key";
            cBoxInstanceName.DisplayMember = "Value";
            Show();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {

        }
        #endregion

        #region btnSelectPath_Click
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowser.SelectedPath = txtSavePath.Text;
            DialogResult Dr = FolderBrowser.ShowDialog();
            if (Dr == DialogResult.OK) txtSavePath.Text = FolderBrowser.SelectedPath;
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            Enabled = false;
            ProgressBarForm.ProgressType = eProgressItemType.Marquee;
            ProgressBarForm.Text = "در حال ایجاد پشتیبانی";
            _DbClassPS = new DbClassPS(CSManager.GenerateCS(cBoxInstanceName.Text, "Master"));
            GenerateBackupString();
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(_PSBackupCommand)) _DbClassPS.ExecuteCommand(_PSBackupCommand);
                if (!String.IsNullOrEmpty(_ISBackupCommand)) _DbClassPS.ExecuteCommand(_ISBackupCommand);

                #region Zip And Protect Backup Data
                String BackupFilePath = txtSavePath.Text.Trim() + "\\AftabDbBackupFile - " + CounterMaker() + ".AftabBackup";
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                // نام فایلی كه باید برای زیپ تولید شود
                ZipHelper.NewZip(BackupFilePath);
                // فایل هایی كه باید به زیپ اضافه شوند اینجا تخصیص می باید
                if (File.Exists(txtSavePath.Text.Trim() + "\\PatientsSystem.Bak"))
                    ZipHelper.AppendFiles(txtSavePath.Text.Trim() + "\\PatientsSystem.Bak", true);
                if (File.Exists(txtSavePath.Text.Trim() + "\\ImagingSystem.Bak"))
                    ZipHelper.AppendFiles(txtSavePath.Text.Trim() + "\\ImagingSystem.Bak", true);
                ZipHelper.PasswordProtect = true;
                ZipHelper.EncryptKeyLength = 256;
                ZipHelper.EncryptPassword = "sudnhdvhk";
                ZipHelper.SetPassword("sudnhdvhk");
                // نوشتن فایل زیپ
                Boolean IsWritingDoCorrectly = ZipHelper.WriteZipAndClose();
                if (!IsWritingDoCorrectly) throw new Exception(ZipHelper.LastErrorText);
                ZipHelper.Dispose();
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry(Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                e.Cancel = true;
                return;
            }
            #endregion
            #region Finally
            finally
            {
                if (File.Exists(txtSavePath.Text.Trim() + "\\PatientsSystem.Bak"))
                    File.Delete(txtSavePath.Text.Trim() + "\\PatientsSystem.Bak");
                if (File.Exists(txtSavePath.Text.Trim() + "\\ImagingSystem.Bak"))
                    File.Delete(txtSavePath.Text.Trim() + "\\ImagingSystem.Bak");
            }
            #endregion
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Enabled = true;
            if (e.Cancelled)
            {
                const String ErrorMessage =
                    "امكان پشتیبانی گرفتن از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PMBox.Show("پشتیبانی از بانك با موفقیت انجام شد.", "ایجاد پشتیبانی موفقیت آمیز",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ProgressBarForm.ProgressType = eProgressItemType.Standard;
            ProgressBarForm.Text = "در انتظار ایجاد پشتیبانی";
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #endregion

        #region Methods

        #region void GenerateBackupString()
        /// <summary>
        /// تابع تولید فایل پشتیبانی
        /// </summary>
        private void GenerateBackupString()
        {
            String Path = txtSavePath.Text.Trim();
            if (!Directory.Exists(Path))
            {
                DialogResult Result = PMBox.Show("پوشه انتخاب شده وجود ندارد! آیا مایلید پوشه مورد نظر ساخته شود؟", "پرسش؟",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Result == DialogResult.Yes) Directory.CreateDirectory(Path);
                else return;
            }
            _PSBackupCommand = "BACKUP DATABASE [PatientsSystem] " +
                "TO  DISK = N'" + Path + @"\PatientsSystem.Bak' " +
                "WITH NOFORMAT, INIT,  " +
                "NAME = N'PatientsSystem-Full Database GenerateBackupString', " +
                "SKIP, NOREWIND, NOUNLOAD,  STATS = 50";
            _ISBackupCommand = String.Empty;
            if (cBoxOption2.Checked)
            {
                _ISBackupCommand = "BACKUP DATABASE [ImagingSystem] " +
                    "TO DISK = N'" + Path + @"\ImagingSystem.Bak' " +
                    "WITH NOFORMAT, INIT,  " +
                    "NAME = N'ImagingSystem-Full Database GenerateBackupString', " +
                    "SKIP, NOREWIND, NOUNLOAD,  STATS = 50";
            }
        }
        #endregion

        #region Dictionary<Int16, String> LoadSqlInstaceNames()
        /// <summary>
        /// تابعی برای یافتن نمونه های بانك اطلاعاتی نصب شده بر روی سیستم
        /// </summary>
        public Dictionary<Int16, String> LoadSqlInstaceNames()
        {
            String ComputerName = SystemInformation.ComputerName;
            const String _SubKey1 = "SOFTWARE\\Microsoft\\Microsoft SQL Server\\Instance Names\\SQL";
            Dictionary<Int16, String> InstanceDic = new Dictionary<Int16, String>();
            try
            {
                RegistryKey MyKey = Registry.LocalMachine.OpenSubKey(_SubKey1, true);
                if (MyKey == null) { return InstanceDic; }
                // ReSharper disable PossibleNullReferenceException
                String[] InstanceNames = Registry.LocalMachine.OpenSubKey(_SubKey1, true).GetValueNames();
                // ReSharper restore PossibleNullReferenceException
                for (Int16 i = 0; i < InstanceNames.Count(); i++)
                { InstanceDic.Add(i, ComputerName + "\\" + InstanceNames[i]); }
            }
            #region Catch
            catch (Exception)
            {
                PMBox.Show("امكان دسترسی به كلید رجیستری نمونه های نصب شده وجود ندارد!", "پرسش؟",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return InstanceDic;
            }
            #endregion
            return InstanceDic;
        }
        #endregion

        #region String CounterMaker()
        /// <summary>
        /// تابعی برای ساختن نمایشگر تاریخ و ساعت با فرمت ساده در نام فایل های پشتیبان
        /// </summary>
        private static String CounterMaker()
        {
            String Counter = "";
            PersianDate Temp = PersianDateConverter.ToPersianDate(DateTime.Now);
            Counter += Temp.Year.ToString();
            Int32 TempNumber = Temp.Month;
            if (TempNumber < 10) { Counter += "0"; }
            Counter += TempNumber;
            TempNumber = Temp.Day;
            if (TempNumber < 10) { Counter += "0"; }
            Counter += TempNumber;
            TempNumber = Temp.Hour;
            if (TempNumber < 10) { Counter += "0"; }
            Counter += TempNumber;
            TempNumber = Temp.Minute;
            if (TempNumber < 10) { Counter += "0"; }
            Counter += TempNumber;
            TempNumber = Temp.Second;
            if (TempNumber < 10) { Counter += "0"; }
            Counter += TempNumber;
            return Counter;
        }
        #endregion

        #endregion
    }
}