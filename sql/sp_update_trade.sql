CREATE OR ALTER PROCEDURE sp_update_trade
@TradeID INT,
@Value FLOAT,
@ClientSector VARCHAR(20)
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

	UPDATE Trade SET Value = @Value, ClientSector = @ClientSector, Category = @Category WHERE Id = @TradeID;
END;