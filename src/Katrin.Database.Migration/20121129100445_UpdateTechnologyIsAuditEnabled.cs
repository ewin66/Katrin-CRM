using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121129100445)]
    public class _20121129100445_UpdateTechnologyIsAuditEnabled : Migration
    {
        public override void Up()
        {
            string sql = "update Metadata_Attribute set IsAuditEnabled=1 where Name like '%tech%'";
            Execute.Sql(sql);
        }

        public override void Down()
        {

        }
    }
}
