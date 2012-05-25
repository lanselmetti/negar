#region using

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Reports.Designables.Report
{
    /// <summary>
    /// كلاسی برای تولید ردیف های گزارش های قابل طراحی
    /// </summary>
    internal static class ReportGenerator
    {

        #region Fields

        #region static DataTable _FinalResultDT
        /// <summary>
        /// جدول نتیجه نهایی گزارش جهت نمایش برای كاربر
        /// </summary>
        private static DataTable _FinalResultDT;
        #endregion

        #endregion

        #region Properties

        #region DataTable FinalResultDataTable
        /// <summary>
        /// جدول نتیجه نهایی گزارش جهت نمایش برای كاربر
        /// </summary>
        internal static DataTable FinalResultDataTable
        {
            get { return _FinalResultDT; }
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean AddAndGenerateReportRow(Int32 PatID, Int32 RefID)
        /// <summary>
        ///  تابع آماده سازی یك ردیف از گزارش بر اساس ستون های انتخاب شده آن و افزودن به نتیجه نهایی
        /// </summary>
        /// <return>صحت انجام كار</return>
        internal static Boolean AddAndGenerateReportRow(Int32 PatID, Int32 RefID)
        {
            RefList RefItem = DBLayerIMS.Referrals.GetRefDataByID(RefID);
            if (RefItem == null) return false;
            DataRow NewRow = _FinalResultDT.NewRow();

            #region Fill Cells Data

            #region RowNumber
            if (_FinalResultDT.Columns.Contains("RowNumber"))
                NewRow["RowNumber"] = _FinalResultDT.Rows.Count + 1;
            #endregion

            #region Patient Data
            if (_FinalResultDT.Columns.Contains("PatientID") ||
                _FinalResultDT.Columns.Contains("PatientName") || _FinalResultDT.Columns.Contains("PatientAge"))
            {
                PatList PatData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(PatID);
                if (PatData == null) return false;

                #region PatientID
                if (_FinalResultDT.Columns.Contains("PatientID"))
                    NewRow["PatientID"] = PatData.PatientID;
                #endregion

                #region PatientName
                if (_FinalResultDT.Columns.Contains("PatientName"))
                {
                    if (String.IsNullOrEmpty(PatData.FirstName)) NewRow["PatientName"] = PatData.LastName;
                    else NewRow["PatientName"] = PatData.FirstName + " " + PatData.LastName;
                }
                #endregion

                #region PatientAge
                if (_FinalResultDT.Columns.Contains("PatientAge"))
                {
                    if (PatData.BirthDate == null) NewRow["PatientAge"] = String.Empty;
                    else NewRow["PatientAge"] = (DateTime.Now.Year - PatData.BirthDate.Value.Year).ToString();
                }
                #endregion

            }
            #endregion

            #region PatAdditionalColumn
            foreach (PatAdditionalColumn PatCol in DBLayerIMS.Referrals.PatAddinColsList)
            {
                if (!_FinalResultDT.Columns.Contains("PatAddinCol" + PatCol.FieldName)) continue;
                NewRow["PatAddinCol" + PatCol.FieldName] = String.Empty;
                String Command =
                    "SELECT * FROM [ImagingSystem].[Referrals].[PatAdditionalData] WHERE [PatientIX] = " + PatID;
                DataTable Result = DBLayerIMS.Manager.ExecuteQuery(Command, 5);
                if (Result == null) return false;
                if (Result.Columns.Contains(PatCol.FieldName) && Result.Rows.Count != 0)
                    NewRow["PatAddinCol" + PatCol.FieldName] = Result.Rows[0][PatCol.FieldName].ToString();
            }
            foreach (DataColumn Col in _FinalResultDT.Columns)
                if (Col.ColumnName.Length > 12 && Col.ColumnName.Substring(0, 9) == "PatAddinCol" &&
                    DBLayerIMS.Referrals.PatAddinColsList.Where(Data => Data.ID ==
                        Convert.ToInt16(Col.ColumnName.Substring(9, Col.ColumnName.Length))).Count() == 0)
                    NewRow[Col] = "حذف شده";
            #endregion

            #region Ref Base Data
            if (_FinalResultDT.Columns.Contains("RefDate") || _FinalResultDT.Columns.Contains("RefTime") ||
                _FinalResultDT.Columns.Contains("RefStatus") || _FinalResultDT.Columns.Contains("RefPrescribDate") ||
                _FinalResultDT.Columns.Contains("RefWeight") || _FinalResultDT.Columns.Contains("RefPhysLastName") ||
                _FinalResultDT.Columns.Contains("RefPhysFullName") || _FinalResultDT.Columns.Contains("RefPhysMedicalID") ||
                _FinalResultDT.Columns.Contains("RefAdmitterName") ||
                _FinalResultDT.Columns.Contains("RefIns1Name") || _FinalResultDT.Columns.Contains("RefIns1Num") ||
                _FinalResultDT.Columns.Contains("RefIns1Validation") || _FinalResultDT.Columns.Contains("RefIns1PageNum") ||
                _FinalResultDT.Columns.Contains("RefIns2Name") || _FinalResultDT.Columns.Contains("RefIns2Num") ||
                _FinalResultDT.Columns.Contains("RefIns2Validation"))
            {
                #region RefDate
                if (_FinalResultDT.Columns.Contains("RefDate"))
                    NewRow["RefDate"] = StringDateTime.DateTimeToDateString(RefItem.RegisterDate);
                #endregion

                #region RefTime
                if (_FinalResultDT.Columns.Contains("RefTime"))
                    NewRow["RefTime"] = StringDateTime.DateTimeToTimeString(RefItem.RegisterDate);
                #endregion

                #region RefStatus
                if (_FinalResultDT.Columns.Contains("RefStatus"))
                {
                    if (RefItem.ReferStatusIX == null) NewRow["RefStatus"] = String.Empty;
                    else NewRow["RefStatus"] = DBLayerIMS.Referrals.RefStatusList.
                        Where(Data => Data.ID == RefItem.ReferStatusIX).First().Title;
                }
                #endregion

                #region RefPrescribDate
                if (_FinalResultDT.Columns.Contains("RefPrescribDate"))
                    NewRow["RefPrescribDate"] = StringDateTime.DateTimeToDateString(RefItem.PrescriptionDate);
                #endregion

                #region RefWeight
                if (_FinalResultDT.Columns.Contains("RefWeight"))
                {
                    if (RefItem.Weight == null) NewRow["RefWeight"] = String.Empty;
                    else NewRow["RefWeight"] = RefItem.Weight.Value.ToString();
                }
                #endregion

                #region RefPhysician
                if (_FinalResultDT.Columns.Contains("RefPhysLastName") ||
                    _FinalResultDT.Columns.Contains("RefPhysFullName") ||
                    _FinalResultDT.Columns.Contains("RefPhysNumber"))
                {
                    RefPhysician ReferPhysData;
                    if (RefItem.ReferPhysicianIX == null)
                    {
                        #region RefPhysLastName
                        if (_FinalResultDT.Columns.Contains("RefPhysLastName"))
                            NewRow["RefPhysLastName"] = String.Empty;
                        #endregion

                        #region RefPhysFullName
                        if (_FinalResultDT.Columns.Contains("RefPhysFullName"))
                            NewRow["RefPhysFullName"] = String.Empty;
                        #endregion

                        #region RefPhysMedicalID
                        if (_FinalResultDT.Columns.Contains("RefPhysMedicalID"))
                            NewRow["RefPhysMedicalID"] = String.Empty;
                        #endregion
                    }
                    else
                    {
                        ReferPhysData = Negar.DBLayerPMS.ClinicData.GetRefPhysBaseDataByID(RefItem.ReferPhysicianIX.Value);
                        if (ReferPhysData == null) return false;
                        #region RefPhysLastName
                        if (_FinalResultDT.Columns.Contains("RefPhysLastName"))
                            NewRow["RefPhysLastName"] = ReferPhysData.LastName;
                        #endregion

                        #region RefPhysFullName
                        if (_FinalResultDT.Columns.Contains("RefPhysFullName"))
                            NewRow["RefPhysFullName"] = ReferPhysData.FirstName + " " + ReferPhysData.LastName;
                        #endregion

                        #region RefPhysMedicalID
                        if (_FinalResultDT.Columns.Contains("RefPhysMedicalID"))
                            NewRow["RefPhysMedicalID"] = ReferPhysData.MedicalID;
                        #endregion
                    }
                }
                #endregion

                #region RefAdmitterName
                if (_FinalResultDT.Columns.Contains("RefAdmitterName"))
                    NewRow["RefAdmitterName"] = Negar.DBLayerPMS.Security.UsersList.
                        Where(Data => Data.ID == RefItem.AdmitterIX).First().FullName;
                #endregion

                #region RefIns1Name
                if (_FinalResultDT.Columns.Contains("RefIns1Name"))
                {
                    if (RefItem.Ins1IX == null) NewRow["RefIns1Name"] = String.Empty;
                    else NewRow["RefIns1Name"] = DBLayerIMS.Insurance.InsFullList.
                        Where(Data => Data.ID == RefItem.Ins1IX).First().Name;
                }
                #endregion

                #region RefIns1Num
                if (_FinalResultDT.Columns.Contains("RefIns1Num"))
                    NewRow["RefIns1Num"] = RefItem.Ins1Num1;
                #endregion

                #region RefIns1Validation
                if (_FinalResultDT.Columns.Contains("RefIns1Validation"))
                    NewRow["RefIns1Validation"] = StringDateTime.DateTimeToDateString(RefItem.Ins1Validation);
                #endregion

                #region RefIns1PageNum
                if (_FinalResultDT.Columns.Contains("RefIns1PageNum"))
                    NewRow["RefIns1PageNum"] = RefItem.Ins1PageNum;
                #endregion

                #region RefIns2Name
                if (_FinalResultDT.Columns.Contains("RefIns2Name"))
                {
                    if (RefItem.Ins2IX == null) NewRow["RefIns2Name"] = String.Empty;
                    else NewRow["RefIns2Name"] = DBLayerIMS.Insurance.InsFullList.
                        Where(Data => Data.ID == RefItem.Ins2IX).First().Name;
                }
                #endregion

                #region RefIns2Num
                if (_FinalResultDT.Columns.Contains("RefIns2Num"))
                    NewRow["RefIns2Num"] = RefItem.Ins2Num;
                #endregion

                #region RefIns2Validation
                if (_FinalResultDT.Columns.Contains("RefIns2Validation"))
                    NewRow["RefIns2Validation"] = StringDateTime.DateTimeToDateString(RefItem.Ins2Validation);
                #endregion
            }
            #endregion

            #region RefAdditionalColumn
            foreach (RefAdditionalColumn PatCol in DBLayerIMS.Referrals.RefAddinColsList)
            {
                if (!_FinalResultDT.Columns.Contains("RefAddinCol" + PatCol.FieldName)) continue;
                NewRow["RefAddinCol" + PatCol.FieldName] = String.Empty;
                String Command =
                    "SELECT * FROM [ImagingSystem].[Referrals].[RefAdditionalData] WHERE [ReferralIX] = " + RefID;
                DataTable Result = DBLayerIMS.Manager.ExecuteQuery(Command, 5);
                if (Result == null) return false;
                if (Result.Columns.Contains(PatCol.FieldName) && Result.Rows.Count != 0)
                    NewRow["RefAddinCol" + PatCol.FieldName] = Result.Rows[0][PatCol.FieldName].ToString();
            }
            foreach (DataColumn Col in _FinalResultDT.Columns)
                if (Col.ColumnName.Length > 12 && Col.ColumnName.Substring(0, 9) == "RefAddinCol" &&
                    DBLayerIMS.Referrals.PatAddinColsList.Where(Data => Data.ID ==
                        Convert.ToInt16(Col.ColumnName.Substring(9, Col.ColumnName.Length))).Count() == 0)
                    NewRow[Col] = "حذف شده";
            #endregion

            #region Ref Services
            Boolean AnyAdditionalPriceColumn = false;
            foreach (AdditionalPriceColumn Col in DBLayerIMS.Services.ServAddinPriceColsList)
                if (_FinalResultDT.Columns.Contains("ServicePrice" + Col.ColumnName))
                { AnyAdditionalPriceColumn = true; break; }

            if (AnyAdditionalPriceColumn || _FinalResultDT.Columns.Contains("ServiceCode") ||
                _FinalResultDT.Columns.Contains("ServiceName") || _FinalResultDT.Columns.Contains("ServiceCategories") ||
                _FinalResultDT.Columns.Contains("ServiceExpertName") || _FinalResultDT.Columns.Contains("ServicePhysName") ||
                _FinalResultDT.Columns.Contains("RefServicesPriceFree") || _FinalResultDT.Columns.Contains("RefServicesPriceGov") ||
                _FinalResultDT.Columns.Contains("RefServicesTotalPayable") ||
                _FinalResultDT.Columns.Contains("RefServicesSumIns1Price") ||
                _FinalResultDT.Columns.Contains("RefServicesSumIns1PatPart") ||
                _FinalResultDT.Columns.Contains("RefServicesSumIns1PartPrice") ||
                _FinalResultDT.Columns.Contains("RefServicesSumIns2Price") ||
                _FinalResultDT.Columns.Contains("RefServicesSumIns2PartPrice"))
            {
                List<RefService> CurrentRefServices;
                try
                {
                    IQueryable<RefService> TempData = DBLayerIMS.Manager.DBML.RefServices.
                        Where(Data => Data.ReferralIX == RefID && Data.IsActive);
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                    CurrentRefServices = TempData.ToList();
                }
                #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Sepehr", "Reports - Designables",
                        Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return false;
                }
                #endregion

                #region ServiceCode
                if (_FinalResultDT.Columns.Contains("ServiceCode"))
                {
                    String Codes = String.Empty;
                    foreach (RefService refService in CurrentRefServices)
                    {
                        String Code = DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == refService.ServiceIX).First().Code;
                        if (!String.IsNullOrEmpty(Code)) Codes += " " + Code + " - ";
                    }
                    if (!String.IsNullOrEmpty(Codes)) NewRow["ServiceCode"] = Codes.Substring(0, Codes.Length - 2).Trim();
                }
                #endregion

                #region ServiceName
                if (_FinalResultDT.Columns.Contains("ServiceName"))
                {
                    String TempData = String.Empty;
                    foreach (RefService Srv in CurrentRefServices)
                    {
                        List<SP_SelectServicesListResult> Temp =
                            DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == Srv.ServiceIX).ToList();
                        if (Temp.Count() != 0) TempData += " " + Temp.First().Name + " ,";
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["ServiceName"] = TempData.Substring(1, TempData.Length - 2).Trim();
                }
                #endregion

                #region ServiceCategories
                if (_FinalResultDT.Columns.Contains("ServiceCategories"))
                {
                    String TempData = String.Empty;
                    foreach (RefService Srv in CurrentRefServices)
                    {
                        Int16? CategoryID =
                            DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == Srv.ServiceIX).First().CategoryIX;
                        if (CategoryID != null)
                        {
                            String CatName = DBLayerIMS.Services.ServCategoriesList.
                                Where(Data => Data.ID == CategoryID.Value).Select(Data => Data.Name).First();
                            TempData += " " + CatName + " ,";
                        }
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["ServiceCategories"] = TempData.Substring(1, TempData.Length - 2).Trim();
                    else NewRow["ServiceCategories"] = String.Empty;
                }
                #endregion

                #region ServiceExpertName
                if (_FinalResultDT.Columns.Contains("ServiceExpertName"))
                {
                    String TempData = String.Empty;
                    foreach (RefService refService in CurrentRefServices)
                    {
                        if (refService.ExpertIX == null) continue;
                        String LastName =
                            DBLayerIMS.Referrals.RefServPerformers.Where(Data => Data.ID == refService.ExpertIX).First().FullName;
                        TempData += " " + LastName + " - ";
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["ServiceExpertName"] = TempData.Substring(1, TempData.Length - 2).Trim();
                }
                #endregion

                #region ServicePhysName
                if (_FinalResultDT.Columns.Contains("ServicePhysName"))
                {
                    String TempData = String.Empty;
                    foreach (RefService refService in CurrentRefServices)
                    {
                        if (refService.PhysicianIX == null) continue;
                        String FullName =
                            DBLayerIMS.Referrals.RefServPerformers.Where(Data => Data.ID == refService.PhysicianIX).First().FullName;
                        TempData += " " + FullName + " - ";
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["ServicePhysName"] = TempData.Substring(1, TempData.Length - 2).Trim();
                }
                #endregion

                #region RefServicesPriceFree
                if (_FinalResultDT.Columns.Contains("RefServicesPriceFree"))
                {
                    Int32 Temp = 0;
                    foreach (RefService Srv in CurrentRefServices)
                    {
                        List<SP_SelectServicesListResult> Temp1 =
                            DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == Srv.ServiceIX).ToList();
                        if (Temp1.Count != 0)
                            Temp += Temp1.First().PriceFree;
                        else { Temp = 0; break; }
                    }
                    NewRow["RefServicesPriceFree"] = Temp.ToString();
                }
                #endregion

                #region RefServicesPriceGov
                if (_FinalResultDT.Columns.Contains("RefServicesPriceGov"))
                {
                    Int32 Temp = 0;
                    foreach (RefService Srv in CurrentRefServices)
                        Temp += DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == Srv.ServiceIX).First().PriceGov;
                    NewRow["RefServicesPriceGov"] = Temp.ToString();
                }
                #endregion

                #region RefServicesTotalPayable
                if (_FinalResultDT.Columns.Contains("RefServicesTotalPayable"))
                    NewRow["RefServicesTotalPayable"] = DBLayerIMS.Manager.DBML.FK_CalcRefServicesPayable(RefID).ToString();
                #endregion

                #region Additional Price Column
                foreach (AdditionalPriceColumn Col in DBLayerIMS.Services.ServAddinPriceColsList)
                    if (_FinalResultDT.Columns.Contains("ServicePrice" + Col.ColumnName))
                    {
                        Int32 TempData = 0;
                        foreach (RefService Srv in CurrentRefServices)
                        {
                            DataTable Result = DBLayerIMS.Manager.ExecuteQuery("SELECT TOP 1 " + Col.ColumnName +
                                " FROM [ImagingSystem].[Services].[AdditionalPriceData] WHERE [ServiceIX] = " + Srv.ServiceIX, 5);
                            if (Result == null) return false;
                            if (Result.Rows.Count != 0 && Result.Rows[0][0] != DBNull.Value) TempData += Convert.ToInt32(Result.Rows[0][0]);
                        }
                        NewRow["ServicePrice" + Col.ColumnName] = TempData;
                    }
                #endregion

                #region Ref Services Summation
                List<RefService> ServiceInsFilter = CurrentRefServices.Where(Data => Data.IsIns1Cover == true).ToList();
                Int32? SumIns1Price = 0;
                Int32? SumIns1Part = 0;
                Int32? SumIns2Price = 0;
                Int32? SumIns2Part = 0;
                foreach (RefService refService in ServiceInsFilter)
                {
                    SumIns1Price += refService.Quantity * refService.Ins1Price;
                    SumIns1Part += refService.Quantity * refService.Ins1PartPrice;
                    SumIns2Price += refService.Quantity * refService.Ins2Price;
                    SumIns2Price += refService.Quantity * refService.Ins2PartPrice;
                }

                #region RefServicesSumIns1Price
                if (_FinalResultDT.Columns.Contains("RefServicesSumIns1Price"))
                    NewRow["RefServicesSumIns1Price"] = SumIns1Price;
                #endregion

                #region RefServicesSumIns1PatPart
                if (_FinalResultDT.Columns.Contains("RefServicesSumIns1PatPart"))
                    NewRow["RefServicesSumIns1PatPart"] = SumIns1Price.Value - SumIns1Part.Value;
                #endregion

                #region RefServicesSumIns1PartPrice
                if (_FinalResultDT.Columns.Contains("RefServicesSumIns1PartPrice"))
                    NewRow["RefServicesSumIns1PartPrice"] = SumIns1Part.Value;
                #endregion

                #region RefServicesSumIns2Price
                if (_FinalResultDT.Columns.Contains("RefServicesSumIns2Price"))
                    NewRow["RefServicesSumIns2Price"] = SumIns2Price;
                #endregion

                #region RefServicesSumIns2PartPrice
                if (_FinalResultDT.Columns.Contains("RefServicesSumIns2PartPrice"))
                    NewRow["RefServicesSumIns2PartPrice"] = SumIns2Part.Value;
                #endregion

                #endregion
            }
            #endregion

            #region Ref Costs And Discounts
            if (_FinalResultDT.Columns.Contains("DiscountsTitle") || _FinalResultDT.Columns.Contains("DiscountsDateTime") ||
                _FinalResultDT.Columns.Contains("DiscountsUserFullName") || _FinalResultDT.Columns.Contains("CostsTitle") ||
                _FinalResultDT.Columns.Contains("CostsDateTime") || _FinalResultDT.Columns.Contains("CostsUserFullName") ||
                _FinalResultDT.Columns.Contains("SumDiscount") || _FinalResultDT.Columns.Contains("SumCost"))
            {
                List<RefCostsAndDiscount> CurrentRefCD;
                List<RefCostsAndDiscount> RefCost;
                List<RefCostsAndDiscount> RefDiscount;
                try
                {
                    IQueryable<RefCostsAndDiscount> TempData = DBLayerIMS.Manager.DBML.
                    RefCostsAndDiscounts.Where(Data => Data.ReferralIX == RefID);
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                    CurrentRefCD = TempData.ToList();
                    RefCost = CurrentRefCD.Where(Data => Data.CostsAndDiscountsType.IsCost).ToList();
                    RefDiscount = CurrentRefCD.Where(Data => !Data.CostsAndDiscountsType.IsCost).ToList();
                }
                #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Sepehr", "Reports - Designables",
                        Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return false;
                }
                #endregion

                #region DiscountsTitle
                if (_FinalResultDT.Columns.Contains("DiscountsTitle"))
                {
                    String TempData = String.Empty;
                    foreach (RefCostsAndDiscount Discounts in RefDiscount)
                        TempData += " " + Discounts.CostsAndDiscountsType.Name + " ,";
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["DiscountsTitle"] = TempData.Substring(1, TempData.Length - 2).Trim();
                }
                #endregion

                #region DiscountsDateTime
                if (_FinalResultDT.Columns.Contains("DiscountsDateTime"))
                {
                    String TempData = String.Empty;
                    foreach (RefCostsAndDiscount Dis in RefDiscount)
                    {
                        TempData += " " + StringDateTime.DateTimeToDateString(Dis.Date) + " - " +
                            StringDateTime.DateTimeToTimeString(Dis.Date) + " ,";
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["DiscountsDateTime"] = TempData.Substring(1, TempData.Length - 2).Trim();
                }
                #endregion

                #region DiscountsUserFullName
                if (_FinalResultDT.Columns.Contains("DiscountsUserFullName"))
                {
                    String TempData = String.Empty;
                    foreach (RefCostsAndDiscount Dis in RefDiscount)
                    {
                        List<SP_SelectUsersResult> Temp =
                            Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID == Dis.CashierIX).ToList();
                        if (Temp.Count != 0) TempData += " " + Temp.First().FullName + " ,";
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["DiscountsUserFullName"] = TempData.Substring(1, TempData.Length - 2).Trim();
                }
                #endregion

                #region CostsTitle
                if (_FinalResultDT.Columns.Contains("CostsTitle"))
                {
                    String TempData = String.Empty;
                    foreach (RefCostsAndDiscount Costs in RefCost)
                        TempData += " " + Costs.CostsAndDiscountsType.Name + " ,";
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["CostsTitle"] = TempData.Substring(1, TempData.Length - 2).Trim();
                }
                #endregion

                #region CostsDateTime
                if (_FinalResultDT.Columns.Contains("CostsDateTime"))
                {
                    String TempData = String.Empty;
                    foreach (RefCostsAndDiscount Cos in RefCost)
                    {
                        NewRow["CostsDateTime"] += " " + StringDateTime.DateTimeToDateString(Cos.Date) + " - " +
                            StringDateTime.DateTimeToTimeString(Cos.Date) + " ,";
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["CostsDateTime"] = TempData.Substring(1, TempData.Length - 2).Trim();
                }
                #endregion

                #region CostsUserFullName
                if (_FinalResultDT.Columns.Contains("CostsUserFullName"))
                {
                    String TempData = String.Empty;
                    foreach (RefCostsAndDiscount Cos in RefCost)
                    {
                        List<SP_SelectUsersResult> Temp =
                            Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID == Cos.CashierIX).ToList();
                        if (Temp.Count != 0) TempData += " " + Temp.First().FullName + " ,";
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["CostsUserFullName"] = TempData.Substring(1, TempData.Length - 2).Trim();
                }
                #endregion

                #region RefCosts Columns
                foreach (CostsAndDiscountsType MyData in DBLayerIMS.Account.CostAndDiscountFullList.Where(Data => Data.IsCost))
                    if (_FinalResultDT.Columns.Contains("RefCosts" + MyData.ID))
                    {
                        Int32 Sum = 0;
                        foreach (RefCostsAndDiscount RC in RefCost)
                            if (RC.CostIXOrDiscountIX == MyData.ID) Sum += RC.Value;
                        NewRow["RefCosts" + MyData.ID] = Sum;
                    }
                #endregion

                #region RefDiscounts Columns
                foreach (CostsAndDiscountsType MyData in DBLayerIMS.Account.CostAndDiscountFullList.Where(Data => !Data.IsCost))
                    if (_FinalResultDT.Columns.Contains("RefDiscounts" + MyData.ID))
                    {
                        Int32 Sum = 0;
                        foreach (RefCostsAndDiscount RC in RefDiscount)
                            if (RC.CostIXOrDiscountIX == MyData.ID) Sum += RC.Value;
                        NewRow["RefDiscounts" + MyData.ID] = Sum.ToString();
                    }
                #endregion

                #region SumDiscount
                if (_FinalResultDT.Columns.Contains("SumDiscount"))
                    NewRow["SumDiscount"] = RefDiscount.Sum(Data => Data.Value);
                #endregion

                #region SumCost
                if (_FinalResultDT.Columns.Contains("SumCost"))
                    NewRow["SumCost"] = RefCost.Sum(Data => Data.Value);
                #endregion
            }
            #endregion

            #region Ref Transactions
            if (_FinalResultDT.Columns.Contains("TransType") || _FinalResultDT.Columns.Contains("TransDate") ||
                _FinalResultDT.Columns.Contains("TransTime") || _FinalResultDT.Columns.Contains("TransDescription") ||
                _FinalResultDT.Columns.Contains("TransCheckNumber") || _FinalResultDT.Columns.Contains("TransCheckDate") ||
                _FinalResultDT.Columns.Contains("TransAccountNumber") || _FinalResultDT.Columns.Contains("TransAccountType") ||
                _FinalResultDT.Columns.Contains("TransBankName") || _FinalResultDT.Columns.Contains("TransBranchCode") ||
                _FinalResultDT.Columns.Contains("TransBranchName") || _FinalResultDT.Columns.Contains("TransCashierName") ||
                _FinalResultDT.Columns.Contains("TransCashName") || _FinalResultDT.Columns.Contains("TransValue") ||
                _FinalResultDT.Columns.Contains("SumTransBalance"))
            {
                List<RefTransaction> CurrentRefTrans;
                try
                {
                    IQueryable<RefTransaction> TempData =
                        DBLayerIMS.Manager.DBML.RefTransactions.Where(Data => Data.ReferralIX == RefID);
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                    CurrentRefTrans = TempData.ToList();
                }
                #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Sepehr", "Reports - Designables",
                        Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return false;
                }
                #endregion

                #region TransType
                if (_FinalResultDT.Columns.Contains("TransType"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                    {
                        if (Trans.RefTransactionAdditionalData != null && Trans.RefTransactionAdditionalData.PayType != null)
                        {
                            if (Trans.RefTransactionAdditionalData.PayType == 0) TempData += " نقدی ,";
                            else if (Trans.RefTransactionAdditionalData.PayType == 1) TempData += " چك ,";
                            else if (Trans.RefTransactionAdditionalData.PayType == 2) TempData += " فیش,";
                        }
                        else TempData += " نقدی ,";
                    }
                    if (!String.IsNullOrEmpty(TempData)) NewRow["TransType"] = TempData.Substring(1, TempData.Length - 2).Trim();
                }
                #endregion

                #region TransDate
                if (_FinalResultDT.Columns.Contains("TransDate"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                        TempData += " " + StringDateTime.DateTimeToDateString(Trans.OccuredDate) + " ,";
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["TransDate"] = TempData.Substring(1, TempData.Length - 2);
                }
                #endregion

                #region TransTime
                if (_FinalResultDT.Columns.Contains("TransTime"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                        TempData += " " + StringDateTime.DateTimeToTimeString(Trans.OccuredDate) + " ,";
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["TransTime"] = TempData.Substring(1, TempData.Length - 2);
                }
                #endregion

                #region TransDescription
                if (_FinalResultDT.Columns.Contains("TransDescription"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                        if (!String.IsNullOrEmpty(Trans.Description)) TempData += " " + Trans.Description + " ,";
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["TransDescription"] = TempData.Substring(1, TempData.Length - 2).Trim();
                }
                #endregion

                #region TransCheckNumber
                if (_FinalResultDT.Columns.Contains("TransCheckNumber"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                    {
                        if (Trans.RefTransactionAdditionalData != null &&
                            !String.IsNullOrEmpty(Trans.RefTransactionAdditionalData.CheckNumber))
                            TempData += " " + Trans.RefTransactionAdditionalData.CheckNumber + " ,";
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["TransCheckNumber"] = TempData.Substring(1, TempData.Length - 2);
                }
                #endregion

                #region TransCheckDate
                if (_FinalResultDT.Columns.Contains("TransCheckDate"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                    {
                        if (Trans.RefTransactionAdditionalData != null &&
                            Trans.RefTransactionAdditionalData.CheckDate != null)
                            TempData += " " + StringDateTime.DateTimeToDateString(
                                Trans.RefTransactionAdditionalData.CheckDate) + " ,";
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["TransCheckDate"] = TempData.Substring(1, TempData.Length - 2);
                }
                #endregion

                #region TransAccountNumber
                if (_FinalResultDT.Columns.Contains("TransAccountNumber"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                    {
                        if (Trans.RefTransactionAdditionalData != null &&
                            !String.IsNullOrEmpty(Trans.RefTransactionAdditionalData.AccountNumber))
                            TempData += " " + Trans.RefTransactionAdditionalData.AccountNumber + " ,";
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["TransAccountNumber"] = TempData.Substring(1, TempData.Length - 2);
                }
                #endregion

                #region TransAccountType
                if (_FinalResultDT.Columns.Contains("TransAccountType"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                    {
                        if (Trans.RefTransactionAdditionalData != null &&
                            Trans.RefTransactionAdditionalData.AccountType != null)
                            if (Trans.RefTransactionAdditionalData.AccountType == 1)
                                TempData += " " + "جاری" + " ,";
                            else if (Trans.RefTransactionAdditionalData.AccountType == 2)
                                TempData += " " + "پس انداز" + " ,";
                            else if (Trans.RefTransactionAdditionalData.AccountType == 3)
                                TempData += " " + "قرض الحسنه" + " ,";
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["TransAccountType"] = TempData.Substring(1, TempData.Length - 2);
                }
                #endregion

                #region TransBankName
                if (_FinalResultDT.Columns.Contains("TransBankName"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                        if (Trans.RefTransactionAdditionalData != null)
                        {
                            List<SP_SelectBanksResult> Temp = DBLayerIMS.Account.BanksFullList.
                                Where(Data => Data.ID == Trans.RefTransactionAdditionalData.BankIX).ToList();
                            if (Temp.Count != 0)
                                TempData += " " + Temp.First().Name + " ,";
                        }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["TransBankName"] = TempData.Substring(1, TempData.Length - 2);
                }
                #endregion

                #region TransBranchCode
                if (_FinalResultDT.Columns.Contains("TransBranchCode"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                        if (Trans.RefTransactionAdditionalData != null &&
                            !String.IsNullOrEmpty(Trans.RefTransactionAdditionalData.BranchCode))
                            TempData += " " + Trans.RefTransactionAdditionalData.BranchCode + " ,";
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["TransBranchCode"] = TempData.Substring(1, TempData.Length - 2);
                }
                #endregion

                #region TransBranchName
                if (_FinalResultDT.Columns.Contains("TransBranchName"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                        if (Trans.RefTransactionAdditionalData != null &&
                            !String.IsNullOrEmpty(Trans.RefTransactionAdditionalData.BranchName))
                            TempData += " " + Trans.RefTransactionAdditionalData.BranchName + " ,";
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["TransBranchName"] = TempData.Substring(1, TempData.Length - 2);
                }
                #endregion

                #region TransCashierName
                if (_FinalResultDT.Columns.Contains("TransCashierName"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                    {
                        List<SP_SelectUsersResult> Temp =
                            Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID == Trans.CashierIX).ToList();
                        if (Temp.Count != 0)
                            TempData += " " + Temp.First().FullName + " ,";
                    }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["TransCashierName"] = TempData.Substring(1, TempData.Length - 2);
                }
                #endregion

                #region TransCashName
                if (_FinalResultDT.Columns.Contains("TransCashName"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans)
                        if (Trans.CashIX != null)
                        {
                            List<Cash> Temp =
                                DBLayerIMS.Manager.DBML.Cashes.Where(Data => Data.ID == Trans.CashIX).ToList();
                            TempData += " " + Temp.First().Name + " ,";
                        }
                    if (!String.IsNullOrEmpty(TempData))
                        NewRow["TransCashName"] = TempData.Substring(1, TempData.Length - 2);
                }
                #endregion

                #region TransValue
                if (_FinalResultDT.Columns.Contains("TransValue"))
                {
                    String TempData = String.Empty;
                    foreach (RefTransaction Trans in CurrentRefTrans) TempData += " " + Trans.Value + " - ";
                    NewRow["TransValue"] = TempData.Substring(1, TempData.Length - 2).Trim();
                }
                #endregion

                #region SumTransBalance
                if (_FinalResultDT.Columns.Contains("SumTransBalance"))
                    NewRow["SumTransBalance"] = CurrentRefTrans.Sum(Data => Data.Value);
                #endregion
            }
            #endregion

            #region Ref Account Summary

            #region RefPayable
            if (_FinalResultDT.Columns.Contains("RefPayable"))
                NewRow["RefPayable"] = DBLayerIMS.Manager.DBML.FK_CalcRefPayable(RefID).ToString();
            #endregion

            #region RefRemainValue
            if (_FinalResultDT.Columns.Contains("RefRemainValue"))
                NewRow["RefRemainValue"] = DBLayerIMS.Manager.DBML.FK_CalcTotalRefRemain(RefID).ToString();
            #endregion

            #endregion

            #region DesignableReport Additional Columns
            foreach (DesignableReportsAddinCol Col in ReportHelper.DesignableReportsAddinCols)
            {
                if (_FinalResultDT.Columns.Contains("ReportAddinCol" + Col.FieldName))
                    NewRow["ReportAddinCol" + Col.FieldName] = ExecuteCommand(Col.FieldFormula);
            }
            #endregion

            #endregion

            _FinalResultDT.Rows.Add(NewRow);
            return true;
        }
        #endregion

        #region Boolean GenerateFinalResultDataTable(Int16 ReportID)
        /// <summary>
        /// تابع ساختن دیتا تیبل كه با نتیجه پر خواهد شد
        /// </summary>
        internal static Boolean GenerateFinalResultDataTable(Int16 ReportID)
        {
            String ReportColumnsXML;
            try
            {
                DesignableReport CurrentReportStruct = DBLayerIMS.Manager.DBML.DesignableReports.
                    Where(Data => Data.ID == ReportID).First();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, CurrentReportStruct);
                ReportColumnsXML = CurrentReportStruct.ColumnsData;
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("امكان خواندن اطلاعات گزارش قابل طراحی جاری وجود ندارد!\n" + "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Reports Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion

            #region Generate Current Report Columns DataTable
            DataTable TempDataTable = new DataTable("DesignableReport");
            TempDataTable.Columns.Add("ColColumnsName", typeof(String));
            TempDataTable.Columns.Add("ColColumnsHeaders", typeof(String));
            TempDataTable.Columns.Add("ColIsNumeric", typeof(Boolean));
            try
            {
                if (File.Exists("DesignableReport.DAT")) File.Delete("DesignableReport.DAT");
                File.WriteAllText("DesignableReport.DAT", ReportColumnsXML);
                TempDataTable.ReadXml("DesignableReport.DAT");
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("امكان خواندن ستون های انتخاب شده برای گزارش جاری وجود ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Reports Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            #region Finally
            finally
            {
                try { if (File.Exists("DesignableReport.DAT")) File.Delete("DesignableReport.DAT"); }
                catch { }
            }
            #endregion
            #endregion

            #region Prepare FinalResult DataTable
            _FinalResultDT = new DataTable();
            foreach (DataRow row in TempDataTable.Rows)
            {
                DataColumn col = new DataColumn(row["ColColumnsName"].ToString());
                if (row["ColIsNumeric"] == null || row["ColIsNumeric"] == DBNull.Value || !Convert.ToBoolean(row["ColIsNumeric"]))
                    col.DataType = typeof(String);
                else col.DataType = typeof(Int32);
                col.Caption = row["ColColumnsHeaders"].ToString();
                _FinalResultDT.Columns.Add(col);
            }
            #endregion

            return true;
        }
        #endregion

        #region String ExecuteCommand(String Parameter)
        /// <summary>
        ///  محاسبه مقدار فیلد های اطلاعاتی اضافه
        /// </summary>
        /// <param name="Parameter">نتیجه محاسبه به صورت متن</param>
        private static String ExecuteCommand(String Parameter)
        {
            String Command = "DECLARE @Result BIGINT; " + "DECLARE @ParamDefinition NVARCHAR(50); "
                + "DECLARE @Formula NVARCHAR(MAX); " + "SET @Formula = 'SET @Result = "
                + Parameter + ";' " + "SET @ParamDefinition = N'@Result BIGINT OUTPUT'; "
                + "EXECUTE SP_EXECUTESQL @Formula, @ParamDefinition, @Result = @Result OUTPUT; SELECT @Result;";
            DataTable ResultDataSet = Negar.DBLayerPMS.Manager.ExecuteQuery(Command, 5);
            if (ResultDataSet == null) return String.Empty;
            return Convert.ToString(ResultDataSet.Rows[0][0]);
        }
        #endregion

        #region Static Class StringDateTime
        /// <summary>
        /// كلاس تبدیل شی زمان به شی متنی
        /// </summary>
        private static class StringDateTime
        {
            #region String DateTimeToDateString(DateTime? SentDateTime)
            /// <summary>
            /// تبدیل تاریخ شی زمانی به متن 
            /// </summary>
            /// <param name="SentDateTime">شی زمان</param>
            /// <returns>تاریخ به صورت متن</returns>
            public static String DateTimeToDateString(DateTime? SentDateTime)
            {
                if (SentDateTime == null) return String.Empty;
                PersianDate ResulrDateTime = SentDateTime.Value.ToPersianDate();
                String Month;
                String Day;

                if (ResulrDateTime.Month < 10)
                    Month = "0" + ResulrDateTime.Month;
                else Month = ResulrDateTime.Month.ToString();

                if (ResulrDateTime.Day < 10)
                    Day = "0" + ResulrDateTime.Day;
                else Day = ResulrDateTime.Day.ToString();

                return ResulrDateTime.Year + "/" + Month + "/" + Day;
            }
            #endregion

            #region String DateTimeToTimeString(DateTime? SentDateTime)
            /// <summary>
            /// تبدیل ساعت شی زمانی به متن 
            /// </summary>
            /// <param name="SentDateTime">شی زمان</param>
            /// <returns>ساعت به صورت متن</returns>
            public static String DateTimeToTimeString(DateTime? SentDateTime)
            {
                if (SentDateTime == null) return String.Empty;
                PersianDate ResulrDateTime = SentDateTime.Value.ToPersianDate();
                String Hour;
                String Min;
                if (ResulrDateTime.Hour < 10)
                    Hour = "0" + ResulrDateTime.Hour;
                else Hour = ResulrDateTime.Hour.ToString();

                if (ResulrDateTime.Minute < 10)
                    Min = "0" + ResulrDateTime.Minute;
                else Min = ResulrDateTime.Minute.ToString();
                return Hour + ":" + Min;
            }
            #endregion
        }
        #endregion

        #endregion

    }
}