USE [master]
GO
IF EXISTS(SELECT * FROM sys.sysdatabases WHERE name = 'Test')
BEGIN
	DROP DATABASE [Test]
END
GO
CREATE DATABASE [Test]
GO
USE [Test]
GO
CREATE TABLE [dbo].[Message]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Content] NVARCHAR(300) NOT NULL
)
GO
INSERT INTO [Message]([Content])
VALUES('The message content 1')

INSERT INTO [Message]([Content])
VALUES('The message content 2')

INSERT INTO [Message]([Content])
VALUES('The message content 3')

INSERT INTO [Message]([Content])
VALUES('The message content 4')

INSERT INTO [Message]([Content])
VALUES('The message content 5')