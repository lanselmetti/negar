USE ImagingSystem
GO
IF OBJECT_ID ( 'Reports.SP_SelectBillTemplate', 'P' ) IS NOT NULL
    DROP PROCEDURE [Reports].[SP_SelectBillTemplate];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/01/23
-- Last Modified: 1391/01/08
-- Created By: Saeed Pournejati
-- Last Modified By: Mohammad Hosein Zohrehvand
-- روالی برای خواندن لیست قالب های قبوض تصویربرداری
-- قابل استفاده برای كنترل چاپ قبض
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Reports].[SP_SelectBillTemplate]
@UserIX SMALLINT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	-- برای كاربران مدیر
	IF (@UserIX > 2)
	
			SELECT [Tbl1].[ID] , [Tbl2].[UserIX] , [Tbl2].[PrintLimitation] , 
			[Tbl1].[IsActive] , [Tbl1].[Name] , [Tbl1].[Description]
		FROM [ImagingSystem].[Reports].[BillTemplates] AS [Tbl1]
		INNER JOIN [ImagingSystem].[Reports].[BillsUserAccess] AS [Tbl2]
		ON [Tbl1].[ID] = [Tbl2].[BillIX]
		WHERE [Tbl2].[UserIX] = @UserIX AND [Tbl1].[IsActive] = 1;
		-- این قسمت توسط آقای پورنجاتی طراحی شده بود كه ایراد داشت
		-- و قبوض را به صورت تكراری نمایش می داد
		--SELECT DISTINCT [Tbl1].[ID] , @UserIX AS [UserIX] , [Tbl2].[PrintLimitation] , 
		--	[Tbl1].[IsActive] , [Tbl1].[Name] , [Tbl1].[Description]
		--FROM [ImagingSystem].[Reports].[BillTemplates] AS [Tbl1]
		--LEFT OUTER JOIN [ImagingSystem].[Reports].[BillsUserAccess] AS [Tbl2]
		--ON [Tbl1].[ID] = [Tbl2].[BillIX]
		--WHERE [Tbl1].[IsActive] = 1;
		
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	ELSE
		SELECT  [Tbl1].[ID] , @UserIX AS [UserIX] , NULL AS [PrintLimitation] , 
			[Tbl1].[IsActive] , [Tbl1].[Name] , [Tbl1].[Description]
		FROM [ImagingSystem].[Reports].[BillTemplates] AS [Tbl1]
		WHERE [Tbl1].[IsActive] = 1;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Reports].[SP_SelectBillTemplate] 2
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@