CREATE TABLE [dbo].[Event_Category] (
    [categoryId] UNIQUEIDENTIFIER NOT NULL,
    [eventId]    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Event_Category] PRIMARY KEY CLUSTERED ([categoryId] ASC, [eventId] ASC),
    CONSTRAINT [FK_Event_Category_Category] FOREIGN KEY ([categoryId]) REFERENCES [dbo].[Category] ([id]),
    CONSTRAINT [FK_Event_Category_Event] FOREIGN KEY ([eventId]) REFERENCES [dbo].[Event] ([id])
);

