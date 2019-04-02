CREATE TABLE [dbo].[Notification]
(
	[NotificationId] UNIQUEIDENTIFIER NOT NULL , 
	[ObjectId] UNIQUEIDENTIFIER NULL, 
	[ObjectType] NVARCHAR(200) NULL, 
    [Subject] NVARCHAR(200) NULL, 
    [Body] NVARCHAR(1000) NULL, 
	[NotificationUrl] NVARCHAR(200) NULL, 
	[AboutAttributeId] UNIQUEIDENTIFIER NULL, 
    [AboutUrl] NVARCHAR(200) NULL, 
    [CreatedOn] DATETIME NULL, 
    [CreatedById] UNIQUEIDENTIFIER NULL, 
    [ModifiedOn] DATETIME NULL, 
    [ModifiedById] UNIQUEIDENTIFIER NULL, 
    [VersionNumber] ROWVERSION NULL
    CONSTRAINT [PK_Notification] PRIMARY KEY ([NotificationId]), 

    CONSTRAINT [FK_Notification_User_CreatedBy] FOREIGN KEY ([CreatedById]) REFERENCES [User]([UserId]), 
    CONSTRAINT [FK_Notification_User_ModifiedBy] FOREIGN KEY ([ModifiedById]) REFERENCES [User]([UserId])
)
