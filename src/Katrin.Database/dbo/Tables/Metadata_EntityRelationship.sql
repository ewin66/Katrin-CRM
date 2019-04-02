CREATE TABLE [dbo].[Metadata_EntityRelationship] (
    [EntityRelationshipId]   UNIQUEIDENTIFIER NOT NULL,
    [SchemaName]             NVARCHAR (255)   NULL,
    [EntityRelationshipType] TINYINT          NOT NULL,
    [IsCustomRelationship]   BIT              NOT NULL,
    [IsCustomizable]         BIT              NOT NULL,
    [VersionNumber]          ROWVERSION       NULL,
    CONSTRAINT [PK_Metadata_EntityRelationship] PRIMARY KEY CLUSTERED ([EntityRelationshipId] ASC)
);

