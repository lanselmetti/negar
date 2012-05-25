#region using
using System;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Insurances.Properties;
#endregion

namespace Sepehr.Settings.Insurances.Insurances
{
    /// <summary>
    /// فرم مدیریت فرمول های بیمه دوم
    /// </summary>
    internal partial class frmFormulas : Form
    {

        #region Fields

        #region IOrderedQueryable<Ins2Formula> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private IOrderedQueryable<Ins2Formula> _DataSource;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmFormulas()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillDataSource()) { Close(); return; }
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
                dgvData_CellMouseClick(1, new DataGridViewCellMouseEventArgs
                    (0, dgvData.SelectedCells[0].RowIndex, Left + Width - 150,
                    Top + dgvData.Top + dgvData.ColumnHeadersHeight + 27 +
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DialogResult Dr = new frmFormulasManage((
                (Ins2Formula)dgvData.SelectedRows[0].DataBoundItem).ID).DialogResult;
            if (Dr == DialogResult.OK) ChangeDataSource();
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult Dr = new frmFormulasManage().DialogResult;
            if (Dr == DialogResult.OK) { FillDataSource(); ChangeDataSource(); }
        }
        #endregion

        #region btnEdit_Click
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                DialogResult Dr = new frmFormulasManage((
                    (Ins2Formula)dgvData.SelectedRows[0].DataBoundItem).ID).DialogResult;
                if (Dr == DialogResult.OK) { FillDataSource(); ChangeDataSource(); }
            }
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0 || dgvData.SelectedRows[0].IsNewRow) return;
            DialogResult Dr = PMBox.Show("آیا مایلید فرمول زیر حذف گردد:\n\"" +
                dgvData.SelectedCells[1].Value + "\"", "هشدار", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            DBLayerIMS.Manager.DBML.Ins2Formulas.
                DeleteOnSubmit((Ins2Formula)dgvData.SelectedRows[0].DataBoundItem);
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان حذف فرمول بیمه دوم انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!FillDataSource()) { Close(); return; }
            ChangeDataSource();
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

            #region cBoxWithInActives
            String TooltipText = ToolTipManager.GetText("cBoxWithInActivesIns2Formula", "IMS");
            FormToolTip.SetSuperTooltip(cBoxWithInActives,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAdd
            TooltipText = ToolTipManager.GetText("btnAddInsFormula", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات خواندن اطلاعات فرمول های بیمه دوم
        /// </summary>
        private Boolean FillDataSource()
        {
            try
            {
                if (_DataSource == null)
                    _DataSource = DBLayerIMS.Manager.DBML.Ins2Formulas.OrderBy(Ins2Formula => Ins2Formula.Name);
                else DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _DataSource);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات فرمول های بیمه دوم از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Insurances Settings", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region void ChangeDataSource()
        /// <summary>
        /// تابع تغییر منبع داده بر اساس فیلتر فرم
        /// </summary>
        private void ChangeDataSource()
        {
            if (cBoxWithInActives.Checked) dgvData.DataSource = _DataSource.ToList();
            else dgvData.DataSource = _DataSource.Where(Data => Data.IsActive).ToList();
        }
        #endregion

        #endregion

    }
}