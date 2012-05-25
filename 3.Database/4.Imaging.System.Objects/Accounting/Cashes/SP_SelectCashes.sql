USE ImagingSystem;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
IF OBJECT_ID ( 'Accounting.SP_SelectCashes', 'P' ) IS NOT NULL
    DROP PROCEDURE [Accounting].[SP_SelectCashes];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/4/7
-- Last Modified: 1388/7/12
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Accounting].[SP_SelectCashes]
WITH ENCRYPTION 
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT NULL AS [ID] , NULL AS [IsActive] , N'(«‰ Œ«» ‰‘œÂ)' AS 'Name'
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	UNION ALL SELECT [ID] , CAST([IsActive] AS BIT) AS [IsActive] , [Name]
	FROM [ImagingSystem].[Accounting].[Cashes] ORDER BY [Name];
 GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Accounting].[SP_SelectCashes];
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@