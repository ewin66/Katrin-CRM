CREATE TABLE [dbo].[PrivilegeEntity] (
    [PrivilegeEntityId] UNIQUEIDENTIFIER NOT NULL,
    [PrivilegeId]       UNIQUEIDENTIFIER NOT NULL,
    [EntityName]        VARCHAR (20)     NOT NULL,
    CONSTRAINT [PK_PrivilegeEntity] PRIMARY KEY CLUSTERED ([PrivilegeEntityId] ASC),
    CONSTRAINT [FK_PrivilegeEntity_Privilege] FOREIGN KEY ([PrivilegeId]) REFERENCES [dbo].[Privilege] ([PrivilegeId])
);

