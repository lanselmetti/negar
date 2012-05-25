#region using

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Account
{
    /// <summary>
    /// فایل كمكی كلاس فرم مدیریت حساب برای مدیریت تخفیف ها و هزینه ها
    /// </summary>
    public partial class frmAccount
    {

        #region dgvCostDiscounts Event Handlers

        #region dgvCostDiscounts_PreviewKeyDown
        private void dgvCostDiscounts_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvCostDiscounts.SelectedCells.Count != 0)
            {
                dgvCostDiscounts_CellMouseClick(1,
                    new DataGridViewCellMouseEventArgs(0, dgvCostDiscounts.SelectedCells[0].RowIndex,
                        Left + dgvCostDiscounts.Width - 100,
                        Math.Abs(Top) + PanelFormBottom.Top + dgvCostDiscounts.Top + dgvCostDiscounts.ColumnHeadersHeight +
                        dgvCostDiscounts.GetRowDisplayRectangle(dgvCostDiscounts.SelectedCells[0].RowIndex, true).Top + 17,
                        new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
            }
        }
        #endregion

        #region dgvCostDiscounts_CellMouseClick
        private void dgvCostDiscounts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Point Position = MousePosition;
            // اگر درخواست كننده تابع جاری كلید ویندوز باشد و نه كلیك راست موس محل نمایش نموی كلیك راست تغییر می كند
            if (sender is Int32 && e.RowIndex >= 0 && e.ColumnIndex >= 0) Position = e.Location;
            else if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (CurrentFormState != AccountFormStates.Editing ||
                e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            dgvCostDiscounts.Focus();
            if (((RefCostsAndDiscount)dgvCostDiscounts.Rows[e.RowIndex].DataBoundItem).
                CostsAndDiscountsType.IsCost)
            {
                if (_CanEditCosts) btnEditCostDiscount.Visible = true;
                else btnEditCostDiscount.Visible = false;
                if (_CanRemoveCosts) btnRemoveCostDiscount.Visible = true;
                else btnRemoveCostDiscount.Visible = false;
                if (!_CanEditCosts && !_CanRemoveCosts) return;
            }
            else
            {
                if (_CanEditDiscounts) btnEditCostDiscount.Visible = true;
                else btnEditCostDiscount.Visible = false;
                if (_CanRemoveDiscounts) btnRemoveCostDiscount.Visible = true;
                else btnRemoveCostDiscount.Visible = false;
                if (!_CanEditDiscounts && !_CanRemoveDiscounts) return;
            }
            dgvCostDiscounts.Rows[e.RowIndex].Selected = true;
            cmsdgvCostOrDiscount.Popup(Position);
        }
        #endregion

        #region dgvCostDiscounts_CellMouseDoubleClick
        private void dgvCostDiscounts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CurrentFormState == AccountFormStates.Viewing ||
                e.RowIndex < 0 || e.ColumnIndex < 0 || e.Button != MouseButtons.Left) return;
            if (((RefCostsAndDiscount)dgvCostDiscounts.Rows[e.RowIndex].DataBoundItem).CostsAndDiscountsType.IsCost
                && !_CanEditCosts) return;
            if (!((RefCostsAndDiscount)dgvCostDiscounts.Rows[e.RowIndex].DataBoundItem).CostsAndDiscountsType.IsCost
                && !_CanEditDiscounts) return;
            EditCostOrDiscount(e.RowIndex);
        }
        #endregion

        #region btnAddCostOrDiscount_Click
        private void btnAddCostOrDiscount_Click(object sender, EventArgs e)
        {
            if (CurrentFormState == AccountFormStates.Viewing) return;
            #region Load Form
            frmManageCostOrDiscount MyForm;
            if (((Control)sender).Tag.ToString() == "Cost")
            {
                MyForm = new frmManageCostOrDiscount(true, true);
                if (!MyForm.IsDisposed) MyForm.ShowDialog();
            }
            else
            {
                MyForm = new frmManageCostOrDiscount(false, true);
                if (!MyForm.IsDisposed) MyForm.ShowDialog();
            }
            if (MyForm.IsDisposed) return;
            if (MyForm.DialogResult != DialogResult.OK) { MyForm.Dispose(); return; }
            #endregion

            #region Check Cost Or Discount Limitation
            Int32 TypeLimitation = DBLayerIMS.Account.CostAndDiscountFullList.
                Where(Data => Data.ID == Convert.ToInt16(MyForm.cboType.SelectedValue)).First().Limitation;
            if (TypeLimitation != 0)
            {
                Int32 TotalCount = 0;
                foreach (RefCostsAndDiscount Values in _CurrentRefCostsDiscounts)
                {
                    if (Values.CostIXOrDiscountIX == Convert.ToInt16(MyForm.cboType.SelectedValue))
                        TotalCount += Values.Value;
                }
                TotalCount += MyForm.txtValue.Value;
                if (TotalCount > TypeLimitation)
                {
                    PMBox.Show("امكان افزودن تخفیف یا هزینه مورد نظر ، بیش از سقف تعیین شده وجود ندارد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            #endregion

            #region Insert Members To CostOrDiscount
            RefCostsAndDiscount NewCostDiscount = new RefCostsAndDiscount();
            NewCostDiscount.ReferralIX = _CurrentRefID;
            NewCostDiscount.CashierIX = SecurityManager.CurrentUserID;
            NewCostDiscount.Date = new DateTime(MyForm.RegDate.SelectedDateTime.Value.Year,
            MyForm.RegDate.SelectedDateTime.Value.Month, MyForm.RegDate.SelectedDateTime.Value.Day,
            MyForm.RegTime.Value.Hour, MyForm.RegTime.Value.Minute, MyForm.RegTime.Value.Second);
            NewCostDiscount.Value = MyForm.txtValue.Value;
            NewCostDiscount.CostIXOrDiscountIX = Convert.ToInt16(MyForm.cboType.SelectedValue);
            CostsAndDiscountsType NewType = DBLayerIMS.Manager.DBML.CostsAndDiscountsTypes.
                Where(Data => Data.ID == Convert.ToInt16(MyForm.cboType.SelectedValue)).First();
            NewCostDiscount.CostsAndDiscountsType = NewType;
            NewCostDiscount.Description = MyForm.txtDescription.Text.Trim();
            _CurrentRefCostsDiscounts.Add(NewCostDiscount);
            DBLayerIMS.Manager.DBML.RefCostsAndDiscounts.InsertOnSubmit(NewCostDiscount);
            dgvCostDiscounts.DataSource = _CurrentRefCostsDiscounts.ToList();
            #endregion
            dgvCostDiscounts.Refresh();
            ReCalculateRefPrices();
            _IsCurrentFormModified = true;
            dgvCostDiscounts.Focus();
        }
        #endregion

        #region btnEditCostDiscount_Click
        private void btnEditCostDiscount_Click(object sender, EventArgs e)
        {
            if (!dgvCostDiscounts.Focused ||
                CurrentFormState == AccountFormStates.Viewing || dgvCostDiscounts.SelectedRows.Count == 0) return;
            EditCostOrDiscount(dgvCostDiscounts.SelectedRows[0].Index);
        }
        #endregion

        #region btnRemoveCostDiscount_Click
        private void btnRemoveCostDiscount_Click(object sender, EventArgs e)
        {
            if (!dgvCostDiscounts.Focused || CurrentFormState == AccountFormStates.Viewing ||
                dgvCostDiscounts.SelectedRows.Count == 0) return;
            Boolean CanRemove = false;
            if (((RefCostsAndDiscount)dgvCostDiscounts.SelectedRows[0].DataBoundItem).
                CostsAndDiscountsType.IsCost)
            { if (_CanRemoveCosts) CanRemove = true; }
            else if (_CanRemoveDiscounts) CanRemove = true;
            if (!CanRemove) return;
            DialogResult Dr = PMBox.Show("آیا از حذف كردن تخفیف/هزینه انتخاب شده اطمینان دارید؟", "هشدار!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.No) return;
            _CurrentRefCostsDiscounts.Remove(
                (RefCostsAndDiscount)dgvCostDiscounts.SelectedRows[0].DataBoundItem);
            DBLayerIMS.Manager.DBML.RefCostsAndDiscounts.DeleteOnSubmit(
                (RefCostsAndDiscount)dgvCostDiscounts.SelectedRows[0].DataBoundItem);
            dgvCostDiscounts.DataSource = _CurrentRefCostsDiscounts.ToList();
            dgvCostDiscounts.Refresh();
            ReCalculateRefPrices();
            _IsCurrentFormModified = true;
            dgvCostDiscounts.Focus();
        }
        #endregion

        #region txtCostAndDiscountValue_PreviewKeyDown
        private void txtCostAndDiscountValue_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData != Keys.Enter || !(cboCostAndDiscountType.SelectedIndex >= 0)) return;
            if (sender.Equals(txtCostAndDiscountValue)) { if (txtCostAndDiscountValue.Value == 0) return; }
            else if (txtCDPercent.Value == 0) return;

            #region Check Cost Or Discount Limitation
            Int32 TypeLimitation = DBLayerIMS.Account.CostAndDiscountFullList.
                Where(Data => Data.ID == Convert.ToInt16(cboCostAndDiscountType.SelectedValue)).First().Limitation;
            if (TypeLimitation != 0)
            {
                Int32 TotalCount = 0;
                foreach (RefCostsAndDiscount Values in _CurrentRefCostsDiscounts)
                {
                    if (Values.CostIXOrDiscountIX == Convert.ToInt16(cboCostAndDiscountType.SelectedValue))
                        TotalCount += Values.Value;
                }
                if (sender.Equals(txtCostAndDiscountValue)) TotalCount += txtCostAndDiscountValue.Value;
                else TotalCount += _CurrentRefRecievableValue * txtCDPercent.Value / 100;
                if (TotalCount > TypeLimitation)
                {
                    PMBox.Show("امكان افزودن تخفیف یا هزینه مورد نظر ، بیش از سقف تعیین شده وجود ندارد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            #endregion

            #region Insert Members To CostOrDiscount
            RefCostsAndDiscount NewCostDiscount = new RefCostsAndDiscount();
            NewCostDiscount.ReferralIX = _CurrentRefID;
            NewCostDiscount.CashierIX = SecurityManager.CurrentUserID;
            NewCostDiscount.Date = DateTime.Now;
            if (sender.Equals(txtCostAndDiscountValue)) NewCostDiscount.Value = txtCostAndDiscountValue.Value;
            else NewCostDiscount.Value = _CurrentRefRecievableValue * txtCDPercent.Value / 100;
            if (NewCostDiscount.Value <= 0)
            {
                PMBox.Show("مبلغ تخفیف یا هزینه باید بزرگتر از صفر باشد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            NewCostDiscount.CostIXOrDiscountIX = Convert.ToInt16(cboCostAndDiscountType.SelectedValue);
            CostsAndDiscountsType NewType = DBLayerIMS.Manager.DBML.CostsAndDiscountsTypes.
                Where(Data => Data.ID == Convert.ToInt16(cboCostAndDiscountType.SelectedValue)).First();
            NewCostDiscount.CostsAndDiscountsType = NewType;
            NewCostDiscount.Description = String.Empty;
            _CurrentRefCostsDiscounts.Add(NewCostDiscount);
            DBLayerIMS.Manager.DBML.RefCostsAndDiscounts.InsertOnSubmit(NewCostDiscount);
            dgvCostDiscounts.DataSource = _CurrentRefCostsDiscounts.ToList();
            #endregion

            dgvCostDiscounts.Refresh();
            ReCalculateRefPrices();
            txtCostAndDiscountValue.Value = 0;
            txtCostAndDiscountValue.ValueObject = null;
            txtCDPercent.Value = 0;
            txtCDPercent.ValueObject = null;
            _IsCurrentFormModified = true;
            dgvCostDiscounts.Focus();
        }
        #endregion

        #endregion

        #region dgvCostDiscounts Methods

        #region void EditCostOrDiscount(Int32 RowID)
        /// <summary>
        /// تابعی برای ویرایش یك تخفیف یا هزینه افزوده شده
        /// </summary>
        /// <param name="RowID">ردیف تخفیف یا هزینه در جدول</param>
        private void EditCostOrDiscount(Int32 RowID)
        {
            #region Show Form
            RefCostsAndDiscount CurrentData = (RefCostsAndDiscount)dgvCostDiscounts.Rows[RowID].DataBoundItem;
            frmManageCostOrDiscount MyForm = new frmManageCostOrDiscount(
                CurrentData.CostsAndDiscountsType.IsCost, false);
            if (!((List<CostsAndDiscountsType>)MyForm.cboType.DataSource).
                     Exists(Data => Data.ID == CurrentData.CostIXOrDiscountIX))
                MyForm.cboType.DataSource = ((List<CostsAndDiscountsType>)MyForm.cboType.DataSource).
                    Union(DBLayerIMS.Account.CostAndDiscountFullList.
                    Where(Data => Data.ID == CurrentData.CostIXOrDiscountIX)).ToList();
            MyForm.cboType.SelectedValue = CurrentData.CostIXOrDiscountIX;
            MyForm.RegDate.SelectedDateTime = CurrentData.Date;
            MyForm.RegTime.Value = CurrentData.Date;
            MyForm.txtValue.Value = CurrentData.Value;
            MyForm.txtDescription.Text = CurrentData.Description;
            MyForm.txtValue.Focus();
            MyForm.ShowDialog();
            if (MyForm.DialogResult != DialogResult.OK)
            {
                MyForm.Dispose();
                return;
            }
            #endregion

            #region Check Cost Or Discount Limitation
            Int32 TypeLimitation = DBLayerIMS.Account.CostAndDiscountFullList.
                Where(Data => Data.ID == Convert.ToInt16(MyForm.cboType.SelectedValue)).First().Limitation;
            if (TypeLimitation != 0)
            {
                Int32 TotalCount = 0;
                foreach (RefCostsAndDiscount Values in _CurrentRefCostsDiscounts)
                {
                    if (Values.CostIXOrDiscountIX == Convert.ToInt16(MyForm.cboType.SelectedValue) && Values.ID != CurrentData.ID)
                        TotalCount += Values.Value;
                }
                TotalCount += MyForm.txtValue.Value;
                if (TotalCount > TypeLimitation)
                {
                    PMBox.Show("امكان افزودن تخفیف یا هزینه مورد نظر ، بیش از سقف تعیین شده وجود ندارد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            #endregion

            #region Update Members To CostOrDiscount
            ((RefCostsAndDiscount)dgvCostDiscounts.SelectedRows[0].DataBoundItem).CostsAndDiscountsType =
                DBLayerIMS.Manager.DBML.CostsAndDiscountsTypes.
                Where(Data => Data.ID == Convert.ToInt16(MyForm.cboType.SelectedValue)).First();
            DateTime RegDate = new DateTime(MyForm.RegDate.SelectedDateTime.Value.Year,
                MyForm.RegDate.SelectedDateTime.Value.Month,
                MyForm.RegDate.SelectedDateTime.Value.Day,
                MyForm.RegTime.Value.Hour, MyForm.RegTime.Value.Minute,
                MyForm.RegTime.Value.Second);
            ((RefCostsAndDiscount)dgvCostDiscounts.SelectedRows[0].DataBoundItem).Date = RegDate;
            ((RefCostsAndDiscount)dgvCostDiscounts.SelectedRows[0].DataBoundItem).Value = MyForm.txtValue.Value;
            ((RefCostsAndDiscount)dgvCostDiscounts.SelectedRows[0].DataBoundItem).Description =
                MyForm.txtDescription.Text.Trim();
            #endregion
            dgvCostDiscounts.Refresh();
            ReCalculateRefPrices();
            _IsCurrentFormModified = true;
            dgvCostDiscounts.Focus();
        }
        #endregion

        #endregion

    }
}