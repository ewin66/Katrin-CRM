using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121119165236)]
    public class _20121119165236_AddTechnologyCode : Migration
    {
        public override void Up()
        {

            string sql = @"DECLARE @optionsetId nvarchar(100)
                        SELECT @optionsetId=[OptionSetId]
                        FROM [dbo].[Metadata_OptionSet]
                        WHERE [Name] = 'opportunity_technologycode'
                        INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D70018', 23, 22, @optionsetId)
                        INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D70018', N'DisplayName', N'C++')";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            Delete.FromTable("Metadata_LocalizedLabel").Row(new { ObjectId = "5C9B5D54-9C4E-48C0-B53C-461198D70018" });

            Delete.FromTable("Metadata_AttributePicklistValue").Row(new { AttributePicklistValueId = "5C9B5D54-9C4E-48C0-B53C-461198D70018" });
        }
    }
}
