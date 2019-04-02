using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121127171645)]
    public class _20121127171645_AddTaskPriority : Migration
    {
        public override void Up()
        {
            string sql = @"DECLARE @optionsetId nvarchar(100)
                            SELECT @optionsetId=[OptionSetId]
                            FROM [dbo].[Metadata_OptionSet]
                            WHERE [Name]='projecttask_prioritycode'
                            UPDATE [dbo].[Metadata_AttributePicklistValue] SET [DisplayOrder] = 1 WHERE [AttributePicklistValueId] = '56D8465B-665E-459A-A8E3-187AE973F4D0'
                            UPDATE [dbo].[Metadata_AttributePicklistValue] SET [DisplayOrder] = 2 WHERE [AttributePicklistValueId] = '56D8465B-665E-459A-A8E3-187AE973F4D1'
                            UPDATE [dbo].[Metadata_AttributePicklistValue] SET [DisplayOrder] = 3 WHERE [AttributePicklistValueId] = '56D8465B-665E-459A-A8E3-187AE973F4D2'
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F4D3', 4, 0, @optionsetId)
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F4D3', N'DisplayName', N'Urgency')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F4D3', N'DisplayName', N'??')";
            Execute.Sql(sql);
        }

        public override void Down()
        {

        }
    }
}
