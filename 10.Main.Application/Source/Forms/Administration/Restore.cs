#region using
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Negar;
using Chilkat;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms.Administration
{
    /// <summary>
    /// فرم بازیابی فایل پشتیبانی بانك اطلاعاتی
    /// </summary>
    public partial class frmRestore : Form
    {

        #region Fields
        private String _PSBackupCommand;
        private String _ISBackupCommand;
        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmRestore()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("En-Us"));
            InitializeComponent();
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Load
        private void Form_Load(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region btnSelectPath_Click
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            TextBoxX Control = new TextBoxX();
            switch (((ButtonX)sender).Name)
            {
                case "btnBackupPath": Control = txtBackupPath; break;
                case "btnRestorePath1": Control = txtRestorePath1; break;
                case "btnRestorePath2": Control = txtRestorePath2; break;
            }
            DialogResult Dr = FolderBrowser.ShowDialog();
            if (Dr == DialogResult.OK) Control.Text = FolderBrowser.SelectedPath;
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            RestoreDb();
            if (!BGWorker.IsBusy)
            {
                if (File.Exists(txtBackupPath.Text.Trim() + "\\PatientsSystem.Bak"))
                    File.Delete(txtBackupPath.Text.Trim() + "\\PatientsSystem.Bak");
                if (File.Exists(txtBackupPath.Text.Trim() + "\\ImagingSystem.Bak"))
                    File.Delete(txtBackupPath.Text.Trim() + "\\ImagingSystem.Bak");
            }
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Boolean Result = false;
            if (!String.IsNullOrEmpty(_PSBackupCommand))
                Result = Negar.DBLayerPMS.Manager.ExecuteCommand(_PSBackupCommand, 0, "Master");
            if (!String.IsNullOrEmpty(_ISBackupCommand))
                Result = Negar.DBLayerPMS.Manager.ExecuteCommand(_ISBackupCommand, 0, "Master");
            if (!Result) { e.Cancel = true; }
            if (File.Exists(txtBackupPath.Text.Trim() + "\\PatientsSystem.Bak"))
                File.Delete(txtBackupPath.Text.Trim() + "\\PatientsSystem.Bak");
            if (File.Exists(txtBackupPath.Text.Trim() + "\\ImagingSystem.Bak"))
                File.Delete(txtBackupPath.Text.Trim() + "\\ImagingSystem.Bak");
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) PMBox.Show("خطا در عملیات بازیابی اطلاعات بر روی بانك اطلاعاتی!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else PMBox.Show("اتمام عملیات بازیابی اطلاعات بر روی بانك اطلاعاتی!", "پایان بازیابی!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProgressBarForm.ProgressType = eProgressItemType.Standard;
            Enabled = true;
            ProgressBarForm.Text = "در انتظار بازیابی بانك اطلاعاتی";
            BringToFront();
            Focus();
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            Dispose();
        }
        #endregion

        #endregion

        #region Methods

        #region void SetControlsToolTipTexts()
        /// <summary>
        /// تابع تنظیم متن راهنمای كنترل ها
        /// </summary>
        private void SetControlsToolTipTexts()
        {
            const String TooltipHeader = "راهنمای تنظیمات سیستم";
            const String TooltipFooter = "سیستم مدیریت تصویربرداری سپهر";

            #region btnHelp
            String TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnRestore", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region void RestoreDb()
        /// <summary>
        /// روالی برای بازیابی فایل پشتیبانی بانك ها
        /// </summary>
        private void RestoreDb()
        {
            #region Validations
            if (!cBoxOption1.Checked && !cBoxOption2.Checked)
            {
                PMBox.Show("برای بازیابی بانك ها حداقل یك بانك اطلاعاتی را انتخاب نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(txtBackupPath.Text.Trim()))
            {
                PMBox.Show("پوشه انتخاب شده وجود ندارد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(txtBackupPath.Text.Trim() + "\\NegarDbBackupFile.NegarBackup"))
            {
                PMBox.Show("فایل پشتیبانی در پوشه ی انتخاب شده وجود ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Unzip And Unprotect Backup Data
            try
            {
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                Boolean IsOpenedZipFile = ZipHelper.OpenZip(txtBackupPath.Text.Trim() + "\\NegarDbBackupFile.NegarBackup");
                if (!IsOpenedZipFile) throw new Exception(ZipHelper.LastErrorText);
                ZipHelper.DecryptPassword = "sudnhdvhk";
                Int32 FilesCount = ZipHelper.Unzip(txtBackupPath.Text.Trim());
                if (FilesCount == -1) throw new Exception(ZipHelper.LastErrorText);
                ZipHelper.CloseZip();
                ZipHelper.Dispose();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان باز كردن فایل پشتیبانی وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا فایل مورد نظر آسین ندیده است؟\n" +
                    "2. آیا سیستم جاری دارای ویروس نمی باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            #endregion

            #region PatientsSystem RestoreDb String
            _PSBackupCommand = String.Empty;
            if (cBoxOption1.Checked)
            {
                if (!File.Exists(txtBackupPath.Text.Trim() + "\\PatientsSystem.Bak"))
                {
                    PMBox.Show("فایل پشتیبانی سیستم مدیریت كلینیك در فایل پشتیبانی انتخاب شده وجود ندارد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Directory.Exists(txtRestorePath1.Text.Trim()))
                {
                    DialogResult Result = PMBox.Show("پوشه انتخاب شده وجود ندارد! آیا مایلید پوشه مورد نظر ساخته شود؟", "پرسش؟",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Result == DialogResult.Yes) Directory.CreateDirectory(txtRestorePath1.Text.Trim());
                    else return;
                }
                _PSBackupCommand = "ALTER DATABASE [PatientsSystem] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                    "RESTORE DATABASE [PatientsSystem] " +
                    "FROM DISK = N'" + txtBackupPath.Text.Trim() + "\\PatientsSystem.Bak' " +
                    "WITH  FILE = 1,  " +
                    "MOVE N'PatientsSystem' TO N'" + txtRestorePath1.Text.Trim() + "\\PatientsSystem.mdf', " +
                    "MOVE N'PatientsSystem_Log' TO N'" + txtRestorePath1.Text.Trim() + "\\PatientsSystem_Log.ldf', " +
                    "NOUNLOAD, REPLACE,  STATS = 50; " +
                    "ALTER DATABASE [PatientsSystem] SET MULTI_USER";
            }
            #endregion

            #region ImagingSystem RestoreDb String
            _ISBackupCommand = String.Empty;
            if (cBoxOption2.Checked)
            {
                if (!File.Exists(txtBackupPath.Text.Trim() + "\\PatientsSystem.Bak"))
                {
                    PMBox.Show("فایل پشتیبانی سیستم مدیریت كلینیك در فایل پشتیبانی انتخاب شده وجود ندارد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Directory.Exists(txtRestorePath2.Text.Trim()))
                {
                    DialogResult Result = PMBox.Show("پوشه انتخاب شده وجود ندارد! آیا مایلید پوشه مورد نظر ساخته شود؟", "پرسش؟",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Result == DialogResult.Yes) Directory.CreateDirectory(txtRestorePath2.Text.Trim());
                    else return;
                }
                _PSBackupCommand = "ALTER DATABASE [ImagingSystem] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                    "RESTORE DATABASE [ImagingSystem] " +
                    "FROM DISK = N'" + txtBackupPath.Text.Trim() + "\\ImagingSystem.Bak' " +
                    "WITH  FILE = 1,  " +
                    "MOVE N'ImagingSystem' TO N'" + txtRestorePath2.Text.Trim() + "\\ImagingSystem.mdf', " +
                    "MOVE N'ImagingSystem_Log' TO N'" + txtRestorePath2.Text.Trim() + "\\ImagingSystem_Log.ldf', " +
                    "NOUNLOAD, REPLACE,  STATS = 50;" +
                    "ALTER DATABASE [ImagingSystem] SET MULTI_USER";
            }
            #endregion

            Enabled = false;
            ProgressBarForm.ProgressType = eProgressItemType.Marquee;
            ProgressBarForm.Text = "در حال بازیابی بانك اطلاعاتی";
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #endregion

    }
}