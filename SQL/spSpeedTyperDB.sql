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
		SELECT UserID, UserName, DisplayName, RankID, Level, CurrentXP, XPToLevel
		FROM Users
		WHERE Username = @Username
	END
GO

print '' print '*** Creating sp_retrieve_user_by_id'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_user_by_id]
	(
	@UserID 	int
	)
AS
	BEGIN
		SELECT UserID, UserName, DisplayName, RankID, Level, CurrentXP, XPToLevel
		FROM Users
		WHERE UserID = @UserID
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


print '' print '*** Creating sp_update_user'
GO
CREATE PROCEDURE [dbo].[sp_update_user]
	(
	@UserID				int,
	@OldPasswordHash	varchar(100),
	@OldDisplayName		varchar(20),
	@NewDisplayName		varchar(20),
	@NewPasswordHash	varchar(100)
	)
AS
	BEGIN
		UPDATE Users
			SET PasswordHash = @NewPasswordHash,
				DisplayName = @NewDisplayName
			WHERE UserID = @UserID
			AND PasswordHash = @OldPasswordHash
			AND DisplayName = @OldDisplayName
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** Creating sp_retrieve_rank_names'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_rank_names]
AS
	BEGIN
		SELECT RankID, RankName
		FROM RankInfo
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
	@TestID int,
	@WPM decimal(18,2),
	@SecondsElapsed int
	)
AS
	BEGIN
		INSERT INTO TestResults
			(UserID, TestID, WPM, SecondsElapsed, DateTaken)
		VALUES
			(@UserID, @TestID, @WPM, @SecondsElapsed, GETDATE())
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
		SELECT TOP 10 Users.RankID, Users.DisplayName, WPM, DateTaken
		FROM Users, TestResults
		WHERE Users.UserID = TestResults.UserID
		ORDER BY WPM DESC
	END
GO

print '' print '*** Creating sp_retrieve_user_last_10_scores'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_user_last_10_scores]
	(
	@UserID int
	)
AS
	BEGIN
		SELECT TOP 10 WPM, SecondsElapsed, DateTaken
		FROM TestResults
		WHERE UserID = @UserID
		ORDER BY DateTaken DESC
	END
GO

print '' print '*** Creating sp_retrieve_wpm_xp_modifier'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_wpm_xp_modifier]
	(
	@WPM decimal(18,2)
	)
AS
	BEGIN
		SELECT MAX(ModifierValue)
		FROM XPModifierInfo
		WHERE @WPM >= RequiredValue
		AND ModifierType = "wpm"
	END
GO

print '' print '*** Creating sp_retrieve_time_xp_modifier'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_time_xp_modifier]
	(
	@SecondsElapsed decimal(18,2)
	)
AS
	BEGIN
		SELECT MAX(ModifierValue)
		FROM XPModifierInfo
		WHERE @SecondsElapsed <= RequiredValue
		AND ModifierType = "time"
	END
GO
