CREATE TABLE [dbo].[EventDates] (
    [id]      UNIQUEIDENTIFIER NOT NULL,
    [eventId] UNIQUEIDENTIFIER NOT NULL,
    [date]    DATETIME         NOT NULL,
    CONSTRAINT [PK_EventDates] PRIMARY KEY CLUSTERED ([id] ASC, [eventId] ASC),
    CONSTRAINT [FK_EventDates_Event] FOREIGN KEY ([eventId]) REFERENCES [dbo].[Event] ([id])
);



