#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using Negar.Classes;
using Negar.DBLayerPMS.DataLayer;
using Chilkat;
using DevComponents.DotNetBar;
#endregion

namespace Negar.Forms
{
    /// <summary>
    /// فرم نصب سیستم مدیریت سپهر
    /// </summary>
    public partial class frmMain : Office2007Form
    {

        #region Fields

        #region readonly DbLayer _DbClassPS
        /// <summary>
        /// لایه داده
        /// </summary>
        private readonly DbLayer _DbClassPS;
        #endregion

        #region DataContext _DataClass
        private DataContext _DataClass;
        #endregion

        #region String _InstanceName
        private String _InstanceName;
        #endregion

        #region String _ConnectionString
        /// <summary>
        /// رشته اتصال به سرور
        /// </summary>
        private String _ConnectionString;
        #endregion

        #region String _SqlCommandText
        private String _SqlCommandText;
        #endregion

        #region String _NegarInstallPath
        /// <summary>
        /// آدرس فیزیكی نصب نگار
        /// </summary>
        private String _NegarInstallPath;
        #endregion

        #region Boolean _InstallHardwareLock
        /// <summary>
        /// نصب كامپوننت قفل سخت افزاری
        /// </summary>
        private Boolean _InstallHardwareLock;
        #endregion

        #region Boolean _InstallPersianPackages
        private Boolean _InstallPersianPackages;
        #endregion

        #region Boolean _InstallPersianKeyboard
        private Boolean _InstallPersianKeyboard;
        #endregion

        #region Boolean _InstallPersianFonts
        private Boolean _InstallPersianFonts;
        #endregion

        #region Boolean _InstallCrystallReport
        private Boolean _InstallCrystallReport;
        #endregion

        #region readonly String _PMSConnectionString
        private readonly String _PMSConnectionString;
        #endregion

        #region readonly String _IMSConnectionString
        private readonly String _IMSConnectionString;
        #endregion

        #region List<HISApplication> _CurrentApplications
        /// <summary>
        /// لیست زیر سیستم های ثبت شده در سرور انتخاب شده
        /// </summary>
        private List<HISApplication> _CurrentApplications;
        #endregion

        #region List<DbUpgradData> _PMSVersions
        /// <summary>
        /// نگهدارنده لیست ورژن های بانك اطلاعاتی بیماران
        /// </summary>
        private List<DbUpgradData> _PMSVersions;
        #endregion

        #region List<DbUpgradData> _IMSVersions
        /// <summary>
        ///  نگهدارنده لیست ورژن های بانك اطلاعاتی تصویربرداری
        /// </summary>
        private List<DbUpgradData> _IMSVersions;
        #endregion

        #region Queue<String> _PMSDestinationVersions
        /// <summary>
        /// لیست نسخه هایی كه باید بانك بیماران جاری تا رسیدن به آخرین نسخه طی كند
        /// </summary>
        private Queue<String> _PMSDestinationVersions;
        #endregion

        #region Queue<String> _IMSDestinationVersions
        /// <summary>
        /// لیست نسخه هایی كه باید بانك تصویربرداری جاری تا رسیدن به آخرین نسخه طی كند
        /// </summary>
        private Queue<String> _IMSDestinationVersions;
        #endregion

        #region Boolean _IsUpdatingPMS
        /// <summary>
        /// مجزا كننده ای برای مشخص كردن اینكه بكگراند وركر توسط چه بانكی صدا زده شده است
        /// </summary>
        private Boolean _IsUpdatingPMS;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            foreach (CheckBoxItem item in lstInstallServer.Items) item.CheckedChanging += cBoxes_CheckedChanging;
            foreach (CheckBoxItem item in lstInstallClient.Items) item.CheckedChanging += cBoxes_CheckedChanging;
            _PMSConnectionString = "Data Source = =InstanceName=; Initial Catalog = PatientsSystem; " +
                "Persist Security Info=False; User ID=sa; Password= sudnhdvhk;Connection Timeout = 0;";
            _DbClassPS = new DbLayer(_PMSConnectionString);
            _IMSConnectionString = "Data Source = =InstanceName=; Initial Catalog = ImagingSystem; " +
                "Persist Security Info=False; User ID=sa; Password= sudnhdvhk;Connection Timeout = 0;";
        }
        #endregion

        #region Event Handlers

        #region From_Shown
        private void From_Shown(object sender, EventArgs e)
        {
            Text += " - نسخه: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Opacity = 1;
        }
        #endregion

        #region btnDbUpgrade_LinkClicked
        private void btnDbUpgrade_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WizardControl.SelectedPage = WPDbUpgrade;
        }
        #endregion

        #region btnLicenseAgreement_LinkClicked
        private void btnLicenseAgreement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmLicenseAgreement().ShowDialog();
        }
        #endregion

        #region WPageStart_NextButtonClick
        private void WPageStart_NextButtonClick(object sender, CancelEventArgs e)
        {
            DialogResult Result = PMBox.Show("با وارد شدن به قسمت بعد ، شما تایید می نمایید كه متن موافقتنامه استفاده " +
                "از این نرم افزار را مطالعه نموده و پذیرفته اید.\n" +
                "در صورتی كه نیاز به مطالعه موافقتنامه دارید بر روی لینك آبی رنگ مطالعه موافقتنامه در این صفحه كلیك نمایید.\n" +
                "آیا موافقتنامه را می پذیرید؟", "دریافت تایید پذیرش موافقتنامه از سمت خریدار؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (Result != DialogResult.Yes) { e.Cancel = true; return; }
            if (cBoxInstallClient.Checked) { e.Cancel = true; WizardControl.SelectedPage = WPClient01; }
        }
        #endregion

        // ++++++++++++++++++ Server Install +++++++++++++++++++

        #region btnPreInstall_Click
        /// <summary>
        /// روالی برای فراخوانی نصب پیش نیاز ها
        /// </summary>
        private void btnPreInstall_Click(object sender, EventArgs e)
        {
            #region Install SQL Server 2005 Express
            // نصب اس كیو ال 2005 اكسپرس
            if (((ButtonItem)sender).Name == btnPreInstall1.Name)
            {
                try
                {
                    ProcessStartInfo ProcessInfo = new ProcessStartInfo(Application.StartupPath +
                        "\\Data - Server\\Microsoft SQL 2005 Express.Exe");
                    ProcessInfo.Arguments = "/qb INSTANCENAME=NegarServer01 SECURITYMODE=SQL SAPWD=\"sudnhdvhk\" " +
                        "ADDLOCAL=SQL_Engine, SQL_Data_Files, SQL_Replication, " +
                        "SQL_FullText , Client_Components , Connectivity , " +
                        "SQLACCOUNT=\"NT AUTHORITY\\LOCAL SERVICE\" ";
                    ProcessInfo.CreateNoWindow = false;
                    Process MyProcess = Process.Start(ProcessInfo);
                    if (MyProcess != null) MyProcess.WaitForExit();
                    if (MyProcess != null) MyProcess.Close();
                }
                #region Catch
                catch (Exception)
                {
                    PMBox.Show("خطا در نصب اس كیو ال!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormClosing -= Form_Closing;
                    Application.Exit();
                }
                #endregion
            }
            #endregion
        }
        #endregion

        #region WPServer01_NextButtonClick
        /// <summary>
        /// صفحه تنظیمات سرور
        /// </summary>
        private void WPServer01_NextButtonClick(object sender, CancelEventArgs e)
        {
            #region Step 1: Check Is Server Folder Exists
            // 1. بررسی وجود پوشه ی فایل بانك اطلاعاتی
            if (!Directory.Exists(txtBankInstallFolder.Text.Trim()))
            {
                DialogResult Result =
                    PMBox.Show("پوشه ای با آدرس ذكر شده برای نصب بانك اطلاعاتی وجود ندارد.\nآیا مایلید این پوشه ساخته شود؟",
                    "خطا! پرسش؟", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (Result == DialogResult.No) { e.Cancel = true; txtServerInstanceName.Focus(); return; }
                Directory.CreateDirectory(txtBankInstallFolder.Text.Trim());
            }
            #endregion

            #region Step 2: Check Sql Instance Is Ready And Make _ConnectionString
            // 2. بررسی وجود نمونه ی بانك اطلاعاتی وارد شده
            _InstanceName = txtServerInstanceName.Text.Trim();
            _ConnectionString = "Data Source = " + _InstanceName +
                "; Initial Catalog = Master; UID = 'Sa'; PWD = 'sudnhdvhk'; Connection Timeout = 4;";
            if (!IsCorrectConnection(_ConnectionString))
            {
                _ConnectionString = "Data Source = " + _InstanceName +
                "; Initial Catalog = Master; Integrated Security = True; Connection Timeout = 4;";
                if (!IsCorrectConnection(_ConnectionString))
                {
                    const string Message =
                        "امكان برقراری ارتباط با سرور یا نمونه بانك اطلاعاتی وارد شده ممكن نشد." +
                        "\nموارد زیر را برای رفع اشكال بررسی كنید:\n" +
                        "1. آیا نام سرور وارد شده یا آدرس آن را صحیح وارد نموده اید؟\n" +
                        "2. آیا نام نمونه ی بانك اطلاعاتی را صحیح وارد نموده اید؟\n" +
                        "3. آیا نام نمونه ای كه وارد كرده اید غیر فعال نیست؟\n" +
                        "4. آیا اتصال سیستم جاری با شبكه برقراری است؟";
                    PMBox.Show(Message, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true; return;
                }
            }
            _ConnectionString = "Data Source = " + _InstanceName +
                "; Initial Catalog = Master; UID = 'Sa'; PWD = 'sudnhdvhk'; Connection Timeout = 0;";
            #endregion

            #region Step 3: Drop Databases If Exists
            if (!CheckExistDataBase()) { e.Cancel = true; return; }
            #endregion

            MakeRestoreBankCommandString();
        }
        #endregion

        #region WPServer02_AfterPageDisplayed
        /// <summary>
        /// صفحه نصب نسخه سرور
        /// </summary>
        private void WPServer02_AfterPageDisplayed(object sender, WizardPageChangeEventArgs e)
        {
            BGWorkerServer.RunWorkerAsync();
        }
        #endregion

        #region WPServer02_NextButtonClick
        private void WPServer02_NextButtonClick(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            WizardControl.SelectedPage = WPageFinish;
        }
        #endregion

        // ++++++++++++++++++ Client Install +++++++++++++++++++

        #region WPClient01_BackButtonClick
        private void WPClient01_BackButtonClick(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            WizardControl.SelectedPageIndex = 0;
        }
        #endregion

        #region WPClient01_NextButtonClick
        /// <summary>
        /// صفحه تنظیمات كلاینت
        /// </summary>
        private void WPClient01_NextButtonClick(object sender, CancelEventArgs e)
        {
            #region Step 1: Check Is Installation Folder Exists
            // 1. بررسی وجود پوشه های انتخاب شده
            if (!Directory.Exists(txtNegarFolder.Text.Trim()))
            {
                DialogResult Result = PMBox.Show("پوشه ای با آدرس ذكر شده برای نصب سیستم های پزشكی وجود ندارد!\n" +
                    "آیا مایلید این پوشه ساخته شود؟", "پرسش؟", MessageBoxButtons.YesNo, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                if (Result == DialogResult.No) { e.Cancel = true; txtNegarFolder.Focus(); return; }
            }
            else
            {
                try { Directory.Delete(txtNegarFolder.Text.Trim(), true); }
                catch
                {
                    e.Cancel = true;
                    PMBox.Show("امكان ثبت اطلاعات در پوشه مورد نظر وجود ندارد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
            }
            Directory.CreateDirectory(txtNegarFolder.Text.Trim());
            Directory.CreateDirectory(txtNegarFolder.Text.Trim() + "\\Negar SSM");
            Directory.CreateDirectory(txtNegarFolder.Text.Trim() + "\\Sepehr IMS");
            _NegarInstallPath = txtNegarFolder.Text.Trim();
            #endregion

            if (cBoxPreInstall_FaPackage.Checked) cBoxC1.Visible = true;
            else cBoxC1.Visible = false;
            _InstallPersianPackages = cBoxPreInstall_FaPackage.Checked;
            if (cBoxPreInstall_FaKeyboard.Checked) cBoxC2.Visible = true;
            else cBoxC2.Visible = false;
            if (cBoxPreInstall_Fonts.Checked) cBoxC3.Visible = true;
            else cBoxC3.Visible = false;
            _InstallHardwareLock = cBoxPreInstall_HLock.Checked;
            _InstallPersianKeyboard = cBoxPreInstall_FaKeyboard.Checked;
            _InstallPersianFonts = cBoxPreInstall_Fonts.Checked;
            _InstallCrystallReport = cBoxPreInstall_CrystalReport.Checked;
        }
        #endregion

        #region WPClient02_AfterPageDisplayed
        /// <summary>
        /// صفحه نصب كلاینت
        /// </summary>
        private void WPClient02_AfterPageDisplayed(object sender, WizardPageChangeEventArgs e)
        {
            BGWorkerClient.RunWorkerAsync();
        }
        #endregion

        // ++++++++++++++++++ Update Databases +++++++++++++++++++

        #region WPDbUpgrade_BackButtonClick
        private void WPDbUpgrade_BackButtonClick(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            WizardControl.SelectedPageIndex = 0;
        }
        #endregion

        #region btnCheckCurrentDb_Click
        /// <summary>
        /// دكمه ای برای بررسی وضعیت نسخه های بانك های اطلاعاتی نصب شده در نمونه ی وارد شده توسط كاربر
        /// </summary>
        private void btnCheckCurrentDb_Click(object sender, EventArgs e)
        {
            if (!FillDatabasesVersionsArray() || !ReadCurrentInstanceApps()) return;

            #region Check PMS
            // مقایسه نسخه جاری با آخرین نسخه
            if (_CurrentApplications.Where(Data => Data.ID == 1).First().DbVersion != _PMSVersions.Last().DBVersion)
            {
                lblUpgradeStatus.Text = "بانك اطلاعاتی بیماران باید از نسخه " +
                    _CurrentApplications.Where(Data => Data.ID == 1).First().DbVersion +
                    " به نسخه " + _PMSVersions.Last().DBVersion + " ارتقاء یابد.\n";
                btnPMSUpdate.Text = "ارتقاء بانك بیماران به نسخه\n" + _PMSVersions.Last().DBVersion;
                btnPMSUpdate.Enabled = true;
            }
            else
            {
                lblUpgradeStatus.Text = "بانك اطلاعاتی بیماران نیازی به ارتقاء ندارد!\n";
                btnPMSUpdate.Enabled = false;
            }
            #endregion

            #region Check IMS
            if (_CurrentApplications.Where(Data => Data.ID == 500).First().DbVersion != _IMSVersions.Last().DBVersion)
            {
                lblUpgradeStatus.Text += "بانك اطلاعاتی تصویربرداری باید از نسخه " +
                    _CurrentApplications.Where(Data => Data.ID == 500).First().DbVersion +
                    " به نسخه " + _IMSVersions.Last().DBVersion + " ارتقاء یابد.";
                btnIMSUpdate.Text = "ارتقاء بانك تصویربرداری به نسخه\n" + _IMSVersions.Last().DBVersion;
                btnIMSUpdate.Enabled = true;
            }
            else
            {
                lblUpgradeStatus.Text += "بانك اطلاعاتی تصویربرداری نیازی به ارتقاء ندارد!";
                btnIMSUpdate.Enabled = false;
            }
            #endregion

            if (btnPMSUpdate.Enabled || btnIMSUpdate.Enabled) PanelUpgrade.Show();
            else
            {
                PanelUpgrade.Hide();
                PMBox.Show("بانك های نصب شده كاملاً به روز می باشند و نیازی به ارتقاء ندارند.", "هشدار!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region btnPMSUpdate_Click
        private void btnPMSUpdate_Click(object sender, EventArgs e)
        {
            if (!ReadCurrentInstanceApps()) return;
            _PMSDestinationVersions = new Queue<String>();
            String CurrentVersion = _CurrentApplications.Where(Data => Data.ID == 1).First().DbVersion;
            for (Int32 i = 0; i < _PMSVersions.Count; i++)
            {
                if (_PMSVersions[i].DBVersion != CurrentVersion) continue;
                for (Int32 j = i + 1; j < _PMSVersions.Count; j++)
                    _PMSDestinationVersions.Enqueue(_PMSVersions[j].DBVersion);
                break;
            }
            _IsUpdatingPMS = true;
            UpdateProgressBar.Visible = true;
            btnPMSUpdate.Enabled = false;
            btnIMSUpdate.Enabled = false;
            BGWorkerUpdate.RunWorkerAsync();
        }
        #endregion

        #region btnIMSUpdate_Click
        private void btnIMSUpdate_Click(object sender, EventArgs e)
        {
            if (!ReadCurrentInstanceApps()) return;
            _IMSDestinationVersions = new Queue<String>();
            String CurrentVersion = _CurrentApplications.Where(Data => Data.ID == 500).First().DbVersion;
            for (Int32 i = 0; i < _IMSVersions.Count; i++)
            {
                if (_IMSVersions[i].DBVersion != CurrentVersion) continue;
                for (Int32 j = i + 1; j < _IMSVersions.Count; j++)
                    _IMSDestinationVersions.Enqueue(_IMSVersions[j].DBVersion);
                break;
            }
            _IsUpdatingPMS = false;
            UpdateProgressBar.Visible = true;
            btnPMSUpdate.Enabled = false;
            btnIMSUpdate.Enabled = false;
            BGWorkerUpdate.RunWorkerAsync();
        }
        #endregion

        #region BGWorkerUpdate_DoWork
        private void BGWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            #region Update PMS
            if (_IsUpdatingPMS)
            {
                if (_PMSDestinationVersions.Count == 0)
                {
                    PMBox.Show("ارتقاء بانك اطلاعاتی بیماران با موفقیت پایان یافت!", "اتمام ارتقاء!");
                    e.Cancel = true;
                    return;
                }
                String NewCS = _PMSConnectionString.Replace("=InstanceName=", txtUpdateInstance.Text.Trim());
                String UpdateCommand = _PMSVersions.Where(Data => Data.DBVersion ==
                    _PMSDestinationVersions.Peek()).First().Command;
                DataContext Comm = new DataContext(NewCS);
                Comm.CommandTimeout = 0;
                try { Comm.ExecuteCommand(UpdateCommand); }
                #region Catch
                catch (Exception)
                {
                    PMBox.Show("امكان ارتقاء بانك بیماران وجود ندارد! \n" + "موارد زیر را بررسی نمایید: \n" +
                        "1. آیا ارتباط شما با بانك اطلاعاتی برقرار است؟ ", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
                #endregion
            }
            #endregion

            #region Update IMS
            else
            {
                if (_IMSDestinationVersions.Count == 0)
                { PMBox.Show("ارتقاء بانك اطلاعاتی تصویربرداری با موفقیت پایان یافت!", "اتمام ارتقاء!"); e.Cancel = true; }
                if (!e.Cancel)
                {
                    String NewCS = _IMSConnectionString.Replace("=InstanceName=", txtUpdateInstance.Text.Trim());
                    String UpdateCommand = _IMSVersions.Where(Data => Data.DBVersion ==
                        _IMSDestinationVersions.Peek()).First().Command;
                    DataContext Comm = new DataContext(NewCS);
                    Comm.CommandTimeout = 0;
                    try { Comm.ExecuteCommand(UpdateCommand); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                        PMBox.Show("امكان ارتقاء بانك تصویربرداری وجود ندارد! \n" + "موارد زیر را بررسی نمایید: \n" +
                            "1. آیا ارتباط شما با بانك اطلاعاتی برقرار است؟ ", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                    #endregion
                }
            }
            #endregion
        }
        #endregion

        #region BGWorkerUpdate_RunWorkerCompleted
        private void BGWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateProgressBar.Visible = false;
            if (e.Cancelled) { btnCheckCurrentDb_Click(null, null); return; }

            #region Manage PMS Update
            if (_IsUpdatingPMS)
            {
                DbUpgradData VersionData = _PMSVersions.
                    Where(Data => Data.DBVersion == _PMSDestinationVersions.Peek()).First();
                try
                {
                    HISApplication TargetRow = _DbClassPS.HISApplications.Where(Data => Data.ID == 1).First();
                    TargetRow.DbVersion = VersionData.DBVersion;
                    TargetRow.Version = VersionData.Version;
                    _DbClassPS.SubmitChanges();
                }
                #region Catch
                catch (Exception)
                {
                    PMBox.Show("امكان به روز رسانی بانك در جدول برنامه ها وجود ندارد! \n" + "موارد زیر را بررسی نمایید: \n" +
                        "1. آیا ارتباط شما با بانك اطلاعاتی برقرار است؟", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion
                _PMSDestinationVersions.Dequeue();
            }
            #endregion

            #region Manage IMS Update
            else
            {
                DbUpgradData VersionData = _IMSVersions.
                    Where(Data => Data.DBVersion == _IMSDestinationVersions.Peek()).First();
                try
                {
                    HISApplication TargetRow = _DbClassPS.HISApplications.Where(Data => Data.ID == 500).First();
                    TargetRow.DbVersion = VersionData.DBVersion;
                    TargetRow.Version = VersionData.Version;
                    _DbClassPS.SubmitChanges();
                }
                #region Catch
                catch (Exception)
                {
                    PMBox.Show("امكان به روز رسانی ورژن بانك در جدول برنامه ها وجود ندارد! \n" + "موارد زیر را بررسی نمایید: \n" +
                        "1. آیا ارتباط شما با بانك اطلاعاتی برقرار است؟", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion
                _IMSDestinationVersions.Dequeue();
            }
            #endregion

            BGWorkerUpdate.RunWorkerAsync();
        }
        #endregion

        // +++++++++++++++++++++++++++++++++++++

        #region WizardControl_CancelButtonClick
        private void WizardControl_CancelButtonClick(object sender, CancelEventArgs e)
        {
            Close();
        }
        #endregion

        #region WPageFinish_FinishButtonClick
        private void WPageFinish_FinishButtonClick(object sender, CancelEventArgs e)
        {
            FormClosing -= Form_Closing;
            Application.Exit();
        }
        #endregion

        // +++++++++++++++++++++++++++++++++++++

        #region btnSelectFolders_Click
        private void btnSelectFolders_Click(object sender, EventArgs e)
        {
            switch (((ButtonX)sender).Name)
            {
                case "btnSelectFolder1":
                    {
                        FolderBrowser.SelectedPath = txtBankInstallFolder.Text;
                        DialogResult Result = FolderBrowser.ShowDialog();
                        if (Result == DialogResult.OK) txtBankInstallFolder.Text = FolderBrowser.SelectedPath;
                        break;
                    }
                case "btnSelectFolder2":
                    {
                        FolderBrowser.SelectedPath = txtNegarFolder.Text;
                        DialogResult Result = FolderBrowser.ShowDialog();
                        if (Result == DialogResult.OK) txtNegarFolder.Text = FolderBrowser.SelectedPath;
                        break;
                    }
            }
        }
        #endregion

        #region cBoxes_CheckedChanging
        private static void cBoxes_CheckedChanging(object sender, CheckBoxChangeEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region BGWorkerServer_DoWork
        private void BGWorkerServer_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _DataClass = new DataContext(_ConnectionString);
                _DataClass.CommandTimeout = 0;

                #region Part 1 - Set SA Password And Change Login
                const String ChangeSaPassCommandString = "USE MASTER; ALTER LOGIN [sa] WITH PASSWORD='sudnhdvhk'";
                _DataClass.ExecuteCommand(ChangeSaPassCommandString);
                // تغییر كاربر رشته ی اتصال به كاربر مدیر
                _ConnectionString = "Data Source = " + _InstanceName +
                    "; Initial Catalog = Master; UID = 'Sa'; PWD = 'sudnhdvhk'; Connection Timeout = 0;";
                _DataClass = new DataContext(_ConnectionString);
                _DataClass.CommandTimeout = 0;
                Thread.Sleep(500);
                BGWorkerServer.ReportProgress(1);
                #endregion

                #region Part 2 - Remove Other Sql Logins
                #region Delete Sql Logins
                const String RemoveSqlLoginsCommandText =
                    "SELECT [name] FROM sys.server_principals WHERE type_desc <> 'SERVER_ROLE' " +
                    "AND type_desc <> 'CERTIFICATE_MAPPED_LOGIN' AND [name] <> 'sa' ";
                DataTable tbl = new DataTable();
                SqlCommand cmd = new SqlCommand(RemoveSqlLoginsCommandText, new SqlConnection(_ConnectionString));
                try
                {
                    cmd.Connection.Open();
                    // ReSharper disable AssignNullToNotNullAttribute
                    tbl.Load(cmd.ExecuteReader());
                    // ReSharper restore AssignNullToNotNullAttribute
                }
                #region Catch
                catch (Exception)
                {
                    PMBox.Show("امكان خواندن لیست كاربران مجاز برای نصب بانك بر روی سرور مقدور نمی باشد.", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    FormClosing -= Form_Closing;
                    Application.Exit();
                    return;
                }
                finally { cmd.Connection.Close(); }
                #endregion
                if (tbl.Rows.Count != 0)
                    foreach (DataRow row in tbl.Rows)
                    {
                        String RemoveLoginComm =
                            "IF EXISTS(SELECT * FROM [master].[sys].[server_principals] WHERE [name] = N'" +
                            row[0] + "')" + " DROP LOGIN [" + row[0] + "]";
                        _DataClass.ExecuteCommand(RemoveLoginComm);
                    }
                #endregion
                Thread.Sleep(500);
                BGWorkerServer.ReportProgress(2);
                #endregion

                #region Part 3 - Unzip Database File
                try
                {
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\DbZipFile.Zip"))
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\DbZipFile.Zip");
                    if (File.Exists(Application.StartupPath + "\\Data - Server\\IMSDb.Zip"))
                        File.Copy(Application.StartupPath + "\\Data - Server\\IMSDb.Zip",
                            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\DbZipFile.Zip", true);
                    Zip ZipHelper = new Zip();
                    ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                    ZipHelper.TempDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                    Boolean IsOpenedZipFile = ZipHelper.OpenZip(
                        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\DbZipFile.Zip");
                    if (!IsOpenedZipFile) throw new Exception(ZipHelper.LastErrorText);
                    ZipHelper.DecryptPassword = "sudnhdvhk";
                    Boolean IsOk = ZipHelper.Extract(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
                    if (!IsOk) throw new Exception(ZipHelper.LastErrorText);
                    ZipHelper.CloseZip();
                    ZipHelper.Dispose();
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان باز كردن فایل پشتیبانی وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا فایل مورد نظر آسیب ندیده است؟\n" +
                        "2. آیا سیستم جاری دارای ویروس نمی باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\PatientsSystem.Bak"))
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\PatientsSystem.Bak");
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\ImagingSystem.Bak"))
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\ImagingSystem.Bak");
                    throw new Exception(Ex.Message, Ex.InnerException);
                }
                finally
                {
                    try
                    {
                        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\DbZipFile.Zip"))
                            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\DbZipFile.Zip");
                    }
                    // ReSharper disable EmptyGeneralCatchClause
                    catch (Exception) { }
                    // ReSharper restore EmptyGeneralCatchClause
                }
                #endregion
                #endregion

                #region Part 4 - Restore Databases And Delete Db Files
                _DataClass.ExecuteCommand(_SqlCommandText);
                BGWorkerServer.ReportProgress(3);
                #endregion

                #region Part 5 - Add Sql Exceptions
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\PatientsSystem.Bak"))
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\PatientsSystem.Bak");
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\ImagingSystem.Bak"))
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\ImagingSystem.Bak");
                Thread.Sleep(500);
                BGWorkerServer.ReportProgress(4);
                #endregion
            }
            #region Catch
            catch (Exception)
            {
                // For Test: MessageBox.Show(Ex.Message);
                PMBox.Show("امكان انجان عملیات نصب مقدور نمی باشد.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                FormClosing -= Form_Closing;
                Application.Exit();
                return;
            }
            #endregion
        }
        #endregion

        #region BGWorkerServer_ProgressChanged
        private void BGWorkerServer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ((CheckBoxItem)lstInstallServer.Items[e.ProgressPercentage - 1]).CheckedChanging -= cBoxes_CheckedChanging;
            ((CheckBoxItem)lstInstallServer.Items[e.ProgressPercentage - 1]).Checked = true;
            ((CheckBoxItem)lstInstallServer.Items[e.ProgressPercentage - 1]).CheckedChanging += cBoxes_CheckedChanging;
            lstInstallServer.Invalidate();
        }
        #endregion

        #region BGWorkerServer_RunWorkerCompleted
        private void BGWorkerServer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WPServer02.NextButtonVisible = eWizardButtonState.True;
            PBarServer.ProgressType = eProgressItemType.Standard;
            PBarServer.Text = "مراحل نصب سیستم با موفقیت انجام شد";
            BringToFront();
            Focus();
            SystemSound Beep = SystemSounds.Beep;
            Beep.Play();
        }
        #endregion

        // +++++++++++++++++++++++++++++++++++++

        #region BGWorkerClient_DoWork
        private void BGWorkerClient_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                #region Step 1: Install Persian Packages
                // 1: اجرای پروسس نصب بسته های فارسی ساز
                if (_InstallPersianPackages) InstallPersianPackages();
                Thread.Sleep(500);
                BGWorkerClient.ReportProgress(1);
                #endregion

                #region Step 2: Install Persian Keyboard
                // 2: اجرای پروسس نصب كیبورد
                if (_InstallPersianKeyboard) InstallPersianKeyboard();
                Thread.Sleep(500);
                BGWorkerClient.ReportProgress(2);
                #endregion

                #region Step 3: Install Persian Fonts
                // 3: كپی قلم های فارسی به پوشه ی قلم های ویندوز
                if (_InstallPersianFonts) CopyPersianFonts();
                Thread.Sleep(500);
                BGWorkerClient.ReportProgress(3);
                #endregion

                #region Step 4: Copy Application Files
                // 4: كپی برنامه ها به پوشه های مورد نظر
                CopyApplicationFiles();
                Thread.Sleep(500);
                BGWorkerClient.ReportProgress(4);
                #endregion

                #region Step 5: Register Components
                // 5: ثبت كاپوننت ها در رجیستری
                if (_InstallHardwareLock) RegisterDLLs();
                Thread.Sleep(500);
                BGWorkerClient.ReportProgress(5);
                #endregion

                #region Step 6: Empty Part
                // 6: ثبت برنامه ها در ویندوز - ثبت خاصی صورت نمی گیرد
                Thread.Sleep(500);
                BGWorkerClient.ReportProgress(6);
                #endregion

                #region Step 7: Make Shortcuts
                // 7: قرار دادن آیكون برنامه در منوی استارت و دسكتاپ
                CreateShortcuts();
                Thread.Sleep(500);
                BGWorkerClient.ReportProgress(7);
                #endregion
            }
            #region Catch
            catch (Exception)
            {
                PMBox.Show("امكان انجان عملیات نصب مقدور نمی باشد.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                FormClosing -= Form_Closing;
                Application.Exit();
                return;
            }
            #endregion
        }
        #endregion

        #region BGWorkerClient_ProgressChanged
        private void BGWorkerClient_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ((CheckBoxItem)lstInstallClient.Items[e.ProgressPercentage - 1]).CheckedChanging -= cBoxes_CheckedChanging;
            ((CheckBoxItem)lstInstallClient.Items[e.ProgressPercentage - 1]).Checked = true;
            ((CheckBoxItem)lstInstallClient.Items[e.ProgressPercentage - 1]).CheckedChanging += cBoxes_CheckedChanging;
            lstInstallClient.Invalidate();
        }
        #endregion

        #region BGWorkerClient_RunWorkerCompleted
        private void BGWorkerClient_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WPClient02.NextButtonVisible = eWizardButtonState.True;
            PBarClient.ProgressType = eProgressItemType.Standard;
            PBarClient.Text = "مراحل نصب سیستم با موفقیت انجام شد";
            SystemSound Beep = SystemSounds.Beep;
            Beep.Play();
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (WizardControl.SelectedPage == WPServer02 || WizardControl.SelectedPage == WPClient02)
            { e.Cancel = true; return; }
            DialogResult Result = PMBox.Show("آیا مایل به خروج از سیستم نصب می باشید؟", "خروج از نصب",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result == DialogResult.Yes) { FormClosing -= (Form_Closing); Application.Exit(); }
            else e.Cancel = true;
        }
        #endregion

        #endregion

        #region Methods

        // @@@@@@@@@  Server @@@@@@@@@

        #region Boolean IsCorrectConnection(String ConnectionString)
        /// <summary>
        /// تعیین صحت كاركرد رشته اتصال دریافت شده
        /// </summary>
        /// <param name="ConnectionString">رشته اتصال</param>
        /// <returns>صحت كاركرد</returns>
        private static Boolean IsCorrectConnection(String ConnectionString)
        {
            DataContext MyDbClass = new DataContext(ConnectionString);
            try { MyDbClass.Connection.Open(); }
            catch (SqlException) { return false; }
            #region Catch
            catch (Exception)
            {
                const string Message =
                    "خطایی غیر معمول در ارتباط با بانك اطلاعاتی رخ داده است." +
                    "\nبرای رفع عیب با مدیر سایت تماس بگیرید.";
                PMBox.Show(Message, "خطا!", MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                MyDbClass.Connection.Close();
                MyDbClass.Dispose();
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean CheckExistDataBase()
        /// <summary>
        /// بررسی وجود بانك های اطلاعاتی قبلی بر روی سیستم و حذف آنها
        /// </summary>
        private Boolean CheckExistDataBase()
        {
            SqlCommand comm = null;
            _DataClass = new DataContext(_ConnectionString);
            _DataClass.CommandTimeout = 0;
            try
            {
                #region Install PMS
                const String PMSCheckCommand = "IF EXISTS (SELECT [name] FROM sys.databases " +
                       "WHERE [name] = N'PatientsSystem') SELECT 1 ELSE SELECT 0";
                comm = new SqlCommand(PMSCheckCommand, new SqlConnection(_ConnectionString));
                comm.Connection.Open();
                Int16 PMSReturnValue = Convert.ToInt16(comm.ExecuteScalar());
                if (PMSReturnValue == 1)
                {
                    DialogResult Result = PMBox.Show("بانك اطلاعاتی مركزی سیستم قبلاً بر روی سرور نصب شده است.\n" +
                        "آیا مایلید بانك قبلی را حذف نموده و بانك جدید را جایگزین نمایید؟", "پرسش؟",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Result == DialogResult.Yes)
                    {
                        const String DropCommand = "USE MASTER; " +
                            "IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = N'PatientsSystem') " +
                            "DROP DATABASE [PatientsSystem]; ";
                        comm.CommandText = DropCommand;
                        comm.ExecuteNonQuery();
                    }
                    else return false;
                }
                #endregion

                #region Install IMS
                const String CheckCommand = "IF EXISTS (SELECT [name] FROM sys.databases " +
                    "WHERE [name] = N'ImagingSystem') SELECT 1 ELSE SELECT 0";
                comm = new SqlCommand(CheckCommand, new SqlConnection(_ConnectionString));
                comm.Connection.Open();
                Int16 ReturnValue = Convert.ToInt16(comm.ExecuteScalar());
                if (ReturnValue == 1)
                {
                    DialogResult Result = PMBox.Show("بانك اطلاعاتی تصویربرداری قبلاً بر روی سرور نصب شده است.\n" +
                        "آیا مایلید بانك قبلی را حذف نموده و بانك جدید را جایگزین نمایید؟", "پرسش؟",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Result == DialogResult.Yes)
                    {
                        const String DropCommand = "USE MASTER; " +
                            "IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = N'ImagingSystem') " +
                            "DROP DATABASE [ImagingSystem];";
                        comm.CommandText = DropCommand;
                        comm.ExecuteNonQuery();
                    }
                    else return false;
                }
                #endregion
            }
            #region Catch
            catch
            {
                PMBox.Show("خطا در حذف بانك های اطلاعاتی جاری سیستم.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            finally
            {
                if (comm != null) comm.Connection.Close();
                try
                {
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\DbZipFile.Zip"))
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\DbZipFile.Zip");
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\PatientsSystem.Bak"))
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\PatientsSystem.Bak");
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\ImagingSystem.Bak"))
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\ImagingSystem.Bak");
                }
                // ReSharper disable EmptyGeneralCatchClause
                catch (Exception) { }
                // ReSharper restore EmptyGeneralCatchClause
            }
            #endregion
            return true;
        }
        #endregion

        #region void MakeRestoreBankCommandString()
        /// <summary>
        /// تابعی برای تولید رشته بازیابی بانك های سیستم
        /// </summary>
        private void MakeRestoreBankCommandString()
        {
            String BackUpPath1 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\PatientsSystem.Bak";
            String BackUpPath2 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\ImagingSystem.Bak";
            _SqlCommandText = String.Empty;
            _SqlCommandText = "RESTORE DATABASE [PatientsSystem] " +
                "FROM DISK = N'" + BackUpPath1 + "' " +
                "WITH  FILE = 1,  " +
                "MOVE N'PatientsSystem' TO N'" + txtBankInstallFolder.Text.Trim() + "\\PatientsSystem.mdf', " +
                "MOVE N'PatientsSystem_Log' TO N'" + txtBankInstallFolder.Text.Trim() + "\\PatientsSystem_Log.ldf', " +
                "NOUNLOAD, REPLACE,  STATS = 50; ";
            _SqlCommandText += "RESTORE DATABASE [ImagingSystem] " +
                "FROM DISK = N'" + BackUpPath2 + "' " +
                "WITH  FILE = 1,  " +
                "MOVE N'ImagingSystem' TO N'" + txtBankInstallFolder.Text.Trim() + "\\ImagingSystem.mdf', " +
                "MOVE N'ImagingSystem_Log' TO N'" + txtBankInstallFolder.Text.Trim() + "\\ImagingSystem_Log.ldf', " +
                "NOUNLOAD, REPLACE,  STATS = 50;";
        }
        #endregion

        #region Boolean ReadCurrentInstanceApps()
        /// <summary>
        /// تابع تازه سازی اطلاعات جدول برنامه ها
        /// </summary>
        private Boolean ReadCurrentInstanceApps()
        {
            try
            {
                _DbClassPS.Connection.ConnectionString =
                    _PMSConnectionString.Replace("0", "4").Replace("=InstanceName=", txtUpdateInstance.Text.Trim());
                Table<HISApplication> TempApps = _DbClassPS.HISApplications;
                _DbClassPS.Refresh(RefreshMode.OverwriteCurrentValues, TempApps);
                _CurrentApplications = TempApps.ToList();
            }
            #region Catch
            catch (Exception)
            {
                PMBox.Show("امكان خواندن اطلاعات برنامه های نصب شده بر روی سرور وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید: \n" +
                    "1. آیا ارتباط شما با بانك اطلاعاتی بر قرار است؟\n" +
                    "2. آیا نمونه بانك اطلاعاتی وارد شده صحیح می باشد؟", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        // @@@@@@@@@  Client @@@@@@@@@

        #region void InstallPersianPackages()
        /// <summary>
        /// تابع نصب بسته های تنظیم كننده زبان ویندوز
        /// </summary>
        private void InstallPersianPackages()
        {
            try
            {
                ProcessStartInfo ProcessInfo = new ProcessStartInfo(Application.StartupPath +
                    "\\Data - Client\\Persian Packages\\Fix 1.Exe");
                ProcessInfo.Arguments = "/Q /R:N";
                ProcessInfo.CreateNoWindow = true;
                Process MyProcess = Process.Start(ProcessInfo);
                if (MyProcess != null) MyProcess.WaitForExit();
                if (MyProcess != null) MyProcess.Close();
                ProcessInfo.FileName = Application.StartupPath + "\\Data - Client\\Persian Packages\\Fix 2.Exe";
                ProcessInfo.Arguments = "/Q /R:N";
                MyProcess = Process.Start(ProcessInfo);
                if (MyProcess != null) MyProcess.WaitForExit();
                if (MyProcess != null) MyProcess.Close();
            }
            #region Catch
            catch (Exception)
            {
                PMBox.Show("خطا در نصب كیبورد فارسی استاندارد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormClosing -= Form_Closing;
                //Application.Exit();
            }
            #endregion
        }
        #endregion

        #region void InstallPersianKeyboard()
        /// <summary>
        /// تابع نصب بسته های نصب كننده كیبورد فارسی ویندوز
        /// </summary>
        private void InstallPersianKeyboard()
        {
            try
            {
                ProcessStartInfo ProcessInfo = new ProcessStartInfo(Application.StartupPath +
                    "\\Data - Client\\Persian Keyboard\\Setup.Exe");
                ProcessInfo.CreateNoWindow = false;
                ProcessInfo.UseShellExecute = false;
                Process.Start(ProcessInfo);
            }
            #region Catch
            catch (Exception)
            {
                PMBox.Show("خطا در نصب كیبورد فارسی استاندارد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormClosing -= Form_Closing;
                //Application.Exit();
            }
            #endregion
        }
        #endregion

        #region void CopyPersianFonts()
        /// <summary>
        /// تابع كپی كردن قلم های فارسی بر روی سیستم
        /// </summary>
        private void CopyPersianFonts()
        {
            try
            {
                String FontInstallPath = Application.StartupPath + "\\Data - Client\\Persian Fonts";
                String[] Fonts = Directory.GetFiles(FontInstallPath);
                foreach (String FontFile in Fonts)
                {
                    String DestinationFolder = Environment.GetEnvironmentVariables()["SystemRoot"] + "\\Fonts" +
                        FontFile.Substring(FontInstallPath.Length);
                    File.Copy(FontFile, DestinationFolder, true);
                }
                Process.Start(Environment.SystemDirectory.
                    Substring(0, Environment.SystemDirectory.Length - 9) + "\\Fonts");
            }
            #region Catch
            catch (Exception)
            {
                PMBox.Show("امكان نصب كردن قلم های فارسی بر روی سیستم جاری ممكن نمی باشد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormClosing -= Form_Closing;
                //Application.Exit();
            }
            #endregion
        }
        #endregion

        #region void CopyApplicationFiles()
        /// <summary>
        /// تابع كپی كردن فایل های اجرایی برنامه ها در پوشه های مشخص شده
        /// </summary>
        private void CopyApplicationFiles()
        {
            String ArashPMSPath = _NegarInstallPath + "\\Negar SSM";
            String SepehrIMSPath = _NegarInstallPath + "\\Sepehr IMS";

            #region Negar SSM Copy
            try
            {
                String PMSInstallPath = Application.StartupPath + "\\Data - Client\\PMS Files";
                String[] PMSFiles = Directory.GetFiles(PMSInstallPath);
                foreach (String PMSFile in PMSFiles)
                    if (PMSFile.Substring(PMSInstallPath.Length) != "HLManager.dll")
                        File.Copy(PMSFile, ArashPMSPath + "\\" + PMSFile.Substring(PMSInstallPath.Length), true);
                if (_InstallHardwareLock)
                    File.Copy(PMSInstallPath + "\\HLManager.dll",
                        Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\HLManager.dll", true);
            }
            #region Catch
            catch
            {
                PMBox.Show("امكان نصب كردن نرم افزار مدیریت كلینیك بر روی سیستم جاری ممكن نمی باشد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormClosing -= Form_Closing;
                //Application.Exit();
            }
            #endregion
            #endregion

            #region Sepehr IMS Copy
            try
            {
                String IMSInstallPath = Application.StartupPath + "\\Data - Client\\IMS Files";
                String[] IMSFiles = Directory.GetFiles(IMSInstallPath);
                foreach (String IMSFile in IMSFiles)
                    File.Copy(IMSFile, SepehrIMSPath + "\\" + IMSFile.Substring(IMSInstallPath.Length), true);
            }
            #region Catch
            catch
            {
                PMBox.Show("امكان نصب كردن نرم افزار مدیریت كلینیك بر روی سیستم جاری ممكن نمی باشد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormClosing -= Form_Closing;
                Application.Exit();
            }
            #endregion
            #endregion

            #region Install Crystall Reports
            if (_InstallCrystallReport)
                try
                {
                    ProcessStartInfo ProcessInfo =
                        new ProcessStartInfo(Application.StartupPath + "\\Data - Client\\CR2008\\CR2008.MSI");
                    ProcessInfo.Arguments = "/quiet";
                    ProcessInfo.CreateNoWindow = true;
                    ProcessInfo.UseShellExecute = true;
                    Process.Start(ProcessInfo);
                }
                #region Catch
                catch (Exception)
                {
                    PMBox.Show("خطا در نصب كریستال ریپورت!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormClosing -= Form_Closing;
                    //Application.Exit();
                }
                #endregion
            #endregion
        }
        #endregion

        #region void RegisterDLLs()
        /// <summary>
        /// تابعی برای ثبت كامپوننت ها
        /// </summary>
        private void RegisterDLLs()
        {
            if (Directory.Exists(_NegarInstallPath))
            {
                try
                {
                    ProcessStartInfo ProcessInfo = new ProcessStartInfo("Regsvr32.exe");
                    ProcessInfo.Arguments = "/s HLManager.Dll";
                    ProcessInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    ProcessInfo.CreateNoWindow = true;
                    ProcessInfo.UseShellExecute = false;
                    Process MyProcess = Process.Start(ProcessInfo);
                    if (MyProcess != null) MyProcess.WaitForExit();
                    if (MyProcess != null) MyProcess.Close();
                }
                #region Catch
                catch (Exception)
                {
                    PMBox.Show("خطا در نصب اجزاء برنامه!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormClosing -= Form_Closing;
                    Application.Exit();
                    return;
                }
                #endregion
            }
        }
        #endregion

        #region void CreateShortcuts()
        /// <summary>
        /// تابعی برای ایجاد آیكون میانبر برنامه
        /// </summary>
        private void CreateShortcuts()
        {
            try
            {
                ShellLink Shortcut = new ShellLink();
                Shortcut.Target = _NegarInstallPath + "\\Negar SSM\\Negar.SSM.exe";
                Shortcut.WorkingDirectory = _NegarInstallPath + "\\Negar SSM";
                Shortcut.DisplayMode = ShellLink.LinkDisplayMode.NormalWindow;
                Shortcut.Description = "میانبر سیستم مدیریت كلینیك نگار";
                Shortcut.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\نگار.lnk");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\نگار");
                Shortcut.Save(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\نگار\\نگار.lnk");
            }
            #region Catch
            catch (Exception)
            {
                PMBox.Show("خطا در ایجاد میانبر برنامه!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormClosing -= Form_Closing;
                Application.Exit();
            }
            #endregion
        }
        #endregion

        // @@@@@@@@@  Update @@@@@@@@@

        #region Boolean FillDatabasesVersionsArray()
        /// <summary>
        /// تابع تعریف ورژن های مختلف بانك اطلاعاتی
        /// </summary>
        private Boolean FillDatabasesVersionsArray()
        {
            _PMSVersions = SetupHelper.GenerateUpgradeList(MedicalSystemDbList.PatientsSystem);
            _IMSVersions = SetupHelper.GenerateUpgradeList(MedicalSystemDbList.ImagingSystem);
            if (_PMSVersions == null || _IMSVersions == null) return false;
            return true;
        }
        #endregion

        #endregion

    }
}