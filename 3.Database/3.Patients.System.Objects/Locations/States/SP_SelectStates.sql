USE PatientsSystem;
GO
IF OBJECT_ID ( 'Locations.SP_SelectStates', 'P' ) IS NOT NULL
    DROP PROCEDURE [Locations].[SP_SelectStates];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/16
-- Last Modified: 1388/5/17
-- Created By: Elham Samiei
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Locations].[SP_SelectStates]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT [ID], [IsActive] , [Name] , [CountryIX] FROM [PatientsSystem].[Locations].[States]	
	UNION SELECT NULL AS [ID] , CONVERT(BIT , 1) AS [IsActive] , 
		'(انتخاب نشده)' AS [Title] , CONVERT(SMALLINT , -1) AS [CountryIX]
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Execute PatientsSystem.Locations.SP_SelectStates
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- موارد استفاده:
-- Admission => frmPatients
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@