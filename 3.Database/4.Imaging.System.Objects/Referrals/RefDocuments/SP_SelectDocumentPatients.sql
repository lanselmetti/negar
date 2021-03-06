USE ImagingSystem;
GO
IF OBJECT_ID ( 'Referrals.SP_SelectDocumentPatients', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_SelectDocumentPatients];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/24
-- Last Modified: 1388/7/18
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_SelectDocumentPatients]
@BeginTime SMALLDATETIME
,@EndTime SMALLDATETIME
-- نمایش مراجعات فاقد خدمت
,@ShowNoServiceRefs BIT
,@ServicePhysIX SMALLINT = NULL
,@ServiceCatIX SMALLINT = NULL
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS 
	IF @ShowNoServiceRefs = 1
		SELECT ROW_NUMBER() OVER(ORDER BY [Tbl2].[RegisterDate] ASC) AS [RowNumber] , 
			[Tbl1].ID AS [PatientListID], [Tbl1].[PatientID], 
			[FullName] = (ISNULL([Tbl1].[FirstName] + ' ' , '') + [Tbl1].[LastName])
			, [Tbl2].[ID] AS [RefID] , [Tbl2].[RegisterDate] AS [RefDate]
			, [Referrals].[FK_CalcRefDocsCount](Tbl2.[ID]) AS [DocumentsCount]			
			-- , [Tbl2].
		-- @@@@@@@@@@@@@@@@@@@@@@@
		FROM [PatientsSystem].Patients.List AS [Tbl1]
		INNER JOIN [ImagingSystem].[Referrals].[List] AS [Tbl2]
		ON [Tbl1].[ID] = Tbl2.[PatientIX]
		-- @@@@@@@@@@@@@@@@@@@@@@@
		WHERE [Tbl2].[RegisterDate] >= @BeginTime
			AND [Tbl2].[RegisterDate] <= @EndTime
			AND [Referrals].[FK_CalcRefDocsCount]([Tbl2].[ID]) = 0
			AND [Referrals].[FK_IsRefServiceContainPhysician]([Tbl2].[ID] , @ServicePhysIX) = 1
			AND [Referrals].[FK_IsRefServiceContainCat]([Tbl2].[ID] , @ServiceCatIX) = 1
		-- @@@@@@@@@@@@@@@@@@@@@@@
		ORDER BY [Tbl2].[RegisterDate] ASC , [Tbl2].[ID] ASC
	-- =========================================
	-- =========================================
	-- =========================================
	ELSE -- @ShowNoServiceRefs = 0
		SELECT ROW_NUMBER() OVER(ORDER BY [Tbl2].[RegisterDate] ASC) AS [RowNumber] , 
			[Tbl1].ID AS [PatientListID], [Tbl1].[PatientID], 
			[FullName] = (ISNULL([Tbl1].[FirstName] + ' ' , '') + Tbl1.[LastName])
			, [Tbl2].[ID] AS [RefID] , [Tbl2].[RegisterDate] AS [RefDate]
			, [ImagingSystem].[Referrals].[FK_CalcRefDocsCount](Tbl2.[ID]) AS [DocumentsCount]
		-- @@@@@@@@@@@@@@@@@@@@@@@
		FROM [PatientsSystem].Patients.List AS [Tbl1]
		INNER JOIN [ImagingSystem].[Referrals].[List] AS [Tbl2]
		ON [Tbl1].[ID] = [Tbl2].[PatientIX]
		-- @@@@@@@@@@@@@@@@@@@@@@@
		WHERE [Tbl2].[RegisterDate] >= @BeginTime
			AND [Tbl2].[RegisterDate] <= @EndTime
			AND [Referrals].[FK_CalcRefDocsCount]([Tbl2].[ID]) = 0
			AND [Referrals].[FK_CalcRefServiceCount]([Tbl2].[ID]) <> 0
			AND [Referrals].[FK_IsRefServiceContainPhysician]([Tbl2].[ID] , @ServicePhysIX) = 1
			AND [Referrals].[FK_IsRefServiceContainCat]([Tbl2].[ID] , @ServiceCatIX) = 1
		-- @@@@@@@@@@@@@@@@@@@@@@@
		ORDER BY [Tbl2].[RegisterDate] ASC , [Tbl2].[ID] ASC
	-- =========================================
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Referrals].[SP_SelectDocumentPatients] '2008/08/08' , '2009/11/01' , 0
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@