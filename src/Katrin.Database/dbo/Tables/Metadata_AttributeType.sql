CREATE TABLE [dbo].[Metadata_AttributeType] (
    [AttributeTypeId] UNIQUEIDENTIFIER NOT NULL,
    [Description]     NVARCHAR (255)   NULL,
    CONSTRAINT [PK_AttributeType] PRIMARY KEY CLUSTERED ([AttributeTypeId] ASC)
);

