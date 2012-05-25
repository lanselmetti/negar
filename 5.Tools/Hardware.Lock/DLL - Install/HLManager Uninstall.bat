@Echo off
echo:
echo:
echo:
echo   NovinLock Driver and Library Remover 
echo:
echo:
echo       Unregistering library
regsvr32 %systemroot%\system32\HLManager.dll -u -s
echo       Removing Library
del %systemroot%\system32\HLManager.dll
echo:
echo   NovinLock has been removed !
pause