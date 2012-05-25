USE ImagingSystem;
GO
IF OBJECT_ID (N'Accounting.FK_CalcLastCashLogID', N'FN') IS NOT NULL
    DROP FUNCTION [Accounting].[FK_CalcLastCashLogID];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/9/29
-- Last Modified: 1388/9/29
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روال محاسبه آخرین لاگ برای یك صندوق
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE FUNCTION [Accounting].[FK_CalcLastCashLogID] (@CashID INT)
RETURNS INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS 
BEGIN
	DECLARE @ReturnVal INT;
	-- @@@@@@@@@@@@@@@@@@@@@@@
	-- بدست آوردن كلید آخرین لاگ برای صندوق مورد نظر
	-- باید توجه داشته كه لاگ آخر ارتباطی به تاریخ ندارد و
	-- تنها بر اساس كلید لاگ بدست می آید
	SET @ReturnVal = (SELECT MAX([ID])
		FROM [ImagingSystem].[Accounting].[CashLog] 
		WHERE [CashIX] = @CashID);
	-- @@@@@@@@@@@@@@@@@@@@@@@
	RETURN(@ReturnVal);
END
GO
---@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- SELECT [Accounting].[FK_CalcLastCashLogID] (3);