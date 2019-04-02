using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121018095334)]
    public class _20121018095334_AddTechnologyField : Migration
    {
        public override void Up()
        {

            string sql = @"DECLARE @optionsetId nvarchar(100)
                        SELECT @optionsetId=[OptionSetId]
                        FROM [dbo].[Metadata_OptionSet]
                        WHERE [Name] = 'opportunity_technologycode'

                        INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D7000F', 14, 13, @optionsetId)
                        INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D7000F', N'DisplayName', N'C#')
                        INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D70010', 15, 14, @optionsetId)
                        INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D70010', N'DisplayName', N'PHP')
                        INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D70011', 16, 15, @optionsetId)
                        INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D70011', N'DisplayName', N'JavaScript')
                        INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D70012', 17, 16, @optionsetId)
                        INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D70012', N'DisplayName', N'Windows Phone')
                        INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D70013', 18, 17, @optionsetId)
                        INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D70013', N'DisplayName', N'mojoPortal')
                        INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D70014', 19, 18, @optionsetId)
                        INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D70014', N'DisplayName', N'N2 CMS')
                        INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D70015', 20, 19, @optionsetId)
                        INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D70015', N'DisplayName', N'SharePoint')
                        INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D70016', 21, 20, @optionsetId)
                        INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D70016', N'DisplayName', N'SQL Server')
                        INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D70017', 22, 21, @optionsetId)
                        INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D70017', N'DisplayName', N'Oracle')";
            Execute.Sql(sql);
            
            //Insert.IntoTable("Metadata_AttributePicklistValue").Row(new { AttributePicklistValueId = "5C9B5D54-9C4E-48C0-B53C-461198D7000F", Value = 14, DisplayOrder = 13, OptionSetId = optionsetId });
        }
        public override void Down()
        {
            Delete.FromTable("Metadata_LocalizedLabel").Row(new { ObjectId = "5C9B5D54-9C4E-48C0-B53C-461198D70017" });
            Delete.FromTable("Metadata_LocalizedLabel").Row(new { ObjectId = "5C9B5D54-9C4E-48C0-B53C-461198D70016" });
            Delete.FromTable("Metadata_LocalizedLabel").Row(new { ObjectId = "5C9B5D54-9C4E-48C0-B53C-461198D70015" });
            Delete.FromTable("Metadata_LocalizedLabel").Row(new { ObjectId = "5C9B5D54-9C4E-48C0-B53C-461198D70014" });
            Delete.FromTable("Metadata_LocalizedLabel").Row(new { ObjectId = "5C9B5D54-9C4E-48C0-B53C-461198D70013" });
            Delete.FromTable("Metadata_LocalizedLabel").Row(new { ObjectId = "5C9B5D54-9C4E-48C0-B53C-461198D70012" });
            Delete.FromTable("Metadata_LocalizedLabel").Row(new { ObjectId = "5C9B5D54-9C4E-48C0-B53C-461198D70011" });
            Delete.FromTable("Metadata_LocalizedLabel").Row(new { ObjectId = "5C9B5D54-9C4E-48C0-B53C-461198D70010" });
            Delete.FromTable("Metadata_LocalizedLabel").Row(new { ObjectId = "5C9B5D54-9C4E-48C0-B53C-461198D7000F" });

            Delete.FromTable("Metadata_AttributePicklistValue").Row(new { AttributePicklistValueId = "5C9B5D54-9C4E-48C0-B53C-461198D70017" });
            Delete.FromTable("Metadata_AttributePicklistValue").Row(new { AttributePicklistValueId = "5C9B5D54-9C4E-48C0-B53C-461198D70016" });
            Delete.FromTable("Metadata_AttributePicklistValue").Row(new { AttributePicklistValueId = "5C9B5D54-9C4E-48C0-B53C-461198D70015" });
            Delete.FromTable("Metadata_AttributePicklistValue").Row(new { AttributePicklistValueId = "5C9B5D54-9C4E-48C0-B53C-461198D70014" });
            Delete.FromTable("Metadata_AttributePicklistValue").Row(new { AttributePicklistValueId = "5C9B5D54-9C4E-48C0-B53C-461198D70013" });
            Delete.FromTable("Metadata_AttributePicklistValue").Row(new { AttributePicklistValueId = "5C9B5D54-9C4E-48C0-B53C-461198D70012" });
            Delete.FromTable("Metadata_AttributePicklistValue").Row(new { AttributePicklistValueId = "5C9B5D54-9C4E-48C0-B53C-461198D70011" });
            Delete.FromTable("Metadata_AttributePicklistValue").Row(new { AttributePicklistValueId = "5C9B5D54-9C4E-48C0-B53C-461198D70010" });
            Delete.FromTable("Metadata_AttributePicklistValue").Row(new { AttributePicklistValueId = "5C9B5D54-9C4E-48C0-B53C-461198D7000F" });
        }
    }
}
