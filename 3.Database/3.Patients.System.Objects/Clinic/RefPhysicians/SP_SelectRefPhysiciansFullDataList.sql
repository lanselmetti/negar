USE PatientsSystem;
GO
IF OBJECT_ID ( 'Clinic.SP_SelectRefPhysiciansFullDataList', 'P' ) IS NOT NULL
    DROP PROCEDURE [Clinic].[SP_SelectRefPhysiciansFullDataList];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/4/21
-- Last Modified: 1389/5/16
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Clinic].[SP_SelectRefPhysiciansFullDataList]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT NULL AS [ID] , '(انتخاب نشده)' AS [FullName] , NULL AS [Gender] ,
		NULL AS [FirstName], NULL AS [LastName], 
		NULL AS [MedicalID] , NULL AS [Specialty], NULL AS [Description]
	UNION ALL SELECT [Tbl1].[ID], ISNULL([MedicalID] + ' - ', '') + 
		ISNULL([FirstName] + ' ', '') + [LastName] AS [FullName] ,
		(CASE [IsMale] WHEN 1 THEN 'مرد' ELSE 'زن' END) AS [Gender],
		Tbl1.[FirstName], Tbl1.[LastName], 
		Tbl1.[MedicalID], Tbl2.Title AS [Specialty], Tbl1.[Description]
		FROM [PatientsSystem].[Clinic].[RefPhysicians] AS Tbl1
		LEFT OUTER JOIN [PatientsSystem].[Clinic].[RefPhysiciansSpecs] AS Tbl2
		ON Tbl1.SpecialtyIX = Tbl2.ID;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Clinic].[SP_SelectRefPhysiciansFullDataList] 1571 , NULL
-- EXEC [Clinic].[SP_SelectRefPhysiciansFullDataList] NULL , '21'
-- EXEC [Clinic].[SP_SelectRefPhysiciansFullDataList] NULL , NULL , 'سا'
-- EXEC [Clinic].[SP_SelectRefPhysiciansFullDataList] NULL , NULL
-- EXEC [Clinic].[SP_SelectRefPhysiciansFullDataList] 0 , NULL , NULL
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@