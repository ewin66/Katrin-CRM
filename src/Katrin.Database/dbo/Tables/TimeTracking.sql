CREATE TABLE [dbo].[TimeTracking] (
    [TimeTrackingId] UNIQUEIDENTIFIER NOT NULL,
    [TypeCode]       INT              NULL,
    [Effort]         FLOAT (53)       NULL,
    [RecordOn]       DATETIME         NULL,
    [RecordById]     UNIQUEIDENTIFIER NULL,
    [OpportunityId]  UNIQUEIDENTIFIER NULL,
    [Description]    NVARCHAR (500)   NULL,
    CONSTRAINT [PK_TimeTracking] PRIMARY KEY CLUSTERED ([TimeTrackingId] ASC),
    CONSTRAINT [FK_TimeTracking_Opportunity] FOREIGN KEY ([OpportunityId]) REFERENCES [dbo].[Opportunity] ([OpportunityId]),
    CONSTRAINT [FK_TimeTracking_User] FOREIGN KEY ([RecordById]) REFERENCES [dbo].[User] ([UserId])
);

