using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121128151945)]
    public class _20121128151945_ModifyIsAuditEnabled : Migration
    {
        public override void Up()
        {
            Update.Table("Metadata_Entity").InSchema("dbo").Set(new { IsAuditEnabled = true }).Where(new { Name = "ProjectTask" });
            Update.Table("Metadata_Entity").InSchema("dbo").Set(new { IsAuditEnabled = true }).Where(new { Name = "Project" });
        }

        public override void Down()
        {

        }
    }
}
