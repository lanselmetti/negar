USE ImagingSystem;
GO
IF  EXISTS (SELECT * FROM [sys].[triggers] 
	WHERE OBJECT_ID = OBJECT_ID(N'Accounting.TR_AfterRefTransactionChanged'))
	DROP TRIGGER [Accounting].[TR_AfterRefTransactionChanged];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/09/07
-- Last Modified: 1389/09/07
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE TRIGGER [TR_AfterRefTransactionChanged]
ON [ImagingSystem].[Accounting].[RefTransaction]
WITH ENCRYPTION
AFTER INSERT, UPDATE, DELETE
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	DECLARE @ChangedRefID INT;
	IF (SELECT TOP 1 [ReferralIX] FROM DELETED) IS NOT NULL
		SET @ChangedRefID = (SELECT TOP 1 [ReferralIX] FROM DELETED);
	ELSE IF (SELECT TOP 1 [ReferralIX] FROM INSERTED) IS NOT NULL
		SET @ChangedRefID = (SELECT TOP 1 [ReferralIX] FROM INSERTED);
	UPDATE [ImagingSystem].[Referrals].[List]
	SET [ImagingSystem].[Referrals].[List].[RemainValue] = 
		[ImagingSystem].[Accounting].[FK_CalcTotalRefRemain](@ChangedRefID)
	WHERE [ImagingSystem].[Referrals].[List].[ID] = @ChangedRefID;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@