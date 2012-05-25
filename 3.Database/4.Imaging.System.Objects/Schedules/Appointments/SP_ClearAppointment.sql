USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_ClearAppointment', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_ClearAppointment];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/02/10
-- Last Modified: 1391/01/11
-- Created By: Saeed Pournejati
-- Last Modified By: Mohammad Hosein Zohrehvand
-- روالی برای پاك كردن كامل یك نوبت از برنامه های نوبت دهی
-- ChangeLog:
-- افزودن ستون DateTime جهت خالی شدن
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_ClearAppointment]
@SchID INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	UPDATE [ImagingSystem].[Schedules].[Appointments]
	SET [IsActive] = 1 ,[IsAppointed] = 0 , [PatientIX] = NULL , [ReferralIX] = NULL
		,[FirstName] = NULL ,[LastName] = NULL ,[IsMale] = NULL
		,[Age] = NULL ,[TelNo1] = NULL
		,[TelNo2] = NULL ,[DateTime] = NULL ,[SchedulerIX] = NULL
		WHERE [ID] = @SchID;
	DELETE FROM [ImagingSystem].[Schedules].[AdditionalData]
		WHERE [AppointmentIX] = @SchID;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Schedules].[SP_ClearAppointment] 83
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@