USE PatientsSystem;
GO
IF OBJECT_ID (N'Clinic.FK_DateToString', N'FN') IS NOT NULL
    DROP FUNCTION [Clinic].[FK_DateToString];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1390/05/18
-- Last Modified: 1390/05/18
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روال تولید تاریخ به صورت رشته
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE FUNCTION [Clinic].[FK_DateToString] (@Date DATETIME)
RETURNS CHAR(10)
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS
BEGIN
	IF @Date IS NULL RETURN(NULL);
	DECLARE @ReturnVal VARCHAR(10);
	SET @ReturnVal = CONVERT(VARCHAR(4) , DATEPART(YEAR, @Date)) + '/';
	DECLARE @TempItem TINYINT;
	SET @TempItem = DATEPART(MONTH, @Date);
	IF @TempItem < 10 SET @ReturnVal = @ReturnVal + '0' + CONVERT(NVARCHAR(1), @TempItem) + '/'
	ELSE SET @ReturnVal = @ReturnVal + CONVERT(NVARCHAR(2) , @TempItem) + '/'
	SET @TempItem = DATEPART(DAY , @Date);
	IF @TempItem < 10 SET @ReturnVal = @ReturnVal + '0' + CONVERT(NVARCHAR(1), @TempItem)
	ELSE SET @ReturnVal = @ReturnVal + CONVERT(NVARCHAR(2) , @TempItem)
	RETURN(@ReturnVal);
END
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@
-- SELECT [Clinic].[FK_DateToString] ('2010/1/02');
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@