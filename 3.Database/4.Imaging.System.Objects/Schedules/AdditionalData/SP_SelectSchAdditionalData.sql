USE ImagingSystem;
GO
IF OBJECT_ID ('Schedules.SP_SelectSchAdditionalData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_SelectSchAdditionalData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1389/2/10
-- Last Modified: 1389/2/10
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای خواندن فیلد های اطلاعات اضافی یك نوبت مشخص
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_SelectSchAdditionalData]
@ID INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT [Tbl1].[ID] , [Tbl2].*
	FROM [ImagingSystem].[Schedules].[Appointments] AS [Tbl1]
	FULL OUTER JOIN [ImagingSystem].[Schedules].[AdditionalData] AS [Tbl2]
	ON [Tbl1].[ID] = [Tbl2].AppointmentIX
	WHERE [Tbl1].[ID] = @ID;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Schedules].[SP_SelectSchAdditionalData] 49 , N'2009/09/21 08:48:00'
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@