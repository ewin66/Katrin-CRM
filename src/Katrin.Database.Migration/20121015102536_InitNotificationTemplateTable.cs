using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121015102536)]
    public class _20121015102536_InitNotificationTemplateTable : Migration
    {
        private void Insert(string notificationTemplateId, string subjectTemplate)
        {
            string sqlStatement = @"INSERT INTO [dbo].[NotificationTemplate] ([NotificationTemplateId], [SubjectTemplate])  
	VALUES ('{0}', N'{1}')";
            Execute.Sql(string.Format(sqlStatement, notificationTemplateId, subjectTemplate));
        }
        public override void Up()
        {
            Insert("CD73F3B3-7587-43D1-8206-09446001F375", "??:?? $Note.Contract.Title$ ?????  $Note.Subject$ ???  ????? $Note.NoteText$");
            Insert("1264C570-CE9D-40ED-BD81-0A8E87C13CC4", "$Note.Contract.Title$ ??????");
            Insert("0A18C0E5-DD61-4FA8-9D89-1827544847DA", "??:???? $Note.Lead.Subject$ ?????  $Note.Subject$ ???  ????? $Note.NoteText$");
            Insert("31E9458A-B0D3-43B7-BF23-2C349382482F", "??:?? $Contract.Title$ ??????, ?????$Contract.ExpiresOn$");
            Insert("306C243B-7E2F-4BD4-840C-3F45C73402B6", "?? $ProjectTask.Name$ ????");
            Insert("35A76537-F6DF-458F-8789-46CF53CCBF89", "$Note.Quote.Name$ ??????");
            Insert("4CC00B24-E111-4BBF-B47E-49717F9F5C88", "??:?? $ProjectTask.Name$ ??????, ?????$ProjectTask.EndDate$");
            Insert("D5EFB45D-BC01-44EC-9DD2-584F3056FDA8", "??:???? $Note.Opportunity.Name$ ?????  $Note.Subject$ ???  ????? $Note.NoteText$");
            Insert("8650650F-E9C2-419B-8234-80BCBC3D2875", "?? $ProjectTask.Name$ ??????");
            Insert("C191202F-F571-4550-AF86-827D6E940805", "??:?? $Note.Quote.Name$ ?????  $Note.Subject$ ???  ????? $Note.NoteText$");
            Insert("20D28948-EF14-48AB-8C4F-8D40FD7F5318", "??:?? $ProjectTask.Name$ ????");
            Insert("F5B9608E-4E93-4A0D-820A-9D34DB4342A1", "??:$Opportunity.Name$ ????????");
            Insert("52FE1869-9B38-4C40-AB83-A3367F0C1856", "$Opportunity.Lead.Subject$ ?????????????");
            Insert("9D1370B4-9396-46FD-8CC6-A774A582B9BB", "$Opportunity.Name$ ????????");
            Insert("373B3550-EDC3-4792-908C-C3295071EAD2", "$Contract.Title$ ????");
            Insert("44CD1ECA-1C8F-43B5-9857-D6B9C74A7825", "??:???? $Opportunity.Lead.Subject$ ????  $Opportunity.Name$ ????");
            Insert("DC314DA6-7EEB-49E8-A221-E72CF1C3457C", "$Note.Lead.Subject$ ????????");
            Insert("A4A960E9-5829-45BF-987D-FC1FBDBAB64D", "$Note.Opportunity.Name$ ????????");
        }
        public override void Down()
        {
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "CD73F3B3-7587-43D1-8206-09446001F375" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "1264C570-CE9D-40ED-BD81-0A8E87C13CC4" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "0A18C0E5-DD61-4FA8-9D89-1827544847DA" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "31E9458A-B0D3-43B7-BF23-2C349382482F" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "306C243B-7E2F-4BD4-840C-3F45C73402B6" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "35A76537-F6DF-458F-8789-46CF53CCBF89" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "4CC00B24-E111-4BBF-B47E-49717F9F5C88" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "D5EFB45D-BC01-44EC-9DD2-584F3056FDA8" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "8650650F-E9C2-419B-8234-80BCBC3D2875" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "C191202F-F571-4550-AF86-827D6E940805" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "20D28948-EF14-48AB-8C4F-8D40FD7F5318" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "F5B9608E-4E93-4A0D-820A-9D34DB4342A1" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "52FE1869-9B38-4C40-AB83-A3367F0C1856" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "9D1370B4-9396-46FD-8CC6-A774A582B9BB" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "373B3550-EDC3-4792-908C-C3295071EAD2" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "44CD1ECA-1C8F-43B5-9857-D6B9C74A7825" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "DC314DA6-7EEB-49E8-A221-E72CF1C3457C" });
            Delete.FromTable("NotificationTemplate").Row(new { NotificationTemplateId = "A4A960E9-5829-45BF-987D-FC1FBDBAB64D" });
        }
    }
}
