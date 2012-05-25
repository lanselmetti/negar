USE ImagingSystem;
GO
IF OBJECT_ID ( 'Services.SP_SelectAdditionalPriceData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Services].[SP_SelectAdditionalPriceData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/2/24
-- Last Modified: 1388/5/14
-- Created By: Saeed Pournejati
-- Last Modified By:  Saeed Pournejati
-- این روال وظیفه خواندن مقادیر فیلدهای اطلاعاتی اضافی قیمت خدمات را بر عهده دارد
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Services].[SP_SelectAdditionalPriceData]
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS
	SELECT * FROM [ImagingSystem].[Services].[AdditionalPriceData];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Services].[SP_SelectAdditionalPriceData] 10 , 10 , 500
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@