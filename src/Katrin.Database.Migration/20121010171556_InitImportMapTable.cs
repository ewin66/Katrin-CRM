using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121010171556)]
    public class _20121010171556_InitImportMapTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("ImportMap").Row(new { ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3649", Name = "SugarCRM", Source = "" });
            Insert.IntoTable("ImportMap").Row(new { ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3650", Name = "KatrinCRM", Source = "" });
        }
        public override void Down()
        {
            Delete.FromTable("ImportMap").Row(new { ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3649" });
            Delete.FromTable("ImportMap").Row(new { ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3650" });
        }
    }
}
