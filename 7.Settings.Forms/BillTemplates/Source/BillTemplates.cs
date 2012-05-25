#region using
using System;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.BillTemplates.Properties;
#endregion

namespace Sepehr.Settings.BillTemplates
{
    /// <summary>
    /// فرم مدیریت قالب قبوض مراجعات تصویربرداری
    /// </summary>
    public partial class frmBillTemplates : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmBillTemplates()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillFormData()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBillTemplatesManage MyForm = new frmBillTemplatesManage();
            if (MyForm.DialogResult == DialogResult.OK) if (!FillFormData()) { Close(); return; }
            BringToFront();
            Focus();
            MyForm.Dispose();
        }
        #endregion

        #region btnEdit_Click
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) return;
            frmBillTemplatesManage MyForm =
                new frmBillTemplatesManage(Convert.ToInt16(dgvData.SelectedRows[0].Cells[ColID.Index].Value), false);
            if (MyForm.DialogResult == DialogResult.OK) if (!FillFormData()) { Close(); return; }
            BringToFront();
            Focus();
            MyForm.Dispose();
        }
        #endregion

        #region btnCopy_Click
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) return;
            frmBillTemplatesManage MyForm =
                new frmBillTemplatesManage(Convert.ToInt16(dgvData.SelectedRows[0].Cells[ColID.Index].Value), true);
            if (MyForm.DialogResult == DialogResult.OK) if (!FillFormData()) { Close(); return; }
            BringToFront();
            Focus();
            MyForm.Dispose();
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

        #region dgvData_CellMouseDoubleClick
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.Button != MouseButtons.Left) return;
            btnEdit_Click(null, null);
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) return;
            Int32 RowIndex = dgvData.SelectedCells[0].RowIndex;
            DialogResult Dr = PMBox.Show("آیا مایلید ردیف زیر حذف گردد:\n\"" +
                dgvData.Rows[RowIndex].Cells[2].Value +
                "\"\nبا حذف این قالب ساختار قالب از بانك حذف خواهد شد و امكان بازگشت تغییرات وجود ندارد.",
                "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            DBLayerIMS.Manager.DBML.BillTemplates.DeleteAllOnSubmit(DBLayerIMS.Manager.DBML.BillTemplates.
                Where(Data => Data.ID == Convert.ToInt16(dgvData.Rows[RowIndex].Cells[0].Value)));
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان حذف قالب قبض انتخاب شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (!FillFormData()) { Close(); return; }
        }
        #endregion

        #region btnExport_Click
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog.Filter = "فایل اكسل (*.xls)|*.xls";
            DialogResult Result = SaveFileDialog.ShowDialog();
            if (Result != DialogResult.OK) return;
            String FilePath = SaveFileDialog.FileName;
            try
            {
                if (File.Exists(FilePath)) File.Delete(FilePath);
                BillTemplate BillTemplateData = DBLayerIMS.Manager.DBML.BillTemplates.
                    Where(Data => Data.ID == Convert.ToInt16(dgvData.SelectedRows[0].Cells[ColID.Index].Value)).ToList().First();
                Binary TempData = BillTemplateData.TemplateData;
                File.Create(FilePath).Close();
                if (TempData != null) File.WriteAllBytes(FilePath, TempData.ToArray());
            }
            #region Catch

            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان ذخیره كردن فایل در مسیر وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا دسترسی لازم برای ذخیره كردن فایل در مسیر انتخاب شده در ویندوز وجود دارد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }

            #endregion
            return;
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

            #region btnAddTemplate
            TooltipText = ToolTipManager.GetText("btnAddBillTemplate", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillFormData()
        /// <summary>
        /// تابع خواندن اطلاعات قالب های قبوض
        /// </summary>
        /// <returns></returns>
        private Boolean FillFormData()
        {
            try
            {
                dgvData.DataSource = DBLayerIMS.Manager.DBML.BillTemplates.
                    Select(Data => new { Data.ID, Data.IsActive, Data.Name, Data.Description }).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات قالب های قبوض از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            dgvData.Refresh();
            return true;
        }
        #endregion

        #endregion

    }
}