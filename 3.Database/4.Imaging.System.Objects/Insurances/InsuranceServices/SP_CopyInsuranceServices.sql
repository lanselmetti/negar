USE ImagingSystem;
GO
IF OBJECT_ID ( 'Insurances.SP_CopyInsuranceServices', 'P' ) IS NOT NULL
    DROP PROCEDURE [Insurances].[SP_CopyInsuranceServices];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/19
-- Last Modified: 1388/3/26
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای كپی برداری تنظیمات یك بیمه بر روی بیمه دیگر
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Insurances].[SP_CopyInsuranceServices]
@InsID1 SMALLINT, 
@InsID2 SMALLINT
WITH ENCRYPTION 
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	DELETE FROM [ImagingSystem].[Insurances].[InsuranceServices]
		WHERE [InsIX] = @InsID2;
	--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	INSERT INTO [ImagingSystem].[Insurances].[InsuranceServices]
		([InsIX] ,[ServiceIX] ,[IsCover] ,[InsPrice] ,[InsPart] ,[PatientPayable])
	(SELECT @InsID2 ,[ServiceIX] ,[IsCover] ,[InsPrice] ,[InsPart] ,[PatientPayable] 
		FROM [ImagingSystem].[Insurances].[InsuranceServices]
		WHERE [InsIX] = @InsID1);
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC ImagingSystem.Insurances.[SP_CopyInsuranceServices] 1 , 8
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@