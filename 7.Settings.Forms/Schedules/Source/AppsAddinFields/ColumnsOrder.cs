#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Schedules.Properties;
#endregion

namespace Sepehr.Settings.Schedules.AppsAddinFields
{
    /// <summary>
    /// فرم مدیریت فیلدهای اطلاعات اضافی نوبت دهی
    /// </summary>
    internal partial class frmColumnsOrder : Form
    {
        #region Fields

        #region List<SchColumnsOrder> _ColumnsOrdersDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<SchColumnsOrder> _ColumnsOrdersDataSource;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmColumnsOrder()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown

        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }

        #endregion

        #region btnUp_Click
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows[0].Index == 0) return;
            Int32 TempInsertIndex = dgvData.SelectedRows[0].Index - 1;
            dgvData.Rows.InsertCopy(dgvData.SelectedRows[0].Index, TempInsertIndex);
            foreach (DataGridViewCell cell in dgvData.Rows[dgvData.SelectedRows[0].Index].Cells)
                dgvData.Rows[dgvData.SelectedRows[0].Index - 2].Cells[cell.ColumnIndex].Value = cell.Value;
            dgvData.Rows.Remove(dgvData.SelectedRows[0]);
            dgvData.Rows[TempInsertIndex].Selected = true;
        }
        #endregion

        #region btnDown_Click
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows[0].Index == dgvData.Rows.Count - 1) return;
            Int32 TempInsertIndex = dgvData.SelectedRows[0].Index;
            dgvData.Rows.InsertCopy(TempInsertIndex, TempInsertIndex + 2);
            foreach (DataGridViewCell cell in dgvData.Rows[dgvData.SelectedRows[0].Index].Cells)
                dgvData.Rows[dgvData.SelectedRows[0].Index + 2].Cells[cell.ColumnIndex].Value = cell.Value;
            dgvData.Rows.Remove(dgvData.SelectedRows[0]);
            dgvData.Rows[TempInsertIndex + 1].Selected = true;
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            // حذف تنظیمات قبلی
            Manager.DBML.SchColumnsOrders.DeleteAllOnSubmit(DBLayerIMS.Schedules.SchAddinColumnsOrdersList);
            if (!Manager.Submit())
            {
                const String ErrorMessage =
                    "امكان حذف اطلاعات ترتیب فیلد های اطلاعات اضافی نوبت دهی از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ثبت تنظیمات جدید
            foreach (DataGridViewRow row in dgvData.Rows)
                if (!InsertSchColumnsOrder(Convert.ToInt16(row.Cells[ColID.Index].Value), Convert.ToByte(row.Index + 4))) return;
            DBLayerIMS.Schedules.SchAddinColumnsOrdersList = null;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
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

            #region btnAccept
            String TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnClose
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        private Boolean FillDataSource()
        {
            List<SchColumnOrder> ResultList = new List<SchColumnOrder>();
            DBLayerIMS.Schedules.SchAddinColumnsOrdersList = null;
            _ColumnsOrdersDataSource = DBLayerIMS.Schedules.SchAddinColumnsOrdersList;
            if (_ColumnsOrdersDataSource == null) return false;
            DBLayerIMS.Schedules.SchAddinColumnsList = null;
            List<SchAddinColumns> AllSchColumns = DBLayerIMS.Schedules.SchAddinColumnsList;
            if (AllSchColumns == null) return false;

            #region Add Fixed Columns
            SchAddinColumns DateTime = new SchAddinColumns();
            DateTime.ID = -9;
            DateTime.FieldName = "[PatientID]";
            DateTime.Title = "زمان تغییر";
            DateTime.TypeID = 0;
            DateTime.Description = "زمان ثبت یا آخرین تغییر";
            AllSchColumns.Insert(0, DateTime);
            SchAddinColumns PatientIX = new SchAddinColumns();
            PatientIX.ID = -8;
            PatientIX.FieldName = "[PatientID]";
            PatientIX.Title = "شماره بیمار";
            PatientIX.TypeID = 0;
            PatientIX.Description = "شماره بیمار پذیرش شده";
            AllSchColumns.Insert(0, PatientIX);
            SchAddinColumns User = new SchAddinColumns();
            User.ID = -7;
            User.FieldName = "[User]";
            User.Title = "كاربر";
            User.TypeID = 0;
            User.Description = "كاربر ثبت كننده بیمار در سیستم";
            AllSchColumns.Insert(0, User);
            SchAddinColumns TelNo2 = new SchAddinColumns();
            TelNo2.ID = -6;
            TelNo2.FieldName = "[TelNo2]";
            TelNo2.Title = "تلفن تماس 2";
            TelNo2.TypeID = 0;
            TelNo2.Description = "دومین شماره تماس بیمار";
            AllSchColumns.Insert(0, TelNo2);
            SchAddinColumns TelNo1 = new SchAddinColumns();
            TelNo1.ID = -5;
            TelNo1.FieldName = "[TelNo1]";
            TelNo1.Title = "تلفن تماس 1";
            TelNo1.TypeID = 0;
            TelNo1.Description = "اولین شماره تماس بیمار";
            AllSchColumns.Insert(0, TelNo1);
            SchAddinColumns Age = new SchAddinColumns();
            Age.ID = -4;
            Age.FieldName = "[Age]";
            Age.Title = "سن";
            Age.TypeID = 1;
            Age.Description = "سن بیمار";
            AllSchColumns.Insert(0, Age);
            SchAddinColumns Sex = new SchAddinColumns();
            Sex.ID = -3;
            Sex.FieldName = "[Sex]";
            Sex.Title = "جنسیت";
            Sex.TypeID = 1;
            Sex.Description = "جنسیت بیمار";
            AllSchColumns.Insert(0, Sex);
            SchAddinColumns LastName = new SchAddinColumns();
            LastName.ID = -2;
            LastName.FieldName = "[LastName]";
            LastName.Title = "نام خانوادگی";
            LastName.TypeID = 0;
            LastName.Description = "نام خانوادگی بیمار";
            AllSchColumns.Insert(0, LastName);
            SchAddinColumns FirstName = new SchAddinColumns();
            FirstName.ID = -1;
            FirstName.FieldName = "[FirstName]";
            FirstName.Title = "نام";
            FirstName.TypeID = 0;
            FirstName.Description = "نام بیمار";
            AllSchColumns.Insert(0, FirstName);
            #endregion

            foreach (SchAddinColumns Item in AllSchColumns)
            {
                SchColumnOrder Temp = new SchColumnOrder();
                Temp.Cols = Item;
                // ReSharper disable AccessToModifiedClosure
                if (_ColumnsOrdersDataSource.Any(Data => Data.ColumnIX == Item.ID))
                { Temp.ColOrder = _ColumnsOrdersDataSource.Where(Data => Data.ColumnIX == Item.ID).First().OrderNumber; }
                else Temp.ColOrder = Convert.ToByte(_ColumnsOrdersDataSource.Count);
                // ReSharper restore AccessToModifiedClosure
                ResultList.Add(Temp);
            }
            foreach (SchColumnOrder source in ResultList.OrderBy(Data => Data.ColOrder))
                dgvData.Rows.Add(source.Cols.ID, source.Cols.Title, source.Cols.Description);
            return true;
        }
        #endregion

        #region Boolean InsertSchColumnsOrder(Int16 ColumnID, Byte OrderIndex)
        /// <summary>
        /// تابعی برای ثبت یك شماره ترتیب ستون برنامه های نوبت دهی در بانك اطلاعات
        /// </summary>
        /// <returns>صحت ثبت اطلاعات یا وقوع خطا</returns>
        private static Boolean InsertSchColumnsOrder(Int16 ColumnID, Byte OrderIndex)
        {
            try { Manager.DBML.SP_InsertColumnsOrder(ColumnID, OrderIndex); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان ثبت ترتیب ستون انتخاب شده برای برنامه های نوبت دهی مورد نظر در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

        #region Classes

        #region class SchColumnOrder
        /// <summary>
        /// كلاس مدیریت ترتیب یك ستون نوبت دهی
        /// </summary>
        private class SchColumnOrder
        {
            /// <summary>
            /// فیلد اطلاعات ستون نوبت دهی
            /// </summary>
            public SchAddinColumns Cols { get; set; }
            /// <summary>
            /// ترتیب ستون نوبت دهی
            /// </summary>
            public Byte ColOrder { get; set; }
        }
        #endregion

        #endregion
    }
}