CREATE TABLE [dbo].[Metadata_AttributePicklistValue] (
    [AttributePicklistValueId] UNIQUEIDENTIFIER NOT NULL,
    [Value]                    INT              NULL,
    [DisplayOrder]             INT              NULL,
    [VersionNumber]            ROWVERSION       NOT NULL,
    [OptionSetId]              UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_AttributePicklistValue] PRIMARY KEY CLUSTERED ([AttributePicklistValueId] ASC),
    CONSTRAINT [FK_AttributePicklistValue_OptionSet] FOREIGN KEY ([OptionSetId]) REFERENCES [dbo].[Metadata_OptionSet] ([OptionSetId])
);

