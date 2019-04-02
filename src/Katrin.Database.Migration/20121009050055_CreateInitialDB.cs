using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121009050055)]
    public class _20121009050055_CreateInitialDB : Migration
    {
        public override void Up()
        {
            //For ImportEntityMapping
            Create.Table("ImportEntityMapping").InSchema("dbo")
                .WithColumn("ImportEntityMappingId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("SourceEntityName").AsString(160).Nullable()
                .WithColumn("TargetEntityName").AsString(160).Nullable()
                .WithColumn("ImportMapId").AsGuid().Nullable()
            ;
            //For CustomerAddress
            Create.Table("CustomerAddress").InSchema("dbo")
                .WithColumn("CustomerAddressId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("ParentId").AsGuid().Nullable()
                .WithColumn("AddressTypeCode").AsInt32().Nullable()
                .WithColumn("Name").AsString(200).Nullable()
                .WithColumn("PrimaryContactName").AsString(150).Nullable()
                .WithColumn("Line1").AsMaxString().Nullable()
                .WithColumn("Line2").AsMaxString().Nullable()
                .WithColumn("Line3").AsMaxString().Nullable()
                .WithColumn("City").AsMaxString().Nullable()
                .WithColumn("StateOrProvince").AsMaxString().Nullable()
                .WithColumn("County").AsMaxString().Nullable()
                .WithColumn("Country").AsMaxString().Nullable()
                .WithColumn("PostOfficeBox").AsString(50).Nullable()
                .WithColumn("PostalCode").AsString(50).Nullable()
                .WithColumn("Latitude").AsDouble().Nullable()
                .WithColumn("Longitude").AsDouble().Nullable()
                .WithColumn("Fax").AsString(50).Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
            ;
            //For Department
            Create.Table("Department").InSchema("dbo")
                .WithColumn("DepartmentId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(50).Nullable()
            ;
            //For PickListMapping
            Create.Table("PickListMapping").InSchema("dbo")
                .WithColumn("PickListMappingId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("ColumnMappingId").AsGuid().Nullable()
                .WithColumn("TargetValue").AsInt32().Nullable()
                .WithColumn("SourceValue").AsMaxString().Nullable()
            ;
            //For Invoice
            Create.Table("Invoice").InSchema("dbo")
                .WithColumn("InvoiceId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("InvoiceNumber").AsString(100).NotNullable()
                .WithColumn("Name").AsString(300).Nullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("TotalAmount").AsMoney().Nullable()
                .WithColumn("PaidAmount").AsMoney().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("StatusCode").AsInt32().NotNullable()
                .WithColumn("DateDelivered").AsDateTime().Nullable()
                .WithColumn("ReceivedDate").AsDateTime().Nullable()
                .WithColumn("TransactionCurrencyId").AsGuid().Nullable()
                .WithColumn("ExchangeRate").AsDecimal(23,10).Nullable()
                .WithColumn("OwnerId").AsGuid().NotNullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("BillingCustomerId").AsGuid().Nullable()
            ;
            //For ColumnMapping
            Create.Table("ColumnMapping").InSchema("dbo")
                .WithColumn("ColumnMappingId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("SourceEntityName").AsString(160).Nullable()
                .WithColumn("SourceAttributeName").AsString(160).Nullable()
                .WithColumn("TargetEntityName").AsString(160).Nullable()
                .WithColumn("TargetAttributeName").AsString(160).Nullable()
                .WithColumn("ImportMapId").AsGuid().Nullable()
            ;
            //For InvoiceContract
            Create.Table("InvoiceContract").InSchema("dbo")
                .WithColumn("InvoiceContractId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("InvoiceId").AsGuid().NotNullable()
                .WithColumn("ContractId").AsGuid().NotNullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
            ;
            //For Lead
            Create.Table("Lead").InSchema("dbo")
                .WithColumn("LeadId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("LeadSourceCode").AsInt32().Nullable()
                .WithColumn("PriorityCode").AsInt32().Nullable()
                .WithColumn("Subject").AsString(300).Nullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("CompanyName").AsString(100).Nullable()
                .WithColumn("FirstName").AsString(50).Nullable()
                .WithColumn("MiddleName").AsString(50).Nullable()
                .WithColumn("LastName").AsString(50).Nullable()
                .WithColumn("Revenue").AsMoney().Nullable()
                .WithColumn("NumberOfEmployees").AsString(10).Nullable()
                .WithColumn("EmailAddress").AsString(100).Nullable()
                .WithColumn("FullName").AsString(160).Nullable()
                .WithColumn("WebSiteUrl").AsString(200).Nullable()
                .WithColumn("MobilePhone").AsString(50).Nullable()
                .WithColumn("Telephone1").AsString(50).Nullable()
                .WithColumn("Telephone2").AsString(50).Nullable()
                .WithColumn("Fax").AsString(50).Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("StatusCode").AsInt32().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("CustomerId").AsGuid().Nullable()
                .WithColumn("OwnerId").AsGuid().Nullable()
                .WithColumn("Country").AsString(100).Nullable()
                .WithColumn("City").AsString(100).Nullable()
                .WithColumn("Address").AsString(100).Nullable()
                .WithColumn("ZIP").AsString(50).Nullable()
                .WithColumn("DepartmentId").AsGuid().Nullable()
                .WithColumn("OriginalMessage").AsString(200).Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("CountryCode").AsInt32().Nullable()
                .WithColumn("TechnologyCode").AsInt32().Nullable()
            ;
            //For LookupMapping
            Create.Table("LookupMapping").InSchema("dbo")
                .WithColumn("LookupMappingId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("ColumnMappingId").AsGuid().Nullable()
                .WithColumn("LookupEntityName").AsString(160).Nullable()
                .WithColumn("ValueAttributeName").AsString(160).Nullable()
                .WithColumn("LookupAttributeName").AsString(160).Nullable()
            ;
            //For Metadata_AttributeLookupValue
            Create.Table("Metadata_AttributeLookupValue").InSchema("dbo")
                .WithColumn("AttributeLookupValueId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("AttributeId").AsGuid().NotNullable()
                .WithColumn("EntityId").AsGuid().NotNullable()
                .WithColumn("DisplayEntityAttributeId").AsGuid().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").NotNullable()
            ;
            //For Metadata_AttributePicklistValue
            Create.Table("Metadata_AttributePicklistValue").InSchema("dbo")
                .WithColumn("AttributePicklistValueId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Value").AsInt32().Nullable()
                .WithColumn("DisplayOrder").AsInt32().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").NotNullable()
                .WithColumn("OptionSetId").AsGuid().NotNullable()
            ;
            //For Metadata_AttributePicklistValueMap
            Create.Table("Metadata_AttributePicklistValueMap").InSchema("dbo")
                .WithColumn("AttributePicklistValueId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("MapToValueId").AsGuid().NotNullable()
                .WithColumn("IsDefault").AsBoolean().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
            ;
            //For Metadata_AttributeType
            Create.Table("Metadata_AttributeType").InSchema("dbo")
                .WithColumn("AttributeTypeId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
            ;
            //For Metadata_Entity
            Create.Table("Metadata_Entity").InSchema("dbo")
                .WithColumn("EntityId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(64).Nullable()
                .WithColumn("PhysicalName").AsString(64).Nullable()
                .WithColumn("LogicalName").AsString(64).Nullable()
                .WithColumn("TableName").AsString(64).Nullable()
                .WithColumn("IsAuditEnabled").AsBoolean().NotNullable()
            ;
            //For Project
            Create.Table("Project").InSchema("dbo")
                .WithColumn("ProjectId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(500).NotNullable()
                .WithColumn("Contact").AsString(500).Nullable()
                .WithColumn("SaleServiceId").AsGuid().Nullable()
                .WithColumn("Objective").AsMaxString().Nullable()
                .WithColumn("PlannedStartDate").AsDateTime().Nullable()
                .WithColumn("PlannedEndDate").AsDateTime().Nullable()
                .WithColumn("PlannedProgress").AsInt32().Nullable()
                .WithColumn("EstimatedEndDate").AsDateTime().Nullable()
                .WithColumn("ActualStartDate").AsDateTime().Nullable()
                .WithColumn("ActualEndDate").AsDateTime().Nullable()
                .WithColumn("ActualProgress").AsInt32().Nullable()
                .WithColumn("ManagerId").AsGuid().Nullable()
                .WithColumn("StatusCode").AsInt32().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable()
                .WithColumn("ContractId").AsGuid().Nullable()
                .WithColumn("LatestFeadbackOn").AsDateTime().Nullable()
                .WithColumn("CustomerId").AsGuid().Nullable()
                .WithColumn("ProjectTypeCode").AsInt32().Nullable()
                .WithColumn("TechnologyCode").AsInt32().Nullable()
                .WithColumn("ProbabilityCode").AsInt32().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
            ;
            //For Metadata_LocalizedLabel
            Create.Table("Metadata_LocalizedLabel").InSchema("dbo")
                .WithColumn("LocalizedLabelId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("LanguageId").AsInt32().NotNullable()
                .WithColumn("ObjectId").AsGuid().NotNullable()
                .WithColumn("ObjectColumnName").AsString(128).NotNullable()
                .WithColumn("Label").AsMaxString().NotNullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").NotNullable()
            ;
            //For Metadata_OptionSet
            Create.Table("Metadata_OptionSet").InSchema("dbo")
                .WithColumn("OptionSetId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("IsCustomizable").AsBoolean().NotNullable()
            ;
            //For Product
            Create.Table("Product").InSchema("dbo")
                .WithColumn("ProductId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(100).Nullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("ProductTypeCode").AsInt32().Nullable()
                .WithColumn("ProductUrl").AsString(255).Nullable()
                .WithColumn("Price").AsMoney().Nullable()
                .WithColumn("ProductNumber").AsString(100).NotNullable()
                .WithColumn("CurrentCost").AsMoney().Nullable()
                .WithColumn("StandardCost").AsMoney().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("StatusCode").AsInt32().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("TransactionCurrencyId").AsGuid().Nullable()
                .WithColumn("ExchangeRate").AsDecimal(23,10).Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
            ;
            //For AttentionInfomation
            Create.Table("AttentionInfomation").InSchema("dbo")
                .WithColumn("AttentionInfoId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("ObjectId").AsGuid().Nullable()
                .WithColumn("ObjectType").AsString(200).Nullable()
                .WithColumn("Subject").AsString(200).Nullable()
                .WithColumn("Content").AsString(1000).Nullable()
                .WithColumn("AttentionUrl").AsString(200).Nullable()
                .WithColumn("AboutAttributeId").AsGuid().Nullable()
                .WithColumn("AboutUrl").AsString(200).Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
            ;
            //For Contract
            Create.Table("Contract").InSchema("dbo")
                .WithColumn("ContractId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("ContractNumber").AsString(100).Nullable()
                .WithColumn("ActiveOn").AsDateTime().Nullable()
                .WithColumn("ExpiresOn").AsDateTime().Nullable()
                .WithColumn("CancelOn").AsDateTime().Nullable()
                .WithColumn("Title").AsString(100).Nullable()
                .WithColumn("BillingEndOn").AsDateTime().Nullable()
                .WithColumn("BillingStartOn").AsDateTime().Nullable()
                .WithColumn("BillingFrequencyCode").AsInt32().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("TotalPrice").AsMoney().Nullable()
                .WithColumn("StatusCode").AsInt32().Nullable()
                .WithColumn("TransactionCurrencyId").AsGuid().Nullable()
                .WithColumn("ExchangeRate").AsDecimal(23,10).Nullable()
                .WithColumn("OwnerId").AsGuid().NotNullable()
                .WithColumn("BillingCustomerId").AsGuid().Nullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("OpportunityId").AsGuid().Nullable()
                .WithColumn("DepartmentId").AsGuid().Nullable()
                .WithColumn("CustomerSignedOn").AsDateTime().Nullable()
                .WithColumn("CompanySignedOn").AsDateTime().Nullable()
                .WithColumn("CustomerSatisfactionCode").AsInt32().Nullable()
                .WithColumn("EndTypeCode").AsInt32().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
            ;
            //For Quote
            Create.Table("Quote").InSchema("dbo")
                .WithColumn("QuoteId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(300).Nullable()
                .WithColumn("OpportunityId").AsGuid().Nullable()
                .WithColumn("QuoteNumber").AsString(100).Nullable()
                .WithColumn("StageCode").AsInt32().Nullable()
                .WithColumn("OwnerId").AsGuid().Nullable()
                .WithColumn("ExpiresOn").AsDateTime().Nullable()
                .WithColumn("PaymentTermsCode").AsInt32().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("StatusCode").AsInt32().Nullable()
                .WithColumn("CustomerId").AsGuid().Nullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("TotalAmount").AsMoney().Nullable()
                .WithColumn("TotalTax").AsMoney().Nullable()
                .WithColumn("TotalDiscountAmount").AsMoney().Nullable()
                .WithColumn("TotalLineItemAmount").AsMoney().Nullable()
                .WithColumn("TransactionCurrencyId").AsGuid().Nullable()
                .WithColumn("ExchangeRate").AsDecimal(23,10).Nullable()
                .WithColumn("BillTo_AddressId").AsGuid().Nullable()
                .WithColumn("BillTo_ContactName").AsString(150).Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
            ;
            //For AttentionMember
            Create.Table("AttentionMember").InSchema("dbo")
                .WithColumn("AttentionMemberId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("AttentionInfoId").AsGuid().Nullable()
                .WithColumn("AttentionUserId").AsGuid().Nullable()
                .WithColumn("AttentionStatus").AsString(50).Nullable()
                .WithColumn("ReadedOn").AsDateTime().Nullable()
            ;
            //For QuoteLineItem
            Create.Table("QuoteLineItem").InSchema("dbo")
                .WithColumn("QuoteLineItemId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("QuoteId").AsGuid().Nullable()
                .WithColumn("Quantity").AsDecimal(23,10).Nullable()
                .WithColumn("ProductId").AsGuid().Nullable()
                .WithColumn("UnitPrice").AsMoney().Nullable()
                .WithColumn("TotalPrice").AsMoney().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
            ;
            //For Metadata_AttentionConfig
            Create.Table("Metadata_AttentionConfig").InSchema("dbo")
                .WithColumn("AttentionConfigId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("AttentionEntityId").AsGuid().NotNullable()
                .WithColumn("AboutAttributeId").AsGuid().Nullable()
                .WithColumn("AboutEntityId").AsGuid().Nullable()
                .WithColumn("AttentionDisplayName").AsString(100).Nullable()
                .WithColumn("AboutDisplayName").AsString(100).Nullable()
                .WithColumn("AttentionUrl").AsString(200).Nullable()
                .WithColumn("AboutUrl").AsString(200).Nullable()
                .WithColumn("IsSys").AsBoolean().Nullable()
            ;
            //For Metadata_Attribute
            Create.Table("Metadata_Attribute").InSchema("dbo")
                .WithColumn("AttributeId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("AttributeTypeId").AsGuid().Nullable()
                .WithColumn("LogicalType").AsString(50).Nullable()
                .WithColumn("Name").AsString(50).Nullable()
                .WithColumn("PhysicalName").AsString(50).Nullable()
                .WithColumn("Length").AsInt32().Nullable()
                .WithColumn("IsNullable").AsBoolean().Nullable()
                .WithColumn("EntityId").AsGuid().NotNullable()
                .WithColumn("DefaultValue").AsString(100).Nullable()
                .WithColumn("ColumnNumber").AsInt32().NotNullable()
                .WithColumn("LogicalName").AsString(50).NotNullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").NotNullable()
                .WithColumn("MaxLength").AsInt32().Nullable()
                .WithColumn("MinValue").AsDouble().Nullable()
                .WithColumn("MaxValue").AsDouble().Nullable()
                .WithColumn("IsAuditEnabled").AsBoolean().NotNullable()
                .WithColumn("TableColumnName").AsString(50).Nullable()
                .WithColumn("OptionSetId").AsGuid().Nullable()
                .WithColumn("AppDefaultValue").AsInt32().Nullable()
                .WithColumn("IsPKAttribute").AsBoolean().Nullable()
                .WithColumn("IsCopyEnabled").AsBoolean().Nullable()
            ;
            //For TransactionCurrency
            Create.Table("TransactionCurrency").InSchema("dbo")
                .WithColumn("TransactionCurrencyId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("CurrencySymbol").AsString(5).NotNullable()
                .WithColumn("CurrencyName").AsString(100).NotNullable()
                .WithColumn("CurrencyPrecision").AsInt32().NotNullable()
                .WithColumn("ExchangeRate").AsDecimal(23,10).Nullable()
                .WithColumn("StatusCode").AsInt32().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
            ;
            //For Metadata_AttentionMemberConfig
            Create.Table("Metadata_AttentionMemberConfig").InSchema("dbo")
                .WithColumn("AttentionMemberId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("MemberEntityId").AsGuid().Nullable()
                .WithColumn("MemberAttributeId").AsGuid().Nullable()
                .WithColumn("AttentionConfigId").AsGuid().Nullable()
            ;
            //For Metadata_FilterConditionDetail
            Create.Table("Metadata_FilterConditionDetail").InSchema("dbo")
                .WithColumn("FilterConditionDetailId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("FilterConditionId").AsGuid().NotNullable()
                .WithColumn("ParentDetailId").AsGuid().NotNullable()
                .WithColumn("Operator").AsString(100).Nullable()
                .WithColumn("OperatorType").AsString(100).Nullable()
                .WithColumn("CompareAttributeId").AsGuid().Nullable()
                .WithColumn("CompareValue").AsString(100).Nullable()
            ;
            //For ProjectMember
            Create.Table("ProjectMember").InSchema("dbo")
                .WithColumn("ProjectMemberId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("ProjectId").AsGuid().NotNullable()
                .WithColumn("MemberId").AsGuid().NotNullable()
            ;
            //For Metadata_FilterConditon
            Create.Table("Metadata_FilterConditon").InSchema("dbo")
                .WithColumn("FilterConditionId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("FilterObjectId").AsGuid().NotNullable()
                .WithColumn("FilterConditionText").AsString(200).Nullable()
            ;
            //For User
            Create.Table("User").InSchema("dbo")
                .WithColumn("UserId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("DepartmentId").AsGuid().Nullable()
                .WithColumn("UserName").AsString(50).NotNullable()
                .WithColumn("Password").AsString(128).Nullable()
                .WithColumn("PasswordSalt").AsString(128).Nullable()
                .WithColumn("FirstName").AsString(50).Nullable()
                .WithColumn("MiddleName").AsString(50).Nullable()
                .WithColumn("LastName").AsString(50).Nullable()
                .WithColumn("FullName").AsString(50).Nullable()
                .WithColumn("NickName").AsString(50).Nullable()
                .WithColumn("Title").AsString(100).Nullable()
                .WithColumn("EmailAddress").AsString(100).Nullable()
                .WithColumn("HomePhone").AsString(50).Nullable()
                .WithColumn("MobilePhone").AsString(50).Nullable()
                .WithColumn("IsDisabled").AsBoolean().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("ParentUserId").AsGuid().Nullable()
                .WithColumn("UserType").AsInt32().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("NativePlace").AsString(100).Nullable()
                .WithColumn("EntryDate").AsDateTime().Nullable()
                .WithColumn("GraduatedCollege").AsString(100).Nullable()
                .WithColumn("EnglishCommunication").AsString(50).Nullable()
                .WithColumn("EnglishLevel").AsString(50).Nullable()
                .WithColumn("TechnicalExpertise").AsString(50).Nullable()
                .WithColumn("BirthDate").AsDateTime().Nullable()
                .WithColumn("MSN").AsString(50).Nullable()
                .WithColumn("QQ").AsString(50).Nullable()
                .WithColumn("Hobby").AsString(100).Nullable()
                .WithColumn("WorkExperience").AsString(50).Nullable()
                .WithColumn("JobLevelCode").AsInt32().Nullable()
                .WithColumn("LastPromotionDate").AsDateTime().Nullable()
            ;
            Create.Index("IX_UserName").OnTable("User").InSchema("dbo").OnColumn("UserName").Ascending().WithOptions().Unique()
            ;

            //For Attendance
            Create.Table("Attendance").InSchema("dbo")
                .WithColumn("AttendanceId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("RecordPersonId").AsGuid().Nullable()
                .WithColumn("RecordOn").AsDateTime().Nullable()
                .WithColumn("AttendanceTypeCode").AsInt32().Nullable()
                .WithColumn("AttendanceLength").AsInt32().Nullable()
                .WithColumn("AttendanceUnitCode").AsInt32().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("Description").AsMaxString().Nullable()
            ;
            //For Metadata_EntityRelationship
            Create.Table("Metadata_EntityRelationship").InSchema("dbo")
                .WithColumn("EntityRelationshipId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("SchemaName").AsString(255).Nullable()
                .WithColumn("EntityRelationshipType").AsTINYINT().NotNullable()
                .WithColumn("IsCustomRelationship").AsBoolean().NotNullable()
                .WithColumn("IsCustomizable").AsBoolean().NotNullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
            ;
            //For Metadata_EntityRelationshipRole
            Create.Table("Metadata_EntityRelationshipRole").InSchema("dbo")
                .WithColumn("EntityRelationshipRoleId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("EntityRelationshipId").AsGuid().NotNullable()
                .WithColumn("EntityId").AsGuid().NotNullable()
                .WithColumn("RelationshipRoleType").AsTINYINT().NotNullable()
                .WithColumn("NavPanelDisplayOption").AsTINYINT().Nullable()
                .WithColumn("NavPaneOrder").AsInt32().Nullable()
            ;
            //For Role
            Create.Table("Role").InSchema("dbo")
                .WithColumn("RoleId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("RoleName").AsString(100).Nullable()
                .WithColumn("Description").AsString(500).Nullable()
            ;
            //For UserRole
            Create.Table("UserRole").InSchema("dbo")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("UserId").AsGuid().Nullable()
                .WithColumn("RoleId").AsGuid().Nullable()
            ;
            
            //For Privilege
            Create.Table("Privilege").InSchema("dbo")
                .WithColumn("PrivilegeId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(50).Nullable()
                .WithColumn("AccessRight").AsInt32().Nullable()
            ;
            //For ProjectTask
            Create.Table("ProjectTask").InSchema("dbo")
                .WithColumn("TaskId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(500).NotNullable()
                .WithColumn("ProjectId").AsGuid().NotNullable()
                .WithColumn("ProjectIterationId").AsGuid().Nullable()
                .WithColumn("StatusCode").AsInt32().Nullable()
                .WithColumn("StartDate").AsDateTime().Nullable()
                .WithColumn("EndDate").AsDateTime().Nullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("QuoteWorkHours").AsDouble().Nullable()
                .WithColumn("ActualWorkHours").AsDouble().Nullable()
                .WithColumn("ActualInput").AsDouble().Nullable()
                .WithColumn("Effort").AsDouble().Nullable()
                .WithColumn("Overtime").AsDouble().Nullable()
                .WithColumn("EvaluateExactlyRate").AsDouble().Nullable()
                .WithColumn("InputEffortRate").AsDouble().Nullable()
                .WithColumn("RemainderTime").AsDouble().Nullable()
                .WithColumn("OwnerId").AsGuid().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("PriorityCode").AsInt32().Nullable()
            ;
            //For PrivilegeEntity
            Create.Table("PrivilegeEntity").InSchema("dbo")
                .WithColumn("PrivilegeEntityId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("PrivilegeId").AsGuid().NotNullable()
                .WithColumn("EntityName").AsString(20).NotNullable()
            ;
            //For RolePrivilege
            Create.Table("RolePrivilege").InSchema("dbo")
                .WithColumn("RolePrivilegeId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("RoleId").AsGuid().NotNullable()
                .WithColumn("PrivilegeId").AsGuid().NotNullable()
            ;
            //For Metadata_Relationship
            Create.Table("Metadata_Relationship").InSchema("dbo")
                .WithColumn("RelationshipId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(255).Nullable()
                .WithColumn("ReferencingEntityId").AsGuid().NotNullable()
                .WithColumn("ReferencingAttributeId").AsGuid().NotNullable()
                .WithColumn("ReferencedEntityId").AsGuid().NotNullable()
                .WithColumn("ReferencedAttributeId").AsGuid().NotNullable()
                .WithColumn("RelationshipType").AsInt32().Nullable()
                .WithColumn("CascadeDelete").AsTINYINT().NotNullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").NotNullable()
            ;
            //For SystemSetting
            Create.Table("SystemSetting").InSchema("dbo")
                .WithColumn("SystemSettingId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Value").AsMaxString().Nullable()
            ;
            //For ProjectIteration
            Create.Table("ProjectIteration").InSchema("dbo")
                .WithColumn("ProjectIterationId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("ProjectId").AsGuid().NotNullable()
                .WithColumn("Name").AsString(500).NotNullable()
                .WithColumn("Objective").AsMaxString().Nullable()
                .WithColumn("StartDate").AsDateTime().Nullable()
                .WithColumn("Deadline").AsDateTime().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("ProjectVersionId").AsGuid().Nullable()
            ;
            //For ProjectWeekReport
            Create.Table("ProjectWeekReport").InSchema("dbo")
                .WithColumn("ProjectWeekReportId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("ProjectId").AsGuid().NotNullable()
                .WithColumn("ProjectIterationId").AsGuid().NotNullable()
                .WithColumn("Name").AsString(500).NotNullable()
                .WithColumn("CurrentProgressCode").AsInt32().Nullable()
                .WithColumn("OutlookProgressCode").AsInt32().Nullable()
                .WithColumn("CriteriaProgress").AsMaxString().Nullable()
                .WithColumn("CurrentQualityCode").AsInt32().Nullable()
                .WithColumn("OutlookQualityCode").AsInt32().Nullable()
                .WithColumn("CriteriaQuality").AsMaxString().Nullable()
                .WithColumn("Suggestions").AsMaxString().Nullable()
                .WithColumn("Reviews").AsMaxString().Nullable()
                .WithColumn("RecordOn").AsDateTime().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
            ;
            //For SavedQuery
            Create.Table("SavedQuery").InSchema("dbo")
                .WithColumn("SavedQueryId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("QueryParentId").AsGuid().Nullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("QueryType").AsInt32().NotNullable()
                .WithColumn("IsDefault").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("ReturnedTypeId").AsGuid().NotNullable()
                .WithColumn("IsUserDefined").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("FetchXml").AsMaxString().Nullable()
                .WithColumn("IsCustomizable").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("IsQuickFindQuery").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("ColumnSetXml").AsMaxString().Nullable()
                .WithColumn("LayoutXml").AsMaxString().Nullable()
                .WithColumn("CreatedBy").AsGuid().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedBy").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("IsPrivate").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("AdvancedGroupBy").AsString(160).Nullable()
                .WithColumn("ConditionalFormatting").AsMaxString().Nullable()
                .WithColumn("CanBeDeleted").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("StatusCode").AsInt32().Nullable()
            ;
            //For TaskTimeHistory
            Create.Table("TaskTimeHistory").InSchema("dbo")
                .WithColumn("TaskTimeHistoryId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("TaskId").AsGuid().NotNullable()
                .WithColumn("StartTime").AsInt32().Nullable()
                .WithColumn("EndTime").AsInt32().Nullable()
                .WithColumn("ActualInput").AsDouble().Nullable()
                .WithColumn("Effort").AsDouble().Nullable()
                .WithColumn("Overtime").AsDouble().Nullable()
                .WithColumn("ActualProgress").AsDouble().Nullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("RecordOn").AsDateTime().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
            ;
            //For Metadata_EntityRelationshipRelationships
            Create.Table("Metadata_EntityRelationshipRelationships").InSchema("dbo")
                .WithColumn("EntityRelationshipRelationshipsId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("EntityRelationshipId").AsGuid().Nullable()
                .WithColumn("RelationshipId").AsGuid().NotNullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").NotNullable()
            ;
            //For Note
            Create.Table("Note").InSchema("dbo")
                .WithColumn("NoteId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Subject").AsString(500).Nullable()
                .WithColumn("NoteText").AsMaxString().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("ObjectType").AsString(64).Nullable()
                .WithColumn("ObjectId").AsGuid().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
            ;
            //For TimeTracking
            Create.Table("TimeTracking").InSchema("dbo")
                .WithColumn("TimeTrackingId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("TypeCode").AsInt32().Nullable()
                .WithColumn("Effort").AsDouble().Nullable()
                .WithColumn("RecordOn").AsDateTime().Nullable()
                .WithColumn("RecordById").AsGuid().Nullable()
                .WithColumn("OpportunityId").AsGuid().Nullable()
                .WithColumn("Description").AsString(500).Nullable()
            ;
            //For Account
            Create.Table("Account").InSchema("dbo")
                .WithColumn("AccountId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("AccountCategoryCode").AsInt32().Nullable()
                .WithColumn("CustomerSizeCode").AsInt32().Nullable()
                .WithColumn("CustomerTypeCode").AsInt32().Nullable()
                .WithColumn("AccountRatingCode").AsInt32().Nullable()
                .WithColumn("IndustryCode").AsInt32().Nullable()
                .WithColumn("AccountClassificationCode").AsInt32().Nullable()
                .WithColumn("BusinessTypeCode").AsInt32().Nullable()
                .WithColumn("PaymentTermsCode").AsInt32().Nullable()
                .WithColumn("OriginatingLeadId").AsGuid().Nullable()
                .WithColumn("PrimaryContactId").AsGuid().Nullable()
                .WithColumn("Name").AsString(160).Nullable()
                .WithColumn("AccountNumber").AsString(20).Nullable()
                .WithColumn("Revenue").AsMoney().Nullable()
                .WithColumn("NumberOfEmployees").AsInt32().Nullable()
                .WithColumn("Country").AsString(100).Nullable()
                .WithColumn("City").AsString(100).Nullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("SIC").AsString(20).Nullable()
                .WithColumn("TickerSymbol").AsString(10).Nullable()
                .WithColumn("OwnershipCode").AsInt32().Nullable()
                .WithColumn("WebSiteURL").AsString(200).Nullable()
                .WithColumn("EMailAddress1").AsString(100).Nullable()
                .WithColumn("EMailAddress2").AsString(100).Nullable()
                .WithColumn("EMailAddress3").AsString(100).Nullable()
                .WithColumn("Telephone1").AsString(50).Nullable()
                .WithColumn("Telephone2").AsString(50).Nullable()
                .WithColumn("Telephone3").AsString(50).Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("ParentAccountId").AsGuid().Nullable()
                .WithColumn("StatusCode").AsInt32().Nullable()
                .WithColumn("OwnerId").AsGuid().NotNullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("CountryCode").AsInt32().Nullable()
                .WithColumn("DepartmentId").AsGuid().Nullable()
            ;
            //For ProjectVersion
            Create.Table("ProjectVersion").InSchema("dbo")
                .WithColumn("ProjectVersionId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("ProjectId").AsGuid().NotNullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("VersionName").AsString(50).NotNullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
            ;
            //For Opportunity
            Create.Table("Opportunity").InSchema("dbo")
                .WithColumn("OpportunityId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("PriorityCode").AsInt32().Nullable()
                .WithColumn("OpportunityRatingCode").AsInt32().Nullable()
                .WithColumn("Name").AsString(300).Nullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("EstimatedValue").AsMoney().Nullable()
                .WithColumn("EstimatedCloseDate").AsDateTime().Nullable()
                .WithColumn("CloseProbability").AsInt32().Nullable()
                .WithColumn("ActualValue").AsMoney().Nullable()
                .WithColumn("ActualCloseDate").AsDateTime().Nullable()
                .WithColumn("OriginatingLeadId").AsGuid().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("StatusCode").AsInt32().Nullable()
                .WithColumn("TransactionCurrencyId").AsGuid().Nullable()
                .WithColumn("CustomerId").AsGuid().Nullable()
                .WithColumn("OwnerId").AsGuid().Nullable()
                .WithColumn("StepId").AsGuid().Nullable()
                .WithColumn("StepName").AsString(200).Nullable()
                .WithColumn("SalesStageCode").AsInt32().Nullable()
                .WithColumn("LeadSourceCode").AsInt32().Nullable()
                .WithColumn("OpportunityTypeCode").AsInt32().Nullable()
                .WithColumn("DepartmentId").AsGuid().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("ProjectTypeCode").AsInt32().Nullable()
                .WithColumn("TechnologyCode").AsInt32().Nullable()
                .WithColumn("TechnicianId").AsGuid().Nullable()
                .WithColumn("LatestFeedbackOn").AsDateTime().Nullable()
                .WithColumn("ExpectedStartOn").AsDateTime().Nullable()
                .WithColumn("EstimatedWorkAmount").AsDouble().Nullable()
                .WithColumn("ClosedTime").AsDateTime().Nullable()
            ;
            //For Audit
            Create.Table("Audit").InSchema("dbo")
                .WithColumn("AuditId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Action").AsString(50).Nullable()
                .WithColumn("ObjectId").AsGuid().Nullable()
                .WithColumn("ObjectType").AsString(64).Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("ChangeDate").AsMaxString().Nullable()
                .WithColumn("UserId").AsGuid().Nullable()
                .WithColumn("FieldName").AsString(50).Nullable()
                .WithColumn("OriginalValue").AsMaxString().Nullable()
                .WithColumn("NewValue").AsMaxString().Nullable()
                .WithColumn("TrasactionId").AsGuid().NotNullable()
            ;
            //For ImportMap
            Create.Table("ImportMap").InSchema("dbo")
                .WithColumn("ImportMapId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(320).Nullable()
                .WithColumn("Source").AsString(160).Nullable()
            ;
            //For Contact
            Create.Table("Contact").InSchema("dbo")
                .WithColumn("ContactId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("OriginatingLeadId").AsGuid().Nullable()
                .WithColumn("JobTitle").AsString(100).Nullable()
                .WithColumn("FirstName").AsString(50).Nullable()
                .WithColumn("Department").AsString(100).Nullable()
                .WithColumn("NickName").AsString(50).Nullable()
                .WithColumn("MiddleName").AsString(50).Nullable()
                .WithColumn("LastName").AsString(50).Nullable()
                .WithColumn("Suffix").AsString(10).Nullable()
                .WithColumn("FullName").AsString(160).Nullable()
                .WithColumn("Anniversary").AsDateTime().Nullable()
                .WithColumn("BirthDate").AsDateTime().Nullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("EmployeeId").AsString(50).Nullable()
                .WithColumn("GenderCode").AsInt32().Nullable()
                .WithColumn("AnnualIncome").AsMoney().Nullable()
                .WithColumn("HasChildrenCode").AsInt32().Nullable()
                .WithColumn("EducationCode").AsInt32().Nullable()
                .WithColumn("WebSiteUrl").AsString(200).Nullable()
                .WithColumn("FamilyStatusCode").AsInt32().Nullable()
                .WithColumn("SpousesName").AsString(100).Nullable()
                .WithColumn("EMailAddress1").AsString(100).Nullable()
                .WithColumn("EMailAddress2").AsString(100).Nullable()
                .WithColumn("EMailAddress3").AsString(100).Nullable()
                .WithColumn("AssistantName").AsString(100).Nullable()
                .WithColumn("AssistantPhone").AsString(50).Nullable()
                .WithColumn("ManagerName").AsString(100).Nullable()
                .WithColumn("ManangerPhone").AsString(50).Nullable()
                .WithColumn("AccountRoleCode").AsInt32().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("NumberOfChildren").AsInt32().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                .WithColumn("MobilePhone").AsString(50).Nullable()
                .WithColumn("Telephone1").AsString(50).Nullable()
                .WithColumn("Telephone2").AsString(50).Nullable()
                .WithColumn("Telephone3").AsString(50).Nullable()
                .WithColumn("Fax").AsString(50).Nullable()
                .WithColumn("StatusCode").AsInt32().Nullable()
                .WithColumn("OwnerId").AsGuid().NotNullable()
                .WithColumn("ParentCustomerId").AsGuid().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
            ;

            //For Criteria
            Create.Table("Criteria").InSchema("dbo")
                .WithColumn("CriteriaId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(200).Nullable()
                ;
            //For CriteriaNode
            Create.Table("CriteriaNode").InSchema("dbo")
                .WithColumn("CriteriaNodeId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("CriteriaId").AsGuid().NotNullable()
                .WithColumn("ParentNodeId").AsGuid().NotNullable()
                .WithColumn("Operator").AsString(100).Nullable()
                .WithColumn("OperatorType").AsString(100).Nullable()
                .WithColumn("CompareAttributeId").AsGuid().Nullable()
                .WithColumn("CompareValue").AsString(100).Nullable()
                ;
            //For Notification
            Create.Table("Notification").InSchema("dbo")
                .WithColumn("NotificationId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("ObjectId").AsGuid().Nullable()
                .WithColumn("ObjectType").AsString(200).Nullable()
                .WithColumn("Subject").AsString(200).Nullable()
                .WithColumn("Body").AsString(1000).Nullable()
                .WithColumn("NotificationUrl").AsString(200).Nullable()
                .WithColumn("AboutAttributeId").AsGuid().Nullable()
                .WithColumn("AboutUrl").AsString(200).Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
                ;
            //For NotificationTemplate
            Create.Table("NotificationTemplate").InSchema("dbo")
                .WithColumn("NotificationTemplateId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("SubjectTemplate").AsString(1000).Nullable()
                ;
            //For NotificationProfile
            Create.Table("NotificationProfile").InSchema("dbo")
                .WithColumn("NotificationProfileId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("CriteriaId").AsGuid().Nullable()
                .WithColumn("NotificationTemplateId").AsGuid().Nullable()
                .WithColumn("SubjectTemplateId").AsGuid().Nullable()
                .WithColumn("IsSys").AsBoolean().Nullable()
                ;
            //For NotificationRecipient
            Create.Table("NotificationRecipient").InSchema("dbo")
                .WithColumn("NotificationRecipientId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("NotificationId").AsGuid().Nullable()
                .WithColumn("RecipientId").AsGuid().Nullable()
                .WithColumn("NotificationStatus").AsString(50).Nullable()
                .WithColumn("ReadedOn").AsDateTime().Nullable()
                ;
            //For NotificationRecipientAttributes
            Create.Table("NotificationRecipientAttributes").InSchema("dbo")
                .WithColumn("NotificationRecipientAttributeId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("RecipientEntityId").AsGuid().Nullable()
                .WithColumn("AttributeId").AsGuid().Nullable()
                .WithColumn("NotificationProfileId").AsGuid().Nullable()
                .WithColumn("CriteriaId").AsGuid().Nullable()
                ;
            //For NotificationVariable
            Create.Table("NotificationVariable").InSchema("dbo")
                .WithColumn("NotificationVariableId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("ParentId").AsGuid().Nullable()
                .WithColumn("RelatedAttributeId").AsGuid().Nullable()
                .WithColumn("EntityId").AsGuid().Nullable()
                .WithColumn("Name").AsString(200).Nullable()
                .WithColumn("NotificationUrl").AsString(200).Nullable()
                ;
            //For ProfileVariable
            Create.Table("ProfileVariable").InSchema("dbo")
                .WithColumn("ProfileVariableId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("NotificationProfileId").AsGuid().Nullable()
                .WithColumn("NotificationVariableId").AsGuid().Nullable()
                ;

            //For Subscription
            Create.Table("Subscription").InSchema("dbo")
                .WithColumn("SubscriptionId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("UserId").AsGuid().Nullable()
                .WithColumn("NotificationProfileId").AsGuid().Nullable()
                ;

            //Foreign Key List 
            Create.ForeignKey().FromTable("ImportEntityMapping").ForeignColumn("ImportMapId").ToTable("ImportMap").PrimaryColumn("ImportMapId");

            Create.ForeignKey().FromTable("PickListMapping").ForeignColumn("ColumnMappingId").ToTable("ColumnMapping").PrimaryColumn("ColumnMappingId");

            Create.ForeignKey().FromTable("Invoice").ForeignColumn("BillingCustomerId").ToTable("Account").PrimaryColumn("AccountId");

            Create.ForeignKey().FromTable("Invoice").ForeignColumn("TransactionCurrencyId").ToTable("TransactionCurrency").PrimaryColumn("TransactionCurrencyId");

            Create.ForeignKey().FromTable("Invoice").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Invoice").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Invoice").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("ColumnMapping").ForeignColumn("ImportMapId").ToTable("ImportMap").PrimaryColumn("ImportMapId");

            Create.ForeignKey().FromTable("InvoiceContract").ForeignColumn("ContractId").ToTable("Contract").PrimaryColumn("ContractId");

            Create.ForeignKey().FromTable("InvoiceContract").ForeignColumn("InvoiceId").ToTable("Invoice").PrimaryColumn("InvoiceId");

            Create.ForeignKey().FromTable("Lead").ForeignColumn("DepartmentId").ToTable("Department").PrimaryColumn("DepartmentId");

            Create.ForeignKey().FromTable("Lead").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Lead").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Lead").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("LookupMapping").ForeignColumn("ColumnMappingId").ToTable("ColumnMapping").PrimaryColumn("ColumnMappingId");

            Create.ForeignKey().FromTable("Metadata_AttributeLookupValue").ForeignColumn("EntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");

            Create.ForeignKey().FromTable("Metadata_AttributeLookupValue").ForeignColumn("AttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");

            Create.ForeignKey().FromTable("Metadata_AttributePicklistValue").ForeignColumn("OptionSetId").ToTable("Metadata_OptionSet").PrimaryColumn("OptionSetId");

            Create.ForeignKey().FromTable("Metadata_AttributePicklistValueMap").ForeignColumn("AttributePicklistValueId").ToTable("Metadata_AttributePicklistValue").PrimaryColumn("AttributePicklistValueId");

            Create.ForeignKey().FromTable("Metadata_AttributePicklistValueMap").ForeignColumn("MapToValueId").ToTable("Metadata_AttributePicklistValue").PrimaryColumn("AttributePicklistValueId");

            Create.ForeignKey().FromTable("Project").ForeignColumn("ContractId").ToTable("Contract").PrimaryColumn("ContractId");

            Create.ForeignKey().FromTable("Project").ForeignColumn("ManagerId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Project").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Project").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Project").ForeignColumn("SaleServiceId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Product").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Product").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("AttentionInfomation").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("AttentionInfomation").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Contract").ForeignColumn("BillingCustomerId").ToTable("Account").PrimaryColumn("AccountId");

            Create.ForeignKey().FromTable("Contract").ForeignColumn("DepartmentId").ToTable("Department").PrimaryColumn("DepartmentId");

            Create.ForeignKey().FromTable("Contract").ForeignColumn("OpportunityId").ToTable("Opportunity").PrimaryColumn("OpportunityId");

            Create.ForeignKey().FromTable("Contract").ForeignColumn("TransactionCurrencyId").ToTable("TransactionCurrency").PrimaryColumn("TransactionCurrencyId");

            Create.ForeignKey().FromTable("Contract").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Contract").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Contract").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Quote").ForeignColumn("CustomerId").ToTable("Account").PrimaryColumn("AccountId");

            Create.ForeignKey().FromTable("Quote").ForeignColumn("BillTo_AddressId").ToTable("CustomerAddress").PrimaryColumn("CustomerAddressId");

            Create.ForeignKey().FromTable("Quote").ForeignColumn("OpportunityId").ToTable("Opportunity").PrimaryColumn("OpportunityId");

            Create.ForeignKey().FromTable("Quote").ForeignColumn("TransactionCurrencyId").ToTable("TransactionCurrency").PrimaryColumn("TransactionCurrencyId");

            Create.ForeignKey().FromTable("Quote").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Quote").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Quote").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("AttentionMember").ForeignColumn("AttentionInfoId").ToTable("AttentionInfomation").PrimaryColumn("AttentionInfoId");

            Create.ForeignKey().FromTable("AttentionMember").ForeignColumn("AttentionUserId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("QuoteLineItem").ForeignColumn("ProductId").ToTable("Product").PrimaryColumn("ProductId");

            Create.ForeignKey().FromTable("QuoteLineItem").ForeignColumn("QuoteId").ToTable("Quote").PrimaryColumn("QuoteId");

            Create.ForeignKey().FromTable("Metadata_AttentionConfig").ForeignColumn("AboutAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");

            Create.ForeignKey().FromTable("Metadata_AttentionConfig").ForeignColumn("AboutEntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");

            Create.ForeignKey().FromTable("Metadata_AttentionConfig").ForeignColumn("AttentionEntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");

            Create.ForeignKey().FromTable("Metadata_Attribute").ForeignColumn("AttributeTypeId").ToTable("Metadata_AttributeType").PrimaryColumn("AttributeTypeId");

            Create.ForeignKey().FromTable("Metadata_Attribute").ForeignColumn("EntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");

            Create.ForeignKey().FromTable("Metadata_Attribute").ForeignColumn("OptionSetId").ToTable("Metadata_OptionSet").PrimaryColumn("OptionSetId");

            Create.ForeignKey().FromTable("Metadata_AttentionMemberConfig").ForeignColumn("AttentionConfigId").ToTable("Metadata_AttentionConfig").PrimaryColumn("AttentionConfigId");

            Create.ForeignKey().FromTable("Metadata_AttentionMemberConfig").ForeignColumn("MemberAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");

            Create.ForeignKey().FromTable("Metadata_AttentionMemberConfig").ForeignColumn("MemberEntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");

            Create.ForeignKey().FromTable("Metadata_FilterConditionDetail").ForeignColumn("CompareAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");

            Create.ForeignKey().FromTable("Metadata_FilterConditionDetail").ForeignColumn("FilterConditionId").ToTable("Metadata_FilterConditon").PrimaryColumn("FilterConditionId");

            Create.ForeignKey().FromTable("ProjectMember").ForeignColumn("ProjectId").ToTable("Project").PrimaryColumn("ProjectId");

            Create.ForeignKey().FromTable("ProjectMember").ForeignColumn("MemberId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("User").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("User").ForeignColumn("DepartmentId").ToTable("Department").PrimaryColumn("DepartmentId");

            Create.ForeignKey().FromTable("User").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("User").ForeignColumn("ParentUserId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Attendance").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Attendance").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Attendance").ForeignColumn("RecordPersonId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Metadata_EntityRelationshipRole").ForeignColumn("EntityRelationshipId").ToTable("Metadata_EntityRelationship").PrimaryColumn("EntityRelationshipId");

            Create.ForeignKey().FromTable("Metadata_EntityRelationshipRole").ForeignColumn("EntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");

            Create.ForeignKey().FromTable("UserRole").ForeignColumn("RoleId").ToTable("Role").PrimaryColumn("RoleId");

            Create.ForeignKey().FromTable("UserRole").ForeignColumn("UserId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("ProjectTask").ForeignColumn("ProjectId").ToTable("Project").PrimaryColumn("ProjectId");

            Create.ForeignKey().FromTable("ProjectTask").ForeignColumn("ProjectIterationId").ToTable("ProjectIteration").PrimaryColumn("ProjectIterationId");

            Create.ForeignKey().FromTable("ProjectTask").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("ProjectTask").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("ProjectTask").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("PrivilegeEntity").ForeignColumn("PrivilegeId").ToTable("Privilege").PrimaryColumn("PrivilegeId");

            Create.ForeignKey().FromTable("RolePrivilege").ForeignColumn("PrivilegeId").ToTable("Privilege").PrimaryColumn("PrivilegeId");

            Create.ForeignKey().FromTable("RolePrivilege").ForeignColumn("RoleId").ToTable("Role").PrimaryColumn("RoleId");

            Create.ForeignKey().FromTable("Metadata_Relationship").ForeignColumn("ReferencedAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");

            Create.ForeignKey().FromTable("Metadata_Relationship").ForeignColumn("ReferencedEntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");

            Create.ForeignKey().FromTable("Metadata_Relationship").ForeignColumn("ReferencingAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");

            Create.ForeignKey().FromTable("Metadata_Relationship").ForeignColumn("ReferencingEntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");

            Create.ForeignKey().FromTable("ProjectIteration").ForeignColumn("ProjectId").ToTable("Project").PrimaryColumn("ProjectId");

            Create.ForeignKey().FromTable("ProjectIteration").ForeignColumn("ProjectVersionId").ToTable("ProjectVersion").PrimaryColumn("ProjectVersionId");

            Create.ForeignKey().FromTable("ProjectIteration").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("ProjectIteration").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("ProjectWeekReport").ForeignColumn("ProjectId").ToTable("Project").PrimaryColumn("ProjectId");

            Create.ForeignKey().FromTable("ProjectWeekReport").ForeignColumn("ProjectIterationId").ToTable("ProjectIteration").PrimaryColumn("ProjectIterationId");

            Create.ForeignKey().FromTable("ProjectWeekReport").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("ProjectWeekReport").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("TaskTimeHistory").ForeignColumn("TaskId").ToTable("ProjectTask").PrimaryColumn("TaskId");

            Create.ForeignKey().FromTable("Metadata_EntityRelationshipRelationships").ForeignColumn("EntityRelationshipId").ToTable("Metadata_EntityRelationship").PrimaryColumn("EntityRelationshipId");

            Create.ForeignKey().FromTable("Metadata_EntityRelationshipRelationships").ForeignColumn("RelationshipId").ToTable("Metadata_Relationship").PrimaryColumn("RelationshipId");

            Create.ForeignKey().FromTable("Note").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Note").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("TimeTracking").ForeignColumn("OpportunityId").ToTable("Opportunity").PrimaryColumn("OpportunityId");

            Create.ForeignKey().FromTable("TimeTracking").ForeignColumn("RecordById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Account").ForeignColumn("PrimaryContactId").ToTable("Contact").PrimaryColumn("ContactId");

            Create.ForeignKey().FromTable("Account").ForeignColumn("DepartmentId").ToTable("Department").PrimaryColumn("DepartmentId");

            Create.ForeignKey().FromTable("Account").ForeignColumn("OriginatingLeadId").ToTable("Lead").PrimaryColumn("LeadId");

            Create.ForeignKey().FromTable("Account").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Account").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Account").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("ProjectVersion").ForeignColumn("ProjectId").ToTable("Project").PrimaryColumn("ProjectId");

            Create.ForeignKey().FromTable("ProjectVersion").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("ProjectVersion").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Opportunity").ForeignColumn("DepartmentId").ToTable("Department").PrimaryColumn("DepartmentId");

            Create.ForeignKey().FromTable("Opportunity").ForeignColumn("OriginatingLeadId").ToTable("Lead").PrimaryColumn("LeadId");

            Create.ForeignKey().FromTable("Opportunity").ForeignColumn("TransactionCurrencyId").ToTable("TransactionCurrency").PrimaryColumn("TransactionCurrencyId");

            Create.ForeignKey().FromTable("Opportunity").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Opportunity").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Opportunity").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Opportunity").ForeignColumn("TechnicianId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Contact").ForeignColumn("OriginatingLeadId").ToTable("Lead").PrimaryColumn("LeadId");

            Create.ForeignKey().FromTable("Contact").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Contact").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("Contact").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");


            Create.ForeignKey().FromTable("CriteriaNode").ForeignColumn("CompareAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");
            Create.ForeignKey().FromTable("CriteriaNode").ForeignColumn("CriteriaId").ToTable("Criteria").PrimaryColumn("CriteriaId");

            Create.ForeignKey().FromTable("NotificationProfile").ForeignColumn("CriteriaId").ToTable("Criteria").PrimaryColumn("CriteriaId");
            Create.ForeignKey().FromTable("NotificationProfile").ForeignColumn("NotificationTemplateId").ToTable("NotificationTemplate").PrimaryColumn("NotificationTemplateId");
            Create.ForeignKey().FromTable("NotificationProfile").ForeignColumn("SubjectTemplateId").ToTable("NotificationTemplate").PrimaryColumn("NotificationTemplateId");

            Create.ForeignKey().FromTable("Notification").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey().FromTable("Notification").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("NotificationRecipient").ForeignColumn("NotificationId").ToTable("Notification").PrimaryColumn("NotificationId");
            Create.ForeignKey().FromTable("NotificationRecipient").ForeignColumn("RecipientId").ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey().FromTable("NotificationRecipientAttributes").ForeignColumn("AttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");
            Create.ForeignKey().FromTable("NotificationRecipientAttributes").ForeignColumn("CriteriaId").ToTable("Criteria").PrimaryColumn("CriteriaId");
            Create.ForeignKey().FromTable("NotificationRecipientAttributes").ForeignColumn("RecipientEntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");
            Create.ForeignKey().FromTable("NotificationRecipientAttributes").ForeignColumn("NotificationProfileId").ToTable("NotificationProfile").PrimaryColumn("NotificationProfileId");

            Create.ForeignKey().FromTable("NotificationVariable").ForeignColumn("RelatedAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");
            Create.ForeignKey().FromTable("NotificationVariable").ForeignColumn("EntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");

            Create.ForeignKey().FromTable("ProfileVariable").ForeignColumn("NotificationProfileId").ToTable("NotificationProfile").PrimaryColumn("NotificationProfileId");
            Create.ForeignKey().FromTable("ProfileVariable").ForeignColumn("NotificationVariableId").ToTable("NotificationVariable").PrimaryColumn("NotificationVariableId");

            Create.ForeignKey().FromTable("Subscription").ForeignColumn("NotificationProfileId").ToTable("NotificationProfile").PrimaryColumn("NotificationProfileId");
            Create.ForeignKey().FromTable("Subscription").ForeignColumn("UserId").ToTable("User").PrimaryColumn("UserId");

            var sql = @"ALTER TABLE [dbo].[CustomerAddress] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[CustomerAddress]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Invoice] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Invoice]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[InvoiceContract] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[InvoiceContract]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Lead] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Lead]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Metadata_AttributeLookupValue] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Metadata_AttributeLookupValue]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Metadata_AttributePicklistValue] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Metadata_AttributePicklistValue]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Metadata_AttributePicklistValueMap] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Metadata_AttributePicklistValueMap]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Project] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Project]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Metadata_LocalizedLabel] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Metadata_LocalizedLabel]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Product] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Product]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Contract] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Contract]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Quote] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Quote]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[QuoteLineItem] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[QuoteLineItem]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Metadata_Attribute] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Metadata_Attribute]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[TransactionCurrency] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[TransactionCurrency]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[User] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[User]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Attendance] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Attendance]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Metadata_EntityRelationship] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Metadata_EntityRelationship]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[ProjectTask] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[ProjectTask]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Metadata_Relationship] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Metadata_Relationship]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[ProjectIteration] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[ProjectIteration]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[ProjectWeekReport] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[ProjectWeekReport]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[SavedQuery] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[SavedQuery]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[TaskTimeHistory] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[TaskTimeHistory]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Metadata_EntityRelationshipRelationships] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Metadata_EntityRelationshipRelationships]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Note] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Note]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Account] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Account]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[ProjectVersion] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[ProjectVersion]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Opportunity] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Opportunity]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[AttentionInfomation] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[AttentionInfomation]  ADD VersionNumber ROWVERSION NOT NULL
ALTER TABLE [dbo].[Contact] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Contact]  ADD VersionNumber ROWVERSION NOT NULL";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Delete.ForeignKey().FromTable("ImportEntityMapping").ForeignColumn("ImportMapId").ToTable("ImportMap").PrimaryColumn("ImportMapId");
            Delete.ForeignKey().FromTable("PickListMapping").ForeignColumn("ColumnMappingId").ToTable("ColumnMapping").PrimaryColumn("ColumnMappingId");
            Delete.ForeignKey().FromTable("Invoice").ForeignColumn("BillingCustomerId").ToTable("Account").PrimaryColumn("AccountId");
            Delete.ForeignKey().FromTable("Invoice").ForeignColumn("TransactionCurrencyId").ToTable("TransactionCurrency").PrimaryColumn("TransactionCurrencyId");
            Delete.ForeignKey().FromTable("Invoice").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Invoice").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Invoice").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("ColumnMapping").ForeignColumn("ImportMapId").ToTable("ImportMap").PrimaryColumn("ImportMapId");
            Delete.ForeignKey().FromTable("InvoiceContract").ForeignColumn("ContractId").ToTable("Contract").PrimaryColumn("ContractId");
            Delete.ForeignKey().FromTable("InvoiceContract").ForeignColumn("InvoiceId").ToTable("Invoice").PrimaryColumn("InvoiceId");
            Delete.ForeignKey().FromTable("Lead").ForeignColumn("DepartmentId").ToTable("Department").PrimaryColumn("DepartmentId");
            Delete.ForeignKey().FromTable("Lead").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Lead").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Lead").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("LookupMapping").ForeignColumn("ColumnMappingId").ToTable("ColumnMapping").PrimaryColumn("ColumnMappingId");
            Delete.ForeignKey().FromTable("Metadata_AttributeLookupValue").ForeignColumn("EntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");
            Delete.ForeignKey().FromTable("Metadata_AttributeLookupValue").ForeignColumn("AttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");
            Delete.ForeignKey().FromTable("Metadata_AttributePicklistValue").ForeignColumn("OptionSetId").ToTable("Metadata_OptionSet").PrimaryColumn("OptionSetId");
            Delete.ForeignKey().FromTable("Metadata_AttributePicklistValueMap").ForeignColumn("AttributePicklistValueId").ToTable("Metadata_AttributePicklistValue").PrimaryColumn("AttributePicklistValueId");
            Delete.ForeignKey().FromTable("Metadata_AttributePicklistValueMap").ForeignColumn("MapToValueId").ToTable("Metadata_AttributePicklistValue").PrimaryColumn("AttributePicklistValueId");
            Delete.ForeignKey().FromTable("Project").ForeignColumn("ContractId").ToTable("Contract").PrimaryColumn("ContractId");
            Delete.ForeignKey().FromTable("Project").ForeignColumn("ManagerId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Project").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Project").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Project").ForeignColumn("SaleServiceId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Product").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Product").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("AttentionInfomation").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("AttentionInfomation").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Contract").ForeignColumn("BillingCustomerId").ToTable("Account").PrimaryColumn("AccountId");
            Delete.ForeignKey().FromTable("Contract").ForeignColumn("DepartmentId").ToTable("Department").PrimaryColumn("DepartmentId");
            Delete.ForeignKey().FromTable("Contract").ForeignColumn("OpportunityId").ToTable("Opportunity").PrimaryColumn("OpportunityId");
            Delete.ForeignKey().FromTable("Contract").ForeignColumn("TransactionCurrencyId").ToTable("TransactionCurrency").PrimaryColumn("TransactionCurrencyId");
            Delete.ForeignKey().FromTable("Contract").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Contract").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Contract").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Quote").ForeignColumn("CustomerId").ToTable("Account").PrimaryColumn("AccountId");
            Delete.ForeignKey().FromTable("Quote").ForeignColumn("BillTo_AddressId").ToTable("CustomerAddress").PrimaryColumn("CustomerAddressId");
            Delete.ForeignKey().FromTable("Quote").ForeignColumn("OpportunityId").ToTable("Opportunity").PrimaryColumn("OpportunityId");
            Delete.ForeignKey().FromTable("Quote").ForeignColumn("TransactionCurrencyId").ToTable("TransactionCurrency").PrimaryColumn("TransactionCurrencyId");
            Delete.ForeignKey().FromTable("Quote").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Quote").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Quote").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("AttentionMember").ForeignColumn("AttentionInfoId").ToTable("AttentionInfomation").PrimaryColumn("AttentionInfoId");
            Delete.ForeignKey().FromTable("AttentionMember").ForeignColumn("AttentionUserId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("QuoteLineItem").ForeignColumn("ProductId").ToTable("Product").PrimaryColumn("ProductId");
            Delete.ForeignKey().FromTable("QuoteLineItem").ForeignColumn("QuoteId").ToTable("Quote").PrimaryColumn("QuoteId");
            Delete.ForeignKey().FromTable("Metadata_AttentionConfig").ForeignColumn("AboutAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");
            Delete.ForeignKey().FromTable("Metadata_AttentionConfig").ForeignColumn("AboutEntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");
            Delete.ForeignKey().FromTable("Metadata_AttentionConfig").ForeignColumn("AttentionEntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");
            Delete.ForeignKey().FromTable("Metadata_Attribute").ForeignColumn("AttributeTypeId").ToTable("Metadata_AttributeType").PrimaryColumn("AttributeTypeId");
            Delete.ForeignKey().FromTable("Metadata_Attribute").ForeignColumn("EntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");
            Delete.ForeignKey().FromTable("Metadata_Attribute").ForeignColumn("OptionSetId").ToTable("Metadata_OptionSet").PrimaryColumn("OptionSetId");
            Delete.ForeignKey().FromTable("Metadata_AttentionMemberConfig").ForeignColumn("AttentionConfigId").ToTable("Metadata_AttentionConfig").PrimaryColumn("AttentionConfigId");
            Delete.ForeignKey().FromTable("Metadata_AttentionMemberConfig").ForeignColumn("MemberAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");
            Delete.ForeignKey().FromTable("Metadata_AttentionMemberConfig").ForeignColumn("MemberEntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");
            Delete.ForeignKey().FromTable("Metadata_FilterConditionDetail").ForeignColumn("CompareAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");
            Delete.ForeignKey().FromTable("Metadata_FilterConditionDetail").ForeignColumn("FilterConditionId").ToTable("Metadata_FilterConditon").PrimaryColumn("FilterConditionId");
            Delete.ForeignKey().FromTable("ProjectMember").ForeignColumn("ProjectId").ToTable("Project").PrimaryColumn("ProjectId");
            Delete.ForeignKey().FromTable("ProjectMember").ForeignColumn("MemberId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("User").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("User").ForeignColumn("DepartmentId").ToTable("Department").PrimaryColumn("DepartmentId");
            Delete.ForeignKey().FromTable("User").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("User").ForeignColumn("ParentUserId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Attendance").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Attendance").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Attendance").ForeignColumn("RecordPersonId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Metadata_EntityRelationshipRole").ForeignColumn("EntityRelationshipId").ToTable("Metadata_EntityRelationship").PrimaryColumn("EntityRelationshipId");
            Delete.ForeignKey().FromTable("Metadata_EntityRelationshipRole").ForeignColumn("EntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");
            Delete.ForeignKey().FromTable("UserRole").ForeignColumn("RoleId").ToTable("Role").PrimaryColumn("RoleId");
            Delete.ForeignKey().FromTable("UserRole").ForeignColumn("UserId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("ProjectTask").ForeignColumn("ProjectId").ToTable("Project").PrimaryColumn("ProjectId");
            Delete.ForeignKey().FromTable("ProjectTask").ForeignColumn("ProjectIterationId").ToTable("ProjectIteration").PrimaryColumn("ProjectIterationId");
            Delete.ForeignKey().FromTable("ProjectTask").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("ProjectTask").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("ProjectTask").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("PrivilegeEntity").ForeignColumn("PrivilegeId").ToTable("Privilege").PrimaryColumn("PrivilegeId");
            Delete.ForeignKey().FromTable("RolePrivilege").ForeignColumn("PrivilegeId").ToTable("Privilege").PrimaryColumn("PrivilegeId");
            Delete.ForeignKey().FromTable("RolePrivilege").ForeignColumn("RoleId").ToTable("Role").PrimaryColumn("RoleId");
            Delete.ForeignKey().FromTable("Metadata_Relationship").ForeignColumn("ReferencedAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");
            Delete.ForeignKey().FromTable("Metadata_Relationship").ForeignColumn("ReferencedEntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");
            Delete.ForeignKey().FromTable("Metadata_Relationship").ForeignColumn("ReferencingAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");
            Delete.ForeignKey().FromTable("Metadata_Relationship").ForeignColumn("ReferencingEntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");
            Delete.ForeignKey().FromTable("ProjectIteration").ForeignColumn("ProjectId").ToTable("Project").PrimaryColumn("ProjectId");
            Delete.ForeignKey().FromTable("ProjectIteration").ForeignColumn("ProjectVersionId").ToTable("ProjectVersion").PrimaryColumn("ProjectVersionId");
            Delete.ForeignKey().FromTable("ProjectIteration").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("ProjectIteration").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("ProjectWeekReport").ForeignColumn("ProjectId").ToTable("Project").PrimaryColumn("ProjectId");
            Delete.ForeignKey().FromTable("ProjectWeekReport").ForeignColumn("ProjectIterationId").ToTable("ProjectIteration").PrimaryColumn("ProjectIterationId");
            Delete.ForeignKey().FromTable("ProjectWeekReport").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("ProjectWeekReport").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("TaskTimeHistory").ForeignColumn("TaskId").ToTable("ProjectTask").PrimaryColumn("TaskId");
            Delete.ForeignKey().FromTable("Metadata_EntityRelationshipRelationships").ForeignColumn("EntityRelationshipId").ToTable("Metadata_EntityRelationship").PrimaryColumn("EntityRelationshipId");
            Delete.ForeignKey().FromTable("Metadata_EntityRelationshipRelationships").ForeignColumn("RelationshipId").ToTable("Metadata_Relationship").PrimaryColumn("RelationshipId");
            Delete.ForeignKey().FromTable("Note").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Note").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("TimeTracking").ForeignColumn("OpportunityId").ToTable("Opportunity").PrimaryColumn("OpportunityId");
            Delete.ForeignKey().FromTable("TimeTracking").ForeignColumn("RecordById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Account").ForeignColumn("PrimaryContactId").ToTable("Contact").PrimaryColumn("ContactId");
            Delete.ForeignKey().FromTable("Account").ForeignColumn("DepartmentId").ToTable("Department").PrimaryColumn("DepartmentId");
            Delete.ForeignKey().FromTable("Account").ForeignColumn("OriginatingLeadId").ToTable("Lead").PrimaryColumn("LeadId");
            Delete.ForeignKey().FromTable("Account").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Account").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Account").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("ProjectVersion").ForeignColumn("ProjectId").ToTable("Project").PrimaryColumn("ProjectId");
            Delete.ForeignKey().FromTable("ProjectVersion").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("ProjectVersion").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Opportunity").ForeignColumn("DepartmentId").ToTable("Department").PrimaryColumn("DepartmentId");
            Delete.ForeignKey().FromTable("Opportunity").ForeignColumn("OriginatingLeadId").ToTable("Lead").PrimaryColumn("LeadId");
            Delete.ForeignKey().FromTable("Opportunity").ForeignColumn("TransactionCurrencyId").ToTable("TransactionCurrency").PrimaryColumn("TransactionCurrencyId");
            Delete.ForeignKey().FromTable("Opportunity").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Opportunity").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Opportunity").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Opportunity").ForeignColumn("TechnicianId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Contact").ForeignColumn("OriginatingLeadId").ToTable("Lead").PrimaryColumn("LeadId");
            Delete.ForeignKey().FromTable("Contact").ForeignColumn("OwnerId").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Contact").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Contact").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Delete.ForeignKey().FromTable("CriteriaNode").ForeignColumn("CompareAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");
            Delete.ForeignKey().FromTable("CriteriaNode").ForeignColumn("CriteriaId").ToTable("Criteria").PrimaryColumn("CriteriaId");

            Delete.ForeignKey().FromTable("NotificationProfile").ForeignColumn("CriteriaId").ToTable("Criteria").PrimaryColumn("CriteriaId");
            Delete.ForeignKey().FromTable("NotificationProfile").ForeignColumn("NotificationTemplateId").ToTable("NotificationTemplate").PrimaryColumn("NotificationTemplateId");
            Delete.ForeignKey().FromTable("NotificationProfile").ForeignColumn("SubjectTemplateId").ToTable("NotificationTemplate").PrimaryColumn("NotificationTemplateId");

            Delete.ForeignKey().FromTable("Notification").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("Notification").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            Delete.ForeignKey().FromTable("NotificationRecipient").ForeignColumn("NotificationId").ToTable("Notification").PrimaryColumn("NotificationId");
            Delete.ForeignKey().FromTable("NotificationRecipient").ForeignColumn("RecipientId").ToTable("User").PrimaryColumn("UserId");

            Delete.ForeignKey().FromTable("NotificationRecipientAttributes").ForeignColumn("AttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");
            Delete.ForeignKey().FromTable("NotificationRecipientAttributes").ForeignColumn("CriteriaId").ToTable("Criteria").PrimaryColumn("CriteriaId");
            Delete.ForeignKey().FromTable("NotificationRecipientAttributes").ForeignColumn("RecipientEntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");
            Delete.ForeignKey().FromTable("NotificationRecipientAttributes").ForeignColumn("NotificationProfileId").ToTable("NotificationProfile").PrimaryColumn("NotificationProfileId");

            Delete.ForeignKey().FromTable("NotificationVariable").ForeignColumn("RelatedAttributeId").ToTable("Metadata_Attribute").PrimaryColumn("AttributeId");
            Delete.ForeignKey().FromTable("NotificationVariable").ForeignColumn("EntityId").ToTable("Metadata_Entity").PrimaryColumn("EntityId");

            Delete.ForeignKey().FromTable("ProfileVariable").ForeignColumn("NotificationProfileId").ToTable("NotificationProfile").PrimaryColumn("NotificationProfileId");
            Delete.ForeignKey().FromTable("ProfileVariable").ForeignColumn("NotificationVariableId").ToTable("NotificationVariable").PrimaryColumn("NotificationVariableId");

            Delete.ForeignKey().FromTable("Subscription").ForeignColumn("NotificationProfileId").ToTable("NotificationProfile").PrimaryColumn("NotificationProfileId");
            Delete.ForeignKey().FromTable("Subscription").ForeignColumn("UserId").ToTable("User").PrimaryColumn("UserId");


            Delete.Index("IX_UserName");

            Delete.Table("Contact");
            Delete.Table("ImportMap");
            Delete.Table("Audit");
            Delete.Table("Opportunity");
            Delete.Table("ProjectVersion");
            Delete.Table("Account");
            Delete.Table("TimeTracking");
            Delete.Table("Note");
            Delete.Table("Metadata_EntityRelationshipRelationships");
            Delete.Table("TaskTimeHistory");
            Delete.Table("SavedQuery");
            Delete.Table("ProjectWeekReport");
            Delete.Table("ProjectIteration");
            Delete.Table("SystemSetting");
            Delete.Table("Metadata_Relationship");
            Delete.Table("RolePrivilege");
            Delete.Table("PrivilegeEntity");
            Delete.Table("ProjectTask");
            Delete.Table("Privilege");
            Delete.Table("UserRole");
            Delete.Table("Role");
            Delete.Table("Metadata_EntityRelationshipRole");
            Delete.Table("Metadata_EntityRelationship");
            Delete.Table("Attendance");
            Delete.Table("User");
            Delete.Table("Metadata_FilterConditon");
            Delete.Table("ProjectMember");
            Delete.Table("Metadata_FilterConditionDetail");
            Delete.Table("Metadata_AttentionMemberConfig");
            Delete.Table("TransactionCurrency");
            Delete.Table("Metadata_Attribute");
            Delete.Table("Metadata_AttentionConfig");
            Delete.Table("QuoteLineItem");
            Delete.Table("AttentionMember");
            Delete.Table("Quote");
            Delete.Table("Contract");
            Delete.Table("AttentionInfomation");
            Delete.Table("Product");
            Delete.Table("Metadata_OptionSet");
            Delete.Table("Metadata_LocalizedLabel");
            Delete.Table("Project");
            Delete.Table("Metadata_Entity");
            Delete.Table("Metadata_AttributeType");
            Delete.Table("Metadata_AttributePicklistValueMap");
            Delete.Table("Metadata_AttributePicklistValue");
            Delete.Table("Metadata_AttributeLookupValue");
            Delete.Table("LookupMapping");
            Delete.Table("Lead");
            Delete.Table("InvoiceContract");
            Delete.Table("ColumnMapping");
            Delete.Table("Invoice");
            Delete.Table("PickListMapping");
            Delete.Table("Department");
            Delete.Table("CustomerAddress");
            Delete.Table("ImportEntityMapping");

            Delete.Table("Subscription");
            Delete.Table("ProfileVariable");
            Delete.Table("NotificationVariable");
            Delete.Table("NotificationRecipientAttributes");
            Delete.Table("NotificationRecipient");
            Delete.Table("NotificationProfile");
            Delete.Table("NotificationTemplate");
            Delete.Table("Notification");
            Delete.Table("CriteriaNode");
            Delete.Table("Criteria");

        }
    }
}
