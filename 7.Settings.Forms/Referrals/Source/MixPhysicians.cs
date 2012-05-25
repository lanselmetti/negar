#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    public partial class frmMixPhysicians : Form
    {

        #region Fields

        #region IQueryable<RefPhysician> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private IQueryable<RefPhysician> _DataSource;
        #endregion

        #region Int32? _LastSelectedMergeRow
        /// <summary>
        /// كلید آخرین ردیفی كه برای ادغام انتخاب شده یا تهی برای عدم انتخاب
        /// </summary>
        private Int32? _LastSelectedMergeRow;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmMixPhysicians()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (!FillDataSource()) { Close(); return; }
            ColRefCount.ValueType = typeof(Int32);
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region From_Shown
        private void From_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
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

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            #region Handle ColMergeTo Selection
            if (e.Button == MouseButtons.Left && e.ColumnIndex == ColMergeTo.Index)
            {
                // حالتی كه هیچ گزینه ای قبلاً انتخاب نشده است
                if (_LastSelectedMergeRow == null) dgvData.Rows[e.RowIndex].Cells[ColMergeTo.Index].Value = true;
                else
                {
                    if (_LastSelectedMergeRow.Value == e.RowIndex)
                    {
                        dgvData.Rows[e.RowIndex].Cells[ColMergeTo.Index].Value = false;
                        _LastSelectedMergeRow = null;
                        dgvData.EndEdit();
                        return;
                    }
                    dgvData.Rows[_LastSelectedMergeRow.Value].Cells[ColMergeTo.Index].Value = false;
                    if (dgvData.Rows[e.RowIndex].Cells[ColMergeTo.Index].Value == null ||
                        !Convert.ToBoolean(dgvData.Rows[e.RowIndex].Cells[ColMergeTo.Index].Value))
                        dgvData.Rows[e.RowIndex].Cells[ColMergeTo.Index].Value = true;
                    else dgvData.Rows[e.RowIndex].Cells[ColMergeTo.Index].Value = false;
                }
                _LastSelectedMergeRow = e.RowIndex;
                dgvData.EndEdit();
                return;
            }
            #endregion
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnMix.Focus();
            dgvData.EndEdit();
            List<Int32> ToDeleteIDList = new List<Int32>();
            Int32 ToReplaceID = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.IsNewRow) continue;
                if (Convert.ToBoolean(row.Cells[ColMergeSelection.Index].Value))
                    ToDeleteIDList.Add(Convert.ToInt32(row.Cells[ColID.Index].Value));
                else if (Convert.ToBoolean(row.Cells[ColMergeTo.Index].Value))
                    ToReplaceID = Convert.ToInt32(row.Cells[ColID.Index].Value);
            }
            if (ToReplaceID == 0 || ToDeleteIDList.Count == 0)
            {
                PMBox.Show("هیچ پزشكی برای كپی برداری انتخاب نشده است!", "عدم انتخاب پزشك!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            foreach (Int32 ToDeleteID in ToDeleteIDList)
                try { Negar.DBLayerPMS.Manager.DBML.SP_MixRefPhysicians(ToDeleteID, ToReplaceID); }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان ادغام پزشكان انتخاب شده وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Referrals Setting", Ex.Message + "\n" + Ex.StackTrace,
                        EventLogEntryType.Error); return;
                }
                #endregion

            for (Int32 i = dgvData.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dgvData.Rows[i];
                if (row.IsNewRow) continue;
                if (Convert.ToBoolean(row.Cells[ColMergeSelection.Index].Value)) dgvData.Rows.RemoveAt(i);
            }
            PMBox.Show("ادغام پزشكان انتخاب شده با موفقیت انجام شد.", "موفقیت در ادغام پزشكان.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnMix, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
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
                List<SP_SelectRefPhysiciansSpecsResult> Specs =
                    Negar.DBLayerPMS.Manager.DBML.SP_SelectRefPhysiciansSpecs().OrderBy(Data => Data.Title).ToList();
                _DataSource = Negar.DBLayerPMS.Manager.DBML.RefPhysicians.OrderBy(Data => Data.LastName);
                foreach (RefPhysician row in _DataSource)
                {
                    dgvData.Rows.Add(row.ID, row.IsActive, null, null,
                        DBLayerIMS.Manager.DBML.RefLists.Where(Data => Data.ReferPhysicianIX == row.ID).Count(),
                        row.IsMale, row.FirstName, row.LastName, row.MedicalID,
                        Specs.Where(Data => Data.ID == row.SpecialtyIX).First().Title);
                }
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

        #endregion

    }
}