using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121025163935)]
    public class _20121025163935_UpdateNotificationProfileTable : Migration
    {
        public override void Up()
        {
            Update.Table("NotificationProfile").InSchema("dbo").Set(new { SubjectTemplateId = "1264C570-CE9D-40ED-BD81-0A8E87C13CC4" }).Where(new { NotificationProfileId = "5855B2BD-B844-4C01-B470-04E17D32483A" });
            Update.Table("NotificationProfile").InSchema("dbo").Set(new { SubjectTemplateId = "373B3550-EDC3-4792-908C-C3295071EAD2" }).Where(new { NotificationProfileId = "BFD148D0-64EB-48C9-A326-6A48A7729F81" });
            Update.Table("NotificationProfile").InSchema("dbo").Set(new { SubjectTemplateId = "A4A960E9-5829-45BF-987D-FC1FBDBAB64D" }).Where(new { NotificationProfileId = "05D9C711-4D73-4896-A841-755D8824BEAC" });
            Update.Table("NotificationProfile").InSchema("dbo").Set(new { SubjectTemplateId = "52FE1869-9B38-4C40-AB83-A3367F0C1856" }).Where(new { NotificationProfileId = "66DE0DC1-E13E-4CC2-8E3F-952EB6A48F1E" });
            Update.Table("NotificationProfile").InSchema("dbo").Set(new { SubjectTemplateId = "DC314DA6-7EEB-49E8-A221-E72CF1C3457C" }).Where(new { NotificationProfileId = "31B3C548-698C-410A-9069-B35782A2B47B" });
            Update.Table("NotificationProfile").InSchema("dbo").Set(new { SubjectTemplateId = "35A76537-F6DF-458F-8789-46CF53CCBF89" }).Where(new { NotificationProfileId = "72F2B50C-DA7F-4F48-BD19-BA7EE16C7CC2" });
            Update.Table("NotificationProfile").InSchema("dbo").Set(new { SubjectTemplateId = "306C243B-7E2F-4BD4-840C-3F45C73402B6" }).Where(new { NotificationProfileId = "0C5113E9-A67C-43A1-97F3-F6B5ED8A9040" });
            Update.Table("NotificationProfile").InSchema("dbo").Set(new { SubjectTemplateId = "A4A960E9-5829-45BF-987D-FC1FBDBAB64D" }).Where(new { NotificationProfileId = "62B43989-2CDE-4D72-9BDC-FE8415D745BF" });
            Update.Table("NotificationProfile").InSchema("dbo").Set(new { SubjectTemplateId = "8650650F-E9C2-419B-8234-80BCBC3D2875" }).Where(new { NotificationProfileId = "CEC12B59-3934-4CE7-82BF-FF9D2FADB272" });
        }
        public override void Down()
        {

        }
    }
}
