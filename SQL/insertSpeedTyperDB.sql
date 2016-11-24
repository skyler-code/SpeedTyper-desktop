print '' print '*** Inserting User'
GO
INSERT INTO [dbo].[Users]
		([UserName], [DisplayName])
	VALUES
		('test', 'test'),
		('test1', 'test1'),
		('test2', 'test2'),
		('test3', 'test3')
GO

print '' print '*** Inserting dummy tests'
GO
INSERT INTO [dbo].[TestResults]
	([UserID], [TestID], [WPM], [SecondsElapsed],[DateTaken])
	VALUES
	(1, 1, 150.5, 24, GETDATE()),
	(1, 1, 115.5, 24, GETDATE()),
	(1, 1, 154.5, 24, GETDATE()),
	(1, 1, 150.5, 24, GETDATE()),
	(1, 1, 150.5, 24, GETDATE()),
	(1, 1, 12.5, 24, GETDATE()),
	(1, 1, 150.5, 24, GETDATE()),
	(1, 1, 14.5, 24, GETDATE()),
	(1, 1, 154.5, 24, GETDATE()),
	(1, 1, 150.5, 24, GETDATE()),
	(1, 1, 152.5, 24, GETDATE()),
	(1, 1, 150.5, 24, GETDATE()),
	(1, 1, 150.5, 24, GETDATE()),
	(1, 1, 150.5, 24, GETDATE())
GO
	

print '' print '*** Inserting LevelInfo Records'
GO
INSERT INTO [dbo].[LevelInfo]
	([Level], [RequiredXP])
	VALUES
		(1, 200),
		(2, 800),
		(3, 1800),
		(4, 3200),
		(5, 5000),
		(6, 7200),
		(7, 9800),
		(8, 12800),
		(9, 16200),
		(10, 20000),
		(11, 24200),
		(12, 28800),
		(13, 33800),
		(14, 39200),
		(15, 45000)
GO

print '' print '*** Inserting RankInfo Records'
GO
INSERT INTO [dbo].[RankInfo]
	([RankID], [RankName])
	VALUES
	-- These are the Alliance honor ranks from vanilla WoW. Sadly, I knew this without looking it up.
	(0, "Citizen"),
	(1, "Private"),
	(2, "Corporal"),
	(3, "Sergeant"),
	(4, "Master Sergeant"),
	(5, "Sergeant Major"),
	(6, "Knight"),
	(7, "Knight-Lieutenant"),
	(8, "Knight-Captain"),
	(9, "Knight-Champion"),
	(10, "Lieutenant Commander"),
	(11, "Commander"),
	(12, "Marshal"),
	(13, "Field Marshal"),
	(14, "Grand Marshal"),
	(15, "The King")
GO

print '' print '*** Inserting XPModifierInfo Records'
GO
INSERT INTO [dbo].[XPModifierInfo]
	([ModifierType], [RequiredValue], [ModifierValue])
	VALUES
	("wpm", 0.0, 1.0),
	("wpm", 50.0, 1.5),
	("wpm", 70.0, 2.0),
	("wpm", 100.0, 3.0),
	("time", 7.0, 3.0),
	("time", 12.0, 2.0),
	("time", 20.0, 1.5),
	("time", 200.0, 1.0)
GO

		

print '' print '*** Inserting TestData Records'
GO
INSERT INTO [dbo].[TestData]
		([TestID], [TestDataText], [DataSource])
	VALUES
	-- Thanks to http://www.seanwrona.com/typeracer/texts.php
		(1, "I know a bloke who knows a bloke who knows a bloke. Now, I know you know this bloke. This is a bloke you know.", "Sexy Beast, a movie directed by Jonathan Glazer"),
		(2, "Good games offer players a set of challenging problems and then let them practice these until they have routinized their mastery.", "What Video Games Have to Teach Us About Learning and Literacy, a book by James Paul Gee"),
		(3, "Remember that humor is written backwards. That means you first find the cliche you want to work on, then build a story around it.", "Comedy Writing Secrets, a book by Mel Helitzer and Mark Shatz"),
		(4, "Ever since I was a child, folks have thought they had me pegged, because of the way I am, the way I talk. And they're always wrong.", "Capote, a movie directed by Bennett Miller"),
		(5, "For centuries, the battle of morality was fought between those who claimed that your life belongs to God and those who claimed that it belongs to your neighbors. And no one came to say that your life belongs to you and that the good is to live it.", "Atlas Shrugged, a book by Ayn Rand")
GO		