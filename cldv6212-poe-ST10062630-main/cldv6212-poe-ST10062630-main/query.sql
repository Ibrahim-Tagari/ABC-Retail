CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PhoneNumber NVARCHAR(15),
    Address NVARCHAR(255),
    CreatedDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50),
    Price DECIMAL(10, 2) NOT NULL,
    StockQuantity INT DEFAULT 0,
    CreatedDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    ProductID INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    Quantity INT NOT NULL,
    TotalAmount DECIMAL(10, 2),  -- Make this a regular column
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TRIGGER trg_CalculateTotalAmount
ON Orders
AFTER INSERT
AS
BEGIN
    UPDATE Orders
    SET TotalAmount = i.Quantity * p.Price
    FROM Orders o
    INNER JOIN inserted i ON o.OrderID = i.OrderID
    INNER JOIN Products p ON i.ProductID = p.ProductID;
END;

    
SELECT * FROM Customers;
SELECT * FROM Products;
SELECT * FROM Orders;
