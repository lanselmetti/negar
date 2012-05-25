USE ImagingSystem;
GO
IF OBJECT_ID (N'Accounting.FK_CalcLastCashInOutBalance', N'FN') IS NOT NULL
    DROP FUNCTION [Accounting].[FK_CalcLastCashInOutBalance];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/9/29
-- Last Modified: 1388/9/29
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روال محاسبه بالانس ورود و خروج پول برای یك صندوق مشخص
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE FUNCTION [Accounting].[FK_CalcLastCashInOutBalance] (@CashID INT)
RETURNS INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS 
BEGIN
	DECLARE @ReturnVal INT;
	-- @@@@@@@@@@@@@@@@@@@@@@@
	-- بدست آوردن كلید آخرین لاگ برای صندوق مورد نظر
	DECLARE @LastCashLogID INT;
	SET @LastCashLogID = (SELECT MAX([ID])
		FROM [ImagingSystem].[Accounting].[CashLog] 
		WHERE [CashIX] = @CashID);
	-- @@@@@@@@@@@@@@@@@@@@@@@	
	-- محاسبه تراز ورود و خروج پول برای لاگ صندوق مورد نظر
	-- به دلیل آنكه خروج پول به صورت عبارت منفی ثبت 
	-- می شود ، محاسبه مجموع اعداد كفایت می كند
	SET @ReturnVal = (SELECT SUM([Value])
		FROM [ImagingSystem].[Accounting].[CashInputOutput] AS [MyTbl]
		WHERE [MyTbl].[CashLogIX] = @LastCashLogID)
	-- @@@@@@@@@@@@@@@@@@@@@@@
	RETURN(@ReturnVal);
END
GO
---@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- SELECT [Accounting].[FK_CalcLastCashInOutBalance] (3);