#region using

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Account;
using Sepehr.Forms.Cash.Properties;

#endregion

namespace Sepehr.Forms.Cash
{
    /// <summary>
    /// فرم مانیتور بیماران مراجعه كننده به صندوق
    /// </summary>
    public partial class frmCashPatients : Form
    {

        #region Fields

        #region DateTime _DateStart
        private DateTime _DateStart;
        #endregion

        #region DateTime _DateEnd
        private DateTime _DateEnd;
        #endregion

        #region Boolean _ShouldHidePayedRefs
        private Boolean _ShouldHidePayedRefs;
        #endregion

        #region Boolean _ShouldShowNoServiceRefs
        /// <summary>
        /// تعیین نمایش مراجعات فاقد خدمت
        /// </summary>
        private Boolean _ShouldShowNoServiceRefs;
        #endregion

        #region Boolean _ShouldExcludedRefs
        private Boolean _ShouldExcludedRefs;
        #endregion

        #region DataTable _SearchResult
        /// <summary>
        /// نتیجه جستجوی بیماران
        /// </summary>
        private DataTable _SearchResult;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmCashPatients()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (Negar.DBLayerPMS.Security.UsersList == null) { Close(); return; }
            #region Check User Permissions
            // بررسی سطح دسترسی كاربر جاری
            if (SecurityManager.CurrentUserID > 2 && !ReadCurrentUserPermissions()) { Close(); return; }
            #endregion
            if (!FillFormDataSource() || !ReadCurrentUserSettings()) { Close(); return; }
            ColRefDate.ShowTime = true;
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (BGWorker.IsBusy) BGWorker.CancelAsync();
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

        #region TimerRefresh_Tick
        private void TimerRefresh_Tick(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }
        #endregion

        #region dgvData_CellFormatting
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColValue.Index)
            {
                Int32 Value = Convert.ToInt32(((DataRowView)dgvData.Rows[e.RowIndex].DataBoundItem)["PatientPayable"]);
                if (Value == 0) e.Value = "قبض صفر";
                else e.Value = String.Format("{0:N0}", Value) + " ریال";
            }
        }
        #endregion

        #region dgvPatients_CellMouseDoubleClick
        private void dgvPatients_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex >= 0 && e.RowIndex >= 0)
                btnRecieveMoney_Click(null, null);
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter) btnRecieveMoney_Click(null, null);
        }
        #endregion

        #region dgvData_KeyDown
        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) e.Handled = true;
        }
        #endregion

        #region btnRecieveMoney_Click
        private void btnRecieveMoney_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                PMBox.Show("مراجعه ی بیماری برای دریافت از لیست انتخاب نشده!\nلطفاً مجدداً جستجو نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
            }
            Int32 RefID = Convert.ToInt32(((DataRowView)dgvData.SelectedRows[0].DataBoundItem)["RefID"]);
            frmManageTrans MyForm = new frmManageTrans(false, RefID, true, null);
            MyForm.Dispose();
            Activate();
            Select();
            BringToFront();
            Focus();
            btnRefresh_Click(null, null);
        }
        #endregion

        #region btnHide_Click
        private void btnHide_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                PMBox.Show("مراجعه ی بیماری برای مخفی سازی از لیست انتخاب نشده!\nلطفاً مجدداً جستجو نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
            }
            Int32 RefID = Convert.ToInt32(((DataRowView)dgvData.SelectedRows[0].DataBoundItem)["RefID"]);
            try
            {
                IQueryable<CashExcludedRef> Result =
                DBLayerIMS.Manager.DBML.CashExcludedRefs.Where(Data => Data.RefIX == RefID);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, Result);
                if (Result.Count() == 0)
                {
                    CashExcludedRef NewItem = new CashExcludedRef();
                    NewItem.RefIX = RefID;
                    DBLayerIMS.Manager.DBML.CashExcludedRefs.InsertOnSubmit(NewItem);
                    DBLayerIMS.Manager.DBML.SubmitChanges();
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در مخفی سازی مراجعه انتخاب شده!" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Cash Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
            btnRefresh_Click(null, null);
        }
        #endregion

        #region btnShow_Click
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                PMBox.Show("مراجعه ی بیماری برای آشكار سازی انتخاب نشده!\nلطفاً مجدداً جستجو نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
            }
            Int32 RefID = Convert.ToInt32(((DataRowView)dgvData.SelectedRows[0].DataBoundItem)["RefID"]);
            try
            {
                IQueryable<CashExcludedRef> Result =
                DBLayerIMS.Manager.DBML.CashExcludedRefs.Where(Data => Data.RefIX == RefID);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, Result);
                if (Result.Count() != 0)
                {
                    DBLayerIMS.Manager.DBML.CashExcludedRefs.DeleteOnSubmit(Result.First());
                    DBLayerIMS.Manager.DBML.SubmitChanges();
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در آشكار سازی مراجعه انتخاب شده!" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Cash Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
            btnRefresh_Click(null, null);
        }
        #endregion

        #region btnAccount_Click
        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                PMBox.Show("مراجعه ای برای نمایش حساب وجود ندارد! لطفاً مجدداً جستجو نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Int32 RefID = Convert.ToInt32(((DataRowView)dgvData.SelectedRows[0].DataBoundItem)["RefID"]);
            new frmAccount(RefID, false);
            BringToFront();
            Focus();
        }
        #endregion

        #region btnCash_Click
        private void btnCash_Click(object sender, EventArgs e)
        {
            new frmCashesReport();
        }
        #endregion

        #region btnRefresh_Click
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (BGWorker.IsBusy) return;
            Cursor = Cursors.WaitCursor;
            btnRefresh.Enabled = false;
            _DateStart = DateTime.Now.AddHours((-1) * txtBeginTime.Value);
            _DateEnd = DateTime.Now.AddHours(txtEndTime.Value + 1);
            _ShouldHidePayedRefs = !cBoxHidePayedRefs.Checked;
            _ShouldShowNoServiceRefs = cBoxShowNoServiceRefs.Checked;
            _ShouldExcludedRefs = cBoxShowExcludedRefs.Checked;
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region cBoxes_CheckedChanged
        private void cBoxes_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            btnRefresh_Click(null, null);
        }
        #endregion

        #region TextBoxes_PreviewKeyDown
        private void TextBoxes_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter) btnRefresh_Click(null, null);
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (!SearchCashPatients()) { e.Cancel = true; return; }
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            btnRefresh.Enabled = true;
            PanelCashPatients.Enabled = true;
            if (e.Cancelled) return;
            dgvData.DataSource = _SearchResult;
            if (dgvData.Rows.Count != 0) dgvData.Focus();
        }
        #endregion

        #region Form Closing
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BGWorker.IsBusy) BGWorker.CancelAsync();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean ReadCurrentUserPermissions()
        /// <summary>
        /// تابع بررسی سطوح دسترسی فرم
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean ReadCurrentUserPermissions()
        {
            #region # Check Lock License
            if (!LicenseHelper.GetSavedLicenses().Contains("530"))
            {
                if (ribbonBarOrders.Items.Contains(btnAccount)) ribbonBarOrders.Items.Remove(btnAccount);
            }
            #endregion

            #region Account Access (505)
            // مدیریت حساب مراجعات بیماران
            if (SecurityManager.GetCurrentUserPermission(505) == false)
                if (ribbonBarOrders.Items.Contains(btnAccount)) ribbonBarOrders.Items.Remove(btnAccount);
            #endregion
            return true;
        }
        #endregion

        #region Boolean ReadCurrentUserSettings()
        /// <summary>
        /// تابع خواندن تنظیمات كاربر جاری
        /// </summary>
        /// <returns></returns>
        private Boolean ReadCurrentUserSettings()
        {
            #region 601 - Hide Payed Refs
            // نمایش مراجعات دارای یكبار پرداخت
            List<UsersSetting> Setting601 = DBLayerIMS.Settings.
                CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 601).ToList();
            if (Setting601.Count > 0 && Setting601.First().Boolean == true) cBoxHidePayedRefs.Checked = true;
            #endregion

            #region 602 - Show No Service Refs
            // نمایش مراجعات فاقد خدمت ثبت شده
            List<UsersSetting> Setting602 = DBLayerIMS.Settings.
                CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 602).ToList();
            if (Setting602.Count > 0 && Setting602.First().Boolean == true)
                cBoxShowNoServiceRefs.Checked = true;
            #endregion

            #region 603 - Default Search Time
            // ساعت پیش فرض بازه ی زمانی جستجو در فرم بیماران صندوق
            List<UsersSetting> Setting603 = DBLayerIMS.Settings.
                CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 603).ToList();
            if (Setting603.Count > 0 && Setting603.First().Value != null)
            {
                String txtTime = Setting603.First().Value;
                for (Int32 i = 0; i < txtTime.Length; i++)
                    if (txtTime[i] == '-')
                    {
                        txtBeginTime.Value = Convert.ToInt32(txtTime.Substring(0, i));
                        txtEndTime.Value = Convert.ToInt32(txtTime.Substring(i + 1));
                        break;
                    }
            }
            #endregion

            #region 604 & 605 - Auto Refresh
            // آیا بیماران صندوق در بازه های زمانی مشخص به روز رسانی شوند
            // به صورت پیش فرض این قابلیت غیر فعال است
            List<UsersSetting> Setting604 = DBLayerIMS.Settings.
                CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 604).ToList();
            if (Setting604.Count > 0 && Setting604.First().Boolean == true)
            {
                List<UsersSetting> Setting605 =
                    DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 605).ToList();
                if (Setting605.Count > 0 && Setting605.First().Value != null)
                    TimerRefresh.Interval = Convert.ToInt32(Setting605.First().Value) * 60 * 1000;
                TimerRefresh.Enabled = true;
            }
            #endregion
            return true;
        }
        #endregion

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

            #region btnAccount
            TooltipText = ToolTipManager.GetText("btnRefAccount", "IMS");
            FormToolTip.SetSuperTooltip(btnAccount, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnRecieveMoney
            TooltipText = ToolTipManager.GetText("btnRecieveMoney", "IMS");
            FormToolTip.SetSuperTooltip(btnRecieveMoney, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCashReport
            TooltipText = ToolTipManager.GetText("btnCashReport", "IMS");
            FormToolTip.SetSuperTooltip(btnCashReport, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillFormDataSource()
        /// <summary>
        /// جستجوی بیماران صندوق بر اساس اطلاعات ارسال شده
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillFormDataSource()
        {
            lblCashier.Text = Negar.DBLayerPMS.Security.UsersList.Where(result => result.ID == SecurityManager.CurrentUserID).
                    Select(result => result.FullName).First();
            List<SP_SelectInsFullDataResult> DataSource = DBLayerIMS.Insurance.InsFullList.ToList();
            ColIns1.DataSource = DataSource.ToList();
            ColIns1.DataPropertyName = "Ins1IX";
            ColIns1.DisplayMember = "Name";
            ColIns1.ValueMember = "ID";
            ColIns2.DataSource = DataSource.ToList();
            ColIns2.DataPropertyName = "Ins2IX";
            ColIns2.DisplayMember = "Name";
            ColIns2.ValueMember = "ID";
            return true;
        }
        #endregion

        #region Boolean SearchCashPatients()
        /// <summary>
        /// جستجوی بیماران صندوق بر اساس اطلاعات ارسال شده
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean SearchCashPatients()
        {
            try
            {
                SqlParameter Param1 = new SqlParameter("@Param1", SqlDbType.NVarChar, 20);
                Param1.Value = _DateStart.Year + "/" + _DateStart.Month + "/" + _DateStart.Day + " " +
                    _DateStart.Hour + ":" + _DateStart.Minute + ":" + _DateStart.Second;
                SqlParameter Param2 = new SqlParameter("@Param2", SqlDbType.NVarChar, 20);
                Param2.Value = _DateEnd.Year + "/" + _DateEnd.Month + "/" + _DateEnd.Day + " " +
                    _DateEnd.Hour + ":" + _DateEnd.Minute + ":" + _DateEnd.Second;
                SqlParameter Param3 = new SqlParameter("@Param3", SqlDbType.Bit);
                Param3.Value = _ShouldHidePayedRefs;
                SqlParameter Param4 = new SqlParameter("@Param4", SqlDbType.Bit);
                Param4.Value = _ShouldShowNoServiceRefs;
                SqlParameter Param5 = new SqlParameter("@Param5", SqlDbType.Bit);
                Param5.Value = _ShouldExcludedRefs;
                SqlParameter[] ParamsCollection = new SqlParameter[5];
                ParamsCollection[0] = Param1;
                ParamsCollection[1] = Param2;
                ParamsCollection[2] = Param3;
                ParamsCollection[3] = Param4;
                ParamsCollection[4] = Param5;
                _SearchResult = DBLayerIMS.Manager.ExecuteQuery("EXEC [ImagingSystem].[Accounting].[SP_SelectCashPatients] " +
                    "@Param1 , @Param2 , @Param3 , @Param4 , @Param5", 20, ParamsCollection);
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات بیماران صندوق از بانك اطلاعات!" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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