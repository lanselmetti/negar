USE ImagingSystem;
GO
IF OBJECT_ID ( 'Services.SP_UpdateAdditionalPriceColumns', 'P' ) IS NOT NULL
    DROP PROCEDURE [Services].[SP_UpdateAdditionalPriceColumns];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/8/21
-- Last Modified: 1388/8/21
-- Created By: Elham Samiei
-- Last Modified By:  Saeed Pournejati
-- روالی برای ویرایش اطلاعات یك فیلد قیمت اضافی جدید در 2 جدول مربوط به آن
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Services].[SP_UpdateAdditionalPriceColumns]
@ID SMALLINT ,
@Name NVARCHAR(25) ,
@Description NVARCHAR(300)
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS
	UPDATE [ImagingSystem].[Services].[AdditionalPriceColumns]
	SET [Name] = @Name 	, [Description] = @Description
	WHERE  ID = @ID;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Services].[SP_UpdateAdditionalPriceColumns] 'تعرفه كنگره رادیولوژی', 'تعرفه كنگره '
-- TRUNCATE TABLE [Services].[SP_UpdateAdditionalPriceColumns]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@