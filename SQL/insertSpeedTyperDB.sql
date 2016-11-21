print '' print '*** Inserting User'
GO
INSERT INTO [dbo].[Users]
		([UserName], [DisplayName])
	VALUES
		('test', 'test')
GO

print '' print '*** Inserting LevelInfo Records'
GO
INSERT INTO [dbo].[LevelInfo]
	([Level], [RequiredXP])
	VALUES
		(1, 150),
		(2, 2000),
		(3, 5000),
		(4, 10000),
		(5, 15000),
		(6, 20000),
		(7, 25000),
		(8, 30000),
		(9, 35000),
		(10, 40000),
		(11, 45000),
		(12, 50000),
		(13, 55000),
		(14, 60000)
GO

print '' print '*** Inserting RankInfo Records'
GO
INSERT INTO [dbo].[RankInfo]
	([RankID], [RankName])
	VALUES
	-- These are the Alliance honor ranks from vanilla WoW. Sadly, I knew this without looking it up.
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