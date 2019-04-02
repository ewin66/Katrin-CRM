GO

CREATE TABLE [dbo].[ProjectVersion](
	[ProjectVersionId] [uniqueidentifier] NOT NULL,
	[ProjectId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[VersionName] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedById] [uniqueidentifier] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedById] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[VersionNumber] [timestamp] NULL,
 CONSTRAINT [PK_ProjectVersion] PRIMARY KEY CLUSTERED 
(
	[ProjectVersionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ProjectVersion]  WITH CHECK ADD  CONSTRAINT [FK_ProjectVersion_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO

ALTER TABLE [dbo].[ProjectVersion] CHECK CONSTRAINT [FK_ProjectVersion_Project]
GO

ALTER TABLE [dbo].[ProjectVersion]  WITH CHECK ADD  CONSTRAINT [FK_ProjectVersion_User] FOREIGN KEY([CreatedById])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[ProjectVersion] CHECK CONSTRAINT [FK_ProjectVersion_User]
GO

ALTER TABLE [dbo].[ProjectVersion]  WITH CHECK ADD  CONSTRAINT [FK_ProjectVersion_User1] FOREIGN KEY([ModifiedById])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[ProjectVersion] CHECK CONSTRAINT [FK_ProjectVersion_User1]
GO

INSERT [ProjectVersion](ProjectVersionId,ProjectId,VersionName,IsDeleted) 
SELECT 
  AttributeId = NEWID(),
  [ProjectId],
  [VersionName],
  IsDeleted
FROM [ProjectIteration]
WHERE [VersionName] IS NOT NULL

GO

ALTER TABLE [ProjectIteration] ADD [ProjectVersionId] uniqueidentifier null

GO

UPDATE [ProjectIteration] 
SET ProjectVersionId = v.ProjectVersionId
FROM [ProjectIteration] i
	INNER JOIN [ProjectVersion] v
	ON	v.ProjectId		= i.ProjectId
	AND	v.VersionName	= i.VersionName
	
GO

ALTER TABLE [ProjectIteration] DROP COLUMN [VersionName]

GO

ALTER TABLE dbo.ProjectIteration ADD CONSTRAINT
	FK_ProjectIteration_ProjectVersion FOREIGN KEY
	(
	ProjectVersionId
	) REFERENCES dbo.ProjectVersion
	(
	ProjectVersionId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO