CREATE TABLE [dbo].[Metadata_Relationship] (
    [RelationshipId]         UNIQUEIDENTIFIER NOT NULL,
    [Name]                   NVARCHAR (255)   NULL,
    [ReferencingEntityId]    UNIQUEIDENTIFIER NOT NULL,
    [ReferencingAttributeId] UNIQUEIDENTIFIER NOT NULL,
    [ReferencedEntityId]     UNIQUEIDENTIFIER NOT NULL,
    [ReferencedAttributeId]  UNIQUEIDENTIFIER NOT NULL,
    [RelationshipType]       INT              NULL,
    [CascadeDelete]          TINYINT          NOT NULL,
    [VersionNumber]          ROWVERSION       NOT NULL,
    CONSTRAINT [PK_Metadata_Relationship] PRIMARY KEY CLUSTERED ([RelationshipId] ASC),
    CONSTRAINT [FK_Metadata_Relationship_Metadata_ReferencedAttribute] FOREIGN KEY ([ReferencedAttributeId]) REFERENCES [dbo].[Metadata_Attribute] ([AttributeId]),
    CONSTRAINT [FK_Metadata_Relationship_Metadata_ReferencedEntity] FOREIGN KEY ([ReferencedEntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]),
    CONSTRAINT [FK_Metadata_Relationship_Metadata_ReferencingAttribute] FOREIGN KEY ([ReferencingAttributeId]) REFERENCES [dbo].[Metadata_Attribute] ([AttributeId]),
    CONSTRAINT [FK_Metadata_Relationship_Metadata_ReferencingEntity] FOREIGN KEY ([ReferencingEntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId])
);

