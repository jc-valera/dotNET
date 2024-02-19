USE master
GO

CREATE DATABASE CrudWebMvcFramework
GO

USE CrudWebMvcFramework
GO

INSERT INTO Users(Name, LastName, Age) 
VALUES 
	('Centolia', 'Perez', 50), 
	('Ceforino', 'Chavez', 45)
GO