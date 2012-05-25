#region using
using System;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Schedules.Properties;
#endregion

namespace Sepehr.Settings.Schedules.Applications
{
    /// <summary>
    /// فرم ویرایش اطلاعات پایه یك برنامه نوبت دهی
    /// </summary>
    internal partial class frmAppsBaseEdit : Form
    {

        #region Fields

        #region readonly Int16 _CurrentAppID
        /// <summary>
        /// كلید برنامه جاری
        /// </summary>
        private readonly Int16 _CurrentAppID;
        #endregion

        #region SchApplications _CurrentAppDataSource
        /// <summary>
        /// منبع داده برنامه جاری
        /// </summary>
        private SchApplications _CurrentAppDataSource;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده فرم برای ویرایش یك برنامه نوبت دهی
        /// </summary>
        public frmAppsBaseEdit(Int16 AppID)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _CurrentAppID = AppID;
            if (!FillApplicationDataSource()) { Close(); return; }
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

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAppName.Text))
            {
                FormErrorProvider.SetError(txtAppName, "برای برنامه حتما نامی انتخاب نمایید!");
                return;
            }
            FormErrorProvider.SetError(txtAppName, String.Empty);
            if (EditCurrentApplication()) DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید بدون ذخیره سازی اطلاعات ، فرم بسته شود؟", "!هشدار",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
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

        #region Boolean FillApplicationDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات برنامه نوبت دهی از بانك
        /// </summary>
        private Boolean FillApplicationDataSource()
        {
            _CurrentAppDataSource = DBLayerIMS.Schedules.GetSchAppData(_CurrentAppID);
            if (_CurrentAppDataSource == null) return false;
            txtAppName.Text = _CurrentAppDataSource.Name;
            txtDescription.Text = _CurrentAppDataSource.Description;
            return true;
        }
        #endregion

        #region Boolean EditCurrentApplication()
        /// <summary>
        /// تابع ویرایش برنامه نوبت دهی 
        /// </summary>
        /// <returns>صحت ویرایش اطلاعات</returns>
        private Boolean EditCurrentApplication()
        {
            _CurrentAppDataSource.IsActive = cBoxIsActive.Checked;
            _CurrentAppDataSource.Name = txtAppName.Text.Trim().Normalize();
            _CurrentAppDataSource.Description= txtDescription.Text.Trim().Normalize();
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان به روز رسانی اطلاعات پایه برنامه ی نوبت دهی جاری در بانك وجود ندارد.\n" +
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