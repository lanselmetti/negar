SELECT TOP 100 [TblPatList].[PatientID] ,
(ISNULL([TblPatList].[FirstName] + ' ' , '') + [TblPatList].[LastName] ) AS [FullName], 
[TblRefTrans].[OccuredDate] AS [TransDateTimeEn],
'1380/01/01 - 10:00:00' AS [TransDateTime],
[TblRefTrans].[Value] AS [RealValue] , 
(CASE WHEN [TblRefTrans].[Value] >= 0 THEN 'دریافت' ELSE 'بازپرداخت' END) AS [Type] ,
ABS([TblRefTrans].[Value]) AS [Value] ,
(CASE WHEN [TblRefTransAddin].[PayType] = 1 THEN 'چك' 
WHEN [TblRefTransAddin].[PayType] = 2 THEN 'فیش' ELSE 'نقد' END) AS [PayType] ,
(SELECT TOP 1 [Tbl].[Name] FROM [ImagingSystem].[Accounting].[Banks] AS [Tbl]
	WHERE [Tbl].[ID] = [TblRefTransAddin].[BankIX]) AS [BankName] ,
[TblRefTransAddin].[BranchName] ,
[TblRefTransAddin].[BranchCode] ,
[TblRefTransAddin].[CheckDate] AS [CheckDateEn] ,
'1380/01/01' AS [CheckDate] ,
[TblRefTransAddin].[CheckNumber] ,
(CASE WHEN [TblRefTransAddin].[AccountType] = 1 THEN 'جاری' 
WHEN [TblRefTransAddin].[AccountType] = 2 THEN 'پس انداز'
WHEN [TblRefTransAddin].[AccountType] = 3 THEN 'قرض الحسنه' END) AS [AccountType] ,
[TblRefTransAddin].[AccountNumber]
-- +++++++++++++++++++++++++++++++++++
FROM [PatientsSystem].[Patients].[List] AS [TblPatList]
INNER JOIN  [ImagingSystem].[Referrals].[List] AS [TblRefList] 
ON [TblPatList].[ID] = [TblRefList].[PatientIX]
INNER JOIN [ImagingSystem].[Accounting].[RefTransaction] AS [TblRefTrans] 
ON [TblRefTrans].[ReferralIX] = [TblRefList].[ID]
LEFT OUTER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblRefTransAddin] 
ON [TblRefTrans].[ID] = [TblRefTransAddin].[RefTransactionIX]
-- +++++++++++++++++++++++++++++++++++
ORDER BY [TblRefList].[RegisterDate] , [TblRefList].[ID] , [TblRefTrans].[OccuredDate] ASC