CREATE TABLE [dbo].[Role] (
    [RoleId]      UNIQUEIDENTIFIER NOT NULL,
    [RoleName]    NVARCHAR (100)   NULL,
    [Description] NVARCHAR (500)   NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);

