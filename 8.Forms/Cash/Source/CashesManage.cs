#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Cash.Properties;

#endregion

namespace Sepehr.Forms.Cash
{
    /// <summary>
    /// فرم مدیریت صندوق ها
    /// </summary>
    public partial class frmCashesManage : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmCashesManage()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dgvCashes.AutoGenerateColumns = false;
            if (Negar.DBLayerPMS.Security.UsersList == null) { Close(); return; }
            #region Check User Permissions
            // بررسی سطح دسترسی كاربر جاری
            if (SecurityManager.CurrentUserID > 2 && !ReadCurrentUserPermissions()) { Close(); return; }
            #endregion
            if (!FillCashesStatus()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            btnCloseCash.Visible = false;
            btnOpenCash.Visible = false;
            cmsdgvData.Popup(-100, -100);
            cmsdgvData.ClosePopup();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region dgvCashes_PreviewKeyDown
        private void dgvCashes_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvCashes.SelectedCells.Count != 0)
            {
                dgvCashes_CellMouseClick(1,
                    new DataGridViewCellMouseEventArgs
                        (0, dgvCashes.SelectedCells[0].RowIndex, Left + Width - 150,
                        Top + dgvCashes.Top + dgvCashes.ColumnHeadersHeight + 29 +
                        dgvCashes.GetRowDisplayRectangle(dgvCashes.SelectedCells[0].RowIndex, true).Top,
                        new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
            }
        }
        #endregion

        #region dgvCashes_CellMouseClick
        private void dgvCashes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            System.Drawing.Point Position = MousePosition;
            // اگر درخواست كننده تابع جاری كلید ویندوز باشد و نه كلیك راست موس محل نمایش نموی كلیك راست تغییر می كند
            if (sender is Int32 && e.RowIndex >= 0 && e.ColumnIndex >= 0) Position = e.Location;
            else if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (((SP_SelectCashesStatusResult)dgvCashes.Rows[e.RowIndex].DataBoundItem).CashStatus == "باز")
                {
                    btnCashInOutReport.Visible = true;
                    btnCloseCash.Visible = true;
                    btnOpenCash.Visible = false;
                    btnInput.Visible = true;
                    btnOutput.Visible = true;
                }
                else
                {
                    btnCashInOutReport.Visible = false;
                    btnCloseCash.Visible = false;
                    btnOpenCash.Visible = true;
                    btnInput.Visible = false;
                    btnOutput.Visible = false;
                }
                dgvCashes.Rows[e.RowIndex].Selected = true;
                // منوی كلیك راست نمایش داده می شود
                cmsdgvData.Popup(Position);
            }
        }
        #endregion

        #region btnOpenOrCloseCash_Click
        private void btnOpenOrCloseCash_Click(object sender, EventArgs e)
        {
            if (dgvCashes.SelectedRows.Count == 0) return;
            frmCashOpenClose MyForm =
                new frmCashOpenClose(((SP_SelectCashesStatusResult)dgvCashes.SelectedRows[0].DataBoundItem).CashID);
            Activate();
            Select();
            BringToFront();
            Focus();
            if (MyForm.DialogResult == DialogResult.OK && !FillCashesStatus()) Close();
        }
        #endregion

        #region btnInputOrOutputMoney_Click
        private void btnInputOrOutputMoney_Click(Object sender, EventArgs e)
        {
            #region Handle Errors
            if (dgvCashes.SelectedRows.Count == 0) return;
            if (((SP_SelectCashesStatusResult)dgvCashes.SelectedRows[0].DataBoundItem).CashLogID == null)
            {
                PMBox.Show("صندوق انتخاب شده هنوز باز نشده تا ورود و خروج پولی داشته باشد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
            try
            {
                frmCashInOut MyForm;
                if (((ButtonItem)sender).Tag.ToString() == "Input")
                    MyForm = new frmCashInOut(
                                ((SP_SelectCashesStatusResult)dgvCashes.SelectedRows[0].DataBoundItem).CashLogID.Value, true);
                else MyForm = new frmCashInOut(
                    ((SP_SelectCashesStatusResult)dgvCashes.SelectedRows[0].DataBoundItem).CashLogID.Value, false);
                BringToFront();
                Focus();
                if (MyForm.DialogResult == DialogResult.OK && !FillCashesStatus()) { Close(); return; }
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات صندوق ها از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Cash Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
        }
        #endregion

        #region btnCashInOutReport_Click
        private void btnCashInOutReport_Click(object sender, EventArgs e)
        {
            if (dgvCashes.SelectedRows.Count == 0) return;
            if (((SP_SelectCashesStatusResult)dgvCashes.SelectedRows[0].DataBoundItem).CashLogID == null)
            {
                PMBox.Show("صندوق انتخاب شده هنوز باز نشده تا ورود و خروج پولی داشته باشد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new frmCashInOutReport(Convert.ToInt32(
                ((SP_SelectCashesStatusResult)dgvCashes.SelectedRows[0].DataBoundItem).CashLogID));
            BringToFront();
            Focus();
        }
        #endregion

        #region btnRefresh_Click
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!FillCashesStatus()) { Close(); return; }
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region btnHelp_Click
        /// <summary>
        /// روال نمایش راهنمایی برای فرم
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            GC.Collect();
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

            #region btnClose
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnRefresh
            TooltipText = ToolTipManager.GetText("btnRefresh", "IMS");
            FormToolTip.SetSuperTooltip(btnRefresh, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCloseCash
            TooltipText = ToolTipManager.GetText("btnCashCloseCash", "IMS");
            FormToolTip.SetSuperTooltip(btnCloseCash, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnOpenCash
            TooltipText = ToolTipManager.GetText("btnCashOpenCash", "IMS");
            FormToolTip.SetSuperTooltip(btnOpenCash, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnInput
            TooltipText = ToolTipManager.GetText("btnCashInput", "IMS");
            FormToolTip.SetSuperTooltip(btnInput, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnOutput
            TooltipText = ToolTipManager.GetText("btnCashOutput", "IMS");
            FormToolTip.SetSuperTooltip(btnOutput, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCashInOutReport
            TooltipText = ToolTipManager.GetText("btnCashInOutReport", "IMS");
            FormToolTip.SetSuperTooltip(btnCashInOutReport, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean ReadCurrentUserPermissions()
        /// <summary>
        /// تابع بررسی سطوح دسترسی فرم
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private static Boolean ReadCurrentUserPermissions()
        {
            #region Account Access (5620)
            // مدیریت حساب مراجعات بیماران
            if (SecurityManager.GetCurrentUserPermission(5620) == false)
            {
                PMBox.Show("كاربر جاری دسترسی به حساب بیماران تصویربرداری را ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #region Child Permissions

            #endregion

            #endregion
            return true;
        }
        #endregion

        #region Boolean FillCashesStatus()
        /// <summary>
        /// تابع خواندن اطلاعات وضعیت صندوق ها
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillCashesStatus()
        {
            List<SP_SelectCashesStatusResult> CashesStatus;
            try { CashesStatus = DBLayerIMS.Manager.DBML.SP_SelectCashesStatus(SecurityManager.CurrentUserID).ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات وضعیت صندوق ها از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Cash Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            if (CashesStatus.Count == 0)
            {
                PMBox.Show("صندوقی برای مدیریت كاربر جاری وجود ندارد!\n" +
                    "ابتدا صندوقی تعریف نموده و كاربر جاری را با آن ارتباط دهید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            dgvCashes.DataSource = CashesStatus;
            return true;
        }
        #endregion

        #endregion

    }
}