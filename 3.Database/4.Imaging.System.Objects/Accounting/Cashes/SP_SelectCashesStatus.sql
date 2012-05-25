USE ImagingSystem;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
IF OBJECT_ID ( 'Accounting.SP_SelectCashesStatus', 'P' ) IS NOT NULL
    DROP PROCEDURE [Accounting].[SP_SelectCashesStatus];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/04/16
-- Last Modified: 1389/06/14
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای نمایش وضعیت صندوق های تصویربرداری
-- این روال وضعیت صندوق های را از نظر باز یا بسته بودن بررسی می نماید
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Accounting].[SP_SelectCashesStatus]
-- این كلید برای فیلتر كردن صندوق های مجاز كاربر جاری خواهد بود
@CashierID SMALLINT = NULL
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	-- مدیران اصلی سیستم به تمام صندوق های "فعال" دسترسی دارند
	IF @CashierID < 3
		SELECT ROW_NUMBER() OVER (ORDER BY [Tbl1].[ID]) AS [RowNo] , -- ردیف
		[Tbl1].[ID] AS [CashID] , -- كلید صندوق
		[Tbl1].[Name], -- نام صندوق
		[Tbl1].[Description], -- توضیحات صندوق
		-- كلید آخرین لاگ صندوق جاری
		(SELECT [ImagingSystem].[Accounting].[FK_CalcLastCashLogID] ([Tbl1].[ID])) AS [CashLogID] ,
		-- كلید وضعیت صندوق
		(SELECT [ImagingSystem].[Accounting].[FK_GetCashLogStatus] ([Tbl1].[ID])) AS [CashStatusID], 
		-- وضعیت صندوق ، در دو دسته "باز" و "بسته" بر اساس آخرین ردیف رخداد صندوق مورد نظر
		(CASE WHEN [ImagingSystem].[Accounting].[FK_GetCashLogStatus] ([Tbl1].[ID]) = 0 THEN 'باز'
			ELSE 'بسته' END) AS [CashStatus] ,
		-- تراز ورود و خروج پول برای آخرین رخداد صندوق مورد نظر
		(SELECT [ImagingSystem].[Accounting].[FK_CalcLastCashInOutBalance]([Tbl1].[ID])) AS [InOutBalance]
		-- *******************************************************
		FROM [ImagingSystem].[Accounting].[Cashes] AS [Tbl1] 
		WHERE [Tbl1].[IsActive] = 1 ORDER BY [Tbl1].[ID];
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	-- اگر صندوقدار مدیر اصلی سیستم نباشد ، بر اساس دسترسی
	-- وی به صندوق ها "وضعیت" نمایش داده می شود
	ELSE
		SELECT ROW_NUMBER() OVER (ORDER BY [Tbl1].[ID]) AS [RowNo] , -- ردیف
		[Tbl1].[ID] AS [CashID] , -- كلید صندوق
		[Tbl1].[Name], -- نام صندوق
		[Tbl1].[Description], -- توضیحات صندوق
		-- كلید آخرین لاگ صندوق جاری
		(SELECT [ImagingSystem].[Accounting].[FK_CalcLastCashLogID] ([Tbl1].[ID])) AS [CashLogID] ,
		-- كلید وضعیت صندوق
		(SELECT [ImagingSystem].[Accounting].[FK_GetCashLogStatus] ([Tbl1].[ID])) AS [CashStatusID], 
		-- وضعیت صندوق ، در دو دسته "باز" و "بسته" بر اساس آخرین ردیف رخداد صندوق مورد نظر
		(CASE WHEN [ImagingSystem].[Accounting].[FK_GetCashLogStatus] ([Tbl1].[ID]) = 0 THEN 'باز'
			ELSE 'بسته' END) AS [CashStatus] ,
		-- تراز ورود و خروج پول برای آخرین رخداد صندوق مورد نظر
		(SELECT [ImagingSystem].[Accounting].[FK_CalcLastCashInOutBalance]([Tbl1].[ID])) AS [InOutBalance]
		-- *******************************************************
		FROM [ImagingSystem].[Accounting].[Cashes] AS [Tbl1] 
		RIGHT OUTER JOIN [ImagingSystem].[Accounting].[CashiersCashes] AS [Tbl2]
		ON [Tbl1].[ID] = [Tbl2].[CashIX]
		WHERE [Tbl1].[IsActive] = 1 AND [Tbl2].[CashierIX] = @CashierID ORDER BY [Tbl1].[ID];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Accounting].[SP_SelectCashesStatus] 3
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@