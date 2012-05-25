#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.Settings.Services
{
    /// <summary>
    /// فرم افزودن كادر درمان پیش فرض
    /// </summary>
    internal partial class frmDefaultPerformersAdd : Form
    {

        #region Fields

        #region List<SP_SelectCategoriesResult> _CategoriesDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی كومبو باكس طبقه بندی خدمات
        /// </summary>
        private List<SP_SelectCategoriesResult> _CategoriesDataSource;
        #endregion

        #region List<SP_SelectServicesListResult> _ServicesDataSource
        /// <summary>
        /// لیست خدمات ثبت شده در سیستم
        /// </summary>
        private List<SP_SelectServicesListResult> _ServicesDataSource;
        #endregion

        #region List<SP_SelectPerformersResult> _PerformersDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی پزشكان
        /// </summary>
        private List<SP_SelectPerformersResult> _PerformersDataSource;
        #endregion

        #region List<SP_SelectDefaultPerformersResult> _DefaultPerformersList
        /// <summary>
        /// فیلد منبع اطلاعاتی پزشكان و كارشناسان پیش فرض
        /// </summary>
        private List<DefaultPerformers> _DefaultPerformersList;
        #endregion

        #endregion

        #region Ctor
        public frmDefaultPerformersAdd()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillBaseDataSource()) { Close(); return; }
            TimeStart.Value = new DateTime(2000, 1, 1, 08, 00, 00);
            TimeEnd.Value = new DateTime(2000, 1, 1, 16, 00, 00);
            cboCategories_SelectedIndexChanged(null, null);
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region cboCategories_SelectedIndexChanged
        private void cboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategories.SelectedIndex == 0) dgvData.DataSource =
                _ServicesDataSource.Where(Data => Data.IsActive).OrderBy(Data => Convert.ToInt32(Data.Code)).ToList();
            else dgvData.DataSource =
                _ServicesDataSource.Where(Data => Data.IsActive &&
                    Data.CategoryIX == Convert.ToInt16(cboCategories.SelectedValue))
                    .OrderBy(Data => Convert.ToInt32(Data.Code)).ToList();
        }
        #endregion

        #region btnClear_Click
        private void btnClear_Click(object sender, EventArgs e)
        { TimeStart.ValueObject = null; TimeEnd.ValueObject = null; }
        #endregion

        #region chkPhysician_CheckedChanged
        private void chkPhysician_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPhysician.Checked)
            {
                lblPerformers.Text = "نام پزشكان:";
                cboPerformers.DataSource = _PerformersDataSource.
                    Where(Data => Data.ID != null && Data.IsActive == true && Data.IsPhysician == true).ToList();
            }
            else
            {
                lblPerformers.Text = "نام كارشناسان:";
                cboPerformers.DataSource = _PerformersDataSource.
                    Where(Data => Data.ID != null && Data.IsActive == true && Data.IsExpert == true).ToList();
            }
        }
        #endregion

        #region btnAll_Click
        private void btnAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Cells[ColSelection.Index].Value = true;
            }
        }
        #endregion

        #region btnNone_Click
        private void btnNone_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Cells[ColSelection.Index].Value = false;
            }
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            #region Generate Days String
            Boolean ChkDays = false;
            String Days = String.Empty;
            if (cBoxDay1.Checked) { Days += "1"; ChkDays = true; } else Days += "0";
            if (cBoxDay2.Checked) { Days += "1"; ChkDays = true; } else Days += "0";
            if (cBoxDay3.Checked) { Days += "1"; ChkDays = true; } else Days += "0";
            if (cBoxDay4.Checked) { Days += "1"; ChkDays = true; } else Days += "0";
            if (cBoxDay5.Checked) { Days += "1"; ChkDays = true; } else Days += "0";
            if (cBoxDay6.Checked) { Days += "1"; ChkDays = true; } else Days += "0";
            if (cBoxDay7.Checked) { Days += "1"; ChkDays = true; } else Days += "0";
            #endregion

            #region Generate Times String
            String Times = String.Empty;
            if (TimeStart.ValueObject != null && TimeEnd.ValueObject != null)
            {
                if (TimeStart.Value.Hour < 10) Times += "0";
                Times += TimeStart.Value.Hour.ToString();
                if (TimeStart.Value.Minute < 10) Times += "0";
                Times += TimeStart.Value.Minute.ToString();
                if (TimeEnd.Value.Hour < 10) Times += "0";
                Times += TimeEnd.Value.Hour.ToString();
                if (TimeEnd.Value.Minute < 10) Times += "0";
                Times += TimeEnd.Value.Minute.ToString();
            }
            #endregion

            #region Validations
            // بررسی نسبت ساعت آغاز به پایان
            if (TimeStart.ValueObject != null && TimeEnd.ValueObject != null)
            {
                Int16 StartTime = Convert.ToInt16(Times.Substring(0, 4));
                Int16 EndTime = Convert.ToInt16(Times.Substring(4, 4));
                if (StartTime > EndTime)
                {
                    PMBox.Show("ساعت شروع از ساعت پایان بزرگ تر می باشد!\n" +
                               "لطفاً مجدداً بررسی و تصحیح نمایید.", "هشدار!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (StartTime == EndTime)
                {
                    PMBox.Show("ساعت شروع با ساعت پایان برابر می باشد!\n" +
                               "لطفاً مجدداً بررسی و تصحیح نمایید.", "هشدار!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            // هشدار به كاربر برای عدم انتخاب یك روز مشخص
            if (!ChkDays)
            {
                DialogResult Dr = PMBox.Show("هیچ یك از ایام هفته انتخاب نشده است!\n" +
                    "در این صورت این كارشناس یا پزشك برای تمام ایام هفته اعمال خواهد شد.\n" + "آیا مایل به اعمال تغییرات هستید؟"
                    , "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) return;
                Days = "1111111";
            }
            // نمایش خطا به كاربر برای انتخاب فقط یك بازه ساعت
            if ((TimeStart.ValueObject == null && TimeEnd.ValueObject != null) ||
                (TimeStart.ValueObject != null && TimeEnd.ValueObject == null))
            {
                PMBox.Show("فقط برای یكی از مقادیر ساعت شروع و پایان مقدار تعیین شده است!\n" +
                    "یا برای هر دو آیتم مقدار تعیین نمایید و یا با استفاده از دكمه ضربدر قرمز مقادیر آن را حذف نمایید."
                    , "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            // هشدار به كاربر برای عدم انتخاب بازه ساعت مشخص
            if (TimeStart.ValueObject == null && TimeEnd.ValueObject == null)
            {
                DialogResult Dr = PMBox.Show("مقداری برای ساعت شروع یا پایان انتخاب نشده است!\n" +
                    "در این صورت این كارشناس یا پزشك برای تمامی ساعات روز اعمال خواهد شد.\n" +
                    "آیا مایل به اعمال تغییرات هستید؟", "هشدار!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) return;
            }
            #endregion

            #region Add Selected Services For Default Performers
            Boolean IsAnyServiceSelected = false;
            foreach (DataGridViewRow row in dgvData.Rows)
                if (row.Cells[ColSelection.Index].Value != null && Convert.ToBoolean(row.Cells[ColSelection.Index].Value))
                {
                    IsAnyServiceSelected = true;
                    if (!CheckTimeConflict(Days, Times, row)) return;
                    DefaultPerformers NewItem = new DefaultPerformers();
                    NewItem.PerformerIX = Convert.ToInt16(cboPerformers.SelectedValue);
                    NewItem.ServiceIX = ((SP_SelectServicesListResult)row.DataBoundItem).ID;
                    NewItem.IsExpert = chkExpert.Checked;
                    NewItem.Days = Days;
                    NewItem.Period = Times;
                    DBLayerIMS.Manager.DBML.DefaultPerformers.InsertOnSubmit(NewItem);
                }
            #region Check If No Service Added
            if (!IsAnyServiceSelected)
            {
                PMBox.Show("هیچ خدمتی انتخاب نشده است!بررسی نمایید.", "خطا!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
            #endregion

            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ثبت اطلاعات پزشكان و كارشناسان پیش فرض در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            DialogResult = DialogResult.OK;
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean FillBaseDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات گروه های خدمات از بانك
        /// </summary>
        private Boolean FillBaseDataSource()
        {
            #region Fill Data Sources
            _CategoriesDataSource = DBLayerIMS.Services.ServCategoriesList;
            if (_CategoriesDataSource == null) return false;
            _CategoriesDataSource[0].Name = "(همه موارد)";
            _ServicesDataSource = DBLayerIMS.Services.ServicesList;
            if (_ServicesDataSource == null) return false;
            _PerformersDataSource = DBLayerIMS.Referrals.RefServPerformers;
            if (_PerformersDataSource == null) return false;
            if (_PerformersDataSource.Where(Data => Data.IsActive == true).ToList().Count == 1)
            {
                PMBox.Show("هیچ كادر پزشكی در سیستم ثبت نگردیده است!\n" +
                    "لطفاً ابتدا كادر پزشكی را تعریف نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try { _DefaultPerformersList = DBLayerIMS.Manager.DBML.DefaultPerformers.ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات پزشكان یا كارشناسان پیش فرض از بانك اطلاعات!" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.");
                LogManager.SaveLogEntry("Sepehr", "Services Settings", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error);
                return false;
            }
            #endregion
            #endregion

            #region Set ComboBoxes DataSource
            cboCategories.DataSource = _CategoriesDataSource;
            if (_PerformersDataSource.Where(Data => Data.IsActive == true && Data.IsExpert == true).Count() == 0)
            {
                lblPerformerChoice.Hide();
                chkExpert.Hide();
                chkPhysician.Checked = true;
                chkPhysician.Hide();
                cboPerformers.DataSource = _PerformersDataSource.
                    Where(Data => Data.IsActive == true && Data.IsPhysician == true).ToList();
            }
            else if (_PerformersDataSource.Where(Data => Data.IsActive == true && Data.IsPhysician == true).Count() == 0)
            {
                lblPerformerChoice.Hide();
                chkPhysician.Hide();
                chkExpert.Checked = true;
                chkExpert.Hide();
                cboPerformers.DataSource = _PerformersDataSource.
                    Where(Data => Data.ID != null && Data.IsActive == true && Data.IsExpert == true).ToList();
            }
            else
            {
                chkExpert.Checked = true;
                cboPerformers.DataSource = _PerformersDataSource.
                    Where(Data => Data.ID != null && Data.IsActive == true && Data.IsExpert == true).ToList();
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean CheckTimeConflict(String Days, String TimePeriod, DataGridViewRow row)
        /// <summary>
        /// تابعی برای تایید اعتبار ردیف خدمات وارد شده
        /// </summary>
        /// <returns></returns>
        private Boolean CheckTimeConflict(String Days, String TimePeriod, DataGridViewRow ServiceRow)
        {
            // بدست آوردن لیستی از كادر درمان پیش فرض ثبت شده برای خدمت جاری
            List<DefaultPerformers> FoundedDefaultPeformers = _DefaultPerformersList.
                Where(Data => Data.ServiceIX == ((SP_SelectServicesListResult)ServiceRow.DataBoundItem).ID &&
                    Data.IsExpert == chkExpert.Checked).ToList();
            // اگر قبلاً هیچ پیش فرضی برای سرویس جاری وجود نداشته باشد ، مقدار صحیح باز گردانده می شود
            if (FoundedDefaultPeformers.Count == 0) return true;

            StringBuilder TempErrorMessage = new StringBuilder();
            StringBuilder ErrorMessage = new StringBuilder();
            foreach (DefaultPerformers Item in FoundedDefaultPeformers)
            {
                #region Compare Days One By One
                // چك كردن مقایسه تك تك روز های تعیین شده با سطر جاری در مقایسه
                Boolean[] DaysConflictArray = new Boolean[7];
                Boolean AreDaysEqual = false;
                if (Days.Substring(0, 1) == Item.Days.Substring(0, 1) && Days.Substring(0, 1) == "1")
                { DaysConflictArray[0] = true; AreDaysEqual = true; }
                if (Days.Substring(1, 1) == Item.Days.Substring(1, 1) && Days.Substring(1, 1) == "1")
                { DaysConflictArray[1] = true; AreDaysEqual = true; }
                if (Days.Substring(2, 1) == Item.Days.Substring(2, 1) && Days.Substring(2, 1) == "1")
                { DaysConflictArray[2] = true; AreDaysEqual = true; }
                if (Days.Substring(3, 1) == Item.Days.Substring(3, 1) && Days.Substring(3, 1) == "1")
                { DaysConflictArray[3] = true; AreDaysEqual = true; }
                if (Days.Substring(4, 1) == Item.Days.Substring(4, 1) && Days.Substring(4, 1) == "1")
                { DaysConflictArray[4] = true; AreDaysEqual = true; }
                if (Days.Substring(5, 1) == Item.Days.Substring(5, 1) && Days.Substring(5, 1) == "1")
                { DaysConflictArray[5] = true; AreDaysEqual = true; }
                if (Days.Substring(6, 1) == Item.Days.Substring(6, 1) && Days.Substring(6, 1) == "1")
                { DaysConflictArray[6] = true; AreDaysEqual = true; }
                // اگر هیچ روز مشتركی بین خدمت جاری و خدمات پیش فرض تعریف شده وجود نداشته باشد حلقه ادامه می یابد
                if (!AreDaysEqual) continue;
                #endregion

                #region When TimePeriod & Item.Period Are Not Null Or Empty
                // بررسی اشتراك ساعتی بین سرویس ثبت شده و سرویس جاری برای ثبت
                if (!String.IsNullOrEmpty(TimePeriod) && !String.IsNullOrEmpty(Item.Period))
                {
                    Int16 NewStartTime = Convert.ToInt16(TimePeriod.Substring(0, 4));
                    Int16 NewEndTime = Convert.ToInt16(TimePeriod.Substring(4, 4));
                    Int16 SavedStartTime = Convert.ToInt16(Item.Period.Substring(0, 4));
                    Int16 SavedEndTime = Convert.ToInt16(Item.Period.Substring(4, 4));

                    #region When NewStartTime is Between SavedStartTime & SavedEndTime
                    // هنگامی كه ساعت شروع تعیین شده در بین ساعت شروع و پایان سطری می باشد كه در حال مقایسه است
                    if (NewStartTime >= SavedStartTime && NewStartTime < SavedEndTime)
                    {
                        //هنگامی كه ساعت شروع و پایان تعیین شده هر دو
                        //در بین ساعت شروع و پایان سطری [می باشد] كه در حال مقایسه است
                        if (NewEndTime <= SavedEndTime)
                        {
                            GenerateErrorMessage(DaysConflictArray, TempErrorMessage);
                            TempErrorMessage.AppendLine("در فاصله زمانی: " + TimePeriod.Substring(0, 2) + ":" +
                                TimePeriod.Substring(2, 2) + " تا " + TimePeriod.Substring(4, 2) + ":" + TimePeriod.Substring(6, 2));
                            // ReSharper disable AccessToModifiedClosure
                            SP_SelectPerformersResult PerformerData =
                                _PerformersDataSource.Where(Data => Data.ID == Item.PerformerIX).First();
                            // ReSharper restore AccessToModifiedClosure
                            TempErrorMessage.AppendLine("كادر درمان پیش فرض: " + PerformerData.FullName);
                        }
                        // هنگامی كه ساعت شروع تعیین شده در بین ساعت شروع و پایان سطر
                        // و ساعت پایان بعد از ساعت پایان سطری می باشد كه در حال مقایسه است
                        else
                        {
                            GenerateErrorMessage(DaysConflictArray, TempErrorMessage);
                            TempErrorMessage.AppendLine("در فاصله زمانی: " + TimePeriod.Substring(0, 2) + ":"
                                + TimePeriod.Substring(2, 2) + " تا " + Item.Period.Substring(4, 2) + ":" + Item.Period.Substring(6, 2));
                            // ReSharper disable AccessToModifiedClosure
                            SP_SelectPerformersResult PerformerData =
                                _PerformersDataSource.Where(Data => Data.ID == Item.PerformerIX).First();
                            // ReSharper restore AccessToModifiedClosure
                            TempErrorMessage.AppendLine("كادر درمان پیش فرض: " + PerformerData.FullName);
                        }
                    }
                    #endregion

                    #region  When NewStartTime is NOT Between  ItemStartTime && ItemtEndTime
                    // هنگامی كه ساعت شروع تعیین شده در بین ساعت شروع و پایان سطری كه در حال مقایسه است نمی باشد
                    else
                    {
                        // هنگامی كه ساعت شروع تعیین شده در بین ساعت شروع و پایان سطری كه در حال مقایسه است نمی باشد و 
                        // هنگامی كه ساعت پایان تعیین شده در بین ساعت شروع و پایان سطری كه در حال مقایسه است می باشد 
                        if (NewEndTime > SavedStartTime && NewEndTime <= SavedEndTime)
                        {
                            GenerateErrorMessage(DaysConflictArray, TempErrorMessage);
                            TempErrorMessage.AppendLine("در فاصله زمانی: " + Item.Period.Substring(0, 2) + ":" +
                                Item.Period.Substring(2, 2) + " تا " + TimePeriod.Substring(4, 2) + ":" + TimePeriod.Substring(6, 2));
                            // ReSharper disable AccessToModifiedClosure
                            SP_SelectPerformersResult PerformerData =
                                _PerformersDataSource.Where(Data => Data.ID == Item.PerformerIX).First();
                            // ReSharper restore AccessToModifiedClosure
                            TempErrorMessage.AppendLine("كادر درمان پیش فرض: " + PerformerData.FullName);
                        }
                        else
                        {
                            // هنگامی كه ساعت شروع تعیین شده از ساعت شروع سطر در حال مقایسه كوچكتر و 
                            // ساعت پایان تعیین شده از ساعت پایان سطر در حال مقایسه بزرگتر است
                            if (NewStartTime < SavedStartTime && NewEndTime > SavedEndTime)
                            {
                                GenerateErrorMessage(DaysConflictArray, TempErrorMessage);
                                TempErrorMessage.AppendLine("در فاصله زمانی: " + Item.Period.Substring(0, 2) + ":" +
                                    Item.Period.Substring(2, 2) + " تا " + Item.Period.Substring(4, 2) + ":" + Item.Period.Substring(6, 2));
                                // ReSharper disable AccessToModifiedClosure
                                SP_SelectPerformersResult PerformerData =
                                    _PerformersDataSource.Where(Data => Data.ID == Item.PerformerIX).First();
                                // ReSharper restore AccessToModifiedClosure
                                TempErrorMessage.AppendLine("كادر درمان پیش فرض: " + PerformerData.FullName);
                            }
                        }
                    }
                    #endregion
                }
                #endregion

                #region When TimePeriod || Item.Period Are Null Or Empty
                // هنگامی كه بازه زمانی سطر در حال مقایسه و یا بازه زمانی جدید به صورت تمام روز می باشد 
                else
                {
                    GenerateErrorMessage(DaysConflictArray, TempErrorMessage);
                    #region When TimePeriod Is Null Or Empty && Item.Period Is Not Null Or Empty
                    //هنگامی كه فقط بازه زمانی جدید به صورت تمام روز می باشد
                    if (!String.IsNullOrEmpty(Item.Period) && String.IsNullOrEmpty(TimePeriod))
                        TempErrorMessage.AppendLine("در فاصله زمانی: " + Item.Period.Substring(0, 2) + ":" +
                            Item.Period.Substring(2, 2) + " تا " + Item.Period.Substring(4, 2) + ":" + Item.Period.Substring(6, 2));
                    #endregion

                    #region When TimePeriod Is Not Null Or Empty && Item.Period Is Null Or Empty
                    //هنگامی كه فقط بازه زمانی سطر در حال مقایسه به صورت تمام روز می باشد
                    else if (String.IsNullOrEmpty(Item.Period) && !String.IsNullOrEmpty(TimePeriod))
                        TempErrorMessage.AppendLine("در فاصله زمانی: " + TimePeriod.Substring(0, 2) + ":" +
                            TimePeriod.Substring(2, 2) + " تا " + TimePeriod.Substring(4, 2) + ":" + TimePeriod.Substring(6, 2));
                    #endregion

                    #region When TimePeriod && Item.Period Are Not Null Or Empty
                    //هنگامی كه بازه زمانی سطر در حال مقایسه و یا بازه زمانی جدید هر دو به صورت تمام روز می باشد
                    else TempErrorMessage.AppendLine("بازه زمانی وارد شده در تمام ساعات روز مشترك است!");
                    #endregion

                    // ReSharper disable AccessToModifiedClosure
                    SP_SelectPerformersResult PerformerData =
                        _PerformersDataSource.Where(Data => Data.ID == Item.PerformerIX).First();
                    // ReSharper restore AccessToModifiedClosure
                    TempErrorMessage.AppendLine("كادر درمان پیش فرض: " + PerformerData.FullName);
                }
                #endregion
            }
            #region If There Is Conflict
            if (TempErrorMessage.Length != 0)
            {
                ErrorMessage.AppendLine("مدت زمان تعیین شده در بازه های زیر با سایر اطلاعات ثبت شده تداخل دارد: ");
                ErrorMessage.AppendLine("خدمت : \"" + _ServicesDataSource.
                    Where(DataGridViewRow => DataGridViewRow.ID ==
                    ((SP_SelectServicesListResult)ServiceRow.DataBoundItem).ID).First().Code + " - " + _ServicesDataSource.
                    Where(DataGridViewRow => DataGridViewRow.ID ==
                        ((SP_SelectServicesListResult)ServiceRow.DataBoundItem).ID).First().Name + "\"");
                ErrorMessage.Append(TempErrorMessage.ToString());
                PMBox.Show(ErrorMessage.ToString(), "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region GenerateErrorMessage(bool[] D, StringBuilder ErMessage)
        private static void GenerateErrorMessage(Boolean[] DaysList, StringBuilder ErrorMessage)
        {
            ErrorMessage.AppendLine();
            String NewString = "روزهای تداخل: \n";
            for (Int32 i = 0; i < 7; i++)
            {
                if (!DaysList[i]) continue;
                if (i == 0) NewString += "شنبه ،";
                if (i == 1) NewString += "یكشنبه ،";
                if (i == 2) NewString += "دوشنبه ،";
                if (i == 3) NewString += "سه شنبه ،";
                if (i == 4) NewString += "چهارشنبه ،";
                if (i == 5) NewString += "پنج شنبه ،";
                if (i == 6) NewString += "جمعه ،";
            }
            // حذف "و" آخر از عبارت
            NewString = NewString.Substring(0, NewString.Length - 2);
            ErrorMessage.AppendLine(NewString);
        }
        #endregion

        #endregion

    }
}