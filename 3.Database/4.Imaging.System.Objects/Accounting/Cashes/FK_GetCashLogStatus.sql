USE ImagingSystem;
GO
IF OBJECT_ID (N'Accounting.FK_GetCashLogStatus', N'FN') IS NOT NULL
    DROP FUNCTION [Accounting].[FK_GetCashLogStatus];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/9/29
-- Last Modified: 1388/9/29
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روال بدست آوردن وضعیت یك صندوق از نظر باز یا بسته بودن
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE FUNCTION [Accounting].[FK_GetCashLogStatus] (@CashID INT)
RETURNS INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS 
BEGIN
	DECLARE @ReturnVal INT;
	-- @@@@@@@@@@@@@@@@@@@@@@@
	-- بدست آوردن وضعیت یك صندوق با استفاده از آخرین لاگ
	-- صندوق باز 0 باز می گرداند و صندوق بسته 1
	-- مقدار تهی برای صندوق باز نشده خواهد بود
	SET @ReturnVal = (SELECT TOP 1 [MyTbl].[IsClosed]
		FROM [ImagingSystem].[Accounting].[CashLog] AS [MyTbl] 
		WHERE [MyTbl].[CashIX] = @CashID
		ORDER BY [MyTbl].[ID] DESC);
	-- @@@@@@@@@@@@@@@@@@@@@@@
	RETURN(@ReturnVal);
END
GO
---@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- SELECT [Accounting].[FK_GetCashLogStatus] (1);