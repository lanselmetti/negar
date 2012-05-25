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
    /// فرم مدیریت اطلاعات اضافی حساب مراجعات بیمار
    /// </summary>
    public partial class frmManageTransDesc : Form
    {

        #region Fields

        #region Boolean _IsFormControlsChanged
        /// <summary>
        /// تعیین ویرایش شدن  اطلاعات اضافی حساب  جاری توسط كاربر از حالت اولیه
        /// </summary>
        private Boolean _IsFormControlsChanged;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmManageTransDesc()
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            if (!FillcboBankName()) { Close(); return; }
            CheckDate.SelectedDateTime = DateTime.Now;
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            _IsFormControlsChanged = false;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (_IsFormControlsChanged)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید بدون ذخیره سازی فرم را ببندید؟",
                    "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            Cursor.Current = Cursors.Default;
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

            #region cboBankName
            TooltipText = ToolTipManager.GetText("cboBankName", "IMS");
            FormToolTip.SetSuperTooltip(cboBankName, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillcboBankName()
        ///<summary>
        /// تابع خواندن اطلاعات بانك ها
        ///</summary>
        ///<returns>صحت خواندن اطلاعات</returns>
        private Boolean FillcboBankName()
        {
            List<SP_SelectBanksResult> DataSource = DBLayerIMS.Account.BanksFullList;
            if (DataSource == null) return false;
            cboBankName.DataSource = DataSource.Where(Data => Data.IsActive == true).ToList();
            return true;
        }
        #endregion

        #endregion

    }
}