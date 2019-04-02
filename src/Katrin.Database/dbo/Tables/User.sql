CREATE TABLE [dbo].[User] (
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [DepartmentId]         UNIQUEIDENTIFIER NULL,
    [UserName]             NVARCHAR (50)    NOT NULL,
    [Password]             NVARCHAR (128)   NULL,
    [PasswordSalt]         NVARCHAR (128)   NULL,
    [FirstName]            NVARCHAR (50)    NULL,
    [MiddleName]           NVARCHAR (50)    NULL,
    [LastName]             NVARCHAR (50)    NULL,
    [FullName]             NVARCHAR (50)    NULL,
    [NickName]             NVARCHAR (50)    NULL,
    [Title]                NVARCHAR (100)   NULL,
    [EmailAddress]         NVARCHAR (100)   NULL,
    [HomePhone]            NVARCHAR (50)    NULL,
    [MobilePhone]          NVARCHAR (50)    NULL,
    [IsDisabled]           BIT              NULL,
    [VersionNumber]        ROWVERSION       NULL,
    [CreatedOn]            DATETIME         NULL,
    [ModifiedOn]           DATETIME         NULL,
    [CreatedById]          UNIQUEIDENTIFIER NULL,
    [ModifiedById]         UNIQUEIDENTIFIER NULL,
    [ParentUserId]         UNIQUEIDENTIFIER NULL,
    [UserType]             INT              NULL,
    [IsDeleted]            BIT              CONSTRAINT [DF_User_IsDeleted] DEFAULT ((0)) NOT NULL,
    [NativePlace]          NVARCHAR (100)   NULL,
    [EntryDate]            DATETIME         NULL,
    [GraduatedCollege]     NVARCHAR (100)   NULL,
    [EnglishCommunication] NVARCHAR (50)    NULL,
    [EnglishLevel]         NVARCHAR (50)    NULL,
    [TechnicalExpertise]   NVARCHAR (50)    NULL,
    [BirthDate]            DATETIME         NULL,
    [MSN]                  NVARCHAR (50)    NULL,
    [QQ]                   NVARCHAR (50)    NULL,
    [Hobby]                NVARCHAR (100)   NULL,
    [WorkExperience]       NVARCHAR (50)    NULL,
    [JobLevelCode]         INT              NULL,
	[LastPromotionDate]    DATETIME         NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_CreatedBy] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_User_Department] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([DepartmentId]),
    CONSTRAINT [FK_User_ModifiedBy] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_User_ParentUser] FOREIGN KEY ([ParentUserId]) REFERENCES [dbo].[User] ([UserId])
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserName]
    ON [dbo].[User]([UserName] ASC);

