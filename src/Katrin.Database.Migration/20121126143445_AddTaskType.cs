using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121126143445)]
    public class _20121126143445_AddTaskType : Migration
    {
        public override void Up()
        {
            string sql = @"DECLARE @optionsetId nvarchar(100)
                            SELECT @optionsetId=[OptionSetId]
                            FROM [dbo].[Metadata_OptionSet]
                            WHERE [Name]='projecttask_taskcategorycode'
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F4E3', 3, 2, @optionsetId)
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F4E3', N'DisplayName', N'Requirement')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F4E3', N'DisplayName', N'??')";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = @"DELETE FROM [dbo].[Metadata_AttributePicklistValue]
                            WHERE [AttributePicklistValueId]=N'56D8465B-665E-459A-A8E3-187AE973F4E3'
                            DELETE FROM [dbo].[Metadata_LocalizedLabel]
                            WHERE [ObjectId]=N'56D8465B-665E-459A-A8E3-187AE973F4E3'";
            Execute.Sql(sql);
        }
    }
}
