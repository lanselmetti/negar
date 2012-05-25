USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_SelectAppLastDay', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_SelectAppLastDay];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/23
-- Last Modified: 1388/11/14
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای پیدا كردن آخرین روز یك برنامه نوبت دهی با توجه به ایام تعطیل
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_SelectAppLastDay]
@AppID SMALLINT ,
@ReturnValue SMALLDATETIME = NULL OUTPUT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SET @ReturnValue = (SELECT TOP (1) [Tbl1].[OccuredDateTime]
	FROM [ImagingSystem].[Schedules].[Appointments] AS [Tbl1]
	WHERE [Tbl1].[ApplicationIX] = @AppID 
	-- شرط تعیین می كند كه روز مورد نظر نباید در بین ایام تعطیل برنامه انتخاب شده باشد
	AND [OccuredDateTime] NOT IN (SELECT [HolidayDate] 
		FROM [ImagingSystem].[Schedules].[Holidays] AS [Tbl2] 
		WHERE [Tbl2].[ApplicationIX] = [Tbl1].[ApplicationIX])
		ORDER BY [Tbl1].[OccuredDateTime] DESC);
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
--DECLARE @Value SMALLDATETIME
--EXEC [Schedules].[SP_SelectAppLastDay] 83 , @Value OUTPUT
--SELECT @Value
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@