USE ImagingSystem;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
IF OBJECT_ID ( 'Accounting.SP_SelectCashiersCashesList', 'P' ) IS NOT NULL
    DROP PROCEDURE [Accounting].[SP_SelectCashiersCashesList];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/01/06
-- Last Modified: 1389/01/06
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روال نمایش دسترسی كاربران به صندوق ها ، ویژه فرم تنظیمات ارتباط صندوق ها و صندوقداران
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Accounting].[SP_SelectCashiersCashesList]
WITH ENCRYPTION 
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT [Tbl2].[CashierIX] AS [CashierID] , [Tbl3].[UserName] ,
	ISNULL([Tbl3].[FirstName] + ' ', '') +  [Tbl3].[LastName] AS [FullName] ,
	[Tbl1].[ID] AS [CashID] , [Tbl1].[IsActive] AS [CashIsActive] , [Tbl1].[Name] AS [CashName]
	FROM [ImagingSystem].[Accounting].[Cashes] AS [Tbl1]
	INNER JOIN [ImagingSystem].[Accounting].[CashiersCashes] AS [Tbl2]
	ON [Tbl1].[ID] = [Tbl2].[CashIX]
	INNER JOIN [PatientsSystem].[Security].[Users] AS [Tbl3]
	ON [Tbl3].[ID] = [Tbl2].[CashierIX];
 GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Accounting].[SP_SelectCashiersCashesList]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@