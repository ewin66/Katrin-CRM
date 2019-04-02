using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121015110455)]
    public class _20121015110455_InitNotificationRecipientAttributesTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "13990C7C-9E3A-4BB9-A7C0-2B78A280D76E", RecipientEntityId = "80E79E18-0F0B-4D28-ABE9-92BF875BA426", AttributeId = "25156B7E-76D7-42A9-BF56-777AB1DE0AB3", NotificationProfileId = "66DE0DC1-E13E-4CC2-8E3F-952EB6A48F1E", CriteriaId = "EE237D96-6A55-4673-BD68-791899382190" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "6099C44F-25C6-4CCE-861D-3544BFF240E4", RecipientEntityId = "8CCE9A0F-856F-42D4-8023-65A2E85AE1DD", AttributeId = "BCD248DA-3456-4ED7-ABD9-9F2FD6B89337", NotificationProfileId = "CEC12B59-3934-4CE7-82BF-FF9D2FADB272", CriteriaId = "2688B751-CF90-40A2-8531-FCED2DF5F0B1" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "F07502A7-F8C5-4CD9-AD26-4BF2F8C8796A", RecipientEntityId = "8C06FC35-C27D-4C4D-BC96-8F1BD15A480C", AttributeId = "FDFBA642-7E88-4895-BAA0-FF71A1E89E31", NotificationProfileId = "31B3C548-698C-410A-9069-B35782A2B47B", CriteriaId = "6D2545B1-8051-4C6B-8C9F-478728E1042A" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "03B9FA0A-7CA8-4816-87CB-55888BECE07C", RecipientEntityId = "DAE981F9-AD1F-4D94-A6C2-AC131DEE5AE2", AttributeId = "988C4B39-FBA0-4F91-B716-2C3AB44ED1AB", NotificationProfileId = "31B3C548-698C-410A-9069-B35782A2B47B", CriteriaId = "8A2F5543-068D-4ECA-B282-F848C9F1888F" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "C97CA571-189A-4ED1-B4B5-680B77D21670", RecipientEntityId = "80E79E18-0F0B-4D28-ABE9-92BF875BA426", AttributeId = "A86DB4AA-3CB4-47B6-B9CB-5B88BA6A11D4", NotificationProfileId = "62B43989-2CDE-4D72-9BDC-FE8415D745BF", CriteriaId = "C902BCBC-3FD6-41E2-8A5B-3D2FB007D343" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "8DCCFA5B-30AD-429D-83D5-71B06D63C3D5", RecipientEntityId = "80E79E18-0F0B-4D28-ABE9-92BF875BA426", AttributeId = "A86DB4AA-3CB4-47B6-B9CB-5B88BA6A11D4", NotificationProfileId = "05D9C711-4D73-4896-A841-755D8824BEAC", CriteriaId = "56A16CF7-3AEA-4873-AB84-B17AD7610469" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "7267ED8A-C944-451B-97B2-7C768C59403C", RecipientEntityId = "3B96362A-A7B1-4898-8A6A-9B400041BFA6", AttributeId = "01D9879C-0E67-499B-856D-6698645AC997", NotificationProfileId = "0C5113E9-A67C-43A1-97F3-F6B5ED8A9040", CriteriaId = "E9C21274-D150-4F63-ACDD-07B2FCBA21ED" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "11A88F10-E75E-4A26-8E68-812C8768847E", RecipientEntityId = "80E79E18-0F0B-4D28-ABE9-92BF875BA426", AttributeId = "25156B7E-76D7-42A9-BF56-777AB1DE0AB3", NotificationProfileId = "05D9C711-4D73-4896-A841-755D8824BEAC", CriteriaId = "AE59976D-C2B1-4727-96E5-EED09153A4A2" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "4F3E93E7-9A69-465A-B416-820C7731111A", RecipientEntityId = "DAE981F9-AD1F-4D94-A6C2-AC131DEE5AE2", AttributeId = "988C4B39-FBA0-4F91-B716-2C3AB44ED1AB", NotificationProfileId = "5855B2BD-B844-4C01-B470-04E17D32483A", CriteriaId = "6AE70226-8AC7-4362-89E6-570EB261F1F2" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "7EEBB21E-9AB5-4151-BB29-8B3DE5D520E5", RecipientEntityId = "8C06FC35-C27D-4C4D-BC96-8F1BD15A480C", AttributeId = "FDFBA642-7E88-4895-BAA0-FF71A1E89E31", NotificationProfileId = "66DE0DC1-E13E-4CC2-8E3F-952EB6A48F1E", CriteriaId = "E80FFCB3-3092-49CE-AC80-F68F1B6DA468" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "18A457D6-9655-4736-9952-90C721636D9F", RecipientEntityId = "6E8642FB-FB19-44B2-99B1-36B21DCC21E2", AttributeId = "31C8E0BD-0459-4040-92AC-65AB9C23A4FC", NotificationProfileId = "BFD148D0-64EB-48C9-A326-6A48A7729F81", CriteriaId = "B60A3845-AD4B-476E-B656-214A8721BE29" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "0A2A03E6-ABFA-4A40-A82C-926582AE8BE2", RecipientEntityId = "FCA2446B-C739-4AAA-BF63-A23C9147FDCA", AttributeId = "5D46B365-D605-4400-B050-EBCC386BF945", NotificationProfileId = "72F2B50C-DA7F-4F48-BD19-BA7EE16C7CC2", CriteriaId = "984C86BA-3609-4D4D-922C-D35B756F2E1D" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "F937498F-E23C-4A47-A6A2-BAF59D7BEFDA", RecipientEntityId = "6E8642FB-FB19-44B2-99B1-36B21DCC21E2", AttributeId = "31C8E0BD-0459-4040-92AC-65AB9C23A4FC", NotificationProfileId = "5855B2BD-B844-4C01-B470-04E17D32483A", CriteriaId = "4FE04CCA-EABC-42FD-9F66-B203633DBF89" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "642A9F7A-8135-4995-828F-E339546B5CA3", RecipientEntityId = "80E79E18-0F0B-4D28-ABE9-92BF875BA426", AttributeId = "25156B7E-76D7-42A9-BF56-777AB1DE0AB3", NotificationProfileId = "62B43989-2CDE-4D72-9BDC-FE8415D745BF", CriteriaId = "02F2A407-9F53-46C0-A5C2-C6BFB08E4FF8" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "D4DCD128-B91A-439C-A19A-E671D10D8235", RecipientEntityId = "DAE981F9-AD1F-4D94-A6C2-AC131DEE5AE2", AttributeId = "988C4B39-FBA0-4F91-B716-2C3AB44ED1AB", NotificationProfileId = "62B43989-2CDE-4D72-9BDC-FE8415D745BF", CriteriaId = "E993F1DB-8E5C-4678-AC1E-30420EE3F00B" });
            Insert.IntoTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "CAE99505-CB10-465B-A0B2-EFE89D3845C3", RecipientEntityId = "DAE981F9-AD1F-4D94-A6C2-AC131DEE5AE2", AttributeId = "988C4B39-FBA0-4F91-B716-2C3AB44ED1AB", NotificationProfileId = "72F2B50C-DA7F-4F48-BD19-BA7EE16C7CC2", CriteriaId = "C6B9438C-AE55-47B1-BDE3-1C0D6D5B47CE" });
        }
        public override void Down()
        {
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "13990C7C-9E3A-4BB9-A7C0-2B78A280D76E" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "6099C44F-25C6-4CCE-861D-3544BFF240E4" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "F07502A7-F8C5-4CD9-AD26-4BF2F8C8796A" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "03B9FA0A-7CA8-4816-87CB-55888BECE07C" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "C97CA571-189A-4ED1-B4B5-680B77D21670" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "8DCCFA5B-30AD-429D-83D5-71B06D63C3D5" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "7267ED8A-C944-451B-97B2-7C768C59403C" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "11A88F10-E75E-4A26-8E68-812C8768847E" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "4F3E93E7-9A69-465A-B416-820C7731111A" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "7EEBB21E-9AB5-4151-BB29-8B3DE5D520E5" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "18A457D6-9655-4736-9952-90C721636D9F" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "0A2A03E6-ABFA-4A40-A82C-926582AE8BE2" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "F937498F-E23C-4A47-A6A2-BAF59D7BEFDA" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "642A9F7A-8135-4995-828F-E339546B5CA3" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "D4DCD128-B91A-439C-A19A-E671D10D8235" });
            Delete.FromTable("NotificationRecipientAttributes").Row(new { NotificationRecipientAttributeId = "CAE99505-CB10-465B-A0B2-EFE89D3845C3" });
        }
    }
}
