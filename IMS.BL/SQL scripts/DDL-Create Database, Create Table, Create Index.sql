USE master 
GO

CREATE DATABASE [InventoryManagementSystemDB];
GO

USE [InventoryManagementSystemDB];
GO

CREATE TABLE Products
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Quantity INT NOT NULL
);

CREATE UNIQUE INDEX Index_Product_Name ON [Products] ([Name]);

