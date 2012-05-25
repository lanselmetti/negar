USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_SelectLogCategories', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_SelectLogCategories];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1391/01/14
-- Last Modified: 1391/01/14
-- Created By: Mohammad Hosein Zohrehvand
-- Last Modified By: Mohammad Hosein Zohrehvand
-- روالی برای فراخوانی لیست طبقه بندی رخداد های نوبت دهی همراه با آیتم انتخاب نشده
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_SelectLogCategories]
WITH ENCRYPTION
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS ID , '(انتخاب نشده)' AS [Name] , NULL AS [Description]
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@
	UNION ALL SELECT [ID] ,[Name] ,[Description]
	FROM [ImagingSystem].[Schedules].[LogCategories];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Schedules].[SP_SelectLogCategories] 
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@