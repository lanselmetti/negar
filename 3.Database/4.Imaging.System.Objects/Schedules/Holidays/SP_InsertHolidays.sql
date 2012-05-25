USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_InsertHolidays', 'P' ) IS NOT NULL
	DROP PROCEDURE Schedules.SP_InsertHolidays;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/6
-- Last Modified: 1388/5/6
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_InsertHolidays]
@AppID SMALLINT
,@Date SMALLDATETIME
WITH ENCRYPTION
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	IF NOT EXISTS (SELECT * FROM [ImagingSystem].[Schedules].[Holidays]
		WHERE [ApplicationIX] = @AppID 
		AND YEAR([HolidayDate]) + MONTH([HolidayDate]) + DAY([HolidayDate]) = 
			YEAR(@Date) + MONTH(@Date) + DAY(@Date))
		INSERT INTO [ImagingSystem].[Schedules].[Holidays] 
			([ApplicationIX], 	[HolidayDate]) 
		VALUES (@AppID, @Date)
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE  Schedules.SP_InsertHolidays
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@