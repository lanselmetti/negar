#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Referrals.Properties;
#endregion

namespace Sepehr.Settings.Referrals
{
    /// <summary>
    /// فرم تعریف فیلد اطلاعات اضافی مراجعات
    /// </summary>
    internal partial class frmAdditionalColsAdd : Form
    {

        #region Fields

        #region readonly Boolean _IsAdding
        /// <summary>
        /// تعیین وضعیت فرم در دو حالت افزودن و ویرایش
        /// </summary>
        private readonly Boolean _IsAdding;
        #endregion

        #region readonly Int16 _CurrentFieldID;
        /// <summary>
        /// كلید فیلد جاری
        /// </summary>
        private readonly Int16 _CurrentFieldID;
        #endregion

        #region RefAdditionalColumn _CurrentFieldData
        /// <summary>
        /// فیلد اطلاعات ستون پویا جاری برای ویرایش
        /// </summary>
        private RefAdditionalColumn _CurrentFieldData;
        #endregion

        #endregion

        #region Ctors

        #region frmAdditionalColsAdd()
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAdditionalColsAdd()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _IsAdding = true;
            cboFieldType.SelectedIndex = 0;
            ShowDialog();
        }
        #endregion

        #region frmAdditionalColsAdd(Int16 ColID)
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAdditionalColsAdd(Int16 ColID)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _IsAdding = false;
            _CurrentFieldID = ColID;
            if (!FillCurrentColData()) { Close(); return; }
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

        #region Boolean FillCurrentColData()
        /// <summary>
        /// روالی برای خواندن اطلاعات ستون انتخاب شده
        /// </summary>
        private Boolean FillCurrentColData()
        {
            cboFieldType.Enabled = false;
            txtLenght.Enabled = false;
            DBLayerIMS.Referrals.RefAddinColsList = null;
            List<RefAdditionalColumn> FieldData = DBLayerIMS.Referrals.RefAddinColsList;
            if (FieldData == null) return false;
            _CurrentFieldData = FieldData.Where(Data => Data.ID == _CurrentFieldID).First();
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
            return InsertAddinColumn(txtName.Text, Convert.ToByte(cboFieldType.SelectedIndex),
                FieldLenght, txtDescription.Text.Normalize().Trim());
        }
        #endregion

        #region Boolean InsertAddinColumn(String FieldName, Byte TypeID, Byte? FieldLenght, String Description)
        /// <summary>
        /// تابعی برای ثبت یك فیلد اطلاعاتی روز تعطیل برای برنامه نوبت دهی در بانك اطلاعات
        /// </summary>
        /// <returns>صحت ثبت اطلاعات یا وقوع خطا</returns>
        public static Boolean InsertAddinColumn(String FieldName, Byte TypeID, Byte? FieldLenght, String Description)
        {
            try
            {
                DBLayerIMS.Manager.DBML.SP_InsertRefAdditionalColumns(FieldName.Trim().Normalize(),
                    TypeID, FieldLenght, Description.Trim().Normalize());
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ثبت فیلد پویا جدید در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Settings - Referrals", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
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
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان به روز رسانی بانك بر اساس اطلاعات فیلد وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #endregion

    }
}