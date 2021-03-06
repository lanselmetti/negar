USE PatientsSystem;
GO
IF OBJECT_ID ( 'Security.SP_InsertACLPermissionsUsers', 'P' ) IS NOT NULL
    DROP PROCEDURE [Security].[SP_InsertACLPermissionsUsers];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/2/24
-- Last Modified: 1388/5/5
-- Created By: Saeed Pournejati
-- Last Modified By:  Saeed Pournejati
-- روالی برای افزودن دسترسی به یك كاربر یا ویرایش دسترسی قبلی آن كاربر
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Security].[SP_InsertACLPermissionsUsers]
@UserIX SMALLINT ,
@ACLIX INT ,
@IsAllowed BIT ,
@IsPremiered BIT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	-- اگر قبلاً آن كاربر دسترسی داشته باشد ، دسترسی به روز می شود
	IF EXISTS (SELECT * FROM [PatientsSystem].[Security].[PermissionsUsers]
		WHERE [UserIX] = @UserIX AND [ACLIX] = @ACLIX)
		UPDATE [PatientsSystem].[Security].[PermissionsUsers]
		SET [IsAllowed] = @IsAllowed , [IsPremiered] = @IsPremiered
		WHERE [UserIX] = @UserIX AND [ACLIX] = @ACLIX;
	-- @@@@@@@@@@@@@@@@@@@@@@@
	ELSE
		INSERT INTO [PatientsSystem].[Security].[PermissionsUsers]
			([UserIX] ,[ACLIX] ,[IsAllowed] ,[IsPremiered])
		VALUES (@UserIX, @ACLIX, @IsAllowed , @IsPremiered)
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Security].[SP_InsertACLPermissionsUsers] 5 , 5 , 1 , 1
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@