// مبلغ قابل پرداخت بیماران
                ReportSelectString.Append("SELECT N'صندوق' AS [Title] , SUM([RefServ].[PatientPayablePrice]) AS [Value] " +
                    "FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServ] " +
                    "INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList] " +
                    "ON [RefList].[ID] = [RefServ].[ReferralIX] " +
                    "WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate " +
                    "AND [RefServ].[IsActive] = 1 ");





-- بخش اول اشكال مختلف درآمد را نمایش می دهد - بدهكاران
DECLARE @BeginDate DateTime
SET @BeginDate = '20110805 18:00:00'
DECLARE @EndDate DateTime
SET @EndDate = '20110805 19:00:00'
-- مبلغ قابل پرداخت بیماران
SELECT N'سهم بیماران آزاد' AS [Title] , SUM([RefServ].[PatientPayablePrice]) AS [Value]
FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServ]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList]
ON [RefList].[ID] = [RefServ].[ReferralIX]
WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate 
AND [RefServ].[IsActive] = 1
-- سهم بیمه های اصلی
UNION ALL SELECT N'سهم بیمه اصلی: "' + [TblIns].[Name] + '"' AS [Title] , SUM([RefServ].[Ins1PartPrice]) AS [Value]
FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServ]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList]
ON [RefList].[ID] = [RefServ].[ReferralIX]
INNER JOIN [PatientsSystem].[Clinic].[Insurances] AS [TblIns]
ON [RefList].[Ins1IX] = [TblIns].[ID]
WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate 
AND [RefServ].[IsActive] = 1 AND [RefServ].[IsIns1Cover] = 1
GROUP BY [TblIns].[Name]
-- بیمه های تكمیلی
UNION ALL SELECT N'سهم بیمه تكمیلی: "' + [TblIns].[Name] + '"' AS [Title] , SUM([RefServ].[Ins2PartPrice]) AS [Value]
FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServ]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList]
ON [RefList].[ID] = [RefServ].[ReferralIX]
INNER JOIN [PatientsSystem].[Clinic].[Insurances] AS [TblIns]
ON [RefList].[Ins2IX] = [TblIns].[ID]
WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate 
AND [RefServ].[IsActive] = 1 AND [RefServ].[IsIns2Cover] = 1
GROUP BY [TblIns].[Name]
-- درآمد طبقه بندی های مختلف
UNION ALL SELECT N'درآمد طبقه بندی: "' + [TblCatList].[Name] + '"' AS [Title] , 
	SUM([RefServ].[PatientPayablePrice] + ISNULL([RefServ].[Ins1PartPrice] , 0) + ISNULL([RefServ].[Ins2PartPrice] , 0)) AS [Value]
FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServ]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList]
ON [RefList].[ID] = [RefServ].[ReferralIX]
INNER JOIN [ImagingSystem].[Services].[List] AS [TblServList]
ON [TblServList].[ID] = [RefServ].[ServiceIX]
LEFT OUTER JOIN [ImagingSystem].[Services].[Categories] AS [TblCatList]
ON [TblCatList].[ID] = [TblServList].[CategoryIX]
WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate 
AND [RefServ].[IsActive] = 1
GROUP BY [TblCatList].[Name]
-- بازپرداخت ها
UNION ALL SELECT N'بازپرداخت های نقدی' AS [Title] , SUM(ABS([TblTrans].[Value])) AS [Value]
	FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans]
	LEFT OUTER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin]
	ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX]
	WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate 
	AND [TblTrans].[Value] < 0
	AND [TblTransAddin].[RefTransactionIX] IS NULL
-- بازپرداخت های چك
UNION ALL SELECT N'بازپرداخت های چك' AS [Title] , SUM(ABS([TblTrans].[Value])) AS [Value] 
	FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans]
	INNER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin]
	ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX]
	WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate 
	AND [TblTrans].[Value] < 0
	AND [TblTransAddin].[PayType] = 1
-- بازپرداخت های فیش
UNION ALL SELECT N'بازپرداخت های فیش' AS [Title] , SUM(ABS([TblTrans].[Value])) AS [Value] 
	FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans]
	INNER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin]
	ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX]
	WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate 
	AND [TblTrans].[Value] < 0
	AND [TblTransAddin].[PayType] = 2
-- بازپرداخت های كارتخوان
UNION ALL SELECT N'بازپرداخت های كارتخوان' AS [Title] , SUM(ABS([TblTrans].[Value])) AS [Value] 
	FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans]
	INNER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin]
	ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX]
	WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate 
	AND [TblTrans].[Value] < 0
	AND [TblTransAddin].[PayType] = 3
-- مجموع بدهكاری
UNION ALL SELECT N'مجموع بدهی ها به بیماران' AS [Title] , SUM(ABS([RefList].[RemainValue])) AS [Value]
FROM [ImagingSystem].[Referrals].[List] AS [RefList]
WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate
AND [RefList].[RemainValue] < 0
-- مجموع هزینه ها
UNION ALL SELECT N'هزینه: "' + [TblCD].[Name] + '"' AS [Title] , SUM(ABS([RefCD].[Value])) AS [Value]
FROM [ImagingSystem].[Accounting].[RefCostsAndDiscounts] AS [RefCD]
INNER JOIN [ImagingSystem].[Accounting].[CostsAndDiscountsTypes] AS [TblCD]
ON [TblCD].[ID] = [RefCD].[CostIXOrDiscountIX]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList]
ON [RefList].[ID] = [RefCD].[ReferralIX]
WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate
AND [TblCD].[IsCost] = 1
GROUP BY [TblCD].[Name]
-- ==============================
-- ==============================
-- ==============================
-- بخش دوم درآمدهای ثبت شده بر اساس طبقه بندی های خدمات را نمایش می دهد. این بخش مستقل از مطالبات می باشد
-- دریافتهای نقدی
SELECT N'دریافتهای نقدی' AS [Title] , SUM([TblTrans].[Value]) AS [Value]
	FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans]
	LEFT OUTER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin]
	ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX]
	WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate 
	AND [TblTrans].[Value] > 0
	AND [TblTransAddin].[RefTransactionIX] IS NULL
-- دریافتهای چك
UNION ALL SELECT N'دریافتهای چك' AS [Title] , SUM([TblTrans].[Value]) AS [Value] 
	FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans]
	INNER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin]
	ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX]
	WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate 
	AND [TblTrans].[Value] > 0
	AND [TblTransAddin].[PayType] = 1
-- دریافتهای فیش
UNION ALL SELECT N'دریافتهای فیش' AS [Title] , SUM([TblTrans].[Value]) AS [Value] 
	FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans]
	INNER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin]
	ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX]
	WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate 
	AND [TblTrans].[Value] > 0
	AND [TblTransAddin].[PayType] = 2
-- دریافتهای كارتخوان
UNION ALL SELECT N'دریافتهای كارتخوان' AS [Title] , SUM([TblTrans].[Value]) AS [Value] 
	FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans]
	INNER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin]
	ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX]
	WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate 
	AND [TblTrans].[Value] > 0
	AND [TblTransAddin].[PayType] = 3
-- درآمد طبقه بندی های مختلف
UNION ALL SELECT N'درآمد طبقه بندی: "' + [TblCatList].[Name] + '"' AS [Title] , 
	SUM([RefServ].[PatientPayablePrice] + ISNULL([RefServ].[Ins1PartPrice] , 0) + ISNULL([RefServ].[Ins2PartPrice] , 0)) AS [Value]
FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServ]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList]
ON [RefList].[ID] = [RefServ].[ReferralIX]
INNER JOIN [ImagingSystem].[Services].[List] AS [TblServList]
ON [TblServList].[ID] = [RefServ].[ServiceIX]
LEFT OUTER JOIN [ImagingSystem].[Services].[Categories] AS [TblCatList]
ON [TblCatList].[ID] = [TblServList].[CategoryIX]
WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate 
AND [RefServ].[IsActive] = 1
GROUP BY [TblCatList].[Name]
-- مجموع طلبكاری
UNION ALL SELECT N'مجموع طلب ها از بیماران' AS [Title] , SUM([RefList].[RemainValue]) AS [Value]
FROM [ImagingSystem].[Referrals].[List] AS [RefList]
WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate
AND [RefList].[RemainValue] > 0

-- نخفیف ها
UNION ALL SELECT N'تخفیف: "' + [TblCD].[Name] + '"' AS [Title] , SUM([RefCD].[Value]) AS [Value]
FROM [ImagingSystem].[Accounting].[RefCostsAndDiscounts] AS [RefCD]
INNER JOIN [ImagingSystem].[Accounting].[CostsAndDiscountsTypes] AS [TblCD]
ON [TblCD].[ID] = [RefCD].[CostIXOrDiscountIX]
INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList]
ON [RefList].[ID] = [RefCD].[ReferralIX]
WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate
AND [TblCD].[IsCost] = 0
GROUP BY [TblCD].[Name]
