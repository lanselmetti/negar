#region using

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Admission.Properties;

#endregion

namespace Sepehr.Forms.Admission.Patients
{
    /// <summary>
    /// فرم نمایش بیماران با نام و نام خانوادگی مشابه
    /// </summary>
    internal partial class frmSimilarPatients : Form
    {

        #region Fields & Properties

        #region public Int32 SelectedPatientListID
        /// <summary>
        /// شماره بیمار انتخاب شده
        /// </summary>
        public Int32 SelectedPatientListID { get; set; }
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmSimilarPatients(String FirstName, String LastName)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!SearchPatients(FirstName.Trim(), LastName.Trim())) { Cursor.Current = Cursors.Default; Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            FillPatientsDetails();
            Cursor.Current = Cursors.Default;
            SetControlsToolTipTexts();
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter && dgvData.SelectedRows.Count != 0)
                btnSelect_Click(sender, new EventArgs());
        }
        #endregion

        #region btnSelect_Click
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) DialogResult = DialogResult.Cancel;
            SelectedPatientListID = ((PatList)dgvData.SelectedRows[0].DataBoundItem).ID;
            DialogResult Result = PMBox.Show("با انتخاب بیمار مورد نظر ، اطلاعاتی كه برای بیمار وارد نموده اید " +
                "در نظر گرفته نمی شود و بیمار انتخاب شده نمایش داده خواهد شد.\n" +
                "آیا از این كار اطمینان دارید؟", "هشدار!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result == DialogResult.Yes) DialogResult = DialogResult.OK;
            else return;
            Dispose();
        }
        #endregion

        #region void btnCancel_Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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

            #region btnCancel
            String TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSelect
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnSelect, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region Boolean SearchPatients(String FirstName, String LastName)
        /// <summary>
        /// تابعی برای خواندن اطلاعات بیماران مشابه
        /// </summary>
        /// <returns>صحت جستجو</returns>
        private Boolean SearchPatients(String FirstName, String LastName)
        {
            List<PatList> SearchedPatList;
            try
            {
                IQueryable<PatList> TempSearchedPatList = Negar.DBLayerPMS.Manager.DBML.PatLists.
                    Where(Data => Data.LastName.StartsWith(LastName.Trim().Normalize()));
                if (!String.IsNullOrEmpty(FirstName))
                {
                    TempSearchedPatList = TempSearchedPatList.
                        Where(Data => Data.FirstName.StartsWith(FirstName.Trim().Normalize()));
                }
                Negar.DBLayerPMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempSearchedPatList);
                SearchedPatList = TempSearchedPatList.ToList();
                if (SearchedPatList.Count == 0) return false;
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
            dgvData.DataSource = SearchedPatList.ToList();
            return true;
        }
        #endregion

        #region void FillPatientsDetails()
        /// <summary>
        /// تابعی برای خواندن جزئیات اطلاعات بیماران جستجو شده
        /// </summary>
        private void FillPatientsDetails()
        {
            Int32 RowID = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Cells[ColRow.Index].Value = ++RowID;
                PatList PatData = (PatList)row.DataBoundItem;
                String PatFullName = PatData.LastName;
                if (!String.IsNullOrEmpty(PatData.FirstName))
                    PatFullName = PatData.FirstName + " " + PatFullName;
                row.Cells[ColFullName.Index].Value = PatFullName;
                if (PatData.IsMale != null)
                {
                    if (PatData.IsMale.Value) row.Cells[ColGender.Index].Value = "مرد";
                    else row.Cells[ColGender.Index].Value = "زن";
                }
                if (PatData.BirthDate != null)
                    row.Cells[ColAge.Index].Value = DateTime.Now.Year - PatData.BirthDate.Value.Year;
                try
                {
                    row.Cells[ColRefCount.Index].Value =
                        DBLayerIMS.Manager.DBML.RefLists.Where(Data => Data.PatientIX == PatData.ID).Count();
                    Int32? LastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(PatData.ID, true);
                    if (LastRefID != null && LastRefID.Value != 0)
                    {
                        RefList RefData = DBLayerIMS.Referrals.GetRefDataByID(LastRefID.Value);
                        if (RefData != null)
                        {
                            PersianDate PDate = PersianDateConverter.ToPersianDate(RefData.RegisterDate);
                            row.Cells[ColLastRef.Index].Value = PDate.Year + "/" + PDate.Month + "/" + PDate.Day +
                                " - " + PDate.Hour + ":" + PDate.Minute + ":" + PDate.Second;
                        }
                    }
                }
                #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Sepehr", "Admission Forms",
                        Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                }
                #endregion
            }
        }
        #endregion

        #endregion

    }
}