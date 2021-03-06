USE ImagingSystem;
GO
IF OBJECT_ID ( 'Services.SP_DeleteAdditionalPriceColumns', 'P' ) IS NOT NULL
    DROP PROCEDURE [Services].[SP_DeleteAdditionalPriceColumns]
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/2/24
-- Last Modified: 1388/5/14
-- Created By: Saeed Pournejati
-- Last Modified By:  Saeed Pournejati
-- روالی برای حذف یك فیلد قیمت اضافی جدید از 2 جدول مربوط به آن
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Services].[SP_DeleteAdditionalPriceColumns]
@ID SMALLINT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
AS 
	BEGIN TRANSACTION;
	BEGIN TRY
		DECLARE @FieldName NVARCHAR(25);
		SET @FieldName = (SELECT [ColumnName] 
		FROM [ImagingSystem].[Services].[AdditionalPriceColumns]
		WHERE [ID] = @ID);
		DELETE FROM [ImagingSystem].[Services].[AdditionalPriceColumns]
		WHERE [ID] = @ID;
		-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
		DECLARE @Execution NVARCHAR(300);
		SET @Execution = 'ALTER TABLE [ImagingSystem].[Services].[AdditionalPriceData] ' +
			'DROP CONSTRAINT DF_AdditionalPriceData_' + @FieldName;
		EXEC (@Execution);
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
		SET @Execution = 'ALTER TABLE [ImagingSystem].[Services].[AdditionalPriceData] ' +
			'DROP COLUMN ' + @FieldName;	
		EXEC (@Execution);		
		COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
	END CATCH
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Services].[SP_DeleteAdditionalPriceColumns] 3
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@