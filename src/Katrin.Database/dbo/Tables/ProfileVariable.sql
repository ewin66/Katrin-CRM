CREATE TABLE [dbo].[ProfileVariable]
(
	[ProfileVariableId] UNIQUEIDENTIFIER NOT NULL , 
	[NotificationProfileId] UNIQUEIDENTIFIER NULL, 
	[NotificationVariableId] UNIQUEIDENTIFIER NULL, 
    CONSTRAINT [PK_ProfileVariable] PRIMARY KEY ([ProfileVariableId]), 
    CONSTRAINT [FK_ProfileVariable_NotificationProfile] FOREIGN KEY ([NotificationProfileId]) REFERENCES [NotificationProfile]([NotificationProfileId]), 
    CONSTRAINT [FK_ProfileVariable_NotificationVariable] FOREIGN KEY ([NotificationVariableId]) REFERENCES [NotificationVariable]([NotificationVariableId])
)
