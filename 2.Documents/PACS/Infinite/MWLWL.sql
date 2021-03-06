/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [MWL_KEY]
      ,[TRIGGER_DTTM]
      ,[CHARACTER_SET] -- ISO_IR 100
      ,[SCHEDULED_AETITLE] -- ANY
      ,[SCHEDULED_MODALITY] -- e.g. CR - CT ,...
      ,[SCHEDULED_STATION] -- ??
      ,[SCHEDULED_LOCATION] -- ??
      ,[SCHEDULED_PROC_ID] -- ??
      ,[SCHEDULED_PROC_DESC] -- ??
      ,[SCHEDULED_ACTION_CODES] -- ??
      ,[SCHEDULED_PROC_STATUS] -- ??
      ,[REQUESTED_PROC_ID] -- ??
      ,[REQUESTED_PROC_DESC] -- ??
      ,[REQUESTED_PROC_CODES] -- ??
      ,[STUDY_INSTANCE_UID] -- ??
      ,[PROC_PLACER_ORDER_NO] -- ??
      ,[ACCESSION_NO] -- ??
      ,[ATTEND_DOCTOR] -- ??
      ,[CONSULT_DOCTOR] -- ??
      ,[REQUEST_DOCTOR] -- ??
      ,[REFER_DOCTOR] -- ??
      ,[REQUEST_DEPARTMENT] -- ??
      ,[PATIENT_NAME]
      ,[PATIENT_ID]
      ,[PATIENT_BIRTH_DATE]
      ,[PATIENT_SEX]
  FROM [PACS].[dbo].[MWLWL]