USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_DeleteAppointment', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_DeleteAppointment];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/02/10
-- Last Modified: 1389/02/10
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای پاك كردن كامل یك نوبت از برنامه های نوبت دهی
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_DeleteAppointment]
@ID INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	DELETE FROM [ImagingSystem].[Schedules].[Appointments]
		WHERE [ID] = @ID;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
--EXEC [Schedules].[SP_DeleteAppointment] 83
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@