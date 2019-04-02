CREATE TABLE [dbo].[NotificationTemplate]
(
	[NotificationTemplateId] UNIQUEIDENTIFIER NOT NULL , 
    [SubjectTemplate] NVARCHAR(1000) NULL, 
    CONSTRAINT [PK_NotificationTemplate] PRIMARY KEY ([NotificationTemplateId])
)
