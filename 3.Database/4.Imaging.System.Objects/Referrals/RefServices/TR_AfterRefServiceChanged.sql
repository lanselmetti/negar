USE ImagingSystem;
GO
IF  EXISTS (SELECT * FROM [sys].[triggers] 
	WHERE OBJECT_ID = OBJECT_ID(N'Referrals.TR_AfterRefServiceChanged'))
	DROP TRIGGER [Referrals].[TR_AfterRefServiceChanged];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/09/07
-- Last Modified: 1389/09/07
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE TRIGGER [TR_AfterRefServiceChanged]
ON [ImagingSystem].[Referrals].[RefServices]
WITH ENCRYPTION
AFTER INSERT, UPDATE, DELETE 
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	DECLARE @ChangedServiceRefID INT;
	IF (SELECT TOP 1 [ReferralIX] FROM DELETED) IS NOT NULL
		SET @ChangedServiceRefID = (SELECT TOP 1 [ReferralIX] FROM DELETED);
	ELSE IF (SELECT TOP 1 [ReferralIX] FROM INSERTED) IS NOT NULL
		SET @ChangedServiceRefID = (SELECT TOP 1 [ReferralIX] FROM INSERTED);
	UPDATE [ImagingSystem].[Referrals].[List]
	SET [ImagingSystem].[Referrals].[List].[RemainValue] = 
		[ImagingSystem].[Accounting].[FK_CalcTotalRefRemain](@ChangedServiceRefID)
	WHERE [ImagingSystem].[Referrals].[List].[ID] = @ChangedServiceRefID;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@