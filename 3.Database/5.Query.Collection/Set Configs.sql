SELECT * FROM sys.configurations
ORDER BY name ;
EXEC [master].[dbo].[sp_configure] 'show advanced option', 1;
RECONFIGURE;
EXEC [master].[dbo].[sp_configure] 'remote access', 1;
RECONFIGURE;
EXEC [master].[dbo].[sp_configure] 'remote admin connections', 1;
RECONFIGURE;
EXEC [master].[dbo].[sp_configure] 'xp_cmdshell', 1;
RECONFIGURE;