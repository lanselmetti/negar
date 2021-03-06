USE ImagingSystem;
GO
IF OBJECT_ID ('Referrals.SP_InsertRefAdditionalColumns', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_InsertRefAdditionalColumns];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/05/07
-- Last Modified: 1389/09/09
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای افزودن یك فیلد اطلاعاتی اضافی مراجعات به 2 جدول مربوط به آن
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_InsertRefAdditionalColumns]
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
		INSERT INTO [ImagingSystem].[Referrals].[RefAdditionalColumns]
			([Title] ,[TypeID] , [Lenght] ,[Description]) 
		VALUES (@Title , @TypeID, @Lenght , @Description);
		DECLARE @FieldName NVARCHAR(10);
		SET @FieldName = 'Field' + CONVERT(NVARCHAR(5) , SCOPE_IDENTITY());
		UPDATE [ImagingSystem].[Referrals].[RefAdditionalColumns]
		SET [FieldName] = @FieldName WHERE ID = SCOPE_IDENTITY();
		-- @@@@@@@@@@@@@@@@@@@@@@@
		DECLARE @Execution NVARCHAR(500);	
		-- @@@@@@@@@@@@@@@@@@@@@@@
		IF @TypeID = 0 
			SET @Execution = 'ALTER TABLE [ImagingSystem].[Referrals].[RefAdditionalData] ' +
			'ADD ' + @FieldName + ' NVARCHAR(' + CONVERT(NVARCHAR(4) , @Lenght) + ') NULL';		
		ELSE IF @TypeID = 1 
			SET @Execution = 'ALTER TABLE [ImagingSystem].[Referrals].[RefAdditionalData] ADD ' + 
			@FieldName + ' BIT NULL';
		ELSE IF @TypeID = 2
			SET @Execution = 'ALTER TABLE [ImagingSystem].[Referrals].[RefAdditionalData] ADD ' + 
			@FieldName + ' INT NULL';
		ELSE IF @TypeID = 3
			SET @Execution = 'ALTER TABLE [ImagingSystem].[Referrals].[RefAdditionalData] ADD ' + 
			@FieldName + ' SMALLINT NULL';
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
-- EXEC [Referrals].[SP_InsertRefAdditionalColumns] 'Saeed' , 1 , 'Test'
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@