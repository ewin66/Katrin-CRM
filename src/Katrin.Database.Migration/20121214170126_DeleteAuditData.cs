using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121214170126)]
    public class _20121214170126_DeleteAuditData : Migration
    {
        public override void Up()
        {
            string sql = @"delete from audit where FieldName in(
            select FieldName from audit where FieldName not in(
            select distinct  PhysicalName from Metadata_Attribute
            )
            )";
            Execute.Sql(sql);
        }
        public override void Down()
        {

        }
    }
}
