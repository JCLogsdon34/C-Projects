USE MASTER
GO

DROP DATABASE BankAccountTest
GO

CREATE DATABASE BankAccountTest
GO

USE BankAccountTest
GO

CREATE TABLE AccountType (
	AccountTypeID int PRIMARY KEY IDENTITY(1,1),
	AccountTypeName varchar(250) NOT NULL,
)
GO

CREATE TABLE Balance (
	BalanceID int PRIMARY KEY IDENTITY(1,1),
	Balance decimal(9,2) NOT NULL,
)
GO

CREATE TABLE Account (
	AccountID int PRIMARY KEY IDENTITY(1,1)
	AccountName varchar(250) NOT NULL,
	BalanceID int Foreign KEY REFERENCES Balance(BalanceID) NOT NULL,
	AccountTypeID int FOREIGN KEY REFERENCES AccountType(AccountTypeID) NOT NULL
)
GO

SET IDENTITY_INSERT AccountType ON;
GO
 
INSERT INTO AccountType(AccountTypeID, AccountTypeName)
VALUES (1, 'Free'),
(2, 'Basic'),
(3, 'Premium')
 
SET IDENTITY_INSERT AccountType OFF;
GO

SET IDENTITY_INSERT Balance ON;
GO
 
INSERT INTO Balance(BalanceID, balance)
VALUES (1, 2000.00),
(2, 3000.00),
(3, 2.00)
 
SET IDENTITY_INSERT Balance OFF;
GO

SET IDENTITY_INSERT AccountType ON;
GO

INSERT INTO Account (AccountName, BalanceID, AccountTypeID)
VALUES ('Simon Kenton', 1, 2),
('John Adair', 2, 2),
('James Orr', 2, 3)

SET IDENTITY_INSERT AccountType OFF;
GO