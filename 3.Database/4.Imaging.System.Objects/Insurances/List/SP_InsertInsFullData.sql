USE ImagingSystem;
GO
IF OBJECT_ID ( 'Insurances.SP_InsertInsFullData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Insurances].[SP_InsertInsFullData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/2/23
-- Last Modified: 1388/4/1
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Insurances].[SP_InsertInsFullData]
@IsActiveBase BIT,
@Name NVARCHAR(50) ,
@IsActiveImaging BIT ,
@ContractStartDate SMALLDATETIME ,
@ContractEndDate SMALLDATETIME ,
@PatientPercent TINYINT ,
@InsurerPartLimit INT ,
@IsIns1 BIT ,
@IsIns2 BIT ,
@Ins2FormulasIX SMALLINT = NULL,
@Description NVARCHAR(300) = NULL
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	BEGIN TRANSACTION;
	BEGIN TRY
		DECLARE @ID SMALLINT;
		-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		INSERT INTO [PatientsSystem].[Clinic].[Insurances]
			([IsActive] ,[Name]) VALUES (@IsActiveBase ,@Name);
		-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		SET @ID = SCOPE_IDENTITY()
		-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		INSERT INTO [ImagingSystem].[Insurances].[List]
			([InsuranceIX],[IsActive],[ContractStartDate]
			,[ContractEndDate],[PatientPercent],[InsurerPartLimit]
			,[IsIns1] , [IsIns2] ,[Ins2FormulasIX],[Description])
		 VALUES
			(@ID,@IsActiveImaging , @ContractStartDate
			,@ContractEndDate , @PatientPercent
			,@InsurerPartLimit , @IsIns1
			,@IsIns2 , @Ins2FormulasIX , @Description);
		COMMIT TRANSACTION;
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
	END CATCH
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Insurances].SP_InsertInsFullData 1, 'ljfg;fg',1,1387,1389,10,1000,0,1,1,1,1,1,1,1,1,1,null
-- EXEC [Insurances].SP_InsertInsurances 0, b
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@