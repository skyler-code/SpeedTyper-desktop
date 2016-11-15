print '' print '*** Creating sp_authenticate_user'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_user]
	(
	@UserName	varchar(20),
	@PasswordHash varchar(100)
	)
AS
	BEGIN
		SELECT COUNT(UserID)
		FROM Users
		WHERE UserName = @UserName
		AND PasswordHash = @PasswordHash
	END
GO

print '' print '*** Creating sp_retrieve_user_by_username'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_user_by_username]
	(
	@Username 	varchar(20)
	)
AS
	BEGIN
		SELECT UserID, UserName, DisplayName, TitleID, Level, CurrentXP, XPToLevel
		FROM Users
		WHERE Username = @Username
	END
GO

print '' print '*** Creating sp_create_user'
GO
CREATE PROCEDURE [dbo].[sp_create_user]
	(
	@UserName varchar(20),
	@DisplayName varchar(20),
	@PasswordHash varchar(100)
	)
AS
	BEGIN
		INSERT INTO Users
			(UserName, DisplayName, PasswordHash)
		VALUES
			(@UserName, @DisplayName, @PasswordHash)
	END
GO

print '' print '*** Creating sp_retrieve_random_test'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_random_test]
AS
	BEGIN
		SELECT TOP 1 TestID, TestDataText, DataSource
		FROM TestData
		ORDER BY NEWID()
	END
GO

print '' print '*** Creating sp_insert_test_result'
GO
CREATE PROCEDURE [dbo].[sp_insert_test_result]
	(
	@UserID int,
	@WPM decimal(18,2),
	@SecondsElapsed int
	)
AS
	BEGIN
		INSERT INTO TestResults
			(UserID, WPM, SecondsElapsed, DateTaken)
		VALUES
			(@UserID, @WPM, @SecondsElapsed, GETDATE())
		SELECT CONVERT(int, SCOPE_IDENTITY())
	END
GO

print '' print '*** Creating sp_retrieve_test_by_id'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_test_by_id]
	(
	@TestResultID int
	)
AS
	BEGIN
		SELECT TestResultID, UserID, WPM, SecondsElapsed, DateTaken
		FROM TestResults
		WHERE TestResultID = @TestResultID
	END
GO

print '' print '*** Creating sp_retrieve_top_10_test_scores'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_top_10_test_scores]
AS
	BEGIN
		SELECT TOP 10 Users.DisplayName, WPM, DateTaken
		FROM Users, TestResults
		WHERE Users.UserID = TestResults.UserID
		ORDER BY WPM DESC
	END
GO
