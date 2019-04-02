
DECLARE @RoleId uniqueidentifier
SET	@RoleId = '2174AB96-C59F-4A4F-B3CD-5FE12727B7B4'
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

        
SET	@RoleId = 'C6FBFB92-51C0-4CF6-B8A6-1D5302C4E77B'

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
SET	@RoleId = '74247C6F-97BE-46C6-BF0A-6D4C4B03070A'
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
SET	@RoleId = '527CB559-0CC6-487F-A962-143BC9CD1484'
INSERT INTO [dbo].[UserRole]
           ([Id]
           ,[UserId]
           ,[RoleId])
SELECT	NEWID(),
		UserId,
		@RoleId
FROM	[User]
WHERE	FullName IN (N'叶建',N'王强',N'先晓雪',N'冉军')
