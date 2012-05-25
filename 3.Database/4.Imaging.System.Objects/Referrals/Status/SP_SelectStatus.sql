USE ImagingSystem;
GO
IF OBJECT_ID ( 'Referrals.SP_SelectStatus', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_SelectStatus];
GO
---@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/16
-- Last Modified: 1389/1/19
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
---@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_SelectStatus]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS [ID] , CONVERT(BIT , 1) AS [IsActive] ,'(«‰ Œ«» ‰‘œÂ)' AS [Title]
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	UNION ALL SELECT [ID] , [IsActive] , [Title] 
	FROM [ImagingSystem].[Referrals].[Status] ORDER BY [Title];
GO
---@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [ImagingSystem].[Referrals].[SP_SelectStatus]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@