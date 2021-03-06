SELECT SUM([TblRefService].[Quantity] * [TblRefService].[PatientPayablePrice]) AS [ServicePayable]
-- ISNULL([TblRefService].[Ins1PartPrice] , 0) AS [Ins1PartPrice],
-- ISNULL([TblRefService].[Ins2PartPrice] , 0) AS [Ins2PartPrice],
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
FROM [ImagingSystem].[Referrals].[List] AS [TblRefs]
INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService]
ON [TblRefService].[ReferralIX] = [TblRefs].[ID]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
--INNER JOIN [ImagingSystem].[Services].[List] AS [TblServices]
--ON [TblRefService].[ServiceIX] = [TblServices].[ID]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
--INNER JOIN [ImagingSystem].[Services].[ServiceInGroups] AS [TblGroups]
--ON [TblRefService].[ServiceIX] = [TblGroups].[ServiceIX]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
WHERE [TblRefService].[IsActive] = 1 -- [TblServices].[CategoryIX] IN (13) -- AND [TblGroups].[GroupIX] IN (10 , 20)