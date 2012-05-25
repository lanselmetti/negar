SELECT ROW_NUMBER() OVER(ORDER BY [TblRefList].[PrescriptionDate] , [TblRefList].[RegisterDate]  ASC) AS [RowN] , 
[TblRefList].[Ins1IX] AS [InsuranceID] , 
[TblInsList].[Name] AS [InsName],
[TblRefList].[PatientIX] , 
(ISNULL ([TblPatList].[FirstName] + ' ' , '') + [TblPatList].[LastName]) AS [FullName] , 
[TblRefList].[ID] AS [RefIX] , 
[TblRefList].[RegisterDate] ,
[TblRefList].[PrescriptionDate] , 
[TblRefList].[Ins1Validation] , 
[TblRefList].[Ins1Num1] , 
[TblPhysList].[MedicalID] , 
[TblPhysList].[SpecialtyIX] ,
[TblRefList].[Ins1PageNum] , 
[TblRefList].[ReferPhysicianIX] AS [PhysicianIX]
FROM [PatientsSystem].[Patients].[List] AS [TblPatList] 
INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] 
	ON [TblPatList].[ID] = [TblRefList].[PatientIX]
INNER JOIN [PatientsSystem].[Clinic].[Insurances] AS [TblInsList] 
	ON [TblInsList].[ID] = [TblRefList].[Ins1IX] 
INNER JOIN [PatientsSystem].[Clinic].[RefPhysicians] AS [TblPhysList] 
	ON [TblPhysList].[ID] = [TblRefList].[ReferPhysicianIX]
WHERE 
--[TblRefList].[PrescriptionDate] >= @Param1 AND [TblRefList].[PrescriptionDate] <= @Param2 
-- AND [TblRefList].[Ins1IX] IN (1) AND 
(SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefServices]
	LEFT OUTER JOIN [ImagingSystem].[Services].[List] AS [TblServList]
	ON [TblRefServices].[ServiceIX] = [TblServList].[ID]
	WHERE [TblRefServices].[ReferralIX] = [TblRefList].[ID] 
	AND [TblServList].[CategoryIX] IN (5)) > 0;
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
	SELECT ROW_NUMBER() OVER(ORDER BY [TblRefServs].[ID] ASC) AS [RowNumber] , 
[TblServList].[Code], 
[TblServList].[Name], 
ISNULL([TblRefServs].[Ins1Price] * [TblRefServs].[Quantity] , 0) AS [Ins1Price] , 
ISNULL([TblRefServs].[Ins1PartPrice] * [TblRefServs].[Quantity] , 0) AS [Ins1PartPrice] , 
ISNULL([TblRefServs].[Ins1Price] * [TblRefServs].[Quantity] - 
	[TblRefServs].[Ins1PartPrice] * [TblRefServs].[Quantity], 0) AS [Ins1PatientPrice] , 
[TblRefServs].[Quantity] AS [ServQty] , 
[TblCatList].[Name] AS [CatName] , 
(CASE [TblServList].[CategoryIX] WHEN 1 THEN 3 WHEN 5 THEN 5 END) AS [InsCategoryID] , 
[TblServList].[CategoryIX] , 
[TblRefServs].[ReferralIX] , 
[TblServList].[ID] 

FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefServs] 
INNER JOIN [ImagingSystem].[Services].[List] AS [TblServList] ON [TblRefServs].[ServiceIX] = [TblServList] .[ID] 
INNER JOIN  [ImagingSystem].[Services].[Categories] AS [TblCatList] ON [TblServList].[CategoryIX] = [TblCatList].[ID] 

WHERE -- [TblRefServs].[ReferralIX] = 2 AND 
--[TblServList].[CategoryIX] IN (1,5) AND 
[TblRefServs].[IsActive] = 1 AND [TblRefServs].[IsIns1Cover] = 1 
ORDER BY [TblRefServs].[ID] ASC;