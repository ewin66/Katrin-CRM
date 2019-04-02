CREATE TABLE [dbo].[ImportMap] (
    [ImportMapId] UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (320)   NULL,
    [Source]      NVARCHAR (160)   NULL,
    CONSTRAINT [PK_ImportMap] PRIMARY KEY CLUSTERED ([ImportMapId] ASC)
);

