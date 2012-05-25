#region using
using System;
using System.Data.Linq;
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
    /// فرم مدیریت پزشكان و كارشناسان خدمات مراجعه
    /// </summary>
    public partial class frmPerformers : Form
    {

        #region Fields

        #region Table<Performer> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private Table<Performer> _DataSource;
        #endregion

        #region Boolean _IsGridValuesChanged
        /// <summary>
        /// تعیین ویرایش شدن فرم توسط كاربر
        /// </summary>
        private Boolean _IsGridValuesChanged;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmPerformers()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillDataSource()) { Close(); return; }
            SetControlsToolTipTexts();
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            _IsGridValuesChanged = false;
            cBoxWithInActives.Checked = false;
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvData.SelectedCells.Count != 0)
            {
                dgvData_CellMouseClick(1,
                    new DataGridViewCellMouseEventArgs
                        (0, dgvData.SelectedCells[0].RowIndex, Left + Width - 150,
                        dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top
                        + dgvData.ColumnHeadersHeight + 30 + Top,
                        new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
            }
        }
        #endregion

        #region dgvData_CellBeginEdit
        /// <summary>
        /// روال مدیریت آغاز تغییر در یك سلول جدول
        /// </summary>
        private void dgvData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            btnDelete.Shortcuts.Clear();
        }
        #endregion

        #region dgvData_CellEndEdit
        /// <summary>
        /// روال مدیریت اتمام تغییر در یك سلول جدول
        /// </summary>
        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Shortcuts.Add(eShortcut.Del);
        }
        #endregion

        #region dgvData_CellValueChanged
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _IsGridValuesChanged = true;
        }
        #endregion

        #region dgvData_DefaultValuesNeeded
        void dgvData_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = true;
            e.Row.Cells[2].Value = "نام خانوادگی";
            e.Row.Cells[3].Value = true;
            e.Row.Cells[4].Value = true;
            e.Row.Cells[5].Value = true;
        }
        #endregion

        #region dgvData_UserAddedRow
        private void dgvData_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvData.AllowUserToAddRows = false;
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

        #region cBoxWithInActives_CheckedChanged
        private void cBoxWithInActives_CheckedChanged(object sender, EventArgs e)
        {
            if (_IsGridValuesChanged)
            {
                DialogResult Dr = PMBox.Show(
                    "در صورتی كه ردیفی را حذف كرده باشید باید قبل از تغییر وضعیت نمایش فرم ، " +
                    "اطلاعات را در بانك اعمال نمایید. آیا مایلید بدون اعمال تغییرات ، " +
                    "در بانك ، نمای فرم تغییر كند؟", "هشدار!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) return;
            }
            if (cBoxWithInActives.Checked) dgvData.DataSource = _DataSource;
            else dgvData.DataSource = _DataSource.Where(FilteredData => FilteredData.IsActive);
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvData.AllowUserToAddRows = true;
            dgvData.Rows[dgvData.Rows.Count - 1].Cells[1].Selected = true;
            dgvData.Focus();
            dgvData.BeginEdit(true);
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((dgvData.SelectedRows.Count == 0 || dgvData.SelectedRows[0].IsNewRow) &&
                (dgvData.SelectedCells.Count == 0 || dgvData.Rows[dgvData.SelectedCells[0].RowIndex].IsNewRow)) return;
            Int32 RowIndex;
            if (dgvData.SelectedRows.Count == 0) RowIndex = dgvData.SelectedCells[0].RowIndex;
            else RowIndex = dgvData.SelectedRows[0].Index;
            String FullName = dgvData.Rows[RowIndex].Cells[1].Value + " " + dgvData.Rows[RowIndex].Cells[2].Value;
            if (dgvData.Rows[RowIndex].Cells[1].Value == null)
                FullName = dgvData.Rows[RowIndex].Cells[2].Value.ToString();
            DialogResult Dr = PMBox.Show("آیا مایلید ردیف زیر حذف گردد:\n\"" + FullName +
                "\"\nبا حذف این انجام دهنده ، اطلاعات پزشك یا كارشناسان كلیه خدماتی كه این شخص برای آنها ثبت شده حذف خواهد شد.",
                "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.Yes)
                try
                {
                    dgvData.Rows.Remove(dgvData.Rows[RowIndex]);
                    _IsGridValuesChanged = true;
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان حذف انجام دهنده از بانك وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Referrals Setting", Ex.Message + "\n" + Ex.StackTrace,
                        EventLogEntryType.Error);
                }
                #endregion
        }
        #endregion

        #region btnApply_Click
        private void btnApply_Click(object sender, EventArgs e)
        {
            btnAccept.Focus();
            dgvData.EndEdit();
            if (!ValidateForData()) return;
            foreach (Performer DeletedPerformer in DBLayerIMS.Manager.DBML.GetChangeSet().Deletes)
            {
                IQueryable<RefService> TempServices =
                    DBLayerIMS.Manager.DBML.RefServices.Where(Data => Data.ExpertIX == DeletedPerformer.ID);
                foreach (RefService service in TempServices) service.ExpertIX = null;
                TempServices = DBLayerIMS.Manager.DBML.RefServices.Where(Data => Data.PhysicianIX == DeletedPerformer.ID);
                foreach (RefService service in TempServices) service.PhysicianIX = null;
            }
            try
            {
                DBLayerIMS.Manager.DBML.RefServices.Context.SubmitChanges();
                if (!DBLayerIMS.Manager.Submit()) throw new Exception("خطا در ثبت تغییرات در فرم مدیریت كادر پزشكی");
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان به روز رسانی بانك بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا نام تكراری وارد ننموده اید؟\n" +
                    "2. آیا ردیف جدیدی فاقد نام وارد ننموده اید؟\n" +
                    "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Referrals Setting", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error); return;
            }
            #endregion
            _IsGridValuesChanged = false;
            if (!FillDataSource()) { Close(); return; }
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnAccept.Focus();
            dgvData.EndEdit();
            if (!ValidateForData()) return;
            foreach (Performer DeletedPerformer in DBLayerIMS.Manager.DBML.GetChangeSet().Deletes)
            {
                IQueryable<RefService> TempServices =
                    DBLayerIMS.Manager.DBML.RefServices.Where(Data => Data.ExpertIX == DeletedPerformer.ID);
                foreach (RefService service in TempServices) service.ExpertIX = null;
                TempServices = DBLayerIMS.Manager.DBML.RefServices.Where(Data => Data.PhysicianIX == DeletedPerformer.ID);
                foreach (RefService service in TempServices) service.PhysicianIX = null;
            }
            try
            {
                DBLayerIMS.Manager.DBML.RefServices.Context.SubmitChanges();
                if (!DBLayerIMS.Manager.Submit()) throw new Exception("خطا در ثبت تغییرات در فرم مدیریت كادر پزشكی");
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان به روز رسانی بانك بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا نام تكراری وارد ننموده اید؟\n" +
                    "2. آیا ردیف جدیدی فاقد نام وارد ننموده اید؟\n" +
                    "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Referrals Setting", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error); return;
            }
            #endregion
            _IsGridValuesChanged = false;
            DialogResult = DialogResult.OK;
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
                DialogResult Dr = PMBox.Show("آیا منصرف از اعمال تغییرات منصرف شده اید؟", "پرسش؟", MessageBoxButtons.YesNo,
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

            #region btnHelp
            string TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnCancel", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region cBoxWithInActives
            TooltipText = ToolTipManager.GetText("cBoxWithInActivesRefPerformers", "IMS");
            FormToolTip.SetSuperTooltip(cBoxWithInActives,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnDelete
            TooltipText = ToolTipManager.GetText("btnDelete", "IMS");
            FormToolTip.SetSuperTooltip(btnDelete,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnApply
            TooltipText = ToolTipManager.GetText("btnApply", "IMS");
            FormToolTip.SetSuperTooltip(btnApply,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAdd
            TooltipText = ToolTipManager.GetText("btnAddRefPerformers", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات  انجام دهندگان جدول از بانك
        /// </summary>
        private Boolean FillDataSource()
        {
            try { _DataSource = DBLayerIMS.Manager.DBML.Performers; }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات انجام دهندگان از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Referrals Setting", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean ValidateForData()
        /// <summary>
        /// بررسی اطلاعات وارد شده در فرم
        /// </summary>
        /// <returns>صحت ورود اطلاعات</returns>
        private Boolean ValidateForData()
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.IsNewRow) continue;
                if ((row.Cells[ColIsExpert.Index].Value == null || row.Cells[ColIsExpert.Index].Value == DBNull.Value ||
                    !Convert.ToBoolean(row.Cells[ColIsExpert.Index].Value)) &&
                    (row.Cells[ColIsPhysician.Index].Value == null || row.Cells[ColIsPhysician.Index].Value == DBNull.Value ||
                    !Convert.ToBoolean(row.Cells[ColIsPhysician.Index].Value)))
                {
                    String GenderTitle = String.Empty;
                    if (row.Cells[ColIsMale.Index].Value != null)
                    {
                        if (Convert.ToBoolean(row.Cells[ColIsMale.Index].Value)) GenderTitle = "آقای \"";
                        else GenderTitle = "خانم \"";
                    }
                    PMBox.Show("پزشك یا كارشناس بودن برای " + GenderTitle + row.Cells[ColFirstName.Index].Value +
                        row.Cells[ColLastName.Index].Value + "\" انتخاب نشده است! ", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        #endregion

        #endregion

    }
}