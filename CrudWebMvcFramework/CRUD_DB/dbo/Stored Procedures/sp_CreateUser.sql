CREATE PROCEDURE [dbo].[sp_CreateUser]
	@Name VARCHAR(50),
	@LastName VARCHAR(50),
	@Age INT
AS
BEGIN
	INSERT INTO Users 
		(Name, LastName, Age)
	VALUES 
		(@Name, @LastName, @Age)
END
