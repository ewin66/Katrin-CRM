using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121113155155)]
    public class _20121113155155_AddTaskTypeInProjectTask : Migration
    {
        public override void Up()
        {
            Alter.Table("ProjectTask").AddColumn("TaskCategoryCode").AsInt32().Nullable();
            string sql = @" DECLARE @optionsetId nvarchar(100)
                            -----------------projecttask_taskcategorycode ????
                            SET @optionsetId = NEWID()
                            INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) 
                            VALUES(@optionsetId,'projecttask_taskcategorycode',1)

                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
                            VALUES (N'56D8465B-665E-459A-A8E3-187AE973F4E1', 1, 0, @optionsetId)

                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
                            VALUES (N'56D8465B-665E-459A-A8E3-187AE973F4E2', 2, 1, @optionsetId)

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F4E1', N'DisplayName', N'Task')

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F4E2', N'DisplayName', N'Bug')

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F4E1', N'DisplayName', N'??')

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F4E2', N'DisplayName', N'Bug')

                            UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'ProjectTaskCategoryCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='ProjectTask')
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
		                            IsCopyEnabled,
                                    OptionSetId)
                            VALUES(	NEWID(),
		                            '00000000-0000-0000-00AA-110000000030',
		                            'taskcategorycode',
		                            'TaskCategoryCode',
		                            1,
		                            '3B96362A-A7B1-4898-8A6A-9B400041BFA6',
		                            27,
		                            'taskcategorycode',
		                            0,
		                            'TaskCategoryCode',
		                            0, 
		                            1,
                                     @optionsetId)
                           DECLARE @ObjectId   nvarchar(100)
                            SELECT  @ObjectId= [AttributeId]
                            FROM [dbo].[Metadata_Attribute]
                            WHERE [PhysicalName]='TaskCategoryCode'
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 2052, @ObjectId, N'DisplayName', N'????')

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 1033, @ObjectId, N'DisplayName', N'Task Category')";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            Delete.Column("TaskCategoryCode").FromTable("ProjectTask");
            string sql = @"DELETE FROM Metadata_Attribute
                            WHERE PhysicalName	= 'TaskCategoryCode'
                            DELETE FROM [dbo].[Metadata_LocalizedLabel]
                            WHERE [ObjectId] IN (N'56D8465B-665E-459A-A8E3-187AE973F4E1',N'56D8465B-665E-459A-A8E3-187AE973F4E2')
                            DELETE FROM [dbo].[Metadata_AttributePicklistValue]
                            WHERE [AttributePicklistValueId] IN(N'56D8465B-665E-459A-A8E3-187AE973F4E1',N'56D8465B-665E-459A-A8E3-187AE973F4E2')
                            DELETE FROM [dbo].[Metadata_OptionSet]
                            WHERE Name=N'projecttask_taskcategorycode'
                            DELETE FROM [dbo].[Metadata_LocalizedLabel]
                            WHERE [Label] IN(N'????',N'Task Category')";
            Execute.Sql(sql);
        }
    }
}
