using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121009051836)]
    public class _20121009051836_InitMetadataEntityTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "BB185E89-9E91-49A6-B450-0979AB6B8C9B", Name = "Department", PhysicalName = "Department", LogicalName = "department", TableName = "Department", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "F4987522-469B-4EED-AE0B-0C202EF89431", Name = "QuoteLineItem", PhysicalName = "QuoteLineItem", LogicalName = "quotelineitem", TableName = "QuoteLineItem", IsAuditEnabled = 1 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "DF0895A9-AE60-40A5-B6FF-190C5C91D045", Name = "Role", PhysicalName = "Role", LogicalName = "role", TableName = "Role", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "4AA7B81C-B70D-4BCB-95D6-2AB3AF0CBBB7", Name = "Audit", PhysicalName = "Audit", LogicalName = "audit", TableName = "Audit", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "6E8642FB-FB19-44B2-99B1-36B21DCC21E2", Name = "Contract", PhysicalName = "Contract", LogicalName = "contract", TableName = "Contract", IsAuditEnabled = 1 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "F04176E7-E941-4800-A83E-463C4B8831BF", Name = "Account", PhysicalName = "Account", LogicalName = "account", TableName = "Account", IsAuditEnabled = 1 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "4D712638-B776-463A-9D62-4981C0A954C6", Name = "SystemSetting", PhysicalName = "SystemSetting", LogicalName = "systemsetting", TableName = "SystemSetting", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "F32DF9E2-40DC-4DCF-9B47-4D2F5E251D56", Name = "Product", PhysicalName = "Product", LogicalName = "product", TableName = "Product", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "1163B3E2-9293-4185-BAFE-53BDBB20725C", Name = "ProjectIteration", PhysicalName = "ProjectIteration", LogicalName = "projectiteration", TableName = "ProjectIteration", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "92BB86D2-0087-4542-AFB1-59B35506C95F", Name = "NotificationRecipient", PhysicalName = "NotificationRecipient", LogicalName = "notificationrecipient", TableName = "NotificationRecipient", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "8CCE9A0F-856F-42D4-8023-65A2E85AE1DD", Name = "ProjectMember", PhysicalName = "ProjectMember", LogicalName = "projectmember", TableName = "ProjectMember", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "27628829-20C3-48A2-A488-676C0DF9FDBE", Name = "Notification", PhysicalName = "Notification", LogicalName = "notification", TableName = "Notification", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "5351FC5D-AF9A-4A4A-B900-6EC3C5B2258E", Name = "PrivilegeEntity", PhysicalName = "PrivilegeEntity", LogicalName = "privilegeentity", TableName = "PrivilegeEntity", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "96F6A424-859B-4520-AAA6-7FBE4C6A33A4", Name = "RolePrivilege", PhysicalName = "RolePrivilege", LogicalName = "roleprivilege", TableName = "RolePrivilege", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "4124D7F6-0673-4A6C-BA52-8713254264EB", Name = "User", PhysicalName = "User", LogicalName = "user", TableName = "User", IsAuditEnabled = 1 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "8C06FC35-C27D-4C4D-BC96-8F1BD15A480C", Name = "Lead", PhysicalName = "Lead", LogicalName = "lead", TableName = "Lead", IsAuditEnabled = 1 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "80E79E18-0F0B-4D28-ABE9-92BF875BA426", Name = "Opportunity", PhysicalName = "Opportunity", LogicalName = "opportunity", TableName = "Opportunity", IsAuditEnabled = 1 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "3B96362A-A7B1-4898-8A6A-9B400041BFA6", Name = "ProjectTask", PhysicalName = "ProjectTask", LogicalName = "projecttask", TableName = "ProjectTask", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "4131651A-C217-4D44-9EF5-A0947B5A3749", Name = "Project", PhysicalName = "Project", LogicalName = "project", TableName = "Project", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "FCA2446B-C739-4AAA-BF63-A23C9147FDCA", Name = "Quote", PhysicalName = "Quote", LogicalName = "quote", TableName = "Quote", IsAuditEnabled = 1 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "C6084586-4A6A-4C4E-BA13-A52AFDBBB5C2", Name = "ProjectWeekReport", PhysicalName = "ProjectWeekReport", LogicalName = "projectweekreport", TableName = "ProjectWeekReport", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "DAE981F9-AD1F-4D94-A6C2-AC131DEE5AE2", Name = "Note", PhysicalName = "Note", LogicalName = "note", TableName = "Note", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "715D12E8-9DDB-4D0D-9282-AE30C7C77AA7", Name = "InvoiceContract", PhysicalName = "InvoiceContract", LogicalName = "invoicecontract", TableName = "InvoiceContract", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "924AAB33-6127-4AC2-A001-B46A95A4A6AB", Name = "ProjectVersion", PhysicalName = "ProjectVersion", LogicalName = "projectversion", TableName = "ProjectVersion", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "A2224E4A-DB2B-479D-9CE5-B67500201249", Name = "Invoice", PhysicalName = "Invoice", LogicalName = "invoice", TableName = "Invoice", IsAuditEnabled = 1 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "4CA58595-32F5-42CA-8EA1-BEEC39E2109E", Name = "TimeTracking", PhysicalName = "TimeTracking", LogicalName = "timetracking", TableName = "TimeTracking", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "52A1E467-20B4-42D9-BF2F-C71EE4AF7232", Name = "TaskTimeHistory", PhysicalName = "TaskTimeHistory", LogicalName = "tasktimehistory", TableName = "TaskTimeHistory", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "44FA4628-A7FD-422D-A26B-D866BF5682D4", Name = "Privilege", PhysicalName = "Privilege", LogicalName = "privilege", TableName = "Privilege", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "8BDAA9A2-787D-408A-8F53-E10684634B22", Name = "Contact", PhysicalName = "Contact", LogicalName = "contact", TableName = "Contact", IsAuditEnabled = 1 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "FF5F6CA0-6647-4589-8AE9-EC8AFB2F76F9", Name = "CustomerAddress", PhysicalName = "CustomerAddress", LogicalName = "customeraddress", TableName = "CustomerAddress", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "26B07909-A057-4961-B349-F0FDCE041964", Name = "UserRole", PhysicalName = "UserRole", LogicalName = "userrole", TableName = "UserRole", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "1398A24A-27F4-4733-A8E7-F8CE2BFCC320", Name = "Attendance", PhysicalName = "Attendance", LogicalName = "attendance", TableName = "Attendance", IsAuditEnabled = 0 });
            Insert.IntoTable("Metadata_Entity").Row(new { EntityId = "77000EA8-3A5D-439E-A466-FF2B8D302C6C", Name = "TransactionCurrency", PhysicalName = "TransactionCurrency", LogicalName = "transactioncurrency", TableName = "TransactionCurrency", IsAuditEnabled = 0 });
        }

        public override void Down()
        {
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "BB185E89-9E91-49A6-B450-0979AB6B8C9B" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "F4987522-469B-4EED-AE0B-0C202EF89431" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "DF0895A9-AE60-40A5-B6FF-190C5C91D045" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "4AA7B81C-B70D-4BCB-95D6-2AB3AF0CBBB7" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "6E8642FB-FB19-44B2-99B1-36B21DCC21E2" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "F04176E7-E941-4800-A83E-463C4B8831BF" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "4D712638-B776-463A-9D62-4981C0A954C6" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "F32DF9E2-40DC-4DCF-9B47-4D2F5E251D56" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "1163B3E2-9293-4185-BAFE-53BDBB20725C" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "92BB86D2-0087-4542-AFB1-59B35506C95F" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "8CCE9A0F-856F-42D4-8023-65A2E85AE1DD" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "27628829-20C3-48A2-A488-676C0DF9FDBE" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "5351FC5D-AF9A-4A4A-B900-6EC3C5B2258E" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "96F6A424-859B-4520-AAA6-7FBE4C6A33A4" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "4124D7F6-0673-4A6C-BA52-8713254264EB" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "8C06FC35-C27D-4C4D-BC96-8F1BD15A480C" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "80E79E18-0F0B-4D28-ABE9-92BF875BA426" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "3B96362A-A7B1-4898-8A6A-9B400041BFA6" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "4131651A-C217-4D44-9EF5-A0947B5A3749" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "FCA2446B-C739-4AAA-BF63-A23C9147FDCA" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "C6084586-4A6A-4C4E-BA13-A52AFDBBB5C2" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "DAE981F9-AD1F-4D94-A6C2-AC131DEE5AE2" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "715D12E8-9DDB-4D0D-9282-AE30C7C77AA7" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "924AAB33-6127-4AC2-A001-B46A95A4A6AB" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "A2224E4A-DB2B-479D-9CE5-B67500201249" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "4CA58595-32F5-42CA-8EA1-BEEC39E2109E" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "52A1E467-20B4-42D9-BF2F-C71EE4AF7232" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "44FA4628-A7FD-422D-A26B-D866BF5682D4" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "8BDAA9A2-787D-408A-8F53-E10684634B22" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "FF5F6CA0-6647-4589-8AE9-EC8AFB2F76F9" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "26B07909-A057-4961-B349-F0FDCE041964" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "1398A24A-27F4-4733-A8E7-F8CE2BFCC320" });
            Delete.FromTable("Metadata_Entity").Row(new { EntityId = "77000EA8-3A5D-439E-A466-FF2B8D302C6C" });
        }
    }
}


