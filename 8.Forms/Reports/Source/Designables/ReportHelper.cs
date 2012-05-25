#region using

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Reports.Designables
{
    /// <summary>
    /// كلاس كمكی برای تولید ستون های قابل استفاده در گزارش های قابل طراحی
    /// </summary>
    internal static class ReportHelper
    {

        #region Fields
        private static List<DesignableReportsAddinCol> _DesignableReportsAddinCols;
        private static List<Column> _ColumnsList;
        private static Color[] _ColumnsColorsList;
        #endregion

        #region Properties

        #region Color[] ColumnsColorsList
        /// <summary>
        /// لیست رنگ ستون های قابل استفاده در گزارش های قابل طراحی
        /// </summary>
        internal static Color[] ColumnsColorsList
        {
            get
            {
                if (_ColumnsColorsList == null)
                {
                    _ColumnsColorsList = new Color[15];
                    _ColumnsColorsList[0] = Color.White;
                    _ColumnsColorsList[1] = Color.Pink;
                    _ColumnsColorsList[2] = Color.Khaki;
                    _ColumnsColorsList[3] = Color.PaleGreen;
                    _ColumnsColorsList[4] = Color.PowderBlue;
                    _ColumnsColorsList[5] = Color.White;
                    _ColumnsColorsList[6] = Color.Pink;
                    _ColumnsColorsList[7] = Color.Khaki;
                    _ColumnsColorsList[8] = Color.PaleGreen;
                    _ColumnsColorsList[9] = Color.PowderBlue;
                    _ColumnsColorsList[10] = Color.White;
                    _ColumnsColorsList[11] = Color.Pink;
                    _ColumnsColorsList[12] = Color.Khaki;
                    _ColumnsColorsList[13] = Color.PaleGreen;
                    _ColumnsColorsList[14] = Color.PowderBlue;
                }
                return _ColumnsColorsList;
            }
        }
        #endregion

        #region List<Column> ColumnsList
        /// <summary>
        /// لیست ستون های قابل استفاده در گزارش های قابل طراحی
        /// </summary>
        internal static List<Column> ColumnsList
        {
            get
            {
                if (_ColumnsList == null && !GenerateColumnsList()) return null;
                return _ColumnsList;
            }
        }
        #endregion

        #region List<DesignableReportsAddinCol> DesignableReportsAddinCols
        /// <summary>
        /// لیست ستون های اختصاصی در گزارش های قابل طراحی
        /// </summary>
        internal static List<DesignableReportsAddinCol> DesignableReportsAddinCols
        {
            get
            {
                if (_DesignableReportsAddinCols == null)
                    try
                    {
                        Table<DesignableReportsAddinCol> TempData =
                            DBLayerIMS.Manager.DBML.DesignableReportsAddinCols;
                        DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _DesignableReportsAddinCols = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان جستجوی اطلاعات از بانك اطلاعاتی وجود ندارد.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Reports Forms", Ex.Message + "\n" + Ex.StackTrace,
                            EventLogEntryType.Error); return null;
                    }
                    #endregion
                return _DesignableReportsAddinCols;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean GenerateColumnsList()
        /// <summary>
        /// تابعی برای تولید لیست ستون های قابل استفاده در برنامه
        /// </summary>
        /// <returns>تولید صحیح یا غیر صحیح</returns>
        private static Boolean GenerateColumnsList()
        {
            _ColumnsList = new List<Column>();
            Column Item = new Column();

            #region 1 - Patient Data
            Item.ColumnName = "RowNumber";
            Item.ColumnDescription = "ردیف";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 1;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "PatientID";
            Item.ColumnDescription = "شماره بیمار";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 1;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "PatientName";
            Item.ColumnDescription = "نام بیمار";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 1;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "PatientAge";
            Item.ColumnDescription = "سن بیمار";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 1;
            _ColumnsList.Add(Item);
            #endregion

            #region 2 - Pat Addin Data
            foreach (PatAdditionalColumn PatCol in DBLayerIMS.Referrals.PatAddinColsList)
            {
                Item = new Column();
                Item.ColumnName = "PatAddinCol" + PatCol.FieldName;
                Item.ColumnDescription = "اطلاعات پویا بیمار - " + PatCol.Title;
                Item.IsAdditionalInformation = false;
                Item.GroupID = 2;
                _ColumnsList.Add(Item);
            }
            #endregion

            #region 3 - Ref Base Data
            Item = new Column();
            Item.ColumnName = "RefDate";
            Item.ColumnDescription = "تاریخ پذیرش";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 3;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefTime";
            Item.ColumnDescription = "ساعت پذیرش";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 3;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefStatus";
            Item.ColumnDescription = "وضعیت مراجعه";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 3;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefPrescribDate";
            Item.ColumnDescription = "تاریخ نسخه";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 3;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefWeight";
            Item.ColumnDescription = "وزن مراجعه بیمار";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 3;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefPhysLastName";
            Item.ColumnDescription = "نام خانوادگی پزشك درخواست كننده";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 3;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefPhysFullName";
            Item.ColumnDescription = "نام كامل پزشك درخواست كننده";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 3;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefPhysMedicalID";
            Item.ColumnDescription = "نظام پزشكی پزشك درخواست كننده";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 3;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefAdmitterName";
            Item.ColumnDescription = "كاربر پذیرش كننده مراجعه";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 3;
            _ColumnsList.Add(Item);
            #endregion

            #region 4 - Ref Addin Data
            foreach (RefAdditionalColumn RefCol in DBLayerIMS.Referrals.RefAddinColsList)
            {
                Item = new Column();
                Item.ColumnName = "RefAddinCol" + RefCol.FieldName;
                Item.ColumnDescription = "اطلاعات پویا مراجعه - " + RefCol.Title;
                Item.IsAdditionalInformation = false;
                Item.GroupID = 4;
                _ColumnsList.Add(Item);
            }
            #endregion

            #region 5 - Ref Ins Data
            Item = new Column();
            Item.ColumnName = "RefIns1Name";
            Item.ColumnDescription = "نام بیمه اول";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 5;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefIns1Num";
            Item.ColumnDescription = "شماره بیمه اول";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 5;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefIns1Validation";
            Item.ColumnDescription = "تاریخ اعتبار بیمه اول";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 5;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefIns1PageNum";
            Item.ColumnDescription = "شماره صفحه بیمه اول";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 5;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefIns2Name";
            Item.ColumnDescription = "نام بیمه دوم";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 5;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefIns2Num";
            Item.ColumnDescription = "شماره بیمه دوم";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 5;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefIns2Validation";
            Item.ColumnDescription = "تاریخ اعتبار بیمه دوم";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 5;
            _ColumnsList.Add(Item);
            #endregion

            #region 6 - Ref Services Base Data
            Item = new Column();
            Item.ColumnName = "ServiceCode";
            Item.ColumnDescription = "كد خدمت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 6;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "ServiceName";
            Item.ColumnDescription = "نام كامل خدمات";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 6;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "ServiceCategories";
            Item.ColumnDescription = "طبقه بندی خدمات";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 6;
            _ColumnsList.Add(Item);
            
            Item = new Column();
            Item.ColumnName = "ServiceExpertName";
            Item.ColumnDescription = "كارشناس خدمات";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 6;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "ServicePhysName";
            Item.ColumnDescription = "پزشك خدمات";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 6;
            _ColumnsList.Add(Item);
            #endregion

            #region 7 - Ref Services Price
            Item = new Column();
            Item.ColumnName = "RefServicesPriceFree";
            Item.ColumnDescription = "جمع قیمت بدون بیمه خدمات";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 7;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefServicesPriceGov";
            Item.ColumnDescription = "جمع قیمت دولتی خدمات";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 7;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefServicesTotalPayable";
            Item.ColumnDescription = "جمع پرداختنی خدمات";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 7;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefServicesSumIns1Price";
            Item.ColumnDescription = "جمع قیمت خدمات از نظر بیمه 1";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 7;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefServicesSumIns1PartPrice";
            Item.ColumnDescription = "جمع سهم بیمه 1 برای خدمات";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 7;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefServicesSumIns1PatPart";
            Item.ColumnDescription = "جمع سهم بیمار از بیمه 1 برای خدمات";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 7;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefServicesSumIns2Price";
            Item.ColumnDescription = "جمع قیمت خدمات از نظر بیمه 2";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 7;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefServicesSumIns2PartPrice";
            Item.ColumnDescription = "جمع سهم بیمه 2 برای خدمات";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 7;
            _ColumnsList.Add(Item);
            #endregion

            #region 8 - Ref Services Addin Prices
            foreach (AdditionalPriceColumn Col in DBLayerIMS.Services.ServAddinPriceColsList)
            {
                Item = new Column();
                Item.ColumnName = "ServicePrice" + Col.ColumnName;
                Item.ColumnDescription = "جمع قیمت پایه خدمات: " + Col.Name;
                Item.IsAdditionalInformation = true;
                Item.GroupID = 8;
                _ColumnsList.Add(Item);
            }
            #endregion

            #region 9 - Ref Costs & Discounts Data
            Item = new Column();
            Item.ColumnName = "DiscountsTitle";
            Item.ColumnDescription = "عنوان تخفیف ها";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 9;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "DiscountsDateTime";
            Item.ColumnDescription = "تاریخ و ساعت تخفیف ها";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 9;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "DiscountsUserFullName";
            Item.ColumnDescription = "نام تخفیف دهندگان";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 9;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "CostsTitle";
            Item.ColumnDescription = "عنوان هزینه ها";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 9;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "CostsDateTime";
            Item.ColumnDescription = "تاریخ و ساعت هزینه ها";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 9;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "CostsUserFullName";
            Item.ColumnDescription = "نام هزینه دهندگان";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 9;
            _ColumnsList.Add(Item);
            
            Item = new Column();
            Item.ColumnName = "SumDiscount";
            Item.ColumnDescription = "مجموع تخفیف های مراجعه";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 9;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "SumCost";
            Item.ColumnDescription = "مجموع هزینه های مراجعه";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 9;
            _ColumnsList.Add(Item);
            #endregion

            #region 10 - Ref Costs
            foreach (CostsAndDiscountsType result in DBLayerIMS.Account.CostAndDiscountFullList.Where(Data => Data.IsCost))
            {
                Item = new Column();
                Item.ColumnName = "RefCosts" + result.ID;
                Item.ColumnDescription = "مبلغ هزینه مراجعه - " + result.Name;
                Item.IsAdditionalInformation = true;
                Item.GroupID = 10;
                _ColumnsList.Add(Item);
            }
            #endregion

            #region 11 - Ref Discounts
            foreach (CostsAndDiscountsType result in DBLayerIMS.Account.CostAndDiscountFullList.Where(Data => !Data.IsCost))
            {
                Item = new Column();
                Item.ColumnName = "RefDiscounts" + result.ID;
                Item.ColumnDescription = "مبلغ تخفیف مراجعه - " + result.Name;
                Item.IsAdditionalInformation = true;
                Item.GroupID = 11;
                _ColumnsList.Add(Item);
            }
            #endregion

            #region 12 - Ref Trans Data
            Item = new Column();
            Item.ColumnName = "TransType";
            Item.ColumnDescription = "نوع دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransDate";
            Item.ColumnDescription = "تاریخ دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransTime";
            Item.ColumnDescription = "ساعت دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransDescription";
            Item.ColumnDescription = "شرح دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransCheckNumber";
            Item.ColumnDescription = "شماره فیش یا چك دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransCheckDate";
            Item.ColumnDescription = "تاریخ فیش یا چك دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransAccountNumber";
            Item.ColumnDescription = "شماره حساب دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransAccountType";
            Item.ColumnDescription = "نوع حساب دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransBankName";
            Item.ColumnDescription = "نام بانك دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransBranchCode";
            Item.ColumnDescription = "شماره شعبه دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransBranchName";
            Item.ColumnDescription = "نام شعبه دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransCashierName";
            Item.ColumnDescription = "صندوقدار دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransCashName";
            Item.ColumnDescription = "صندوق دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "TransValue";
            Item.ColumnDescription = "مبلغ دریافت / بازپرداخت";
            Item.IsAdditionalInformation = false;
            Item.GroupID = 12;
            _ColumnsList.Add(Item);
            #endregion

            #region 13 - Ref Account Info
            Item = new Column();
            Item.ColumnName = "RefPayable";
            Item.ColumnDescription = "پرداختنی كل مراجعه";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 13;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "SumTransBalance";
            Item.ColumnDescription = "تراز پرداخت های مراجعه بیمار";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 13;
            _ColumnsList.Add(Item);

            Item = new Column();
            Item.ColumnName = "RefRemainValue";
            Item.ColumnDescription = "باقی مانده مراجعه";
            Item.IsAdditionalInformation = true;
            Item.GroupID = 13;
            _ColumnsList.Add(Item);
            #endregion

            #region 14 - Report Dynamic Fields
            foreach (DesignableReportsAddinCol Col in DesignableReportsAddinCols)
            {
                Item = new Column();
                Item.ColumnName = "ReportAddinCol" + Col.FieldName;
                Item.ColumnDescription = "ستون پویا گزارش - " + Col.Title;
                Item.IsAdditionalInformation = false;
                Item.GroupID = 14;
                _ColumnsList.Add(Item);
            }
            #endregion

            return true;
        }
        #endregion

        #region internal void CleanTempData()
        /// <summary>
        /// تابعی برای تخلیه اطلاعات موجود در سیستم
        /// </summary>
        internal static void CleanTempData()
        {
            _ColumnsList = null;
            _DesignableReportsAddinCols = null;
        }
        #endregion

        #endregion

        #region internal class Column
        /// <summary>
        /// كلاسی برای تعیین آیتم های قابل استفاده در گزارش های قابل طراحی
        /// </summary>
        internal class Column
        {
            public String ColumnName { get; set; }
            public String ColumnDescription { get; set; }
            public Boolean IsAdditionalInformation { get; set; }
            public Int16 GroupID { get; set; }
        }
        #endregion

    }
}