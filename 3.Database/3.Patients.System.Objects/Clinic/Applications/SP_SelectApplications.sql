USE PatientsSystem;
GO
IF OBJECT_ID ( 'Clinic.SP_SelectApplications', 'P' ) IS NOT NULL
    DROP PROCEDURE [Clinic].[SP_SelectApplications];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1387/12/15
-- Last Modified: 1388/6/26
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Clinic].[SP_SelectApplications]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS [ID]  , '[Empty]' AS [EnglishName],
	 '(ÇäÊÎÇÈ äÔÏå)' AS [LocalizedName] , NULL AS [Edition] ,
	NULL AS [Version] , NULL AS [DatabaseName]  , NULL AS [Description]
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	UNION ALL SELECT [ID] ,[EnglishName] ,[LocalizedName]
		  ,[Edition] ,[Version] ,[DatabaseName] ,[Description]
	FROM [PatientsSystem].[Clinic].[Applications]
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Clinic].[SP_SelectApplications]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- ãæÇÑÏ ÇÓÊÝÇÏå:
--    =>   =>
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@