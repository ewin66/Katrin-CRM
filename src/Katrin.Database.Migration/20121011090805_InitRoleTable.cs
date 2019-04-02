using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121011090805)]
    public class _20121011090805_InitRoleTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Role").Row(new { RoleId = "527CB559-0CC6-487F-A962-143BC9CD1484", RoleName = "Department Manager", Description = "" });
            Insert.IntoTable("Role").Row(new { RoleId = "C6FBFB92-51C0-4CF6-B8A6-1D5302C4E77B", RoleName = "Sales", Description = "" });
            Insert.IntoTable("Role").Row(new { RoleId = "2174AB96-C59F-4A4F-B3CD-5FE12727B7B4", RoleName = "Administrators", Description = "" });
            Insert.IntoTable("Role").Row(new { RoleId = "74247C6F-97BE-46C6-BF0A-6D4C4B03070A", RoleName = "Technician", Description = "" });
        }
        public override void Down()
        {
            Delete.FromTable("Role").Row(new { RoleId = "527CB559-0CC6-487F-A962-143BC9CD1484" });
            Delete.FromTable("Role").Row(new { RoleId = "C6FBFB92-51C0-4CF6-B8A6-1D5302C4E77B" });
            Delete.FromTable("Role").Row(new { RoleId = "2174AB96-C59F-4A4F-B3CD-5FE12727B7B4" });
            Delete.FromTable("Role").Row(new { RoleId = "74247C6F-97BE-46C6-BF0A-6D4C4B03070A" });
        }
    }
}
