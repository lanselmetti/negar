USE ImagingSystem;
GO
IF OBJECT_ID ( 'Settings.SP_InsertUserSetting', 'P' ) IS NOT NULL
    DROP PROCEDURE [Settings].[SP_InsertUserSetting];
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
GO
-- Created Date: 1388/07/29
-- Last Modified: 1390/11/05
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای ثبت یك تنظیمات برای یك كاربر مشخص
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Settings].[SP_InsertUserSetting]
@UserID SMALLINT
,@SettingID INT
, @BooleanValue BIT
, @StringValue NVARCHAR(100)
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	IF @UserID IS NULL
		DELETE FROM [ImagingSystem].[Settings].[UsersSettings]
		WHERE [SettingIX] = @SettingID;
	IF EXISTS(SELECT * FROM [ImagingSystem].[Settings].[UsersSettings] 
		WHERE [SettingIX] = @SettingID AND [UserIX] = @UserID)
		UPDATE [ImagingSystem].[Settings].[UsersSettings]
		SET [Boolean] = @BooleanValue ,[Value] = @StringValue
		WHERE [SettingIX] = @SettingID AND [UserIX] = @UserID
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	ELSE INSERT INTO [ImagingSystem].[Settings].[UsersSettings]
           ([SettingIX] ,[UserIX] ,[Boolean] ,[Value])
		VALUES (@SettingID , @UserID , @BooleanValue , @StringValue)
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [Settings].[SP_InsertUserSetting] 1
-- EXECUTE [Settings].[SP_InsertUserSetting] 1 , 1
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@