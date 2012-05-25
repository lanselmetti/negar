USE ImagingSystem;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
IF OBJECT_ID ( 'Accounting.SP_SelectCashiersCashes', 'P' ) IS NOT NULL
    DROP PROCEDURE [Accounting].[SP_SelectCashiersCashes];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/09/18
-- Last Modified: 1389/07/30
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن لیست صندوق های قابل استفاده "فعال" و "باز" بر اساس "مجوز استفاده كاربر" در سیستم
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Accounting].[SP_SelectCashiersCashes]
-- صندوقدار مورد نظر برای بررسی
@CashierID SMALLINT
-- كلید صندوق ویرایش ، در صورتی كه برای ویرایش یك تراكنش فراخوانی شود
-- همه صندوق های مجاز ، به همراه صندوق ارسال شده نمایش داده خواهد شد
-- در غیر این صورت تهی خواهد بود كه برای حالت افزودن استفاده خواهد شد
-- و تنها صندوق های مجاز نمایش داده می شود
,@EditCashID SMALLINT = NULL
WITH ENCRYPTION 
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	IF @CashierID < 3 -- برای 2 كاربر پیش فرض			
		SELECT @CashierID AS [CashierID] , [ID] AS [CashID] , 
			[IsActive] AS [CashIsActive] , [Name] AS [CashName]
		FROM [ImagingSystem].[Accounting].[Cashes]		
		-- @@@@@@@@@@@@@@@@@@@@@@@@@
		UNION ALL SELECT NULL AS [CashierID] , NULL AS [CashID] , 
			1 AS [CashIsActive] , '(بدون صندوق)' AS [CashName];
	-- OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
	-- OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
	ELSE -- برای كاربران غیر مدیر
		-- نمایش تنها صندوق های فعال و باز
		IF @EditCashID IS NULL
			SELECT [Tbl2].[CashierIX] AS [CashierID] , [Tbl1].[ID] AS [CashID] , 
			[Tbl1].[IsActive] AS [CashIsActive] , [Tbl1].[Name] AS [CashName]		
			FROM [ImagingSystem].[Accounting].[Cashes] AS [Tbl1]
			INNER JOIN [ImagingSystem].[Accounting].[CashiersCashes] AS [Tbl2]
			ON [Tbl1].[ID] = [Tbl2].[CashIX]		
			WHERE [Tbl2].[CashierIX] = @CashierID AND [Tbl1].[IsActive] = 1 
			-- بررسی صندوق های باز
			AND [ImagingSystem].[Accounting].[FK_GetCashLogStatus] ([Tbl1].[ID]) = 0
			-- @@@@@@@@@@@@@@@@@@@@@@@@@
			UNION ALL SELECT NULL AS [CashierID] , NULL AS [CashID] , 
				1 AS [CashIsActive] , '(بدون صندوق)' AS [CashName];
		-- OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
		-- نمایش صندوق های فعال و باز و صندوق ویرایش
		ELSE
			SELECT [Tbl2].[CashierIX] AS [CashierID] , [Tbl1].[ID] AS [CashID] , 
			[Tbl1].[IsActive] AS [CashIsActive] , [Tbl1].[Name] AS [CashName]		
			FROM [ImagingSystem].[Accounting].[Cashes] AS [Tbl1]
			INNER JOIN [ImagingSystem].[Accounting].[CashiersCashes] AS [Tbl2]
			ON [Tbl1].[ID] = [Tbl2].[CashIX]		
			WHERE [Tbl2].[CashierIX] = @CashierID AND [Tbl1].[IsActive] = 1
			-- بررسی صندوق های باز
			AND [ImagingSystem].[Accounting].[FK_GetCashLogStatus] ([Tbl1].[ID]) = 0
			-- @@@@@@@@@@@@@@@@@@@@@@@@@
			UNION SELECT @CashierID AS [CashierID] , [ID] AS [CashID] , 
			[IsActive] AS [CashIsActive] , [Name] AS [CashName]
			FROM [ImagingSystem].[Accounting].[Cashes]
			WHERE [ID] = @EditCashID
			-- @@@@@@@@@@@@@@@@@@@@@@@@@
			UNION ALL SELECT NULL AS [CashierID] , NULL AS [CashID] , 
				1 AS [CashIsActive] , '(بدون صندوق)' AS [CashName];
 GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Accounting].[SP_SelectCashiersCashes] 3 , 2
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@