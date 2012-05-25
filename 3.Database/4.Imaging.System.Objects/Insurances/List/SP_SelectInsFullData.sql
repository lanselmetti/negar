USE ImagingSystem;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
IF OBJECT_ID ( 'Insurances.SP_SelectInsFullData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Insurances].[SP_SelectInsFullData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/3/17
-- Last Modified: 1388/12/16
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Insurances].[SP_SelectInsFullData]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS [ID] , CONVERT(BIT , 1) AS [BaseIsActive]
		, CONVERT(BIT , 1) AS [IsActive] , '(بدون بیمه)' AS [Name]
		, CONVERT(BIT , 1) AS [IsIns1] , CONVERT(BIT , 1) AS [IsIns2]
		, NULL AS [ContractStartDate] , NULL AS [ContractEndDate]
		, NULL AS [PatientPercent] , NULL AS [InsurerPartLimit]
		, NULL AS [Ins2FormulasIX] , NULL AS [Description]
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	UNION ALL SELECT [Tbl1].[ID] , [Tbl1].[IsActive] AS [BaseIsActive], [Tbl2].[IsActive] AS [IsActive] ,
		[Tbl1].[Name] , [Tbl2].[IsIns1] , [Tbl2].[IsIns2] , [Tbl2].[ContractStartDate] , 
		[Tbl2].[ContractEndDate] , [Tbl2].[PatientPercent] ,[Tbl2].[InsurerPartLimit],
		[Tbl2].[Ins2FormulasIX] , [Tbl2].[Description]
		FROM [PatientsSystem].[Clinic].[Insurances] AS [Tbl1]
		FULL OUTER JOIN [ImagingSystem].Insurances.List AS [Tbl2]
		ON [Tbl1].ID = [Tbl2].InsuranceIX ORDER BY [Name];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Insurances].[SP_SelectInsFullData]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@