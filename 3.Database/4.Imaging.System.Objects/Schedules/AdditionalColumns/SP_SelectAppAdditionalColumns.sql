USE ImagingSystem;
GO
IF OBJECT_ID ('Schedules.SP_SelectAppAdditionalColumns', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_SelectAppAdditionalColumns];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1389/4/12
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن فیلد های اطلاعاتی یك برنامه نوبت دهی همراه با دسترسی برنامه ها به فیلد ها و ترتیب ستون ها
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_SelectAppAdditionalColumns]
@AppID SMALLINT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT [Tbl2].[ApplicationIX] , [Tbl1].*
	FROM [ImagingSystem].[Schedules].[AdditionalColumns] AS [Tbl1]
	LEFT OUTER JOIN [ImagingSystem].[Schedules].[AdditionalColumnsAppCover] AS [Tbl2]
	ON [Tbl1].[ID] = [Tbl2].[FieldIX]	
	LEFT OUTER JOIN [ImagingSystem].[Schedules].[ColumnsOrder] AS [Tbl3]
	ON [Tbl1].[ID] = [Tbl3].[ColumnIX]	
		WHERE [Tbl2].[ApplicationIX] = @AppID
	ORDER BY [Tbl3].[OrderNumber];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Schedules].[SP_SelectAppAdditionalColumns] 5
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@