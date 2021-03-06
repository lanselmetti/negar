USE ImagingSystem;
GO
IF OBJECT_ID ( 'Services.SP_InsertAdditionalPriceColumns', 'P' ) IS NOT NULL
    DROP PROCEDURE [Services].[SP_InsertAdditionalPriceColumns];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/2/24
-- Last Modified: 1388/5/14
-- Created By: Saeed Pournejati
-- Last Modified By:  Saeed Pournejati
-- روالی برای افزودن یك فیلد قیمت اضافی جدید به 2 جدول مربوط به آن
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Services].[SP_InsertAdditionalPriceColumns]
@Name NVARCHAR(25) ,
@Description NVARCHAR(300)
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS
	BEGIN TRANSACTION;
	BEGIN TRY
		-- @@@@@@@@@@@@@@@@@@@@@@@@
		INSERT INTO [ImagingSystem].[Services].[AdditionalPriceColumns]
			([Name] ,[Description])
		VALUES (@Name ,@Description);
		-- @@@@@@@@@@@@@@@@@@@@@@@@
		DECLARE @ID NVARCHAR(2); 
		SET @ID = CONVERT(NVARCHAR(2) , SCOPE_IDENTITY());
		UPDATE [ImagingSystem].[Services].[AdditionalPriceColumns]
		SET [ColumnName] = 'Field' + @ID
		WHERE ID = SCOPE_IDENTITY();
		-- @@@@@@@@@@@@@@@@@@@@@@@@
		DECLARE @Execution NVARCHAR(300);
		SET @Execution = 'ALTER TABLE [ImagingSystem].[Services].[AdditionalPriceData] ' +
			'ADD Field' + @ID + ' INT NULL ' + 
				'CONSTRAINT DF_AdditionalPriceData_Field' + @ID + ' DEFAULT 0;';
		EXEC (@Execution);
		COMMIT TRANSACTION ;
	END TRY
	-- @@@@@@@@@@@@@@@@@@@@@@@@
	BEGIN CATCH
		ROLLBACK TRANSACTION;
	END CATCH
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Services].[SP_InsertAdditionalPriceColumns] 'تعرفه كنگره رادیولوژی', 'تعرفه كنگره'
-- TRUNCATE TABLE [Services].[SP_InsertAdditionalPriceColumns]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@