CREATE TABLE [dbo].[ProjectMember] (
    [ProjectMemberId] UNIQUEIDENTIFIER NOT NULL,
    [ProjectId]       UNIQUEIDENTIFIER NOT NULL,
    [MemberId]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ProjectMember] PRIMARY KEY CLUSTERED ([ProjectMemberId] ASC),
    CONSTRAINT [FK_ProjectMember_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([ProjectId]),
    CONSTRAINT [FK_ProjectMember_User] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[User] ([UserId])
);

