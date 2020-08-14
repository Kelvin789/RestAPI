IF DB_ID('UserAPI') IS NULL 
    CREATE DATABASE UserAPI

GO

CREATE TABLE [UserAPI].[dbo].[Users] (
    ID INT PRIMARY KEY IDENTITY,
	UserId INT NOT NULL,
    FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	Email NVARCHAR(320),
	Telephone NVARCHAR(15)
);

CREATE TABLE [UserAPI].[dbo].[Leaderboard] (
    ID INT PRIMARY KEY IDENTITY,
	UserId INT NOT NULL,
	Score INT,
	GamesPlayed INT
);