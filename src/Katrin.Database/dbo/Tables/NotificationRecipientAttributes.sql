CREATE TABLE [dbo].[NotificationRecipientAttributes]
(
	[NotificationRecipientAttributeId] UNIQUEIDENTIFIER NOT NULL , 
    [RecipientEntityId] UNIQUEIDENTIFIER NULL, 
    [AttributeId] UNIQUEIDENTIFIER NULL, 
    [NotificationProfileId] UNIQUEIDENTIFIER NULL, 
    [CriteriaId] UNIQUEIDENTIFIER NULL, 
    CONSTRAINT [FK_NotificationRecipientAttributes_Entity] FOREIGN KEY ([RecipientEntityId]) REFERENCES [Metadata_Entity]([EntityId]), 
    CONSTRAINT [FK_NotificationRecipientAttributes_Attribute] FOREIGN KEY ([AttributeId]) REFERENCES [Metadata_Attribute]([AttributeId]), 
    CONSTRAINT [FK_NotificationRecipientAttributes_NotificationProfile] FOREIGN KEY ([NotificationProfileId]) REFERENCES [NotificationProfile]([NotificationProfileId]), 
    CONSTRAINT [PK_NotificationRecipientAttributes] PRIMARY KEY ([NotificationRecipientAttributeId]), 
    CONSTRAINT [FK_NotificationRecipientAttributes_Criteria] FOREIGN KEY ([CriteriaId]) REFERENCES [Criteria]([CriteriaId])
)
