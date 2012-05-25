#region using
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Documents.Properties;
#endregion

namespace Sepehr.Settings.Documents
{
    /// <summary>
    /// فرم نمایش فرمول های قابل استفاده در مدارك برای فیلد های اطلاعاتی پویا بیماران و مراجعات
    /// </summary>
    internal partial class frmAddinFieldsList : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAddinFieldsList()
        {
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
        }
        #endregion

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == ColFormula.Index) dgvData.BeginEdit(true);
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
                DataCollection[2] = "NegarPat" + result.FieldName;
                dgvData.Rows.Add(DataCollection);
            }
            foreach (RefAdditionalColumn result in RefAddinCols)
            {
                String[] DataCollection = new String[3];
                DataCollection[0] = result.Title;
                DataCollection[1] = result.Description;
                DataCollection[2] = "NegarRef" + result.FieldName;
                dgvData.Rows.Add(DataCollection);
            }
            return true;
        }
        #endregion

        #endregion

    }
}