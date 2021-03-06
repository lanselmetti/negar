USE ImagingSystem;
GO
IF OBJECT_ID ( 'Insurances.SP_SelectIns2FormulaColumns', 'P' ) IS NOT NULL
    DROP PROCEDURE [Insurances].[SP_SelectIns2FormulaColumns];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/01/16 
-- Last Modified: 1389/06/10
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Insurances].[SP_SelectIns2FormulaColumns]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT '1FreePrice' AS [ColumnName] , N'تعرفه بدون بیمه' AS [Name]
	UNION ALL SELECT '2GovPrice' AS [ColumnName] , N'تعرفه دولتی' AS [Name]
	-- =====================================
	UNION ALL SELECT [ColumnName] AS [ColumnName] , [Name] AS [Name]
	FROM [ImagingSystem].[Services].[AdditionalPriceColumns]
	-- =====================================
	UNION ALL SELECT 'X1Ins1Price' AS [ColumnName] , N'قیمت از نظر بیمه اول' AS [Name]
	UNION ALL SELECT 'X2Ins1Part' AS [ColumnName] , N'سهم بیمه اول' AS [Name]
	UNION ALL SELECT 'X3Ins1PatientPrice' AS [ColumnName] , N'سهم بیمار از بیمه اول' AS [Name]
	UNION ALL SELECT 'X4Ins1PatientPayable' AS [ColumnName] , N'پرداختنی بیمار از بیمه اول' AS [Name]
	UNION ALL SELECT 'X5Ins1Limit' AS [ColumnName] , N'سقف سهم بیمه در بیمه اول' AS [Name]
	UNION ALL SELECT 'X6Ins1PatientPercent' AS [ColumnName] , N'درصد سهم بیمار از بیمه اول' AS [Name]
	UNION ALL SELECT 'Y1Ins2Limit' AS [ColumnName] , N'سقف سهم بیمه در بیمه دوم' AS [Name];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [ImagingSystem].[Insurances].[SP_SelectIns2FormulaColumns]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@