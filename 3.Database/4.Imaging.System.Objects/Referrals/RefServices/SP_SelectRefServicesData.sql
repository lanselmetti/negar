USE ImagingSystem;
GO
IF OBJECT_ID ( 'Referrals.SP_SelectRefServicesData', 'P' ) IS NOT NULL
    DROP PROCEDURE [Referrals].[SP_SelectRefServicesData];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/10/17
-- Last Modified: 1388/10/17
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Referrals].[SP_SelectRefServicesData]
@RefID INT
WITH ENCRYPTION
-- @@@@@@@@@@@@@@@@@@@@@@@
AS 
	SELECT [Tbl2].[Code], 
	[Tbl2].[Name] AS [ServiceName],  [Tbl3].[Name] AS [CategoryName], 
	[Tbl2].[PriceFree], [Tbl2].[PriceGov], [Tbl2].[Description], [Tbl1].[Quantity], 
	ISNULL([Tbl4].[FirstName] + ' ' , '') + [Tbl4].[LastName] AS [ExpertName], 
	ISNULL([Tbl5].[FirstName] + ' ' , '') + [Tbl5].[LastName] AS [PhysicianName], 
	[Tbl1].[Ins1Price], [Tbl1].[Ins1PartPrice], [Tbl1].[Ins2Price], 
	[Tbl1].[Ins2PartPrice], 
	[Tbl1].[PatientPayablePrice]
	-- @@@@@@@@@@@@@@@@@@@@@@@
	FROM [ImagingSystem].[Referrals].[RefServices] AS [Tbl1]
	LEFT OUTER JOIN [ImagingSystem].[Services].[List] AS [Tbl2]
	ON [Tbl1].[ServiceIX] = [Tbl2].[ID]
	LEFT OUTER JOIN [ImagingSystem].[Services].[Categories] AS [Tbl3]
	ON [Tbl2].[CategoryIX] = [Tbl3].[ID]
	LEFT OUTER JOIN [ImagingSystem].[Referrals].[Performers] AS [Tbl4]
	ON [Tbl1].[ExpertIX] = [Tbl4].[ID]
	LEFT OUTER JOIN [ImagingSystem].[Referrals].[Performers] AS [Tbl5]
	ON [Tbl1].[PhysicianIX] = [Tbl5].[ID]
	-- @@@@@@@@@@@@@@@@@@@@@@@
	WHERE [Tbl1].[ReferralIX] = @RefID AND [Tbl1].[IsActive] = 1
	ORDER BY [Tbl1].[ID];
	-- =========================================
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Referrals].[SP_SelectRefServicesData] 1048
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@