USE PatientsSystem;
GO
IF OBJECT_ID ( 'Clinic.SP_RebuildIndex', 'P' ) IS NOT NULL
    DROP PROCEDURE [Clinic].[SP_RebuildIndex];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/10/20
-- Last Modified: 1388/10/20
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Clinic].[SP_RebuildIndex]
@ApplicationDb NVARCHAR(50)
,@TableFullName NVARCHAR(100)
,@IndexName NVARCHAR(100)
WITH ENCRYPTION
AS
	BEGIN TRY
		EXECUTE ('ALTER INDEX ' + @IndexName + ' ON ' + 
			@ApplicationDb + '.' + @TableFullName + 
			' REORGANIZE WITH (LOB_COMPACTION = ON);')
		EXECUTE ('ALTER INDEX ' + @IndexName + ' ON ' + 
			@ApplicationDb + '.' + @TableFullName + 
			' REBUILD WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF,' + 
			' ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, ' + 
			' SORT_IN_TEMPDB = OFF, ONLINE = OFF);')
	END TRY
	BEGIN CATCH
		PRINT 'ERROR';
	END CATCH
GO
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
-- EXEC [Clinic].[SP_RebuildIndex] 'PatientsSystem' , 'Patients.Name'
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@