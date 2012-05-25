#region using
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms
{
    /// <summary>
    /// فرم  خدمات
    /// </summary>
    internal partial class frmManageServInterCode : Office2007Form
    {

        #region Fields

        #region  private const string _SavedDataFilePath
        /// <summary>
        /// نام فایل ایكس ام ال برای ذخیره  و یا استفاده از آن
        /// </summary>
        private const string _SavedDataFilePath = "ServiceInternationalCode.Xml";
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmManageServInterCode()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            ColICode.ValueType = typeof(String);
            Opacity = 0.01;
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            if (!FillBaseDataSource()) { Close(); return; }
            SetControlsToolTipTexts();
            Opacity = 1;
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

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            dgvData.EndEdit();
            btnAccept.Focus();
            // اگر فایل وجود نداشته باشد آن را می سازد
            if (!File.Exists(_SavedDataFilePath)) File.Create(_SavedDataFilePath).Close();
            if (SaveDataToFile()) DialogResult = DialogResult.OK;
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

            #region btnHelp
            String TooltipText = "نمایش آموزش كاربری فرم.\r\n" +
                                 "این راهنمای كاربری به شما در مورد نحوه عملكرد فرم كمك می نماید.";
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                                                                        Resources.Help_Blue, Resources.SepehrLogo, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = "انصراف از اعمال تغییرات و خروج از فرم.\r\n" +
                          "در صورت اجرای این فرمان ، بدون ذخیره سازی اطلاعات وارد شده ، فرم بسته می شود.";
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                                                                        Resources.Help_Blue, Resources.SepehrLogo, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region Boolean FillBaseDataSource()
        /// <summary>
        /// تابع پر كردن اطلاعات پایه فرم 
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillBaseDataSource()
        {
            try
            {
                dgvData.DataSource = DBLayerIMS.Services.ServicesList.Where(Data => Data.IsActive)
                    .OrderBy(Data => Convert.ToInt32(Data.Code)).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "خواندن اطلاعات خدمت از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "IDMF - AR", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                DialogResult = DialogResult.Cancel;
                return false;
            }
            #endregion
            if (File.Exists(_SavedDataFilePath) && !ReadSavedDataFromFile()) return false;
            return true;
        }
        #endregion

        #region Boolean ReadSavedDataFromFile()
        /// <summary>
        /// خواندن اطلاعات ذخیره شده قبلی از فایل
        /// </summary>
        private Boolean ReadSavedDataFromFile()
        {
            if (!File.Exists(_SavedDataFilePath))
            {
                PMBox.Show("فایل اصلی تنظیمات كد بین المللی خدمات یافت نشد!\n" +
                    "لطفاً تنظیمات را مجدداً اعمال نمایید.", "هشدار!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            try
            {
                DataTable MyDataTable = new DataTable("TableName");
                MyDataTable.Columns.Add("RowID", typeof(Int32));
                MyDataTable.Columns.Add("InterCode", typeof(String));
                MyDataTable.ReadXml(_SavedDataFilePath);
                for (Int16 i = 0; i < dgvData.Rows.Count; i++)
                {
                    DataRow[] SelectedData = MyDataTable.Select("RowID = " + dgvData.Rows[i].Cells[ColID.Index].Value);
                    if (SelectedData.Length != 0 && SelectedData[0]["InterCode"] != null &&
                        SelectedData[0]["InterCode"] != DBNull.Value)
                        dgvData[ColICode.Index, i].Value = SelectedData[0]["InterCode"].ToString();
                }
                dgvData.Refresh();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "خواندن اطلاعات از فایل ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "IDMF - AR", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                DialogResult = DialogResult.Cancel;
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean SaveDataToFile()
        /// <summary>
        /// ذخیره اطلاعات در فایل تنظیمات
        /// </summary>
        private Boolean SaveDataToFile()
        {
            try
            {
                DataTable MyDataTable = new DataTable("TableName");
                MyDataTable.Columns.Add("RowID", typeof(Int32));
                MyDataTable.Columns.Add("InterCode", typeof(String));
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    String InternationalCode;
                    if (row.Cells[ColICode.Index].Value == null) InternationalCode = "0000000";
                    else InternationalCode = row.Cells[ColICode.Index].Value.ToString();
                    MyDataTable.Rows.Add(Convert.ToInt32(row.Cells[ColID.Index].Value), InternationalCode);
                }
                MyDataTable.WriteXml(_SavedDataFilePath);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "نوشتن اطلاعات در فایل ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا كاربر جاری ویندوز فاقد دسترسی نوشتن فایل در سیستم می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "IDMF - AR", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}