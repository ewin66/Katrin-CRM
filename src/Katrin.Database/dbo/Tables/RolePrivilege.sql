CREATE TABLE [dbo].[RolePrivilege] (
    [RolePrivilegeId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId]          UNIQUEIDENTIFIER NOT NULL,
    [PrivilegeId]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_RolePrivilege] PRIMARY KEY CLUSTERED ([RolePrivilegeId] ASC),
    CONSTRAINT [FK_RolePrivilege_Privilege] FOREIGN KEY ([PrivilegeId]) REFERENCES [dbo].[Privilege] ([PrivilegeId]),
    CONSTRAINT [FK_RolePrivilege_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId])
);

