DROP DATABASE BookShelfTest
GO

CREATE DATABASE BookShelfTest
GO

USE BookShelfTest
GO

CREATE TABLE Author (
	authorID int PRIMARY KEY IDENTITY(1,1),
	authorName varchar(250) NOT NULL,
	authorInstitution varchar(150) NOT NULL,
)
GO

CREATE TABLE Publisher (
	pubID int PRIMARY KEY IDENTITY(1,1),
	publisherName varchar(250) NOT NULL,
)
GO

CREATE TABLE Book (
	bookID int PRIMARY KEY IDENTITY(1,1),
	Title varchar(250) NOT NULL,
	Author varchar(150) NOT NULL,
	Publisher varchar(150) NOT NULL,
	ReleaseDate int NOT NULL
)
GO
