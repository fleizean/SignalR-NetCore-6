USE SignalRDB;
GO

CREATE TRIGGER SumMoneyCases
ON Orders
AFTER UPDATE
AS
Declare @Status bit
Declare @TotalPrice decimal(18, 2)
SELECT @Status=Status FROM inserted
SELECT @TotalPrice=TotalPrice FROM inserted
if(@Status = 0)
BEGIN
UPDATE MoneyCases SET TotalAmount=TotalAmount + @TotalPrice 
END;
ELSE IF (@Status = 1)
BEGIN
UPDATE MoneyCases SET TotalAmount=TotalAmount - @TotalPrice
END;
GO
