USE ImagingSystem;
GO
IF OBJECT_ID ( 'Documents.SP_SelectTemplates', 'P' ) IS NOT NULL
    DROP PROCEDURE [Documents].[SP_SelectTemplates];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/01/23
-- Last Modified: 1389/09/08
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Documents].[SP_SelectTemplates]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT [ID] , [ParentIX] , [Name] , [Code] , [IsGroup] , [IsDefault] , [Description]
	FROM [ImagingSystem].[Documents].[Templates];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Documents].[SP_SelectTemplates]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@