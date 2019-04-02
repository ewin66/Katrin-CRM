using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121010175655)]
    public class _20121010175655_InitSystemSettingTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("SystemSetting").Row(new { SystemSettingId = "F8C15EC7-7CD5-4D88-84B9-23A549368E8C", Name = "FullName", Value = "<FirstName> <LastName>" });
        }
        public override void Down()
        {
            Delete.FromTable("SystemSetting").Row(new { SystemSettingId = "F8C15EC7-7CD5-4D88-84B9-23A549368E8C" });
        }
    }
}
