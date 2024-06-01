USE SignalRDB;
GO

CREATE TRIGGER UpdateOrderTotalPrice
ON OrderDetails
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE Orders
    SET TotalPrice = (
        SELECT SUM(od.TotalPrice)
        FROM OrderDetails od
        WHERE od.OrderID = Orders.OrderID
    )
    FROM Orders
    WHERE OrderID IN (
        SELECT DISTINCT OrderID FROM inserted
        UNION
        SELECT DISTINCT OrderID FROM deleted
    );
END;
GO
