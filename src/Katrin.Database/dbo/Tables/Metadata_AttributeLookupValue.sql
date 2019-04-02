CREATE TABLE [dbo].[Metadata_AttributeLookupValue] (
    [AttributeLookupValueId]   UNIQUEIDENTIFIER NOT NULL,
    [AttributeId]              UNIQUEIDENTIFIER NOT NULL,
    [EntityId]                 UNIQUEIDENTIFIER NOT NULL,
    [DisplayEntityAttributeId] UNIQUEIDENTIFIER NULL,
    [VersionNumber]            ROWVERSION       NOT NULL,
    CONSTRAINT [PK_AttributeLookupValue] PRIMARY KEY CLUSTERED ([AttributeLookupValueId] ASC),
    CONSTRAINT [FK_AttributeLookupValue_Entity] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]),
    CONSTRAINT [FK_AttributeLookupValue_For_Attribute] FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[Metadata_Attribute] ([AttributeId])
);

