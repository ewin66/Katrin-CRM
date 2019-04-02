CREATE TABLE [dbo].[NotificationProfile]
(
	[NotificationProfileId] UNIQUEIDENTIFIER NOT NULL , 
	[CriteriaId] UNIQUEIDENTIFIER NULL, 
    [NotificationTemplateId] UNIQUEIDENTIFIER NULL, 
	[SubjectTemplateId] UNIQUEIDENTIFIER NULL, 
    [IsSys] BIT NULL,
    CONSTRAINT [PK_NotificationProfile] PRIMARY KEY ([NotificationProfileId]), 
    CONSTRAINT [FK_NotificationProfile_Criteria] FOREIGN KEY ([CriteriaId]) REFERENCES [Criteria]([CriteriaId]), 
    CONSTRAINT [FK_NotificationProfile_NotificationTemplate] FOREIGN KEY ([NotificationTemplateId]) REFERENCES [NotificationTemplate]([NotificationTemplateId]), 
    CONSTRAINT [FK_NotificationProfile_NotificationTemplate_Subject] FOREIGN KEY ([SubjectTemplateId]) REFERENCES [NotificationTemplate]([NotificationTemplateId])
)
