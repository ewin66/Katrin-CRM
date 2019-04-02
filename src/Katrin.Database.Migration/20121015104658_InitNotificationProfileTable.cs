using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121015104658)]
    public class _20121015104658_InitNotificationProfileTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("NotificationProfile").Row(new { NotificationProfileId = "5855B2BD-B844-4C01-B470-04E17D32483A", CriteriaId = "F3A37163-BC68-478E-B286-53C6D688D638", NotificationTemplateId = "CD73F3B3-7587-43D1-8206-09446001F375", SubjectTemplateId = "1264C570-CE9D-40ED-BD81-0A8E87C13CC4", IsSys = 0 });
            Insert.IntoTable("NotificationProfile").Row(new { NotificationProfileId = "BFD148D0-64EB-48C9-A326-6A48A7729F81", CriteriaId = "442171B7-A494-4635-ABE1-40B4C54C2CB2", NotificationTemplateId = "31E9458A-B0D3-43B7-BF23-2C349382482F", SubjectTemplateId = "373B3550-EDC3-4792-908C-C3295071EAD2", IsSys = 1 });
            Insert.IntoTable("NotificationProfile").Row(new { NotificationProfileId = "05D9C711-4D73-4896-A841-755D8824BEAC", CriteriaId = "C7645994-E0A6-4FB4-A081-6D899C679A70", NotificationTemplateId = "F5B9608E-4E93-4A0D-820A-9D34DB4342A1", SubjectTemplateId = "A4A960E9-5829-45BF-987D-FC1FBDBAB64D", IsSys = 0 });
            Insert.IntoTable("NotificationProfile").Row(new { NotificationProfileId = "66DE0DC1-E13E-4CC2-8E3F-952EB6A48F1E", CriteriaId = "EEBD3399-4EBE-4226-8FD0-52FE998AD497", NotificationTemplateId = "44CD1ECA-1C8F-43B5-9857-D6B9C74A7825", SubjectTemplateId = "52FE1869-9B38-4C40-AB83-A3367F0C1856", IsSys = 0 });
            Insert.IntoTable("NotificationProfile").Row(new { NotificationProfileId = "31B3C548-698C-410A-9069-B35782A2B47B", CriteriaId = "1009944B-63E7-4BA9-A7B0-B5A1381CA35B", NotificationTemplateId = "0A18C0E5-DD61-4FA8-9D89-1827544847DA", SubjectTemplateId = "DC314DA6-7EEB-49E8-A221-E72CF1C3457C", IsSys = 0 });
            Insert.IntoTable("NotificationProfile").Row(new { NotificationProfileId = "72F2B50C-DA7F-4F48-BD19-BA7EE16C7CC2", CriteriaId = "2B000F01-2A0B-4B19-AFCC-D218A6FCD434", NotificationTemplateId = "C191202F-F571-4550-AF86-827D6E940805", SubjectTemplateId = "35A76537-F6DF-458F-8789-46CF53CCBF89", IsSys = 0 });
            Insert.IntoTable("NotificationProfile").Row(new { NotificationProfileId = "0C5113E9-A67C-43A1-97F3-F6B5ED8A9040", CriteriaId = "1CD6159F-9970-4901-92F2-2D5D7891BE42", NotificationTemplateId = "20D28948-EF14-48AB-8C4F-8D40FD7F5318", SubjectTemplateId = "306C243B-7E2F-4BD4-840C-3F45C73402B6", IsSys = 0 });
            Insert.IntoTable("NotificationProfile").Row(new { NotificationProfileId = "62B43989-2CDE-4D72-9BDC-FE8415D745BF", CriteriaId = "46F4D060-7793-4222-B78D-67F558411C9B", NotificationTemplateId = "D5EFB45D-BC01-44EC-9DD2-584F3056FDA8", SubjectTemplateId = "A4A960E9-5829-45BF-987D-FC1FBDBAB64D", IsSys = 0 });
            Insert.IntoTable("NotificationProfile").Row(new { NotificationProfileId = "CEC12B59-3934-4CE7-82BF-FF9D2FADB272", CriteriaId = "CF47973C-9BED-449F-8F0E-2D4D6B26BB5A", NotificationTemplateId = "4CC00B24-E111-4BBF-B47E-49717F9F5C88", SubjectTemplateId = "8650650F-E9C2-419B-8234-80BCBC3D2875", IsSys = 1 });
        }
        public override void Down()
        {
            Delete.FromTable("NotificationProfile").Row(new { NotificationProfileId = "5855B2BD-B844-4C01-B470-04E17D32483A" });
            Delete.FromTable("NotificationProfile").Row(new { NotificationProfileId = "BFD148D0-64EB-48C9-A326-6A48A7729F81" });
            Delete.FromTable("NotificationProfile").Row(new { NotificationProfileId = "05D9C711-4D73-4896-A841-755D8824BEAC" });
            Delete.FromTable("NotificationProfile").Row(new { NotificationProfileId = "66DE0DC1-E13E-4CC2-8E3F-952EB6A48F1E" });
            Delete.FromTable("NotificationProfile").Row(new { NotificationProfileId = "31B3C548-698C-410A-9069-B35782A2B47B" });
            Delete.FromTable("NotificationProfile").Row(new { NotificationProfileId = "72F2B50C-DA7F-4F48-BD19-BA7EE16C7CC2" });
            Delete.FromTable("NotificationProfile").Row(new { NotificationProfileId = "0C5113E9-A67C-43A1-97F3-F6B5ED8A9040" });
            Delete.FromTable("NotificationProfile").Row(new { NotificationProfileId = "62B43989-2CDE-4D72-9BDC-FE8415D745BF" });
            Delete.FromTable("NotificationProfile").Row(new { NotificationProfileId = "CEC12B59-3934-4CE7-82BF-FF9D2FADB272" });
        } 
    }
}
