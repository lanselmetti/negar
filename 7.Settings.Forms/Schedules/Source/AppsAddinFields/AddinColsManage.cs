#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Schedules.Properties;
#endregion

namespace Sepehr.Settings.Schedules.AppsAddinFields
{
    /// <summary>
    /// فرم تعریف فیلد اطلاعات اضافی نوبت دهی
    /// </summary>
    internal partial class frmAddinColsManage : Form
    {

        #region Field

        #region readonly Boolean _IsAdding

        /// <summary>
        /// تعیین حالت فرم
        /// </summary>
        private readonly Boolean _IsAdding;

        #endregion

        #region readonly Int16 _CurrentFieldID
        /// <summary>
        /// كلید فیلد جاری
        /// </summary>
        private readonly Int16 _CurrentFieldID;
        #endregion

        #region SchAddinColumns _CurrentFieldData
        /// <summary>
        /// شیء فیلد پویا جاری
        /// </summary>
        private SchAddinColumns _CurrentFieldData;
        #endregion

        #endregion

        #region Ctors

        #region frmAddinColsManage()
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAddinColsManage()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _IsAdding = true;
            if (!FillBaseDataSource()) { Close(); return; }
            cboFieldType.SelectedIndex = 0;
            ShowDialog();
        }
        #endregion

        #region frmAddinColsManage(Int16 FieldID)
        /// <summary>
        /// سازنده فرم برای ویرایش
        /// </summary>
        public frmAddinColsManage(Int16 FieldID)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _IsAdding = false;
            _CurrentFieldID = FieldID;
            if (!FillBaseDataSource() || !FillCurrentColData()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region cboFieldType_SelectedIndexChanged
        private void cboFieldType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFieldType.SelectedIndex == 0)
            {
                lblLenght.Visible = true;
                txtLenght.Visible = true;
            }
            else
            {
                lblLenght.Visible = false;
                txtLenght.Visible = false;
            }
            FormPanel.Invalidate();
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                PMBox.Show("برای فیلد حتماً نامی انتخاب نمایید!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (_IsAdding) { if (!AddNewCol()) { Close(); return; } }
            else { if (!EditCurrentCol()) { Close(); return; } }
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
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

            #region btnCancel
            String TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillBaseDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات پایه فرم از بانك
        /// </summary>
        private Boolean FillBaseDataSource()
        {
            List<SP_SelectApplicationsResult> Applications =
                DBLayerIMS.Schedules.SchAppList.Where(Data => Data.ID != null).ToList();
            if (Applications.Count == 0)
            {
                PMBox.Show("برنامه نوبت دهی برای افزودن فیلد اطلاعاتی اضافی به آن وجود ندارد!\n" +
                    "ابتدا برنامه نوبت دهی جدیدی تعریف نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            foreach (SP_SelectApplicationsResult SchApp in Applications)
            {
                CheckBoxItem MyItem = new CheckBoxItem(SchApp.Name);
                // خواندن وضعیت دسترسی فیلد در حالت ویرایش یك فیلد
                if (!_IsAdding)
                {
                    Boolean? IsCovered = DBLayerIMS.Schedules.GetSchAddinColumnsAppCover(_CurrentFieldID, SchApp.ID.Value);
                    if (IsCovered == null) return false;
                    MyItem.Checked = IsCovered.Value;
                }
                MyItem.Tag = SchApp.ID;
                MyItem.Text = SchApp.Name;
                lstApplication.Items.Add(MyItem);
            }
            return true;
        }
        #endregion

        #region Boolean FillCurrentColData()
        /// <summary>
        /// روالی برای خواندن اطلاعات ستون انتخاب شده
        /// </summary>
        private Boolean FillCurrentColData()
        {
            cboFieldType.Enabled = false;
            txtLenght.Enabled = false;
            DBLayerIMS.Schedules.SchAddinColumnsList = null;
            List<SchAddinColumns> SchData = DBLayerIMS.Schedules.SchAddinColumnsList;
            if (SchData == null) return false;
            _CurrentFieldData = SchData.Where(Data => Data.ID == _CurrentFieldID).First();
            cboFieldType.SelectedIndex = _CurrentFieldData.TypeID;
            if (_CurrentFieldData.TypeID == 0) txtLenght.Value = _CurrentFieldData.Lenght.Value;
            txtName.Text = _CurrentFieldData.Title;
            txtDescription.Text = _CurrentFieldData.Description;
            return true;
        }
        #endregion

        #region Boolean AddNewCol()
        /// <summary>
        /// تابع افزودن فیلد اطلاعاتی جدید
        /// </summary>
        private Boolean AddNewCol()
        {
            Byte? FieldLenght = null;
            if (cboFieldType.SelectedIndex == 0) FieldLenght = Convert.ToByte(txtLenght.Value);
            Int16? ReturnKey = InsertSchAddinColumn(txtName.Text, Convert.ToByte(cboFieldType.SelectedIndex), 
                FieldLenght, txtDescription.Text);
            if (ReturnKey == null) return false;
            foreach (CheckBoxItem item in lstApplication.Items)
                SetSchAddinColumnsAppCover(ReturnKey.Value, Convert.ToInt16(item.Tag), item.Checked);
            return true;
        }
        #endregion

        #region Int16? InsertSchAddinColumn(String FieldName, Byte TypeID, Byte? FieldLenght, String Description)
        /// <summary>
        /// تابعی برای ثبت یك فیلد اطلاعاتی روز تعطیل برای برنامه نوبت دهی در بانك اطلاعات
        /// </summary>
        /// <returns>صحت ثبت اطلاعات یا وقوع خطا</returns>
        public static Int16? InsertSchAddinColumn(String FieldName, Byte TypeID, Byte? FieldLenght, String Description)
        {
            Int16? ReturnKey = null;
            try
            {
                Manager.DBML.SP_InsertAdditionalColumns(ref ReturnKey, FieldName.Trim().Normalize(),
                    TypeID, FieldLenght, Description.Trim().Normalize());
                if (ReturnKey == null) throw new Exception("خطا در ثبت فیلد در ستون اصلی.\n" + "روال SP_InsertAdditionalColumns.");
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان ثبت فیلد پویا جدید برای برنامه های نوبت دهی در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return ReturnKey;
        }
        #endregion

        #region Boolean EditCurrentCol()
        /// <summary>
        /// تابع افزودن فیلد اطلاعاتی جدید
        /// </summary>
        private Boolean EditCurrentCol()
        {
            _CurrentFieldData.Title = txtName.Text.Trim();
            _CurrentFieldData.Description = txtDescription.Text.Trim();
            if (!Manager.Submit())
            {
                const String ErrorMessage =
                    "امكان به روز رسانی بانك بر اساس اطلاعات فیلد پویا نوبت دهی وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            foreach (CheckBoxItem item in lstApplication.Items)
                if (!SetSchAddinColumnsAppCover(_CurrentFieldID, Convert.ToInt16(item.Tag), item.Checked)) return false;
            return true;
        }
        #endregion

        #region Boolean SetSchAddinColumnsAppCover(Int16 ColID, Int16 AppID , Boolean IsCover)
        /// <summary>
        /// تابعی برای تغییر دسترسی یك برنامه نوبت دهی به یك فیلد پویا نوبت دهی
        /// </summary>
        /// <returns>دسترسی برنامه یا تهی برای وقوع خطا</returns>
        private static Boolean SetSchAddinColumnsAppCover(Int16 ColID, Int16 AppID, Boolean IsCover)
        {
            try { Manager.DBML.SP_SetAdditionalColumnsApp(ColID, AppID, IsCover); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ثبت دسترسی برنامه نوبت دهی جاری به ستون های پویا از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}