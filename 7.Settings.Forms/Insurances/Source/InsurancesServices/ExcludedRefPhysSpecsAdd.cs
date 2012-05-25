#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.Settings.Insurances.InsurancesServices
{
    /// <summary>
    /// فرم افزودن تخصص مجاز برای پزشك درخواست كننده
    /// </summary>
    internal partial class frmExcludedRefPhysSpecsAdd : Form
    {

        #region Fields

        #region readonly Int16 _CurrentInsID
        private readonly Int16 _CurrentInsID;
        #endregion

        #region List<SP_SelectCategoriesResult> _CategoriesDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی كومبو باكس طبقه بندی خدمات
        /// </summary>
        private List<DBLayerIMS.DataLayer.SP_SelectCategoriesResult> _CategoriesDataSource;
        #endregion

        #region List<SP_SelectServicesListResult> _ServicesDataSource
        /// <summary>
        /// لیست خدمات ثبت شده در سیستم
        /// </summary>
        private List<SP_SelectServicesListResult> _ServicesDataSource;
        #endregion

        #region List<SP_SelectRefPhysiciansSpecsResult> _SpecsDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی تخصص ها
        /// </summary>
        private List<SP_SelectRefPhysiciansSpecsResult> _SpecsDataSource;
        #endregion

        #endregion

        #region Ctor
        public frmExcludedRefPhysSpecsAdd(Int16 InsID)
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
            #region Add Selected Services For Default Performers
            Boolean IsAnyServiceSelected = false;
            for (Int32 i = 0; i < dgvData.Rows.Count; i++)
            {
                if (dgvData.Rows[i].Cells[ColSelection.Index].Value != null &&
                    Convert.ToBoolean(dgvData.Rows[i].Cells[ColSelection.Index].Value))
                {
                    IsAnyServiceSelected = true;
                    Int16 ServiceID = ((SP_SelectServicesListResult)dgvData.Rows[i].DataBoundItem).ID;
                    if (cboSpecs.SelectedIndex == 0)
                    {
                        foreach (SP_SelectRefPhysiciansSpecsResult Spec in _SpecsDataSource.Where(Data => Data.ID > 0))
                        {
                            IQueryable<InsRefPhysSpecExclude> Collection = DBLayerIMS.Manager.DBML.InsRefPhysSpecExcludes.
                            Where(Data => Data.InsIX == _CurrentInsID && Data.ServiceIX == ServiceID &&
                                Data.RefPhysSpecID == Spec.ID);
                            if (Collection.Count() == 0)
                            {
                                InsRefPhysSpecExclude NewItem = new InsRefPhysSpecExclude();
                                NewItem.InsIX = _CurrentInsID;
                                NewItem.ServiceIX = ServiceID;
                                NewItem.RefPhysSpecID = Spec.ID.Value;
                                DBLayerIMS.Manager.DBML.InsRefPhysSpecExcludes.InsertOnSubmit(NewItem);
                            }
                        }
                    }
                    else
                    {
                        Int16 SpecID = Convert.ToInt16(cboSpecs.SelectedValue);
                        IQueryable<InsRefPhysSpecExclude> Collection = DBLayerIMS.Manager.DBML.InsRefPhysSpecExcludes.
                            Where(Data => Data.InsIX == _CurrentInsID && Data.ServiceIX == ServiceID &&
                                Data.RefPhysSpecID == SpecID);
                        if (Collection.Count() == 0)
                        {
                            InsRefPhysSpecExclude NewItem = new InsRefPhysSpecExclude();
                            NewItem.InsIX = _CurrentInsID;
                            NewItem.ServiceIX = ServiceID;
                            NewItem.RefPhysSpecID = Convert.ToInt16(cboSpecs.SelectedValue);
                            DBLayerIMS.Manager.DBML.InsRefPhysSpecExcludes.InsertOnSubmit(NewItem);
                        }
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
                const String ErrorMessage = "امكان ثبت اطلاعات تخصص های مجاز در بانك وجود ندارد.\n" +
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
            _SpecsDataSource = Negar.DBLayerPMS.ClinicData.RefPhysicianSpecsList;
            if (_SpecsDataSource == null) return false;
            if (_SpecsDataSource.Where(Data => Data.IsActive == 1).ToList().Count == 1)
            {
                PMBox.Show("هیچ تخصصی در سیستم ثبت نگردیده است!\n" +
                    "لطفاً ابتدا تخصصی برای پزشكان درخواست كننده تعریف نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            cboCategories.DataSource = _CategoriesDataSource;
            cboSpecs.DataSource = _SpecsDataSource.Where(Data => Data.IsActive == 1).ToList();
            return true;
        }
        #endregion

        #endregion

    }
}