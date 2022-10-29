CREATE TABLE [dbo].[Country] (
    [id]   UNIQUEIDENTIFIER NOT NULL,
	[countryCode] NVARCHAR (MAX)   NOT NULL,
    [name] NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([id] ASC)
);

