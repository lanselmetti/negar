USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_SelectApplications', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_SelectApplications];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/4/8
-- Last Modified: 1388/6/29
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای فراخوانی لیست برنامه های نصب شده در سیستم همراه با آیتم انتخاب نشده
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_SelectApplications]
WITH ENCRYPTION
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS ID , NULL AS [IsActive] , '(انتخاب نشده)' AS [Name] ,
	NULL AS [IsFixed] , NULL AS [StartDate] , NULL AS [EndDate] , NULL AS [Description]
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@
	UNION ALL SELECT [ID] ,[IsActive] ,[Name] ,[IsFixed] ,[StartDate] ,[EndDate] ,[Description]
	FROM [ImagingSystem].[Schedules].[Applications];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Schedules].[SP_SelectApplications] NULL
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@