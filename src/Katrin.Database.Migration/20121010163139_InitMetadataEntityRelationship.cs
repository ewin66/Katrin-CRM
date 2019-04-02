using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121010163139)]
    public class _20121010163139_InitMetadataEntityRelationship : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "AA404AAC-4DCF-42DE-AC88-02135FD6D896", SchemaName = "opportunity_user_owner", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9EE920D4-C7DE-49C1-8D17-03D890004D7A", SchemaName = "projectmember_association", EntityRelationshipType = 1, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "EBE71F6D-A843-4493-811C-042D35723C90", SchemaName = "account_department", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "36650F25-E3F0-4C00-84CF-07009D910E1E", SchemaName = "quote_user", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "0A50C157-FEDE-436F-B979-07A7277F0014", SchemaName = "timetracking_user", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9F5DF63B-05E6-43DF-BBAB-07D4F378436C", SchemaName = "lead_user_owner", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "443CD42A-071B-4A0D-AD76-0B0EFDEB554A", SchemaName = "user_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "54CEE8AA-E738-4C8E-9390-0B20AB20247D", SchemaName = "note_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "D129E6AA-3A7E-4AC4-B798-0B40C429D21F", SchemaName = "tasktimehistory_projecttask_taskid", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "3FDC8876-89CB-43DC-81A0-10E10BB0F23D", SchemaName = "contract_opportunity", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "0857573B-C96D-40AE-BF13-149DC82D4571", SchemaName = "projectweekreport_projectiteration_projectiterationid", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F3D96130-300D-4433-8ED1-1A963FF6C0F2", SchemaName = "project_account", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9597AB74-C0F1-410D-AD92-22B3F0F35D9D", SchemaName = "lead_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "90610E43-989D-45A9-AD01-285F6A813AC6", SchemaName = "project_Contract_ContractId", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "47E165C9-93E9-488B-9450-2A141FE1D3F5", SchemaName = "Attendance_user_recordperson", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "8040943D-3BDD-4A15-BDB9-2DDA40BFEE52", SchemaName = "quotelineitem_quote", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "42DA677C-9A6C-4AEC-988A-310E8DCCD0F7", SchemaName = "roleprivilege_association", EntityRelationshipType = 1, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "B22B0E84-BFCB-4B18-8557-32BB94661F0A", SchemaName = "contract_account", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "A8D873D0-FF8F-4657-85EB-33B26AD83447", SchemaName = "opportunity_department", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "4833DC03-E3DC-496C-AC0B-3654971D37E8", SchemaName = "projectiteration_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "E43B3DBE-58B2-414F-85E5-394D73EA8623", SchemaName = "audit_user", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "303A6630-D065-4B38-93D9-39D1E55DC07E", SchemaName = "Notification_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F71DA70D-C805-4725-82BF-3B2089E2F63D", SchemaName = "privilegeEntity_privilege", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "97ABC5A2-5364-4F11-85EE-3CD8724772E6", SchemaName = "projectiteration_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F251825D-15C4-4D94-93E7-44EA826D0EB9", SchemaName = "invoice_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "492805A5-C360-4579-9CAC-45DC9BC3D7CB", SchemaName = "opportunity_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F56769CF-BB15-433C-B912-47125E00BAA2", SchemaName = "projecttask_projectiteration_ProjectIterationId", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "BE5C1988-8061-44CC-BEF4-4A0640171319", SchemaName = "NotificationRecipient_user", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "0CC8740F-26DE-4B59-A6E7-50B4F782E1FF", SchemaName = "projectweekreport_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "CB7BA63C-4CCE-453E-8D74-515F1DC63806", SchemaName = "lead_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "E4918557-C891-45DE-B5E2-5217B083359B", SchemaName = "account_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "56074DB4-8A35-4F75-8139-525E7EFB0F52", SchemaName = "product_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "47DD6F0B-61AF-49FE-A618-5316B65F40CC", SchemaName = "NotificationRecipient_Notification", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "4F7C3910-BB7C-4299-8A2B-5545EBFBC4BE", SchemaName = "Attendance_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "AA812180-5DB3-4E78-9CA6-5A0D5431BA24", SchemaName = "quote_account", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "D6B971E8-0774-442E-9D41-61F0057B40CF", SchemaName = "project_user_SaleServiceId", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "76FD764A-30E5-4519-A5A9-6A85F3EDFE67", SchemaName = "opportunity_lead", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "27386265-4F45-4E5F-A4B3-6C7B0B2A7E4E", SchemaName = "opportunity_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "06C91B63-33EA-443C-814F-6EF15F5017E8", SchemaName = "userrole_association", EntityRelationshipType = 1, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "E6D202DF-12AC-4B6B-8E48-6FCBA1A13921", SchemaName = "note_user_createdby", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "B9E6B3C7-F5A9-4C2A-BF72-709E59C8DCFA", SchemaName = "contract_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "C83037B9-872B-4145-9361-7293AAF25AF5", SchemaName = "projectversion_project_ProjectId", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "DA02C618-896D-4D56-9BD4-73177823FD34", SchemaName = "opportunity_user_technicianId", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "D21A0494-387F-48EA-BABC-7C78F26CC149", SchemaName = "lead_department", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "37C4D625-5E25-4014-97E7-7D6D8C2D323F", SchemaName = "projecttask_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "88DDB10D-30EA-4BEA-BC27-7EBFC42A829F", SchemaName = "Notification_user_ModifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F79F1E65-4D5F-46C3-B77B-85FED2554111", SchemaName = "projecttask_project_ProjectId", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "405485A3-5439-415B-BBB9-8851CF974F8F", SchemaName = "projecttask_user_owner", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "B6A06992-3948-4AA0-A578-892D7F957CB8", SchemaName = "projectversion_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "8DE6FFB6-53EB-4FF2-AE32-8E8B20EF371A", SchemaName = "account_user", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9C64A996-93E1-44BF-8E90-9587F65B89FF", SchemaName = "project_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "CDF0249F-4B87-4FBC-9064-A00229A1056F", SchemaName = "opportunity_account", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "0A20B4FD-AF4B-4832-8553-A2626F646FD6", SchemaName = "product_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "31B11CF3-27DC-4155-ABF3-AA8038326335", SchemaName = "quote_opportunity", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "50F4EF97-D245-40F2-BA98-B4A86D5ABE97", SchemaName = "user_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "AB5E9587-E176-444F-B76B-BA5CFD30622D", SchemaName = "account_contact", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "1C913AB0-0C8C-4796-8E93-BAB212AF8A7E", SchemaName = "contract_department", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "C3315E2A-1D4D-4A17-A368-C3BF21F9DD14", SchemaName = "opportunity_transactionCurrency", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "1AD637EF-8F7A-415C-9DFA-C9D95F100308", SchemaName = "project_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "A57EFE30-0937-4366-84A5-CA6F6E3935C3", SchemaName = "account_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9C08923A-AE7B-483C-A280-D14F0B4E0537", SchemaName = "user_department_DepartmentId", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "2011B65B-37C2-4F2E-8893-D4D4C95917E2", SchemaName = "contract_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "1DFD689C-AB82-456B-86C8-D840907264A5", SchemaName = "projectversion_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F3041F4F-141E-44D5-93D1-E692158909CE", SchemaName = "contact_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9EF6DDED-47F5-44FE-B4C0-E827EC2222C7", SchemaName = "contact_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "C0FC87E7-C9BE-4E85-8C2F-EA01DCFDC78D", SchemaName = "invoice_user", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "3FEC3EB2-7158-4798-8281-EAC85636277E", SchemaName = "projecttask_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "92A08F5D-0238-446E-A78A-EB8EB5F6D70A", SchemaName = "quote_customeraddress", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "C886D17C-2F6B-4D7B-8C77-EB96EA243397", SchemaName = "projectweekreport_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "1A3D4C02-BFAF-474B-B52A-F07526E02EB2", SchemaName = "quote_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9161828E-9045-4146-A4AE-F1C93C4F761F", SchemaName = "invoice_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "4EFFCCBC-C1A9-4FB8-9E5E-F3D62BA80ED5", SchemaName = "project_user_manager", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "7B30716E-1468-41EB-BBA5-F63E9342FB05", SchemaName = "invoice_account", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "B525C43C-7681-42D1-BBB6-F70EC0E415BF", SchemaName = "projectiteration_project_ProjectId", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "4B7DF0F3-9454-4C1C-B366-F724781ED0F9", SchemaName = "Attendance_user_createdBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "77BCACE5-318A-49B7-9D94-F902FF353327", SchemaName = "invoicecontract_association", EntityRelationshipType = 1, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "A9EBE59E-F238-4559-B6F6-F997AF8CC041", SchemaName = "quote_user_modifiedBy", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "8B55447B-D137-4406-BAD5-FC4E92D3CC7E", SchemaName = "projectiteration_projectversion_ProjectVersionId", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "D09CE529-5BDC-47B0-A86E-FCE9E534CD46", SchemaName = "contract_user", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
            Insert.IntoTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F7B7FB1C-ACFD-490D-9EB0-FEE48AF1109E", SchemaName = "projectweekreport_project_projectid", EntityRelationshipType = 0, IsCustomRelationship = 0, IsCustomizable = 0 });
        }
        public override void Down()
        {
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "AA404AAC-4DCF-42DE-AC88-02135FD6D896" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9EE920D4-C7DE-49C1-8D17-03D890004D7A" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "EBE71F6D-A843-4493-811C-042D35723C90" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "36650F25-E3F0-4C00-84CF-07009D910E1E" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "0A50C157-FEDE-436F-B979-07A7277F0014" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9F5DF63B-05E6-43DF-BBAB-07D4F378436C" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "443CD42A-071B-4A0D-AD76-0B0EFDEB554A" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "54CEE8AA-E738-4C8E-9390-0B20AB20247D" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "D129E6AA-3A7E-4AC4-B798-0B40C429D21F" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "3FDC8876-89CB-43DC-81A0-10E10BB0F23D" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "0857573B-C96D-40AE-BF13-149DC82D4571" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F3D96130-300D-4433-8ED1-1A963FF6C0F2" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9597AB74-C0F1-410D-AD92-22B3F0F35D9D" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "90610E43-989D-45A9-AD01-285F6A813AC6" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "47E165C9-93E9-488B-9450-2A141FE1D3F5" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "8040943D-3BDD-4A15-BDB9-2DDA40BFEE52" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "42DA677C-9A6C-4AEC-988A-310E8DCCD0F7" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "B22B0E84-BFCB-4B18-8557-32BB94661F0A" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "A8D873D0-FF8F-4657-85EB-33B26AD83447" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "4833DC03-E3DC-496C-AC0B-3654971D37E8" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "E43B3DBE-58B2-414F-85E5-394D73EA8623" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "303A6630-D065-4B38-93D9-39D1E55DC07E" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F71DA70D-C805-4725-82BF-3B2089E2F63D" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "97ABC5A2-5364-4F11-85EE-3CD8724772E6" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F251825D-15C4-4D94-93E7-44EA826D0EB9" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "492805A5-C360-4579-9CAC-45DC9BC3D7CB" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F56769CF-BB15-433C-B912-47125E00BAA2" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "BE5C1988-8061-44CC-BEF4-4A0640171319" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "0CC8740F-26DE-4B59-A6E7-50B4F782E1FF" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "CB7BA63C-4CCE-453E-8D74-515F1DC63806" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "E4918557-C891-45DE-B5E2-5217B083359B" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "56074DB4-8A35-4F75-8139-525E7EFB0F52" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "47DD6F0B-61AF-49FE-A618-5316B65F40CC" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "4F7C3910-BB7C-4299-8A2B-5545EBFBC4BE" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "AA812180-5DB3-4E78-9CA6-5A0D5431BA24" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "D6B971E8-0774-442E-9D41-61F0057B40CF" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "76FD764A-30E5-4519-A5A9-6A85F3EDFE67" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "27386265-4F45-4E5F-A4B3-6C7B0B2A7E4E" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "06C91B63-33EA-443C-814F-6EF15F5017E8" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "E6D202DF-12AC-4B6B-8E48-6FCBA1A13921" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "B9E6B3C7-F5A9-4C2A-BF72-709E59C8DCFA" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "C83037B9-872B-4145-9361-7293AAF25AF5" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "DA02C618-896D-4D56-9BD4-73177823FD34" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "D21A0494-387F-48EA-BABC-7C78F26CC149" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "37C4D625-5E25-4014-97E7-7D6D8C2D323F" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "88DDB10D-30EA-4BEA-BC27-7EBFC42A829F" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F79F1E65-4D5F-46C3-B77B-85FED2554111" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "405485A3-5439-415B-BBB9-8851CF974F8F" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "B6A06992-3948-4AA0-A578-892D7F957CB8" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "8DE6FFB6-53EB-4FF2-AE32-8E8B20EF371A" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9C64A996-93E1-44BF-8E90-9587F65B89FF" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "CDF0249F-4B87-4FBC-9064-A00229A1056F" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "0A20B4FD-AF4B-4832-8553-A2626F646FD6" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "31B11CF3-27DC-4155-ABF3-AA8038326335" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "50F4EF97-D245-40F2-BA98-B4A86D5ABE97" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "AB5E9587-E176-444F-B76B-BA5CFD30622D" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "1C913AB0-0C8C-4796-8E93-BAB212AF8A7E" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "C3315E2A-1D4D-4A17-A368-C3BF21F9DD14" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "1AD637EF-8F7A-415C-9DFA-C9D95F100308" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "A57EFE30-0937-4366-84A5-CA6F6E3935C3" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9C08923A-AE7B-483C-A280-D14F0B4E0537" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "2011B65B-37C2-4F2E-8893-D4D4C95917E2" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "1DFD689C-AB82-456B-86C8-D840907264A5" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F3041F4F-141E-44D5-93D1-E692158909CE" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9EF6DDED-47F5-44FE-B4C0-E827EC2222C7" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "C0FC87E7-C9BE-4E85-8C2F-EA01DCFDC78D" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "3FEC3EB2-7158-4798-8281-EAC85636277E" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "92A08F5D-0238-446E-A78A-EB8EB5F6D70A" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "C886D17C-2F6B-4D7B-8C77-EB96EA243397" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "1A3D4C02-BFAF-474B-B52A-F07526E02EB2" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "9161828E-9045-4146-A4AE-F1C93C4F761F" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "4EFFCCBC-C1A9-4FB8-9E5E-F3D62BA80ED5" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "7B30716E-1468-41EB-BBA5-F63E9342FB05" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "B525C43C-7681-42D1-BBB6-F70EC0E415BF" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "4B7DF0F3-9454-4C1C-B366-F724781ED0F9" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "77BCACE5-318A-49B7-9D94-F902FF353327" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "A9EBE59E-F238-4559-B6F6-F997AF8CC041" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "8B55447B-D137-4406-BAD5-FC4E92D3CC7E" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "D09CE529-5BDC-47B0-A86E-FCE9E534CD46" });
            Delete.FromTable("Metadata_EntityRelationship").Row(new { EntityRelationshipId = "F7B7FB1C-ACFD-490D-9EB0-FEE48AF1109E" });
        }
    }
}