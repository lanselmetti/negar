USE PatientsSystem;
GO
IF OBJECT_ID ( 'Security.SP_InsertUsersInGroups', 'P' ) IS NOT NULL
    DROP PROCEDURE [Security].[SP_InsertUsersInGroups];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/2/24
-- Last Modified: 1388/5/4
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای افزودن یك كاربر در بین كاربران مجاز یك گروه
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Security].[SP_InsertUsersInGroups]
@UserIX SMALLINT ,
@GroupIX SMALLINT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	-- بررسی وجود كاربر و گروه ارسال شده در سیستم
	IF NOT EXISTS (SELECT * FROM [PatientsSystem].[Security].[Users] WHERE [ID] = @UserIX)
		OR NOT EXISTS (SELECT * FROM [PatientsSystem].[Security].[Groups] WHERE [ID] = @GroupIX)
		RETURN;
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	-- بررسی وجود ارتباط بین كاربر و گروه ارسال شده
	IF NOT EXISTS (SELECT * FROM [PatientsSystem].[Security].[UsersInGroups] AS [Tbl]
		WHERE [Tbl].[UserIX] = @UserIX AND [Tbl].[GroupIX] = @GroupIX)
		INSERT INTO [PatientsSystem].[Security].[UsersInGroups]
			(UserIX , GroupIX) VALUES (@UserIX , @GroupIX);
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Security].[SP_InsertUsersInGroups] 5 , 5
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@