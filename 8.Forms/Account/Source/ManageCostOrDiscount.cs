#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Account.Properties;

#endregion

namespace Sepehr.Forms.Account
{
    /// <summary>
    /// فرم مدیریت تخفیف ها و هزینه های حساب مراجعه بیمار
    /// </summary>
    internal partial class frmManageCostOrDiscount : Form
    {

        #region Fields & Properties

        #region Boolean _IsCurrentFormModified
        /// <summary>
        /// تعیین ویرایش شدن تراكنش حساب  جاری توسط كاربر از حالت اولیه
        /// </summary>
        private Boolean _IsCurrentFormModified;
        #endregion

        #region readonly Boolean _IsAdding
        /// <summary>
        /// تعیین وضعیت ویرایش یا نمایش فرم
        /// </summary>
        private readonly Boolean _IsAdding;
        #endregion

        #region public Boolean IsCurrentFormModified
        /// <summary>
        /// تعیین ویرایش شده بودن فرم
        /// </summary>
        public Boolean IsCurrentFormModified
        {
            get { return _IsCurrentFormModified; }
        }
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم برای اضافه كردن یك تخفیف یا هزینه
        /// </summary>
        public frmManageCostOrDiscount(Boolean IsCost, Boolean IsAdding)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _IsAdding = IsAdding;
            ReadUserPermissions();
            if (!FillcboTypes(IsCost)) { Cursor.Current = Cursors.Default; Close(); return; }
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            if (_IsAdding)
            {
                RegDate.SelectedDateTime = DateTime.Now;
                RegTime.Value = DateTime.Now;
            }
            _IsCurrentFormModified = false;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtValue.Value == 0)
            {
                PMBox.Show("امكان ثبت مبلغ صفر وجود ندارد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtValue.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
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

        #region void ReadUserPermissions()
        /// <summary>
        /// تابع بررسی سطوح دسترسی فرم
        /// </summary>
        private void ReadUserPermissions()
        {
            // امكان ویرایش زمان تخفیف یا هزینه
            if (SecurityManager.GetCurrentUserPermission(50537) == false)
            {
                RegDate.IsReadonly = true;
                RegTime.IsInputReadOnly = true;
                RegTime.ShowUpDown = false;
            }
            if (!_IsAdding)
            {
                // امكان ویرایش مبلغ تخفیف یا هزینه
                if (SecurityManager.GetCurrentUserPermission(50538) == false)
                {
                    txtValue.IsInputReadOnly = true;
                    txtValue.ShowUpDown = false;
                }
                // امكان ویرایش نوع تخفیف یا هزینه
                if (SecurityManager.GetCurrentUserPermission(50539) == false) cboType.Enabled = false;
            }
        }
        #endregion

        #region Boolean FillcboTypes(Boolean IsCost)
        /// <summary>
        /// تابع خواندن اطلاعات انواع تخفیف ها
        /// </summary>
        /// <param name="IsCost">تعیین تخفیف یا هزینه بودن كار</param>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean FillcboTypes(Boolean IsCost)
        {
            List<CostsAndDiscountsType> CDData = DBLayerIMS.Account.CostAndDiscountFullList;
            if (CDData == null) return false;
            CDData = CDData.Where(Data => Data.IsCost == IsCost && Data.IsActive).ToList();
            IQueryable<Int16> ExcludedCD = DBLayerIMS.Account.GetUserExcludedCD(SecurityManager.CurrentUserID);
            if (ExcludedCD == null) return false;
            for (Int32 i = CDData.Count - 1; i >= 0; i--) if (ExcludedCD.Contains(CDData[i].ID)) CDData.Remove(CDData[i]);
            if (CDData.Count == 0)
            {
                PMBox.Show("نوعی برای تخفیف یا هزینه وجود ندارد! برای اعمال تخفیف یا هزینه ابتدا یك نوع تعریف نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            cboType.DataSource = CDData;
            return true;
        }
        #endregion

        #endregion

    }
}