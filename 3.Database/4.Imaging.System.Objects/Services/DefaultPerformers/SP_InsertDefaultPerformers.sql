USE ImagingSystem;
GO
IF OBJECT_ID ( 'Services.SP_InsertDefaultPerformers', 'P' ) IS NOT NULL
    DROP PROCEDURE [Services].[SP_InsertDefaultPerformers];
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
GO
-- Created Date: 1388/3/16 
-- Last Modified: 1388/3/16
-- Created By: M.H.Zohrehvand
-- Last Modified By: M.H.Zohrehvand
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Services].[SP_InsertDefaultPerformers]
@ServiceIX SMALLINT,
@PerformerIX SMALLINT,
@IsExpert BIT,
@Days NVARCHAR(7),
@Period NVARCHAR(8)
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	INSERT INTO [ImagingSystem].[Services].[DefaultPerformers]
		([ServiceIX],[IsExpert],[PerformerIX],[Days],[Period])
     VALUES (@ServiceIX,@IsExpert,@PerformerIX ,@Days ,@Period);
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXECUTE [Services].[SP_InsertDefaultPerformers] 2,12,True,1232,121
-- EXECUTE [Services].[SP_SelectDefaultPerformers]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@