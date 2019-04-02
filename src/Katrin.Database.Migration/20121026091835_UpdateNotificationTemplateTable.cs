using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121026091835)]
    public class _20121026091835_UpdateNotificationTemplateTable : Migration
    {
        private void UpdateTable(string subjectTemplate, string notificationTemplateId)
        {
            string sqlStatement = @"Update [dbo].[NotificationTemplate] set SubjectTemplate=N'{0}' where NotificationTemplateId='{1}' ";
            Execute.Sql(string.Format(sqlStatement, subjectTemplate, notificationTemplateId));
        }

        public override void Up()
        {
            UpdateTable("?????:$Note.Subject$??????:$Note.NoteText$?", "CD73F3B3-7587-43D1-8206-09446001F375");
            UpdateTable("??“$Note.Contract.Title$”??$Note.User.FullName$????", "1264C570-CE9D-40ED-BD81-0A8E87C13CC4");
            UpdateTable("?????:$Note.Subject$??????:$Note.NoteText$?", "0A18C0E5-DD61-4FA8-9D89-1827544847DA");
            UpdateTable("??“$Note.Quote.Name$”??$Note.User.FullName$????", "35A76537-F6DF-458F-8789-46CF53CCBF89");
            UpdateTable("?????:$Note.Subject$??????:$Note.NoteText$?", "D5EFB45D-BC01-44EC-9DD2-584F3056FDA8");
            UpdateTable("?????:$Note.Subject$??????:$Note.NoteText$?", "C191202F-F571-4550-AF86-827D6E940805");
            UpdateTable("????“$Note.Lead.Subject$”??$Note.User.FullName$????", "DC314DA6-7EEB-49E8-A221-E72CF1C3457C");
            UpdateTable("????“$Note.Opportunity.Name$”??$Note.User.FullName$????", "A4A960E9-5829-45BF-987D-FC1FBDBAB64D");

            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "D4651E13-0EF3-4F00-99DF-5F4FC67EBD5F", ParentId = "AE295782-BEA5-40C7-9409-11839E6ED95D", RelatedAttributeId = "988C4B39-FBA0-4F91-B716-2C3AB44ED1AB", Name = "User variable", EntityId = "4124D7F6-0673-4A6C-BA52-8713254264EB", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "D4651E13-0EF3-4F01-99DF-5F4FC67EBD5F", ParentId = "798CB639-FFEA-42D4-80F3-583090DB09E9", RelatedAttributeId = "988C4B39-FBA0-4F91-B716-2C3AB44ED1AB", Name = "User variable", EntityId = "4124D7F6-0673-4A6C-BA52-8713254264EB", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "D4651E13-0EF3-4F02-99DF-5F4FC67EBD5F", ParentId = "D9E8531F-758E-4581-B77B-5BD8D03C05FB", RelatedAttributeId = "988C4B39-FBA0-4F91-B716-2C3AB44ED1AB", Name = "User variable", EntityId = "4124D7F6-0673-4A6C-BA52-8713254264EB", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "D4651E13-0EF3-4F03-99DF-5F4FC67EBD5F", ParentId = "8D23236A-1998-4B64-9940-5D6F2552B160", RelatedAttributeId = "988C4B39-FBA0-4F91-B716-2C3AB44ED1AB", Name = "User variable", EntityId = "4124D7F6-0673-4A6C-BA52-8713254264EB", NotificationUrl = "" });

        }
        public override void Down()
        {

        }
    }
}
