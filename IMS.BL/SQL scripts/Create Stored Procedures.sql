USE [InventoryManagementSystemDB]
GO

CREATE PROCEDURE InsertProduct
    @Name VARCHAR(100),
    @Price DECIMAL(18, 2),
    @Quantity INT
AS
BEGIN
    INSERT INTO Products (Name, Price, Quantity)
    VALUES (@Name, @Price, @Quantity);
END;
GO

CREATE PROCEDURE GetAllProducts
AS
BEGIN
    SELECT * FROM Products;
END;
GO

CREATE PROCEDURE GetProductById
    @Id INT
AS
BEGIN
    SELECT * FROM Products WHERE Id = @Id;
END;
GO

CREATE PROCEDURE GetProductByName
    @Name VARCHAR(100)
AS
BEGIN
    SELECT * FROM [InventoryManagementSystemDB].[dbo].[Products] WHERE Name = @Name;
END;
GO

CREATE PROCEDURE UpdateProduct
    @Id INT,
    @Name VARCHAR(100),
    @Price DECIMAL(18, 2),
    @Quantity INT
AS
BEGIN
    UPDATE Products
    SET Name = @Name, Price = @Price, Quantity = @Quantity
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE DeleteProduct
    @Id INT
AS
BEGIN
    DELETE FROM Products WHERE Id = @Id;
END;
GO

