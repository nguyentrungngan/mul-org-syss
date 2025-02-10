
CREATE PROCEDURE GetMonthlySalesReport
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        OrderID,
        CustomerName,
        ProductName,
        Quantity,
        TotalPrice,
        OrderDate
    FROM Sales
    WHERE OrderDate BETWEEN @StartDate AND @EndDate
    ORDER BY OrderDate ASC;
END;
GO


CREATE PROCEDURE GetInventoryReport
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ProductID,
        ProductName,
        Category,
        StockQuantity,
        ReorderLevel
    FROM Inventory
    WHERE StockQuantity <= ReorderLevel
    ORDER BY StockQuantity ASC;
END;
GO


CREATE PROCEDURE GetCustomerByRegion
    @Region NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CustomerID,
        CustomerName,
        ContactName,
        Region,
        Phone
    FROM Customers
    WHERE Region = @Region;
END;
GO
