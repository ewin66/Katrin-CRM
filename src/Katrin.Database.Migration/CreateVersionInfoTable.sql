if not exists (select name from sysobjects where name='VersionInfo')
begin
CREATE TABLE [dbo].[VersionInfo] (
[Version]   BIGINT   NOT NULL,
[AppliedOn] DATETIME NULL
)


CREATE UNIQUE CLUSTERED INDEX [UC_Version]
ON [dbo].[VersionInfo]([Version] ASC);

end

GO
delete from VersionInfo
INSERT INTO [dbo].[VersionInfo](
[Version],
[AppliedOn])
VALUES('20121009050055','2012-10-09 09:01:28.000')

ALTER TABLE [dbo].[CustomerAddress] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[CustomerAddress]  ADD VersionNumber ROWVERSION NOT NULL
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
ALTER TABLE [dbo].[Contact] DROP COLUMN VersionNumber      ALTER TABLE [dbo].[Contact]  ADD VersionNumber ROWVERSION NOT NULL

DELETE FROM QuoteLineItem
FROM	QuoteLineItem li
WHERE	NOT EXISTS(SELECT * FROM Quote q WHERE q.QuoteId = li.QuoteId)


GO
PRINT N'Dropping DF_SavedQuery_IsCustomizable...';


GO
ALTER TABLE [dbo].[SavedQuery] DROP CONSTRAINT [DF_SavedQuery_IsCustomizable];


GO
PRINT N'Dropping DF_SavedQuery_IsQuickFindQuery...';


GO
ALTER TABLE [dbo].[SavedQuery] DROP CONSTRAINT [DF_SavedQuery_IsQuickFindQuery];


GO
PRINT N'Dropping DF_SavedQuery_IsPrivate...';


GO
ALTER TABLE [dbo].[SavedQuery] DROP CONSTRAINT [DF_SavedQuery_IsPrivate];


GO
PRINT N'Dropping DF_SavedQuery_CanBeDeleted...';


GO
ALTER TABLE [dbo].[SavedQuery] DROP CONSTRAINT [DF_SavedQuery_CanBeDeleted];


GO
PRINT N'Dropping DF_SavedQuery_IsDefault...';


GO
ALTER TABLE [dbo].[SavedQuery] DROP CONSTRAINT [DF_SavedQuery_IsDefault];


GO
PRINT N'Dropping DF_SavedQuery_IsUserDefined...';


GO
ALTER TABLE [dbo].[SavedQuery] DROP CONSTRAINT [DF_SavedQuery_IsUserDefined];


GO
PRINT N'Dropping DF__TaskTimeH__IsDel__28B808A7...';


GO
ALTER TABLE [dbo].[TaskTimeHistory] DROP CONSTRAINT [DF__TaskTimeH__IsDel__28B808A7];


GO
PRINT N'Dropping FK_Account_Contact...';


GO
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK_Account_Contact];


GO
PRINT N'Dropping FK_Account_Department...';


GO
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK_Account_Department];


GO
PRINT N'Dropping FK_Account_Lead...';


GO
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK_Account_Lead];


GO
PRINT N'Dropping FK_Account_User...';


GO
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK_Account_User];


GO
PRINT N'Dropping FK_Account_User_CreatedBy...';


GO
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK_Account_User_CreatedBy];


GO
PRINT N'Dropping FK_Account_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK_Account_User_ModifiedBy];


GO
PRINT N'Dropping FK_Attendance_User_CreatedBy...';


GO
ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT [FK_Attendance_User_CreatedBy];


GO
PRINT N'Dropping FK_Attendance_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT [FK_Attendance_User_ModifiedBy];


GO
PRINT N'Dropping FK_Attendance_User_RecordPersonId...';


GO
ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT [FK_Attendance_User_RecordPersonId];


GO
PRINT N'Dropping FK_AttentionInfomation_User_CreatedBy...';


GO
ALTER TABLE [dbo].[AttentionInfomation] DROP CONSTRAINT [FK_AttentionInfomation_User_CreatedBy];


GO
PRINT N'Dropping FK_AttentionInfomation_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[AttentionInfomation] DROP CONSTRAINT [FK_AttentionInfomation_User_ModifiedBy];


GO
PRINT N'Dropping FK_AttentionMember_AttentionInfo...';


GO
ALTER TABLE [dbo].[AttentionMember] DROP CONSTRAINT [FK_AttentionMember_AttentionInfo];


GO
PRINT N'Dropping FK_AttentionMember_User...';


GO
ALTER TABLE [dbo].[AttentionMember] DROP CONSTRAINT [FK_AttentionMember_User];


GO
PRINT N'Dropping FK_ColumnMapping_ImportMap...';


GO
ALTER TABLE [dbo].[ColumnMapping] DROP CONSTRAINT [FK_ColumnMapping_ImportMap];


GO
PRINT N'Dropping FK_Contact_Lead...';


GO
ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [FK_Contact_Lead];


GO
PRINT N'Dropping FK_Contact_User...';


GO
ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [FK_Contact_User];


GO
PRINT N'Dropping FK_Contact_User_CreatedBy...';


GO
ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [FK_Contact_User_CreatedBy];


GO
PRINT N'Dropping FK_Contact_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [FK_Contact_User_ModifiedBy];


GO
PRINT N'Dropping FK_Contract_Account...';


GO
ALTER TABLE [dbo].[Contract] DROP CONSTRAINT [FK_Contract_Account];


GO
PRINT N'Dropping FK_Contract_Department...';


GO
ALTER TABLE [dbo].[Contract] DROP CONSTRAINT [FK_Contract_Department];


GO
PRINT N'Dropping FK_Contract_Opportunity...';


GO
ALTER TABLE [dbo].[Contract] DROP CONSTRAINT [FK_Contract_Opportunity];


GO
PRINT N'Dropping FK_Contract_TransactionCurrency...';


GO
ALTER TABLE [dbo].[Contract] DROP CONSTRAINT [FK_Contract_TransactionCurrency];


GO
PRINT N'Dropping FK_Contract_User...';


GO
ALTER TABLE [dbo].[Contract] DROP CONSTRAINT [FK_Contract_User];


GO
PRINT N'Dropping FK_Contract_User_CreatedBy...';


GO
ALTER TABLE [dbo].[Contract] DROP CONSTRAINT [FK_Contract_User_CreatedBy];


GO
PRINT N'Dropping FK_Contract_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[Contract] DROP CONSTRAINT [FK_Contract_User_ModifiedBy];


GO
PRINT N'Dropping FK_ImportEntityMapping_ImportMap...';


GO
ALTER TABLE [dbo].[ImportEntityMapping] DROP CONSTRAINT [FK_ImportEntityMapping_ImportMap];


GO
PRINT N'Dropping FK_Invoice_Account...';


GO
ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT [FK_Invoice_Account];


GO
PRINT N'Dropping FK_Invoice_TransactionCurrency...';


GO
ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT [FK_Invoice_TransactionCurrency];


GO
PRINT N'Dropping FK_Invoice_User...';


GO
ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT [FK_Invoice_User];


GO
PRINT N'Dropping FK_Invoice_User_CreatedBy...';


GO
ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT [FK_Invoice_User_CreatedBy];


GO
PRINT N'Dropping FK_Invoice_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT [FK_Invoice_User_ModifiedBy];


GO
PRINT N'Dropping FK_InvoiceContract_Contract...';


GO
ALTER TABLE [dbo].[InvoiceContract] DROP CONSTRAINT [FK_InvoiceContract_Contract];


GO
PRINT N'Dropping FK_InvoiceContract_Invoice...';


GO
ALTER TABLE [dbo].[InvoiceContract] DROP CONSTRAINT [FK_InvoiceContract_Invoice];


GO
PRINT N'Dropping FK_Lead_Department...';


GO
ALTER TABLE [dbo].[Lead] DROP CONSTRAINT [FK_Lead_Department];


GO
PRINT N'Dropping FK_Lead_User...';


GO
ALTER TABLE [dbo].[Lead] DROP CONSTRAINT [FK_Lead_User];


GO
PRINT N'Dropping FK_Lead_User_CreatedBy...';


GO
ALTER TABLE [dbo].[Lead] DROP CONSTRAINT [FK_Lead_User_CreatedBy];


GO
PRINT N'Dropping FK_Lead_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[Lead] DROP CONSTRAINT [FK_Lead_User_ModifiedBy];


GO
PRINT N'Dropping FK_LookupMapping_ColumnMapping...';


GO
ALTER TABLE [dbo].[LookupMapping] DROP CONSTRAINT [FK_LookupMapping_ColumnMapping];


GO
PRINT N'Dropping FK_Metadata_AttentionConfig_About_Attribute...';


GO
ALTER TABLE [dbo].[Metadata_AttentionConfig] DROP CONSTRAINT [FK_Metadata_AttentionConfig_About_Attribute];


GO
PRINT N'Dropping FK_Metadata_AttentionConfig_About_Entity...';


GO
ALTER TABLE [dbo].[Metadata_AttentionConfig] DROP CONSTRAINT [FK_Metadata_AttentionConfig_About_Entity];


GO
PRINT N'Dropping FK_Metadata_AttentionConfig_Entity...';


GO
ALTER TABLE [dbo].[Metadata_AttentionConfig] DROP CONSTRAINT [FK_Metadata_AttentionConfig_Entity];


GO
PRINT N'Dropping FK_Metadata_AttentionMemberConfig_AttentionConfig...';


GO
ALTER TABLE [dbo].[Metadata_AttentionMemberConfig] DROP CONSTRAINT [FK_Metadata_AttentionMemberConfig_AttentionConfig];


GO
PRINT N'Dropping FK_Metadata_AttentionMemberConfig_Attribute...';


GO
ALTER TABLE [dbo].[Metadata_AttentionMemberConfig] DROP CONSTRAINT [FK_Metadata_AttentionMemberConfig_Attribute];


GO
PRINT N'Dropping FK_Metadata_AttentionMemberConfig_Entity...';


GO
ALTER TABLE [dbo].[Metadata_AttentionMemberConfig] DROP CONSTRAINT [FK_Metadata_AttentionMemberConfig_Entity];


GO
PRINT N'Dropping FK_Attribute_AttributeType...';


GO
ALTER TABLE [dbo].[Metadata_Attribute] DROP CONSTRAINT [FK_Attribute_AttributeType];


GO
PRINT N'Dropping FK_Attribute_Entity...';


GO
ALTER TABLE [dbo].[Metadata_Attribute] DROP CONSTRAINT [FK_Attribute_Entity];


GO
PRINT N'Dropping FK_Attribute_OptionSet...';


GO
ALTER TABLE [dbo].[Metadata_Attribute] DROP CONSTRAINT [FK_Attribute_OptionSet];


GO
PRINT N'Dropping FK_AttributeLookupValue_Entity...';


GO
ALTER TABLE [dbo].[Metadata_AttributeLookupValue] DROP CONSTRAINT [FK_AttributeLookupValue_Entity];


GO
PRINT N'Dropping FK_AttributeLookupValue_For_Attribute...';


GO
ALTER TABLE [dbo].[Metadata_AttributeLookupValue] DROP CONSTRAINT [FK_AttributeLookupValue_For_Attribute];


GO
PRINT N'Dropping FK_AttributePicklistValue_OptionSet...';


GO
ALTER TABLE [dbo].[Metadata_AttributePicklistValue] DROP CONSTRAINT [FK_AttributePicklistValue_OptionSet];


GO
PRINT N'Dropping FK_AttributePicklistValueMap_AttributePicklistValue...';


GO
ALTER TABLE [dbo].[Metadata_AttributePicklistValueMap] DROP CONSTRAINT [FK_AttributePicklistValueMap_AttributePicklistValue];


GO
PRINT N'Dropping FK_AttributePicklistValueMap_MapToValue...';


GO
ALTER TABLE [dbo].[Metadata_AttributePicklistValueMap] DROP CONSTRAINT [FK_AttributePicklistValueMap_MapToValue];


GO
PRINT N'Dropping FK_EntityRelationshipRelationships_EntityRelationship...';


GO
ALTER TABLE [dbo].[Metadata_EntityRelationshipRelationships] DROP CONSTRAINT [FK_EntityRelationshipRelationships_EntityRelationship];


GO
PRINT N'Dropping FK_EntityRelationshipRelationships_Relationship...';


GO
ALTER TABLE [dbo].[Metadata_EntityRelationshipRelationships] DROP CONSTRAINT [FK_EntityRelationshipRelationships_Relationship];


GO
PRINT N'Dropping FK_EntityRelationshipRole_EntityRelationship...';


GO
ALTER TABLE [dbo].[Metadata_EntityRelationshipRole] DROP CONSTRAINT [FK_EntityRelationshipRole_EntityRelationship];


GO
PRINT N'Dropping FK_EntityRelationshipRole_Metadata_Entity...';


GO
ALTER TABLE [dbo].[Metadata_EntityRelationshipRole] DROP CONSTRAINT [FK_EntityRelationshipRole_Metadata_Entity];


GO
PRINT N'Dropping FK_Metadata_FilterConditionDetail_Attribute...';


GO
ALTER TABLE [dbo].[Metadata_FilterConditionDetail] DROP CONSTRAINT [FK_Metadata_FilterConditionDetail_Attribute];


GO
PRINT N'Dropping FK_Metadata_FilterConditionDetail_FilterCondition...';


GO
ALTER TABLE [dbo].[Metadata_FilterConditionDetail] DROP CONSTRAINT [FK_Metadata_FilterConditionDetail_FilterCondition];


GO
PRINT N'Dropping FK_Metadata_Relationship_Metadata_ReferencedAttribute...';


GO
ALTER TABLE [dbo].[Metadata_Relationship] DROP CONSTRAINT [FK_Metadata_Relationship_Metadata_ReferencedAttribute];


GO
PRINT N'Dropping FK_Metadata_Relationship_Metadata_ReferencedEntity...';


GO
ALTER TABLE [dbo].[Metadata_Relationship] DROP CONSTRAINT [FK_Metadata_Relationship_Metadata_ReferencedEntity];


GO
PRINT N'Dropping FK_Metadata_Relationship_Metadata_ReferencingAttribute...';


GO
ALTER TABLE [dbo].[Metadata_Relationship] DROP CONSTRAINT [FK_Metadata_Relationship_Metadata_ReferencingAttribute];


GO
PRINT N'Dropping FK_Metadata_Relationship_Metadata_ReferencingEntity...';


GO
ALTER TABLE [dbo].[Metadata_Relationship] DROP CONSTRAINT [FK_Metadata_Relationship_Metadata_ReferencingEntity];


GO
PRINT N'Dropping FK_Note_User_CreatedBy...';


GO
ALTER TABLE [dbo].[Note] DROP CONSTRAINT [FK_Note_User_CreatedBy];


GO
PRINT N'Dropping FK_Note_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[Note] DROP CONSTRAINT [FK_Note_User_ModifiedBy];


GO
PRINT N'Dropping FK_Opportunity_Department...';


GO
ALTER TABLE [dbo].[Opportunity] DROP CONSTRAINT [FK_Opportunity_Department];


GO
PRINT N'Dropping FK_Opportunity_Lead...';


GO
ALTER TABLE [dbo].[Opportunity] DROP CONSTRAINT [FK_Opportunity_Lead];


GO
PRINT N'Dropping FK_Opportunity_TransactionCurrency...';


GO
ALTER TABLE [dbo].[Opportunity] DROP CONSTRAINT [FK_Opportunity_TransactionCurrency];


GO
PRINT N'Dropping FK_Opportunity_User...';


GO
ALTER TABLE [dbo].[Opportunity] DROP CONSTRAINT [FK_Opportunity_User];


GO
PRINT N'Dropping FK_Opportunity_User_CreatedBy...';


GO
ALTER TABLE [dbo].[Opportunity] DROP CONSTRAINT [FK_Opportunity_User_CreatedBy];


GO
PRINT N'Dropping FK_Opportunity_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[Opportunity] DROP CONSTRAINT [FK_Opportunity_User_ModifiedBy];


GO
PRINT N'Dropping FK_Opportunity_User_TechnicianId...';


GO
ALTER TABLE [dbo].[Opportunity] DROP CONSTRAINT [FK_Opportunity_User_TechnicianId];


GO
PRINT N'Dropping FK_PickListMapping_ColumnMapping...';


GO
ALTER TABLE [dbo].[PickListMapping] DROP CONSTRAINT [FK_PickListMapping_ColumnMapping];


GO
PRINT N'Dropping FK_PrivilegeEntity_Privilege...';


GO
ALTER TABLE [dbo].[PrivilegeEntity] DROP CONSTRAINT [FK_PrivilegeEntity_Privilege];


GO
PRINT N'Dropping FK_Product_User_CreatedBy...';


GO
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_User_CreatedBy];


GO
PRINT N'Dropping FK_Product_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_User_ModifiedBy];


GO
PRINT N'Dropping FK_Project_Contract...';


GO
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_Contract];


GO
PRINT N'Dropping FK_Project_User...';


GO
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_User];


GO
PRINT N'Dropping FK_Project_User_CreatedBy...';


GO
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_User_CreatedBy];


GO
PRINT N'Dropping FK_Project_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_User_ModifiedBy];


GO
PRINT N'Dropping FK_Project_User_SaleServiceId...';


GO
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_User_SaleServiceId];


GO
PRINT N'Dropping FK_ProjectIteration_Project...';


GO
ALTER TABLE [dbo].[ProjectIteration] DROP CONSTRAINT [FK_ProjectIteration_Project];


GO
PRINT N'Dropping FK_ProjectIteration_ProjectVersion...';


GO
ALTER TABLE [dbo].[ProjectIteration] DROP CONSTRAINT [FK_ProjectIteration_ProjectVersion];


GO
PRINT N'Dropping FK_ProjectIteration_User_CreatedBy...';


GO
ALTER TABLE [dbo].[ProjectIteration] DROP CONSTRAINT [FK_ProjectIteration_User_CreatedBy];


GO
PRINT N'Dropping FK_ProjectIteration_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[ProjectIteration] DROP CONSTRAINT [FK_ProjectIteration_User_ModifiedBy];


GO
PRINT N'Dropping FK_ProjectMember_Project...';


GO
ALTER TABLE [dbo].[ProjectMember] DROP CONSTRAINT [FK_ProjectMember_Project];


GO
PRINT N'Dropping FK_ProjectMember_User...';


GO
ALTER TABLE [dbo].[ProjectMember] DROP CONSTRAINT [FK_ProjectMember_User];


GO
PRINT N'Dropping FK_ProjectTask_Project...';


GO
ALTER TABLE [dbo].[ProjectTask] DROP CONSTRAINT [FK_ProjectTask_Project];


GO
PRINT N'Dropping FK_ProjectTask_ProjectIteration...';


GO
ALTER TABLE [dbo].[ProjectTask] DROP CONSTRAINT [FK_ProjectTask_ProjectIteration];


GO
PRINT N'Dropping FK_ProjectTask_User...';


GO
ALTER TABLE [dbo].[ProjectTask] DROP CONSTRAINT [FK_ProjectTask_User];


GO
PRINT N'Dropping FK_ProjectTask_User_CreatedBy...';


GO
ALTER TABLE [dbo].[ProjectTask] DROP CONSTRAINT [FK_ProjectTask_User_CreatedBy];


GO
PRINT N'Dropping FK_ProjectTask_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[ProjectTask] DROP CONSTRAINT [FK_ProjectTask_User_ModifiedBy];


GO
PRINT N'Dropping FK_ProjectVersion_Project...';


GO
ALTER TABLE [dbo].[ProjectVersion] DROP CONSTRAINT [FK_ProjectVersion_Project];


GO
PRINT N'Dropping FK_ProjectVersion_User...';


GO
ALTER TABLE [dbo].[ProjectVersion] DROP CONSTRAINT [FK_ProjectVersion_User];


GO
PRINT N'Dropping FK_ProjectVersion_User1...';


GO
ALTER TABLE [dbo].[ProjectVersion] DROP CONSTRAINT [FK_ProjectVersion_User1];


GO
PRINT N'Dropping FK_ProjectWeekReport_Project...';


GO
ALTER TABLE [dbo].[ProjectWeekReport] DROP CONSTRAINT [FK_ProjectWeekReport_Project];


GO
PRINT N'Dropping FK_ProjectWeekReport_ProjectIteration...';


GO
ALTER TABLE [dbo].[ProjectWeekReport] DROP CONSTRAINT [FK_ProjectWeekReport_ProjectIteration];


GO
PRINT N'Dropping FK_ProjectWeekReport_User_CreatedBy...';


GO
ALTER TABLE [dbo].[ProjectWeekReport] DROP CONSTRAINT [FK_ProjectWeekReport_User_CreatedBy];


GO
PRINT N'Dropping FK_ProjectWeekReport_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[ProjectWeekReport] DROP CONSTRAINT [FK_ProjectWeekReport_User_ModifiedBy];


GO
PRINT N'Dropping FK_Quote_Account...';


GO
ALTER TABLE [dbo].[Quote] DROP CONSTRAINT [FK_Quote_Account];


GO
PRINT N'Dropping FK_Quote_CustomerAddress...';


GO
ALTER TABLE [dbo].[Quote] DROP CONSTRAINT [FK_Quote_CustomerAddress];


GO
PRINT N'Dropping FK_Quote_Opportunity...';


GO
ALTER TABLE [dbo].[Quote] DROP CONSTRAINT [FK_Quote_Opportunity];


GO
PRINT N'Dropping FK_Quote_TransactionCurrency...';


GO
ALTER TABLE [dbo].[Quote] DROP CONSTRAINT [FK_Quote_TransactionCurrency];


GO
PRINT N'Dropping FK_Quote_User...';


GO
ALTER TABLE [dbo].[Quote] DROP CONSTRAINT [FK_Quote_User];


GO
PRINT N'Dropping FK_Quote_User_CreatedBy...';


GO
ALTER TABLE [dbo].[Quote] DROP CONSTRAINT [FK_Quote_User_CreatedBy];


GO
PRINT N'Dropping FK_Quote_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[Quote] DROP CONSTRAINT [FK_Quote_User_ModifiedBy];


GO
PRINT N'Dropping FK_QuoteLineItem_Product...';


GO
ALTER TABLE [dbo].[QuoteLineItem] DROP CONSTRAINT [FK_QuoteLineItem_Product];


GO
PRINT N'Dropping FK_QuoteLineItem_Quote...';


GO
ALTER TABLE [dbo].[QuoteLineItem] DROP CONSTRAINT [FK_QuoteLineItem_Quote];


GO
PRINT N'Dropping FK_RolePrivilege_Privilege...';


GO
ALTER TABLE [dbo].[RolePrivilege] DROP CONSTRAINT [FK_RolePrivilege_Privilege];


GO
PRINT N'Dropping FK_RolePrivilege_Role...';


GO
ALTER TABLE [dbo].[RolePrivilege] DROP CONSTRAINT [FK_RolePrivilege_Role];


GO
PRINT N'Dropping FK_TaskTimeHistory_ProjectTask...';


GO
ALTER TABLE [dbo].[TaskTimeHistory] DROP CONSTRAINT [FK_TaskTimeHistory_ProjectTask];


GO
PRINT N'Dropping FK_TimeTracking_Opportunity...';


GO
ALTER TABLE [dbo].[TimeTracking] DROP CONSTRAINT [FK_TimeTracking_Opportunity];


GO
PRINT N'Dropping FK_TimeTracking_User...';


GO
ALTER TABLE [dbo].[TimeTracking] DROP CONSTRAINT [FK_TimeTracking_User];


GO
PRINT N'Dropping FK_User_CreatedBy...';


GO
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_CreatedBy];


GO
PRINT N'Dropping FK_User_Department...';


GO
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Department];


GO
PRINT N'Dropping FK_User_ModifiedBy...';


GO
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_ModifiedBy];


GO
PRINT N'Dropping FK_User_ParentUser...';


GO
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_ParentUser];


GO
PRINT N'Dropping FK_UserRole_Role...';


GO
ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Role];


GO
PRINT N'Dropping FK_UserRole_User...';


GO
ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_User];


GO
PRINT N'Altering [dbo].[Account]...';


GO
ALTER TABLE [dbo].[Account] ALTER COLUMN [SIC] NVARCHAR (20) NULL;


GO
PRINT N'Altering [dbo].[Lead]...';


GO
ALTER TABLE [dbo].[Lead] ALTER COLUMN [NumberOfEmployees] NVARCHAR (10) NULL;


GO
PRINT N'Altering [dbo].[PrivilegeEntity]...';


GO
ALTER TABLE [dbo].[PrivilegeEntity] ALTER COLUMN [EntityName] NVARCHAR (20) NOT NULL;


GO
PRINT N'Starting rebuilding table [dbo].[SavedQuery]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_SavedQuery] (
    [SavedQueryId]          UNIQUEIDENTIFIER NOT NULL,
    [QueryParentId]         UNIQUEIDENTIFIER NULL,
    [Name]                  NVARCHAR (200)   NOT NULL,
    [Description]           NVARCHAR (MAX)   NULL,
    [QueryType]             INT              NOT NULL,
    [IsDefault]             BIT              CONSTRAINT [DF_SavedQuery_IsDefault] DEFAULT ((0)) NOT NULL,
    [ReturnedTypeId]        UNIQUEIDENTIFIER NOT NULL,
    [IsUserDefined]         BIT              CONSTRAINT [DF_SavedQuery_IsUserDefined] DEFAULT ((1)) NULL,
    [FetchXml]              NVARCHAR (MAX)   NULL,
    [IsCustomizable]        BIT              CONSTRAINT [DF_SavedQuery_IsCustomizable] DEFAULT ((1)) NOT NULL,
    [IsQuickFindQuery]      BIT              CONSTRAINT [DF_SavedQuery_IsQuickFindQuery] DEFAULT ((0)) NOT NULL,
    [ColumnSetXml]          NVARCHAR (MAX)   NULL,
    [LayoutXml]             NVARCHAR (MAX)   NULL,
    [CreatedBy]             UNIQUEIDENTIFIER NULL,
    [CreatedOn]             DATETIME         NULL,
    [ModifiedBy]            UNIQUEIDENTIFIER NULL,
    [ModifiedOn]            DATETIME         NULL,
    [IsPrivate]             BIT              CONSTRAINT [DF_SavedQuery_IsPrivate] DEFAULT ((0)) NOT NULL,
    [AdvancedGroupBy]       NVARCHAR (160)   NULL,
    [ConditionalFormatting] NVARCHAR (MAX)   NULL,
    [CanBeDeleted]          BIT              CONSTRAINT [DF_SavedQuery_CanBeDeleted] DEFAULT ((1)) NOT NULL,
    [StatusCode]            INT              NULL,
    [VersionNumber]         ROWVERSION       NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_SavedQuery] PRIMARY KEY CLUSTERED ([SavedQueryId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[SavedQuery])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_SavedQuery] ([SavedQueryId], [Name], [Description], [QueryType], [IsDefault], [ReturnedTypeId], [IsUserDefined], [FetchXml], [IsCustomizable], [IsQuickFindQuery], [ColumnSetXml], [LayoutXml], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsPrivate], [AdvancedGroupBy], [ConditionalFormatting], [CanBeDeleted], [StatusCode])
        SELECT   [SavedQueryId],
                 [Name],
                 [Description],
                 [QueryType],
                 [IsDefault],
                 [ReturnedTypeId],
                 [IsUserDefined],
                 [FetchXml],
                 [IsCustomizable],
                 [IsQuickFindQuery],
                 [ColumnSetXml],
                 [LayoutXml],
                 [CreatedBy],
                 [CreatedOn],
                 [ModifiedBy],
                 [ModifiedOn],
                 [IsPrivate],
                 [AdvancedGroupBy],
                 [ConditionalFormatting],
                 [CanBeDeleted],
                 [StatusCode]
        FROM     [dbo].[SavedQuery]
        ORDER BY [SavedQueryId] ASC;
        
    END

DROP TABLE [dbo].[SavedQuery];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_SavedQuery]', N'SavedQuery';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_SavedQuery]', N'PK_SavedQuery', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Attendance]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Attendance] (
    [AttendanceId]       UNIQUEIDENTIFIER NOT NULL,
    [RecordPersonId]     UNIQUEIDENTIFIER NULL,
    [RecordOn]           DATETIME         NULL,
    [AttendanceTypeCode] INT              NULL,
    [AttendanceLength]   INT              NULL,
    [AttendanceUnitCode] INT              NULL,
    [CreatedOn]          DATETIME         NULL,
    [CreatedById]        UNIQUEIDENTIFIER NULL,
    [ModifiedOn]         DATETIME         NULL,
    [ModifiedById]       UNIQUEIDENTIFIER NULL,
    [IsDeleted]          BIT              NOT NULL,
    [Description]        NVARCHAR (MAX)   NULL,
    [VersionNumber]      ROWVERSION       NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Attendance] PRIMARY KEY CLUSTERED ([AttendanceId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Attendance])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_Attendance] ([AttendanceId], [RecordPersonId], [RecordOn], [AttendanceTypeCode], [AttendanceLength], [AttendanceUnitCode], [CreatedOn], [CreatedById], [ModifiedOn], [ModifiedById], [IsDeleted], [Description])
        SELECT   [AttendanceId],
                 [RecordPersonId],
                 [RecordOn],
                 [AttendanceTypeCode],
                 [AttendanceLength],
                 [AttendanceUnitCode],
                 [CreatedOn],
                 [CreatedById],
                 [ModifiedOn],
                 [ModifiedById],
                 [IsDeleted],
                 [Description]
        FROM     [dbo].[Attendance]
        ORDER BY [AttendanceId] ASC;
        
    END

DROP TABLE [dbo].[Attendance];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Attendance]', N'Attendance';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Attendance]', N'PK_Attendance', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Metadata_Attribute]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Metadata_Attribute] (
    [AttributeId]     UNIQUEIDENTIFIER NOT NULL,
    [AttributeTypeId] UNIQUEIDENTIFIER NULL,
    [LogicalType]     NVARCHAR (50)    NULL,
    [Name]            NVARCHAR (50)    NULL,
    [PhysicalName]    NVARCHAR (50)    NULL,
    [Length]          INT              NULL,
    [IsNullable]      BIT              NULL,
    [EntityId]        UNIQUEIDENTIFIER NOT NULL,
    [DefaultValue]    NVARCHAR (100)   NULL,
    [ColumnNumber]    INT              NOT NULL,
    [LogicalName]     NVARCHAR (50)    NOT NULL,
    [MaxLength]       INT              NULL,
    [MinValue]        FLOAT (53)       NULL,
    [MaxValue]        FLOAT (53)       NULL,
    [IsAuditEnabled]  BIT              NOT NULL,
    [TableColumnName] NVARCHAR (50)    NULL,
    [OptionSetId]     UNIQUEIDENTIFIER NULL,
    [AppDefaultValue] INT              NULL,
    [IsPKAttribute]   BIT              NULL,
    [IsCopyEnabled]   BIT              NULL,
    [VersionNumber]   ROWVERSION       NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Metadata_Attribute] PRIMARY KEY CLUSTERED ([AttributeId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Metadata_Attribute])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_Metadata_Attribute] ([AttributeId], [AttributeTypeId], [LogicalType], [Name], [PhysicalName], [Length], [IsNullable], [EntityId], [DefaultValue], [ColumnNumber], [LogicalName], [MaxLength], [MinValue], [MaxValue], [IsAuditEnabled], [TableColumnName], [OptionSetId], [AppDefaultValue], [IsPKAttribute], [IsCopyEnabled])
        SELECT   [AttributeId],
                 [AttributeTypeId],
                 [LogicalType],
                 [Name],
                 [PhysicalName],
                 [Length],
                 [IsNullable],
                 [EntityId],
                 [DefaultValue],
                 [ColumnNumber],
                 [LogicalName],
                 [MaxLength],
                 [MinValue],
                 [MaxValue],
                 [IsAuditEnabled],
                 [TableColumnName],
                 [OptionSetId],
                 [AppDefaultValue],
                 [IsPKAttribute],
                 [IsCopyEnabled]
        FROM     [dbo].[Metadata_Attribute]
        ORDER BY [AttributeId] ASC;
        
    END

DROP TABLE [dbo].[Metadata_Attribute];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Metadata_Attribute]', N'Metadata_Attribute';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Metadata_Attribute]', N'PK_Metadata_Attribute', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Metadata_AttributeLookupValue]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Metadata_AttributeLookupValue] (
    [AttributeLookupValueId]   UNIQUEIDENTIFIER NOT NULL,
    [AttributeId]              UNIQUEIDENTIFIER NOT NULL,
    [EntityId]                 UNIQUEIDENTIFIER NOT NULL,
    [DisplayEntityAttributeId] UNIQUEIDENTIFIER NULL,
    [VersionNumber]            ROWVERSION       NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Metadata_AttributeLookupValue] PRIMARY KEY CLUSTERED ([AttributeLookupValueId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Metadata_AttributeLookupValue])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_Metadata_AttributeLookupValue] ([AttributeLookupValueId], [AttributeId], [EntityId], [DisplayEntityAttributeId])
        SELECT   [AttributeLookupValueId],
                 [AttributeId],
                 [EntityId],
                 [DisplayEntityAttributeId]
        FROM     [dbo].[Metadata_AttributeLookupValue]
        ORDER BY [AttributeLookupValueId] ASC;
        
    END

DROP TABLE [dbo].[Metadata_AttributeLookupValue];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Metadata_AttributeLookupValue]', N'Metadata_AttributeLookupValue';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Metadata_AttributeLookupValue]', N'PK_Metadata_AttributeLookupValue', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Metadata_AttributePicklistValue]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Metadata_AttributePicklistValue] (
    [AttributePicklistValueId] UNIQUEIDENTIFIER NOT NULL,
    [Value]                    INT              NULL,
    [DisplayOrder]             INT              NULL,
    [OptionSetId]              UNIQUEIDENTIFIER NOT NULL,
    [VersionNumber]            ROWVERSION       NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Metadata_AttributePicklistValue] PRIMARY KEY CLUSTERED ([AttributePicklistValueId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Metadata_AttributePicklistValue])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId])
        SELECT   [AttributePicklistValueId],
                 [Value],
                 [DisplayOrder],
                 [OptionSetId]
        FROM     [dbo].[Metadata_AttributePicklistValue]
        ORDER BY [AttributePicklistValueId] ASC;
        
    END

DROP TABLE [dbo].[Metadata_AttributePicklistValue];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Metadata_AttributePicklistValue]', N'Metadata_AttributePicklistValue';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Metadata_AttributePicklistValue]', N'PK_Metadata_AttributePicklistValue', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Metadata_AttributePicklistValueMap]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Metadata_AttributePicklistValueMap] (
    [AttributePicklistValueId] UNIQUEIDENTIFIER NOT NULL,
    [MapToValueId]             UNIQUEIDENTIFIER NOT NULL,
    [IsDefault]                BIT              NULL,
    [VersionNumber]            ROWVERSION       NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Metadata_AttributePicklistValueMap] PRIMARY KEY CLUSTERED ([AttributePicklistValueId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Metadata_AttributePicklistValueMap])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_Metadata_AttributePicklistValueMap] ([AttributePicklistValueId], [MapToValueId], [IsDefault])
        SELECT   [AttributePicklistValueId],
                 [MapToValueId],
                 [IsDefault]
        FROM     [dbo].[Metadata_AttributePicklistValueMap]
        ORDER BY [AttributePicklistValueId] ASC;
        
    END

DROP TABLE [dbo].[Metadata_AttributePicklistValueMap];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Metadata_AttributePicklistValueMap]', N'Metadata_AttributePicklistValueMap';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Metadata_AttributePicklistValueMap]', N'PK_Metadata_AttributePicklistValueMap', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Metadata_AttributeType]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Metadata_AttributeType] (
    [AttributeTypeId] UNIQUEIDENTIFIER NOT NULL,
    [Description]     NVARCHAR (255)   NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Metadata_AttributeType] PRIMARY KEY CLUSTERED ([AttributeTypeId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Metadata_AttributeType])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_Metadata_AttributeType] ([AttributeTypeId], [Description])
        SELECT   [AttributeTypeId],
                 [Description]
        FROM     [dbo].[Metadata_AttributeType]
        ORDER BY [AttributeTypeId] ASC;
        
    END

DROP TABLE [dbo].[Metadata_AttributeType];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Metadata_AttributeType]', N'Metadata_AttributeType';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Metadata_AttributeType]', N'PK_Metadata_AttributeType', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Metadata_Entity]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Metadata_Entity] (
    [EntityId]       UNIQUEIDENTIFIER NOT NULL,
    [Name]           NVARCHAR (64)    NULL,
    [PhysicalName]   NVARCHAR (64)    NULL,
    [LogicalName]    NVARCHAR (64)    NULL,
    [TableName]      NVARCHAR (64)    NULL,
    [IsAuditEnabled] BIT              NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Metadata_Entity] PRIMARY KEY CLUSTERED ([EntityId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Metadata_Entity])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_Metadata_Entity] ([EntityId], [Name], [PhysicalName], [LogicalName], [TableName], [IsAuditEnabled])
        SELECT   [EntityId],
                 [Name],
                 [PhysicalName],
                 [LogicalName],
                 [TableName],
                 [IsAuditEnabled]
        FROM     [dbo].[Metadata_Entity]
        ORDER BY [EntityId] ASC;
        
    END

DROP TABLE [dbo].[Metadata_Entity];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Metadata_Entity]', N'Metadata_Entity';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Metadata_Entity]', N'PK_Metadata_Entity', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Metadata_EntityRelationshipRole]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Metadata_EntityRelationshipRole] (
    [EntityRelationshipRoleId] UNIQUEIDENTIFIER NOT NULL,
    [EntityRelationshipId]     UNIQUEIDENTIFIER NOT NULL,
    [EntityId]                 UNIQUEIDENTIFIER NOT NULL,
    [RelationshipRoleType]     TINYINT          NOT NULL,
    [NavPanelDisplayOption]    TINYINT          NULL,
    [NavPaneOrder]             INT              NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Metadata_EntityRelationshipRole] PRIMARY KEY CLUSTERED ([EntityRelationshipRoleId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Metadata_EntityRelationshipRole])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_Metadata_EntityRelationshipRole] ([EntityRelationshipRoleId], [EntityRelationshipId], [EntityId], [RelationshipRoleType], [NavPanelDisplayOption], [NavPaneOrder])
        SELECT   [EntityRelationshipRoleId],
                 [EntityRelationshipId],
                 [EntityId],
                 [RelationshipRoleType],
                 [NavPanelDisplayOption],
                 [NavPaneOrder]
        FROM     [dbo].[Metadata_EntityRelationshipRole]
        ORDER BY [EntityRelationshipRoleId] ASC;
        
    END

DROP TABLE [dbo].[Metadata_EntityRelationshipRole];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Metadata_EntityRelationshipRole]', N'Metadata_EntityRelationshipRole';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Metadata_EntityRelationshipRole]', N'PK_Metadata_EntityRelationshipRole', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Metadata_LocalizedLabel]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Metadata_LocalizedLabel] (
    [LocalizedLabelId] UNIQUEIDENTIFIER NOT NULL,
    [LanguageId]       INT              NOT NULL,
    [ObjectId]         UNIQUEIDENTIFIER NOT NULL,
    [ObjectColumnName] NVARCHAR (128)   NOT NULL,
    [Label]            NVARCHAR (MAX)   NOT NULL,
    [VersionNumber]    ROWVERSION       NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Metadata_LocalizedLabel] PRIMARY KEY CLUSTERED ([LocalizedLabelId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Metadata_LocalizedLabel])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])
        SELECT   [LocalizedLabelId],
                 [LanguageId],
                 [ObjectId],
                 [ObjectColumnName],
                 [Label]
        FROM     [dbo].[Metadata_LocalizedLabel]
        ORDER BY [LocalizedLabelId] ASC;
        
    END

DROP TABLE [dbo].[Metadata_LocalizedLabel];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Metadata_LocalizedLabel]', N'Metadata_LocalizedLabel';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Metadata_LocalizedLabel]', N'PK_Metadata_LocalizedLabel', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Metadata_OptionSet]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Metadata_OptionSet] (
    [OptionSetId]    UNIQUEIDENTIFIER NOT NULL,
    [Name]           NVARCHAR (255)   NOT NULL,
    [IsCustomizable] BIT              NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Metadata_OptionSet] PRIMARY KEY CLUSTERED ([OptionSetId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Metadata_OptionSet])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_Metadata_OptionSet] ([OptionSetId], [Name], [IsCustomizable])
        SELECT   [OptionSetId],
                 [Name],
                 [IsCustomizable]
        FROM     [dbo].[Metadata_OptionSet]
        ORDER BY [OptionSetId] ASC;
        
    END

DROP TABLE [dbo].[Metadata_OptionSet];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Metadata_OptionSet]', N'Metadata_OptionSet';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Metadata_OptionSet]', N'PK_Metadata_OptionSet', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[UserRole]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_UserRole] (
    [Id]     UNIQUEIDENTIFIER NOT NULL,
    [UserId] UNIQUEIDENTIFIER NULL,
    [RoleId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_UserRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[UserRole])
    BEGIN
        
        INSERT INTO [dbo].[tmp_ms_xx_UserRole] ([Id], [UserId], [RoleId])
        SELECT   [Id],
                 [UserId],
                 [RoleId]
        FROM     [dbo].[UserRole]
        ORDER BY [Id] ASC;
        
    END

DROP TABLE [dbo].[UserRole];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_UserRole]', N'UserRole';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_UserRole]', N'PK_UserRole', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[Criteria]...';


GO
CREATE TABLE [dbo].[Criteria] (
    [CriteriaId] UNIQUEIDENTIFIER NOT NULL,
    [Name]       NVARCHAR (200)   NULL,
    CONSTRAINT [PK_Criteria] PRIMARY KEY CLUSTERED ([CriteriaId] ASC)
);


GO
PRINT N'Creating [dbo].[CriteriaNode]...';


GO
CREATE TABLE [dbo].[CriteriaNode] (
    [CriteriaNodeId]     UNIQUEIDENTIFIER NOT NULL,
    [CriteriaId]         UNIQUEIDENTIFIER NOT NULL,
    [ParentNodeId]       UNIQUEIDENTIFIER NOT NULL,
    [Operator]           NVARCHAR (100)   NULL,
    [OperatorType]       NVARCHAR (100)   NULL,
    [CompareAttributeId] UNIQUEIDENTIFIER NULL,
    [CompareValue]       NVARCHAR (100)   NULL,
    CONSTRAINT [PK_CriteriaNode] PRIMARY KEY CLUSTERED ([CriteriaNodeId] ASC)
);


GO
PRINT N'Creating [dbo].[Notification]...';


GO
CREATE TABLE [dbo].[Notification] (
    [NotificationId]   UNIQUEIDENTIFIER NOT NULL,
    [ObjectId]         UNIQUEIDENTIFIER NULL,
    [ObjectType]       NVARCHAR (200)   NULL,
    [Subject]          NVARCHAR (200)   NULL,
    [Body]             NVARCHAR (1000)  NULL,
    [NotificationUrl]  NVARCHAR (200)   NULL,
    [AboutAttributeId] UNIQUEIDENTIFIER NULL,
    [AboutUrl]         NVARCHAR (200)   NULL,
    [CreatedById]      UNIQUEIDENTIFIER NULL,
    [CreatedOn]        DATETIME         NULL,
    [ModifiedById]     UNIQUEIDENTIFIER NULL,
    [ModifiedOn]       DATETIME         NULL,
    [VersionNumber]    ROWVERSION       NOT NULL,
    CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED ([NotificationId] ASC)
);


GO
PRINT N'Creating [dbo].[NotificationProfile]...';


GO
CREATE TABLE [dbo].[NotificationProfile] (
    [NotificationProfileId]  UNIQUEIDENTIFIER NOT NULL,
    [CriteriaId]             UNIQUEIDENTIFIER NULL,
    [NotificationTemplateId] UNIQUEIDENTIFIER NULL,
    [SubjectTemplateId]      UNIQUEIDENTIFIER NULL,
    [IsSys]                  BIT              NULL,
    CONSTRAINT [PK_NotificationProfile] PRIMARY KEY CLUSTERED ([NotificationProfileId] ASC)
);


GO
PRINT N'Creating [dbo].[NotificationRecipient]...';


GO
CREATE TABLE [dbo].[NotificationRecipient] (
    [NotificationRecipientId] UNIQUEIDENTIFIER NOT NULL,
    [NotificationId]          UNIQUEIDENTIFIER NULL,
    [RecipientId]             UNIQUEIDENTIFIER NULL,
    [NotificationStatus]      NVARCHAR (50)    NULL,
    [ReadedOn]                DATETIME         NULL,
    CONSTRAINT [PK_NotificationRecipient] PRIMARY KEY CLUSTERED ([NotificationRecipientId] ASC)
);


GO
PRINT N'Creating [dbo].[NotificationRecipientAttributes]...';


GO
CREATE TABLE [dbo].[NotificationRecipientAttributes] (
    [NotificationRecipientAttributeId] UNIQUEIDENTIFIER NOT NULL,
    [RecipientEntityId]                UNIQUEIDENTIFIER NULL,
    [AttributeId]                      UNIQUEIDENTIFIER NULL,
    [NotificationProfileId]            UNIQUEIDENTIFIER NULL,
    [CriteriaId]                       UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_NotificationRecipientAttributes] PRIMARY KEY CLUSTERED ([NotificationRecipientAttributeId] ASC)
);


GO
PRINT N'Creating [dbo].[NotificationTemplate]...';


GO
CREATE TABLE [dbo].[NotificationTemplate] (
    [NotificationTemplateId] UNIQUEIDENTIFIER NOT NULL,
    [SubjectTemplate]        NVARCHAR (1000)  NULL,
    CONSTRAINT [PK_NotificationTemplate] PRIMARY KEY CLUSTERED ([NotificationTemplateId] ASC)
);


GO
PRINT N'Creating [dbo].[NotificationVariable]...';


GO
CREATE TABLE [dbo].[NotificationVariable] (
    [NotificationVariableId] UNIQUEIDENTIFIER NOT NULL,
    [ParentId]               UNIQUEIDENTIFIER NULL,
    [RelatedAttributeId]     UNIQUEIDENTIFIER NULL,
    [EntityId]               UNIQUEIDENTIFIER NULL,
    [Name]                   NVARCHAR (200)   NULL,
    [NotificationUrl]        NVARCHAR (200)   NULL,
    CONSTRAINT [PK_NotificationVariable] PRIMARY KEY CLUSTERED ([NotificationVariableId] ASC)
);


GO
PRINT N'Creating [dbo].[ProfileVariable]...';


GO
CREATE TABLE [dbo].[ProfileVariable] (
    [ProfileVariableId]      UNIQUEIDENTIFIER NOT NULL,
    [NotificationProfileId]  UNIQUEIDENTIFIER NULL,
    [NotificationVariableId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_ProfileVariable] PRIMARY KEY CLUSTERED ([ProfileVariableId] ASC)
);


GO
PRINT N'Creating [dbo].[Subscription]...';


GO
CREATE TABLE [dbo].[Subscription] (
    [SubscriptionId]        UNIQUEIDENTIFIER NOT NULL,
    [UserId]                UNIQUEIDENTIFIER NULL,
    [NotificationProfileId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED ([SubscriptionId] ASC)
);


GO
PRINT N'Creating DF_TaskTimeHistory_IsDeleted...';


GO
ALTER TABLE [dbo].[TaskTimeHistory]
    ADD CONSTRAINT [DF_TaskTimeHistory_IsDeleted] DEFAULT ((0)) FOR [IsDeleted];


GO
PRINT N'Creating FK_Attendance_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[Attendance] WITH NOCHECK
    ADD CONSTRAINT [FK_Attendance_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Attendance_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[Attendance] WITH NOCHECK
    ADD CONSTRAINT [FK_Attendance_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Attendance_RecordPersonId_User_UserId...';


GO
ALTER TABLE [dbo].[Attendance] WITH NOCHECK
    ADD CONSTRAINT [FK_Attendance_RecordPersonId_User_UserId] FOREIGN KEY ([RecordPersonId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Metadata_Attribute_AttributeTypeId_Metadata_AttributeType_AttributeTypeId...';


GO
ALTER TABLE [dbo].[Metadata_Attribute] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_Attribute_AttributeTypeId_Metadata_AttributeType_AttributeTypeId] FOREIGN KEY ([AttributeTypeId]) REFERENCES [dbo].[Metadata_AttributeType] ([AttributeTypeId]);


GO
PRINT N'Creating FK_Metadata_Attribute_EntityId_Metadata_Entity_EntityId...';


GO
ALTER TABLE [dbo].[Metadata_Attribute] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_Attribute_EntityId_Metadata_Entity_EntityId] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]);


GO
PRINT N'Creating FK_Metadata_Attribute_OptionSetId_Metadata_OptionSet_OptionSetId...';


GO
ALTER TABLE [dbo].[Metadata_Attribute] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_Attribute_OptionSetId_Metadata_OptionSet_OptionSetId] FOREIGN KEY ([OptionSetId]) REFERENCES [dbo].[Metadata_OptionSet] ([OptionSetId]);


GO
PRINT N'Creating FK_Metadata_AttributeLookupValue_EntityId_Metadata_Entity_EntityId...';


GO
ALTER TABLE [dbo].[Metadata_AttributeLookupValue] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_AttributeLookupValue_EntityId_Metadata_Entity_EntityId] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]);


GO
PRINT N'Creating FK_Metadata_AttributeLookupValue_AttributeId_Metadata_Attribute_AttributeId...';


GO
ALTER TABLE [dbo].[Metadata_AttributeLookupValue] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_AttributeLookupValue_AttributeId_Metadata_Attribute_AttributeId] FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[Metadata_Attribute] ([AttributeId]);


GO
PRINT N'Creating FK_Metadata_AttributePicklistValue_OptionSetId_Metadata_OptionSet_OptionSetId...';


GO
ALTER TABLE [dbo].[Metadata_AttributePicklistValue] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_AttributePicklistValue_OptionSetId_Metadata_OptionSet_OptionSetId] FOREIGN KEY ([OptionSetId]) REFERENCES [dbo].[Metadata_OptionSet] ([OptionSetId]);


GO
PRINT N'Creating FK_Metadata_AttributePicklistValueMap_AttributePicklistValueId_Metadata_AttributePicklistValue_AttributePicklistValueId...';


GO
ALTER TABLE [dbo].[Metadata_AttributePicklistValueMap] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_AttributePicklistValueMap_AttributePicklistValueId_Metadata_AttributePicklistValue_AttributePicklistValueId] FOREIGN KEY ([AttributePicklistValueId]) REFERENCES [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId]);


GO
PRINT N'Creating FK_Metadata_AttributePicklistValueMap_MapToValueId_Metadata_AttributePicklistValue_AttributePicklistValueId...';


GO
ALTER TABLE [dbo].[Metadata_AttributePicklistValueMap] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_AttributePicklistValueMap_MapToValueId_Metadata_AttributePicklistValue_AttributePicklistValueId] FOREIGN KEY ([MapToValueId]) REFERENCES [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId]);


GO
PRINT N'Creating FK_Metadata_EntityRelationshipRole_EntityRelationshipId_Metadata_EntityRelationship_EntityRelationshipId...';


GO
ALTER TABLE [dbo].[Metadata_EntityRelationshipRole] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_EntityRelationshipRole_EntityRelationshipId_Metadata_EntityRelationship_EntityRelationshipId] FOREIGN KEY ([EntityRelationshipId]) REFERENCES [dbo].[Metadata_EntityRelationship] ([EntityRelationshipId]);


GO
PRINT N'Creating FK_Metadata_EntityRelationshipRole_EntityId_Metadata_Entity_EntityId...';


GO
ALTER TABLE [dbo].[Metadata_EntityRelationshipRole] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_EntityRelationshipRole_EntityId_Metadata_Entity_EntityId] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]);


GO
PRINT N'Creating FK_UserRole_RoleId_Role_RoleId...';


GO
ALTER TABLE [dbo].[UserRole] WITH NOCHECK
    ADD CONSTRAINT [FK_UserRole_RoleId_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]);


GO
PRINT N'Creating FK_UserRole_UserId_User_UserId...';


GO
ALTER TABLE [dbo].[UserRole] WITH NOCHECK
    ADD CONSTRAINT [FK_UserRole_UserId_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_CriteriaNode_CompareAttributeId_Metadata_Attribute_AttributeId...';


GO
ALTER TABLE [dbo].[CriteriaNode] WITH NOCHECK
    ADD CONSTRAINT [FK_CriteriaNode_CompareAttributeId_Metadata_Attribute_AttributeId] FOREIGN KEY ([CompareAttributeId]) REFERENCES [dbo].[Metadata_Attribute] ([AttributeId]);


GO
PRINT N'Creating FK_CriteriaNode_CriteriaId_Criteria_CriteriaId...';


GO
ALTER TABLE [dbo].[CriteriaNode] WITH NOCHECK
    ADD CONSTRAINT [FK_CriteriaNode_CriteriaId_Criteria_CriteriaId] FOREIGN KEY ([CriteriaId]) REFERENCES [dbo].[Criteria] ([CriteriaId]);


GO
PRINT N'Creating FK_Notification_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[Notification] WITH NOCHECK
    ADD CONSTRAINT [FK_Notification_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Notification_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[Notification] WITH NOCHECK
    ADD CONSTRAINT [FK_Notification_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_NotificationProfile_CriteriaId_Criteria_CriteriaId...';


GO
ALTER TABLE [dbo].[NotificationProfile] WITH NOCHECK
    ADD CONSTRAINT [FK_NotificationProfile_CriteriaId_Criteria_CriteriaId] FOREIGN KEY ([CriteriaId]) REFERENCES [dbo].[Criteria] ([CriteriaId]);


GO
PRINT N'Creating FK_NotificationProfile_NotificationTemplateId_NotificationTemplate_NotificationTemplateId...';


GO
ALTER TABLE [dbo].[NotificationProfile] WITH NOCHECK
    ADD CONSTRAINT [FK_NotificationProfile_NotificationTemplateId_NotificationTemplate_NotificationTemplateId] FOREIGN KEY ([NotificationTemplateId]) REFERENCES [dbo].[NotificationTemplate] ([NotificationTemplateId]);


GO
PRINT N'Creating FK_NotificationProfile_SubjectTemplateId_NotificationTemplate_NotificationTemplateId...';


GO
ALTER TABLE [dbo].[NotificationProfile] WITH NOCHECK
    ADD CONSTRAINT [FK_NotificationProfile_SubjectTemplateId_NotificationTemplate_NotificationTemplateId] FOREIGN KEY ([SubjectTemplateId]) REFERENCES [dbo].[NotificationTemplate] ([NotificationTemplateId]);


GO
PRINT N'Creating FK_NotificationRecipient_NotificationId_Notification_NotificationId...';


GO
ALTER TABLE [dbo].[NotificationRecipient] WITH NOCHECK
    ADD CONSTRAINT [FK_NotificationRecipient_NotificationId_Notification_NotificationId] FOREIGN KEY ([NotificationId]) REFERENCES [dbo].[Notification] ([NotificationId]);


GO
PRINT N'Creating FK_NotificationRecipient_RecipientId_User_UserId...';


GO
ALTER TABLE [dbo].[NotificationRecipient] WITH NOCHECK
    ADD CONSTRAINT [FK_NotificationRecipient_RecipientId_User_UserId] FOREIGN KEY ([RecipientId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_NotificationRecipientAttributes_AttributeId_Metadata_Attribute_AttributeId...';


GO
ALTER TABLE [dbo].[NotificationRecipientAttributes] WITH NOCHECK
    ADD CONSTRAINT [FK_NotificationRecipientAttributes_AttributeId_Metadata_Attribute_AttributeId] FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[Metadata_Attribute] ([AttributeId]);


GO
PRINT N'Creating FK_NotificationRecipientAttributes_CriteriaId_Criteria_CriteriaId...';


GO
ALTER TABLE [dbo].[NotificationRecipientAttributes] WITH NOCHECK
    ADD CONSTRAINT [FK_NotificationRecipientAttributes_CriteriaId_Criteria_CriteriaId] FOREIGN KEY ([CriteriaId]) REFERENCES [dbo].[Criteria] ([CriteriaId]);


GO
PRINT N'Creating FK_NotificationRecipientAttributes_RecipientEntityId_Metadata_Entity_EntityId...';


GO
ALTER TABLE [dbo].[NotificationRecipientAttributes] WITH NOCHECK
    ADD CONSTRAINT [FK_NotificationRecipientAttributes_RecipientEntityId_Metadata_Entity_EntityId] FOREIGN KEY ([RecipientEntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]);


GO
PRINT N'Creating FK_NotificationRecipientAttributes_NotificationProfileId_NotificationProfile_NotificationProfileId...';


GO
ALTER TABLE [dbo].[NotificationRecipientAttributes] WITH NOCHECK
    ADD CONSTRAINT [FK_NotificationRecipientAttributes_NotificationProfileId_NotificationProfile_NotificationProfileId] FOREIGN KEY ([NotificationProfileId]) REFERENCES [dbo].[NotificationProfile] ([NotificationProfileId]);


GO
PRINT N'Creating FK_NotificationVariable_RelatedAttributeId_Metadata_Attribute_AttributeId...';


GO
ALTER TABLE [dbo].[NotificationVariable] WITH NOCHECK
    ADD CONSTRAINT [FK_NotificationVariable_RelatedAttributeId_Metadata_Attribute_AttributeId] FOREIGN KEY ([RelatedAttributeId]) REFERENCES [dbo].[Metadata_Attribute] ([AttributeId]);


GO
PRINT N'Creating FK_NotificationVariable_EntityId_Metadata_Entity_EntityId...';


GO
ALTER TABLE [dbo].[NotificationVariable] WITH NOCHECK
    ADD CONSTRAINT [FK_NotificationVariable_EntityId_Metadata_Entity_EntityId] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]);


GO
PRINT N'Creating FK_ProfileVariable_NotificationProfileId_NotificationProfile_NotificationProfileId...';


GO
ALTER TABLE [dbo].[ProfileVariable] WITH NOCHECK
    ADD CONSTRAINT [FK_ProfileVariable_NotificationProfileId_NotificationProfile_NotificationProfileId] FOREIGN KEY ([NotificationProfileId]) REFERENCES [dbo].[NotificationProfile] ([NotificationProfileId]);


GO
PRINT N'Creating FK_ProfileVariable_NotificationVariableId_NotificationVariable_NotificationVariableId...';


GO
ALTER TABLE [dbo].[ProfileVariable] WITH NOCHECK
    ADD CONSTRAINT [FK_ProfileVariable_NotificationVariableId_NotificationVariable_NotificationVariableId] FOREIGN KEY ([NotificationVariableId]) REFERENCES [dbo].[NotificationVariable] ([NotificationVariableId]);


GO
PRINT N'Creating FK_Subscription_NotificationProfileId_NotificationProfile_NotificationProfileId...';


GO
ALTER TABLE [dbo].[Subscription] WITH NOCHECK
    ADD CONSTRAINT [FK_Subscription_NotificationProfileId_NotificationProfile_NotificationProfileId] FOREIGN KEY ([NotificationProfileId]) REFERENCES [dbo].[NotificationProfile] ([NotificationProfileId]);


GO
PRINT N'Creating FK_Subscription_UserId_User_UserId...';


GO
ALTER TABLE [dbo].[Subscription] WITH NOCHECK
    ADD CONSTRAINT [FK_Subscription_UserId_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Account_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[Account] WITH NOCHECK
    ADD CONSTRAINT [FK_Account_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Account_DepartmentId_Department_DepartmentId...';


GO
ALTER TABLE [dbo].[Account] WITH NOCHECK
    ADD CONSTRAINT [FK_Account_DepartmentId_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([DepartmentId]);


GO
PRINT N'Creating FK_Account_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[Account] WITH NOCHECK
    ADD CONSTRAINT [FK_Account_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Account_OriginatingLeadId_Lead_LeadId...';


GO
ALTER TABLE [dbo].[Account] WITH NOCHECK
    ADD CONSTRAINT [FK_Account_OriginatingLeadId_Lead_LeadId] FOREIGN KEY ([OriginatingLeadId]) REFERENCES [dbo].[Lead] ([LeadId]);


GO
PRINT N'Creating FK_Account_OwnerId_User_UserId...';


GO
ALTER TABLE [dbo].[Account] WITH NOCHECK
    ADD CONSTRAINT [FK_Account_OwnerId_User_UserId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Account_PrimaryContactId_Contact_ContactId...';


GO
ALTER TABLE [dbo].[Account] WITH NOCHECK
    ADD CONSTRAINT [FK_Account_PrimaryContactId_Contact_ContactId] FOREIGN KEY ([PrimaryContactId]) REFERENCES [dbo].[Contact] ([ContactId]);


GO
PRINT N'Creating FK_AttentionInfomation_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[AttentionInfomation] WITH NOCHECK
    ADD CONSTRAINT [FK_AttentionInfomation_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_AttentionInfomation_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[AttentionInfomation] WITH NOCHECK
    ADD CONSTRAINT [FK_AttentionInfomation_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_AttentionMember_AttentionInfoId_AttentionInfomation_AttentionInfoId...';


GO
ALTER TABLE [dbo].[AttentionMember] WITH NOCHECK
    ADD CONSTRAINT [FK_AttentionMember_AttentionInfoId_AttentionInfomation_AttentionInfoId] FOREIGN KEY ([AttentionInfoId]) REFERENCES [dbo].[AttentionInfomation] ([AttentionInfoId]);


GO
PRINT N'Creating FK_AttentionMember_AttentionUserId_User_UserId...';


GO
ALTER TABLE [dbo].[AttentionMember] WITH NOCHECK
    ADD CONSTRAINT [FK_AttentionMember_AttentionUserId_User_UserId] FOREIGN KEY ([AttentionUserId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_ColumnMapping_ImportMapId_ImportMap_ImportMapId...';


GO
ALTER TABLE [dbo].[ColumnMapping] WITH NOCHECK
    ADD CONSTRAINT [FK_ColumnMapping_ImportMapId_ImportMap_ImportMapId] FOREIGN KEY ([ImportMapId]) REFERENCES [dbo].[ImportMap] ([ImportMapId]);


GO
PRINT N'Creating FK_Contact_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[Contact] WITH NOCHECK
    ADD CONSTRAINT [FK_Contact_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Contact_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[Contact] WITH NOCHECK
    ADD CONSTRAINT [FK_Contact_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Contact_OriginatingLeadId_Lead_LeadId...';


GO
ALTER TABLE [dbo].[Contact] WITH NOCHECK
    ADD CONSTRAINT [FK_Contact_OriginatingLeadId_Lead_LeadId] FOREIGN KEY ([OriginatingLeadId]) REFERENCES [dbo].[Lead] ([LeadId]);


GO
PRINT N'Creating FK_Contact_OwnerId_User_UserId...';


GO
ALTER TABLE [dbo].[Contact] WITH NOCHECK
    ADD CONSTRAINT [FK_Contact_OwnerId_User_UserId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Contract_BillingCustomerId_Account_AccountId...';


GO
ALTER TABLE [dbo].[Contract] WITH NOCHECK
    ADD CONSTRAINT [FK_Contract_BillingCustomerId_Account_AccountId] FOREIGN KEY ([BillingCustomerId]) REFERENCES [dbo].[Account] ([AccountId]);


GO
PRINT N'Creating FK_Contract_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[Contract] WITH NOCHECK
    ADD CONSTRAINT [FK_Contract_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Contract_DepartmentId_Department_DepartmentId...';


GO
ALTER TABLE [dbo].[Contract] WITH NOCHECK
    ADD CONSTRAINT [FK_Contract_DepartmentId_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([DepartmentId]);


GO
PRINT N'Creating FK_Contract_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[Contract] WITH NOCHECK
    ADD CONSTRAINT [FK_Contract_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Contract_OpportunityId_Opportunity_OpportunityId...';


GO
ALTER TABLE [dbo].[Contract] WITH NOCHECK
    ADD CONSTRAINT [FK_Contract_OpportunityId_Opportunity_OpportunityId] FOREIGN KEY ([OpportunityId]) REFERENCES [dbo].[Opportunity] ([OpportunityId]);


GO
PRINT N'Creating FK_Contract_OwnerId_User_UserId...';


GO
ALTER TABLE [dbo].[Contract] WITH NOCHECK
    ADD CONSTRAINT [FK_Contract_OwnerId_User_UserId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Contract_TransactionCurrencyId_TransactionCurrency_TransactionCurrencyId...';


GO
ALTER TABLE [dbo].[Contract] WITH NOCHECK
    ADD CONSTRAINT [FK_Contract_TransactionCurrencyId_TransactionCurrency_TransactionCurrencyId] FOREIGN KEY ([TransactionCurrencyId]) REFERENCES [dbo].[TransactionCurrency] ([TransactionCurrencyId]);


GO
PRINT N'Creating FK_ImportEntityMapping_ImportMapId_ImportMap_ImportMapId...';


GO
ALTER TABLE [dbo].[ImportEntityMapping] WITH NOCHECK
    ADD CONSTRAINT [FK_ImportEntityMapping_ImportMapId_ImportMap_ImportMapId] FOREIGN KEY ([ImportMapId]) REFERENCES [dbo].[ImportMap] ([ImportMapId]);


GO
PRINT N'Creating FK_Invoice_BillingCustomerId_Account_AccountId...';


GO
ALTER TABLE [dbo].[Invoice] WITH NOCHECK
    ADD CONSTRAINT [FK_Invoice_BillingCustomerId_Account_AccountId] FOREIGN KEY ([BillingCustomerId]) REFERENCES [dbo].[Account] ([AccountId]);


GO
PRINT N'Creating FK_Invoice_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[Invoice] WITH NOCHECK
    ADD CONSTRAINT [FK_Invoice_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Invoice_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[Invoice] WITH NOCHECK
    ADD CONSTRAINT [FK_Invoice_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Invoice_OwnerId_User_UserId...';


GO
ALTER TABLE [dbo].[Invoice] WITH NOCHECK
    ADD CONSTRAINT [FK_Invoice_OwnerId_User_UserId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Invoice_TransactionCurrencyId_TransactionCurrency_TransactionCurrencyId...';


GO
ALTER TABLE [dbo].[Invoice] WITH NOCHECK
    ADD CONSTRAINT [FK_Invoice_TransactionCurrencyId_TransactionCurrency_TransactionCurrencyId] FOREIGN KEY ([TransactionCurrencyId]) REFERENCES [dbo].[TransactionCurrency] ([TransactionCurrencyId]);


GO
PRINT N'Creating FK_InvoiceContract_ContractId_Contract_ContractId...';


GO
ALTER TABLE [dbo].[InvoiceContract] WITH NOCHECK
    ADD CONSTRAINT [FK_InvoiceContract_ContractId_Contract_ContractId] FOREIGN KEY ([ContractId]) REFERENCES [dbo].[Contract] ([ContractId]);


GO
PRINT N'Creating FK_InvoiceContract_InvoiceId_Invoice_InvoiceId...';


GO
ALTER TABLE [dbo].[InvoiceContract] WITH NOCHECK
    ADD CONSTRAINT [FK_InvoiceContract_InvoiceId_Invoice_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice] ([InvoiceId]);


GO
PRINT N'Creating FK_Lead_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[Lead] WITH NOCHECK
    ADD CONSTRAINT [FK_Lead_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Lead_DepartmentId_Department_DepartmentId...';


GO
ALTER TABLE [dbo].[Lead] WITH NOCHECK
    ADD CONSTRAINT [FK_Lead_DepartmentId_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([DepartmentId]);


GO
PRINT N'Creating FK_Lead_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[Lead] WITH NOCHECK
    ADD CONSTRAINT [FK_Lead_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Lead_OwnerId_User_UserId...';


GO
ALTER TABLE [dbo].[Lead] WITH NOCHECK
    ADD CONSTRAINT [FK_Lead_OwnerId_User_UserId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_LookupMapping_ColumnMappingId_ColumnMapping_ColumnMappingId...';


GO
ALTER TABLE [dbo].[LookupMapping] WITH NOCHECK
    ADD CONSTRAINT [FK_LookupMapping_ColumnMappingId_ColumnMapping_ColumnMappingId] FOREIGN KEY ([ColumnMappingId]) REFERENCES [dbo].[ColumnMapping] ([ColumnMappingId]);


GO
PRINT N'Creating FK_Metadata_AttentionConfig_AboutAttributeId_Metadata_Attribute_AttributeId...';


GO
ALTER TABLE [dbo].[Metadata_AttentionConfig] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_AttentionConfig_AboutAttributeId_Metadata_Attribute_AttributeId] FOREIGN KEY ([AboutAttributeId]) REFERENCES [dbo].[Metadata_Attribute] ([AttributeId]);


GO
PRINT N'Creating FK_Metadata_AttentionConfig_AboutEntityId_Metadata_Entity_EntityId...';


GO
ALTER TABLE [dbo].[Metadata_AttentionConfig] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_AttentionConfig_AboutEntityId_Metadata_Entity_EntityId] FOREIGN KEY ([AboutEntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]);


GO
PRINT N'Creating FK_Metadata_AttentionConfig_AttentionEntityId_Metadata_Entity_EntityId...';


GO
ALTER TABLE [dbo].[Metadata_AttentionConfig] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_AttentionConfig_AttentionEntityId_Metadata_Entity_EntityId] FOREIGN KEY ([AttentionEntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]);


GO
PRINT N'Creating FK_Metadata_AttentionMemberConfig_AttentionConfigId_Metadata_AttentionConfig_AttentionConfigId...';


GO
ALTER TABLE [dbo].[Metadata_AttentionMemberConfig] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_AttentionMemberConfig_AttentionConfigId_Metadata_AttentionConfig_AttentionConfigId] FOREIGN KEY ([AttentionConfigId]) REFERENCES [dbo].[Metadata_AttentionConfig] ([AttentionConfigId]);


GO
PRINT N'Creating FK_Metadata_AttentionMemberConfig_MemberAttributeId_Metadata_Attribute_AttributeId...';


GO
ALTER TABLE [dbo].[Metadata_AttentionMemberConfig] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_AttentionMemberConfig_MemberAttributeId_Metadata_Attribute_AttributeId] FOREIGN KEY ([MemberAttributeId]) REFERENCES [dbo].[Metadata_Attribute] ([AttributeId]);


GO
PRINT N'Creating FK_Metadata_AttentionMemberConfig_MemberEntityId_Metadata_Entity_EntityId...';


GO
ALTER TABLE [dbo].[Metadata_AttentionMemberConfig] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_AttentionMemberConfig_MemberEntityId_Metadata_Entity_EntityId] FOREIGN KEY ([MemberEntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]);


GO
PRINT N'Creating FK_Metadata_EntityRelationshipRelationships_EntityRelationshipId_Metadata_EntityRelationship_EntityRelationshipId...';


GO
ALTER TABLE [dbo].[Metadata_EntityRelationshipRelationships] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_EntityRelationshipRelationships_EntityRelationshipId_Metadata_EntityRelationship_EntityRelationshipId] FOREIGN KEY ([EntityRelationshipId]) REFERENCES [dbo].[Metadata_EntityRelationship] ([EntityRelationshipId]);


GO
PRINT N'Creating FK_Metadata_EntityRelationshipRelationships_RelationshipId_Metadata_Relationship_RelationshipId...';


GO
ALTER TABLE [dbo].[Metadata_EntityRelationshipRelationships] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_EntityRelationshipRelationships_RelationshipId_Metadata_Relationship_RelationshipId] FOREIGN KEY ([RelationshipId]) REFERENCES [dbo].[Metadata_Relationship] ([RelationshipId]);


GO
PRINT N'Creating FK_Metadata_FilterConditionDetail_CompareAttributeId_Metadata_Attribute_AttributeId...';


GO
ALTER TABLE [dbo].[Metadata_FilterConditionDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_FilterConditionDetail_CompareAttributeId_Metadata_Attribute_AttributeId] FOREIGN KEY ([CompareAttributeId]) REFERENCES [dbo].[Metadata_Attribute] ([AttributeId]);


GO
PRINT N'Creating FK_Metadata_FilterConditionDetail_FilterConditionId_Metadata_FilterConditon_FilterConditionId...';


GO
ALTER TABLE [dbo].[Metadata_FilterConditionDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_FilterConditionDetail_FilterConditionId_Metadata_FilterConditon_FilterConditionId] FOREIGN KEY ([FilterConditionId]) REFERENCES [dbo].[Metadata_FilterConditon] ([FilterConditionId]);


GO
PRINT N'Creating FK_Metadata_Relationship_ReferencedAttributeId_Metadata_Attribute_AttributeId...';


GO
ALTER TABLE [dbo].[Metadata_Relationship] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_Relationship_ReferencedAttributeId_Metadata_Attribute_AttributeId] FOREIGN KEY ([ReferencedAttributeId]) REFERENCES [dbo].[Metadata_Attribute] ([AttributeId]);


GO
PRINT N'Creating FK_Metadata_Relationship_ReferencedEntityId_Metadata_Entity_EntityId...';


GO
ALTER TABLE [dbo].[Metadata_Relationship] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_Relationship_ReferencedEntityId_Metadata_Entity_EntityId] FOREIGN KEY ([ReferencedEntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]);


GO
PRINT N'Creating FK_Metadata_Relationship_ReferencingAttributeId_Metadata_Attribute_AttributeId...';


GO
ALTER TABLE [dbo].[Metadata_Relationship] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_Relationship_ReferencingAttributeId_Metadata_Attribute_AttributeId] FOREIGN KEY ([ReferencingAttributeId]) REFERENCES [dbo].[Metadata_Attribute] ([AttributeId]);


GO
PRINT N'Creating FK_Metadata_Relationship_ReferencingEntityId_Metadata_Entity_EntityId...';


GO
ALTER TABLE [dbo].[Metadata_Relationship] WITH NOCHECK
    ADD CONSTRAINT [FK_Metadata_Relationship_ReferencingEntityId_Metadata_Entity_EntityId] FOREIGN KEY ([ReferencingEntityId]) REFERENCES [dbo].[Metadata_Entity] ([EntityId]);


GO
PRINT N'Creating FK_Note_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[Note] WITH NOCHECK
    ADD CONSTRAINT [FK_Note_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Note_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[Note] WITH NOCHECK
    ADD CONSTRAINT [FK_Note_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Opportunity_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[Opportunity] WITH NOCHECK
    ADD CONSTRAINT [FK_Opportunity_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Opportunity_DepartmentId_Department_DepartmentId...';


GO
ALTER TABLE [dbo].[Opportunity] WITH NOCHECK
    ADD CONSTRAINT [FK_Opportunity_DepartmentId_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([DepartmentId]);


GO
PRINT N'Creating FK_Opportunity_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[Opportunity] WITH NOCHECK
    ADD CONSTRAINT [FK_Opportunity_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Opportunity_OriginatingLeadId_Lead_LeadId...';


GO
ALTER TABLE [dbo].[Opportunity] WITH NOCHECK
    ADD CONSTRAINT [FK_Opportunity_OriginatingLeadId_Lead_LeadId] FOREIGN KEY ([OriginatingLeadId]) REFERENCES [dbo].[Lead] ([LeadId]);


GO
PRINT N'Creating FK_Opportunity_OwnerId_User_UserId...';


GO
ALTER TABLE [dbo].[Opportunity] WITH NOCHECK
    ADD CONSTRAINT [FK_Opportunity_OwnerId_User_UserId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Opportunity_TechnicianId_User_UserId...';


GO
ALTER TABLE [dbo].[Opportunity] WITH NOCHECK
    ADD CONSTRAINT [FK_Opportunity_TechnicianId_User_UserId] FOREIGN KEY ([TechnicianId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Opportunity_TransactionCurrencyId_TransactionCurrency_TransactionCurrencyId...';


GO
ALTER TABLE [dbo].[Opportunity] WITH NOCHECK
    ADD CONSTRAINT [FK_Opportunity_TransactionCurrencyId_TransactionCurrency_TransactionCurrencyId] FOREIGN KEY ([TransactionCurrencyId]) REFERENCES [dbo].[TransactionCurrency] ([TransactionCurrencyId]);


GO
PRINT N'Creating FK_PickListMapping_ColumnMappingId_ColumnMapping_ColumnMappingId...';


GO
ALTER TABLE [dbo].[PickListMapping] WITH NOCHECK
    ADD CONSTRAINT [FK_PickListMapping_ColumnMappingId_ColumnMapping_ColumnMappingId] FOREIGN KEY ([ColumnMappingId]) REFERENCES [dbo].[ColumnMapping] ([ColumnMappingId]);


GO
PRINT N'Creating FK_PrivilegeEntity_PrivilegeId_Privilege_PrivilegeId...';


GO
ALTER TABLE [dbo].[PrivilegeEntity] WITH NOCHECK
    ADD CONSTRAINT [FK_PrivilegeEntity_PrivilegeId_Privilege_PrivilegeId] FOREIGN KEY ([PrivilegeId]) REFERENCES [dbo].[Privilege] ([PrivilegeId]);


GO
PRINT N'Creating FK_Product_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[Product] WITH NOCHECK
    ADD CONSTRAINT [FK_Product_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Product_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[Product] WITH NOCHECK
    ADD CONSTRAINT [FK_Product_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Project_ContractId_Contract_ContractId...';


GO
ALTER TABLE [dbo].[Project] WITH NOCHECK
    ADD CONSTRAINT [FK_Project_ContractId_Contract_ContractId] FOREIGN KEY ([ContractId]) REFERENCES [dbo].[Contract] ([ContractId]);


GO
PRINT N'Creating FK_Project_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[Project] WITH NOCHECK
    ADD CONSTRAINT [FK_Project_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Project_ManagerId_User_UserId...';


GO
ALTER TABLE [dbo].[Project] WITH NOCHECK
    ADD CONSTRAINT [FK_Project_ManagerId_User_UserId] FOREIGN KEY ([ManagerId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Project_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[Project] WITH NOCHECK
    ADD CONSTRAINT [FK_Project_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Project_SaleServiceId_User_UserId...';


GO
ALTER TABLE [dbo].[Project] WITH NOCHECK
    ADD CONSTRAINT [FK_Project_SaleServiceId_User_UserId] FOREIGN KEY ([SaleServiceId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_ProjectIteration_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[ProjectIteration] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectIteration_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_ProjectIteration_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[ProjectIteration] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectIteration_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_ProjectIteration_ProjectId_Project_ProjectId...';


GO
ALTER TABLE [dbo].[ProjectIteration] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectIteration_ProjectId_Project_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([ProjectId]);


GO
PRINT N'Creating FK_ProjectIteration_ProjectVersionId_ProjectVersion_ProjectVersionId...';


GO
ALTER TABLE [dbo].[ProjectIteration] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectIteration_ProjectVersionId_ProjectVersion_ProjectVersionId] FOREIGN KEY ([ProjectVersionId]) REFERENCES [dbo].[ProjectVersion] ([ProjectVersionId]);


GO
PRINT N'Creating FK_ProjectMember_MemberId_User_UserId...';


GO
ALTER TABLE [dbo].[ProjectMember] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectMember_MemberId_User_UserId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_ProjectMember_ProjectId_Project_ProjectId...';


GO
ALTER TABLE [dbo].[ProjectMember] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectMember_ProjectId_Project_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([ProjectId]);


GO
PRINT N'Creating FK_ProjectTask_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[ProjectTask] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectTask_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_ProjectTask_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[ProjectTask] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectTask_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_ProjectTask_OwnerId_User_UserId...';


GO
ALTER TABLE [dbo].[ProjectTask] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectTask_OwnerId_User_UserId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_ProjectTask_ProjectId_Project_ProjectId...';


GO
ALTER TABLE [dbo].[ProjectTask] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectTask_ProjectId_Project_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([ProjectId]);


GO
PRINT N'Creating FK_ProjectTask_ProjectIterationId_ProjectIteration_ProjectIterationId...';


GO
ALTER TABLE [dbo].[ProjectTask] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectTask_ProjectIterationId_ProjectIteration_ProjectIterationId] FOREIGN KEY ([ProjectIterationId]) REFERENCES [dbo].[ProjectIteration] ([ProjectIterationId]);


GO
PRINT N'Creating FK_ProjectVersion_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[ProjectVersion] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectVersion_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_ProjectVersion_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[ProjectVersion] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectVersion_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_ProjectVersion_ProjectId_Project_ProjectId...';


GO
ALTER TABLE [dbo].[ProjectVersion] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectVersion_ProjectId_Project_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([ProjectId]);


GO
PRINT N'Creating FK_ProjectWeekReport_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[ProjectWeekReport] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectWeekReport_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_ProjectWeekReport_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[ProjectWeekReport] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectWeekReport_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_ProjectWeekReport_ProjectId_Project_ProjectId...';


GO
ALTER TABLE [dbo].[ProjectWeekReport] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectWeekReport_ProjectId_Project_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([ProjectId]);


GO
PRINT N'Creating FK_ProjectWeekReport_ProjectIterationId_ProjectIteration_ProjectIterationId...';


GO
ALTER TABLE [dbo].[ProjectWeekReport] WITH NOCHECK
    ADD CONSTRAINT [FK_ProjectWeekReport_ProjectIterationId_ProjectIteration_ProjectIterationId] FOREIGN KEY ([ProjectIterationId]) REFERENCES [dbo].[ProjectIteration] ([ProjectIterationId]);


GO
PRINT N'Creating FK_Quote_BillTo_AddressId_CustomerAddress_CustomerAddressId...';


GO
ALTER TABLE [dbo].[Quote] WITH NOCHECK
    ADD CONSTRAINT [FK_Quote_BillTo_AddressId_CustomerAddress_CustomerAddressId] FOREIGN KEY ([BillTo_AddressId]) REFERENCES [dbo].[CustomerAddress] ([CustomerAddressId]);


GO
PRINT N'Creating FK_Quote_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[Quote] WITH NOCHECK
    ADD CONSTRAINT [FK_Quote_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Quote_CustomerId_Account_AccountId...';


GO
ALTER TABLE [dbo].[Quote] WITH NOCHECK
    ADD CONSTRAINT [FK_Quote_CustomerId_Account_AccountId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Account] ([AccountId]);


GO
PRINT N'Creating FK_Quote_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[Quote] WITH NOCHECK
    ADD CONSTRAINT [FK_Quote_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Quote_OpportunityId_Opportunity_OpportunityId...';


GO
ALTER TABLE [dbo].[Quote] WITH NOCHECK
    ADD CONSTRAINT [FK_Quote_OpportunityId_Opportunity_OpportunityId] FOREIGN KEY ([OpportunityId]) REFERENCES [dbo].[Opportunity] ([OpportunityId]);


GO
PRINT N'Creating FK_Quote_OwnerId_User_UserId...';


GO
ALTER TABLE [dbo].[Quote] WITH NOCHECK
    ADD CONSTRAINT [FK_Quote_OwnerId_User_UserId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_Quote_TransactionCurrencyId_TransactionCurrency_TransactionCurrencyId...';


GO
ALTER TABLE [dbo].[Quote] WITH NOCHECK
    ADD CONSTRAINT [FK_Quote_TransactionCurrencyId_TransactionCurrency_TransactionCurrencyId] FOREIGN KEY ([TransactionCurrencyId]) REFERENCES [dbo].[TransactionCurrency] ([TransactionCurrencyId]);


GO
PRINT N'Creating FK_QuoteLineItem_ProductId_Product_ProductId...';


GO
ALTER TABLE [dbo].[QuoteLineItem] WITH NOCHECK
    ADD CONSTRAINT [FK_QuoteLineItem_ProductId_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]);


GO
PRINT N'Creating FK_QuoteLineItem_QuoteId_Quote_QuoteId...';


GO
ALTER TABLE [dbo].[QuoteLineItem] WITH NOCHECK
    ADD CONSTRAINT [FK_QuoteLineItem_QuoteId_Quote_QuoteId] FOREIGN KEY ([QuoteId]) REFERENCES [dbo].[Quote] ([QuoteId]);


GO
PRINT N'Creating FK_RolePrivilege_PrivilegeId_Privilege_PrivilegeId...';


GO
ALTER TABLE [dbo].[RolePrivilege] WITH NOCHECK
    ADD CONSTRAINT [FK_RolePrivilege_PrivilegeId_Privilege_PrivilegeId] FOREIGN KEY ([PrivilegeId]) REFERENCES [dbo].[Privilege] ([PrivilegeId]);


GO
PRINT N'Creating FK_RolePrivilege_RoleId_Role_RoleId...';


GO
ALTER TABLE [dbo].[RolePrivilege] WITH NOCHECK
    ADD CONSTRAINT [FK_RolePrivilege_RoleId_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]);


GO
PRINT N'Creating FK_TaskTimeHistory_TaskId_ProjectTask_TaskId...';


GO
ALTER TABLE [dbo].[TaskTimeHistory] WITH NOCHECK
    ADD CONSTRAINT [FK_TaskTimeHistory_TaskId_ProjectTask_TaskId] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[ProjectTask] ([TaskId]);


GO
PRINT N'Creating FK_TimeTracking_OpportunityId_Opportunity_OpportunityId...';


GO
ALTER TABLE [dbo].[TimeTracking] WITH NOCHECK
    ADD CONSTRAINT [FK_TimeTracking_OpportunityId_Opportunity_OpportunityId] FOREIGN KEY ([OpportunityId]) REFERENCES [dbo].[Opportunity] ([OpportunityId]);


GO
PRINT N'Creating FK_TimeTracking_RecordById_User_UserId...';


GO
ALTER TABLE [dbo].[TimeTracking] WITH NOCHECK
    ADD CONSTRAINT [FK_TimeTracking_RecordById_User_UserId] FOREIGN KEY ([RecordById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_User_CreatedById_User_UserId...';


GO
ALTER TABLE [dbo].[User] WITH NOCHECK
    ADD CONSTRAINT [FK_User_CreatedById_User_UserId] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_User_DepartmentId_Department_DepartmentId...';


GO
ALTER TABLE [dbo].[User] WITH NOCHECK
    ADD CONSTRAINT [FK_User_DepartmentId_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([DepartmentId]);


GO
PRINT N'Creating FK_User_ModifiedById_User_UserId...';


GO
ALTER TABLE [dbo].[User] WITH NOCHECK
    ADD CONSTRAINT [FK_User_ModifiedById_User_UserId] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating FK_User_ParentUserId_User_UserId...';


GO
ALTER TABLE [dbo].[User] WITH NOCHECK
    ADD CONSTRAINT [FK_User_ParentUserId_User_UserId] FOREIGN KEY ([ParentUserId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Checking existing data against newly created constraints';


GO

GO
ALTER TABLE [dbo].[Attendance] WITH CHECK CHECK CONSTRAINT [FK_Attendance_CreatedById_User_UserId];

ALTER TABLE [dbo].[Attendance] WITH CHECK CHECK CONSTRAINT [FK_Attendance_ModifiedById_User_UserId];

ALTER TABLE [dbo].[Attendance] WITH CHECK CHECK CONSTRAINT [FK_Attendance_RecordPersonId_User_UserId];

ALTER TABLE [dbo].[Metadata_Attribute] WITH CHECK CHECK CONSTRAINT [FK_Metadata_Attribute_AttributeTypeId_Metadata_AttributeType_AttributeTypeId];

ALTER TABLE [dbo].[Metadata_Attribute] WITH CHECK CHECK CONSTRAINT [FK_Metadata_Attribute_EntityId_Metadata_Entity_EntityId];

ALTER TABLE [dbo].[Metadata_Attribute] WITH CHECK CHECK CONSTRAINT [FK_Metadata_Attribute_OptionSetId_Metadata_OptionSet_OptionSetId];

ALTER TABLE [dbo].[Metadata_AttributeLookupValue] WITH CHECK CHECK CONSTRAINT [FK_Metadata_AttributeLookupValue_EntityId_Metadata_Entity_EntityId];

ALTER TABLE [dbo].[Metadata_AttributeLookupValue] WITH CHECK CHECK CONSTRAINT [FK_Metadata_AttributeLookupValue_AttributeId_Metadata_Attribute_AttributeId];

ALTER TABLE [dbo].[Metadata_AttributePicklistValue] WITH CHECK CHECK CONSTRAINT [FK_Metadata_AttributePicklistValue_OptionSetId_Metadata_OptionSet_OptionSetId];

ALTER TABLE [dbo].[Metadata_AttributePicklistValueMap] WITH CHECK CHECK CONSTRAINT [FK_Metadata_AttributePicklistValueMap_AttributePicklistValueId_Metadata_AttributePicklistValue_AttributePicklistValueId];

ALTER TABLE [dbo].[Metadata_AttributePicklistValueMap] WITH CHECK CHECK CONSTRAINT [FK_Metadata_AttributePicklistValueMap_MapToValueId_Metadata_AttributePicklistValue_AttributePicklistValueId];

ALTER TABLE [dbo].[Metadata_EntityRelationshipRole] WITH CHECK CHECK CONSTRAINT [FK_Metadata_EntityRelationshipRole_EntityRelationshipId_Metadata_EntityRelationship_EntityRelationshipId];

ALTER TABLE [dbo].[Metadata_EntityRelationshipRole] WITH CHECK CHECK CONSTRAINT [FK_Metadata_EntityRelationshipRole_EntityId_Metadata_Entity_EntityId];

ALTER TABLE [dbo].[UserRole] WITH CHECK CHECK CONSTRAINT [FK_UserRole_RoleId_Role_RoleId];

ALTER TABLE [dbo].[UserRole] WITH CHECK CHECK CONSTRAINT [FK_UserRole_UserId_User_UserId];

ALTER TABLE [dbo].[CriteriaNode] WITH CHECK CHECK CONSTRAINT [FK_CriteriaNode_CompareAttributeId_Metadata_Attribute_AttributeId];

ALTER TABLE [dbo].[CriteriaNode] WITH CHECK CHECK CONSTRAINT [FK_CriteriaNode_CriteriaId_Criteria_CriteriaId];

ALTER TABLE [dbo].[Notification] WITH CHECK CHECK CONSTRAINT [FK_Notification_CreatedById_User_UserId];

ALTER TABLE [dbo].[Notification] WITH CHECK CHECK CONSTRAINT [FK_Notification_ModifiedById_User_UserId];

ALTER TABLE [dbo].[NotificationProfile] WITH CHECK CHECK CONSTRAINT [FK_NotificationProfile_CriteriaId_Criteria_CriteriaId];

ALTER TABLE [dbo].[NotificationProfile] WITH CHECK CHECK CONSTRAINT [FK_NotificationProfile_NotificationTemplateId_NotificationTemplate_NotificationTemplateId];

ALTER TABLE [dbo].[NotificationProfile] WITH CHECK CHECK CONSTRAINT [FK_NotificationProfile_SubjectTemplateId_NotificationTemplate_NotificationTemplateId];

ALTER TABLE [dbo].[NotificationRecipient] WITH CHECK CHECK CONSTRAINT [FK_NotificationRecipient_NotificationId_Notification_NotificationId];

ALTER TABLE [dbo].[NotificationRecipient] WITH CHECK CHECK CONSTRAINT [FK_NotificationRecipient_RecipientId_User_UserId];

ALTER TABLE [dbo].[NotificationRecipientAttributes] WITH CHECK CHECK CONSTRAINT [FK_NotificationRecipientAttributes_AttributeId_Metadata_Attribute_AttributeId];

ALTER TABLE [dbo].[NotificationRecipientAttributes] WITH CHECK CHECK CONSTRAINT [FK_NotificationRecipientAttributes_CriteriaId_Criteria_CriteriaId];

ALTER TABLE [dbo].[NotificationRecipientAttributes] WITH CHECK CHECK CONSTRAINT [FK_NotificationRecipientAttributes_RecipientEntityId_Metadata_Entity_EntityId];

ALTER TABLE [dbo].[NotificationRecipientAttributes] WITH CHECK CHECK CONSTRAINT [FK_NotificationRecipientAttributes_NotificationProfileId_NotificationProfile_NotificationProfileId];

ALTER TABLE [dbo].[NotificationVariable] WITH CHECK CHECK CONSTRAINT [FK_NotificationVariable_RelatedAttributeId_Metadata_Attribute_AttributeId];

ALTER TABLE [dbo].[NotificationVariable] WITH CHECK CHECK CONSTRAINT [FK_NotificationVariable_EntityId_Metadata_Entity_EntityId];

ALTER TABLE [dbo].[ProfileVariable] WITH CHECK CHECK CONSTRAINT [FK_ProfileVariable_NotificationProfileId_NotificationProfile_NotificationProfileId];

ALTER TABLE [dbo].[ProfileVariable] WITH CHECK CHECK CONSTRAINT [FK_ProfileVariable_NotificationVariableId_NotificationVariable_NotificationVariableId];

ALTER TABLE [dbo].[Subscription] WITH CHECK CHECK CONSTRAINT [FK_Subscription_NotificationProfileId_NotificationProfile_NotificationProfileId];

ALTER TABLE [dbo].[Subscription] WITH CHECK CHECK CONSTRAINT [FK_Subscription_UserId_User_UserId];

ALTER TABLE [dbo].[Account] WITH CHECK CHECK CONSTRAINT [FK_Account_CreatedById_User_UserId];

ALTER TABLE [dbo].[Account] WITH CHECK CHECK CONSTRAINT [FK_Account_DepartmentId_Department_DepartmentId];

ALTER TABLE [dbo].[Account] WITH CHECK CHECK CONSTRAINT [FK_Account_ModifiedById_User_UserId];

ALTER TABLE [dbo].[Account] WITH CHECK CHECK CONSTRAINT [FK_Account_OriginatingLeadId_Lead_LeadId];

ALTER TABLE [dbo].[Account] WITH CHECK CHECK CONSTRAINT [FK_Account_OwnerId_User_UserId];

ALTER TABLE [dbo].[Account] WITH CHECK CHECK CONSTRAINT [FK_Account_PrimaryContactId_Contact_ContactId];

ALTER TABLE [dbo].[AttentionInfomation] WITH CHECK CHECK CONSTRAINT [FK_AttentionInfomation_CreatedById_User_UserId];

ALTER TABLE [dbo].[AttentionInfomation] WITH CHECK CHECK CONSTRAINT [FK_AttentionInfomation_ModifiedById_User_UserId];

ALTER TABLE [dbo].[AttentionMember] WITH CHECK CHECK CONSTRAINT [FK_AttentionMember_AttentionInfoId_AttentionInfomation_AttentionInfoId];

ALTER TABLE [dbo].[AttentionMember] WITH CHECK CHECK CONSTRAINT [FK_AttentionMember_AttentionUserId_User_UserId];

ALTER TABLE [dbo].[ColumnMapping] WITH CHECK CHECK CONSTRAINT [FK_ColumnMapping_ImportMapId_ImportMap_ImportMapId];

ALTER TABLE [dbo].[Contact] WITH CHECK CHECK CONSTRAINT [FK_Contact_CreatedById_User_UserId];

ALTER TABLE [dbo].[Contact] WITH CHECK CHECK CONSTRAINT [FK_Contact_ModifiedById_User_UserId];

ALTER TABLE [dbo].[Contact] WITH CHECK CHECK CONSTRAINT [FK_Contact_OriginatingLeadId_Lead_LeadId];

ALTER TABLE [dbo].[Contact] WITH CHECK CHECK CONSTRAINT [FK_Contact_OwnerId_User_UserId];

ALTER TABLE [dbo].[Contract] WITH CHECK CHECK CONSTRAINT [FK_Contract_BillingCustomerId_Account_AccountId];

ALTER TABLE [dbo].[Contract] WITH CHECK CHECK CONSTRAINT [FK_Contract_CreatedById_User_UserId];

ALTER TABLE [dbo].[Contract] WITH CHECK CHECK CONSTRAINT [FK_Contract_DepartmentId_Department_DepartmentId];

ALTER TABLE [dbo].[Contract] WITH CHECK CHECK CONSTRAINT [FK_Contract_ModifiedById_User_UserId];

ALTER TABLE [dbo].[Contract] WITH CHECK CHECK CONSTRAINT [FK_Contract_OpportunityId_Opportunity_OpportunityId];

ALTER TABLE [dbo].[Contract] WITH CHECK CHECK CONSTRAINT [FK_Contract_OwnerId_User_UserId];

ALTER TABLE [dbo].[Contract] WITH CHECK CHECK CONSTRAINT [FK_Contract_TransactionCurrencyId_TransactionCurrency_TransactionCurrencyId];

ALTER TABLE [dbo].[ImportEntityMapping] WITH CHECK CHECK CONSTRAINT [FK_ImportEntityMapping_ImportMapId_ImportMap_ImportMapId];

ALTER TABLE [dbo].[Invoice] WITH CHECK CHECK CONSTRAINT [FK_Invoice_BillingCustomerId_Account_AccountId];

ALTER TABLE [dbo].[Invoice] WITH CHECK CHECK CONSTRAINT [FK_Invoice_CreatedById_User_UserId];

ALTER TABLE [dbo].[Invoice] WITH CHECK CHECK CONSTRAINT [FK_Invoice_ModifiedById_User_UserId];

ALTER TABLE [dbo].[Invoice] WITH CHECK CHECK CONSTRAINT [FK_Invoice_OwnerId_User_UserId];

ALTER TABLE [dbo].[Invoice] WITH CHECK CHECK CONSTRAINT [FK_Invoice_TransactionCurrencyId_TransactionCurrency_TransactionCurrencyId];

ALTER TABLE [dbo].[InvoiceContract] WITH CHECK CHECK CONSTRAINT [FK_InvoiceContract_ContractId_Contract_ContractId];

ALTER TABLE [dbo].[InvoiceContract] WITH CHECK CHECK CONSTRAINT [FK_InvoiceContract_InvoiceId_Invoice_InvoiceId];

ALTER TABLE [dbo].[Lead] WITH CHECK CHECK CONSTRAINT [FK_Lead_CreatedById_User_UserId];

ALTER TABLE [dbo].[Lead] WITH CHECK CHECK CONSTRAINT [FK_Lead_DepartmentId_Department_DepartmentId];

ALTER TABLE [dbo].[Lead] WITH CHECK CHECK CONSTRAINT [FK_Lead_ModifiedById_User_UserId];

ALTER TABLE [dbo].[Lead] WITH CHECK CHECK CONSTRAINT [FK_Lead_OwnerId_User_UserId];

ALTER TABLE [dbo].[LookupMapping] WITH CHECK CHECK CONSTRAINT [FK_LookupMapping_ColumnMappingId_ColumnMapping_ColumnMappingId];

ALTER TABLE [dbo].[Metadata_AttentionConfig] WITH CHECK CHECK CONSTRAINT [FK_Metadata_AttentionConfig_AboutAttributeId_Metadata_Attribute_AttributeId];

ALTER TABLE [dbo].[Metadata_AttentionConfig] WITH CHECK CHECK CONSTRAINT [FK_Metadata_AttentionConfig_AboutEntityId_Metadata_Entity_EntityId];

ALTER TABLE [dbo].[Metadata_AttentionConfig] WITH CHECK CHECK CONSTRAINT [FK_Metadata_AttentionConfig_AttentionEntityId_Metadata_Entity_EntityId];

ALTER TABLE [dbo].[Metadata_AttentionMemberConfig] WITH CHECK CHECK CONSTRAINT [FK_Metadata_AttentionMemberConfig_AttentionConfigId_Metadata_AttentionConfig_AttentionConfigId];

ALTER TABLE [dbo].[Metadata_AttentionMemberConfig] WITH CHECK CHECK CONSTRAINT [FK_Metadata_AttentionMemberConfig_MemberAttributeId_Metadata_Attribute_AttributeId];

ALTER TABLE [dbo].[Metadata_AttentionMemberConfig] WITH CHECK CHECK CONSTRAINT [FK_Metadata_AttentionMemberConfig_MemberEntityId_Metadata_Entity_EntityId];

ALTER TABLE [dbo].[Metadata_EntityRelationshipRelationships] WITH CHECK CHECK CONSTRAINT [FK_Metadata_EntityRelationshipRelationships_EntityRelationshipId_Metadata_EntityRelationship_EntityRelationshipId];

ALTER TABLE [dbo].[Metadata_EntityRelationshipRelationships] WITH CHECK CHECK CONSTRAINT [FK_Metadata_EntityRelationshipRelationships_RelationshipId_Metadata_Relationship_RelationshipId];

ALTER TABLE [dbo].[Metadata_FilterConditionDetail] WITH CHECK CHECK CONSTRAINT [FK_Metadata_FilterConditionDetail_CompareAttributeId_Metadata_Attribute_AttributeId];

ALTER TABLE [dbo].[Metadata_FilterConditionDetail] WITH CHECK CHECK CONSTRAINT [FK_Metadata_FilterConditionDetail_FilterConditionId_Metadata_FilterConditon_FilterConditionId];

ALTER TABLE [dbo].[Metadata_Relationship] WITH CHECK CHECK CONSTRAINT [FK_Metadata_Relationship_ReferencedAttributeId_Metadata_Attribute_AttributeId];

ALTER TABLE [dbo].[Metadata_Relationship] WITH CHECK CHECK CONSTRAINT [FK_Metadata_Relationship_ReferencedEntityId_Metadata_Entity_EntityId];

ALTER TABLE [dbo].[Metadata_Relationship] WITH CHECK CHECK CONSTRAINT [FK_Metadata_Relationship_ReferencingAttributeId_Metadata_Attribute_AttributeId];

ALTER TABLE [dbo].[Metadata_Relationship] WITH CHECK CHECK CONSTRAINT [FK_Metadata_Relationship_ReferencingEntityId_Metadata_Entity_EntityId];

ALTER TABLE [dbo].[Note] WITH CHECK CHECK CONSTRAINT [FK_Note_CreatedById_User_UserId];

ALTER TABLE [dbo].[Note] WITH CHECK CHECK CONSTRAINT [FK_Note_ModifiedById_User_UserId];

ALTER TABLE [dbo].[Opportunity] WITH CHECK CHECK CONSTRAINT [FK_Opportunity_CreatedById_User_UserId];

ALTER TABLE [dbo].[Opportunity] WITH CHECK CHECK CONSTRAINT [FK_Opportunity_DepartmentId_Department_DepartmentId];

ALTER TABLE [dbo].[Opportunity] WITH CHECK CHECK CONSTRAINT [FK_Opportunity_ModifiedById_User_UserId];

ALTER TABLE [dbo].[Opportunity] WITH CHECK CHECK CONSTRAINT [FK_Opportunity_OriginatingLeadId_Lead_LeadId];

ALTER TABLE [dbo].[Opportunity] WITH CHECK CHECK CONSTRAINT [FK_Opportunity_OwnerId_User_UserId];

ALTER TABLE [dbo].[Opportunity] WITH CHECK CHECK CONSTRAINT [FK_Opportunity_TechnicianId_User_UserId];

ALTER TABLE [dbo].[Opportunity] WITH CHECK CHECK CONSTRAINT [FK_Opportunity_TransactionCurrencyId_TransactionCurrency_TransactionCurrencyId];

ALTER TABLE [dbo].[PickListMapping] WITH CHECK CHECK CONSTRAINT [FK_PickListMapping_ColumnMappingId_ColumnMapping_ColumnMappingId];

ALTER TABLE [dbo].[PrivilegeEntity] WITH CHECK CHECK CONSTRAINT [FK_PrivilegeEntity_PrivilegeId_Privilege_PrivilegeId];

ALTER TABLE [dbo].[Product] WITH CHECK CHECK CONSTRAINT [FK_Product_CreatedById_User_UserId];

ALTER TABLE [dbo].[Product] WITH CHECK CHECK CONSTRAINT [FK_Product_ModifiedById_User_UserId];

ALTER TABLE [dbo].[Project] WITH CHECK CHECK CONSTRAINT [FK_Project_ContractId_Contract_ContractId];

ALTER TABLE [dbo].[Project] WITH CHECK CHECK CONSTRAINT [FK_Project_CreatedById_User_UserId];

ALTER TABLE [dbo].[Project] WITH CHECK CHECK CONSTRAINT [FK_Project_ManagerId_User_UserId];

ALTER TABLE [dbo].[Project] WITH CHECK CHECK CONSTRAINT [FK_Project_ModifiedById_User_UserId];

ALTER TABLE [dbo].[Project] WITH CHECK CHECK CONSTRAINT [FK_Project_SaleServiceId_User_UserId];

ALTER TABLE [dbo].[ProjectIteration] WITH CHECK CHECK CONSTRAINT [FK_ProjectIteration_CreatedById_User_UserId];

ALTER TABLE [dbo].[ProjectIteration] WITH CHECK CHECK CONSTRAINT [FK_ProjectIteration_ModifiedById_User_UserId];

ALTER TABLE [dbo].[ProjectIteration] WITH CHECK CHECK CONSTRAINT [FK_ProjectIteration_ProjectId_Project_ProjectId];

ALTER TABLE [dbo].[ProjectIteration] WITH CHECK CHECK CONSTRAINT [FK_ProjectIteration_ProjectVersionId_ProjectVersion_ProjectVersionId];

ALTER TABLE [dbo].[ProjectMember] WITH CHECK CHECK CONSTRAINT [FK_ProjectMember_MemberId_User_UserId];

ALTER TABLE [dbo].[ProjectMember] WITH CHECK CHECK CONSTRAINT [FK_ProjectMember_ProjectId_Project_ProjectId];

ALTER TABLE [dbo].[ProjectTask] WITH CHECK CHECK CONSTRAINT [FK_ProjectTask_CreatedById_User_UserId];

ALTER TABLE [dbo].[ProjectTask] WITH CHECK CHECK CONSTRAINT [FK_ProjectTask_ModifiedById_User_UserId];

ALTER TABLE [dbo].[ProjectTask] WITH CHECK CHECK CONSTRAINT [FK_ProjectTask_OwnerId_User_UserId];

ALTER TABLE [dbo].[ProjectTask] WITH CHECK CHECK CONSTRAINT [FK_ProjectTask_ProjectId_Project_ProjectId];

ALTER TABLE [dbo].[ProjectTask] WITH CHECK CHECK CONSTRAINT [FK_ProjectTask_ProjectIterationId_ProjectIteration_ProjectIterationId];

ALTER TABLE [dbo].[ProjectVersion] WITH CHECK CHECK CONSTRAINT [FK_ProjectVersion_CreatedById_User_UserId];

ALTER TABLE [dbo].[ProjectVersion] WITH CHECK CHECK CONSTRAINT [FK_ProjectVersion_ModifiedById_User_UserId];

ALTER TABLE [dbo].[ProjectVersion] WITH CHECK CHECK CONSTRAINT [FK_ProjectVersion_ProjectId_Project_ProjectId];

ALTER TABLE [dbo].[ProjectWeekReport] WITH CHECK CHECK CONSTRAINT [FK_ProjectWeekReport_CreatedById_User_UserId];

ALTER TABLE [dbo].[ProjectWeekReport] WITH CHECK CHECK CONSTRAINT [FK_ProjectWeekReport_ModifiedById_User_UserId];

ALTER TABLE [dbo].[ProjectWeekReport] WITH CHECK CHECK CONSTRAINT [FK_ProjectWeekReport_ProjectId_Project_ProjectId];

ALTER TABLE [dbo].[ProjectWeekReport] WITH CHECK CHECK CONSTRAINT [FK_ProjectWeekReport_ProjectIterationId_ProjectIteration_ProjectIterationId];

ALTER TABLE [dbo].[Quote] WITH CHECK CHECK CONSTRAINT [FK_Quote_BillTo_AddressId_CustomerAddress_CustomerAddressId];

ALTER TABLE [dbo].[Quote] WITH CHECK CHECK CONSTRAINT [FK_Quote_CreatedById_User_UserId];

ALTER TABLE [dbo].[Quote] WITH CHECK CHECK CONSTRAINT [FK_Quote_CustomerId_Account_AccountId];

ALTER TABLE [dbo].[Quote] WITH CHECK CHECK CONSTRAINT [FK_Quote_ModifiedById_User_UserId];

ALTER TABLE [dbo].[Quote] WITH CHECK CHECK CONSTRAINT [FK_Quote_OpportunityId_Opportunity_OpportunityId];

ALTER TABLE [dbo].[Quote] WITH CHECK CHECK CONSTRAINT [FK_Quote_OwnerId_User_UserId];

ALTER TABLE [dbo].[Quote] WITH CHECK CHECK CONSTRAINT [FK_Quote_TransactionCurrencyId_TransactionCurrency_TransactionCurrencyId];

ALTER TABLE [dbo].[QuoteLineItem] WITH CHECK CHECK CONSTRAINT [FK_QuoteLineItem_ProductId_Product_ProductId];

ALTER TABLE [dbo].[QuoteLineItem] WITH CHECK CHECK CONSTRAINT [FK_QuoteLineItem_QuoteId_Quote_QuoteId];

ALTER TABLE [dbo].[RolePrivilege] WITH CHECK CHECK CONSTRAINT [FK_RolePrivilege_PrivilegeId_Privilege_PrivilegeId];

ALTER TABLE [dbo].[RolePrivilege] WITH CHECK CHECK CONSTRAINT [FK_RolePrivilege_RoleId_Role_RoleId];

ALTER TABLE [dbo].[TaskTimeHistory] WITH CHECK CHECK CONSTRAINT [FK_TaskTimeHistory_TaskId_ProjectTask_TaskId];

ALTER TABLE [dbo].[TimeTracking] WITH CHECK CHECK CONSTRAINT [FK_TimeTracking_OpportunityId_Opportunity_OpportunityId];

ALTER TABLE [dbo].[TimeTracking] WITH CHECK CHECK CONSTRAINT [FK_TimeTracking_RecordById_User_UserId];

ALTER TABLE [dbo].[User] WITH CHECK CHECK CONSTRAINT [FK_User_CreatedById_User_UserId];

ALTER TABLE [dbo].[User] WITH CHECK CHECK CONSTRAINT [FK_User_DepartmentId_Department_DepartmentId];

ALTER TABLE [dbo].[User] WITH CHECK CHECK CONSTRAINT [FK_User_ModifiedById_User_UserId];

ALTER TABLE [dbo].[User] WITH CHECK CHECK CONSTRAINT [FK_User_ParentUserId_User_UserId];


GO
PRINT N'Update complete.'
GO


DELETE FROM Metadata_AttentionMemberConfig
DELETE FROM Metadata_FilterConditionDetail
DELETE FROM Metadata_FilterConditon
DELETE FROM Metadata_AttentionConfig

DELETE FROM [Metadata_EntityRelationshipRole]
DELETE FROM [Metadata_EntityRelationshipRelationships]
DELETE FROM [Metadata_EntityRelationship]
DELETE FROM [Metadata_Relationship]
DELETE FROM Metadata_AttributePicklistValueMap
DELETE FROM Metadata_AttributePicklistValue
DELETE FROM Metadata_AttributeLookupValue
DELETE FROM Metadata_Attribute
DELETE FROM Metadata_AttributeType
DELETE FROM Metadata_OptionSet
DELETE FROM Metadata_LocalizedLabel
DELETE FROM PrivilegeEntity
DELETE FROM Metadata_Entity
DELETE FROM LookupMapping
DELETE FROM ImportEntityMapping
DELETE FROM PickListMapping
DELETE FROM ColumnMapping
DELETE FROM ImportMap
DELETE FROM SystemSetting
DELETE FROM RolePrivilege
DELETE FROM UserRole
DELETE FROM Role
DELETE FROM Privilege
DELETE FROM SavedQuery