USE PatientsSystem;
GO
IF OBJECT_ID ( 'Log.SP_SelectCategories', 'P' ) IS NOT NULL
    DROP PROCEDURE [Log].[SP_SelectCategories];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/6/25
-- Last Modified: 1388/6/26
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Log].[SP_SelectCategories]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS [ID] , NULL AS [EnglishTitle] , '(انتخاب نشده)' AS [LocaleTitle]
	UNION ALL SELECT [ID] ,[EnglishTitle] ,[LocaleTitle]
	FROM [PatientsSystem].[Log].[Categories];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- EXEC Log.[SP_SelectCategories] 
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@