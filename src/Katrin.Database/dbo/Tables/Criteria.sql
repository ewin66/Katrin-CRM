CREATE TABLE [dbo].[Criteria]
(
	[CriteriaId] UNIQUEIDENTIFIER NOT NULL , 
    [Name] NVARCHAR(200) NULL, 
    CONSTRAINT [PK_Criteria] PRIMARY KEY ([CriteriaId])
)
