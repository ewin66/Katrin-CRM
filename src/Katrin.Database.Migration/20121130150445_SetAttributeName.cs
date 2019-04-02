using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121130150445)]
    public class _20121130150445_SetAttributeName : Migration
    {
        public override void Up()
        {
            string sql = @" declare @attributeid uniqueidentifier
 select @attributeid = AttributeId from Metadata_Attribute where EntityId='8C06FC35-C27D-4C4D-BC96-8F1BD15A480C'
 and Name='closedon'
   INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 2052, @attributeid, N'DisplayName', N'????')
    INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
    VALUES (NEWID(), 2052, @attributeid, N'DisplayName', N'Closed On')
    select @attributeid = AttributeId from Metadata_Attribute where EntityId='8C06FC35-C27D-4C4D-BC96-8F1BD15A480C'
 and Name='firstresponsedon'   
    INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 2052, @attributeid, N'DisplayName', N'??????')
    INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
    VALUES (NEWID(), 2052, @attributeid, N'DisplayName', N'Email Response Time')    ";
            Execute.Sql(sql);
        }

        public override void Down()
        {

        }
    }
}
