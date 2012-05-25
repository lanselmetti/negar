USE ImagingSystem;
GO
IF OBJECT_ID ('Schedules.SP_InsertAppointmentAddBoolData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_InsertAppointmentAddBoolData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1389/1/10
-- Created By: Saeed Pournejati
-- Last Modified By:  Saeed Pournejati
-- روالی برای افزودن فیلد اطلاعات اضافی نوبت دهی از نوع بولین
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_InsertAppointmentAddBoolData]
@AppointmentID INT
,@FieldName NVARCHAR(10)
,@Data BIT = NULL
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	DECLARE @Execution NVARCHAR(500);
	IF (@Data IS NULL) SET @Data = 0;
	SET @Execution = 'IF (EXISTS(SELECT * FROM [ImagingSystem].[Schedules].[AdditionalData] ' +
		'WHERE AppointmentIX = ' + CAST(@AppointmentID  AS NVARCHAR(10)) + 
		')) UPDATE [ImagingSystem].[Schedules].[AdditionalData] ' +
		'SET [' + @FieldName + '] = ' + CAST(@Data AS NVARCHAR(1)) +
		' WHERE AppointmentIX = ' + CAST(@AppointmentID  AS NVARCHAR(10)) +
	' ELSE INSERT INTO [ImagingSystem].[Schedules].[AdditionalData] ' +
           '([AppointmentIX] , [' + @FieldName +']) VALUES (' + 
			CAST(@AppointmentID  AS NVARCHAR(10)) + ', ' + CAST(@Data AS NVARCHAR(1)) +')';
	EXECUTE(@Execution);
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Schedules].[SP_InsertAppointmentAddBoolData] 1315 , 'Field1' , NULL
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@