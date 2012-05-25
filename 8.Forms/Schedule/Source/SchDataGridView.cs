#region using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS;
using Negar.PersianCalendar.Utilities;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Schedules
{
    /// <summary>
    /// كلاس جدول مدیریت نوبت های برنامه های نوبت دهی
    /// </summary>
    internal class SchDataGridView : DataGridView
    {

        #region Events

        #region delegate void StateChangedDelegate()
        /// <summary>
        /// نماینده تابع مدیریت كننده دستگیره رخداد تغییر حالت فرم نوبت دهی
        /// </summary>
        public delegate void StateChangedDelegate();
        #endregion

        #region event StateChangedDelegate FormStateChanged
        /// <summary>
        /// رخدادی برای مدیریت تغییر در فرم نوبت دهی
        /// </summary>
        public event StateChangedDelegate FormStateChanged;
        #endregion

        #region delegate void FillDataInGridMethodDelegate()
        /// <summary>
        /// نماینده ای برای تابع ثبت داده ها در جدول نوبت دهی
        /// </summary>
        private delegate void FillDataInGridMethodDelegate();
        #endregion

        #endregion

        #region Fields

        #region BackgroundWorker BGWorkerLoadData
        /// <summary>
        /// شیء مدیریت خواندن اطلاعات در ریسمان موازی
        /// </summary>
        private BackgroundWorker BGWorkerLoadData;
        #endregion

        #region DataGridView Columns Fields
        /// <summary>
        /// اشیاء ستون های جدول 
        /// </summary>
        internal DataGridViewTextBoxColumn ColAge;
        internal DataGridViewTextBoxColumn ColApplicationIX;
        internal DataGridViewTextBoxColumn ColFirstName;
        internal DataGridViewTextBoxColumn ColID;
        internal DataGridViewTextBoxColumn ColIsActive;
        internal DataGridViewTextBoxColumn ColIsAppointed;
        internal DataGridViewTextBoxColumn ColLastName;
        internal DataGridViewTextBoxColumn ColOccuredDateTime;
        internal DataGridViewTextBoxColumn ColOrderNo;
        internal DataGridViewTextBoxColumn ColPatientIX;
        internal DataGridViewTextBoxColumn ColReferralIX;
        internal DataGridViewCheckBoxColumn ColSex;
        internal DataGridViewTextBoxColumn ColTel1;
        internal DataGridViewTextBoxColumn ColTel2;
        internal DataGridViewTextBoxColumn ColUser;
        internal DataGridViewTextBoxColumn ColDateTime;
        #endregion

        #region Int16 _CurrentAppID
        /// <summary>
        /// نگهدارنده كلید برنامه نوبت دهی جاری
        /// </summary>
        private Int16 _CurrentAppID;
        #endregion

        #region DataTable _ReadedSchDataTable
        /// <summary>
        /// نگهدارنده نتیجه اطلاعات خوانده شده از بانك اطلاعاتی
        /// </summary>
        private DataTable _ReadedSchDataTable;
        #endregion

        #region Boolean _IsAdvancedLicense
        /// <summary>
        /// تعیین داشتن مجوز نوبت دهی پیشرفته
        /// </summary>
        internal Boolean _IsAdvancedLicense = true;
        #endregion

        #region ACL Fields
        /// <summary>
        /// تعیین امكان ویرایش نوبت سایر كاربران
        /// </summary>
        internal Boolean _CanAddOrEditOtherUsersShift;
        #endregion

        #endregion

        #region Properties

        #region DateTime CurrentShiftDate
        /// <summary>
        /// تاریخ روز جاری
        /// </summary>
        public DateTime CurrentShiftDate { get; set; }
        #endregion

        #region Boolean IsSearching
        /// <summary>
        /// فیلدی برای تعیین جستجوی بیماران.
        /// وقتی این فیلد صحیح باشد ، پس از نمایش یك شیفت مشخص از یك برنامه نوبت دهی ،
        /// در بین نوبت های جستجو شده و بیمار مورد نظر نمایش داده می شود
        /// </summary>
        public Boolean IsSearching { get; set; }
        #endregion

        #region Int32 SearchedAppointmentID { get; set; }
        /// <summary>
        /// كلید نوبت جستجو شده در فرم جستجوی بیماران نوبت دهی شده
        /// </summary>
        public Int32 SearchedAppointmentID { get; set; }
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده كلاس جدول
        /// </summary>
        public SchDataGridView()
        {
            InitializeComponents();
        }
        #endregion

        #region Event Handlers

        #region BGWorkerLoadData_DoWork
        /// <summary>
        /// تابعی برای خواندن اطلاعات یك شیفت مشخص از برنامه نوبت دهی بر اساس كلید برنامه و تاریخ شیفت
        /// </summary>
        private void BGWorkerLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime OccuredDate = Convert.ToDateTime(e.Argument);
            DateTime Date1 = new DateTime(OccuredDate.Year, OccuredDate.Month, OccuredDate.Day, 0, 0, 0, 0);
            DateTime Date2 = new DateTime(OccuredDate.Year, OccuredDate.Month, OccuredDate.Day, 23, 59, 59, 0);

            #region Load Appointment DataTable
            SqlParameter[] Params = new SqlParameter[2];
            Params[0] = new SqlParameter("@Date1", SqlDbType.DateTime);
            Params[0].Value = Date1;
            Params[1] = new SqlParameter("@Date2", SqlDbType.DateTime);
            Params[1].Value = Date2;

            _ReadedSchDataTable = Manager.ExecuteQuery(
                "EXEC [ImagingSystem].[Schedules].[SP_SelectAppData] " +
                _CurrentAppID + " , @Date1 , @Date2", 15, Params);
            if (_ReadedSchDataTable == null)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            #endregion

            // حذف ستون كلید نوبت اضافی از جدول اطلاعات پویا نوبت دهی
            if (_ReadedSchDataTable.Columns.Contains("AppointmentIX"))
                _ReadedSchDataTable.Columns.Remove("AppointmentIX");

            #region Check If Rows Not Found
            if (_ReadedSchDataTable.Rows.Count == 0)
            {
                PMBox.Show("نوبتی برای روز انتخاب شده در برنامه ی مورد نظر وجود ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ReadedSchDataTable = null;
                e.Cancel = true; return;
            }
            #endregion
        }
        #endregion

        #region BGWorkerLoadData_RunWorkerCompleted
        /// <summary>
        /// روالی برای مدیریت عملیات لازم پس از خواندن اطلاعات نوبت های شیفت انتخاب شده از برنامه نوبت دهی جاری
        /// </summary>
        private void BGWorkerLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDataInGridMethodDelegate NewMyDelegate = FillLoadedDataInGrid;
            NewMyDelegate.Invoke();
        }
        #endregion

        #region AppointmentDataGridView_CellPainting
        /// <summary>
        /// روال مدیریت رسم گرافیكی سلول های جدول در حالات خاص
        /// </summary>
        void AppointmentDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewRow RowData = Rows[e.RowIndex];
            if (RowData.Cells[ColIsActive.Index].Value == null ||
                RowData.Cells[ColIsActive.Index].Value == DBNull.Value) return;

            #region For Active Rows
            if (Convert.ToBoolean(RowData.Cells[ColIsActive.Index].Value))
            {
                #region Change ColOrderNo For Appointed Rows
                if (e.ColumnIndex == ColOrderNo.Index && (SelectedCells.Count == 0
                    || SelectedCells[0].RowIndex != e.RowIndex))
                {
                    // @@@@ تغییر رنگ ستون شماره نوبت برای نوبت های ثبت شده به خاكستری @@@@
                    if (Convert.ToBoolean(RowData.Cells[ColIsAppointed.Index].Value))
                        e.CellStyle.BackColor = Color.FromArgb(224, 224, 224);
                }
                #endregion

                #region For Selected Cells
                else if (SelectedCells.Count != 0 && SelectedCells[0].RowIndex == e.RowIndex &&
                    SelectedCells[0].ColumnIndex != e.ColumnIndex &&
                    !Columns[e.ColumnIndex].GetType().Equals(typeof(DataGridViewComboBoxColumn)))
                    e.CellStyle.BackColor = Color.FromArgb(210, 240, 254);
                #endregion
            }
            #endregion

            #region For InActive Rows
            // @@@@ تغییر رنگ ردیف نوبت های غیر فعال به خاكستری @@@@
            else if (!Columns[e.ColumnIndex].GetType().Equals(typeof(DataGridViewComboBoxColumn)))
                e.CellStyle.BackColor = Color.FromArgb(224, 224, 224);
            #endregion

            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            e.Handled = true;
        }
        #endregion

        #region AppointmentDataGridView_CellLeave
        public void AppointmentDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            // تنها در صورت خروج از سلول كمبوباكس این فرمان اجرا می شود
            if (e.RowIndex < 0 || e.ColumnIndex < 0 ||
                Columns[e.ColumnIndex].GetType() != typeof(DataGridViewComboBoxColumn)) return;
            AppointmentDataGridView_CellEndEdit(null, e);
            CellLeave -= AppointmentDataGridView_CellLeave;
        }
        #endregion

        #region AppointmentDataGridView_CellEndEdit
        /// <summary>
        /// پس از اتمام ویرایش یك سلول این فرمان فراخوانی می گردد
        /// </summary>
        public void AppointmentDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CellEndEdit -= AppointmentDataGridView_CellEndEdit;
            DBLayerIMS.Schedules.ChangeLockAppointment(Convert.ToInt32(this[ColID.Index, e.RowIndex].Value), false);
            // اگر سلول كمبوباس نبود ، این فرمان اجرا می شود چون سلول های كمبوباكس در روال دیگری مدیریت می شوند
            if (Columns[e.ColumnIndex].GetType() != typeof(DataGridViewComboBoxColumn)) RefreshCurrentDay();
            AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader);
        }
        #endregion

        #region AppointmentDataGridView_CellValueChanged
        /// <summary>
        /// روال مدیریت تغییر در داده های جدول
        /// </summary>
        public void AppointmentDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
             Int32 AppointmentID =  Convert.ToInt32(Rows[e.RowIndex].Cells[ColID.Index].Value);
            // برای ستون هایی كه توسط كاربر قابل تغییر نیستند اجرا نخواهد شد
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.ColumnIndex < 6
                || e.ColumnIndex == ColUser.Index || e.ColumnIndex == ColDateTime.Index) return;

            CellValueChanged -= AppointmentDataGridView_CellValueChanged;

            #region Validate CheckBox Columns
            if (Columns[e.ColumnIndex].GetType().Equals(typeof(DataGridViewCheckBoxColumn)) &&
                !CheckLockAppointment(e.RowIndex))
            {
                this[e.ColumnIndex, e.RowIndex].Value = !Convert.ToBoolean(this[e.ColumnIndex, e.RowIndex].Value);
                CellValueChanged += AppointmentDataGridView_CellValueChanged;
                return;
            }
            #endregion

            //StringBuilder ChangeLogText = new StringBuilder();
            //ChangeLogText.Append("در برنامه نوبت دهی \"" + DBLayerIMS.Schedules.SchAppList.
            //    Where(Data => Data.ID == _CurrentAppID).First().Name + "\"\n");

            //PersianDate PSchDateTime = Convert.ToDateTime
            //    (Rows[e.RowIndex].Cells[ColOccuredDateTime.Index].Value).ToPersianDate();

            //ChangeLogText.Append("در نوبت تاریخ: " + PSchDateTime.Year + "/" +
            //    PSchDateTime.Month + "/" + PSchDateTime.Day + " - " +
            //    PSchDateTime.Hour + ":" + PSchDateTime.Minute + ":" + PSchDateTime.Second + "\n");
            //ChangeLogText.Append("شماره نوبت: " + Rows[e.RowIndex].Cells[ColOrderNo.Index].Value + "\n");

            #region Trim Text Boxes
            // در صورتی كه در انتهای سلول ها فاصله وجود داشته باشد آنها را پاك می كند
            if (Rows[e.RowIndex].Cells[e.ColumnIndex].Value is String)
            {
                Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                    Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
            }
            #endregion

            #region Change IsAppointed To "True"
            //نوبت خالی به حالت نوبت داده شده تغییر می كند
            if (!Convert.ToBoolean(Rows[e.RowIndex].Cells[ColIsAppointed.Index].Value))
            {
                Rows[e.RowIndex].Cells[ColIsAppointed.Index].Value = true;
                DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 101, String.Empty, String.Empty);
                //ChangeLogText.Append( "نوبت خالی به حالت نوبت داده شده تغییر كرد.\n");
            }
            #endregion

            #region @@ Submit Base Columns Changes To Db @@
            Int32 UserID = SecurityManager.CurrentUserID;
            DateTime UpdateTime = DateTime.Now;
            if (e.ColumnIndex <= ColUser.Index)
            {
                // در صورتی كه لازم نباشد كه كاربر ویرایش كننده بجای كاربری كه اولین بار نوبت را ثبت كرده است ذخیره شود 
                //if (Rows[e.RowIndex].Cells[ColUser.Index].Value != null &&
                //    Rows[e.RowIndex].Cells[ColUser.Index].Value != DBNull.Value)
                // UserID = Convert.ToInt16(Rows[e.RowIndex].Cells[ColUser.Index].Value);

                #region Command
                // متن دستور اینجا ساخته می شود
                StringBuilder UpdateCommand = new StringBuilder();
                UpdateCommand.Append("UPDATE [ImagingSystem].[Schedules].[Appointments] " +
                                     "SET [IsAppointed] = 1 , " + "[SchedulerIX] = " + UserID +
                                     " , [DateTime] = '" + UpdateTime.ToString("yyyy-MM-dd HH:mm:ss") + "' ");
                UpdateCommand.Append(", " + Columns[e.ColumnIndex].Tag + " = ");

                #region ColSex & ColAge
                if (e.ColumnIndex == ColSex.Index || e.ColumnIndex == ColAge.Index)
                {

                    if (this[e.ColumnIndex, e.RowIndex].Value == null ||
                        this[e.ColumnIndex, e.RowIndex].Value == DBNull.Value)
                    {
                        UpdateCommand.Append("NULL");
                        //ChangeLogText.Append("ستون \"" + Columns[e.ColumnIndex].HeaderText + "\" خالی شد.\n");
                        DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 105, Columns[e.ColumnIndex].HeaderText, String.Empty);
                    }
                    else
                    {
                        UpdateCommand.Append(Convert.ToInt32(this[e.ColumnIndex, e.RowIndex].Value).ToString());
                        DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 104, Columns[e.ColumnIndex].HeaderText, 
                            this[e.ColumnIndex, e.RowIndex].Value.ToString());
                        //ChangeLogText.Append("ستون \"" + Columns[e.ColumnIndex].HeaderText + "\" به مقدار: \"" +
                        //this[e.ColumnIndex, e.RowIndex].Value + "\" تغییر كرد.\n");
                    }
                }
                #endregion

                #region Other Col
                else
                {
                    if (this[e.ColumnIndex, e.RowIndex].Value == null ||
                        this[e.ColumnIndex, e.RowIndex].Value == DBNull.Value ||
                        String.IsNullOrEmpty(this[e.ColumnIndex, e.RowIndex].Value.ToString().Trim()))
                    {
                        UpdateCommand.Append("NULL");
                        DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 105, Columns[e.ColumnIndex].HeaderText, String.Empty);
                        //ChangeLogText.Append( "ستون \"" + Columns[e.ColumnIndex].HeaderText + "\" خالی شد.\n");
                    }
                    else
                    {
                        UpdateCommand.Append("N'" + this[e.ColumnIndex, e.RowIndex].Value + "'");
                        DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 104, Columns[e.ColumnIndex].HeaderText,
                           this[e.ColumnIndex, e.RowIndex].Value.ToString());
                        //ChangeLogText.Append("ستون \"" + Columns[e.ColumnIndex].HeaderText + "\" به مقدار: \"" +
                        //this[e.ColumnIndex, e.RowIndex].Value + "\" تغییر كرد.\n");
                    }
                }
                #endregion

                UpdateCommand.Append(" WHERE [ID] = " + Rows[e.RowIndex].Cells[ColID.Index].Value);
                #endregion

                //Note: بروز رسانی اطلاعات پایه ای نوبت در این قسمت صورت می گیرد
                try { Manager.DBML.ExecuteCommand(UpdateCommand.ToString()); }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان ذخیره سازی تغییرات در نوبت انتخاب شده وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                        "2. آیا در حین ویرایش این نوبت ، كاربر دیگری با آزادسازی نوبت اقدام به ویرایش نموده است؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error);
                    CellValueChanged += AppointmentDataGridView_CellValueChanged; return;
                }
                #endregion

                CellValueChanged += AppointmentDataGridView_CellValueChanged;
            }

            #endregion

            #region @@ Submit Addin Columns Data @@
            else
            {
                #region DataGridViewCheckBoxColumn
                if (Columns[e.ColumnIndex].GetType().Equals(typeof(DataGridViewCheckBoxColumn)))
                {
                    try
                    {
                        Boolean? Value = null;
                        if (this[e.ColumnIndex, e.RowIndex].Value != null &&
                            !this[e.ColumnIndex, e.RowIndex].Value.GetType().Equals(typeof(DBNull)))
                            Value = Convert.ToBoolean(this[e.ColumnIndex, e.RowIndex].Value);
                        DBLayerIMS.Manager.DBML.SP_InsertAppointmentAddBoolData(
                            Convert.ToInt32(Rows[e.RowIndex].Cells[ColID.Index].Value),
                            Columns[e.ColumnIndex].Name, Value);
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان ذخیره سازی تغییرات در نوبت انتخاب شده وجود ندارد.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                            Ex.StackTrace, EventLogEntryType.Error);
                        CellValueChanged += AppointmentDataGridView_CellValueChanged; return;
                    }
                    #endregion
                }
                #endregion

                #region DataGridViewTextBoxColumn
                else if ((Columns[e.ColumnIndex].GetType().
                    Equals(typeof(DataGridViewTextBoxColumn)) &&
                          Columns[e.ColumnIndex].ValueType.Equals(typeof(Int32))) ||
                         Columns[e.ColumnIndex].GetType().Equals(typeof(DataGridViewComboBoxColumn)))
                {
                    try
                    {
                        Int32? Value = null;
                        if (this[e.ColumnIndex, e.RowIndex].Value != null &&
                            !this[e.ColumnIndex, e.RowIndex].Value.GetType().Equals(typeof(DBNull)))
                            Value = Convert.ToInt32(this[e.ColumnIndex, e.RowIndex].Value);
                        DBLayerIMS.Manager.DBML.SP_InsertAppointmentAddIntData(
                            Convert.ToInt32(Rows[e.RowIndex].Cells[ColID.Index].Value), Columns[e.ColumnIndex].Name, Value);
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان ذخیره سازی تغییرات در نوبت انتخاب شده وجود ندارد.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                            Ex.StackTrace, EventLogEntryType.Error);
                        CellValueChanged += AppointmentDataGridView_CellValueChanged; return;
                    }
                    #endregion
                }
                #endregion

                #region DataGridViewTextBoxColumn
                else if (Columns[e.ColumnIndex].GetType().Equals(typeof(DataGridViewTextBoxColumn)))
                {
                    try
                    {
                        String Value = String.Empty;
                        if (this[e.ColumnIndex, e.RowIndex].Value != null &&
                            !this[e.ColumnIndex, e.RowIndex].Value.GetType().Equals(typeof(DBNull)))
                            Value = this[e.ColumnIndex, e.RowIndex].Value.ToString();
                        DBLayerIMS.Manager.DBML.SP_InsertAppointmentAddStringData(
                            Convert.ToInt32(Rows[e.RowIndex].Cells[ColID.Index].Value),
                            Columns[e.ColumnIndex].Name, Value.Normalize());
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage =
                            "امكان ذخیره سازی تغییرات در نوبت انتخاب شده وجود ندارد.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                            Ex.StackTrace, EventLogEntryType.Error);
                        CellValueChanged += AppointmentDataGridView_CellValueChanged; return;
                    }
                    #endregion
                }
                #endregion

                // در صورتی كه لازم نباشد كه كاربر ویرایش كننده بجای كاربری كه اولین بار نوبت را ثبت كرده است ذخیره شود 
                //if (Rows[e.RowIndex].Cells[ColUser.Index].Value != null &&
                //    Rows[e.RowIndex].Cells[ColUser.Index].Value != DBNull.Value)
                //    UserID = Convert.ToInt16(Rows[e.RowIndex].Cells[ColUser.Index].Value);

                if (this[e.ColumnIndex, e.RowIndex].Value == null ||
                    this[e.ColumnIndex, e.RowIndex].Value == DBNull.Value)
                    DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 105, Columns[e.ColumnIndex].HeaderText, String.Empty);
                    //ChangeLogText.Append("ستون \"" + Columns[e.ColumnIndex].HeaderText + "\" خالی شد.\n");
                else
                    DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 104, Columns[e.ColumnIndex].HeaderText,
                           this[e.ColumnIndex, e.RowIndex].Value.ToString());
                    //ChangeLogText.Append("ستون \"" + Columns[e.ColumnIndex].HeaderText + "\" به مقدار: \"" +
                    //this[e.ColumnIndex, e.RowIndex].Value + "\" تغییر كرد.\n");

                String UpdateCommand = "UPDATE [ImagingSystem].[Schedules].[Appointments] " +
                    "SET [IsAppointed] = 1 , [LockDateTime] = NULL , [SchedulerIX] = " + UserID +
                    " , [DateTime] = '" + UpdateTime.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                    " WHERE [ID] = " + Rows[e.RowIndex].Cells[ColID.Index].Value;

                if (!Manager.ExecuteCommand(UpdateCommand, 5))
                {
                    const String ErrorMessage = "امكان ذخیره سازی تغییرات در نوبت انتخاب شده وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                        "2. آیا در حین ویرایش این نوبت ، كاربر دیگری با آزادسازی نوبت اقدام به ویرایش نموده است؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CellValueChanged += AppointmentDataGridView_CellValueChanged;
                if (Columns[e.ColumnIndex].GetType().Equals(typeof(DataGridViewComboBoxColumn))) RefreshCurrentDay();
            }
            #endregion

            //ClinicData.SubmitDbEventLog(5600, SecurityManager.CurrentApplicationID,
            //    SecurityManager.CurrentUserID, DateTime.Now, ChangeLogText.ToString());
        }
        #endregion

        #endregion

        #region Overrided Methods

        #region OnCellValidating
        /// <summary>
        /// روال تایید اعتبار برای سلول هایی كه نیاز به تایید اعتبار دارند
        /// </summary>
        protected override void OnCellValidating(DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != ColAge.Index) return;

            #region Validate ColAge
            // ستون سن بیمار
            foreach (Char TheChar in e.FormattedValue.ToString())
                if (!Char.IsNumber(TheChar))
                {
                    PMBox.Show("برای سن بیمار یك مقدار عددی وارد نمایید!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning); e.Cancel = true; return;
                }
            Int32 Value;
            Int32.TryParse(e.FormattedValue.ToString(), out Value);
            if (Value > 150)
            {
                PMBox.Show("برای سن بیمار مقداری كوچكتر از 150 وارد نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning); e.Cancel = true; return;
            }
            #endregion

            if (IsCurrentCellInEditMode)
                DBLayerIMS.Schedules.ChangeLockAppointment(Convert.ToInt32(this[ColID.Index, e.RowIndex].Value), false);
        }
        #endregion

        #region OnCellFormatting
        /// <summary>
        /// روالی برای نبدیل اطلاعات پایه به اطلاعات قابل مشاهده برای كاربر
        /// </summary>
        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            #region Set PatientID
            if (e.ColumnIndex == ColPatientIX.Index)
            {
                e.FormattingApplied = true;
                if (e.Value == null || e.Value == DBNull.Value) e.Value = String.Empty;
                else e.Value = Patients.GetPatientIDByPatListID(Convert.ToInt32(e.Value));
            }
            #endregion

            #region Set Scheduler Name
            else if (e.ColumnIndex == ColUser.Index)
            {
                e.FormattingApplied = true;
                if (e.Value == null || e.Value == DBNull.Value) e.Value = String.Empty;
                else
                    e.Value = Security.UsersList.
                    Where(Data => Data.ID == Convert.ToInt16(e.Value)).First().FullName;
            }
            #endregion

            #region Set DateTime
            else if (e.ColumnIndex == ColDateTime.Index)
            {
                e.FormattingApplied = true;
                if (e.Value == null || e.Value == DBNull.Value) e.Value = String.Empty;
                else
                {
                    PersianDate x = PersianDateConverter.
                     ToPersianDate(Convert.ToDateTime(e.Value));
                    e.Value = x.Hour + ":" + x.Minute +":"+x.Second+ " " + x.Year + "/" + x.Month + "/" + x.Day;
                }
            }
            #endregion

        }
        #endregion

        #region OnCellStateChanged
        /// <summary>
        /// روالی برای رسم مجدد یك ردیف پس از تغییر حالت آن
        /// </summary>
        protected override void OnCellStateChanged(DataGridViewCellStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected) InvalidateRow(e.Cell.RowIndex);
            base.OnCellStateChanged(e);
        }
        #endregion

        #region OnCellMouseClick
        /// <summary>
        /// روال مدیریت كلیك راست بر روی سلول های جدول
        /// </summary>
        protected override void OnCellMouseClick(DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || ReadOnly) { base.OnCellMouseClick(e); return; }
            // مدیریت ستون های كمبو باكس برای باز كردن آنها در زمانی كه امكان ویرایش وجود دارد
            if (e.Button == MouseButtons.Left &&
                Columns[e.ColumnIndex].GetType() == typeof(DataGridViewComboBoxColumn))
            {
                if (ReadOnly || IsCurrentCellDirty || IsCurrentCellInEditMode || IsCurrentRowDirty) return;
                if (!CheckAppointmentRowEditAccess(e.RowIndex, true)) return;
                CellLeave -= AppointmentDataGridView_CellLeave;
                CellLeave += AppointmentDataGridView_CellLeave;
                CellEndEdit -= AppointmentDataGridView_CellEndEdit;
                CellEndEdit += AppointmentDataGridView_CellEndEdit;
                BeginEdit(false);
            }
            else base.OnCellMouseClick(e);
        }
        #endregion

        #region OnCellMouseDoubleClick
        protected override void OnCellMouseDoubleClick(DataGridViewCellMouseEventArgs e)
        {
            if (ReadOnly || Columns[e.ColumnIndex].GetType().Equals(typeof(DataGridViewComboBoxColumn)) ||
                IsCurrentCellDirty || IsCurrentCellInEditMode) return;
            EndEdit();
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && e.Button == MouseButtons.Left)
                EditAppointment(e.RowIndex);
            base.OnCellMouseDoubleClick(e);
        }
        #endregion

        #region Boolean ProcessDialogKey(Keys KeyData)
        /// <summary>
        /// روالی برای مدیریت عملكرد كنترل پس از فشرده شدن كلید Enter
        /// </summary>
        protected override Boolean ProcessDialogKey(Keys KeyData)
        {
            if (KeyData == Keys.Enter && IsCurrentCellInEditMode)
            {
                base.ProcessDataGridViewKey(new KeyEventArgs(Keys.Left));
                if (CurrentCell.ColumnIndex != ColAge.Index)
                {
                    base.ProcessDataGridViewKey(new KeyEventArgs(Keys.Right));
                    base.ProcessDataGridViewKey(new KeyEventArgs(Keys.Left));
                }
                return true;
            }
            return base.ProcessDialogKey(KeyData);
        }
        #endregion

        #region OnKeyDown
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) { ManageKeyPress(new KeyPressEventArgs('\n')); e.Handled = true; }
            else base.OnKeyDown(e);
        }
        #endregion

        #region OnKeyPress
        /// <summary>
        /// روالی برای مدیریت ورود كلید بر روی سلول های جدول نوبت دهی
        /// </summary>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            DataGridViewCell TheCell = Rows[CurrentCell.RowIndex].Cells[ColIsActive.Index];
            if (!Convert.ToBoolean(TheCell.Value) || e.KeyChar == '\r' ||
               !CheckAppointmentRowEditAccess(SelectedCells[0].RowIndex, true))
            { e.Handled = true; return; }
            if (SelectedCells.Count != 0 && !SelectedCells[0].ReadOnly) ManageKeyPress(e);
            else base.OnKeyPress(e);
        }
        #endregion

        #region OnCellBeginEdit
        /// <summary>
        /// روالی برای بررسی وضعیت ویرایش ردیف ، از قبیل در حال ویرایش یا آزاد
        /// </summary>
        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            if (!CheckAppointmentRowEditAccess(e.RowIndex, true)) { e.Cancel = true; return; }
            if (DBLayerIMS.Schedules.
                ChangeLockAppointment(Convert.ToInt32(Rows[e.RowIndex].Cells[ColID.Index].Value), true))
            {
                CellEndEdit -= AppointmentDataGridView_CellEndEdit;
                CellEndEdit += AppointmentDataGridView_CellEndEdit;
                base.OnCellBeginEdit(e);
            }
            else e.Cancel = true;
        }
        #endregion

        #endregion

        #region Private Methods

        #region void InitializeComponents()
        /// <summary>
        /// تابع ساخت و ایجاد كنترل ها و ساختار كلاس
        /// </summary>
        private void InitializeComponents()
        {
            #region Initializing
            DataGridViewCellStyle dgvColumnHeadersDefaultCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCellStyle8 = new DataGridViewCellStyle();
            ColID = new DataGridViewTextBoxColumn();
            ColApplicationIX = new DataGridViewTextBoxColumn();
            ColOrderNo = new DataGridViewTextBoxColumn();
            ColOccuredDateTime = new DataGridViewTextBoxColumn();
            ColIsActive = new DataGridViewTextBoxColumn();
            ColIsAppointed = new DataGridViewTextBoxColumn();
            ColFirstName = new DataGridViewTextBoxColumn();
            ColLastName = new DataGridViewTextBoxColumn();
            ColPatientIX = new DataGridViewTextBoxColumn();
            ColReferralIX = new DataGridViewTextBoxColumn();
            ColSex = new DataGridViewCheckBoxColumn();
            ColAge = new DataGridViewTextBoxColumn();
            ColTel1 = new DataGridViewTextBoxColumn();
            ColTel2 = new DataGridViewTextBoxColumn();
            ColUser = new DataGridViewTextBoxColumn();
            ColDateTime = new DataGridViewTextBoxColumn();
            #endregion

            #region Initialize BGWorkerLoadData
            // BGWorkerLoadData
            BGWorkerLoadData = new BackgroundWorker();
            BGWorkerLoadData.WorkerSupportsCancellation = true;
            BGWorkerLoadData.DoWork += BGWorkerLoadData_DoWork;
            BGWorkerLoadData.RunWorkerCompleted += BGWorkerLoadData_RunWorkerCompleted;
            #endregion

            #region Set ColumnHeadersDefaultCellStyle
            dgvColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvColumnHeadersDefaultCellStyle.Font =
                new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((178)));
            dgvColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ColumnHeadersDefaultCellStyle = dgvColumnHeadersDefaultCellStyle;
            // ===========================================
            #endregion

            #region Set RowTemplate DefaultCellStyle
            RowTemplate.DefaultCellStyle.BackColor = Color.White;
            RowTemplate.DefaultCellStyle.Font =
                new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
            RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SkyBlue;
            RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Blue;
            RowTemplate.Height = 20;
            #endregion

            #region Set Columns Properties

            #region ColID
            // ColID
            ColID.HeaderText = "ID";
            ColID.Name = "ColID";
            ColID.Visible = false;
            #endregion
            #region ColApplicationIX
            // ColApplicationIX
            ColApplicationIX.HeaderText = "ApplicationIX";
            ColApplicationIX.Name = "ColApplicationIX";
            ColApplicationIX.Visible = false;
            #endregion
            #region ColOrderNo
            // ColOrderNo
            dgvCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyle2.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            dgvCellStyle2.NullValue = null;
            ColOrderNo.DefaultCellStyle = dgvCellStyle2;
            ColOrderNo.HeaderText = "#";
            ColOrderNo.MinimumWidth = 40;
            ColOrderNo.Name = "ColOrderNo";
            ColOrderNo.ReadOnly = true;
            ColOrderNo.Resizable = DataGridViewTriState.False;
            ColOrderNo.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColOrderNo.ToolTipText = "شماره نوبت";
            ColOrderNo.Width = 40;
            #endregion
            #region ColOccuredDateTime
            // ColOccuredDateTime
            dgvCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyle3.Format = "HH:mm";
            dgvCellStyle3.NullValue = null;
            ColOccuredDateTime.DefaultCellStyle = dgvCellStyle3;
            ColOccuredDateTime.HeaderText = "زمان";
            ColOccuredDateTime.MaxInputLength = 10;
            ColOccuredDateTime.MinimumWidth = 40;
            ColOccuredDateTime.Name = "ColOccuredDateTime";
            ColOccuredDateTime.ReadOnly = true;
            ColOccuredDateTime.Resizable = DataGridViewTriState.False;
            ColOccuredDateTime.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColOccuredDateTime.ToolTipText = "زمان حضور بیمار";
            ColOccuredDateTime.Width = 40;
            #endregion
            #region ColIsActive
            // ColIsActive
            ColIsActive.Tag = "[IsActive]";
            ColIsActive.HeaderText = "IsActive";
            ColIsActive.Name = "ColIsActive";
            ColIsActive.Visible = false;
            #endregion
            #region ColIsAppointed
            // ColIsAppointed
            ColIsAppointed.HeaderText = "IsAppointed";
            ColIsAppointed.Name = "ColIsAppointed";
            ColIsAppointed.Visible = false;
            ColIsAppointed.Tag = "[IsAppointed]";
            #endregion
            #region ColFirstName
            // ColFirstName
            ColFirstName.DataPropertyName = "[FirstName]";
            ColFirstName.HeaderText = "نام";
            ColFirstName.MaxInputLength = 15;
            ColFirstName.MinimumWidth = 50;
            ColFirstName.Name = "ColFirstName";
            ColFirstName.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColFirstName.ToolTipText = "نام بیمار";
            ColFirstName.Tag = "[FirstName]";
            #endregion
            #region ColLastName
            // ColLastName
            ColLastName.DataPropertyName = "[LastName]";
            ColLastName.HeaderText = "نام خانوادگی";
            ColLastName.MaxInputLength = 25;
            ColLastName.MinimumWidth = 100;
            ColLastName.Name = "ColLastName";
            ColLastName.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColLastName.ToolTipText = "نام خانوادگی بیمار";
            ColLastName.Tag = "[LastName]";
            #endregion
            #region ColPatientIX
            // ColPatientIX
            dgvCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyle4.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((178)));
            dgvCellStyle4.ForeColor = Color.Navy;
            ColPatientIX.DefaultCellStyle = dgvCellStyle4;
            ColPatientIX.HeaderText = "كد بیمار";
            ColPatientIX.MinimumWidth = 50;
            ColPatientIX.Name = "ColPatientIX";
            ColPatientIX.ReadOnly = true;
            ColPatientIX.Width = 70;
            ColPatientIX.Tag = "[PatientIX]";

            #endregion
            #region ColReferralIX
            // ColReferralIX
            ColReferralIX.HeaderText = "ReferralIX";
            ColReferralIX.Name = "ColReferralIX";
            ColReferralIX.Visible = false;
            ColReferralIX.Tag = "[ReferralIX]";
            #endregion
            #region ColSex
            // ColSex
            ColSex.FalseValue = "";
            ColSex.HeaderText = "مرد";
            ColSex.MinimumWidth = 35;
            ColSex.Name = "ColSex";
            ColSex.Resizable = DataGridViewTriState.False;
            ColSex.ToolTipText = "تعیین جنسیت بیمار. مرد یا زن";
            ColSex.TrueValue = "";
            ColSex.Width = 35;
            ColSex.Tag = "[IsMale]";
            #endregion
            #region ColAge
            // ColAge
            dgvCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyle5.NullValue = null;
            ColAge.DefaultCellStyle = dgvCellStyle5;
            ColAge.HeaderText = "سن";
            ColAge.MaxInputLength = 3;
            ColAge.MinimumWidth = 40;
            ColAge.Name = "ColAge";
            ColAge.Resizable = DataGridViewTriState.False;
            ColAge.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColAge.ToolTipText = "سن بیمار";
            ColAge.Width = 40;
            ColAge.Tag = "[Age]";
            #endregion
            #region ColTel1
            // ColTel1
            ColTel1.DataPropertyName = "[TelNo1]";
            dgvCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColTel1.DefaultCellStyle = dgvCellStyle6;
            ColTel1.HeaderText = "تلفن تماس 1";
            ColTel1.MaxInputLength = 15;
            ColTel1.MinimumWidth = 90;
            ColTel1.Name = "ColTel1";
            ColTel1.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColTel1.ToolTipText = "تلفن تماس اول بیمار - تلفن ثابت";
            ColTel1.Width = 90;
            ColTel1.Tag = "[TelNo1]";

            #endregion
            #region ColTel2
            // ColTel2
            ColTel2.DataPropertyName = "[TelNo2]";
            dgvCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColTel2.DefaultCellStyle = dgvCellStyle7;
            ColTel2.HeaderText = "تلفن تماس 2";
            ColTel2.MaxInputLength = 15;
            ColTel2.MinimumWidth = 90;
            ColTel2.Name = "ColTel2";
            ColTel2.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColTel2.ToolTipText = "تلفن تماس دوم بیمار - تلفن همراه";
            ColTel2.Width = 90;
            ColTel2.Tag = "[TelNo2]";
            #endregion
            #region ColUser
            // ColUser
            ColUser.HeaderText = "كاربر";
            ColUser.Name = "ColUser";
            ColUser.ReadOnly = true;
            ColUser.Resizable = DataGridViewTriState.True;
            ColUser.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColUser.ToolTipText = "كاربر ثبت كننده نوبت";
            ColUser.Width = 50;
            ColUser.Tag = "[SchedulerIX]";
            #endregion
            #region ColDateTime
            // ColDateTime
            dgvCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColDateTime.DefaultCellStyle = dgvCellStyle8;
            ColDateTime.HeaderText = "زمان تغییر";
            ColDateTime.MinimumWidth = 60;
            ColDateTime.Name = "ColDateTime";
            ColDateTime.ReadOnly = true;
            ColDateTime.Resizable = DataGridViewTriState.True;
            ColDateTime.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColDateTime.ToolTipText = "زمان ثبت یا آخرین ویرایش";
            ColDateTime.Width = 100;
            ColDateTime.Tag = "[DateTime]";
            #endregion

            #endregion

            #region Set Behavior Properties
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            EditMode = DataGridViewEditMode.EditProgrammatically;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            SelectionMode = DataGridViewSelectionMode.CellSelect;
            #endregion

            #region Set Appearance Properties
            Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            GridColor = Color.LightSteelBlue;
            BackgroundColor = Color.PowderBlue;
            BorderStyle = BorderStyle.Fixed3D;
            ColumnHeadersHeight = 30;
            RowHeadersVisible = false;
            #endregion

            #region Add Base Columns To Columns Collection
            //NOTE: در این قسمت ستون ها به لیست جدول اضافه می شوند ترتیب آنها بسیار مهم است
            Columns.AddRange(new DataGridViewColumn[]
            {ColID,ColApplicationIX,ColOrderNo,ColOccuredDateTime,ColIsActive,ColIsAppointed,
                ColFirstName,ColLastName,ColPatientIX,ColReferralIX,ColSex,ColAge, ColTel1,ColTel2,ColDateTime,ColUser});
            #endregion

            #region Set Base Columns Value Types
            foreach (DataGridViewColumn Col in Columns)
            {
                if (Col.Index == ColID.Index || ColApplicationIX.Index == ColOrderNo.Index)
                    Col.ValueType = typeof(Int32);
                else if (Col.Index == ColOccuredDateTime.Index) Col.ValueType = typeof(DateTime);
                else if (Col.Index == ColIsActive.Index || Col.Index == ColIsAppointed.Index ||
                    Col.Index == ColSex.Index) Col.ValueType = typeof(Boolean);
                else Col.ValueType = typeof(String);
            }
            #endregion
        }
        #endregion

        #region ManageKeyPress(KeyPressEventArgs e)
        /// <summary>
        /// روالی برای كنترل كلید های كیبورد ارسال شده به جدول نوبت دهی
        /// </summary>
        private void ManageKeyPress(KeyPressEventArgs e)
        {
            #region For CheckBox Columns
            if (Columns[SelectedCells[0].ColumnIndex].GetType().Equals(typeof(DataGridViewCheckBoxColumn)))
            {
                if (e.KeyChar == ' ')
                {
                    if (SelectedCells[0].Value == null || SelectedCells[0].Value is DBNull ||
                        Convert.ToBoolean(SelectedCells[0].Value) == false)
                        SelectedCells[0].Value = true;
                    else SelectedCells[0].Value = false;
                }
                return;
            }
            #endregion

            // با كلید Enter سلول بدون آنكه تغییر كند آغاز به ویرایش می كند
            if (e.KeyChar == '\n') { e.Handled = true; BeginEdit(false); return; }
            // اگر كلید وارد شده حرف یا عدد یا از نمادهای كنار اعداد نباشد اجازه ورود داده نمی شود
            if (!Char.IsLetterOrDigit(e.KeyChar) && !Char.IsPunctuation(e.KeyChar)) { e.Handled = true; return; }
            // در غیر اینصورت اجازه ویرایش داده می شود
            if (SelectedCells[0].ValueType.Equals(typeof(String)) || SelectedCells[0].ValueType.Equals(typeof(Int32)))
            {
                CellValueChanged -= AppointmentDataGridView_CellValueChanged;
                BeginEdit(false);
                EditingControl.Text = e.KeyChar.ToString();
                ((TextBox)EditingControl).SelectionStart = 1;
                CellValueChanged += AppointmentDataGridView_CellValueChanged;
            }
            // برای سلول های بولین و كمبوباكس
            else BeginEdit(false);
        }
        #endregion

        #region internal void RefreshCurrentDay()
        /// <summary>
        /// تابعی برای به روز رسانی نوبت های روز جاری در برنامه جاری
        /// </summary>
        internal void RefreshCurrentDay()
        {
            Cursor = Cursors.WaitCursor;
            if (Rows.Count == 0) return;
            FillAppointments(CurrentShiftDate);
        }
        #endregion

        #region void FillLoadedDataInGrid()
        /// <summary>
        /// تابعی برای تكمیل اطلاعات خوانده شده شیفت جاری در جدول
        /// </summary>
        private void FillLoadedDataInGrid()
        {
            Cursor = Cursors.Default;
            if (_ReadedSchDataTable == null) return;

            CellValueChanged -= AppointmentDataGridView_CellValueChanged;
            CellEndEdit -= AppointmentDataGridView_CellEndEdit;
            CellPainting -= AppointmentDataGridView_CellPainting;

            #region Fill Data In Grid
            // تعداد ردیف های جدول كمتر است و باید به آن اضافه شود
            if (Rows.Count < _ReadedSchDataTable.Rows.Count)
                Rows.Add(_ReadedSchDataTable.Rows.Count - Rows.Count);
            // تعداد ردیف های جدول بیشتر است و باید از آن كم شود
            else if (Rows.Count > _ReadedSchDataTable.Rows.Count)
                for (Int32 i = Rows.Count - 1; i != _ReadedSchDataTable.Rows.Count - 1; i--) Rows.RemoveAt(i);
            //ترتیب اضافه كردن ستون ها به لیست ستون های جدول باید با خروجی این دیتا تیبل یكی باشد
            //Note: وارد كردن اطلاعات خوانده شده جدید از بانك اطلاعاتی در جدول
            foreach (DataGridViewRow row in Rows) row.SetValues(_ReadedSchDataTable.Rows[row.Index].ItemArray);
            #endregion

            CellPainting += AppointmentDataGridView_CellPainting;
            CellValueChanged += AppointmentDataGridView_CellValueChanged;

            #region Select Search Appointment
            // در این قسمت در صورتی كه كاربر در حال جستجوی بیمار بوده باشد آن بیمار پیدا شده و انتخاب می شود
            if (IsSearching)
            {
                ClearSelection();
                foreach (DataGridViewRow row in Rows)
                    if (Convert.ToInt32(row.Cells[ColID.Index].Value) == SearchedAppointmentID)
                    {
                        FirstDisplayedScrollingRowIndex = row.Index;
                        FirstDisplayedCell = row.Cells[ColFirstName.Index];
                        CurrentCell = row.Cells[ColFirstName.Index];
                        row.Cells[ColFirstName.Index].Selected = true;
                        break;
                    }
                IsSearching = false;
            }
            #endregion

            Refresh();
            if (FormStateChanged != null) FormStateChanged.Invoke();
            Select();
            Focus();
        }
        #endregion

        #endregion

        #region Public Methods

        #region Boolean GenerateAddinColumns()
        /// <summary>
        /// تابعی برای تولید ستون های اطلاعاتی پویا در صورت داشتن لایسنس نوبت دهی پیشرفته
        /// </summary>
        internal Boolean GenerateAddinColumns()
        {
            // اگر قفل جاری دارای لایسنس پیشرفته نباشد ، ستون های پویا ایجاد نمی شوند
            if (!_IsAdvancedLicense) return true;

            if (DBLayerIMS.Schedules.SchAddinColumnsList == null) return false;

            #region Add New Columns
            // اضافه كردن ستون های اطلاعات اضافی برنامه انتخاب شده
            List<SchAddinColumns> DynamicColumns =
                DBLayerIMS.Schedules.SchAddinColumnsList.OrderBy(Data => Data.ID).ToList();
            for (Int32 i = 0; i < DynamicColumns.Count; i++)
            {
                switch (DynamicColumns[i].TypeID)
                {
                    case 0: // String Data
                        {
                            DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
                            Col.ValueType = typeof(String);
                            Col.Tag = DynamicColumns[i].ID;
                            Col.Name = DynamicColumns[i].FieldName;
                            Col.HeaderText = DynamicColumns[i].Title;
                            Col.ToolTipText = DynamicColumns[i].Description;
                            Col.Width = 40;
                            Col.MinimumWidth = 40;
                            Col.MaxInputLength = Convert.ToInt32(DynamicColumns[i].Lenght);
                            Col.SortMode = DataGridViewColumnSortMode.NotSortable;
                            Columns.Add(Col);
                        } break;
                    case 1: // Boolean Data
                        {
                            DataGridViewCheckBoxColumn Col = new DataGridViewCheckBoxColumn();
                            Col.ValueType = typeof(Boolean);
                            Col.Tag = DynamicColumns[i].ID;
                            Col.Name = DynamicColumns[i].FieldName;
                            Col.HeaderText = DynamicColumns[i].Title;
                            Col.ToolTipText = DynamicColumns[i].Description;
                            Col.Width = 40;
                            Col.MinimumWidth = 40;
                            Col.SortMode = DataGridViewColumnSortMode.NotSortable;
                            Columns.Add(Col);
                        } break;
                    case 2: // Integer Data
                        {
                            DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
                            Col.ValueType = typeof(Int32);
                            Col.Tag = DynamicColumns[i].ID;
                            Col.Name = DynamicColumns[i].FieldName;
                            Col.HeaderText = DynamicColumns[i].Title;
                            Col.ToolTipText = DynamicColumns[i].Description;
                            Col.Width = 40;
                            Col.MinimumWidth = 40;
                            Col.DefaultCellStyle.Format = "N0";
                            Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            Col.MaxInputLength = 10;
                            Col.SortMode = DataGridViewColumnSortMode.NotSortable;
                            Columns.Add(Col);
                        } break;
                    case 3: // MultiChoice Data
                        {
                            DataGridViewComboBoxColumn Col = new DataGridViewComboBoxColumn();
                            Col.ValueType = typeof(Int32?);
                            Col.Tag = DynamicColumns[i].ID;
                            Col.Name = DynamicColumns[i].FieldName;
                            Col.HeaderText = DynamicColumns[i].Title;
                            Col.ToolTipText = DynamicColumns[i].Description;
                            Col.Width = 100;
                            Col.MinimumWidth = 60;
                            Col.SortMode = DataGridViewColumnSortMode.NotSortable;
                            Col.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                            Col.FlatStyle = FlatStyle.Standard;
                            Col.ReadOnly = false;
                            Col.DefaultCellStyle.Font = new Font("Tahoma", 7, FontStyle.Regular);
                            Col.ValueMember = "ID";
                            Col.DisplayMember = "Title";
                            Col.DataSource = DBLayerIMS.Schedules.GetMultiSelectItemsByColID(DynamicColumns[i].ID);
                            Columns.Add(Col);
                        } break;
                }
            }
            #endregion

            #region Set Columns Orders
            foreach (SchColumnsOrder ColumnOrder in DBLayerIMS.Schedules.SchAddinColumnsOrdersList)
                if (ColumnOrder.ColumnIX < 0)
                    switch (ColumnOrder.ColumnIX)
                    {
                        case -1: ColFirstName.DisplayIndex = ColumnOrder.OrderNumber; break;
                        case -2: ColLastName.DisplayIndex = ColumnOrder.OrderNumber; break;
                        case -3: ColSex.DisplayIndex = ColumnOrder.OrderNumber; break;
                        case -4: ColAge.DisplayIndex = ColumnOrder.OrderNumber; break;
                        case -5: ColTel1.DisplayIndex = ColumnOrder.OrderNumber; break;
                        case -6: ColTel2.DisplayIndex = ColumnOrder.OrderNumber; break;
                        case -7: ColUser.DisplayIndex = ColumnOrder.OrderNumber; break;
                        case -8: ColPatientIX.DisplayIndex = ColumnOrder.OrderNumber; break;
                        case -9: ColDateTime.DisplayIndex = ColumnOrder.OrderNumber; break;
                    }
                else
                {
                    // ReSharper disable AccessToModifiedClosure
                    List<SchAddinColumns> ColumnData =
                        DBLayerIMS.Schedules.SchAddinColumnsList.
                        Where(Data => Data.ID == ColumnOrder.ColumnIX).ToList();
                    // ReSharper restore AccessToModifiedClosure
                    if (ColumnData.Count == 0) continue;
                    String FieldName = ColumnData.First().FieldName;
                    // ReSharper disable PossibleNullReferenceException
                    if (Columns.Contains(FieldName)) Columns[FieldName].DisplayIndex = ColumnOrder.OrderNumber;
                    // ReSharper restore PossibleNullReferenceException
                }
            #endregion

            return true;
        }
        #endregion

        #region Boolean ChangeApplication(Int16 AppID, Boolean ShouldChangeDay)
        /// <summary>
        /// تابع مدیریت تغییر برنامه نوبت دهی جاری
        /// </summary>
        /// <param name="AppID">كلید برنامه</param>
        /// <param name="ShouldChangeDay">تعیین تغییر برنامه به نزدیك ترین روز</param>
        internal Boolean ChangeApplication(Int16 AppID, Boolean ShouldChangeDay)
        {
            _CurrentAppID = AppID;

            #region Change Addin Columns Visibilities
            // اگر لایسنس پیشرفته باشد و ستون اطلاعاتی اضافی در جدول وجود داشته باشد
            if (_IsAdvancedLicense && ColUser.Index + 1 != Columns.Count)
            {
                List<SchAddinColsAppCover> AppAdditionalCols =
                    DBLayerIMS.Schedules.SchAddinColsAppCover.Where(Data => Data.ApplicationIX == AppID).ToList();
                //NOTE: در صورتی كه "كاربر" ستون آخری نباشد كه به لیست ستون ها اضافه می شود نمایش داده نمی شود.
                for (Int32 i = Columns.Count - 1; i != ColUser.Index; i--)
                {
                    List<SchAddinColsAppCover> AddinFields = AppAdditionalCols.
                        Where(Data => Data.SchAddinColumns.FieldName == Columns[i].Name).ToList();
                    if (AddinFields.Count == 0) Columns[i].Visible = false;
                    else Columns[i].Visible = true;
                }
            }
            #endregion

            #region Find Close Date For Selected Application
            if (ShouldChangeDay)
            {
                // پیدا كردن اولین روز بعدی برنامه نسبت به دیروز
                DateTime? AppFirstDate = DBLayerIMS.Schedules.GetSchApplicationNextOrPrevDay(
                    AppID, DateTime.Now.AddDays(-1), true);
                if (AppFirstDate == null) // اگر اولین روز بعدی برای برنامه نسبت به دیروز وجود نداشت
                {
                    // پیدا كردن اولین روز قبلی برنامه نسبت به فردا
                    AppFirstDate = DBLayerIMS.Schedules.GetSchApplicationNextOrPrevDay(AppID, DateTime.Now.AddDays(1), false);
                    if (AppFirstDate == null) // اگر اولین روز قبلی برای برنامه نسبت به فردا وجود نداشت
                    {
                        PMBox.Show("برنامه مورد نظر هیچ شیفت فعالی ندارد!", "عدم وجود شیفت فعال!",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Rows.Clear();
                        // اگر ستون اطلاعاتی اضافی در جدول وجود داشته باشد آن ستون حذف می گردد
                        for (Int32 i = Columns.Count; i - 1 != ColUser.Index; i--) Columns.RemoveAt(i - 1);
                        return true;
                    }
                }
                // نمایش اطلاعات روز پیدا شده
                FillAppointments(Convert.ToDateTime(AppFirstDate));
            }
            #endregion

            if (FormStateChanged != null) FormStateChanged.Invoke();
            return true;
        }
        #endregion

        #region void FillAppointments(DateTime ShiftDate)
        /// <summary>
        /// تابع خواندن نوبت های یك برنامه برای یك روز مشخص
        /// </summary>
        /// <param name="ShiftDate">تاریخ شیفت نوبت دهی</param>
        internal void FillAppointments(DateTime ShiftDate)
        {
            CurrentShiftDate = ShiftDate;
            if (BGWorkerLoadData.IsBusy) return;
            BGWorkerLoadData.RunWorkerAsync(ShiftDate);
        }
        #endregion

        #region Boolean CheckAppointmentRowEditAccess(Int32 RowIndex , Boolean ShouldWarn)
        /// <summary>
        /// تابعی برای بررسی آزاد بودن دسترسی ویرایش یك ردیف نوبت
        /// </summary>
        /// <param name="RowIndex">ردیف نوبت در جدول</param>
        /// <param name="ShouldWarn">تعیین نیاز به هشدار برای محدودیت یا عدم هشدار</param>
        /// <returns>تعیین دسترسی داشتن یا نداشتن كاربر جاری برای ویرایش نوبت انتخاب شده</returns>
        internal Boolean CheckAppointmentRowEditAccess(Int32 RowIndex, Boolean ShouldWarn)
        {
            DataGridViewRow TheRow = Rows[RowIndex];
            // بررسی غیر فعال بودن نوبت
            if (!Convert.ToBoolean(TheRow.Cells[ColIsActive.Index].Value))
            {
                if (ShouldWarn) PMBox.Show("ردیف نوبت جاری غیر فعال می باشد!\n" +
                   "برای تغییر اطلاعات ردیف نوبت غیر فعال ابتدا آن را به حالت فعال باز گردانید!",
                   "محدودیت ویرایش!", MessageBoxButtons.OK, MessageBoxIcon.Stop); return false;
            }
            // بررسی دسترسی امكان ویرایش نوبت سایر كاربران
            if (SecurityManager.CurrentUserID > 2 && !_CanAddOrEditOtherUsersShift &&
                Convert.ToBoolean(TheRow.Cells[ColIsAppointed.Index].Value) &&
                    TheRow.Cells[ColUser.Index].Value != null && TheRow.Cells[ColUser.Index].Value != DBNull.Value &&
                    Convert.ToInt16(TheRow.Cells[ColUser.Index].Value) != SecurityManager.CurrentUserID)
            {
                if (ShouldWarn) PMBox.Show("امكان ویرایش نوبت های ثبت شده توسط سایر كاربران را ندارید!",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            // بررسی قفل بودن نوبت و ویرایش آن توسط سایر كاربران
            if (!CheckLockAppointment(RowIndex)) return false;
            return true;
        }
        #endregion

        #region Boolean CheckCurrentCellIsInEditMode()
        /// <summary>
        /// تابعی برای بررسی اینكه آیا سلول جاری در حالت ویرایش است و امكان تغییر وضعیت وجود دارد یا خیر
        /// </summary>
        internal Boolean CheckCurrentCellIsInEditMode()
        {
            if (CurrentCell != null && CurrentCell.ColumnIndex == ColAge.Index && IsCurrentCellDirty) return false;
            EndEdit();
            if (SelectedCells.Count == 0 || IsCurrentCellInEditMode) return false;
            return true;
        }
        #endregion

        #region Boolean CheckCanEditOthersSchByRowID(Int32 RowIndex)
        /// <summary>
        /// تابعی برای بررسی اینكه آیا كاربر جاری می تواند نوبت دیگران را ویرایش كند و
        /// اگر نمی تواند ردیف انتخاب شده برای سایر كاربران است یا نه
        /// </summary>
        internal Boolean CheckCanEditOthersSchByRowID(Int32 RowIndex)
        {
            DataGridViewRow TheRow = Rows[RowIndex];
            // بررسی دسترسی امكان ویرایش نوبت سایر كاربران
            if (SecurityManager.CurrentUserID > 2 && !_CanAddOrEditOtherUsersShift &&
                Convert.ToBoolean(TheRow.Cells[ColIsAppointed.Index].Value) &&
                    TheRow.Cells[ColUser.Index].Value != null && TheRow.Cells[ColUser.Index].Value != DBNull.Value &&
                    Convert.ToInt16(TheRow.Cells[ColUser.Index].Value) != SecurityManager.CurrentUserID)
            {
                PMBox.Show("امكان ویرایش نوبت های ثبت شده توسط سایر كاربران را ندارید!",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            return true;
        }
        #endregion

        #region void ChangeAppointmentRowActivationAccess(Int32 RowIndex)
        /// <summary>
        /// تابعی برای تغییر فعال بودن یك ردیف نوبت به عكس آن
        /// </summary>
        /// <param name="RowIndex">ردیف نوبت در جدول</param>
        internal void ChangeAppointmentRowActivationAccess(Int32 RowIndex)
        {
            if (!CheckCurrentCellIsInEditMode() || !CheckCanEditOthersSchByRowID(RowIndex)) return;
            DataGridViewRow TheRow = Rows[RowIndex];
            try
            {
                Int32 AppointmentID = Convert.ToInt32(TheRow.Cells[ColID.Index].Value);
                if (Convert.ToBoolean(TheRow.Cells[ColIsActive.Index].Value))
                {
                    if (!CheckAppointmentRowEditAccess(RowIndex, true)) return;
                    DBLayerIMS.Manager.DBML.SP_ChangeIsActiveAppointments(AppointmentID, false);
                    DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 103, String.Empty, String.Empty);
                }
                else
                {
                    DialogResult Result = PMBox.Show("آیا مایلید نوبت انتخاب شده را فعال نمایید؟\n" +
                        "با فعال كردن یك نوبت ، امكان ویرایش یا لغو نوبت فعال می گردد.", "پرسش؟",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (Result != DialogResult.Yes) return;
                    DBLayerIMS.Manager.DBML.SP_ChangeIsActiveAppointments(AppointmentID, true);
                    DBLayerIMS.Schedules.InsertSchLogEvents(AppointmentID, 102, String.Empty, String.Empty);
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان تغییر فعال بودن ردیف و اعمال در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            RefreshCurrentDay();
        }
        #endregion

        #region Boolean CheckLockAppointment(Int32 RowIndex)
        /// <summary>
        /// تابع بررسی قفل بودن یك ردیف جدول
        /// </summary>
        /// <param name="RowIndex">شماره ردیف جدول</param>
        /// <returns>قفل بودن یا آزاد بودن نوبت</returns>
        internal Boolean CheckLockAppointment(Int32 RowIndex)
        {
            Int32 AppointmentID = Convert.ToInt32(Rows[RowIndex].Cells[ColID.Index].Value);
            if (!_IsAdvancedLicense) return true;
            Boolean? IsEditing = false;
            try { DBLayerIMS.Manager.DBML.SP_CheckLockAppointments(AppointmentID, ref IsEditing); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن وضعیت نوبت انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            if (IsEditing == true)
            {
                PMBox.Show("این نوبت توسط كاربر دیگری در حال ویرایش می باشد!\n" +
                "ممكن است تداخل اطلاعات بین 2 كاربر ایجاد شود.",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop); return false;
            }
            return true;
        }
        #endregion

        #region void EditAppointment(Int32 RowIndex)
        /// <summary>
        /// تابعی برای فراخوانی فرم ویرایش یك نوبت قبل از بررسی امكان ویرایش
        /// </summary>
        /// <param name="RowIndex">كلید ردیف نوبت در جدول</param>
        internal void EditAppointment(Int32 RowIndex)
        {
            if (!CheckCurrentCellIsInEditMode() || !CheckAppointmentRowEditAccess(RowIndex, true)) return;
            new frmAppointmentsEdit(Convert.ToInt32(Rows[RowIndex].Cells[ColID.Index].Value));
            RefreshCurrentDay();
        }
        #endregion

        #region void ViewAppointmentLog(Int32 RowIndex)
        /// <summary>
        /// تابعی برای فراخوانی فرم مشاهده سابقه یك نوبت
        /// </summary>
        /// <param name="RowIndex">كلید ردیف نوبت در جدول</param>
        internal void ViewAppointmentLog(Int32 RowIndex)
        {
            new frmAppointmentsLog(Convert.ToInt32(Rows[RowIndex].Cells[ColID.Index].Value));
        }
        #endregion

        #region void FreeLockedAppointmentByRowID(Int32 RowIndex)
        /// <summary>
        /// تابعی برای آزاد سازی نوبت قفل شده همراه با تایید اجرا توسط كاربر
        /// </summary>
        /// <param name="RowIndex">كلید ردیف نوبت در جدول</param>
        internal void FreeLockedAppointmentByRowID(Int32 RowIndex)
        {
            #region User Permission Question
            DialogResult Dr = PMBox.Show("آیا مایلید این نوبت را برای ویرایش آزاد نمایید؟\n" +
                "در صورتی كه این نوبت قفل شده باشد ، امكان آزاد سازی آن وجود دارد.\n" +
                "اما در صورتی كه كاربر دیگری در حال ویرایش نوبت جاری باشد این امكان وجود نخواهد داشت.",
                "پرسش", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.No) return;
            #endregion
            try
            {
                DBLayerIMS.Manager.DBML.SP_ChangeLockAppointments(Convert.ToInt32(
                    Rows[RowIndex].Cells[ColID.Index].Value), false);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ذخیره سازی تغییرات در نوبت انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
            RefreshCurrentDay();
        }
        #endregion

        #endregion

    }
}