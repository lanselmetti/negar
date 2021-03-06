﻿#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Accounts.Properties;
#endregion

namespace Sepehr.Settings.Accounts
{
    /// <summary>
    /// فرم مدیریت انواع هزینه ها 
    /// </summary>
    public partial class frmCostDiscountTypes : Form
    {

        #region Fields

        #region IOrderedQueryable<CostsAndDiscountsType> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private IOrderedQueryable<CostsAndDiscountsType> _DataSource;
        #endregion

        #region Boolean _IsGridValuesChanged
        /// <summary>
        /// تعیین ویرایش شدن فرم توسط كاربر
        /// </summary>
        private Boolean _IsGridValuesChanged;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmCostDiscountTypes()
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
            _IsGridValuesChanged = false;
            cBoxWithInActives.Checked = false;
        }
        #endregion

        #region dgvData_CellValidating
        private void dgvData_CellValidating_1(object sender, DataGridViewCellValidatingEventArgs e)
        {
            #region Check Medical ID
            if (e.ColumnIndex == ColName.Index)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (!row.IsNewRow && row.Cells[e.ColumnIndex].Value != null &&
                        row.Cells[e.ColumnIndex].Value != DBNull.Value &&
                        row.Index != e.RowIndex &&
                        e.FormattedValue != null && e.FormattedValue != DBNull.Value &&
                        row.Cells[e.ColumnIndex].Value.ToString().Trim().ToLower() == e.FormattedValue.ToString().ToLower())
                    {
                        PMBox.Show("نام هزینه یا تخفیف وارد شده تكراریست! لطفاً مقدار وارد شده را بررسی نمایید.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvData.Focus();
                        // dgvData.Rows[e.RowIndex].Selected = true;
                        e.Cancel = true;
                        return;
                    }
                }
            }
            #endregion
        }

        #endregion

        #region dgvData_CellValueChanged
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _IsGridValuesChanged = true;
        }
        #endregion

        #region dgvData_DefaultValuesNeeded
        void dgvData_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[ColIsActive.Name].Value = true;
            e.Row.Cells[ColName.Name].Value = "عنوان جدید";
            e.Row.Cells[ColIsCost.Name].Value = false;
            e.Row.Cells[ColLimit.Name].Value = "0";
        }
        #endregion

        #region dgvData_UserAddedRow
        private void dgvData_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvData.AllowUserToAddRows = false;
        }
        #endregion

        #region cBoxWithInActives_CheckedChanged
        private void cBoxWithInActives_CheckedChanged(object sender, EventArgs e)
        {
            if (_IsGridValuesChanged)
            {
                DialogResult Dr = PMBox.Show(
                    "در صورتی كه ردیفی را حذف كرده باشید باید قبل از تغییر وضعیت نمایش فرم ، " +
                    "اطلاعات را در بانك اعمال نمایید. آیا مایلید بدون اعمال تغییرات ، " +
                    "در بانك ، نمای فرم تغییر كند؟", "هشدار!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) return;
            }
            if (cBoxWithInActives.Checked) dgvData.DataSource = _DataSource.ToList();
            else dgvData.DataSource = _DataSource.Where(FilteredData => FilteredData.IsActive);
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvData.AllowUserToAddRows = true;
            dgvData.Rows[dgvData.Rows.Count - 1].Cells[1].Selected = true;
            dgvData.Focus();
            dgvData.BeginEdit(true);
        }
        #endregion

        #region btnApply_Click
        private void btnApply_Click(object sender, EventArgs e)
        {
            btnAccept.Focus();
            dgvData.EndEdit();
            #region Validations
            // تعریف لیست آیتم های چك شده برای موارد تكراری
            List<String> CheckedItems = new List<String>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                // نادیده گرفتن ردیف افزوده شده ی جدید
                if (row.IsNewRow) continue;
                #region Duplicate Rows
                // بررسی عدم وجود ردیف جاری در ردیف های بررسی شده
                if (!CheckedItems.Contains(row.Cells[ColName.Index].Value.ToString().Trim()))
                {
                    // جستجوی مجدد در بین تمام آیتم های جدول
                    foreach (DataGridViewRow TempRow in dgvData.Rows)
                        if (!TempRow.IsNewRow && // ردیف جدید نباشد
                            row.Index != TempRow.Index && // با ردیف جاری برای مقایسه برابر نباشد
                            TempRow.Cells[ColName.Index].Value != null && // مقدار آن تهی نباشد
                            TempRow.Cells[ColName.Index].Value != DBNull.Value &&
                            // اگر هر دو ردیف برابر باشند
                            TempRow.Cells[ColName.Index].Value.ToString().Trim().ToLower() ==
                            row.Cells[ColName.Index].Value.ToString().Trim().ToLower())
                        {

                            PMBox.Show("در بین هزینه یا تخفیف های وارد شده ، نام گروه تكراری وجود دارد!\n" +
                                "لطفاً اصلاح نمایید.", "خطا!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            row.Cells[ColName.Index].Selected = true;
                            return;
                        }
                    // افزودن ردیف غیر تكراری به لیست آیتم های چك شده
                    CheckedItems.Add(row.Cells[ColName.Index].Value.ToString().Trim());
                }
                #endregion
            }
            #endregion
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان به روز رسانی بانك بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا نام تكراری وارد ننموده اید؟\n" +
                    "2. آیا ردیف جدیدی فاقد نام وارد ننموده اید؟\n" +
                    "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _IsGridValuesChanged = false;
            if (!FillDataSource()) { Close(); return; }
            dgvData.Focus();
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvData.EndEdit();
            btnAccept.Focus();
            #region Validations
            // تعریف لیست آیتم های چك شده برای موارد تكراری
            List<String> CheckedItems = new List<String>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                // نادیده گرفتن ردیف افزوده شده ی جدید
                if (row.IsNewRow) continue;
                #region Duplicate Rows
                // بررسی عدم وجود ردیف جاری در ردیف های بررسی شده
                if (!CheckedItems.Contains(row.Cells[ColName.Index].Value.ToString().Trim()))
                {
                    // جستجوی مجدد در بین تمام آیتم های جدول
                    foreach (DataGridViewRow TempRow in dgvData.Rows)
                        if (!TempRow.IsNewRow && // ردیف جدید نباشد
                            row.Index != TempRow.Index && // با ردیف جاری برای مقایسه برابر نباشد
                            TempRow.Cells[ColName.Index].Value != null && // مقدار آن تهی نباشد
                            TempRow.Cells[ColName.Index].Value != DBNull.Value &&
                            // اگر هر دو ردیف برابر باشند
                            TempRow.Cells[ColName.Index].Value.ToString().Trim().ToLower() ==
                            row.Cells[ColName.Index].Value.ToString().Trim().ToLower())
                        {

                            PMBox.Show("در بین هزینه یا تخفیف های وارد شده ، نام گروه تكراری وجود دارد!\n" +
                                "لطفاً اصلاح نمایید.", "خطا!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            row.Cells[ColName.Index].Selected = true;
                            return;
                        }
                    // افزودن ردیف غیر تكراری به لیست آیتم های چك شده
                    CheckedItems.Add(row.Cells[ColName.Index].Value.ToString().Trim());
                }
                #endregion
            }
            #endregion
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان به روز رسانی بانك بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا نام تكراری وارد ننموده اید؟\n" +
                    "2. آیا ردیف جدیدی فاقد نام وارد ننموده اید؟\n" +
                    "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            _IsGridValuesChanged = false;
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
            if (_IsGridValuesChanged)
            {
                DialogResult Dr = PMBox.Show("آیا از اعمال تغییرات منصرف شده اید؟", "هشدار!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
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

            #region cBoxWithInActives
            String TooltipText = ToolTipManager.GetText("cBoxWithInActivesRefCDTypes", "IMS");
            FormToolTip.SetSuperTooltip(cBoxWithInActives,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnCancel", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnApply
            TooltipText = ToolTipManager.GetText("btnApply", "IMS");
            FormToolTip.SetSuperTooltip(btnApply, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAdd
            TooltipText = ToolTipManager.GetText("btnAddCDTypes", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader,
                TooltipFooter, TooltipText, Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات تخفیف ها و هزینه ها از بانك
        /// </summary>
        private Boolean FillDataSource()
        {
            try { _DataSource = DBLayerIMS.Manager.DBML.CostsAndDiscountsTypes.OrderBy(Data => Data.Name); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات تخفیف ها و هزینه ها از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Accounts Settings", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}