USE ImagingSystem;
GO
IF OBJECT_ID ('Referrals.SP_InsertPatIntData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_InsertPatIntData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/09/09
-- Last Modified: 1389/09/09
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای افزودن فیلد اطلاعات اضافی از نوع عددی
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_InsertPatIntData]
@PatientListID INT
,@FieldName NVARCHAR(10)
,@Data INT = NULL
WITH ENCRYPTION 
AS	
-- @@@@@@@@@@@@@@@@@@@@@@@
	DECLARE @Execution NVARCHAR(500);
	DECLARE @StringValue NVARCHAR(15);
	IF (@Data IS NULL) SET @StringValue = 'NULL';
	ELSE SET @StringValue = 'N''' + CAST(@Data AS NVARCHAR(15)) + '''';
	SET @Execution = 
	'IF (EXISTS(SELECT * FROM [ImagingSystem].[Referrals].[PatAdditionalData] ' +
		'WHERE [PatientIX] = ' + CAST(@PatientListID  AS NVARCHAR(10)) + 
		')) UPDATE [ImagingSystem].[Referrals].[PatAdditionalData] ' +
		'SET [' + @FieldName + '] = ' +@StringValue +
		' WHERE [PatientIX] = ' + CAST(@PatientListID  AS NVARCHAR(10)) +
	' ELSE INSERT INTO [ImagingSystem].[Referrals].[PatAdditionalData] ' +
           '([PatientIX] , [' + @FieldName +']) VALUES (' + 
			CAST(@PatientListID  AS NVARCHAR(10)) + ', ' + @StringValue +')';
	EXECUTE(@Execution);
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Referrals].[SP_InsertPatIntData] 170814 , 'Field22' , NULL
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@