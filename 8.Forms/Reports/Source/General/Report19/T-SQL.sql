SELECT 
ISNULL((SELECT TOP 1 ISNULL([TblRefPhys].[FirstName] + ' ' , '') + [TblRefPhys].[LastName] + 
	ISNULL(' - ' + [TblRefPhys].[MedicalID] , '') FROM [PatientsSystem].[Clinic].[RefPhysicians] AS [TblRefPhys] 
	WHERE [TblRefPhys].[ID] = [TblRefList].[ReferPhysicianIX]) , '(فاقد پزشك)') AS [RefPhysName] , 
ISNULL((SELECT TOP 1 [TblServiceCat].[Name] FROM [ImagingSystem].[Services].[Categories] AS [TblServiceCat] 
	WHERE [TblServiceCat].[ID] = [TblServList].[CategoryIX]) , '(فاقد طبقه بندی)') AS [ServCatName] , 
(SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[List] AS [TblRef]
	WHERE [TblRef].[ReferPhysicianIX] = [TblRefList].[ReferPhysicianIX]
	AND (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [TblServ]
		INNER JOIN [ImagingSystem].[Services].[List] AS [ServList]
		ON [TblServ].[ServiceIX] = [ServList].[ID]
		WHERE [TblServ].[ReferralIX] = [TblRef].[ID] AND [TblServ].[IsActive] = 1 AND
		[ServList].[CategoryIX] = [TblServList].[CategoryIX]) > 0) AS [RefCount],
SUM([TblRefService].[Quantity]) AS [ServQty] ,
SUM(ISNULL([TblRefService].[PatientPayablePrice] , 0) * [TblRefService].[Quantity]) AS [PatPayablePrice],
SUM(ISNULL([TblRefService].[Ins1PartPrice] , 0) * [TblRefService].[Quantity]) AS [Ins1Part],
SUM(ISNULL([TblRefService].[Ins2PartPrice] , 0) * [TblRefService].[Quantity]) AS [Ins2Part]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefService]
INNER JOIN [ImagingSystem].[Services].[List] AS [TblServList]
ON [TblRefService].[ServiceIX] = [TblServList].[ID]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList]
ON [TblRefList].[ID] = [TblRefService].[ReferralIX]
WHERE [TblRefService].[IsActive] = 1
AND [TblRefList].[ReferPhysicianIX] IS NOT NULL
--AND [TblServList].[CategoryIX] IN (2) 
GROUP BY [TblServList].[CategoryIX] , [TblRefList].[ReferPhysicianIX]
ORDER BY COUNT([TblRefList].[ID]) DESC;
