CREATE TABLE [dbo].[Category] (
    [id]   UNIQUEIDENTIFIER NOT NULL,
    [name] NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([id] ASC)
);

