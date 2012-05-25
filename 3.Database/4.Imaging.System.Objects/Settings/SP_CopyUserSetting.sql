USE ImagingSystem;
GO
IF OBJECT_ID ( 'Settings.SP_CopyUserSetting', 'P' ) IS NOT NULL
    DROP PROCEDURE [Settings].[SP_CopyUserSetting];
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
GO
-- Created Date: 1388/9/13
-- Last Modified: 1388/9/13
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای كپی برداری تنظیمات یك كاربر به كاربر دیگر
-- توجه: این روال تنظیمات قبلی كاربر مقصد را حذف نمی كند
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Settings].[SP_CopyUserSetting]
-- كاربر اولیه برای كپی برداری
@BaseUserID SMALLINT ,
-- كاربر مقصد برای جایگذاری
@TargetUserID SMALLINT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	INSERT INTO [ImagingSystem].[Settings].[UsersSettings]
	([SettingIX] , [UserIX] , [Boolean] , [Value])
	(SELECT [SettingIX] ,@TargetUserID AS [UserIX] , [Boolean] , [Value]
		FROM [ImagingSystem].[Settings].[UsersSettings]
		WHERE [UserIX] = @BaseUserID);
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [Settings].[SP_CopyUserSetting] 10 , 3
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@