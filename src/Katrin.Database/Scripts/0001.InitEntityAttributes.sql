BEGIN TRANSACTION
DELETE FROM Subscription
DELETE FROM NotificationRecipientAttributes
DELETE FROM ProfileVariable
DELETE FROM NotificationVariable
DELETE FROM NotificationProfile
DELETE FROM CriteriaNode
DELETE FROM Criteria
DELETE FROM NotificationTemplate

DELETE FROM [Metadata_EntityRelationshipRole]
DELETE FROM [Metadata_EntityRelationshipRelationships]
DELETE FROM [Metadata_EntityRelationship]
DELETE FROM [Metadata_Relationship]
DELETE FROM Metadata_AttributePicklistValueMap
DELETE FROM Metadata_AttributePicklistValue
DELETE FROM Metadata_AttributeLookupValue
DELETE FROM Metadata_Attribute
DELETE FROM Metadata_AttributeType
DELETE FROM Metadata_OptionSet
DELETE FROM Metadata_LocalizedLabel
DELETE FROM PrivilegeEntity
DELETE FROM Metadata_Entity


------------根据指定的表名创建临时表,即从数据库中读取指定表的结构
CREATE TABLE #tmpEntity(
	[EntityId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](64) NULL,
	[PhysicalName] [nvarchar](64) NULL,
	[LogicalName] [nvarchar](64) NULL,
	[TableName] [nvarchar](64) NULL,
	[IsAuditEnabled] [bit] NOT NULL)
INSERT INTO #tmpEntity ([EntityId], [Name], [PhysicalName], [LogicalName], [TableName], [IsAuditEnabled])
SELECT	EntityId		= NEWID(),
		Name			= [TABLE_NAME],
		PhysicalName	= [TABLE_NAME],
		LogicalName		= Lower([TABLE_NAME]),
		TableName		= [TABLE_NAME],
		IsAuditEnabled	= 0
FROM [INFORMATION_SCHEMA].[TABLES]
WHERE TABLE_NAME IN ('Lead', 'Account','CustomerAddress', 'Contact', 'User'
,'Opportunity','Product','Quote','QuoteLineItem','TransactionCurrency','Contract'
,'Invoice','InvoiceContract','Department','Audit','Note','Role','SystemSetting'
,'TimeTracking','UserRole','RolePrivilege','Privilege','PrivilegeEntity'
,'ProjectTask','Project','ProjectMember','TaskTimeHistory','ProjectIteration','ProjectWeekReport','Attendance','ProjectVersion',
'Notification','NotificationRecipient')
  

---------初始化entity数据
INSERT INTO Metadata_Entity ([EntityId], [Name], [PhysicalName], [LogicalName], [TableName], [IsAuditEnabled])
SELECT	*
FROM	#tmpEntity

----------------------初始数据的类型
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000011', N'bigint')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000012', N'binary')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000013', N'bit')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000014', N'char')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000015', N'datetime')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000016', N'decimal')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000017', N'float')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000018', N'image')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000019', N'int')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-11000000001a', N'money')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-11000000001b', N'nchar')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-11000000001c', N'ntext')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-11000000001d', N'numeric')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-11000000001e', N'nvarchar')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-11000000001f', N'real')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000020', N'smalldatetime')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000021', N'smallint')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000022', N'smallmoney')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000023', N'sql_variant')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000024', N'text')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000025', N'timestamp')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000026', N'tinyint')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000027', N'uniqueidentifier')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000028', N'varbinary')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000029', N'varchar')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000030', N'picklist')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000031', N'lookup')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000032', N'primarykey')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000033', N'virtual')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000034', N'customer')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000035', N'owner')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000036', N'state')
INSERT INTO [dbo].[Metadata_AttributeType] ([AttributeTypeId], [Description]) VALUES (N'00000000-0000-0000-00aa-110000000037', N'status')



--------------------根据entity中的表获得相应表中的字段属性
INSERT	Metadata_Attribute(
		AttributeId,
		AttributeTypeId,
		Name,
		PhysicalName,
		Length,
		IsNullable,
		EntityId,
		ColumnNumber,
		LogicalName,
		IsAuditEnabled,
		TableColumnName,
		IsPKAttribute)
SELECT	AttributeId = NEWID(),
		AttributeTypeId = CASE WHEN c.COLUMN_NAME LIKE '%Code' THEN '00000000-0000-0000-00AA-110000000030'
							ELSE t.AttributeTypeId END, ---获得字段对应的数据类型
		Name			= Lower(c.COLUMN_NAME),
		PhysicalName	= c.COLUMN_NAME,
		Length			= c.CHARACTER_MAXIMUM_LENGTH,
		IsNullable		= CASE c.IS_NULLABLE WHEN 'NO' THEN 0 ELSE 1 END,
		EntityId		= e.EntityId,
		ColumnNumber	= ORDINAL_POSITION,
		LogicalName		= Lower(c.COLUMN_NAME),
		IsAuditEnabled	= 0,
		TableColumnName	= c.COLUMN_NAME,
		IsPKAttribute	=  CASE WHEN EXISTS(	select 1
												  from INFORMATION_SCHEMA.TABLE_CONSTRAINTS as tc
												  join INFORMATION_SCHEMA.KEY_COLUMN_USAGE as kcu
													on kcu.CONSTRAINT_SCHEMA = tc.CONSTRAINT_SCHEMA
												   and kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME
												   and kcu.TABLE_SCHEMA = tc.TABLE_SCHEMA
												   and kcu.TABLE_NAME = tc.TABLE_NAME
												 where tc.CONSTRAINT_TYPE in ( 'PRIMARY KEY')
												 AND	kcu.TABLE_NAME = e.TableName COLLATE DATABASE_DEFAULT
												 AND	kcu.COLUMN_NAME = c.COLUMN_NAME COLLATE DATABASE_DEFAULT)
								THEN 1
								ELSE 0 
							END
FROM	[INFORMATION_SCHEMA].[COLUMNS] c
		INNER JOIN #tmpEntity e
		ON	e.TableName	COLLATE DATABASE_DEFAULT = c.TABLE_NAME COLLATE DATABASE_DEFAULT
		LEFT OUTER JOIN Metadata_AttributeType t
		ON	t.Description = c.DATA_Type

-------------------删除临时表
DROP TABLE #tmpEntity

----------设置类似StatusCode的字段都不为空
UPDATE Metadata_Attribute
SET	IsNullable = 0
WHERE PhysicalName = 'StatusCode'

---------------SET ATTRIBUTE COPY 
UPDATE Metadata_Attribute SET IsCopyEnabled=1
UPDATE Metadata_Attribute SET IsCopyEnabled=0 WHERE IsPKAttribute=1
UPDATE Metadata_Attribute SET IsCopyEnabled=0 WHERE TableColumnName like '%create%' OR 
TableColumnName like '%modif%'

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='Lead')
AND TableColumnName IN ('Subject','FirstName','LastName')

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='Opportunity')
AND TableColumnName IN ('Name')

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='Account')
AND TableColumnName IN ('Name')

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='Contact')
AND TableColumnName IN ('JobTitle','FirstName','NickName','MiddleName','LastName',
'FullName')

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='Contract')
AND TableColumnName IN ('ContractNumber','Title','OpportunityId')

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='Invoice')
AND TableColumnName IN ('InvoiceNumber','Name','PaidAmount')

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='Product')
AND TableColumnName IN ('Name','ProductNumber','Price')

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='Project')
AND TableColumnName IN ('Name')

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='ProjectIteration')
AND TableColumnName IN ('Name','Objective','StartDate','Deadline')

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='ProjectTask')
AND TableColumnName IN ('Name','QuoteWorkHours','ActualWorkHours','ActualInput','Effort','Overtime')

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='ProjectVersion')
AND TableColumnName IN ('VersionNumber','VersionName')

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='ProjectWeekReport')
AND TableColumnName IN ('Name')

UPDATE Metadata_Attribute SET IsCopyEnabled = 0
WHERE Metadata_Attribute.EntityId = 
(SELECT TOP 1 EntityId FROM  Metadata_Entity WHERE PhysicalName='Quote')
AND TableColumnName IN ('Name','QuoteNumber')

COMMIT


