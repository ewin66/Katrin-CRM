CREATE TABLE [dbo].[Audit] (
    [AuditId]       UNIQUEIDENTIFIER NOT NULL,
    [Action]        NVARCHAR (50)    NULL,
    [ObjectId]      UNIQUEIDENTIFIER NULL,
    [ObjectType]    NVARCHAR (64)    NULL,
    [CreatedOn]     DATETIME         NULL,
    [ChangeDate]    NVARCHAR (MAX)   NULL,
    [UserId]        UNIQUEIDENTIFIER NULL,
    [FieldName]     NVARCHAR (50)    NULL,
    [OriginalValue] NVARCHAR (MAX)   NULL,
    [NewValue]      NVARCHAR (MAX)   NULL,
    [TrasactionId]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Audit] PRIMARY KEY CLUSTERED ([AuditId] ASC)
);

