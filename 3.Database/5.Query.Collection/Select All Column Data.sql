DECLARE @ServiceName NVARCHAR(MAX);
SET @ServiceName = '';
SELECT @ServiceName = @ServiceName + ' , ' + Convert(NVARCHAR(255) , [Tbl2].[Name])
	FROM [ImagingSystem].[Referrals].[RefServices] AS [Tbl1]
	INNER JOIN [ImagingSystem].[Services].[List] AS [Tbl2]
	ON [Tbl1].[ServiceIX] = [Tbl2].[ID]
	WHERE [Tbl1].[ReferralIX] = 110007;
	SELECT @ServiceName;