USE ImagingSystem;
GO
IF OBJECT_ID ('Referrals.SP_InsertRefAddinStringData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_InsertRefAddinStringData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1388/6/28
-- Created By: Saeed Pournejati
-- Last Modified By:  Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_InsertRefAddinStringData]
@ReferralIX INT
,@FieldName NVARCHAR(10)
,@Data NVARCHAR(200) = NULL
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	DECLARE @Execution NVARCHAR(500);
	IF (@Data IS NULL) SET @Data = '';
	SET @Execution = 
	'IF (EXISTS(SELECT * FROM [ImagingSystem].[Referrals].[RefAdditionalData] ' +
		'WHERE [ReferralIX] = ' + CAST(@ReferralIX  AS NVARCHAR(10)) + 
		')) UPDATE [ImagingSystem].[Referrals].[RefAdditionalData] ' +
		'SET [' + @FieldName + '] = N''' + @Data +
		''' WHERE [ReferralIX] = ' + CAST(@ReferralIX  AS NVARCHAR(10)) +
	' ELSE INSERT INTO [ImagingSystem].[Referrals].[RefAdditionalData] ' +
           '([ReferralIX] , [' + @FieldName +']) VALUES (' + 
			CAST(@ReferralIX  AS NVARCHAR(10)) + ', N''' + @Data +''')';
	EXECUTE(@Execution);
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Referrals].[SP_InsertRefAddinStringData] 53 , 'Field11' , 'asdasd'
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@