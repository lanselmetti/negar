USE ImagingSystem;
GO
IF OBJECT_ID ('Referrals.SP_InsertRefAddinBoolData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_InsertRefAddinBoolData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1388/6/28
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_InsertRefAddinBoolData]
@ReferralIX INT
,@FieldName NVARCHAR(10)
,@Data BIT = NULL
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	DECLARE @Execution NVARCHAR(500)
	SET @Execution = 
	'IF (EXISTS(SELECT * FROM [ImagingSystem].[Referrals].[RefAdditionalData] ' +
		'WHERE [ReferralIX] = ' + CAST(@ReferralIX  AS NVARCHAR(10)) + 
		')) UPDATE [ImagingSystem].[Referrals].[RefAdditionalData] ' +
		'SET [' + @FieldName + '] = ' + CAST(@Data AS NVARCHAR(1)) +
		' WHERE [ReferralIX] = ' + CAST(@ReferralIX  AS NVARCHAR(10)) +
	' ELSE INSERT INTO [ImagingSystem].[Referrals].[RefAdditionalData] ' +
           '([ReferralIX] , [' + @FieldName +']) VALUES (' + 
			CAST(@ReferralIX  AS NVARCHAR(10)) + ', ' + CAST(@Data AS NVARCHAR(1)) +')'
	EXECUTE(@Execution)
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Referrals].[SP_InsertRefAddinBoolData] 109500 , 'Field6' , 1
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- موارد استفاده:
-- Schedules => frmAppointments
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@