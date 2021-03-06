SELECT [Tbl3].[ID] , [Tbl3].[PatientID] ,
[FullName] = (ISNULL([Tbl3].[FirstName] + ' ' , '') + [Tbl3].[LastName] ), 
[ImagingSystem].[Accounting].[FK_CalcRefServicesPayable] ([Tbl1].[ID]) AS [ServicePayable],
[ImagingSystem].[Accounting].[FK_CalcSumCost] ([Tbl1].[ID]) AS [TotalCosts],
[ImagingSystem].[Accounting].[FK_CalcSumDiscount] ([Tbl1].[ID]) AS [TotalDiscounts],
[ImagingSystem].[Accounting].[FK_CalcSumRecieve] ([Tbl1].[ID]) AS [TotalRecieves],
[ImagingSystem].[Accounting].[FK_CalcSumPay] ([Tbl1].[ID]) AS [TotalPays],
[ImagingSystem].[Accounting].[FK_CalcTotalRefRemain] ([Tbl1].[ID]) AS [RemainValue],
[Tbl2].[OccuredDate] AS [TransDateTimeEn],
'1380/01/01 - 10:00:00' AS [TransDateTime],
ABS([Tbl2].[Value]) AS [Value] , 
[Tbl2].[Value] AS [RealValue] , 
(CASE WHEN [Tbl2].[Value] >= 0 THEN 'دریافت' ELSE 'بازپرداخت' END) AS [Type] ,
(ISNULL([Tbl4].[FirstName] + ' ' , '') + [Tbl4].[LastName]) AS [CashierName] ,
[Tbl2].[Description]
-- +++++++++++++++++++++++++++++++++++
FROM [ImagingSystem].[Accounting].[RefTransaction] AS [Tbl2] 
INNER JOIN [ImagingSystem].[Referrals].[List] AS [Tbl1] 
ON [Tbl2].[ReferralIX] = [Tbl1].[ID]
INNER JOIN [PatientsSystem].[Patients].[List] AS [Tbl3]
ON [Tbl3].[ID] = [Tbl1].[PatientIX]
INNER JOIN [PatientsSystem].[Security].[Users] AS [Tbl4]
ON [Tbl4].[ID] = [Tbl2].[CashierIX]