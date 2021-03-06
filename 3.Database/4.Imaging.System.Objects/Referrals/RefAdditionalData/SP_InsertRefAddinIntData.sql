USE ImagingSystem;
GO
IF OBJECT_ID ('Referrals.SP_InsertRefAddinIntData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_InsertRefAddinIntData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/09/09
-- Last Modified: 1389/09/09
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای افزودن فیلد اطلاعات اضافی از نوع عددی
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_InsertRefAddinIntData]
@ReferralIX INT
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
	'IF (EXISTS(SELECT * FROM [ImagingSystem].[Referrals].[RefAdditionalData] ' +
		'WHERE [ReferralIX] = ' + CAST(@ReferralIX  AS NVARCHAR(10)) + 
		')) UPDATE [ImagingSystem].[Referrals].[RefAdditionalData] ' +
		'SET [' + @FieldName + '] = ' +@StringValue +
		' WHERE [ReferralIX] = ' + CAST(@ReferralIX  AS NVARCHAR(10)) +
	' ELSE INSERT INTO [ImagingSystem].[Referrals].[RefAdditionalData] ' +
           '([ReferralIX] , [' + @FieldName +']) VALUES (' + 
			CAST(@ReferralIX  AS NVARCHAR(10)) + ', ' + @StringValue +')';
	EXECUTE(@Execution);
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Referrals].[SP_InsertRefAddinIntData] 170814 , 'Field22' , NULL
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@