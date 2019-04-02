CREATE TABLE [dbo].[Metadata_EntityRelationshipRelationships] (
    [EntityRelationshipRelationshipsId] UNIQUEIDENTIFIER NOT NULL,
    [EntityRelationshipId]              UNIQUEIDENTIFIER NULL,
    [RelationshipId]                    UNIQUEIDENTIFIER NOT NULL,
    [VersionNumber]                     ROWVERSION       NOT NULL,
    CONSTRAINT [PK_Metadata_EntityRelationshipRelationships] PRIMARY KEY CLUSTERED ([EntityRelationshipRelationshipsId] ASC),
    CONSTRAINT [FK_EntityRelationshipRelationships_EntityRelationship] FOREIGN KEY ([EntityRelationshipId]) REFERENCES [dbo].[Metadata_EntityRelationship] ([EntityRelationshipId]),
    CONSTRAINT [FK_EntityRelationshipRelationships_Relationship] FOREIGN KEY ([RelationshipId]) REFERENCES [dbo].[Metadata_Relationship] ([RelationshipId])
);

