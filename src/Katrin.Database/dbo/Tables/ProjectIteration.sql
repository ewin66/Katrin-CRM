CREATE TABLE [dbo].[ProjectIteration] (
    [ProjectIterationId] UNIQUEIDENTIFIER NOT NULL,
    [ProjectId]          UNIQUEIDENTIFIER NOT NULL,
    [Name]               NVARCHAR (500)   NOT NULL,
    [Objective]          NVARCHAR (MAX)   NULL,
    [StartDate]          DATETIME         NULL,
    [Deadline]           DATETIME         NULL,
    [CreatedOn]          DATETIME         NULL,
    [CreatedById]        UNIQUEIDENTIFIER NULL,
    [ModifiedOn]         DATETIME         NULL,
    [ModifiedById]       UNIQUEIDENTIFIER NULL,
    [IsDeleted]          BIT              NOT NULL,
    [VersionNumber]      ROWVERSION       NULL,
    [ProjectVersionId]   UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_ProjectIteration] PRIMARY KEY CLUSTERED ([ProjectIterationId] ASC),
    CONSTRAINT [FK_ProjectIteration_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([ProjectId]),
    CONSTRAINT [FK_ProjectIteration_ProjectVersion] FOREIGN KEY ([ProjectVersionId]) REFERENCES [dbo].[ProjectVersion] ([ProjectVersionId]),
    CONSTRAINT [FK_ProjectIteration_User_CreatedBy] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_ProjectIteration_User_ModifiedBy] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId])
);

