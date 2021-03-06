USE PatientsSystem;
GO
IF OBJECT_ID ( 'Patients.SP_CheckLockPatientList', 'P' ) IS NOT NULL
    DROP PROCEDURE [Patients].[SP_CheckLockPatientList];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/10/25
-- Last Modified: 1389/03/30
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای بدست آوردن قفل بودن یا نبودن یك بیمار
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Patients].[SP_CheckLockPatientList]
@PatID INT,
@IsLock BIT = NULL OUTPUT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	-- اگر آخرین زمان ویرایش از 10 دقیقه پیش بیشتر باشد قطعاً ردیف آزاد است
	DECLARE @LastDate DATETIME;
	SET @LastDate = (SELECT TOP 1 [LockDateTime]
		FROM [PatientsSystem].[Patients].[List]
		WHERE ID = @PatID);
	IF @LastDate IS NULL OR DATEDIFF(MINUTE , @LastDate , GETDATE()) > 10
		SET @IsLock = 0;
	ELSE SET @IsLock = 1;
	RETURN @IsLock;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Patients].[SP_CheckLockPatientList] 890519 , @Value;
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- موارد استفاده:
-- Referrals => frmAppoinments
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@