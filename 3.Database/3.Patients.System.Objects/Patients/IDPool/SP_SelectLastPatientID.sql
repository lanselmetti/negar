USE PatientsSystem;
GO
IF OBJECT_ID ('Patients.SP_SelectLastPatientID', 'P') IS NOT NULL
    DROP PROCEDURE [Patients].[SP_SelectLastPatientID];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/02/03
-- Last Modified: 1389/09/07
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای تولید كدی جدید برای ثبت بیمار جدید
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Patients].[SP_SelectLastPatientID]
@TodayDate NVARCHAR(10) ,
@PatientID NVARCHAR(20) = NULL OUTPUT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
	BEGIN TRANSACTION;
	BEGIN TRY		
		DECLARE @LastDate NVARCHAR(10);
		SET @LastDate = (SELECT TOP 1 [LastDate] FROM [PatientsSystem].[Patients].[IDPool] WITH (HOLDLOCK));
		-- *********************************************
		IF (@LastDate IS NULL)
			INSERT INTO [PatientsSystem].[Patients].[IDPool] WITH (HOLDLOCK)
			([LastDate] , [CurrentID]) VALUES (@TodayDate , 0);
		ELSE IF (@LastDate < @TodayDate)
			UPDATE [PatientsSystem].[Patients].[IDPool] WITH (HOLDLOCK)
				SET [LastDate] = @TodayDate , [CurrentID] = 0;
		-- KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
		DECLARE @Counter INT;
		SET @Counter = (SELECT TOP 1 [CurrentID] + 1
			FROM [PatientsSystem].[Patients].[IDPool] WITH (HOLDLOCK));
		UPDATE [PatientsSystem].[Patients].[IDPool] WITH (HOLDLOCK) SET [CurrentID] = @Counter;	
		-- KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
		DECLARE @TextCounter NVARCHAR(3);
		SET @TextCounter = CAST(@Counter AS NVARCHAR(3));
		IF (LEN(@TextCounter) = 1) SET @TextCounter = '00' + @TextCounter;
		ELSE IF (LEN(@TextCounter) = 2) SET @TextCounter = '0' + @TextCounter;
		SET @PatientID = @TodayDate + @TextCounter;
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
	END CATCH
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
--DECLARE @Value NVARCHAR(20);
--EXECUTE [Patients].[SP_SelectLastPatientID] '890729' , @Value OUTPUT;
--SELECT @Value;
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@