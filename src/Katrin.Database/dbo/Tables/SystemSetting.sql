CREATE TABLE [dbo].[SystemSetting] (
    [SystemSettingId] UNIQUEIDENTIFIER NOT NULL,
    [Name]            NVARCHAR (200)   NOT NULL,
    [Value]           NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_SystemSetting] PRIMARY KEY CLUSTERED ([SystemSettingId] ASC)
);

