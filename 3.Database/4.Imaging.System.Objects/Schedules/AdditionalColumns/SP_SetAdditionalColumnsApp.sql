USE ImagingSystem;
GO
IF OBJECT_ID ('Schedules.SP_SetAdditionalColumnsApp', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_SetAdditionalColumnsApp];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1388/6/26
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای تعیین پوشش یك فیدل اطلاعاتی اضافی نوبت دهی به یك برنامه نوبت دهی
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_SetAdditionalColumnsApp]
@ColumnID SMALLINT ,
@AppID SMALLINT,
@IsCovered BIT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	IF @IsCovered = 1 AND (NOT EXISTS (SELECT *	
		FROM [ImagingSystem].[Schedules].[AdditionalColumnsAppCover]
		WHERE  [ApplicationIX] = @AppID  AND  [FieldIX]=@ColumnID))	
		INSERT INTO [ImagingSystem].[Schedules].[AdditionalColumnsAppCover]
		([ApplicationIX],[FieldIX]) VALUES (@AppID,@ColumnID);
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	ELSE IF @IsCovered = 0 AND (EXISTS (SELECT *	
		FROM [ImagingSystem].[Schedules].[AdditionalColumnsAppCover]
		WHERE [ApplicationIX] = @AppID AND [FieldIX]=@ColumnID))
		DELETE FROM [ImagingSystem].[Schedules].[AdditionalColumnsAppCover]
		WHERE [ApplicationIX] = @AppID AND [FieldIX]=@ColumnID;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Schedules].[SP_SetAdditionalColumnsApp] 6 ,48  , 0
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@