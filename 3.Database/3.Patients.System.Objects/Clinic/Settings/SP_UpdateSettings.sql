USE PatientsSystem;
GO
IF OBJECT_ID ( 'Clinic.SP_UpdateSettings', 'P' ) IS NOT NULL
    DROP PROCEDURE [Clinic].[SP_UpdateSettings];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/2/23
-- Last Modified: 1388/2/29
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Clinic].[SP_UpdateSettings]
@ID SMALLINT
, @Boolean BIT
, @Value NVARCHAR(500)
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	UPDATE [PatientsSystem].[Clinic].[Settings]
	   SET [Boolean] = @Boolean , [Value] = @Value		  
	 WHERE [ID] = @ID
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Clinic].[SP_UpdateSettings] 1 , 1 , 'Test'
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- موارد استفاده:
--    =>   =>  
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@