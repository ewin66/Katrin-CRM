CREATE TABLE [dbo].[Metadata_Entity] (
    [EntityId]       UNIQUEIDENTIFIER NOT NULL,
    [Name]           NVARCHAR (64)    NULL,
    [PhysicalName]   NVARCHAR (64)    NULL,
    [LogicalName]    NVARCHAR (64)    NULL,
    [TableName]      NVARCHAR (64)    NULL,
    [IsAuditEnabled] BIT              NOT NULL,
    CONSTRAINT [PK_Entity] PRIMARY KEY CLUSTERED ([EntityId] ASC)
);

