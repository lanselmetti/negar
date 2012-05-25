USE ImagingSystem;
GO
IF OBJECT_ID ( 'Services.SP_SelectGroups', 'P' ) IS NOT NULL
    DROP PROCEDURE [Services].[SP_SelectGroups];
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
GO
-- Created Date: 1388/8/11 
-- Last Modified: 1388/8/11
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Services].[SP_SelectGroups]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS  [ID] , NULL AS [IsActive] , '(انتخاب نشده)' AS [Name]
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	UNION ALL SELECT [ID] , [IsActive] , [Name]
	FROM [ImagingSystem].[Services].[Groups] WHERE [IsActive] = 1 ORDER BY 3;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [Services].[SP_SelectGroups] 7
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@