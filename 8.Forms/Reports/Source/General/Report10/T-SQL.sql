SELECT [TblPatList].[PatientID],
ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] AS [FullName], 
SUM([TblRefService].[Ins1Price] * [TblRefService].[Quantity]) AS [InsPrice],
SUM(([TblRefService].[Ins1Price] - [TblRefService].[Ins1PartPrice]) * [TblRefService].[Quantity]) AS [InsPatPart],
SUM((ISNULL([TblRefService].[Ins1PartPrice] , 0) + 
	ISNULL([TblRefService].[Ins2PartPrice] , 0)) * [TblRefService].[Quantity]) AS [InsPart],
SUM([TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity]) AS [PatientPayablePrice],
[ImagingSystem].[Accounting].[FK_CalcSumCost] ([TblRefList].[ID]) AS [TotalCosts],
[ImagingSystem].[Accounting].[FK_CalcSumDiscount] ([TblRefList].[ID]) AS [TotalDiscounts],
[ImagingSystem].[Accounting].[FK_CalcSumRecieve] ([TblRefList].[ID]) AS [TotalRecieves],
[ImagingSystem].[Accounting].[FK_CalcSumPay] ([TblRefList].[ID]) AS [TotalPays],
[ImagingSystem].[Accounting].[FK_CalcTotalRefRemain] ([TblRefList].[ID]) AS [RemainValue]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
FROM [PatientsSystem].[Patients].[List] AS [TblPatList]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] 
	ON [TblPatList].[ID] = [TblRefList].[PatientIX]
INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService]
	ON [TblRefService].[ReferralIX] = [TblRefList].[ID]
--WHERE [TblRefList].[Ins1IX] IS NOT NULL 
--	AND [TblRefService].[IsActive] = 1 AND [TblRefService].[IsIns1Cover] = 1
-- --	AND (SELECT TOP 1 [TblServiceList].[CategoryIX] FROM [ImagingSystem].[Services].[List] AS [TblServiceList] 
----WHERE [TblServiceList].[ID] = [TblRefService].[ServiceIX]) IN (7) 
GROUP BY [TblPatList].[PatientID] , ISNULL([TblPatList].[FirstName] + ' ' , '') + [TblPatList].[LastName] , 
[TblRefList].[ID] , [TblRefList].[RegisterDate]
ORDER BY [TblRefList].[RegisterDate] , [TblPatList].[PatientID] ASC;
---------------------------------------------------------------------------------------------------
--	AND [TblRefService].[IsActive] = 1 AND [TblRefService].[IsIns1Cover] = 1
--GROUP BY [TblPatList].[PatientID] , [TblRefList].[RegisterDate] ,
--	ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] ,
--	[TblRefList].[Ins1Num1] , [TblRefList].[PrescriptionDate]
--ORDER BY [TblRefList].[RegisterDate] ASC;