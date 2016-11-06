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
