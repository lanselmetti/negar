USE PatientsSystem;
GO
IF OBJECT_ID ( 'Clinic.SP_SelectRefPhysiciansFullData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Clinic].[SP_SelectRefPhysiciansFullData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/03/17
-- Last Modified: 1389/07/08
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Clinic].[SP_SelectRefPhysiciansFullData]
@ID INT = NULL
, @FirstMedicalIDNo NVARCHAR(2) = NULL
, @FirstLastNameChar NVARCHAR(2) = NULL
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	-- جستجوی یك پزشك با عدد اول نظام پزشكی
	IF @FirstMedicalIDNo IS NOT NULL
		SELECT NULL AS [ID] , '' AS [FullName] , NULL AS [Gender] , NULL AS [FirstName] ,
			'' AS [LastName] , NULL AS [MedicalID] , NULL AS [Specialty] , NULL AS [Description]
		UNION SELECT Tbl1.ID, ISNULL(Tbl1.[MedicalID] + ' - ', '') +
			Tbl1.[LastName] + ISNULL(' - ' + Tbl1.[FirstName] , '') AS [FullName] ,
			(CASE [IsMale] WHEN 1 THEN 'مرد' WHEN 0 THEN 'زن' ELSE NULL END) AS [Gender],
			Tbl1.[FirstName], Tbl1.[LastName], 
			Tbl1.[MedicalID], Tbl2.Title AS [Specialty], [Tbl1].[Description] AS [Description]
		FROM [PatientsSystem].[Clinic].[RefPhysicians] AS Tbl1
		LEFT OUTER JOIN [PatientsSystem].[Clinic].[RefPhysiciansSpecs] AS Tbl2
		ON Tbl1.[SpecialtyIX] = Tbl2.[ID]
		WHERE Tbl1.[IsActive] = 1 AND Tbl1.[MedicalID] LIKE @FirstMedicalIDNo + '%' ORDER BY 2;
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	ELSE IF @FirstLastNameChar IS NOT NULL
		SELECT NULL AS [ID] , '' AS [FullName] , NULL AS [Gender] , NULL AS [FirstName] ,
			'' AS [LastName] , NULL AS [MedicalID] , NULL AS [Specialty] , NULL AS [Description]
		UNION SELECT Tbl1.ID, Tbl1.[LastName] + ISNULL(' - ' + Tbl1.[FirstName], '') +
			ISNULL(' - ' + Tbl1.[MedicalID], '') AS [FullName] ,
			(CASE [IsMale] WHEN 1 THEN 'مرد' WHEN 0 THEN 'زن' ELSE NULL END) AS [Gender],
			Tbl1.[FirstName], Tbl1.[LastName], 
			Tbl1.[MedicalID], Tbl2.Title AS [Specialty], [Tbl1].[Description] AS [Description]
		FROM [PatientsSystem].[Clinic].[RefPhysicians] AS Tbl1
		LEFT OUTER JOIN [PatientsSystem].[Clinic].[RefPhysiciansSpecs] AS Tbl2
		ON Tbl1.[SpecialtyIX] = Tbl2.[ID]
		WHERE Tbl1.[IsActive] = 1 AND Tbl1.[LastName] LIKE @FirstLastNameChar + '%' ORDER BY 2;
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	ELSE IF @ID IS NOT NULL AND @ID <> 0
		SELECT Tbl1.ID, ISNULL(Tbl1.[MedicalID] + ' - ', '') +
			Tbl1.[LastName] + ISNULL(' - ' + Tbl1.[FirstName] , '') AS [FullName] ,
			(CASE [IsMale] WHEN 1 THEN 'مرد' WHEN 0 THEN 'زن' ELSE NULL END) AS [Gender],
			Tbl1.[FirstName], Tbl1.[LastName], 
			Tbl1.[MedicalID], Tbl2.Title AS [Specialty], [Tbl1].[Description]
		FROM [PatientsSystem].[Clinic].[RefPhysicians] AS Tbl1
		LEFT OUTER JOIN [PatientsSystem].[Clinic].[RefPhysiciansSpecs] AS Tbl2
		ON Tbl1.[SpecialtyIX] = Tbl2.[ID]
		WHERE Tbl1.[ID] = @ID ORDER BY 2;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Clinic].[SP_SelectRefPhysiciansFullData] 1571 , NULL
-- EXEC [Clinic].[SP_SelectRefPhysiciansFullData] NULL , NULL , 'سا'
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@