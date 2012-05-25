EXEC ('USE MASTER');
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
DECLARE @BaseDbBackupPath1 NVARCHAR(4000);
SET @BaseDbBackupPath1 = 'C:\DbBackup\BACK-PAT.BAK';
DECLARE @BaseDbBackupPath2 NVARCHAR(4000);
SET @BaseDbBackupPath2 = 'C:\DbBackup\BACK-IMG.BAK';
DECLARE @TargetDbFolder NVARCHAR(4000);
SET @TargetDbFolder = 'C:\DbBackup\'; -- آدرس پوشه ی بانك اطلاعات جانبی
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
EXECUTE ('BACKUP DATABASE [PatientsSystem] TO  DISK = N''' + @BaseDbBackupPath1 +
''' WITH NOFORMAT, INIT,  NAME = N''PatientsSystem-Full Database Backup'', ' + 
'SKIP, NOREWIND, NOUNLOAD,  STATS = 50');
EXECUTE ('BACKUP DATABASE [ImagingSystem] TO  DISK = N''' + @BaseDbBackupPath2 +
''' WITH NOFORMAT, INIT,  NAME = N''ImagingSystem-Full Database Backup'', ' + 
'SKIP, NOREWIND, NOUNLOAD,  STATS = 50');