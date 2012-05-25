USE ImagingSystem;
GO
IF OBJECT_ID ('Referrals.SP_SelectRefAdditionalData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_SelectRefAdditionalData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1388/6/26
-- Created By: Saeed Pournejati
-- Last Modified By:  Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_SelectRefAdditionalData]
@ReferralIX INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT * FROM [ImagingSystem].[Referrals].[RefAdditionalData]
	WHERE [ReferralIX] = @ReferralIX;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Referrals].[SP_SelectPatAdditionalData] 49 , N'2009/09/21 08:48:00'
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@