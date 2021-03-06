USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_ChangeIsActiveAppointments', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_ChangeIsActiveAppointments];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/2/27
-- Last Modified: 1389/2/27
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای تغییر وضعیت فعال بودن یك نوبت
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_ChangeIsActiveAppointments]
@AppoinmentID INT,
@IsActive BIT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	BEGIN TRY
		UPDATE [ImagingSystem].[Schedules].[Appointments]
		SET [IsActive] = @IsActive
		WHERE [ID] = @AppoinmentID;
	END TRY
	BEGIN CATCH
		PRINT 'ERROR';
	END CATCH
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Schedules].[SP_ChangeIsActiveAppointments] 890527 , 0;
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@