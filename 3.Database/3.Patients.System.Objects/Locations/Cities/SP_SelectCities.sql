USE PatientsSystem;
GO
IF OBJECT_ID ( 'Locations.SP_SelectCities', 'P' ) IS NOT NULL
    DROP PROCEDURE [Locations].[SP_SelectCities];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/16
-- Last Modified: 1388/5/17
-- Created By: Elham Samiei
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Locations].[SP_SelectCities]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT [ID], [IsActive] , [Name] , [StateIX]
	FROM [PatientsSystem].[Locations].[Cities]	
	UNION SELECT NULL AS [ID] , CONVERT(BIT , 1) AS [IsActive] ,
		'(انتخاب نشده)' AS [Title] , CONVERT(SMALLINT , -1) AS [StateIX]
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Execute PatientsSystem.Locations.SP_SelectCities
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- موارد استفاده:
-- Admission => frmPatients
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@