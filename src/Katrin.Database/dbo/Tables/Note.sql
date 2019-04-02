CREATE TABLE [dbo].[Note] (
    [NoteId]        UNIQUEIDENTIFIER NOT NULL,
    [Subject]       NVARCHAR (500)   NULL,
    [NoteText]      NVARCHAR (MAX)   NULL,
    [CreatedOn]     DATETIME         NULL,
    [CreatedById]   UNIQUEIDENTIFIER NULL,
    [ModifiedById]  UNIQUEIDENTIFIER NULL,
    [ModifiedOn]    DATETIME         NULL,
    [VersionNumber] ROWVERSION       NULL,
    [ObjectType]    NVARCHAR (64)    NULL,
    [ObjectId]      UNIQUEIDENTIFIER NULL,
    [IsDeleted]     BIT              CONSTRAINT [DF_Note_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED ([NoteId] ASC),
    CONSTRAINT [FK_Note_User_CreatedBy] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_Note_User_ModifiedBy] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId])
);

