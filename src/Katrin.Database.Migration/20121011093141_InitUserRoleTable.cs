using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121011093141)]
    public class _20121011093141_InitUserRoleTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("UserRole").Row(new { Id = "42ADEA4F-08F0-4D12-875A-F1F0318FC312", UserId = "20C163A1-BF24-4282-AF2B-728A8B4AD124", RoleId = "2174AB96-C59F-4A4F-B3CD-5FE12727B7B4" });
        }
        public override void Down()
        {
            Delete.FromTable("UserRole").Row(new { Id = "42ADEA4F-08F0-4D12-875A-F1F0318FC312" });
        }
    }
}
