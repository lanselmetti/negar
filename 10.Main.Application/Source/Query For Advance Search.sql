SELECT ROW_NUMBER() OVER(ORDER BY [TblPatients].[ID] , [TblRefList].[ID] ASC) AS [ردیف] ,
[TblPatients].[ID] AS [PatientListID] ,
[TblPatients].[PatientID] AS [شماره بیمار] ,
ISNULL([TblPatients].[FirstName] + ' ' , '') + [TblPatients].[LastName] AS [نام بیمار] ,
CASE [TblPatients].[IsMale] WHEN 0 THEN 'زن' WHEN 1 THEN 'مرد' ELSE NULL END AS [جنسیت] ,
[TblPatients].[BirthDate] AS [تاریخ تولد]
--, (SELECT [TblJobs].[Title] FROM [PatientsSystem].[Patients].[Jobs] AS [TblJobs] 
--	WHERE [TblPatDetails].[JobIX] = [TblJobs].[ID]) AS [شغل]
--, (SELECT [TblCities].[Name] FROM [PatientsSystem].[Locations].[Cities] AS [TblCities] 
--	WHERE [TblPatDetails].[CityIX] = [TblCities].[ID]) AS [شهر]
--, (SELECT ISNULL([TblUsers].[FirstName] + ' ' , '') + [TblUsers].[LastName] 
--	FROM [PatientsSystem].[Security].[Users] AS [TblUsers] 
--	WHERE [TblRefList].[AdmitterIX] = [TblUsers].[ID]) AS [كاربر پذیرش كننده]
--, (SELECT ISNULL([TblRefPhys].[FirstName] + ' ' , '') + [TblRefPhys].[LastName] 
--	FROM [PatientsSystem].[Clinic].[RefPhysicians] AS [TblRefPhys] 
--	WHERE [TblRefList].[ReferPhysicianIX] = [TblRefPhys].[ID]) AS [پزشك درخواست كننده]
--, (SELECT [TblRefStatus].[Title] FROM [ImagingSystem].[Referrals].[Status] AS [TblRefStatus] 
--	WHERE [TblRefList].[ReferStatusIX] = [TblRefStatus].[ID]) AS [وضعیت مراجعه]
--, (SELECT [TblClinicIns].[Name] 	FROM [PatientsSystem].[Clinic].[Insurances] AS [TblClinicIns] 
--	WHERE [TblRefList].[Ins1IX] = [TblClinicIns].[ID]) AS [بیمه اول]
--, (SELECT [TblDocTypes].[Title] FROM [ImagingSystem].[Documents].[Type] AS [TblDocTypes] 
--	WHERE [TblRefDocs].[TypeIX] = [TblDocTypes].[ID]) AS [نوع مدرك]
--, (SELECT ISNULL([TblDocPhys].[FirstName] + ' ' , '') + [TblDocPhys].[LastName]
--	FROM [ImagingSystem].[Referrals].[Performers] AS [TblDocPhys]
--	WHERE [TblRefDocs].[ReportPhysicianIX] = [TblDocPhys].[ID]) AS [پزشك گزارش كننده مدرك]
--, (SELECT ISNULL([TblUsers].[FirstName] + ' ' , '') + [TblUsers].[LastName] 
--	FROM [PatientsSystem].[Security].[Users] AS [TblUsers] 
--	WHERE [TblRefDocs].[TypistIX] = [TblUsers].[ID]) AS [كاربر ثبت كننده مدرك]
--, (SELECT TOP 1 [TblServiceList].[Code] FROM [ImagingSystem].[Services].[List] AS [TblServiceList]
--	WHERE [TblServiceList].[ID] = [TblRefServices].[ServiceIX]) AS [كد خدمت]
--, (SELECT TOP 1 [TblServiceList].[Name] FROM [ImagingSystem].[Services].[List] AS [TblServiceList]
--	WHERE [TblServiceList].[ID] = [TblRefServices].[ServiceIX]) AS [نام خدمت]
, (SELECT TOP 1 [TblServiceCat].[Name] FROM [ImagingSystem].[Services].[Categories] AS [TblServiceCat]
	WHERE [TblServiceCat].[ID] = [TblRefServices].[ServiceIX]) AS [طبقه بندی خدمت]
, [TblRefServices].[Quantity] AS [تعداد خدمت]
, (SELECT TOP 1 ISNULL([TblServicePerformer].[FirstName] + ' ' , '') + [TblServicePerformer].[LastName] 
	FROM [ImagingSystem].[Referrals].[Performers] AS [TblServicePerformer]
	WHERE [TblServicePerformer].[ID] = [TblRefServices].[ExpertIX]) AS [كارشناس خدمت]
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- انتخاب جداول
-- جدول بیماران
FROM [PatientsSystem].[Patients].[List] AS [TblPatients]
-- ======================================
-- جدول جزئیات اطلاعات بیماران
LEFT OUTER JOIN [PatientsSystem].[Patients].[Details] AS [TblPatDetails]
ON [TblPatients].[ID] = [TblPatDetails].[PatientListIX]
-- ======================================
-- جدول اطلاعات اضافی بیماران
LEFT OUTER JOIN [ImagingSystem].[Referrals].[PatAdditionalData] AS [TblPatAddinData]
ON [TblPatAddinData].[PatientIX] = [TblPatients].[ID]
-- ======================================
-- جدول اطلاعات مراجعات تصویربرداری بیماران
LEFT OUTER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] 
ON [TblRefList].[PatientIX] = [TblPatients].[ID]
-- ======================================
-- جدول اطلاعات مراجعات بیماران
LEFT OUTER JOIN [ImagingSystem].[Referrals].[RefAdditionalData] AS [TblRefAddinData]
ON [TblRefAddinData].[ReferralIX] = [TblRefList].[ID]
-- ======================================
-- جدول اطلاعات خدمات مراجعات بیماران
LEFT OUTER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefServices]
ON [TblRefList].[ID] = [TblRefServices].[ReferralIX]
-- ======================================
---- اطلاعات مدارك مراجعات بیماران
--LEFT OUTER JOIN [ImagingSystem].[Referrals].[RefDocuments] AS [TblRefDocs]
--ON [TblRefList].[ID] = [TblRefDocs].[RefIX]