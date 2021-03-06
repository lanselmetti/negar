USE ImagingSystem;
GO
IF OBJECT_ID ( 'Referrals.SP_SelectDocBinary', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_SelectDocBinary];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1390/11/13
-- Last Modified: 1390/11/13
-- Created By: Sayid Pournejati
-- Last Modified By: Sayid Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_SelectDocBinary]
@DocID INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS 
	DECLARE @DocServerPath VARCHAR(80);
	SET @DocServerPath = (SELECT TOP 1 [Value] FROM [ImagingSystem].[Settings].[UsersSettings]
		WHERE [SettingIX] = 790);
	DECLARE @DocPath VARCHAR(80);
	SET @DocPath = (SELECT TOP 1 [DocPath] FROM [ImagingSystem].[Referrals].[RefDocuments]
		WHERE [ID] = @DocID);
	BEGIN TRY
		EXEC ('SELECT * FROM OPENROWSET ' +
		'(BULK ''' + @DocServerPath + @DocPath + ''', SINGLE_BLOB) AS MyFile');
	END TRY
	BEGIN CATCH
		SELECT NULL;
	END CATCH;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [ImagingSystem].[Referrals].[SP_SelectDocBinary] 60874
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@