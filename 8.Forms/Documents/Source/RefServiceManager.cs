#region using

using System;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Documents
{
    /// <summary>
    /// فرم مدیریت اطلاعات خدمات بیمار برای كاربر ثبت كننده مدرك
    /// </summary>
    public partial class frmRefServiceManager : Form
    {

        #region Fields

        #region readonly Int32 _CurrentRefID
        /// <summary>
        /// كلید مراجعه جاری
        /// </summary>
        private readonly Int32 _CurrentRefID;
        #endregion

        #endregion

        #region Ctor
        public frmRefServiceManager(Int32 RefID)
        {
            InitializeComponent();
            dgvRefServices.AutoGenerateColumns = false;
            #region ColExpert
            ColExpert.DataSource = DBLayerIMS.Referrals.RefServPerformers.Where(Data => Data.IsExpert == true).ToList();
            ColExpert.DataPropertyName = "ExpertIX";
            ColExpert.DisplayMember = "FullName";
            ColExpert.ValueMember = "ID";
            #endregion
            #region ColPhysician
            ColPhysician.DataSource = DBLayerIMS.Referrals.RefServPerformers.Where(Data => Data.IsPhysician == true).ToList();
            ColPhysician.DataPropertyName = "PhysicianIX";
            ColPhysician.ValueMember = "ID";
            ColPhysician.DisplayMember = "FullName";
            #endregion
            _CurrentRefID = RefID;
            if (!FillCurrentRefServices()) { Close(); return; }
            dgvRefServices.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvRefServices.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region dgvRefServices_CellFormatting
        private void dgvRefServices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColServiceName.Index)
                e.Value = DBLayerIMS.Services.ServicesList.Where(Data => Data.ID ==
                    ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).ServiceIX).First().Name;
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ثبت تغییرات خدمات در بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            DialogResult = DialogResult.OK;
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean FillCurrentRefServices()
        /// <summary>
        /// تابعی برای خواندن اطلاعات خدمات مراجعه جاری
        /// </summary>
        /// <returns></returns>
        private Boolean FillCurrentRefServices()
        {
            try
            {
                IOrderedQueryable<RefService> TempServices =
                    DBLayerIMS.Manager.DBML.RefServices.Where(Data => Data.ReferralIX == _CurrentRefID &&
                    Data.IsActive).OrderBy(Data => Data.ID);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempServices);
                dgvRefServices.DataSource = TempServices.Where(Data => Data.IsActive).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات خدمات مراجعه از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}