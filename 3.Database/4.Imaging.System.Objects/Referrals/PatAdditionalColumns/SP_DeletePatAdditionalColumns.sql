USE ImagingSystem;
GO
IF OBJECT_ID ('Referrals.SP_DeletePatAdditionalColumns', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_DeletePatAdditionalColumns];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1388/5/14
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای حذف یك فیدل اطلاعاتی اضافی بیمار ثبت شده از 2 جدول مربوط به آن
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_DeletePatAdditionalColumns]
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
		SET @Execution = 'ALTER TABLE [ImagingSystem].[Referrals].[PatAdditionalData] ' +
			'DROP COLUMN ' + @FieldName;
		EXECUTE (@Execution);
		-- @@@@@@@@@@@@@@@@@@@@@@@
		DELETE FROM [ImagingSystem].[Referrals].[PatAdditionalColumns]			   
		WHERE ID = @ID;
		-- @@@@@@@@@@@@@@@@@@@@@@@
		COMMIT;
	END TRY
	-- @@@@@@@@@@@@@@@@@@@@@@@
	BEGIN CATCH
		ROLLBACK TRANSACTION;
	END CATCH
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Referrals].[SP_DeletePatAdditionalColumns] 5
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@