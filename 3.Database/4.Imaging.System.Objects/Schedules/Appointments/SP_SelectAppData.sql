USE ImagingSystem;
GO
IF OBJECT_ID ('Schedules.SP_SelectAppData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_SelectAppData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1389/5/9
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن فیلد های ثابت و اطلاعات اضافی یك برنامه نوبت دهی برای یك روز خاص
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_SelectAppData]
@AppID SMALLINT
,@Date1 DATETIME
,@Date2 DATETIME
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT [Tbl1].[ID] , [Tbl1].[ApplicationIX]
	, [Tbl1].[OrderNo] ,[Tbl1].[OccuredDateTime] 
	, [Tbl1].[IsActive] ,[Tbl1].[IsAppointed] ,[Tbl1].[FirstName] ,[Tbl1].[LastName]
	, [Tbl1].[PatientIX] , [Tbl1].[ReferralIX]
	, [Tbl1].[IsMale] ,[Tbl1].[Age] ,[Tbl1].[TelNo1] ,[Tbl1].[TelNo2] ,[Tbl1].[SchedulerIX]	
	, [Tbl2].* FROM [ImagingSystem].[Schedules].[Appointments] AS [Tbl1]
	FULL OUTER JOIN [ImagingSystem].[Schedules].[AdditionalData] AS [Tbl2]
	ON [Tbl1].[ID] = [Tbl2].[AppointmentIX]
	WHERE [Tbl1].[ApplicationIX] = @AppID 
	AND [Tbl1].[OccuredDateTime] >= @Date1 AND [Tbl1].[OccuredDateTime] <= @Date2
	ORDER BY [Tbl1].[OrderNo] , [Tbl1].[ID];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Schedules].[SP_SelectAppData] 5 , N'2009/09/21 08:48:00'  , N'2010/09/21 09:48:00'
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@