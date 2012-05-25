USE ImagingSystem;
GO
IF OBJECT_ID (N'Accounting.FK_GetCashLogStatutorySypply', N'FN') IS NOT NULL
    DROP FUNCTION [Accounting].[FK_GetCashLogStatutorySypply];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Last Modified: 1388/10/2
-- Last Modified: 1389/01/06
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روال بدست آوردن موجودی مقرر یك لاگ صندوق
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE FUNCTION [Accounting].[FK_GetCashLogStatutorySypply](@CashLogID INT)
RETURNS INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS 
BEGIN
	DECLARE @ReturnVal INT;
	-- @@@@@@@@@@@@@@@@@@@@@@@
	DECLARE @CashLogStart DATETIME;
	SET @CashLogStart = (SELECT [StartDateTime] 
		FROM [ImagingSystem].[Accounting].[CashLog] WHERE [ID] = @CashLogID);
	-- @@@@@@@@@@@@@@@@@@@@@@@
	DECLARE @CashLogFinish DATETIME;
	SET @CashLogFinish = (SELECT [FinishDateTime]
		FROM [ImagingSystem].[Accounting].[CashLog] WHERE [ID] = @CashLogID);
	-- @@@@@@@@@@@@@@@@@@@@@@@
	DECLARE @CashID SMALLINT;
	SET @CashID = (SELECT [CashIX]
		FROM [ImagingSystem].[Accounting].[CashLog] WHERE [ID] = @CashLogID);
	-- @@@@@@@@@@@@@@@@@@@@@@@
	IF @CashLogFinish IS NULL
		SET @ReturnVal = 
			(SELECT SUM([MyTbl].[Value]) FROM [ImagingSystem].[Accounting].[RefTransaction] AS [MyTbl]
			WHERE [MyTbl].[CashIX] = @CashID AND [MyTbl].[OccuredDate] >= @CashLogStart);
	ELSE 
		SET @ReturnVal = 
			(SELECT SUM([MyTbl].[Value]) FROM [ImagingSystem].[Accounting].[RefTransaction] AS [MyTbl]
			WHERE [MyTbl].[CashIX] = @CashID AND [MyTbl].[OccuredDate] >= @CashLogStart
			AND [MyTbl].[OccuredDate] <= @CashLogFinish);
	-- @@@@@@@@@@@@@@@@@@@@@@@
	RETURN(@ReturnVal);
END
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
-- SELECT [Accounting].[FK_GetCashLogStatutorySypply] (3);
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@