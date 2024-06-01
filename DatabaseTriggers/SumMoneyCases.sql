USE SignalRDB;
GO

CREATE TRIGGER SumMoneyCases
ON Orders
AFTER UPDATE
AS
BEGIN
    Declare @MenuTableID int
    Declare @Status bit
    Declare @TotalPrice decimal(18, 2)

    SELECT @MenuTableID=MenuTableID, @TotalPrice=TotalPrice FROM inserted

    SELECT @Status = Status FROM MenuTables WHERE MenuTableID = @MenuTableID

    IF (@Status = 0)
    BEGIN
        UPDATE MoneyCases SET TotalAmount = TotalAmount + @TotalPrice 
    END
END;
GO
