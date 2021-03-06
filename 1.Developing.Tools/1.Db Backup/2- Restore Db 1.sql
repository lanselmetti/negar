USE MASTER;
GO
-- RESTORE Databases:
RESTORE DATABASE [PatientsSystem] 
FROM DISK = N'C:\Projects\Negar\3.Database\1.Db.Backup\PatientsSystem 1.Bak' 
WITH FILE = 1, 
MOVE N'PatientsSystem' TO N'C:\Databases\PatientsSystem.mdf', 
MOVE N'PatientsSystem_log' TO N'C:\Databases\PatientsSystem_Log.ldf',
NOUNLOAD,  REPLACE,  STATS = 25
GO
RESTORE DATABASE [ImagingSystem] 
FROM DISK = N'C:\Projects\Negar\3.Database\1.Db.Backup\ImagingSystem 1.Bak' 
WITH FILE = 1, 
MOVE N'ImagingSystem' TO N'C:\Databases\ImagingSystem.mdf', 
MOVE N'ImagingSystem_log' TO N'C:\Databases\ImagingSystem_Log.ldf',
NOUNLOAD,  REPLACE,  STATS = 25
GO
RESTORE DATABASE [PACS] 
FROM DISK = N'C:\Projects\Negar\3.Database\1.Db.Backup\PACS 1.Bak' 
WITH FILE = 1, 
MOVE N'PACS' TO N'C:\Databases\PACS.mdf', 
MOVE N'PACS_log' TO N'C:\Databases\PACS_Log.ldf',
NOUNLOAD,  REPLACE,  STATS = 25
GO
SELECT 'Restore Finished';