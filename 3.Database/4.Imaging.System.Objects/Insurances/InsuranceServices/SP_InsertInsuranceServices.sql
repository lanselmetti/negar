USE ImagingSystem;
GO
IF OBJECT_ID ( 'Insurances.SP_InsertInsuranceServices', 'P' ) IS NOT NULL
    DROP PROCEDURE [Insurances].[SP_InsertInsuranceServices];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/19
-- Last Modified: 1388/3/25
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای ثبت ارتباط یك خدمت با یك بیمه
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Insurances].[SP_InsertInsuranceServices]
@InsIX SMALLINT, 
@ServiceIX  SMALLINT,
@IsCover BIT,
@InsPrice INT, 
@InsPart INT, 
@PatientPayable INT
WITH ENCRYPTION 
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	IF @IsCover IS NULL SET @IsCover = 1;
	IF @InsPrice IS NULL SET @InsPrice = 0;
	IF @InsPart IS NULL SET @InsPart = 0;
	IF @PatientPayable IS NULL SET @PatientPayable = 0;
	--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	IF EXISTS(SELECT * FROM [ImagingSystem].[Insurances].[InsuranceServices]
		WHERE (InsIX = @InsIX) AND (ServiceIX = @ServiceIX))
	BEGIN
		UPDATE [ImagingSystem].[Insurances].[InsuranceServices]
			SET [IsCover] = @IsCover , 
				[InsPrice] = @InsPrice ,
				[InsPart] = @InsPart ,
				[PatientPayable] = @PatientPayable
		WHERE (InsIX = @InsIX) AND (ServiceIX = @ServiceIX)
	END
	--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	ELSE
	BEGIN
		INSERT INTO [ImagingSystem].[Insurances].[InsuranceServices] 
		([InsIX] , [ServiceIX], [IsCover], [InsPrice],  [InsPart], [PatientPayable]) 
		VALUES ( @InsIX, @ServiceIX , @IsCover,@InsPrice, @InsPart, @PatientPayable)
	END
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC ImagingSystem.Insurances.SP_InsertInsuranceServices 6 , 8 , 1 , 0 , 0 , 0
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@