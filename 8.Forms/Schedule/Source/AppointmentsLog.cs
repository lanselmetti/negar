#region using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Schedules
{
    ///<summary>
    /// فرم نمایش سابقه تغییرات نوبت دهی
    ///</summary>
    public partial class frmAppointmentsLog : Form
    {
        #region Fields

        #region readonly Int32 _AppointmentID
        /// <summary>
        /// نگهدارنده محلی شناسه نوبت 
        /// </summary>
        private readonly Int32 _AppointmentID;
        #endregion

        #region List<SP_SelectLogEventsResult> LogEventsList
        /// <summary>
        /// لیست سابقه خوانده شده از بانك اطلاعاتی
        /// </summary>
        private List<SP_SelectLogEventsResult> LogEventsList;
        #endregion

        #endregion

        #region Ctor
        ///<summary>
        /// سازنده پیش فرض فرم
        ///</summary>
        ///<param name="AppointmentID">شناسه نوبت</param>
        public frmAppointmentsLog(Int32 AppointmentID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            dgvAppointmentLog.AutoGenerateColumns = false;
            ShowDialog();
        }
        #endregion

        #region EventHandler

        #region frmAppointmentsLog_Shown
        private void frmAppointmentsLog_Shown(object sender, EventArgs e)
        {
            if (!FillAppointmentLog(_AppointmentID)) { Close(); return; }
        }
        #endregion

        #region cboSchLog_SelectedIndexChanged
        private void cboSchLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSchLog.SelectedIndex == 0)
            {
                dgvAppointmentLog.DataSource = LogEventsList;
                return;
            }
            dgvAppointmentLog.DataSource =
                LogEventsList.Where(Data => Data.CategoryIX ==
                    Convert.ToByte(cboSchLog.SelectedValue)).ToList();
        }
        #endregion

        #region dgvAppointmentLog_CellPainting
        private void dgvAppointmentLog_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex % 2 == 0) e.CellStyle.BackColor = Color.LightGray;
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean FillAppointmentLog(Int32 AppointmentID)
        /// <summary>
        /// تابع پر كردن منابع داده فرم
        /// </summary>
        /// <param name="AppointmentID">شناسه نوبت</param>
        /// <returns></returns>
        private Boolean FillAppointmentLog(Int32 AppointmentID)
        {
            cboSchLog.DataSource = DBLayerIMS.Schedules.SchLogCategoriesList;
            LogEventsList = DBLayerIMS.Manager.DBML.SP_SelectLogEvents(AppointmentID).
                 OrderByDescending(Data => Data.Date).OrderByDescending(Data2 => Data2.ID).ToList();
            dgvAppointmentLog.DataSource = LogEventsList;
            return true;
        }
        #endregion

        #endregion
    }
}
