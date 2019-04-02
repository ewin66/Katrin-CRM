﻿CREATE TABLE [dbo].[Metadata_Attribute] (
    [AttributeId]     UNIQUEIDENTIFIER NOT NULL,
    [AttributeTypeId] UNIQUEIDENTIFIER NULL,
    [LogicalType]     NVARCHAR (50)    NULL,
    [Name]            NVARCHAR (50)    NULL,
    [PhysicalName]    NVARCHAR (50)    NULL,
    [Length]          INT              NULL,
    [IsNullable]      BIT              NULL,
    [EntityId]        UNIQUEIDENTIFIER NOT NULL,
    [DefaultValue]    NVARCHAR (100)   NULL,
    [ColumnNumber]    INT              NOT NULL,
    [LogicalName]     NVARCHAR (50)    NOT NULL,
    [VersionNumber]   ROWVERSION       NOT NULL,
    [MaxLength]       INT              NULL,
    [MinValue]        FLOAT (53)       NULL,
    [MaxValue]        FLOAT (53)       NULL,
    [IsAuditEnabled]  BIT              NOT NULL,
    [TableColumnName] NVARCHAR (50)    NULL,
    [OptionSetId]     UNIQUEIDENTIFIER NULL,
    [AppDefaultValue] INT              NULL,
    [IsPKAttribute]   BIT              NULL,
    [IsCopyEnabled] BIT NULL, 
    CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED ([AttributeId] ASC),
    CONSTRAINT [FK_Attribute_AttributeType] FOREIGN KEY ([AttributeTypeId]) REFERENCES [dbo].[Metadata_AttributeType] ([AttributeTypeId]),
    CONSTRAINT [FK_Attribute_Entity] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]),
    CONSTRAINT [FK_Attribute_OptionSet] FOREIGN KEY ([OptionSetId]) REFERENCES [dbo].[Metadata_OptionSet] ([OptionSetId])
);

