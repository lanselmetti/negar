USE PatientsSystem;
GO
IF  EXISTS (SELECT * FROM [sys].[triggers] 
	WHERE OBJECT_ID = OBJECT_ID(N'Clinic.TR_AfterDeleteRefPhysicians'))
	DROP TRIGGER [Clinic].[TR_AfterDeleteRefPhysicians];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/05/10
-- Last Modified: 1389/06/07
-- Created By: M.H.Zohrehvand
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE TRIGGER [TR_AfterDeleteRefPhysicians]
ON [PatientsSystem].[Clinic].[RefPhysicians]
AFTER DELETE
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	DECLARE @DeletedID INT;
	SET @DeletedID = (SELECT TOP 1 [ID] FROM DELETED);
	IF EXISTS (SELECT * FROM [sys].[objects]
		WHERE OBJECT_ID = OBJECT_ID(N'ImagingSystem.Referrals.List') AND [TYPE] = N'U')
		UPDATE [ImagingSystem].[Referrals].[List]
			SET [ReferPhysicianIX] = NULL WHERE [ReferPhysicianIX] = @DeletedID;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@