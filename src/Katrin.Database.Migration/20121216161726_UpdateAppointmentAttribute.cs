using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121216161726)]
    public class _20121216161726_UpdateAppointmentAttribute : Migration
    {
        public override void Up()
        {
            string sql = @"UPDATE [dbo].[Metadata_Attribute] 
                            SET [LogicalName] = 'modifiedon', [TableColumnName] = 'ModifiedOn'
                            WHERE [AttributeId] = 'A4D92DD6-B1C4-4A04-96EC-DD947383A30F'";
            Execute.Sql(sql);
        }
        public override void Down()
        {

        }
    }
}
