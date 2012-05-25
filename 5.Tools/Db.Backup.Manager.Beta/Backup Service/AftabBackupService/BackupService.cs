#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using Aftab;
using AftabAftabBackupService.DbLayer;
using AftabCalendar.Utilities;
using Chilkat;
#endregion

namespace AftabBackupService
{

    public partial class AftabBackupService : ServiceBase
    {
        #region Fields

        #region String _SettingFilePath
        /// <summary>
        /// 
        /// </summary>
        private String _SettingFilePath;
        #endregion

        #region DbClassPS _DbClassPS
        /// <summary>
        /// شی ارتباط با بانك ارتباطی
        /// </summary>
        private DbClassPS _DbClassPS;
        #endregion

        #region DataTable _BackupPlansDataTable
        /// <summary>
        /// نگهدارنده اطلاعات برای هم ذخیره كردن و هم خواندن
        /// </summary>
        private DataTable _BackupPlansDataTable;
        #endregion

        #region String _PSBackupCommand
        /// <summary>
        /// نگهدارنده متن پشتیبان گیری از بانك بیماران
        /// </summary>
        private String _PSBackupCommand;
        #endregion

        #region String _ISBackupCommand
        /// <summary>
        /// نگهدارنده متن پشتیبان گیری از بانك تصویر برداری
        /// </summary>
        private String _ISBackupCommand;
        #endregion

        #region Queue<DataRow> _ActiveJobs
        /// <summary>
        /// صف پشتیبان های در حال انتظار
        /// </summary>
        private readonly Queue<DataRow> _ActiveJobs;
        #endregion

        #region Timer _timer
        /// <summary>
        /// تایمر اجرای دستورات چك كردن برنامه نوبت دهی
        /// </summary>
        readonly Timer _timer;
        #endregion

        #region BackgroundWorker _BGWorker
        /// <summary>
        /// بك گراند وركر جهت اجرای پشتیبان گیری ها و چك كردن برنامه به صورت هم زمان
        /// </summary>
        private readonly BackgroundWorker _BGWorker;
        #endregion
        
        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض سرویس
        /// </summary>
        public AftabBackupService()
        {
            _BGWorker = new BackgroundWorker();
            _BGWorker.DoWork += BGWorker_DoWork;
            _BGWorker.RunWorkerCompleted += BGWorker_RunWorkerCompleted;
            _SettingFilePath = Environment.SystemDirectory + "\\BackupPlans.DAT";
            _timer = new Timer((Timer_Tick), null, Timeout.Infinite, Timeout.Infinite);
            InitializeComponent();
            _ActiveJobs = new Queue<DataRow>();
        }
        #endregion

        #region EventHandlers

        #region void OnStart(string[] args)
        protected override void OnStart(string[] args)
        {
            const String LogMessage = "سروس پشتیبان گیری از بانك های اطلاعاتی فعال شد.";
            LogManager.SaveLogEntry(LogMessage, EventLogEntryType.Information);
            _timer.Change(0, 300000);
        }
        #endregion

        #region void Timer_Tick(object state)
        public void Timer_Tick(object state)
        {
            const String LogMessage = "سرویس پشتیبان گیری از بانك های اطلاعاتی در حالت فعال می باشد.";
            LogManager.SaveLogEntry(LogMessage, EventLogEntryType.Information);
            ReadPlansDataFromFile();
            FindCurrentTimePeriodJobs();
            if (!_BGWorker.IsBusy) _BGWorker.RunWorkerAsync();
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // اگر جاب فعالی برای پشتیبانی وجود نداشته باشد از روال خارج می شود
            if (_ActiveJobs.Count == 0) { e.Cancel = true;}
            if (!e.Cancel)
            {
                const String LogMessage = "شروع پشتیبان گیری از بانك های اطلاعاتی.";
                LogManager.SaveLogEntry(LogMessage, EventLogEntryType.Information);

                #region Read Job Data
                String BackupDestinationPath = _ActiveJobs.Peek()["FirstPath"].ToString();
                String SecondPath = _ActiveJobs.Peek()["SecondPath"].ToString();
                String ThirdPath = _ActiveJobs.Peek()["ThirdPath"].ToString();
                Boolean ShouldBackupIMS = Convert.ToBoolean(_ActiveJobs.Peek()["ImagingBank"]);
                #endregion

                GenerateBackupString(BackupDestinationPath, ShouldBackupIMS);

                #region Execute Backup Command
                try
                {
                    String CS = CSManager.GenerateCS(_ActiveJobs.Peek()["InstanceName"].ToString(), "Master").Replace("0","4");
                    _DbClassPS = new DbClassPS(CS);
                    if (File.Exists(BackupDestinationPath.Trim() + "\\PatientsSystem.Bak"))
                        File.Delete(BackupDestinationPath.Trim() + "\\PatientsSystem.Bak");
                    if (File.Exists(BackupDestinationPath.Trim() + "\\ImagingSystem.Bak"))
                        File.Delete(BackupDestinationPath.Trim() + "\\ImagingSystem.Bak");
                    if (!String.IsNullOrEmpty(_PSBackupCommand)) _DbClassPS.ExecuteCommand(_PSBackupCommand);
                    if (!String.IsNullOrEmpty(_ISBackupCommand)) _DbClassPS.ExecuteCommand(_ISBackupCommand);
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان پشتیبانی گیری از بانك های اطلاعاتی وجود ندارد.";
                    LogManager.SaveLogEntry(
                        ErrorMessage + "\n" + Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    e.Cancel = true;
                    return;
                }
                #endregion
                finally { _DbClassPS.Dispose(); }
                #endregion

                #region Zip And Protect Backup Data
                try
                {
                    String BackupFilePath = BackupDestinationPath.Trim() +
                        "\\AftabDbBackupFile - " + GetCurrentDate() + ".AftabBackup";
                    #region Zip Files
                    Zip ZipHelper = new Zip();
                    ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                    // نام فایلی كه باید برای زیپ تولید شود
                    ZipHelper.NewZip(BackupFilePath);
                    // فایل هایی كه باید به زیپ اضافه شوند اینجا تخصیص می باید
                    if (File.Exists(BackupDestinationPath.Trim() + "\\PatientsSystem.Bak"))
                    {
                        File.SetAttributes(BackupDestinationPath.Trim() + "\\PatientsSystem.Bak", FileAttributes.Normal);
                        ZipHelper.AppendFiles(BackupDestinationPath.Trim() + "\\PatientsSystem.Bak", true);
                    }
                    if (File.Exists(BackupDestinationPath.Trim() + "\\ImagingSystem.Bak"))
                    {
                        File.SetAttributes(BackupDestinationPath.Trim() + "\\ImagingSystem.Bak", FileAttributes.Normal);
                        ZipHelper.AppendFiles(BackupDestinationPath.Trim() + "\\ImagingSystem.Bak", true);
                    }
                    ZipHelper.PasswordProtect = true;
                    ZipHelper.EncryptKeyLength = 256;
                    ZipHelper.EncryptPassword = "sudnhdvhk";
                    ZipHelper.SetPassword("sudnhdvhk");
                    // نوشتن فایل زیپ
                    Boolean IsWritingDoCorrectly = ZipHelper.WriteZipAndClose();
                    if (!IsWritingDoCorrectly) throw new Exception(ZipHelper.LastErrorText);
                    #endregion
                    // كپی برداری از فایل در محل دوم
                    if (!String.IsNullOrEmpty(SecondPath))
                    {
                        if (!Directory.Exists(SecondPath)) { Directory.CreateDirectory(SecondPath); }
                        File.Copy(BackupFilePath, SecondPath + BackupFilePath);
                    }
                    // كپی برداری از فایل در محل سوم
                    if (!String.IsNullOrEmpty(ThirdPath))
                    {
                        if (!Directory.Exists(ThirdPath)) { Directory.CreateDirectory(ThirdPath); }
                        File.Copy(BackupFilePath, ThirdPath + BackupFilePath);
                    }
                    ZipHelper.Dispose();
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان زیپ كردن فایل های پشتیبان وجود ندارد.";
                    LogManager.SaveLogEntry(
                        ErrorMessage + "\n" + Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    e.Cancel = true;
                    return;
                }
                #endregion
                #region Finally
                finally
                {
                    if (File.Exists(BackupDestinationPath.Trim() + "\\PatientsSystem.Bak"))
                        File.Delete(BackupDestinationPath.Trim() + "\\PatientsSystem.Bak");
                    if (File.Exists(BackupDestinationPath.Trim() + "\\ImagingSystem.Bak"))
                        File.Delete(BackupDestinationPath.Trim() + "\\ImagingSystem.Bak");
                }
                #endregion
                #endregion
            }
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) return;
            const String LogMessage = "پشتیبان گیری از بانك های اطلاعاتی با موفقیت انجام شد. ";
            LogManager.SaveLogEntry(LogMessage, EventLogEntryType.Information);
            _ActiveJobs.Dequeue();
            if (_ActiveJobs.Count != 0) _BGWorker.RunWorkerAsync();
        }
        #endregion

        #region void OnStop()
        protected override void OnStop()
        {
            const String LogMessage = "سروس پشتیبان گیری از بانك های اطلاعاتی غیر فعال شد.";
            LogManager.SaveLogEntry(LogMessage, EventLogEntryType.Information);
        }
        #endregion

        #endregion

        #region Methods

        #region void ReadPlansDataFromFile()
        /// <summary>
        /// تابع خواندن اطلاعات تنظیمات از فایل
        /// </summary>
        private void ReadPlansDataFromFile()
        {
            #region Initialize DataSet
            _BackupPlansDataTable = new DataTable("BackupPlans");
            _BackupPlansDataTable.Columns.Add("ID", typeof(Int32));
            _BackupPlansDataTable.Columns["ID"].AutoIncrement = true;
            _BackupPlansDataTable.Columns.Add("IsActive", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("AppName", typeof(String));
            _BackupPlansDataTable.Columns.Add("DateAppStart", typeof(DateTime));
            _BackupPlansDataTable.Columns.Add("DateAppEnd", typeof(DateTime));
            _BackupPlansDataTable.Columns.Add("TimeStart", typeof(DateTime));
            _BackupPlansDataTable.Columns.Add("InstanceName", typeof(String));
            _BackupPlansDataTable.Columns.Add("ImagingBank", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("FirstPath", typeof(String));
            _BackupPlansDataTable.Columns.Add("SecondPath", typeof(String));
            _BackupPlansDataTable.Columns.Add("ThirdPath", typeof(String));
            #region Day Of Week Columns
            _BackupPlansDataTable.Columns.Add("FirstDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("SecondDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("ThirdDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("FourthDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("FifthDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("SixthDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("SeventhDay", typeof(Boolean));
            #endregion
            #endregion
            // اگر فایل تنظیماتی وجود نداشته باشد ، یك منبع داده خالی تولید می شود
            if (File.Exists(_SettingFilePath))
            {
                try { _BackupPlansDataTable.ReadXml(_SettingFilePath); }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان خواندن اطلاعات از فایل تنظیمات برنامه های پشتیبان گیری وجود ندارد.";
                    LogManager.SaveLogEntry(ErrorMessage + "\n" + Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                }
                #endregion
            }
            else
            {
                const String ErrorMessage = "فایل تنظیمات برنامه های پشتیبان گیری یافت نشد.";
                LogManager.SaveLogEntry(ErrorMessage, EventLogEntryType.Error);
            }
        }
        #endregion

        #region private void FindCurrentTimePeriodJobs()
        /// <summary>
        /// تابعی برای فیلتر وظایفت خوانده شده بر اساس تیك جاری
        /// </summary>
        /// <remarks>تیك جاری به معنی زمان حال است</remarks>
        private void FindCurrentTimePeriodJobs()
        {
            foreach (DataRow Job in _BackupPlansDataTable.Rows)
            {
                // برای وظایف غیرفعال
                if (!Convert.ToBoolean(Job["IsActive"])) continue;
                // بدست آوردن اختلاف زمانی وظیفه با زمان حال
                Int32 Time = Convert.ToDateTime(Job["TimeStart"]).Minute - DateTime.Now.Minute;
                if ((Time <= 5 && Time > 0) || (Time > -60 && Time <= -55))
                {
                    #region Check Week Days
                    switch (Convert.ToInt16(DateTime.Now.DayOfWeek))
                    {
                        case 1: if (!Convert.ToBoolean(Job["SecondDay"])) continue; break;
                        case 2: if (!Convert.ToBoolean(Job["ThirdDay"])) continue; break;
                        case 3: if (!Convert.ToBoolean(Job["FourthDay"])) continue; break;
                        case 4: if (!Convert.ToBoolean(Job["FifthDay"])) continue; break;
                        case 5: if (!Convert.ToBoolean(Job["SixthDay"])) continue; break;
                        case 6: if (!Convert.ToBoolean(Job["SeventhDay"])) continue; break;
                        case 7: if (!Convert.ToBoolean(Job["FirstDay"])) continue; break;
                    }
                    #endregion
                    if (DateTime.Now < Convert.ToDateTime(Job["DateAppStart"]) ||
                        DateTime.Now > Convert.ToDateTime(Job["DateAppEnd"])) continue;
                    // افزودن وظیفه پیدا شده به وظیفه های فعال
                    _ActiveJobs.Enqueue(Job);
                }
            }
        }
        #endregion

        #region void GenerateBackupString(String FilePath, Boolean ShouldBackupIMS)
        /// <summary>
        /// تابع تولید رشته فرمان پشتیبانی بانك ها
        /// </summary>
        private void GenerateBackupString(String FilePath, Boolean ShouldBackupIMS)
        {
            if (!Directory.Exists(FilePath)) { Directory.CreateDirectory(FilePath); }
            _PSBackupCommand = "BACKUP DATABASE [PatientsSystem] " +
                "TO  DISK = N'" + FilePath + @"\PatientsSystem.Bak' " +
                "WITH NOFORMAT, INIT,  " +
                "NAME = N'PatientsSystem-Full Database GenerateBackupString', " +
                "SKIP, NOREWIND, NOUNLOAD,  STATS = 50";
            _ISBackupCommand = String.Empty;
            if (ShouldBackupIMS)
            {
                _ISBackupCommand = "BACKUP DATABASE [ImagingSystem] " +
                    "TO DISK = N'" + FilePath + @"\ImagingSystem.Bak' " +
                    "WITH NOFORMAT, INIT,  " +
                    "NAME = N'ImagingSystem-Full Database GenerateBackupString', " +
                    "SKIP, NOREWIND, NOUNLOAD,  STATS = 50";
            }
        }
        #endregion

        #region String GetCurrentDate()
        /// <summary>
        /// تابعی برای تولید رشته تاریخ شمسی همراه با صفر برای تاریخ های تك رقمی
        /// </summary>
        private static String GetCurrentDate()
        {
            String Counter = String.Empty;
            PersianDate CurrentPersianDate = DateTime.Now;
            Counter += CurrentPersianDate.Year.ToString();
            Int32 TempNumber = CurrentPersianDate.Month;
            if (TempNumber < 10) { Counter += "0"; }
            Counter += TempNumber;
            TempNumber = CurrentPersianDate.Day;
            if (TempNumber < 10) { Counter += "0"; }
            Counter += TempNumber;
            TempNumber = CurrentPersianDate.Hour;
            if (TempNumber < 10) { Counter += "0"; }
            Counter += TempNumber;
            TempNumber = CurrentPersianDate.Minute;
            if (TempNumber < 10) { Counter += "0"; }
            Counter += TempNumber;
            TempNumber = CurrentPersianDate.Second;
            if (TempNumber < 10) { Counter += "0"; }
            Counter += TempNumber;
            return Counter;
        }
        #endregion

        #endregion

    }
}
