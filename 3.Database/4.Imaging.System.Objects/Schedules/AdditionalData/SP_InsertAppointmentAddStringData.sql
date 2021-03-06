USE ImagingSystem;
GO
IF OBJECT_ID ('Schedules.SP_InsertAppointmentAddStringData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_InsertAppointmentAddStringData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1389/5/6
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_InsertAppointmentAddStringData]
@AppointmentID INT
,@FieldName NVARCHAR(10)
,@Data NVARCHAR(200) = NULL
WITH ENCRYPTION
-- روالی برای افزودن فیلد اطلاعات اضافی نوبت دهی از نوع رشته
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	DECLARE @Execution NVARCHAR(500);
	IF (@Data IS NULL) SET @Data = '';
	SET @Execution = 
	'IF (EXISTS(SELECT * FROM [ImagingSystem].[Schedules].[AdditionalData] ' +
		'WHERE AppointmentIX = ' + CAST(@AppointmentID  AS NVARCHAR(10)) + 
		')) UPDATE [ImagingSystem].[Schedules].[AdditionalData] ' +
		'SET [' + @FieldName + '] = N''' +@Data +
		''' WHERE AppointmentIX = ' + CAST(@AppointmentID  AS NVARCHAR(10)) +
	' ELSE INSERT INTO [ImagingSystem].[Schedules].[AdditionalData] ' +
           '([AppointmentIX] , [' + @FieldName +']) VALUES (' + 
			CAST(@AppointmentID  AS NVARCHAR(10)) + ', N''' + @Data +''')';
	EXECUTE(@Execution);
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Schedules].[SP_InsertAppointmentAddStringData] 1315 , 'Field2' , NULL
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- موارد استفاده:
-- Schedules => frmAppointments
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@