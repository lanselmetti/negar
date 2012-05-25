#region using

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Schedules
{
    /// <summary>
    /// فرم ویرایش نوبت بیمار
    /// </summary>
    internal partial class frmAppointmentsEdit : Form
    {

        #region Fields

        #region Boolean _IsFormControlModified
        /// <summary>
        /// تعیین ویرایش شدن تراكنش حساب  جاری توسط كاربر از حالت اولیه
        /// </summary>
        private Boolean _IsFormControlModified;
        #endregion

        #region readonly Int32 _CurrentID
        private readonly Int32 _CurrentID;
        #endregion

        #region SchAppointments _CurrentAppointmentData;
        /// <summary>
        /// فیلد اطلاعات نوبت جاری
        /// </summary>
        private SchAppointments _CurrentAppointmentData;
        #endregion

        #region List<SP_SelectAppAdditionalColumnsResult> _AppAdditionalCols
        /// <summary>
        /// لیست ستون های اضافی تحت پوشش این برنامه نوبت دهی
        /// </summary>
        private List<SP_SelectAppAdditionalColumnsResult> _AppAdditionalCols;
        #endregion

        #region Dictionary<String, String> _ChangedCtrls
        /// <summary>
        /// دیكشنری نگهدارنده نام ستون و مقدار تغییر یافته
        /// </summary>
        private Dictionary<String, String> _ChangedCtrls = new Dictionary<String, String>();
        #endregion

        #region Boolean _IsAppointed
        /// <summary>
        /// آیا این نوبت برای اولین بار نوبت دهی می شود؟
        /// </summary>
        private Boolean _IsAppointed;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAppointmentsEdit(Int32 AppointmentID)
        {
            InitializeComponent();
            _CurrentID = AppointmentID;
            InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            if (!FillAppointmentData(_CurrentID)) { Close(); return; }
            SetControlsChangeEventHandlers();
            if (!ReadFormCurrentUserSettings()) { Close(); return; }
            _IsFormControlModified = false;
        }
        #endregion

        #region Controls_TextChanged
        void Controls_TextChanged(object sender, EventArgs e)
        {
            SaveChangedControls((Control)sender);
            _IsFormControlModified = true;
        }
        #endregion

        #region txtAge_ButtonCustomClick
        private void txtAge_ButtonCustomClick(object sender, EventArgs e)
        {
            frmChangeDate MyForm = new frmChangeDate();
            if (txtAge.ValueObject != null)
                MyForm.FormDatePicker.SelectedDateTime = DateTime.Now.AddYears(-1 * txtAge.Value);
            MyForm.ShowDialog();
            if (MyForm.DialogResult == DialogResult.OK)
            {
                if (MyForm.FormDatePicker.SelectedDateTime == null)
                    txtAge.ValueObject = null;
                else txtAge.ValueObject =
                    (DateTime.Now.Year - Convert.ToInt32(MyForm.FormDatePicker.SelectedDateTime.Value.Date.Year));
            }
            MyForm.Dispose();
        }
        #endregion

        #region btnAccept_Click
        /// <summary>
        /// تایید اعمال تغییرات در بانك
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (_IsFormControlModified)
            {
                _CurrentAppointmentData.OrderNo = Convert.ToInt16(txtOrderNo.Value);
                _CurrentAppointmentData.OccuredDateTime = new DateTime(
                    _CurrentAppointmentData.OccuredDateTime.Year,
                    _CurrentAppointmentData.OccuredDateTime.Month,
                    _CurrentAppointmentData.OccuredDateTime.Day,
                    TimeInputShiftTime.Value.Hour, TimeInputShiftTime.Value.Minute,
                    TimeInputShiftTime.Value.Second, 0);
                _CurrentAppointmentData.FirstName = txtFirstName.Text.Trim().Normalize();
                _CurrentAppointmentData.LastName = txtLastName.Text.Trim().Normalize();
                #region Is Male
                if (cboxMale.Checked) _CurrentAppointmentData.IsMale = true;
                else if (cBoxFemale.Checked) _CurrentAppointmentData.IsMale = false;
                else _CurrentAppointmentData.IsMale = null;
                #endregion

                Byte? Age = null;
                if (txtAge.ValueObject != null) Age = Convert.ToByte(txtAge.Value);
                _CurrentAppointmentData.Age = Age;
                _CurrentAppointmentData.TelNo1 = txtTel1.Text.Trim().Normalize();
                _CurrentAppointmentData.TelNo2 = txtTel2.Text.Trim().Normalize();
                _CurrentAppointmentData.IsAppointed = true;
                //_CurrentAppointmentData.SchedulerIX = Convert.ToInt16(cboSchedulders.SelectedValue);
                _CurrentAppointmentData.SchedulerIX = SecurityManager.CurrentUserID;
                _CurrentAppointmentData.DateTime = DateTime.Now;

                #region Save Data & Addin Data
                try
                {
                    DBLayerIMS.Manager.DBML.SubmitChanges();
                    foreach (Control ctrl in PanelAdditionalData.Controls)
                    {
                        if (!ctrl.GetType().Equals(typeof(Label)))
                        {
                            if (ctrl.GetType().Equals(typeof(CheckBoxX)))
                                DBLayerIMS.Manager.DBML.SP_InsertAppointmentAddBoolData(
                                    _CurrentAppointmentData.ID, ctrl.Name, ((CheckBoxX)ctrl).Checked);
                            else if (ctrl.GetType().Equals(typeof(TextBox)))
                                DBLayerIMS.Manager.DBML.SP_InsertAppointmentAddStringData(
                                    _CurrentAppointmentData.ID, ctrl.Name, ctrl.Text.Trim().Normalize());
                            else if (ctrl.GetType().Equals(typeof(IntegerInput)))
                                DBLayerIMS.Manager.DBML.SP_InsertAppointmentAddIntData(
                                    _CurrentAppointmentData.ID, ctrl.Name, (Int32?)((IntegerInput)ctrl).ValueObject);
                            else if (ctrl.GetType().Equals(typeof(ComboBox)))
                                DBLayerIMS.Manager.DBML.SP_InsertAppointmentAddIntData(
                                    _CurrentAppointmentData.ID, ctrl.Name, (Int16?)((ComboBox)ctrl).SelectedValue);
                        }
                    }
                    // آزاد سازی نوبت جاری
                    DBLayerIMS.Manager.DBML.SP_ChangeLockAppointments(_CurrentAppointmentData.ID, false);
                    _IsFormControlModified = false;
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان ثبت اطلاعات نوبت جاری در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                        "2. آیا بیش از 10 دقیقه در حال ویرایش این نوبت بوده اید؟\n" +
                        "ممكن در پس از 10 دقیقه كاربر دیگری نوبت جاری را ویرایش نموده باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    _IsFormControlModified = false;
                    DialogResult = DialogResult.Cancel;
                }
                #endregion
                #endregion
            }
            if (!InsertSchLogEvent()) return;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (_IsFormControlModified)
            {
                DialogResult Dr = PMBox.Show("آیا از اعمال تغییرات منصرف شدید؟", "هشدار",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
            #region Change IsEditing To "False"
            try
            { DBLayerIMS.Manager.DBML.SP_ChangeLockAppointments(_CurrentAppointmentData.ID, false); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان آزاد سازی نوبت انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                    "احتمالاً نوبت مورد نظر قفل شده و باید آزاد گردد.";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
            #endregion
            Dispose();
            GC.Collect();
        }
        #endregion

        #endregion

        #region Methods

        #region static void SetComboBoxReadOnly(ComboBox cbo, Boolean Readonly)
        private static void SetComboBoxReadOnly(ComboBox cbo, Boolean Readonly)
        {
            #region ReadOnly
            if (Readonly)
            {
                cbo.KeyDown += (cbo_KeyDown);
                cbo.KeyPress += (cbo_KeyPress);
                cbo.ContextMenu = new ContextMenu();
                cbo.AccessibleDescription = cbo.DropDownStyle.ToString();
                cbo.DropDownStyle = ComboBoxStyle.Simple;
            }
            #endregion

            #region Not ReadOnly
            else
            {
                cbo.KeyDown -= (cbo_KeyDown);
                cbo.KeyPress -= (cbo_KeyPress);
                cbo.ContextMenu = null;
                if (cbo.AccessibleDescription == "DropDown")
                    cbo.DropDownStyle = ComboBoxStyle.DropDown;
                else cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            #endregion

            cbo.Invalidate();
        }

        static void cbo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Delete)
                e.Handled = true;
        }

        static void cbo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Boolean ReadFormCurrentUserSettings()
        /// <summary>
        /// تابع خواندن تنظیمات كاربر جاری
        /// </summary>
        /// <returns></returns>
        private Boolean ReadFormCurrentUserSettings()
        {
            #region 202
            // 202: لیست ستون های نمایش داده شده جدول نوبت دهی
            List<UsersSetting> Setting202 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 202).ToList();
            if (Setting202.Count != 0 && !String.IsNullOrEmpty(Setting202.First().Value))
            {
                if (Setting202.First().Value.Substring(0, 1) == "0")
                {
                    lblGender.Hide();
                    cboxMale.Hide();
                    cBoxFemale.Hide();
                }
                if (Setting202.First().Value.Substring(1, 1) == "0")
                {
                    lblAge.Hide();
                    txtAge.Hide();
                    lblTel2.Left += 140;
                    txtTel2.Left += 140;
                    lblTel1.Left += 140;
                    txtTel1.Left += 140;
                }
                if (Setting202.First().Value.Substring(2, 1) == "0")
                {
                    lblTel1.Hide();
                    txtTel1.Hide();
                    lblTel2.Left += 160;
                    txtTel2.Left += 160;
                }
                if (Setting202.First().Value.Substring(3, 1) == "0")
                {
                    lblTel2.Hide();
                    txtTel2.Hide();
                }
                if (Setting202.First().Value.Substring(1, 1) == "0" &&
                    Setting202.First().Value.Substring(2, 1) == "0" &&
                    Setting202.First().Value.Substring(3, 1) == "0")
                {
                    Panel2.Height -= 27;
                    PanelAdditionalData.Top -= 27;
                    PanelAdditionalData.Height += 27;
                }
            }
            #endregion

            #region 204
            // 204: امكان تغییر كاربر نوبت دهنده برای یك نوبت در فرم ویرایش نوبت
            if (DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 204).Count() > 0 &&
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 204).First().Boolean == false)
                SetComboBoxReadOnly(cboSchedulders, true);
            #endregion
            return true;
        }
        #endregion

        #region void SetControlsChangeEventHandlers()
        /// <summary>
        /// تابع تنظیم متن راهنمای كنترل ها
        /// </summary>
        private void SetControlsChangeEventHandlers()
        {
            foreach (Control ctrl in Panel1.Controls)
            {
                if (ctrl is ComboBoxEx) ((ComboBoxEx)ctrl).SelectedIndexChanged += (Controls_TextChanged);
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += (Controls_TextChanged);
                else if (ctrl is DateTimeInput) ((DateTimeInput)ctrl).ValueChanged += (Controls_TextChanged);
            }
            foreach (Control ctrl in Panel2.Controls)
            {
                if (ctrl is TextBoxX) ctrl.TextChanged += (Controls_TextChanged);
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += (Controls_TextChanged);
            }
            cboxMale.CheckedChanged += Controls_TextChanged;
            cBoxFemale.CheckedChanged += Controls_TextChanged;
            foreach (Control ctrl in PanelAdditionalData.Controls)
            {
                if (ctrl is TextBox) ctrl.TextChanged += (Controls_TextChanged);
                else if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += (Controls_TextChanged);
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += (Controls_TextChanged);
                else if (ctrl is ComboBox) ((ComboBox)ctrl).SelectedIndexChanged += (Controls_TextChanged);
            }
            _IsFormControlModified = false;
        }
        #endregion

        #region Boolean FillAppointmentData(Int32 AppointmentID)
        /// <summary>
        /// تابع خواندن اطلاعات نوبت ارسال شده
        /// </summary>
        /// <param name="AppointmentID">كلید نوبت</param>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean FillAppointmentData(Int32 AppointmentID)
        {
            try
            {
                #region Change IsEditing To "True"
                try
                { DBLayerIMS.Manager.DBML.SP_ChangeLockAppointments(AppointmentID, true); }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان ذخیره سازی تغییرات در نوبت انتخاب شده وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return false;
                }
                #endregion
                #endregion

                _CurrentAppointmentData = DBLayerIMS.Manager.DBML.
                    SchAppointments.Where(Data => Data.ID == AppointmentID).First();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _CurrentAppointmentData);

                #region Fill cboSchedulers
                SetComboBoxReadOnly(cboSchedulders, true);
                cboSchedulders.DataSource = Negar.DBLayerPMS.Security.UsersList;
                cboSchedulders.DisplayMember = "FullName";
                cboSchedulders.ValueMember = "ID";
                if (_CurrentAppointmentData.SchedulerIX == null)
                    cboSchedulders.SelectedValue = SecurityManager.CurrentUserID;
                else cboSchedulders.SelectedValue = _CurrentAppointmentData.SchedulerIX;
                #endregion

                txtTitle.Text = DBLayerIMS.Manager.DBML.SP_SelectApplications().
                    Where(result => result.ID == _CurrentAppointmentData.ApplicationIX).
                    Select(result => result.Name.Trim()).First();
                // ست كردن این كه برای اولین بار نوبت داده می شود
                _IsAppointed = _CurrentAppointmentData.IsAppointed;

                #region Read AppAdditionalColumns
                // خواندن ستون های اطلاعات اضافی
                _AppAdditionalCols =
                    DBLayerIMS.Manager.DBML.SP_SelectAppAdditionalColumns(
                    _CurrentAppointmentData.ApplicationIX).ToList();
                #endregion

                #region Fill Additional Columns Data
                // خواندن فیلد های اطلاعاتی اضافی نوبت دهی در صورتی كه
                // فیلدی تعریف شده باشد و كاربر مدیر باشد یا مجوز داشته باشد
                if (_AppAdditionalCols.Count > 0 &&
                    (SecurityManager.CurrentUserID < 3 || LicenseHelper.GetSavedLicenses().Contains("515")))
                {
                    DataTable TempDataTable = DBLayerIMS.Manager.ExecuteQuery(
                        "EXECUTE [Schedules].[SP_SelectSchAdditionalData] " + AppointmentID, 5);
                    if (TempDataTable == null) return false;

                    #region Insert AppAdditionalCols
                    // اضافه كردن ستون های اطلاعات اضافی برنامه انتخاب شده
                    Int32 CtrlHeight = 2;
                    for (Int32 i = 0; i < _AppAdditionalCols.Count; i++)
                    {
                        switch (_AppAdditionalCols[i].TypeID)
                        {
                            #region String Fields
                            case 0: // String Fields
                                {
                                    Label lblAdditionalTitle = new Label();
                                    lblAdditionalTitle.RightToLeft = RightToLeft.Yes;
                                    lblAdditionalTitle.Tag = _AppAdditionalCols[i].ID;
                                    lblAdditionalTitle.Name = _AppAdditionalCols[i].FieldName;
                                    lblAdditionalTitle.Text = _AppAdditionalCols[i].Title;
                                    lblAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                                    lblAdditionalTitle.AutoSize = false;
                                    lblAdditionalTitle.Size = new Size(225, 21);
                                    if (i % 2 != 0) lblAdditionalTitle.Location = new Point(10, CtrlHeight);
                                    else lblAdditionalTitle.Location = new Point(250, CtrlHeight);
                                    lblAdditionalTitle.Margin = new Padding(4);
                                    lblAdditionalTitle.Padding = new Padding(4);
                                    PanelAdditionalData.Controls.Add(lblAdditionalTitle);
                                    CtrlHeight = CtrlHeight + 24;
                                    TextBox txtAdditionalData = new TextBox();
                                    txtAdditionalData.Tag = _AppAdditionalCols[i].ID;
                                    txtAdditionalData.Name = _AppAdditionalCols[i].FieldName;
                                    txtAdditionalData.AutoSize = false;
                                    txtAdditionalData.MaxLength = _AppAdditionalCols[i].Lenght.Value;
                                    txtAdditionalData.Size = new Size(225, 21);
                                    if (i % 2 != 0) txtAdditionalData.Location = new Point(10, CtrlHeight);
                                    else txtAdditionalData.Location = new Point(250, CtrlHeight);
                                    txtAdditionalData.Margin = new Padding(4);
                                    txtAdditionalData.Padding = new Padding(4);
                                    // پر كردن فیلد های ستون اطلاعات اضافی
                                    if (TempDataTable.Rows[0][_AppAdditionalCols[i].FieldName].GetType() != typeof(DBNull))
                                        txtAdditionalData.Text = TempDataTable.Rows[0][_AppAdditionalCols[i].FieldName].ToString();
                                    PanelAdditionalData.Controls.Add(txtAdditionalData);
                                    if (i % 2 == 0) CtrlHeight = CtrlHeight - 24;
                                    else CtrlHeight = CtrlHeight + 24;
                                } break;
                            #endregion

                            #region Boolean Fields
                            case 1: // Boolean Fields
                                {
                                    CheckBoxX cBoxAdditionalTitle = new CheckBoxX();
                                    cBoxAdditionalTitle.Tag = _AppAdditionalCols[i].ID;
                                    cBoxAdditionalTitle.Name = _AppAdditionalCols[i].FieldName;
                                    cBoxAdditionalTitle.Text = _AppAdditionalCols[i].Title;
                                    cBoxAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                                    cBoxAdditionalTitle.AutoSize = false;
                                    cBoxAdditionalTitle.Size = new Size(225, 21);
                                    cBoxAdditionalTitle.Margin = new Padding(4);
                                    cBoxAdditionalTitle.Padding = new Padding(4);
                                    if (i % 2 != 0) cBoxAdditionalTitle.Location = new Point(10, CtrlHeight);
                                    else cBoxAdditionalTitle.Location = new Point(250, CtrlHeight);
                                    // پر كردن فیلد های ستون اطلاعات اضافی
                                    if (TempDataTable.Rows[0][_AppAdditionalCols[i].FieldName].GetType() != typeof(DBNull))
                                        cBoxAdditionalTitle.Checked =
                                            Convert.ToBoolean(TempDataTable.Rows[0][_AppAdditionalCols[i].FieldName]);
                                    PanelAdditionalData.Controls.Add(cBoxAdditionalTitle);
                                    CtrlHeight = CtrlHeight + 24;
                                    Label lblAdditionalTitle = new Label();
                                    lblAdditionalTitle.RightToLeft = RightToLeft.Yes;
                                    lblAdditionalTitle.Tag = _AppAdditionalCols[i].ID;
                                    lblAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                                    lblAdditionalTitle.Name = _AppAdditionalCols[i].FieldName;
                                    lblAdditionalTitle.Text = _AppAdditionalCols[i].Description;
                                    lblAdditionalTitle.AutoSize = false;
                                    lblAdditionalTitle.Size = new Size(225, 21);
                                    if (i % 2 != 0) lblAdditionalTitle.Location = new Point(10, CtrlHeight);
                                    else lblAdditionalTitle.Location = new Point(250, CtrlHeight);
                                    lblAdditionalTitle.Margin = new Padding(4);
                                    lblAdditionalTitle.Padding = new Padding(4);
                                    PanelAdditionalData.Controls.Add(lblAdditionalTitle);
                                    if (i % 2 == 0) CtrlHeight = CtrlHeight - 24;
                                    else CtrlHeight = CtrlHeight + 24;
                                } break;
                            #endregion

                            #region Integer Fields
                            case 2: // Integer Fields
                                {
                                    Label lblAdditionalTitle = new Label();
                                    lblAdditionalTitle.RightToLeft = RightToLeft.Yes;
                                    lblAdditionalTitle.Tag = _AppAdditionalCols[i].ID;
                                    lblAdditionalTitle.Name = _AppAdditionalCols[i].FieldName;
                                    lblAdditionalTitle.Text = _AppAdditionalCols[i].Title;
                                    lblAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                                    lblAdditionalTitle.AutoSize = false;
                                    lblAdditionalTitle.Size = new Size(225, 21);
                                    if (i % 2 != 0) lblAdditionalTitle.Location = new Point(10, CtrlHeight);
                                    else lblAdditionalTitle.Location = new Point(250, CtrlHeight);
                                    lblAdditionalTitle.Margin = new Padding(4);
                                    lblAdditionalTitle.Padding = new Padding(4);
                                    PanelAdditionalData.Controls.Add(lblAdditionalTitle);
                                    CtrlHeight = CtrlHeight + 24;
                                    IntegerInput txtAdditionalData = new IntegerInput();
                                    txtAdditionalData.Tag = _AppAdditionalCols[i].ID;
                                    txtAdditionalData.Name = _AppAdditionalCols[i].FieldName;
                                    txtAdditionalData.AutoSize = false;
                                    txtAdditionalData.MaxValue = 2147483647;
                                    txtAdditionalData.ShowUpDown = true;
                                    txtAdditionalData.InputHorizontalAlignment = eHorizontalAlignment.Center;
                                    txtAdditionalData.Size = new Size(225, 21);
                                    if (i % 2 != 0) txtAdditionalData.Location = new Point(10, CtrlHeight);
                                    else txtAdditionalData.Location = new Point(250, CtrlHeight);
                                    txtAdditionalData.Margin = new Padding(4);
                                    txtAdditionalData.Padding = new Padding(4);
                                    // پر كردن فیلد های ستون اطلاعات اضافی
                                    if (TempDataTable.Rows[0][_AppAdditionalCols[i].FieldName].GetType() != typeof(DBNull))
                                        txtAdditionalData.Value = Convert.ToInt32(TempDataTable.Rows[0][_AppAdditionalCols[i].FieldName]);
                                    PanelAdditionalData.Controls.Add(txtAdditionalData);
                                    if (i % 2 == 0) CtrlHeight = CtrlHeight - 24;
                                    else CtrlHeight = CtrlHeight + 24;
                                } break;
                            #endregion

                            #region MultiChoice Fields
                            case 3: // MultiChoice Fields
                                {
                                    Label lblAdditionalTitle = new Label();
                                    lblAdditionalTitle.RightToLeft = RightToLeft.Yes;
                                    lblAdditionalTitle.Tag = _AppAdditionalCols[i].ID;
                                    lblAdditionalTitle.Name = _AppAdditionalCols[i].FieldName;
                                    lblAdditionalTitle.Text = _AppAdditionalCols[i].Title;
                                    lblAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                                    lblAdditionalTitle.AutoSize = false;
                                    lblAdditionalTitle.Size = new Size(225, 21);
                                    if (i % 2 != 0) lblAdditionalTitle.Location = new Point(10, CtrlHeight);
                                    else lblAdditionalTitle.Location = new Point(250, CtrlHeight);
                                    lblAdditionalTitle.Margin = new Padding(4);
                                    lblAdditionalTitle.Padding = new Padding(4);
                                    PanelAdditionalData.Controls.Add(lblAdditionalTitle);
                                    CtrlHeight = CtrlHeight + 24;
                                    ComboBox cboAdditionalData = new ComboBox();
                                    cboAdditionalData.Tag = _AppAdditionalCols[i].ID;
                                    cboAdditionalData.Name = _AppAdditionalCols[i].FieldName;
                                    cboAdditionalData.AutoSize = false;
                                    cboAdditionalData.Size = new Size(225, 21);
                                    if (i % 2 != 0) cboAdditionalData.Location = new Point(10, CtrlHeight);
                                    else cboAdditionalData.Location = new Point(250, CtrlHeight);
                                    cboAdditionalData.Margin = new Padding(4);
                                    cboAdditionalData.Padding = new Padding(4);
                                    cboAdditionalData.DropDownStyle = ComboBoxStyle.DropDownList;
                                    cboAdditionalData.FlatStyle = FlatStyle.Standard;
                                    cboAdditionalData.ValueMember = "ID";
                                    cboAdditionalData.DisplayMember = "Title";
                                    cboAdditionalData.DataSource = DBLayerIMS.Manager.DBML.SP_SelectMultiSelectItems(_AppAdditionalCols[i].ID).ToList();
                                    PanelAdditionalData.Controls.Add(cboAdditionalData);
                                    // پر كردن فیلد های ستون اطلاعات اضافی
                                    if (TempDataTable.Rows[0][_AppAdditionalCols[i].FieldName].GetType() == typeof(DBNull))
                                        cboAdditionalData.SelectedIndex = 0;
                                    else cboAdditionalData.SelectedValue =
                                           Convert.ToInt16(TempDataTable.Rows[0][_AppAdditionalCols[i].FieldName]);
                                    if (i % 2 == 0) CtrlHeight = CtrlHeight - 24;
                                    else CtrlHeight = CtrlHeight + 24;
                                } break;
                            #endregion
                        }
                    }
                    #endregion
                }
                else
                {
                    PanelAdditionalData.Hide();
                    Height = 263;
                }
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات نوبت جاری از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error);
                return false;
            }
            #endregion

            #region Fill Controls
            txtOrderNo.Value = _CurrentAppointmentData.OrderNo;
            PersianDate OccuredDate = PersianDateConverter.ToPersianDate(
                _CurrentAppointmentData.OccuredDateTime.Date);
            txtAppDate.Text = OccuredDate.Year + "/" + OccuredDate.Month + "/" + OccuredDate.Day;
            TimeInputShiftTime.Value = _CurrentAppointmentData.OccuredDateTime;
            txtFirstName.Text = _CurrentAppointmentData.FirstName;
            txtLastName.Text = _CurrentAppointmentData.LastName;
            #region IsMale
            if (_CurrentAppointmentData.IsMale != null)
            {
                if (Convert.ToBoolean(_CurrentAppointmentData.IsMale)) cboxMale.Checked = true;
                else cBoxFemale.Checked = true;
            }
            else
            {
                PanelGender.TabStop = true;
                cboxMale.TabStop = true;
            }
            #endregion
            #region Age
            if (_CurrentAppointmentData.Age != null)
                txtAge.Value = _CurrentAppointmentData.Age.Value;
            else txtAge.ValueObject = null;
            #endregion
            txtTel1.Text = _CurrentAppointmentData.TelNo1;
            txtTel2.Text = _CurrentAppointmentData.TelNo2;
            #endregion

            return true;
        }
        #endregion

        #region Boolean SaveLog(Control Ctrl)
        /// <summary>
        /// تابع ذخیره كننده كنترل های تغییر كرده
        /// </summary>
        /// <param name="Ctrl">كنترل تغییر كرده</param>
        private void SaveChangedControls(Control Ctrl)
        {
            #region Static Fields
            if (Ctrl.Name == "txtOrderNo")
            {
                Int16 OrderNo = Convert.ToInt16(((IntegerInput)Ctrl).Value);
                if (_ChangedCtrls.ContainsKey("ردیف")) _ChangedCtrls["ردیف"] = OrderNo.ToString();
                else _ChangedCtrls.Add("ردیف", OrderNo.ToString());
                return ;
            }
            if (Ctrl.Name == "TimeInputShiftTime")
            {
                String ShiftTime = ((DateTimeInput)Ctrl).Value.Hour + ":" + ((DateTimeInput)Ctrl).Value.Minute;
                if (_ChangedCtrls.ContainsKey("زمان")) _ChangedCtrls["زمان"] = ShiftTime;
                else _ChangedCtrls.Add("زمان", ShiftTime);
                return ;
            }
            if (Ctrl.Name == "txtFirstName")
            {
                if (_ChangedCtrls.ContainsKey("نام")) _ChangedCtrls["نام"] = Ctrl.Text;
                else _ChangedCtrls.Add("نام", Ctrl.Text);
                return ;
            }
            if (Ctrl.Name == "txtLastName")
            {
                if (_ChangedCtrls.ContainsKey("نام خانوادگی")) _ChangedCtrls["نام خانوادگی"] = Ctrl.Text;
                else _ChangedCtrls.Add("نام خانوادگی", Ctrl.Text);
                return ;
            }
            String IsMale;
            if (Ctrl.Name == "cboxMale")
            {
                if (((RadioButton)Ctrl).Checked) IsMale = "بله";
                else IsMale = "خیر";
                if (_ChangedCtrls.ContainsKey("مرد")) _ChangedCtrls["مرد"] = IsMale;
                else _ChangedCtrls.Add("مرد", IsMale);
                return ;
            }
            if (Ctrl.Name == "cBoxFemale")
            {
                if (((RadioButton)Ctrl).Checked) IsMale = "خیر";
                else IsMale = "بله";
                if (_ChangedCtrls.ContainsKey("مرد")) _ChangedCtrls["مرد"] = IsMale;
                else _ChangedCtrls.Add("مرد", IsMale);
                return ;
            }
            if (Ctrl.Name == "txtAge")
            {
                String Age = "";
                if (((IntegerInput)Ctrl).ValueObject != null) Age = Convert.ToByte(((IntegerInput)Ctrl).Value).ToString();
                if (_ChangedCtrls.ContainsKey("سن")) _ChangedCtrls["سن"] = Age;
                else _ChangedCtrls.Add("سن", Age);
                return ;
            }
            if (Ctrl.Name == "txtTel1")
            {
                if (_ChangedCtrls.ContainsKey("تلفن تماس 1")) _ChangedCtrls["تلفن تماس 1"] = Ctrl.Text;
                else _ChangedCtrls.Add("تلفن تماس 1", Ctrl.Text);
                return ;
            }
            if (Ctrl.Name == "txtTel2")
            {
                if (_ChangedCtrls.ContainsKey("تلفن تماس 2")) _ChangedCtrls["تلفن تماس 2"] = Ctrl.Text;
                else _ChangedCtrls.Add("تلفن تماس 2", Ctrl.Text);
                return ;
            }
            #endregion

            #region Dynamic Fields
            String AddFieldsTitle = _AppAdditionalCols.Where(Data => Data.FieldName == Ctrl.Name).First().Title;
            String AddFieldValue = "";
            if (Ctrl is TextBox) AddFieldValue = Ctrl.Text;
            else if (Ctrl is CheckBoxX)
            {
                if (((CheckBoxX)Ctrl).Checked) AddFieldValue = "بله";
                else AddFieldValue = "خیر";
            }
            else if (Ctrl is IntegerInput)
            {
                if (((IntegerInput)Ctrl).ValueObject != null)
                    AddFieldValue = Convert.ToInt32(((IntegerInput)Ctrl).Value).ToString();
            }
            else if (Ctrl is ComboBox)
            {
                AddFieldValue = ((ComboBox)Ctrl).SelectedText;
            }
            if (_ChangedCtrls.ContainsKey(AddFieldsTitle)) _ChangedCtrls[AddFieldsTitle] = AddFieldValue;
            else _ChangedCtrls.Add(AddFieldsTitle, AddFieldValue);
            #endregion
        }
        #endregion

        #region Boolean InsertSchLogEvent()
        /// <summary>
        /// تابع ذخیره كننده تغییرات نوبت در بانك اطلاعاتی
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean InsertSchLogEvent()
        {
            if (!_IsAppointed && !DBLayerIMS.Schedules.InsertSchLogEvents(_CurrentID, 101, String.Empty, String.Empty))
                return false;

            foreach (KeyValuePair<String, String> ChangedCtrl in _ChangedCtrls)
            {
                if (String.IsNullOrEmpty(ChangedCtrl.Value))
                {
                    if (!DBLayerIMS.Schedules.InsertSchLogEvents(_CurrentID, 105, ChangedCtrl.Key, String.Empty))
                        continue;
                }
                else
                {
                    if (!DBLayerIMS.Schedules.InsertSchLogEvents(_CurrentID, 104, ChangedCtrl.Key, ChangedCtrl.Value))
                        continue;
                }
            }
            return true;
        }
        #endregion

        #endregion

    }
}