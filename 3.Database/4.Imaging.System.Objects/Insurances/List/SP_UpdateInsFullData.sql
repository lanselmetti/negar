USE ImagingSystem;
GO
IF OBJECT_ID ('Insurances.SP_UpdateInsFullData', 'P') IS NOT NULL
    DROP PROCEDURE [Insurances].[SP_UpdateInsFullData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/2/23
-- Last Modified: 1388/8/21
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Insurances].[SP_UpdateInsFullData]
@ID SMALLINT , 
@IsActiveBase BIT,
@Name NVARCHAR(50) ,
@IsActiveImaging BIT ,
@ContractStartDate SMALLDATETIME ,
@ContractEndDate SMALLDATETIME ,
@PatientPercent TINYINT ,
@InsurerPartLimit INT ,
@IsIns1 BIT ,
@IsIns2 BIT ,
@Ins2FormulasIX SMALLINT ,
@Description NVARCHAR(300)
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	UPDATE [PatientsSystem].[Clinic].[Insurances]
	SET [IsActive] = @IsActiveBase
      ,[Name] = @Name
	WHERE ID = @ID;
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	UPDATE [ImagingSystem].[Insurances].[List]
		SET [IsActive] = @IsActiveImaging
			,[ContractStartDate] =@ContractStartDate 
			,[ContractEndDate] = @ContractEndDate 
			,[PatientPercent] = @PatientPercent 
			,[InsurerPartLimit] = @InsurerPartLimit
			,[IsIns1] = @IsIns1 
			,[IsIns2] = @IsIns2
			,[Ins2FormulasIX] = @Ins2FormulasIX
			,[Description] = @Description
	 WHERE InsuranceIX = @ID;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Insurances].[SP_UpdateInsFullData] 2 , 0 , 'تامین اجتماعی'
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@