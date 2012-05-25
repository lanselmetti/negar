USE ImagingSystem;
GO
IF OBJECT_ID ('Referrals.SP_SelectRefMultiSelectItems', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_SelectRefMultiSelectItems];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/09/09
-- Last Modified: 1389/09/09
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای نمایش فیلد های چند گزینه ای قابل استفاده در یك فیلد چند گزینه ای
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_SelectRefMultiSelectItems]
@ColumnID SMALLINT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT NULL AS [ID] , '   ' AS [Title]
	UNION SELECT [Tbl1].[ID] , [Tbl1].[Title]
	FROM [ImagingSystem].[Referrals].[RefAdditionalDataItems] AS [Tbl1]
	INNER JOIN [ImagingSystem].[Referrals].[RefAdditionalDataItemsColCover] AS [Tbl2]
	ON [Tbl1].[ID] = [Tbl2].[ItemIX]
	WHERE [Tbl2].[ColumnIX] = @ColumnID
	ORDER BY 2;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Referrals].[SP_SelectRefMultiSelectItems] 22
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@