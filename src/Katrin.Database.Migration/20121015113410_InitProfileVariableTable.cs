using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121015113410)]
    public class _20121015113410_InitProfileVariableTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("ProfileVariable").Row(new { ProfileVariableId = "7218FC2D-CA7D-4E8F-AEDC-1D982C6490C3", NotificationProfileId = "31B3C548-698C-410A-9069-B35782A2B47B", NotificationVariableId = "AE295782-BEA5-40C7-9409-11839E6ED95D" });
            Insert.IntoTable("ProfileVariable").Row(new { ProfileVariableId = "3AFB072E-027E-4757-8534-445056CE9C09", NotificationProfileId = "CEC12B59-3934-4CE7-82BF-FF9D2FADB272", NotificationVariableId = "65D03DB2-7B61-4490-BA84-0AEC9246A5E9" });
            Insert.IntoTable("ProfileVariable").Row(new { ProfileVariableId = "5B4BD0A5-6670-4BC7-B88B-521EDC177E27", NotificationProfileId = "05D9C711-4D73-4896-A841-755D8824BEAC", NotificationVariableId = "242025A9-5AC1-454A-A036-516C07A68265" });
            Insert.IntoTable("ProfileVariable").Row(new { ProfileVariableId = "60F78814-A9F8-4D24-905A-5ECA1BEA6728", NotificationProfileId = "72F2B50C-DA7F-4F48-BD19-BA7EE16C7CC2", NotificationVariableId = "8D23236A-1998-4B64-9940-5D6F2552B160" });
            Insert.IntoTable("ProfileVariable").Row(new { ProfileVariableId = "3F99B7E7-696E-45D5-913A-A4C26A271E1B", NotificationProfileId = "62B43989-2CDE-4D72-9BDC-FE8415D745BF", NotificationVariableId = "D9E8531F-758E-4581-B77B-5BD8D03C05FB" });
            Insert.IntoTable("ProfileVariable").Row(new { ProfileVariableId = "E9F7EB3D-CF02-408D-ABC4-BC1F784EFF22", NotificationProfileId = "0C5113E9-A67C-43A1-97F3-F6B5ED8A9040", NotificationVariableId = "4D4B1BC8-CF80-4CF5-A881-5DB9CB2C8F8A" });
            Insert.IntoTable("ProfileVariable").Row(new { ProfileVariableId = "7E3F39DB-FC5F-45F0-BE5B-D37F9D0ADAD2", NotificationProfileId = "BFD148D0-64EB-48C9-A326-6A48A7729F81", NotificationVariableId = "917AACAC-CC08-4A9A-AF96-889FB5CCE9FC" });
            Insert.IntoTable("ProfileVariable").Row(new { ProfileVariableId = "BBAF2B80-C12A-4366-BDA8-EA30CD880AA7", NotificationProfileId = "5855B2BD-B844-4C01-B470-04E17D32483A", NotificationVariableId = "798CB639-FFEA-42D4-80F3-583090DB09E9" });
            Insert.IntoTable("ProfileVariable").Row(new { ProfileVariableId = "0E89BC92-9E77-4E24-A415-F26FE89E79FB", NotificationProfileId = "66DE0DC1-E13E-4CC2-8E3F-952EB6A48F1E", NotificationVariableId = "11B4232C-405E-492C-8581-083171122F9E" });
        }
        public override void Down()
        {
            Delete.FromTable("ProfileVariable").Row(new { ProfileVariableId = "7218FC2D-CA7D-4E8F-AEDC-1D982C6490C3" });
            Delete.FromTable("ProfileVariable").Row(new { ProfileVariableId = "3AFB072E-027E-4757-8534-445056CE9C09" });
            Delete.FromTable("ProfileVariable").Row(new { ProfileVariableId = "5B4BD0A5-6670-4BC7-B88B-521EDC177E27" });
            Delete.FromTable("ProfileVariable").Row(new { ProfileVariableId = "60F78814-A9F8-4D24-905A-5ECA1BEA6728" });
            Delete.FromTable("ProfileVariable").Row(new { ProfileVariableId = "3F99B7E7-696E-45D5-913A-A4C26A271E1B" });
            Delete.FromTable("ProfileVariable").Row(new { ProfileVariableId = "E9F7EB3D-CF02-408D-ABC4-BC1F784EFF22" });
            Delete.FromTable("ProfileVariable").Row(new { ProfileVariableId = "7E3F39DB-FC5F-45F0-BE5B-D37F9D0ADAD2" });
            Delete.FromTable("ProfileVariable").Row(new { ProfileVariableId = "BBAF2B80-C12A-4366-BDA8-EA30CD880AA7" });
            Delete.FromTable("ProfileVariable").Row(new { ProfileVariableId = "0E89BC92-9E77-4E24-A415-F26FE89E79FB" });
        }
    }
}
