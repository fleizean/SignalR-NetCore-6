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

    SELECT @MenuTableID=MenuTableID, @TotalPrice=TotalPrice, @Status=Status FROM inserted

    IF (@Status = 1 AND @TotalPrice > 0)
    BEGIN
        UPDATE MoneyCases SET TotalAmount = TotalAmount + @TotalPrice 
        /* UPDATE Orders SET Status = 0 WHERE MenuTableID = @MenuTableID */
        INSERT INTO MoneyCaseHistories (Amount, TransactionType, TransactionDate)
        VALUES (@TotalPrice, 'ADD', GETDATE())
    END
END;
GO
