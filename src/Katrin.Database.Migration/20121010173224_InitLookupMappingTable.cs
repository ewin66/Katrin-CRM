using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121010173224)]
    public class _20121010173224_InitLookupMappingTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("LookupMapping").Row(new { LookupMappingId = "F05749FD-0C67-4CEA-BE41-38EBD48CD3E6", ColumnMappingId = "8C348BC9-2B0A-4A0B-ABF7-BD8561172CAA", LookupEntityName = "Department", ValueAttributeName = "DepartmentId", LookupAttributeName = "Name" });
            Insert.IntoTable("LookupMapping").Row(new { LookupMappingId = "7935AB74-C477-48DA-A060-4CD43E4356D1", ColumnMappingId = "A763F71B-6E34-475D-8D60-DE28BBFD94FE", LookupEntityName = "Department", ValueAttributeName = "DepartmentId", LookupAttributeName = "Name" });
        }
        public override void Down()
        {
            Delete.FromTable("LookupMapping").Row(new { LookupMappingId = "F05749FD-0C67-4CEA-BE41-38EBD48CD3E6" });
            Delete.FromTable("LookupMapping").Row(new { LookupMappingId = "7935AB74-C477-48DA-A060-4CD43E4356D1" });
        }
    }
}
