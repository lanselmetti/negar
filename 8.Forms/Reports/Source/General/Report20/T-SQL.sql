SELECT [TblPat].[PatientID] ,
[FullName] = (ISNULL([TblPat].[FirstName] + ' ' , '') + [TblPat].[LastName] ), 
[TblRefTrans].[OccuredDate] AS [TransDateTimeEn],
'1380/01/01 - 10:00:00' AS [TransDateTime],
ABS([TblRefTrans].[Value]) AS [Value] , 
[TblRefTrans].[Value] AS [RealValue] , 
(CASE WHEN [TblRefTrans].[Value] >= 0 THEN 'دریافت' ELSE 'بازپرداخت' END) AS [Type] ,
(CASE [TblRefAddin].[PayType] 
WHEN 1 THEN 'چك' WHEN 2 THEN 'فیش' WHEN 3 THEN 'كارتخوان' ELSE 'نقد' END) AS [PayType] ,
(ISNULL([TblUsers].[FirstName] + ' ' , '') + [TblUsers].[LastName]) AS [CashierName] ,
[TblRefTrans].[Description]
-- +++++++++++++++++++++++++++++++++++
FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblRefTrans] 
LEFT OUTER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblRefAddin] 
ON [TblRefTrans].[ID] = [TblRefAddin].[RefTransactionIX]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRef] 
ON [TblRefTrans].[ReferralIX] = [TblRef].[ID]
INNER JOIN [PatientsSystem].[Patients].[List] AS [TblPat]
ON [TblPat].[ID] = [TblRef].[PatientIX]
INNER JOIN [PatientsSystem].[Security].[Users] AS [TblUsers]
ON [TblUsers].[ID] = [TblRefTrans].[CashierIX]