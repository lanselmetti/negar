USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_SelectAppPrevDay', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_SelectAppPrevDay];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/23
-- Last Modified: 1388/12/13
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_SelectAppPrevDay]
@AppID SMALLINT , 
@Date DATETIME , 
@ReturnValue DATETIME = NULL OUTPUT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- این روال روز قبلی یك برنامه نوبت دهی را بر اساس روز و كلید برنامه ارسال شده پیدا می كند
-- این روال ایام تعطیل را در محاسبات در نظر نمی گیرد
-- اگر روز قبلی وجود نداشته باشد تهی بازگردانده می شود
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SET @ReturnValue = (SELECT TOP (1) [Tbl1].[OccuredDateTime]
	FROM [ImagingSystem].[Schedules].[Appointments] AS [Tbl1]
	WHERE [Tbl1].[ApplicationIX] = @AppID 
	AND [Tbl1].[OccuredDateTime] < @Date
	AND CONVERT(NVARCHAR(4) , YEAR([Tbl1].[OccuredDateTime])) + '/' + 
		CONVERT(NVARCHAR(2) , MONTH([Tbl1].[OccuredDateTime])) + '/' + 
		CONVERT(NVARCHAR(2) , DAY([Tbl1].[OccuredDateTime])) NOT IN 
		(SELECT CONVERT(NVARCHAR(4) , YEAR([HolidayDate])) + '/' + 
			CONVERT(NVARCHAR(2) , MONTH([HolidayDate])) + '/' + 
			CONVERT(NVARCHAR(2) , DAY([HolidayDate]))
		 FROM [ImagingSystem].[Schedules].[Holidays]
		WHERE [ApplicationIX] = @AppID AND [HolidayDate] < @Date)
	ORDER BY [Tbl1].[OccuredDateTime] DESC);
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
--DECLARE @Date SMALLDATETIME
--EXEC [Schedules].SP_SelectAppPrevDay 3 , '2010/03/07 08:00:00' , @Date OUTPUT
--SELECT @Date
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@