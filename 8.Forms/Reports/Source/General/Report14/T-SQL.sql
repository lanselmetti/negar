SELECT [TblPatients].[PatientID],
(ISNULL([TblPatients].[FirstName] + ' ' , '') + [TblPatients].[LastName]) AS [FullName] ,
[TblRefList].[RegisterDate] AS [RefDate] ,
'1380/01/01 - 10:00:00' AS [RefDateFa] ,
-- مجموع دریافت های مراجعه
[ImagingSystem].[Accounting].[FK_CalcSumRecieve]([TblRefList].[ID]) AS [SumRecieve] ,
-- مجموع پرداخت های مراجعه
[ImagingSystem].[Accounting].[FK_CalcSumPay]([TblRefList].[ID]) AS [SumPay] ,
-- نوع: بدهكاری یا طلبكاری
(CASE WHEN [ImagingSystem].[Accounting].[FK_CalcTotalRefRemain]([TblRefList].[ID]) > 0 THEN 'بدهكار' 
ELSE 'طلبكار' END) AS [RemainType] ,
-- مبلغ بدهكاری یا طلبكاری
[ImagingSystem].[Accounting].[FK_CalcTotalRefRemain]([TblRefList].[ID]) AS [RemainValue]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
FROM [ImagingSystem].[Referrals].[List] AS [TblRefList]
INNER JOIN [PatientsSystem].[Patients].[List] AS [TblPatients]
ON [TblPatients].ID = [TblRefList].PatientIX
WHERE [ImagingSystem].[Accounting].[FK_CalcTotalRefRemain]([TblRefList].[ID]) <> 0