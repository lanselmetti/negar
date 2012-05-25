#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Insurances.Insurances;
using Sepehr.Settings.Insurances.InsurancesServices;
using Sepehr.Settings.Insurances.Properties;
#endregion

namespace Sepehr.Settings.Insurances
{
    /// <summary>
    /// فرم مدیریت بیمه ها
    /// </summary>
    public partial class frmInsurances : Form
    {

        #region Fields

        #region List<SP_SelectInsFullDataResult> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<SP_SelectInsFullDataResult> _DataSource;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmInsurances()
        {
            InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillDataSource() || !FillIns2FormulaCboDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            cBoxWithInActives.Checked = false;
        }
        #endregion

        #region cBoxWithInActives_CheckedChanged
        private void cBoxWithInActives_CheckedChanged(object sender, EventArgs e)
        {
            ChangeDataSource();
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvData.SelectedRows.Count != 0)
            {
                dgvData_CellMouseClick(1,
                    new DataGridViewCellMouseEventArgs
                        (0, dgvData.SelectedCells[0].RowIndex, Left + Width - 150,
                        Top + dgvData.Top + dgvData.ColumnHeadersHeight + 17 +
                        dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top,
                        new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
            }
        }
        #endregion

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            System.Drawing.Point Position = MousePosition;
            // اگر درخواست كننده تابع جاری كلید ویندوز باشد و نه كلیك راست موس محل نمایش نموی كلیك راست تغییر می كند
            if (sender is Int32 && e.RowIndex >= 0 && e.ColumnIndex >= 0) Position = e.Location;
            else if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            // ردیف مورد نظر انتخاب می شود
            dgvData.Rows[e.RowIndex].Selected = true;
            // منوی كلیك راست نمایش داده می شود
            cmsMenu.Popup(Position);
        }
        #endregion

        #region dgvData_CellMouseDoubleClick
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DialogResult Dr = new frmInsManage(Convert.ToInt16(((SP_SelectInsFullDataResult)
                    dgvData.SelectedRows[0].DataBoundItem).ID)).DialogResult;
            if (Dr == DialogResult.OK)
            {
                if (!FillDataSource()) { Close(); return; }
                ChangeDataSource();
            }
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult Dr = new frmInsManage().DialogResult;
            if (Dr == DialogResult.OK)
            {
                if (!FillDataSource()) { Close(); return; }
                ChangeDataSource();
            }
            BringToFront();
            Focus();
        }
        #endregion

        #region btnEdit_Click
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult Dr = new frmInsManage(Convert.ToInt16(((SP_SelectInsFullDataResult)
                dgvData.SelectedRows[0].DataBoundItem).ID)).DialogResult;
            if (Dr == DialogResult.OK)
            {
                if (!FillDataSource()) { Close(); return; }
                ChangeDataSource();
            }
            BringToFront();
            Focus();
        }
        #endregion

        #region btnIns2Formulas_Click
        private void btnIns2Formulas_Click(object sender, EventArgs e)
        {
            new frmFormulas();
            if (!FillIns2FormulaCboDataSource()) { Close(); return; }
            ChangeDataSource();
            BringToFront();
            Focus();
        }
        #endregion

        #region btnInsuranceServices_Click
        private void btnInsuranceServices_Click(object sender, EventArgs e)
        {
            new frmServicesCoverage(((SP_SelectInsFullDataResult)dgvData.SelectedRows[0].DataBoundItem).ID.Value);
            BringToFront();
            Focus();
        }
        #endregion

        #region btnExcludeSpecs_Click
        private void btnExcludeSpecs_Click(object sender, EventArgs e)
        {
            new frmExcludedRefPhysSpecs(((SP_SelectInsFullDataResult)dgvData.SelectedRows[0].DataBoundItem).ID.Value);
            BringToFront();
            Focus();
        }
        #endregion

        #region btnExcludeRefPhys_Click
        private void btnExcludeRefPhys_Click(object sender, EventArgs e)
        {
            new frmExcludedRefPhys(((SP_SelectInsFullDataResult)dgvData.SelectedRows[0].DataBoundItem).ID.Value);
            BringToFront();
            Focus();
        }
        #endregion

        #region btnCopyInsuranceSettings_Click
        private void btnCopyInsuranceSettings_Click(object sender, EventArgs e)
        {
            new frmCopySettings();
            BringToFront();
            Focus();
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
            GC.Collect();
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

            #region cBoxWithInActives
            String TooltipText = ToolTipManager.GetText("cBoxWithInActivesInsurances", "IMS");
            FormToolTip.SetSuperTooltip(cBoxWithInActives,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader,
                TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAdd
            TooltipText = ToolTipManager.GetText("btnAddInsurances", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter,
                TooltipText, Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnEdit
            TooltipText = ToolTipManager.GetText("btnEditIns", "IMS");
            FormToolTip.SetSuperTooltip(btnEdit, new SuperTooltipInfo(TooltipHeader, TooltipFooter,
                TooltipText, Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnIns2Formulas
            TooltipText = ToolTipManager.GetText("btnManageIns2Formulas", "IMS");
            FormToolTip.SetSuperTooltip(btnIns2Formulas, new SuperTooltipInfo(TooltipHeader,
                TooltipFooter, TooltipText, Resources.Help,
                Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCopyInsuranceSettings
            TooltipText = ToolTipManager.GetText("btnCopyInsuranceSettings", "IMS");
            FormToolTip.SetSuperTooltip(btnCopyInsuranceSettings,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        private Boolean FillDataSource()
        {
            DBLayerIMS.Insurance.InsFullList = null;
            _DataSource = DBLayerIMS.Insurance.InsFullList;
            if (_DataSource == null) return false;
            _DataSource = _DataSource.Where(Data => Data.ID != null && Data.BaseIsActive == true).ToList();
            return true;
        }
        #endregion

        #region Boolean FillIns2FormulaCboDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات فرمول های بیمه دوم
        /// </summary>
        private Boolean FillIns2FormulaCboDataSource()
        {
            DBLayerIMS.Insurance.Ins2FormulaList = null;
            ColFormula.DataSource = DBLayerIMS.Insurance.Ins2FormulaList;
            if (ColFormula.DataSource == null) return false;
            ColFormula.DataPropertyName = "Ins2FormulasIX";
            ColFormula.DisplayMember = "Name";
            ColFormula.ValueMember = "ID";
            return true;
        }
        #endregion

        #region void ChangeDataSource()
        /// <summary>
        /// تابع تغییر پارامترهای فیلتر منبع داده
        /// </summary>
        private void ChangeDataSource()
        {
            if (cBoxWithInActives.Checked) dgvData.DataSource = _DataSource.ToList();
            else dgvData.DataSource = _DataSource.Where(Data => Data.IsActive == true).ToList();
        }
        #endregion

        #endregion

    }
}