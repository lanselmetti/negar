#region using

using System;
using System.Windows.Forms;

#endregion

namespace Sepehr.Forms.Schedules
{
    /// <summary>
    /// فرم انتخاب تاریخ
    /// </summary>
    internal partial class frmChangeDate : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmChangeDate()
        {
            InitializeComponent();
            FormDatePicker.SelectedDateTime = DateTime.Now;
        }
        #endregion

        #region Event Handlers

        #region Dates_Changed
        private void Dates_Changed(object sender, EventArgs e)
        {
            FormDatePicker.SelectedDateTimeChanged -= Dates_Changed;
            FormMonthView.SelectedDateTimeChanged -= Dates_Changed;
            if (((Control)sender).Name == "FormDatePicker")
                FormMonthView.SelectedDateTime = FormDatePicker.SelectedDateTime;
            else FormDatePicker.SelectedDateTime = FormMonthView.SelectedDateTime;
            FormDatePicker.SelectedDateTimeChanged += Dates_Changed;
            FormMonthView.SelectedDateTimeChanged += Dates_Changed;
        }
        #endregion

        #region FormMonthView_DoubleClick
        private void FormMonthView_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            GC.Collect();
        }
        #endregion

        #endregion

    }
}