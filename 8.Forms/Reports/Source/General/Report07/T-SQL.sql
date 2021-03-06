SELECT ROW_NUMBER() OVER(ORDER BY [TblRefList].[RegisterDate] , [TblPatList].[PatientID] ASC) AS [RowNum] ,
-- اطلاعات بیمار
[TblPatList].[PatientID],
ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] AS [FullName], 
-- اطلاعات مراجعه
[TblRefList].[RegisterDate] ,
'1380/01/01 - 10:00:00' AS [RegisterDateFa] ,
[TblRefList].[PrescriptionDate] ,
'1380/01/01' AS [PrescriptionDateFa] ,
-- اطلاعات بیمه مراجعه
(SELECT TOP 1 [TblIns].[Name] FROM [PatientsSystem].[Clinic].[Insurances] AS [TblIns]
	WHERE [TblIns].[ID] = [TblRefList].[Ins1IX]) AS [InsName] ,
[TblRefList].[Ins1Validation] ,
'1380/01/01' AS [Ins1ValidationDateFa] ,
[TblRefList].[Ins1Num1] ,
[TblRefList].[Ins1PageNum] ,
-- اطلاعات خدمات
(SELECT TOP 1 [TblServices].[Code] FROM [ImagingSystem].[Services].[List] AS [TblServices]
WHERE [TblServices].[ID] = [TblRefService].[ServiceIX]) AS [ServiceCode],
(SELECT TOP 1 [TblServices].[Name] FROM [ImagingSystem].[Services].[List] AS [TblServices]
WHERE [TblServices].[ID] = [TblRefService].[ServiceIX]) AS [ServiceName],
[TblRefService].[Quantity] AS [ServiceQty],
[TblRefService].[Ins1Price] * [TblRefService].[Quantity] AS [InsPrice],
[TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity] AS [InsPart],
([TblRefService].[Ins1Price] - [TblRefService].[Ins1PartPrice]) * [TblRefService].[Quantity] AS [InsPatPart]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
FROM [PatientsSystem].[Patients].[List] AS [TblPatList]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] 
	ON [TblPatList].[ID] = [TblRefList].[PatientIX]
INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService]
	ON [TblRefService].[ReferralIX] = [TblRefList].[ID]
WHERE [TblRefList].[Ins1IX] IS NOT NULL 
	AND [TblRefService].[IsActive] = 1 AND [TblRefService].[IsIns1Cover] = 1
 --	AND (SELECT TOP 1 [TblServiceList].[CategoryIX] FROM [ImagingSystem].[Services].[List] AS [TblServiceList] 
-- [TblServiceList].[ID] = [TblRefService].[ServiceIX]) IN (7)ORDER BY [TblRefList].[RegisterDate] ASC;