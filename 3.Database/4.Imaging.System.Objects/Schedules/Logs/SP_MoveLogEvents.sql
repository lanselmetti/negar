USE ImagingSystem;
GO
IF OBJECT_ID ( 'Schedules.SP_MoveLogEvents', 'P' ) IS NOT NULL
    DROP PROCEDURE [Schedules].[SP_MoveLogEvents];
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1391/01/19
-- Last Modified: 1391/01/19
-- Created By: Mohammad Hosein Zohrehvand
-- Last Modified By: Mohammad Hosein Zohrehvand
-- روالی برای انتقال رخداد های نوبت دهی
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Schedules].[SP_MoveLogEvents]
@PrincipleID INT,
@DestinationID INT
WITH ENCRYPTION
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
AS
	--INSERT INTO [ImagingSystem].[Schedules].[LogEvents]
	--([CategoryIX],[AppointmentIX],[UserIX],[Date],[Description])
	--SELECT [CategoryIX],@DestinationID AS [AppointmentIX],[UserIX],[Date],[Description] 
	--FROM [ImagingSystem].[Schedules].[LogEvents]
	--WHERE [AppointmentIX] = @PrincipleID
	UPDATE [ImagingSystem].[Schedules].[LogEvents]
	SET [AppointmentIX] = @DestinationID
	WHERE [AppointmentIX] = @PrincipleID
GO
--@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Schedules].[SP_MoveLogEvents] 467852
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@