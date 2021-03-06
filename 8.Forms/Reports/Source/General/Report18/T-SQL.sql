SELECT 
ISNULL((SELECT TOP 1 [TblServiceCat].[Name] FROM [ImagingSystem].[Services].[Categories] AS [TblServiceCat] 
	WHERE [TblServiceCat].[ID] = [TblServList].[CategoryIX]) , '(بدون طبقه بندی)') AS [ServCatName] , 
ISNULL((SELECT TOP 1 [TblIns].[Name] FROM [PatientsSystem].[Clinic].[Insurances] AS [TblIns] 
	WHERE [TblIns].[ID] = [TblRefList].[Ins1IX]) , '(بدون بیمه اصلی)') AS [Ins1Name] , 
ISNULL((SELECT TOP 1 [TblIns].[Name] FROM [PatientsSystem].[Clinic].[Insurances] AS [TblIns] 
	WHERE [TblIns].[ID] = [TblRefList].[Ins2IX]) , '(بدون بیمه تكمیلی)') AS [Ins2Name] , 
SUM([TblRefService].[Quantity]) AS [ServQty] ,
SUM([TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity]) AS [PatPayablePrice],
SUM([TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity]) AS [Ins1Part],
SUM([TblRefService].[Ins2PartPrice] * [TblRefService].[Quantity]) AS [Ins2Part]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefService]
INNER JOIN [ImagingSystem].[Services].[List] AS [TblServList]
ON [TblRefService].[ServiceIX] = [TblServList].[ID]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList]
ON [TblRefList].[ID] = [TblRefService].[ReferralIX]
WHERE [TblRefService].[IsActive] = 1
--AND [TblServList].[CategoryIX] IN (2) 
GROUP BY [TblServList].[CategoryIX] , [TblRefList].[Ins1IX] , [TblRefList].[Ins2IX]
ORDER BY [TblServList].[CategoryIX] , [TblRefList].[Ins1IX] , [TblRefList].[Ins2IX] ASC;