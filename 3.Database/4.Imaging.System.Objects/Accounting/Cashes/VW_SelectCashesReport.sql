USE ImagingSystem;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
IF OBJECT_ID ( 'Accounting.VW_SelectCashesReport') IS NOT NULL
    DROP VIEW [Accounting].[VW_SelectCashesReport];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/4/18
-- Last Modified: 1388/10/2
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE VIEW [Accounting].[VW_SelectCashesReport]
WITH ENCRYPTION 
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT ROW_NUMBER() OVER (ORDER BY [Tbl2].[ID]) AS [RowNo] ,
	[Tbl1].[ID] AS [CashID] , [Tbl1].[Name] AS [CashName], [Tbl1].[Description], [Tbl2].[ID] AS [CashLogID],
	-- +++++++++++++++++++++++++++
	(CASE WHEN [Tbl2].[IsClosed] = 0 THEN 'باز' ELSE 'بسته' END) AS [CashStatus],
	-- +++++++++++++++++++++++++++
	[Tbl2].[OpenerCashierIX],
	-- +++++++++++++++++++++++++++
	(SELECT (ISNULL([MyTbl].[FirstName] + ' ', '')  + 
		[MyTbl].[LastName]) AS [FullName]
		FROM [PatientsSystem].[Security].[Users] AS [MyTbl]
		WHERE [MyTbl].[ID] = [Tbl2].[OpenerCashierIX]) AS [OpenerCashierName] ,
	-- +++++++++++++++++++++++++++
	[Tbl2].[StartDateTime] , [Tbl2].[SupplyBegin], 
	-- +++++++++++++++++++++++++++
	-- موجودی مقرر
	[ImagingSystem].[Accounting].[FK_GetCashLogStatutorySypply]([Tbl2].[ID]) AS [StatutorySypply] ,
	-- +++++++++++++++++++++++++++
	Tbl2.[SupplyEnd], 
	-- +++++++++++++++++++++++++++
	(SELECT SUM([Value]) FROM [ImagingSystem].[Accounting].[CashInputOutput] 
		WHERE [Accounting].[CashInputOutput].[CashLogIX] = [Tbl2].[ID]) AS [InputsOutputsBalance] ,
	-- +++++++++++++++++++++++++++
	[Tbl2].[CloserCashierIX] , 
	-- +++++++++++++++++++++++++++
	(SELECT (ISNULL(MyTbl.[FirstName] + ' ', '')  + 
		MyTbl.[LastName]) AS [FullName]
		FROM [PatientsSystem].[Security].[Users] AS MyTbl
		WHERE MyTbl.ID = Tbl2.CloserCashierIX) AS [CloserCashierName] ,
	-- +++++++++++++++++++++++++++
	[Tbl2].[FinishDateTime]
	-- ******************************************************************
	FROM [ImagingSystem].[Accounting].[Cashes] AS [Tbl1]
	LEFT OUTER JOIN [ImagingSystem].[Accounting].[CashLog] AS [Tbl2]
	ON [Tbl1].[ID] = [Tbl2].[CashIX]
	LEFT OUTER JOIN [ImagingSystem].[Accounting].[CashInputOutput] As [Tbl3]
	ON [Tbl2].[ID] = [Tbl3].[CashLogIX]
	WHERE [Tbl1].[IsActive] = 1 AND [Tbl2].[IsClosed] IS NOT NULL
	-- ++++++++++++++++++++++++++++++++++++++
	GROUP BY [Tbl1].[ID] , [Tbl1].[Name] , 
	[Tbl1].[Description] , [Tbl2].[ID] ,
	[Tbl2].[IsClosed] , [Tbl2].[StartDateTime] ,
	[Tbl2].[FinishDateTime] , [Tbl2].[OpenerCashierIX] , 
	[Tbl2].[SupplyBegin], [Tbl2].[SupplyEnd], 
	[Tbl2].[CloserCashierIX];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- SELECT * FROM [ImagingSystem].[Accounting].[VW_SelectCashesReport]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@