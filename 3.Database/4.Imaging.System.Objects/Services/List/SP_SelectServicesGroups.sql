USE ImagingSystem;
GO
IF OBJECT_ID ( 'Services.SP_SelectServicesGroups', 'P' ) IS NOT NULL
    DROP PROCEDURE [Services].[SP_SelectServicesGroups];
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
GO
-- Created Date: 1388/9/18 
-- Last Modified: 1388/12/16
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن گروه هایی كه یك خدمت عضو آن هستند
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Services].[SP_SelectServicesGroups]
@ServiceID SMALLINT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT [Tbl3].[ID], [Tbl3].[IsActive], 
	[Tbl3].[Code] , [Tbl3].[Name] AS [ServiceName] , 
	[Tbl1].[IsActive] AS [GroupIsActive] , [Tbl1].[Name] AS [GroupName]
	FROM [ImagingSystem].[Services].[Groups] AS [Tbl1]
	INNER JOIN [ImagingSystem].[Services].[ServiceInGroups] AS [Tbl2]
	ON [Tbl1].[ID] = [Tbl2].[GroupIX]
	INNER JOIN [ImagingSystem].[Services].[List] AS [Tbl3]
	ON [Tbl2].[ServiceIX] = [Tbl3].[ID]
	WHERE [Tbl3].[ID] = @ServiceID;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [Services].[SP_SelectServicesGroups] 1
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@