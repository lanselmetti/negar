#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.Security.Classes;
using Negar.Security.Properties;
using DevComponents.DotNetBar;
using Application=System.Windows.Forms.Application;

#endregion

namespace Negar.Security
{
    /// <summary>
    /// فرم مدیریت كاربران سیستم
    /// </summary>
    public partial class frmUsers : Form
    {

        #region Fields

        #region IOrderedQueryable<UsersList> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private IOrderedQueryable<UsersList> _DataSource;
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
        public frmUsers()
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

        #region cBoxWithInActives_CheckedChanged
        private void cBoxWithInActives_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxWithInActives.Checked) dgvData.DataSource = _DataSource;
            else dgvData.DataSource = _DataSource.Where(Data => Data.IsActive);
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvData.AllowUserToAddRows = true;
            dgvData.Rows[dgvData.Rows.Count - 1].Cells[ColUserName.Index].Selected = true;
            dgvData.Focus();
            dgvData.BeginEdit(true);
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvData.SelectedCells.Count != 0)
            {
                dgvData_CellMouseClick(1, new DataGridViewCellMouseEventArgs
                        (0, dgvData.SelectedCells[0].RowIndex, Left + Width - 150,
                        Top + dgvData.Top + dgvData.ColumnHeadersHeight +
                        dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top + 12,
                        new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
            }
        }
        #endregion

        #region dgvData_CellEnter
        /// <summary>
        /// روالی برای تغییر زبان كیبورد پس از ورود به سلول ها
        /// </summary>
        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColUserName.Index)
                Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("En-Us"));
            else Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
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

        #region dgvData_DefaultValuesNeeded
        /// <summary>
        /// روال تولید مقادیر پیش فرض برای ردیف جدید جدول
        /// </summary>
        private void dgvData_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[ColIsActive.Name].Value = true;
            e.Row.Cells[ColUserName.Name].Value = "UserName";
            e.Row.Cells[ColLastName.Name].Value = "نام خانوادگی";
            e.Row.Cells[ColMustChangePassword.Name].Value = true;
            e.Row.Cells[ColPass.Index].Value = "MoFlp+jAZnE8olbK4dTuEg==";
        }
        #endregion

        #region dgvData_UserAddedRow
        private void dgvData_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvData.AllowUserToAddRows = false;
        }
        #endregion

        #region dgvData_CellValidating
        /// <summary>
        /// روال بررسی صحت اعتبار اطلاعات وارد شده در یك سلول جدول
        /// </summary>
        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            #region Check User Name
            if (e.ColumnIndex == ColUserName.Index)
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
                {
                    PMBox.Show("نام كاربری حتماً باید تكمیل گردد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    return;
                }
                if (e.FormattedValue.ToString().ToLower() == "administrator")
                {
                    PMBox.Show("كاربری با نام كاربری Administrator را نمی توانید تعریف نمایید!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (!row.IsNewRow && row.Cells[e.ColumnIndex].Value != null && row.Index != e.RowIndex &&
                        row.Cells[e.ColumnIndex].Value.ToString().ToLower() == e.FormattedValue.ToString().ToLower())
                    {
                        PMBox.Show("نام كاربری وارد شده تكراریست! لطفاً نام كاربری دیگری انتخاب نمایید.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            #endregion

            #region Check Last Name
            else if (e.ColumnIndex == ColLastName.Index)
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
                {
                    PMBox.Show("نام خانوادگی كاربر حتماً باید تكمیل گردد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    return;
                }
            }
            #endregion

        }
        #endregion

        #region dgvData_CellMouseClick
        /// <summary>
        /// روالی برای مدیریت نمایش كلیك راست بر روی فرم
        /// </summary>
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Point Position = MousePosition;
            // اگر درخواست كننده تابع جاری كلید ویندوز باشد و نه كلیك راست موس محل نمایش نموی كلیك راست تغییر می كند
            if (sender is Int32 && e.RowIndex >= 0 && e.ColumnIndex >= 0) { Position = e.Location; }
            else if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            else dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            // منوی كلیك راست نمایش داده می شود
            cmsUsersManage.Popup(Position);
        }
        #endregion

        #region btnResetPassword_Click
        /// <summary>
        /// دكمه ی بازنویسی كلمه عبور یك كاربر
        /// </summary>
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            dgvData.EndEdit();
            btnAccept.Focus();
            dgvData.Focus();
            // اگر ردیفی انتخاب نشده باشد خارج می گردد
            if (dgvData.SelectedCells.Count == 0) return;
            ChangeUserPassword MyForm = new ChangeUserPassword(0, false, false);
            if (MyForm.DialogResult == DialogResult.OK)
            {
                String DecryptPassword = Cryptographer.EncryptString(MyForm.txtPass1.Text.Trim(), "AftabClearPassword");
                ((UsersList)dgvData.Rows[dgvData.SelectedCells[0].RowIndex].DataBoundItem).Password = DecryptPassword;
                _IsGridValuesChanged = true;
            }
            MyForm.Dispose();
        }
        #endregion

        #region btnApply_Click
        /// <summary>
        /// روال دكمه ی اعمال
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            // اتمام ویرایش سلول های جدول در صورتی كه در حال ویرایش هستند
            dgvData.EndEdit();
            btnApply.Focus();
            #region Validations
            // تعریف لیست آیتم های چك شده برای موارد تكراری
            List<String> CheckedItems = new List<String>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                // نادیده گرفتن ردیف افزوده شده ی جدید
                if (row.IsNewRow) continue;

                #region Administrator UserNames
                // بررسی وارد شدن عبارات رزرو شده توسط كاربر
                if (row.Cells[ColUserName.Name].Value.ToString().ToLower() == "administrator")
                {
                    PMBox.Show("كاربری با نام كاربری Administrator را نمی توانید تعریف نمایید!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (row.Cells[ColUserName.Name].Value.ToString().ToLower() == "sa")
                {
                    PMBox.Show("كاربری با نام كاربری Sa را نمی توانید تعریف نمایید!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                #region Empty Cells
                // بررسی عدم ورود مقادیر تهی برای ستون هایی كه تهی نمی پذیرند
                if (row.Cells[ColUserName.Name].Value == null ||
                    String.IsNullOrEmpty(row.Cells[ColUserName.Name].Value.ToString().Trim()))
                {
                    PMBox.Show("نام كاربری حتماً باید تكمیل گردد!\n" +
                        "در بین كاربران ثبت شده كاربری فاقد نام كاربری وجود دارد.", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    row.Selected = true;
                    return;
                }
                if (row.Cells[ColLastName.Name].Value == null ||
                    String.IsNullOrEmpty(row.Cells[ColLastName.Name].Value.ToString().Trim()))
                {
                    PMBox.Show("نام خانوادگی حتماً باید تكمیل گردد!\n" +
                        "در بین كاربران ثبت شده كاربری فاقد نام خانوادگی وجود دارد.", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    row.Selected = true;
                    return;
                }
                #endregion

                #region Duplicate Rows
                // بررسی عدم وجود ردیف جاری در ردیف های بررسی شده
                if (!CheckedItems.Contains(row.Cells[ColUserName.Name].Value.ToString().Trim()))
                {
                    // جستجوی مجدد در بین تمام آیتم های جدول
                    foreach (DataGridViewRow TempRow in dgvData.Rows)
                        if (!TempRow.IsNewRow && // ردیف جدید نباشد
                            row.Index != TempRow.Index && // با ردیف جاری برای مقایسه برابر نباشد
                            TempRow.Cells[ColUserName.Name].Value != null && // مقدار آن تهی نباشد
                            // اگر هر دو ردیف برابر باشند
                            TempRow.Cells[ColUserName.Name].Value.ToString().ToLower() ==
                            row.Cells[ColUserName.Name].Value.ToString().ToLower())
                        {
                            PMBox.Show("در بین نام های كاربری ، نام كاربری تكراری وجود دارد!\n" + "لطفاً اصلاح نمایید.", "خطا!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    // افزودن ردیف غیر تكراری به لیست آیتم های چك شده
                    CheckedItems.Add(row.Cells[ColUserName.Name].Value.ToString().Trim());
                }
                #endregion
            }
            #endregion
            if (!DBLayerPMS.Manager.Submit())
            {
                const String ErrorMessage =
                    "امكان به روز رسانی اطلاعات كاربران بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا نام كاربری تكراری وارد ننموده اید؟\n" +
                    "2. آیا ردیف جدیدی فاقد نام كاربری وارد ننموده اید؟\n" +
                    "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _IsGridValuesChanged = false;
            dgvData.Focus();
        }
        #endregion

        #region btnSave_Click
        /// <summary>
        /// روال ذخیره سازی اطلاعات
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvData.EndEdit();
            btnAccept.Focus();
            #region Validations
            ArrayList CheckedItems = new ArrayList();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    #region Administrator UserName
                    if (row.Cells["ColUserName"].Value.ToString().ToLower() == "administrator")
                    {
                        PMBox.Show("كاربری با نام كاربری Administrator را نمی توانید تعریف نمایید!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (row.Cells["ColUserName"].Value.ToString().ToLower() == "sa")
                    {
                        PMBox.Show("كاربری با نام كاربری Sa را نمی توانید تعریف نمایید!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion

                    #region Empty Cells
                    if (row.Cells["ColUserName"].Value == null ||
                        String.IsNullOrEmpty(row.Cells["ColUserName"].Value.ToString().Trim()))
                    {
                        PMBox.Show("نام كاربری حتماً باید تكمیل گردد!\n" +
                            "در بین كاربران ثبت شده كاربری فاقد نام كاربری وجود دارد.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        row.Selected = true;
                        return;
                    }
                    if (row.Cells["ColLastName"].Value == null ||
                        String.IsNullOrEmpty(row.Cells["ColLastName"].Value.ToString().Trim()))
                    {
                        PMBox.Show("نام خانوادگی حتماً باید تكمیل گردد!\n" +
                            "در بین كاربران ثبت شده كاربری فاقد نام خانوادگی وجود دارد.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        row.Selected = true;
                        return;
                    }
                    #endregion

                    #region Duplicate Rows
                    if (!CheckedItems.Contains(row.Cells["ColUserName"].Value.ToString().Trim()))
                    {
                        foreach (DataGridViewRow TempRow in dgvData.Rows)
                        {
                            if (!TempRow.IsNewRow && row.Index != TempRow.Index &&
                                TempRow.Cells["ColUserName"].Value != null &&
                                row.Cells["ColUserName"].Value != null &&
                                TempRow.Cells["ColUserName"].Value.ToString().ToLower() ==
                                row.Cells["ColUserName"].Value.ToString().ToLower())
                            {
                                PMBox.Show("در بین نام های كاربری ، نام كاربری تكراری وجود دارد!\n" +
                                "لطفاً اصلاح نمایید.", "خطا!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                                return;
                            }
                        }
                        CheckedItems.Add(row.Cells["ColUserName"].Value.ToString().Trim());
                    }
                    #endregion
                }
            }
            #endregion
            if (!DBLayerPMS.Manager.Submit())
            {
                const String ErrorMessage =
                    "امكان به روز رسانی اطلاعات كاربران بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا نام كاربری تكراری وارد ننموده اید؟\n" +
                    "2. آیا ردیف جدیدی فاقد نام كاربری وارد ننموده اید؟\n" +
                    "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            TooltipText = ToolTipManager.GetText("cBoxWithInActivesUser", "IMS");
            FormToolTip.SetSuperTooltip(cBoxWithInActives,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnResetPassword
            TooltipText = ToolTipManager.GetText("btnUsersResetPassword", "IMS");
            FormToolTip.SetSuperTooltip(btnResetPassword,
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
            TooltipText = ToolTipManager.GetText("btnAddUser", "IMS");
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
            // حذف كاربر Administrator , Sa
            // خواندن لیست كاربران از بانك به صورت مستقیم
            try { _DataSource = DBLayerPMS.Manager.DBML.UsersLists.Where(Data => Data.ID > 2).OrderBy(User => User.UserName); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات كاربران از بانك اطلاعات بیماران ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Arash" , "Security Forms" , Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}