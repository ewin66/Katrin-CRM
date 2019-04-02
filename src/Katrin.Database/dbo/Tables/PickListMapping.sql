CREATE TABLE [dbo].[PickListMapping] (
    [PickListMappingId] UNIQUEIDENTIFIER NOT NULL,
    [ColumnMappingId]   UNIQUEIDENTIFIER NULL,
    [TargetValue]       INT              NULL,
    [SourceValue]       NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_PickListMapping] PRIMARY KEY CLUSTERED ([PickListMappingId] ASC),
    CONSTRAINT [FK_PickListMapping_ColumnMapping] FOREIGN KEY ([ColumnMappingId]) REFERENCES [dbo].[ColumnMapping] ([ColumnMappingId])
);

