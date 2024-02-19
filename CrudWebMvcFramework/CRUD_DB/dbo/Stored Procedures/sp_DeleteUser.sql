CREATE PROCEDURE [dbo].[sp_DeleteUser]
	@Id int
AS
BEGIN
	DELETE 
		FROM Users
	WHERE 
		Id = @Id
END
