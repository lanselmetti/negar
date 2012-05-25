#region using
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AftabCalendar.UI.Controls;
#endregion

namespace Aftab
{
    public partial class frmBackupPlans : Form
    {
        #region Fields

        #region DataTable _BackupPlansDataTable
        /// <summary>
        /// نگهدارنده اطلاعات برای هم ذخیره كردن و هم خواندن
        /// </summary>
        private DataTable _BackupPlansDataTable;
        #endregion

        #region String _SettingFilePath
        /// <summary>
        /// 
        /// </summary>
        private String _SettingFilePath;
        #endregion

        #endregion

        #region Ctor
        public frmBackupPlans()
        {
            InitializeComponent();
            _SettingFilePath = Environment.SystemDirectory + "\\BackupPlans.DAT";
            dgvData.AutoGenerateColumns = false;
            ((DataGridViewPersianDateTimePickerColumn)dgvData.Columns[ColStartDate.Index]).ShowTime = false;
            ((DataGridViewPersianDateTimePickerColumn)dgvData.Columns[ColEndDate.Index]).ShowTime = false;
            FillBaseData();
            Show();
        }
        #endregion

        #region EventHandlers

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvData.SelectedCells.Count != 0)
            {
                dgvData_CellMouseClick(1,
                    new DataGridViewCellMouseEventArgs
                        (0, dgvData.SelectedCells[0].RowIndex, Left + Width - 150,
                        Top + dgvData.Top +
                        dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top
                        + dgvData.ColumnHeadersHeight + 25,
                        new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
            }
        }
        #endregion

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sender.GetType().Equals(typeof(Int32)) &&
           e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvData.Rows[e.RowIndex].Selected = true;
                cmsMenu.PopupMenu(e.Location);
            }
            else if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvData.Rows[e.RowIndex].Selected = true;
                cmsMenu.Popup(MousePosition);
            }
        }
        #endregion

        #region dgvData_CellMouseDoubleClick
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || e.Button != MouseButtons.Left) return;
            btnEditApp_Click(null, null);
        }
        #endregion

        #region btnEditApp_Click
        private void btnEditApp_Click(object sender, EventArgs e)
        {
            frmManageBackupPlans MyForm = new frmManageBackupPlans(
                Convert.ToInt32(dgvData.SelectedRows[0].Cells[ColID.Index].Value));
            MyForm.ShowDialog();
            FillBaseData();
        }
        #endregion

        #region btnRemove_Click
        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveBackupPlan();
            FillBaseData();
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmManageBackupPlans MyForm = new frmManageBackupPlans(null);
            MyForm.ShowDialog();
            FillBaseData();
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #endregion

        #region Methods

        #region FillBaseData()
        /// <summary>
        /// پر كردن اطلاعات پایه
        /// </summary>
        private void FillBaseData()
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
            dgvData.DataSource = _BackupPlansDataTable;
            dgvData.Sort(ColID , ListSortDirection.Ascending);
        }
        #endregion

        #region void RemoveBackupPlan()
        /// <summary>
        /// تابع به روز رسانی تنظیمات در فایل
        /// </summary>
        private void RemoveBackupPlan()
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
            #region Remove a Job
            try
            {
                _BackupPlansDataTable.Rows.Remove(_BackupPlansDataTable
                                .Select("ID = " + Convert.ToInt32(dgvData.SelectedRows[0].Cells[ColID.Index].Value)).First());
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
            try
            {
                _BackupPlansDataTable.ReadXml(_SettingFilePath);
            }
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

        #endregion

    }
}
