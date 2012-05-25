DECLARE @LocaleName NVARCHAR(50)
DECLARE @EnglishName NVARCHAR(50)
DECLARE @IsFirstName BIT

SET @LocaleName = N'باقری'
SET @EnglishName = 'Bagheri'
SET @IsFirstName = 'true'

IF EXISTS(SELECT [LocaleName] FROM [PatientsSystem].[Patients].[NamesBank] 
WHERE [LocaleName] = @LocaleName AND [IsFirstName] = @IsFirstName)

BEGIN
IF EXISTS(SELECT [LocaleName] FROM [PatientsSystem].[Patients].[NamesBank] 
WHERE [LocaleName] = @LocaleName AND [IsFirstName] =@IsFirstName AND 
	([EnglishName] IS NULL OR [EnglishName]  = ''))

UPDATE [PatientsSystem].[Patients].[NamesBank]
SET [EnglishName] = @EnglishName WHERE [LocaleName] = @LocaleName;
END
ELSE INSERT INTO [PatientsSystem].[Patients].[NamesBank] ([LocaleName] ,[EnglishName] ,[IsFirstName]) 
VALUES (@LocaleName, @EnglishName ,@IsFirstName)