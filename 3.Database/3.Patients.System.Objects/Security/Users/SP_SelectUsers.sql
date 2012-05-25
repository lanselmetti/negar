USE PatientsSystem;
GO
IF OBJECT_ID ( 'Security.SP_SelectUsers', 'P' ) IS NOT NULL
    DROP PROCEDURE [Security].[SP_SelectUsers];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/23
-- Last Modified: 1388/5/26
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن لیست كاربران ثبت شده در سیستم همراه با كاربر انتخاب نشده
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Security].[SP_SelectUsers]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS [ID] , NULL AS  [IsActive], NULL AS [UserName],
	 NULL AS [FirstName] , NULL AS [LastName] , '(انتخاب نشده)' AS [FullName] , NULL AS [Description]
	UNION ALL SELECT [ID] , [IsActive] , [UserName] , [FirstName] , [LastName] , 
		[FullName] = ( ISNULL([FirstName] + ' ', '') + [LastName]) , [Description]
	FROM [PatientsSystem].[Security].[Users];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [PatientsSystem].[Security].[SP_SelectUsers]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@