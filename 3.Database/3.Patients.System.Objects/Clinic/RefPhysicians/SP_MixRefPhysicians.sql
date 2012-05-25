USE PatientsSystem;
GO
IF OBJECT_ID ( 'Clinic.SP_MixRefPhysicians', 'P' ) IS NOT NULL
    DROP PROCEDURE [Clinic].[SP_MixRefPhysicians];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/06/07
-- Last Modified: 1389/06/07
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای ادغام مراجعات یك پزشك درخواست كننده با پزشك دیگر
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Clinic].[SP_MixRefPhysicians]
@ToDeleteID INT ,
@ToReplaceID INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	IF OBJECT_ID('ImagingSystem.Referrals.List') IS NOT NULL -- بانك تصویربرداری
		UPDATE [ImagingSystem].[Referrals].[List] 
		SET [ReferPhysicianIX] = @ToReplaceID WHERE [ReferPhysicianIX] = @ToDeleteID;
	-- ================================================
	DELETE FROM [PatientsSystem].[Clinic].[RefPhysicians] WHERE [ID] = @ToDeleteID;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Clinic].[SP_MixRefPhysicians] 1 , 2
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@