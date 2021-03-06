USE ImagingSystem;
GO
IF OBJECT_ID ('Schedules.SP_InsertColumnsOrder', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].SP_InsertColumnsOrder;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/3/22
-- Last Modified: 1388/3/30
-- Created By: M.H.Zohrehvand
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_InsertColumnsOrder]
@ColumnIX SMALLINT ,
@OrderNumber TINYINT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	IF EXISTS(SELECT * FROM [ImagingSystem].[Schedules].[ColumnsOrder] 
	WHERE [ColumnIX] = @ColumnIX)
	UPDATE [ImagingSystem].[Schedules].[ColumnsOrder]
		SET [OrderNumber] = @OrderNumber WHERE [ColumnIX] = @ColumnIX;
	-- ====================================================
	ELSE INSERT INTO [ImagingSystem].[Schedules].[ColumnsOrder]
		([ColumnIX] , [OrderNumber]) VALUES (@ColumnIX , @OrderNumber);
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Schedules].SP_InsertColumnsOrder 1 , 2
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
