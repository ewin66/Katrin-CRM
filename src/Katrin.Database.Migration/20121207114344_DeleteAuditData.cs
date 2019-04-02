using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121207114344)]
    public class _20121207114344_DeleteAuditData : Migration
    {
        public override void Up()
        {
            string sql = @"delete from Audit where fieldName in('ModifiedOn','VersionNumber','ModifiedBy','ModifiedById') or FieldName is null";
            Execute.Sql(sql);
        }

        public override void Down()
        {

        }
    }
}
