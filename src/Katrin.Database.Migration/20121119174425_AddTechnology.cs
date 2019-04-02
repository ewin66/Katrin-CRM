using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121119174425)]
    public class _20121119174425_AddTechnology : Migration
    {
        public override void Up()
        {
            Alter.Table("Lead").AddColumn("Technology").AsString(100).Nullable();
            Alter.Table("Opportunity").AddColumn("Technology").AsString(100).Nullable();
            Alter.Table("Project").AddColumn("Technology").AsString(100).Nullable();
            string sql = @"DECLARE @EntityId uniqueidentifier
                            SELECT @EntityId = [EntityId]
                            FROM [dbo].[Metadata_Entity]
                            WHERE [Name]='Lead'
                            INSERT	Metadata_Attribute(
		                            AttributeId,
		                            AttributeTypeId,
		                            Name,
		                            PhysicalName,
		                            IsNullable,
		                            EntityId,
		                            ColumnNumber,
		                            LogicalName,
		                            IsAuditEnabled,
		                            TableColumnName,
		                            IsPKAttribute,
		                            IsCopyEnabled)
                            VALUES(	NEWID(),
		                            '00000000-0000-0000-00AA-11000000001E',
		                            'technology',
		                            'Technology',
		                            1,
		                            @EntityId,
		                            34,
		                            'technology',
		                            0,
		                            'Technology',
		                            0, 
		                            1)
                             SELECT @EntityId = [EntityId]
                            FROM [dbo].[Metadata_Entity]
                            WHERE [Name]='Project'
                            INSERT	Metadata_Attribute(
		                            AttributeId,
		                            AttributeTypeId,
		                            Name,
		                            PhysicalName,
		                            IsNullable,
		                            EntityId,
		                            ColumnNumber,
		                            LogicalName,
		                            IsAuditEnabled,
		                            TableColumnName,
		                            IsPKAttribute,
		                            IsCopyEnabled)
                            VALUES(	NEWID(),
		                            '00000000-0000-0000-00AA-11000000001E',
		                            'technology',
		                            'Technology',
		                            1,
		                            @EntityId,
		                            25,
		                            'technology',
		                            0,
		                            'Technology',
		                            0, 
		                            1)
                            SELECT @EntityId = [EntityId]
                            FROM [dbo].[Metadata_Entity]
                            WHERE [Name]='Opportunity'
                            INSERT	Metadata_Attribute(
		                            AttributeId,
		                            AttributeTypeId,
		                            Name,
		                            PhysicalName,
		                            IsNullable,
		                            EntityId,
		                            ColumnNumber,
		                            LogicalName,
		                            IsAuditEnabled,
		                            TableColumnName,
		                            IsPKAttribute,
		                            IsCopyEnabled)
                            VALUES(	NEWID(),
		                            '00000000-0000-0000-00AA-11000000001E',
		                            'technology',
		                            'Technology',
		                            1,
		                            @EntityId,
		                            33,
		                            'technology',
		                            0,
		                            'Technology',
		                            0, 
		                            1)
                            DECLARE @ObjectId   nvarchar(100)
                            SELECT  @ObjectId= [AttributeId]
                            FROM [dbo].[Metadata_Attribute]
                            WHERE [PhysicalName]='Technology' 
                            AND [EntityId] IN(SELECT [EntityId] FROM [dbo].[Metadata_Entity]
					                            WHERE [Name]='Lead')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 2052, @ObjectId, N'DisplayName', N'????')

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 1033, @ObjectId, N'DisplayName', N'Technology')
                            
                            SELECT  @ObjectId= [AttributeId]
                            FROM [dbo].[Metadata_Attribute]
                            WHERE [PhysicalName]='Technology' 
                            AND [EntityId] IN(SELECT [EntityId] FROM [dbo].[Metadata_Entity]
					                            WHERE [Name]='Opportunity')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 2052, @ObjectId, N'DisplayName', N'????')

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 1033, @ObjectId, N'DisplayName', N'Technology')
                            
                            SELECT  @ObjectId= [AttributeId]
                            FROM [dbo].[Metadata_Attribute]
                            WHERE [PhysicalName]='Technology' 
                            AND [EntityId] IN(SELECT [EntityId] FROM [dbo].[Metadata_Entity]
					                            WHERE [Name]='Project')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 2052, @ObjectId, N'DisplayName', N'????')

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 1033, @ObjectId, N'DisplayName', N'Technology')
                           
                            update Lead set Technology=a.Label
                            from(
                            select a.LeadId,a.TechnologyCode,c.Label 
                            from Lead a
                            inner join Metadata_AttributePicklistValue b 
                            on a.TechnologyCode = b.Value and 
                            b.OptionSetId='49FE89FE-476C-4779-BDC2-E5917A8B6473'
                            inner join Metadata_LocalizedLabel c 
                            on b.AttributePicklistValueId = c.ObjectId
                            ) a where a.LeadId = lead.LeadId

                             update Opportunity set Technology=a.Label
                            from(
                            select a.OpportunityId,a.TechnologyCode,c.Label 
                            from Opportunity a
                            inner join Metadata_AttributePicklistValue b 
                            on a.TechnologyCode = b.Value and 
                            b.OptionSetId='49FE89FE-476C-4779-BDC2-E5917A8B6473'
                            inner join Metadata_LocalizedLabel c 
                            on b.AttributePicklistValueId = c.ObjectId
                            ) a where a.OpportunityId = Opportunity.OpportunityId  
                            
                            update Project set Technology=a.Label
                            from(
                            select a.ProjectId,a.TechnologyCode,c.Label 
                            from Project a
                            inner join Metadata_AttributePicklistValue b 
                            on a.TechnologyCode = b.Value and 
                            b.OptionSetId='49FE89FE-476C-4779-BDC2-E5917A8B6473'
                            inner join Metadata_LocalizedLabel c 
                            on b.AttributePicklistValueId = c.ObjectId
                            ) a where a.ProjectId = Project.ProjectId";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            Delete.Column("Technology").FromTable("Lead");
            Delete.Column("Technology").FromTable("Opportunity");
            Delete.Column("Technology").FromTable("Project");
            string sql = @"DECLARE @EntityId uniqueidentifier
                            SELECT @EntityId = [EntityId]
                            FROM [dbo].[Metadata_Entity]
                            WHERE [Name]='Lead'
                            DELETE FROM [dbo].[Metadata_Attribute]
                            WHERE [EntityId]=@EntityId AND PhysicalName='Technology'
                            
                            SELECT @EntityId = [EntityId]
                            FROM [dbo].[Metadata_Entity]
                            WHERE [Name]='Opportunity'
                            DELETE FROM [dbo].[Metadata_Attribute]
                            WHERE [EntityId]=@EntityId AND PhysicalName='Technology'
                            
                            SELECT @EntityId = [EntityId]
                            FROM [dbo].[Metadata_Entity]
                            WHERE [Name]='Project'
                            DELETE FROM [dbo].[Metadata_Attribute]
                            WHERE [EntityId]=@EntityId AND PhysicalName='Technology'";
            Execute.Sql(sql);
        }
    }
}
