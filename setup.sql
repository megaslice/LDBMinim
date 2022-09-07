USE master
GO

CREATE DATABASE MinimalReproduction04ECD0D4E3
GO

USE MinimalReproduction04ECD0D4E3
GO

CREATE FUNCTION dbo.ExampleFunction (@k int)
RETURNS int
WITH SCHEMABINDING
AS
BEGIN
  RETURN @k + 1
END
GO

CREATE TABLE Blort (
  X int NOT NULL,
  Y int NOT NULL,
  Z int NOT NULL,
  Blortness int NOT NULL,

  CONSTRAINT PK_Blort PRIMARY KEY (X, Y, Z)
)
GO

CREATE TABLE Foo (
  X int NOT NULL,
  Y int NOT NULL,
  Z int NOT NULL,
  BlortX int NOT NULL,
  BlortY int NOT NULL,
  BlortZ int NOT NULL,
  Fooness int NOT NULL,

  CONSTRAINT PK_Foo PRIMARY KEY (X, Y, Z),
  CONSTRAINT FK_Foo_Blort
    FOREIGN KEY (BlortX, BlortY, BlortZ)
    REFERENCES Blort (X, Y, Z)
)
GO
