USE PatientsSystem;
GO
IF OBJECT_ID ( 'Security.SP_SelectGroups', 'P' ) IS NOT NULL
    DROP PROCEDURE [Security].[SP_SelectGroups];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/23
-- Last Modified: 1388/7/12
-- Created By: Elham Samiei
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن لیست گروه ها ، به همراه آیتم انتخاب نشده
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Security].[SP_SelectGroups]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS [ID] , 1 AS [IsActive] , '(انتخاب نشده)' AS [Name] , NULL AS [Description]
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	UNION ALL SELECT Tbl.[ID] ,Tbl.[IsActive] ,Tbl.[Name] ,Tbl.[Description]
	FROM [PatientsSystem].[Security].[Groups] AS Tbl
	WHERE [IsActive] = 1 ORDER BY 3;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Security].[SP_SelectGroups]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@