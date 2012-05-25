#region using

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Admission.Patients
{
    /// <summary>
    /// فرم نمایش لیست نوبت های ارائه شده به یك بیمار
    /// </summary>
    internal partial class frmPatientSchedules : Form
    {

        #region Fields

        #region readonly Int32 _CurrentPatListID
        /// <summary>
        /// شماره بیمار انتخاب شده
        /// </summary>
        private readonly Int32 _CurrentPatListID;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmPatientSchedules(Int32 PatListID)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _CurrentPatListID = PatListID;
            Opacity = 0.01;
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            if (!SearchPatientSch(_CurrentPatListID)) { Close(); return; }
            Cursor.Current = Cursors.Default;
            Opacity = 1;
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter && dgvData.SelectedRows.Count != 0)
            {
                // ToDo: فراخوانی فرم نوبت دهی برای نمایش نوبت انتخاب شده
            }
        }
        #endregion

        #region void btnCancel_Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean SearchPatientSch(Int32 PatListID)
        /// <summary>
        /// تابعی برای خواندن اطلاعات نوبت های بیمار انتخاب شده
        /// </summary>
        private Boolean SearchPatientSch(Int32 PatListID)
        {
            List<SchAppointments> SchData;
            try
            {
                IQueryable<SchAppointments> TempData =
                    DBLayerIMS.Manager.DBML.SchAppointments.Where(Data => Data.PatientIX == PatListID);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                SchData = TempData.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان جستجو  اطلاعات بیماران از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            if (SchData.Count == 0)
            {
                const String ErrorMessage = "برای بیمار انتخاب شده ، هیچ نوبتی در سیستم ثبت نشده است!";
                PMBox.Show(ErrorMessage, "عدم وجود نوبت!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            dgvData.DataSource = SchData;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Cells[ColAppName.Index].Value = DBLayerIMS.Schedules.SchAppList.
                    Where(Data => Data.ID == ((SchAppointments)row.DataBoundItem).ApplicationIX).First().Name;
                row.Cells[ColDate.Index].Value = Negar.PersianCalendar.Utilities.PersianDateConverter.
                    ToPersianDate(((SchAppointments)row.DataBoundItem).OccuredDateTime).ToWritten();
            }
            dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return true;
        }
        #endregion

        #endregion

    }
}