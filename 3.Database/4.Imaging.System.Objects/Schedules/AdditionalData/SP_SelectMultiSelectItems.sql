USE ImagingSystem;
GO
IF OBJECT_ID ('Schedules.SP_SelectMultiSelectItems', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_SelectMultiSelectItems];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/5/6
-- Last Modified: 1389/5/6
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای نمایش فیلد های چند گزینه ای قابل استفاده در یك ستون چند گزینه ای
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_SelectMultiSelectItems]
@ColumnID SMALLINT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT NULL AS [ID] , '   ' AS [Title]
	UNION SELECT [Tbl1].[ID] , [Tbl1].[Title]
	FROM [ImagingSystem].[Schedules].[AdditionalDataItems] AS [Tbl1]
	INNER JOIN [ImagingSystem].[Schedules].[AdditionalDataItemsColCover] AS [Tbl2]
	ON [Tbl1].[ID] = [Tbl2].[ItemIX]
	WHERE [Tbl2].[ColumnIX] = @ColumnID
	ORDER BY 2;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Schedules].[SP_SelectMultiSelectItems] 22
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@