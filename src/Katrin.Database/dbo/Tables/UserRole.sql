CREATE TABLE [dbo].[UserRole] (
    [Id]     UNIQUEIDENTIFIER NOT NULL,
    [UserId] UNIQUEIDENTIFIER NULL,
    [RoleId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_User_Role] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]),
    CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

