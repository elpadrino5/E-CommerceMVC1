CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [ImgUrl] NVARCHAR(50) NULL
)
