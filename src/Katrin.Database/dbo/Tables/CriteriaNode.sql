CREATE TABLE [dbo].[CriteriaNode]
(
	[CriteriaNodeId] UNIQUEIDENTIFIER NOT NULL , 
    [CriteriaId] UNIQUEIDENTIFIER NOT NULL, 
    [ParentNodeId] UNIQUEIDENTIFIER NOT NULL, 
    [Operator] NVARCHAR(100) NULL, 
    [OperatorType] NVARCHAR(100) NULL, 
    [CompareAttributeId] UNIQUEIDENTIFIER NULL, 
    [CompareValue] NVARCHAR(100) NULL, 
    CONSTRAINT [PK_CriteriaNode] PRIMARY KEY ([CriteriaNodeId]), 
    CONSTRAINT [FK_CriteriaNode_Criteria] FOREIGN KEY ([CriteriaId]) REFERENCES [Criteria]([CriteriaId]), 
    CONSTRAINT [FK_CriteriaNode_Attribute] FOREIGN KEY ([CompareAttributeId]) REFERENCES [Metadata_Attribute]([AttributeId])
)
