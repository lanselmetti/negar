SELECT ROW_NUMBER() OVER(ORDER BY [Tbl3].[ID] , [Tbl1].[RegisterDate] , [Tbl2].[OccuredDate] ASC) AS [Row],
[Tbl3].[PatientID] ,
[FullName] = (ISNULL([Tbl3].[FirstName] + ' ' , '') + [Tbl3].[LastName] ), 
[Tbl1].[RegisterDate] AS [RegisterDateEn], 
'1380/01/01 - 10:00:00' AS [RegisterDate] ,
[Tbl2].[OccuredDate] AS [TransDateTimeEn],
'1380/01/01 - 10:00:00' AS [TransDateTime],
ABS([Tbl2].[Value]) AS [Value] , 
[Tbl2].[Value] AS [RealValue] , 
(CASE WHEN [Tbl2].[Value] >= 0 THEN 'دریافت' ELSE 'بازپرداخت' END) AS [Type] ,
[Tbl5].[Name] AS [CashName] ,
(ISNULL([Tbl4].[FirstName] + ' ' , '') + [Tbl4].[LastName]) AS [CashierName] ,
[Tbl2].[Description]
-- +++++++++++++++++++++++++++++++++++
FROM [ImagingSystem].[Accounting].[RefTransaction] AS [Tbl2] 
INNER JOIN [ImagingSystem].[Referrals].[List] AS [Tbl1] 
ON [Tbl2].ReferralIX = [Tbl1].ID
INNER JOIN [PatientsSystem].[Patients].[List] AS [Tbl3]
ON [Tbl3].ID = [Tbl1].PatientIX 
INNER JOIN [PatientsSystem].[Security].[Users] AS [Tbl4]
ON [Tbl4].[ID] = [Tbl2].[CashierIX] 
LEFT OUTER JOIN [ImagingSystem].[Accounting].[Cashes] AS [Tbl5]
ON [Tbl5].[ID] = [Tbl2].[CashIX]