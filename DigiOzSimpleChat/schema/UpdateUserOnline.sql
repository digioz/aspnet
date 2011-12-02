CREATE PROCEDURE UpdateUserOnline 
	@username	varchar(50)
AS
BEGIN
	IF (SELECT COUNT(*) FROM [tblUsersOnline] WHERE [username]=@username) > 0 
		BEGIN
			UPDATE [tblUsersOnline] SET [timestamp]=getdate() WHERE [username]=@username;
		END
	ELSE
		BEGIN
			INSERT INTO [tblUsersOnline] ([username]) VALUES (@username);
		END

	DELETE FROM [tblUsersOnline] WHERE timestamp < DATEADD( mi, -10, getDate());
END
GO