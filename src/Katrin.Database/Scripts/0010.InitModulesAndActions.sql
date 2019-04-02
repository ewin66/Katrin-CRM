-- =============================================
-- Script Template
-- =============================================

DELETE FROM RolePrivilege
DELETE FROM PrivilegeEntity
DELETE FROM Privilege
DELETE FROM UserRole
DELETE FROM [Role]

GO
CREATE FUNCTION [dbo].[UF_ParseValues] (@ValueList nvarchar(MAX))
RETURNS @ParsedValueList TABLE (iValue nvarchar(MAX))
AS
BEGIN
	DECLARE @sValue varchar(MAX)
	DECLARE @Pos int

	SET @ValueList = LTRIM(RTRIM(@ValueList)) + ','
	SET @Pos = CHARINDEX(',', @ValueList, 1)

	IF REPLACE(@ValueList, ',', '') <> ''
	BEGIN
		WHILE @Pos > 0
		BEGIN
			SET @sValue = LTRIM(RTRIM(LEFT(@ValueList, @Pos - 1)))

			IF @sValue <> ''
			BEGIN
				INSERT INTO @ParsedValueList (iValue) 
				VALUES (@sValue)
			END

			SET @ValueList = RIGHT(@ValueList, LEN(@ValueList) - @Pos)
			SET @Pos = CHARINDEX(',', @ValueList, 1)
		END
	END
	RETURN
END
GO

CREATE PROCEDURE [dbo].[InsertEntityPrivilege]
	@EntityName	nvarchar(100),
	@Name		 nvarchar(100),
	@AccessRight	int
AS
BEGIN

	DECLARE @PrivilegeId uniqueidentifier

	SET @PrivilegeId = NEWID()

	INSERT INTO [dbo].[Privilege]([PrivilegeId],[Name],[AccessRight]) VALUES(@PrivilegeId,@Name,@AccessRight)

	INSERT INTO [dbo].[PrivilegeEntity]
           ([PrivilegeEntityId]
           ,[PrivilegeId]
           ,[EntityName])
     VALUES
           (NEWID()
           ,@PrivilegeId
           ,@EntityName)

END
GO

CREATE PROCEDURE [dbo].[InsertPrivileges]
	@EntityName	nvarchar(100)
AS
BEGIN

	EXEC [dbo].[InsertEntityPrivilege] @EntityName,'Read',1
	EXEC [dbo].[InsertEntityPrivilege] @EntityName,'Create',2
	EXEC [dbo].[InsertEntityPrivilege] @EntityName,'Write',4
	EXEC [dbo].[InsertEntityPrivilege] @EntityName,'Delete',8
END
GO

EXEC [dbo].[InsertPrivileges] 'Lead'
EXEC [dbo].[InsertPrivileges] 'Opportunity'
EXEC [dbo].[InsertPrivileges] 'Quote'
EXEC [dbo].[InsertPrivileges] 'Contract'
EXEC [dbo].[InsertPrivileges] 'Invoice'
EXEC [dbo].[InsertPrivileges] 'Account'
EXEC [dbo].[InsertPrivileges] 'Contact'
EXEC [dbo].[InsertPrivileges] 'Product'
EXEC [dbo].[InsertPrivileges] 'User'
EXEC [dbo].[InsertPrivileges] 'Role'
EXEC [dbo].[InsertPrivileges] 'SystemSetting'
EXEC [dbo].[InsertEntityPrivilege] 'OpportunityReport','Read',1
EXEC [dbo].[InsertPrivileges] 'Project'
EXEC [dbo].[InsertPrivileges] 'ProjectTask'
EXEC [dbo].[InsertEntityPrivilege] 'ProjectReport','Read',1
EXEC [dbo].[InsertPrivileges] 'ProjectWeekReport'
EXEC [dbo].[InsertPrivileges] 'Attendance'
GO

DROP PROCEDURE [dbo].[InsertEntityPrivilege]
DROP PROCEDURE [dbo].[InsertPrivileges]

DROP FUNCTION [dbo].[UF_ParseValues]

DECLARE @RoleId uniqueidentifier
SET	@RoleId = NEWID()

INSERT INTO [dbo].[Role]
           (RoleId
           ,[RoleName])
VALUES	(@RoleId
		   ,'Administrators')

INSERT INTO [dbo].[RolePrivilege]
           ([RolePrivilegeId]
           ,[RoleId]
           ,[PrivilegeId])
SELECT	[RolePrivilegeId]	= NEWID(),
        [RoleId]			= @RoleId,
		[PrivilegeId]		= PrivilegeId
FROM	Privilege

INSERT INTO [dbo].[UserRole]
           ([Id]
           ,[UserId]
           ,[RoleId])

SELECT	Id			= NEWID(),
        [UserId]	=  '20c163a1-bf24-4282-af2b-728a8b4ad124',
        [RoleId]	= @RoleId

UNION ALL

SELECT	Id			= NEWID(),
        [UserId]	=  (SELECT UserId FROM [User] WHERE FullName = N'徐强'),
        [RoleId]	= @RoleId

        
SET	@RoleId = NEWID()

INSERT INTO [dbo].[Role]
           (RoleId
           ,[RoleName])
VALUES	(@RoleId
		   ,'Sales')

INSERT INTO [dbo].[RolePrivilege]
           ([RolePrivilegeId]
           ,[RoleId]
           ,[PrivilegeId])
SELECT	[RolePrivilegeId]	= NEWID(),
        [RoleId]			= @RoleId,
		[PrivilegeId]		= p.PrivilegeId
FROM	Privilege p
		INNER JOIN PrivilegeEntity pe
		ON	pe.PrivilegeId	= p.PrivilegeId
WHERE	pe.EntityName IN('Lead', 'Account','CustomerAddress', 'Contact','Opportunity','Product','Quote','QuoteLineItem','Contract','Invoice','InvoiceContract','Note')
AND		p.AccessRight <> 8

INSERT INTO [dbo].[RolePrivilege]
           ([RolePrivilegeId]
           ,[RoleId]
           ,[PrivilegeId])
SELECT	[RolePrivilegeId]	= NEWID(),
        [RoleId]			= @RoleId,
		[PrivilegeId]		= p.PrivilegeId
FROM	Privilege p
		INNER JOIN PrivilegeEntity pe
		ON	pe.PrivilegeId	= p.PrivilegeId
WHERE	pe.EntityName IN('OpportunityReport','ProjectReport')
AND		p.AccessRight = 1

INSERT INTO [dbo].[UserRole]
           ([Id]
           ,[UserId]
           ,[RoleId])
SELECT	NEWID(),
		UserId,
		@RoleId
FROM	[User]
WHERE	FullName IN (N'李晓宇',N'龚磊',N'凌元丽',N'康宝丹')

--------------Technican------------------
SET	@RoleId = NEWID()
INSERT INTO [dbo].[Role]
           (RoleId
           ,[RoleName])
VALUES	(@RoleId
		   ,'Technician')

INSERT INTO [dbo].[RolePrivilege]
           ([RolePrivilegeId]
           ,[RoleId]
           ,[PrivilegeId])
SELECT	[RolePrivilegeId]	= NEWID(),
        [RoleId]			= @RoleId,
		[PrivilegeId]		= p.PrivilegeId
FROM	Privilege p
		INNER JOIN PrivilegeEntity pe
		ON	pe.PrivilegeId	= p.PrivilegeId
WHERE	pe.EntityName IN('Lead','Opportunity','Quote','Contract')
AND		p.AccessRight = 1

INSERT INTO [dbo].[RolePrivilege]
           ([RolePrivilegeId]
           ,[RoleId]
           ,[PrivilegeId])
SELECT	[RolePrivilegeId]	= NEWID(),
        [RoleId]			= @RoleId,
		[PrivilegeId]		= p.PrivilegeId
FROM	Privilege p
		INNER JOIN PrivilegeEntity pe
		ON	pe.PrivilegeId	= p.PrivilegeId
WHERE	pe.EntityName IN('OpportunityReport','Project','ProjectTask','ProjectWeekReport')
AND		p.AccessRight <> 8

INSERT INTO [dbo].[UserRole]
           ([Id]
           ,[UserId]
           ,[RoleId])
SELECT	NEWID(),
		UserId,
		@RoleId
FROM	[User]
WHERE	FullName NOT IN (N'李晓宇',N'龚磊',N'凌元丽',N'徐强', N'康宝丹')
AND	[UserId]	<>  '20c163a1-bf24-4282-af2b-728a8b4ad124'

--------------Department Manager------------------
SET	@RoleId = NEWID()
INSERT INTO [dbo].[Role]
           (RoleId
           ,[RoleName])
VALUES	(@RoleId
		   ,'Department Manager')

INSERT INTO [dbo].[RolePrivilege]
           ([RolePrivilegeId]
           ,[RoleId]
           ,[PrivilegeId])
SELECT	[RolePrivilegeId]	= NEWID(),
        [RoleId]			= @RoleId,
		[PrivilegeId]		= p.PrivilegeId
FROM	Privilege p
		INNER JOIN PrivilegeEntity pe
		ON	pe.PrivilegeId	= p.PrivilegeId
WHERE	pe.EntityName IN('OpportunityReport','Project','ProjectTask','ProjectWeekReport', 'ProjectReport')
AND		p.AccessRight <> 8

INSERT INTO [dbo].[UserRole]
           ([Id]
           ,[UserId]
           ,[RoleId])
SELECT	NEWID(),
		UserId,
		@RoleId
FROM	[User]
WHERE	FullName IN (N'叶建',N'王强',N'先晓雪',N'冉军')
