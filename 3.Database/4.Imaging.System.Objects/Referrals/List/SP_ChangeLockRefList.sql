USE ImagingSystem;
GO
IF OBJECT_ID ( 'Referrals.SP_ChangeLockRefList', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_ChangeLockRefList];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/10/2
-- Last Modified: 1389/03/31
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای تغییر وضعیت قفل بودن یك مراجعه
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_ChangeLockRefList]
@RefID INT,
@IsLock BIT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	BEGIN TRY
		-- حالت برای قفل كردن مراجعه
		IF @IsLock = 1
			UPDATE [ImagingSystem].[Referrals].[List]
			SET [LockDateTime] = GETDATE() 
			WHERE [ID] = @RefID;
		-- حالتی برای آزاد كردن مراجعه
		ELSE UPDATE [ImagingSystem].[Referrals].[List]
			SET [LockDateTime] = NULL
			WHERE [ID] = @RefID;
	END TRY
	BEGIN CATCH
		PRINT 'ERROR';
	END CATCH
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Referrals].[SP_ChangeLockRefList] 890519 , 0;
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- موارد استفاده:
-- Referrals => frmAppoinments
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@