CREATE TABLE [dbo].[Metadata_OptionSet] (
    [OptionSetId]    UNIQUEIDENTIFIER NOT NULL,
    [Name]           NVARCHAR (255)   NOT NULL,
    [IsCustomizable] BIT              NOT NULL,
    CONSTRAINT [PK_OptionSet] PRIMARY KEY CLUSTERED ([OptionSetId] ASC)
);

