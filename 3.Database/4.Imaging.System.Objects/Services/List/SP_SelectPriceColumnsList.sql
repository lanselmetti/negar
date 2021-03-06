USE ImagingSystem;
GO
IF OBJECT_ID ( 'Services.SP_SelectPriceColumnsList', 'P' ) IS NOT NULL
    DROP PROCEDURE [Services].[SP_SelectPriceColumnsList];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/01/16 
-- Last Modified: 1389/06/09
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
-- این روال وظیفه خواندن فیلدهای اطلاعاتی و فیلدهای اضافی قیمت خدمات را بر عهده دارد
-- از این روال برای مدیریت فیلدهای قیمت خدمات استفاده می شود
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Services].[SP_SelectPriceColumnsList]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	-- دو مورد اول به صورت دستی افزوده می شوند
	SELECT '1FreePrice' AS [ColumnName] , N'تعرفه بدون بیمه' AS [Name]
	UNION ALL SELECT '2GovPrice' AS [ColumnName] , N'تعرفه دولتی' AS [Name]
	UNION ALL SELECT [ColumnName] AS [ColumnName] ,[Name] AS [Name]
	FROM [ImagingSystem].[Services].[AdditionalPriceColumns];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [Services].[SP_SelectPriceColumnsList]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@