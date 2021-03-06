USE ImagingSystem;
GO
IF OBJECT_ID ('Referrals.SP_InsertPatAddinStringData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_InsertPatAddinStringData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1388/6/28
-- Created By: Saeed Pournejati
-- Last Modified By:  Saeed Pournejati
-- روالی برای افزودن یك فیلد رشته اضافی برای یك بیمار
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_InsertPatAddinStringData]
@PatientListID INT
,@FieldName NVARCHAR(10)
,@Data NVARCHAR(200) = NULL
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	DECLARE @Execution NVARCHAR(500);
	IF (@Data IS NULL) SET @Data = '';
	SET @Execution = 
	'IF (EXISTS(SELECT * FROM [ImagingSystem].[Referrals].[PatAdditionalData] ' +
		'WHERE [PatientIX] = ' + CAST(@PatientListID  AS NVARCHAR(10)) + 
		')) UPDATE [ImagingSystem].[Referrals].[PatAdditionalData] ' +
		'SET [' + @FieldName + '] = N''' + @Data +
		''' WHERE [PatientIX] = ' + CAST(@PatientListID  AS NVARCHAR(10)) +
	' ELSE INSERT INTO [ImagingSystem].[Referrals].[PatAdditionalData] ' +
           '([PatientIX] , [' + @FieldName +']) VALUES (' + 
			CAST(@PatientListID  AS NVARCHAR(10)) + ', N''' + @Data +''')';
	EXECUTE(@Execution);
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Referrals].[SP_InsertPatAddinStringData] 53 , 'Field11' , 'asdasd'
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@