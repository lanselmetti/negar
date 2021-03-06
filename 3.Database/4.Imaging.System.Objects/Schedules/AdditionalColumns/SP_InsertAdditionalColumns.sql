USE ImagingSystem;
GO
IF OBJECT_ID ('Schedules.SP_InsertAdditionalColumns', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_InsertAdditionalColumns];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1389/5/4
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای افزودن فیلد اطلاعاتی اضافی برای برنامه های نوبت دهی
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_InsertAdditionalColumns]
@NewID SMALLINT = NULL OUTPUT,
@Title NVARCHAR(50),
@TypeID TINYINT,
@Lenght TINYINT = NULL,
@Description NVARCHAR(300)
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	BEGIN TRANSACTION;
	BEGIN TRY		
	-- @@@@@@@@@@@@@@@@@@@@@@@
	INSERT INTO [ImagingSystem].[Schedules].[AdditionalColumns] 
	([Title] ,[TypeID] , [Lenght] ,[Description])
	VALUES (@Title , @TypeID, @Lenght , @Description);
	-- @@@@@@@@@@@@@@@@@@@@@@@
	DECLARE @FieldName NVARCHAR(10);
	SET @FieldName = 'Field' + CONVERT(NVARCHAR(5) , SCOPE_IDENTITY());
	UPDATE [ImagingSystem].[Schedules].[AdditionalColumns]
	SET [FieldName] = @FieldName WHERE ID = SCOPE_IDENTITY();		
	-- @@@@@@@@@@@@@@@@@@@@@@@
	DECLARE @Execution NVARCHAR(500);	
	-- @@@@@@@@@@@@@@@@@@@@@@@
	IF @TypeID = 0 -- NVARCHAR
		SET @Execution = 'ALTER TABLE [ImagingSystem].[Schedules].[AdditionalData] ' +
			'ADD ' + @FieldName + ' NVARCHAR(' + CONVERT(NVARCHAR(4) , @Lenght) + ') NULL';		
	ELSE IF @TypeID = 1 -- BIT
		SET @Execution = 'ALTER TABLE [ImagingSystem].[Schedules].[AdditionalData] ' +
			'ADD ' + @FieldName + ' BIT NULL';
	ELSE IF @TypeID = 2 -- INT
		SET @Execution = 'ALTER TABLE [ImagingSystem].[Schedules].[AdditionalData] ' +
			'ADD ' + @FieldName + ' INT NULL';
	ELSE IF @TypeID = 3 -- MultiSelection
		SET @Execution = 'ALTER TABLE [ImagingSystem].[Schedules].[AdditionalData] ' +
			'ADD ' + @FieldName + ' SMALLINT NULL';
	-- @@@@@@@@@@@@@@@@@@@@@@@
	EXECUTE (@Execution);
	SET @NewID = SCOPE_IDENTITY();
	COMMIT;
	-- @@@@@@@@@@@@@@@@@@@@@@@
	END TRY	
	BEGIN CATCH
		SET @NewID = 0;
		ROLLBACK TRANSACTION;
	END CATCH
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
--DECLARE @Return SMALLINT;
--EXEC [Schedules].[SP_InsertAdditionalColumns] @Return OUTPUT , 'Saeed' , 1 , 50 , 'Test'
--SELECT @Return
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@