using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121120135136)]
    public class _20121120135136_SortTechnology:Migration
    {
        public override void Up()
        {
            string sql = @"UPDATE [dbo].[Metadata_AttributePicklistValue] SET [DisplayOrder]= a.r
                            FROM(
                            SELECT ROW_NUMBER() OVER( ORDER BY a.[Label])-1 AS r , a.* 
                            FROM(
                            SELECT a.[AttributePicklistValueId], a.[Value], a.[DisplayOrder], a.[OptionSetId], a.[VersionNumber],b.[label]
                            FROM         [dbo].[Metadata_AttributePicklistValue] AS a LEFT OUTER JOIN
                                                  [dbo].[Metadata_LocalizedLabel] AS b ON a.[AttributePicklistValueId] = b.[objectid]
                            WHERE  a.[OptionSetId] = '49fe89fe-476c-4779-bdc2-e5917a8b6473'
                            ) a 
                            ) a 
                            where a.Value=[dbo].[Metadata_AttributePicklistValue].[Value]
                            AND [dbo].[Metadata_AttributePicklistValue].[OptionSetId]=N'49fe89fe-476c-4779-bdc2-e5917a8b6473'";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            
        }
    }
}
