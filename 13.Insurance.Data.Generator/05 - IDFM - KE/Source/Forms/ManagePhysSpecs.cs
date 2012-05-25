#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Negar;
using Sepehr.DbLayer;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms
{
    /// <summary>
    /// فرم نمایش خصوصیات بیمه ها
    /// </summary>
    internal partial class frmManagePhysSpecs : Office2007Form
    {
        #region Fields

        #region _DbClassPS _DbClassPS
        /// <summary>
        /// شی ارتباط با بانك اطلاعاتی
        /// </summary>
        private readonly DbClassPS _DbClassPS;
        #endregion

        #region String _SavedDataFilePath = "PhysiciansCatID.XML"
        /// <summary>
        /// مسیر ثبت گروه های پزشكی
        /// </summary>
        private const String _SavedDataFilePath = "PhysiciansCatID.XML";
        #endregion

        #region private DataTable _MyDataTable
        /// <summary>
        /// شی برای نگهداری اطلاعات خوانده شده از فایل
        /// </summary>
        private DataTable _MyDataTable;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmManagePhysSpecs()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _DbClassPS = new DbClassPS(CSManager.GetConnectionString("PatientsSystem"));
            if (!FillBaseDataSource()) { Close(); return; }
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

        #region dgvData_CellEnter
        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // این دستور برای باز كردن خودكار سلول های كمبوباكس در جدول استفاده می شود
            if (e.RowIndex >= 0 && e.ColumnIndex == ColGroup.Index) dgvData.BeginEdit(false);
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            dgvData.EndEdit();
            btnAccept.Focus();
            // اگر فایل وجود نداشته باشد آن را می سازد
            if (!File.Exists(_SavedDataFilePath)) File.Create(_SavedDataFilePath).Close();
            if (SaveDataToFile()) DialogResult = DialogResult.OK;
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
            String TooltipText = "نمایش آموزش كاربری فرم.\r\n" +
                                 "این راهنمای كاربری به شما در مورد نحوه عملكرد فرم كمك می نماید.";
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                                                                        Resources.Help_Blue, Resources.SepehrLogo, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = "انصراف از اعمال تغییرات و خروج از فرم.\r\n" +
                          "در صورت اجرای این فرمان ، بدون ذخیره سازی اطلاعات وارد شده ، فرم بسته می شود.";
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                                                                        Resources.Help_Blue, Resources.SepehrLogo, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region Boolean FillBaseDataSource()
        /// <summary>
        /// تابعی برای خواندن اطلاعات تخصص های پزشكان
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillBaseDataSource()
        {
            try
            {
                List<SP_SelectRefPhysiciansSpecsResult> Data =
                    _DbClassPS.SP_SelectRefPhysiciansSpecs().Where(MyData => MyData.ID != null).ToList();
                if (Data.Count == 0)
                {
                    PMBox.Show("تخصصی برای تنظیم نوع آن در سیستم تعریف نشده است!", "عدم تعریف تخصص!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                List<PhysiciansSpecsCollection> SpecsCollectionCustom = new List<PhysiciansSpecsCollection>();
                foreach (SP_SelectRefPhysiciansSpecsResult result in Data)
                    SpecsCollectionCustom.Add(new PhysiciansSpecsCollection(result.ID.Value, result.Title, 1));
                dgvData.DataSource = SpecsCollectionCustom;
            }
            #region Catch

            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان جستجو  اطلاعات بیماران از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr" , "IDMF - KE" , Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }

            #endregion

            #region ColType
            Dictionary<Int16, String> Type = new Dictionary<Int16, String>();
            Type.Add(01, "پزشك");
            Type.Add(02, "دندانپزشك");
            Type.Add(03, "ماما");
            Type.Add(04, "پیرا پزشك");

            ColGroup.DataSource = Type.ToList();
            ColGroup.DisplayMember = "Value";
            ColGroup.ValueMember = "Key";
            ColGroup.DataPropertyName = "KeyID";
            #endregion

            if (!ReadSavedDataFromFile()) return false;
            return true;
        }

        #endregion

        #region Boolean ReadSavedDataFromFile()
        /// <summary>
        /// تابعی برای خواندن اطلاعات قبلی ذخیره شده از فایل تنظیمات
        /// </summary>
        private Boolean ReadSavedDataFromFile()
        {
            if (!File.Exists(_SavedDataFilePath))
            {
                PMBox.Show("فایل اصلی تنظیمات تخصص های پزشكان یافت نشد!\n" +
                    "لطفاً تنظیمات را مجدداً اعمال نمایید.", "هشدار!", MessageBoxButtons.OK, MessageBoxIcon.Warning); return true;
            }
            try
            {
                _MyDataTable = new DataTable("TableName");
                _MyDataTable.Columns.Add("SpecsID", typeof(Int16));
                _MyDataTable.Columns.Add("SpecsCode", typeof(Int16));
                _MyDataTable.ReadXml(_SavedDataFilePath);
                // تكمیل اطلاعات لیست اختصاصی تخصص های پزشكان بر اساس تخصص های ثبت شده در بانك اطلاعات
                for (Int16 i = 0; i < dgvData.Rows.Count; i++)
                {
                    DataRow[] SelectedData = _MyDataTable.Select("SpecsID = " + dgvData.Rows[i].Cells[ColSpecsID.Index].Value);
                    if (SelectedData.Length != 0 && SelectedData[0]["SpecsCode"] != null &&
                      SelectedData[0]["SpecsCode"] != DBNull.Value)
                        dgvData.Rows[i].Cells[ColGroup.Index].Value = Convert.ToInt16(SelectedData[0]["SpecsCode"]);
                }
                dgvData.Refresh();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "خواندن اطلاعات از فایل ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "IDFM - TE", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                try { File.Delete(_SavedDataFilePath); }
                // ReSharper disable EmptyGeneralCatchClause
                catch (Exception) { }
                // ReSharper restore EmptyGeneralCatchClause
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean SaveDataToFile()
        /// <summary>
        /// ذخیره سازی اطلاعات تنظیم شده در فرم در فایل تنظیمات
        /// </summary>
        private Boolean SaveDataToFile()
        {
            _MyDataTable = new DataTable("TableName");
            _MyDataTable.Columns.Add("SpecsID", typeof(Int16));
            _MyDataTable.Columns.Add("SpecsCode", typeof(Int16));

            foreach (DataGridViewRow row in dgvData.Rows)
                _MyDataTable.Rows.Add(Convert.ToInt16(row.Cells[ColSpecsID.Index].Value),
                    Convert.ToInt16(row.Cells[ColGroup.Index].Value));
            // ذخیره اطلاعات در فایل
            try { _MyDataTable.WriteXml(_SavedDataFilePath); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "نوشتن اطلاعات انتخاب شده در فایل ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا كاربر جاری ویندوز دسترسی لازم برای ایجاد فایل را دارد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr" , "IDMF - KE" , Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

        #region Classes

        #region private class PhysiciansSpecsCollection
        /// <summary>
        /// كلاس اختصاصی برنامه برای مدیریت تخصص های پزشكان
        /// </summary>
        private class PhysiciansSpecsCollection
        {
            // ReSharper disable UnusedAutoPopertyAccessor
            public Int16 ID { get; set; }
            public String Name { get; set; }
            public Int16 KeyID { get; set; }
            // ReSharper restore UnusedAutoPopertyAccessor

            public PhysiciansSpecsCollection(Int16 TheID, String TheName, Int16 TheKeyID)
            {
                ID = TheID;
                Name = TheName;
                KeyID = TheKeyID;
            }
        }
        #endregion

        #endregion

    }
}