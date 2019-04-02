using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121214091626)]
    public class _20121214091626_AddAppointmentModule : Migration
    {
        public override void Up()
        {
            string sql = @"CREATE TABLE [dbo].[Resource] (
                                [ResourceId]                UNIQUEIDENTIFIER NOT NULL,
                                [Name]						NVARCHAR(50)     NULL,

                                CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED ([ResourceId] ASC)
                            );

                            INSERT INTO [dbo].[Resource]
                            ([ResourceId],[Name])
                            VALUES
                            ('91303CCB-2A3C-483A-A285-3EF0A1366A74',N'1508A????')
                            ,('18A392A6-D03B-4A1A-B4A7-BB76DE054870',N'1508A????')
                            ,('0811EE7F-D636-4B8D-A778-DA00D7DDAD18',N'1509???')

                            CREATE TABLE [dbo].[Appointment] (
                                [AppointmentId]             UNIQUEIDENTIFIER NOT NULL,
                                [ResourceId]				UNIQUEIDENTIFIER NOT NULL,
                                [Subject]					NVARCHAR(50)     NULL,
                                [Description]				NVARCHAR(300)    NULL,
                                [StartTime]					DATETIME         NULL,
                                [EndTime]					DATETIME         NULL,
                                [RecurrenceEndTime]			DATETIME         NULL,
                                [RecurrenceInfo]			NVARCHAR(MAX)    NULL,
                                [AppointmentType]			INT				 NULL,
                                [CreatedOn]                 DATETIME         NULL,
                                [CreatedById]               UNIQUEIDENTIFIER NULL,
                                [ModifiedOn]                DATETIME         NULL,
                                [ModifiedById]              UNIQUEIDENTIFIER NULL,
   
                                CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED ([AppointmentId] ASC),
                                CONSTRAINT [FK_Appointment_Resource] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[Resource] ([ResourceId]),
                                CONSTRAINT [FK_Appointment_User_CreatedBy] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]),
                                CONSTRAINT [FK_Appointment_User_ModifiedBy] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId])
                            );

                            INSERT INTO [dbo].[Metadata_Entity]
                            ([EntityId],[Name],[PhysicalName],[LogicalName],[TableName],[IsAuditEnabled]) 
                            VALUES
                            ('44CAB437-9080-4605-8E26-6645AB858F1D','Resource','Resource','resource','Resource',0)
                            ,('D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','Appointment','Appointment','appointment','Appointment',0)

                            INSERT INTO [dbo].[Metadata_Attribute] 
                            ([AttributeId], [AttributeTypeId], [LogicalType], [Name], [PhysicalName]
                            , [Length], [IsNullable], [EntityId], [DefaultValue], [ColumnNumber]
                            , [LogicalName], [MaxLength], [MinValue], [MaxValue], [IsAuditEnabled]
                            , [TableColumnName], [OptionSetId], [AppDefaultValue], [IsPKAttribute], [IsCopyEnabled])
                            VALUES
                            ('B8AF3A73-AA40-49B1-85FE-3B0A74C5E4EE','00000000-0000-0000-00AA-110000000027','','resourceid','ResourceId'
                            ,NULL,0,'44CAB437-9080-4605-8E26-6645AB858F1D','',1
                            ,'resourceid',NULL,NULL,NULL,0
                            ,'ResourceId',NULL,NULL,1,0)

                            ,('F40BBF82-99AD-4692-94DC-0BFFE61AEFE6','00000000-0000-0000-00AA-11000000001E','','name','Name'
                            ,50,1,'44CAB437-9080-4605-8E26-6645AB858F1D','',2
                            ,'name',NULL,NULL,NULL,0
                            ,'Name',NULL,NULL,0,1)

                            ,('D693B0AD-9C9A-4ABA-B6BE-B10328D37154','00000000-0000-0000-00AA-110000000027','','appointmentid','AppointmentId'
                            ,NULL,0,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',1
                            ,'appointmentid',NULL,NULL,NULL,0
                            ,'AppointmentId',NULL,NULL,1,0)

                            ,('F4E45112-C0AD-44E1-A1FC-D8824B9CEB7A','00000000-0000-0000-00AA-110000000027','','resourceid','ResourceId'
                            ,NULL,0,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',2
                            ,'resourceid',NULL,NULL,NULL,0
                            ,'ResourceId',NULL,NULL,0,1)

                            ,('67683933-C2B7-4933-8550-E56820B0577B','00000000-0000-0000-00AA-11000000001E','','subject','Subject'
                            ,50,1,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',3
                            ,'subject',NULL,NULL,NULL,0
                            ,'Subject',NULL,NULL,0,1)

                            ,('83F2BA55-6921-4BDD-95A7-76C61C2B81E8','00000000-0000-0000-00AA-11000000001E','','description','Description'
                            ,300,1,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',4
                            ,'description',NULL,NULL,NULL,0
                            ,'Description',NULL,NULL,0,1)

                            ,('F45B9E37-1C2F-41F6-A120-A04B31441900','00000000-0000-0000-00AA-110000000015','','starttime','StartTime'
                            ,NULL,1,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',5
                            ,'starttime',NULL,NULL,NULL,0
                            ,'StartTime',NULL,NULL,0,1)

                            ,('30FBA747-80A2-4886-9D32-A7CC338280B8','00000000-0000-0000-00AA-110000000015','','endtime','EndTime'
                            ,NULL,1,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',6
                            ,'endtime',NULL,NULL,NULL,0
                            ,'EndTime',NULL,NULL,0,1)

                            ,('E1EC4E00-B61F-4F59-B0F9-2F00332F5124','00000000-0000-0000-00AA-110000000015','','recurrenceendtime','RecurrenceEndTime'
                            ,NULL,1,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',7
                            ,'recurrenceendtime',NULL,NULL,NULL,0
                            ,'RecurrenceEndTime',NULL,NULL,0,1)

                            ,('60E29AF3-E08C-44CC-B198-DAD2A2F41B46','00000000-0000-0000-00AA-11000000001E','','recurrenceinfo','RecurrenceInfo'
                            ,-1,1,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',8
                            ,'recurrenceinfo',NULL,NULL,NULL,0
                            ,'RecurrenceInfo',NULL,NULL,0,1)

                            ,('C5BF5369-4B2A-4919-B503-72F5793DEA74','00000000-0000-0000-00AA-110000000019','','appointmenttype','AppointmentType'
                            ,NULL,1,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',9
                            ,'appointmenttype',NULL,NULL,NULL,0
                            ,'AppointmentType',NULL,NULL,0,1)

                            ,('ACCA9E09-54F8-4828-B6A8-653CFA1A3433','00000000-0000-0000-00AA-110000000015','','createdon','CreatedOn'
                            ,NULL,1,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',10
                            ,'createdon',NULL,NULL,NULL,0
                            ,'CreatedOn',NULL,NULL,0,0)

                            ,('02E8CF6D-217B-4A8A-9644-35C67C3DC92B','00000000-0000-0000-00AA-110000000027','','createdbyid','CreatedById'
                            ,NULL,1,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',11
                            ,'createdbyid',NULL,NULL,NULL,0
                            ,'CreatedById',NULL,NULL,0,0)

                            ,('A4D92DD6-B1C4-4A04-96EC-DD947383A30F','00000000-0000-0000-00AA-110000000015','','modifiedon','ModifiedOn'
                            ,NULL,1,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',12
                            ,'modifiedon',NULL,NULL,NULL,0
                            ,'ModifiedOn',NULL,NULL,0,0)

                            ,('E56E393B-F3B1-4F03-9477-2763C465162F','00000000-0000-0000-00AA-110000000027','','modifiedbyid','ModifiedById'
                            ,NULL,1,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','',13
                            ,'modifiedbyid',NULL,NULL,NULL,0
                            ,'ModifiedById',NULL,NULL,0,0)

                            INSERT INTO [dbo].[Metadata_Relationship]
                            ([RelationshipId],[Name],[ReferencingEntityId],[ReferencingAttributeId]
                            ,[ReferencedEntityId],[ReferencedAttributeId],[RelationshipType],[CascadeDelete])
                            VALUES
                            ('2EB278F4-CE36-4F16-9444-AC23148518BE','FK_Appointment_Resource','D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','F4E45112-C0AD-44E1-A1FC-D8824B9CEB7A'
                            ,'44CAB437-9080-4605-8E26-6645AB858F1D','B8AF3A73-AA40-49B1-85FE-3B0A74C5E4EE',1,1)

                            ,('E34CCC1A-5D98-4587-9268-47DDAE1CCBF1','FK_Appointment_User_CreatedBy','D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','02E8CF6D-217B-4A8A-9644-35C67C3DC92B'
                            ,'4124D7F6-0673-4A6C-BA52-8713254264EB','EE1E53CC-8EE8-4682-8272-8EB6075C670D',1,1)

                            ,('4341B60C-30D2-4CCC-8DD4-DF8DE14C2C19','FK_Appointment_User_ModifiedBy','D133BB15-6A01-4D5E-A1C8-B029DA9A68D7','E56E393B-F3B1-4F03-9477-2763C465162F'
                            ,'4124D7F6-0673-4A6C-BA52-8713254264EB','EE1E53CC-8EE8-4682-8272-8EB6075C670D',1,1)

                            INSERT INTO [dbo].[Metadata_EntityRelationship]
                            ([EntityRelationshipId],[SchemaName],[EntityRelationshipType],[IsCustomRelationship],[IsCustomizable])
                            VALUES
                            ('BE20723D-2040-4EF1-8BFC-E98F399F346E','appointment_resource_resourceId',0,0,0)
                            ,('C82C9EE5-0407-429E-9629-6E8CC68A12F5','appointment_user_createdBy',0,0,0)
                            ,('5F8C9CB5-3057-4FB4-8A95-98B0151433A6','appointment_user_modifiedBy',0,0,0)

                            INSERT INTO [dbo].[Metadata_EntityRelationshipRelationships]
                            ([EntityRelationshipRelationshipsId],[EntityRelationshipId],[RelationshipId])
                            VALUES
                            ('C4BEA9E9-6BAE-4A0A-8152-B62209B3C197','BE20723D-2040-4EF1-8BFC-E98F399F346E','2EB278F4-CE36-4F16-9444-AC23148518BE')
                            ,('C0998EAE-9885-4208-907A-ED8E56C392AB','C82C9EE5-0407-429E-9629-6E8CC68A12F5','E34CCC1A-5D98-4587-9268-47DDAE1CCBF1')
                            ,('86C28471-6490-43B0-A58F-BEA62AE6384D','5F8C9CB5-3057-4FB4-8A95-98B0151433A6','4341B60C-30D2-4CCC-8DD4-DF8DE14C2C19')

                            INSERT INTO [dbo].[Metadata_EntityRelationshipRole]
                            ([EntityRelationshipRoleId],[EntityRelationshipId]
                            ,[EntityId],[RelationshipRoleType],[NavPanelDisplayOption],[NavPaneOrder])
                            VALUES
                            ('5188E6E7-146E-4EDC-94F1-76DFA42C1D0F','BE20723D-2040-4EF1-8BFC-E98F399F346E'
                            ,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7',1,0,NULL)
                            ,('81044A78-8680-4C4A-AE81-5660B610210B','BE20723D-2040-4EF1-8BFC-E98F399F346E'
                            ,'44CAB437-9080-4605-8E26-6645AB858F1D',0,0,NULL)

                            ,('673FC2BA-768C-45D6-BA7A-6B44776B1C15','C82C9EE5-0407-429E-9629-6E8CC68A12F5'
                            ,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7',1,0,NULL)
                            ,('97B39C87-5757-4AAB-9403-A8F52FF8BE70','C82C9EE5-0407-429E-9629-6E8CC68A12F5'
                            ,'4124D7F6-0673-4A6C-BA52-8713254264EB',0,0,NULL)

                            ,('FE2B463A-4AF1-4728-AB95-F67A67E58127','5F8C9CB5-3057-4FB4-8A95-98B0151433A6'
                            ,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7',1,0,NULL)
                            ,('D2051517-CDE0-4376-BDB5-837DA2AA322B','5F8C9CB5-3057-4FB4-8A95-98B0151433A6'
                            ,'4124D7F6-0673-4A6C-BA52-8713254264EB',0,0,NULL)";
            Execute.Sql(sql);
        }
        public override void Down()
        {

        }
    }
}
