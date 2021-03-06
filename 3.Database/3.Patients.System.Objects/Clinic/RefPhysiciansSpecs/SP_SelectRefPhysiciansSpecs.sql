USE PatientsSystem;
GO
IF OBJECT_ID ('Clinic.SP_SelectRefPhysiciansSpecs', 'P') IS NOT NULL
    DROP PROCEDURE [Clinic].[SP_SelectRefPhysiciansSpecs];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1387/12/15
-- Last Modified: 1388/6/31
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن لیست تخصص های پزشكان مراجعه به همراه آیتم انتتخاب نشده
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Clinic].[SP_SelectRefPhysiciansSpecs]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS [ID] , 1 AS [IsActive] , '(انتخاب نشده)' AS [Title]
	UNION ALL SELECT [ID] , [IsActive] , [Title]
	FROM [PatientsSystem].[Clinic].[RefPhysiciansSpecs] ORDER BY [Title];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Clinic].[SP_SelectRefPhysiciansSpecs] null
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@