﻿USE PatientsSystem;
GO
IF OBJECT_ID ( 'Locations.SP_SelectCountries', 'P' ) IS NOT NULL
    DROP PROCEDURE [Locations].[SP_SelectCountries];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/16
-- Last Modified: 1388/5/17
-- Created By: Elham Samiei
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Locations].[SP_SelectCountries]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT [ID] , [IsActive] , [Name] FROM [PatientsSystem].[Locations].[Countries]
	UNION SELECT NULL AS [ID] , CONVERT(BIT , 1) AS [IsActive] ,'(انتخاب نشده)' AS [Title]
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Execute PatientsSystem.Locations.SP_SelectCountries
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- موارد استفاده:
-- Admission => frmPatients
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@