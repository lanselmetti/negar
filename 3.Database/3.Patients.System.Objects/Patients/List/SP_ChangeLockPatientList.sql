USE PatientsSystem;
GO
IF OBJECT_ID ( 'Patients.SP_ChangeLockPatientList', 'P' ) IS NOT NULL
    DROP PROCEDURE [Patients].[SP_ChangeLockPatientList];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/10/25
-- Last Modified: 1389/03/30
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای تغییر وضعیت قفل بودن یك بیمار
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Patients].[SP_ChangeLockPatientList]
@PatID INT,
@IsLock BIT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	BEGIN TRY
		-- حالت برای قفل كردن بیمار
		IF @IsLock = 1
			UPDATE [PatientsSystem].[Patients].[List]
			SET [LockDateTime] = GETDATE() 
			WHERE [ID] = @PatID;
		-- حالتی برای آزاد كردن بیمار
		ELSE UPDATE [PatientsSystem].[Patients].[List]
			SET [LockDateTime] = NULL
			WHERE [ID] = @PatID;
	END TRY
	BEGIN CATCH
		PRINT 'ERROR';
	END CATCH
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Patients].[SP_ChangeLockPatientList] 890519 , 0;
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- موارد استفاده:
-- Referrals => frmAppoinments
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@