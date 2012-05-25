#region using

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Account
{
    /// <summary>
    /// فایل كمكی كلاس فرم مدیریت حساب برای مدیریت تراكنش ها
    /// </summary>
    public partial class frmAccount
    {

        #region Event Handlers

        #region dgvTransaction_PreviewKeyDown
        private void dgvTransaction_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvTransaction.SelectedCells.Count != 0)
            {
                dgvTransaction_CellMouseClick(1,
                    new DataGridViewCellMouseEventArgs(0, dgvTransaction.SelectedCells[0].RowIndex,
                        Left + Width - 100,
                        Math.Abs(Top) + PanelFormBottom.Top + dgvTransaction.Top + dgvTransaction.ColumnHeadersHeight +
                        dgvTransaction.GetRowDisplayRectangle(dgvTransaction.SelectedCells[0].RowIndex, true).Top + 17,
                        new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
            }
        }
        #endregion

        #region dgvTransaction_CellFormatting
        private void dgvTransaction_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColTransType.Index)
            {
                if (Convert.ToInt32(dgvTransaction[0, e.RowIndex].Value) < 0)
                {
                    e.Value = "بازپرداخت";
                    e.CellStyle.BackColor = Color.LightPink;
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    e.Value = "دریافت";
                    e.CellStyle.BackColor = Color.LemonChiffon;
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
            else if (e.ColumnIndex == ColTransPrice.Index)
            {
                if (Convert.ToInt32(dgvTransaction[0, e.RowIndex].Value) < 0)
                {
                    e.CellStyle.BackColor = Color.LightPink;
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    e.CellStyle.BackColor = Color.LemonChiffon;
                    e.CellStyle.ForeColor = Color.Green;
                }
                e.Value = Math.Abs(Convert.ToInt32(dgvTransaction[ColTransRealPrice.Index, e.RowIndex].Value));
            }
        }
        #endregion

        #region dgvTransaction_CellMouseClick
        private void dgvTransaction_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Point Position = MousePosition;
            // اگر درخواست كننده تابع جاری كلید ویندوز باشد و نه كلیك راست موس محل نمایش نموی كلیك راست تغییر می كند
            if (sender is Int32 && e.RowIndex >= 0 && e.ColumnIndex >= 0) Position = e.Location;
            else if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (CurrentFormState != AccountFormStates.Editing ||
                e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            dgvTransaction.Focus();
            if (((RefTransaction)dgvTransaction.Rows[e.RowIndex].DataBoundItem).Value < 0)
            {
                if (_CanEditPayMoney) btnEditTransaction.Visible = true;
                else btnEditTransaction.Visible = false;
                if (_CanRemovePays) btnRemoveTransaction.Visible = true;
                else btnRemoveTransaction.Visible = false;
                if (!_CanEditPayMoney && !_CanRemovePays) return;
            }
            else
            {
                if (_CanEditRecievesMoney) btnEditTransaction.Visible = true;
                else btnEditTransaction.Visible = false;
                if (_CanRemoveRecieves) btnRemoveTransaction.Visible = true;
                else btnRemoveTransaction.Visible = false;
                if (!_CanEditRecievesMoney && !_CanRemoveRecieves) return;
            }
            dgvTransaction.Rows[e.RowIndex].Selected = true;
            cmsdgvTransactions.Popup(Position);
        }
        #endregion

        #region dgvTransaction_CellMouseDoubleClick
        private void dgvTransaction_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CurrentFormState == AccountFormStates.Viewing ||
                e.RowIndex < 0 || e.ColumnIndex < 0 || e.Button != MouseButtons.Left) return;
            if (((RefTransaction)dgvTransaction.Rows[e.RowIndex].DataBoundItem).Value < 0
                && !_CanEditPayMoney) return;
            if (((RefTransaction)dgvTransaction.Rows[e.RowIndex].DataBoundItem).Value >= 0
                && !_CanEditRecievesMoney) return;
            EditTransaction(e.RowIndex);
        }
        #endregion

        #region btnAddTransaction_Click
        /// <summary>
        /// روال افزودن دریافت یا بازپرداخت به لیست تراكنش های مراجعه جاری
        /// </summary>
        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            if (CurrentFormState == AccountFormStates.Viewing) return;
            #region Load Form
            frmManageTrans MyForm;
            // اگر كلید دریافت فشرده شود
            if (((Control)sender).Tag.ToString() == "Recieve")
                MyForm = new frmManageTrans(false, _CurrentRefID, false, _CurrentRefRecievableValue);
            // اگر كلید بازپرداخت فشرده شود
            else MyForm = new frmManageTrans(true, _CurrentRefID, false, _CurrentRefRecievableValue);
            if (MyForm.DialogResult != DialogResult.OK) { MyForm.Dispose(); return; }
            #endregion

            #region Insert Members To "RefTransaction"
            RefTransaction NewRefTran = new RefTransaction();
            NewRefTran.ReferralIX = _CurrentRefID;
            // تراكنش جدید همواره فعال است
            NewRefTran.IsActive = true;
            // تخصیص كلید صندوق تراكنش
            if (MyForm.cboCash.SelectedValue == null) NewRefTran.CashIX = null;
            else NewRefTran.CashIX = Convert.ToInt16(MyForm.cboCash.SelectedValue);
            // كلید صندوقدار تراكنش كه كاربر جاری می باشد
            NewRefTran.CashierIX = SecurityManager.CurrentUserID;
            // تنظیم زمان تراكنش
            NewRefTran.OccuredDate = new DateTime(MyForm.TransDate.SelectedDateTime.Value.Year,
                MyForm.TransDate.SelectedDateTime.Value.Month, MyForm.TransDate.SelectedDateTime.Value.Day,
                MyForm.TransTime.Value.Hour, MyForm.TransTime.Value.Minute, MyForm.TransTime.Value.Second);
            // اگر تراكنش دریافت باشد ، مقدار مثبت و در غیر این صورت مقدار منفی خواهد بود
            if (Convert.ToInt32(MyForm.PanelType.Tag) == 1) NewRefTran.Value = MyForm.txtValue.Value;
            else NewRefTran.Value = (MyForm.txtValue.Value) * (-1);
            // توضیحات تراكنش
            NewRefTran.Description = MyForm.txtDescription.Text.Trim();
            #region Set RefTransaction Additional Data
            // اطلاعات اضافی تراكنش
            if (!MyForm.cBoxInCash.Checked)
            {
                RefTransAddinData RefTransAdditionalData = new RefTransAddinData();
                RefTransAdditionalData.RefTransactionIX = 0;
                if (MyForm.cBoxInCash.Checked) RefTransAdditionalData.PayType = 0;
                else if (MyForm.cBoxInCheck.Checked) RefTransAdditionalData.PayType = 1;
                else if (MyForm.cBoxInBill.Checked) RefTransAdditionalData.PayType = 2;
                else RefTransAdditionalData.PayType = 3;
                if (MyForm.ManageTransDescForm != null)
                {
                    if (MyForm.ManageTransDescForm.cboBankName.SelectedIndex != 0)
                        RefTransAdditionalData.BankIX = Convert.ToInt16(MyForm.ManageTransDescForm.cboBankName.SelectedValue);
                    RefTransAdditionalData.BranchName = MyForm.ManageTransDescForm.txtBranchName.Text.Trim();
                    RefTransAdditionalData.BranchCode = MyForm.ManageTransDescForm.txtBranchCode.Text.Trim();
                    RefTransAdditionalData.CheckDate = MyForm.ManageTransDescForm.CheckDate.SelectedDateTime;
                    RefTransAdditionalData.CheckNumber = MyForm.ManageTransDescForm.txtCheckNumber.Text.Trim();
                    if (MyForm.ManageTransDescForm.cBox1.Checked) RefTransAdditionalData.AccountType = 1;
                    else if (MyForm.ManageTransDescForm.cBox2.Checked) RefTransAdditionalData.AccountType = 2;
                    else RefTransAdditionalData.AccountType = 3;
                    RefTransAdditionalData.AccountNumber = MyForm.ManageTransDescForm.txtAccountNumber.Text.Trim();
                    RefTransAdditionalData.Description = MyForm.ManageTransDescForm.txtAccountNumber.Text.Trim();
                }
                NewRefTran.RefTransactionAdditionalData = RefTransAdditionalData;
            }
            #endregion
            // افزودن تراكنش به لیست تراكنش های مراجعه جاری
            _CurrentRefTransaction.Add(NewRefTran);
            DBLayerIMS.Manager.DBML.RefTransactions.InsertOnSubmit(NewRefTran);
            // به روز رسانی جدول تراكنش های مراجعه جاری روی فرم
            dgvTransaction.DataSource = _CurrentRefTransaction.ToList();
            dgvTransaction.Refresh();
            #endregion
            // محاسبه مجدد قیمت های مراجعه
            ReCalculateRefPrices();
            _IsCurrentFormModified = true;
            dgvTransaction.Focus();
        }
        #endregion

        #region btnEditTransaction_Click
        private void btnEditTransaction_Click(object sender, EventArgs e)
        {
            if (!dgvTransaction.Focused ||
                CurrentFormState == AccountFormStates.Viewing || dgvTransaction.SelectedRows.Count == 0) return;
            EditTransaction(dgvTransaction.SelectedRows[0].Index);
        }
        #endregion

        #region btnRemoveTransaction_Click
        private void btnRemoveTransaction_Click(object sender, EventArgs e)
        {
            if (!dgvTransaction.Focused || CurrentFormState == AccountFormStates.Viewing ||
                dgvTransaction.SelectedRows.Count == 0) return;
            Boolean CanRemove = false;
            if (((RefTransaction)dgvTransaction.SelectedRows[0].DataBoundItem).Value >= 0)
            { if (_CanRemoveRecieves) CanRemove = true; }
            else if (_CanRemovePays) CanRemove = true;
            if (!CanRemove) return;
            DialogResult Dr = PMBox.Show("آیا از حذف كردن تراكنش انتخاب شده اطمینان دارید؟", "هشدار!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.No) return;
            _CurrentRefTransaction.Remove((RefTransaction)dgvTransaction.SelectedRows[0].DataBoundItem);
            DBLayerIMS.Manager.DBML.RefTransactions.DeleteOnSubmit(
                (RefTransaction)dgvTransaction.SelectedRows[0].DataBoundItem);
            dgvTransaction.DataSource = _CurrentRefTransaction.ToList();
            dgvTransaction.Refresh();
            ReCalculateRefPrices();
            _IsCurrentFormModified = true;
            dgvTransaction.Focus();
        }
        #endregion

        #endregion

        #region Methods

        #region void EditTransaction(Int32 dgvTransRowID)
        /// <summary>
        /// تابعی برای ویرایش یك ردیف از جدول تراكنش های مراجعه جاری
        /// </summary>
        /// <param name="dgvTransRowID">كلید ردیف تراكنش</param>
        private void EditTransaction(Int32 dgvTransRowID)
        {
            Int32 TransactionID = ((RefTransaction)dgvTransaction.Rows[dgvTransRowID].DataBoundItem).ID;
            #region Show Form
            if (TransactionID == 0)
            {
                PMBox.Show("این ردیف به تازگی افزوده شده و در بانك اطلاعاتی اعمال نشده است.\n" +
                    "ابتدا تغییرات را ثبت نمایید ، سپس اقدام به ویرایش نمایید یا " +
                    "ردیف مورد نظر را حذف نموده و مجدداً مبلغ مورد نظر را دریافت نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Hand); return;
            }
            frmManageTrans MyForm =
                new frmManageTrans(Convert.ToInt32(TransactionID), _CurrentRefRecievableValue);
            if (MyForm.DialogResult != DialogResult.OK)
            {
                MyForm.Dispose();
                return;
            }
            #endregion

            #region Update Members To RefTransaction
            DateTime TransDate = new DateTime(MyForm.TransDate.SelectedDateTime.Value.Year,
                MyForm.TransDate.SelectedDateTime.Value.Month, MyForm.TransDate.SelectedDateTime.Value.Day,
                MyForm.TransTime.Value.Hour, MyForm.TransTime.Value.Minute, MyForm.TransTime.Value.Second);
            ((RefTransaction)dgvTransaction.SelectedRows[0].DataBoundItem).CashIX = (Int16?)MyForm.cboCash.SelectedValue;
            ((RefTransaction)dgvTransaction.SelectedRows[0].DataBoundItem).OccuredDate = TransDate;
            if (Convert.ToInt32(MyForm.PanelType.Tag) == 1)
                ((RefTransaction)dgvTransaction.SelectedRows[0].DataBoundItem).Value = MyForm.txtValue.Value;
            else ((RefTransaction)dgvTransaction.SelectedRows[0].DataBoundItem).Value = (-1) * MyForm.txtValue.Value;
            ((RefTransaction)dgvTransaction.SelectedRows[0].DataBoundItem).Description = MyForm.txtDescription.Text;

            #region Set RefTransaction Additional Data
            // اطلاعات اضافی تراكنش
            if (MyForm.cBoxInCash.Checked && DBLayerIMS.Manager.DBML.RefTransAddinDatas.
                Where(Data => Data.RefTransactionIX == TransactionID).ToList().Count != 0)
            {
                DBLayerIMS.Manager.DBML.RefTransAddinDatas.DeleteOnSubmit(
                    ((RefTransaction)dgvTransaction.SelectedRows[0].DataBoundItem).RefTransactionAdditionalData);
            }
            else if (!MyForm.cBoxInCash.Checked)
            {
                RefTransAddinData RefTransAdditionalData = new RefTransAddinData();
                RefTransAdditionalData.RefTransactionIX = 0;
                if (MyForm.cBoxInCash.Checked) RefTransAdditionalData.PayType = 0;
                else if (MyForm.cBoxInCheck.Checked) RefTransAdditionalData.PayType = 1;
                else if (MyForm.cBoxInBill.Checked) RefTransAdditionalData.PayType = 2;
                else RefTransAdditionalData.PayType = 3;
                if (MyForm.ManageTransDescForm != null)
                {
                    if (MyForm.ManageTransDescForm.cboBankName.SelectedIndex != 0)
                        RefTransAdditionalData.BankIX = Convert.ToInt16(MyForm.ManageTransDescForm.cboBankName.SelectedValue);
                    RefTransAdditionalData.BranchName = MyForm.ManageTransDescForm.txtBranchName.Text.Trim();
                    RefTransAdditionalData.BranchCode = MyForm.ManageTransDescForm.txtBranchCode.Text.Trim();
                    RefTransAdditionalData.CheckDate = MyForm.ManageTransDescForm.CheckDate.SelectedDateTime;
                    RefTransAdditionalData.CheckNumber = MyForm.ManageTransDescForm.txtCheckNumber.Text.Trim();
                    if (MyForm.ManageTransDescForm.cBox1.Checked) RefTransAdditionalData.AccountType = 1;
                    else if (MyForm.ManageTransDescForm.cBox2.Checked) RefTransAdditionalData.AccountType = 2;
                    else RefTransAdditionalData.AccountType = 3;
                    RefTransAdditionalData.AccountNumber = MyForm.ManageTransDescForm.txtAccountNumber.Text.Trim();
                    RefTransAdditionalData.Description = MyForm.ManageTransDescForm.txtAccountNumber.Text.Trim();
                }
                ((RefTransaction)dgvTransaction.SelectedRows[0].DataBoundItem).RefTransactionAdditionalData =
                    RefTransAdditionalData;
            }
            #endregion

            #endregion
            dgvTransaction.Refresh();
            ReCalculateRefPrices();
            _IsCurrentFormModified = true;
            dgvTransaction.Focus();
        }
        #endregion

        #endregion

    }
}