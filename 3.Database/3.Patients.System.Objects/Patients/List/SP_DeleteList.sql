USE PatientsSystem;
GO
IF OBJECT_ID ( 'Patients.SP_DeleteList', 'P' ) IS NOT NULL
    DROP PROCEDURE [Patients].[SP_DeleteList];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/01/23
-- Last Modified: 1389/06/15
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای حذف یك بیمار از سیستم پزشكی و حذف اطلاعات آن بیمار از زیر سیستم ها
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Patients].[SP_DeleteList]
@ID INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	DELETE FROM [PatientsSystem].[Patients].[List] 
	WHERE [PatientsSystem].[Patients].[List].[ID] = @ID;
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	-- در این قسمت بررسی میگردد كه زیر سیستم های مورد نظر وجود دارند یا خیر
	IF OBJECT_ID(N'ImagingSystem.Referrals.List') IS NOT NULL
	BEGIN
		DELETE FROM [ImagingSystem].[Referrals].[List] WHERE [PatientIX] = @ID;
		DELETE FROM [ImagingSystem].[Referrals].[PatAdditionalData] WHERE [PatientIX] = @ID;
	END
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Patients].[SP_DeleteList] 88
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@