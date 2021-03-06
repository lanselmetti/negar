USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_CheckLockAppointments', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_CheckLockAppointments];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/8/17
-- Last Modified: 1389/2/14
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای بررسی وضعیت قفل بودن یك نوبت
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_CheckLockAppointments]
@AppoinmentID INT,
@IsLock BIT = NULL OUTPUT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	-- اگر آخرین زمان ویرایش از 10 دقیقه پیش بیشتر باشد قطعاً ردیف آزاد است
	DECLARE @LastDate	DATETIME;
	SET @LastDate = (SELECT TOP 1 [LockDateTime]
		FROM [ImagingSystem].[Schedules].[Appointments]
		WHERE ID = @AppoinmentID);
	IF @LastDate IS NULL OR DATEDIFF(MINUTE , @LastDate , GETDATE()) > 10
		SET @IsLock = 0;
	ELSE SET @IsLock = 1;
	RETURN @IsLock;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
--DECLARE @Value BIT;
--EXEC [Schedules].[SP_CheckLockAppointments] 21629 , @Value OUTPUT;
--SELECT @Value;
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@