USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_InsertOneDayAppointments', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_InsertOneDayAppointments];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/22 
-- Last Modified: 1388/12/02
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای ثبت نوبت های یك برنامه نوبت دهی برای یك روز مشخص با تعداد و زمان معین
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_InsertOneDayAppointments]
-- كلید برنامه
@AppID SMALLINT,
-- +++++++++++++++++++++
-- ساعت آغاز و پایان نوبت های روز
@StartTime SMALLDATETIME ,
@EndTime SMALLDATETIME ,
-- +++++++++++++++++++++
-- ظرفیت نوبت
@Capacity SMALLINT , 
-- زمان گرد
@RoundMin SMALLINT
-- +++++++++++++++++++++
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	DECLARE @TimePeriod SMALLINT;
	SET @TimePeriod = DATEDIFF(MINUTE , @StartTime, @EndTime) / @Capacity;
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	DECLARE @RowNo SMALLINT;
	SET @RowNo = 1;
	-- ++++++++++++++++++++++++++++++++++++++
	DECLARE @AddingMin SMALLINT
	SET @AddingMin = 0;
	-- ++++++++++++++++++++++++++++++++++++++
	DECLARE @InsertDateTime SMALLDATETIME;
	SET @InsertDateTime = @StartTime;
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	-- تعریف نوبت های دارای روندینگ
	IF @RoundMin != 0
		WHILE @RowNo != @Capacity + 1
		BEGIN
			-- ++++++++++++++++++++++++++++++++++++++		
			SET @AddingMin = (@TimePeriod * (@RowNo - 1))
			-- ++++++++++++++++++++++++++++++++++++++		
			IF @AddingMin % @RoundMin = 0
				SET @InsertDateTime = DATEADD(MINUTE , @AddingMin, @StartTime)
			ELSE
				SET @InsertDateTime = 
					DATEADD(MINUTE , @AddingMin + @RoundMin - 
						(@AddingMin % @RoundMin), @StartTime)		
			-- ++++++++++++++++++++++++++++++++++++++
			INSERT INTO [ImagingSystem].[Schedules].[Appointments]
				   ([ApplicationIX] ,[OrderNo] ,[OccuredDateTime]
				   ,[IsActive] ,[IsAppointed])
			VALUES (@AppID , @RowNo, @InsertDateTime , 1 , 0)
			-- ++++++++++++++++++++++++++++++++++++++
			SET @RowNo = @RowNo + 1
		END
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	-- تعریف نوبت های فاقد روندینگ
	ELSE
		WHILE @RowNo != @Capacity + 1
		BEGIN						
			-- ++++++++++++++++++++++++++++++++++++++			
			SET @InsertDateTime = DATEADD(MINUTE , (@TimePeriod * (@RowNo - 1)), @StartTime);
			-- ++++++++++++++++++++++++++++++++++++++
			INSERT INTO [ImagingSystem].[Schedules].[Appointments]
				([ApplicationIX] , [OrderNo] , [OccuredDateTime]
				,[IsActive] ,[IsAppointed])
			VALUES (@AppID , @RowNo, @InsertDateTime , 1 , 0)
			-- ++++++++++++++++++++++++++++++++++++++
			SET @RowNo = @RowNo + 1;
		END
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Schedules].[SP_InsertOneDayAppointments] 4 , '2009/01/01 8:00:00' , '2009/01/01 10:00:00' , 10 , 0 , 0;
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@