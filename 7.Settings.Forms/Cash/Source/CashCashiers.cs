#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Cash.Properties;
#endregion

namespace Sepehr.Settings.Cash
{
    /// <summary>
    /// فرم مدیریت ارتباط صندوق ها و صندوقداران
    /// </summary>
    public partial class frmCashCashiers : Form
    {

        #region Fields

        #region IEnumerable<SP_SelectCashiersCashesListResult> _CashiersInSelectedCash
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private IEnumerable<SP_SelectCashiersCashesListResult> _CashiersInSelectedCash;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmCashCashiers()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillCashesDataSource() || !FillCashCashiersDataSource()) { Close(); return; }
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

        #region cboCashes_SelectedIndexChanged
        private void cboCashes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FillCashCashiersDataSource()) { Close(); return; }
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Negar.Security.Classes.UsersSelection MyForm = new Negar.Security.Classes.UsersSelection();
            if (MyForm.DialogResult != DialogResult.OK) { MyForm.Dispose(); return; }

            List<Int16> AddedUsersID = MyForm.SelectedUsersID;
            try
            {
                foreach (Int16 UserID in AddedUsersID)
                    DBLayerIMS.Manager.DBML.SP_InsertCashiersCashes(UserID, Convert.ToInt16(cboCashes.SelectedValue));
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در افزودن اطلاعات كاربر صندوقدار به بانك اطلاعات!" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.", "خطا!");
                LogManager.SaveLogEntry("Sepehr", "Cashes Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
            #region Finally
            finally
            {
                MyForm.Dispose();
                _CashiersInSelectedCash = null;
                if (!FillCashCashiersDataSource()) Close();
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
                        Top + dgvData.Top + dgvData.ColumnHeadersHeight +
                        dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top + 28,
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

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) return;
            Int32 RowIndex = dgvData.SelectedRows[0].Index;
            DialogResult Dr = PMBox.Show("آیا مایلید كاربر زیر حذف گردد:\n\"" +
                dgvData.Rows[RowIndex].Cells[1].Value +
                "\"\nبا حذف این صندوقدار ، تغییری در وضعیت عملیاتی كه " +
                "این كاربر انجام داده صورت نمی گیرد و تنها قادر نخواهد بود عملیات مالی جدیدی در صندوق مورد نظر انجام دهد.",
                "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            DBLayerIMS.Manager.DBML.CashiersCashes.DeleteAllOnSubmit(
                DBLayerIMS.Manager.DBML.CashiersCashes.
                Where(Data => Data.CashIX == Convert.ToInt16(cboCashes.SelectedValue) &&
                    Data.CashierIX == ((SP_SelectCashiersCashesListResult)dgvData.Rows[RowIndex].DataBoundItem).CashierID));
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان حذف كاربر صندوقدار از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            _CashiersInSelectedCash = null;
            if (!FillCashCashiersDataSource()) { Close(); return; }
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

            #region btnAddCashCashiers
            TooltipText = ToolTipManager.GetText("btnAddCashCashier", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region cboCashGroups
            TooltipText = ToolTipManager.GetText("cboCash", "IMS");
            FormToolTip.SetSuperTooltip(cboCashes, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillCashesDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات ارتباط صندوق ها و صندوقداران از بانك
        /// </summary>
        private Boolean FillCashesDataSource()
        {
            List<SP_SelectCashesResult> Cashes = DBLayerIMS.Cash.CashFullList;
            if (Cashes == null) return false;
            Cashes = Cashes.Where(Data => Data.IsActive == true).ToList();
            if (Cashes.Count == 0)
            {
                PMBox.Show("صندوقی برای مدیریت ارتباط صندوق ها و صندوقداران ثبت نگردیده است!\n" +
                    "لطفاً ابتدا صندوقی را تعریف نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            cboCashes.DataSource = Cashes;
            return true;
        }
        #endregion

        #region Boolean FillCashCashiersDataSource()
        /// <summary>
        /// تابع تكمیل  اطلاعات ارتباط صندوق ها و صندوقداران 
        /// </summary>
        private Boolean FillCashCashiersDataSource()
        {
            if (_CashiersInSelectedCash == null)
                try { _CashiersInSelectedCash = DBLayerIMS.Manager.DBML.SP_SelectCashiersCashesList().ToList(); }
                #region Catch
                catch (Exception Ex)
                {
                    PMBox.Show("خطا در خواندن اطلاعات ارتباط صندوق ها و صندوقداران از بانك اطلاعات!" +
                               "موارد زیر را بررسی نمایید:\n" +
                               "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                               "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.");
                    LogManager.SaveLogEntry("Sepehr", "Cashes Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return false;
                }
                #endregion
            dgvData.DataSource = _CashiersInSelectedCash.
                Where(Data => Data.CashID == Convert.ToInt16(cboCashes.SelectedValue)).ToList();
            return true;
        }
        #endregion

        #endregion

    }
}