USE PatientsSystem;
GO
IF OBJECT_ID ( 'Patients.SP_SelectJobs', 'P' ) IS NOT NULL
    DROP PROCEDURE [Patients].[SP_SelectJobs];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/1/15
-- Last Modified: 1388/5/17
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Patients].[SP_SelectJobs]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT [ID] , [IsActive] , [Title] FROM PatientsSystem.Patients.Jobs
	UNION SELECT NULL AS [ID] , CONVERT(BIT , 1) AS [IsActive] ,'(ÇäÊÎÇÈ äÔÏå)' AS [Title]
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Patients].[SP_SelectJobs]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- ãæÇÑÏ ÇÓÊÝÇÏå:
-- Admission => frmPatients
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@