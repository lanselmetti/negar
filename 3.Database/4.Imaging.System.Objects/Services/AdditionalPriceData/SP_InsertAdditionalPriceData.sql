USE ImagingSystem;
GO
IF OBJECT_ID ( 'Services.SP_InsertAdditionalPriceData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Services].[SP_InsertAdditionalPriceData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/2/24
-- Last Modified: 1388/5/14
-- Created By: Saeed Pournejati
-- Last Modified By:  Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
-- این روال وظیفه ثبت یا ویرایش یك مقدار برای فیلد اطلاعاتی اضافی قیمت یك خدمت را بر عهده دارد
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Services].[SP_InsertAdditionalPriceData]
@ServiceIX SMALLINT,
@FieldID SMALLINT ,
@Price INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS
	DECLARE @Execution NVARCHAR(500);
	DECLARE @FieldName NVARCHAR(25);
	SET @FieldName = 
		(SELECT TOP 1 [ColumnName] 
		FROM [ImagingSystem].[Services].[AdditionalPriceColumns] WHERE ID = @FieldID);
	-- @@@@@@@@@@@@@@@@@@@@@@@
	BEGIN TRANSACTION;
	BEGIN TRY		
		IF EXISTS (SELECT * FROM [ImagingSystem].[Services].[AdditionalPriceData] 
			WHERE ServiceIX = @ServiceIX)	
		BEGIN
			SET @Execution = 'UPDATE [ImagingSystem].[Services].[AdditionalPriceData] ' + 
			'SET ' + @FieldName + ' = ' + CONVERT(NVARCHAR(30) , @Price) + 
			' WHERE [ServiceIX] = ' + CONVERT(NVARCHAR(10) , @ServiceIX);
		END
		-- @@@@@@@@@@@@@@@@@@@@@@@
		ELSE
		BEGIN
			SET @Execution = 'INSERT INTO [ImagingSystem].[Services].[AdditionalPriceData] ' +
				'([ServiceIX] , [' + @FieldName + ']) ' +
				'VALUES (' + CONVERT(NVARCHAR(10) , @ServiceIX) + 
				' , ' + CONVERT(NVARCHAR(30) , @Price) + ')';
		END
		-- @@@@@@@@@@@@@@@@@@@@@@@
		EXECUTE (@Execution);
		COMMIT;
	END TRY
	-- @@@@@@@@@@@@@@@@@@@@@@@
	BEGIN CATCH
		ROLLBACK TRANSACTION;
	END CATCH
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Services].[SP_InsertAdditionalPriceData] 10 , 10 , 500
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@