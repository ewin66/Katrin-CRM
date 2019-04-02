using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121010171625)]
    public class _20121010171625_InitImportEntityMappingTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "A4C3D7C1-BEDE-4982-8C3C-093C645F00F8", SourceEntityName = "Lead", TargetEntityName = "Opportunity", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3650" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "8B490E90-6D37-4ED3-9103-0EAC2E2A9710", SourceEntityName = "Lead", TargetEntityName = "Account", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3650" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "1B1BF0FA-2986-4342-AF7B-2F02092F84BC", SourceEntityName = "Opportunities", TargetEntityName = "Opportunity", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3649" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "869D64AE-CC52-4F3E-8F74-470E9A3D56F1", SourceEntityName = "Katrin_Invoice", TargetEntityName = "Invoice", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3649" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "9F659E6E-EC3C-4174-B38D-4A9287D58903", SourceEntityName = "Contracts", TargetEntityName = "Contract", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3649" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "580D9DC3-3CCF-4920-A1EC-5341F0192F7C", SourceEntityName = "Opportunity", TargetEntityName = "Contract", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3650" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "552F18D0-12D2-4FEA-95A3-66C26830C0F2", SourceEntityName = "Users", TargetEntityName = "User", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3649" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "36772C77-F5CF-410E-A794-6AD4D9407A9B", SourceEntityName = "ProductQuotes", TargetEntityName = "QuoteLineItem", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3649" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "E578C918-3292-4B48-A1C7-7D04D866977C", SourceEntityName = "Products", TargetEntityName = "Product", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3649" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "B97CA372-C94E-4B88-ABA7-958574252F74", SourceEntityName = "Contract", TargetEntityName = "Invoice", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3650" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "644406DD-D356-4D96-BDD1-A90E506EFE5B", SourceEntityName = "Accounts", TargetEntityName = "Account", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3649" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "998EDB2D-2D2A-42A4-A9B4-B29D07CF32C7", SourceEntityName = "Lead", TargetEntityName = "Contact", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3650" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "F0F5F9C8-508E-492A-A460-B863EF85A239", SourceEntityName = "Contacts", TargetEntityName = "Contact", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3649" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "EF323BE2-EF90-48A0-BF10-CFE4486A3DBE", SourceEntityName = "Quotes", TargetEntityName = "Quote", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3649" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "B81DF2EB-AA9D-4998-87A0-E3531AB156BF", SourceEntityName = "Leads", TargetEntityName = "Lead", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3649" });
            Insert.IntoTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "549737E4-7EC4-4AF9-A4FE-FBA40592150D", SourceEntityName = "Opportunity", TargetEntityName = "Quote", ImportMapId = "75720961-A26A-4D25-B3E5-1978322B3650" });
        }
        public override void Down()
        {
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "A4C3D7C1-BEDE-4982-8C3C-093C645F00F8" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "8B490E90-6D37-4ED3-9103-0EAC2E2A9710" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "1B1BF0FA-2986-4342-AF7B-2F02092F84BC" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "869D64AE-CC52-4F3E-8F74-470E9A3D56F1" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "9F659E6E-EC3C-4174-B38D-4A9287D58903" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "580D9DC3-3CCF-4920-A1EC-5341F0192F7C" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "552F18D0-12D2-4FEA-95A3-66C26830C0F2" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "36772C77-F5CF-410E-A794-6AD4D9407A9B" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "E578C918-3292-4B48-A1C7-7D04D866977C" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "B97CA372-C94E-4B88-ABA7-958574252F74" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "644406DD-D356-4D96-BDD1-A90E506EFE5B" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "998EDB2D-2D2A-42A4-A9B4-B29D07CF32C7" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "F0F5F9C8-508E-492A-A460-B863EF85A239" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "EF323BE2-EF90-48A0-BF10-CFE4486A3DBE" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "B81DF2EB-AA9D-4998-87A0-E3531AB156BF" });
            Delete.FromTable("ImportEntityMapping").Row(new { ImportEntityMappingId = "549737E4-7EC4-4AF9-A4FE-FBA40592150D" });
        }
    }
}
