CREATE TABLE [dbo].[NotificationRecipient]
(
	[NotificationRecipientId] UNIQUEIDENTIFIER NOT NULL , 
    [NotificationId] UNIQUEIDENTIFIER NULL, 
    [RecipientId] UNIQUEIDENTIFIER NULL, 
    [NotificationStatus] NVARCHAR(50) NULL, --NotSend,Opened,Readed
    [ReadedOn] DATETIME NULL, 
    CONSTRAINT [PK_NotificationRecipient] PRIMARY KEY ([NotificationRecipientId]), 
    CONSTRAINT [FK_NotificationRecipient_Notification] FOREIGN KEY ([NotificationId]) REFERENCES [Notification]([NotificationId]), 
    CONSTRAINT [FK_NotificationRecipient_User] FOREIGN KEY ([RecipientId]) REFERENCES [User]([UserId])
)
