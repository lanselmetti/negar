USE PatientsSystem;
GO
IF OBJECT_ID ( 'Clinic.SP_SelectSettings', 'P' ) IS NOT NULL
    DROP PROCEDURE [Clinic].[SP_SelectSettings];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/2/23
-- Last Modified: 1388/2/29
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Clinic].[SP_SelectSettings]
WITH ENCRYPTION
AS
	SELECT [ID] ,[Title] ,[Description] ,[Boolean] ,[Value]
	FROM [PatientsSystem].[Clinic].[Settings]
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Clinic].[SP_SelectSettings]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- ãæÇÑÏ ÇÓÊÝÇÏå:
--    =>   =>  
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@