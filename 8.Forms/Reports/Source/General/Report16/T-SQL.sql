SELECT 
-- اطلاعات بیمار
ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] AS [FullName], 
-- اطلاعات مراجعه
[TblRefList].[ID] AS [RefID] ,
[TblRefList].[Ins1Num1] ,
[TblRefList].[PrescriptionDate] ,
'1380/01/01 - 10:00:00' AS [PrescriptionDateFa] ,
[TblRefList].[Ins1Validation] ,
'1380/01/01 - 10:00:00' AS [Ins1ValidationFa] ,
[TblRefList].[Ins1PageNum] ,
(SELECT TOP 1 ISNULL([RefPhys].[FirstName] + ' ' , '') + [RefPhys].[LastName] + 
	ISNULL(' - ' + [RefPhys].[MedicalID] , '') 
	FROM [PatientsSystem].[Clinic].[RefPhysicians] AS [RefPhys] 
	WHERE [RefPhys].[ID] = [TblRefList].[ReferPhysicianIX]) AS [RefPhysName],
[ImagingSystem].[Accounting].[FK_CalcSumIns1Price] ([TblRefList].[ID]) AS [TotInsPrice],
[ImagingSystem].[Accounting].[FK_CalcSumIns1PartPrice] ([TblRefList].[ID]) AS [TotInsPart],
[ImagingSystem].[Accounting].[FK_CalcSumIns1PatientPart] ([TblRefList].[ID]) AS [TotInsPatPart],
-- اطلاعات خدمات
[TblRefService].[ID] AS [RefServID] ,
(SELECT TOP 1 [TblServices].[Name] FROM [ImagingSystem].[Services].[List] AS [TblServices]
	WHERE [TblServices].[ID] = [TblRefService].[ServiceIX]) AS [ServiceName],
[TblRefService].[Quantity] AS [ServiceQty],
[TblRefService].[Ins1Price] * [TblRefService].[Quantity] AS [Ins1Price],
[TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity] AS [Ins1PartPrice],
([TblRefService].[Ins1Price] - [TblRefService].[Ins1PartPrice]) * [TblRefService].[Quantity] AS [Ins1PatientPart]
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