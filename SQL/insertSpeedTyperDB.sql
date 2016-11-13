print '' print '*** Inserting User Test Records'
INSERT INTO [dbo].[Users]
		([UserName], [DisplayName])
	VALUES
		('test', 'test')
GO

print '' print '*** Inserting TestData Records'
INSERT INTO [dbo].[TestData]
		([TestID], [TestDataText], [DataSource])
	VALUES
		(1, "I know a bloke who knows a bloke who knows a bloke. Now, I know you know this bloke. This is a bloke you know.", "from Sexy Beast, a movie directed by Jonathan Glazer")
GO		