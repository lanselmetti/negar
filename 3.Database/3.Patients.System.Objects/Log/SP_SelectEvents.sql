USE PatientsSystem;
GO
IF OBJECT_ID ( 'Log.SP_SelectEvents', 'P' ) IS NOT NULL
    DROP PROCEDURE [Log].[SP_SelectEvents];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/6/25
-- Last Modified: 1388/6/26
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Log].[SP_SelectEvents]
@StartDate SMALLDATETIME ,
@EndDate SMALLDATETIME
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT ROW_NUMBER() OVER (ORDER BY Tbl1.ID) AS [RowNumber], [Tbl1].[ID] , 
		[Tbl1].[ApplicationIX] , [Tbl2].[LocalizedName] AS [ApplicationName],
		[Tbl1].[CategoryIX] , [Tbl3].[LocaleTitle] AS [CategoryName] , 
		[Tbl1].[UserIX] , [Tbl4].[UserName] , 
		ISNULL([Tbl4].[FirstName] + ' ' , '') + [Tbl4].[LastName] AS [FullName] ,
		[Tbl1].[Date] , [Tbl1].[Description]
	FROM [PatientsSystem].[Log].[Events] AS [Tbl1]
	LEFT OUTER JOIN [PatientsSystem].[Clinic].[Applications] AS [Tbl2]
	ON [Tbl1].[ApplicationIX] = [Tbl2].[ID]
	LEFT OUTER JOIN [PatientsSystem].[Log].[Categories] AS [Tbl3]
	ON [Tbl1].[CategoryIX] = [Tbl3].[ID]
	LEFT OUTER JOIN [PatientsSystem].[Security].[Users] AS [Tbl4]
	ON [Tbl1].[UserIX] = [Tbl4].[ID]
	WHERE [Tbl1].[Date] >= @StartDate AND [Tbl1].[Date] <= @EndDate
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Log].[SP_SelectEvents] 
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@