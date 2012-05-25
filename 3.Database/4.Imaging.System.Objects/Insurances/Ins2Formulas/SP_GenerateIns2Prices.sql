USE ImagingSystem;
GO
IF OBJECT_ID ( 'Insurances.SP_GenerateIns2Prices', 'P' ) IS NOT NULL
    DROP PROCEDURE [Insurances].[SP_GenerateIns2Prices];
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
-- Created Date: 1388/4/10
-- Last Modified: 1388/8/24
-- Created By: Saeed Pournejati
-- Last Modified By: Saeed Pournejati
-- روالی برای تولید 3 قیمت برای یك خدمت در یك بیمه دوم
-- @@@@@@@@@@@@@@@@@@@@@@@
CREATE PROCEDURE [Insurances].[SP_GenerateIns2Prices]
@Ins2ID SMALLINT , 
@ServiceID SMALLINT ,
@X1Ins1Price INT = NULL ,
@X2Ins1Part INT = NULL ,
@X3Ins1PatientPrice INT = NULL ,
@X4Ins1PatientPayable INT = NULL ,
@X5Ins1Limit INT = NULL ,
@X6Ins1PatientPercent INT = NULL ,
@Y1Ins2Limit INT = NULL ,
@Result1 INT = NULL OUTPUT,
@Result2 INT = NULL OUTPUT,
@Result3 INT = NULL OUTPUT
WITH ENCRYPTION
AS
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	-- OOOOOOOO Ins2 Price Calculation OOOOOOOO
	DECLARE @Ins2Price_Syntax NVARCHAR(500)
	SET @Ins2Price_Syntax = 	
		(SELECT [Tbl2].Ins2Price FROM [ImagingSystem].[Insurances].[List] AS [Tbl1]
		INNER JOIN [ImagingSystem].[Insurances].[Ins2Formulas] AS [Tbl2]
		ON [Tbl1].[Ins2FormulasIX] = [Tbl2].[ID]
		WHERE [Tbl1].[InsuranceIX] = @Ins2ID)
	-- +++++++++++++++++++++++++++++++++++
	DECLARE @PriceFree INT;
	SET @PriceFree = 	
		ISNULL((SELECT TOP 1 [PriceFree] FROM [ImagingSystem].[Services].[List] WHERE ID = @ServiceID) , 0);
	-- +++++++++++++++++++++++++++++++++++
	DECLARE @PriceGov INT;
	SET @PriceGov = 
		ISNULL((SELECT PriceGov FROM [ImagingSystem].[Services].[List] WHERE [ID] = @ServiceID) , 0);
	-- +++++++++++++++++++++++++++++++++++
	SET @X1Ins1Price = ISNULL(@X1Ins1Price , 0);
	SET @X2Ins1Part = ISNULL(@X2Ins1Part , 0);
	SET @X3Ins1PatientPrice = ISNULL(@X3Ins1PatientPrice , 0);
	SET @X4Ins1PatientPayable = ISNULL(@X4Ins1PatientPayable , 0);
	SET @X5Ins1Limit = ISNULL(@X5Ins1Limit , 0);
	SET @X6Ins1PatientPercent = ISNULL(@X6Ins1PatientPercent , 0);
	SET @Y1Ins2Limit = ISNULL(@Y1Ins2Limit , 0);
	--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	SET @Ins2Price_Syntax = 
		REPLACE(@Ins2Price_Syntax , '1FreePrice' , CONVERT(NVARCHAR(10) , @PriceFree))
	SET @Ins2Price_Syntax = 
		REPLACE(@Ins2Price_Syntax , '2GovPrice' , CONVERT(NVARCHAR(10) , @PriceGov))	
	SET @Ins2Price_Syntax = 
		REPLACE(@Ins2Price_Syntax , 'X1Ins1Price' , CONVERT(NVARCHAR(10) , @X1Ins1Price))	
	SET @Ins2Price_Syntax = 
		REPLACE(@Ins2Price_Syntax , 'X2Ins1Part' , CONVERT(NVARCHAR(10) , @X2Ins1Part))	
	SET @Ins2Price_Syntax = 
		REPLACE(@Ins2Price_Syntax , 'X3Ins1PatientPrice' , CONVERT(NVARCHAR(10) , @X3Ins1PatientPrice))	
	SET @Ins2Price_Syntax = 
		REPLACE(@Ins2Price_Syntax , 'X4Ins1PatientPayable' , CONVERT(NVARCHAR(10) , @X4Ins1PatientPayable))	
	SET @Ins2Price_Syntax = 
		REPLACE(@Ins2Price_Syntax , 'X5Ins1Limit' , CONVERT(NVARCHAR(10) , @X5Ins1Limit))	
	SET @Ins2Price_Syntax = 
		REPLACE(@Ins2Price_Syntax , 'X6Ins1PatientPercent' , CONVERT(NVARCHAR(10) , @X6Ins1PatientPercent))
	SET @Ins2Price_Syntax = 
		REPLACE(@Ins2Price_Syntax , '@Y1Ins2Limit' , CONVERT(NVARCHAR(10) , @Y1Ins2Limit))	
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	-- OOOOOOOO Ins2 Part Calculation OOOOOOOO
	DECLARE @Ins2Part_Syntax NVARCHAR(500)
	SET @Ins2Part_Syntax = 
		(SELECT [Tbl2].[Ins2Part] FROM [ImagingSystem].[Insurances].[List] AS [Tbl1]
		INNER JOIN [ImagingSystem].[Insurances].[Ins2Formulas] AS [Tbl2]
		ON [Tbl1].[Ins2FormulasIX] = [Tbl2].[ID]
		WHERE [Tbl1].[InsuranceIX] = @Ins2ID)
	-- +++++++++++++++++++++++++++++++++++
	SET @Ins2Part_Syntax = REPLACE(@Ins2Part_Syntax , '1FreePrice' , CONVERT(NVARCHAR(10) , @PriceFree))
	-- +++++++++++++++++++++++++++++++++++
	SET @Ins2Part_Syntax = REPLACE(@Ins2Part_Syntax , '2GovPrice' , CONVERT(NVARCHAR(10) , @PriceGov))	
	-- +++++++++++++++++++++++++++++++++++
	SET @Ins2Part_Syntax = 
		REPLACE(@Ins2Part_Syntax, 'X1Ins1Price' , CONVERT(NVARCHAR(10) , @X1Ins1Price))	
	SET @Ins2Part_Syntax  = 
		REPLACE(@Ins2Part_Syntax , 'X2Ins1Part' , CONVERT(NVARCHAR(10) , @X2Ins1Part))	
	SET @Ins2Part_Syntax  = 
		REPLACE(@Ins2Part_Syntax , 'X3Ins1PatientPrice' , CONVERT(NVARCHAR(10) , @X3Ins1PatientPrice))	
	SET @Ins2Part_Syntax  = 
		REPLACE(@Ins2Part_Syntax  , 'X4Ins1PatientPayable' , CONVERT(NVARCHAR(10) , @X4Ins1PatientPayable))	
	SET @Ins2Part_Syntax = 
		REPLACE(@Ins2Part_Syntax  , 'X5Ins1Limit' , CONVERT(NVARCHAR(10) , @X5Ins1Limit))	
	SET @Ins2Part_Syntax  = 
		REPLACE(@Ins2Part_Syntax  , 'X6Ins1PatientPercent' , CONVERT(NVARCHAR(10) , @X6Ins1PatientPercent))
	SET @Ins2Part_Syntax = 
		REPLACE(@Ins2Part_Syntax  , '@Y1Ins2Limit' , CONVERT(NVARCHAR(10) , @Y1Ins2Limit))		
	-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	-- OOOOOOOO Patient Payable Calculation OOOOOOOO
	DECLARE @PatientPayable_Syntax NVARCHAR(500)	
	SET @PatientPayable_Syntax = 
		(SELECT [Tbl2].[PatientPayable]
		FROM [ImagingSystem].[Insurances].[List] AS [Tbl1] 
		INNER JOIN [ImagingSystem].[Insurances].[Ins2Formulas] AS [Tbl2]
		ON [Tbl1].[Ins2FormulasIX] = [Tbl2].[ID]
		WHERE [Tbl1].[InsuranceIX] = @Ins2ID)
	-- +++++++++++++++++++++++++++++++++++
	SET @PatientPayable_Syntax = 
		REPLACE(@PatientPayable_Syntax , '1FreePrice' , CONVERT(NVARCHAR(10) , @PriceFree))
	-- +++++++++++++++++++++++++++++++++++
	SET @PatientPayable_Syntax = 
		REPLACE(@PatientPayable_Syntax , '2GovPrice' , CONVERT(NVARCHAR(10) , @PriceGov))	
	-- +++++++++++++++++++++++++++++++++++
	SET @PatientPayable_Syntax  = 
		REPLACE(@PatientPayable_Syntax , 'X1Ins1Price' , CONVERT(NVARCHAR(10) , @X1Ins1Price))	
	SET @PatientPayable_Syntax  = 
		REPLACE(@PatientPayable_Syntax , 'X2Ins1Part' , CONVERT(NVARCHAR(10) , @X2Ins1Part))	
	SET @PatientPayable_Syntax  = 
		REPLACE(@PatientPayable_Syntax , 'X3Ins1PatientPrice' , CONVERT(NVARCHAR(10) , @X3Ins1PatientPrice))	
	SET @PatientPayable_Syntax  = 
		REPLACE(@PatientPayable_Syntax , 'X4Ins1PatientPayable' , CONVERT(NVARCHAR(10) , @X4Ins1PatientPayable))	
	SET @PatientPayable_Syntax  = 
		REPLACE(@PatientPayable_Syntax , 'X5Ins1Limit' , CONVERT(NVARCHAR(10) , @X5Ins1Limit))	
	SET @PatientPayable_Syntax  = 
		REPLACE(@PatientPayable_Syntax , 'X6Ins1PatientPercent' , CONVERT(NVARCHAR(10) , @X6Ins1PatientPercent))	
	SET @PatientPayable_Syntax  = 
		REPLACE(@PatientPayable_Syntax , '@Y1Ins2Limit' , CONVERT(NVARCHAR(10) , @Y1Ins2Limit))
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	DECLARE @Cursor CURSOR;
	SET @Cursor = CURSOR FOR SELECT [ColumnName]
		FROM [ImagingSystem].[Services].[AdditionalPriceColumns];
	DECLARE @Count INT;
	SET @Count = (SELECT COUNT(*) FROM [ImagingSystem].[Services].[AdditionalPriceColumns]);
	OPEN @Cursor;	
	WHILE @Count > 0
    BEGIN
		DECLARE @FieldName NVARCHAR(15)
		FETCH NEXT FROM @Cursor INTO @FieldName;
		DECLARE @FieldData INT;
		DECLARE @ParamDefinition NVARCHAR(100);
		SET @ParamDefinition = N'@FieldData INT OUTPUT';
		DECLARE @Query NVARCHAR(150)
		SET @Query = 'SET @FieldData = (SELECT TOP 1 ' + @FieldName + 
			' FROM [ImagingSystem].[Services].[AdditionalPriceData] WHERE [ServiceIX] = ' + 
			CONVERT(NVARCHAR(7) , @ServiceID) + ')';
		-- OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
		BEGIN TRY
			EXECUTE SP_EXECUTESQL @Query , @ParamDefinition , @FieldData = @FieldData OUTPUT;
		END TRY
		BEGIN CATCH
			IF @Result1 IS NULL SET @Result1 = 0;
			IF @Result2 IS NULL SET @Result2 = 0;
			IF @Result3 IS NULL SET @Result3 = 0;
			RETURN;
		END CATCH
		-- OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
		IF @FieldData IS NULL SET @FieldData = 0;
		SET @Ins2Price_Syntax = 
			REPLACE(@Ins2Price_Syntax , @FieldName , CONVERT(NVARCHAR(10) , @FieldData));
		SET @Ins2Part_Syntax = 
			REPLACE(@Ins2Part_Syntax , @FieldName , CONVERT(NVARCHAR(10) , @FieldData));
		SET @PatientPayable_Syntax = 
			REPLACE(@PatientPayable_Syntax , @FieldName , CONVERT(NVARCHAR(10) , @FieldData));
		SET @Count = @Count - 1;
	END
	CLOSE @Cursor;
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
	SET @Ins2Price_Syntax = 'SET @Result1 = ISNULL(' +  @Ins2Price_Syntax	 + ' , 0)'
	SET @Ins2Part_Syntax = 'SET @Result2 = ISNULL(' +  @Ins2Part_Syntax + ' , 0)'	
	SET @PatientPayable_Syntax = 'SET @Result3 = ISNULL(' +  @PatientPayable_Syntax + ' , 0)'
	-- OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
	BEGIN TRY
		SET @ParamDefinition = N'@Result1 INT OUTPUT'
		-- PRINT @Ins2Price_Syntax;
		EXECUTE SP_EXECUTESQL @Ins2Price_Syntax , @ParamDefinition, @Result1 = @Result1 OUTPUT;
		SET @ParamDefinition = N'@Result2 INT OUTPUT'
		-- PRINT @Ins2Part_Syntax;
		EXECUTE SP_EXECUTESQL @Ins2Part_Syntax, @ParamDefinition, @Result2 = @Result2 OUTPUT;
		SET @ParamDefinition = N'@Result3 INT OUTPUT'
		-- PRINT @PatientPayable_Syntax;
		EXECUTE SP_EXECUTESQL @PatientPayable_Syntax, @ParamDefinition, @Result3 = @Result3 OUTPUT;		
	END TRY
	BEGIN CATCH
		IF @Result1 IS NULL SET @Result1 = 0;
		IF @Result2 IS NULL SET @Result2 = 0;
		IF @Result3 IS NULL SET @Result3 = 0;
		RETURN;
	END CATCH
	-- OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
	IF @Result1 IS NULL SET @Result1 = 0;
	IF @Result2 IS NULL SET @Result2 = 0;
	IF @Result3 IS NULL SET @Result3 = 0;
GO
-- @@@@@@@@@@@@@@@@@@@@@@@
--DECLARE @Value1 INT , @Value2 INT , @Value3 INT;
--EXEC [Insurances].[SP_GenerateIns2Prices] 
--2 , -- @Ins2ID
--5 , -- @ServiceID
--1000 , -- @X1Ins1Price
--1000 , -- @X2Ins1Part
--1000 , -- @X3Ins1PatientPrice
--6500 ,  -- @X4Ins1PatientPayable
--1000 , -- @X5Ins1Limit
--1000 , -- @X6Ins1PatientPercent
--1000 ,  -- @Y1Ins2Limit
--@Value1 OUTPUT , @Value2 OUTPUT , @Value3 OUTPUT;
--SELECT @Value1 , @Value2 , @Value3
-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@