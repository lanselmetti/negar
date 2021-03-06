USE ImagingSystem;
GO
IF OBJECT_ID ( 'Referrals.SP_CheckLockRefList', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_CheckLockRefList];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/10/2
-- Last Modified: 1389/03/31
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای بدست آوردن قفل بودن یا نبودن یك مراجعه
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_CheckLockRefList]
@RefID INT,
@IsLock BIT = NULL OUTPUT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	-- اگر آخرین زمان ویرایش از 10 دقیقه پیش بیشتر باشد قطعاً ردیف آزاد است
	DECLARE @LastDate DATETIME;
	SET @LastDate = (SELECT TOP 1 [LockDateTime]
		FROM [ImagingSystem].[Referrals].[List]
		WHERE ID = @RefID);
	IF @LastDate IS NULL OR DATEDIFF(MINUTE , @LastDate , GETDATE()) > 10
		SET @IsLock = 0;
	ELSE SET @IsLock = 1;
	RETURN @IsLock;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Referrals].[SP_CheckLockRefList] 890519 , @Value;
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@