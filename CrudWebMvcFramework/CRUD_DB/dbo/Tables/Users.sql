CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY(1,1),
	[Name] VARCHAR(50),
	[LastName] VARCHAR(50),
	[Age] INT

	CONSTRAINT PK_Users_Id PRIMARY KEY(Id)
)
