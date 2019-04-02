using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121112093245)]
    public class _20121112093245_AddStatusInInvoice:Migration
    {
        public override void Up()
        {
            string sql = @"DECLARE @optionsetId nvarchar(100)
                            SELECT @optionsetId=[OptionSetId]
                            FROM [dbo].[Metadata_OptionSet]
                            WHERE [Name]='invoice_statuscode'
                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2446', 6, 5, @optionsetId)
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2446', N'DisplayName', N'Cancelled')
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2446', N'DisplayName', N'???')";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = @"DELETE FROM [dbo].[Metadata_AttributePicklistValue]
                            WHERE [AttributePicklistValueId]=N'962E9B66-47DD-4747-A786-A7B163DF2446'
                            DELETE FROM [dbo].[Metadata_LocalizedLabel]
                            WHERE [ObjectId]=N'962E9B66-47DD-4747-A786-A7B163DF2446'";
            Execute.Sql(sql);
        }
    }
}
