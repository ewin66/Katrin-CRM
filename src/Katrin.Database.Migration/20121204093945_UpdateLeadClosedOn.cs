using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121204093945)]
    public class _20121204093945_UpdateLeadClosedOn : Migration
    {
        public override void Up()
        {
            string sql = @" UPDATE Lead SET ClosedOn=ModifiedOn WHERE StatusCode IN(6,4)";
            Execute.Sql(sql);
        }

        public override void Down()
        {

        }
    }
}
