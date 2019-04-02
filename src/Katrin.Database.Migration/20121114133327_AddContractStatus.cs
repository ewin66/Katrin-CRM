using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121114133327)]
    public class _20121114133327_AddContractStatus : Migration
    {
        public override void Up()
        {
            string sql = @"DELETE FROM [dbo].[Metadata_AttributePicklistValue]
                            WHERE [AttributePicklistValueId] IN (N'962E9B66-47DD-4747-A786-A7B163DF2431',
									                            N'962E9B66-47DD-4747-A786-A7B163DF2432',
									                            N'962E9B66-47DD-4747-A786-A7B163DF2433',
									                            N'962E9B66-47DD-4747-A786-A7B163DF2434',
									                            N'962E9B66-47DD-4747-A786-A7B163DF2435',
									                            N'962E9B66-47DD-4747-A786-A7B163DF2436',
									                            N'962E9B66-47DD-4747-A786-A7B163DF2437')
                            DELETE FROM [dbo].[Metadata_LocalizedLabel]
                            WHERE [ObjectId] IN (N'962E9B66-47DD-4747-A786-A7B163DF2431',
					                            N'962E9B66-47DD-4747-A786-A7B163DF2432',
					                            N'962E9B66-47DD-4747-A786-A7B163DF2433',
					                            N'962E9B66-47DD-4747-A786-A7B163DF2434',
					                            N'962E9B66-47DD-4747-A786-A7B163DF2435',
					                            N'962E9B66-47DD-4747-A786-A7B163DF2436',
					                            N'962E9B66-47DD-4747-A786-A7B163DF2437')

                            DECLARE @optionsetId nvarchar(100)
                            SELECT @optionsetId=[OptionSetId]
                            FROM [dbo].[Metadata_OptionSet]
                            WHERE [Name]='contract_statuscode'
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2431', 1, 0, @optionsetId)
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2432', 2, 1, @optionsetId)
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2433', 3, 2, @optionsetId)
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2434', 4, 3, @optionsetId)
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2435', 5, 4, @optionsetId)
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2436', 6, 5, @optionsetId)
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2437', 7, 6, @optionsetId)

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2431', N'DisplayName', N'Draft')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2432', N'DisplayName', N'Active')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2433', N'DisplayName', N'Canceled')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2434', N'DisplayName', N'Closed')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2435', N'DisplayName', N'Invoiced')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2436', N'DisplayName', N'OnHold')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2437', N'DisplayName', N'Closing')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2431', N'DisplayName', N'??')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2432', N'DisplayName', N'???')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2433', N'DisplayName', N'??')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2434', N'DisplayName', N'???')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2435', N'DisplayName', N'????')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2436', N'DisplayName', N'??')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2437', N'DisplayName', N'???')
                            UPDATE [dbo].[Contract]
                            SET [StatusCode]=4
                            WHERE [StatusCode]=3
                            UPDATE [dbo].[Contract]
                            SET [StatusCode]=3
                            WHERE [StatusCode]=5";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = @"DELETE FROM [dbo].[Metadata_AttributePicklistValue]
                            WHERE [AttributePicklistValueId] IN (N'962E9B66-47DD-4747-A786-A7B163DF2431',
									                            N'962E9B66-47DD-4747-A786-A7B163DF2432',
									                            N'962E9B66-47DD-4747-A786-A7B163DF2433',
									                            N'962E9B66-47DD-4747-A786-A7B163DF2434',
									                            N'962E9B66-47DD-4747-A786-A7B163DF2435',
									                            N'962E9B66-47DD-4747-A786-A7B163DF2436',
									                            N'962E9B66-47DD-4747-A786-A7B163DF2437')
                            DELETE FROM [dbo].[Metadata_LocalizedLabel]
                            WHERE [ObjectId] IN (N'962E9B66-47DD-4747-A786-A7B163DF2431',
					                            N'962E9B66-47DD-4747-A786-A7B163DF2432',
					                            N'962E9B66-47DD-4747-A786-A7B163DF2433',
					                            N'962E9B66-47DD-4747-A786-A7B163DF2434',
					                            N'962E9B66-47DD-4747-A786-A7B163DF2435',
					                            N'962E9B66-47DD-4747-A786-A7B163DF2436',
					                            N'962E9B66-47DD-4747-A786-A7B163DF2437')

                            DECLARE @optionsetId nvarchar(100)
                            SELECT @optionsetId=[OptionSetId]
                            FROM [dbo].[Metadata_OptionSet]
                            WHERE [Name]='contract_statuscode'
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2431', 1, 0, @optionsetId)
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2432', 2, 1, @optionsetId)
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2433', 3, 2, @optionsetId)
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2434', 4, 3, @optionsetId)
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2435', 5, 4, @optionsetId)

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2431', N'DisplayName', N'Prepare')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2432', N'DisplayName', N'Working')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2433', N'DisplayName', N'Finished')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2434', N'DisplayName', N'Closed')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2435', N'DisplayName', N'Failed')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2431', N'DisplayName', N'??')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2432', N'DisplayName', N'???')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2433', N'DisplayName', N'??')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2434', N'DisplayName', N'??')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2435', N'DisplayName', N'???')
                            UPDATE [dbo].[Contract]
                            SET [StatusCode]=5
                            WHERE [StatusCode]=3
                            UPDATE [dbo].[Contract]
                            SET [StatusCode]=3
                            WHERE [StatusCode]=4";
            Execute.Sql(sql);
        }
    }
}
