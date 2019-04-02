using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121119133254)]
    public class _20121119133254_AddNotificationConfig:Migration
    {


        private void AddPro()
        {
            string sql = @"-----------------------***************************--------------
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

            ---------------------------------------------------------------------------end create PROCEDURE------------------------------------";
            Execute.Sql(sql);
        }
        private void DeletePro()
        {
            string sql = @"GO
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
            GO";
            Execute.Sql(sql);
        }

        public override void Up()
        {
            AddPro();
            string sql = @"declare @CriteriaId uniqueidentifier
            declare @RootCriteriaNodeId uniqueidentifier
            DECLARE @NotificationTemplateId uniqueidentifier
            DECLARE @SubjectNotificationTemplateId uniqueidentifier
            DECLARE @RootVariableId uniqueidentifier
            DECLARE @NotificationProfileId uniqueidentifier
            DECLARE @TempGuid uniqueidentifier


            -------------------------------------------------LEAD StatusCode change NOTIFICATION---------------
            SET @CriteriaId = NEWID()
            SET @RootCriteriaNodeId = NEWID()
            SET @NotificationTemplateId = NEWID()
            SET @RootVariableId = NEWID()
            SET @NotificationProfileId = NEWID()
            SET @SubjectNotificationTemplateId = NEWID()
            EXEC [dbo].[InitCriteria]  @CriteriaId,N'LEAD-StatusCode-Criteria'
            EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
            SET @TempGuid = NEWID()
            EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Lead','IsDeleted','false'
            SET @TempGuid = NEWID()
            EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','NotEqual','Lead','StatusCode',''


            EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','Lead variable','Lead',''
           
            EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N'????“$Lead.Subject$” ?????'
            EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'???“$Lead.OldStatusCode$”?????“$Lead.StatusCode$”'
            EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
            -----------------------------init member---------------
            SET @CriteriaId = NEWID()
            SET @RootCriteriaNodeId = NEWID()
            EXEC [dbo].[InitCriteria]  @CriteriaId,N'LEAD-Member-Criteria'
            EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Lead','LeadId',''
            EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Lead','OwnerId'
            EXEC [dbo].[InitSubscription] @NotificationProfileId,N'??'
            EXEC [dbo].[InitSubscription] @NotificationProfileId,N'??'";

            sql += @"-------------------------------------------------Opportunity StatusCode change NOTIFICATION---------------
            SET @CriteriaId = NEWID()
            SET @RootCriteriaNodeId = NEWID()
            SET @NotificationTemplateId = NEWID()
            SET @RootVariableId = NEWID()
            SET @NotificationProfileId = NEWID()
            SET @SubjectNotificationTemplateId = NEWID()
            EXEC [dbo].[InitCriteria]  @CriteriaId,N'Opportunity-StatusCode-Criteria'
            EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
            SET @TempGuid = NEWID()
            EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Opportunity','IsDeleted','false'
            SET @TempGuid = NEWID()
            EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','NotEqual','Opportunity','StatusCode',''


            EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','Opportunity variable','Opportunity',''
           
            EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N' ????“$Opportunity.Name$” ?????'
            EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'???“$Opportunity.OldStatusCode$”?????“$Opportunity.StatusCode$”'
            EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
            -----------------------------init member---------------
            SET @CriteriaId = NEWID()
            SET @RootCriteriaNodeId = NEWID()
            EXEC [dbo].[InitCriteria]  @CriteriaId,N'Opportunity-Member-Criteria'
            EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Opportunity','OpportunityId',''
            EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Opportunity','OwnerId'
            EXEC [dbo].[InitSubscription] @NotificationProfileId,N'??'
            EXEC [dbo].[InitSubscription] @NotificationProfileId,N'??'";

            sql += @"-------------------------------------------------Contract StatusCode change NOTIFICATION---------------
            SET @CriteriaId = NEWID()
            SET @RootCriteriaNodeId = NEWID()
            SET @NotificationTemplateId = NEWID()
            SET @RootVariableId = NEWID()
            SET @NotificationProfileId = NEWID()
            SET @SubjectNotificationTemplateId = NEWID()
            EXEC [dbo].[InitCriteria]  @CriteriaId,N'Contract-StatusCode-Criteria'
            EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
            SET @TempGuid = NEWID()
            EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Contract','IsDeleted','false'
            SET @TempGuid = NEWID()
            EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','NotEqual','Contract','StatusCode',''


            EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','Contract variable','Contract',''
           
            EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N' ??“$Contract.Title$” ?????'
            EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'???“$Contract.OldStatusCode$”?????“$Contract.StatusCode$”'
            EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
            -----------------------------init member---------------
            SET @CriteriaId = NEWID()
            SET @RootCriteriaNodeId = NEWID()
            EXEC [dbo].[InitCriteria]  @CriteriaId,N'Contract-Member-Criteria'
            EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Contract','ContractId',''
            EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Contract','OwnerId'
            EXEC [dbo].[InitSubscription] @NotificationProfileId,N'??'
            EXEC [dbo].[InitSubscription] @NotificationProfileId,N'??'";

            sql += @"-------------------------------------------------Invoice StatusCode change NOTIFICATION---------------
            SET @CriteriaId = NEWID()
            SET @RootCriteriaNodeId = NEWID()
            SET @NotificationTemplateId = NEWID()
            SET @RootVariableId = NEWID()
            SET @NotificationProfileId = NEWID()
            SET @SubjectNotificationTemplateId = NEWID()
            EXEC [dbo].[InitCriteria]  @CriteriaId,N'Invoice-StatusCode-Criteria'
            EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
            SET @TempGuid = NEWID()
            EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Invoice','IsDeleted','false'
            SET @TempGuid = NEWID()
            EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','NotEqual','Invoice','StatusCode',''


            EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','Invoice variable','Invoice',''
           
            EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N' ??“$Invoice.Name$” ?????'
            EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'???“$Invoice.OldStatusCode$”?????“$Invoice.StatusCode$”'
            EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
            -----------------------------init member---------------
            SET @CriteriaId = NEWID()
            SET @RootCriteriaNodeId = NEWID()
            EXEC [dbo].[InitCriteria]  @CriteriaId,N'Invoice-Member-Criteria'
            EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Invoice','InvoiceId',''
            EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Invoice','OwnerId'
            EXEC [dbo].[InitSubscription] @NotificationProfileId,N'??'
            EXEC [dbo].[InitSubscription] @NotificationProfileId,N'??'";


            sql += @"-------------------------------------------------Project StatusCode change NOTIFICATION---------------
            SET @CriteriaId = NEWID()
            SET @RootCriteriaNodeId = NEWID()
            SET @NotificationTemplateId = NEWID()
            SET @RootVariableId = NEWID()
            SET @NotificationProfileId = NEWID()
            SET @SubjectNotificationTemplateId = NEWID()
            EXEC [dbo].[InitCriteria]  @CriteriaId,N'Project-StatusCode-Criteria'
            EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
            SET @TempGuid = NEWID()
            EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','Project','IsDeleted','false'
            SET @TempGuid = NEWID()
            EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','NotEqual','Project','StatusCode',''


            EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','Project variable','Project',''
           
            EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N' ??“$Project.Name$” ?????'
            EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'???“$Project.OldStatusCode$”?????“$Project.StatusCode$”'
            EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
            -----------------------------init member---------------
            SET @CriteriaId = NEWID()
            SET @RootCriteriaNodeId = NEWID()
            EXEC [dbo].[InitCriteria]  @CriteriaId,N'Project-Member-Criteria'
            EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','ProjectMember','ProjectId',''
            EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'ProjectMember','MemberId'
            EXEC [dbo].[InitSubscription] @NotificationProfileId,N'??'
            EXEC [dbo].[InitSubscription] @NotificationProfileId,N'??'";

            sql += @"-------------------------------------------------ProjectTask StatusCode change NOTIFICATION---------------
            SET @CriteriaId = NEWID()
            SET @RootCriteriaNodeId = NEWID()
            SET @NotificationTemplateId = NEWID()
            SET @RootVariableId = NEWID()
            SET @NotificationProfileId = NEWID()
            SET @SubjectNotificationTemplateId = NEWID()
            EXEC [dbo].[InitCriteria]  @CriteriaId,N'ProjectTask-StatusCode-Criteria'
            EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Group','And',NULL,NULL,NULL
            SET @TempGuid = NEWID()
            EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','Equal','ProjectTask','IsDeleted','false'
            SET @TempGuid = NEWID()
            EXEC [dbo].[InitCriteriaNode]  @TempGuid,@RootCriteriaNodeId,@CriteriaId,'Binry','NotEqual','ProjectTask','StatusCode',''


            EXEC [dbo].[InitNotificationVariable]  @RootVariableId,'00000000-0000-0000-0000-000000000000','','ProjectTask variable','ProjectTask',''
           
            EXEC [dbo].[InitTemplate] @SubjectNotificationTemplateId,N' ????“$ProjectTask.Name$” ?????'
            EXEC [dbo].[InitTemplate] @NotificationTemplateId,N'???“$ProjectTask.OldStatusCode$”?????“$ProjectTask.StatusCode$”'
            EXEC [dbo].[InitProfile] @NotificationProfileId,@CriteriaId,@NotificationTemplateId,@SubjectNotificationTemplateId,@RootVariableId,0
            -----------------------------init member---------------
            SET @CriteriaId = NEWID()
            SET @RootCriteriaNodeId = NEWID()
            EXEC [dbo].[InitCriteria]  @CriteriaId,N'ProjectTask-Member-Criteria'
            EXEC [dbo].[InitCriteriaNode]  @RootCriteriaNodeId,'00000000-0000-0000-0000-000000000000',@CriteriaId,'Binry','Equal','Project','ProjectId',''
            EXEC [dbo].[InitRecipientAttributes] @CriteriaId,@NotificationProfileId,'Project','ManagerId'";


            Execute.Sql(sql);


            DeletePro();
        }


        public override void Down()
        {
            
        }
    }
}
