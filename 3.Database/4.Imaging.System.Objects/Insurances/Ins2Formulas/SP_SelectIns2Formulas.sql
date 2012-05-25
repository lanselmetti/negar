USE ImagingSystem;
GO
IF OBJECT_ID ( 'Insurances.SP_SelectIns2Formulas', 'P' ) IS NOT NULL
    DROP PROCEDURE [Insurances].[SP_SelectIns2Formulas];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/01/16 
-- Last Modified: 1389/06/10
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای نمایش لیست فرمول های بیمه دوم تعریف شده به همراه آیتم انتخاب نشده
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Insurances].[SP_SelectIns2Formulas]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT NULL AS [ID] , CONVERT(BIT , 1) AS [IsActive] , N'(انتخاب نشده)' AS [Name]
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
	UNION ALL SELECT [ID] ,CONVERT(BIT , [IsActive]) AS [IsActive] ,[Name]
	FROM [ImagingSystem].[Insurances].[Ins2Formulas]	ORDER BY [Name];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [ImagingSystem].[Insurances].[SP_SelectIns2Formulas]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@