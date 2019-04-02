DELETE FROM [Metadata_EntityRelationshipRole]
DELETE FROM [Metadata_EntityRelationshipRelationships]
DELETE FROM [Metadata_EntityRelationship]
DELETE FROM [Metadata_Relationship]

INSERT INTO [Metadata_Relationship](
			[RelationshipId]
           ,[Name]
           ,[ReferencingEntityId]
           ,[ReferencingAttributeId]
           ,[ReferencedEntityId]
           ,[ReferencedAttributeId]
           ,[RelationshipType]
           ,[CascadeDelete])
SELECT	[RelationshipId]		= NEWID(),
		[Name]					= OBJECT_NAME(s.constid),
		[ReferencingEntityId]	= (SELECT EntityId FROM Metadata_Entity WHERE Name = o1.name),
		[ReferencingAttributeId]= (SELECT attr.AttributeId FROM Metadata_Attribute attr 
												INNER JOIN  Metadata_Entity e 
												ON e.EntityId	= attr.EntityId
										WHERE	attr.Name = c1.name AND e.Name = o1.name),
		[ReferencedEntityId]	= (SELECT EntityId FROM Metadata_Entity WHERE Name = o2.name),
		[ReferencedAttributeId]	= (SELECT attr.AttributeId FROM Metadata_Attribute attr 
												INNER JOIN  Metadata_Entity e 
												ON e.EntityId	= attr.EntityId
										WHERE	attr.Name = c2.name AND e.Name = o2.name),
		[RelationshipType]		= 1,
		[CascadeDelete]			= 1
FROM	sysforeignkeys s
		INNER JOIN sysobjects o1
		ON	o1.id		= s.fkeyid
		INNER JOIN sysobjects o2
		ON	o2.id		= s.rkeyid
		INNER JOIN syscolumns c1
		ON	c1.id		= s.fkeyid
		AND	c1.colid	= s.fkey
		INNER JOIN syscolumns c2
		ON	c2.id		= s.rkeyid
		AND	c2.colid	= s.rkey
WHERE EXISTS(SELECT 1 FROM Metadata_Entity WHERE Name = o1.name)

INSERT INTO [Metadata_Relationship](
			[RelationshipId]
           ,[Name]
           ,[ReferencingEntityId]
           ,[ReferencingAttributeId]
           ,[ReferencedEntityId]
           ,[ReferencedAttributeId]
           ,[RelationshipType]
           ,[CascadeDelete])

SELECT	[RelationshipId]		= NEWID(),
		[Name]					= 'User_Audit',
		[ReferencingEntityId]	= (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Audit'),
		[ReferencingAttributeId]= (	SELECT attr.AttributeId
									FROM	Metadata_Attribute attr 
											INNER JOIN  Metadata_Entity e 
											ON e.EntityId	= attr.EntityId
									WHERE	attr.Name = 'UserId' AND e.Name = 'Audit'),
		[ReferencedEntityId]	= (SELECT EntityId FROM Metadata_Entity WHERE Name = 'User'),
		[ReferencedAttributeId]	= (SELECT attr.AttributeId FROM Metadata_Attribute attr 
												INNER JOIN  Metadata_Entity e 
												ON e.EntityId	= attr.EntityId
										WHERE	attr.Name = 'UserId' AND e.Name = 'User'),
		[RelationshipType]		= 1,
		[CascadeDelete]			= 1

GO

CREATE PROCEDURE [dbo].[CreateEntityOneToManyRelathionshipRole] 
	@SchemaName			nvarchar(255),
	@ReferencingEntityName nvarchar(64),
	@ReferencingAttributeName nvarchar(64),
	@ReferencedEntityName nvarchar(64),
	@ReferencedAttributeName nvarchar(64)
AS
BEGIN
	DECLARE	@EntityRelationshipId uniqueidentifier

	SET @EntityRelationshipId	= NEWID()

	INSERT INTO [dbo].[Metadata_EntityRelationship]
			   ([EntityRelationshipId]
			   ,[SchemaName]
			   ,[EntityRelationshipType]
			   ,[IsCustomRelationship]
			   ,[IsCustomizable])
	SELECT	[EntityRelationshipId]		= @EntityRelationshipId,
			[SchemaName]				= @SchemaName,
			[EntityRelationshipType]	= 0,
			[IsCustomRelationship]		= 0,
			[IsCustomizable]			= 0

	INSERT INTO [dbo].[Metadata_EntityRelationshipRelationships]
			   ([EntityRelationshipRelationshipsId]
			   ,[EntityRelationshipId]
			   ,[RelationshipId])
	SELECT	EntityRelationshipRelationshipsId	= NEWID(),
			[EntityRelationshipId]				= @EntityRelationshipId,
			[RelationshipId]					= (	SELECT	r.RelationshipId
													FROM	Metadata_Relationship r
															INNER JOIN Metadata_Entity referencingEntity
															ON	referencingEntity.EntityId = r.ReferencingEntityId
															AND	referencingEntity.Name = @ReferencingEntityName
															INNER JOIN Metadata_Attribute referencingAttribute
															ON	referencingAttribute.EntityId	= r.ReferencingEntityId
															AND	referencingAttribute.AttributeId = r.ReferencingAttributeId
															AND	referencingAttribute.PhysicalName = @ReferencingAttributeName
															INNER JOIN Metadata_Entity referencedEntity
															ON	referencedEntity.EntityId = r.ReferencedEntityId
															AND	referencedEntity.Name = @ReferencedEntityName
															INNER JOIN Metadata_Attribute referencedAttribute
															ON	referencedAttribute.EntityId	= r.ReferencedEntityId
															AND	referencedAttribute.AttributeId = r.ReferencedAttributeId
															AND	referencedAttribute.PhysicalName = @ReferencedAttributeName)
	INSERT INTO [dbo].[Metadata_EntityRelationshipRole]
			   ([EntityRelationshipRoleId]
			   ,[EntityRelationshipId]
			   ,[EntityId]
			   ,[RelationshipRoleType])
	SELECT	[EntityRelationshipRoleId]	= NEWID(),
			[EntityRelationshipId]		= @EntityRelationshipId,
			[EntityId]					= (	SELECT	EntityId FROM	Metadata_Entity WHERE Name = @ReferencingEntityName),
			[RelationshipRoleType]		= 1

	UNION ALL

	SELECT	[EntityRelationshipRoleId]	= NEWID(),
			[EntityRelationshipId]		= @EntityRelationshipId,
			[EntityId]					= (	SELECT	EntityId FROM	Metadata_Entity WHERE Name = @ReferencedEntityName),
			[RelationshipRoleType]		= 0
END
GO

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'opportunity_lead', 'opportunity','OriginatingLeadId', 'lead','LeadId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'opportunity_department', 'opportunity', 'DepartmentId','department','DepartmentId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'opportunity_user_owner', 'opportunity', 'OwnerId','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'opportunity_user_modifiedBy', 'opportunity', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'opportunity_user_createdBy', 'opportunity', 'CreatedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'opportunity_user_technicianId', 'opportunity', 'TechnicianId','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'opportunity_transactionCurrency', 'opportunity', 'TransactionCurrencyId','TransactionCurrency','TransactionCurrencyId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'quote_opportunity', 'quote','OpportunityId', 'opportunity','OpportunityId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'quote_account', 'quote','CustomerId', 'Account','AccountId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'quote_customeraddress', 'quote','BillTo_AddressId', 'customeraddress','CustomerAddressId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'quote_user', 'quote','OwnerId', 'user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'quotelineitem_quote', 'quotelineitem','QuoteId', 'quote','QuoteId'


EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'contract_opportunity', 'contract','OpportunityId', 'opportunity','OpportunityId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'contract_account', 'contract','BillingCustomerId', 'account','AccountId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'contract_user', 'contract','OwnerId', 'user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'contract_department', 'contract','DepartmentId', 'department','DepartmentId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'invoice_account', 'invoice', 'BillingCustomerId','account','AccountId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'invoice_user', 'invoice','OwnerId', 'user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'lead_department', 'lead', 'DepartmentId','department','DepartmentId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'lead_user_owner', 'lead', 'OwnerId','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'lead_user_modifiedBy', 'lead', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'lead_user_createdBy', 'lead', 'CreatedById','user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'audit_user', 'audit','UserId', 'user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'privilegeEntity_privilege', 'PrivilegeEntity','PrivilegeId', 'Privilege','PrivilegeId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'timetracking_user', 'timetracking','RecordById', 'user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'note_user_createdby', 'Note','CreatedById', 'User','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'note_user_modifiedBy', 'Note','ModifiedById', 'User','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'account_department', 'account', 'DepartmentId','department','DepartmentId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'account_user', 'account','OwnerId', 'user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'account_contact', 'account','PrimaryContactId', 'contact','ContactId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'contract_user_modifiedBy', 'contract', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'contract_user_createdBy', 'contract', 'CreatedById','user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'invoice_user_modifiedBy', 'invoice', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'invoice_user_createdBy', 'invoice', 'CreatedById','user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'contact_user_modifiedBy', 'contact', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'contact_user_createdBy', 'contact', 'CreatedById','user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'account_user_modifiedBy', 'account', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'account_user_createdBy', 'account', 'CreatedById','user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'quote_user_modifiedBy', 'quote', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'quote_user_createdBy', 'quote', 'CreatedById','user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'product_user_modifiedBy', 'product', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'product_user_createdBy', 'product', 'CreatedById','user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'user_user_modifiedBy', 'user', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'user_user_createdBy', 'user', 'CreatedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'user_department_DepartmentId', 'user', 'DepartmentId','Department','DepartmentId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'project_user_manager', 'project', 'ManagerId','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'project_user_modifiedBy', 'project', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'project_user_createdBy', 'project', 'CreatedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'project_Contract_ContractId', 'project', 'ContractId','Contract','ContractId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'project_user_SaleServiceId', 'project', 'SaleServiceId','user','UserId'
	

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projecttask_project_ProjectId', 'projecttask', 'ProjectId','project','ProjectId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projecttask_projectiteration_ProjectIterationId', 'projecttask', 'ProjectIterationId','projectiteration','ProjectIterationId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projecttask_user_owner', 'projecttask', 'OwnerId','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projecttask_user_modifiedBy', 'projecttask', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projecttask_user_createdBy', 'projecttask', 'CreatedById','user','UserId'	

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projectiteration_project_ProjectId', 'projectiteration', 'ProjectId','project','ProjectId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projectiteration_projectversion_ProjectVersionId', 'projectiteration', 'ProjectVersionId','projectversion','ProjectVersionId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projectiteration_user_modifiedBy', 'projectiteration', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projectiteration_user_createdBy', 'projectiteration', 'CreatedById','user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projectweekreport_user_modifiedBy', 'projectweekreport', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projectweekreport_user_createdBy', 'projectweekreport', 'CreatedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projectweekreport_projectiteration_projectiterationid', 'projectweekreport', 'projectiterationid','projectiteration','projectiterationid'						
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projectweekreport_project_projectid', 'projectweekreport', 'projectid','project','projectid'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'tasktimehistory_projecttask_taskid', 'tasktimehistory', 'taskid','projecttask','taskid'	

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'Attendance_user_modifiedBy', 'Attendance', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'Attendance_user_createdBy', 'Attendance', 'CreatedById','user','UserId'		
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'Attendance_user_recordperson', 'Attendance', 'RecordPersonId','user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projectversion_project_ProjectId', 'projectversion', 'ProjectId','project','ProjectId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projectversion_user_modifiedBy', 'projectversion', 'ModifiedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'projectversion_user_createdBy', 'projectversion', 'CreatedById','user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'Notification_user_createdBy', 'Notification', 'CreatedById','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'Notification_user_ModifiedBy', 'Notification', 'ModifiedById','user','UserId'

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'NotificationRecipient_user', 'NotificationRecipient', 'RecipientId','user','UserId'
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'NotificationRecipient_Notification', 'NotificationRecipient', 'NotificationId','Notification','NotificationId'
				
DROP PROCEDURE [dbo].[CreateEntityOneToManyRelathionshipRole]
GO

CREATE PROCEDURE [dbo].[CreateEntityManyToManyRelathionshipRole] 
	@SchemaName			nvarchar(255),
	@EntityName1 nvarchar(64),
	@EntityName2 nvarchar(64),
	@RelationshipEntityName nvarchar(64)
AS
BEGIN
	DECLARE	@EntityRelationshipId uniqueidentifier

	SET @EntityRelationshipId	= NEWID()

	INSERT INTO [dbo].[Metadata_EntityRelationship]
			   ([EntityRelationshipId]
			   ,[SchemaName]
			   ,[EntityRelationshipType]
			   ,[IsCustomRelationship]
			   ,[IsCustomizable])
	SELECT	[EntityRelationshipId]		= @EntityRelationshipId,
			[SchemaName]				= @SchemaName,
			[EntityRelationshipType]	= 1,
			[IsCustomRelationship]		= 0,
			[IsCustomizable]			= 0

	INSERT INTO [dbo].[Metadata_EntityRelationshipRole]
			   ([EntityRelationshipRoleId]
			   ,[EntityRelationshipId]
			   ,[EntityId]
			   ,[RelationshipRoleType])
	SELECT	[EntityRelationshipRoleId]	= NEWID(),
			[EntityRelationshipId]		= @EntityRelationshipId,
			[EntityId]					= (	SELECT	EntityId FROM	Metadata_Entity WHERE Name = @EntityName1),
			[RelationshipRoleType]		= 2

	UNION ALL

	SELECT	[EntityRelationshipRoleId]	= NEWID(),
			[EntityRelationshipId]		= @EntityRelationshipId,
			[EntityId]					= (	SELECT	EntityId FROM	Metadata_Entity WHERE Name = @EntityName2),
			[RelationshipRoleType]		= 2

	UNION ALL

	SELECT	[EntityRelationshipRoleId]	= NEWID(),
			[EntityRelationshipId]		= @EntityRelationshipId,
			[EntityId]					= (	SELECT	EntityId FROM	Metadata_Entity WHERE Name = @RelationshipEntityName),
			[RelationshipRoleType]		= 3


	INSERT INTO [dbo].[Metadata_EntityRelationshipRelationships]
			   ([EntityRelationshipRelationshipsId]
			   ,[EntityRelationshipId]
			   ,[RelationshipId])
	SELECT	EntityRelationshipRelationshipsId	= NEWID(),
			[EntityRelationshipId]				= @EntityRelationshipId,
			[RelationshipId]					= r.RelationshipId
	FROM	Metadata_Relationship r
			INNER JOIN Metadata_Entity referencingEntity
			ON	referencingEntity.EntityId = r.ReferencingEntityId
			AND	referencingEntity.Name = @RelationshipEntityName
END
GO

EXEC dbo.[CreateEntityManyToManyRelathionshipRole] 'invoicecontract_association', 'invoice', 'contract','InvoiceContract'
EXEC dbo.[CreateEntityManyToManyRelathionshipRole] 'userrole_association', 'user','role', 'UserRole'
EXEC dbo.[CreateEntityManyToManyRelathionshipRole] 'roleprivilege_association', 'role','privilege', 'RolePrivilege'
EXEC dbo.[CreateEntityManyToManyRelathionshipRole] 'projectmember_association', 'project', 'user','ProjectMember'
DROP PROCEDURE [dbo].[CreateEntityManyToManyRelathionshipRole]
GO

-----------------------------set entity Related--------------------------------
Update Metadata_EntityRelationshipRole set NavPanelDisplayOption=0
------------------------Lead------------------------------
update  Metadata_EntityRelationshipRole  set NavPanelDisplayOption=1 where 
EntityRelationshipRoleId in
(
SELECT a.EntityRelationshipRoleId FROM Metadata_EntityRelationshipRole A 
 INNER JOIN Metadata_Entity B
 ON A.EntityId= B.EntityId
 INNER JOIN Metadata_EntityRelationship C
 ON A.EntityRelationshipId = C.EntityRelationshipId
 WHERE B.PhysicalName='Lead' and c.SchemaName='opportunity_lead'
)

---------------------Opportunity----------------------------
update  Metadata_EntityRelationshipRole  set NavPanelDisplayOption=1 where 
EntityRelationshipRoleId in
(
SELECT a.EntityRelationshipRoleId FROM Metadata_EntityRelationshipRole A 
 INNER JOIN Metadata_Entity B
 ON A.EntityId= B.EntityId
 INNER JOIN Metadata_EntityRelationship C
 ON A.EntityRelationshipId = C.EntityRelationshipId
 WHERE B.PhysicalName='Opportunity' and c.SchemaName in('opportunity_lead','contract_opportunity','quote_opportunity')
 )
 -----------------------Contract------------------------------
 update  Metadata_EntityRelationshipRole  set NavPanelDisplayOption=1 where 
EntityRelationshipRoleId in
(
SELECT a.EntityRelationshipRoleId FROM Metadata_EntityRelationshipRole A 
 INNER JOIN Metadata_Entity B
 ON A.EntityId= B.EntityId
 INNER JOIN Metadata_EntityRelationship C
 ON A.EntityRelationshipId = C.EntityRelationshipId
 WHERE B.PhysicalName='Contract' 
 and c.SchemaName in('contract_account','contract_opportunity','invoicecontract_association')
 )
 ----------------------Invoice----------------------------------
 update  Metadata_EntityRelationshipRole  set NavPanelDisplayOption=1 where 
EntityRelationshipRoleId in
(
SELECT a.EntityRelationshipRoleId FROM Metadata_EntityRelationshipRole A 
 INNER JOIN Metadata_Entity B
 ON A.EntityId= B.EntityId
 INNER JOIN Metadata_EntityRelationship C
 ON A.EntityRelationshipId = C.EntityRelationshipId
 WHERE B.PhysicalName='Invoice' 
 and c.SchemaName in('invoice_account','invoicecontract_association')
 )

 -----------------------User------------------------------
 update  Metadata_EntityRelationshipRole  set NavPanelDisplayOption=0 where 
EntityRelationshipRoleId in
(
SELECT a.EntityRelationshipRoleId FROM Metadata_EntityRelationshipRole A 
 INNER JOIN Metadata_Entity B
 ON A.EntityId= B.EntityId
 INNER JOIN Metadata_EntityRelationship C
 ON A.EntityRelationshipId = C.EntityRelationshipId
 WHERE B.PhysicalName='User' 
 and c.SchemaName in('projectmember_association')
 )
 ----------------------Project----------------------------------
 update  Metadata_EntityRelationshipRole  set NavPanelDisplayOption=0 where 
EntityRelationshipRoleId in
(
SELECT a.EntityRelationshipRoleId FROM Metadata_EntityRelationshipRole A 
 INNER JOIN Metadata_Entity B
 ON A.EntityId= B.EntityId
 INNER JOIN Metadata_EntityRelationship C
 ON A.EntityRelationshipId = C.EntityRelationshipId
 WHERE B.PhysicalName='Project' 
 and c.SchemaName in('projectmember_association')
 )

 -------------------Account----------------------------
 update  Metadata_EntityRelationshipRole  set NavPanelDisplayOption=1 where 
EntityRelationshipRoleId in
(
SELECT a.EntityRelationshipRoleId FROM Metadata_EntityRelationshipRole A 
 INNER JOIN Metadata_Entity B
 ON A.EntityId= B.EntityId
 INNER JOIN Metadata_EntityRelationship C
 ON A.EntityRelationshipId = C.EntityRelationshipId
 WHERE B.PhysicalName='Account' 
 and c.SchemaName in('contract_account','invoice_account','quote_account')
 )
 -------------------Quote----------------------
 update  Metadata_EntityRelationshipRole  set NavPanelDisplayOption=1 where 
EntityRelationshipRoleId in
(
SELECT a.EntityRelationshipRoleId FROM Metadata_EntityRelationshipRole A 
 INNER JOIN Metadata_Entity B
 ON A.EntityId= B.EntityId
 INNER JOIN Metadata_EntityRelationship C
 ON A.EntityRelationshipId = C.EntityRelationshipId
 WHERE B.PhysicalName='Quote' 
 and c.SchemaName in('quote_opportunity')
 )


 ------------------------------------------------------------建立一对多关系-------------------------------
 INSERT INTO [Metadata_Relationship](
			[RelationshipId]
           ,[Name]
           ,[ReferencingEntityId]
           ,[ReferencingAttributeId]
           ,[ReferencedEntityId]
           ,[ReferencedAttributeId]
           ,[RelationshipType]
           ,[CascadeDelete])

SELECT	[RelationshipId]		= NEWID(),
		[Name]					= 'Opportunity_Account',
		[ReferencingEntityId]	= (	SELECT EntityId FROM Metadata_Entity WHERE Name = 'Opportunity'),
		[ReferencingAttributeId]= (	SELECT attr.AttributeId
									FROM	Metadata_Attribute attr 
											INNER JOIN  Metadata_Entity e 
											ON e.EntityId	= attr.EntityId
									WHERE	attr.Name = 'CustomerId' AND e.Name = 'Opportunity'),
		[ReferencedEntityId]	= (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Account'),
		[ReferencedAttributeId]	= (SELECT attr.AttributeId FROM Metadata_Attribute attr 
												INNER JOIN  Metadata_Entity e 
												ON e.EntityId	= attr.EntityId
										WHERE	attr.Name = 'AccountId' AND e.Name = 'Account'),
		[RelationshipType]		= 1,
		[CascadeDelete]			= 1

		 INSERT INTO [Metadata_Relationship](
			[RelationshipId]
           ,[Name]
           ,[ReferencingEntityId]
           ,[ReferencingAttributeId]
           ,[ReferencedEntityId]
           ,[ReferencedAttributeId]
           ,[RelationshipType]
           ,[CascadeDelete])

SELECT	[RelationshipId]		= NEWID(),
		[Name]					= 'Project_Account',
		[ReferencingEntityId]	= (	SELECT EntityId FROM Metadata_Entity WHERE Name = 'Project'),
		[ReferencingAttributeId]= (	SELECT attr.AttributeId
									FROM	Metadata_Attribute attr 
											INNER JOIN  Metadata_Entity e 
											ON e.EntityId	= attr.EntityId
									WHERE	attr.Name = 'CustomerId' AND e.Name = 'Project'),
		[ReferencedEntityId]	= (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Account'),
		[ReferencedAttributeId]	= (SELECT attr.AttributeId FROM Metadata_Attribute attr 
												INNER JOIN  Metadata_Entity e 
												ON e.EntityId	= attr.EntityId
										WHERE	attr.Name = 'AccountId' AND e.Name = 'Account'),
		[RelationshipType]		= 1,
		[CascadeDelete]			= 1
GO

CREATE PROCEDURE [dbo].[CreateEntityOneToManyRelathionshipRole] 
	@SchemaName			nvarchar(255),
	@ReferencingEntityName nvarchar(64),
	@ReferencingAttributeName nvarchar(64),
	@ReferencedEntityName nvarchar(64),
	@ReferencedAttributeName nvarchar(64),
	@DisplayRelation int
AS
BEGIN
	DECLARE	@EntityRelationshipId uniqueidentifier

	SET @EntityRelationshipId	= NEWID()

	INSERT INTO [dbo].[Metadata_EntityRelationship]
			   ([EntityRelationshipId]
			   ,[SchemaName]
			   ,[EntityRelationshipType]
			   ,[IsCustomRelationship]
			   ,[IsCustomizable])
	SELECT	[EntityRelationshipId]		= @EntityRelationshipId,
			[SchemaName]				= @SchemaName,
			[EntityRelationshipType]	= 0,
			[IsCustomRelationship]		= 0,
			[IsCustomizable]			= 0

	INSERT INTO [dbo].[Metadata_EntityRelationshipRelationships]
			   ([EntityRelationshipRelationshipsId]
			   ,[EntityRelationshipId]
			   ,[RelationshipId])
	SELECT	EntityRelationshipRelationshipsId	= NEWID(),
			[EntityRelationshipId]				= @EntityRelationshipId,
			[RelationshipId]					= (	SELECT	r.RelationshipId
													FROM	Metadata_Relationship r
															INNER JOIN Metadata_Entity referencingEntity
															ON	referencingEntity.EntityId = r.ReferencingEntityId
															AND	referencingEntity.Name = @ReferencingEntityName
															INNER JOIN Metadata_Attribute referencingAttribute
															ON	referencingAttribute.EntityId	= r.ReferencingEntityId
															AND	referencingAttribute.AttributeId = r.ReferencingAttributeId
															AND	referencingAttribute.PhysicalName = @ReferencingAttributeName
															INNER JOIN Metadata_Entity referencedEntity
															ON	referencedEntity.EntityId = r.ReferencedEntityId
															AND	referencedEntity.Name = @ReferencedEntityName
															INNER JOIN Metadata_Attribute referencedAttribute
															ON	referencedAttribute.EntityId	= r.ReferencedEntityId
															AND	referencedAttribute.AttributeId = r.ReferencedAttributeId
															AND	referencedAttribute.PhysicalName = @ReferencedAttributeName)
	INSERT INTO [dbo].[Metadata_EntityRelationshipRole]
			   ([EntityRelationshipRoleId]
			   ,[EntityRelationshipId]
			   ,[EntityId]
			   ,[RelationshipRoleType]
			   ,[NavPanelDisplayOption])
	SELECT	[EntityRelationshipRoleId]	= NEWID(),
			[EntityRelationshipId]		= @EntityRelationshipId,
			[EntityId]					= (	SELECT	EntityId FROM	Metadata_Entity WHERE Name = @ReferencingEntityName),
			[RelationshipRoleType]		= 1,
			0

	UNION ALL

	SELECT	[EntityRelationshipRoleId]	= NEWID(),
			[EntityRelationshipId]		= @EntityRelationshipId,
			[EntityId]					= (	SELECT	EntityId FROM	Metadata_Entity WHERE Name = @ReferencedEntityName),
			[RelationshipRoleType]		= 0,
			@DisplayRelation
END
GO

EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'opportunity_account', 'opportunity','CustomerId', 'Account','AccountId',1
EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'project_account', 'project','CustomerId', 'Account','AccountId',0
									
DROP PROCEDURE [dbo].[CreateEntityOneToManyRelathionshipRole]
GO
