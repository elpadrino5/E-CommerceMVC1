CREATE TABLE [dbo].[Product] (
    [ProductId]   INT            IDENTITY (1005, 1) NOT NULL,
    [Name]        VARCHAR (50)   NOT NULL,
    [Price]       MONEY          NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [ImgUrl]      NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

