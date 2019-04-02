CREATE TABLE [dbo].[ProjectVersion] (
    [ProjectVersionId] UNIQUEIDENTIFIER NOT NULL,
    [ProjectId]        UNIQUEIDENTIFIER NOT NULL,
    [Description]      NVARCHAR (MAX)   NULL,
    [VersionName]      NVARCHAR (50)    NOT NULL,
    [CreatedOn]        DATETIME         NULL,
    [CreatedById]      UNIQUEIDENTIFIER NULL,
    [ModifiedOn]       DATETIME         NULL,
    [ModifiedById]     UNIQUEIDENTIFIER NULL,
    [IsDeleted]        BIT              NOT NULL,
    [VersionNumber]    ROWVERSION       NULL,
    CONSTRAINT [PK_ProjectVersion] PRIMARY KEY CLUSTERED ([ProjectVersionId] ASC),
    CONSTRAINT [FK_ProjectVersion_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([ProjectId]),
    CONSTRAINT [FK_ProjectVersion_User] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_ProjectVersion_User1] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId])
);

