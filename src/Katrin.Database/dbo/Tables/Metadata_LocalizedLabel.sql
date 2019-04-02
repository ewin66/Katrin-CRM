CREATE TABLE [dbo].[Metadata_LocalizedLabel] (
    [LocalizedLabelId] UNIQUEIDENTIFIER NOT NULL,
    [LanguageId]       INT              NOT NULL,
    [ObjectId]         UNIQUEIDENTIFIER NOT NULL,
    [ObjectColumnName] NVARCHAR (128)   NOT NULL,
    [Label]            NVARCHAR (MAX)   NOT NULL,
    [VersionNumber]    ROWVERSION       NOT NULL,
    CONSTRAINT [PK_LocalizedLabel] PRIMARY KEY CLUSTERED ([LocalizedLabelId] ASC)
);

