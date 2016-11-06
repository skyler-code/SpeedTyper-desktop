print '' print '*** Inserting User Test Records'
INSERT INTO [dbo].[Users]
		([UserName], [DisplayName])
	VALUES
		('test', 'test')
GO