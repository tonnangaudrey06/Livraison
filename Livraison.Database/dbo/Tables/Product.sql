CREATE TABLE [dbo].[Product] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Reference]  NVARCHAR (50) NOT NULL,
    [Lieu]       NVARCHAR (50) NOT NULL,
    [CategoryId] INT           NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [IX_Product] UNIQUE NONCLUSTERED ([Reference] ASC)
);

