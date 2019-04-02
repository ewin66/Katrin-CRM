BEGIN TRANSACTION
DELETE FROM Subscription
DELETE FROM NotificationRecipientAttributes
DELETE FROM ProfileVariable
DELETE FROM NotificationVariable
DELETE FROM NotificationProfile
DELETE FROM CriteriaNode
DELETE FROM Criteria
DELETE FROM NotificationTemplate

DECLARE @ObjectColumnName nvarchar(100)
SET @ObjectColumnName = 'TEMPLET'
DELETE FROM Metadata_LocalizedLabel WHERE ObjectColumnName = @ObjectColumnName

GO
-----------------------***************************--------------
CREATE PROCEDURE [dbo].[InitCriteria] 
@CriteriaId			UNIQUEIDENTIFIER,
@Name NVARCHAR(200)
AS
BEGIN
INSERT INTO Criteria(CriteriaId,Name) VALUES (@CriteriaId,@Name)
END
GO
------------------**************************************---------------------
CREATE PROCEDURE [dbo].[InitCriteriaNode] 
@CriteriaNodeId UNIQUEIDENTIFIER,
@ParentNodeId UNIQUEIDENTIFIER,
@CriteriaId			UNIQUEIDENTIFIER,
@Operator NVARCHAR(100),
@OperatorType NVARCHAR(100) ,
@CompareEntityName NVARCHAR(100),
@CompareAttrName NVARCHAR(100),
@CompareValue NVARCHAR(100)
AS
BEGIN
DECLARE @CompareAttributeId uniqueidentifier
SELECT	@CompareAttributeId = a.AttributeId
FROM Metadata_Entity e
INNER JOIN Metadata_Attribute a 
ON e.EntityId = a.EntityId
WHERE e.Name = @CompareEntityName
AND a.TableColumnName = @CompareAttrName
INSERT INTO CriteriaNode(CriteriaNodeId,CriteriaId,ParentNodeId,Operator,OperatorType,CompareAttributeId,CompareValue)
VALUES(@CriteriaNodeId,@CriteriaId,@ParentNodeId,@Operator,@OperatorType,@CompareAttributeId,@CompareValue)
END
GO
-----------------------***********************************------------------
CREATE PROCEDURE [dbo].[InitTemplate] 
@NotificationTemplateId UNIQUEIDENTIFIER,
@SubjectTemplate NVARCHAR(1000)
AS
BEGIN
INSERT INTO NotificationTemplate(NotificationTemplateId,SubjectTemplate) VALUES(@NotificationTemplateId,@SubjectTemplate)
END
GO
-------------------------*****************************-------------------------
CREATE PROCEDURE [dbo].[InitNotificationVariable] 
@NotificationVariableId UNIQUEIDENTIFIER,
@ParentId UNIQUEIDENTIFIER,
@RelatedAttributeName  NVARCHAR(200),
@Name NVARCHAR(200),
@EntityName NVARCHAR(200),
@NotificationUrl NVARCHAR(200)
AS
BEGIN
declare @EntityId UNIQUEIDENTIFIER

SELECT	@EntityId = EntityId
FROM Metadata_Entity WHERE Name = @EntityName

declare @RelatedAttributeId UNIQUEIDENTIFIER
set @RelatedAttributeId = null
if @ParentId is not null AND @RelatedAttributeName IS NOT NULL AND @RelatedAttributeName<>''
begin
SELECT @RelatedAttributeId = A.AttributeId
FROM Metadata_Attribute A INNER JOIN Metadata_Entity B ON A.EntityId = B.EntityId
WHERE  A.TableColumnName =  @RelatedAttributeName
AND B.EntityId IN (SELECT EntityId FROM NotificationVariable WHERE NotificationVariableId=@ParentId)
end
INSERT INTO NotificationVariable(NotificationVariableId,ParentId,RelatedAttributeId,Name,EntityId,NotificationUrl) VALUES
(@NotificationVariableId,@ParentId,@RelatedAttributeId,@Name,@EntityId,@NotificationUrl)
END
GO
-----------------------------------****************************************-----------------------------
CREATE PROCEDURE [dbo].[InitProfile] 
@NotificationProfileId UNIQUEIDENTIFIER,
@CriteriaId UNIQUEIDENTIFIER,
@NotificationTemplateId UNIQUEIDENTIFIER,
@SubjectNotificationTemplateId UNIQUEIDENTIFIER,
@NotificationVariableId UNIQUEIDENTIFIER,
@IsSys BIT
AS
BEGIN
INSERT INTO NotificationProfile(NotificationProfileId,CriteriaId,NotificationTemplateId,SubjectTemplateId,IsSys) VALUES
(@NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@IsSys)
INSERT INTO ProfileVariable(ProfileVariableId,NotificationProfileId,NotificationVariableId) VALUES(NEWID(),@NotificationProfileId,@NotificationVariableId)
END
GO
------------------------------------------*************************************----------------------------
CREATE PROCEDURE [dbo].[InitRecipientAttributes] 
@CriteriaId UNIQUEIDENTIFIER,
@NotificationProfileId UNIQUEIDENTIFIER,
@EntityName nvarchar(200),
@AttributeName nvarchar(200)
AS
BEGIN
declare @entityId UNIQUEIDENTIFIER
declare @attributeId UNIQUEIDENTIFIER
SELECT	@attributeId = a.AttributeId,
@entityId = e.EntityId
FROM Metadata_Entity e
INNER JOIN Metadata_Attribute a 
ON e.EntityId = a.EntityId
WHERE e.Name = @EntityName
AND a.TableColumnName = @AttributeName

INSERT INTO NotificationRecipientAttributes(NotificationRecipientAttributeId,RecipientEntityId,AttributeId,NotificationProfileId,CriteriaId)
VALUES (NEWID(),@entityId,@attributeId,@NotificationProfileId,@CriteriaId)

END
Go
CREATE PROCEDURE [dbo].[InitSubscription] 
@NotificationProfileId UNIQUEIDENTIFIER,
@UserName nvarchar(200)
AS
BEGIN
declare @UserId UNIQUEIDENTIFIER

SELECT	@UserId = UserId from [User] where FullName = @UserName

INSERT INTO Subscription(SubscriptionId,UserId,NotificationProfileId)
VALUES (NEWID(),@UserId,@NotificationProfileId)
END
Go

---------------------------------------------------------------------------end create PROCEDURE------------------------------------
declare @CriteriaId uniqueidentifier
declare @RootCriteriaNodeId uniqueidentifier
DECLARE @NotificationTemplateId uniqueidentifier
DECLARE @SubjectNotificationTemplateId uniqueidentifier
DECLARE @RootVariableId uniqueidentifier
DECLARE @NotificationProfileId uniqueidentifier
DECLARE @TempGuid uniqueidentifier


-------------------------------------------------NOTE - LEAD NOTIFICATION---------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
SET @NotificationTemplateId = NEWID()
SET @RootVariableId = NEWID()
SET @NotificationProfileId = NEWID()
SET @SubjectNotificationTemplateId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'NOTE-LEAD-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Note','IsDeleted','false'
EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','Note variable','Note',''
SET @TempGuid = NEWID()
EXEC [dbo].[InitNotificationVariable]  @TempGuid,@RootVariableId,'ObjectId','Lead variable','Lead',''
EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N'$Note.Lead.Subject$ 潜在客户已被评论'
EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'正文：潜在客户 $Note.Lead.Subject$ 添加主题为  $Note.Subject$ 的评论  评论内容为 $Note.NoteText$'
EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
-----------------------------init member---------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'LEAD-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Lead','LeadId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Lead','OwnerId'
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'NOTE-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Note','ObjectId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Note','CreatedById'
-----------------------------------------------------Opportunity UPDATE NOTIFICATION---------------------------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
SET @NotificationTemplateId = NEWID()
SET @RootVariableId = NEWID()
SET @NotificationProfileId = NEWID()
SET @SubjectNotificationTemplateId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'Opportunity-Update-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Opportunity','IsDeleted','false'
EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','Opportunity variable','Opportunity',''

EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N'$Opportunity.Name$ 商业机遇已被修改'
EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'正文：$Opportunity.Name$ 商业机遇已被修改'
EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
-------------------------------init member--------------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'Opportunity-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Opportunity','OpportunityId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Opportunity','OwnerId'

SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'Technician-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Opportunity','OpportunityId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Opportunity','TechnicianId'

-----------------------------------------------------NOTE - Opportunity NOTIFICATION---------------------------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
SET @NotificationTemplateId = NEWID()
SET @RootVariableId = NEWID()
SET @NotificationProfileId = NEWID()
SET @SubjectNotificationTemplateId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'NOTE-Opportunity-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Note','IsDeleted','false'
EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','Note variable','Note',''
SET @TempGuid = NEWID()
EXEC [dbo].[InitNotificationVariable]  @TempGuid,@RootVariableId,'ObjectId','Opportunity variable','Opportunity',''
EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N'$Note.Opportunity.Name$ 商业机遇已被评论'
EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'正文：商业机遇 $Note.Opportunity.Name$ 添加主题为  $Note.Subject$ 的评论  评论内容为 $Note.NoteText$'
EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
-----------------------------init member---------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'Opportunity-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Opportunity','OpportunityId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Opportunity','OwnerId'
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'NOTE-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Note','ObjectId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Note','CreatedById'

SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'Technician-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Opportunity','OpportunityId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Opportunity','TechnicianId'

-----------------------------------------------------Quote - Note Notification --------------------------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
SET @NotificationTemplateId = NEWID()
SET @RootVariableId = NEWID()
SET @NotificationProfileId = NEWID()
SET @SubjectNotificationTemplateId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'NOTE-Quote-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Note','IsDeleted','false'
EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','Note variable','Note',''
SET @TempGuid = NEWID()
EXEC [dbo].[InitNotificationVariable]  @TempGuid,@RootVariableId,'ObjectId','Quote variable','Quote',''
EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N'$Note.Quote.Name$ 报价已被评论'
EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'正文：报价 $Note.Quote.Name$ 添加主题为  $Note.Subject$ 的评论  评论内容为 $Note.NoteText$'
EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
-----------------------------init member---------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'Quote-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Quote','QuoteId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Quote','OwnerId'
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'NOTE-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Note','ObjectId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Note','CreatedById'

-----------------------------------------------------Contract - Note Notification------------------------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
SET @NotificationTemplateId = NEWID()
SET @RootVariableId = NEWID()
SET @NotificationProfileId = NEWID()
SET @SubjectNotificationTemplateId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'NOTE-Contract-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Note','IsDeleted','false'
EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','Note variable','Note',''
SET @TempGuid = NEWID()
EXEC [dbo].[InitNotificationVariable]  @TempGuid,@RootVariableId,'ObjectId','Contract variable','Contract',''
EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N'$Note.Contract.Title$ 合同已被评论'
EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'正文：合同 $Note.Contract.Title$ 添加主题为  $Note.Subject$ 的评论  评论内容为 $Note.NoteText$'
EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
-----------------------------init member---------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'Contract-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Contract','ContractId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Contract','OwnerId'
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'NOTE-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Note','ObjectId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Note','CreatedById'
-----------------------------------------------------Assign Task Notification----------------------------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
SET @NotificationTemplateId = NEWID()
SET @RootVariableId = NEWID()
SET @NotificationProfileId = NEWID()
SET @SubjectNotificationTemplateId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'ProjectTask-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','ProjectTask','IsDeleted','false'
EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','ProjectTask variable','ProjectTask',''

EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N'任务 $ProjectTask.Name$ 已被指派'
EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'正文：任务 $ProjectTask.Name$ 已被指派'
EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
-----------------------------init member---------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'ProjectTask-Owner-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','ProjectTask','TaskId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'ProjectTask','OwnerId'
------------------------------------------------------Lead convert to Opportunity Covert------------------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
SET @NotificationTemplateId = NEWID()
SET @RootVariableId = NEWID()
SET @NotificationProfileId = NEWID()
SET @SubjectNotificationTemplateId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'Opportunity-LEAD-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Opportunity','IsDeleted','false'
EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','Opportunity variable','Opportunity',''
SET @TempGuid = NEWID()
EXEC [dbo].[InitNotificationVariable]  @TempGuid,@RootVariableId,'OriginatingLeadId','Lead variable','Lead',''
EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N'$Opportunity.Lead.Subject$ 潜在客户已被转换成商业机遇'
EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'正文：潜在客户 $Opportunity.Lead.Subject$ 已转换为  $Opportunity.Name$ 商业机遇'
EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
-----------------------------init member---------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'LEAD-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Lead','LeadId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Lead','OwnerId'
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'LEAD-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Opportunity','OpportunityId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Opportunity','OwnerId'
EXEC [dbo].[InitSubscription] @NotificationProfileId,N'徐强'

-----------------------------------------------------Contract- ExpiresOn Notification---------------------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
SET @NotificationTemplateId = NEWID()
SET @RootVariableId = NEWID()
SET @NotificationProfileId = NEWID()
SET @SubjectNotificationTemplateId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'Contract-ExpiresOn-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Contract','IsDeleted','false'
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'TimeCompare','Less','Contract','ExpiresOn','5'
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'TimeCompare','GreaterOrEqual','Contract','ExpiresOn','0'
EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','Contract variable','Contract',''
EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N'$Contract.Title$ 合同失效'
EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'正文:合同 $Contract.Title$ 快要期满失效， 失效日期为$Contract.ExpiresOn$'
EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,1
-----------------------------init member
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'Contract-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',null,null,null
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Contract','IsDeleted','false'
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Contract','ContractId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Contract','OwnerId'
EXEC [dbo].[InitSubscription] @NotificationProfileId,N'徐强'

----------------------------------------------------------------------------ProjectTask - EndDate - Notification--------------
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
SET @NotificationTemplateId = NEWID()
SET @RootVariableId = NEWID()
SET @NotificationProfileId = NEWID()
SET @SubjectNotificationTemplateId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'ProjectTask-EndDate-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','ProjectTask','IsDeleted','false'
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'TimeCompare','Less','ProjectTask','EndDate','3'
SET @TempGuid = NEWID()
EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'TimeCompare','GreaterOrEqual','ProjectTask','EndDate','0'
EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','ProjectTask variable','ProjectTask',''
SET @TempGuid = NEWID()
EXEC [dbo].[InitNotificationVariable]  @TempGuid,@RootVariableId,'ProjectId','Project variable','Project',''
EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N'任务 $ProjectTask.Name$ 快到结束日期'
EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'正文:任务 $ProjectTask.Name$ 快到结束日期, 结束日期为$ProjectTask.EndDate$'
EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,1
-----------------------------init member
SET @CriteriaId = NEWID()
SET @RootCriteriaNodeId = NEWID()
EXEC [dbo].[InitCriteria]  @CriteriaId,N'Project-Member-Criteria'
EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','ProjectMember','ProjectId',''
EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'ProjectMember','MemberId'

-------------------------------------------------------------------------------drop PROCEDURE------------------------------
GO
DROP PROCEDURE [dbo].[InitSubscription]
GO
DROP PROCEDURE [dbo].[InitRecipientAttributes] 
GO
DROP PROCEDURE [dbo].[InitProfile] 
GO
DROP PROCEDURE [dbo].[InitNotificationVariable] 
GO
DROP PROCEDURE [dbo].[InitTemplate]
GO
DROP PROCEDURE [dbo].[InitCriteriaNode]
GO
DROP PROCEDURE [dbo].[InitCriteria] 
GO
COMMIT