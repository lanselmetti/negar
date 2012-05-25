#region using
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Negar;
using Negar.PersianCalendar.Utilities;
using Sepehr.DbLayer;
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

        #region readonly DbClassPS _DbClassPS
        /// <summary>
        /// شی ء لایه داده ارتباط با بانك اطلاعات بیماران
        /// </summary>
        private readonly DbClassPS _DbClassPS;
        #endregion

        #region readonly DbClassIS _DbClassIS
        /// <summary>
        /// شی ء لایه داده ارتباط با بانك اطلاعات تصویربرداری
        /// </summary>
        private readonly DbClassIS _DbClassIS;
        #endregion

        #region SqlConnection _FormSqlConnection
        /// <summary>
        /// كانكشن برای ارتباط با اس كیو ال
        /// </summary>
        private readonly SqlConnection _FormSqlConnection;
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
            _DbClassPS = new DbClassPS(CSManager.GetConnectionString("PatientsSystem"));
            _DbClassIS = new DbClassIS(CSManager.GetConnectionString("ImagingSystem"));
            _FormSqlConnection = new SqlConnection(CSManager.GetConnectionString("PatientsSystem"));
            // جهت عدم نمایش ساعت در ستون های تاریخ نسخه و پذیرش و اعتبار دفترچه در جدول مراجعات
            ColRefDate.ShowTime = false;
            ColRefPrescribeDate.ShowTime = false;
            // برای بالا بردن سرعت نمایش فرم از این روش استفاده شد
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Text += " - نسخه: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
            Opacity = 0.01;
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
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

        #region btnMakeReport_Click
        /// <summary>
        /// رویداد كلیك بر روی دكمه نمایش اطلاعات
        /// </summary>
        private void btnMakeReport_Click(object sender, EventArgs e)
        {
            if (!GenerateSearchStrings()) return;
            btnMakeReport.Enabled = false;
            // خالی كردن جداول نتیجه اطلاعات
            dgvRefData.DataSource = null;
            dgvServiceData.DataSource = null;
            Cursor.Current = Cursors.WaitCursor;
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
                LogManager.SaveLogEntry("IDFM - SS", "Error" , 
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
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
                if (RefServices == null) _DataTableSearchedRefs.Rows.RemoveAt(i);
                else _ServiceTable.Merge(RefServices);
            }
        }
        #endregion

        #region BGWorkerSearchData_RunWorkerCompleted
        private void BGWorkerSearchData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            btnMakeReport.Enabled = true;
            if (e.Cancelled) return;
            FormTabControl.SelectedTabIndex = 1;
            // پر كردن جدول مراجعات
            dgvRefData.DataSource = _DataTableSearchedRefs;
            dgvRefData.Refresh();

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
            if (e.RowIndex >= 0)
            {
                //برای تغییر چك باكس به وسیله كلیك بر روی تمام سطح
                var x = dgvIns.Rows[e.RowIndex].Cells[ColInsSelect.Index].Value;
                if (x == null || !Convert.ToBoolean(x))
                    dgvIns.Rows[e.RowIndex].Cells[ColInsSelect.Index].Value = true;
                else dgvIns.Rows[e.RowIndex].Cells[ColInsSelect.Index].Value = false;
            }
        }
        #endregion

        #region dgvCategories_CellClick
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //برای تغییر چك باكس به وسیله كلیك بر روی تمام سطح
                var x = dgvCat.Rows[e.RowIndex].Cells[ColCatSelect.Index].Value;
                if (x == null || !Convert.ToBoolean(x))
                    dgvCat.Rows[e.RowIndex].Cells[ColCatSelect.Index].Value = true;
                else dgvCat.Rows[e.RowIndex].Cells[ColCatSelect.Index].Value = false;
            }
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
            _DbClassPS.Dispose();
            _DbClassIS.Dispose();
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
            try
            {
                #region Part One - General Data
                _SettingDataTable = new DataTable("Setting");
                _SettingDataTable.Columns.Add("Sort", typeof(Boolean));
                _SettingDataTable.Columns.Add("RefDate", typeof(Boolean));

                if (File.Exists("DisketSetting1.XML"))
                {
                    _SettingDataTable.ReadXml("DisketSetting1.XML");
                    cBoxOrder1.Checked = Convert.ToBoolean(_SettingDataTable.Rows[0]["Sort"]);
                    if (!cBoxOrder1.Checked) cBoxOrder2.Checked = true;
                    cBoxTime.Checked = Convert.ToBoolean(_SettingDataTable.Rows[0]["RefDate"]);
                }
                #endregion

                #region Part Two - Selected Insurance Data
                // خواندن اطلاعات ذخیره شده از فایل
                _SettingDataTable2 = new DataTable("Setting");
                _SettingDataTable2.Columns.Add("InsID", typeof(Int16));
                if (File.Exists("DisketSetting2.XML")) _SettingDataTable2.ReadXml("DisketSetting2.XML");

                // پر كردن جدول بیمه ها
                dgvIns.DataSource = _DbClassIS.SP_SelectInsFullData().Where(Data => Data.ID != null).ToList();
                foreach (DataGridViewRow Row in dgvIns.Rows)
                {
                    DataRow[] selectedData = _SettingDataTable2.Select("InsID = " + Row.Cells[ColInsID.Index].Value);
                    if (selectedData != null && selectedData.Length != 0)
                    {
                        Row.Cells[ColInsSelect.Index].Value = true;
                    }
                }
                #endregion

                #region Part Three - Selected Service Categories
                // پر كردن اطلاعات گروه های خدمات در جدول گروه ها
                _SettingDataTable3 = new DataTable("Setting");
                _SettingDataTable3.Columns.Add("CatID", typeof(Int16));
                if (File.Exists("DisketSetting3.XML")) _SettingDataTable3.ReadXml("DisketSetting3.XML");

                // پر كردن جدول طبقه بندی خدمات
                dgvCat.DataSource = _DbClassIS.SP_SelectCategories().Where(Data => Data.ID != null).ToList();
                foreach (DataGridViewRow Row in dgvCat.Rows)
                {
                    DataRow[] selectedData = _SettingDataTable3.Select("CatID = " + Row.Cells[ColCatID.Index].Value);
                    if (selectedData != null && selectedData.Length != 0)
                    {
                        Row.Cells[ColCatSelect.Index].Value = true;
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
                LogManager.SaveLogEntry("IDFM - SS", "Error", Ex.Message + "\n" + Ex.StackTrace, 
                    EventLogEntryType.Error);
                return false;
            }
            #endregion

            return true;
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
                " [TblRefList].[PrescriptionDate] , [TblRefList].[RegisterDate] ASC) AS [RowN] , ");
            else StringSelect.Append(" [TblRefList].[RegisterDate] , [TblRefList].[PrescriptionDate]  ASC) AS [RowN] , ");
            StringSelect.Append("[TblInsList].[Name] AS [InsName] , ");
            StringSelect.Append("(ISNULL ([TblPatList].[FirstName] + ' ' , '') + [TblPatList].[LastName]) AS [FullName] , ");
            StringSelect.Append("[TblRefList].[ID] AS [RefIX] , ");
            StringSelect.Append("[TblRefList].[RegisterDate] , ");
            StringSelect.Append("[TblRefList].[PrescriptionDate] , ");
            StringSelect.Append("[TblRefList].[Ins1Num1] ");
            StringSelect.Append("FROM [PatientsSystem].[Patients].[List] AS [TblPatList] ");
            StringSelect.Append("INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] ");
            StringSelect.Append("ON [TblPatList].[ID] = [TblRefList].[PatientIX] ");
            StringSelect.Append("INNER JOIN [PatientsSystem].[Clinic].[Insurances] AS [TblInsList] ");
            StringSelect.Append("ON [TblInsList].[ID] = [TblRefList].[Ins1IX] ");
            StringSelect.Append("INNER JOIN [PatientsSystem].[Clinic].[RefPhysicians] AS [TblPhysList] ");
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
            foreach (DataGridViewRow Row in dgvIns.Rows)
            {
                if (Row.Cells[1].Value == null || !Convert.ToBoolean(Row.Cells[1].Value)) continue;
                InsIDSelected += Row.Cells[0].Value + ",";
            }
            #endregion

            #region if No Ins was Selected
            // بررسی اینكه آیا بیمه ای انتخاب شده است یا خیر
            if (InsIDSelected == String.Empty)
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
            foreach (DataGridViewRow Row in dgvCat.Rows)
            {
                if (Row.Cells[1].Value == null || !Convert.ToBoolean(Row.Cells[1].Value)) continue;
                _ServiceIDSelected += Row.Cells[0].Value + ",";
            }
            #endregion

            #region Not Selected Service
            //بررسی اینكه آیا خدماتی انتخاب شده است یا خیر
            if (_ServiceIDSelected == String.Empty)
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
                "WHERE [TblRefServices].[ReferralIX] = [TblRefList].[ID] " +
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
            SelectService.Append("ISNULL([TblRefServs].[Ins1Price] * [TblRefServs].[Quantity] , 0) AS [Ins1Price] , ");// i = 3
            SelectService.Append("ISNULL([TblRefServs].[Ins1PartPrice] * [TblRefServs].[Quantity] , 0) AS [Ins1PartPrice] , ");// i = 4
            SelectService.Append("ISNULL([TblRefServs].[Ins1Price] * [TblRefServs].[Quantity] - " +
                "[TblRefServs].[Ins1PartPrice] * [TblRefServs].[Quantity], 0) AS [Ins1PatientPrice] , "); // i = 5
            SelectService.Append("[TblRefServs].[Quantity] AS [ServQty] , ");  // i = 6
            SelectService.Append("[TblCatList].[Name] AS [CatName], "); // i = 7
            SelectService.Append("[TblRefServs].[ReferralIX] "); // i = 8
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
                LogManager.SaveLogEntry("IDFM - SS", "Error", 
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
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
            #region Try Create Data File
            String FilePath = txtSavePath.Text + "\\IRIBInsurer.Txt";
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
                LogManager.SaveLogEntry("IDFM - SS", "Error", 
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            #endregion

            #region Generate Data String
            StringBuilder GeneratedDataString = new StringBuilder();
            // ثبت اطلاعات مراجعات
            for (Int16 RefRowIndex = 0; RefRowIndex < dgvRefData.Rows.Count; RefRowIndex++)
            {
                // خواتدن اطلاعات خدمات مراجعه جاری - در اطلاعات شناسنامه كل مراجعه نیز استفاده می شود
                DataRow[] CurrentRefServicesList = _ServiceTable.Select("ReferralIX = " + Convert.ToInt32(dgvRefData[ColRefID.Index, RefRowIndex].Value));
               
                #region SN - Ins1 Number 1
                // شماره سریال دفترچه :شماره اول بیمه
                GeneratedDataString.Append("  ");
                GeneratedDataString.Append(dgvRefData[ColRefIns1Num1.Index, RefRowIndex].Value);
                GeneratedDataString.Append("                 ");
                #endregion

                #region IS - Total Ref Ins Part Price
                // جمع سهم بیمه گذار - سهم بیمه برای مراجعه
                Int32 RefTotalInsPartPrice = 0;
                foreach (DataRow row in CurrentRefServicesList) RefTotalInsPartPrice += Convert.ToInt32(row[4]);
                GeneratedDataString.AppendLine(RefTotalInsPartPrice.ToString());
                #endregion

            }
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
                LogManager.SaveLogEntry("IDFM - SS", "Error", 
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            #endregion
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
            _SettingDataTable.Columns.Add("Sort", typeof(Boolean));
            _SettingDataTable.Columns.Add("RefDate", typeof(Boolean));
            _SettingDataTable.Rows.Add(cBoxOrder1.Checked, cBoxTime.Checked);
            if (!File.Exists("DisketSetting1.XML")) File.Create("DisketSetting1.XML").Close();
            _SettingDataTable.WriteXml("DisketSetting1.XML");
            #endregion

            #region Part Two
            _SettingDataTable2 = new DataTable("Setting");
            _SettingDataTable2.Columns.Add("InsID", typeof(Int16));
            foreach (DataGridViewRow Row in dgvIns.Rows)
                if (Row.Cells[ColInsSelect.Index].Value != null && Convert.ToBoolean(Row.Cells[ColInsSelect.Index].Value))
                    _SettingDataTable2.Rows.Add(Row.Cells[ColInsID.Index].Value);
            if (!File.Exists("DisketSetting2.XML")) File.Create("DisketSetting2.XML").Close();
            _SettingDataTable2.WriteXml("DisketSetting2.XML");
            #endregion

            #region Part Three
            _SettingDataTable3 = new DataTable("Setting");
            _SettingDataTable3.Columns.Add("CatID", typeof(Int16));
            foreach (DataGridViewRow Row in dgvCat.Rows)
                if (Row.Cells[ColCatSelect.Index].Value != null && Convert.ToBoolean(Row.Cells[ColCatSelect.Index].Value))
                    _SettingDataTable3.Rows.Add(Row.Cells[ColCatID.Index].Value);
            if (!File.Exists("DisketSetting3.XML")) File.Create("DisketSetting3.XML").Close();
            _SettingDataTable3.WriteXml("DisketSetting3.XML");
            #endregion
        }
        #endregion

        #endregion
    }
}