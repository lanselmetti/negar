USE PatientsSystem;
GO
IF OBJECT_ID ( 'Security.SP_SelectACL', 'P' ) IS NOT NULL
    DROP PROCEDURE [Security].[SP_SelectACL];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/23
-- Last Modified: 1388/5/4
-- Created By: Elham Samiei
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن لیست كامل دسترسی های ثبت شده در سیستم یا برای یك زیر سیستم
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Security].[SP_SelectACL]
@AppID SMALLINT = NULL
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	IF @AppID IS NULL	
		SELECT [ID] ,[ParentIX] ,[ApplicationIX] ,[IsTitle] ,[EnglishName] ,[LocaleName] ,[Description]
		FROM [PatientsSystem].[Security].[ACL]
		ORDER BY 1;
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	ELSE
		SELECT [ID] ,[ParentIX] ,[ApplicationIX] ,[IsTitle] ,[EnglishName] ,[LocaleName] ,[Description]
		FROM [PatientsSystem].[Security].[ACL]
		WHERE [ApplicationIX] = @AppID
		ORDER BY 1;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Security].[SP_SelectACL] 500
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@