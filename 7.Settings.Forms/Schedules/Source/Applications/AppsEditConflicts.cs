#region using
using System;
using System.Windows.Forms;
using Negar.PersianCalendar.Utilities;
#endregion

namespace Sepehr.Settings.Schedules.Applications
{
    /// <summary>
    /// فرم مدیریت فیلدهای اطلاعات اضافی نوبت دهی
    /// </summary>
    internal partial class frmAppsEditConflicts : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAppsEditConflicts()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                PersianDate PDate = PersianDateConverter.ToPersianDate(
                    ((DBLayerIMS.DataLayer.SchAppointments) row.DataBoundItem).OccuredDateTime);
                row.Cells[ColDate.Index].Value = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
            }
            dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
        #endregion

        #endregion

    }
}