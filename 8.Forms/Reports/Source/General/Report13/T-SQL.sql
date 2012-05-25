SELECT [TblPatients].[PatientID] ,
ISNULL([TblPatients].[FirstName] + ' ' , '') + [TblPatients].[LastName] AS [FullName] , 
[TblReferrals].[RegisterDate] AS [RefDate] ,
'1380/01/01' AS [RefDateFa] ,
[TblRefCAndD].[CostIXOrDiscountIX] AS [CostOrDiscountID],
[TblCAndD].[Name] AS [TypeName] ,
[TblRefCAndD].[Date] AS [OccuredDate] ,
'1380/01/01 - 10:00:00' AS [OccuredDateFa] ,
ISNULL([TblUsers].[FirstName] + ' ' , '') + [TblUsers].[LastName] AS [CashierName] ,
[TblRefCAndD].[Value]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
FROM [ImagingSystem].[Accounting].[RefCostsAndDiscounts] AS [TblRefCAndD] 
INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblReferrals]
ON [TblRefCAndD].[ReferralIX] = [TblReferrals].[ID]
INNER JOIN [PatientsSystem].[Patients].[List] AS [TblPatients]
ON [TblPatients].[ID] = [TblReferrals].[PatientIX]
INNER JOIN [PatientsSystem].[Security].[Users] AS [TblUsers]
ON [TblUsers].[ID] = [TblRefCAndD].[CashierIX] 
INNER JOIN [ImagingSystem].[Accounting].[CostsAndDiscountsTypes] AS [TblCAndD]
ON [TblCAndD].[ID] = [TblRefCAndD].[CostIXOrDiscountIX]
ORDER BY [TblRefCAndD].[CostIXOrDiscountIX] , [TblRefCAndD].[Date];