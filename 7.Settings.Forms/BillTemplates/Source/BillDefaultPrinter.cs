#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.BillTemplates.Properties;
#endregion

namespace Sepehr.Settings.BillTemplates
{
    /// <summary>
    /// فرم تنظیم چاپگر پیش فرض قالب قبوض مراجعات تصویربرداری
    /// </summary>
    public partial class frmBillDefaultPrinter : Form
    {
        #region Fields

        #region String _SubKeyBillDefaultPrinter
        /// <summary>
        /// كلید ذخیره سازی اطلاعات چاپگر پیش فرض قالب قبوض در رجیستری
        /// </summary>
        private const String _SubKeyBillDefaultPrinter = "Software\\Negar\\NegarBillTemplateDefaultPrinter";
        #endregion

        #region Dictionary<Int16, String> _InstalledPrinters
        /// <summary>
        /// دیكشنری نگهدارنده چاپگر های نصب شده بر روی سیستم
        /// </summary>
        private Dictionary<Int16, String> _InstalledPrinters;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmBillDefaultPrinter()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillTemplateData()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region dgvData_CellMouseDoubleClick
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.Button != MouseButtons.Left) return;
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvData.EndEdit();
            if (!SaveData()) return;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region btnHelp_Click
        /// <summary>
        /// روال نمایش راهنمایی برای فرم
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // ToDo: نمایش راهنما تكمیل شود
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            GC.Collect();
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

            #region btnClose
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillFormData()
        /// <summary>
        /// تابع خواندن اطلاعات قالب های قبوض و چاپگر های پیش فرض
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillTemplateData()
        {
            List<BillTemplateClass> BillTemplateClassList = new List<BillTemplateClass>();
            Int16 ID = 1;

            _InstalledPrinters = new Dictionary<Int16, String>();
            _InstalledPrinters.Add(0, "انتخاب نشده");
            foreach (String item in PrinterSettings.InstalledPrinters)
            {
                _InstalledPrinters.Add(ID, item);
                ID++;
            }
            ColDefaultPrinter.DataSource = _InstalledPrinters.ToList();
            ColDefaultPrinter.DisplayMember = "Value";
            ColDefaultPrinter.ValueMember = "Key";
            try
            {
                List<BillTemplate> BillTemplateList =
                    DBLayerIMS.Manager.DBML.BillTemplates.ToList();
                foreach (BillTemplate BillTemp in BillTemplateList)
                {
                    BillTemplateClass NewBillTemplateClass = new BillTemplateClass();
                    NewBillTemplateClass.ID = BillTemp.ID;
                    NewBillTemplateClass.Name = BillTemp.Name;
                    NewBillTemplateClass.IsActive = BillTemp.IsActive;
                    // اگر كلیدی در رجیستری برای این قالب وجود نداشت گزینه "انتخاب نشده" را انتخاب می كند
                    if (String.IsNullOrEmpty(GetPrtNameFromReg(BillTemp.ID.ToString())))
                        NewBillTemplateClass.PrinterID = 0;
                    // اگر وجود داشت
                    else
                    {
                        // و هم چنان این چاپگر نصب بود
                        if (_InstalledPrinters.ContainsValue(GetPrtNameFromReg(BillTemp.ID.ToString())))
                            NewBillTemplateClass.PrinterID = _InstalledPrinters.Where(
                                    Data => Data.Value == GetPrtNameFromReg(BillTemp.ID.ToString())).First().Key;
                        // اگر چاپگر دیگر نصب نبود
                        else NewBillTemplateClass.PrinterID = 0;
                    }
                    BillTemplateClassList.Add(NewBillTemplateClass);
                }
                dgvData.DataSource = BillTemplateClassList.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات قالب های قبوض از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion

            dgvData.Refresh();
            return true;
        }
        #endregion

        #region Boolean SaveDefaultPrtToReg(Int16 BillTemplateID, String PrinterName)
        /// <summary>
        /// ذخیره سازی چاپگر پیش فرض در رجیستری
        /// </summary>
        /// <param name="BillTemplateID">شناسه قالب قبوض</param>
        /// <param name="PrinterName">نام چاپگر پیش فرض</param>
        /// <returns>صحت انجام</returns>
        private Boolean SaveDefaultPrtToReg(Int16 BillTemplateID, String PrinterName)
        {
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyBillDefaultPrinter, true);
                if (MyKey == null)
                {
                    Registry.CurrentUser.CreateSubKey(_SubKeyBillDefaultPrinter);
                    MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyBillDefaultPrinter, true);
                }
                // ReSharper disable PossibleNullReferenceException
                MyKey.SetValue(BillTemplateID.ToString(), PrinterName, RegistryValueKind.String);
            }
            catch (Exception) { return false; }
            return true;
        }
        #endregion

        #region Boolean DeleteDefaultPrtFromReg(String BillTemplateID)
        /// <summary>
        /// حذف اطلاعات چاپگر پیش فرض از رجیستری
        /// </summary>
        /// <param name="BillTemplateID">شناسه قالب قبوض</param>
        /// <returns>صحت انجام</returns>
        private Boolean DeleteDefaultPrtFromReg(String BillTemplateID)
        {
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyBillDefaultPrinter, true);
                if (MyKey == null) return true;
                String Return = MyKey.GetValue(BillTemplateID, String.Empty).ToString();
                if (String.IsNullOrEmpty(Return)) return true;
                MyKey.DeleteValue(BillTemplateID);
            }
            catch (Exception) { return false; }
            return true;
        }
        #endregion

        #region String GetPrtNameFromReg(String BillTemplateID)
        /// <summary>
        /// تابع خواندن نام چاپگر پیش فرض به ازای كلید قالب قبض
        /// </summary>
        /// <returns>نام چاپگر پیش فرض</returns>
        /// <remarks>در صورت وجود خطا در نام چاپگر مقدار خالی باز گردانده می شود</remarks>
        private String GetPrtNameFromReg(String BillTemplateID)
        {
            String ServerAndInstance = String.Empty;
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyBillDefaultPrinter, true);
                if (MyKey == null) return ServerAndInstance;
                ServerAndInstance = MyKey.GetValue(BillTemplateID, String.Empty).ToString();
            }
            catch (Exception) { return ServerAndInstance; }
            return ServerAndInstance;
        }
        #endregion

        #region Boolean SaveData()
        /// <summary>
        /// تابع مدیریت ذخیره سازی اطلاعات در رجیستری
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean SaveData()
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                Int16 BillTemplateID = Convert.ToInt16(row.Cells[ColID.Index].Value);
                Int16 DefaultPrinterID = Convert.ToInt16(row.Cells[ColDefaultPrinter.Index].Value);
                if (DefaultPrinterID == 0)
                {
                    if (!DeleteDefaultPrtFromReg(BillTemplateID.ToString())) return false;
                    continue;
                }
                String a = _InstalledPrinters.Where(Data => Data.Key == DefaultPrinterID).First().Value;
                if (!SaveDefaultPrtToReg(BillTemplateID, a)) return false;
            }
            return true;
        }
        #endregion

        #endregion

        #region class BillTemplateClass
        ///<summary>
        /// كلاس اختصاصی جهت مدیریت منبع داده جدول
        ///</summary>
        public class BillTemplateClass
        {
            #region Fields
            ///<summary>
            ///</summary>
            private Int16 _ID;
            ///<summary>
            ///</summary>
            private Boolean _IsActive;
            ///<summary>
            ///</summary>
            private String _Name;
            ///<summary>
            ///</summary>
            private Int16 _PrinterID;
            #endregion

            #region Props

            #region Int16 ID
            ///<summary>
            /// شناسه قالب قبض
            ///</summary>
            public Int16 ID
            {
                get { return _ID; }
                set { _ID = value; }
            }
            #endregion

            #region  Boolean IsActive
            ///<summary>
            /// فعال بودن قالب قبض
            ///</summary>
            public Boolean IsActive
            {
                get { return _IsActive; }
                set { _IsActive = value; }
            }
            #endregion

            #region String Name
            ///<summary>
            ///نگهدارنده نام قالب قبض
            ///</summary>
            public String Name
            {
                get { return _Name; }
                set { _Name = value; }
            }
            #endregion

            #region Int16 PrinterID
            ///<summary>
            /// نگهدارنده شناسه چاپگر كه توسط برنامه ساخته می شود
            ///</summary>
            public Int16 PrinterID
            {
                get { return _PrinterID; }
                set { _PrinterID = value; }
            }
            #endregion

            #endregion
        }
        #endregion
    }
}