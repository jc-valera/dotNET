CREATE PROCEDURE sp_UpdateUser
	@Id INT,
	@Name VARCHAR(50),
	@LastName VARCHAR(50),
	@Age INT
AS
BEGIN
	UPDATE Users 
	SET 
		Name = @Name, LastName = @LastName, Age = @Age
	WHERE 
		Id = @Id
END
GO