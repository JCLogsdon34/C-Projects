USE MASTER
GO

DROP DATABASE BankAccounts
GO

CREATE DATABASE BankAccounts
GO

USE BankAccounts
GO

CREATE TABLE AccountType (
	accountTypeID int PRIMARY KEY IDENTITY(1,1),
	accountTypeName varchar(250) NOT NULL,
)
GO

CREATE TABLE Balance (
	balanceID int PRIMARY KEY IDENTITY(1,1),
	balance decimal(9,2) NOT NULL,
)
GO

CREATE TABLE Account (
	accountID int PRIMARY KEY IDENTITY(1,1),
	accountName varchar(250) NOT NULL,
	balanceID int Foreign KEY REFERENCES Balance(balanceID) NOT NULL,
	accountTypeID int FOREIGN KEY REFERENCES AccountType(AccountTypeID) NOT NULL
)
GO

SET IDENTITY_INSERT AccountType ON;
GO
 
INSERT INTO AccountType(AccountTypeID, accountTypeName)
VALUES (1, 'Free'),
(2, 'Basic'),
(3, 'Premium')
 
SET IDENTITY_INSERT AccountType OFF;
GO