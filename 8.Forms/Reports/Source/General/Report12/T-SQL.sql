SELECT [TblPatients].[PatientID],
[TblRefs].[RegisterDate],
'1380/10/01 - 12:20:50' AS [RegisterDateFa],
[TblServices].[Name] AS [ServiceName],
[TblRefService].[Quantity] AS [ServiceQty],
[TblRefService].[PatientPayablePrice],
ISNULL([TblRefService].[Ins1PartPrice] , 0) AS [Ins1PartPrice],
ISNULL([TblRefService].[Ins2PartPrice] , 0) AS [Ins2PartPrice],
ISNULL([TblRefService].[PatientPayablePrice] , 0) + ISNULL([TblRefService].[Ins1PartPrice] , 0) + 
	ISNULL([TblRefService].[Ins2PartPrice], 0) AS [TotalIncome] ,
10000000 AS [PerformerPart]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
FROM [PatientsSystem].[Patients].[List] AS [TblPatients]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefs] 
ON [TblPatients].[ID] = [TblRefs].[PatientIX]
INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService]
ON [TblRefService].[ReferralIX] = [TblRefs].[ID]
INNER JOIN [ImagingSystem].[Services].[List] AS [TblServices]
ON [TblRefService].[ServiceIX] = [TblServices].[ID]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
LEFT OUTER JOIN [ImagingSystem].[Services].[ServiceInGroups] AS [TblGroups]
ON [TblServices].[ID] = [TblGroups].[ServiceIX]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- WHERE [TblServices].[CategoryIX] IN (13) -- AND [TblGroups].[GroupIX] IN (10 , 20)
ORDER BY [TblPatients].[PatientID] , [TblRefs].[RegisterDate] , [TblRefService].[ID]