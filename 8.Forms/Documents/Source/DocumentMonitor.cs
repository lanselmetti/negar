#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Documents.Classes;
using Sepehr.Forms.Documents.Properties;

#endregion

namespace Sepehr.Forms.Documents
{
    /// <summary>
    /// فرم مانیتور بیماران مراجعه كننده به جوابدهی برای ثبت مدرك
    /// </summary>
    public partial class frmDocumentMonitor : Form
    {

        #region Fields

        #region DateTime _DateStart
        private DateTime _DateStart;
        #endregion

        #region DateTime _DateEnd
        private DateTime _DateEnd;
        #endregion

        #region Boolean _ShowNoServiceRefs
        private Boolean _ShowNoServiceRefs;
        #endregion

        #region Int16? _ServPhysID
        private Int16? _ServPhysID;
        #endregion

        #region Int16? _ServCatID
        private Int16? _ServCatID;
        #endregion

        #region List<SP_SelectDocumentPatientsResult> _SearchResult
        /// <summary>
        /// فیلد نتیجه جستجوب اطلاعات مدارك بیماران
        /// </summary>
        private List<SP_SelectDocumentPatientsResult> _SearchResult;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmDocumentMonitor()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Negar.DBLayerPMS.Security.UsersList == null) { Close(); return; }
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            #region Security Methods
            if (!ReadCurrentUserPermissions() || !ReadCurrentUserSettings()) { Close(); return; }
            #endregion
            if (!FillFormBaseDataSources()) { Close(); return; }
            btnRefresh_Click(null, null);
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            cboRefPhysician.ComboBoxEx.SelectedIndexChanged += (btnRefresh_Click);
            cboServiceCat.ComboBoxEx.SelectedIndexChanged += (btnRefresh_Click);
            Opacity = 1;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region dgvPatients_CellMouseDoubleClick
        private void dgvPatients_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex >= 0 && e.RowIndex >= 0) AddNewDocument();
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (dgvData.SelectedRows.Count != 0 && e.KeyData == Keys.Enter) AddNewDocument();
        }
        #endregion

        #region dgvData_KeyDown
        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) e.Handled = true;
        }
        #endregion

        #region btnRefresh_Click
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (BGWorker.IsBusy) return;
            Cursor = Cursors.WaitCursor;
            btnRefresh.Enabled = false;
            _DateStart = DateTime.Now.AddHours((-1) * txtBeginTime.Value);
            _DateEnd = DateTime.Now.AddHours(-1 * txtEndTime.Value);
            _ShowNoServiceRefs = cBoxShowNoServiceRefs.Checked;
            _ServPhysID = null;
            if (cboRefPhysician.ComboBoxEx.SelectedIndex != 0)
                _ServPhysID = Convert.ToInt16(cboRefPhysician.ComboBoxEx.SelectedValue);
            _ServCatID = null;
            if (cboServiceCat.ComboBoxEx.SelectedIndex != 0)
                _ServCatID = Convert.ToInt16(cboServiceCat.ComboBoxEx.SelectedValue);
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
            if (!SearchDocPatients()) { e.Cancel = true; return; }
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            btnRefresh.Enabled = true;
            PanelDocPatients.Enabled = true;
            if (e.Cancelled) return;
            dgvData.DataSource = _SearchResult;
            if (dgvData.Rows.Count != 0) dgvData.Focus();
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

        #region Form_Closing
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

            #region btnClose
            String TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnRefresh
            TooltipText = ToolTipManager.GetText("btnRefresh", "IMS");
            FormToolTip.SetSuperTooltip(btnRefresh, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region cBoxShowNoServiceRefs
            TooltipText = ToolTipManager.GetText("cBoxDocMonitorShowNoServiceRefs", "IMS");
            FormToolTip.SetSuperTooltip(cBoxShowNoServiceRefs, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region cboRefPhysician
            TooltipText = ToolTipManager.GetText("cboDocMonitorPhysician", "IMS");
            FormToolTip.SetSuperTooltip(cboRefPhysician, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region cboServiceCat
            TooltipText = ToolTipManager.GetText("cboDocMonitorServiceCat", "IMS");
            FormToolTip.SetSuperTooltip(cboServiceCat, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region @@ Security Methods @@

        #region static Boolean ReadCurrentUserPermissions()
        /// <summary>
        /// تابع بررسی سطوح دسترسی فرم
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private static Boolean ReadCurrentUserPermissions()
        {
            // مدیریت مدارك مراجعات بیمار
            if (SecurityManager.GetCurrentUserPermission(506) == false)
            {
                PMBox.Show("كاربر جاری دسترسی لازم برای مشاهده مدارك بیماران را ندارد.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            // افزودن مدرك جدید برای مراجعه
            if (SecurityManager.GetCurrentUserPermission(5061) == false)
            {
                PMBox.Show("كاربر جاری دسترسی لازم برای افزودن مدرك به مراجعات بیماران را ندارد!",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop); return false;
            }
            return true;
        }
        #endregion

        #region Boolean ReadCurrentUserSettings()
        /// <summary>
        /// تابع خواندن تنظیمات كاربر برای فرم
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean ReadCurrentUserSettings()
        {
            #region 706
            // ساعت پیش فرض بازه ی زمانی جستجو در فرم بیماران جوابدهی.
            List<UsersSetting> Setting706 = DBLayerIMS.Settings.CurrentUserSettingsFullList.
                Where(Data => Data.SettingIX == 706).ToList();
            if (Setting706.Count > 0 && Setting706.First().Value != null)
            {
                String txtTime = Setting706.First().Value;
                for (Int32 i = 0; i < txtTime.Length; i++)
                    if (txtTime[i] == '-')
                    {
                        txtBeginTime.Value = Convert.ToInt32(txtTime.Substring(0, i));
                        txtEndTime.Value = Convert.ToInt32(txtTime.Substring(i + 1));
                        break;
                    }
            }
            #endregion

            #region 707
            // نمایش مراجعات فاقد خدمت ثبت شده به صورت پیش فرض
            List<UsersSetting> Setting707 = DBLayerIMS.Settings.CurrentUserSettingsFullList.
                Where(Data => Data.SettingIX == 707).ToList();
            if (Setting707.Count > 0 && Setting707.First().Boolean == true)
                cBoxShowNoServiceRefs.Checked = true;
            #endregion
            return true;
        }
        #endregion

        #endregion

        #region Boolean FillFormBaseDataSources()
        private Boolean FillFormBaseDataSources()
        {
            cboRefPhysician.ComboBoxEx.DrawMode = DrawMode.Normal;
            cboRefPhysician.ComboBoxEx.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRefPhysician.ComboBoxEx.FlatStyle = FlatStyle.Standard;
            cboRefPhysician.ComboBoxEx.Font = new System.Drawing.Font("Tahoma", 8, System.Drawing.FontStyle.Bold);
            cboRefPhysician.ComboBoxEx.DropDownHeight = 300;
            cboServiceCat.ComboBoxEx.DrawMode = DrawMode.Normal;
            cboServiceCat.ComboBoxEx.DropDownStyle = ComboBoxStyle.DropDownList;
            cboServiceCat.ComboBoxEx.FlatStyle = FlatStyle.Standard;
            cboServiceCat.ComboBoxEx.Font = new System.Drawing.Font("Tahoma", 8, System.Drawing.FontStyle.Bold);
            cboServiceCat.ComboBoxEx.DropDownHeight = 300;
            List<SP_SelectPerformersResult> PerformersData = DBLayerIMS.Referrals.RefServPerformers;
            List<SP_SelectCategoriesResult> ServiceCatData = DBLayerIMS.Services.ServCategoriesList;
            if (PerformersData == null || ServiceCatData == null) return false;
            cboRefPhysician.ComboBoxEx.DataSource = PerformersData.
                    Where(Data => Data.IsPhysician == true && Data.IsActive == true).ToList();
            cboServiceCat.ComboBoxEx.DataSource = ServiceCatData.
                Where(Data => Data.IsActive == true || Data.ID == null).ToList();
            cboRefPhysician.ComboBoxEx.DisplayMember = "FullName";
            cboRefPhysician.ComboBoxEx.ValueMember = "ID";
            cboServiceCat.ComboBoxEx.DisplayMember = "Name";
            cboServiceCat.ComboBoxEx.ValueMember = "ID";
            return true;
        }
        #endregion

        #region Boolean SearchDocPatients()
        /// <summary>
        /// جستجوی بیماران صندوق بر اساس اطلاعات ارسال شده
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean SearchDocPatients()
        {
            try
            {
                _SearchResult = DBLayerIMS.Manager.DBML.
                    SP_SelectDocumentPatients(_DateStart, _DateEnd, _ShowNoServiceRefs, _ServPhysID, _ServCatID).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات بیماران ثبت مدرك از بانك اطلاعات!" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.", "خطا!");
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region void AddNewDocument()
        /// <summary>
        /// تابع افزودن مدرك جدید برای مراجعه بیمار
        /// </summary>
        private void AddNewDocument()
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                PMBox.Show("مراجعه ای برای نمایش حساب انتخاب نشده!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DocumentHelper.AddNewDocument(((SP_SelectDocumentPatientsResult)dgvData.SelectedRows[0].DataBoundItem).RefID);
            if (!SearchDocPatients()) { Close(); return; }
            BringToFront();
            Focus();
        }
        #endregion

        #endregion

    }
}