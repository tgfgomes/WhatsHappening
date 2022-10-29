CREATE TABLE [dbo].[Event] (
    [id]             UNIQUEIDENTIFIER  NOT NULL,
    [name]           NVARCHAR (MAX)    NOT NULL,
    [address]        NVARCHAR (MAX)    NULL,
    [cityId]         UNIQUEIDENTIFIER  NOT NULL,
    [gpsLocation]    [sys].[geography] NULL,
    [creationDate]   DATETIME          NOT NULL,
    [lastUpdateDate] DATETIME          NOT NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Event_City] FOREIGN KEY ([cityId]) REFERENCES [dbo].[City] ([id])
);



