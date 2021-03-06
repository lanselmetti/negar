SELECT 
-- اطلاعات بیمار
[TblPatList].[PatientID],
ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] AS [FullName], 
-- اطلاعات مراجعه
[TblRefList].[ID] AS [RefID] ,
[TblRefList].[RegisterDate] ,
'1380/01/01 - 10:00:00' AS [RegisterDateFa],
[TblRefList].[Ins1Num1] AS [InsNum],
--ISNULL([TblUsers].[FirstName] + ' ' , '') + [TblUsers].[LastName] AS [AdmitterName] ,
-- اطلاعات خدمات
[TblRefService].[ID] AS [RefServID] ,
(SELECT TOP 1 [TblServices].[Code] FROM [ImagingSystem].[Services].[List] AS [TblServices]
	WHERE [TblServices].[ID] = [TblRefService].[ServiceIX]) AS [ServiceCode],
(SELECT TOP 1 [TblServices].[Name] FROM [ImagingSystem].[Services].[List] AS [TblServices]
	WHERE [TblServices].[ID] = [TblRefService].[ServiceIX]) AS [ServiceName],
[TblRefService].[Quantity] AS [ServiceQty],
[TblRefService].[Ins1Price],
[ImagingSystem].[Accounting].[FK_CalcSumIns1Price]([TblRefList].[ID]) AS [InsPrice],
[ImagingSystem].[Accounting].[FK_CalcSumIns1PartPrice]([TblRefList].[ID]) AS [InsPart],
[ImagingSystem].[Accounting].[FK_CalcSumIns1PatientPart]([TblRefList].[ID]) AS [InsPatPart]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
FROM [PatientsSystem].[Patients].[List] AS [TblPatList]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] 
	ON [TblPatList].[ID] = [TblRefList].[PatientIX]
INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService]
	ON [TblRefService].[ReferralIX] = [TblRefList].[ID]
INNER JOIN [PatientsSystem].[Security].[Users] AS [TblUsers]
ON [TblUsers].[ID] = [TblRefList].[AdmitterIX]
WHERE [TblRefList].[Ins1IX] IS NOT NULL 
	AND [TblRefService].[IsActive] = 1 AND [TblRefService].[IsIns1Cover] = 1
 --	AND (SELECT TOP 1 [TblServiceList].[CategoryIX] FROM [ImagingSystem].[Services].[List] AS [TblServiceList] 
-- [TblServiceList].[ID] = [TblRefService].[ServiceIX]) IN (7)ORDER BY [TblRefList].[RegisterDate] ASC;