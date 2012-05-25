USE PatientsSystem;
GO
IF OBJECT_ID ( 'Security.SP_SelectUsersInGroups', 'P' ) IS NOT NULL
    DROP PROCEDURE [Security].[SP_SelectUsersInGroups];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/23
-- Last Modified: 1388/11/30
-- Created By: Elham Samiei
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن لیست كاربران عضو در گروه های مختلف
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Security].[SP_SelectUsersInGroups]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT [Tbl1].[GroupIX] AS [GroupID] ,
	[Tbl2].ID AS [UserID] , 	
	[Tbl2].[UserName] , 
	(ISNULL(Tbl2.[FirstName] + ' ', '')  + [Tbl2].[LastName]) AS [FullName] ,
	[Tbl2].[FirstName] , [Tbl2].[LastName]	
	FROM [PatientsSystem].[Security].[UsersInGroups] AS [Tbl1]
	FULL OUTER JOIN [PatientsSystem].[Security].[Users] AS [Tbl2]
	ON [Tbl1].UserIX = [Tbl2].ID;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Security].[SP_SelectUsersInGroups]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@