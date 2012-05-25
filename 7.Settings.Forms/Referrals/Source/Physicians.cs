#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using DevComponents.DotNetBar;
using Sepehr.Settings.Referrals.Properties;
using Application = System.Windows.Forms.Application;
#endregion

namespace Sepehr.Settings.Referrals
{
    /// <summary>
    /// فرم مدیریت پزشكان مراجعه
    /// </summary>
    public partial class frmPhysicians : Form
    {

        #region Fields

        #region IQueryable<RefPhysician> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private IQueryable<RefPhysician> _DataSource;
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
        public frmPhysicians()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (!FillDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region From_Shown
        private void From_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            _IsGridValuesChanged = false;
            cBoxWithInActives.Checked = false;
            System.Windows.Forms.Cursor.Current = Cursors.Default;
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

        #region dgvData_CellValidating
        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            #region Check Medical ID
            if (e.ColumnIndex == ColMedicalID.Index)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (!row.IsNewRow && row.Cells[e.ColumnIndex].Value != null &&
                        row.Cells[e.ColumnIndex].Value != DBNull.Value &&
                        row.Index != e.RowIndex &&
                        e.FormattedValue != null && e.FormattedValue != DBNull.Value &&
                        row.Cells[e.ColumnIndex].Value.ToString().Trim().ToLower() == e.FormattedValue.ToString().ToLower())
                    {
                        PMBox.Show("نظام پزشكی وارد شده تكراریست! لطفاً مقدار وارد شده را بررسی نمایید.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvData.Rows[e.RowIndex].Selected = true;
                        e.Cancel = true;
                        return;
                    }
                }
            }
            #endregion
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
            e.Row.Cells[1].Value = true;
            e.Row.Cells[3].Value = "نام";
            e.Row.Cells[3].Value = "نام خانوادگی";
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
            else dgvData.DataSource = _DataSource.Where(FilteredData => FilteredData.IsActive == true);
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvData.AllowUserToAddRows = true;
            dgvData.Rows[dgvData.Rows.Count - 1].Cells[2].Selected = true;
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

            String FullName;
            if (dgvData.Rows[RowIndex].Cells["ColFirstName"].Value != null)
                FullName = dgvData.Rows[RowIndex].Cells["ColFirstName"].Value + " " +
                    dgvData.Rows[RowIndex].Cells["ColLastName"].Value;
            else FullName = dgvData.Rows[RowIndex].Cells["ColLastName"].Value.ToString();
            DialogResult Dr = PMBox.Show("آیا مایلید ردیف زیر حذف گردد:\n\"" + FullName +
                "\"\nبا حذف این پزشك ، اطلاعات پزشك مراجعه كلیه مراجعات بیمارانی" +
                " كه این پزشك مراجعه برای آنها ثبت شده حذف خواهد شد.",
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
                        "امكان حذف پزشك مراجعه از بانك وجود ندارد.\n" +
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

            #region Validations
            List<String> MedList = _DataSource.Select(Data => Data.MedicalID.Trim()).ToList();
            if (MedList.Count != MedList.Distinct().Count())
            {
                PMBox.Show("در بین نظام پزشكی های ثبت شده ، نظام پزشكی تكراری وجود دارد!\n" +
                    "لطفاً اصلاح نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            #endregion
            if (!Negar.DBLayerPMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان به روز رسانی بانك بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا نام تكراری وارد ننموده اید؟\n" +
                    "2. آیا ردیف جدیدی فاقد نام وارد ننموده اید؟\n" +
                    "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _IsGridValuesChanged = false;
            if (!FillDataSource()) { Close(); return; }
            dgvData.DataSource = _DataSource;
            dgvData.Refresh();
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnAccept.Focus();
            dgvData.EndEdit();
            #region Validations
            List<String> MedList = _DataSource.Select(Data => Data.MedicalID.Trim()).ToList();
            if (MedList.Count != MedList.Distinct().Count())
            {
                PMBox.Show("در بین نظام پزشكی های ثبت شده ، نظام پزشكی تكراری وجود دارد!\n" +
                    "لطفاً اصلاح نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
            if (!Negar.DBLayerPMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان به روز رسانی بانك بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا نام تكراری وارد ننموده اید؟\n" +
                    "2. آیا ردیف جدیدی فاقد نام وارد ننموده اید؟\n" +
                    "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            _IsGridValuesChanged = false;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region btnMixRows_Click
        private void btnMixRows_Click(object sender, EventArgs e)
        {
            dgvData.EndEdit();
            btnAccept.Select();
            if (_IsGridValuesChanged)
            {
                PMBox.Show("قبل از ورود به فرم ادغام ، باید تغغیرات را ذخیره نمایید.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            new frmMixPhysicians();
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (!FillDataSource()) { _IsGridValuesChanged = false; Close(); }
            cBoxWithInActives_CheckedChanged(null, null);
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }
        #endregion

        #region btnTranslate_Click
        private void btnTranslate_Click(object sender, EventArgs e)
        {
            DialogResult Result = PMBox.Show("آیا مایلید كلیه اسامی پزشكان در این فرم را به انگلیسی ترجمه كنید؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (Result == DialogResult.Yes)
            {
                Thread MyThread = new Thread(TranslateNames);
                MyThread.Start();
            }
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
                DialogResult Dr = PMBox.Show("آیا از اعمال تغییرات منصرف شدید؟", "هشدار!", MessageBoxButtons.YesNo,
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
            String TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnCancel", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region cBoxWithInActives
            TooltipText = ToolTipManager.GetText("cBoxWithInActivesRefPhys", "IMS");
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
            TooltipText = ToolTipManager.GetText("btnAddRefPhys", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnMixRows
            TooltipText = ToolTipManager.GetText("btnRefPhysMixRows", "IMS");
            FormToolTip.SetSuperTooltip(btnMixRows,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات پایه فرم از بانك
        /// </summary>
        private Boolean FillDataSource()
        {
            try
            {
                ColSpecs.DataSource =
                    Negar.DBLayerPMS.Manager.DBML.SP_SelectRefPhysiciansSpecs().OrderBy(Data => Data.Title).ToList();
                ColSpecs.DisplayMember = "Title";
                ColSpecs.ValueMember = "ID";
                _DataSource = Negar.DBLayerPMS.Manager.DBML.RefPhysicians.OrderBy(Data => Data.LastName);
                Negar.DBLayerPMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _DataSource);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات پزشكان مراجعه از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Referrals Setting", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region void TranslateNames()
        private void TranslateNames()
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                RefPhysician Data = (RefPhysician)row.DataBoundItem;
                if (!String.IsNullOrEmpty(Data.FirstName))
                {
                    String PersianValue = Negar.DBLayerPMS.Patients.GetEnglishName(Data.FirstName, true);
                    if (!String.IsNullOrEmpty(PersianValue)) row.Cells[ColFirstNameEn.Index].Value = PersianValue;
                }
                if (!String.IsNullOrEmpty(Data.LastName))
                {
                    String PersianValue = Negar.DBLayerPMS.Patients.GetEnglishName(Data.LastName, false);
                    if (!String.IsNullOrEmpty(PersianValue)) row.Cells[ColLastNameEn.Index].Value = PersianValue;
                }
            }
            PMBox.Show("ترجمه اسامی پایان یافت.", "تبریك!");
        }
        #endregion

        #endregion

    }
}