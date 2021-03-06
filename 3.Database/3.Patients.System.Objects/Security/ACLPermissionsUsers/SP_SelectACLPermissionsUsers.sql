USE PatientsSystem;
GO
IF OBJECT_ID ( 'Security.SP_SelectACLPermissionsUsers', 'P' ) IS NOT NULL
    DROP PROCEDURE [Security].[SP_SelectACLPermissionsUsers];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/23
-- Last Modified: 1389/5/24
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- روالی برای بدست آوردن دسترسی یك كاربر به یك سطح دسترسی
-- این روال دسترسی گروه هایی كه كاربر ارسال شده در آن عوض می باشد را
-- برای دسترسی مورد نظر بررسی می كند
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Security].[SP_SelectACLPermissionsUsers]
@UserID SMALLINT
,@ACLID INT
,@IsAllowed BIT = NULL OUTPUT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SET @IsAllowed = (SELECT [IsAllowed] FROM [PatientsSystem].[Security].[PermissionsUsers]
		WHERE [UserIX] = @UserID AND [ACLIX] = @ACLID);
	-- MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
	IF (@IsAllowed IS NULL OR @IsAllowed = 1)
	BEGIN
		DECLARE @IsPremiered BIT;
		SET @IsPremiered = (SELECT [IsPremiered] FROM [PatientsSystem].[Security].[PermissionsUsers]
			WHERE [UserIX] = @UserID AND [ACLIX] = @ACLID)
		-- MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
		IF (@IsPremiered IS NULL OR @IsPremiered = 0)
		BEGIN
			DECLARE @Cursor CURSOR;
			SET @Cursor = CURSOR FOR SELECT [Tbl1].[GroupIX]
				FROM [PatientsSystem].[Security].[UsersInGroups] AS [Tbl1] 
				INNER JOIN [PatientsSystem].[Security].[Groups] AS [Tbl2] 
				ON [Tbl1].[GroupIX] = [Tbl2].[ID]
				WHERE [Tbl1].[UserIX] = @UserID AND [Tbl2].[IsActive] = 1;
			DECLARE @Count INT;
			SET @Count = (SELECT COUNT(*) 
				FROM [PatientsSystem].[Security].[UsersInGroups] WHERE [UserIX] = @UserID);
			-- MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
			DECLARE @GroupID SMALLINT;
			OPEN @Cursor;
			WHILE @Count > 0
		    BEGIN
				FETCH NEXT FROM @Cursor INTO @GroupID;
				SET @IsAllowed = ISNULL((SELECT [IsAllowed]
					FROM [PatientsSystem].[Security].[PermissionsGroups]
					WHERE [GroupIX] = @GroupID AND [ACLIX] = @ACLID) , 1);
				IF (@IsAllowed = 0) BREAK;
				SET @Count = (@Count - 1);
			END
			-- MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
			CLOSE @Cursor;
			DEALLOCATE @Cursor;
		END
		-- MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
	END
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
--DECLARE @ReturnValue BIT
--EXEC [Security].[SP_SelectACLPermissionsUsers] 10 , 5 , @ReturnValue OUTPUT
--SELECT @ReturnValue
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@