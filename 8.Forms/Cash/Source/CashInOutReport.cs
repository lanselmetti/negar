#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
    internal partial class frmCashInOutReport : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmCashInOutReport(Int32 CashLogID)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dgvCashes.AutoGenerateColumns = false;
            if (!FillCashInOutReport(CashLogID)) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region dgvCashes_CellFormatting
        private void dgvCashes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColPayType.Index)
            {
                if (Convert.ToBoolean(dgvCashes.Rows[e.RowIndex].Cells[ColRealType.Index].Value))
                {
                    e.Value = "ورود پول";
                    e.CellStyle.ForeColor = Color.Navy;
                }
                else
                {
                    e.Value = "خروج پول";
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Form Closing
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

            #region btnClose
            String TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillCashInOutReport(Int32 CashLogID)
        /// <summary>
        /// تابع خواندن اطلاعات فرم
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillCashInOutReport(Int32 CashLogID)
        {
            ColCashierName.DataSource = Negar.DBLayerPMS.Security.UsersList;
            ColCashierName.DataPropertyName = "CashierIX";
            ColCashierName.DisplayMember = "FullName";
            ColCashierName.ValueMember = "ID";
            try
            {
                txtCashName.Text = DBLayerIMS.Manager.DBML.CashLogs.Where(Data => Data.ID == CashLogID).
                    Select(Data => Data.Cash.Name).First();
                List<CashInputOutput> DataSource =
                    DBLayerIMS.Manager.DBML.CashInputOutputs.Where(Data => Data.CashLogIX == CashLogID).ToList();
                dgvCashes.DataSource = DataSource;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات ورود و خروج پول به صندوق انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Cash Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}