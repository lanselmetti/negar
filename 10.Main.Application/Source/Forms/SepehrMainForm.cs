#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Administration;
using Sepehr.Forms.Documents;
using Sepehr.Forms.Help;
using Sepehr.Forms.Search;
using Sepehr.Forms.UserSettings;
using Sepehr.Properties;
using Sepehr.Forms.Documents.Classes;
using Sepehr.Forms.Admission.Classes;
#endregion

namespace Sepehr.Forms
{
    /// <summary>
    /// فرم اصلی سیستم
    /// </summary>
    internal partial class frmSepehrMainForm : Form
    {

        #region Fields & Properties

        #region frmSplash _SplashForm
        private frmSplash _SplashForm;
        #endregion

        #region enum SearchStates
        /// <summary>
        /// وضعیت جاری برای جستجوی اطلاعات بیماران
        /// </summary>
        private enum SearchStates
        {
            /// <summary>
            /// جستجو با كلید بیمار
            /// </summary>
            SearchByPatientListID = 0,
            /// <summary>
            /// جستجوی با كد بیمار
            /// </summary>
            SearchByPatientID = 1,
            /// <summary>
            /// جستجو با شروط پایه بیمار
            /// </summary>
            SearchByPatientsFilter = 2,
            /// <summary>
            /// جستجو با لیستی از كدهای بیمار
            /// </summary>
            SearchByPatientIDList = 3,
            /// <summary>
            /// جستجوی بیماران دارای كد مشابه با كد بیمار
            /// </summary>
            SearchSamePatByPatientID = 4,
            /// <summary>
            /// خواندن اطلاعات لازم برای ذخیره سازی در حافظه
            /// </summary>
            ReadCachedData = 5
        }
        #endregion

        #region SearchStates _CurrentSearchState
        /// <summary>
        /// وضعیت جاری جستجو
        /// </summary>
        private SearchStates _CurrentSearchState;
        #endregion

        #region Boolean _IsGridRightClicked = true
        private Boolean _IsGridRightClicked = true;
        #endregion

        #region Queue<Int32> _RecentPatientsList
        /// <summary>
        /// لیست بیماران مشاهده شده توسط كاربر
        /// </summary>
        // ReSharper disable FieldCanBeMadeReadOnly
        private Queue<Int32> _RecentPatientsList;
        // ReSharper restore FieldCanBeMadeReadOnly
        #endregion

        #region List<PatientSearcher.PatientData> _SearchResult
        /// <summary>
        /// نتیجه جستجوی بیماران ، قابل نمایش در جدول بیماران
        /// </summary>
        private List<PatientSearcher.PatientData> _SearchResult;
        #endregion

        #region Int32 _CurrentPatientListID
        /// <summary>
        /// كلید بیمار اخیری كه اكنون كلیك شده
        /// </summary>
        private Int32 _CurrentPatientListID;
        #endregion

        #region frmAdvancedSearch _SearchForm
        /// <summary>
        /// فرم جستجوی پیشرفته
        /// </summary>
        private frmAdvancedSearch _SearchForm;
        #endregion

        #region Settings Fields
        /// <summary>
        /// كلید رفتار برنامه پس از 2 بار كلیك بر روی یك بیمار
        /// </summary>
        private Byte _DefaultPatientClickBehaviorID;
        /// <summary>
        /// كلید رفتار برنامه پس از 2 بار كلیك بر روی یك مراجعه
        /// </summary>
        private Byte _DefaultRefClickBehaviorID;
        /// <summary>
        /// تعیین افزودن آخرین بیمار بررسی شده به لیست آخرین بیماران
        /// </summary>
        private Boolean _ShouldAddRecentPatients;
        /// <summary>
        /// دریافت تایید از كاربر هنگام خروج از برنامه
        /// </summary>
        private Boolean _ShouldAskUserForExit;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده فرم
        /// </summary>
        public frmSepehrMainForm()
        {
            _SplashForm = new frmSplash();
            _SplashForm.Show(this);
            InitializeComponent();
            #region Set Form Properties
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            dgvPatData.AutoGenerateColumns = false;
            dgvRefData.AutoGenerateColumns = false;
            FormMenu.BackgroundHoverEnabled = false;
            FormMenu.BackgroundStyle.BackColor = Color.FromArgb(200, 220, 250);
            FormMenu.BackgroundStyle.BackColor2 = Color.White;
            RBarSearchPatients.BackgroundHoverEnabled = false;
            RBarSearchPatients.BackgroundStyle.BackColor = Color.White;
            RBarSearchPatients.BackgroundStyle.BackColor2 = Color.FromArgb(200, 220, 250);
            // تنظیمات خصوصیات جعبه متن های جستجوی بیماران
            txtPatientID.TextBox.Font = new Font("B Titr", 10, FontStyle.Bold);
            txtPatientID.TextBox.RightToLeft = RightToLeft.No;
            txtPatientID.TextBox.TextAlign = HorizontalAlignment.Center;
            txtPatientID.TextBox.PreviewKeyDown += Control_PreviewKeyDown;
            txtFName.TextBox.Font = new Font("Tahoma", 9);
            txtFName.TextBox.TextAlign = HorizontalAlignment.Center;
            txtFName.TextBox.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            txtFName.TextBox.PreviewKeyDown += Control_PreviewKeyDown;
            txtLName.TextBox.Font = new Font("Tahoma", 9);
            txtLName.TextBox.TextAlign = HorizontalAlignment.Center;
            txtLName.TextBox.Padding = new System.Windows.Forms.Padding(100, 0, 100, 0);
            txtLName.TextBox.PreviewKeyDown += Control_PreviewKeyDown;
            txtAge.TextBox.TextAlign = HorizontalAlignment.Center;
            txtAge.TextBox.PreviewKeyDown += Control_PreviewKeyDown;
            txtAge.TextBox.Validating += TextBox_Validating;
            #endregion
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            if (!CheckCurrentLockLicenses() || !ReloadApplicationData()) { _ShouldAskUserForExit = false; Close(); return; }
            // نمونه سازی از شیء لیست آخرین بیماران دیده شده
            _RecentPatientsList = new Queue<Int32>();
            #region Set Main Form Properties
            Text += " - نسخه: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            txtCurrentUserName.Text = Negar.DBLayerPMS.Security.UsersList.
                Where(Data => Data.ID == SecurityManager.CurrentUserID).Select(Data => Data.FullName).First();
            txtCSName.Text = CSManager.CurrentSetting;
            txtPatientID.Focus();
            SetControlsToolTipTexts();
            #endregion
            #region ReadCachedData
            // بدست آوردن آخرین بیمار ثبت شده
            Int32? LastID = Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(true);
            _CurrentSearchState = SearchStates.ReadCachedData;
            BWFormThread.RunWorkerAsync(LastID);
            #endregion
        }
        #endregion

        #region @@@ btnLastPatients Event Handlers @@@

        #region btnRecentPatient_MouseUp
        void btnRecentPatient_MouseUp(object sender, MouseEventArgs e)
        {
            _IsGridRightClicked = false;
            _CurrentPatientListID = Convert.ToInt32(((ButtonItem)sender).Tag);
            if (e.Button == MouseButtons.Right)
                cmsdgvPatData.PopupMenu(MousePosition);
        }
        #endregion

        #region btnRecentPatient_Click
        void btnRecentPatient_Click(object sender, EventArgs e)
        {
            cmsdgvPatData.ClosePopup();
            dgvPatData_CellMouseDoubleClick(Convert.ToInt32(((ButtonItem)sender).Tag), null);
        }
        #endregion

        #endregion

        #region @@@ Panel Patients @@@

        #region cBoxSearchBy_Click
        private void cBoxSearchBy_Click(object sender, EventArgs e)
        {
            if (sender.Equals(cBoxSearchByPatientID) || sender.Equals(lblSearchByPatientID))
            {
                cBoxSearchByPatientID.Checked = true;
                cBoxSearchByRefID.Checked = false;
            }
            else
            {
                cBoxSearchByPatientID.Checked = false;
                cBoxSearchByRefID.Checked = true;
            }
        }
        #endregion

        #region btnNextPatient_Click
        /// <summary>
        /// دكمه ی جابجایی بیمار جاری به بیمار بعدی
        /// </summary>
        private void btnNextPatient_Click(object sender, EventArgs e)
        {
            if (BWFormThread.IsBusy) return;
            txtFName.TextBox.Clear();
            txtLName.TextBox.Clear();
            txtAge.TextBox.Clear();

            #region txtPatientID == Null
            if (String.IsNullOrEmpty(txtPatientID.TextBox.Text.Trim()))
            {
                // بدست آوردن آخرین بیمار ثبت شده
                Int32? LastID = Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(true);
                // جستجوی شماره بیمار بر اساس كلید بیمار
                if (LastID == null) return;
                _CurrentSearchState = SearchStates.SearchByPatientListID;
                BWFormThread.RunWorkerAsync(LastID);
            }
            #endregion

            #region txtPatientID != Null
            else
            {
                Int32? PatientID = Negar.DBLayerPMS.Patients.GetPatListIDByPatientID(txtPatientID.TextBox.Text.Trim());
                if (PatientID == null || PatientID == 0) return;
                Int32? NextID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(PatientID.Value, true);
                if (NextID == null || NextID == PatientID) return;
                _CurrentSearchState = SearchStates.SearchByPatientListID;
                BWFormThread.RunWorkerAsync(NextID);
            }
            #endregion
        }
        #endregion

        #region btnPrevPatient_Click
        /// <summary>
        /// دكمه ی جابجایی بیمار جاری به بیمار قبلی
        /// </summary>
        private void btnPrevPatient_Click(object sender, EventArgs e)
        {
            if (BWFormThread.IsBusy) return;
            txtFName.TextBox.Clear();
            txtLName.TextBox.Clear();
            txtAge.TextBox.Clear();

            #region txtPatientID == Null
            if (String.IsNullOrEmpty(txtPatientID.TextBox.Text.Trim()))
            {
                // بدست آوردن آخرین بیمار ثبت شده
                Int32? LastID = Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(true);
                // جستجوی شماره بیمار بر اساس كلید بیمار
                if (LastID == null) return;
                _CurrentSearchState = SearchStates.SearchByPatientListID;
                BWFormThread.RunWorkerAsync(LastID);
            }
            #endregion

            #region txtPatientID != Null
            else
            {
                Int32? PatientID = Negar.DBLayerPMS.Patients.GetPatListIDByPatientID(txtPatientID.TextBox.Text.Trim());
                if (PatientID == null || PatientID == 0) return;
                Int32? PrevID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(PatientID.Value, false);
                if (PrevID == null || PrevID == PatientID) return;
                _CurrentSearchState = SearchStates.SearchByPatientListID;
                BWFormThread.RunWorkerAsync(PrevID);
            }
            #endregion
        }
        #endregion

        #region Control_PreviewKeyDown
        private void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                if (((Control)sender).Name == dgvPatData.Name || sender.GetHashCode() == txtAge.TextBox.GetHashCode())
                {
                    txtPatientID.TextBox.SelectAll();
                    txtPatientID.Focus();
                }
                else if (sender.GetHashCode() == txtPatientID.TextBox.GetHashCode())
                {
                    txtFName.TextBox.SelectAll();
                    txtFName.Focus();
                }
                else if (sender.GetHashCode() == txtFName.TextBox.GetHashCode())
                {
                    txtLName.TextBox.SelectAll();
                    txtLName.Focus();
                }
                else if (sender.GetHashCode() == txtLName.TextBox.GetHashCode())
                {
                    txtAge.TextBox.SelectAll();
                    txtAge.Focus();
                }
            }
            else if (e.KeyData == (Keys.Shift | Keys.Tab))
            {
                if (((Control)sender).Name == dgvPatData.Name || sender.GetHashCode() == txtPatientID.TextBox.GetHashCode())
                {
                    txtAge.TextBox.SelectAll();
                    txtAge.Focus();
                }
                else if (sender.GetHashCode() == txtAge.TextBox.GetHashCode())
                {
                    txtLName.TextBox.SelectAll();
                    txtLName.Focus();
                }
                else if (sender.GetHashCode() == txtFName.TextBox.GetHashCode())
                {
                    txtPatientID.TextBox.SelectAll();
                    txtPatientID.Focus();
                }
                else if (sender.GetHashCode() == txtLName.TextBox.GetHashCode())
                {
                    txtFName.TextBox.SelectAll();
                    txtFName.Focus();
                }
            }
            else if (((Control)sender).Name == dgvPatData.Name && e.KeyData == Keys.Apps &&
                dgvPatData.SelectedRows.Count != 0)
            {
                dgvPatData_CellMouseClick(1, new DataGridViewCellMouseEventArgs(0, dgvPatData.SelectedRows[0].Index,
                    dgvPatData.Width - 50, Top + FormMenu.Height + dgvPatData.Top + dgvPatData.ColumnHeadersHeight +
                    dgvPatData.GetRowDisplayRectangle(dgvPatData.SelectedCells[0].RowIndex, true).Top - 20,
                    new MouseEventArgs(MouseButtons.Right, 1, 1, 1, 1)));
            }
            else if (((Control)sender).Name == dgvPatData.Name && e.KeyData == Keys.Enter &&
                dgvPatData.SelectedRows.Count != 0) dgvPatData_CellMouseDoubleClick(null,
                    new DataGridViewCellMouseEventArgs(0, dgvPatData.SelectedRows[0].Index,
                    0, 0, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)));
        }
        #endregion

        #region dgvData_KeyDown
        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) e.Handled = true;
        }
        #endregion

        #region txtPatientFilters_KeyPress
        /// <summary>
        /// روالی برای مدیریت كلیدهای وارد شده در فیلترهای جستجوی ساده بیمار
        /// </summary>
        private void txtPatientFilters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBoxItem)sender).Name == txtAge.Name &&
                (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))) e.Handled = true;
            else if (e.KeyChar == '\r') // Enter Pressed...
            {
                if (((TextBoxItem)sender).Name == txtPatientID.Name)
                {
                    if (String.IsNullOrEmpty(((TextBoxItem)sender).TextBox.Text.Trim())) return;
                    txtFName.TextBox.Clear();
                    txtLName.TextBox.Clear();
                    txtAge.TextBox.Clear();
                }
                else txtPatientID.TextBox.Clear();
                btnSearch_Click(null, null);
            }
        }
        #endregion

        #region TextBox_Validating
        void TextBox_Validating(object sender, CancelEventArgs e)
        {
            Boolean IsError = false;
            foreach (char Charecter in txtAge.TextBox.Text)
                if (!Char.IsNumber(Charecter) && !Char.IsControl(Charecter)) IsError = true;
            if (IsError)
            {
                PMBox.Show("برای سن باید یك مقدار عددی وارد نمایید!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAge.TextBox.SelectAll();
                e.Cancel = true;
            }
        }
        #endregion

        #region btnSearch_Click
        /// <summary>
        /// روالی برای مدیریت جستجوی بیمار بر اساس فیلتر های ساده فرم اصلی
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (BWFormThread.IsBusy) return;
            Cursor.Current = Cursors.WaitCursor;
            if (String.IsNullOrEmpty(txtPatientID.TextBox.Text.Trim()))
            {
                txtPatientID.TextBox.Text = String.Empty;
                txtFName.TextBox.Text = txtFName.TextBox.Text.Trim();
                txtLName.TextBox.Text = txtLName.TextBox.Text.Trim();
                txtAge.TextBox.Text = txtAge.TextBox.Text.Trim();
                if (String.IsNullOrEmpty(txtFName.TextBox.Text) &&
                    String.IsNullOrEmpty(txtLName.TextBox.Text) &&
                    String.IsNullOrEmpty(txtAge.TextBox.Text)) return;
                String[] ParameterObject = new String[3];
                ParameterObject[0] = txtFName.TextBox.Text;
                ParameterObject[1] = txtLName.TextBox.Text;
                if (!String.IsNullOrEmpty(txtAge.TextBox.Text))
                    ParameterObject[2] = txtAge.TextBox.Text;
                _CurrentSearchState = SearchStates.SearchByPatientsFilter;
                BWFormThread.RunWorkerAsync(ParameterObject);
            }
            else
            {
                txtPatientID.TextBox.Text = txtPatientID.TextBox.Text.Trim();
                txtFName.TextBox.Text = String.Empty;
                txtLName.TextBox.Text = String.Empty;
                txtAge.TextBox.Text = String.Empty;
                if (cBoxSearchByRefID.Checked)
                {
                    Int32? PatListID = Referrals.GetPatIDByRefID(Convert.ToInt32(txtPatientID.TextBox.Text.Trim()));
                    if (PatListID == null) return;
                    String PatID = Negar.DBLayerPMS.Patients.GetPatientIDByPatListID(PatListID.Value);
                    if (String.IsNullOrEmpty(PatID)) return;
                    txtPatientID.TextBox.Text = PatID;
                }
                _CurrentSearchState = SearchStates.SearchSamePatByPatientID;
                BWFormThread.RunWorkerAsync(txtPatientID.TextBox.Text);
            }
            btnNextPatient.Enabled = false;
            btnPrevPatient.Enabled = false;
            btnSearch.Enabled = false;
        }
        #endregion

        #region btnTodayOrYesterday_Click
        private void btnTodayOrYesterday_Click(object sender, EventArgs e)
        {
            DateTime? TodayDate = Negar.DBLayerPMS.Manager.ServerCurrentDateTime;
            if (TodayDate == null) return;
            PersianDate PDate = TodayDate.Value.ToPersianDate();
            if (sender.Equals(btnToday)) PDate = TodayDate.Value.ToPersianDate();
            else if (sender.Equals(btnYesterday)) PDate = TodayDate.Value.AddDays(-1).ToPersianDate();
            String CurrentDate = PDate.Year.ToString().Substring(2, 2);
            if (PDate.Month < 10) CurrentDate += "0" + PDate.Month;
            else CurrentDate += PDate.Month;
            if (PDate.Day < 10) CurrentDate += "0" + PDate.Day;
            else CurrentDate += PDate.Day;
            txtPatientID.TextBox.Text = CurrentDate;
            btnSearch_Click(null, null);
        }
        #endregion

        #region btnAdvancedSearch_Click
        /// <summary>
        /// روال مدیریت دكمه جستجوی پیشرفته
        /// </summary>
        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            if (_SearchForm == null) _SearchForm = new frmAdvancedSearch();
            if (_SearchForm.IsDisposed) { _SearchForm = null; return; }
            _SearchForm.ShowDialog();
            if (_SearchForm.DialogResult != DialogResult.OK) return;
            List<Int32> AdvancedSearchPatients = new List<Int32>(_SearchForm.dgvData.SelectedRows.Count);
            for (Int32 i = 0; i < _SearchForm.dgvData.SelectedRows.Count; i++)
                AdvancedSearchPatients.Add(Convert.ToInt32(_SearchForm.dgvData.SelectedRows[i].Cells[1].Value));
            AdvancedSearchPatients = AdvancedSearchPatients.Distinct().OrderBy(Data => Data).ToList();
            _CurrentSearchState = SearchStates.SearchByPatientIDList;
            BWFormThread.RunWorkerAsync(AdvancedSearchPatients);
            btnNextPatient.Enabled = false;
            btnPrevPatient.Enabled = false;
            btnSearch.Enabled = false;
        }
        #endregion

        #region BWFormThread_DoWork
        private void BWFormThread_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                switch (_CurrentSearchState)
                {
                    case SearchStates.SearchByPatientListID:
                        _SearchResult = new List<PatientSearcher.PatientData>();
                        _SearchResult.Add(PatientSearcher.GetPatDataByPatListID((Int32)e.Argument)); break;
                    case SearchStates.SearchByPatientID:
                        _SearchResult = new List<PatientSearcher.PatientData>();
                        _SearchResult.Add(PatientSearcher.GetPatDataByPatID(e.Argument.ToString())); break;
                    case SearchStates.SearchByPatientsFilter:
                        Object[] Filters = (Object[])e.Argument;
                        Int32? Age = null;
                        if (Filters[2] != null) Age = Convert.ToInt32(Filters[2]);
                        _SearchResult = PatientSearcher.GetPatDataListSimpleFilter(
                            Filters[0].ToString(), Filters[1].ToString(), Age); break;
                    case SearchStates.SearchByPatientIDList:
                        _SearchResult = PatientSearcher.GetPatDataListByPatListIDList((List<Int32>)e.Argument); break;
                    case SearchStates.SearchSamePatByPatientID:
                        _SearchResult = PatientSearcher.GetSamePatDataByPatID(e.Argument.ToString()); break;
                    case SearchStates.ReadCachedData:
                        {
                            LoadFormBaseSettings();
                            if (e.Argument != null)
                            {
                                _SearchResult = new List<PatientSearcher.PatientData>();
                                _SearchResult.Add(PatientSearcher.GetPatDataByPatListID((Int32)e.Argument));
                            }
                            break;
                        }
                }
            }
            catch { e.Cancel = true; }
        }
        #endregion

        #region BWFormThread_RunWorkerCompleted
        private void BWFormThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnNextPatient.Enabled = true;
            btnPrevPatient.Enabled = true;
            btnSearch.Enabled = true;
            Cursor.Current = Cursors.Default;
            if (e.Cancelled) return;
            if (_CurrentSearchState != SearchStates.ReadCachedData &&
                (_SearchResult == null || _SearchResult.Count == 0 || _SearchResult.First() == null))
            { dgvPatData.DataSource = null; return; }
            if (_CurrentSearchState == SearchStates.SearchByPatientListID || _CurrentSearchState == SearchStates.SearchByPatientID)
                txtPatientID.TextBox.Text = _SearchResult.First().PatientID;
            if (_CurrentSearchState == SearchStates.ReadCachedData)
            {
                _SplashForm.Close();
                _SplashForm = null;
                Opacity = 1;
                TopMost = true;
                BringToFront();
                Select();
                Focus();
                Activate();
                TopMost = false;
            }
            else dgvPatData.DataSource = _SearchResult;
            if (dgvPatData.Rows.Count > 0)
            {
                dgvPatData.Focus();
                if (dgvPatData.Rows.Count < 100) dgvPatData.AutoResizeColumns();
            }
            else txtPatientID.TextBox.Focus();
            FormMenu.Invalidate(true);
        }
        #endregion

        #region btnClearGrid_Click
        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            dgvPatData.DataSource = null;
            dgvPatData.Rows.Clear();
            txtPatientID.TextBox.Clear();
            txtFName.TextBox.Clear();
            txtLName.TextBox.Clear();
            txtAge.TextBox.Clear();
        }
        #endregion

        #region btnPrintGrid_Click
        private void btnPrintGrid_Click(object sender, EventArgs e)
        {
            new Negar.GridPrinting.frmReportPreview(dgvPatData);
        }
        #endregion

        #endregion

        #region @@@ dgvPatData Event Handlers @@@

        #region dgvPatData_CellMouseClick
        private void dgvPatData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 && e.Button == MouseButtons.Left && _SearchResult != null)
            {
                DataGridViewColumn Column = dgvPatData.Columns[e.ColumnIndex];
                if (Column == ColPatientID) dgvPatData.DataSource = _SearchResult.OrderBy(Data => Data.PatientID).ToList();
                else if (Column == ColFullName) dgvPatData.DataSource = _SearchResult.OrderBy(Data => Data.PatientFullName).ToList();
                else if (Column == ColGender) dgvPatData.DataSource = _SearchResult.OrderBy(Data => Data.PatientGender).ToList();
                else if (Column == ColAge) dgvPatData.DataSource = _SearchResult.OrderBy(Data => Data.PatientAge).ToList();
                else if (Column == ColPersianRefDate) dgvPatData.DataSource = _SearchResult.OrderBy(Data => Data.LastRefPDateTime).ToList();
                else if (Column == ColRefCount) dgvPatData.DataSource = _SearchResult.OrderBy(Data => Data.RefCount).ToList();
                else dgvPatData.DataSource = _SearchResult;
            }
            _IsGridRightClicked = true;
            Point Position = MousePosition;
            if (sender.GetType().Equals(typeof(Int32)) &&
                e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
                Position = e.Location;
            else if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            dgvPatData.Rows[e.RowIndex].Selected = true;
            cmsdgvPatData.PopupMenu(Position);
        }
        #endregion

        #region dgvPatData_CellMouseDoubleClick
        private void dgvPatData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Int32 PatientListID;
            // اگر روال از طریق كلید بر روی جدول فراخوانی شده باشد
            if (sender != null && sender.GetType().Equals(typeof(Int32))) PatientListID = Convert.ToInt32(sender);
            else if (e.Button != MouseButtons.Left || e.ColumnIndex < 0 || e.RowIndex < 0) return;
            else PatientListID = ((PatientSearcher.PatientData)dgvPatData.SelectedRows[0].DataBoundItem).PatientListID;
            switch (_DefaultPatientClickBehaviorID)
            {
                // نمایش آخرین مراجعه بیمار
                case 0: if (btnLastRef.Visible && cmsdgvPatData.SubItems.Contains(btnLastRef))
                        AdmitHelper.EditPatientLastRef(PatientListID); break;
                case 1: if (btnPatientFile.Visible && cmsdgvPatData.SubItems.Contains(btnPatientFile))
                        AdmitHelper.EditPatient(PatientListID, false); break;
                case 2: if (btnLastAccount.Visible && cmsdgvPatData.SubItems.Contains(btnLastAccount))
                        new Account.frmAccount(PatientListID, true); break;
                // نمایش تصاویر پزشكی آخرین مراجعه بیمار غیر فعال است
                case 3: break;
                // نمایش آخرین تصویر پزشكی بیمار غیر فعال است
                case 4: break;
                // نمایش مدارك بیمار
                case 5:
                    {
                        if (!btnManageDoc.Visible || !cmsdgvPatData.SubItems.Contains(btnManageDoc)) break;
                        new frmDocuments(PatientListID, true); break;
                    }
                // نمایش آخرین مدرك بیمار
                case 6:
                    {
                        if (!btnEditLastDoc.Visible || !cmsdgvPatData.SubItems.Contains(btnEditLastDoc)) break;
                        Int32? LastDocID = Referrals.GetPatFirstOrLastDocID(PatientListID, true);
                        if (LastDocID == null) return;
                        if (LastDocID == 0)
                        {
                            PMBox.Show("مراجعه ی آخر این بیمار دارای مدرك نمی باشد و یا این بیمار دارای مراجعه نیست!", "خطا!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                        }
                        DocumentHelper.EditRefDocument(LastDocID.Value);
                        break;
                    }
                // ثبت مدرك جدید برای بیمار
                case 7:
                    {
                        if (!btnNewDoc.Visible || !cmsdgvPatData.SubItems.Contains(btnNewDoc)) break;
                        btnNewDoc_Click(null, null);
                        break;
                    }
            }
            AddUsedPatientToRecentList(PatientListID);
        }
        #endregion

        #region dgvPatData_RowStateChanged
        private void dgvPatData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected && e.Row.Selected && e.Row.Index >= 0)
            {
                dgvRefData.DataSource = PatientSearcher.GetPatRefListDataByPatID(
                    ((PatientSearcher.PatientData)e.Row.DataBoundItem).PatientListID);
                dgvRefData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            else dgvRefData.DataSource = null;
        }
        #endregion

        #region cmsdgvData_PopupOpen
        private void cmsdgvData_PopupOpen(object sender, PopupOpenEventArgs e)
        {
            Boolean IsAnyItemVisible = false;
            foreach (BaseItem item in cmsdgvPatData.SubItems)
                if (item.Visible) { IsAnyItemVisible = true; break; }
            if (!IsAnyItemVisible || cmsdgvPatData.SubItems.Count == 0) e.Cancel = true;
        }
        #endregion

        #region btnLastRef_Click
        private void btnLastRef_Click(object sender, EventArgs e)
        {
            Int32 PatientListID;
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                PatientListID = ((PatientSearcher.PatientData)dgvPatData.SelectedRows[0].DataBoundItem).PatientListID;
            }
            else PatientListID = _CurrentPatientListID;
            AdmitHelper.EditPatientLastRef(PatientListID);
            AddUsedPatientToRecentList(PatientListID);
        }
        #endregion

        #region btnPatientFile_Click
        private void btnPatientFile_Click(object sender, EventArgs e)
        {
            Int32 PatientListID;
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                PatientListID = ((PatientSearcher.PatientData)dgvPatData.SelectedRows[0].DataBoundItem).PatientListID;
            }
            else PatientListID = _CurrentPatientListID;
            AdmitHelper.EditPatient(PatientListID, false);
            AddUsedPatientToRecentList(PatientListID);
        }
        #endregion

        #region btnNewRef_Click
        private void btnNewRef_Click(object sender, EventArgs e)
        {
            Int32 PatientListID;
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                PatientListID = ((PatientSearcher.PatientData)dgvPatData.SelectedRows[0].DataBoundItem).PatientListID;
            }
            else PatientListID = _CurrentPatientListID;
            AdmitHelper.AdmitNewRef(PatientListID, null);
            AddUsedPatientToRecentList(PatientListID);
        }
        #endregion

        #region btnLastAccount_Click
        private void btnLastAccount_Click(object sender, EventArgs e)
        {
            Int32 PatientListID;
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                PatientListID = ((PatientSearcher.PatientData)dgvPatData.SelectedRows[0].DataBoundItem).PatientListID;
            }
            else PatientListID = _CurrentPatientListID;
            new Account.frmAccount(PatientListID, true);
            AddUsedPatientToRecentList(PatientListID);
        }
        #endregion

        #region sliderPrintCount_ValueChanged
        private void sliderPrintCount_ValueChanged(object sender, EventArgs e)
        {
            sliderPrintCount.Text = "تعداد چاپ: " + sliderPrintCount.Value + " نسخه";
        }
        #endregion

        #region btnPrintBillLastRef_Click
        /// <summary>
        /// تابعی برای چاپ قبض آخرین مراجعه بیمار انتخاب شده
        /// </summary>
        private void btnPrintBillLastRef_Click(object sender, EventArgs e)
        {
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                List<Int32> PatList = new List<Int32>();
                foreach (DataGridViewRow row in dgvPatData.SelectedRows)
                {
                    PatList.Add(((PatientSearcher.PatientData)row.DataBoundItem).PatientListID);
                    AddUsedPatientToRecentList(((PatientSearcher.PatientData)row.DataBoundItem).PatientListID);
                }
                Int16 BillID = ((SP_SelectBillTemplateResult)cboPrintTemplates.ComboBoxEx.SelectedItem).ID;
                BillPrintManager.RefBillPrint(PatList, BillID, Convert.ToInt16(sliderPrintCount.Value), true);
            }
            else
            {
                Int32 PatientListID = _CurrentPatientListID;
                Int32? PatLastRefID = Referrals.GetPatFirstOrLastRefID(PatientListID, true);
                if (PatLastRefID == null) return;
                if (PatLastRefID == 0)
                {
                    PMBox.Show("مراجعه ای برای بیمار انتخاب شده وجود ندارد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                Int16 BillID = ((SP_SelectBillTemplateResult)cboPrintTemplates.ComboBoxEx.SelectedItem).ID;
                BillPrintManager.RefBillPrint(PatLastRefID.Value, BillID, Convert.ToInt16(sliderPrintCount.Value));
                AddUsedPatientToRecentList(PatientListID);
            }
        }
        #endregion

        #region btnPrintBillAllRef_Click
        private void btnPrintBillAllRef_Click(object sender, EventArgs e)
        {
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                List<Int32> PatList = new List<Int32>();
                foreach (DataGridViewRow row in dgvPatData.SelectedRows)
                {
                    PatList.Add(((PatientSearcher.PatientData)row.DataBoundItem).PatientListID);
                    AddUsedPatientToRecentList(((PatientSearcher.PatientData)row.DataBoundItem).PatientListID);
                }
                Int16 BillID = ((SP_SelectBillTemplateResult)cboPrintTemplates.ComboBoxEx.SelectedItem).ID;
                BillPrintManager.RefBillPrint(PatList, BillID, Convert.ToInt16(sliderPrintCount.Value), false);
            }
            else
            {
                Int32 PatientListID = _CurrentPatientListID;
                List<Int32> PatRefIDList = Referrals.GetPatRefIDListByPatID(PatientListID);
                if (PatRefIDList == null) return;
                if (PatRefIDList.Count == 0)
                {
                    PMBox.Show("بیمار انتخاب شده مراجعه ای ندارد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                Int16 BillID = ((SP_SelectBillTemplateResult)cboPrintTemplates.ComboBoxEx.SelectedItem).ID;
                foreach (Int32 RefID in PatRefIDList)
                    BillPrintManager.RefBillPrint(RefID, BillID, Convert.ToInt16(sliderPrintCount.Value));
                AddUsedPatientToRecentList(PatientListID);
            }
        }
        #endregion

        #region btnLastDicomImage_Click
        private void btnLastDicomImage_Click(object sender, EventArgs e)
        {
            //Int32 PatientListID;
            //if (_IsGridRightClicked)
            //{
            //    if (dgvData.SelectedRows.Count == 0) return;
            //    PatientListID = ((PatientSearcher.PatientData)dgvData.SelectedRows[0].DataBoundItem).ID;
            //}
            //else PatientListID = _CurrentPatientListID;
            //PACS.DocumentHelper.ViewStudy(PatientListID);
        }
        #endregion

        #region btnManageDoc_Click
        private void btnManageDoc_Click(object sender, EventArgs e)
        {
            Int32 PatientListID;
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                PatientListID = ((PatientSearcher.PatientData)dgvPatData.SelectedRows[0].DataBoundItem).PatientListID;
            }
            else PatientListID = _CurrentPatientListID;
            new frmDocuments(PatientListID, true);
            AddUsedPatientToRecentList(PatientListID);
        }
        #endregion

        #region btnLastDoc_Click
        private void btnLastDoc_Click(object sender, EventArgs e)
        {
            Int32 PatientListID;
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                PatientListID = ((PatientSearcher.PatientData)dgvPatData.SelectedRows[0].DataBoundItem).PatientListID;
            }
            else PatientListID = _CurrentPatientListID;
            Int32? LastDocID = Referrals.GetPatFirstOrLastDocID(PatientListID, true);
            if (LastDocID == null) return;
            if (LastDocID == 0)
            {
                PMBox.Show("مراجعه ی آخر این بیمار دارای مدرك نمی باشد و یا این بیمار دارای مراجعه نیست!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            DocumentHelper.EditRefDocument(LastDocID.Value);
            AddUsedPatientToRecentList(PatientListID);
        }
        #endregion

        #region btnNewDoc_Click
        private void btnNewDoc_Click(object sender, EventArgs e)
        {
            Int32 PatientListID;
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                PatientListID = ((PatientSearcher.PatientData)dgvPatData.SelectedRows[0].DataBoundItem).PatientListID;
            }
            else PatientListID = _CurrentPatientListID;
            Int32? LastRefID = Referrals.GetPatFirstOrLastRefID(PatientListID, true);
            if (LastRefID == null) return;
            if (LastRefID == 0)
                PMBox.Show("بیمار انتخاب شده دارای مراجعه نمی باشد!\n" +
                    "برای ثبت مدرك ابتدا یك مراجعه برای بیمار ثبت نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else DocumentHelper.AddNewDocument(LastRefID.Value);
            AddUsedPatientToRecentList(PatientListID);
        }
        #endregion

        #region btnPrintLastRefDoc_Click
        private void btnPrintLastRefDoc_Click(object sender, EventArgs e)
        {
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                List<Int32> PatIDList = new List<Int32>();
                foreach (DataGridViewRow row in dgvPatData.SelectedRows)
                {
                    PatIDList.Add(((PatientSearcher.PatientData)row.DataBoundItem).PatientListID);
                    AddUsedPatientToRecentList(((PatientSearcher.PatientData)row.DataBoundItem).PatientListID);
                }
                DocumentHelper.PrintPatientsDocs(PatIDList, true);
            }
            else
            {
                List<Int32> PatIDList = new List<Int32>();
                PatIDList.Add(_CurrentPatientListID);
                DocumentHelper.PrintPatientsDocs(PatIDList, true);
            }
        }
        #endregion

        #region btnPrintAllRefDoc_Click
        private void btnPrintAllRefDoc_Click(object sender, EventArgs e)
        {
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                List<Int32> PatIDList = new List<Int32>();
                foreach (DataGridViewRow row in dgvPatData.SelectedRows)
                {
                    PatIDList.Add(((PatientSearcher.PatientData)row.DataBoundItem).PatientListID);
                    AddUsedPatientToRecentList(((PatientSearcher.PatientData)row.DataBoundItem).PatientListID);
                }
                DocumentHelper.PrintPatientsDocs(PatIDList, false);
            }
            else
            {
                List<Int32> PatIDList = new List<Int32>();
                PatIDList.Add(_CurrentPatientListID);
                DocumentHelper.PrintPatientsDocs(PatIDList, false);
            }
        }
        #endregion

        #region btnExportPatDocuments_Click
        private void btnExportPatDocuments_Click(object sender, EventArgs e)
        {
            DialogResult result = PMBox.Show("آیا مایلید جواب های بیماران انتخاب شده را ذخیره كنید؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.Yes) return;
            FolderBrowserDialog folderSelector = new FolderBrowserDialog();
            result = folderSelector.ShowDialog();
            if (result != DialogResult.OK) return;
            String folderAddress = folderSelector.SelectedPath;
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                List<Int32> PatIDList = new List<Int32>();
                foreach (DataGridViewRow row in dgvPatData.SelectedRows)
                {
                    PatIDList.Add(((PatientSearcher.PatientData)row.DataBoundItem).PatientListID);
                    AddUsedPatientToRecentList(((PatientSearcher.PatientData)row.DataBoundItem).PatientListID);
                }
                DocumentHelper.ExportDocument(PatIDList, folderAddress);
            }
            else
            {
                List<Int32> PatIDList = new List<Int32>();
                PatIDList.Add(_CurrentPatientListID);
                DocumentHelper.ExportDocument(PatIDList, folderAddress);
            }
        }
        #endregion

        #region btnSendSMS_Click
        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            if (!DocumentHelper.IsMessageTemplateReady())
            {
                PMBox.Show("قالبی برای متن پیام ارسالی تعریف نشده است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                List<Int32> PatList = new List<Int32>();
                foreach (DataGridViewRow row in dgvPatData.SelectedRows)
                {
                    PatList.Add(((PatientSearcher.PatientData)row.DataBoundItem).PatientListID);
                    AddUsedPatientToRecentList(((PatientSearcher.PatientData)row.DataBoundItem).PatientListID);
                }
                DialogResult Dr;
                if (PatList.Count == 1) Dr = PMBox.Show("آیا مایلید برای بیمار جاری پیام اتمام گزارش ارسال شود؟", "پرسش؟",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                else Dr = PMBox.Show("آیا مایلید برای تمام بیماران انتخاب شده پیام اتمام گزارش ارسال شود؟", "پرسش؟",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.Yes)
                    foreach (Int32 PatID in PatList)
                    {
                        Int32? PatLastRefID = Referrals.GetPatFirstOrLastRefID(PatID, true);
                        if (PatLastRefID == null) return;
                        DocumentHelper.SendMessageToPatient(PatLastRefID.Value);
                    }
            }
            else
            {
                Int32 PatientListID = _CurrentPatientListID;
                DialogResult Dr = PMBox.Show("آیا مایلید برای بیمار جاری پیام اتمام گزارش ارسال شود؟", "پرسش؟",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr != DialogResult.Yes) return;
                Int32? PatLastRefID = Referrals.GetPatFirstOrLastRefID(PatientListID, true);
                if (PatLastRefID == null) return;
                DocumentHelper.SendMessageToPatient(PatLastRefID.Value);
                AddUsedPatientToRecentList(PatientListID);
            }
        }
        #endregion

        #region btnDeletePatient_Click
        private void btnDeletePatient_Click(object sender, EventArgs e)
        {
            Int32 PatientListID;
            if (_IsGridRightClicked)
            {
                if (dgvPatData.SelectedRows.Count == 0) return;
                PatientListID = ((PatientSearcher.PatientData)dgvPatData.SelectedRows[0].DataBoundItem).PatientListID;
            }
            else PatientListID = _CurrentPatientListID;
            DialogResult Dr = PMBox.Show("آیا از حذف بیمار انتخاب شده اطمینان دارید؟", "پرسش!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.No) return;
            Dr = PMBox.Show("آیا از حذف بیمار انتخاب شده اطمینان دارید؟\n" +
                "با حذف بیمار كلیه اطلاعات پرونده وی حذف می گردد!", "هشدار!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.No) return;
            Negar.DBLayerPMS.Patients.DeletePatient(PatientListID);
            PatientSearcher.PatientData RemovedPat =
                (PatientSearcher.PatientData)dgvPatData.SelectedRows[0].DataBoundItem;
            if (_SearchResult.Contains(RemovedPat))
                _SearchResult.Remove(RemovedPat);
            dgvPatData.DataSource = _SearchResult.ToList();
        }
        #endregion

        #endregion

        #region @@@ dgvRefData Event Handlers @@@

        #region dgvRefData_CellMouseClick
        private void dgvRefData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Point Position = MousePosition;
            if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            dgvRefData.Rows[e.RowIndex].Selected = true;
            cmsdgvRefData.PopupMenu(Position);
        }
        #endregion

        #region dgvRefData_CellMouseDoubleClick
        private void dgvRefData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.ColumnIndex < 0 || e.RowIndex < 0) return;
            switch (_DefaultRefClickBehaviorID)
            {
                // نمایش مراجعه بیمار
                case 0: if (btnRefAdmit.Visible && cmsdgvRefData.SubItems.Contains(btnRefAdmit))
                        btnRefAdmit_Click(null, null); break;
                case 1: if (btnRefAccount.Visible && cmsdgvRefData.SubItems.Contains(btnRefAccount))
                        btnRefAccount_Click(null, null); break;
                case 2: if (btnRefDocs.Visible && cmsdgvRefData.SubItems.Contains(btnRefDocs))
                        btnRefDocs_Click(null, null); break;
                case 3: if (btnRefLastDoc.Visible && cmsdgvRefData.SubItems.Contains(btnRefLastDoc))
                        btnRefLastDoc_Click(null, null); break;
                case 4: if (btnRefNewDoc.Visible && cmsdgvRefData.SubItems.Contains(btnRefNewDoc))
                        btnRefNewDoc_Click(null, null); break;
            }
        }
        #endregion

        #region cmsdgvRefData_PopupOpen
        private void cmsdgvRefData_PopupOpen(object sender, PopupOpenEventArgs e)
        {
            Boolean IsAnyItemVisible = false;
            foreach (BaseItem item in cmsdgvRefData.SubItems)
                if (item.Visible) { IsAnyItemVisible = true; break; }
            if (!IsAnyItemVisible || cmsdgvRefData.SubItems.Count == 0) e.Cancel = true;
        }
        #endregion

        #region btnRefAdmit_Click
        private void btnRefAdmit_Click(object sender, EventArgs e)
        {
            if (dgvRefData.SelectedRows.Count == 0) return;
            AdmitHelper.EditPatientRef(((PatientSearcher.PatientRefData)dgvRefData.SelectedRows[0].DataBoundItem).RefID);
        }
        #endregion

        #region btnRefAccount_Click
        private void btnRefAccount_Click(object sender, EventArgs e)
        {
            if (dgvRefData.SelectedRows.Count == 0) return;
            new Account.frmAccount(((PatientSearcher.PatientRefData)dgvRefData.SelectedRows[0].DataBoundItem).RefID, false);
        }
        #endregion

        #region sliderRefBillQty_ValueChanged
        private void sliderRefBillQty_ValueChanged(object sender, EventArgs e)
        {
            sliderRefBillQty.Text = "تعداد چاپ: " + sliderRefBillQty.Value + " نسخه";
        }
        #endregion

        #region btnRefBillPrint_Click
        private void btnRefBillPrint_Click(object sender, EventArgs e)
        {
            if (dgvRefData.SelectedRows.Count == 0) return;
            Int16 BillID = ((SP_SelectBillTemplateResult)cboRefBill.ComboBoxEx.SelectedItem).ID;
            BillPrintManager.RefBillPrint(((PatientSearcher.PatientRefData)dgvRefData.SelectedRows[0].DataBoundItem).RefID,
                BillID, Convert.ToInt16(sliderRefBillQty.Value));
        }
        #endregion

        #region btnRefDocs_Click
        private void btnRefDocs_Click(object sender, EventArgs e)
        {
            if (dgvRefData.SelectedRows.Count == 0) return;
            new frmDocuments(((PatientSearcher.PatientRefData)dgvRefData.SelectedRows[0].DataBoundItem).RefID, false);
        }
        #endregion

        #region btnRefLastDoc_Click
        private void btnRefLastDoc_Click(object sender, EventArgs e)
        {
            if (dgvRefData.SelectedRows.Count == 0) return;
            Int32? LastDocID = Document.GetRefLastDocIDByRefID(
                ((PatientSearcher.PatientRefData)dgvRefData.SelectedRows[0].DataBoundItem).RefID);
            if (LastDocID == null) return;
            if (LastDocID == 0)
            {
                PMBox.Show("مراجعه ی آخر این بیمار دارای مدرك نمی باشد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            DocumentHelper.EditRefDocument(LastDocID.Value);
        }
        #endregion

        #region btnRefNewDoc_Click
        private void btnRefNewDoc_Click(object sender, EventArgs e)
        {
            if (dgvRefData.SelectedRows.Count == 0) return;
            DocumentHelper.AddNewDocument(
                ((PatientSearcher.PatientRefData)dgvRefData.SelectedRows[0].DataBoundItem).RefID);
        }
        #endregion

        #region btnRefLastDocPrint_Click
        private void btnRefLastDocPrint_Click(object sender, EventArgs e)
        {
            if (dgvRefData.SelectedRows.Count == 0) return;
            Int32? LastDocID = Document.GetRefLastDocIDByRefID(
                ((PatientSearcher.PatientRefData)dgvRefData.SelectedRows[0].DataBoundItem).RefID);
            if (LastDocID == null) return;
            if (LastDocID == 0)
            {
                PMBox.Show("مراجعه ی آخر این بیمار دارای مدرك نمی باشد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            DocumentHelper.PrintDocument(LastDocID.Value);
        }
        #endregion

        #region btnRefAllDocPrint_Click
        private void btnRefAllDocPrint_Click(object sender, EventArgs e)
        {
            if (dgvRefData.SelectedRows.Count == 0) return;
            List<Int32> DocList = Document.GetRefDocIDListByRefID(
                ((PatientSearcher.PatientRefData)dgvRefData.SelectedRows[0].DataBoundItem).RefID);
            if (DocList == null) return;
            if (DocList.Count == 0)
            {
                PMBox.Show("مدركی برای این مراجعه ثبت نشده است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            foreach (Int32 DocID in DocList) DocumentHelper.PrintDocument(DocID);
        }
        #endregion

        #region btnRefRemove_Click
        private void btnRefRemove_Click(object sender, EventArgs e)
        {
            #region Ask User Permission
            DialogResult Dr1 = PMBox.Show("آیا مایلید اطلاعات مراجعه انتخاب شده حذف شود؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr1 == DialogResult.Yes)
            {
                DialogResult Dr2 = PMBox.Show("آیا مطمئن هستید كه اطلاعات مراجعه بیمار حذف شود؟" +
                    " پس از حذف اطلاعات مراجعه بیمار كلیه اطلاعات مالی ، اطلاعات بیمه " +
                    "و همچنین اسناد بیمار برای آن پرونده حذف می گردد و امكان بازگشت آن وجود ندارد.", "هشدار!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (Dr2 == DialogResult.No) return;
            }
            else if (Dr1 == DialogResult.No) return;
            #endregion
            Referrals.DeletePatRef(((PatientSearcher.PatientRefData)dgvRefData.SelectedRows[0].DataBoundItem).RefID);
            btnSearch_Click(null, null);
        }
        #endregion

        #endregion

        #region btnFiles_Click
        private void btnFiles_Click(object sender, EventArgs e)
        {
            switch (((ButtonItem)sender).Tag.ToString())
            {
                case "frmAppointments": Visible = false; new Schedules.frmAppointments(); Visible = true; break;
                case "frmPatients": { AdmitHelper.AdmitPatient(null); break; }
                case "frmAdmitNewReferral": { AdmitHelper.AdmitPatWithRef(null); break; }
                case "frmCashMonitor": new Cash.frmCashPatients(); break;
                case "frmCashesManage": new Cash.frmCashesManage(); break;
                case "frmCashesReport": new Cash.frmCashesReport(); break;
                case "frmDocumentMonitor": new frmDocumentMonitor(); break;
                case "frmMessagesDashboard": new SMSSender.frmDashboard(); break;
            }
            Select();
            Activate();
            BringToFront();
            Focus();
            GC.Collect();
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            switch (((ButtonItem)sender).Tag.ToString())
            {
                case "DesignableReports": new Reports.Designables.frmReports(); break;
                case "frmReportSpecial": new SpecialReports.frmList(); break;
                case "Report1.1": new Reports.General.Report01.frmFilter(); break;
                case "Report1.2": new Reports.General.Report09.frmFilter(); break;
                case "Report1.3": new Reports.General.Report17.frmFilter(); break;
                case "Report1.4": new Reports.General.Report20.frmFilter(); break;
                case "Report2.1": new Reports.General.Report02.frmFilter(); break;
                case "Report2.2": new Reports.General.Report13.frmFilter(); break;
                case "Report3.1": new Reports.General.Report03.frmFilter(); break;
                case "Report3.2": new Reports.General.Report14.frmFilter(); break;
                case "Report4.1": new Reports.General.Report04.frmFilter(); break;
                case "Report4.2": new Reports.General.Report07.frmFilter(); break;
                case "Report4.3": new Reports.General.Report08.frmFilter(); break;
                case "Report4.4": new Reports.General.Report16.frmFilter(); break;
                case "Report5.1": new Reports.General.Report05.frmFilter(); break;
                case "Report5.2": new Reports.General.Report10.frmFilter(); break;
                case "Report5.3": new Reports.General.Report11.frmFilter(); break;
                case "Report5.4": new Reports.General.Report18.frmFilter(); break;
                case "Report5.5": new Reports.General.Report21.frmFilter(); break;
                case "Report6.1": new Reports.General.Report06.frmFilter(); break;
                case "Report6.2": new Reports.General.Report12.frmFilter(); break;
                case "Report6.3": new Reports.General.Report19.frmFilter(); break;
            }
        }
        #endregion

        #region btnSettings_Click
        /// <summary>
        /// روال مدیریت نمایش فرم های تنظیمات
        /// </summary>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            switch (((ButtonItem)sender).Tag.ToString())
            {
                case "ChangeUserPassword":
                    new Negar.Security.Classes.ChangeUserPassword(SecurityManager.CurrentUserID, true, true); break;
                case "frmManageUserSettings": frmManage MyForm = new frmManage();
                    if (!MyForm.IsDisposed) MyForm.ShowDialog(); break;
                // تنظیمات امنیتی
                case "frmUsers": new Negar.Security.frmUsers(); break;
                case "frmUsersGroups": new Negar.Security.frmUsersGroups(); break;
                case "frmUsersGrouping": new Negar.Security.frmUsersInGroups(); break;
                case "frmACLManages": new Negar.Security.ACL.frmManage(); break;
                // تنظیمات نوبت دهی
                case "frmApplications": new Settings.Schedules.Applications.frmApps(); break;
                case "frmSchAddinFields": new Settings.Schedules.AppsAddinFields.frmAddinCols(); break;
                // تنظیمات بیماران
                case "frmCities": new Settings.Patients.frmCities(); break;
                case "frmStates": new Settings.Patients.frmStates(); break;
                case "frmCountries": new Settings.Patients.frmCountries(); break;
                case "frmPatientsJob": new Settings.Patients.frmPatientsJob(); break;
                case "frmPatientsName": new Settings.Patients.frmPatientsName(); break;
                case "frmPatAdditionalCols": new Settings.Patients.frmAdditionalCols(); break;
                // تنظیمات مراجعات
                case "frmStatus": new Settings.Referrals.frmStatus(); break;
                case "frmPhysiciansSpecs": new Settings.Referrals.frmPhysiciansSpecs(); break;
                case "frmPhysicians": new Settings.Referrals.frmPhysicians(); break;
                case "frmPerformers": new Settings.Referrals.frmPerformers();
                    DocumentHelper.DisposeDocumentForm(); break;
                case "frmRefAdditionalCols": new Settings.Referrals.frmAdditionalCols(); break;
                // تنظیمات خدمات و بیمه ها
                case "frmGroupsServices": new Settings.Services.frmGroups(); break;
                case "frmCategories": new Settings.Services.frmCategories(); break;
                case "frmServices": new Settings.Services.frmServices(); break;
                case "frmServicesGrouping": new Settings.Services.frmServicesGrouping(); break;
                case "frmDefaultPerformers": new Settings.Services.frmDefaultPerformers(); break;
                // case "frmServicesAdditionalCols": new Settings.Services.frmAdditionalCols(); break;
                case "frmInsurances": new Settings.Insurances.frmInsurances(); break;
                // تنظیمات حساب و صندوق ها
                case "frmCostDiscountTypes": new Settings.Accounts.frmCostDiscountTypes(); break;
                case "frmCostDiscountUsersExclude": new Settings.Accounts.frmCostDiscountUsersExclude(); break;
                case "frmBanks": new Settings.Accounts.frmBanks(); break;
                case "frmCashes": new Settings.Cash.frmCashes(); break;
                case "frmCashCashiers": new Settings.Cash.frmCashCashiers(); break;
                // تنظیمات مدارك بیمار
                case "frmDocTemplates": new Settings.Documents.frmDocTemplates();
                    DocumentHelper.ResetDocTemplateData(); break;
                case "frmDocTexts": new Settings.Documents.frmDocTexts();
                    DocumentHelper.ResetDocTemplateData(); break;
                case "frmDocumentsTypes": new Settings.Documents.frmDocTypes();
                    DocumentHelper.DisposeDocumentForm(); break;
                // تنظیمات قالب های قبوض
                case "frmBillTemplates": new Settings.BillTemplates.frmBillTemplates(); break;
                case "frmBillTemplatesAccess": new Settings.BillTemplates.frmBillUserAccess(); break;
                case "frmBillServCatExclude": new Settings.BillTemplates.frmBillServiceGroupsExclude(); break;
                case "frmBillDefaultPrinter": new Settings.BillTemplates.frmBillDefaultPrinter(); break;
                // مدیریت ارتباط با پكس
                case "frmPACSModalities": new Settings.PACSIntegration.frmModalities(); break;
                case "frmPACSServicesModalities":
                    new Settings.PACSIntegration.frmModalitiesServicesGrouping(); break;
                case "frmPACSStudies":
                    new Settings.PACSIntegration.frmStudies(); break;
                case "frmPACSServicesStudies":
                    new Settings.PACSIntegration.frmStudiesServicesGrouping(); break;
                // مدیریت پیام رسانی
                case "frmDocMessageTemplate": new Settings.SMS.frmDocCompleteMessage(); break;
            }
            Activate();
            Select();
            Focus();
            BringToFront();
            btnRefreshSettings_Click(null, null);
        }
        #endregion

        #region btnTools_Click
        private void btnTools_Click(object sender, EventArgs e)
        {
            if (((ButtonItem)sender).Tag.ToString() == "frmBackup") new frmBackup();
            else if (((ButtonItem)sender).Tag.ToString() == "frmRestore") new frmRestore();
            else if (((ButtonItem)sender).Tag.ToString() == "frmEventViewer") new frmEventViewer();
            else if (((ButtonItem)sender).Tag.ToString() == "frmRebuildDatabase") new frmRebuildDatabase();
            else if (((ButtonItem)sender).Tag.ToString() == "frmRemoveData") new frmRemoveData();
        }
        #endregion

        #region btnHelp_Click
        private void btnHelp_Click(object sender, EventArgs e)
        {
            switch (((ButtonItem)sender).Tag.ToString())
            {
                case "frmAbout": new frmAbout(); break;
                case "frmContactUs": new frmContactUs(); break;
                case "frmLicenseList": new frmLicenseList(); break;
                // case "frmUserLearning": new FormResources().ShowDialog(); break;
            }
        }
        #endregion

        #region btnRefreshSettings_Click
        /// <summary>
        /// تابعی برای خواندن مجدد اطلاعات موجود در حافظه و دسترسی های و تنظیمات كاربر جاری
        /// </summary>
        private void btnRefreshSettings_Click(object sender, EventArgs e)
        {
            Negar.DBLayerPMS.Manager.ReleaseCachedFiles();
            Manager.ReleaseCachedFiles();
            BillPrintManager.CurrentUserBillTemplatesList = null;
            SecurityManager.RenewAccess();
            AdmitHelper.ClearTempAdmit();
            DocumentHelper.DisposeDocumentForm();
            if (!ReloadApplicationData()) { _ShouldAskUserForExit = false; Application.Exit(); }
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (_ShouldAskUserForExit)
            {
                DialogResult Dr = PMBox.Show("آیا مایل به خروج از برنامه هستید؟", "پرسش؟", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
            FormClosing -= Form_Closing;
            Application.Exit();
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

            #region btnStart
            String TooltipText = ToolTipManager.GetText("btn_MainForm_Start", "IMS");
            FormToolTip.SetSuperTooltip(btnLastPatients, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region RBarSearchPatients
            TooltipText = ToolTipManager.GetText("btn_MainForm_RTabPatients", "IMS");
            FormToolTip.SetSuperTooltip(RBarSearchPatients, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnFile
            TooltipText = ToolTipManager.GetText("btn_MainForm_RTabFile", "IMS");
            FormToolTip.SetSuperTooltip(btnFile, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnReport
            TooltipText = ToolTipManager.GetText("btn_MainForm_RTabReport", "IMS");
            FormToolTip.SetSuperTooltip(btnReport, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSettings
            TooltipText = ToolTipManager.GetText("btn_MainForm_RTabSettings", "IMS");
            FormToolTip.SetSuperTooltip(btnSettings, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAdministration
            TooltipText = ToolTipManager.GetText("btn_MainForm_RTabSystemAdmin", "IMS");
            FormToolTip.SetSuperTooltip(btnTools, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btn_MainForm_RTabHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region static void LoadFormBaseSettings()
        /// <summary>
        /// تابعی برای انجام تنظیمات پایه فرم اصلی
        /// </summary>
        private static void LoadFormBaseSettings()
        {
            if (Insurance.InsFullList == null ||
                Services.ServicesList == null ||
                Services.DefaultPerformersList == null) return;
            #region Delete Temp Files
            String[] FilesList = Directory.GetFiles(Application.StartupPath);
            Int32 StartIndex = Application.StartupPath.Length + 1;
            foreach (String FileName in FilesList)
            {
                if ((FileName.Length > StartIndex + 6 && FileName.Substring(StartIndex, 6) == "RefDoc") ||
                    (FileName.Length > StartIndex + 7 && FileName.Substring(StartIndex, 7) == "TempDoc") ||
                    (FileName.Length > StartIndex + 8 && FileName.Substring(StartIndex, 8) == "Document") ||
                    (FileName.Length > StartIndex + 16 && FileName.Substring(StartIndex, 16) == "TempBillTemplate"))
                {
                    try
                    {
                        File.SetAccessControl(FileName, new FileSecurity(FileName, AccessControlSections.All));
                        File.SetAttributes(FileName, FileAttributes.Normal);
                        File.Delete(FileName);
                    }
                    // ReSharper disable EmptyGeneralCatchClause
                    catch (Exception) { }
                    // ReSharper restore EmptyGeneralCatchClause
                }
            }
            #endregion
        }
        #endregion

        #region Boolean ReloadApplicationData()
        /// <summary>
        /// تابعی برای خواندن و تنظیم اطلاعات تنظبمات ، دسترسی ها و سایر اطلاعات مربوط به برنامه
        /// </summary>
        private Boolean ReloadApplicationData()
        {
            if (!ReadCurrentUserAccess() || !ReadFormCurrentUserSettings()) return false;
            #region Fill Bill Templates
            if (BillPrintManager.CurrentUserBillTemplatesList == null ||
                BillPrintManager.CurrentUserBillTemplatesList.Count == 0)
            {
                btnPrintBill.Visible = false;
                btnRefBills.Visible = false;
            }
            else
            {
                btnPrintBill.Visible = true;
                cboPrintTemplates.ComboBoxEx.DrawMode = DrawMode.Normal;
                cboPrintTemplates.ComboBoxEx.FlatStyle = FlatStyle.Standard;
                cboPrintTemplates.ComboBoxEx.DisplayMember = "Name";
                cboPrintTemplates.ComboBoxEx.ValueMember = "ID";
                cboPrintTemplates.ComboBoxEx.Items.Clear();
                foreach (SP_SelectBillTemplateResult BillTemplate in BillPrintManager.CurrentUserBillTemplatesList)
                    cboPrintTemplates.ComboBoxEx.Items.Add(BillTemplate);
                cboPrintTemplates.ComboBoxEx.SelectedIndex = 0;
                btnRefBills.Visible = true;
                cboRefBill.ComboBoxEx.DrawMode = DrawMode.Normal;
                cboRefBill.ComboBoxEx.FlatStyle = FlatStyle.Standard;
                cboRefBill.ComboBoxEx.DisplayMember = "Name";
                cboRefBill.ComboBoxEx.ValueMember = "ID";
                cboRefBill.ComboBoxEx.Items.Clear();
                foreach (SP_SelectBillTemplateResult BillTemplate in BillPrintManager.CurrentUserBillTemplatesList)
                    cboRefBill.ComboBoxEx.Items.Add(BillTemplate);
                cboRefBill.ComboBoxEx.SelectedIndex = 0;
            }
            #endregion
            FormMenu.Invalidate(true);
            FormMenu.Refresh();
            return true;
        }
        #endregion

        #region Boolean CheckCurrentLockLicenses()
        /// <summary>
        /// تابعی برای اعمال تنظیمات لایسنس های موجود در قفل جاری
        /// </summary>
        /// <remarks>این تابع در زمان اجرای برنامه فراخوانی می شود و نیاز به بررسی موجود بودن كنترلها در آن نیست</remarks>
        private Boolean CheckCurrentLockLicenses()
        {
            if (LicenseHelper.GetSavedLicenses().Count == 0)
            {
                PMBox.Show("قفل نصب شده دارای هیچ نوع مجوز استفاده ای نمی باشد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand); return false;
            }
            if (SecurityManager.CurrentUserID < 3) return true;
            // لایسنس نوبت دهی
            if (!LicenseHelper.GetSavedLicenses().Contains("510") && !LicenseHelper.GetSavedLicenses().Contains("515"))
                btnFile.SubItems.Remove(btnAppointments);
            // لایسنس تنظیمات نوبت دهی
            if (!LicenseHelper.GetSavedLicenses().Contains("511") && !LicenseHelper.GetSavedLicenses().Contains("516"))
                btnSettings.SubItems.Remove(btnSchSettings);
            // لایسنس تنظیمات نوبت دهی پیشرفته
            else if (!LicenseHelper.GetSavedLicenses().Contains("516")) btnSchSettings.SubItems.Remove(btnSchAddinFields);
            // لایسنس پذیرش
            if (!LicenseHelper.GetSavedLicenses().Contains("520") && !LicenseHelper.GetSavedLicenses().Contains("525"))
            {
                btnFile.SubItems.Remove(btnNewPatient);
                btnFile.SubItems.Remove(btnNewPatientRef);
                cmsdgvPatData.SubItems.Remove(btnPatientFile);
                cmsdgvPatData.SubItems.Remove(btnNewRef);
                cmsdgvPatData.SubItems.Remove(btnLastRef);
                cmsdgvPatData.SubItems.Remove(btnDeletePatient);
            }
            // لایسنس تنظیمات پذیرش پیشرفته
            if (!LicenseHelper.GetSavedLicenses().Contains("526"))
            {
                // دارا بودن لایسنس تنظیمات پذیرش عادی
                if (LicenseHelper.GetSavedLicenses().Contains("521"))
                {
                    // حذف منوی بیماران
                    btnSettings.SubItems.Remove(btnPatientsSettings);
                    // حذف فیلد های پویا مراجعات
                    btnRefSettings.SubItems.Remove(btnRefAddinData);
                    // حذف وضعیت های مراجعه
                    btnRefSettings.SubItems.Remove(btnRefStatus);
                    // حذف تعریف گروه های خدمات
                    btnServInsSettings.SubItems.Remove(btnServiceGroups);
                    btnServInsSettings.SubItems.Remove(btnServiceGrouping);
                    // حذف تعریف كادر پزشكی پیش فرض خدمات
                    btnServInsSettings.SubItems.Remove(btnDefaultServicePerformers);
                }
                // عدم دسترسی به لایسنس تنظیمات پذیرش عادی
                else
                {
                    btnSettings.SubItems.Remove(btnPatientsSettings);
                    btnSettings.SubItems.Remove(btnRefSettings);
                    btnSettings.SubItems.Remove(btnServInsSettings);
                }
            }
            // لایسنس حساب
            if (!LicenseHelper.GetSavedLicenses().Contains("530")) cmsdgvPatData.SubItems.Remove(btnLastAccount);
            // لایسنس تنظیمات حساب
            if (!LicenseHelper.GetSavedLicenses().Contains("531"))
            {
                btnAccountCashSettings.SubItems.Remove(btnCostDiscountTypes);
                btnAccountCashSettings.SubItems.Remove(btnCostDiscountExcludedUsers);
                btnAccountCashSettings.SubItems.Remove(btnBanks);
                btnAccountCashSettings.Text = "<b>صندوق</b><br></br>" +
                    "<font color=\"#000000\">تعاریف چند صندوقی.</font> ";
            }
            // لایسنس صندوق
            if (!LicenseHelper.GetSavedLicenses().Contains("540"))
            {
                btnFile.SubItems.Remove(btnCashManage);
                btnFile.SubItems.Remove(btnCashPatients);
                btnFile.SubItems.Remove(btnCashReport);
            }
            // لایسنس تنظیمات صندوق
            if (!LicenseHelper.GetSavedLicenses().Contains("541"))
            {
                btnAccountCashSettings.SubItems.Remove(btnCashes);
                btnAccountCashSettings.SubItems.Remove(btnCashCashiers);
                btnAccountCashSettings.Text = "<b>حساب</b><br></br>" +
                    "<font color=\"#000000\">تعاریف مالی و حساب.</font> ";
            }
            // حذف گروه صندوق و حساب ، در صورت نداشتن مجوز هر دو مورد
            if (!LicenseHelper.GetSavedLicenses().Contains("531") && !LicenseHelper.GetSavedLicenses().Contains("541"))
                btnSettings.SubItems.Remove(btnAccountCashSettings);
            // لایسنس مدارك
            if (!LicenseHelper.GetSavedLicenses().Contains("550"))
            {
                btnFile.SubItems.Remove(btnDocumentPatients);
                cmsdgvPatData.SubItems.Remove(btnManageDoc);
                cmsdgvPatData.SubItems.Remove(btnEditLastDoc);
                cmsdgvPatData.SubItems.Remove(btnNewDoc);
                cmsdgvPatData.SubItems.Remove(btnPrintRefDoc);
            }
            // لایسنس تنظیمات مدارك
            if (!LicenseHelper.GetSavedLicenses().Contains("551")) btnSettings.SubItems.Remove(btnDocSettings);
            // لایسنس تنظیمات قبوض
            if (!LicenseHelper.GetSavedLicenses().Contains("561")) btnSettings.SubItems.Remove(btnBillTemplatesSettings);
            // لایسنس مدیریت ارتباط با پكس
            if (!LicenseHelper.GetSavedLicenses().Contains("580")) btnSettings.SubItems.Remove(btnPacsManage);
            // لایسنس مدیریت پیام كوتاه
            if (!LicenseHelper.GetSavedLicenses().Contains("571")) btnSettings.SubItems.Remove(btnMessagesSettings);
            // اگر كلیه فرمان های پیام كوتاه حذف شده باشد ، منوی آن به طور كامل حذف می شود
            //if (btnMessagesSettings.SubItems.Count == 0 && btnSettings.SubItems.Contains(btnMessagesSettings))
            //    btnSettings.SubItems.Remove(btnMessagesSettings);
            // لایسنس گزارش گیری
            if (!LicenseHelper.GetSavedLicenses().Contains("560")) FormMenu.Items.Remove(btnReport);
            // لایسنس مدیریت امنیتی
            if (!LicenseHelper.GetSavedLicenses().Contains("110")) btnSettings.SubItems.Remove(btnSecuritySettings);
            // لایسنس ابزارهای سیستم
            if (!LicenseHelper.GetSavedLicenses().Contains("120")) FormMenu.Items.Remove(btnTools);
            // اگر كلیه فرمان های پرونده حذف شده باشد ، منوی آن به طور كامل حذف می شود
            if (btnFile.SubItems.Count == 0 && FormMenu.Items.Contains(btnFile)) FormMenu.Items.Remove(btnFile);
            return true;
        }
        #endregion

        #region Boolean ReadFormCurrentUserSettings()
        /// <summary>
        /// تابع خواندن تنظیمات كاربر جاری
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean ReadFormCurrentUserSettings()
        {
            if (DBLayerIMS.Settings.CurrentUserSettingsFullList == null) return false;
            #region 101
            // 101: رفتار برنامه بعد از دوبار كلیك بر روی بیمار
            if (SecurityManager.CurrentUserID < 3) _DefaultPatientClickBehaviorID = 0;
            else
            {
                List<UsersSetting> Setting101 =
                    DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 101).ToList();
                if (Setting101.Count != 0 && !String.IsNullOrEmpty(Setting101.First().Value))
                    _DefaultPatientClickBehaviorID = Convert.ToByte(Setting101.First().Value);
                else _DefaultPatientClickBehaviorID = 0;
            }
            #endregion
            #region 102
            // 102: لیست ستون های نمایش داده شده در نتیجه جستجوی مراجعات
            List<UsersSetting> Setting102 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 102).ToList();
            if (Setting102.Count != 0 && !String.IsNullOrEmpty(Setting102.First().Value))
            {
                if (Setting102.First().Value.Substring(0, 1) == "1") ColRefPeriod.Visible = true;
                else ColRefPeriod.Visible = false;
                if (Setting102.First().Value.Substring(1, 1) == "1") ColRefIns1.Visible = true;
                else ColRefIns1.Visible = false;
                if (Setting102.First().Value.Substring(2, 1) == "1") ColRefIns2.Visible = true;
                else ColRefIns2.Visible = false;
                if (Setting102.First().Value.Substring(3, 1) == "1") ColRefServCat.Visible = true;
                else ColRefServCat.Visible = false;
                if (Setting102.First().Value.Substring(4, 1) == "1") ColRefDocCount.Visible = true;
                else ColRefDocCount.Visible = false;
                if (Setting102.First().Value.Substring(5, 1) == "1") ColRefLastDoc.Visible = true;
                else ColRefLastDoc.Visible = false;
                if (Setting102.First().Value.Substring(6, 1) == "1") ColIns1PriceTotal.Visible = true;
                else ColIns1PriceTotal.Visible = false;
                if (Setting102.First().Value.Substring(7, 1) == "1") ColIns1PartTotal.Visible = true;
                else ColIns1PartTotal.Visible = false;
                if (Setting102.First().Value.Substring(8, 1) == "1") ColIns1PatientPart.Visible = true;
                else ColIns1PatientPart.Visible = false;
                if (Setting102.First().Value.Substring(9, 1) == "1") ColIns2PriceTotal.Visible = true;
                else ColIns2PriceTotal.Visible = false;
                if (Setting102.First().Value.Substring(10, 1) == "1") ColIns2PartTotal.Visible = true;
                else ColIns2PartTotal.Visible = false;
            }
            else
            {
                ColRefPeriod.Visible = true;
                ColRefIns1.Visible = true;
                ColRefIns2.Visible = true;
                ColRefServCat.Visible = true;
                ColRefDocCount.Visible = true;
                ColRefLastDoc.Visible = true;
                ColIns1PriceTotal.Visible = true;
                ColIns1PartTotal.Visible = true;
                ColIns1PatientPart.Visible = true;
                ColIns2PriceTotal.Visible = true;
                ColIns2PartTotal.Visible = true;
            }
            #endregion
            #region 103
            // 103: لیست ستون های نمایش داده شده در نتیجه جستجوی فرم اصلی
            List<UsersSetting> Setting103 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 103).ToList();
            if (Setting103.Count != 0 && !String.IsNullOrEmpty(Setting103.First().Value))
            {
                if (Setting103.First().Value.Substring(0, 1) == "1") ColGender.Visible = true;
                else ColGender.Visible = false;
                if (Setting103.First().Value.Substring(1, 1) == "1") ColAge.Visible = true;
                else ColAge.Visible = false;
                if (Setting103.First().Value.Substring(2, 1) == "1") ColRefCount.Visible = true;
                else ColRefCount.Visible = false;
                if (Setting103.First().Value.Substring(3, 1) == "1") ColPersianRefDate.Visible = true;
                else ColPersianRefDate.Visible = false;
            }
            else
            {
                ColGender.Visible = true;
                ColAge.Visible = true;
                ColRefCount.Visible = true;
                ColPersianRefDate.Visible = true;
            }
            #endregion
            #region 104
            // 104: رفتار برنامه بعد از دوبار كلیك بر روی مراجعه
            if (SecurityManager.CurrentUserID < 3) _DefaultRefClickBehaviorID = 0;
            else
            {
                List<UsersSetting> Setting104 =
                    DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 104).ToList();
                if (Setting104.Count != 0 && !String.IsNullOrEmpty(Setting104.First().Value))
                    _DefaultRefClickBehaviorID = Convert.ToByte(Setting104.First().Value);
                else _DefaultRefClickBehaviorID = 0;
            }
            #endregion
            #region 105
            // 105: افزوده شدن آخرین كاربران مشاهده شده از فرم اصلی به منوی اصلی
            List<UsersSetting> Setting105 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 105).ToList();
            if (Setting105.Count != 0 && Setting105.First().Boolean != true) _ShouldAddRecentPatients = false;
            else _ShouldAddRecentPatients = true;
            #endregion
            // 106: امكان تغییر آیتم ها و دكمه های نوار دسترسی فوری در فرم اصلی - حذف شد
            #region 107
            // 107: نمایش نام كاربر جاری و تنظیمات اتصال جاری در پایین صفحه اصلی
            List<UsersSetting> Setting107 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 107).ToList();
            if (Setting107.Count != 0 && Setting107.First().Boolean != true) barStatus.Visible = false;
            else barStatus.Visible = true;
            #endregion

            #region 108
            // 108: دریافت تایید از كاربر هنگام خروج از برنامه
            List<UsersSetting> Setting108 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 108).ToList();
            if (Setting108.Count != 0 && Setting108.First().Boolean != true) _ShouldAskUserForExit = false;
            else _ShouldAskUserForExit = true;
            #endregion
            return true;
        }
        #endregion

        #region Boolean ReadCurrentUserAccess()
        /// <summary>
        /// تابع خواندن اطلاعات سطوح دسترسی كاربر
        /// </summary>
        /// <remarks>این تابع تنها دسترسی ها را بر اساس قابل دیده شدن و نشدن مدیریت می كند
        ///  و اگر كنترل قبلاً كامل حذف شده باشد ، با حذف آن كاری ندارد</remarks>
        /// <returns>صحت اعمال تنظیمات</returns>
        private Boolean ReadCurrentUserAccess()
        {
            Select(); BringToFront(); Focus(); Activate();
            if (SecurityManager.CurrentUserID < 3) return true;

            #region Patients Search Items - 501
            // بخش جستجوی بیماران
            if (!SecurityManager.GetCurrentUserPermission(501))
            {
                RBarSearchPatients.Visible = false;
                dgvPatData.Visible = false;
                dgvRefData.Visible = false;
                btnAdvancedSearch.Shortcuts.Clear();
            }
            else
            {
                RBarSearchPatients.Visible = true;
                dgvPatData.Visible = true;
                dgvRefData.Visible = true;
                // جستجوی پیشرفته
                if (!SecurityManager.GetCurrentUserPermission(5011))
                {
                    btnSearch.ShowSubItems = false;
                    btnAdvancedSearch.Shortcuts.Clear();
                }
                else
                {
                    btnSearch.ShowSubItems = true;
                    btnAdvancedSearch.Shortcuts.Clear();
                    btnAdvancedSearch.Shortcuts.Add(eShortcut.CtrlF);
                }
            }
            #endregion

            #region Schedules Menu - 502
            // منوی نوبت دهی
            if (SecurityManager.GetCurrentUserPermission(502) == false)
            {
                btnAppointments.Visible = false;
                btnAppointments.Shortcuts.Clear();
            }
            else
            {
                btnAppointments.Visible = true;
                btnAppointments.Shortcuts.Clear();
                btnAppointments.Shortcuts.Add(eShortcut.CtrlA);
            }
            #endregion

            #region Patient File - 503
            if (!SecurityManager.GetCurrentUserPermission(503))
            {
                btnNewPatient.Visible = false;
                btnNewPatient.Shortcuts.Clear();
                btnPatientFile.Visible = false;
                btnPatientFile.Shortcuts.Clear();
                btnDeletePatient.Visible = false;
            }
            else
            {
                if (!SecurityManager.GetCurrentUserPermission(5031))
                {
                    btnNewPatient.Visible = false;
                    btnNewPatient.Shortcuts.Clear();
                }
                else
                {
                    btnNewPatient.Visible = true;
                    btnNewPatient.Shortcuts.Clear();
                    btnNewPatient.Shortcuts.Add(eShortcut.CtrlS);
                }
                btnPatientFile.Visible = true;
                btnPatientFile.Shortcuts.Clear();
                btnPatientFile.Shortcuts.Add(eShortcut.F3);
                if (!SecurityManager.GetCurrentUserPermission(5035)) btnDeletePatient.Visible = false;
                else btnDeletePatient.Visible = true;
            }
            #endregion

            #region Referrals - 504
            if (!SecurityManager.GetCurrentUserPermission(504))
            {
                btnNewPatientRef.Visible = false;
                btnNewPatientRef.Shortcuts.Clear();
                btnLastRef.Visible = false;
                btnLastRef.Shortcuts.Clear();
                btnNewRef.Visible = false;
                btnNewRef.Shortcuts.Clear();
                btnRefAdmit.Visible = false;
                btnRefRemove.Visible = false;
            }
            else
            {
                // دسترسی افزودن مراجعه جدید
                if (!SecurityManager.GetCurrentUserPermission(5041))
                {
                    btnNewPatientRef.Visible = false;
                    btnNewPatientRef.Shortcuts.Clear();
                }
                else
                {
                    btnNewPatientRef.Visible = true;
                    btnNewPatientRef.Shortcuts.Clear();
                    btnNewPatientRef.Shortcuts.Add(eShortcut.CtrlD);
                }
                // دسترسی حذف مراجعه
                if (!SecurityManager.GetCurrentUserPermission(5044))
                {
                    btnRefRemove.Visible = false;
                    btnRefRemove.Shortcuts.Clear();
                }
                else btnRefRemove.Visible = true;
                btnLastRef.Visible = true;
                btnLastRef.Shortcuts.Clear();
                btnLastRef.Shortcuts.Add(eShortcut.F4);
                btnNewRef.Visible = true;
                btnNewRef.Shortcuts.Clear();
                btnNewRef.Shortcuts.Add(eShortcut.F2);
                btnRefAdmit.Visible = true;
            }
            #endregion

            #region Account - 505
            if (!SecurityManager.GetCurrentUserPermission(505))
            {
                btnLastAccount.Visible = false;
                btnLastAccount.Shortcuts.Clear();
                btnCashPatients.Visible = false;
                btnCashPatients.Shortcuts.Clear();
                btnCashManage.Visible = false;
                btnCashReport.Visible = false;
                btnRefAccount.Visible = false;
            }
            else
            {
                btnLastAccount.Visible = true;
                btnLastAccount.Shortcuts.Clear();
                btnLastAccount.Shortcuts.Add(eShortcut.F5);
                btnCashPatients.Visible = true;
                btnCashPatients.Shortcuts.Clear();
                btnCashPatients.Shortcuts.Add(eShortcut.CtrlQ);
                btnCashManage.Visible = true;
                btnCashReport.Visible = true;
                btnRefAccount.Visible = true;
            }
            #endregion

            #region Document - 506
            if (SecurityManager.GetCurrentUserPermission(506) == false)
            {
                btnDocumentPatients.Visible = false;
                btnDocumentPatients.Shortcuts.Clear();
                btnManageDoc.Visible = false;
                btnEditLastDoc.Visible = false;
                btnNewDoc.Visible = false;
                btnPrintRefDoc.Visible = false;
                btnRefLastDoc.Visible = false;
                btnRefDocs.Visible = false;
                btnRefNewDoc.Visible = false;
                btnRefPrintDoc.Visible = false;
            }
            else
            {
                // دسترسی ثبت مدرك جدید
                if (SecurityManager.GetCurrentUserPermission(5061) == false)
                {
                    btnDocumentPatients.Visible = false;
                    btnDocumentPatients.Shortcuts.Clear();
                    btnNewDoc.Visible = false;
                    btnRefNewDoc.Visible = false;
                }
                else
                {
                    btnDocumentPatients.Visible = true;
                    btnDocumentPatients.Shortcuts.Clear();
                    btnDocumentPatients.Shortcuts.Add(eShortcut.CtrlW);
                    btnNewDoc.Visible = true;
                    btnRefNewDoc.Visible = true;
                }
                // دسترسی ویرایش مدرك بیمار
                if (SecurityManager.GetCurrentUserPermission(5062) == false)
                {
                    btnEditLastDoc.Visible = false;
                    btnRefLastDoc.Visible = false;
                }
                else
                {
                    btnEditLastDoc.Visible = true;
                    btnRefLastDoc.Visible = true;
                }
                // سایر فرمان ها
                btnManageDoc.Visible = true;
                btnPrintRefDoc.Visible = true;
                btnRefDocs.Visible = true;
                btnRefPrintDoc.Visible = true;
            }
            #endregion

            #region Reports - 507
            //منوی گزارش
            if (SecurityManager.GetCurrentUserPermission(507) == false) btnReport.Visible = false;
            else
            {
                btnReport.Visible = true;
                // گزارش های عمومی
                if (SecurityManager.GetCurrentUserPermission(5071) == false) btnGeneralReports.Visible = false;
                else
                {
                    if (SecurityManager.GetCurrentUserPermission(50711) == false) btnR1.Visible = false;
                    else btnR1.Visible = true;
                    if (SecurityManager.GetCurrentUserPermission(50712) == false) btnR2.Visible = false;
                    else btnR2.Visible = true;
                    if (SecurityManager.GetCurrentUserPermission(50713) == false) btnR3.Visible = false;
                    else btnR3.Visible = true;
                    if (SecurityManager.GetCurrentUserPermission(50714) == false) btnR4.Visible = false;
                    else btnR4.Visible = true;
                    if (SecurityManager.GetCurrentUserPermission(50715) == false) btnR5.Visible = false;
                    else btnR5.Visible = true;
                    if (SecurityManager.GetCurrentUserPermission(50716) == false) btnR6.Visible = false;
                    else btnR6.Visible = true;
                    if (!btnR1.Visible && !btnR2.Visible && !btnR3.Visible && !btnR4.Visible && !btnR5.Visible && !btnR6.Visible)
                        btnGeneralReports.Visible = false;
                    else btnGeneralReports.Visible = true;
                }
                // گزارش های قابل طراحی
                if (SecurityManager.GetCurrentUserPermission(5072) == false) btnDesignableReports.Visible = false;
                else btnDesignableReports.Visible = true;
                // گزارش های اختصاصی
                if (SecurityManager.GetCurrentUserPermission(5073) == false) btnSpecialReports.Visible = false;
                else btnSpecialReports.Visible = true;
                Boolean IsAnyButtonVisible = false;
                foreach (ButtonItem btn in btnReport.SubItems) if (btn.Visible) { IsAnyButtonVisible = true; break; }
                if (IsAnyButtonVisible) btnReport.Visible = true;
                else btnReport.Visible = false;
            }
            #endregion

            #region Settings Menu - 508
            // منوی تنظیمات
            if (SecurityManager.GetCurrentUserPermission(508) == false) btnSettings.Visible = false;
            else
            {
                btnSettings.Visible = true;
                // امكان تغییر كلمه عبور كاربر جاری
                if (SecurityManager.GetCurrentUserPermission(50801) == false) btnChangePassword.Visible = false;
                else btnChangePassword.Visible = true;
                // امكان اعمال تنظیمات كاربری
                if (SecurityManager.GetCurrentUserPermission(50802) == false) btnUserSettings.Visible = false;
                else btnUserSettings.Visible = true;
                // تنظیمات امنیتی
                if (SecurityManager.GetCurrentUserPermission(50803) == false) btnSecuritySettings.Visible = false;
                else btnSecuritySettings.Visible = true;
                // تنظیمات نوبت دهی
                if (SecurityManager.GetCurrentUserPermission(50804) == false) btnSchSettings.Visible = false;
                else btnSchSettings.Visible = true;
                // تنظیمات بیماران
                if (SecurityManager.GetCurrentUserPermission(50805) == false) btnPatientsSettings.Visible = false;
                else btnPatientsSettings.Visible = true;
                // تنظیمات مراجعات
                if (SecurityManager.GetCurrentUserPermission(50806) == false) btnRefSettings.Visible = false;
                else btnRefSettings.Visible = true;
                // تنظیمات خدمات و بیمه ها
                if (SecurityManager.GetCurrentUserPermission(50807) == false) btnServInsSettings.Visible = false;
                else btnServInsSettings.Visible = true;
                // تنظیمات مالی و حسابداری
                if (SecurityManager.GetCurrentUserPermission(50808) == false) btnAccountCashSettings.Visible = false;
                else btnAccountCashSettings.Visible = true;
                // تنظیمات مدارك تصویربرداری
                if (SecurityManager.GetCurrentUserPermission(50809) == false) btnDocSettings.Visible = false;
                else btnDocSettings.Visible = true;
                // مدیریت قالب های قبوض
                if (SecurityManager.GetCurrentUserPermission(50810) == false) btnBillTemplatesSettings.Visible = false;
                else btnBillTemplatesSettings.Visible = true;
                // مدیریت اتصال به پكس
                if (SecurityManager.GetCurrentUserPermission(50811) == false) btnPacsManage.Visible = false;
                else btnPacsManage.Visible = true;
                // تنظیمات قالب های پیام كوتاه
                if (SecurityManager.GetCurrentUserPermission(50812) == false) btnMessagesSettings.Visible = false;
                else btnMessagesSettings.Visible = true;
                Boolean IsAnySettingButtonVisible = false;
                foreach (ButtonItem btn in btnSettings.SubItems) if (btn.Visible) { IsAnySettingButtonVisible = true; break; }
                if (IsAnySettingButtonVisible) btnSettings.Visible = true;
                else btnSettings.Visible = false;
            }
            #endregion

            #region Tools Menu - 509
            // منوی ابزارها
            if (SecurityManager.GetCurrentUserPermission(509) == false) btnTools.Visible = false;
            else
            {
                btnTools.Visible = true;
                // =========================
                // فرم ایجاد پشتیبانی
                if (SecurityManager.GetCurrentUserPermission(50901) == false) btnBackup.Visible = false;
                else btnBackup.Visible = true;
                // فرم بازیابی پشتیبانی
                if (SecurityManager.GetCurrentUserPermission(50902) == false) btnRestore.Visible = false;
                else btnRestore.Visible = true;
                // =========================
                // فرم بازسازی بانك اطلاعات
                if (SecurityManager.GetCurrentUserPermission(50903) == false) btnRebuildDataBase.Visible = false;
                else btnRebuildDataBase.Visible = true;
                // فرم حذف اطلاعات
                if (SecurityManager.GetCurrentUserPermission(50904) == false) btnDeleteData.Visible = false;
                else btnDeleteData.Visible = true;
                // فرم نمایش رخداد ها
                if (SecurityManager.GetCurrentUserPermission(50905) == false) btnEventsViewer.Visible = false;
                else btnEventsViewer.Visible = true;
                // =========================
                Boolean IsAnyToolsButtonVisible = false;
                foreach (ButtonItem btn in btnTools.SubItems) if (btn.Visible) { IsAnyToolsButtonVisible = true; break; }
                if (IsAnyToolsButtonVisible) btnTools.Visible = true;
                else btnTools.Visible = false;
            }
            #endregion

            #region Messaging Items - 510
            if (SecurityManager.GetCurrentUserPermission(510) == false)
            {
                btnMessagesDashboard.Visible = false;
                btnSendSMS.Visible = false;
            }
            else
            {
                // دسترسی به داشبورد ارسال پیام كوتاه
                if (SecurityManager.GetCurrentUserPermission(5101) == false) btnMessagesDashboard.Visible = false;
                else btnMessagesDashboard.Visible = true;
                // امكان ارسال پیام كوتاه از فرم اصلی
                if (SecurityManager.GetCurrentUserPermission(5102) == false) btnSendSMS.Visible = false;
                else btnSendSMS.Visible = true;
            }
            #endregion

            Boolean IsAnyFileButtonVisible = false;
            foreach (ButtonItem btn in btnFile.SubItems) if (btn.Visible) { IsAnyFileButtonVisible = true; break; }
            if (IsAnyFileButtonVisible) btnFile.Visible = true;
            else btnFile.Visible = false;
            return true;
        }
        #endregion

        #region void AddUsedPatientToRecentList(Int32 PatientListID)
        /// <summary>
        /// افزودن یك بیمار به لیست آخرین بیماران مشاهده شده
        /// </summary>
        /// <param name="PatientListID">كلید بیمار مورد نظر</param>
        private void AddUsedPatientToRecentList(Int32 PatientListID)
        {
            if (!_ShouldAddRecentPatients) return;
            // بررسی افزوده شدن بیمار در فرمان های قبلی
            if (_RecentPatientsList.ToList().Where(Data => Data == PatientListID).ToList().Count != 0) return;
            // نمایش پنل آخرین بیماران مشاهده شده
            if (!btnLastPatients.Visible)
            {
                btnLastPatients.Visible = true;
                FormMenu.Invalidate();
            }
            #region Create New Button
            PatientSearcher.PatientData PatientData = null;
            foreach (DataGridViewRow row in dgvPatData.Rows)
                if (((PatientSearcher.PatientData)row.DataBoundItem).PatientListID == PatientListID)
                {
                    PatientData = (PatientSearcher.PatientData)row.DataBoundItem;
                    break;
                }
            if (PatientData == null) return;
            ButtonItem btn = new ButtonItem();
            btn.Text = PatientData.PatientID + " - " + PatientData.PatientFullName;
            btn.Tag = PatientListID;
            btn.FontBold = true;
            if (_RecentPatientsList.Count % 2 == 0) btn.ColorTable = eButtonColor.Orange;
            else btn.ColorTable = eButtonColor.OrangeWithBackground;
            btn.PersonalizedMenus = ePersonalizedMenus.Disabled;
            btn.CanCustomize = false;
            btn.MouseUp += btnRecentPatient_MouseUp;
            btn.Click += btnRecentPatient_Click;
            #endregion
            // حذف قدیمی ترین بیمار ، در صورتی كه تعداد بیماران افزوده به 10 بیمار رسیده باشد
            if (_RecentPatientsList.Count == 10)
            {
                _RecentPatientsList.Dequeue();
                iContainerRecentPatients.SubItems.RemoveAt(1);
            }
            // افزودن به لیست آخرین بیماران
            _RecentPatientsList.Enqueue(Convert.ToInt32(btn.Tag));
            iContainerRecentPatients.SubItems.Add(btn);
        }
        #endregion

        #endregion

    }
}