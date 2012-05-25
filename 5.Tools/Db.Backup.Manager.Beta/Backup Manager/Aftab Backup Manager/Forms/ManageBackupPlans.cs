#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Microsoft.Win32;

#endregion

namespace Aftab
{
    /// <summary>
    /// فرم ایجاد و یا ویرایش برنامه پشتیبان گیری
    /// </summary>
    public partial class frmManageBackupPlans : Form
    {

        #region Fields

        #region DataTable _BackupPlansDataTable
        /// <summary>
        /// نگهدارنده اطلاعات برای هم ذخیره كردن و هم خواندن
        /// </summary>
        private DataTable _BackupPlansDataTable;
        #endregion

        #region Int32? _JobID
        /// <summary>
        /// آی دی برای ویرایش برنامه پشتیبان گیری
        /// </summary>
        private readonly Int32? _JobID;
        #endregion

        #region String _SettingFilePath
        /// <summary>
        /// 
        /// </summary>
        private String _SettingFilePath;
        #endregion

        #endregion

        #region Ctor
        public frmManageBackupPlans(Int32? JobID)
        {
            InitializeComponent();
            _SettingFilePath = Environment.SystemDirectory + "\\BackupPlans.DAT";
            _JobID = JobID;
            cBoxInstanceName.DataSource = LoadSqlInstaceNames().ToList();
            cBoxInstanceName.ValueMember = "Key";
            cBoxInstanceName.DisplayMember = "Value";
            if (_JobID != null) FillBaseData();
            else
            {
                DateAppStart.SelectedDateTime = DateTime.Now;
                DateAppEnd.SelectedDateTime = DateTime.Now.AddMonths(1);
                TimeStart.Value = new DateTime(2000, 1, 1, 6, 0, 0);
            }
        }
        #endregion

        #region Event Handlers

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            Boolean IsAnyChecked = false;
            foreach (CheckBoxX chk in PanelDays.Controls)
                if (chk.Checked)
                {
                    IsAnyChecked = true;
                    break;
                }
            if (!IsAnyChecked)
            {
                PMBox.Show("باید برای تعریف برنامه حداقل یك روز را انتخاب نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_JobID != null) UpdateBackupPlan();
            else SaveBackupPlanToFile();
            Close();
        }
        #endregion

        #region btnSelectPath_Click
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowser.SelectedPath = txtSaveFirstPath.Text;
            DialogResult Dr = FolderBrowser.ShowDialog();
            if (Dr == DialogResult.OK) txtSaveFirstPath.Text = FolderBrowser.SelectedPath;
        }
        #endregion

        #region btnSelectSecondPath_Click
        private void btnSelectSecondPath_Click(object sender, EventArgs e)
        {
            FolderBrowser.SelectedPath = txtSaveSecondPath.Text;
            DialogResult Dr = FolderBrowser.ShowDialog();
            if (Dr == DialogResult.OK) txtSaveSecondPath.Text = FolderBrowser.SelectedPath;
        }
        #endregion

        #region btnSelectThirdPath_Click
        private void btnSelectThirdPath_Click(object sender, EventArgs e)
        {
            FolderBrowser.SelectedPath = txtSaveThirdPath.Text;
            DialogResult Dr = FolderBrowser.ShowDialog();
            if (Dr == DialogResult.OK) txtSaveThirdPath.Text = FolderBrowser.SelectedPath;
        }
        #endregion

        #region btnSelectInstance_Click
        private void btnSelectInstance_Click(object sender, EventArgs e)
        {
            if (txtInstanceName.Visible)
            {
                txtInstanceName.Visible = false;
                cBoxInstanceName.Visible = true;
            }
            else
            {
                cBoxInstanceName.Visible = false;
                txtInstanceName.Visible = true;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region void SaveBackupPlanToFile()
        /// <summary>
        /// تابع ذخیره سازی تنظیمات در فایل
        /// </summary>
        private void SaveBackupPlanToFile()
        {
            _BackupPlansDataTable = new DataTable("BackupPlans");
            #region AddColumns
            _BackupPlansDataTable.Columns.Add("ID", typeof(Int32));
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
            #region Week
            _BackupPlansDataTable.Columns.Add("FirstDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("SecondDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("ThirdDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("FourthDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("FifthDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("SixthDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("SeventhDay", typeof(Boolean));
            #endregion
            _BackupPlansDataTable.Columns["ID"].AutoIncrement = true;
            #endregion
            ReadXml();
            #region Add Row
            try
            {
                _BackupPlansDataTable.Rows.Add(null, cBoxIsActive.Checked, txtAppName.Text,
                                DateAppStart.SelectedDateTime, DateAppEnd.SelectedDateTime, TimeStart.Value,
                                cBoxInstanceName.Text, cBoxImagingBank.Checked, txtSaveFirstPath.Text, txtSaveSecondPath.Text,
                                txtSaveThirdPath.Text, cBoxDay1.Checked, cBoxDay2.Checked, cBoxDay3.Checked, cBoxDay4.Checked,
                                cBoxDay5.Checked, cBoxDay6.Checked, cBoxDay7.Checked);
            }
            #region Catch
            catch (Exception)
            {
                const String ErrorMessage =
                    "امكان اضافه كردن سطر جدید به دیتا تیبل وجود ندارد.\n" +
                    "با مدیر سیستم تماس بگیرید";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
            #endregion
            WriteXml();
        }
        #endregion

        #region void UpdateBackupPlan()
        /// <summary>
        /// تابع به روز رسانی تنظیمات در فایل
        /// </summary>
        private void UpdateBackupPlan()
        {
            _BackupPlansDataTable = new DataTable("BackupPlans");
            #region AddColumns
            _BackupPlansDataTable.Columns.Add("ID", typeof(Int32));
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
            #region Week
            _BackupPlansDataTable.Columns.Add("FirstDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("SecondDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("ThirdDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("FourthDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("FifthDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("SixthDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("SeventhDay", typeof(Boolean));
            #endregion
            _BackupPlansDataTable.Columns["ID"].AutoIncrement = true;
            #endregion
            ReadXml();
            #region First Remove And then Add Row

            String InstanceName = txtInstanceName.Visible ? txtInstanceName.Text : cBoxInstanceName.Text;
            try
            {
                _BackupPlansDataTable.Rows.Remove(_BackupPlansDataTable.Select("ID = " + _JobID).First());
                _BackupPlansDataTable.Rows.Add(_JobID, cBoxIsActive.Checked, txtAppName.Text,
                                DateAppStart.SelectedDateTime, DateAppEnd.SelectedDateTime, TimeStart.Value, InstanceName,
                                cBoxImagingBank.Checked, txtSaveFirstPath.Text, txtSaveSecondPath.Text, txtSaveThirdPath.Text,
                                cBoxDay1.Checked, cBoxDay2.Checked, cBoxDay3.Checked, cBoxDay4.Checked, cBoxDay5.Checked,
                                cBoxDay6.Checked, cBoxDay7.Checked);
            }
            #region Catch
            catch (Exception)
            {
                const String ErrorMessage =
                    "امكان اضافه كردن و یا حذف سطر دیتا تیبل وجود ندارد.\n" +
                    "با مدیر سیستم تماس بگیرید";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
            #endregion
            WriteXml();
        }
        #endregion

        #region void FillBaseData()
        /// <summary>
        /// تابع به روز رسانی تنظیمات در فایل
        /// </summary>
        private void FillBaseData()
        {
            cBoxInstanceName.Visible = false;
            txtInstanceName.Visible = true;
            btnSelectInstance.Enabled = true;
            _BackupPlansDataTable = new DataTable("BackupPlans");
            #region AddColumns
            _BackupPlansDataTable.Columns.Add("ID", typeof(Int32));
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
            #region Week
            _BackupPlansDataTable.Columns.Add("FirstDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("SecondDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("ThirdDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("FourthDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("FifthDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("SixthDay", typeof(Boolean));
            _BackupPlansDataTable.Columns.Add("SeventhDay", typeof(Boolean));
            #endregion
            _BackupPlansDataTable.Columns["ID"].AutoIncrement = true;
            #endregion
            ReadXml();
            #region SetControls

            cBoxIsActive.Checked = Convert.ToBoolean(_BackupPlansDataTable.Select("ID = " + _JobID).First()["IsActive"]);
            txtAppName.Text = _BackupPlansDataTable.Select("ID = " + _JobID).First()["AppName"].ToString();

            DateAppStart.SelectedDateTime = Convert.ToDateTime(
                _BackupPlansDataTable.Select("ID = " + _JobID).First()["DateAppStart"]);
            DateAppEnd.SelectedDateTime = Convert.ToDateTime(
                _BackupPlansDataTable.Select("ID = " + _JobID).First()["DateAppEnd"]);
            TimeStart.Value = Convert.ToDateTime(_BackupPlansDataTable.Select("ID = " + _JobID).First()["TimeStart"]);

            txtInstanceName.Text = _BackupPlansDataTable.Select("ID = " + _JobID).First()["InstanceName"].ToString();
            cBoxImagingBank.Checked = Convert.ToBoolean(
                _BackupPlansDataTable.Select("ID = " + _JobID).First()["ImagingBank"]);

            txtSaveFirstPath.Text = _BackupPlansDataTable.Select("ID = " + _JobID).First()["FirstPath"].ToString();
            txtSaveSecondPath.Text = _BackupPlansDataTable.Select("ID = " + _JobID).First()["SecondPath"].ToString();
            txtSaveThirdPath.Text = _BackupPlansDataTable.Select("ID = " + _JobID).First()["ThirdPath"].ToString();

            cBoxDay1.Checked = Convert.ToBoolean(_BackupPlansDataTable.Select("ID = " + _JobID).First()["FirstDay"]);
            cBoxDay2.Checked = Convert.ToBoolean(_BackupPlansDataTable.Select("ID = " + _JobID).First()["SecondDay"]);
            cBoxDay3.Checked = Convert.ToBoolean(_BackupPlansDataTable.Select("ID = " + _JobID).First()["ThirdDay"]);
            cBoxDay4.Checked = Convert.ToBoolean(_BackupPlansDataTable.Select("ID = " + _JobID).First()["FourthDay"]);
            cBoxDay5.Checked = Convert.ToBoolean(_BackupPlansDataTable.Select("ID = " + _JobID).First()["FifthDay"]);
            cBoxDay6.Checked = Convert.ToBoolean(_BackupPlansDataTable.Select("ID = " + _JobID).First()["SixthDay"]);
            cBoxDay7.Checked = Convert.ToBoolean(_BackupPlansDataTable.Select("ID = " + _JobID).First()["SeventhDay"]);

            #endregion
        }
        #endregion

        #region void WriteXml()
        /// <summary>
        /// تابع نوشتن اطلاعات تنظیمات در فایل
        /// </summary>
        private void WriteXml()
        {
            try
            {
                if (!File.Exists(_SettingFilePath)) File.Create(_SettingFilePath).Close();
                _BackupPlansDataTable.WriteXml(_SettingFilePath);
            }
            #region Catch
            catch (Exception)
            {
                PMBox.Show("امكان نوشتن اطلاعات در فایل تنظیمات پشتیبان گیری وجود ندارد.\n" +
                "موارد زیر را بررسی نمایید:\n" +
                "1.نداشتن مجوز دسترسی به فایل تنظیمات.\n" +
                "2.نداشتن مجوز ایجاد فایل تنظیمات.\n" +
                "3.تغییر دادن محتویات فایل تنظیمات پشتیبان گیری به صورت دستی",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }
        #endregion

        #region void ReadXml()
        /// <summary>
        /// تابع خواندن اطلاعات تنظیمات از فایل
        /// </summary>
        private void ReadXml()
        {
            if (!File.Exists(_SettingFilePath)) return;
            try { _BackupPlansDataTable.ReadXml(_SettingFilePath); }
            #region Catch
            catch (Exception)
            {
                PMBox.Show("امكان خواندن اطلاعات از فایل تنظیمات پشتیبان گیری وجود ندارد.\n" +
                "موارد زیر را بررسی نمایید:\n" +
                "1.نداشتن مجوز دسترسی به فایل تنظیمات.\n" +
                "2.تغییر دادن محتویات فایل تنظیمات پشتیبان گیری به صورت دستی",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
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
            Dictionary<short, string> InstanceDic = new Dictionary<Int16, String>();
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
            catch (Exception)
            {
                PMBox.Show("امكان دسترسی به كلید رجیستری نمونه های نصب شده وجود ندارد!", "پرسش؟",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return InstanceDic;
            }
            return InstanceDic;
        }
        #endregion

        #endregion

    }
}
