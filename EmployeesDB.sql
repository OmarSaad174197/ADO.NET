--CREATE DATABASE EmployeeDB;
--GO

USE EmployeeDB;
GO

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DeptNumber INT,
    DeptName NVARCHAR(50)
);
