CREATE TABLE [dbo].[NotificationVariable]
(
	[NotificationVariableId] UNIQUEIDENTIFIER NOT NULL , 
	[ParentId] UNIQUEIDENTIFIER NULL, 
	[RelatedAttributeId] UNIQUEIDENTIFIER NULL, 
	[Name] NVARCHAR(200) NULL,  
	[EntityId] UNIQUEIDENTIFIER NULL, 
    [NotificationUrl] NVARCHAR(200) NULL,  
    CONSTRAINT [PK_NotificationVariable] PRIMARY KEY ([NotificationVariableId]), 
    CONSTRAINT [FK_NotificationVariable_Metadata_Entity] FOREIGN KEY ([EntityId]) REFERENCES [Metadata_Entity](EntityId), 
    CONSTRAINT [FK_NotificationVariable_Metadata_Attribute] FOREIGN KEY ([RelatedAttributeId]) REFERENCES [Metadata_Attribute]([AttributeId])
)
