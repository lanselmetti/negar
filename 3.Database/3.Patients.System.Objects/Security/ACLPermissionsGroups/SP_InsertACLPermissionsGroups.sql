USE PatientsSystem;
GO
IF OBJECT_ID ( 'Security.SP_InsertACLPermissionsGroups', 'P' ) IS NOT NULL
    DROP PROCEDURE [Security].[SP_InsertACLPermissionsGroups];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/2/24
-- Last Modified: 1388/5/5
-- Created By: Saeed Pournejati
-- Last Modified By:  Saeed Pournejati
-- روالی برای افزودن دسترسی به یك گروه یا ویرایش دسترسی قبلی آن گروه
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Security].[SP_InsertACLPermissionsGroups]
@GroupID SMALLINT,
@ACLIX INT,
@IsAllowed BIT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	-- اگر قبلاً آن گروه دسترسی داشته باشد ، دسترسی به روز می شود
	IF EXISTS (SELECT * FROM [PatientsSystem].[Security].[PermissionsGroups]
		WHERE [GroupIX] = @GroupID AND [ACLIX] = @ACLIX)
		UPDATE [PatientsSystem].[Security].[PermissionsGroups]
		SET [IsAllowed] = @IsAllowed
		WHERE [GroupIX] = @GroupID AND [ACLIX] = @ACLIX
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	ELSE 
		INSERT INTO [PatientsSystem].[Security].[PermissionsGroups]
		([GroupIX] ,[ACLIX] ,[IsAllowed]) VALUES (@GroupID, @ACLIX, @IsAllowed)
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Security].[SP_InsertACLPermissionsGroups] 1 , 1 , 1
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@