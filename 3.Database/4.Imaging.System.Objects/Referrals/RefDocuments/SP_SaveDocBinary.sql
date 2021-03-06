USE ImagingSystem;
GO
IF OBJECT_ID ( 'Referrals.SP_SaveDocBinary', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_SaveDocBinary];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1390/11/13
-- Last Modified: 1390/11/13
-- Created By: Sayid Pournejati
-- Last Modified By: Sayid Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_SaveDocBinary]
@DocID INT,
@Binary VARBINARY(MAX)
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS 
	DECLARE @ServerAddress VARCHAR(80);
	SET @ServerAddress = (SELECT TOP 1 [Value] FROM [ImagingSystem].[Settings].[UsersSettings]
		WHERE [SettingIX] = 791);
	DECLARE @DocServerPath VARCHAR(80);
	SET @DocServerPath = (SELECT TOP 1 [Value] FROM [ImagingSystem].[Settings].[UsersSettings]
		WHERE [SettingIX] = 790);
	DECLARE @DocPath VARCHAR(80);
	SET @DocPath = (SELECT TOP 1 [DocPath] FROM [ImagingSystem].[Referrals].[RefDocuments]
		WHERE [ID] = @DocID);
	INSERT INTO [ImagingSystem].[Documents].[TempData] ([Data]) VALUES (@Binary);	
	DECLARE @NewID VARCHAR(10);
	SET @NewID = CONVERT(VARCHAR(10), SCOPE_IDENTITY());
	BEGIN TRY
		DECLARE @NewFolder NVARCHAR(8);
		SET @NewFolder = CONVERT(VARCHAR(20), ((@DocID / 1000) + 1));
		EXEC('EXEC XP_CMDSHELL ''mkDir ' + @DocServerPath + @NewFolder + '''');
		EXEC(
		'EXEC XP_CMDSHELL ''BCP "SELECT TOP 1 [Data] FROM [ImagingSystem].[Documents].[TempData] ' + 
			'WHERE [ID] = ' +  @NewID + '" QUERYOUT ' + 
			@DocServerPath + @DocPath + ' -S ' + @ServerAddress + ' -T -n''');
	END TRY
	BEGIN CATCH
		SELECT 'Error';
	END CATCH;
	DELETE FROM [ImagingSystem].[Documents].[TempData] WHERE [ID] = @NewID;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Referrals].[SP_SaveDocBinary] 60901, EXEC [Referrals].[SP_SelectDocBinary] 60874
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@