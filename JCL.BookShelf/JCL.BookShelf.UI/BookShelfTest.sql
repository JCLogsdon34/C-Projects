USE MASTER
GO

DROP DATABASE BookShelfTest
GO

CREATE DATABASE BookShelfTest
GO

USE BookShelfTest
GO
 
CREATE TABLE Book (
	BookID int PRIMARY KEY IDENTITY(1,1),
	Title varchar(250) NOT NULL,
	Author varchar(150) NOT NULL,
	Publisher varchar(150) NOT NULL,
	ReleaseDate int NOT NULL
)
GO

SET IDENTITY_INSERT AccountType ON;
GO
 
INSERT INTO Book(BookID, Title, Author, Publisher, ReleaseDate)
VALUES (1, 'Shepherd Cycle','James Hoggs','Edinburgh',1756),
(2, 'Kidnapped!','Robert Lewis Stevenson','Random House',1795),
(3, 'Border Ballads','Sir Walter Scott','Clarke Magazine',1792),
(4, 'Weaver Poems','James Orr','Belfast Publishing',1793),
(5, 'Poems','Robert Burns','Edinburgh University Press',1784);
 
