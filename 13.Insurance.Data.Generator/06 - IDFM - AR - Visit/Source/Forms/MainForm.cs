#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms
{
    /// <summary>
    /// فرم مدیریت اطلاعات دیسكت
    /// </summary>
    internal partial class frmMainForm : Form
    {

        #region Fields

        #region SqlConnection _FormSqlConnection
        /// <summary>
        /// كانكشن برای ارتباط با اس كیو ال
        /// </summary>
        private readonly SqlConnection _FormSqlConnection;
        #endregion

        #region Dictionary<Int16, Int16> _TypePhysician
        /// <summary>
        /// نوع پزشك انتخاب شده
        /// </summary>
        /// <remarks>كلید اول كلید تخصص در بانك و كلید دوم تخصص از نظر بیمه می باشد</remarks>
        private Dictionary<Int16, Int16> _TypePhysician;
        #endregion

        #region  Dictionary<String, String> _ServInternationalCode
        /// <summary>
        /// دیكشنری كد وكد بین المللی خدمات
        /// </summary>
        private Dictionary<Int32, String> _ServInternationalCode;
        #endregion

        #region List<Int32> _SelectedService
        /// <summary>
        /// كلید طبقه بندی های خدمات انتخاب شده و كلید آنها از نظر بیمه
        /// </summary>
        private List<Int32> _SelectedService;
        #endregion

        #region Dictionary<Int16, Int16> _SelectedIns
        /// <summary>
        /// بیمه های انتخاب شده توسط كاربر برای جستجو
        /// </summary>
        /// <remarks>
        /// كلید اول ، كلید بیمه می باشد و كلید دوم كلید نوع آن از نظر سازمان بیمه می باشد
        /// </remarks>
        private Dictionary<Int16, Int16> _SelectedIns;
        #endregion

        #region Dictionary<Int16, String> _InsType
        /// <summary>
        /// نوع های بیمه
        /// </summary>
        private Dictionary<Int16, String> _InsType;

        #endregion

        #region DataTable _DataTableSearchedRefs
        /// <summary>
        /// انتخاب شده
        /// </summary>
        private DataTable _DataTableSearchedRefs;
        #endregion

        #region DataTable _ServiceTable
        /// <summary>
        /// نگهدارنده اطلاعات خدمات یك مراجعه برای قرار دادن در جدول خدمات مراجعه
        /// </summary>
        private DataTable _ServiceTable;
        #endregion

        #region DataTable _SettingDataTable
        /// <summary>
        ///از این شی برای نگهداری اطلاعات تنظیمات مانند:
        ///نام مركز كد مركز كد نوع مركز نحوه مرتب شدن و
        /// فعال یا غیر فعال بودن فیلتر زمان پذیرش استفاده می شود 
        /// </summary>
        private DataTable _SettingDataTable;
        #endregion

        #region DataTable _SettingDataTable2
        /// <summary>
        /// از این شی برای نگهداری اطلاعات بیمه های انتخاب شده
        ///و نوع های انتخاب شده استفاده می شود تا جهت 
        /// بازیابی مجدد در فایل ایكس ام ال مربوطه ذخیره شود 
        /// </summary>
        private DataTable _SettingDataTable2;
        #endregion

        #region DataTable _SettingDataTable3
        /// <summary>
        /// از این شی برای نگهداری نوع خدمات انتخاب شده 
        /// جهت ذخیره و بازیابی مجدد در فایل ایكس ام ال مربوطه استفاده می شود
        /// </summary>
        private DataTable _SettingDataTable3;
        #endregion

        #region  String _ServiceIDSelected
        /// <summary>
        /// متن قسمتی از دستور سلكت 
        /// </summary>
        private String _ServiceIDSelected;
        #endregion

        #region String _PhysiciansCatIDFilePath = "PhysiciansCatID.XML"
        /// <summary>
        /// مسیر ثبت گروه های پزشكی
        /// </summary>
        private const String _PhysiciansCatIDFilePath = "PhysiciansCatID.XML";
        #endregion

        #region String _ServiceInternationalCodeFilePath = "ServiceInternationalCode.Xml"
        /// <summary>
        /// مسیر ثبت كدهای بین المللی
        /// </summary>
        private const String _ServiceInternationalCodeFilePath = "ServiceInternationalCode.Xml";
        #endregion

        #region SqlParameter _Params
        private SqlParameter _ParamPrescribeDate1;
        private SqlParameter _ParamPrescribeDate2;
        private SqlParameter _ParamRefDate1;
        private SqlParameter _ParamRefDate2;
        #endregion

        #region String _SearchQuery
        private String _SearchQuery;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmMainForm()
        {
            InitializeComponent();
            dgvIns.AutoGenerateColumns = false;
            dgvCat.AutoGenerateColumns = false;
            dgvRefData.AutoGenerateColumns = false;
            dgvServiceData.AutoGenerateColumns = false;
            _FormSqlConnection = new SqlConnection(CSManager.GetConnectionString("PatientsSystem"));
            // جهت عدم نمایش ساعت در ستون های تاریخ نسخه و پذیرش و اعتبار دفترچه در جدول مراجعات
            ColRefDate.ShowTime = false;
            ColRefIns1Validation.ShowTime = false;
            ColRefPrescribeDate.ShowTime = false;
            // برای بالا بردن سرعت نمایش فرم از این روش استفاده شد
            Opacity = 0.01;
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            Text += " - نسخه: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            SetControlsToolTipTexts();
            #region Set Default Date Of Controls
            PersianDate CurrentPersianDate = DateTime.Now.ToPersianDate();
            ToDatePrescription.SelectedDateTime = CurrentPersianDate;
            ToDateRefDate.SelectedDateTime = CurrentPersianDate;
            CurrentPersianDate.Day = 1;
            FromDatePrescription.SelectedDateTime = CurrentPersianDate;
            FromDateRefDate.SelectedDateTime = CurrentPersianDate;
            #endregion
            cBoxTime.Checked = false;
            if (!FillBaseData()) { Close(); return; }
            if (File.Exists(_PhysiciansCatIDFilePath)) ReadSavedPhysiciansTypeID();
            else PMBox.Show("فایل پیش فرض تخصص پزشكان یافت نشد!\n" +
                "برای ارائه دیسكت به سازمان بیمه ، نوع تخصص پزشكان ارجاع باید مشخص گردد.",
                "اخطار!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (File.Exists(_ServiceInternationalCodeFilePath)) LoadServiceCode();
            else PMBox.Show("فایل پیش فرض كدهای بین المللی یافت نشد!\n" +
                "برای ارائه دیسكت به سازمان بیمه ، كد بین المللی خدمات باید مشخص گردد.",
                "اخطار!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Opacity = 1;
            Activate();
            Focus();
            BringToFront();
        }
        #endregion

        #region cBoxTime_CheckedChanged
        private void cBoxTime_CheckedChanged(object sender, EventArgs e)
        {
            //غیر فعال كردن پنل مربوط به فیلتر تاریخ پذیرش
            PanelRefDate.Enabled = cBoxTime.Checked;
        }
        #endregion

        #region btnSpecsManage_Click
        private void btnSpecsManage_Click(object sender, EventArgs e)
        {
            //ساختن فرم مدیریت تخصص پزشكان از نظر بیمه
            frmManagePhysSpecs Myform = new frmManagePhysSpecs();
            if (Myform.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Myform.Dispose();
                // خواندن مجدد اطلاعات فایل ایكس ام ال تخصص پزشكان از نظر بیمه
                ReadSavedPhysiciansTypeID();
            }
        }
        #endregion

        #region btnServiceCodeManage_Click
        /// <summary>
        /// ساختن فرم مدیریت كد های بین المللی
        /// </summary>
        private void btnServiceCodeManage_Click(object sender, EventArgs e)
        {
            frmManageServInterCode Myform = new frmManageServInterCode();
            if (Myform.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Myform.Dispose();
                //خواندن مجدد اطلاعات فایل ایكس ام ال كد های بین المللی خدمات
                LoadServiceCode();
            }
        }
        #endregion

        #region btnMakeReport_Click
        /// <summary>
        /// رویداد كلیك بر روی دكمه نمایش اطلاعات
        /// </summary>
        private void btnMakeReport_Click(object sender, EventArgs e)
        {
            #region User Data Validation
            // هشدار برای عدم خواندن اطلاعات كد های هفت رقمی و تخصص پزشكان
            if (_TypePhysician == null)
            {
                PMBox.Show("اطلاعات تخصص پزشكان یافت نشد.\n" +
                    "برای تنظیم این اطلاعات بر روی دكمه\nتنظیم تخصص پزشكان كلیك نمایید!", "هشدار ");
                return;
            }
            if (_ServInternationalCode == null)
            {
                PMBox.Show("اطلاعات كد های بین المللی خدمات یافت نشد.\n" +
                    "برای تنظیم این اطلاعات بر روی دكمه\nتنظیم كد خدمات كلیك نمایید!", "هشدار ");
                return;
            }
            #endregion

            if (!GenerateSearchStrings()) return;
            btnMakeReport.Enabled = false;
            // خالی كردن جداول نتیجه اطلاعات
            dgvRefData.DataSource = null;
            dgvServiceData.DataSource = null;
            Cursor = Cursors.WaitCursor;
            BGWorkerSearchData.RunWorkerAsync();
        }
        #endregion

        #region BGWorkerSearchData_DoWork
        private void BGWorkerSearchData_DoWork(object sender, DoWorkEventArgs e)
        {
            #region Fill Ref DataTable
            SqlCommand MyCommand = new SqlCommand();
            MyCommand.Connection = _FormSqlConnection;
            MyCommand.Parameters.Add(_ParamPrescribeDate1);
            MyCommand.Parameters.Add(_ParamPrescribeDate2);
            if (_ParamRefDate1 != null)
            {
                MyCommand.Parameters.Add(_ParamRefDate1);
                MyCommand.Parameters.Add(_ParamRefDate2);
            }
            _DataTableSearchedRefs = new DataTable("TableName1");
            MyCommand.CommandText = _SearchQuery;
            try
            {
                MyCommand.Connection.Open();
                // ReSharper disable AssignNullToNotNullAttribute
                _DataTableSearchedRefs.Load(MyCommand.ExecuteReader());
                // ReSharper restore AssignNullToNotNullAttribute
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان جستجوی اطلاعات مراجعات از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "IDMF - AR", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                e.Cancel = true;
                return;
            }
            finally { MyCommand.Connection.Close(); }
            #endregion
            #endregion

            // خواندن اطلاعات خدمات مراجعات جستجو شده از بانك
            _ServiceTable = new DataTable("TableName2");
            for (Int32 i = _DataTableSearchedRefs.Rows.Count - 1; i >= 0; i--)
            {
                DataTable RefServices = SelectRefServicesFromDb(Convert.ToInt32(_DataTableSearchedRefs.Rows[i]["RefIX"]));
                if (RefServices == null || RefServices.Rows.Count == 0) _DataTableSearchedRefs.Rows.RemoveAt(i);
                else _ServiceTable.Merge(RefServices);
            }
        }
        #endregion

        #region BGWorkerSearchData_RunWorkerCompleted
        private void BGWorkerSearchData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            btnMakeReport.Enabled = true;
            if (e.Cancelled) return;
            FormTabControl.SelectedTabIndex = 1;
            // پر كردن جدول مراجعات
            dgvRefData.DataSource = _DataTableSearchedRefs;
            dgvRefData.Refresh();

            #region Set Insurance Settings

            #region Fill Type Of Ins In dgvRefData
            // پر كردن ستون كد نوع بیمه و ستون نوع بیمه  
            for (Int16 i = 0; i < dgvRefData.Rows.Count; i++)
                // حركت در دیكشنری بیمه های انتخاب شده
                for (Int16 j = 0; j < _SelectedIns.Count; j++)
                {
                    if (Convert.ToInt16(dgvRefData[ColRefIns1ID.Index, i].Value) == _SelectedIns.ElementAt(j).Key)
                    {
                        //نگه داشتن كد نوع دفترچه برای ذخیره فایل ck
                        dgvRefData[ColRefIns1TypeID.Index, i].Value = _SelectedIns.ElementAt(j).Value;
                        dgvRefData[ColRefInsTypeName.Index, i].Value = _InsType[_SelectedIns.ElementAt(j).Value];
                        break;
                    }
                }
            #endregion

            #region Fill Type Of Ref Physicians In dgvRefData
            // حركت در سطر های جدول مراجعات
            for (Int16 i = 0; i < dgvRefData.Rows.Count; i++)
            {
                // حركت در دیكشنری نوع تخصص های انتخاب شده
                for (Int32 j = 0; j < _TypePhysician.Count; j++)
                {
                    if (dgvRefData[ColRefPhysSpecialtyID.Index, i].Value != null &&
                        dgvRefData[ColRefPhysSpecialtyID.Index, i].Value != DBNull.Value &&
                        Convert.ToInt16(dgvRefData[ColRefPhysSpecialtyID.Index, i].Value) ==
                        _TypePhysician.ElementAt(j).Key)
                    {
                        // ذخیره كردن كد گروه پزشك برای ذخیره فایل نهایی دیسكت برای تگ PG
                        dgvRefData[ColRefPhysTypeID.Index, i].Value = _TypePhysician.ElementAt(j).Value;
                        switch (_TypePhysician.ElementAt(j).Value)
                        {
                            // Note: به علت تعریف نشدن لیست نوع تخصص های پزشكان ، تخصص ها اینجا به صورت دستی اضافه شد
                            case 1: dgvRefData[ColRefPhysTypeName.Index, i].Value = "پزشك"; break;
                            case 2: dgvRefData[ColRefPhysTypeName.Index, i].Value = "دندانپزشك"; break;
                            case 3: dgvRefData[ColRefPhysTypeName.Index, i].Value = "ماما"; break;
                            case 4: dgvRefData[ColRefPhysTypeName.Index, i].Value = "پیرا پزشك"; break;
                        }
                    }
                }
            }
            #endregion

            #endregion

            #region Calculate The Sum Of Prices
            Int32 SumOfPatientPayablePrice = 0;
            Int32 SumOfIns1Price = 0;
            Int32 SumOfIns1PartPrice = 0;
            foreach (DataRow row in _ServiceTable.Rows)
            {
                SumOfIns1Price += Convert.ToInt32(row["Ins1Price"]);
                SumOfPatientPayablePrice += Convert.ToInt32(row["Ins1PatientPrice"]);
                SumOfIns1PartPrice += Convert.ToInt32(row["Ins1PartPrice"]);
            }
            txtTotal1.Text = String.Format("{0:N0}", SumOfIns1Price) + " ریال";
            txtTotal2.Text = String.Format("{0:N0}", SumOfPatientPayablePrice) + " ریال";
            txtTotal3.Text = String.Format("{0:N0}", SumOfIns1PartPrice) + " ریال";
            #endregion

            // فعال كردن رویداد تغییر ردیف جاری در جدول نتیجه مراجعات
            dgvRefData.SelectionChanged -= dgvRefData_SelectionChanged;
            dgvRefData.SelectionChanged += dgvRefData_SelectionChanged;
            dgvRefData_SelectionChanged(null, null);
            SaveSearchSettingsToFile();
            dgvRefData.Refresh();
            dgvRefData.Invalidate();
            ValidateRefData();
        }
        #endregion

        #region btnSelectPath_Click
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FormFolderBrowser.SelectedPath = txtSavePath.Text;
            DialogResult Result = FormFolderBrowser.ShowDialog();
            if (Result != DialogResult.OK) return;
            txtSavePath.Text = FormFolderBrowser.SelectedPath;
        }
        #endregion

        #region btnSaveData_Click
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            GenerateInsDataFile();
        }
        #endregion

        #region dgvIns_CellClick
        private void dgvIns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex != ColInsType.Index && e.ColumnIndex != ColFileName.Index)
            {
                //برای تغییر چك باكس به وسیله كلیك بر روی تمام سطح
                var x = dgvIns.Rows[e.RowIndex].Cells[ColInsSelect.Index].Value;
                if (x == null || !Convert.ToBoolean(x))
                    dgvIns.Rows[e.RowIndex].Cells[ColInsSelect.Index].Value = true;
                else dgvIns.Rows[e.RowIndex].Cells[ColInsSelect.Index].Value = false;
            }
        }
        #endregion

        #region dgvIns_CellValidating
        private void dgvIns_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != ColFileName.Index || e.FormattedValue == null) return;

            foreach (DataGridViewRow row in dgvIns.Rows)
            {
                if (e.RowIndex == row.Index || row.Cells[ColFileName.Index].Value == null) continue;
                if (e.FormattedValue.ToString() == row.Cells[ColFileName.Index].Value.ToString())
                {
                    PMBox.Show("نام فایل وارد شده تكراری می باشد!\nلطفاً مجدداً بررسی كنید.", "اخطار",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvIns.Focus();
                    e.Cancel = true;
                    return;
                }

            }
            String EnteredText = e.FormattedValue.ToString();
            foreach (Char c in EnteredText)
            {
                if (Char.IsDigit(c)) continue;
                PMBox.Show("تنها وارد كردن عبارت عددی مجاز است!\nلطفاً مجدداً بررسی كنید.", "اخطار!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvIns.Focus();
                e.Cancel = true;
                return;
            }
        }
        #endregion

        #region dgvIns_CellEnter
        private void dgvIns_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //برای كومبو باكس نوع بیمه كه بتوان با دو كلیك به جای سه كلیك وارد آن شد
            if (e.RowIndex >= 0 && e.ColumnIndex == ColInsType.Index)
                dgvIns.BeginEdit(false);
        }
        #endregion

        #region dgvRefData_SelectionChanged(object sender, EventArgs e)
        private void dgvRefData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRefData.SelectedCells.Count == 0) return;
            Int32 RowID = dgvRefData.SelectedCells[0].RowIndex;
            DataTable TempTable = _ServiceTable.Clone();
            DataRow[] ReadedData = _ServiceTable.Select("ReferralIX = " + dgvRefData[ColRefID.Index, RowID].Value);
            foreach (DataRow row in ReadedData) TempTable.Rows.Add(row.ItemArray);
            dgvServiceData.DataSource = TempTable;
            dgvServiceData.Refresh();
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult Result = PMBox.Show("آیا مایلید از برنامه خارج شوید؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result != DialogResult.Yes) { e.Cancel = true; return; }
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

            #region btnHelp
            String TooltipText = "نمایش آموزش كاربری فرم.\r\n" +
                                 "این راهنمای كاربری به شما در مورد نحوه عملكرد فرم كمك مینماید.";
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                                                                      Resources.Help_Blue, Resources.SepehrLogo, eTooltipColor.Lemon));
            #endregion

            #region btnExit
            TooltipText = "انصراف از اعمال تغییرات و خروج از فرم.\r\n" +
                "در صورت اجرای این فرمان ، بدون ذخیره سازی اطلاعات وارد شده ، فرم بسته می شود.";
            FormToolTip.SetSuperTooltip(btnExit, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help_Blue, Resources.SepehrLogo, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillBaseData()
        /// <summary>
        /// تابعی جهت خواندن اطلاعات پایه فرم مانند بیمه ها و تنظیمات
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillBaseData()
        {
            #region ColInsType
            // پر كردن كومبو باكس نوع بیمه
            _InsType = new Dictionary<Int16, String>();
            _InsType.Add(0, "انتخاب نشده");
            _InsType.Add(1, "عادی");
            _InsType.Add(2, "خاص");

            ColInsType.DataSource = _InsType.ToList();
            ColInsType.ValueMember = "Key";
            ColInsType.DisplayMember = "Value";
            ColInsType.DataPropertyName = "TypeID";
            #endregion

            #region Read Last Used Data From Data File
            try
            {
                #region Part One - General Data
                _SettingDataTable = new DataTable("Setting");
                _SettingDataTable.Columns.Add("CenterName", typeof(String));
                _SettingDataTable.Columns.Add("CenterTypeCode", typeof(String));
                _SettingDataTable.Columns.Add("CenterCode", typeof(String));
                _SettingDataTable.Columns.Add("Sort", typeof(Boolean));
                _SettingDataTable.Columns.Add("RefDate", typeof(Boolean));

                if (File.Exists("DisketSetting1.XML"))
                {
                    _SettingDataTable.ReadXml("DisketSetting1.XML");
                    txtUnitName.Text = _SettingDataTable.Rows[0]["CenterName"].ToString();
                    txtUnitTypeCode.Text = _SettingDataTable.Rows[0]["CenterTypeCode"].ToString();
                    txtUnitCode.Text = _SettingDataTable.Rows[0]["CenterCode"].ToString();
                    cBoxOrder1.Checked = Convert.ToBoolean(_SettingDataTable.Rows[0]["Sort"]);
                    if (!cBoxOrder1.Checked) cBoxOrder2.Checked = true;
                    cBoxTime.Checked = Convert.ToBoolean(_SettingDataTable.Rows[0]["RefDate"]);
                }
                #endregion

                #region Part Two - Selected Insurance Data
                // خواندن اطلاعات ذخیره شده از فایل
                _SettingDataTable2 = new DataTable("Setting");
                _SettingDataTable2.Columns.Add("InsID", typeof(Int16));
                _SettingDataTable2.Columns.Add("InsType", typeof(Int16));
                _SettingDataTable2.Columns.Add("FileNameCode", typeof(Int16));
                if (File.Exists("DisketSetting2.XML")) _SettingDataTable2.ReadXml("DisketSetting2.XML");

                // پر كردن جدول بیمه ها
                List<SP_SelectInsFullDataResult> InsData = DBLayerIMS.Insurance.InsFullList.
                    Where(Data => Data.ID != null).ToList();
                List<InsListCustom> CustomInsList = new List<InsListCustom>();
                foreach (SP_SelectInsFullDataResult InsResult in InsData)
                    CustomInsList.Add(new InsListCustom(InsResult.ID.Value, InsResult.Name, 0));
                dgvIns.DataSource = CustomInsList;
                foreach (DataGridViewRow Row in dgvIns.Rows)
                {
                    DataRow[] selectedData = _SettingDataTable2.Select("InsID = " + Row.Cells[ColInsID.Index].Value);
                    if (selectedData != null && selectedData.Length != 0)
                    {
                        Row.Cells[ColInsSelect.Index].Value = true;
                        ((InsListCustom)Row.DataBoundItem).TypeID = Convert.ToInt16(selectedData.First()[1]);
                        Row.Cells[ColFileName.Index].Value = selectedData.First()[2].ToString();
                    }
                }
                #endregion

                #region Part Three - Selected Service Categories
                // پر كردن اطلاعات گروه های خدمات در جدول گروه ها
                _SettingDataTable3 = new DataTable("Setting");
                _SettingDataTable3.Columns.Add("CatID", typeof(Int16));
                _SettingDataTable3.Columns.Add("CatType", typeof(Int16));
                if (File.Exists("DisketSetting3.XML")) _SettingDataTable3.ReadXml("DisketSetting3.XML");

                List<SP_SelectCategoriesResult> Categories = DBLayerIMS.Services.ServCategoriesList.
                    Where(Data => Data.ID != null).ToList();
                ColServTypeName.DataSource = Categories;
                ColServTypeName.ValueMember = "ID";
                ColServTypeName.DisplayMember = "Name";
                List<CatListCustom> CustomCatList = new List<CatListCustom>();
                foreach (SP_SelectCategoriesResult result in Categories)
                    CustomCatList.Add(new CatListCustom(result.ID.Value, result.Name, 0));
                // پر كردن جدول طبقه بندی خدمات
                dgvCat.DataSource = CustomCatList;
                foreach (DataGridViewRow Row in dgvCat.Rows)
                {
                    DataRow[] selectedData = _SettingDataTable3.Select("CatID = " + Row.Cells[ColCatID.Index].Value);
                    if (selectedData != null && selectedData.Length != 0)
                    {
                        Row.Cells[ColCatSelect.Index].Value = true;
                        ((CatListCustom)Row.DataBoundItem).TypeID = Convert.ToInt16(selectedData.First()[1]);
                    }
                }
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات پایه فرم مانند بیمه ها و تنظیمات از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "IDMF - AR", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            #endregion

            return true;
        }
        #endregion

        #region void ReadSavedPhysiciansTypeID()
        /// <summary>
        /// پر كردن دیكشنری نوع پزشكان انتخاب شده
        /// </summary>
        private void ReadSavedPhysiciansTypeID()
        {
            #region Read Xml Data
            //خواندن نوع پزشكان از فایل
            DataTable MyDataTable = new DataTable("TableName");
            MyDataTable.Columns.Add("SpecsID", typeof(Int16));
            MyDataTable.Columns.Add("SpecsCode", typeof(Int16));
            try
            {
                MyDataTable.ReadXml(_PhysiciansCatIDFilePath);
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("امكان خواندن اطلاعات ذخیره شده برای تخصص پزشكان وجود ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "IDMF - AR", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            #endregion

            #region Fill _TypePhysician DataSource
            // پر كردن دیكشنری نوع پزشكان انتخاب شده
            _TypePhysician = new Dictionary<Int16, Int16>();
            for (Int32 i = 0; i < MyDataTable.Rows.Count; i++)
                _TypePhysician.Add(Convert.ToInt16(MyDataTable.Rows[i]["SpecsID"]),
                    Convert.ToInt16(MyDataTable.Rows[i]["SpecsCode"]));
            #endregion
        }
        #endregion

        #region void LoadServiceCode()
        /// <summary>
        /// پر كردن دیكشنری كد خدمات و كد بین المللی آنها
        /// </summary>
        private void LoadServiceCode()
        {
            #region Read Xml Code
            // خواندن كد وكد بین المللی خدمات از فایل
            DataTable MyDataTable = new DataTable("TableName");
            MyDataTable.Columns.Add("RowID", typeof(Int32));
            MyDataTable.Columns.Add("InterCode", typeof(String));
            MyDataTable.ReadXml(_ServiceInternationalCodeFilePath);
            #endregion

            #region Fill the _ServInternationalCode
            _ServInternationalCode = new Dictionary<Int32, String>();
            for (Int32 i = 0; i < MyDataTable.Rows.Count; i++)
                _ServInternationalCode.Add(Convert.ToInt32(MyDataTable.Rows[i]["RowID"]),
                    MyDataTable.Rows[i]["InterCode"].ToString());
            #endregion
        }
        #endregion

        #region Boolean GenerateSearchStrings()
        /// <summary>
        /// تابع تولید فرمان جستجوی اطلاعات مراجعات بیماران و خدمات مراجعات
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean GenerateSearchStrings()
        {
            #region Generate Select Columns
            // ساختن متن اصلی دستور 
            StringBuilder StringSelect = new StringBuilder();
            StringSelect.Append("SELECT ROW_NUMBER() OVER(ORDER BY ");
            // تعیین نحوه مرتب سازی گزارش بر اساس انتخاب كاربر
            if (cBoxOrder1.Checked) StringSelect.Append(
                " [TblPhysList].[MedicalID], [TblRefList].[RegisterDate] ASC) AS [RowN] , ");
            else StringSelect.Append(" [TblRefList].[RegisterDate] ASC) AS [RowN] , ");
            StringSelect.Append("[TblRefList].[Ins1IX] AS [InsuranceID] , ");
            StringSelect.Append("[TblInsList].[Name] AS [InsName] , ");
            StringSelect.Append("[TblRefList].[PatientIX] , ");
            StringSelect.Append("(ISNULL ([TblPatList].[FirstName] + ' ' , '') + [TblPatList].[LastName]) AS [FullName] , ");
            StringSelect.Append("[TblRefList].[ID] AS [RefIX] , ");
            StringSelect.Append("[TblRefList].[RegisterDate] , ");
            StringSelect.Append("[TblRefList].[PrescriptionDate] , ");
            StringSelect.Append("[TblRefList].[Ins1Validation] , ");
            StringSelect.Append("[TblRefList].[Ins1Num1] , ");
            StringSelect.Append("[TblPhysList].[MedicalID] , ");
            StringSelect.Append("[TblPhysList].[SpecialtyIX] , ");
            StringSelect.Append("[TblRefList].[Ins1PageNum] , ");
            StringSelect.Append("[TblRefList].[ReferPhysicianIX] AS [PhysicianIX] ");
            StringSelect.Append("FROM [PatientsSystem].[Patients].[List] AS [TblPatList] ");
            StringSelect.Append("INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] ");
            StringSelect.Append("ON [TblPatList].[ID] = [TblRefList].[PatientIX] ");
            StringSelect.Append("INNER JOIN [PatientsSystem].[Clinic].[Insurances] AS [TblInsList] ");
            StringSelect.Append("ON [TblInsList].[ID] = [TblRefList].[Ins1IX] ");
            StringSelect.Append("LEFT OUTER JOIN [PatientsSystem].[Clinic].[RefPhysicians] AS [TblPhysList] ");
            StringSelect.Append("ON [TblPhysList].[ID] = [TblRefList].[ReferPhysicianIX] ");
            #endregion

            #region Generate Filter Strings
            // ساختن شروط انتخاب شده توسط كاربر
            StringBuilder SelectWhereString = new StringBuilder();

            #region Date Filters

            #region Prescription Date
            // اعمال تاریخ انتخاب شده برای نسخه
            SelectWhereString.Append(" WHERE [TblRefList].[PrescriptionDate] >= @Param1 "
                + "AND [TblRefList].[PrescriptionDate] <= @Param2 ");
            #region SqlParam
            _ParamPrescribeDate1 = new SqlParameter("@Param1", SqlDbType.DateTime);
            _ParamPrescribeDate1.Value = new DateTime(FromDatePrescription.SelectedDateTime.Value.Year,
                FromDatePrescription.SelectedDateTime.Value.Month, FromDatePrescription.SelectedDateTime.Value.Day,
                FromTimePrescription.Value.Hour, FromTimePrescription.Value.Minute, FromTimePrescription.Value.Second);
            _ParamPrescribeDate2 = new SqlParameter("@Param2", SqlDbType.DateTime);
            _ParamPrescribeDate2.Value = new DateTime(ToDatePrescription.SelectedDateTime.Value.Year,
                ToDatePrescription.SelectedDateTime.Value.Month, ToDatePrescription.SelectedDateTime.Value.Day,
                ToTimePrescription.Value.Hour, ToTimePrescription.Value.Minute, ToTimePrescription.Value.Second);
            #endregion
            #endregion

            #region RefDate Param
            //اعمال تاریخ انتخاب شده در قسمت مراجعه
            if (cBoxTime.Checked)
            {
                SelectWhereString.Append(" AND [TblRefList].[RegisterDate] >= @Param3 "
                    + "AND [TblRefList].[RegisterDate]<= @Param4 ");
                #region SqlParam
                _ParamRefDate1 = new SqlParameter("@Param3", SqlDbType.DateTime);
                _ParamRefDate1.Value = new DateTime(FromDateRefDate.SelectedDateTime.Value.Year,
                    FromDateRefDate.SelectedDateTime.Value.Month,
                    FromDateRefDate.SelectedDateTime.Value.Day,
                    FromTimeRefDate.Value.Hour, FromTimeRefDate.Value.Minute,
                    FromTimeRefDate.Value.Second);
                _ParamRefDate2 = new SqlParameter("@Param4", SqlDbType.DateTime);
                _ParamRefDate2.Value = new DateTime(ToDateRefDate.SelectedDateTime.Value.Year,
                    ToDateRefDate.SelectedDateTime.Value.Month,
                    ToDateRefDate.SelectedDateTime.Value.Day,
                    ToTimeRefDate.Value.Hour, ToTimeRefDate.Value.Minute,
                    ToTimeRefDate.Value.Second);
                #endregion
            }
            else
            {
                _ParamRefDate1 = null;
                _ParamRefDate2 = null;
            }
            #endregion

            #endregion

            #region Ins1 Filters
            // اعمال فیلتر بیمه ها
            #region Selected Ins ID
            //لیستی از آی دی بیمه های انتخاب شده
            String InsIDSelected = String.Empty;
            //دیكشنری از نام و نوع بیمه انتخاب شده
            _SelectedIns = new Dictionary<Int16, Int16>();
            foreach (DataGridViewRow Row in dgvIns.Rows)
            {
                if (Row.Cells[1].Value == null || !Convert.ToBoolean(Row.Cells[1].Value)) continue;
                InsIDSelected += Row.Cells[0].Value + ",";
                //چك كردن اینكه حتماً نوع بیمه انتخاب شده باشد
                if (Row.Cells[3].Value == null || (Int16)Row.Cells[3].Value == 0)
                {
                    PMBox.Show("برای " + Row.Cells[2].Value + " نوع خاصی انتخاب نشده است!\n" +
                        "لطفاً مجدداً بررسی نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                _SelectedIns.Add(((InsListCustom)Row.DataBoundItem).ID, ((InsListCustom)Row.DataBoundItem).TypeID);
            }
            #endregion

            #region if No Ins was Selected
            // بررسی اینكه آیا بیمه ای انتخاب شده است یا خیر
            if (_SelectedIns.Count == 0)
            {
                PMBox.Show("بیمه ای انتخاب نشده است! لطفاً مجدداً بررسی نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            #endregion

            #region  AddSelectWhereString
            //از بین بردن كاما آخر
            if (InsIDSelected.Length > 1) InsIDSelected = InsIDSelected.Substring(0, InsIDSelected.Length - 1);
            //افزودن شروط به متن شروط قبلی
            SelectWhereString.Append("AND [TblRefList].[Ins1IX] IN (" + InsIDSelected + ")");
            #endregion

            #endregion

            #region Service
            // اعمال فیلتر خدمات
            #region Apply Service Category Filter
            //لیستی از آی دی خدمات انتخاب شده
            _ServiceIDSelected = String.Empty;
            //دیكشنری از نام و كد خدمات انتخاب شده
            _SelectedService = new List<Int32>();
            foreach (DataGridViewRow Row in dgvCat.Rows)
            {
                if (Row.Cells[1].Value == null || !Convert.ToBoolean(Row.Cells[1].Value)) continue;
                _ServiceIDSelected += Row.Cells[0].Value + ",";
                _SelectedService.Add(Convert.ToInt32(Row.Cells[ColCatID.Index].Value));
            }
            #endregion

            #region Not Selected Service
            //بررسی اینكه آیا خدماتی انتخاب شده است یا خیر
            if (_SelectedService.Count < 1)
            {
                PMBox.Show("خدمتی انتخاب نشده است! لطفاً مجدداً بررسی نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return true;
            }
            #endregion

            #region Add Filter String
            // از بین بردن كاما آخر
            if (_ServiceIDSelected.Length > 1) _ServiceIDSelected =
                _ServiceIDSelected.Substring(0, _ServiceIDSelected.Length - 1);
            //افزودن شروط به متن شروط قبلی
            SelectWhereString.Append(" AND (SELECT COUNT(*) " +
                "FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefServices] " +
                "LEFT OUTER JOIN [ImagingSystem].[Services].[List] AS [TblServList] " +
                "ON [TblRefServices].[ServiceIX] = [TblServList].[ID] " +
                "WHERE [TblRefServices].[IsActive] = 1 AND " +
                "[TblRefServices].[ReferralIX] = [TblRefList].[ID] " +
                "AND [TblServList].[CategoryIX] IN (" + _ServiceIDSelected + ")) > 0;");
            #endregion

            #endregion

            #endregion

            _SearchQuery = StringSelect.Append(SelectWhereString).ToString();
            return true;
        }
        #endregion

        #region DataTable SelectRefServicesFromDb(Int32 RefID)
        /// <summary>
        /// تابعی برای خواندن لیست اطلاعات خدمات یك مراجعه از بانك اطلاعاتی
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        private DataTable SelectRefServicesFromDb(Int32 RefID)
        {
            #region Prepare SqlCommand
            SqlCommand MyCommand = new SqlCommand();
            MyCommand.Connection = _FormSqlConnection;
            #endregion

            #region Generate SELECT
            StringBuilder SelectService = new StringBuilder();
            SelectService.Append("SELECT ROW_NUMBER() OVER(ORDER BY [TblRefServs].[ID] ASC) AS [RowNumber] ,"); // i = 0
            SelectService.Append("[TblServList].[Code], "); // i = 1
            SelectService.Append("[TblServList].[Name], "); // i = 2
            SelectService.Append("ISNULL([TblRefServs].[Ins1Price] * [TblRefServs].[Quantity] , 0) AS [Ins1Price] , ");
            SelectService.Append("ISNULL([TblRefServs].[Ins1PartPrice] * [TblRefServs].[Quantity] , 0) AS [Ins1PartPrice] , ");
            SelectService.Append("ISNULL([TblRefServs].[Ins1Price] * [TblRefServs].[Quantity] - " +
                "[TblRefServs].[Ins1PartPrice] * [TblRefServs].[Quantity], 0) AS [Ins1PatientPrice] , "); // i = 5
            SelectService.Append("[TblRefServs].[Quantity] AS [ServQty] , ");  // i = 6
            SelectService.Append("[TblCatList].[Name] AS [CatName], "); // i = 7
            SelectService.Append("[TblServList].[CategoryIX] , "); // i = 8
            SelectService.Append("[TblRefServs].[ReferralIX] , "); // i = 9
            SelectService.Append("[TblRefServs].[ServiceIX] ");  // i = 10
            SelectService.Append("FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefServs] ");
            SelectService.Append("INNER JOIN [ImagingSystem].[Services].[List] AS [TblServList] ");
            SelectService.Append("ON [TblRefServs].[ServiceIX] = [TblServList] .[ID] ");
            SelectService.Append("INNER JOIN  [ImagingSystem].[Services].[Categories] AS [TblCatList] ");
            SelectService.Append("ON [TblServList].[CategoryIX] = [TblCatList].[ID] ");
            SelectService.Append("WHERE [TblRefServs].[ReferralIX] = " + RefID + " ");
            #endregion

            #region Set Service Category
            if (_ServiceIDSelected.Length != 0)
                SelectService.Append("AND [TblServList].[CategoryIX] IN (" + _ServiceIDSelected + ") ");
            #endregion

            #region Set Service IsActive = 1 & Service IsIns1Cover = 1
            SelectService.Append("AND [TblRefServs].[IsActive] = 1 AND [TblRefServs].[IsIns1Cover] = 1 ");
            #endregion

            #region Add ORDER BY
            SelectService.Append("ORDER BY [TblRefServs].[ID] ASC;");
            #endregion

            #region Execute SqlCommand
            DataTable CurrentRefServicesDataTable = new DataTable();
            MyCommand.CommandText = SelectService.ToString();
            try
            {
                MyCommand.Connection.Open();
                // ReSharper disable AssignNullToNotNullAttribute
                CurrentRefServicesDataTable.Load(MyCommand.ExecuteReader());
                // ReSharper restore AssignNullToNotNullAttribute
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان جستجوی اطلاعات خدمات مراجعه از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "IDMF - AR", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            finally
            {
                MyCommand.Connection.Close();
            }
            #endregion

            return CurrentRefServicesDataTable;
        }
        #endregion

        #region void GenerateInsDataFile()
        /// <summary>
        /// تابع تولید فایل دیسكت بر اساس داده های خوانده شده از بانك اطلاعاتی
        /// </summary>
        private void GenerateInsDataFile()
        {
            Int32 RefRowIDInDataFile = 1;
            for (Int32 InsRowIndex = 0; InsRowIndex < dgvIns.Rows.Count; InsRowIndex++)
            {
                if (dgvIns[ColInsSelect.Index, InsRowIndex].Value == null ||
                    Convert.ToBoolean(dgvIns[ColInsSelect.Index, InsRowIndex].Value) == false)
                    continue;

                #region Try Create Data File
                String FileName;
                if (cBoxOrder1.Checked) FileName = "Vis";
                else FileName = "Ser";
                String FilePath = txtSavePath.Text + "\\" + FileName + dgvIns[ColFileName.Index, InsRowIndex].Value + ".Txt";
                try
                {
                    if (File.Exists(FilePath)) File.Delete(FilePath);
                    else File.Create(FilePath).Close();
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان ذخیره اطلاعات در فایل انتخاب شده وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا مسیر انتخاب شده صحیح می باشد؟\n" +
                        "2. آیا فایل مورد نظر توسط برنامه دیگری باز نشده است؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "IDMF - AR", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return;
                }
                #endregion
                #endregion

                #region Generate Data String
                StringBuilder GeneratedDataString = new StringBuilder();

                // شروع فایل دیسكت - <Y>
                GeneratedDataString.AppendLine("<Y>");

                #region <HR> - @ Base Data File Information @
                // هدر فایل - <HR>
                GeneratedDataString.AppendLine("<HR>");
                #region <DC> - Center Code
                // كد مركز - <DC>
                GeneratedDataString.Append("<DC>");
                GeneratedDataString.Append(txtUnitCode.Text.Trim());
                GeneratedDataString.AppendLine("</DC>");
                #endregion

                #region <DN> - Clinic Name (Text)
                // نام مركز خدمات - نام كلینیك یا تصویربرداری - <DN>
                GeneratedDataString.Append("<DN>");
                GeneratedDataString.Append(txtUnitName.Text.Trim());
                GeneratedDataString.AppendLine("</DN>");
                #endregion

                #region <RC> - Ref Count
                Int32 RC = dgvRefData.Rows.Count;
                // تعداد نسخه - <RC>
                GeneratedDataString.Append("<RC>");
                GeneratedDataString.Append(RC);
                GeneratedDataString.AppendLine("</RC>");
                #endregion

                #region <FD> - From Date
                // تاریخ شروع گزارش - تاریخ نسخه<FD>
                GeneratedDataString.Append("<FD>");
                GeneratedDataString.Append(DisketDate.DisketDateTimeMaker(FromDatePrescription.SelectedDateTime.Value));
                GeneratedDataString.AppendLine("</FD>");
                #endregion

                #region <TD> - To Date
                // تاریخ پایان گزارش - تاریخ نسخه - <TD>
                GeneratedDataString.Append("<TD>");
                GeneratedDataString.Append(DisketDate.DisketDateTimeMaker(ToDatePrescription.SelectedDateTime.Value));
                GeneratedDataString.AppendLine("</TD>");
                #endregion

                #region <CR> - Company Name
                // كد - نام - موسسه یا شركت طراح نرم افزار<CR>
                GeneratedDataString.Append("<CR>");
                GeneratedDataString.Append("شركت رایان پرتونگار");
                GeneratedDataString.AppendLine("</CR>");
                #endregion

                GeneratedDataString.AppendLine("</HR>");
                #endregion

                #region <X> - @ Ref & Service Data @
                // ثبت اطلاعات مراجعات
                for (Int16 RefRowIndex = 0; RefRowIndex < dgvRefData.Rows.Count; RefRowIndex++)
                {
                    if (Convert.ToInt16(dgvRefData.Rows[RefRowIndex].Cells[ColRefIns1ID.Index].Value) !=
                        Convert.ToInt16(dgvIns[ColInsID.Index, InsRowIndex].Value)) continue;
                    // خواتدن اطلاعات خدمات مراجعه جاری - در اطلاعات شناسنامه كل مراجعه نیز استفاده می شود
                    DataRow[] CurrentRefServicesList = _ServiceTable.Select("ReferralIX = " +
                        Convert.ToInt32(dgvRefData[ColRefID.Index, RefRowIndex].Value));
                    // خواندن اطلاعات مراجعه جاری
                    #region <X></X> - Read Ref Data
                    // <X> - شروع نسخه
                    GeneratedDataString.AppendLine("<X>");
                    #region <PH></PH> - Ref Header Data
                    // <PH> - شروع هدر نسخه
                    GeneratedDataString.AppendLine("<PH>");

                    #region SQ - Ref Row Number
                    // شماره ترتیب نسخ در پاکت - ردیف جدول استفاده می شود
                    GeneratedDataString.Append("<SQ>");
                    GeneratedDataString.Append(RefRowIDInDataFile);
                    GeneratedDataString.Append("</SQ>");
                    #endregion

                    #region ND - Prescription Data
                    // تاریخ نسخه بیمار
                    GeneratedDataString.Append("<ND>");
                    GeneratedDataString.Append(
                        DisketDate.DisketDateTimeMaker((DateTime)dgvRefData[ColRefPrescribeDate.Index, RefRowIndex].Value));
                    GeneratedDataString.Append("</ND>");
                    #endregion

                    #region RD - Ref Date
                    // تاریخ مراجعه بیمار
                    GeneratedDataString.Append("<RD>");
                    GeneratedDataString.Append(
                        DisketDate.DisketDateTimeMaker((DateTime)dgvRefData[ColRefDate.Index, RefRowIndex].Value));
                    GeneratedDataString.Append("</RD>");
                    #endregion

                    #region PT - Fix Type
                    GeneratedDataString.Append("<PT>");
                    GeneratedDataString.Append("104");
                    GeneratedDataString.Append("</PT>");
                    #endregion

                    #region SN - Ins1 Number 1
                    // شماره سریال دفترچه :شماره اول بیمه
                    GeneratedDataString.Append("<SN>");
                    GeneratedDataString.Append(dgvRefData[ColRefIns1Num1.Index, RefRowIndex].Value);
                    GeneratedDataString.Append("</SN>");
                    #endregion

                    #region VD - Ref Ins Validation Date
                    // تاریخ اعتبار نسخه مراجعه
                    GeneratedDataString.Append("<VD>");
                    if (dgvRefData[ColRefIns1Validation.Index, RefRowIndex].Value == null ||
                        dgvRefData[ColRefIns1Validation.Index, RefRowIndex].Value == DBNull.Value)
                        GeneratedDataString.Append(" ");
                    else GeneratedDataString.Append(
                        DisketDate.DisketDateTimeMaker((DateTime)dgvRefData[ColRefIns1Validation.Index, RefRowIndex].Value));
                    GeneratedDataString.Append("</VD>");
                    #endregion

                    #region PC - Ref Physician Medical ID
                    // شماره نظام پزشكی پزشك معالج
                    GeneratedDataString.Append("<PC>");
                    GeneratedDataString.Append(dgvRefData[ColRefPhysMedID.Index, RefRowIndex].Value);
                    GeneratedDataString.Append("</PC>");
                    #endregion

                    #region RN - Ref Ins Page Number
                    // شماره برگ دفترچه
                    GeneratedDataString.Append("<RN>");
                    GeneratedDataString.Append(dgvRefData[ColRefInsPageNum.Index, RefRowIndex].Value);
                    GeneratedDataString.Append("</RN>");
                    #endregion

                    #region NN - Unknown field
                    GeneratedDataString.Append("<NN>");
                    GeneratedDataString.Append(dgvRefData[ColRefInsPageNum.Index, RefRowIndex].Value);
                    GeneratedDataString.Append("</NN>");
                    #endregion

                    #region PP - Total Ref Ins Price
                    // جمع ریالی نسخه - مجموع "قیمت بیمه" برای كل خدمات مراجعه
                    Int32 RefTotalInsPrice = 0;
                    foreach (DataRow row in CurrentRefServicesList) RefTotalInsPrice += Convert.ToInt32(row[3]);
                    GeneratedDataString.Append("<PP>");
                    GeneratedDataString.Append(RefTotalInsPrice.ToString());
                    GeneratedDataString.Append("</PP>");
                    #endregion

                    #region PS - Total Ref Patient Part Price
                    Int32 RefTotalPatPartPrice = 0;
                    foreach (DataRow row in CurrentRefServicesList) RefTotalPatPartPrice += Convert.ToInt32(row[5]);
                    GeneratedDataString.Append("<PS>");
                    GeneratedDataString.Append(RefTotalPatPartPrice.ToString());
                    GeneratedDataString.AppendLine("</PS>");
                    #endregion

                    #region IS - Total Ref Ins Part Price
                    // جمع سهم بیمه گذار - سهم بیمه برای مراجعه
                    Int32 RefTotalInsPartPrice = 0;
                    foreach (DataRow row in CurrentRefServicesList) RefTotalInsPartPrice += Convert.ToInt32(row[4]);
                    GeneratedDataString.Append("<IS>");
                    GeneratedDataString.Append(RefTotalInsPartPrice.ToString());
                    GeneratedDataString.Append("</IS>");
                    #endregion

                    // </PH> - پایان هدر نسخه
                    GeneratedDataString.AppendLine("</PH>");
                    #endregion

                    #region <BY></BY> - Create Ref Services Data , Row By Row
                    // شروع اطلاعات خدمات مراجعه
                    GeneratedDataString.AppendLine("<BY>");
                    for (Int16 RefServiceIndex = 0; RefServiceIndex < CurrentRefServicesList.Length; RefServiceIndex++)
                    {
                        // شروع اطلاعات هر خدمت
                        GeneratedDataString.Append("<MH>");

                        #region MG - International Code
                        // كد بین المللی - كد هفت رقمی خدمات
                        String InterCode;
                        _ServInternationalCode.TryGetValue(
                            Convert.ToInt16(CurrentRefServicesList[RefServiceIndex][10]), out InterCode);
                        GeneratedDataString.Append("<MG>");
                        GeneratedDataString.Append(InterCode);
                        GeneratedDataString.Append("</MG>");
                        #endregion

                        #region MD - Requested Service Quantity
                        // تعداد تقاضای خدمات - تعداد خدماتی كه در نسخه درخواست شده است
                        // به علت عدم پذیرش این مورد توسط مشتریان ، مقدار آن با خدمات كاملاً عرضه شده برابر می باشد
                        GeneratedDataString.Append("<MD>");
                        GeneratedDataString.Append(CurrentRefServicesList[RefServiceIndex][6].ToString());
                        GeneratedDataString.Append("</MD>");
                        #endregion

                        #region MR - Performed Service Quantity
                        // تعداد عرضه خدمات - تعداد خدمتی كه كاملاً به بیمار عرضه شده
                        GeneratedDataString.Append("<MR>");
                        GeneratedDataString.Append(CurrentRefServicesList[RefServiceIndex][6].ToString());
                        GeneratedDataString.Append("</MR>");
                        #endregion

                        #region MP - Service Ins1 Price
                        // مبلغ هر خدمت - مبلغ بیمه اول برای خدمت
                        GeneratedDataString.Append("<MP>");
                        GeneratedDataString.Append(CurrentRefServicesList[RefServiceIndex][3].ToString());
                        GeneratedDataString.Append("</MP>");
                        #endregion

                        #region MI - Service Ins1 Part Price
                        // مبلغ سهم سازمان برای خدمت
                        GeneratedDataString.Append("<MI>");
                        GeneratedDataString.Append(CurrentRefServicesList[RefServiceIndex][4].ToString());
                        GeneratedDataString.Append("</MI>");
                        #endregion

                        #region MS - Service Patient Ins1 Part Price
                        // مبلغ سهم بیمار برای خدمت
                        GeneratedDataString.Append("<MS>");
                        GeneratedDataString.Append(CurrentRefServicesList[RefServiceIndex][5].ToString());
                        GeneratedDataString.Append("</MS>");
                        #endregion

                        // پایان اطلاعات هر خدمت
                        GeneratedDataString.AppendLine("</MH>");
                    }
                    // اتمام اطلاعات خدمات مراجعه
                    GeneratedDataString.AppendLine("</BY>");
                    #endregion
                    // </X> - پایان نسخه
                    GeneratedDataString.AppendLine("</X>");
                    #endregion

                    // افزودن شماره ردیف
                    RefRowIDInDataFile++;
                }
                #endregion

                // پایان فایل دیسكت - </Y>
                GeneratedDataString.Append("</Y>");
                #endregion

                #region Write Data In File
                try
                {
                    File.WriteAllText(FilePath, GeneratedDataString.ToString(), Encoding.UTF8);
                    DialogResult Result = PMBox.Show("فایل دیسكت با موفقیت تولید و ذخیره گردید.\n" +
                        "آیا مایلید محتویات فایل تولید شده را مشاهده نمایید؟", "پرسش؟",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Result == DialogResult.Yes) Process.Start(FilePath);
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان نوشتن اطلاعات در فایل انتخاب شده وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا فایل مورد نظر توسط برنامه دیگری باز نشده است؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "IDMF - AR", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return;
                }
                #endregion
                #endregion
            }
        }
        #endregion

        #region void SaveSearchSettingsToFile()
        /// <summary>
        /// تابع ذخیره سازی تنظیمات در فایل
        /// </summary>
        private void SaveSearchSettingsToFile()
        {
            #region Part One
            _SettingDataTable = new DataTable("Setting");
            _SettingDataTable.Columns.Add("CenterName", typeof(String));
            _SettingDataTable.Columns.Add("CenterTypeCode", typeof(String));
            _SettingDataTable.Columns.Add("CenterCode", typeof(String));
            _SettingDataTable.Columns.Add("Sort", typeof(Boolean));
            _SettingDataTable.Columns.Add("RefDate", typeof(Boolean));
            _SettingDataTable.Rows.Add(txtUnitName.Text, txtUnitTypeCode.Text, txtUnitCode.Text,
                cBoxOrder1.Checked, cBoxTime.Checked);
            if (!File.Exists("DisketSetting1.XML")) File.Create("DisketSetting1.XML").Close();
            _SettingDataTable.WriteXml("DisketSetting1.XML");
            #endregion

            #region Part Two
            _SettingDataTable2 = new DataTable("Setting");
            _SettingDataTable2.Columns.Add("InsID", typeof(Int16));
            _SettingDataTable2.Columns.Add("InsType", typeof(Int16));
            _SettingDataTable2.Columns.Add("FileNameCode", typeof(Int16));
            foreach (DataGridViewRow Row in dgvIns.Rows)
                if (Row.Cells[ColInsSelect.Index].Value != null && Convert.ToBoolean(Row.Cells[ColInsSelect.Index].Value))
                    _SettingDataTable2.Rows.Add(Row.Cells[ColInsID.Index].Value,
                        Row.Cells[ColInsType.Index].Value, Convert.ToInt16(Row.Cells[ColFileName.Index].Value));
            if (!File.Exists("DisketSetting2.XML")) File.Create("DisketSetting2.XML").Close();
            _SettingDataTable2.WriteXml("DisketSetting2.XML");
            #endregion
        }
        #endregion

        #region private void ValidateRefData()
        /// <summary>
        /// تابعی برای بررسی اطلاعات مراجعات جستجو شده
        /// </summary>
        private void ValidateRefData()
        {
            StringBuilder ErrorMessageString = new StringBuilder();
            Int32 ErrorCount = 0;
            for (Int32 i = 0; i < dgvRefData.Rows.Count; i++)
            {
                Boolean ErrorIndicator = false;
                String ExpertMessage = String.Empty;
                String PageNoMessage = String.Empty;
                String MedicalIDMessage = String.Empty;
                String Ins1No = String.Empty;
                String RefPrescribeDate = String.Empty;
                String Ins1ExpireDate = String.Empty;
                String RefPhysTypeID = String.Empty;
                if (dgvRefData[ColRefPhysSpecialtyID.Index, i].Value == null ||
                    dgvRefData[ColRefPhysSpecialtyID.Index, i].Value == DBNull.Value)
                {
                    ErrorIndicator = true;
                    ExpertMessage = "تخصصی برای پزشك ثبت شده برای این مراجعه بیمار ثبت نشده است!";
                }
                if (dgvRefData[ColRefInsPageNum.Index, i].Value == null ||
                    dgvRefData[ColRefInsPageNum.Index, i].Value == DBNull.Value)
                {
                    ErrorIndicator = true;
                    PageNoMessage = "شماره صفحه دفترچه بیمه برای این مراجعه بیمار ثبت نشده است!";
                }
                if (dgvRefData[ColRefPhysMedID.Index, i].Value == null ||
                    dgvRefData[ColRefPhysMedID.Index, i].Value == DBNull.Value)
                {
                    ErrorIndicator = true;
                    MedicalIDMessage = "شماره نظام پزشكی برای پزشك ثبت شده برای این مراجعه بیمار ثبت نشده است!";
                }
                if (dgvRefData[ColRefIns1Num1.Index, i].Value == null ||
                    dgvRefData[ColRefIns1Num1.Index, i].Value == DBNull.Value)
                {
                    ErrorIndicator = true;
                    Ins1No = "شماره بیمه برای این مراجعه ثبت نشده است!";
                }
                if (dgvRefData[ColRefPrescribeDate.Index, i].Value == null ||
                    dgvRefData[ColRefPrescribeDate.Index, i].Value == DBNull.Value)
                {
                    ErrorIndicator = true;
                    RefPrescribeDate = "تاریخ نسخه مراجعه ثبت نشده است!";
                }
                if (dgvRefData[ColRefIns1Validation.Index, i].Value == null ||
                    dgvRefData[ColRefIns1Validation.Index, i].Value == DBNull.Value)
                {
                    ErrorIndicator = true;
                    Ins1ExpireDate = "تاریخ اعتبار بیمه مراجعه ثبت نشده است!";
                }
                if (dgvRefData[ColRefPhysTypeID.Index, i].Value != null &&
                    dgvRefData[ColRefPhysTypeID.Index, i].Value != DBNull.Value &&
                    (Int16)dgvRefData[ColRefPhysTypeID.Index, i].Value != 1 &&
                    (Int16)dgvRefData[ColRefPhysTypeID.Index, i].Value != 2)
                {
                    ErrorIndicator = true;
                    RefPhysTypeID = "نوع تخصص پزشك ثبت شده با تخصص های تعریف شده برای تصویربرداری همخوانی ندارد!";
                }
                if (ErrorIndicator)
                {
                    ErrorMessageString.Append("در ردیف شماره " + dgvRefData.Rows[i].Cells[ColRefRow.Index].Value);
                    ErrorMessageString.AppendLine(" برای " +
                        dgvRefData.Rows[i].Cells[ColRefPatName.Index].Value + " خطاهای زیر یافت شد:");
                    if (!String.IsNullOrEmpty(ExpertMessage)) ErrorMessageString.AppendLine(ExpertMessage);
                    if (!String.IsNullOrEmpty(PageNoMessage)) ErrorMessageString.AppendLine(PageNoMessage);
                    if (!String.IsNullOrEmpty(MedicalIDMessage)) ErrorMessageString.AppendLine(MedicalIDMessage);
                    if (!String.IsNullOrEmpty(Ins1No)) ErrorMessageString.AppendLine(Ins1No);
                    if (!String.IsNullOrEmpty(RefPrescribeDate)) ErrorMessageString.AppendLine(RefPrescribeDate);
                    if (!String.IsNullOrEmpty(Ins1ExpireDate)) ErrorMessageString.AppendLine(Ins1ExpireDate);
                    if (!String.IsNullOrEmpty(RefPhysTypeID)) ErrorMessageString.AppendLine(RefPhysTypeID);
                    ErrorMessageString.AppendLine("=====================");
                    ErrorCount++;
                }
            }
            if (ErrorMessageString.Length > 0) new frmErrorMessageBox(ErrorMessageString.ToString(), ErrorCount);
        }
        #endregion

        #endregion

        #region Classes

        #region static private class DisketDate
        /// <summary>
        /// ساختن تاریخ با توجه به فرمت مورد نیاز دیسكت بیمه
        /// </summary>
        static private class DisketDate
        {
            /// <summary>
            /// تابعی برای اصلاح تاریخ برای فرمت YYMMDD
            /// </summary>
            /// <param name="NotFormatedDateTime">تاریخ اصلاح نشده</param>
            /// <returns>تاریخ اصلاح شده</returns>
            public static String DisketDateTimeMaker(DateTime NotFormatedDateTime)
            {
                PersianDate PDate = PersianDateConverter.ToPersianDate(NotFormatedDateTime);
                String A1 = "";
                String A2 = "";
                if (PDate.Month < 10) A1 = "0";
                if (PDate.Day < 10) A2 = "0";
                String _DisketDT = PDate.Year.ToString().Substring(2, 2) + A1 + PDate.Month + A2 + PDate.Day;
                return _DisketDT;
            }
        }
        #endregion

        #region private class InsListCustom
        private class InsListCustom
        {
            // ReSharper disable UnusedAutoPopertyAccessor
            public Int16 ID { get; set; }
            public String Name { get; set; }
            public Int16 TypeID { get; set; }
            // ReSharper restore UnusedAutoPopertyAccessor
            public InsListCustom(Int16 TheID, String TheName, Int16 TheTypeID)
            {
                ID = TheID;
                Name = TheName;
                TypeID = TheTypeID;
            }
        }
        #endregion

        #region private class CatListCustom
        private class CatListCustom
        {
            // ReSharper disable UnusedAutoPopertyAccessor
            public Int16 ID { get; set; }
            public String Name { get; set; }
            public Int16 TypeID { get; set; }
            // ReSharper restore UnusedAutoPopertyAccessor
            public CatListCustom(Int16 TheID, String TheName, Int16 TheTypeID)
            {
                ID = TheID;
                Name = TheName;
                TypeID = TheTypeID;
            }
        }
        #endregion

        #endregion

    }
}