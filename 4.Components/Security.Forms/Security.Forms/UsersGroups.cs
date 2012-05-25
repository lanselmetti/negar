#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.Security.Properties;
using DevComponents.DotNetBar;
using Application=System.Windows.Forms.Application;

#endregion

namespace Negar.Security
{
    /// <summary>
    /// فرم مدیریت گروه های كاربری
    /// </summary>
    public partial class frmUsersGroups : Form
    {

        #region Fields

        #region IOrderedQueryable<UsersGroups> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private IOrderedQueryable<UsersGroups> _DataSource;
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
        public frmUsersGroups()
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
            _IsGridValuesChanged = false;
        }
        #endregion

        #region dgvData_CellValidating
        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            #region Check Medical ID
            if (e.ColumnIndex == ColName.Index)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (!row.IsNewRow && row.Cells[e.ColumnIndex].Value != null &&
                        row.Cells[e.ColumnIndex].Value != DBNull.Value &&
                        row.Index != e.RowIndex &&
                        e.FormattedValue != null && e.FormattedValue != DBNull.Value &&
                        row.Cells[e.ColumnIndex].Value.ToString().Trim().ToLower() == e.FormattedValue.ToString().ToLower())
                    {
                        PMBox.Show("نام گروه وارد شده تكراریست! لطفاً مقدار وارد شده را بررسی نمایید.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvData.Focus();
                        // dgvData.Rows[e.RowIndex].Selected = true;
                        e.Cancel = true;
                        return;
                    }
                }
            }
            #endregion
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
                        Top + dgvData.Top + dgvData.ColumnHeadersHeight + 28 +
                        dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top,
                        new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
            }
        }
        #endregion

        #region dgvData_CellValueChanged
        /// <summary>
        /// روالی برای كنترل به وقوع پیوستن تغییرات در جدول
        /// </summary>
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _IsGridValuesChanged = true;
        }
        #endregion

        #region dgvData_CellEnter
        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
        }
        #endregion

        #region dgvData_CellBeginEdit
        /// <summary>
        /// روال مدیریت آغاز تغییر در یك سلول جدول
        /// </summary>
        private void dgvData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _IsGridValuesChanged = true;
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

        #region dgvData_DefaultValuesNeeded
        /// <summary>
        /// روال تولید مقادیر پیش فرض برای ردیف جدید جدول
        /// </summary>
        private void dgvData_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = true;
            e.Row.Cells[1].Value = "گروه " + (e.Row.Index + 1);
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
            if (sender.GetType().Equals(typeof(Int32)) &&
            e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvData.Rows[e.RowIndex].Selected = true;
                cmsMenu.PopupMenu(e.Location);
            }
            else if (e.Button == MouseButtons.Right && e.RowIndex >= 0 &&
                e.ColumnIndex >= 0 && e.RowIndex != dgvData.NewRowIndex)
            {
                dgvData.Rows[e.RowIndex].Selected = true;
                cmsMenu.Popup(MousePosition);
            }
        }
        #endregion

        #region cBoxWithInActives_CheckedChanged
        private void cBoxWithInActives_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxWithInActives.Checked) dgvData.DataSource = _DataSource;
            else dgvData.DataSource = (from Data in _DataSource where Data.IsActive select Data);
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
            DialogResult Dr = PMBox.Show("آیا مایلید گروه كاربری زیر حذف گردد:\n\"" +
                dgvData.Rows[RowIndex].Cells[1].Value +
                "\"\nبا حذف این گروه ، اطلاعات كاربران عضو در این گروه و سطوح دسترسی آنها حذف خواهد شد.", "هشدار!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
                        "امكان حذف گروه های كاربری از بانك وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Negar", "Security Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                }
                #endregion
        }
        #endregion

        #region btnApply_Click
        /// <summary>
        /// روال دكمه ی اعمال
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            btnAccept.Focus();
            dgvData.EndEdit();
            #region Validations
            // تعریف لیست آیتم های چك شده برای موارد تكراری
            System.Collections.Generic.List<String> CheckedItems2 = new List<String>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                // نادیده گرفتن ردیف افزوده شده ی جدید
                if (row.IsNewRow) continue;

                #region Duplicate Rows
                // بررسی عدم وجود ردیف جاری در ردیف های بررسی شده
                if (!CheckedItems2.Contains(row.Cells[ColName.Index].Value.ToString().Trim()))
                {
                    // جستجوی مجدد در بین تمام آیتم های جدول
                    foreach (DataGridViewRow TempRow in dgvData.Rows)
                        if (!TempRow.IsNewRow && // ردیف جدید نباشد
                            row.Index != TempRow.Index && // با ردیف جاری برای مقایسه برابر نباشد
                            TempRow.Cells[ColName.Index].Value != null && // مقدار آن تهی نباشد
                            // اگر هر دو ردیف برابر باشند
                            TempRow.Cells[ColName.Index].Value.ToString().ToLower() ==
                            row.Cells[ColName.Index].Value.ToString().ToLower())
                        {

                            PMBox.Show("در بین گروه های وارد شده ، نام گروه تكراری وجود دارد!\n" +
                                "لطفاً اصلاح نمایید.", "خطا!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            row.Cells[ColName.Index].Selected = true;
                            return;
                        }
                    // افزودن ردیف غیر تكراری به لیست آیتم های چك شده
                    CheckedItems2.Add(row.Cells[ColName.Index].Value.ToString().Trim());
                }
                #endregion
            }
            ArrayList CheckedItems = new ArrayList();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    #region Empty Cells
                    if (row.Cells["ColName"].Value == null ||
                        String.IsNullOrEmpty(row.Cells["ColName"].Value.ToString().Trim()))
                    {
                        PMBox.Show("نام كاربری حتماً باید تكمیل گردد!\n" +
                            "در بین كاربران ثبت شده كاربری فاقد نام كاربری وجود دارد.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        row.Selected = true;
                        return;
                    }
                    if (row.Cells["ColName"].Value == null ||
                        String.IsNullOrEmpty(row.Cells["ColName"].Value.ToString().Trim()))
                    {
                        PMBox.Show("نام خانوادگی حتماً باید تكمیل گردد!\n" +
                            "در بین كاربران ثبت شده كاربری فاقد نام خانوادگی وجود دارد.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        row.Selected = true;
                        return;
                    }
                    #endregion

                    #region Duplicate Cells
                    if (!CheckedItems.Contains(row.Cells["ColName"].Value.ToString().Trim()))
                    {
                        foreach (DataGridViewRow TempRow in dgvData.Rows)
                        {
                            if (!TempRow.IsNewRow && row.Index != TempRow.Index &&
                                TempRow.Cells["ColName"].Value != null &&
                                row.Cells["ColName"].Value != null &&
                                TempRow.Cells["ColName"].Value.ToString().ToLower() ==
                                row.Cells["ColName"].Value.ToString().ToLower())
                            {
                                PMBox.Show("در بین نام های كاربری ، نام كاربری تكراری وجود دارد!\n" +
                                "لطفاً اصلاح نمایید.", "خطا!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                                return;
                            }
                        }
                        CheckedItems.Add(row.Cells["ColName"].Value.ToString().Trim());
                    }
                    #endregion
                }
            }
            #endregion
            if (!DBLayerPMS.Manager.Submit())
            {
                const String ErrorMessage =
                    "امكان به روز رسانی اطلاعات گروه های كاربری بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا گروه تكراری وارد ننموده اید؟\n" +
                    "2. آیا ردیف جدیدی فاقد عنوان وارد ننموده اید؟\n" +
                    "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _IsGridValuesChanged = false;
        }
        #endregion

        #region btnSave_Click
        /// <summary>
        /// روال ذخیره سازی اطلاعات
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnAccept.Focus();
            dgvData.EndEdit();
            #region Validations
            // تعریف لیست آیتم های چك شده برای موارد تكراری
            System.Collections.Generic.List<String> CheckedItems2 = new List<String>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                // نادیده گرفتن ردیف افزوده شده ی جدید
                if (row.IsNewRow) continue;

                #region Duplicate Rows
                // بررسی عدم وجود ردیف جاری در ردیف های بررسی شده
                if (!CheckedItems2.Contains(row.Cells[ColName.Index].Value.ToString().Trim()))
                {
                    // جستجوی مجدد در بین تمام آیتم های جدول
                    foreach (DataGridViewRow TempRow in dgvData.Rows)
                        if (!TempRow.IsNewRow && // ردیف جدید نباشد
                            row.Index != TempRow.Index && // با ردیف جاری برای مقایسه برابر نباشد
                            TempRow.Cells[ColName.Index].Value != null && // مقدار آن تهی نباشد
                            // اگر هر دو ردیف برابر باشند
                            TempRow.Cells[ColName.Index].Value.ToString().ToLower() ==
                            row.Cells[ColName.Index].Value.ToString().ToLower())
                        {

                            PMBox.Show("در بین گروه های وارد شده ، نام گروه تكراری وجود دارد!\n" +
                                "لطفاً اصلاح نمایید.", "خطا!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            row.Cells[ColName.Index].Selected = true;
                            return;
                        }
                    // افزودن ردیف غیر تكراری به لیست آیتم های چك شده
                    CheckedItems2.Add(row.Cells[ColName.Index].Value.ToString().Trim());
                }
                #endregion
            }
            ArrayList CheckedItems = new ArrayList();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    #region Empty Cells
                    if (row.Cells["ColName"].Value == null ||
                        String.IsNullOrEmpty(row.Cells["ColName"].Value.ToString().Trim()))
                    {
                        PMBox.Show("نام كاربری حتماً باید تكمیل گردد!\n" +
                            "در بین كاربران ثبت شده كاربری فاقد نام كاربری وجود دارد.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        row.Selected = true;
                        return;
                    }
                    if (row.Cells["ColName"].Value == null ||
                        String.IsNullOrEmpty(row.Cells["ColName"].Value.ToString().Trim()))
                    {
                        PMBox.Show("نام خانوادگی حتماً باید تكمیل گردد!\n" +
                            "در بین كاربران ثبت شده كاربری فاقد نام خانوادگی وجود دارد.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        row.Selected = true;
                        return;
                    }
                    #endregion

                    #region Duplicate Cells
                    if (!CheckedItems.Contains(row.Cells["ColName"].Value.ToString().Trim()))
                    {
                        foreach (DataGridViewRow TempRow in dgvData.Rows)
                        {
                            if (!TempRow.IsNewRow && row.Index != TempRow.Index &&
                                TempRow.Cells["ColName"].Value != null &&
                                row.Cells["ColName"].Value != null &&
                                TempRow.Cells["ColName"].Value.ToString().ToLower() ==
                                row.Cells["ColName"].Value.ToString().ToLower())
                            {
                                PMBox.Show("در بین نام های كاربری ، نام كاربری تكراری وجود دارد!\n" +
                                "لطفاً اصلاح نمایید.", "خطا!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                                return;
                            }
                        }
                        CheckedItems.Add(row.Cells["ColName"].Value.ToString().Trim());
                    }
                    #endregion
                }
            }
            #endregion
            if (!DBLayerPMS.Manager.Submit())
            {
                const String ErrorMessage =
                    "امكان به روز رسانی اطلاعات گروه های كاربری بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا گروه تكراری وارد ننموده اید؟\n" +
                    "2. آیا ردیف جدیدی فاقد عنوان وارد ننموده اید؟\n" +
                    "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                DialogResult Dr = PMBox.Show("آیا از اعمال تغییرات منصرف شدید؟", "هشدار",
                    MessageBoxButtons.YesNo,
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
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnCancel", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region cBoxWithInActives
            TooltipText = ToolTipManager.GetText("cBoxWithInActivesUserGroups", "IMS");
            FormToolTip.SetSuperTooltip(cBoxWithInActives,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnDelete
            TooltipText = ToolTipManager.GetText("btnDelete", "IMS");
            FormToolTip.SetSuperTooltip(btnDelete,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnApply
            TooltipText = ToolTipManager.GetText("btnApply", "IMS");
            FormToolTip.SetSuperTooltip(btnApply,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAdd
            TooltipText = ToolTipManager.GetText("btnAdd", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        private Boolean FillDataSource()
        {
            try { _DataSource = DBLayerPMS.Manager.DBML.UsersGroups.OrderBy(Group => Group.Name); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات گروه های كاربری از بانك اطلاعات بیماران ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Security Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}