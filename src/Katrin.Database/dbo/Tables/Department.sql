CREATE TABLE [dbo].[Department] (
    [DepartmentId] UNIQUEIDENTIFIER NOT NULL,
    [Name]         NVARCHAR (50)    NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([DepartmentId] ASC)
);

