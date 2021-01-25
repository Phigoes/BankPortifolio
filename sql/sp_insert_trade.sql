CREATE OR ALTER PROCEDURE sp_insert_trade
@Value FLOAT,
@ClientSector VARCHAR(20),
@TradeID INT OUTPUT
AS
SET NOCOUNT ON
BEGIN
	DECLARE @Category VARCHAR(20)

	IF (@Value < 1000000 AND @ClientSector = 'Public')
		BEGIN
			SET @Category = 'LOWRISK';
		END
	ELSE IF (@Value > 1000000 AND @ClientSector = 'Public')
		BEGIN
			SET @Category = 'MEDIUMRISK';
		END
	ELSE IF (@Value > 1000000 AND @ClientSector = 'Private')
		BEGIN
			SET @Category = 'MEDIUMRISK';
		END
	ELSE
		BEGIN
			SET @Category = 'UNKNOWNRISK';
		END

	INSERT INTO Trade (Value, ClientSector, Category) VALUES (@Value, @ClientSector, @Category);

	SET @TradeID = SCOPE_IDENTITY()
END