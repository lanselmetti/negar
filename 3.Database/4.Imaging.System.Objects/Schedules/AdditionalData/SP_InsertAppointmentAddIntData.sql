USE ImagingSystem;
GO
IF OBJECT_ID ('Schedules.SP_InsertAppointmentAddIntData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_InsertAppointmentAddIntData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/5/6
-- Last Modified: 1389/5/6
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_InsertAppointmentAddIntData]
@AppointmentID INT
,@FieldName NVARCHAR(10)
,@Data INT = NULL
WITH ENCRYPTION
-- روالی برای افزودن فیلد اطلاعات اضافی نوبت دهی از نوع عددی
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	DECLARE @Execution NVARCHAR(500);
	DECLARE @StringValue NVARCHAR(15);
	IF (@Data IS NULL) SET @StringValue = 'NULL';
	ELSE SET @StringValue = 'N''' + CAST(@Data AS NVARCHAR(15)) + '''';
	SET @Execution = 
	'IF (EXISTS(SELECT * FROM [ImagingSystem].[Schedules].[AdditionalData] ' +
		'WHERE AppointmentIX = ' + CAST(@AppointmentID  AS NVARCHAR(10)) + 
		')) UPDATE [ImagingSystem].[Schedules].[AdditionalData] ' +
		'SET [' + @FieldName + '] = ' +@StringValue +
		' WHERE AppointmentIX = ' + CAST(@AppointmentID  AS NVARCHAR(10)) +
	' ELSE INSERT INTO [ImagingSystem].[Schedules].[AdditionalData] ' +
           '([AppointmentIX] , [' + @FieldName +']) VALUES (' + 
			CAST(@AppointmentID  AS NVARCHAR(10)) + ', ' + @StringValue +')';
	EXECUTE(@Execution);
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Schedules].[SP_InsertAppointmentAddIntData] 170814 , 'Field22' , NULL
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@