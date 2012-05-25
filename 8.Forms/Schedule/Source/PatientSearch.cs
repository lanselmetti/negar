#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Sepehr.DBLayerIMS;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Schedules.Properties;

#endregion

namespace Sepehr.Forms.Schedules
{
    /// <summary>
    /// فرم جستجوی بیمار نوبت داده شده
    /// </summary>
    internal partial class frmPatientSearch : Form
    {

        #region Ctors

        #region frmPatientSearch(Boolean IsPatSearch)
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        /// <param name="IsPatSearch">تعیین آنكه جستجوی بیمار نمایش داده شود یا مراجعه بیمار</param>
        public frmPatientSearch(Boolean IsPatSearch)
        {
            InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            dgvPatList.AutoGenerateColumns = false;
            dgvRefList.AutoGenerateColumns = false;
            ColumnRefDate.ShowTime = true;
            if (IsPatSearch)
            {
                dgvRefList.Visible = false;
                dgvPatList.Height = 309;
                dgvPatList.PreviewKeyDown += dgvData_PreviewKeyDown;
                dgvPatList.CellMouseDoubleClick += dgvData_CellMouseDoubleClick;
            }
            else
            {
                dgvPatList.SelectionChanged += dgvPatData_SelectionChanged;
                dgvRefList.PreviewKeyDown += dgvData_PreviewKeyDown;
                dgvRefList.CellMouseDoubleClick += dgvData_CellMouseDoubleClick;
            }
        }
        #endregion

        #region frmPatientSearch(Int32 PID)
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        /// <param name="PID">كلید بیماری كه مراجعات وی باید نمایش داده شود</param>
        public frmPatientSearch(Int32 PID)
        {
            InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            dgvPatList.AutoGenerateColumns = false;
            dgvRefList.AutoGenerateColumns = false;
            ColumnRefDate.ShowTime = true;
            lblPID.Visible = false;
            txtPID.Visible = false;
            lblFirstName.Visible = false;
            txtFirstName.Visible = false;
            lblLastName.Visible = false;
            txtLastName.Visible = false;
            btnSearch.Visible = false;
            dgvPatList.Visible = false;
            dgvRefList.Top = 10;
            dgvRefList.Height = 362;
            FillRefListDataGridView(PID);
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

        #region dgvPatData_SelectionChanged
        void dgvPatData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPatList.SelectedRows.Count == 0) return;
            FillRefListDataGridView(((PatientSearcher.PatientData)dgvPatList.SelectedRows[0].DataBoundItem).PatientListID);
        }
        #endregion

        #region Grids_KeyDown
        private void Grids_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                btnSelect_Click(null, null);
            }
        }
        #endregion

        #region txtClear_ButtonCustomClick
        private void txtClear_ButtonCustomClick(object sender, EventArgs e)
        {
            ((TextBoxX)sender).Text = String.Empty;
        }
        #endregion

        #region btnSearch_Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!String.IsNullOrEmpty(txtPID.Text.Trim()))
            {
                txtFirstName.Text = String.Empty;
                txtLastName.Text = String.Empty;
            }
            List<PatientSearcher.PatientData> Result;
            if (String.IsNullOrEmpty(txtPID.Text.Trim())) Result = PatientSearcher.GetPatDataListSimpleFilter(
                    txtFirstName.Text.Trim().Normalize(), txtLastName.Text.Trim().Normalize(), null);
            else Result = PatientSearcher.GetSamePatDataByPatID(txtPID.Text.Trim().Normalize());
            dgvPatList.DataSource = Result;
            if (dgvPatList.Rows.Count != 0) dgvPatList.Focus();
            Cursor = Cursors.Default;
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter && ((DataGridViewX)sender).SelectedRows.Count != 0)
                btnSelect_Click(sender, new EventArgs());
        }
        #endregion

        #region dgvData_CellMouseDoubleClick
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) btnSelect_Click(null, null);
        }
        #endregion

        #region btnSelect_Click
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvPatList.Visible && dgvPatList.Rows.Count > 0 && dgvPatList.SelectedRows.Count > 0) DialogResult = DialogResult.OK;
            else if (dgvRefList.Visible && dgvRefList.Rows.Count > 0 && dgvRefList.SelectedRows.Count > 0)
                DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

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

            #region btnSearch
            String TooltipText = ToolTipManager.GetText("btnSchPatSearch", "IMS");
            FormToolTip.SetSuperTooltip(btnSearch, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSelect
            TooltipText = ToolTipManager.GetText("btnSchPatSearchSelect", "IMS");
            FormToolTip.SetSuperTooltip(btnSelect, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnClose
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region void FillRefListDataGridView(Int32 PatientListID)
        /// <summary>
        /// تابع به روز رسانی اطلاعات مراجعات كاربر
        /// </summary>
        /// <param name="PatientListID">كلید بیمار</param>
        private void FillRefListDataGridView(Int32 PatientListID)
        {
            List<Int32> RefList = Referrals.GetPatRefIDListByPatID(PatientListID);
            List<RefList> RefCollection = new List<RefList>();
            foreach (Int32 RefID in RefList)
            {
                RefList RefData = Referrals.GetRefDataByID(RefID);
                if (RefData == null) return;
                RefCollection.Add(RefData);
            }
            dgvRefList.DataSource = RefCollection;
            Int32 Index = 1;
            foreach (DataGridViewRow row in dgvRefList.Rows)
            {
                row.Cells[ColRefRowNo.Index].Value = Index;
                if (((RefList)row.DataBoundItem).Ins1IX != null)
                    row.Cells[ColIns1Name.Index].Value = Insurance.InsFullList.
                        Where(Data => Data.ID == ((RefList)row.DataBoundItem).Ins1IX.Value).First().Name;
                if (((RefList)row.DataBoundItem).Ins2IX != null)
                    row.Cells[ColIns2Name.Index].Value = Insurance.InsFullList.
                        Where(Data => Data.ID == ((RefList)row.DataBoundItem).Ins2IX.Value).First().Name;
                Index++;
            }
        }
        #endregion

        #endregion

    }
}