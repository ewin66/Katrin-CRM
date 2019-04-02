CREATE TABLE [dbo].[Privilege] (
    [PrivilegeId] UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (50)    NULL,
    [AccessRight] INT              NULL,
    CONSTRAINT [PK_Privilege] PRIMARY KEY CLUSTERED ([PrivilegeId] ASC)
);

