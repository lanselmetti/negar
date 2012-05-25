USE ImagingSystem;
GO
IF OBJECT_ID ('Referrals.SP_SelectPatAdditionalData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_SelectPatAdditionalData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/5/7
-- Last Modified: 1388/6/26
-- Created By: Saeed Pournejati
-- Last Modified By:  Saeed Pournejati
-- روالی برای خواندن كلیه فیلد های اطلاعاتی اضافی یك بیمار
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_SelectPatAdditionalData]
@PatientListID INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS	
	SELECT * FROM [ImagingSystem].[Referrals].[PatAdditionalData]
	WHERE [PatientIX] = @PatientListID;
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	
-- EXEC [Referrals].[SP_SelectPatAdditionalData] 49 , N'2009/09/21 08:48:00'
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@