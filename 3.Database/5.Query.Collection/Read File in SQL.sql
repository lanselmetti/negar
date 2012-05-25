-- ŒÊ«‰œ‰ «“ Â«—œ ”—Ê—
DECLARE @TempBinary VARBINARY(MAX);
SET @TempBinary = (SELECT * FROM OPENROWSET (BULK N'C:\bootlog.txt', SINGLE_BLOB) AS MyFile)
-- ‰Ê‘ ‰ «“ ÃœÊ· „Êﬁ 
EXECUTE XP_CMDSHELL 
'BCP "SELECT @TempBinary" QUERYOUT "C:\NewFile.txt" -S SAYID-PC\SQLDEVELOPER -T -n'
EXECUTE XP_CMDSHELL 
'BCP "(SELECT * FROM OPENROWSET (BULK N''C:\bootlog.txt'', SINGLE_BLOB) AS MyFile)" QUERYOUT "C:\NewFile.txt" -S SAYID-PC\SQLDEVELOPER -T -n'