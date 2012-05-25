EXEC ('USE MASTER');
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
DECLARE @BaseDbBackupPath1 NVARCHAR(4000);
SET @BaseDbBackupPath1 = 'C:\DbBackup\BACK-PAT.BAK';
DECLARE @BaseDbBackupPath2 NVARCHAR(4000);
SET @BaseDbBackupPath2 = 'C:\DbBackup\BACK-IMG.BAK';
DECLARE @TargetDbFolder NVARCHAR(4000);
SET @TargetDbFolder = 'C:\DbBackup\'; -- آدرس پوشه ی بانك اطلاعات جانبی
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
EXECUTE ('RESTORE DATABASE [PatientsSystem] FROM  DISK = N''' + @BaseDbBackupPath1 + 
''' WITH  FILE = 1,  MOVE N''PatientsSystem_Data'' TO N''' + @TargetDbFolder + 'PatientsSystem.mdf'',  
MOVE N''PatientsSystem_Log'' TO N''' + @TargetDbFolder + 'PatientsSystem_Log.LDF'',  NOUNLOAD,  REPLACE,  STATS = 50');
EXECUTE ('RESTORE DATABASE [ImagingSystem] FROM  DISK = N''' + @BaseDbBackupPath2 + 
''' WITH  FILE = 1,  MOVE N''ImagingSystem_Data'' TO N''' + @TargetDbFolder + 'ImagingSystem.mdf'',  
MOVE N''ImagingSystem_Log'' TO N''' + @TargetDbFolder + 'ImagingSystem_Log.LDF'',  NOUNLOAD,  REPLACE,  STATS = 50');
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- از این قسمت به بعد حذف اطلاعات صورت میگیرد
-- اگر نمی خواهید اطلاعاتی حذف شود از این خط به بعد را پاك كنید
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
DECLARE @Percent NVARCHAR(3);
SET @Percent = '90'; -- درصد حذف بیماران
DECLARE @Cursor CURSOR;
SET @Cursor = CURSOR FOR SELECT CAST(YEAR([RegisterDate]) AS NVARCHAR(4)) + '-' +
	CAST(MONTH([RegisterDate]) AS NVARCHAR(2)) + '-' +
	CAST(DAY([RegisterDate]) AS NVARCHAR(2))
	FROM [ImagingSystem].[Referrals].[List]
	GROUP BY CAST(YEAR([RegisterDate]) AS NVARCHAR(4)) + '-' +
	CAST(MONTH([RegisterDate]) AS NVARCHAR(2)) + '-' +
	CAST(DAY([RegisterDate]) AS NVARCHAR(2));
-- MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
OPEN @Cursor;
DECLARE @Date NVARCHAR(12);
FETCH NEXT FROM @Cursor INTO @Date;	
DECLARE @Command NVARCHAR(4000);
EXEC (@Command);	 
WHILE @@FETCH_STATUS = 0
BEGIN
	FETCH NEXT FROM @Cursor INTO @Date;	
	SET @Command = 'DELETE TOP (' + @Percent + ') PERCENT ' + 
		'FROM [ImagingSystem].[Referrals].[List] ' + 
		'WHERE CAST(YEAR([RegisterDate]) AS NVARCHAR(4)) + ''-'' + ' +
		'CAST(MONTH([RegisterDate]) AS NVARCHAR(2)) + ''-'' + ' + 
		'CAST(DAY([RegisterDate]) AS NVARCHAR(2)) = ''' + @Date + ''' AND [Ins1IX] IS NULL'
	EXEC (@Command);	 
END
CLOSE @Cursor;
DEALLOCATE @Cursor;
-- MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
-- دستور برای حذف مدارك در صورت نیاز
DELETE FROM [ImagingSystem].[Referrals].[RefDocuments];