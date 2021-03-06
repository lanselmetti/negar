USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_ChangeLockAppointments', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_ChangeLockAppointments];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/8/17
-- Last Modified: 1389/2/2
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای تغییر وضعیت قفل بودن یك نوبت
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_ChangeLockAppointments]
@AppoinmentID INT,
@IsLock BIT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	BEGIN TRY
		-- حالت برای قفل كردن بیمار
		IF @IsLock = 1
			UPDATE [ImagingSystem].[Schedules].[Appointments]
			SET [LockDateTime] = GETDATE() 
			WHERE [ID] = @AppoinmentID;
		-- حالتی برای قفل كردن بیمار
		ELSE UPDATE [ImagingSystem].[Schedules].[Appointments]
			SET [LockDateTime] = NULL
			WHERE [ID] = @AppoinmentID;
	END TRY
	BEGIN CATCH
		PRINT 'ERROR';
	END CATCH
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Schedules].[SP_ChangeLockAppointments] 890527 , 0;
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@