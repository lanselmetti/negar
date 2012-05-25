USE ImagingSystem;
GO
IF OBJECT_ID ( 'Services.SP_SelectServicesList', 'P' ) IS NOT NULL
    DROP PROCEDURE [Services].[SP_SelectServicesList];
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
GO
-- Created Date: 1388/4/8 
-- Last Modified: 1388/12/16
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Services].[SP_SelectServicesList]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT [Tbl1].[ID] , [Tbl1].[IsActive] , [Tbl1].[Code] , [Tbl1].[Name] , 
		[Tbl1].[CategoryIX] , ISNULL(Tbl2.[Name] , '(بدون طبقه بندی)') AS [CategoryName],
		[Tbl1].[PriceFree] , [Tbl1].[PriceGov] ,
		[Tbl1].[Description]
	FROM [ImagingSystem].[Services].[List] AS [Tbl1]
	LEFT OUTER JOIN [ImagingSystem].[Services].[Categories] AS [Tbl2]
		ON [Tbl1].[CategoryIX] = [Tbl2].[ID] ORDER BY [Tbl1].[Code];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [Services].[SP_SelectServicesList] 7
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@