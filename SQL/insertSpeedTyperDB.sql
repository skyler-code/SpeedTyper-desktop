print '' print '*** Inserting User Test Records'
INSERT INTO [dbo].[Users]
		([UserName], [DisplayName])
	VALUES
		('test', 'test')
GO

print '' print '*** Insert FakeTestResults'
INSERT INTO [dbo].[TestResults]
		([UserID], [WPM], [SecondsElapsed], [DateTaken])
	VALUES
		(1, 200, 40, GETDATE()),
		(1, 32, 40, GETDATE()),
		(1, 54, 40, GETDATE()),
		(1, 124, 40, GETDATE()),
		(1, 542, 40, GETDATE()),
		(1, 23, 40, GETDATE()),
		(1, 21, 40, GETDATE()),
		(1, 1, 40, GETDATE()),
		(1, 54, 40, GETDATE()),
		(1, 64, 40, GETDATE()),
		(1, 344, 40, GETDATE()),
		(1, 23, 40, GETDATE()),
		(1, 43, 40, GETDATE()),
		(1, 523, 40, GETDATE())
GO

print '' print '*** Inserting TestData Records'
INSERT INTO [dbo].[TestData]
		([TestID], [TestDataText], [DataSource])
	VALUES
		(1, "I know a bloke who knows a bloke who knows a bloke. Now, I know you know this bloke. This is a bloke you know.", "Sexy Beast, a movie directed by Jonathan Glazer"),
		(2, "Good games offer players a set of challenging problems and then let them practice these until they have routinized their mastery.", "What Video Games Have to Teach Us About Learning and Literacy, a book by James Paul Gee"),
		(3, "Remember that humor is written backwards. That means you first find the cliche you want to work on, then build a story around it.", "Comedy Writing Secrets, a book by Mel Helitzer and Mark Shatz"),
		(4, "Ever since I was a child, folks have thought they had me pegged, because of the way I am, the way I talk. And they're always wrong.", "Capote, a movie directed by Bennett Miller"),
		(5, "For centuries, the battle of morality was fought between those who claimed that your life belongs to God and those who claimed that it belongs to your neighbors. And no one came to say that your life belongs to you and that the good is to live it.", "Atlas Shrugged, a book by Ayn Rand")
GO		