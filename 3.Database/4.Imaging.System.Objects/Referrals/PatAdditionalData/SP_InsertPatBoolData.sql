USE ImagingSystem;
GO
IF OBJECT_ID ('Referrals.SP_InsertPatAddinBoolData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_InsertPatAddinBoolData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1388/6/28
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای افزودن یك فیلد بولین اضافی برای یك بیمار
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_InsertPatAddinBoolData]
@PatientListID INT
,@FieldName NVARCHAR(10)
,@Data BIT = NULL
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	DECLARE @Execution NVARCHAR(500);
	SET @Execution = 
	'IF (EXISTS(SELECT * FROM [ImagingSystem].[Referrals].[PatAdditionalData] ' +
		'WHERE [PatientIX] = ' + CAST(@PatientListID  AS NVARCHAR(10)) + 
		')) UPDATE [ImagingSystem].[Referrals].[PatAdditionalData] ' +
		'SET [' + @FieldName + '] = ' + CAST(@Data AS NVARCHAR(1)) +
		' WHERE [PatientIX] = ' + CAST(@PatientListID  AS NVARCHAR(10)) +
	' ELSE INSERT INTO [ImagingSystem].[Referrals].[PatAdditionalData] ' +
           '([PatientIX] , [' + @FieldName +']) VALUES (' + 
			CAST(@PatientListID  AS NVARCHAR(10)) + ', ' + CAST(@Data AS NVARCHAR(1)) +')';
	EXECUTE(@Execution);
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Referrals].[SP_InsertPatAddinBoolData] 109500 , 'Field6' , 1
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@