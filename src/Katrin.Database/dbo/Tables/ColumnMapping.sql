CREATE TABLE [dbo].[ColumnMapping] (
    [ColumnMappingId]     UNIQUEIDENTIFIER NOT NULL,
    [SourceEntityName]    NVARCHAR (160)   NULL,
    [SourceAttributeName] NVARCHAR (160)   NULL,
    [TargetEntityName]    NVARCHAR (160)   NULL,
    [TargetAttributeName] NVARCHAR (160)   NULL,
    [ImportMapId]         UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_ColumnMapping] PRIMARY KEY CLUSTERED ([ColumnMappingId] ASC),
    CONSTRAINT [FK_ColumnMapping_ImportMap] FOREIGN KEY ([ImportMapId]) REFERENCES [dbo].[ImportMap] ([ImportMapId])
);

