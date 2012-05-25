USE ImagingSystem;
GO
IF OBJECT_ID ( 'Services.SP_SelectServicesInGroups', 'P' ) IS NOT NULL
    DROP PROCEDURE [Services].[SP_SelectServicesInGroups];
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
GO
-- Created Date: 1388/1/16 
-- Last Modified: 1389/1/19
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن لیست خدمات عضو در گروه های مختلف
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Services].[SP_SelectServicesInGroups]
WITH ENCRYPTION	  
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT [Tbl1].[ID], [Tbl2].[GroupIX] AS [GroupID], [Tbl1].[Code], [Tbl1].[Name]
	FROM [ImagingSystem].[Services].[List] AS [Tbl1]
	LEFT OUTER JOIN [ImagingSystem].[Services].[ServiceInGroups] AS [Tbl2]
	ON [Tbl1].[ID] = [Tbl2].[ServiceIX] ORDER BY [Tbl2].[GroupIX] , [Tbl1].[Code];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [Services].[SP_SelectServicesInGroups]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@