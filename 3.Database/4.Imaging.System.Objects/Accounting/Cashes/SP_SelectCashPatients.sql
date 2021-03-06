USE ImagingSystem;
GO
IF OBJECT_ID ( 'Accounting.SP_SelectCashPatients', 'P' ) IS NOT NULL
    DROP PROCEDURE [Accounting].[SP_SelectCashPatients];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/24
-- Last Modified: 1390/04/06
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Accounting].[SP_SelectCashPatients]
@BeginTime NVARCHAR(20)
,@EndTime NVARCHAR(20)
-- عدم نمایش مراجعات دارای یك بار پرداخت
,@HidePayedRefs BIT
-- نمایش مراجعات فاقد خدمت
,@ShowNoServiceRefs BIT
-- نمایش مراجعات مخفی شده
,@ShowExcludedRefs BIT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS 
	DECLARE @Command VARCHAR(MAX);
	SET @Command = 'SELECT [TblPat].[ID] AS [PatientListID], [TblPat].[PatientID], ' + 
		'[FullName] = (ISNULL([TblPat].[FirstName] + '' '' , '''') + [TblPat].[LastName]) ' +
		', [TblRef].[ID] AS [RefID] , [TblRef].[RegisterDate] AS [RefDate] ' +
		', [TblRef].[Ins1IX] , [TblRef].[Ins2IX] ' +
		', [ImagingSystem].[Accounting].[FK_CalcTotalRefRemain]([TblRef].[ID]) AS [PatientPayable] ' + 
		-- @@@@@@@@@@@@@@@@@@@@@@@
		'FROM [PatientsSystem].[Patients].[List] AS [TblPat] ' +
		'INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRef] ' +
		'ON [TblPat].[ID] = [TblRef].[PatientIX] ' +
		-- @@@@@@@@@@@@@@@@@@@@@@@
		'WHERE [TblRef].[RegisterDate] >= ''' + @BeginTime + ''' ' +
		'AND [TblRef].[RegisterDate] <= ''' + @EndTime + ''' ';
		-- ===========================================================
		-- مخفی كردن مراجعات پرداخت شده - نمایش مراجعات فاقد خدمت
		IF @HidePayedRefs = 1 AND @ShowNoServiceRefs = 1			
			SET @Command = @Command +
			-- پرداختنی بیمار بزرگتر از صفر باشد
			'AND [ImagingSystem].[Accounting].[FK_CalcTotalRefRemain]([TblRef].[ID]) >= 0 ' +
			-- مراجعاتی كه پرداختی دارند نمایش داده نشود
			'AND [ImagingSystem].[Accounting].[FK_CalcRefTransactionCount]([TblRef].ID) = 0) ';
		-- ===========================================================
		-- مخفی كردن مراجعات پرداخت شده - عدم نمایش مراجعات فاقد خدمت
		ELSE IF @HidePayedRefs = 1 -- AND @ShowNoServiceRefs = 0	
			SET @Command = @Command +
			-- پرداختنی بیمار بزرگتر از صفر باشد
			'AND [ImagingSystem].[Accounting].[FK_CalcTotalRefRemain]([TblRef].[ID]) >= 0 ' +
			-- هیچ پولی قبلاً از بیمار گرفته نشده باشد
			'AND [ImagingSystem].[Accounting].[FK_CalcRefTransactionCount]([TblRef].ID) = 0 ' +
			-- مراجعه بیمار دارای خدمت باشد
			'AND [ImagingSystem].[Referrals].[FK_CalcRefServiceCount]([TblRef].[ID]) > 0 ';
		-- ===========================================================
		-- نمایش مراجعات دارای یك بار پرداخت - یعنی نمایش همه بیماران بدون بیماران تسویه شده
		-- و عدم نمایش مراجعات فاقد خدمت
		ELSE IF @ShowNoServiceRefs = 1 -- AND @HidePayedRefs = 0
			SET @Command = @Command +
			-- عدم نمایش مراجعات دارای باقیمانده
			'AND ([ImagingSystem].[Accounting].[FK_CalcTotalRefRemain]([TblRef].[ID]) > 0 ' +
			-- یا نمایش مراجعات بدون دریافت یا بازپرداخت
			'OR [ImagingSystem].[Accounting].[FK_CalcRefTransactionCount]([TblRef].ID) = 0) ';
		-- ===========================================================
		-- عدم مخفی كردن مراجعات دارای پرداخت و عدم نمایش مراجعات بدون خدمت
		ELSE -- IF @HidePayedRefs = 0 AND @ShowNoServiceRefs = 0
			SET @Command = @Command +
			-- عدم نمایش مراجعات بدون خدمت
			'AND [ImagingSystem].[Referrals].[FK_CalcRefServiceCount]([TblRef].[ID]) <> 0 ' +
			-- عدم نمایش مراجعات تسویه شده
			'AND ([ImagingSystem].[Accounting].[FK_CalcTotalRefRemain]([TblRef].[ID]) > 0 ' +
			-- یا نمایش مراجعات بدون دریافت و پرداخت
			'OR [ImagingSystem].[Accounting].[FK_CalcRefTransactionCount]([TblRef].ID) = 0) ';
		-- ===========================================================
		IF @ShowExcludedRefs = 0
			SET @Command = @Command +
			'AND [TblRef].[ID] NOT IN (SELECT [RefIX] FROM [ImagingSystem].[Accounting].[CashExcludedRefs]) ';
		SET @Command = @Command + 'ORDER BY [TblRef].[RegisterDate] ASC;';
		EXECUTE (@Command);
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- EXEC Accounting.[SP_SelectCashPatients] '2010/05/06 09:25:27' , '2011/06/27 12:25:28' , 0 , 1 , 1
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@