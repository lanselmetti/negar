USE MASTER;
GO
-- BACKUP Databases:
BACKUP DATABASE [PatientsSystem]
TO  DISK = N'C:\Projects\Negar\3.Database\1.Db.Backup\PatientsSystem 1.Bak'
WITH NOFORMAT, INIT, NAME = N'PatientsSystem-Full Database Backup', 
SKIP, NOREWIND, NOUNLOAD, STATS = 25;
GO
BACKUP DATABASE [ImagingSystem]
TO  DISK = N'C:\Projects\Negar\3.Database\1.Db.Backup\ImagingSystem 1.Bak' 
WITH NOFORMAT, INIT,  NAME = N'ImagingSystem-Full Database Backup', 
SKIP, NOREWIND, NOUNLOAD, STATS = 25;
GO
BACKUP DATABASE [PACS]
TO  DISK = N'C:\Projects\Negar\3.Database\1.Db.Backup\PACS 1.Bak' 
WITH NOFORMAT, INIT,  NAME = N'PACS-Full Database Backup', 
SKIP, NOREWIND, NOUNLOAD, STATS = 25;
GO
SELECT 'Backup Finished';