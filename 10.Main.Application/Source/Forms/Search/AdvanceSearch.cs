#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.UI.Controls;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms.Search
{
    /// <summary>
    /// فرم جستجوی پیشرفته اطلاعات بیماران
    /// </summary>
    public partial class frmAdvancedSearch : Form
    {

        #region Fields & Enums

        #region enum FieldPart
        private enum FieldPart
        {
            PatientsSearch = 0, ReferralsSearch = 1, RefServices = 2, DocumentsSearch = 3,
        }
        #endregion

        #region enum FieldsType
        private enum FieldsType
        {
            String = 1, Number = 2, Date = 3, Time = 4, FixItem = 5, DateTime = 6, ComboBox = 7
        }
        #endregion

        #region Form Base DataSource
        private List<SavedSearch> _SavedSearch;
        #endregion

        #region List<SearchField> _List
        /// <summary>
        /// آیتم های جستجو در بیماران
        /// </summary>
        private List<SearchField> _List1;
        /// <summary>
        /// آیتم های جستجو در مراجعات بیماران
        /// </summary>
        private List<SearchField> _List2;
        /// <summary>
        /// آیتم های جستجو در خدمات مراجعات بیماران
        /// </summary>
        private List<SearchField> _List3;
        /// <summary>
        /// آیتم های جستجو در مدارك مراجعات بیماران
        /// </summary>
        private List<SearchField> _List4;
        #endregion

        #region DataGridViewRow _TempRow
        /// <summary>
        /// فیلدی برای جابجایی یك شرط
        /// </summary>
        private DataGridViewRow _TempRow;
        #endregion

        #region StringBuilder _SearchCommand
        private StringBuilder _SearchCommand;
        #endregion

        #region DataTable _SearchTbl
        private DataTable _SearchTbl;
        #endregion

        #region frmList _SelectedColumns
        private frmSearchColumns _SelectedColumns;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAdvancedSearch()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            dgvSavedSearch.AutoGenerateColumns = false;
            if (!FillFormDataSource() || !LoadSavedSearches()) { Close(); return; }
            InitializeFieldsList();
            DateInput.SelectedDateTime = DateTime.Now;
            TimeInput.Value = new DateTime(2000, 1, 1, 8, 0, 0);
            dgvConditions.ColumnHeadersDefaultCellStyle.Font = new Font("B Koodak", 12, FontStyle.Bold);
            dgvSavedSearch.ColumnHeadersDefaultCellStyle.Font = new Font("B Koodak", 12, FontStyle.Bold);
            cBoxSType1.Checked = true;
        }
        #endregion

        #region Event Handlers

        #region Form Shown
        private void Form_Shown(object sender, EventArgs e)
        {
        }
        #endregion

        #region btnHelp_Click
        private void btnHelp_Click(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region cBoxSearchLocation_CheckedChangedEx
        private void cBoxSearchLocation_CheckedChangedEx(object sender, CheckBoxXChangeEventArgs e)
        {
            if (((CheckBoxX)sender).Name == cBoxSType1.Name)
            { if (e.NewChecked.Checked) FillFieldsCboDataSource(FieldPart.PatientsSearch); }
            else if (((CheckBoxX)sender).Name == cBoxSType2.Name)
            { if (e.NewChecked.Checked) FillFieldsCboDataSource(FieldPart.ReferralsSearch); }
            else if (((CheckBoxX)sender).Name == cBoxSType3.Name)
            { if (e.NewChecked.Checked) FillFieldsCboDataSource(FieldPart.RefServices); }
            else if (((CheckBoxX)sender).Name == cBoxSType4.Name)
            { if (e.NewChecked.Checked) FillFieldsCboDataSource(FieldPart.DocumentsSearch); }
        }
        #endregion

        #region cboFields_SelectedIndexChanged
        private void cboFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxSType1.Checked) FillCboConditions(FieldPart.PatientsSearch);
            else if (cBoxSType2.Checked) FillCboConditions(FieldPart.ReferralsSearch);
            else if (cBoxSType3.Checked) FillCboConditions(FieldPart.RefServices);
            else if (cBoxSType4.Checked) FillCboConditions(FieldPart.DocumentsSearch);
        }
        #endregion

        #region btnClearFilters_Click
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            dgvConditions.Rows.Clear();
        }
        #endregion

        #region btnOrders_Click
        private void btnOrders_Click(object sender, EventArgs e)
        {
            switch (((ButtonX)sender).Name)
            {
                case "btnOrder_Not": dgvConditions.Rows.Add("غیر از", "NOT ", String.Empty); break;
                case "btnOrder_And": btnAddCondition_Click(null, null);
                    dgvConditions.Rows.Add("و همچنین", "AND ", String.Empty); break;
                case "btnOrder_AndSingle": dgvConditions.Rows.Add("و همچنین", "AND ", String.Empty); break;
                case "btnOrder_Or": btnAddCondition_Click(null, null);
                    dgvConditions.Rows.Add("یا اینكه", "OR ", String.Empty); break;
                case "btnOrder_OrSingle": dgvConditions.Rows.Add("یا اینكه", "OR ", String.Empty); break;
                case "btnOrder_P1": dgvConditions.Rows.Add("پرانتز باز (", "( ", String.Empty); break;
                case "btnOrder_P2": dgvConditions.Rows.Add(") پرانتز بسته", ") ", String.Empty); break;
            }
        }
        #endregion

        #region btnAddCondition_Click
        /// <summary>
        /// مدیریت افزودن شروط به جدول شروط در این روال انجام می شود
        /// </summary>
        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            // Note: مدیریت افزودن شروط به جدول شروط در این روال انجام می شود
            String FilterText = String.Empty;
            String FilterSql = String.Empty;
            String InnerJoinText = String.Empty;

            #region Add Filter Field Names

            #region Patients Fields
            if (cBoxSType1.Checked)
            {
                switch (Convert.ToInt32(cboFields.SelectedValue))
                {
                    case -100: FilterSql = "[TblPatients].[PatientID] "; FilterText = "كد آنها "; break;
                    case -101: FilterSql = "[TblPatients].[FirstName] "; FilterText = "نام آنها "; break;
                    case -102: FilterSql = "[TblPatients].[LastName] "; FilterText = "نام خانوادگی آنها "; break;
                    case -103: FilterSql = "[TblPatients].[IsMale] "; FilterText = "جنسیت آنها "; break;
                    case -104: FilterSql = "CONVERT(SMALLDATETIME , " +
                        "(CONVERT(NVARCHAR(4) , YEAR([TblPatients].[BirthDate])) + '/' + " +
                        "CONVERT(NVARCHAR(2) , MONTH([TblPatients].[BirthDate])) + '/' + " +
                        "CONVERT(NVARCHAR(2) , DAY([TblPatients].[BirthDate])) + ' 00:00:00')) ";
                        FilterText = "تاریخ تولد آنها "; break;
                    case -201: FilterSql = "[TblPatDetails].[FatherName] "; FilterText = "نام پدر آنها ";
                        InnerJoinText = "TblPatDetails"; break;
                    case -202: FilterSql = "[TblPatDetails].[IDNo] "; FilterText = "شماره شناسنامه آنها ";
                        InnerJoinText = "TblPatDetails"; break;
                    case -203: FilterSql = "[TblPatDetails].[NationalID] "; FilterText = "كد ملی آنها ";
                        InnerJoinText = "TblPatDetails"; break;
                    case -204: FilterSql = "[TblPatDetails].[BirthLocation] "; FilterText = "محل تولد آنها ";
                        InnerJoinText = "TblPatDetails"; break;
                    case -205: FilterSql = "[TblPatDetails].[JobIX] "; FilterText = "شغل آنها ";
                        InnerJoinText = "TblPatDetails"; break;
                    case -206: FilterSql = "[TblPatDetails].[TelNo1] "; FilterText = "تلفن اول آنها ";
                        InnerJoinText = "TblPatDetails"; break;
                    case -207: FilterSql = "[TblPatDetails]. "; FilterText = "تلفن دوم آنها ";
                        InnerJoinText = "TblPatDetails"; break;
                    // case -208: FilterSql = "[TblPatDetails]. "; FilterText = "كشور محل سكونت آنها "; break;
                    // case -209: FilterSql = "[TblPatDetails]. "; FilterText = "استان محل سكونت آنها "; break;
                    case -210: FilterSql = "[TblPatDetails].[CityIX] "; FilterText = "شهر محل سكونت آنها ";
                        InnerJoinText = "TblPatDetails"; break;
                    case -211: FilterSql = "[TblPatDetails].[Email] "; FilterText = "ایمیل آنها ";
                        InnerJoinText = "TblPatDetails"; break;
                    case -212: FilterSql = "[TblPatDetails].[ZipCode] "; FilterText = "كد پستی آنها ";
                        InnerJoinText = "TblPatDetails"; break;
                    case -213: FilterSql = "[TblPatDetails].[Address] "; FilterText = "آدرس پستی آنها ";
                        InnerJoinText = "TblPatDetails"; break;
                    default: FilterSql = "[TblPatAddinData].[Field" + Convert.ToInt32(cboFields.SelectedValue) + "] ";
                        FilterText = cboFields.Text + " آنها "; InnerJoinText = "TblPatAddinData"; break;
                }
            }
            #endregion

            #region Ref Fields
            else if (cBoxSType2.Checked)
            {
                switch (Convert.ToInt32(cboFields.SelectedValue))
                {
                    case -301: FilterSql = "CONVERT(SMALLDATETIME , " +
                        "(CONVERT(NVARCHAR(4) , YEAR([TblRefList].[RegisterDate])) + '/' + " +
                        "CONVERT(NVARCHAR(2) , MONTH([TblRefList].[RegisterDate])) + '/' + " +
                        "CONVERT(NVARCHAR(2) , DAY([TblRefList].[RegisterDate])) + ' 00:00:00')) ";
                        FilterText = "تاریخ مراجعه آنها "; InnerJoinText = "TblRefList"; break;
                    case -302: FilterSql = " DATENAME(hh , [TblRefList].[RegisterDate]) + ':' + " +
                        "DATENAME(mi , [TblRefList].[RegisterDate]) + ':' + DATENAME(s , [TblRefList].[RegisterDate]) ";
                        FilterText = "ساعت مراجعه آنها "; InnerJoinText = "TblRefList"; break;
                    case -303: FilterSql = "[TblRefList].[AdmitterIX] "; FilterText = "كاربر پذیرش كننده مراجعه آنها ";
                        InnerJoinText = "TblRefList"; break;
                    case -304: FilterSql = "CONVERT(SMALLDATETIME , " +
                        "(CONVERT(NVARCHAR(4) , YEAR([TblRefList].[PrescriptionDate])) + '/' + " +
                        "CONVERT(NVARCHAR(2) , MONTH([TblRefList].[PrescriptionDate])) + '/' + " +
                        "CONVERT(NVARCHAR(2) , DAY([TblRefList].[PrescriptionDate])) + ' 00:00:00')) ";
                        FilterText = "تاریخ نسخه مراجعه آنها "; InnerJoinText = "TblRefList"; break;
                    case -305: FilterSql = "[TblRefList].[Weight] "; FilterText = "وزن بیمار در مراجعه ";
                        InnerJoinText = "TblRefList"; break;
                    case -306: FilterSql = "[TblRefList].[ReferPhysicianIX] "; FilterText = "پزشك درخواست كننده مراجعه آنها ";
                        InnerJoinText = "TblRefList"; break;
                    case -307: FilterSql = "[TblRefList].[ReferStatusIX] "; FilterText = "وضعیت مراجعه آنها ";
                        InnerJoinText = "TblRefList"; break;
                    case -308: FilterSql = "[TblRefList].[Description] "; FilterText = "یادداشت مراجعه آنها ";
                        InnerJoinText = "TblRefList"; break;
                    case -309: FilterSql = "[TblRefList].[Ins1IX] "; FilterText = "بیمه اول مراجعه آنها ";
                        InnerJoinText = "TblRefList"; break;
                    case -310: FilterSql = "[TblRefList].[Ins2IX] "; FilterText = "بیمه دوم مراجعه آنها ";
                        InnerJoinText = "TblRefList"; break;
                    case -311: FilterSql = "[TblRefList].[RegisterDate] ";
                        FilterText = "تاریخ و ساعت مراجعه آنها "; InnerJoinText = "TblRefList"; break;
                    default: FilterSql = "[TblRefAddinData].[Field" + Convert.ToInt32(cboFields.SelectedValue) + "] ";
                        FilterText = cboFields.Text + " مراجعه آنها "; InnerJoinText = "TblRefAddinData"; break;
                }
            }
            #endregion

            #region Ref Service Fields
            else if (cBoxSType3.Checked)
            {
                switch (Convert.ToInt32(cboFields.SelectedValue))
                {
                    case -401: FilterSql = "(SELECT TOP 1 [TblServiceList].[Code] " +
                        "FROM [ImagingSystem].[Services].[List] AS [TblServiceList] " +
                        "WHERE [TblServiceList].[ID] = [TblRefServices].[ServiceIX]) ";
                        FilterText = "كد خدمت مراجعه آنها "; InnerJoinText = "TblRefServices"; break;
                    case -402: FilterSql = "(SELECT TOP 1 [TblServiceList].[Name] " +
                        "FROM [ImagingSystem].[Services].[List] AS [TblServiceList] " +
                        "WHERE [TblServiceList].[ID] = [TblRefServices].[ServiceIX]) ";
                        FilterText = "نام خدمت مراجعه آنها "; InnerJoinText = "TblRefServices"; break;
                    case -403: FilterSql = "(SELECT TOP 1 [TblServiceList].[CategoryIX] " +
                        "FROM [ImagingSystem].[Services].[List] AS [TblServiceList] " +
                        "WHERE [TblServiceList].[ID] = [TblRefServices].[ServiceIX]) ";
                        FilterText = "طبقه بندی خدمت مراجعه آنها "; InnerJoinText = "TblRefServices"; break;
                    case -404: FilterSql = "[TblRefServices].[Quantity] ";
                        FilterText = "تعداد خدمات مراجعه آنها "; InnerJoinText = "TblRefServices"; break;
                    case -405: FilterSql = "[TblRefServices].[ExpertIX] ";
                        FilterText = "كارشناس خدمات مراجعه آنها "; InnerJoinText = "TblRefServices"; break;
                    case -406: FilterSql = "[TblRefServices].[PhysicianIX] ";
                        FilterText = "پزشك خدمات مراجعه آنها "; InnerJoinText = "TblRefServices"; break;
                }
            }
            #endregion

            #region Document Fields
            else if (cBoxSType4.Checked)
            {
                switch (Convert.ToInt32(cboFields.SelectedValue))
                {
                    case -501: FilterSql = "[TblRefDocs].[TypeIX] "; FilterText = "نوع مدرك مراجعه آنها ";
                        InnerJoinText = "TblRefDocs"; break;
                    case -502: FilterSql = "[TblRefDocs].[Title] "; FilterText = "عنوان مدرك مراجعه آنها ";
                        InnerJoinText = "TblRefDocs"; break;
                    case -503: FilterSql = "[TblRefDocs].[ReportPhysicianIX] "; FilterText = "پزشك گزارش كننده مدرك مراجعه آنها ";
                        InnerJoinText = "TblRefDocs"; break;
                    case -504: FilterSql = "CONVERT(SMALLDATETIME , " +
                                           "(CONVERT(NVARCHAR(4) , YEAR([TblRefDocs].[Date])) + '/' + " +
                                           "CONVERT(NVARCHAR(2) , MONTH([TblRefDocs].[Date])) + '/' + " +
                                           "CONVERT(NVARCHAR(2) , DAY([TblRefDocs].[Date])) + ' 00:00:00')) ";
                        FilterText = "تاریخ ثبت مدرك مراجعه آنها "; InnerJoinText = "TblRefDocs"; break;
                    case -505: FilterSql = "DATENAME(hh , [TblRefDocs].[Date]) + ':' + " +
                                           "DATENAME(mi , [TblRefDocs].[Date]) + ':' + DATENAME(s , [TblRefDocs].[Date]) ";
                        FilterText = "ساعت ثبت مدرك مراجعه آنها "; InnerJoinText = "TblRefDocs"; break;
                    case -506: FilterSql = "[TblRefDocs].[TypistIX] "; FilterText = "تایپیست مدرك مراجعه آنها ";
                        InnerJoinText = "TblRefDocs"; break;
                }
            }
            #endregion

            #endregion

            #region Add Filter Values

            #region String Filter
            if (txtStringInput.Visible)
            {
                if (String.IsNullOrEmpty(txtStringInput.Text)) return;
                switch (cboConditions.SelectedIndex)
                {
                    case 0: FilterSql += "= N'" + txtStringInput.Text.Trim() + "' ";
                        FilterText += "برابر است با: " + txtStringInput.Text.Trim(); break;
                    case 1: FilterSql += "Like N'" + txtStringInput.Text.Trim() + "%' ";
                        FilterText += "شروع می شود با: " + txtStringInput.Text.Trim(); break;
                    case 2: FilterSql += "Like N'%" + txtStringInput.Text.Trim() + "' ";
                        FilterText += "پایان می یابد با: " + txtStringInput.Text.Trim(); break;
                    case 3: FilterSql += "Like N'%" + txtStringInput.Text.Trim() + "%' ";
                        FilterText += "حاوی عبارت مقابل است: " + txtStringInput.Text.Trim(); break;
                }
            }
            #endregion

            #region Integer Filter
            else if (IntInput.Visible)
            {
                switch (cboConditions.SelectedIndex)
                {
                    case 0: FilterSql += "= " + IntInput.Value + "";
                        FilterText += "برابر است با: " + IntInput.Value; break;
                    case 1: FilterSql += " < " + IntInput.Value + "";
                        FilterText += "كوچكتر است از: " + IntInput.Value; break;
                    case 2: FilterSql += "<= " + IntInput.Value + "";
                        FilterText += "كوچكتر یا مساوی است با: " + IntInput.Value; break;
                    case 3: FilterSql += ">= " + IntInput.Value + "";
                        FilterText += "بزرگتر یا مساوی است با: " + IntInput.Value; break;
                    case 4: FilterSql += "> " + IntInput.Value + "";
                        FilterText += "بزرگتر است از: " + IntInput.Value; break;
                }
            }
            #endregion

            #region DateInput Filter
            else if (DateInput.Visible && !TimeInput.Visible)
            {
                switch (cboConditions.SelectedIndex)
                {
                    case 0: FilterSql += "= '" + DateInput.SelectedDateTime.Value.Date.ToString("yyyy/MM/dd") + "' ";
                        FilterText += "برابر است با: " +
                            DateInput.SelectedDateTime.Value.ToPersianDate().ToString("yyyy/MM/dd"); break;
                    case 1: FilterSql += "< '" + DateInput.SelectedDateTime.Value.Date.ToString("yyyy/MM/dd") + "' ";
                        FilterText += "كوچكتر است از: " +
                            DateInput.SelectedDateTime.Value.ToPersianDate().ToString("yyyy/MM/dd"); break;
                    case 2: FilterSql += "<= '" + DateInput.SelectedDateTime.Value.Date.ToString("yyyy/MM/dd") + "' ";
                        FilterText += "كوچكتر یا مساوی است با: " +
                            DateInput.SelectedDateTime.Value.ToPersianDate().ToString("yyyy/MM/dd"); break;
                    case 3: FilterSql += ">= '" + DateInput.SelectedDateTime.Value.Date.ToString("yyyy/MM/dd") + "' ";
                        FilterText += "بزرگتر یا مساوی است با: " +
                            DateInput.SelectedDateTime.Value.ToPersianDate().ToString("yyyy/MM/dd"); break;
                    case 4: FilterSql += "> '" + DateInput.SelectedDateTime.Value.Date.ToString("yyyy/MM/dd") + "' ";
                        FilterText += "بزرگتر است از: " +
                            DateInput.SelectedDateTime.Value.ToPersianDate().ToString("yyyy/MM/dd"); break;
                }
            }
            #endregion

            #region TimeInput Filter
            else if (!DateInput.Visible && TimeInput.Visible)
            {
                switch (cboConditions.SelectedIndex)
                {
                    case 0: FilterSql += " = '" + TimeInput.Value.Hour + ":" +
                        TimeInput.Value.Minute + ":" + TimeInput.Value.Second + "' ";
                        FilterText += "برابر است با: " + TimeInput.Value.Hour + ":" +
                            TimeInput.Value.Minute + ":" + TimeInput.Value.Second; break;
                    case 1: FilterSql += " < '" + TimeInput.Value.Hour + ":" +
                        TimeInput.Value.Minute + ":" + TimeInput.Value.Second + "' ";
                        FilterText += "كوچكتر است از: " + TimeInput.Value.Hour + ":" +
                            TimeInput.Value.Minute + ":" + TimeInput.Value.Second; break;
                    case 2: FilterSql += " <= '" + TimeInput.Value.Hour + ":" +
                                         TimeInput.Value.Minute + ":" + TimeInput.Value.Second + "' ";
                        FilterText += "كوچكتر یا مساوی است با: " + TimeInput.Value.Hour + ":" +
                                      TimeInput.Value.Minute + ":" + TimeInput.Value.Second; break;
                    case 3: FilterSql += " >= '" + TimeInput.Value.Hour + ":" +
                        TimeInput.Value.Minute + ":" + TimeInput.Value.Second + "' ";
                        FilterText += "بزرگتر یا مساوی است با: " + TimeInput.Value.Hour + ":" +
                            TimeInput.Value.Minute + ":" + TimeInput.Value.Second; break;
                    case 4: FilterSql += " > '" + TimeInput.Value.Hour + ":" +
                        TimeInput.Value.Minute + ":" + TimeInput.Value.Second + "' ";
                        FilterText += "بزرگتر است از: " + TimeInput.Value.Hour + ":" +
                            TimeInput.Value.Minute + ":" + TimeInput.Value.Second; break;
                }
            }
            #endregion

            #region cboFixItem Filter
            else if (cboFixItem.Visible)
            {
                #region For Gender
                if (cBoxSType1.Checked && cboFields.SelectedValue.ToString() == "-103")
                {
                    switch (cboConditions.SelectedIndex)
                    {
                        case 0:
                            if (cboFixItem.SelectedIndex == 0)
                            {
                                FilterSql += "= 1 ";
                                FilterText += "برابر است با مرد.";
                            }
                            else
                            {
                                FilterSql += "= 0 ";
                                FilterText += "برابر است با زن.";
                            } break;
                        case 1:
                            if (cboFixItem.SelectedIndex == 0)
                            {
                                FilterSql += "<> 1 ";
                                FilterText += "برابر نباشد با مرد.";
                            }
                            else
                            {
                                FilterSql += "<> 0 ";
                                FilterText += "برابر نباشد با زن.";
                            } break;
                    }
                }
                #endregion

                #region For Addin Data
                else if (cboFields.SelectedValue != null && Convert.ToInt32(cboFields.SelectedValue) > 0)
                {
                    Byte TypeID;
                    if (cBoxSType1.Checked)
                    {
                        TypeID = DBLayerIMS.Referrals.PatAddinColsList.Where(
                                Data => Data.ID == Convert.ToInt32(cboFields.SelectedValue)).First().TypeID;
                    }
                    else // if (cBoxSType1.Checked)
                    {
                        TypeID = DBLayerIMS.Referrals.RefAddinColsList.Where(
                                Data => Data.ID == Convert.ToInt32(cboFields.SelectedValue)).First().TypeID;
                    }

                    if (TypeID == 1) // فیلد بولین
                    {
                        switch (cboConditions.SelectedIndex)
                        {
                            case 0:
                                if (cboFixItem.SelectedIndex == 0)
                                {
                                    FilterSql += "= 1 ";
                                    FilterText += "تیك خورده باشد.";
                                }
                                else
                                {
                                    FilterSql += "= 0 ";
                                    FilterText += "تیك نخورده باشد.";
                                } break;
                            case 1:
                                if (cboFixItem.SelectedIndex == 0)
                                {
                                    FilterSql += "<> 1 ";
                                    FilterText += "تیك خورده نباشد.";
                                }
                                else
                                {
                                    FilterSql += "<> 0 ";
                                    FilterText += "تیك نخورده نباشد";
                                } break;
                        }
                    }
                    else if (TypeID == 3) // فیلد كمبوباكس
                    {
                        switch (cboConditions.SelectedIndex)
                        {
                            case 0:
                                if (cboFixItem.SelectedIndex == 0)
                                {
                                    FilterSql += "IS NULL ";
                                    FilterText += "انتخاب نشده باشد. ";
                                }
                                else
                                {
                                    FilterSql += "= " + cboFixItem.SelectedValue + " ";
                                    FilterText += "برابر باشد با: " + cboFixItem.Text; break;
                                }
                                break;
                            default:
                                if (cboFixItem.SelectedIndex == 0)
                                {
                                    FilterSql += "IS NOT NULL ";
                                    FilterText += "انتخاب نشده نباشد. ";
                                }
                                else
                                {
                                    FilterSql += "<> " + cboFixItem.SelectedValue + " ";
                                    FilterText += "برابر نباشد با: " + cboFixItem.Text;
                                }
                                break;
                        }
                    }
                }
                #endregion

                #region For NULL Values
                else if (cboFixItem.SelectedValue == null)
                {
                    switch (cboConditions.SelectedIndex)
                    {
                        case 0: FilterSql += "IS NULL ";
                            FilterText += "مقداری نداشته باشد."; break;
                        case 1: FilterSql += "IS NOT NULL ";
                            FilterText += "بدون مقدار نباشد."; break;
                    }
                }
                #endregion

                #region For Other Values
                else
                {
                    switch (cboConditions.SelectedIndex)
                    {
                        case 0: FilterSql += "= " + cboFixItem.SelectedValue + " ";
                            FilterText += "برابر است با: " + cboFixItem.Text; break;
                        case 1: FilterSql += "<> " + cboFixItem.SelectedValue + " ";
                            FilterText += "برابر نباشد با: " + cboFixItem.Text; break;
                    }
                }
                #endregion
            }
            #endregion

            #region DateTime Filter
            else if (DateInput.Visible && TimeInput.Visible)
            {
                String SelectedDateTime = DateInput.SelectedDateTime.Value.Year + "/" +
                    DateInput.SelectedDateTime.Value.Month + "/" + DateInput.SelectedDateTime.Value.Day + " " +
                    TimeInput.Value.Hour + ":" + TimeInput.Value.Minute + ":" + TimeInput.Value.Second;
                switch (cboConditions.SelectedIndex)
                {
                    case 0: FilterSql += "= '" + SelectedDateTime + "' ";
                        FilterText += "برابر است با: " + SelectedDateTime.ToPersianDate(); break;
                    case 1: FilterSql += "< '" + SelectedDateTime + "' ";
                        FilterText += "كوچكتر است از: " + SelectedDateTime.ToPersianDate(); break;
                    case 2: FilterSql += "<= '" + SelectedDateTime + "' ";
                        FilterText += "كوچكتر یا مساوی است با: " + SelectedDateTime.ToPersianDate(); break;
                    case 3: FilterSql += ">= '" + SelectedDateTime + "' ";
                        FilterText += "بزرگتر یا مساوی است با: " + SelectedDateTime.ToPersianDate(); break;
                    case 4: FilterSql += "> '" + SelectedDateTime + "' ";
                        FilterText += "بزرگتر است از: " + SelectedDateTime.ToPersianDate(); break;
                }
            }
            #endregion

            #endregion

            dgvConditions.Rows.Add(FilterText, FilterSql, InnerJoinText);
        }
        #endregion

        #region @@@ dgvConditions Drag And Drop @@@

        #region dgvConditions_CellMouseEnter
        private void dgvConditions_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 || e.RowIndex < 0) return;
            if (_TempRow != null && MouseButtons == MouseButtons.Left)
            {
                dgvConditions.Rows[e.RowIndex].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvConditions.Rows[e.RowIndex].HeaderCell.Style.Font = new Font("Tahoma", 10, FontStyle.Bold);
                dgvConditions.Rows[e.RowIndex].HeaderCell.Value = "=";
            }
        }
        #endregion

        #region dgvConditions_CellMouseDown
        private void dgvConditions_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 || e.RowIndex < 0) return;
            _TempRow = dgvConditions.Rows[e.RowIndex];
        }
        #endregion

        #region dgvConditions_CellMouseUp
        private void dgvConditions_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 || e.RowIndex < 0) return;
            if (_TempRow != null && _TempRow.Index != e.RowIndex)
            {
                dgvConditions.Rows.Remove(_TempRow);
                dgvConditions.Rows.Insert(e.RowIndex, _TempRow);
                _TempRow = null;
                foreach (DataGridViewRow row in dgvConditions.Rows) row.HeaderCell.Value = null;
            }
        }
        #endregion

        #region dgvConditions_CellMouseLeave
        private void dgvConditions_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 || e.RowIndex < 0) return;
            dgvConditions.Rows[e.RowIndex].HeaderCell.Value = null;
        }
        #endregion

        #endregion

        #region btnSaveSearch_Click
        private void btnSaveSearch_Click(object sender, EventArgs e)
        {
            DialogResult Result = PMBox.Show("آیا مایلید ساختار جستجوی جاری را برای استفاده های بعدی ذخیره نمایید؟",
                "پرسش؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.No) return;

            #region Save Selected Columns
            String SelectString = String.Empty;
            if (_SelectedColumns != null)
            {
                DataTable SelectedColumns = new DataTable("SelectedColumns");
                SelectedColumns.Columns.Add("ColName", typeof(String));
                SelectedColumns.Columns.Add("IsShow", typeof(Boolean));
                // اطلاعات پایه بیماران
                if (_SelectedColumns.TreeViewOptions.Nodes[0].Checked)
                    foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[0].Nodes)
                        if (node.Checked) SelectedColumns.Rows.Add(node.Tag.ToString(), true);
                // جزئیات اطلاعات بیماران
                if (_SelectedColumns.TreeViewOptions.Nodes[1].Checked)
                    foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[1].Nodes)
                        if (node.Checked) SelectedColumns.Rows.Add(node.Tag.ToString(), true);
                // فیلد های پویا بیماران
                if (_SelectedColumns.TreeViewOptions.Nodes[2].Checked)
                    foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[2].Nodes)
                        if (node.Checked) SelectedColumns.Rows.Add("Pat" + node.Tag, true);
                // فیلد های مربوط به مراجعات
                if (_SelectedColumns.TreeViewOptions.Nodes[3].Checked)
                {
                    // فیلد های پایه مراجعات
                    if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Checked)
                        foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes)
                            if (node.Checked) SelectedColumns.Rows.Add(node.Tag.ToString(), true);
                    // فیلد های پویا مراجعات
                    if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[1].Checked)
                        foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[1].Nodes)
                            if (node.Checked) SelectedColumns.Rows.Add("Ref" + node.Tag, true);
                    // فیلد های خدمات مراجعات
                    if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Checked)
                        foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes)
                            if (node.Checked) SelectedColumns.Rows.Add(node.Tag.ToString(), true);
                    // فیلد های مدارك مراجعات
                    if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[3].Checked)
                        foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[3].Nodes)
                            if (node.Checked) SelectedColumns.Rows.Add(node.Tag.ToString(), true);
                }
                StringWriter writer = new StringWriter();
                SelectedColumns.WriteXml(writer, true);
                SelectString = writer.GetStringBuilder().ToString();
            }
            #endregion

            #region Save Filter
            String FilterString = String.Empty;
            if (dgvConditions.Rows.Count != 0)
            {
                DataTable FilterData = new DataTable("Filters");
                FilterData.Columns.Add("ColLocaleData", typeof(String));
                FilterData.Columns.Add("ColSqlData", typeof(String));
                FilterData.Columns.Add("ColInnerJoins", typeof(String));
                foreach (DataGridViewRow row in dgvConditions.Rows)
                {
                    String[] ValueArray = new String[3];
                    for (Int32 i = 0; i < 3; i++) ValueArray[i] = row.Cells[i].Value.ToString();
                    FilterData.Rows.Add(ValueArray);
                }
                StringWriter writer = new StringWriter();
                FilterData.WriteXml(writer, true);
                FilterString = writer.GetStringBuilder().ToString();
            }
            #endregion

            #region Save Data In Bank
            SavedSearch NewRow = new SavedSearch();
            NewRow.Name = "جستجوی تاریخ: " + PersianDate.Now.ToString("yy/mm/dd") +
                " - " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            NewRow.ColumnsData = SelectString;
            NewRow.FilterData = FilterString;
            DBLayerIMS.Manager.DBML.SavedSearches.InsertOnSubmit(NewRow);
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ذخیره سازی اطلاعات جستجوی ذخیره شده در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            if ((!LoadSavedSearches())) { Close(); return; }
            TabControlForm.SelectedTabIndex = 2;
        }
        #endregion

        #region btnReportColumns_Click
        private void btnReportColumns_Click(object sender, EventArgs e)
        {
            if (_SelectedColumns == null) _SelectedColumns = new frmSearchColumns();
            _SelectedColumns.ShowDialog();
        }
        #endregion

        #region btnSearch_Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GenerateSearchString();
            Enabled = false;
            ProgressBarForm.ProgressType = eProgressItemType.Marquee;
            ProgressBarForm.Text = "در حال جستجوی اطلاعات";
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _SearchTbl = Negar.DBLayerPMS.Manager.ExecuteQuery(_SearchCommand.ToString(), 0);
            if (_SearchTbl == null)
            {
                const String ErrorMessage = "امكان جستجوی اطلاعات از بانك اطلاعاتی وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); e.Cancel = true;
            }
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                PMBox.Show("جستجوی اطلاعات با خطا مواجه شد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else TabControlForm.SelectedTabIndex = 1;
            dgvData.Columns.Clear();
            dgvData.DataSource = _SearchTbl;
            if (_SearchTbl != null)
            {
                foreach (DataColumn column in _SearchTbl.Columns)
                {
                    if (column.DataType.Equals(typeof(Boolean)))
                    {
                        DataGridViewCheckBoxColumn Col = new DataGridViewCheckBoxColumn();
                        Col.Name = column.ColumnName;
                        Col.HeaderText = column.Caption;
                        Col.DataPropertyName = column.ColumnName;
                        dgvData.Columns.Add(Col);
                    }
                    else if (column.DataType.Equals(typeof(DateTime)))
                    {
                        DataGridViewPersianDateTimePickerColumn Col = new DataGridViewPersianDateTimePickerColumn();
                        Col.Name = column.ColumnName;
                        Col.HeaderText = column.Caption;
                        Col.DataPropertyName = column.ColumnName;
                        if (column.ColumnName == "زمان مراجعه" || column.ColumnName == "زمان ثبت مدرك")
                            Col.ShowTime = true;
                        else if (column.ColumnName == "تاریخ تولد" || column.ColumnName == "تاریخ نسخه")
                            Col.ShowTime = false;
                        dgvData.Columns.Add(Col);
                    }
                    else
                    {
                        DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
                        Col.Name = column.ColumnName;
                        Col.HeaderText = column.Caption;
                        Col.DataPropertyName = column.ColumnName;
                        dgvData.Columns.Add(Col);
                    }
                }
                if (dgvData.Columns.Count > 2) dgvData.Columns[1].Visible = false;
                dgvData.AutoResizeColumns();
                dgvData.AutoResizeRows();
            }
            ProgressBarForm.ProgressType = eProgressItemType.Standard;
            Enabled = true;
            ProgressBarForm.Text = "در انتظار جستجوی اطلاعات";
            BringToFront();
            Focus();
        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            new Negar.GridPrinting.frmReportPreview(dgvData);
        }
        #endregion

        #region dgvSavedReports_CellMouseClick
        private void dgvSavedReports_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Point Position = MousePosition;
            if (sender.GetType().Equals(typeof(Int32)) &&
                e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
                Position = e.Location;
            else if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            dgvSavedSearch.Rows[e.RowIndex].Selected = true;
            cmsdgvData.PopupMenu(Position);
        }
        #endregion

        #region dgvSavedReports_CellEndEdit
        private void dgvSavedReports_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ذخیره سازی اطلاعات جستجوی ذخیره شده در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region dgvSavedReports_CellMouseDoubleClick
        private void dgvSavedReports_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (_SelectedColumns != null)
            {
                _SelectedColumns.Dispose();
                _SelectedColumns = null;
            }
            _SelectedColumns = new frmSearchColumns();
            dgvConditions.Rows.Clear();
            SavedSearch SearchData = ((SavedSearch)dgvSavedSearch.Rows[e.RowIndex].DataBoundItem);

            #region Read Columns
            if (!String.IsNullOrEmpty(SearchData.ColumnsData))
            {
                #region Prepare DataTable
                DataTable SelectedColumns = new DataTable("SelectedColumns");
                SelectedColumns.Columns.Add("ColName", typeof(String));
                SelectedColumns.Columns.Add("IsShow", typeof(Boolean));
                if (File.Exists("TempSelectedColumns.DAT")) File.Delete("TempSelectedColumns.DAT");
                File.WriteAllText("TempSelectedColumns.DAT", SearchData.ColumnsData);
                SelectedColumns.ReadXml("TempSelectedColumns.DAT");
                if (File.Exists("TempSelectedColumns.DAT")) File.Delete("TempSelectedColumns.DAT");
                #endregion

                // اطلاعات پایه بیماران
                foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[0].Nodes)
                {
                    DataRow[] SearchedColData = SelectedColumns.Select("ColName = '" + node.Tag + "'");
                    if (SearchedColData.Count() != 0 && Convert.ToBoolean(SearchedColData.First()["IsShow"]))
                        _SelectedColumns.TreeViewOptions.Nodes[0].Nodes[node.Tag.ToString()].Checked = true;
                    else _SelectedColumns.TreeViewOptions.Nodes[0].Nodes[node.Tag.ToString()].Checked = false;
                }
                // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@2
                // جزئیات اطلاعات بیماران
                foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[1].Nodes)
                {
                    DataRow[] SearchedColData = SelectedColumns.Select("ColName = '" + node.Tag + "'");
                    if (SearchedColData.Count() != 0 && Convert.ToBoolean(SearchedColData.First()["IsShow"]))
                        _SelectedColumns.TreeViewOptions.Nodes[1].Nodes[node.Tag.ToString()].Checked = true;
                    else _SelectedColumns.TreeViewOptions.Nodes[1].Nodes[node.Tag.ToString()].Checked = false;
                }
                // فیلدهای پویا بیماران
                foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[2].Nodes)
                {
                    DataRow[] SearchedColData = SelectedColumns.Select("ColName = 'Pat" + node.Tag + "'");
                    if (SearchedColData.Count() != 0 && Convert.ToBoolean(SearchedColData.First()["IsShow"]))
                        _SelectedColumns.TreeViewOptions.Nodes[2].Nodes["Pat" + node.Tag].Checked = true;
                    else _SelectedColumns.TreeViewOptions.Nodes[2].Nodes["Pat" + node.Tag].Checked = false;
                }
                // فیلد های پایه مراجعات
                foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes)
                {
                    DataRow[] SearchedColData = SelectedColumns.Select("ColName = '" + node.Tag + "'");
                    if (SearchedColData.Count() != 0 && Convert.ToBoolean(SearchedColData.First()["IsShow"]))
                        _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[node.Tag.ToString()].Checked = true;
                    else _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[node.Tag.ToString()].Checked = false;
                }
                // فیلد های پویا مراجعات
                foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[1].Nodes)
                {
                    DataRow[] SearchedColData = SelectedColumns.Select("ColName = 'Ref" + node.Tag + "'");
                    if (SearchedColData.Count() != 0 && Convert.ToBoolean(SearchedColData.First()["IsShow"]))
                        _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[1].Nodes["Ref" + node.Tag].Checked = true;
                    else _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[1].Nodes["Ref" + node.Tag].Checked = false;
                }
                // فیلد های خدمات مراجعات
                foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes)
                {
                    DataRow[] SearchedColData = SelectedColumns.Select("ColName = '" + node.Tag + "'");
                    if (SearchedColData.Count() != 0 && Convert.ToBoolean(SearchedColData.First()["IsShow"]))
                        _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes[node.Tag.ToString()].Checked = true;
                    else _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes[node.Tag.ToString()].Checked = false;
                }
                // فیلد های مدارك مراجعات
                foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[3].Nodes)
                {
                    DataRow[] SearchedColData = SelectedColumns.Select("ColName = '" + node.Tag + "'");
                    if (SearchedColData.Count() != 0 && Convert.ToBoolean(SearchedColData.First()["IsShow"]))
                        _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[3].Nodes[node.Tag.ToString()].Checked = true;
                    else _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[3].Nodes[node.Tag.ToString()].Checked = false;
                }
            }
            #endregion

            #region Read Filters
            if (!String.IsNullOrEmpty(SearchData.FilterData))
            {
                #region Prepare DataTable
                DataTable Filters = new DataTable("Filters");
                Filters.Columns.Add("ColLocaleData", typeof(String));
                Filters.Columns.Add("ColSqlData", typeof(String));
                Filters.Columns.Add("ColInnerJoins", typeof(String));
                if (File.Exists("FiltersXML.DAT")) File.Delete("FiltersXML.DAT");
                File.WriteAllText("FiltersXML.DAT", SearchData.FilterData);
                Filters.ReadXml("FiltersXML.DAT");
                if (File.Exists("FiltersXML.DAT")) File.Delete("FiltersXML.DAT");
                #endregion

                foreach (DataRow row in Filters.Rows)
                    dgvConditions.Rows.Add(row.ItemArray);
            }
            #endregion

            TabControlForm.SelectedTabIndex = 0;
        }
        #endregion

        #region btnEditSearchName_Click
        private void btnEditSearchName_Click(object sender, EventArgs e)
        {
            if (dgvSavedSearch.SelectedRows.Count == 0) return;
            dgvSavedSearch.BeginEdit(true);
        }
        #endregion

        #region btnDeleteSearch_Click
        private void btnDeleteSearch_Click(object sender, EventArgs e)
        {
            if (dgvSavedSearch.SelectedRows.Count == 0) return;
            DialogResult Result = PMBox.Show("آیا مایلید جستجوی ذخیره شده ی انتخاب شده را حذف نمایید؟\n" +
                "با حذف یك جستجوی ذخیره شده ، ساختار آن حذف شده و قابل بازگشت نمی باشد.", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result != DialogResult.Yes) return;
            DBLayerIMS.Manager.DBML.SavedSearches.DeleteOnSubmit(
                    (SavedSearch)dgvSavedSearch.SelectedRows[0].DataBoundItem);
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان حذف اطلاعات جستجوی ذخیره شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (!LoadSavedSearches()) { Close(); return; }
        }
        #endregion

        #region btnMoveResult_Click
        private void btnMoveResult_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                PMBox.Show("موردی برای انتقال به فرم بیماران انتخاب نشده است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); return;
            }
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

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
        }
        #endregion

        #region Boolean FillFormDataSource()
        /// <summary>
        /// تابعی برای خواندن اطلاعاتی پایه فرم از بانك
        /// </summary>
        private Boolean FillFormDataSource()
        {
            // حذف لایسنس گزارش گیری
            if (!LicenseHelper.GetSavedLicenses().Contains("560"))
            {
                btnPrint.Visible = false;
                btnMoveResult.Left = btnPrint.Left;
            }
            return true;
        }
        #endregion

        #region Boolean LoadSavedSearches()
        /// <summary>
        /// تابعی برای خواندن لیست جستجوهای ذخیره شده از بانك
        /// </summary>
        private Boolean LoadSavedSearches()
        {
            try { _SavedSearch = DBLayerIMS.Manager.DBML.SavedSearches.ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات جستجوهای ذخیره شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            dgvSavedSearch.DataSource = _SavedSearch.ToList();
            return true;
        }
        #endregion

        #region void InitializeFieldsList()
        /// <summary>
        /// تابعی برای تعریف فیلد های قابل استفاده برای فیلتر كردن در جستجو
        /// </summary>
        private void InitializeFieldsList()
        {
            // Note: اینجا محل تعریف فیلتر های موجود در فرم می باشد
            #region Patient Filter List
            _List1 = new List<SearchField>();
            _List1.Add(new SearchField(-100, "شماره بیمار"));
            _List1.Add(new SearchField(-101, "نام بیمار"));
            _List1.Add(new SearchField(-102, "نام خانوادگی بیمار"));
            _List1.Add(new SearchField(-103, "جنسیت"));
            _List1.Add(new SearchField(-104, "تاریخ تولد"));
            // -------------------------------------------------------------
            _List1.Add(new SearchField(-201, "نام پدر"));
            _List1.Add(new SearchField(-202, "شماره شناسنامه"));
            _List1.Add(new SearchField(-203, "كد ملی"));
            _List1.Add(new SearchField(-204, "محل تولد"));
            _List1.Add(new SearchField(-205, "شغل"));
            _List1.Add(new SearchField(-206, "تلفن 1"));
            _List1.Add(new SearchField(-207, "تلفن 2"));
            // _List1.Add(new SearchField(-208, "كشور"));
            // _List1.Add(new SearchField(-209, "استان"));
            _List1.Add(new SearchField(-210, "شهر"));
            _List1.Add(new SearchField(-211, "ایمیل"));
            _List1.Add(new SearchField(-212, "كد پستی"));
            _List1.Add(new SearchField(-213, "آدرس پستی"));
            foreach (PatAdditionalColumn column in DBLayerIMS.Referrals.PatAddinColsList)
                _List1.Add(new SearchField(column.ID, column.Title));
            #endregion

            #region Referrals Filter List
            _List2 = new List<SearchField>();
            _List2.Add(new SearchField(-301, "تاریخ مراجعه"));
            _List2.Add(new SearchField(-302, "ساعت مراجعه"));
            _List2.Add(new SearchField(-311, "تاریخ و ساعت مراجعه"));
            _List2.Add(new SearchField(-304, "تاریخ نسخه"));
            _List2.Add(new SearchField(-305, "وزن بیمار"));
            _List2.Add(new SearchField(-306, "پزشك درخواست كننده"));
            _List2.Add(new SearchField(-307, "وضعیت مراجعه"));
            _List2.Add(new SearchField(-308, "یادداشت"));
            _List2.Add(new SearchField(-309, "بیمه اول"));
            _List2.Add(new SearchField(-310, "بیمه دوم"));
            foreach (RefAdditionalColumn column in DBLayerIMS.Referrals.RefAddinColsList)
                _List2.Add(new SearchField(column.ID, column.Title));
            #endregion

            #region Referrals Services Filter List
            _List3 = new List<SearchField>();
            _List3.Add(new SearchField(-401, "كد خدمت"));
            _List3.Add(new SearchField(-402, "نام خدمت"));
            _List3.Add(new SearchField(-403, "طبقه بندی خدمت"));
            _List3.Add(new SearchField(-404, "تعداد خدمت"));
            _List3.Add(new SearchField(-405, "كارشناس خدمت"));
            _List3.Add(new SearchField(-406, "پزشك خدمت"));
            #endregion

            #region Document Filter List
            _List4 = new List<SearchField>();
            _List4.Add(new SearchField(-501, "نوع مدرك"));
            _List4.Add(new SearchField(-502, "عنوان مدرك"));
            _List4.Add(new SearchField(-503, "پزشك گزارش كننده مدرك"));
            _List4.Add(new SearchField(-504, "تاریخ ثبت مدرك"));
            _List4.Add(new SearchField(-505, "ساعت ثبت مدرك"));
            _List4.Add(new SearchField(-506, "تایپیست مدرك"));
            #endregion
        }
        #endregion

        #region void FillFieldsCboDataSource(FieldPart PartName)
        /// <summary>
        /// تابعی برای خواندن فیلد های فیلتر بخش های مختلف
        /// </summary>
        /// <param name="PartName">نام بخش</param>
        private void FillFieldsCboDataSource(FieldPart PartName)
        {
            cboFields.DisplayMember = "LocaleName";
            cboFields.ValueMember = "ID";
            switch (PartName)
            {
                case FieldPart.PatientsSearch: cboFields.DataSource = _List1; break;
                case FieldPart.ReferralsSearch: cboFields.DataSource = _List2; break;
                case FieldPart.RefServices: cboFields.DataSource = _List3; break;
                case FieldPart.DocumentsSearch: cboFields.DataSource = _List4; break;
            }
            cboFields.SelectedIndex = 0;
        }
        #endregion

        #region void FillCboConditions(FieldPart Part)
        /// <summary>
        /// تابعی برای تنظیم حالات فیلتر برای پارامتر های مختلف
        /// </summary>
        /// <param name="Part">نام بخش مورد نظر</param>
        private void FillCboConditions(FieldPart Part)
        {
            // Note: اینجا محل تكمیل كمبوباكس شروط ، بر طبق نوع: بیمار ، مراجعه و... و نوع داده ای آن: حرفی ، عددی و... می باشد
            switch (Part)
            {
                #region PatientsSearch
                case FieldPart.PatientsSearch:
                    switch ((Int32)cboFields.SelectedValue)
                    {
                        // رشته
                        case -100:
                        case -101:
                        case -102:
                        case -201:
                        case -202:
                        case -203:
                        case -204:
                        case -206:
                        case -207:
                        case -211:
                        case -212:
                        case -213:
                            FieldsFilterAdd(FieldsType.String); break;
                        // آیتم های فیكس
                        case -103: cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                            cboFixItem.Items.Add("مرد"); cboFixItem.Items.Add("زن"); cboFixItem.SelectedIndex = 0;
                            FieldsFilterAdd(FieldsType.FixItem); break;
                        case -205:
                            cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                            cboFixItem.DataSource = Negar.DBLayerPMS.Patients.PatientsJobsList.OrderBy(Data => Data.Title).ToList();
                            cboFixItem.DisplayMember = "Title"; cboFixItem.ValueMember = "ID";
                            FieldsFilterAdd(FieldsType.FixItem); break;
                        case -210:
                            cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                            cboFixItem.DataSource = Negar.DBLayerPMS.Patients.CitiesList.OrderBy(Data => Data.StateIX).ToList();
                            cboFixItem.DisplayMember = "Name"; cboFixItem.ValueMember = "ID";
                            FieldsFilterAdd(FieldsType.FixItem); break;
                        // تاریخ
                        case -104: FieldsFilterAdd(FieldsType.Date); break;
                        // فیلد های اطلاعاتی اضافی
                        default:
                            if (cboFields.SelectedValue != null && DBLayerIMS.Referrals.PatAddinColsList.Count != 0)
                            {
                                Byte AddinFieldType = DBLayerIMS.Referrals.PatAddinColsList.
                                    Where(Data => Data.ID == Convert.ToInt32(cboFields.SelectedValue)).First().TypeID;
                                switch (AddinFieldType)
                                {
                                    // متنی
                                    case 0: FieldsFilterAdd(FieldsType.String); break;
                                    // بولین
                                    case 1:
                                        cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                                        cboFixItem.Items.Add("صحیح"); cboFixItem.Items.Add("غلط"); cboFixItem.SelectedIndex = 0;
                                        FieldsFilterAdd(FieldsType.FixItem); break;
                                    // عددی
                                    case 2: FieldsFilterAdd(FieldsType.Number); break;
                                    // كمبو باكس
                                    case 3:
                                        cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                                        cboFixItem.DataSource = DBLayerIMS.Manager.DBML.
                                            SP_SelectPatMultiSelectItems(Convert.ToInt16(cboFields.SelectedValue)).ToList();
                                        cboFixItem.DisplayMember = "Title"; cboFixItem.ValueMember = "ID";
                                        FieldsFilterAdd(FieldsType.ComboBox); break;
                                    default: break;
                                }
                            } break;
                    } break;
                #endregion

                #region ReferralsSearch
                case FieldPart.ReferralsSearch:
                    switch (Convert.ToInt16(cboFields.SelectedValue))
                    {
                        // عددی
                        case -305: FieldsFilterAdd(FieldsType.Number); break;
                        // رشته
                        case -306:
                        case -308:
                            FieldsFilterAdd(FieldsType.String); break;
                        // آیتم های فیكس
                        case -303:
                            cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                            cboFixItem.DataSource = Negar.DBLayerPMS.Security.UsersList;
                            cboFixItem.DisplayMember = "FullName"; cboFixItem.ValueMember = "ID";
                            FieldsFilterAdd(FieldsType.FixItem); break;
                        case -307:
                            cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                            cboFixItem.DataSource = DBLayerIMS.Referrals.RefStatusList.OrderBy(Data => Data.Title).ToList();
                            cboFixItem.DisplayMember = "Title"; cboFixItem.ValueMember = "ID";
                            FieldsFilterAdd(FieldsType.FixItem); break;
                        case -309:
                        case -310:
                            cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                            cboFixItem.DataSource = DBLayerIMS.Insurance.InsFullList.OrderBy(Data => Data.Name).ToList();
                            cboFixItem.DisplayMember = "Name"; cboFixItem.ValueMember = "ID";
                            FieldsFilterAdd(FieldsType.FixItem); break;
                        // تاریخ
                        case -301:
                        case -304:
                            FieldsFilterAdd(FieldsType.Date); break;
                        // ساعت
                        case -302: FieldsFilterAdd(FieldsType.Time); break;
                        // تاریخ و ساعت
                        case -311: FieldsFilterAdd(FieldsType.DateTime); break;
                        // فیلد های اطلاعاتی اضافی
                        default:
                            if (cboFields.SelectedValue != null && DBLayerIMS.Referrals.RefAddinColsList.Count != 0)
                            {
                                Byte AddinFieldType = DBLayerIMS.Referrals.RefAddinColsList.
                                    Where(Data => Data.ID == Convert.ToInt32(cboFields.SelectedValue)).First().TypeID;
                                switch (AddinFieldType)
                                {
                                    // متنی
                                    case 0: FieldsFilterAdd(FieldsType.String); break;
                                    // بولین
                                    case 1:
                                        cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                                        cboFixItem.Items.Add("صحیح"); cboFixItem.Items.Add("غلط"); cboFixItem.SelectedIndex = 0;
                                        FieldsFilterAdd(FieldsType.FixItem); break;
                                    // عددی
                                    case 2: FieldsFilterAdd(FieldsType.Number); break;
                                    // كمبو باكس
                                    case 3:
                                        cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                                        cboFixItem.DataSource = DBLayerIMS.Manager.DBML.
                                            SP_SelectRefMultiSelectItems(Convert.ToInt16(cboFields.SelectedValue)).ToList();
                                        cboFixItem.DisplayMember = "Title"; cboFixItem.ValueMember = "ID";
                                        FieldsFilterAdd(FieldsType.ComboBox); break;
                                    default: break;
                                }
                            } break;
                    } break;
                #endregion

                #region RefServices
                case FieldPart.RefServices:
                    switch (Convert.ToInt16(cboFields.SelectedValue))
                    {
                        // عددی
                        case -404:
                            FieldsFilterAdd(FieldsType.Number); break;
                        // رشته
                        case -401:
                        case -402:
                            FieldsFilterAdd(FieldsType.String); break;
                        // آیتم های فیكس
                        case -403: // طبقه بندی خدمت
                            cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                            cboFixItem.DataSource = DBLayerIMS.Services.ServCategoriesList;
                            cboFixItem.DisplayMember = "Name"; cboFixItem.ValueMember = "ID";
                            FieldsFilterAdd(FieldsType.FixItem); break;
                        case -405: // كارشناس خدمت
                            cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                            cboFixItem.DataSource = DBLayerIMS.Referrals.RefServPerformers;
                            cboFixItem.DisplayMember = "FullName"; cboFixItem.ValueMember = "ID";
                            FieldsFilterAdd(FieldsType.FixItem); break;
                        case -406: // پزشك خدمت
                            cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                            cboFixItem.DataSource = DBLayerIMS.Referrals.RefServPerformers;
                            cboFixItem.DisplayMember = "FullName"; cboFixItem.ValueMember = "ID";
                            FieldsFilterAdd(FieldsType.FixItem); break;
                    } break;
                #endregion

                #region DocumentsSearch
                case FieldPart.DocumentsSearch:
                    switch (Convert.ToInt16(cboFields.SelectedValue))
                    {
                        // رشته
                        case -502:
                            FieldsFilterAdd(FieldsType.String); break;
                        // آیتم های فیكس
                        case -501:
                            cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                            cboFixItem.DataSource = DBLayerIMS.Document.DocTypesList.ToList().OrderBy(Data => Data.Title).ToList();
                            cboFixItem.DisplayMember = "Title"; cboFixItem.ValueMember = "ID";
                            FieldsFilterAdd(FieldsType.FixItem); break;
                        case -503:
                            cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                            cboFixItem.DataSource = DBLayerIMS.Referrals.RefServPerformers.ToList().
                                OrderBy(Data => Data.FullName).ToList();
                            cboFixItem.DisplayMember = "FullName"; cboFixItem.ValueMember = "ID";
                            FieldsFilterAdd(FieldsType.FixItem); break;
                        case -506:
                            cboFixItem.DataSource = null; cboFixItem.Items.Clear();
                            cboFixItem.DataSource = Negar.DBLayerPMS.Security.UsersList;
                            cboFixItem.DisplayMember = "FullName"; cboFixItem.ValueMember = "ID";
                            FieldsFilterAdd(FieldsType.FixItem); break;
                        // تاریخ
                        case -504:
                            FieldsFilterAdd(FieldsType.Date); break;
                        // ساعت
                        case -405:
                            FieldsFilterAdd(FieldsType.Time); break;
                    } break;
                #endregion
            }
        }
        #endregion

        #region void FieldsFilterAdd(FieldsType FieldType)
        /// <summary>
        /// تابعی برای افزودن نام شرطهای یك فیلتر به كمبوباكس نوع شرط بر اساس نوع فیلتر
        /// </summary>
        /// <param name="FieldType">نوع شرط</param>
        private void FieldsFilterAdd(FieldsType FieldType)
        {
            cboConditions.Items.Clear();
            switch (FieldType)
            {
                case FieldsType.String:
                    cboConditions.Items.Add("مساوی");
                    cboConditions.Items.Add("شروع با");
                    cboConditions.Items.Add("پایان با");
                    cboConditions.Items.Add("حاوی");
                    txtStringInput.Visible = true;
                    txtStringInput.Text = String.Empty;
                    DateInput.Visible = false;
                    TimeInput.Visible = false;
                    IntInput.Visible = false;
                    cboFixItem.Visible = false;
                    break;
                case FieldsType.Number:
                    cboConditions.Items.Add("مساوی");
                    cboConditions.Items.Add("كوچكتر");
                    cboConditions.Items.Add("كوچكتر مساوی");
                    cboConditions.Items.Add("بزرگتر مساوی");
                    cboConditions.Items.Add("بزرگتر");
                    txtStringInput.Visible = false;
                    DateInput.Visible = false;
                    TimeInput.Visible = false;
                    IntInput.Visible = true;
                    IntInput.Value = 0;
                    cboFixItem.Visible = false;
                    break;
                case FieldsType.Date:
                    cboConditions.Items.Add("مساوی");
                    cboConditions.Items.Add("كوچكتر");
                    cboConditions.Items.Add("كوچكتر مساوی");
                    cboConditions.Items.Add("بزرگتر مساوی");
                    cboConditions.Items.Add("بزرگتر");
                    txtStringInput.Visible = false;
                    DateInput.Visible = true;
                    DateInput.SelectedDateTime = DateTime.Now;
                    TimeInput.Visible = false;
                    IntInput.Visible = false;
                    cboFixItem.Visible = false;
                    break;
                case FieldsType.Time:
                    cboConditions.Items.Add("مساوی");
                    cboConditions.Items.Add("كوچكتر");
                    cboConditions.Items.Add("كوچكتر مساوی");
                    cboConditions.Items.Add("بزرگتر مساوی");
                    cboConditions.Items.Add("بزرگتر");
                    txtStringInput.Visible = false;
                    DateInput.Visible = false;
                    TimeInput.Left = DateInput.Left;
                    TimeInput.Visible = true;
                    TimeInput.Value = new DateTime(2000, 1, 1, 8, 0, 0);
                    IntInput.Visible = false;
                    cboFixItem.Visible = false;
                    break;
                case FieldsType.DateTime:
                    cboConditions.Items.Add("مساوی");
                    cboConditions.Items.Add("كوچكتر");
                    cboConditions.Items.Add("كوچكتر مساوی");
                    cboConditions.Items.Add("بزرگتر مساوی");
                    cboConditions.Items.Add("بزرگتر");
                    txtStringInput.Visible = false;
                    DateInput.Visible = true;
                    DateInput.SelectedDateTime = DateTime.Now;
                    TimeInput.Left = cboFixItem.Left + 20;
                    TimeInput.Visible = true;
                    TimeInput.Value = new DateTime(2000, 1, 1, 8, 0, 0);
                    IntInput.Visible = false;
                    cboFixItem.Visible = false;
                    break;
                case FieldsType.FixItem:
                    cboConditions.Items.Add("مساوی");
                    cboConditions.Items.Add("نا مساوی");
                    txtStringInput.Visible = false;
                    DateInput.Visible = false;
                    TimeInput.Visible = false;
                    IntInput.Visible = false;
                    cboFixItem.Visible = true;
                    break;
                case FieldsType.ComboBox:
                    cboConditions.Items.Add("مساوی");
                    cboConditions.Items.Add("نا مساوی");
                    txtStringInput.Visible = false;
                    DateInput.Visible = false;
                    TimeInput.Visible = false;
                    IntInput.Visible = false;
                    cboFixItem.Visible = true;
                    break;
            }
            cboConditions.SelectedIndex = 0;
        }
        #endregion

        #region void GenerateSearchString()
        /// <summary>
        /// تابعی برای تولید فرمان جستجوی بر اساس فیلتر های تنظیم شده
        /// </summary>
        private void GenerateSearchString()
        {
            if (_SelectedColumns == null) _SelectedColumns = new frmSearchColumns();

            #region Check Inner Join For Tables
            Boolean InnerJoin1_TblPatDetails = false;
            Boolean InnerJoin2_TblPatAddinData = false;
            Boolean InnerJoin3_TblRefList = false;
            Boolean InnerJoin4_TblRefAddinData = false;
            Boolean InnerJoin5_TblRefServices = false;
            Boolean InnerJoin6_TblRefDocs = false;
            foreach (DataGridViewRow row in dgvConditions.Rows)
            {
                if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == "TblPatDetails")
                    InnerJoin1_TblPatDetails = true;
                else if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == "TblPatAddinData")
                    InnerJoin2_TblPatAddinData = true;
                else if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == "TblRefList")
                    InnerJoin3_TblRefList = true;
                else if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == "TblRefAddinData")
                    InnerJoin4_TblRefAddinData = true;
                else if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == "TblRefServices")
                    InnerJoin5_TblRefServices = true;
                else if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == "TblRefDocs")
                    InnerJoin6_TblRefDocs = true;
            }
            if (_SelectedColumns.TreeViewOptions.Nodes[1].Checked) InnerJoin1_TblPatDetails = true;
            if (_SelectedColumns.TreeViewOptions.Nodes[2].Checked) InnerJoin2_TblPatAddinData = true;
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Checked) InnerJoin3_TblRefList = true;
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[1].Checked) InnerJoin4_TblRefAddinData = true;
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Checked) InnerJoin5_TblRefServices = true;
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[3].Checked) InnerJoin6_TblRefDocs = true;
            if (InnerJoin6_TblRefDocs)
            {
                InnerJoin3_TblRefList = true;
                InnerJoin1_TblPatDetails = true;
            }
            if (InnerJoin5_TblRefServices)
            {
                InnerJoin3_TblRefList = true;
                InnerJoin1_TblPatDetails = true;
            }
            if (InnerJoin4_TblRefAddinData)
            {
                InnerJoin3_TblRefList = true;
                InnerJoin1_TblPatDetails = true;
            }
            if (InnerJoin3_TblRefList)
            {
                InnerJoin1_TblPatDetails = true;
            }
            #endregion

            #region Add Select Columns
            _SearchCommand = new StringBuilder();
            _SearchCommand.Append("SELECT ROW_NUMBER() OVER(ORDER BY [TblPatients].[ID] ASC) AS [ردیف] , " +
                "[TblPatients].[ID] AS [PatientListID] ");

            #region Base Pat Data - Nodes[0]
            if (_SelectedColumns.TreeViewOptions.Nodes[0].Nodes[0].Checked)
                _SearchCommand.Append(", [TblPatients].[PatientID] AS [شماره بیمار] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[0].Nodes[1].Checked)
                _SearchCommand.Append(
                    ", ISNULL([TblPatients].[FirstName] + ' ' , '') + [TblPatients].[LastName] AS [نام بیمار] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[0].Nodes[2].Checked)
                _SearchCommand.Append(", CASE [TblPatients].[IsMale] WHEN 0 THEN 'زن' " +
                    "WHEN 1 THEN 'مرد' ELSE NULL END AS [جنسیت] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[0].Nodes[3].Checked)
                _SearchCommand.Append(", [TblPatients].[BirthDate] AS [تاریخ تولد] ");
            #endregion

            #region Pat Detail Data - Nodes[1]
            if (_SelectedColumns.TreeViewOptions.Nodes[1].Nodes[0].Checked)
                _SearchCommand.Append(", [TblPatDetails].[FatherName] AS [نام پدر] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[1].Nodes[1].Checked)
                _SearchCommand.Append(", [TblPatDetails].[IDNo] AS [شماره شناسنامه] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[1].Nodes[2].Checked)
                _SearchCommand.Append(", [TblPatDetails].[NationalID] AS [كد ملی] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[1].Nodes[3].Checked)
                _SearchCommand.Append(", [TblPatDetails].[BirthLocation] AS [محل تولد] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[1].Nodes[4].Checked)
                _SearchCommand.Append(", (SELECT [TblJobs].[Title] FROM [PatientsSystem].[Patients].[Jobs] AS [TblJobs] " +
                    "WHERE [TblPatDetails].[JobIX] = [TblJobs].[ID]) AS [شغل] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[1].Nodes[5].Checked)
                _SearchCommand.Append(", [TblPatDetails].[TelNo1] AS [تلفن 1] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[1].Nodes[6].Checked)
                _SearchCommand.Append(", [TblPatDetails].[TelNo2] AS [تلفن 2] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[1].Nodes[7].Checked)
                _SearchCommand.Append(", (SELECT [TblCities].[Name] FROM [PatientsSystem].[Locations].[Cities] AS [TblCities] " +
                    "WHERE [TblPatDetails].[CityIX] = [TblCities].[ID]) AS [شهر] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[1].Nodes[8].Checked)
                _SearchCommand.Append(", [TblPatDetails].[Email] AS [ایمیل] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[1].Nodes[9].Checked)
                _SearchCommand.Append(", [TblPatDetails].[ZipCode] AS [كد پستی] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[1].Nodes[10].Checked)
                _SearchCommand.Append(", [TblPatDetails].[Address] AS [آدرس پستی] ");
            #endregion

            #region Pat Addin Fields - Nodes[2]
            if (_SelectedColumns.TreeViewOptions.Nodes[2].Checked)
                foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[2].Nodes)
                    if (node.Checked)
                    {
                        Int32 FieldID = Convert.ToInt32(node.Tag);
                        _SearchCommand.Append(", [TblPatAddinData].[Field" + FieldID + "] " +
                            "AS [" + DBLayerIMS.Referrals.PatAddinColsList.Where(Data => Data.ID == FieldID).First().Title + "] ");
                    }
            #endregion

            #region Base Ref Data - Nodes[3].Nodes[0]
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[0].Checked)
                _SearchCommand.Append(", [TblRefList].[RegisterDate] AS [زمان مراجعه] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[1].Checked)
                _SearchCommand.Append(", (SELECT ISNULL([TblUsers].[FirstName] + ' ' , '') + [TblUsers].[LastName] " +
                    "FROM [PatientsSystem].[Security].[Users] AS [TblUsers] " +
                    "WHERE [TblRefList].[AdmitterIX] = [TblUsers].[ID]) AS [كاربر پذیرش كننده]");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[2].Checked)
                _SearchCommand.Append(", [TblRefList].[PrescriptionDate] AS [تاریخ نسخه] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[3].Checked)
                _SearchCommand.Append(", [TblRefList].[Weight] AS [وزن مراجعه بیمار] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[4].Checked)
                _SearchCommand.Append(", (SELECT ISNULL([TblRefPhys].[FirstName] + ' ' , '') + [TblRefPhys].[LastName] " +
                    "FROM [PatientsSystem].[Clinic].[RefPhysicians] AS [TblRefPhys] " +
                    "WHERE [TblRefList].[ReferPhysicianIX] = [TblRefPhys].[ID]) AS [پزشك درخواست كننده]");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[5].Checked)
                _SearchCommand.Append(", (SELECT [TblRefStatus].[Title] " +
                    "FROM [ImagingSystem].[Referrals].[Status] AS [TblRefStatus] " +
                    "WHERE [TblRefList].[ReferStatusIX] = [TblRefStatus].[ID]) AS [وضعیت مراجعه]");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[6].Checked)
                _SearchCommand.Append(", [TblRefList].[Description] AS [توضیحات مراجعه] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[7].Checked)
                _SearchCommand.Append(", (SELECT [TblClinicIns].[Name] " +
                    "FROM [PatientsSystem].[Clinic].[Insurances] AS [TblClinicIns] " +
                    "WHERE [TblRefList].[Ins1IX] = [TblClinicIns].[ID]) AS [بیمه اول] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[8].Checked)
                _SearchCommand.Append(", (SELECT [TblClinicIns].[Name] " +
                    "FROM [PatientsSystem].[Clinic].[Insurances] AS [TblClinicIns] " +
                    "WHERE [TblRefList].[Ins2IX] = [TblClinicIns].[ID]) AS [بیمه دوم] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[9].Checked)
                _SearchCommand.Append(", [ImagingSystem].[Accounting].[FK_CalcSumIns1Price]" +
                    "([TblRefList].[ID]) AS [كل قیمت بیمه 1] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[10].Checked)
                _SearchCommand.Append(", [ImagingSystem].[Accounting].[FK_CalcSumIns1PartPrice]" +
                    "([TblRefList].[ID]) AS [كل سهم بیمه 1] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[11].Checked)
                _SearchCommand.Append(", [ImagingSystem].[Accounting].[FK_CalcSumIns1PatientPart]" +
                    "([TblRefList].[ID]) AS [كل سهم بیمار از بیمه 1] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[12].Checked)
                _SearchCommand.Append(", [ImagingSystem].[Accounting].[FK_CalcSumIns2Price]" +
                    "([TblRefList].[ID]) AS [كل قیمت بیمه 2] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[13].Checked)
                _SearchCommand.Append(", [ImagingSystem].[Accounting].[FK_CalcSumIns2PartPrice]" +
                    "([TblRefList].[ID]) AS [كل سهم بیمه 2] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[14].Checked)
                _SearchCommand.Append(", [ImagingSystem].[Accounting].[FK_CalcRefPayable]" +
                    "([TblRefList].[ID]) AS [كل پرداختنی] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[15].Checked)
                _SearchCommand.Append(", [ImagingSystem].[Accounting].[FK_CalcSumDiscount]" +
                    "([TblRefList].[ID]) AS [كل تخفیف ها] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[16].Checked)
                _SearchCommand.Append(", [ImagingSystem].[Accounting].[FK_CalcSumCost]" +
                    "([TblRefList].[ID]) AS [كل هزینه ها] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[17].Checked)
                _SearchCommand.Append(", [ImagingSystem].[Accounting].[FK_CalcSumRecieve]" +
                    "([TblRefList].[ID]) AS [كل دریافت ها] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[18].Checked)
                _SearchCommand.Append(", [ImagingSystem].[Accounting].[FK_CalcSumPay]" +
                    "([TblRefList].[ID]) AS [كل بازپرداخت ها] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[19].Checked)
                _SearchCommand.Append(", [ImagingSystem].[Accounting].[FK_CalcTotalRefRemain]" +
                    "([TblRefList].[ID]) AS [كل باقیمانده] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[0].Nodes[20].Checked)
                _SearchCommand.Append(", [TblRefList].[PrePayable] AS [پیش پرداخت] ");
            #endregion

            #region Ref Addin Fields - Nodes[3].Nodes[1]
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[1].Checked)
                foreach (TreeNode node in _SelectedColumns.TreeViewOptions.Nodes[3].Nodes[1].Nodes)
                    if (node.Checked)
                    {
                        Int32 FieldID = Convert.ToInt32(node.Tag);
                        _SearchCommand.Append(", [TblRefAddinData].[Field" + FieldID + "] " +
                            "AS [" + DBLayerIMS.Referrals.RefAddinColsList.Where(Data => Data.ID == FieldID).First().Title + "] ");
                    }
            #endregion

            #region Base Ref Service Data - Nodes[3].Nodes[2]
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes[0].Checked)
                _SearchCommand.Append(", (SELECT TOP 1 [TblServiceList].[Code] " +
                    "FROM [ImagingSystem].[Services].[List] AS [TblServiceList] " +
                    "WHERE [TblServiceList].[ID] = [TblRefServices].[ServiceIX]) AS [كد خدمت] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes[1].Checked)
                _SearchCommand.Append(", (SELECT TOP 1 [TblServiceList].[Name] " +
                    "FROM [ImagingSystem].[Services].[List] AS [TblServiceList] " +
                    "WHERE [TblServiceList].[ID] = [TblRefServices].[ServiceIX]) AS [نام خدمت] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes[2].Checked)
                _SearchCommand.Append(
                    ", [ImagingSystem].[Referrals].[FK_GetServiceCatName]([TblRefServices].[ServiceIX]) AS [طبقه بندی خدمت] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes[3].Checked)
                _SearchCommand.Append(", [TblRefServices].[Quantity] AS [تعداد خدمت] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes[4].Checked)
                _SearchCommand.Append(", (SELECT TOP 1 ISNULL([TblServicePerformer].[FirstName] + ' ' , '') + " +
                    "[TblServicePerformer].[LastName] FROM [ImagingSystem].[Referrals].[Performers] AS [TblServicePerformer] " +
                    "WHERE [TblServicePerformer].[ID] = [TblRefServices].[ExpertIX]) AS [كارشناس خدمت] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes[5].Checked)
                _SearchCommand.Append(", (SELECT TOP 1 ISNULL([TblServicePerformer].[FirstName] + ' ' , '') + " +
                    "[TblServicePerformer].[LastName] FROM [ImagingSystem].[Referrals].[Performers] AS [TblServicePerformer] " +
                    "WHERE [TblServicePerformer].[ID] = [TblRefServices].[PhysicianIX]) AS [پزشك خدمت] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes[6].Checked)
                _SearchCommand.Append(", [TblRefServices].[Ins1Price] AS [قیمت بیمه 1 خدمت] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes[7].Checked)
                _SearchCommand.Append(", [TblRefServices].[Ins1PartPrice] AS [سهم بیمه 1 خدمت] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[2].Nodes[8].Checked)
                _SearchCommand.Append(", [TblRefServices].[Ins1Price] - [TblRefServices].[Ins1PartPrice] AS [سهم بیمار از بیمه 1 خدمت] ");
            #endregion

            #region Base Ref Doc Data - Nodes[3].Nodes[3]
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[3].Nodes[0].Checked)
                _SearchCommand.Append(", [TblRefDocs].[Title] AS [عنوان مدرك] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[3].Nodes[1].Checked)
                _SearchCommand.Append(", (SELECT [TblDocTypes].[Title] FROM [ImagingSystem].[Documents].[Type] AS [TblDocTypes] " +
                    "WHERE [TblRefDocs].[TypeIX] = [TblDocTypes].[ID]) AS [نوع مدرك] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[3].Nodes[2].Checked)
                _SearchCommand.Append(", [TblRefDocs].[Date] AS [زمان ثبت مدرك] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[3].Nodes[3].Checked)
                _SearchCommand.Append(", (SELECT ISNULL([TblDocPhys].[FirstName] + ' ' , '') + [TblDocPhys].[LastName] " +
                    "FROM [ImagingSystem].[Referrals].[Performers] AS [TblDocPhys] " +
                    "WHERE [TblRefDocs].[ReportPhysicianIX] = [TblDocPhys].[ID]) AS [پزشك گزارش كننده مدرك] ");
            if (_SelectedColumns.TreeViewOptions.Nodes[3].Nodes[3].Nodes[4].Checked)
                _SearchCommand.Append(", (SELECT ISNULL([TblUsers].[FirstName] + ' ' , '') + [TblUsers].[LastName] " +
                    "FROM [PatientsSystem].[Security].[Users] AS [TblUsers] " +
                    "WHERE [TblRefDocs].[TypistIX] = [TblUsers].[ID]) AS [كاربر ثبت كننده مدرك] ");
            #endregion

            #endregion

            #region Add JOINS
            _SearchCommand.Append("FROM [PatientsSystem].[Patients].[List] AS [TblPatients] ");
            if (InnerJoin1_TblPatDetails)
                _SearchCommand.Append("LEFT OUTER JOIN [PatientsSystem].[Patients].[Details] AS [TblPatDetails] " +
                    "ON [TblPatients].[ID] = [TblPatDetails].[PatientListIX] ");
            if (InnerJoin2_TblPatAddinData)
                _SearchCommand.Append("LEFT OUTER JOIN [ImagingSystem].[Referrals].[PatAdditionalData] AS [TblPatAddinData] " +
                    "ON [TblPatAddinData].[PatientIX] = [TblPatients].[ID] ");
            if (InnerJoin3_TblRefList)
                _SearchCommand.Append("LEFT OUTER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] " +
                    "ON [TblRefList].[PatientIX] = [TblPatients].[ID] ");
            if (InnerJoin4_TblRefAddinData)
                _SearchCommand.Append("LEFT OUTER JOIN [ImagingSystem].[Referrals].[RefAdditionalData] AS [TblRefAddinData] " +
                    "ON [TblRefAddinData].[ReferralIX] = [TblRefList].[ID] ");
            if (InnerJoin5_TblRefServices)
                _SearchCommand.Append("LEFT OUTER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefServices] " +
                    "ON [TblRefList].[ID] = [TblRefServices].[ReferralIX] ");
            if (InnerJoin6_TblRefDocs)
                _SearchCommand.Append("LEFT OUTER JOIN [ImagingSystem].[Referrals].[RefDocuments] AS [TblRefDocs] " +
                    "ON [TblRefList].[ID] = [TblRefDocs].[RefIX] ");
            #endregion

            // افزودن شروط
            if (dgvConditions.Rows.Count != 0) _SearchCommand.Append("WHERE ");
            foreach (DataGridViewRow Row in dgvConditions.Rows)
                _SearchCommand.Append(Row.Cells[1].Value.ToString());
            // افزودن فیلتر خدمات فعال در صورت انتخاب فیلتر یا ستون خدمت
            if (InnerJoin5_TblRefServices)
            {
                if (dgvConditions.Rows.Count == 0) _SearchCommand.Append("WHERE [TblRefServices].[IsActive] = 1");
                else _SearchCommand.Append(" AND [TblRefServices].[IsActive] = 1");
            }
        }
        #endregion

        #endregion

        #region class SearchField
        private class SearchField
        {
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            // ReSharper disable MemberCanBePrivate.Local
            // ReSharper disable UnusedAutoPopertyAccessor
            public Int32 ID { get; set; }
            public String LocaleName { get; set; }
            // ReSharper restore UnusedAutoPropertyAccessor.Local
            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPopertyAccessor

            public SearchField(Int32 TheID, String TheLocaleName)
            {
                ID = TheID;
                LocaleName = TheLocaleName;
            }
        }
        #endregion

    }
}