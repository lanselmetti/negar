USE ImagingSystem;
GO
IF OBJECT_ID ('Accounting.SP_InsertCashiersCashes', 'P') IS NOT NULL
    DROP PROCEDURE [Accounting].[SP_InsertCashiersCashes];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/20 
-- Last Modified: 1388/4/18
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Accounting].[SP_InsertCashiersCashes]
@CashierID SMALLINT,
@CashID SMALLINT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	IF NOT EXISTS (SELECT * FROM [ImagingSystem].[Accounting].[CashiersCashes] 
		WHERE [CashierIX] = @CashierID AND [CashIX] = @CashID)
	    INSERT INTO [ImagingSystem].[Accounting].[CashiersCashes]
			([CashierIX], [CashIX]) VALUES (@CashierID , @CashID);
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [Accounting].[SP_InsertCashiersCashes] 1, 1
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@