CREATE TABLE [dbo].[LookupMapping] (
    [LookupMappingId]     UNIQUEIDENTIFIER NOT NULL,
    [ColumnMappingId]     UNIQUEIDENTIFIER NULL,
    [LookupEntityName]    NVARCHAR (160)   NULL,
    [ValueAttributeName]  NVARCHAR (160)   NULL,
    [LookupAttributeName] NVARCHAR (160)   NULL,
    CONSTRAINT [PK_LookupMapping] PRIMARY KEY CLUSTERED ([LookupMappingId] ASC),
    CONSTRAINT [FK_LookupMapping_ColumnMapping] FOREIGN KEY ([ColumnMappingId]) REFERENCES [dbo].[ColumnMapping] ([ColumnMappingId])
);

