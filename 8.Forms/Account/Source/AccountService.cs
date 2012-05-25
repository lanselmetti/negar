#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Account
{
    /// <summary>
    /// فایل كمكی كلاس فرم مدیریت حساب برای مدیریت خدمات
    /// </summary>
    public partial class frmAccount
    {

        #region dgvServices Event Handlers

        #region cmsdgvServices_PopupOpen
        private void cmsdgvServices_PopupOpen(object sender, PopupOpenEventArgs e)
        {
            Int32 RowIndex = dgvServices.SelectedCells[0].RowIndex;
            RefService CurrentService = (RefService)dgvServices.Rows[RowIndex].DataBoundItem;

            #region Service Activation
            btnIsActive.Checked = CurrentService.IsActive;
            if (btnIsActive.Checked)
                btnIsActive.Text = "<b>فعال</b><div></div><font color=\"Black\">وضعیت فعال بودن خدمت.</font>";
            else btnIsActive.Text = "<b>غیر فعال</b><div></div><font color=\"Black\">وضعیت فعال بودن خدمت.</font>";
            #endregion

            #region Service Category
            List<Int16?> CategoryID = DBLayerIMS.Services.ServicesList.
                Where(ServiceData => ServiceData.ID == CurrentService.ServiceIX)
                .Select(ServiceData => ServiceData.CategoryIX).ToList();
            String CategoryName;
            if (CategoryID.Count == 0 || CategoryID.First() == null) CategoryName = String.Empty;
            else CategoryName = DBLayerIMS.Services.ServCategoriesList.
                Where(Data => Data.ID == CategoryID.First()).Select(Data => Data.Name).First();
            if (String.IsNullOrEmpty(CategoryName)) lblServiceCategory.Text = "فاقد طبقه بندی";
            else lblServiceCategory.Text = "طبقه بندی: " + CategoryName;
            #endregion

            #region Service Groups
            List<SP_SelectServicesInGroupsResult> ServiceGroups = DBLayerIMS.Services.ServicesInGroupsList.
                Where(Data => Data.ID == CurrentService.ID).ToList();
            if (ServiceGroups.Count == 0) btnServiceGroups.Visible = false;
            else
            {
                btnServiceGroups.Visible = true;
                btnServiceGroups.SubItems.Clear();
                foreach (SP_SelectServicesInGroupsResult Group in ServiceGroups)
                {
                    LabelItem lblGroup = new LabelItem();
                    lblGroup.BackColor = Color.White;
                    lblGroup.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    lblGroup.BorderSide = eBorderSide.None;
                    lblGroup.Width = 150;
                    lblGroup.Text = DBLayerIMS.Services.ServGroupsList.
                        // ReSharper disable AccessToModifiedClosure
                        Where(Data => Data.ID == Group.GroupID.Value).First().Name;
                    // ReSharper restore AccessToModifiedClosure
                    btnServiceGroups.SubItems.Add(lblGroup);
                }
            }
            #endregion

            #region Service Base Price
            List<SP_SelectServicesListResult> ServiceBasePrices = DBLayerIMS.Services.ServicesList.
                    Where(Data => Data.ID == CurrentService.ServiceIX).ToList();
            if (ServiceBasePrices.Count == 0) btnServiceBasePriceList.Visible = false;
            else
            {
                btnServiceBasePriceList.Visible = true;
                lblServiceFreePrice.Text = "تعرفه آزاد: " + String.Format("{0:N0}", ServiceBasePrices.First().PriceFree) + " ریال";
                lblServiceGovPrice.Text = "تعرفه دولتی: " + String.Format("{0:N0}", ServiceBasePrices.First().PriceGov) + " ریال";
            }
            #endregion

            #region Service Ins Price
            if (_CurrentRefData.Ins1IX == null) btnServiceInsPrice.Visible = false;
            else
            {
                btnServiceInsPrice.Visible = true;
                List<InsuranceService> ServiceInsPrices = DBLayerIMS.Insurance.InsServiceFullList.
                    Where(Data => Data.ServiceIX == CurrentService.ServiceIX && Data.IsCover).ToList();
                if (ServiceInsPrices.Count == 0)
                {
                    lblServiceIns1Price.Text = "قیمت بیمه اول: تعریف نشده";
                    lblServiceIns1Part.Text = "سهم بیمه اول: تعریف نشده";
                    lblServiceIns1PatientPart.Text = "سهم بیمار برای بیمه اول: تعریف نشده";
                }
                else
                {
                    lblServiceIns1Price.Text = "قیمت بیمه اول: " + String.Format("{0:N0}", ServiceInsPrices.First().InsPrice) + " ریال";
                    lblServiceIns1Part.Text = "سهم بیمه اول: " + String.Format("{0:N0}", ServiceInsPrices.First().InsPart) + " ریال";
                    lblServiceIns1PatientPart.Text = "سهم بیمار برای بیمه اول: " +
                        String.Format("{0:N0}", (ServiceInsPrices.First().InsPrice - ServiceInsPrices.First().InsPart)) + " ریال";
                }
            }
            #endregion
        }
        #endregion

        #region btnIsActive_Click
        private void btnIsActive_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedCells.Count == 0) return;
            Int32 RowIndex = dgvServices.SelectedCells[0].RowIndex;
            if (CurrentFormState == AccountFormStates.Viewing)
            {
                PMBox.Show("حساب در حالت نمایش می باشد!\n" +
                    "لطفاً ابتدا بر روی دكمه ی ویرایش كلیك كرده و به حالت ویرایش حساب بروید.",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (btnIsActive.Checked)
            {
                DialogResult Result = PMBox.Show("با این كار خدمت انتخاب شده لغو شده و در محاسبات در نظر گرفته نمی شود!\n" +
                    "آیا نسبت به این كار اطمینان دارید؟",
                    "هشدار! پرسش؟", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (Result != DialogResult.Yes) return;
                btnIsActive.Checked = false;
                ((RefService)dgvServices.Rows[RowIndex].DataBoundItem).IsActive = false;
            }
            else
            {
                DialogResult Result = PMBox.Show("با این كار خدمت انتخاب شده فعال شده و در محاسبات در نظر گرفته می شود!\n" +
                    "آیا نسبت به این كار اطمینان دارید؟",
                    "هشدار! پرسش؟", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (Result != DialogResult.Yes) return;
                btnIsActive.Checked = true;
                ((RefService)dgvServices.Rows[RowIndex].DataBoundItem).IsActive = true;
            }
            _IsCurrentFormModified = true;
            dgvServices.EndEdit();
            dgvServices.Refresh();
            ReCalculateRefPrices();
        }
        #endregion

        #region dgvServices_PreviewKeyDown
        private void dgvServices_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvServices.SelectedCells.Count != 0)
                dgvServices_CellMouseClick(1,
                    new DataGridViewCellMouseEventArgs(0, dgvServices.SelectedCells[0].RowIndex, Left + Width - 150,
                        Top + dgvServices.Top + dgvServices.ColumnHeadersHeight +
                        dgvServices.GetRowDisplayRectangle(dgvServices.SelectedCells[0].RowIndex, true).Top + 17,
                        new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
        }
        #endregion

        #region dgvServices_CellFormatting
        private void dgvServices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColServiceName.Index)
                e.Value = DBLayerIMS.Services.ServicesList.Where(
                    Data => Data.ID == ((RefService)dgvServices.Rows[e.RowIndex].DataBoundItem).ServiceIX).First().Name;
            else if (e.ColumnIndex == ColExpert.Index)
                e.Value = DBLayerIMS.Referrals.RefServPerformers.Where(
                    Data => Data.ID == ((RefService)dgvServices.Rows[e.RowIndex].DataBoundItem).ExpertIX).First().FullName;
            else if (e.ColumnIndex == ColPhysician.Index)
                e.Value = DBLayerIMS.Referrals.RefServPerformers.Where(
                    Data => Data.ID == ((RefService)dgvServices.Rows[e.RowIndex].DataBoundItem).PhysicianIX).First().FullName;

            #region Calculate Ins1 Patient Part Price
            else if (e.ColumnIndex >= ColIns1PatientPartPrice.Index)
            {
                // اگر بیمه اول انتخاب نشده باشد یا خدمت مورد نظر تحت پوشش بیمه مورد نظر نباشد
                if (_CurrentRefData.Ins1IX == null ||
                    !Convert.ToBoolean(((RefService)dgvServices.Rows[e.RowIndex].DataBoundItem).IsIns1Cover))
                    dgvServices.Rows[e.RowIndex].Cells[ColIns1PatientPartPrice.Name].Value = null;
                else dgvServices.Rows[e.RowIndex].Cells[ColIns1PatientPartPrice.Name].Value =
                    Convert.ToInt32(Convert.ToInt32(dgvServices.Rows[e.RowIndex].Cells[ColIns1Price.Index].Value) -
                    Convert.ToInt32(dgvServices.Rows[e.RowIndex].Cells[ColIns1PartPrice.Index].Value));
            }
            #endregion

            #region Calculate Patient Percent
            else if (e.ColumnIndex == ColIns1Percent.Index)
            {
                // اگر بیمه اول انتخاب نشده باشد یا خدمت مورد نظر تحت پوشش بیمه مورد نظر نباشد
                if (_CurrentRefData.Ins1IX == null ||
                    !Convert.ToBoolean(((RefService)dgvServices.Rows[e.RowIndex].DataBoundItem).IsIns1Cover))
                    dgvServices.Rows[e.RowIndex].Cells[ColIns1Percent.Name].Value = 0;
                // اگر بیمه اول انتخاب شده باشد و خدمت مورد نظر تحت پوشش بیمه مورد نظر باشد
                else
                {
                    if (Convert.ToDecimal(dgvServices.Rows[e.RowIndex].Cells[ColIns1Price.Name].Value) == 0)
                        dgvServices.Rows[e.RowIndex].Cells[ColIns1Percent.Name].Value = 0;
                    else dgvServices.Rows[e.RowIndex].Cells[ColIns1Percent.Name].Value =
                        Convert.ToInt32(Convert.ToDecimal(dgvServices.Rows[e.RowIndex].Cells[ColIns1PartPrice.Name].Value)
                        * 100 / Convert.ToDecimal(dgvServices.Rows[e.RowIndex].Cells[ColIns1Price.Name].Value));
                }
            }
            #endregion
        }
        #endregion

        #region dgvServices_CellValidating
        /// <summary>
        /// روالی برای تایید اعتبار مقادیر وارد شده در ستون های جدول خدمات مراجعات
        /// </summary>
        private void dgvServices_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // اگر سلول در حال ویرایش نباشد ، تایید اعتبار صورت نمی گیرد
            if (!dgvServices[e.ColumnIndex, e.RowIndex].IsInEditMode) return;
            #region Validate Service Quantity
            if (e.ColumnIndex == ColQuantity.Index) // ستون تعداد خدمت
                try
                {
                    Int32 Value;
                    Boolean IsCorrectValue = Int32.TryParse(e.FormattedValue.ToString(), out Value);
                    if (!IsCorrectValue || Value <= 0)
                    {
                        PMBox.Show("مقدار وارد شده برای تعداد خدمت صحیح نمی باشد!", "خطا!",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
                #region Catch
                catch (Exception)
                {
                    PMBox.Show("مقدار وارد شده برای تعداد خدمت صحیح نمی باشد!", "خطا!",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
                #endregion
            #endregion

            #region Validate Number Columns
            // سایر ستون های عددی
            else if (e.ColumnIndex == ColQuantity.Index || e.ColumnIndex == ColPatientPayablePrice.Index ||
                e.ColumnIndex == ColIns1Percent.Index ||
                e.ColumnIndex == ColIns1Price.Index || e.ColumnIndex == ColIns1PartPrice.Index ||
                e.ColumnIndex == ColIns2Price.Index || e.ColumnIndex == ColIns2PartPrice.Index)
                try
                {
                    Int32 Value;
                    Boolean IsCorrectValue = Int32.TryParse(e.FormattedValue.ToString(),
                        NumberStyles.AllowThousands, System.Threading.Thread.CurrentThread.CurrentCulture, out Value);
                    if (!IsCorrectValue || Value < 0)
                    {
                        PMBox.Show("مقدار وارد شده مقدار صحیحی برای یك فیلد عددی نمی باشد!", "خطا!",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
                #region Catch
                catch (Exception)
                {
                    PMBox.Show("مقدار وارد شده برای تعداد خدمت صحیح نمی باشد!", "خطا!",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
                #endregion
            #endregion

            #region Calculate ColIns1PartPrice Or ColIns1Percent Changed
            // Note: در این قسمت با تغییر قیمت بیمه اول خدمت ، پرداختنی آن به صورت خودكار تحت تاثیر قرار میگیرد
            if (e.ColumnIndex == ColIns1PartPrice.Index || e.ColumnIndex == ColIns1Percent.Index)
            {
                Int32 Value;
                Int32.TryParse(e.FormattedValue.ToString(),
                    NumberStyles.AllowThousands, System.Threading.Thread.CurrentThread.CurrentCulture, out Value);
                Int32 Diff = Convert.ToInt32(dgvServices[e.ColumnIndex, e.RowIndex].Value) - Value;
                if (e.ColumnIndex == ColIns1Percent.Index)
                {
                    Value = Convert.ToInt32(dgvServices[ColIns1Price.Index, e.RowIndex].Value) * Value / 100;
                    Diff = Convert.ToInt32(dgvServices[ColIns1PartPrice.Index, e.RowIndex].Value) - Value;
                }
                Int32 NewVal = (Convert.ToInt32(dgvServices[ColPatientPayablePrice.Index, e.RowIndex].Value) + Diff) *
                    Convert.ToInt32(dgvServices[ColQuantity.Index, e.RowIndex].Value);
                if (NewVal >= 0) dgvServices[ColPatientPayablePrice.Index, e.RowIndex].Value = NewVal;
                else
                {
                    NewVal = Convert.ToInt32(dgvServices[ColPatientPayablePrice.Index, e.RowIndex].Value) + NewVal;
                    if (NewVal >= 0) dgvServices[ColPatientPayablePrice.Index, e.RowIndex].Value = NewVal;
                    else dgvServices[ColPatientPayablePrice.Index, e.RowIndex].Value = 0;
                }
            }
            else if (e.ColumnIndex == ColIns2PartPrice.Index)
            {
                Int32 Value;
                Int32.TryParse(e.FormattedValue.ToString(),
                    NumberStyles.AllowThousands, System.Threading.Thread.CurrentThread.CurrentCulture, out Value);
                Int32 Diff = Convert.ToInt32(dgvServices[e.ColumnIndex, e.RowIndex].Value) - Value;
                Int32 NewVal = (Convert.ToInt32(dgvServices[ColPatientPayablePrice.Index, e.RowIndex].Value) + Diff) *
                    Convert.ToInt32(dgvServices[ColQuantity.Index, e.RowIndex].Value);
                if (NewVal >= 0) dgvServices[ColPatientPayablePrice.Index, e.RowIndex].Value = NewVal;
                else dgvServices[ColPatientPayablePrice.Index, e.RowIndex].Value = 0;
            }
            #endregion
        }
        #endregion

        #region dgvServices_CellPainting
        /// <summary>
        /// روالی برای رسم ردیف های غیر فعال در جدول خدمات
        /// </summary>
        private void dgvServices_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                !((RefService)dgvServices.Rows[e.RowIndex].DataBoundItem).IsActive && // برای ردیف های غیر فعال
                e.CellStyle.BackColor != Color.IndianRed)
                // @@@@ تغییر رنگ ردیف نوبت های غیر فعال به قرمز @@@@
                e.CellStyle.BackColor = Color.IndianRed;
        }
        #endregion

        #region dgvServices_CellMouseClick
        private void dgvServices_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Point Position = MousePosition;
            // اگر درخواست كننده تابع جاری كلید ویندوز باشد و نه كلیك راست موس محل نمایش نموی كلیك راست تغییر می كند
            if (sender is Int32 && e.RowIndex >= 0 && e.ColumnIndex >= 0) Position = e.Location;
            else if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            dgvServices[e.ColumnIndex, e.RowIndex].Selected = true;
            // منوی كلیك راست نمایش داده می شود
            cmsdgvServices.Popup(Position);
        }
        #endregion

        #region dgvServices_CellContentClick
        private void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CurrentFormState == AccountFormStates.Viewing) return;
            if (e.ColumnIndex == ColIsIns1Cover.Index || e.ColumnIndex == ColIsIns2Cover.Index)
            {
                // اگر بیمه ی اول انتخاب نشده باشد ، پوشش بیمه قابل تغییر نیست
                if (e.ColumnIndex == ColIsIns1Cover.Index && _CurrentRefData.Ins1IX == null)
                {
                    PMBox.Show("بیمه ی اولی انتخاب نشده تا خدمت تحت پوشش آن قرار بگیرد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                if (e.ColumnIndex == ColIsIns2Cover.Index && _CurrentRefData.Ins2IX == null)
                {
                    PMBox.Show("بیمه ی دومی انتخاب نشده تا خدمت تحت پوشش آن قرار بگیرد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                if (e.ColumnIndex == ColIsIns1Cover.Index)
                {
                    List<Boolean> InsData = DBLayerIMS.Insurance.InsServiceFullList.
                        Where(Data => Data.ServiceIX == ((RefService)dgvServices.Rows[e.RowIndex].DataBoundItem).ServiceIX &&
                            Data.InsIX == _CurrentRefData.Ins1IX).Select(Data => Data.IsCover).ToList();
                    if (InsData.Count == 0 || !InsData.First())
                    {
                        PMBox.Show("خدمت انتخاب شده تحت پوشش بیمه ی اول انتخاب شده نیست!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }
                if (e.ColumnIndex == ColIsIns2Cover.Index)
                {
                    List<Boolean> InsData = DBLayerIMS.Insurance.InsServiceFullList.
                        Where(Data => Data.ServiceIX == ((RefService)dgvServices.Rows[e.RowIndex].DataBoundItem).ServiceIX &&
                            Data.InsIX == _CurrentRefData.Ins2IX).Select(Data => Data.IsCover).ToList();
                    if (InsData.Count == 0 || !InsData.First())
                    {
                        PMBox.Show("خدمت انتخاب شده تحت پوشش بیمه ی دوم انتخاب شده نیست!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }
                dgvServices[e.ColumnIndex, e.RowIndex].Value =
                    !Convert.ToBoolean(dgvServices[e.ColumnIndex, e.RowIndex].Value);
            }
        }
        #endregion

        #region dgvServices_CellBeginEdit
        private void dgvServices_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // اگر كاربر بر روی ستون های چك باكس كلیك نماید ، این تابع اجازه آغاز ویرایش را نمیدهد
            // آغاز ویرایش در چك باكس ها با تابع CellContentClick مدیریت می شود
            if (e.ColumnIndex == ColIsIns1Cover.Index || e.ColumnIndex == ColIsIns2Cover.Index) e.Cancel = true;
        }
        #endregion

        #region dgvServices_CellEndEdit
        private void dgvServices_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex <= 0) return;

            #region Ins1 Percent Changed
            if (e.ColumnIndex == ColIns1Percent.Index)
            {
                Int32 Percent = Convert.ToInt32(dgvServices[ColIns1Percent.Index, e.RowIndex].Value);
                dgvServices.Rows[e.RowIndex].Cells[ColIns1PartPrice.Name].Value =
                    Convert.ToInt32(dgvServices[ColIns1Price.Index, e.RowIndex].Value) * Percent / 100;
            }
            #endregion

            #region Ins1 Price Changed
            else if (e.ColumnIndex == ColIns1Price.Index)
            {
                Byte PatientPercent = Convert.ToByte(DBLayerIMS.Insurance.InsFullList.
                    Where(Data => Data.ID == _CurrentRefData.Ins1IX).Select(Data => Data.PatientPercent).First());
                dgvServices[ColIns1PartPrice.Index, e.RowIndex].Value =
                    Convert.ToInt32(dgvServices[ColIns1Price.Index, e.RowIndex].Value) * (100 - PatientPercent) / 100;
            }
            #endregion

            #region Ins2 Price Changed
            else if (e.ColumnIndex == ColIns2Price.Index)
                dgvServices[ColIns2PartPrice.Index, e.RowIndex].Value = dgvServices[ColIns2Price.Index, e.RowIndex].Value;
            #endregion

            _IsCurrentFormModified = true;
            dgvServices.Refresh();
            ReCalculateRefPrices();
        }
        #endregion

        #region dgvServices_CellValueChanged
        private void dgvServices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex <= 0) return;
            dgvServices.CellValueChanged -= dgvServices_CellValueChanged;

            #region Ins1 Cover Changed
            if (e.ColumnIndex == ColIsIns1Cover.Index)
            {
                RefService Service = ((RefService)dgvServices.Rows[e.RowIndex].DataBoundItem);

                #region Set Ins1 Cover = False
                if (!Convert.ToBoolean(dgvServices.Rows[e.RowIndex].Cells[ColIsIns1Cover.Index].Value))
                {
                    Service.IsIns1Cover = false;
                    // در صورتی كه بیمه ی اول خدمت مورد نظر را تحت پوشش قرار ندهد 
                    // قیمت های بیمه ی اول برای خدمت مورد نظر صفر می شود
                    Service.Ins1Price = 0;
                    Service.Ins1PartPrice = 0;
                    #region Ins2 IsCover = True
                    if (Service.IsIns2Cover != null && Service.IsIns2Cover == true)
                    {
                        // مقدار پرداختنی خدمت بر اساس بیمه دوم و با قیمت های بیمه اول صفر مجدداً محاسبه گردد
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        SP_SelectInsFullDataResult Ins2Data = DBLayerIMS.Insurance.InsFullList.
                            Where(Result => Result.ID == _CurrentRefData.Ins2IX).First();
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        Int32? Ins2Price = 0;
                        Int32? Ins2Part = 0;
                        Int32? Ins2Payable = 0;
                        Int32? Ins1PatientPart = Service.Ins1Price - Service.Ins1PartPrice;
                        if (Service.Ins2Price == null) Service.Ins2Price = 0;
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        try
                        {
                            // تابع محاسبه قیمت های بیمه دوم بر اساس فرمول بیمه در اینجا فراخوانی می گردد
                            DBLayerIMS.Manager.DBML.SP_GenerateIns2Prices(
                                // بیمه دوم انتخاب شده
                                _CurrentRefData.Ins2IX,
                                // خدمت انتخاب شده
                                Service.ServiceIX,
                                // قیمت بیمه اول محاسبه شده
                                Service.Ins1Price,
                                // قیمت سهم بیمه اول محاسبه شده
                                Service.Ins1PartPrice,
                                // قیمت سهم بیمار از بیمه اول محاسبه شده
                                Ins1PatientPart,
                                // قیمت پرداختنی بیمار بابت بیمه اول محاسبه شده
                                0,
                                // قیمت سقف تعهد بیمه اول
                                0,
                                // درصد بیمار برای بیمه اول
                                100,
                                // درصد بیمار برای بیمه اول
                                Ins2Data.InsurerPartLimit,
                                // خروجی 3 قیمت تولید شده
                                ref Ins2Price, ref Ins2Part, ref Ins2Payable);
                        }
                        #region Catch
                        catch (Exception Ex)
                        {
                            const String ErrorMessage =
                                "امكان خواندن اطلاعات مبالغ بیمه دوم خدمات از بانك اطلاعات ممكن نیست.\n" +
                                "موارد زیر را بررسی نمایید:\n" +
                                "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                            PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LogManager.SaveLogEntry("Sepehr", "Account Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                            if (ParentForm != null) ParentForm.Close();
                            return;
                        }
                        #endregion
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        Service.Ins2Price = Convert.ToInt32(Ins2Price);
                        Service.Ins2PartPrice = Convert.ToInt32(Ins2Part);
                        Service.PatientPayablePrice = Convert.ToInt32(Ins2Payable);
                    }
                    #endregion

                    #region Ins2 IsCover = False
                    else // مقدار پرداختنی خدمت برابر مقدار آن در حالت بدون بیمه میگردد
                        Service.PatientPayablePrice = DBLayerIMS.Services.ServicesList.
                            Where(Data => Data.ID == Service.ServiceIX).Select(Data => Data.PriceFree).First();
                    #endregion
                }
                #endregion

                #region Set Ins1 Cover = True
                else
                {
                    Service.IsIns1Cover = true;
                    // در صورتی كه بیمه ی اول خدمت مورد نظر را تحت پوشش قرار دهد 
                    // قیمت های بیمه ی اول برای خدمت مورد نظر بر اساس قیمت های آن محاسبه می شود
                    // پیمایش بین جدول ارتباط بیمه ها و خدمات برای بدست آوردن قیمت های خدمات مورد نظر در بیمه ی اول انتخاب شده
                    List<InsuranceService> CurrentServiceIns1Data = DBLayerIMS.Insurance.InsServiceFullList.
                        Where(Result => Result.ServiceIX == Service.ServiceIX && Result.InsIX == _CurrentRefData.Ins1IX).ToList();
                    Service.Ins1Price = CurrentServiceIns1Data.First().InsPrice;
                    Service.Ins1PartPrice = CurrentServiceIns1Data.First().InsPart;

                    #region Ins2 IsCover = True
                    if (Service.IsIns2Cover != null && Service.IsIns2Cover == true)
                    {
                        // مقدار پرداختنی خدمت در این حالت باید مجددا بر اساس بیمه دوم انتخاب شده محاسبه گردد
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        SP_SelectInsFullDataResult Ins1Data = DBLayerIMS.Insurance.InsFullList.
                            Where(Result => Result.ID == _CurrentRefData.Ins1IX).First();
                        SP_SelectInsFullDataResult Ins2Data = DBLayerIMS.Insurance.InsFullList.
                            Where(Result => Result.ID == _CurrentRefData.Ins2IX).First();
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        Int32? Ins2Price = 0;
                        Int32? Ins2Part = 0;
                        Int32? Ins2Payable = 0;
                        Int32? Ins1PatientPart = Service.Ins1Price - Service.Ins1PartPrice;
                        if (Service.Ins2Price == null) Service.Ins2Price = 0;
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        try
                        {
                            Int32 CurrentServiceIns1PatientPayable = 0;
                            if (CurrentServiceIns1Data.Count != 0)
                                CurrentServiceIns1PatientPayable = CurrentServiceIns1Data.First().PatientPayable;
                            // تابع محاسبه قیمت های بیمه دوم بر اساس فرمول بیمه در اینجا فراخوانی می گردد
                            DBLayerIMS.Manager.DBML.SP_GenerateIns2Prices(
                                // بیمه دوم انتخاب شده
                                _CurrentRefData.Ins2IX,
                                // خدمت انتخاب شده
                                Service.ServiceIX,
                                // قیمت بیمه اول محاسبه شده
                                Service.Ins1Price,
                                // قیمت سهم بیمه اول محاسبه شده
                                Service.Ins1PartPrice,
                                // قیمت سهم بیمار از بیمه اول محاسبه شده
                                Ins1PatientPart,
                                // قیمت پرداختنی بیمار بابت بیمه اول محاسبه شده
                                CurrentServiceIns1PatientPayable,
                                // قیمت سقف تعهد بیمه اول
                                Ins1Data.InsurerPartLimit,
                                // درصد بیمار برای بیمه اول
                                Ins1Data.PatientPercent,
                                // درصد بیمار برای بیمه اول
                                Ins2Data.InsurerPartLimit,
                                // خروجی 3 قیمت تولید شده
                                ref Ins2Price, ref Ins2Part, ref Ins2Payable);
                        }
                        #region Catch
                        catch (Exception Ex)
                        {
                            const String ErrorMessage =
                                "امكان خواندن اطلاعات مبالغ بیمه دوم خدمات از بانك اطلاعات ممكن نیست.\n" +
                                "موارد زیر را بررسی نمایید:\n" +
                                "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                            PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LogManager.SaveLogEntry("Sepehr", "Account Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                            if (ParentForm != null) ParentForm.Close();
                            return;
                        }
                        #endregion
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        Service.Ins2Price = Convert.ToInt32(Ins2Price);
                        Service.Ins2PartPrice = Convert.ToInt32(Ins2Part);
                        Service.PatientPayablePrice = Convert.ToInt32(Ins2Payable);
                    }
                    #endregion

                    #region Ins2 IsCover = False
                    else
                    {
                        // مقدار پرداختنی خدمت برابر مقدار آن در حالت با بیمه اول و بدون بیمه دوم گردد
                        Service.PatientPayablePrice = CurrentServiceIns1Data.First().PatientPayable;
                    }
                    #endregion
                }
                #endregion

                if (Service.IsIns1Cover == false)
                {
                    dgvServices.Rows[e.RowIndex].Cells[ColIns1Price.Index].Value = null;
                    dgvServices.Rows[e.RowIndex].Cells[ColIns1PartPrice.Index].Value = null;
                }
                else
                {
                    // خدمت مورد نظر می تواند مجدداً در اینجا بر اساس بیمه محاسبه گردد
                    dgvServices.Rows[e.RowIndex].Cells[ColIns1Price.Index].Value = Service.Ins1Price;
                    dgvServices.Rows[e.RowIndex].Cells[ColIns1PartPrice.Index].Value = Service.Ins1PartPrice;
                }
                _IsCurrentFormModified = true;
            }
            #endregion

            #region Ins2 Cover Changed
            else if (e.ColumnIndex == ColIsIns2Cover.Index)
            {
                RefService Service = ((RefService)dgvServices.Rows[dgvServices.SelectedCells[0].RowIndex].DataBoundItem);

                #region Set Ins2 Cover = False
                if (!Convert.ToBoolean(dgvServices.Rows[e.RowIndex].Cells[ColIsIns2Cover.Index].Value))
                {
                    Service.IsIns2Cover = false;
                    // در صورتی كه بیمه ی دوم خدمت مورد نظر را تحت پوشش قرار ندهد 
                    // قیمت های بیمه ی دوم برای خدمت مورد نظر صفر می شود
                    Service.Ins2Price = 0;
                    Service.Ins2PartPrice = 0;

                    #region Ins1 IsCover = True
                    // مقدار پرداختنی خدمت بر اساس بیمه اول و با قیمت های بیمه دوم صفر مجدداً محاسبه گردد
                    if (Service.IsIns1Cover != null && Service.IsIns1Cover == true)
                    {
                        // پیمایش بین جدول ارتباط بیمه ها و خدمات برای بدست آوردن قیمت های خدمات مورد نظر در بیمه ی اول انتخاب شده
                        List<InsuranceService> CurrentServiceIns1Data = DBLayerIMS.Insurance.InsServiceFullList.
                            Where(Data => Data.ServiceIX == Service.ServiceIX && Data.InsIX == _CurrentRefData.Ins1IX).ToList();
                        Service.Ins1Price = CurrentServiceIns1Data.First().InsPrice;
                        Service.Ins1PartPrice = CurrentServiceIns1Data.First().InsPart;
                        Service.PatientPayablePrice = CurrentServiceIns1Data.First().PatientPayable;
                        Service.Ins2Price = 0;
                        Service.Ins2PartPrice = 0;
                    }
                    #endregion

                    #region Ins1 IsCover = False
                    // مقدار پرداختنی خدمت برابر مقدار آن در حالت بدون بیمه میگردد
                    else Service.PatientPayablePrice = DBLayerIMS.Services.ServicesList.
                        Where(Data => Data.ID == Service.ServiceIX).Select(Data => Data.PriceFree).First();
                    #endregion
                }
                #endregion

                #region Set Ins2 Cover = True
                else
                {
                    // در صورتی كه بیمه ی دوم خدمت مورد نظر را تحت پوشش قرار دهد 
                    // قیمت های بیمه ی دوم برای خدمت مورد نظر بر اساس قیمت های آن محاسبه می شود
                    Service.IsIns2Cover = true;

                    #region Ins1 IsCover = True
                    if (Service.IsIns2Cover != null || Service.IsIns2Cover == true)
                    {
                        // پیمایش بین جدول ارتباط بیمه ها و خدمات برای بدست آوردن قیمت های خدمات مورد نظر در بیمه ی اول انتخاب شده
                        List<InsuranceService> CurrentServiceIns1Data = DBLayerIMS.Insurance.InsServiceFullList.
                            Where(Data => Data.ServiceIX == Service.ServiceIX && Data.InsIX == _CurrentRefData.Ins1IX).ToList();
                        // مقدار پرداختنی خدمت در این حالت باید مجددا بر اساس بیمه اول و دوم انتخاب شده محاسبه گردد
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        SP_SelectInsFullDataResult Ins1Data = DBLayerIMS.Insurance.InsFullList.
                            Where(Result => Result.ID == _CurrentRefData.Ins1IX).First();
                        SP_SelectInsFullDataResult Ins2Data = DBLayerIMS.Insurance.InsFullList.
                            Where(Result => Result.ID == _CurrentRefData.Ins2IX).First();
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        Int32? Ins2Price = 0;
                        Int32? Ins2Part = 0;
                        Int32? Ins2Payable = 0;
                        Int32? Ins1PatientPart = Service.Ins1Price - Service.Ins1PartPrice;
                        if (Service.Ins2Price == null) Service.Ins2Price = 0;
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        try
                        {
                            Int32 CurrentServiceIns1PatientPayable = 0;
                            if (CurrentServiceIns1Data.Count != 0)
                                CurrentServiceIns1PatientPayable = CurrentServiceIns1Data.First().PatientPayable;
                            // تابع محاسبه قیمت های بیمه دوم بر اساس فرمول بیمه در اینجا فراخوانی می گردد
                            DBLayerIMS.Manager.DBML.SP_GenerateIns2Prices(
                                _CurrentRefData.Ins2IX, // بیمه دوم انتخاب شده
                                Service.ServiceIX, // خدمت انتخاب شده
                                Service.Ins1Price, // قیمت بیمه اول محاسبه شده
                                Service.Ins1PartPrice, // قیمت سهم بیمه اول محاسبه شده
                                Ins1PatientPart, // قیمت سهم بیمار از بیمه اول محاسبه شده
                                CurrentServiceIns1PatientPayable, // قیمت پرداختنی بیمار بابت بیمه اول محاسبه شده
                                Ins1Data.InsurerPartLimit, // قیمت سقف تعهد بیمه اول
                                Ins1Data.PatientPercent, // درصد بیمار برای بیمه اول
                                Ins2Data.InsurerPartLimit, // درصد بیمار برای بیمه اول
                                // خروجی 3 قیمت تولید شده
                                ref Ins2Price, ref Ins2Part, ref Ins2Payable);
                        }
                        #region Catch
                        catch (Exception Ex)
                        {
                            const String ErrorMessage =
                                "امكان خواندن اطلاعات مبالغ بیمه دوم خدمات از بانك اطلاعات ممكن نیست.\n" +
                                "موارد زیر را بررسی نمایید:\n" +
                                "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                            PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LogManager.SaveLogEntry("Sepehr", "Account Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                            if (ParentForm != null) ParentForm.Close();
                            return;
                        }
                        #endregion
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        Service.Ins2Price = Convert.ToInt32(Ins2Price);
                        Service.Ins2PartPrice = Convert.ToInt32(Ins2Part);
                        Service.PatientPayablePrice = Convert.ToInt32(Ins2Payable);
                    }
                    #endregion

                    #region Ins1 IsCover = False
                    else
                    {
                        // مقدار پرداختنی خدمت بر اساس بیمه دوم و با قیمت های بیمه اول صفر مجدداً محاسبه گردد
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        SP_SelectInsFullDataResult Ins2Data = DBLayerIMS.Insurance.InsFullList.
                            Where(Data => Data.ID == _CurrentRefData.Ins2IX).First();
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        Int32? Ins2Price = 0;
                        Int32? Ins2Part = 0;
                        Int32? Ins2Payable = 0;
                        Int32? Ins1PatientPart = Service.Ins1Price - Service.Ins1PartPrice;
                        if (Service.Ins2Price == null) Service.Ins2Price = 0;
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        try
                        {
                            // تابع محاسبه قیمت های بیمه دوم بر اساس فرمول بیمه در اینجا فراخوانی می گردد
                            DBLayerIMS.Manager.DBML.SP_GenerateIns2Prices(
                                _CurrentRefData.Ins2IX, // بیمه دوم انتخاب شده
                                Service.ServiceIX, // خدمت انتخاب شده
                                Service.Ins1Price, // قیمت بیمه اول محاسبه شده
                                Service.Ins1PartPrice, // قیمت سهم بیمه اول محاسبه شده
                                Ins1PatientPart, // قیمت سهم بیمار از بیمه اول محاسبه شده
                                0, // قیمت پرداختنی بیمار بابت بیمه اول محاسبه شده
                                0, // قیمت سقف تعهد بیمه اول
                                100, // درصد بیمار برای بیمه اول
                                Ins2Data.InsurerPartLimit, // درصد بیمار برای بیمه اول
                                // خروجی 3 قیمت تولید شده
                                ref Ins2Price, ref Ins2Part, ref Ins2Payable);
                        }
                        #region Catch
                        catch (Exception Ex)
                        {
                            const String ErrorMessage =
                                "امكان خواندن اطلاعات مبالغ بیمه دوم خدمات از بانك اطلاعات ممكن نیست.\n" +
                                "موارد زیر را بررسی نمایید:\n" +
                                "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                            PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LogManager.SaveLogEntry("Sepehr", "Account Forms", Ex.Message + "\n" +
                                Ex.StackTrace, EventLogEntryType.Error);
                            if (ParentForm != null) ParentForm.Close();
                            return;
                        }
                        #endregion
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        Service.Ins2Price = Convert.ToInt32(Ins2Price);
                        Service.Ins2PartPrice = Convert.ToInt32(Ins2Part);
                        Service.PatientPayablePrice = Convert.ToInt32(Ins2Payable);
                    }

                    #endregion
                }
                #endregion
                _IsCurrentFormModified = true;
            }
            #endregion

            SetServiceCellSettings(e.RowIndex, e.ColumnIndex);
            dgvServices.Invalidate();
            dgvServices.CellValueChanged += dgvServices_CellValueChanged;
        }
        #endregion

        #endregion

        #region dgvServices Methods

        #region void SetServiceCellSettings(Int32 RowIndex, Int32 ColumnIndex)
        /// <summary>
        /// تابع تنظیم سلول های ردیف های خدمات بیمار
        /// </summary>
        /// <param name="RowIndex">كلید ردیف</param>
        /// <param name="ColumnIndex">كلید ستون</param>
        /// <returns>كلید مراجعه یا تهی برای خطا</returns>
        private void SetServiceCellSettings(Int32 RowIndex, Int32 ColumnIndex)
        {
            if (RowIndex < 0 || ColumnIndex < 0) return;

            #region @@ Change Row ReadOnly Based On Row IsActive @@

            #region Active Rows
            // برای ردیف های فعال
            if (((RefService)dgvServices.Rows[RowIndex].DataBoundItem).IsActive)
            {
                if (dgvServices[ColumnIndex, RowIndex].ReadOnly) dgvServices[ColumnIndex, RowIndex].ReadOnly = false;

                #region Set Ref Insurance Settings
                // برای حالتی كه بیمه اول انتخاب نشده
                if (_CurrentRefData.Ins1IX == null)
                {
                    if (!dgvServices.Rows[RowIndex].Cells[ColIsIns1Cover.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIsIns1Cover.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns1Percent.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1Percent.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns1Price.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1Price.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns1PartPrice.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1PartPrice.Name].ReadOnly = true;

                    if (!dgvServices.Rows[RowIndex].Cells[ColIsIns2Cover.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIsIns2Cover.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns2Price.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns2Price.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns2PartPrice.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns2PartPrice.Name].ReadOnly = true;
                }
                // برای حالتی كه بیمه اول انتخاب شده ولی تحت پوشش بیمه اول نیست و تحت پوشش بیمه دوم هم نیست
                else if (_CurrentRefData.Ins1IX != null &&
                    !Convert.ToBoolean(((RefService)dgvServices.Rows[RowIndex].DataBoundItem).IsIns1Cover) &&
                    !Convert.ToBoolean(((RefService)dgvServices.Rows[RowIndex].DataBoundItem).IsIns2Cover))
                {
                    if (dgvServices.Rows[RowIndex].Cells[ColIsIns1Cover.Name].ReadOnly && ColIsIns1Cover.Tag == null)
                        dgvServices.Rows[RowIndex].Cells[ColIsIns1Cover.Name].ReadOnly = false;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns1Percent.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1Percent.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns1Price.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1Price.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns1PartPrice.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1PartPrice.Name].ReadOnly = true;

                    if (!dgvServices.Rows[RowIndex].Cells[ColIsIns2Cover.Name].ReadOnly && ColIsIns2Cover.Tag == null)
                        dgvServices.Rows[RowIndex].Cells[ColIsIns2Cover.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns2Price.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns2Price.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns2PartPrice.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns2PartPrice.Name].ReadOnly = true;
                }
                // برای حالتی كه بیمه اول انتخاب شده ولی تحت پوشش بیمه اول نیست ولی تحت پوشش بیمه دوم هست
                else if (_CurrentRefData.Ins1IX != null &&
                    !Convert.ToBoolean(((RefService)dgvServices.Rows[RowIndex].DataBoundItem).IsIns1Cover) &&
                    Convert.ToBoolean(((RefService)dgvServices.Rows[RowIndex].DataBoundItem).IsIns2Cover))
                {
                    if (dgvServices.Rows[RowIndex].Cells[ColIsIns1Cover.Name].ReadOnly && ColIsIns1Cover.Tag == null)
                        dgvServices.Rows[RowIndex].Cells[ColIsIns1Cover.Name].ReadOnly = false;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns1Percent.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1Percent.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns1Price.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1Price.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns1PartPrice.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1PartPrice.Name].ReadOnly = true;

                    if (!dgvServices.Rows[RowIndex].Cells[ColIsIns2Cover.Name].ReadOnly && ColIsIns2Cover.Tag == null)
                        dgvServices.Rows[RowIndex].Cells[ColIsIns2Cover.Name].ReadOnly = false;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns2Price.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns2Price.Name].ReadOnly = false;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns2PartPrice.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns2PartPrice.Name].ReadOnly = false;
                }
                // برای حالتی كه بیمه اول انتخاب شده و تحت پوشش است ولی بیمه دوم تحت پوشش نیست
                else if (_CurrentRefData.Ins1IX != null &&
                    Convert.ToBoolean(((RefService)dgvServices.Rows[RowIndex].DataBoundItem).IsIns1Cover) &&
                    !Convert.ToBoolean(((RefService)dgvServices.Rows[RowIndex].DataBoundItem).IsIns2Cover))
                {
                    if (dgvServices.Rows[RowIndex].Cells[ColIsIns1Cover.Name].ReadOnly && ColIsIns1Cover.Tag == null)
                        dgvServices.Rows[RowIndex].Cells[ColIsIns1Cover.Name].ReadOnly = false;
                    if (dgvServices.Rows[RowIndex].Cells[ColIns1Percent.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1Percent.Name].ReadOnly = false;
                    if (dgvServices.Rows[RowIndex].Cells[ColIns1Price.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1Price.Name].ReadOnly = false;
                    if (dgvServices.Rows[RowIndex].Cells[ColIns1PartPrice.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1PartPrice.Name].ReadOnly = false;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIsIns2Cover.Name].ReadOnly && ColIsIns2Cover.Tag == null)
                        dgvServices.Rows[RowIndex].Cells[ColIsIns2Cover.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns2Price.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns2Price.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns2PartPrice.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns2PartPrice.Name].ReadOnly = true;
                }
                // برای حالتی كه بیمه اول و دوم انتخاب شده و هر دو تحت پوشش هستند
                else
                {
                    if (dgvServices.Rows[RowIndex].Cells[ColIsIns1Cover.Name].ReadOnly && ColIsIns1Cover.Tag == null)
                        dgvServices.Rows[RowIndex].Cells[ColIsIns1Cover.Name].ReadOnly = false;
                    if (dgvServices.Rows[RowIndex].Cells[ColIns1Percent.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1Percent.Name].ReadOnly = false;
                    if (dgvServices.Rows[RowIndex].Cells[ColIns1Price.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1Price.Name].ReadOnly = false;
                    if (dgvServices.Rows[RowIndex].Cells[ColIns1PartPrice.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1PartPrice.Name].ReadOnly = false;
                    if (dgvServices.Rows[RowIndex].Cells[ColIsIns2Cover.Name].ReadOnly && ColIsIns2Cover.Tag == null)
                        dgvServices.Rows[RowIndex].Cells[ColIsIns2Cover.Name].ReadOnly = false;
                    if (dgvServices.Rows[RowIndex].Cells[ColIns2Price.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns2Price.Name].ReadOnly = false;
                    if (dgvServices.Rows[RowIndex].Cells[ColIns2PartPrice.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns2PartPrice.Name].ReadOnly = false;
                }
                #endregion

                if (ColQuantity.Tag != null && !dgvServices.Rows[RowIndex].Cells[ColQuantity.Name].ReadOnly)
                    dgvServices.Rows[RowIndex].Cells[ColQuantity.Name].ReadOnly = true;
                if (ColPatientPayablePrice.Tag != null &&
                    !dgvServices.Rows[RowIndex].Cells[ColPatientPayablePrice.Name].ReadOnly)
                    dgvServices.Rows[RowIndex].Cells[ColPatientPayablePrice.Name].ReadOnly = true;
                if (ColIns1Price.Tag != null)
                {
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns1Percent.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1Percent.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns1Price.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1Price.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns1PartPrice.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns1PartPrice.Name].ReadOnly = true;
                }
                if (ColIns2Price.Tag != null)
                {
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns2Price.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns2Price.Name].ReadOnly = true;
                    if (!dgvServices.Rows[RowIndex].Cells[ColIns2PartPrice.Name].ReadOnly)
                        dgvServices.Rows[RowIndex].Cells[ColIns2PartPrice.Name].ReadOnly = true;
                }
                if (ColIsIns1Cover.Tag != null && !dgvServices.Rows[RowIndex].Cells[ColIsIns1Cover.Name].ReadOnly)
                    dgvServices.Rows[RowIndex].Cells[ColIsIns1Cover.Name].ReadOnly = true;
                if (ColIsIns2Cover.Tag != null && !dgvServices.Rows[RowIndex].Cells[ColIsIns2Cover.Name].ReadOnly)
                    dgvServices.Rows[RowIndex].Cells[ColIsIns2Cover.Name].ReadOnly = true;
            }
            #endregion

            #region InActive Rows
            // برای ردیف های غیر فعال
            else
            {
                // اگر ردیفی غیر فعال است اما قابل ویرایش است باید غیر قابل ویرایش گردد
                if (dgvServices[ColumnIndex, RowIndex].ReadOnly == false)
                    dgvServices[ColumnIndex, RowIndex].ReadOnly = true;
            }
            #endregion

            #endregion

            // در هر شرایطی این ستون ها غیر فعال هستند
            if (!dgvServices.Rows[RowIndex].Cells[ColIsActive.Index].ReadOnly)
                dgvServices.Rows[RowIndex].Cells[ColIsActive.Index].ReadOnly = true;
            if (!dgvServices.Rows[RowIndex].Cells[ColServiceName.Index].ReadOnly)
                dgvServices.Rows[RowIndex].Cells[ColServiceName.Index].ReadOnly = true;
            if (!dgvServices.Rows[RowIndex].Cells[ColExpert.Index].ReadOnly)
                dgvServices.Rows[RowIndex].Cells[ColExpert.Index].ReadOnly = true;
            if (!dgvServices.Rows[RowIndex].Cells[ColPhysician.Index].ReadOnly)
                dgvServices.Rows[RowIndex].Cells[ColPhysician.Index].ReadOnly = true;
            if (!dgvServices.Rows[RowIndex].Cells[ColIns1PatientPartPrice.Index].ReadOnly)
                dgvServices.Rows[RowIndex].Cells[ColIns1PatientPartPrice.Index].ReadOnly = true;
        }
        #endregion

        #endregion

    }
}