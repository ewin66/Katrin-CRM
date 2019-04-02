CREATE TABLE [dbo].[TaskTimeHistory] (
    [TaskTimeHistoryId] UNIQUEIDENTIFIER NOT NULL,
    [TaskId]            UNIQUEIDENTIFIER NOT NULL,
    [StartTime]         INT              NULL,
    [EndTime]           INT              NULL,
    [ActualInput]       FLOAT (53)       NULL,
    [Effort]            FLOAT (53)       NULL,
    [Overtime]          FLOAT (53)       NULL,
    [ActualProgress]    FLOAT (53)       NULL,
    [Description]       NVARCHAR (MAX)   NULL,
    [RecordOn]          DATETIME         NULL,
    [CreatedOn]         DATETIME         NULL,
    [CreatedById]       UNIQUEIDENTIFIER NULL,
    [ModifiedOn]        DATETIME         NULL,
    [ModifiedById]      UNIQUEIDENTIFIER NULL,
    [VersionNumber]     ROWVERSION       NULL,
    [IsDeleted]         BIT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_TaskTimeHistory] PRIMARY KEY CLUSTERED ([TaskTimeHistoryId] ASC),
    CONSTRAINT [FK_TaskTimeHistory_ProjectTask] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[ProjectTask] ([TaskId])
);

