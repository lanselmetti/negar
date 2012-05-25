USE PatientsSystem;
GO
IF OBJECT_ID ( 'Security.SP_SelectACLPermissions', 'P' ) IS NOT NULL
    DROP PROCEDURE [Security].[SP_SelectACLPermissions];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/23
-- Last Modified: 1388/10/21
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Security].[SP_SelectACLPermissions]
@ACLID INT = NULL
WITH ENCRYPTION
-- روالی برای خواندن دسترسی های ثبت شده برای كاربران یا گروه ها در یك سطح دسترسی مشخص
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	IF @ACLID IS NOT NULL
		SELECT [Tbl1].[UserIX] AS [ID]
			, (ISNULL(Tbl2.[FirstName] + ' ', '')  + Tbl2.[LastName]) AS [FullName]
			, [Tbl1].[ACLIX] AS [ACLID] , CONVERT(BIT , 1) AS [IsUser]
			, N'كاربر' AS [Type]
			, (CASE [Tbl1].[IsAllowed] WHEN 0 THEN N'فاقد دسترسی' 
			ELSE N'دارای دسترسی' END) AS [IsAllowed] 
			, [Tbl1].[IsPremiered]
		FROM [PatientsSystem].[Security].[PermissionsUsers] AS [Tbl1]
		INNER JOIN [PatientsSystem].[Security].[Users] AS [Tbl2]
		ON [Tbl1].[UserIX] = Tbl2.ID
		WHERE Tbl1.[UserIX] > 2 AND Tbl1.ACLIX = @ACLID
		-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		UNION SELECT [Tbl1].[GroupIX] AS [ID]
			,[Tbl2].[Name] AS [FullName] ,[Tbl1].[ACLIX] AS [ACLID]
			, CONVERT(BIT , 0) AS [IsUser] , N'گروه' AS [Type]
			, (CASE [Tbl1].[IsAllowed] WHEN 0 THEN N'فاقد دسترسی' 
			ELSE N'دارای دسترسی' END) AS [IsAllowed]
			, NULL AS [IsPremiered]
		FROM [PatientsSystem].[Security].[PermissionsGroups] AS [Tbl1]
		LEFT OUTER JOIN [PatientsSystem].[Security].[Groups] AS [Tbl2]
		ON [Tbl1].[GroupIX] = [Tbl2].[ID]
		WHERE [Tbl1].ACLIX = @ACLID;
	-- OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
	-- OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
	-- OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
	ELSE	
		SELECT [Tbl1].[UserIX] AS [ID]
			, (ISNULL(Tbl2.[FirstName] + ' ', '')  + Tbl2.[LastName]) AS [FullName]
			, [Tbl1].[ACLIX] AS [ACLID] , CONVERT(BIT , 1) AS [IsUser]
			, N'كاربر' AS [Type]
			, (CASE [Tbl1].[IsAllowed] WHEN 0 THEN N'فاقد دسترسی' 
			ELSE N'دارای دسترسی' END) AS [IsAllowed] 
			, [Tbl1].[IsPremiered]
		FROM [PatientsSystem].[Security].[PermissionsUsers] AS [Tbl1]
		INNER JOIN [PatientsSystem].[Security].[Users] AS [Tbl2]
		ON [Tbl1].[UserIX] = Tbl2.ID
		WHERE [Tbl1].[UserIX] > 2
		-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		UNION SELECT [Tbl1].[GroupIX] AS [ID]
			,[Tbl2].[Name] AS [FullName] ,[Tbl1].[ACLIX] AS [ACLID]
			, CONVERT(BIT , 0) AS [IsUser] , N'گروه' AS [Type]
			, (CASE [Tbl1].[IsAllowed] WHEN 0 THEN N'فاقد دسترسی' 
			ELSE N'دارای دسترسی' END) AS [IsAllowed]
			, NULL AS [IsPremiered]
		FROM [PatientsSystem].[Security].[PermissionsGroups] AS [Tbl1]
		LEFT OUTER JOIN [PatientsSystem].[Security].[Groups] AS [Tbl2]
		ON [Tbl1].[GroupIX] = [Tbl2].[ID];	
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Security].[SP_SelectACLPermissions] 3
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@