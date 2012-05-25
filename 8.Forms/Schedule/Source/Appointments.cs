#region using

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.GridPrinting;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Admission.Classes;
using Sepehr.Forms.Schedules.Properties;

#endregion

namespace Sepehr.Forms.Schedules
{
    /// <summary>
    /// فرم مدیریت برنامه های نوبت دهی
    /// </summary>
    public partial class frmAppointments : Form
    {

        #region Fields

        #region readonly AppointmentDataGridView dgvSchedules
        /// <summary>
        /// 
        /// </summary>
        private readonly SchDataGridView dgvSchedules;
        #endregion

        #region Edit App Fields

        #region Object[] _TempCopyPasteData
        /// <summary>
        /// اطلاعات موقت ردیف برای كپی یا انتقال
        /// </summary>
        private Object[] _TempCopyPasteData;
        #endregion

        #region Boolean _IsCopy
        /// <summary>
        /// تعیین وضعیت كپی محلی نوبت
        /// </summary>
        private Boolean _IsCopy;
        #endregion

        #endregion

        #region Boolean _IsAdvancedLicense
        /// <summary>
        /// تعیین داشتن مجوز نوبت دهی پیشرفته
        /// </summary>
        private Boolean _IsAdvancedLicense = true;
        #endregion

        #region Int16 _DefaultAppID
        /// <summary>
        /// برنامه نوبت دهی پیش فرض
        /// </summary>
        private Int16 _DefaultAppID;
        #endregion

        #region Int32? _CopyShiftTemp
        /// <summary>
        /// كلید اولین نوبت شیفتی كه می خواهد كپی شود
        /// </summary>
        private Int32? _CopyShiftTemp;
        #endregion

        #region ACL Fields
        /// <summary>
        /// تعیین امكان ویرایش نوبت سایر كاربران
        /// </summary>
        private Boolean _CanAddOrEditOtherUsersShift;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAppointments()
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            if (!FillApplicationsDataSource()) { FormClosing -= Form_Closing; Cursor.Current = Cursors.Default; Close(); return; }
            InitializeComponent();
            Controls.Remove(BarSchedules);
            dgvSchedules = new SchDataGridView();
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            ReadCurrentLockLicense();
            // برای تولید فیلدهای پویا نیاز به داشتن مجوز لایسنس پیشرفته است
            if (_IsAdvancedLicense && !dgvSchedules.GenerateAddinColumns())
            { FormClosing -= Form_Closing; Cursor = Cursors.Default; Close(); return; }
            if (!ReadFormCurrentUserSettings() || !ReadCurrentUserAccess())
            { FormClosing -= Form_Closing; Cursor.Current = Cursors.Default; return; }
            Text += " - كاربر جاری: " + Negar.DBLayerPMS.Security.UsersList.
                Where(Data => Data.ID == SecurityManager.CurrentUserID).Select(Data => Data.FullName).First();
            Controls.Add(dgvSchedules);
            dgvSchedules.Dock = DockStyle.Fill;
            Controls.Add(BarSchedules);
            #region Set Event Handlers
            dgvSchedules.FormStateChanged += dgvSchedules_FormStateChanged;
            dgvSchedules.PreviewKeyDown += dgvSchedules_PreviewKeyDown;
            dgvSchedules.SelectionChanged += dgvSchedules_SelectionChanged;
            dgvSchedules.CellMouseClick += dgvSchedules_CellMouseClick;
            #endregion
            cboApplications.DataSource = DBLayerIMS.Schedules.SchAppList.
                Where(Data => Data.IsActive == true && Data.ID != null).
                OrderBy(result => result.Name).ToList();
            cboApplications.DropDownClosed += (ComboBoxEx_DropDownClosed);
            HandleContextMenus();
            cboApplications.Focus();
            Cursor.Current = Cursors.Default;
            Opacity = 1;
        }
        #endregion

        #region cboApplications_SelectedIndexChanged
        /// <summary>
        /// روال مدیریت تغییر برنامه نوبت دهی انتخاب شده در كمبو باكس
        /// </summary>
        private void cboApplications_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboApplications.SelectedValue == null || cboApplications.DroppedDown) return;
            if (_DefaultAppID > 0) { cboApplications.SelectedValue = _DefaultAppID; _DefaultAppID = 0; }
            if (!dgvSchedules.ChangeApplication(Convert.ToInt16(cboApplications.SelectedValue), true))
            { FormClosing -= Form_Closing; Close(); return; }
        }
        #endregion

        #region ComboBoxEx_DropDownClosed
        /// <summary>
        /// این روال ، در صورت بسته شدن كمبو باكس برنامه ها بر روی جدول برنامه ها فوكوس می كند
        /// </summary>
        void ComboBoxEx_DropDownClosed(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode())
            {
                PMBox.Show("یكی از خانه های نوبت دهی در حال ویرایش است! لطفاً ابتدا ویرایش نوبت را تمام كنید!", "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1); return;
            }
            if (cboApplications.SelectedValue == null || cboApplications.DroppedDown) return;
            if (!dgvSchedules.ChangeApplication(Convert.ToInt16(cboApplications.SelectedValue), true))
            { FormClosing -= Form_Closing; Close(); return; }
            dgvSchedules.Focus();
        }
        #endregion

        #region btnSelectAppFromList_Click
        /// <summary>
        /// روالی برای باز كردن كمبوباكس برنامه های جهت انتخاب برنامه
        /// </summary>
        private void btnSelectAppFromList_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode())
            {
                PMBox.Show("یكی از خانه های نوبت دهی در حال ویرایش است! لطفاً ابتدا ویرایش نوبت را تمام كنید!", "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1); return;
            }
            cboApplications.DroppedDown = true;
            cboApplications.Focus();
        }
        #endregion

        #region btnCurrentDate_Click
        /// <summary>
        /// روال تغییر تاریخ جاری برنامه نوبت دهی
        /// </summary>
        private void btnCurrentDate_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode())
            {
                PMBox.Show("یكی از خانه های نوبت دهی در حال ویرایش است! لطفاً ابتدا ویرایش نوبت را تمام كنید!", "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1); return;
            }
            frmChangeDate MyForm = new frmChangeDate();
            if (dgvSchedules.Rows.Count != 0) MyForm.FormDatePicker.SelectedDateTime =
                    Convert.ToDateTime(dgvSchedules.Rows[0].Cells[dgvSchedules.ColOccuredDateTime.Index].Value);
            MyForm.ShowDialog();
            if (MyForm.DialogResult == DialogResult.OK)
                dgvSchedules.FillAppointments(MyForm.FormDatePicker.SelectedDateTime.Value);
            MyForm.Dispose();
        }
        #endregion

        #region btnShowProgramDetails_Click
        /// <summary>
        /// روال نمایش خلاصه تنظیمات برنامه نوبت دهی
        /// </summary>
        private void btnShowProgramDetails_Click(object sender, EventArgs e)
        {
            new frmAppsDescription(Convert.ToInt16(cboApplications.SelectedValue));
        }
        #endregion

        #region btnPrevShift_Click
        /// <summary>
        /// دكمه ی نمایش نوبت های روز قبل برای برنامه جاری
        /// </summary>
        private void btnPrevShift_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode())
            {
                PMBox.Show("یكی از خانه های نوبت دهی در حال ویرایش است! لطفاً ابتدا ویرایش نوبت را تمام كنید!", "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1); return;
            }
            Cursor.Current = Cursors.WaitCursor;
            DateTime? PrevDay = DBLayerIMS.Schedules.
                GetSchApplicationNextOrPrevDay(Convert.ToInt16(cboApplications.SelectedValue),
                dgvSchedules.CurrentShiftDate, false);
            // نوبتی برای برنامه وجود ندارد یا روز قبلی وجود ندارد
            if (PrevDay == null) { Cursor.Current = Cursors.Default; return; }
            // حالتی كه به اولین نوبت نرسیده است و می توان روز را به عقب برد
            if (dgvSchedules.CurrentShiftDate != PrevDay) dgvSchedules.FillAppointments(PrevDay.Value);
        }
        #endregion

        #region btnNextShift_Click
        /// <summary>
        /// دكمه ی نمایش نوبت های روز بعد برای برنامه جاری
        /// </summary>
        private void btnNextShift_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode())
            {
                PMBox.Show("یكی از خانه های نوبت دهی در حال ویرایش است! لطفاً ابتدا ویرایش نوبت را تمام كنید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1); return;
            }
            Cursor.Current = Cursors.WaitCursor;
            DateTime? NextDay = DBLayerIMS.Schedules.
                GetSchApplicationNextOrPrevDay(Convert.ToInt16(cboApplications.SelectedValue),
                dgvSchedules.CurrentShiftDate, true);
            // نوبتی برای برنامه وجود ندارد یا روز بعدی وجود ندارد
            if (NextDay == null) { Cursor.Current = Cursors.Default; return; }
            // حالتی كه به آخرین نوبت نرسیده است و می توان روز را به جلو برد
            if (dgvSchedules.CurrentShiftDate != NextDay) dgvSchedules.FillAppointments(NextDay.Value);
        }
        #endregion

        #region btnRefresh_Click
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode())
            {
                PMBox.Show("یكی از خانه های نوبت دهی در حال ویرایش است! لطفاً ابتدا ویرایش نوبت را تمام كنید!", "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1); return;
            }
            dgvSchedules.RefreshCurrentDay();
        }
        #endregion

        #region btnAddAppointment_Click
        /// <summary>
        /// روال افزودن نوبت جدید به یك برنامه
        /// </summary>
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode())
            {
                PMBox.Show("یكی از خانه های نوبت دهی در حال ویرایش است! لطفاً ابتدا ویرایش نوبت را تمام كنید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1); return;
            }
            DialogResult Dr = PMBox.Show("آیا مایلید به روز و برنامه نوبت دهی جاری نوبت اضافه نمایید؟\n" +
                "پس از تایید این فرمان یك نوبت به آخرین نوبت این برنامه افزوده می شود.\n" +
                "شما قادرید پس از افزودن نوبت ، آن نوبت را حذف نمایید.", "پرسش!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            SchAppointments NewApp = new SchAppointments();
            NewApp.IsActive = true;
            NewApp.ApplicationIX = Convert.ToInt16(cboApplications.SelectedValue);
            NewApp.OccuredDateTime = dgvSchedules.CurrentShiftDate;
            NewApp.IsAppointed = false;
            NewApp.OrderNo = Convert.ToInt16(Convert.ToInt16(
                dgvSchedules.Rows[dgvSchedules.Rows.GetLastRow(DataGridViewElementStates.Visible)].
                Cells[dgvSchedules.ColOrderNo.Index].Value) + 1);
            DBLayerIMS.Manager.DBML.SchAppointments.InsertOnSubmit(NewApp);
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ثبت نوبت جدید در بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvSchedules.RefreshCurrentDay();
        }
        #endregion

        #region btnCopyShiftApps_Click
        private void btnCopyShiftApps_Click(object sender, EventArgs e)
        {
            try { _CopyShiftTemp = Convert.ToInt32(dgvSchedules.Rows[0].Cells[dgvSchedules.ColID.Index].Value); }
            catch { }
        }
        #endregion

        #region btnPasteShiftApps_Click
        private void btnPasteShiftApps_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode()) return;
            if (_CopyShiftTemp == null)
            {
                PMBox.Show("شیفتی برای جایگزینی با نوبت های شیفت جاری انتخاب نشده.\n" +
                    "ابتدا شیفتی برای جایگزینی كپی نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            try
            {
                SchAppointments Apps = DBLayerIMS.Manager.DBML.SchAppointments.
                    Where(Data => Data.ID == _CopyShiftTemp.Value).First();

                #region Sure?
                DialogResult Result =
                    PMBox.Show("آیا مایلید نوبت های شیفت كپی شده را جایگزین نوبت های شیفت جاری نمایید؟\n" +
                    "اطلاعات شیفت انتخاب شده:\n" +
                    "برنامه نوبت دهی: " + Apps.SchApplications.Name + "\n" +
                    "تاریخ شیفت: " + Apps.OccuredDateTime.ToPersianDate().ToWritten() + "\n" +
                    "اطلاعات نوبت های شیفت جاری به صورت كامل حذف شده و اطلاعات شیفت كپی شده جایگزین خواهد شد.\n" +
                    "آیا از این كار اطمینان دارید؟ این فرمان قابل بازگشت نمی باشد.", "هشدار!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (Result != DialogResult.Yes) return;
                #endregion

                #region Clear Current Day Appointment
                foreach (DataGridViewRow Row in dgvSchedules.Rows)
                {
                    Int32 AppointmentID = Convert.ToInt32(Row.Cells[dgvSchedules.ColID.Index].Value);
                    // پاك كردن نوبت مبداء
                    try { DBLayerIMS.Manager.DBML.SP_ClearAppointment(AppointmentID); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage =
                            "امكان خواندن اطلاعات نوبت پایه برای جایگذاری وجود ندارد.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return;
                    }
                    #endregion
                    if (!DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 100, String.Empty, String.Empty)) continue;
                }
                #endregion

                #region Copy Copied Shift To Current Shift
                List<SchAppointments> CopiedAppointments = DBLayerIMS.Manager.DBML.SchAppointments.
                    Where(Data => Data.ApplicationIX == Apps.ApplicationIX &&
                        Data.OccuredDateTime.Date == Apps.OccuredDateTime.Date).ToList();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, CopiedAppointments);
                for (Int32 i = 0; i < dgvSchedules.Rows.Count; i++)
                {
                    Int32 AppointmentID = Convert.ToInt32(dgvSchedules.Rows[i].Cells[dgvSchedules.ColID.Index].Value);
                    if (i + 1 > CopiedAppointments.Count) break;
                    #region Save Copy Log Event
                    // تاریخ نوبت مبدأ
                    PersianDate DestinationOccuredDate = PersianDateConverter.ToPersianDate(
                        Convert.ToDateTime(CopiedAppointments[i].OccuredDateTime));
                    // شماره نوبت مبدأ
                    String DestinationOrderNo = CopiedAppointments[i].OrderNo.ToString();
                    // متن توضیحات مبدأ
                    String DestinationDescription = "جایگذاری در تاریخ : " + DestinationOccuredDate.Year + "/" +
                        DestinationOccuredDate.Month + "/" + DestinationOccuredDate.Day + "و ساعت : " +
                        DestinationOccuredDate.Hour + ":" + DestinationOccuredDate.Minute
                        + " و شماره نوبت : " + DestinationOrderNo;
                    // ثبت رخداد های سابقه نوبت مبدأ در بانك اطلاعاتی
                    DBLayerIMS.Schedules.InsertSchLogEvents(CopiedAppointments[i].ID, 106,
                        DestinationDescription, String.Empty);

                    // تاریخ نوبت مقصد
                    PersianDate PrincipleOccuredDate = PersianDateConverter.ToPersianDate(
                        Convert.ToDateTime(dgvSchedules.Rows[i].Cells[dgvSchedules.ColOccuredDateTime.Index].Value));
                    // شماره نوبت مقصد
                    String PrincipleOrderNo = dgvSchedules.Rows[i].Cells[dgvSchedules.ColOrderNo.Index].Value.ToString();
                    // متن توضیحات مقصد
                    String PrincipleDescription = "كپی برداری از تاریخ : " + PrincipleOccuredDate.Year + "/"
                        + PrincipleOccuredDate.Month + "/" + PrincipleOccuredDate.Day + "و ساعت : "
                        + PrincipleOccuredDate.Hour + ":" + PrincipleOccuredDate.Minute
                        + " و شماره نوبت : " + PrincipleOrderNo;
                    // ثبت رخداد های سابقه نوبت مقصد در بانك اطلاعاتی
                    DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 108, PrincipleDescription, String.Empty);

                    #endregion
                    String IsMale;
                    if (CopiedAppointments[i].IsMale == null) IsMale = "NULL";
                    else
                    {
                        String FieldValue;
                        Int16 Male = Convert.ToInt16(CopiedAppointments[i].IsMale.Value);
                        IsMale = Male.ToString();
                        if (Male == 0) FieldValue = "خیر";
                        else FieldValue = "بله";
                        DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 104,"مرد", FieldValue);
                    }
                    String Age;
                    if (CopiedAppointments[i].Age == null) Age = "NULL";
                    else
                    {
                        Age = Convert.ToInt16(CopiedAppointments[i].Age.Value).ToString();
                        DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 104,"سن", Age);
                    }
                    String MyCommand = String.Empty;
                    MyCommand += "UPDATE [ImagingSystem].[Schedules].[Appointments] " +
                        "SET [IsActive] = " + Convert.ToInt16(CopiedAppointments[i].IsActive) +
                        " ,[IsAppointed] = " + Convert.ToInt16(CopiedAppointments[i].IsAppointed) +
                        " ,[FirstName] = N'" + CopiedAppointments[i].FirstName + "'" +
                        " ,[LastName] = N'" + CopiedAppointments[i].LastName + "'" +
                        " ,[IsMale] = " + IsMale +
                        " ,[Age] = " + Age +
                        " ,[TelNo1] = N'" + CopiedAppointments[i].TelNo1 + "'" +
                        " ,[TelNo2] = N'" + CopiedAppointments[i].TelNo2 + "'" +
                        " ,[SchedulerIX] = " + SecurityManager.CurrentUserID +
                        " WHERE [ID] = " + dgvSchedules.Rows[i].Cells[dgvSchedules.ColID.Index].Value;

                    DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 104,"نام", CopiedAppointments[i].FirstName);
                    DBLayerIMS.Schedules.InsertSchLogEvents
                        (AppointmentID, 104,"نام خانوادگی", CopiedAppointments[i].LastName);
                    DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 104,"تلفن 1", CopiedAppointments[i].TelNo1);
                    DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 104,"تلفن 2", CopiedAppointments[i].TelNo2);

                    if (DBLayerIMS.Schedules.SchAddinColumnsList.Count != 0)
                    {
                        MyCommand += " DELETE FROM [ImagingSystem].[Schedules].[AdditionalData] " +
                            "WHERE [AppointmentIX] = " + dgvSchedules.Rows[i].Cells[dgvSchedules.ColID.Index].Value;
                        MyCommand += " INSERT INTO [ImagingSystem].[Schedules].[AdditionalData] ([AppointmentIX] , ";
                        List<SchAddinColumns> AddinFields = DBLayerIMS.Schedules.SchAddinColumnsList;
                        if (AddinFields == null) return;
                        foreach (SchAddinColumns columns in AddinFields)
                            MyCommand += "[" + columns.FieldName + "] , ";
                        MyCommand = MyCommand.Substring(0, MyCommand.Length - 3);
                        MyCommand += ") VALUES (" + dgvSchedules.Rows[i].Cells[dgvSchedules.ColID.Index].Value + " , ";
                        System.Data.DataTable TempDataTable = DBLayerIMS.Manager.ExecuteQuery(
                            "EXECUTE [Schedules].[SP_SelectSchAdditionalData] " + CopiedAppointments[i].ID, 5);
                        if (TempDataTable == null) continue;

                        #region Insert AppAdditionalCols
                        // اضافه كردن ستون های اطلاعات اضافی برنامه انتخاب شده
                        for (Int32 j = 0; j < AddinFields.Count; j++)
                        {
                            switch (AddinFields[j].TypeID)
                            {
                                #region String Fields
                                case 0: // String Fields
                                    {
                                        if (TempDataTable.Rows[0][AddinFields[j].FieldName].GetType() == typeof(DBNull))
                                            MyCommand += "NULL , ";
                                        else
                                        {
                                            MyCommand += "N'" + TempDataTable.Rows[0][AddinFields[j].FieldName] + "' , ";
                                            DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 104,
                                                AddinFields[j].Title, TempDataTable.Rows[0][AddinFields[j].FieldName].ToString());
                                        }

                                    } break;
                                #endregion

                                #region Boolean Fields
                                case 1: // Boolean Fields
                                    {
                                        if (TempDataTable.Rows[0][AddinFields[j].FieldName].GetType() == typeof(DBNull))
                                            MyCommand += "NULL , ";
                                        else
                                        {
                                            Int16 BooleanField = Convert.ToInt16(TempDataTable.Rows[0][AddinFields[j].FieldName]);
                                            String FieldValue = String.Empty;
                                            if (BooleanField == 0) FieldValue = "خیر";
                                            else FieldValue = "بله";
                                            MyCommand += BooleanField + " , ";
                                            DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 104,AddinFields[j].Title, FieldValue);

                                        }
                                    } break;
                                #endregion

                                #region Integer Fields
                                case 2: // Integer Fields
                                    {
                                        if (TempDataTable.Rows[0][AddinFields[j].FieldName].GetType() == typeof(DBNull))
                                            MyCommand += "NULL , ";
                                        else
                                        {
                                            MyCommand += TempDataTable.Rows[0][AddinFields[j].FieldName] + " , ";
                                            DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 104,
                                                AddinFields[j].Title, TempDataTable.Rows[0][AddinFields[j].FieldName].ToString());
                                        }
                                    } break;
                                #endregion

                                #region MultiChoice Fields
                                case 3: // MultiChoice Fields
                                    {
                                        if (TempDataTable.Rows[0][AddinFields[j].FieldName].GetType() == typeof(DBNull))
                                            MyCommand += "NULL , ";
                                        else
                                        {
                                            MyCommand += TempDataTable.Rows[0][AddinFields[j].FieldName] + " , ";
                                            String FieldValue = DBLayerIMS.Schedules.SchAddinDataItemsList.Where(
                                                    Data => Data.ID == Convert.ToInt16(
                                                        TempDataTable.Rows[0][AddinFields[j].FieldName])).First().Title;
                                            DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 104,
                                                AddinFields[j].Title, FieldValue);
                                        }
                                    } break;
                                #endregion
                            }
                        }
                        #endregion
                        MyCommand = MyCommand.Substring(0, MyCommand.Length - 3);
                        MyCommand += ")";
                    }
                    DBLayerIMS.Manager.ExecuteCommand(MyCommand, 0);


                }
                #endregion
                dgvSchedules.RefreshCurrentDay();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان حذف اطلاعات نوبت انتقال یافته وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
        }
        #endregion

        #region btnSearchApplications_Click
        /// <summary>
        /// روال نمایش فرم جستجوی وضعیت برنامه ها
        /// </summary>
        private void btnSearchApplications_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode())
            {
                PMBox.Show("یكی از خانه های نوبت دهی در حال ویرایش است! لطفاً ابتدا ویرایش نوبت را تمام كنید!", "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1); return;
            }
            frmAppsSearch MyForm = new frmAppsSearch();
            if (MyForm.DialogResult != DialogResult.OK) { MyForm.Dispose(); dgvSchedules.RefreshCurrentDay(); return; }
            frmAppsSearch.SearchResultData ResultData = MyForm.ReturnData;
            if (Convert.ToInt16(cboApplications.SelectedValue) != ResultData.AppID)
            {
                cboApplications.SelectedIndexChanged -= cboApplications_SelectedIndexChanged;
                cboApplications.SelectedValue = ResultData.AppID;
                cboApplications.SelectedIndexChanged += cboApplications_SelectedIndexChanged;
                dgvSchedules.ChangeApplication(ResultData.AppID, false);
            }
            dgvSchedules.FillAppointments(ResultData.Date);
            MyForm.Dispose();
        }
        #endregion

        #region btnFindPatientSchedule_Click
        /// <summary>
        /// روال مدیریت جستجوی نوبت بیمار
        /// </summary>
        private void btnFindPatientSchedule_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode())
            {
                PMBox.Show("یكی از خانه های نوبت دهی در حال ویرایش است! لطفاً ابتدا ویرایش نوبت را تمام كنید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1); return;
            }
            frmPatientShiftSearch MyForm = new frmPatientShiftSearch();
            MyForm.ShowDialog();
            if (MyForm.DialogResult != DialogResult.OK) { MyForm.Dispose(); dgvSchedules.RefreshCurrentDay(); return; }
            SchAppointments ResultData = MyForm.ReturnData;
            if (Convert.ToInt16(cboApplications.SelectedValue) != ResultData.ApplicationIX)
            {
                cboApplications.SelectedIndexChanged -= cboApplications_SelectedIndexChanged;
                cboApplications.SelectedValue = ResultData.ApplicationIX;
                cboApplications.SelectedIndexChanged += cboApplications_SelectedIndexChanged;
                dgvSchedules.ChangeApplication(ResultData.ApplicationIX, false);
            }
            dgvSchedules.IsSearching = true;
            dgvSchedules.SearchedAppointmentID = ResultData.ID;
            dgvSchedules.FillAppointments(ResultData.OccuredDateTime);
            MyForm.Dispose();
        }
        #endregion

        #region btnPrintTable_Click
        /// <summary>
        /// روال چاپ جدول برنامه های نوبت دهی
        /// </summary>
        private void btnPrintTable_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode())
            {
                PMBox.Show("یكی از خانه های نوبت دهی در حال ویرایش است! لطفاً ابتدا ویرایش نوبت را تمام كنید!", "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1); return;
            }
            new frmReportPreview(dgvSchedules);
        }
        #endregion

        #region dgvSchedules_FormStateChanged
        /// <summary>
        /// روالی برای مدیریت تغییرات شیفت جاری در جدول نوبت دهی
        /// </summary>
        private void dgvSchedules_FormStateChanged()
        {
            SetCurrentShiftData();
        }
        #endregion

        #region dgvSchedules_PreviewKeyDown
        /// <summary>
        /// روالی برای فراخوانی منوی كلیك راست
        /// </summary>
        private void dgvSchedules_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData != Keys.Apps || dgvSchedules.SelectedCells.Count == 0) return;
            HandleContextMenus();
            cmsGridView.Popup(Left + Width - 150, Top + dgvSchedules.Top + dgvSchedules.ColumnHeadersHeight +
                dgvSchedules.GetRowDisplayRectangle(dgvSchedules.SelectedCells[0].RowIndex, true).Top + 20);
        }
        #endregion

        #region dgvSchedules_CellMouseClick
        void dgvSchedules_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvSchedules.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader);
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || e.Button != MouseButtons.Right) return;
            HandleContextMenus();
            dgvSchedules[e.ColumnIndex, e.RowIndex].Selected = true;
            cmsGridView.Popup(MousePosition.X, MousePosition.Y);
        }
        #endregion

        #region dgvSchedules_SelectionChanged
        /// <summary>
        /// با به وقوع پیوستن این روال ، وضعیت منوی كلیك راست جدول تغییر می كند
        /// </summary>
        private void dgvSchedules_SelectionChanged(object sender, EventArgs e)
        {
            HandleContextMenus();
        }
        #endregion

        #region @ Context Menu Strip Event Handlers @

        #region cmsGridView_PopupOpen
        /// <summary>
        /// روال مدیریت باز شدن منوی مدیریت نوبت
        /// </summary>
        private void cmsGridView_PopupOpen(object sender, PopupOpenEventArgs e)
        {
            #region HaveVisibleItem
            Boolean HaveVisibleItem = false;
            foreach (ButtonItem item in cmsGridView.SubItems)
                if (item.Visible) HaveVisibleItem = true;
            if (!HaveVisibleItem || dgvSchedules.IsCurrentCellInEditMode) { e.Cancel = true; return; }
            #endregion
            HandleContextMenus();
        }
        #endregion

        #region btnCopy_Click
        /// <summary>
        /// روال كپی برداری از نوبت انتخاب شده
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            #region Validations
            if (dgvSchedules.CurrentCell != null && dgvSchedules.CurrentCell.ColumnIndex == dgvSchedules.ColAge.Index &&
                dgvSchedules.IsCurrentCellDirty) return;
            dgvSchedules.EndEdit();
            if (dgvSchedules.SelectedCells.Count == 0 || dgvSchedules.IsCurrentCellInEditMode) return;
            if (!(Convert.ToBoolean(
                dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColIsAppointed.Index].Value)))
            {
                PMBox.Show("نوبت جاری خالی است! اطلاعاتی برای كپی برداری در آن وجود ندارد.", "هشدار!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            _TempCopyPasteData = new Object[dgvSchedules.Columns.Count];
            for (Int32 i = 0; i < dgvSchedules.Columns.Count; i++)
                _TempCopyPasteData[i] = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[i].Value;
            _IsCopy = true;
        }
        #endregion

        #region btnCut_Click
        /// <summary>
        /// روال دكمه ی بریدن یك نوبت
        /// </summary>
        private void btnCut_Click(object sender, EventArgs e)
        {
            #region Validations
            if (dgvSchedules.CurrentCell != null && dgvSchedules.CurrentCell.ColumnIndex == dgvSchedules.ColAge.Index &&
                dgvSchedules.IsCurrentCellDirty) return;
            dgvSchedules.EndEdit();
            if (dgvSchedules.SelectedCells.Count == 0 || dgvSchedules.IsCurrentCellInEditMode) return;
            #region Can Add Or Edit Shift Other User
            if (SecurityManager.CurrentUserID > 2)
            {
                if (!_CanAddOrEditOtherUsersShift &&
                    Convert.ToBoolean(dgvSchedules[dgvSchedules.ColIsAppointed.Index,
                    dgvSchedules.SelectedCells[0].RowIndex].Value) &&
                    dgvSchedules[dgvSchedules.ColUser.Index,
                    dgvSchedules.SelectedCells[0].RowIndex].Value != null &&
                    dgvSchedules[dgvSchedules.ColUser.Index,
                    dgvSchedules.SelectedCells[0].RowIndex].Value != DBNull.Value &&
                    Convert.ToInt16(dgvSchedules[dgvSchedules.ColUser.Index,
                    dgvSchedules.SelectedCells[0].RowIndex].Value) !=
                    SecurityManager.CurrentUserID)
                {
                    PMBox.Show("امكان ویرایش نوبت های سایر كاربران را ندارید!", "هشدار!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion

            if (!CheckLockAppointment(Convert.ToInt32(dgvSchedules[dgvSchedules.ColID.Index,
                dgvSchedules.SelectedCells[0].RowIndex].Value))) return;

            if (!(Convert.ToBoolean(dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColIsAppointed.Index].Value)))
            {
                PMBox.Show("نوبت جاری خالی است! اطلاعاتی برای انتقال دادن در آن وجود ندارد.", "هشدار!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            #endregion
            _TempCopyPasteData = new Object[dgvSchedules.Columns.Count];
            for (Int32 i = 0; i < dgvSchedules.Columns.Count; i++)
                _TempCopyPasteData[i] = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[i].Value;
            _IsCopy = false;
        }
        #endregion

        #region btnPaste_Click
        /// <summary>
        /// روال مدیریت چسباندن یك ردیف نوبت
        /// </summary>
        private void btnPaste_Click(object sender, EventArgs e)
        {
            #region Validations
            if (dgvSchedules.CurrentCell != null && dgvSchedules.CurrentCell.ColumnIndex == dgvSchedules.ColAge.Index &&
                dgvSchedules.IsCurrentCellDirty || _TempCopyPasteData == null) return;
            dgvSchedules.EndEdit();
            if (dgvSchedules.SelectedCells.Count == 0 || dgvSchedules.IsCurrentCellInEditMode) return;
            Int32 CurrentRowKeyID = Convert.ToInt32(
                dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColID.Index].Value);
            if (!CheckLockAppointment(CurrentRowKeyID)) return;
            // اگر ردیف مبداء و مقصد یكی باشد از روال خارج می شود
            if (CurrentRowKeyID == Convert.ToInt32(_TempCopyPasteData[0]))
            {
                PMBox.Show("ردیف مبداء و مقصد انتخاب شده برای كپی برداری یكسان می باشند!\n" +
                    "ردیف دیگری برای جایگذاری انتخاب نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            #endregion

            Int32 OldRowKeyID = Convert.ToInt32(_TempCopyPasteData[dgvSchedules.ColID.Index]);
            if (_IsCopy)
            {
                _TempCopyPasteData[dgvSchedules.ColPatientIX.Index] = null;
                _TempCopyPasteData[dgvSchedules.ColReferralIX.Index] = null;

                #region Save Copy Log Event
                // تاریخ نوبت مبدأ
                PersianDate DestinationOccuredDate = PersianDateConverter.ToPersianDate(
                    Convert.ToDateTime(dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].
                    Cells[dgvSchedules.ColOccuredDateTime.Index].Value));
                // شماره نوبت مبدأ
                String DestinationOrderNo = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].
                    Cells[dgvSchedules.ColOrderNo.Index].Value.ToString();
                // متن توضیحات مبدأ
                String DestinationDescription = "جایگذاری در تاریخ : " + DestinationOccuredDate.Year + "/" +
                    DestinationOccuredDate.Month + "/" + DestinationOccuredDate.Day + "و ساعت : " +
                    DestinationOccuredDate.Hour + ":" + DestinationOccuredDate.Minute
                    + " و شماره نوبت : " + DestinationOrderNo;
                // ثبت رخداد های سابقه نوبت مبدأ در بانك اطلاعاتی
                DBLayerIMS.Schedules.InsertSchLogEvents(OldRowKeyID, 106, DestinationDescription, String.Empty);

                // تاریخ نوبت مقصد
                PersianDate PrincipleOccuredDate = PersianDateConverter.ToPersianDate(
                    Convert.ToDateTime(_TempCopyPasteData[dgvSchedules.ColOccuredDateTime.Index]));
                // شماره نوبت مقصد
                String PrincipleOrderNo = _TempCopyPasteData[dgvSchedules.ColOrderNo.Index].ToString();
                // متن توضیحات مقصد
                String PrincipleDescription = "كپی برداری از تاریخ : " + PrincipleOccuredDate.Year + "/"
                    + PrincipleOccuredDate.Month + "/" + PrincipleOccuredDate.Day + "و ساعت : "
                    + PrincipleOccuredDate.Hour + ":" + PrincipleOccuredDate.Minute
                    + " و شماره نوبت : " + PrincipleOrderNo;
                // ثبت رخداد های سابقه نوبت مقصد در بانك اطلاعاتی
                DBLayerIMS.Schedules.InsertSchLogEvents(CurrentRowKeyID, 108, PrincipleDescription, String.Empty);

                #endregion
            }
            if (!_IsCopy)
            {
                #region Save Move Log Event
                // كپی كردن رخداد های نوبت مبدأ در نوبت مقصد در انتقال
                try { DBLayerIMS.Manager.DBML.SP_MoveLogEvents(OldRowKeyID, CurrentRowKeyID); }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان انتقال سابقه رخداد های نوبت انتخاب شده وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return;
                }
                #endregion

                #region Principle
                // تاریخ نوبت مبدأ                
                PersianDate DestinationOccuredDate = PersianDateConverter.ToPersianDate(
                    Convert.ToDateTime(dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].
                   Cells[dgvSchedules.ColOccuredDateTime.Index].Value));
                // شماره نوبت مبدأ
                String DestinationOrderNo = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].
                    Cells[dgvSchedules.ColOrderNo.Index].Value.ToString();
                // متن توضیحات مبدأ
                String DestinationDescription = "جایگذاری در تاریخ : " + DestinationOccuredDate.Year + "/" +
                    DestinationOccuredDate.Month + "/" + DestinationOccuredDate.Day + "و ساعت : " +
                    DestinationOccuredDate.Hour + ":" + DestinationOccuredDate.Minute
                    + " و شماره نوبت : " + DestinationOrderNo;
                // ثبت رخداد های سابقه نوبت مبدأ در بانك اطلاعاتی
                if (!DBLayerIMS.Schedules.InsertSchLogEvents(OldRowKeyID, 107, DestinationDescription, String.Empty)) return;
                #endregion

                #region Destination
                // تاریخ نوبت مقصد
                PersianDate PrincipleOccuredDate = PersianDateConverter.ToPersianDate(
                    Convert.ToDateTime(_TempCopyPasteData[dgvSchedules.ColOccuredDateTime.Index]));
                // شماره نوبت مقصد
                String PrincipleOrderNo = _TempCopyPasteData[dgvSchedules.ColOrderNo.Index].ToString();
                // متن توضیحات مقصد
                String PrincipleDescription = "انتقال از تاریخ : " + PrincipleOccuredDate.Year + "/"
                    + PrincipleOccuredDate.Month + "/" + PrincipleOccuredDate.Day + "و ساعت : "
                    + PrincipleOccuredDate.Hour + ":" + PrincipleOccuredDate.Minute
                    + " و شماره نوبت : " + PrincipleOrderNo;
                // ثبت رخداد های سابقه نوبت مقصد در بانك اطلاعاتی
                if (!DBLayerIMS.Schedules.InsertSchLogEvents(CurrentRowKeyID, 109, PrincipleDescription, String.Empty)) return;
                #endregion

                #endregion

                // خالی كردن نوبت مبدأ
                try { DBLayerIMS.Manager.DBML.SP_ClearAppointment(OldRowKeyID); }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان حذف اطلاعات نوبت انتقال یافته وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return;
                }
                #endregion

                DBLayerIMS.Schedules.InsertSchLogEvents(OldRowKeyID, 100, String.Empty, String.Empty);
                _IsCopy = true;
            }
            _TempCopyPasteData[dgvSchedules.ColID.Index] = CurrentRowKeyID;
            dgvSchedules.CellValueChanged -= dgvSchedules.AppointmentDataGridView_CellValueChanged;

            dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColUser.Index].Value =
                _TempCopyPasteData[dgvSchedules.ColUser.Index];
            dgvSchedules.CellValueChanged += dgvSchedules.AppointmentDataGridView_CellValueChanged;
            // قراردادن اطلاعات نوبت كپی شده در یك سطر جدول
            try { dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].SetValues(_TempCopyPasteData); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان پر كردن نوبت انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            _TempCopyPasteData[dgvSchedules.ColID.Index] = OldRowKeyID;
            dgvSchedules.RefreshCurrentDay();
        }
        #endregion

        #region btnClear_Click
        /// <summary>
        /// لغو نوبت و تبدیل نوبت به نوبت داده نشده
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            #region Validations
            if (!dgvSchedules.CheckCurrentCellIsInEditMode()) return;
            if (dgvSchedules.SelectedCells.Count == 1)
            {
                DataGridViewRow RowData = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex];
                if (!Convert.ToBoolean(RowData.Cells[dgvSchedules.ColIsAppointed.Index].Value) ||
                    !Convert.ToBoolean(RowData.Cells[dgvSchedules.ColIsActive.Index].Value)) return;
            }
            if (!dgvSchedules.CheckCanEditOthersSchByRowID(dgvSchedules.SelectedCells[0].RowIndex)) return;
            #endregion
            List<Int32> RowIDList = new List<Int32>();
            foreach (DataGridViewCell cell in dgvSchedules.SelectedCells) RowIDList.Add(cell.RowIndex);
            RowIDList = RowIDList.Distinct().ToList();
            DialogResult Dr;
            if (RowIDList.Count == 1)
                Dr = PMBox.Show("آیا مایلید اطلاعات نوبت انتخاب شده لغو گردد؟", "هشدار!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            else Dr = PMBox.Show("آیا مایلید اطلاعات نوبت های انتخاب شده لغو گردند؟\n" +
                "تعداد نوبت های انتخاب شده: " + RowIDList.Count, "هشدار!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            foreach (Int32 RowID in RowIDList)
            {
                #region CanAddOrEditShiftOtherUser
                if (SecurityManager.CurrentUserID > 2)
                {
                    if (!_CanAddOrEditOtherUsersShift &&
                        !Convert.ToBoolean(dgvSchedules.Rows[RowID].Cells[dgvSchedules.ColIsAppointed.Index].Value) &&
                        Convert.ToInt16(dgvSchedules.Rows[RowID].Cells[dgvSchedules.ColUser.Index].Value) != SecurityManager.CurrentUserID)
                    {
                        PMBox.Show("ردیف نوبت به شماره نوبت " + dgvSchedules.Rows[RowID].Cells[dgvSchedules.ColOrderNo.Index].Value +
                            " توسط كاربر دیگری ثبت شده و شما امكان ویرایش یا لغو آن را ندارید!", "محدودیت در لغو!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }
                }
                #endregion

                #region Check Locked Rows
                if (!CheckLockAppointment(Convert.ToInt32(dgvSchedules.Rows[RowID].Cells[dgvSchedules.ColID.Index].Value)))
                    continue;
                #endregion

                #region Check InActive Rows
                if (!Convert.ToBoolean(dgvSchedules.Rows[RowID].Cells[dgvSchedules.ColIsActive.Index].Value))
                {
                    PMBox.Show("ردیف نوبت به شماره نوبت " + dgvSchedules.Rows[RowID].Cells[dgvSchedules.ColOrderNo.Index].Value +
                        " غیر فعال می باشد و امكان ویرایش یا لغو آن را ندارید!", "محدودیت در لغو!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    continue;
                }
                #endregion

                #region @ Clear Base Row @
                // پاك كردن نوبت مبداء
                try
                {
                    Int32 SchID = Convert.ToInt32(dgvSchedules.Rows[RowID].Cells[dgvSchedules.ColID.Index].Value);
                    DBLayerIMS.Manager.DBML.SP_ClearAppointment(SchID);
                    DBLayerIMS.Schedules.InsertSchLogEvents(SchID, 100, String.Empty, String.Empty);
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان خواندن اطلاعات نوبت پایه برای جایگذاری وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return;
                }
                #endregion
                #endregion
            }
            dgvSchedules.RefreshCurrentDay();
        }
        #endregion

        #region btnRemoveAppointment_Click
        /// <summary>
        /// روال حذف یك نوبت از بانك
        /// </summary>
        private void btnRemoveAppointment_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex];
            Int32 AppointmentID = Convert.ToInt32(Row.Cells[dgvSchedules.ColID.Index].Value);
            if (!dgvSchedules.CheckCurrentCellIsInEditMode()) return;
            if (!CheckLockAppointment(AppointmentID)) return;
            DialogResult Dr = PMBox.Show("آیا مایلید نوبت مورد نظر به طور كامل از لیست روز حذف گردد؟", "هشدار!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            try { DBLayerIMS.Manager.DBML.SP_DeleteAppointment(AppointmentID); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "خطا در حذف نوبت انتخاب شده از بانك اطلاعات.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                Close();
                return;
            }
            #endregion
            dgvSchedules.RefreshCurrentDay();
        }
        #endregion

        #region btnEdit_Click
        /// <summary>
        /// تابع ویرایش یك نوبت در فرم جدید
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedCells.Count == 0) return;
            dgvSchedules.EditAppointment(dgvSchedules.SelectedCells[0].RowIndex);
        }
        #endregion

        #region btnAppointmentLog_Click
        /// <summary>
        /// تابع مشاهده سابقه یك نوبت در فرم جدید
        /// </summary>
        private void btnAppointmentLog_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedCells.Count == 0) return;
            dgvSchedules.ViewAppointmentLog(dgvSchedules.SelectedCells[0].RowIndex);
        }
        #endregion

        #region btnIsActive_Click
        /// <summary>
        /// این دكمه فعال بودن یا نبودن ردیف را تغییر می دهد
        /// </summary>
        private void btnIsActive_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedCells.Count == 0) return;
            dgvSchedules.ChangeAppointmentRowActivationAccess(dgvSchedules.SelectedCells[0].RowIndex);
            HandleContextMenus();
        }
        #endregion

        #region btnFreeAppointment_Click
        /// <summary>
        /// روالی برای آزاد كردن نوبت قفل شده
        /// </summary>
        private void btnFreeAppointment_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedCells.Count == 0 || !dgvSchedules.CheckCurrentCellIsInEditMode()) return;
            dgvSchedules.FreeLockedAppointmentByRowID(dgvSchedules.SelectedCells[0].RowIndex);
        }
        #endregion

        #region btnAdmitAsNewRef_Click
        /// <summary>
        /// روال پذیرش مراجعه بیمار جدید بر اساس نوبت انتخاب شده
        /// </summary>
        private void btnAdmitAsNewRef_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode()) return;
            DataGridViewRow CurrentRow = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex];
            Int32 SchID = Convert.ToInt32(CurrentRow.Cells[dgvSchedules.ColID.Index].Value);
            Int32? PatientID = null;
            if (CurrentRow.Cells[dgvSchedules.ColPatientIX.Index].Value != null &&
                CurrentRow.Cells[dgvSchedules.ColPatientIX.Index].Value != DBNull.Value)
                PatientID = Convert.ToInt32(CurrentRow.Cells[dgvSchedules.ColPatientIX.Index].Value);
            if (PatientID == null) AdmitHelper.AdmitPatWithRef(SchID);
            else AdmitHelper.AdmitNewRef(PatientID.Value, SchID);
            dgvSchedules.RefreshCurrentDay();
        }
        #endregion

        #region btnSelectPat_Click
        private void btnSelectPat_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode()) return;
            frmPatientSearch MyForm = new frmPatientSearch(true);
            MyForm.ShowDialog();
            if (MyForm.DialogResult != DialogResult.OK) { MyForm.Dispose(); dgvSchedules.RefreshCurrentDay(); return; }
            DataGridViewRow CurrentRow = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex];
            if (MyForm.dgvPatList.CurrentRow == null) return;
            Int32 PID = ((DBLayerIMS.PatientSearcher.PatientData)
                MyForm.dgvPatList.CurrentRow.DataBoundItem).PatientListID;
            MyForm.Dispose();
            CurrentRow.Cells[dgvSchedules.ColPatientIX.Index].Value = PID;
            PatList PatData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(PID);
            if (PatData == null) return;
            CurrentRow.Cells[dgvSchedules.ColFirstName.Index].Value = PatData.FirstName;
            CurrentRow.Cells[dgvSchedules.ColLastName.Index].Value = PatData.LastName;
            CurrentRow.Cells[dgvSchedules.ColSex.Index].Value = PatData.IsMale;
            if (PatData.BirthDate != null) CurrentRow.Cells[dgvSchedules.ColAge.Index].Value =
                DateTime.Now.Year - PatData.BirthDate.Value.Year;
            if (PatData.PatDetail != null)
            {
                CurrentRow.Cells[dgvSchedules.ColTel1.Index].Value = PatData.PatDetail.TelNo1;
                CurrentRow.Cells[dgvSchedules.ColTel2.Index].Value = PatData.PatDetail.TelNo2;
            }
            dgvSchedules.RefreshCurrentDay();
        }
        #endregion

        #region btnSelectRef_Click
        private void btnSelectRef_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode()) return;
            frmPatientSearch MyForm;
            #region No Patient Is Connected
            if (dgvSchedules[dgvSchedules.ColPatientIX.Index, dgvSchedules.SelectedCells[0].RowIndex].Value == DBNull.Value)
            {
                MyForm = new frmPatientSearch(false);
                MyForm.ShowDialog();
                if (MyForm.DialogResult != DialogResult.OK) return;
                Int32 PID = ((DBLayerIMS.PatientSearcher.PatientData)
                    MyForm.dgvPatList.SelectedRows[0].DataBoundItem).PatientListID;
                Int32 RefID = ((RefList)MyForm.dgvRefList.SelectedRows[0].DataBoundItem).ID;
                #region Check If Ref Saved On Other Shift
                // بررسی ثبت بودن مراجعه انتخاب شده برای نوبت دیگر
                List<SchAppointments> OtherRefID;
                try
                {
                    IQueryable<SchAppointments> TempData =
                        DBLayerIMS.Manager.DBML.SchAppointments.Where(Data => Data.ReferralIX == RefID);
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                    OtherRefID = TempData.ToList();
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان خواندن اطلاعات سایر نوبت ها از بانك وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error); return;
                }
                #endregion

                if (OtherRefID.Count != 0)
                {
                    PersianDate PDate = OtherRefID.First().OccuredDateTime.ToPersianDate();
                    PMBox.Show("مراجعه انتخاب شده قبلاً در نوبت \"" + OtherRefID.First().OrderNo +
                        "\" در برنامه نوبت دهی \"" + OtherRefID.First().SchApplications.Name + "\" در تاریخ \"" +
                        PDate.Year + "/" + PDate.Month + "/" + PDate.Day + "\" ثبت شده است."); return;
                }
                #endregion
                DataGridViewRow CurrentRow = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex];
                MyForm.Dispose();
                CurrentRow.Cells[dgvSchedules.ColPatientIX.Index].Value = PID;
                PatList PatData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(PID);
                if (PatData == null) return;
                CurrentRow.Cells[dgvSchedules.ColFirstName.Index].Value = PatData.FirstName;
                CurrentRow.Cells[dgvSchedules.ColLastName.Index].Value = PatData.LastName;
                CurrentRow.Cells[dgvSchedules.ColSex.Index].Value = PatData.IsMale;
                if (PatData.BirthDate != null) CurrentRow.Cells[dgvSchedules.ColAge.Index].Value =
                    DateTime.Now.Year - PatData.BirthDate.Value.Year;
                if (PatData.PatDetail != null)
                {
                    CurrentRow.Cells[dgvSchedules.ColTel1.Index].Value = PatData.PatDetail.TelNo1;
                    CurrentRow.Cells[dgvSchedules.ColTel2.Index].Value = PatData.PatDetail.TelNo2;
                }
                dgvSchedules[dgvSchedules.ColReferralIX.Index, dgvSchedules.SelectedCells[0].RowIndex].Value = RefID;
                dgvSchedules.RefreshCurrentDay();
            }
            #endregion

            #region A Patient Is Connected
            else
            {
                Int32 PID =
                    Convert.ToInt32(dgvSchedules[dgvSchedules.ColPatientIX.Index, dgvSchedules.SelectedCells[0].RowIndex].Value);
                MyForm = new frmPatientSearch(PID);
                MyForm.ShowDialog();
                if (MyForm.DialogResult != DialogResult.OK) return;
                Int32 RefID = ((RefList)MyForm.dgvRefList.SelectedRows[0].DataBoundItem).ID;
                #region Check If Ref Saved On Other Shift
                List<SchAppointments> OtherRefID;
                try
                {
                    IQueryable<SchAppointments> TempData =
                        DBLayerIMS.Manager.DBML.SchAppointments.Where(Data => Data.ReferralIX == RefID);
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                    OtherRefID = TempData.ToList();
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان خواندن اطلاعات سایر نوبت ها از بانك وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error); return;
                }
                #endregion
                if (OtherRefID.Count != 0)
                {
                    PersianDate PDate = OtherRefID.First().OccuredDateTime.ToPersianDate();
                    PMBox.Show("مراجعه انتخاب شده قبلاً در نوبت " + OtherRefID.First().OrderNo +
                        " در برنامه نوبت دهی \"" + OtherRefID.First().SchApplications.Name + "\" در تاریخ \"" +
                        PDate.Year + "/" + PDate.Month + "/" + PDate.Day + "\" ثبت شده است.");
                    return;
                }
                #endregion
                dgvSchedules[dgvSchedules.ColReferralIX.Index, dgvSchedules.SelectedCells[0].RowIndex].Value = RefID;
            }
            #endregion
            if (!MyForm.IsDisposed) MyForm.Dispose();
            dgvSchedules.RefreshCurrentDay();
        }
        #endregion

        #region btnViewPatData_Click
        /// <summary>
        /// روالی برای نمایش پرونده بیماری كه با نوبت انتخاب شده مرتبط است
        /// </summary>
        private void btnViewPatData_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode() || dgvSchedules.SelectedCells.Count == 0) return;
            Object PatientID = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].
                Cells[dgvSchedules.ColPatientIX.Index].Value;
            if (PatientID == DBNull.Value) return;
            AdmitHelper.EditPatient(Convert.ToInt32(PatientID), false);
            dgvSchedules.RefreshCurrentDay();
        }
        #endregion

        #region btnViewRefData_Click
        private void btnViewRefData_Click(object sender, EventArgs e)
        {
            if (!dgvSchedules.CheckCurrentCellIsInEditMode() || dgvSchedules.SelectedCells.Count == 0) return;
            Object RefID = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].
                Cells[dgvSchedules.ColReferralIX.Index].Value;
            if (RefID == DBNull.Value) return;
            AdmitHelper.EditPatientRef(Convert.ToInt32(RefID));
            dgvSchedules.RefreshCurrentDay();
        }
        #endregion

        #region btnSearchPatientName_Click
        private void btnSearchPatientName_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.CurrentCell != null && dgvSchedules.CurrentCell.ColumnIndex == dgvSchedules.ColAge.Index &&
                dgvSchedules.IsCurrentCellDirty) return;
            dgvSchedules.EndEdit();
            if (dgvSchedules.SelectedCells.Count == 0 || dgvSchedules.IsCurrentCellInEditMode) return;
            frmPatientShiftSearch MyForm = new frmPatientShiftSearch();
            if (!MyForm.IsDisposed)
            {
                // --------------------------
                String FName = String.Empty;
                if (dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColFirstName.Index].Value != null &&
                    dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColFirstName.Index].Value != DBNull.Value)
                    FName = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColFirstName.Index].Value.ToString();
                MyForm.txtFirstName.Text = FName;
                // --------------------------
                String LName = String.Empty;
                if (dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColLastName.Index].Value != null &&
                    dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColLastName.Index].Value != DBNull.Value)
                    LName = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColLastName.Index].Value.ToString();
                MyForm.txtLastName.Text = LName;
                // --------------------------
                Int32? Age = null;
                if (dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColAge.Index].Value != null &&
                    dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColAge.Index].Value != DBNull.Value)
                    Age = Convert.ToInt32(
                        dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColAge.Index].Value);
                if (Age != null) MyForm.txtAge.Value = Age.Value;
                // --------------------------
                String Tel1 = String.Empty;
                if (dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColTel1.Index].Value != null &&
                    dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColTel1.Index].Value != DBNull.Value)
                    Tel1 = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColTel1.Index].Value.ToString();
                MyForm.txtTel.Text = Tel1;
                // --------------------------
                MyForm.ShowDialog();
            }
            if (MyForm.DialogResult == DialogResult.OK)
            {
                SchAppointments ResultData = MyForm.ReturnData;
                Int16 AppID = ResultData.ApplicationIX;
                if (Convert.ToInt16(cboApplications.SelectedValue) != AppID)
                {
                    cboApplications.SelectedIndexChanged -= cboApplications_SelectedIndexChanged;
                    cboApplications.SelectedValue = AppID;
                    cboApplications.SelectedIndexChanged += cboApplications_SelectedIndexChanged;
                    lblDescription.Text = DBLayerIMS.Schedules.SchAppList.Where(Data => Data.ID == AppID).First().Description;
                    #region Change Addin Columns Visibilities
                    // اگر لایسنس پیشرفته باشد و ستون اطلاعاتی اضافی در جدول وجود داشته باشد
                    if (_IsAdvancedLicense && dgvSchedules.ColUser.Index + 1 != dgvSchedules.Columns.Count)
                    {
                        List<SchAddinColsAppCover> AppAdditionalCols =
                            DBLayerIMS.Schedules.SchAddinColsAppCover.Where(Data => Data.ApplicationIX == AppID).ToList();
                        for (Int32 i = dgvSchedules.Columns.Count - 1; i != dgvSchedules.ColUser.Index; i--)
                        {
                            List<SchAddinColsAppCover> AddinFields = AppAdditionalCols.
                                // ReSharper disable AccessToModifiedClosure
                                Where(Data => Data.SchAddinColumns.FieldName == dgvSchedules.Columns[i].Name).ToList();
                            // ReSharper restore AccessToModifiedClosure
                            if (AddinFields.Count == 0) dgvSchedules.Columns[i].Visible = false;
                            else dgvSchedules.Columns[i].Visible = true;
                        }
                    }
                    #endregion
                }
                dgvSchedules.IsSearching = true;
                dgvSchedules.SearchedAppointmentID = ResultData.ID;
                dgvSchedules.FillAppointments(ResultData.OccuredDateTime);
            }
            MyForm.Dispose();
        }
        #endregion

        #endregion

        #region btnHelp_Click
        /// <summary>
        /// روال نمایش راهنمایی برای فرم
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (dgvSchedules.IsCurrentCellInEditMode && dgvSchedules.IsCurrentCellDirty)
            { dgvSchedules.CancelEdit(); e.Cancel = true; return; }
            if (dgvSchedules.IsCurrentCellInEditMode && !dgvSchedules.IsCurrentCellDirty)
            {
                cboApplications.Focus();
                cboApplications.Select();
                dgvSchedules.CancelEdit();
                try
                {
                    DBLayerIMS.Manager.DBML.SP_ChangeLockAppointments(Convert.ToInt32(dgvSchedules.
                        Rows[dgvSchedules.SelectedCells[0].RowIndex].Cells[dgvSchedules.ColID.Index].Value), false);
                }
                #region Catch

                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان ذخیره سازی تغییرات در نوبت انتخاب شده وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                }

                #endregion            }
            }
            Cursor.Current = Cursors.Default;
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

            #region cboApplications
            TooltipText = ToolTipManager.GetText("cboSchPrograms", "IMS");
            FormToolTip.SetSuperTooltip(cboApplications, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPrevShift
            TooltipText = ToolTipManager.GetText("btnSchPrevShift", "IMS");
            FormToolTip.SetSuperTooltip(btnPrevShift, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnNextShift
            TooltipText = ToolTipManager.GetText("btnSchNextShift", "IMS");
            FormToolTip.SetSuperTooltip(btnNextShift, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnNextShift
            TooltipText = ToolTipManager.GetText("lblSchCurrentDate", "IMS");
            FormToolTip.SetSuperTooltip(btnCurrentDate, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSearchFreeSchedule
            TooltipText = ToolTipManager.GetText("btnSchSearchFreeSchedule", "IMS");
            FormToolTip.SetSuperTooltip(btnSearchApplications, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnShowProgramDetails
            TooltipText = ToolTipManager.GetText("btnSchShowProgramDetails", "IMS");
            FormToolTip.SetSuperTooltip(btnAppDetail, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAddAppointment
            TooltipText = ToolTipManager.GetText("btnSchAddAppointment", "IMS");
            FormToolTip.SetSuperTooltip(btnAddAppointment, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnFindPatientSchedule
            TooltipText = ToolTipManager.GetText("btnSchFindPatientSchedule", "IMS");
            FormToolTip.SetSuperTooltip(btnFindPatientSchedule, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPrintTable
            TooltipText = ToolTipManager.GetText("btnPrint", "IMS");
            FormToolTip.SetSuperTooltip(btnPrintTable, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region void ReadCurrentLockLicense()
        /// <summary>
        /// تابعی برای خواندن لایسنس های قفل جاری و اعمال آن به كنترل های فرم
        /// </summary>
        private void ReadCurrentLockLicense()
        {
            if (SecurityManager.CurrentUserID < 3) return;
            // مجوز نوبت دهی پیشرفته
            if (!LicenseHelper.GetSavedLicenses().Contains("515"))
            {
                if (cmsGridView.SubItems.Contains(btnPatFileManage)) cmsGridView.SubItems.Remove(btnPatFileManage);
                if (BarSchedules.Controls.Contains(btnAddAppointment)) BarSchedules.Controls.Remove(btnAddAppointment);
                if (cmsGridView.SubItems.Contains(btnRemove)) cmsGridView.SubItems.Remove(btnRemove);
                if (PanelApplications.Controls.Contains(btnAppDetail)) PanelApplications.Controls.Remove(btnAppDetail);
                if (cmsGridView.SubItems.Contains(btnFreeAppointment)) cmsGridView.SubItems.Remove(btnFreeAppointment);
                if (BarSchedules.Controls.Contains(btnCopyShiftApps)) BarSchedules.Controls.Remove(btnCopyShiftApps);
                if (BarSchedules.Controls.Contains(btnPasteShiftApps)) BarSchedules.Controls.Remove(btnPasteShiftApps);
                _IsAdvancedLicense = false;
                dgvSchedules._IsAdvancedLicense = false;
            }
            // مجوز پذیرش پیشرفته
            else if (!LicenseHelper.GetSavedLicenses().Contains("525"))
                if (cmsGridView.SubItems.Contains(btnPatFileManage)) cmsGridView.SubItems.Remove(btnPatFileManage);
        }
        #endregion

        #region Boolean ReadFormCurrentUserSettings()
        /// <summary>
        /// تابع خواندن تنظیمات كاربر جاری
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean ReadFormCurrentUserSettings()
        {
            #region 201 - Default Application
            // 201: كلید برنامه نوبت دهی پیش فرض
            List<UsersSetting> Setting201 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 201).ToList();
            if (Setting201.Count != 0 && !String.IsNullOrEmpty(Setting201.First().Value) &&
                // اینجا بررسی می گردد كه برنامه ی نوبت دهی انتخاب شده هنوز وجود دارد و فعال است یا خیر
                DBLayerIMS.Schedules.SchAppList.Exists(Data => Data.ID == Convert.ToInt16(Setting201.First().Value)))
                _DefaultAppID = Convert.ToInt16(Setting201.First().Value);
            #endregion

            #region 202 - Base Columns Visibilities
            // 202: لیست ستون های نمایش داده شده جدول نوبت دهی
            List<UsersSetting> Setting202 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 202).ToList();
            if (Setting202.Count != 0 && !String.IsNullOrEmpty(Setting202.First().Value))
            {
                if (Setting202.First().Value.Substring(0, 1) == "0") dgvSchedules.ColSex.Visible = false;
                if (Setting202.First().Value.Substring(1, 1) == "0") dgvSchedules.ColAge.Visible = false;
                if (Setting202.First().Value.Substring(2, 1) == "0") dgvSchedules.ColTel1.Visible = false;
                if (Setting202.First().Value.Substring(3, 1) == "0") dgvSchedules.ColTel2.Visible = false;
                if (Setting202.First().Value.Substring(4, 1) == "0") dgvSchedules.ColUser.Visible = false;
                if (Setting202.First().Value.Substring(5, 1) == "0") dgvSchedules.ColDateTime.Visible = false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean ReadCurrentUserAccess()
        /// <summary>
        /// تابع خواندن اطلاعات سطوح دسترسی كاربر
        /// </summary>
        /// <returns>صحت اعمال تنظیمات</returns>
        private Boolean ReadCurrentUserAccess()
        {
            if (SecurityManager.CurrentUserID < 3) return true;

            #region Add Or Edit Appoinment - 50201 - 502011
            // امكان افزودن یا ویرایش نوبت 
            if (SecurityManager.GetCurrentUserPermission(50201) == false)
            {
                dgvSchedules.ReadOnly = true;
                cmsGridView.SubItems.Remove(btnCut);
                cmsGridView.SubItems.Remove(btnCopy);
                cmsGridView.SubItems.Remove(btnPaste);
                cmsGridView.SubItems.Remove(btnClear);
                cmsGridView.SubItems.Remove(btnEdit);
            }
            else
            {
                // امكان ویرایش نوبت های ثبت شده توسط سایر كاربران 
                if (SecurityManager.GetCurrentUserPermission(502011) == false) _CanAddOrEditOtherUsersShift = false;
                else _CanAddOrEditOtherUsersShift = true;
                dgvSchedules._CanAddOrEditOtherUsersShift = _CanAddOrEditOtherUsersShift;

            }
            #endregion

            #region Can Change Activation - 50202
            // امكان غیر فعال كردن نوبت
            if (SecurityManager.GetCurrentUserPermission(50202) == false)
                cmsGridView.SubItems.Remove(btnIsActive);
            #endregion

            #region Admit Appoinment - 50203
            // امكان پذیرش نوبت
            if (SecurityManager.GetCurrentUserPermission(50203) == false)
            {
                if (cmsGridView.SubItems.Contains(btnPatFileManage)) cmsGridView.SubItems.Remove(btnPatFileManage);
            }
            #endregion

            #region Add Appointment - 50204
            // امكان افزودن ردیف نوبت جدید
            if (SecurityManager.GetCurrentUserPermission(50204) == false)
                if (BarSchedules.Controls.Contains(btnAddAppointment))
                    BarSchedules.Controls.Remove(btnAddAppointment);
            #endregion

            #region Remove Appoinment - 50205
            // امكان حذف ردیف نوبت
            if (SecurityManager.GetCurrentUserPermission(50205) == false)
            {
                if (cmsGridView.SubItems.Contains(btnRemove)) cmsGridView.SubItems.Remove(btnRemove);
            }
            #endregion

            #region Free Locked Appoinment - 50206
            // امكان آزادسازی نوبت ها
            if (SecurityManager.GetCurrentUserPermission(50206) == false)
                if (cmsGridView.SubItems.Contains(btnFreeAppointment)) cmsGridView.SubItems.Remove(btnFreeAppointment);
            #endregion

            #region Copy Appointment Shift - 50207
            // امكان كپی برداری شیفت نوبت به شیفت دیگر
            if (SecurityManager.GetCurrentUserPermission(50207) == false)
            {
                if (BarSchedules.Controls.Contains(btnCopyShiftApps))
                    BarSchedules.Controls.Remove(btnCopyShiftApps);
                if (BarSchedules.Controls.Contains(btnPasteShiftApps))
                    BarSchedules.Controls.Remove(btnPasteShiftApps);
            }
            #endregion

            #region View Appointment Log - 50208
            // امكان مشاهده سابقه نوبت های ثبت شده
            if (SecurityManager.GetCurrentUserPermission(50208) == false)
                if (cmsGridView.SubItems.Contains(btnAppointmentLog)) cmsGridView.SubItems.Remove(btnAppointmentLog);
            //    _CanVisitAppointmentLog = false;
            //else _CanVisitAppointmentLog = true;
            //dgvSchedules._CanVisitAppointmentLog = _CanVisitAppointmentLog;
            #endregion

            return true;
        }
        #endregion

        #region void HandleContextMenus()
        /// <summary>
        /// تابع مدیریت رفتار دكمه های كلیك راست جدول
        /// </summary>
        private void HandleContextMenus()
        {
            if (dgvSchedules.Rows.Count == 0 || dgvSchedules.SelectedCells.Count == 0) { cmsGridView.Visible = false; return; }
            // قابل دیدن كردن كلیه كنترل های نوبت دهی
            foreach (ButtonItem btn in cmsGridView.SubItems) btn.Visible = true;
            // كپی برداری یك نمونه از نوبت انتخاب شده
            DataGridViewRow RowData = dgvSchedules.Rows[dgvSchedules.SelectedCells[0].RowIndex];

            #region Handle Activation
            if (Convert.ToBoolean(RowData.Cells[dgvSchedules.ColIsActive.Index].Value))
            {
                btnCut.Visible = true;
                btnCopy.Visible = true;
                if (_TempCopyPasteData == null) btnPaste.Visible = false;
                else btnPaste.Visible = true;
                // +++++++++++++++
                btnClear.Visible = true;
                btnIsActive.Text = "<b>غیر فعال كردن</b><div></div>وضعیت جاری: فعال.";
                btnEdit.Visible = true;
                btnFreeAppointment.Visible = true;
                // +++++++++++++++
                btnPatFileManage.Visible = true;
                // +++++++++++++++
                btnSearchPatientName.Visible = true;
                btnRemove.Visible = true;
            }
            else
            {
                btnCut.Visible = false;
                btnCopy.Visible = false;
                btnPaste.Visible = false;
                // +++++++++++++++
                btnClear.Visible = false;
                btnIsActive.Text = "<b>فعال كردن</b><div></div>وضعیت جاری: غیر فعال.";
                btnEdit.Visible = false;
                btnFreeAppointment.Visible = false;
                // +++++++++++++++
                btnPatFileManage.Visible = false;
                // +++++++++++++++
                btnSearchPatientName.Visible = false;
                btnRemove.Visible = false;
                return;
            }
            #endregion

            #region Handle Appointing
            if (Convert.ToBoolean(RowData.Cells[dgvSchedules.ColIsAppointed.Index].Value))
            {
                btnCut.Visible = true;
                btnCopy.Visible = true;
                if (_TempCopyPasteData == null) btnPaste.Visible = false;
                else btnPaste.Visible = true;
                // +++++++++++++++
                btnClear.Visible = true;
                btnEdit.Visible = true;
                // +++++++++++++++
                btnPatFileManage.Visible = true;
                // اگر نوبت با یك مراجعه در ارتباط نباشد
                if (RowData.Cells[dgvSchedules.ColReferralIX.Index].Value == null ||
                    RowData.Cells[dgvSchedules.ColReferralIX.Index].Value == DBNull.Value)
                {
                    btnAdmitNewRef.Visible = true;
                    btnViewRefData.Visible = false;
                    // اگر نوبت با بیمار در ارتباط نباشد
                    if (RowData.Cells[dgvSchedules.ColPatientIX.Index].Value == null ||
                        RowData.Cells[dgvSchedules.ColPatientIX.Index].Value == DBNull.Value)
                        btnViewPatData.Visible = false;
                    else btnViewPatData.Visible = true;
                }
                // اگر نوبت با یك مراجعه در ارتباط باشد
                else
                {
                    btnAdmitNewRef.Visible = false;
                    btnViewPatData.Visible = true;
                    btnViewRefData.Visible = true;
                }
                btnSelectPat.Visible = false;
                btnSelectRef.Visible = false;
                // +++++++++++++++
                btnSearchPatientName.Visible = true;
            }
            else
            {
                btnCut.Visible = false;
                btnCopy.Visible = false;
                if (_TempCopyPasteData == null) btnPaste.Visible = false;
                else btnPaste.Visible = true;
                // +++++++++++++++
                btnClear.Visible = false;
                btnEdit.Visible = true;
                // +++++++++++++++
                btnPatFileManage.Visible = true;
                // وقتی نوبت خالی است ، امكان پذیرش نوبت وجود ندارد
                btnAdmitNewRef.Visible = false;
                btnSelectPat.Visible = true;
                btnSelectRef.Visible = true;
                btnViewPatData.Visible = false;
                btnViewRefData.Visible = false;
                // +++++++++++++++
                btnSearchPatientName.Visible = false;
            }
            #endregion
        }
        #endregion

        #region Boolean FillApplicationsDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات برنامه های تعریف شده
        /// </summary>
        private static Boolean FillApplicationsDataSource()
        {
            if (DBLayerIMS.Schedules.SchAppList == null) return false;
            if (DBLayerIMS.Schedules.SchAppList.Where(Data => Data.IsActive == true && Data.ID != null).Count() == 0)
            {
                PMBox.Show("برنامه نوبت دهی برای مدیریت وجود ندارد یا فعال نیست!\n" +
                    "ابتدا یك برنامه نوبت دهی تعریف نمایید.", "عدم دسترسی به برنامه نوبت دهی!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop); return false;
            }
            return true;
        }
        #endregion

        #region Boolean CheckLockAppointment(Int32 AppointmentID)
        /// <summary>
        /// تابع بررسی قفل بودن یك ردیف نوبت
        /// </summary>
        /// <param name="AppointmentID">كلید نوبت</param>
        /// <returns>قفل بودن یا آزاد بودن نوبت</returns>
        private Boolean CheckLockAppointment(Int32 AppointmentID)
        {
            if (!_IsAdvancedLicense) return true;
            return DBLayerIMS.Schedules.CheckLockAppointment(AppointmentID);
        }
        #endregion

        #region void SetCurrentShiftData()
        /// <summary>
        /// تابع نمایش اطلاعات شیفت جاری محاسبه مجدد وضعیت نوبت های یك برنامه
        /// </summary>
        private void SetCurrentShiftData()
        {
            lblDescription.Text = DBLayerIMS.Schedules.SchAppList.
                Where(Data => Data.ID == Convert.ToInt32(cboApplications.SelectedValue)).First().Description;
            PersianDate CurrentShiftPDate = dgvSchedules.CurrentShiftDate.ToPersianDate();
            btnCurrentDate.Text = CurrentShiftPDate.Year + "/" + CurrentShiftPDate.Month + "/" + CurrentShiftPDate.Day;
            switch (CurrentShiftPDate.DayOfWeek)
            {
                case PersianDayOfWeek.Saturday: lblCurrentDayOfWeek.Text = "شنبه"; break;
                case PersianDayOfWeek.Sunday: lblCurrentDayOfWeek.Text = "یكشنبه"; break;
                case PersianDayOfWeek.Monday: lblCurrentDayOfWeek.Text = "دوشنبه"; break;
                case PersianDayOfWeek.Tuesday: lblCurrentDayOfWeek.Text = "سه شنبه"; break;
                case PersianDayOfWeek.Wednesday: lblCurrentDayOfWeek.Text = "چهارشنبه"; break;
                case PersianDayOfWeek.Thursday: lblCurrentDayOfWeek.Text = "پنج شنبه"; break;
                case PersianDayOfWeek.Friday: lblCurrentDayOfWeek.Text = "جمعه"; break;
            }
            lblCurrentAppShiftCount.Text = "نوبت ها: " + dgvSchedules.Rows.Count;
            Int32 UsedSchCount = 0;
            foreach (DataGridViewRow row in dgvSchedules.Rows)
                if (Convert.ToBoolean(row.Cells[dgvSchedules.ColIsAppointed.Index].Value) ||
                    !Convert.ToBoolean(row.Cells[dgvSchedules.ColIsActive.Index].Value))
                    UsedSchCount++;
            lblCurrentAppUsedShifts.Text = "اشغال: " + UsedSchCount;
        }
        #endregion

        #endregion

    }
}