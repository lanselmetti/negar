USE ImagingSystem;
GO
IF OBJECT_ID ('Schedules.SP_DeleteAdditionalColumns', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_DeleteAdditionalColumns];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1388/5/7
-- Created By: Saeed Pournejati
-- Last Modified By:  Saeed Pournejati
-- روالی برای حذف یك فیلد اطلاعاتی برنامه های نوبت دهی از سیستم
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_DeleteAdditionalColumns]
@ID SMALLINT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	BEGIN TRANSACTION;
	BEGIN TRY		
	-- @@@@@@@@@@@@@@@@@@@@@@@
		DECLARE @FieldName NVARCHAR(10);
		SET @FieldName = 'Field' + CONVERT(NVARCHAR(5) , @ID);
		DECLARE @Execution NVARCHAR(500);	
		SET @Execution = 'ALTER TABLE [ImagingSystem].[Schedules].[AdditionalData] ' +
				'DROP COLUMN ' + @FieldName;
		EXECUTE (@Execution);
		-- @@@@@@@@@@@@@@@@@@@@@@@
		DELETE FROM [ImagingSystem].[Schedules].[AdditionalColumns]			   
		WHERE ID = @ID;
		-- @@@@@@@@@@@@@@@@@@@@@@@
		COMMIT;
	END TRY
	-- @@@@@@@@@@@@@@@@@@@@@@@
	BEGIN CATCH
		PRINT 'ERROR';
		ROLLBACK TRANSACTION;
	END CATCH
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Schedules].[SP_DeleteAdditionalColumns] 5
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@