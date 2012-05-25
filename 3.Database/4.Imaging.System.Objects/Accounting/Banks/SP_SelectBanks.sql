USE ImagingSystem;
GO
IF OBJECT_ID ( 'Accounting.SP_SelectBanks', 'P' ) IS NOT NULL
    DROP PROCEDURE [Accounting].[SP_SelectBanks];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/4/23
-- Last Modified: 1388/10/1
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن اطلاعات بانك های ثبت شده در سیستم برای استفاده های مالی
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Accounting].[SP_SelectBanks]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT NULL AS ID , CAST(1 AS BIT) AS [IsActive] , '(انتخاب نشده)' AS 'Name'		 
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
	UNION SELECT [ID] , [IsActive] , [Name]  
	FROM [ImagingSystem].[Accounting].[Banks] ORDER BY 3;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Accounting].[SP_SelectBanks]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@