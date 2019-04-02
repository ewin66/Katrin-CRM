CREATE TABLE [dbo].[Metadata_AttributePicklistValueMap] (
    [AttributePicklistValueId] UNIQUEIDENTIFIER NOT NULL,
    [MapToValueId]             UNIQUEIDENTIFIER NOT NULL,
    [IsDefault]                BIT              NULL,
    [VersionNumber]            ROWVERSION       NULL,
    CONSTRAINT [PK_AttributePicklistValueMap] PRIMARY KEY CLUSTERED ([AttributePicklistValueId] ASC),
    CONSTRAINT [FK_AttributePicklistValueMap_AttributePicklistValue] FOREIGN KEY ([AttributePicklistValueId]) REFERENCES [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId]),
    CONSTRAINT [FK_AttributePicklistValueMap_MapToValue] FOREIGN KEY ([MapToValueId]) REFERENCES [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId])
);

