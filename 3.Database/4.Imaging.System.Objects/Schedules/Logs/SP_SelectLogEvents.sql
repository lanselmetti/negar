USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_SelectLogEvents', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_SelectLogEvents];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1391/01/14
-- Last Modified: 1391/01/14
-- Created By: Mohammad Hosein Zohrehvand
-- Last Modified By: Mohammad Hosein Zohrehvand
-- روالی برای فراخوانی لیست رخداد های نوبت دهی
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_SelectLogEvents]
@AppointmentID INT
WITH ENCRYPTION
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT [Tbl1].[ID], [FullName] = ( ISNULL([Tbl3].[FirstName] + ' ', '') + [Tbl3].[LastName]) 
	,[Tbl1].[CategoryIX],[Tbl2].[Name],[Tbl1].[Description],[Tbl1].[Date]
	FROM [ImagingSystem].[Schedules].[LogEvents] AS [Tbl1]
	LEFT OUTER JOIN [ImagingSystem].[Schedules].[LogCategories] AS [Tbl2]
	ON [Tbl1].[CategoryIX] = [Tbl2].[ID]
	LEFT OUTER JOIN [PatientsSystem].[Security].[Users] AS [Tbl3]
	ON [Tbl1].[UserIX] = [Tbl3].[ID]
	WHERE [Tbl1].[AppointmentIX] = @AppointmentID;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Schedules].[SP_SelectLogEvents] 467852
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@