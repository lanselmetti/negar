USE ImagingSystem;
GO
IF OBJECT_ID ( 'Services.SP_SelectCategories', 'P' ) IS NOT NULL
    DROP PROCEDURE [Services].[SP_SelectCategories];
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
GO
-- Created Date: 1388/1/16 
-- Last Modified: 1388/7/1
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن لیست طبقه بندی های خدمات همراه با آیتم انتخاب نشده
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Services].[SP_SelectCategories]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS  [ID] , NULL AS [IsActive] , '(انتخاب نشده)' AS [Name]
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	UNION ALL SELECT [ID] , [IsActive] , [Name]
	FROM [ImagingSystem].[Services].[Categories] ORDER BY [Name];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [Services].[SP_SelectCategories] 7
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@