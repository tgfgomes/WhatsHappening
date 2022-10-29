CREATE TABLE [dbo].[City] (
    [id]        UNIQUEIDENTIFIER NOT NULL,
    [name]      NVARCHAR (MAX)   NOT NULL,
    [countryId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_City_Country] FOREIGN KEY ([countryId]) REFERENCES [dbo].[Country] ([id])
);

