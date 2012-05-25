USE ImagingSystem;
GO
IF  EXISTS (SELECT * FROM [sys].[triggers] 
	WHERE OBJECT_ID = OBJECT_ID(N'Referrals.TR_AfterRefDocRemoved'))
	DROP TRIGGER [Referrals].[TR_AfterRefDocRemoved];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1390/11/22
-- Last Modified: 1390/11/22
-- Created By: Sayid Pournejati
-- Last Modified By: Sayid Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE TRIGGER [TR_AfterRefDocRemoved]
ON [ImagingSystem].[Referrals].[RefDocuments]
WITH ENCRYPTION
AFTER DELETE 
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	BEGIN TRY
		DECLARE @DocServerPath VARCHAR(80);
		SET @DocServerPath = (SELECT TOP 1 [Value] FROM [ImagingSystem].[Settings].[UsersSettings]
			WHERE [SettingIX] = 790);
		DECLARE @ChangedDocID INT;
		IF (SELECT TOP 1 [ID] FROM DELETED) IS NOT NULL
			SET @ChangedDocID = (SELECT TOP 1 [ID] FROM DELETED);
		DECLARE @DocPath VARCHAR(80);
			SET @DocPath = (SELECT TOP 1 [DocPath] FROM DELETED);
		EXEC('EXEC XP_CMDSHELL ''del ' + @DocServerPath + @DocPath + '''');
	END TRY
	BEGIN CATCH
		PRINT 'ERROR';
	END CATCH;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@