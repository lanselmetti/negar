USE ImagingSystem;
GO
IF OBJECT_ID ( 'Documents.SP_SelectType', 'P' ) IS NOT NULL
    DROP PROCEDURE [Documents].[SP_SelectType];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/8/14
-- Last Modified: 1388/8/14
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن لیست انواع مدارك تصویربرداری به همراه آیتم انتخاب نشده
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Documents].[SP_SelectType]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS [ID] , 1 AS [IsActive] , N'(انتخاب نشده)' AS [Title] , NULL AS [Description]
	UNION ALL SELECT [ID] ,[IsActive] ,[Title] ,[Description]
	FROM [ImagingSystem].[Documents].[Type];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [Documents].[SP_SelectType]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@