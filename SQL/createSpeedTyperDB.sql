/* Check if database already exists and delete it if it does exist*/
IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'SpeedTyperDB')
BEGIN
	DROP DATABASE SpeedTyperDB
	print '' print '*** dropping database SpeedTyperDB'
END
GO

print '' print '*** creating database SpeedTyperDB'
GO
CREATE DATABASE SpeedTyperDB
GO

print '' print '*** using database SpeedTyperDB'
GO
USE [SpeedTyperDB]
GO

print '' print '*** Creating Users Table'
GO
/* ***** Object:  Table [dbo].[Users]     ***** */
CREATE TABLE [dbo].[Users](
	[UserID] 		[int] IDENTITY (1,1)	NOT NULL,
	[UserName]		[varchar](20)			NOT NULL,
	[DisplayName]	[varchar](20)			NOT NULL,
	[PasswordHash]	[varchar](100)			NOT NULL DEFAULT '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	[TitleID]		[int]					NOT NULL DEFAULT 1,
	[Level]			[int]					NOT NULL DEFAULT 1,
	[CurrentXP]		[int]					NOT NULL DEFAULT 0,
	[XPToLevel]		[int]					NOT NULL DEFAULT 1000, -- Change default

	CONSTRAINT [pk_UserID] PRIMARY KEY([UserID] ASC),
	CONSTRAINT [ak_Username] UNIQUE ([Username] ASC)
)
GO

print '' print '*** Creating TestResults Table'
GO

CREATE TABLE [dbo].[TestResults](
	[TestResultID]	[int] IDENTITY(1,1) NOT NULL,
	[UserID]		[int] 				NOT NULL,
	[WPM]			[decimal](18,2)		NOT NULL,
	[SecondsElapsed][int]				NOT NULL,
	[DateTaken]		[datetime]			NOT NULL,
	
	CONSTRAINT [pk_TestResultID] PRIMARY KEY([TestResultID] ASC)
)
GO

print '' print '*** Creating UserAchievements Table'
GO

CREATE TABLE [dbo].[UserAchievements](
	[AchieveID]			[int]	NOT NULL,
	[UserID]			[int]	NOT NULL,
	[AccomplishDate]	[date]	NOT NULL,
)
GO

print '' print '*** Creating UserTitles Table'
GO

CREATE TABLE [dbo].[UserTitles](
	[TitleID]	[int]			NOT NULL,
	[TitleName]	[varchar](100)	NOT NULL,
	CONSTRAINT [pk_TitleID] PRIMARY KEY([TitleID] ASC)
)
GO

print '' print '*** Creating TestData Table'
GO

CREATE TABLE [dbo].[TestData](
	[TestID]		[int]				NOT NULL,
	[TestDataText]	[varchar](1000)		NOT NULL,
	[DataSource]	[varchar](500)		NOT NULL,
	CONSTRAINT [pk_TestID] PRIMARY KEY([TestID] ASC)
)
GO

print '' print '*** Creating LevelInfo Table'
GO

CREATE TABLE [dbo].[LevelInfo](
	[Level]			[int]		NOT NULL,
	[TitleID]		[int]		NOT NULL,
	[RequiredXP]	[int]		NOT NULL,
	CONSTRAINT [pk_Level] PRIMARY KEY([Level] ASC)
)
GO


