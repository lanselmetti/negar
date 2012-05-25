﻿#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.Security.Classes;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Accounts.Properties;
#endregion

namespace Sepehr.Settings.Accounts
{
    /// <summary>
    /// فرم مدیریت دسترسی كاربران به تخفیف ها و هزینه ها
    /// </summary>
    public partial class frmCostDiscountUsersExclude : Form
    {

        #region Fields

        #region List<CostsAndDiscountsUsersExclude> _UsersCDAccessDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<CostsAndDiscountsUsersExclude> _UsersCDAccessDataSource;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmCostDiscountUsersExclude()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillCostsDiscountsDataSource() || !FillUsersInGroupsDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            cboBills_SelectedIndexChanged(null, null);
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region cboBills_SelectedIndexChanged
        /// <summary>
        /// روال مدیریت تغییر آیتم انتخاب شده در كمبو باكس گروه ها
        /// </summary>
        private void cboBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvData.DataSource = _UsersCDAccessDataSource.
                Where(Data => Data.CDIX == Convert.ToInt16(cboCDList.SelectedValue)).ToList();
        }
        #endregion

        #region dgvData_CellFormatting
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColUserName.Index)
                e.Value = Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID == 
                        ((CostsAndDiscountsUsersExclude)dgvData.Rows[e.RowIndex].DataBoundItem).UserIX).First().FullName;
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvData.SelectedCells.Count != 0)
            {
                dgvData_CellMouseClick(1, new DataGridViewCellMouseEventArgs
                        (0, dgvData.SelectedCells[0].RowIndex, Left + Width - 150,
                        dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top
                        + dgvData.ColumnHeadersHeight + 30 + Top,
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

        #region dgvData_CellBeginEdit
        private void dgvData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            btnDelete.Shortcuts.Clear();
        }
        #endregion

        #region dgvData_CellEndEdit
        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Shortcuts.Add(eShortcut.Del);
        }
        #endregion

        #region btnAdd_Click
        /// <summary>
        /// روال دكمه ی افزودن كاربر جدید به گروه انتخاب شده
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UsersSelection MyForm = new UsersSelection();
            if (MyForm.DialogResult != DialogResult.OK) { MyForm.Dispose(); return; }
            #region Add Members To ServicesGrouping
            List<Int16> AddedUsersID = MyForm.SelectedUsersID;
            foreach (Int16 UserID in AddedUsersID)
            {
                if (_UsersCDAccessDataSource.Where(Data => Data.CDIX == Convert.ToInt16(cboCDList.SelectedValue) &&
                    Data.UserIX == UserID).Count() != 0) continue;
                CostsAndDiscountsUsersExclude NewItem = new CostsAndDiscountsUsersExclude();
                NewItem.CDIX = Convert.ToInt16(cboCDList.SelectedValue);
                NewItem.UserIX = UserID;
                DBLayerIMS.Manager.DBML.CostsAndDiscountsUsersExcludes.InsertOnSubmit(NewItem);
            }
            if (!DBLayerIMS.Manager.Submit())
            {
                PMBox.Show("خطا در ارائه دسترسی به كاربران انتخاب شده!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MyForm.Dispose();
            #endregion
            if (!FillUsersInGroupsDataSource()) { Close(); return; }
            cboBills_SelectedIndexChanged(null, null);
        }
        #endregion

        #region btnDelete_Click
        /// <summary>
        /// روال دكمه ی حذف كاربر از گروه انتخاب شده
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                PMBox.Show("كاربری برای حذف كردن وجود ندارد!\n" +
                "برای حذف یك كاربر باید تخفیف یا هزینه ای را كه شامل كاربر می باشد انتخاب نمایید یا یك كاربر به گروه جاری اضافه كنید.",
                "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
            }
            DialogResult Dr = PMBox.Show("آیا مایلید كاربر انتخاب شده از گروه حذف گردد؟\n" +
                "با حذف این كاربر از گروه ، تغییرات عیناً در بانك اطلاعات منعكس می گردد.",
                "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            DBLayerIMS.Manager.DBML.CostsAndDiscountsUsersExcludes.
                DeleteOnSubmit(((CostsAndDiscountsUsersExclude)dgvData.SelectedRows[0].DataBoundItem));
            if (DBLayerIMS.Manager.Submit())
            {
                if (!FillUsersInGroupsDataSource()) { Close(); return; }
                cboBills_SelectedIndexChanged(null, null);
            }
            else PMBox.Show("خطا در حذف دسترسی كاربر انتخاب شده به تخفیف یا هزینه!", "خطا!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            #region cboCDList
            TooltipText = ToolTipManager.GetText("cboPrintTemplates", "IMS");
            FormToolTip.SetSuperTooltip(cboCDList, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAdd
            TooltipText = ToolTipManager.GetText("btnAddBillTemplateUser", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillCostsDiscountsDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات كمبوباكس
        /// </summary>
        private Boolean FillCostsDiscountsDataSource()
        {
            try
            {
                cboCDList.DataSource = DBLayerIMS.Manager.DBML.CostsAndDiscountsTypes.Where(Data => Data.IsActive)
                    .Select(Data => new { Data.ID, Data.Name }).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات قبوض تعریف شده از بانك اطلاعات!\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.");
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error);
                return false;
            }
            #endregion

            cboCDList.ValueMember = "ID";
            cboCDList.DisplayMember = "Name";

            #region Check Existance
            if (cboCDList.Items.Count == 0)
            {
                PMBox.Show("تخفیف یا هزینه ای برای مدیریت دسترسی كاربران ثبت نگردیده است!\n" +
                    "لطفاً ابتدا تخفیف یا هزینه فعال تعریف نمایید.", "خطا!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean FillUsersInGroupsDataSource()
        /// <summary>
        /// تابع تكمیل اطلاعات ارتباط كاربران و گروه ها
        /// </summary>
        private Boolean FillUsersInGroupsDataSource()
        {
            try
            {
                Table<CostsAndDiscountsUsersExclude> TempData = DBLayerIMS.Manager.DBML.CostsAndDiscountsUsersExcludes;
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                _UsersCDAccessDataSource = TempData.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات دسترسی كاربران به قبوض از بانك اطلاعات!\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.");
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}