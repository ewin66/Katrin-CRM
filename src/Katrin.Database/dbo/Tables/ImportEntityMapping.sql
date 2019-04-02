CREATE TABLE [dbo].[ImportEntityMapping] (
    [ImportEntityMappingId] UNIQUEIDENTIFIER NOT NULL,
    [SourceEntityName]      NVARCHAR (160)   NULL,
    [TargetEntityName]      NVARCHAR (160)   NULL,
    [ImportMapId]           UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_ImportEntityMapping] PRIMARY KEY CLUSTERED ([ImportEntityMappingId] ASC),
    CONSTRAINT [FK_ImportEntityMapping_ImportMap] FOREIGN KEY ([ImportMapId]) REFERENCES [dbo].[ImportMap] ([ImportMapId])
);

