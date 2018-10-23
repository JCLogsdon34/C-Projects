USE MASTER
GO

DROP DATABASE BookShelf
GO

CREATE DATABASE BookShelf
GO

USE BookShelf
GO


CREATE TABLE Book (
	bookID int PRIMARY KEY IDENTITY(1,1),
	Title varchar(250) NOT NULL,
	Author varchar(150) NOT NULL,
	Publisher varchar(150) NOT NULL,
	ReleaseDate int NOT NULL
)
GO

SET IDENTITY_INSERT Book ON;
GO
