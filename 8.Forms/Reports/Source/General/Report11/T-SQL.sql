SELECT [TblPatList].[PatientID],
[TblRefList].[ID] AS [RefID] ,
ISNULL((SELECT TOP 1 [TblIns].[Name] FROM [PatientsSystem].[Clinic].[Insurances] AS [TblIns] 
	WHERE [TblIns].[ID] = [TblRefList].[Ins1IX]) , '(بدون بیمه)') AS [InsName] , 
(SELECT TOP 1 [TblServices].[Name] FROM [ImagingSystem].[Services].[List] AS [TblServices]
	WHERE [TblServices].[ID] = [TblRefService].[ServiceIX]) AS [ServiceName] ,
(SELECT TOP 1 [TblServices].[Code] FROM [ImagingSystem].[Services].[List] AS [TblServices]
	WHERE [TblServices].[ID] = [TblRefService].[ServiceIX]) AS [ServiceCode] ,
[TblRefService].[Quantity] AS [ServQty] ,
(SELECT TOP 1 ISNULL([TblPerformer].[FirstName] + ' ' , '') + [TblPerformer].[LastName] 
	FROM [ImagingSystem].[Referrals].[Performers] AS [TblPerformer]
	WHERE [TblPerformer].[ID] = [TblRefService].[PhysicianIX]) AS [PhysName] ,
(SELECT TOP 1 ISNULL([TblPerformer].[FirstName] + ' ' , '') + [TblPerformer].[LastName] 
	FROM [ImagingSystem].[Referrals].[Performers] AS [TblPerformer]
	WHERE [TblPerformer].[ID] = [TblRefService].[ExpertIX]) AS [ExpName] ,
[ImagingSystem].[Accounting].[FK_CalcSumIns1Price] ([TblRefList].[ID]) AS [InsPrice],
[ImagingSystem].[Accounting].[FK_CalcSumIns1PatientPart] ([TblRefList].[ID]) AS [InsPatPart],
[ImagingSystem].[Accounting].[FK_CalcSumIns1PartPrice] ([TblRefList].[ID]) AS [InsPart],
[ImagingSystem].[Accounting].[FK_CalcRefServicesPayable] ([TblRefList].[ID]) AS [PatientPayablePrice],
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
ORDER BY [TblRefList].[RegisterDate] , [TblPatList].[PatientID] ASC;