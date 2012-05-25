#region using
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.BillTemplates.Properties;
#endregion

namespace Sepehr.Settings.BillTemplates
{
    /// <summary>
    /// فرم لیست فرمول های قابل استفاده برای فیلدهای پویا بیماران و مراجعات
    /// </summary>
    internal partial class frmAddinFieldsList : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAddinFieldsList()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            if (!FillFormDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region btnHelp_Click
        /// <summary>
        /// روال نمایش راهنمایی برای فرم
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // ToDo: نمایش راهنما تكمیل شود
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
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

            #region btnHelp
            String TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillFormDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات فیلد های پویا از بانك
        /// </summary>
        private Boolean FillFormDataSource()
        {
            List<PatAdditionalColumn> PatAddinCols = DBLayerIMS.Referrals.PatAddinColsList;
            List<RefAdditionalColumn> RefAddinCols = DBLayerIMS.Referrals.RefAddinColsList;
            if (PatAddinCols == null || RefAddinCols == null) return false;
            foreach (PatAdditionalColumn result in PatAddinCols)
            {
                String[] DataCollection = new String[3];
                DataCollection[0] = result.Title;
                DataCollection[1] = result.Description;
                DataCollection[2] = "[Pat" + result.FieldName + "]";
                dgvData.Rows.Add(DataCollection);
            }
            foreach (RefAdditionalColumn result in RefAddinCols)
            {
                String[] DataCollection = new String[3];
                DataCollection[0] = result.Title;
                DataCollection[1] = result.Description;
                DataCollection[2] = "[Ref" + result.FieldName + "]";
                dgvData.Rows.Add(DataCollection);
            }
            return true;
        }
        #endregion

        #endregion

    }
}