CREATE PROCEDURE InsertChatMessage 
	@username	varchar(50),
	@message	text
AS
BEGIN
	INSERT INTO [tblMessages] (username, message) 
	VALUES (@username,@message);

	DELETE FROM [tblMessages] WHERE [id] NOT IN 
	(SELECT TOP 100 [id] FROM [tblMessages] ORDER BY [id] DESC);
END
GO
