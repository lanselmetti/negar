#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.PACSIntegration.Properties;
#endregion

namespace Sepehr.Settings.PACSIntegration
{
    /// <summary>
    /// فرم افزودن خدمت به یك گروه
    /// </summary>
    internal partial class frmServicesSelection : Form
    {

        #region Fields & Properties

        #region List<SP_SelectServicesListResult> _ServicesDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<SP_SelectServicesListResult> _ServicesDataSource;
        #endregion

        #region ArrayList _SelectedServicesID
        /// <summary>
        /// لیست كد سرویس های انتخاب شده
        /// </summary>
        private ArrayList _SelectedServicesID;
        #endregion

        #region Boolean _IsGridValuesChanged
        /// <summary>
        /// تعیین ویرایش شدن فرم توسط كاربر
        /// </summary>
        private Boolean _IsGridValuesChanged;
        #endregion

        #region public ArrayList SelectedServicesID
        /// <summary>
        /// لیست كد سرویس های انتخاب شده
        /// </summary>
        public ArrayList SelectedServicesID
        {
            get { return _SelectedServicesID; }
        }
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmServicesSelection()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillServicesDataSource() || !FillCategoriesDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            _IsGridValuesChanged = false;
            cBoxWithInActives.Checked = false;
            SetControlsToolTipTexts();
        }
        #endregion

        #region cboCategory_SelectedIndexChanged
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDataSource();
        }
        #endregion

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Left)
            {
                if ((dgvData[0, e.RowIndex].Value == null || (Boolean)dgvData[0, e.RowIndex].Value == false))
                    dgvData[0, e.RowIndex].Value = true;
                else dgvData[0, e.RowIndex].Value = false;
                _IsGridValuesChanged = true;
            }
        }
        #endregion

        #region cBoxWithInActives_CheckedChanged
        private void cBoxWithInActives_CheckedChanged(object sender, EventArgs e)
        {
            ChangeDataSource();
        }
        #endregion

        #region btnAllAndNone_Click
        private void btnAllAndNone_Click(object sender, EventArgs e)
        {
            if (((ButtonX)sender).Name == "btnAll")
                foreach (DataGridViewRow row in dgvData.Rows) row.Cells["ColSelection"].Value = true;
            else foreach (DataGridViewRow row in dgvData.Rows) row.Cells["ColSelection"].Value = false;
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnAccept.Focus();
            dgvData.EndEdit();
            _SelectedServicesID = new ArrayList();
            for (Int32 i = 0; i < dgvData.Rows.Count; i++)
                if (dgvData.Rows[i].Cells[0].Value != null &&
                    Convert.ToBoolean(dgvData.Rows[i].Cells[ColSelection.Index].Value))
                    SelectedServicesID.Add(((SP_SelectServicesListResult)dgvData.Rows[i].DataBoundItem).ID);
            _IsGridValuesChanged = false;
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
            dgvData.EndEdit();
            if (_IsGridValuesChanged)
            {
                DialogResult Dr = PMBox.Show("آیا منصرف شدید؟", "هشدار", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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

            #region cBoxWithInActives
            String TooltipText = ToolTipManager.GetText("cBoxWithInActivesServices", "IMS");
            FormToolTip.SetSuperTooltip(cBoxWithInActives, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region cboCategory
            TooltipText = ToolTipManager.GetText("cboServiceCategory", "IMS");
            FormToolTip.SetSuperTooltip(cboCategory, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAll
            TooltipText = ToolTipManager.GetText("btnAll", "IMS");
            FormToolTip.SetSuperTooltip(btnAll, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnNone
            TooltipText = ToolTipManager.GetText("btnNone", "IMS");
            FormToolTip.SetSuperTooltip(btnNone, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillCategoriesDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول  طبقه بندی خدمات  از بانك
        /// </summary>
        private Boolean FillCategoriesDataSource()
        {
            DBLayerIMS.Services.ServCategoriesList = null;
            List<SP_SelectCategoriesResult> Categories = DBLayerIMS.Services.ServCategoriesList;
            if (Categories == null) return false;
            cboCategory.DataSource = Categories;
            return true;
        }
        #endregion

        #region Boolean FillServicesDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات خدمات جدول از بانك
        /// </summary>
        private Boolean FillServicesDataSource()
        {
            _ServicesDataSource = DBLayerIMS.Services.ServicesList;
            if (_ServicesDataSource == null) return false;
            return true;
        }
        #endregion

        #region void ChangeDataSource()
        /// <summary>
        /// تابع تغییر نوع ساختار منبع داده بر اساس فیلتر های انتخاب شده
        /// </summary>
        private void ChangeDataSource()
        {
            #region Show All Services
            if (cBoxWithInActives.Checked)
            {
                if (cboCategory.SelectedValue == null) dgvData.DataSource =
                    _ServicesDataSource.OrderBy(List => Convert.ToInt32(List.Code)).ToList();
                else dgvData.DataSource = _ServicesDataSource.
                    Where(Data => Data.CategoryIX == Convert.ToInt16(cboCategory.SelectedValue)).
                    OrderBy(List => Convert.ToInt32(List.Code)).ToList();
            }
            #endregion
            #region Show Active Services
            else
            {
                if (cboCategory.SelectedValue == null)
                    dgvData.DataSource = _ServicesDataSource.Where(FilteredData => FilteredData.IsActive).
                        OrderBy(List => Convert.ToInt32(List.Code)).ToList();
                else dgvData.DataSource = _ServicesDataSource.
                    Where(Data => Data.CategoryIX == Convert.ToInt16(cboCategory.SelectedValue) && Data.IsActive).
                    OrderBy(List => Convert.ToInt32(List.Code)).ToList();
            }
            #endregion
        }
        #endregion

        #endregion

    }
}