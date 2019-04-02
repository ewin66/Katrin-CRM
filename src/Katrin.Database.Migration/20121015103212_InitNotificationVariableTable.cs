using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121015103212)]
    public class _20121015103212_InitNotificationVariableTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "11B4232C-405E-492C-8581-083171122F9E", ParentId = "00000000-0000-0000-0000-000000000000", RelatedAttributeId = (Guid?)null, Name = "Opportunity variable", EntityId = "80E79E18-0F0B-4D28-ABE9-92BF875BA426", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "65D03DB2-7B61-4490-BA84-0AEC9246A5E9", ParentId = "00000000-0000-0000-0000-000000000000", RelatedAttributeId = (Guid?)null, Name = "ProjectTask variable", EntityId = "3B96362A-A7B1-4898-8A6A-9B400041BFA6", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "AE295782-BEA5-40C7-9409-11839E6ED95D", ParentId = "00000000-0000-0000-0000-000000000000", RelatedAttributeId = (Guid?)null, Name = "Note variable", EntityId = "DAE981F9-AD1F-4D94-A6C2-AC131DEE5AE2", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "3D98C2C5-98C1-4920-A831-347AA3973CB0", ParentId = "D9E8531F-758E-4581-B77B-5BD8D03C05FB", RelatedAttributeId = "2602C977-69E4-4E87-B9B0-FB4ED12D6404", Name = "Opportunity variable", EntityId = "80E79E18-0F0B-4D28-ABE9-92BF875BA426", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "5801B85E-4690-4E97-A0AF-473C3817505D", ParentId = "798CB639-FFEA-42D4-80F3-583090DB09E9", RelatedAttributeId = "2602C977-69E4-4E87-B9B0-FB4ED12D6404", Name = "Contract variable", EntityId = "6E8642FB-FB19-44B2-99B1-36B21DCC21E2", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "FC6145B7-E745-4EFD-806C-4C92CFA5925A", ParentId = "11B4232C-405E-492C-8581-083171122F9E", RelatedAttributeId = "7F2DFE63-577F-4D45-BF69-D9706F2A745F", Name = "Lead variable", EntityId = "8C06FC35-C27D-4C4D-BC96-8F1BD15A480C", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "242025A9-5AC1-454A-A036-516C07A68265", ParentId = "00000000-0000-0000-0000-000000000000", RelatedAttributeId = (Guid?)null, Name = "Opportunity variable", EntityId = "80E79E18-0F0B-4D28-ABE9-92BF875BA426", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "798CB639-FFEA-42D4-80F3-583090DB09E9", ParentId = "00000000-0000-0000-0000-000000000000", RelatedAttributeId = (Guid?)null, Name = "Note variable", EntityId = "DAE981F9-AD1F-4D94-A6C2-AC131DEE5AE2", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "D9E8531F-758E-4581-B77B-5BD8D03C05FB", ParentId = "00000000-0000-0000-0000-000000000000", RelatedAttributeId = (Guid?)null, Name = "Note variable", EntityId = "DAE981F9-AD1F-4D94-A6C2-AC131DEE5AE2", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "8D23236A-1998-4B64-9940-5D6F2552B160", ParentId = "00000000-0000-0000-0000-000000000000", RelatedAttributeId = (Guid?)null, Name = "Note variable", EntityId = "DAE981F9-AD1F-4D94-A6C2-AC131DEE5AE2", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "4D4B1BC8-CF80-4CF5-A881-5DB9CB2C8F8A", ParentId = "00000000-0000-0000-0000-000000000000", RelatedAttributeId = (Guid?)null, Name = "ProjectTask variable", EntityId = "3B96362A-A7B1-4898-8A6A-9B400041BFA6", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "D4651E13-0EF3-4F65-99DF-5F4FC67EBD5F", ParentId = "AE295782-BEA5-40C7-9409-11839E6ED95D", RelatedAttributeId = "2602C977-69E4-4E87-B9B0-FB4ED12D6404", Name = "Lead variable", EntityId = "8C06FC35-C27D-4C4D-BC96-8F1BD15A480C", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "917AACAC-CC08-4A9A-AF96-889FB5CCE9FC", ParentId = "00000000-0000-0000-0000-000000000000", RelatedAttributeId = (Guid?)null, Name = "Contract variable", EntityId = "6E8642FB-FB19-44B2-99B1-36B21DCC21E2", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "14A9668E-761C-407E-804C-8E784F4DA8E0", ParentId = "65D03DB2-7B61-4490-BA84-0AEC9246A5E9", RelatedAttributeId = "74B9EFA4-03A1-4618-9085-9BC728196265", Name = "Project variable", EntityId = "4131651A-C217-4D44-9EF5-A0947B5A3749", NotificationUrl = "" });
            Insert.IntoTable("NotificationVariable").Row(new { NotificationVariableId = "E660582E-2130-455E-8C8B-E6128476BDBD", ParentId = "8D23236A-1998-4B64-9940-5D6F2552B160", RelatedAttributeId = "2602C977-69E4-4E87-B9B0-FB4ED12D6404", Name = "Quote variable", EntityId = "FCA2446B-C739-4AAA-BF63-A23C9147FDCA", NotificationUrl = "" });
        }
        public override void Down()
        {
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "11B4232C-405E-492C-8581-083171122F9E" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "65D03DB2-7B61-4490-BA84-0AEC9246A5E9" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "AE295782-BEA5-40C7-9409-11839E6ED95D" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "3D98C2C5-98C1-4920-A831-347AA3973CB0" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "5801B85E-4690-4E97-A0AF-473C3817505D" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "FC6145B7-E745-4EFD-806C-4C92CFA5925A" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "242025A9-5AC1-454A-A036-516C07A68265" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "798CB639-FFEA-42D4-80F3-583090DB09E9" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "D9E8531F-758E-4581-B77B-5BD8D03C05FB" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "8D23236A-1998-4B64-9940-5D6F2552B160" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "4D4B1BC8-CF80-4CF5-A881-5DB9CB2C8F8A" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "D4651E13-0EF3-4F65-99DF-5F4FC67EBD5F" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "917AACAC-CC08-4A9A-AF96-889FB5CCE9FC" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "14A9668E-761C-407E-804C-8E784F4DA8E0" });
            Delete.FromTable("NotificationVariable").Row(new { NotificationVariableId = "E660582E-2130-455E-8C8B-E6128476BDBD" });
        }
    }
}
