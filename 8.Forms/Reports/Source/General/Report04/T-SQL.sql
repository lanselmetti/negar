SELECT ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] AS [FullName], 
[TblRefList].[RegisterDate] ,
'1380/01/01 - 10:00:00' AS [RegisterDateFa] ,
[TblRefList].[Ins1Num1] ,
--[TblRefList].[PrescriptionDate] ,
--'1380/01/01 - 10:00:00' AS [PrescriptionDateFa] ,
SUM([TblRefService].[Ins1Price] * [TblRefService].[Quantity]) AS [InsPrice],
SUM([TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity]) AS [InsPart],
SUM(([TblRefService].[Ins1Price] - [TblRefService].[Ins1PartPrice]) * [TblRefService].[Quantity]) AS [InsPatPart]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
FROM [PatientsSystem].[Patients].[List] AS [TblPatList]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] 
	ON [TblPatList].[ID] = [TblRefList].[PatientIX]
INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService]
	ON [TblRefService].[ReferralIX] = [TblRefList].[ID]
WHERE [TblRefList].[Ins1IX] IS NOT NULL 
	AND [TblRefService].[IsActive] = 1 AND [TblRefService].[IsIns1Cover] = 1
 --	AND (SELECT TOP 1 [TblServiceList].[CategoryIX] FROM [ImagingSystem].[Services].[List] AS [TblServiceList] 
--WHERE [TblServiceList].[ID] = [TblRefService].[ServiceIX]) IN (7) 
GROUP BY [TblPatList].[PatientID] , [TblRefList].[RegisterDate] ,
	ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] ,
	[TblRefList].[Ins1Num1] , [TblRefList].[PrescriptionDate]
ORDER BY [TblRefList].[RegisterDate] , [TblPatList].[PatientID] ASC;
-------------------------------------------------------------------------------------------------
	AND [TblRefService].[IsActive] = 1 AND [TblRefService].[IsIns1Cover] = 1
GROUP BY [TblPatList].[PatientID] , [TblRefList].[RegisterDate] ,
	ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] ,
	[TblRefList].[Ins1Num1] , [TblRefList].[PrescriptionDate]
ORDER BY [TblRefList].[RegisterDate] ASC;
-- ############################################################
-- ############################################################
-- ############################################################
SELECT ROW_NUMBER() OVER(ORDER BY [TblRefList].[RegisterDate] ASC) AS [RowNum] ,
[TblPatList].[PatientID],
ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] AS [FullName], 
[TblRefList].[RegisterDate] ,
'1380/01/01 - 10:00:00' AS [RegisterDateFa] ,
[TblRefList].[Ins2Num] ,
[TblRefList].[PrescriptionDate] ,
'1380/01/01 - 10:00:00' AS [PrescriptionDateFa] ,
SUM([TblRefService].[Ins2Price] * [TblRefService].[Quantity]) AS [InsPrice],
SUM([TblRefService].[Ins2PartPrice] * [TblRefService].[Quantity]) AS [InsPart],
SUM(([TblRefService].[Ins2Price] - [TblRefService].[Ins2PartPrice]) * [TblRefService].[Quantity]) AS [InsPatPart]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
FROM [PatientsSystem].[Patients].[List] AS [TblPatList]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList]
	ON [TblPatList].[ID] = [TblRefList].[PatientIX]
INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService]
	ON [TblRefService].[ReferralIX] = [TblRefList].[ID]
WHERE [TblRefList].[Ins1IX] IS NOT NULL 
-------------------------------------------------------------------------------------------------
	AND [TblRefService].[IsActive] = 1 AND [TblRefService].[IsIns2Cover] = 1
GROUP BY [TblPatList].[PatientID] , [TblRefList].[RegisterDate] ,
	ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] ,
	[TblRefList].[Ins2Num] , [TblRefList].[PrescriptionDate]
ORDER BY [TblRefList].[RegisterDate] ASC;