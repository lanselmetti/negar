#region using
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Negar;
using Chilkat;
using DevComponents.DotNetBar;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms.Administration
{
    /// <summary>
    /// فرم ایجاد فایل پشتیبان از بانك اطلاعات
    /// </summary>
    public partial class frmBackup : Form
    {

        #region Fields
        private String _PSBackupCommand;
        private String _ISBackupCommand;
        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmBackup()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("En-Us"));
            InitializeComponent();
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
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
            GenerateBackupString();
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(_PSBackupCommand)) DBLayerIMS.Manager.ExecuteCommand(_PSBackupCommand, 0);
                if (!String.IsNullOrEmpty(_ISBackupCommand)) Negar.DBLayerPMS.Manager.ExecuteCommand(_ISBackupCommand, 0);

                #region Zip And Protect Backup Data
                String BackupFilePath = txtSavePath.Text.Trim() + "\\NegarDbBackupFile.NegarBackup";
                if (File.Exists(BackupFilePath)) File.Delete(BackupFilePath);
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
                LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                e.Cancel = true;
                return;
            }
            #endregion
            finally
            {
                if (File.Exists(txtSavePath.Text.Trim() + "\\PatientsSystem.Bak"))
                    File.Delete(txtSavePath.Text.Trim() + "\\PatientsSystem.Bak");
                if (File.Exists(txtSavePath.Text.Trim() + "\\ImagingSystem.Bak"))
                    File.Delete(txtSavePath.Text.Trim() + "\\ImagingSystem.Bak");
            }
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
            TooltipText = ToolTipManager.GetText("btnBackup", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

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

        #endregion

    }
}