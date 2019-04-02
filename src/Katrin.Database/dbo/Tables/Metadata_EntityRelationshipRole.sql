CREATE TABLE [dbo].[Metadata_EntityRelationshipRole] (
    [EntityRelationshipRoleId] UNIQUEIDENTIFIER NOT NULL,
    [EntityRelationshipId]     UNIQUEIDENTIFIER NOT NULL,
    [EntityId]                 UNIQUEIDENTIFIER NOT NULL,
    [RelationshipRoleType]     TINYINT          NOT NULL,
    [NavPanelDisplayOption]    TINYINT          NULL,
    [NavPaneOrder]             INT              NULL,
    CONSTRAINT [PK_EntityRelationshipRole] PRIMARY KEY CLUSTERED ([EntityRelationshipRoleId] ASC),
    CONSTRAINT [FK_EntityRelationshipRole_EntityRelationship] FOREIGN KEY ([EntityRelationshipId]) REFERENCES [dbo].[Metadata_EntityRelationship] ([EntityRelationshipId]),
    CONSTRAINT [FK_EntityRelationshipRole_Metadata_Entity] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId])
);

