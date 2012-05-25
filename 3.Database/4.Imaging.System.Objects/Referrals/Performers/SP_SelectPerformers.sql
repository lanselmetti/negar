USE ImagingSystem;
GO
IF OBJECT_ID ( 'Referrals.SP_SelectPerformers', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_SelectPerformers];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/3/17
-- Last Modified: 1389/5/16
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_SelectPerformers]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS ID , CONVERT(BIT , 1) AS [IsActive] , 
		CONVERT(BIT , 1) AS [IsExpert] , CONVERT(BIT , 1) AS [IsPhysician] , 
		' («‰ Œ«» ‰‘œÂ) ' AS [FullName] , NULL AS [FirstName] , NULL AS [LastName]		
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	UNION SELECT [ID] , [IsActive] , [IsExpert] , [IsPhysician] , 
		[LastName] + ISNULL(' , ' + [FirstName] , '') AS [FullName] , [FirstName] , [LastName]		
	FROM [ImagingSystem].[Referrals].[Performers] ORDER BY [FullName];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Referrals].[SP_SelectPerformers]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@