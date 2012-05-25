#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.Settings.Insurances.InsurancesServices
{
    /// <summary>
    /// فرم افزودن پزشك درخواست كننده مجاز
    /// </summary>
    internal partial class frmExcludedRefPhysAdd : Form
    {

        #region Fields

        #region readonly Int16 _CurrentInsID
        private readonly Int16 _CurrentInsID;
        #endregion

        #region List<SP_SelectCategoriesResult> _CategoriesDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی كومبو باكس طبقه بندی خدمات
        /// </summary>
        private List<SP_SelectCategoriesResult> _CategoriesDataSource;
        #endregion

        #region List<SP_SelectServicesListResult> _ServicesDataSource
        /// <summary>
        /// لیست خدمات ثبت شده در سیستم
        /// </summary>
        private List<SP_SelectServicesListResult> _ServicesDataSource;
        #endregion

        #endregion

        #region Ctor
        public frmExcludedRefPhysAdd(Int16 InsID)
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _CurrentInsID = InsID;
            if (!FillBaseDataSource()) { Close(); return; }
            cboCategories_SelectedIndexChanged(null, null);
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region cboCategories_SelectedIndexChanged
        private void cboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategories.SelectedIndex == 0) dgvData.DataSource =
                _ServicesDataSource.Where(Data => Data.IsActive).OrderBy(Data => Convert.ToInt32(Data.Code)).ToList();
            else dgvData.DataSource =
                _ServicesDataSource.Where(Data => Data.IsActive &&
                    Data.CategoryIX == Convert.ToInt16(cboCategories.SelectedValue))
                    .OrderBy(Data => Convert.ToInt32(Data.Code)).ToList();
        }
        #endregion

        #region cboExcludedSpecs_Enter
        private void cboExcludedSpecs_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage =
                InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
        }
        #endregion

        #region cboRefPhysician_KeyPress
        /// <summary>
        /// این روال ، منبع داده پزشكان را در هنگامی كه اطلاعات بیش از 2 كاراكتر باشد تكمیل می نماید
        /// </summary>
        private void cboRefPhysician_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') { SelectNextControl(this, true, true, true, true); return; }
            if (!Char.IsLetterOrDigit(e.KeyChar)) { e.Handled = true; return; }
            // تنها بعد از ورود كاراكتر دوم این روال اجرا می شود
            if (cboRefPhysician.Text.Length != 1) return;
            cboRefPhysician.Text += e.KeyChar.ToString();
            List<Negar.DBLayerPMS.PhysicianFullData> PhysData = null;
            #region Search MedicalID
            if (Char.IsDigit(e.KeyChar))
            {
                PhysData = Negar.DBLayerPMS.ClinicData.GetRefPhysFullDataByValue(cboRefPhysician.Text.Normalize(), true);
                if (PhysData == null) return;
                if (PhysData.Count == 1) { cboRefPhysician_NoDataFound(String.Empty, null); return; }
            }
            #endregion

            #region Search LastName
            else if (Char.IsLetter(e.KeyChar))
            {
                PhysData = Negar.DBLayerPMS.ClinicData.GetRefPhysFullDataByValue(cboRefPhysician.Text.Normalize(), false);
                if (PhysData == null) return;
                if (PhysData.Count == 1) { cboRefPhysician_NoDataFound(String.Empty, null); return; }
            }
            #endregion

            if (PhysData == null) return;
            cboRefPhysician.DataSource = PhysData;
            cboRefPhysician.DisplayMember = "FullTitle";
            cboRefPhysician.ValueMember = "ID";
        }
        #endregion

        #region cboRefPhysician_NoDataFound
        private void cboRefPhysician_NoDataFound(object sender, EventArgs e)
        {
            try
            {
                if (cboRefPhysician.Text.Length == 0) return;
                cboRefPhysician.DataSource = null;
                cboRefPhysician.Text = String.Empty;
                cboCategories.Focus();
                cboCategories.Select();
                cboRefPhysician.Focus();
                cboRefPhysician.Select();
            }
            catch { cboRefPhysician.DataSource = null; }
        }
        #endregion

        #region btnAll_Click
        private void btnAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows) row.Cells[ColSelection.Index].Value = true;
        }
        #endregion

        #region btnNone_Click
        private void btnNone_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows) row.Cells[ColSelection.Index].Value = false;
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cboRefPhysician.SelectedValue == null)
            {
                const String ErrorMessage = "پزشكان درخواست كننده ای انتخاب نشده تا پزشك مجاز ثبت شود.";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            #region Add Selected Services For Default Performers
            Boolean IsAnyServiceSelected = false;
            for (Int32 i = 0; i < dgvData.Rows.Count; i++)
            {
                if (dgvData.Rows[i].Cells[ColSelection.Index].Value != null &&
                    Convert.ToBoolean(dgvData.Rows[i].Cells[ColSelection.Index].Value))
                {
                    IsAnyServiceSelected = true;
                    Int16 ServiceID = ((SP_SelectServicesListResult)dgvData.Rows[i].DataBoundItem).ID;
                    Int16 PhysID = Convert.ToInt16(cboRefPhysician.SelectedValue);
                    IQueryable<InsPhysicianExclude> Collection = DBLayerIMS.Manager.DBML.InsPhysicianExcludes.
                        Where(Data => Data.InsIX == _CurrentInsID && Data.ServiceIX == ServiceID &&
                            Data.RefPhysID == PhysID);
                    if (Collection.Count() == 0)
                    {
                        InsPhysicianExclude NewItem = new InsPhysicianExclude();
                        NewItem.InsIX = _CurrentInsID;
                        NewItem.ServiceIX = ServiceID;
                        NewItem.RefPhysID = PhysID;
                        DBLayerIMS.Manager.DBML.InsPhysicianExcludes.InsertOnSubmit(NewItem);
                    }
                }
            }

            #region Check If No Service Added
            if (!IsAnyServiceSelected)
            {
                PMBox.Show("هیچ خدمتی انتخاب نشده است! بررسی نمایید.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            #endregion
            #endregion
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ثبت پزشكان درخواست كننده مجاز در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            DialogResult = DialogResult.OK;
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean FillBaseDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات گروه های خدمات از بانك
        /// </summary>
        private Boolean FillBaseDataSource()
        {
            #region Fill Data Sources
            _CategoriesDataSource = DBLayerIMS.Services.ServCategoriesList;
            if (_CategoriesDataSource == null) return false;
            _CategoriesDataSource[0].Name = "(همه موارد)";
            _ServicesDataSource = DBLayerIMS.Services.ServicesList;
            if (_ServicesDataSource == null) return false;
            #endregion

            cboCategories.DataSource = _CategoriesDataSource;
            return true;
        }
        #endregion

        #endregion

    }
}