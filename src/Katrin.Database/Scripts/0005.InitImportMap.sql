DELETE FROM [ImportEntityMapping]
DELETE FROM [PickListMapping]
DELETE FROM [LookupMapping]
DELETE FROM [ColumnMapping]
DELETE FROM [ImportMap]

DECLARE @SourceEntityName nvarchar(160)
DECLARE @SourceAttributeName nvarchar(160)
DECLARE @TargetEntityName nvarchar(160)
DECLARE @TargetAttributeName nvarchar(160)
DECLARE @ImportMapId uniqueidentifier
DECLARE	@ColumnMappingId uniqueidentifier

SET @ImportMapId = N'75720961-a26a-4d25-b3e5-1978322b3649'
INSERT INTO [dbo].[ImportMap] ([ImportMapId], [Name], [Source]) VALUES (@ImportMapId, N'SugarCRM', NULL)

SET @SourceEntityName = N'Users' 
SET @TargetEntityName= N'User'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'id' 
SET @TargetAttributeName= 'UserId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'user_name' 
SET @TargetAttributeName= 'UserName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'user_hash' 
SET @TargetAttributeName= 'Password'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'first_name' 
SET @TargetAttributeName= 'FirstName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'last_name' 
SET @TargetAttributeName= 'LastName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'date_entered' 
SET @TargetAttributeName= 'CreatedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'date_modified' 
SET @TargetAttributeName= 'ModifiedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'modified_user_id' 
SET @TargetAttributeName= 'ModifiedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'created_by' 
SET @TargetAttributeName= 'CreatedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'title' 
SET @TargetAttributeName= 'Title'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'phone_home' 
SET @TargetAttributeName= 'HomePhone'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'phone_mobile' 
SET @TargetAttributeName= 'MobilePhone'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'deleted' 
SET @TargetAttributeName= 'IsDeleted'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'reports_to_id' 
SET @TargetAttributeName= 'ParentUserId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'status' 
SET @TargetAttributeName= 'IsDisabled'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'email1' 
SET @TargetAttributeName= 'EmailAddress'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

-----------------------------------------------------------------------------------------
SET @SourceEntityName = 'Accounts' 
SET @TargetEntityName= 'Account'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'id' 
SET @TargetAttributeName= 'AccountId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'name' 
SET @TargetAttributeName= 'Name'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'date_entered' 
SET @TargetAttributeName= 'CreatedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'date_modified' 
SET @TargetAttributeName= 'ModifiedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'modified_user_id' 
SET @TargetAttributeName= 'ModifiedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'created_by' 
SET @TargetAttributeName= 'CreatedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'description' 
SET @TargetAttributeName= 'Description'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'deleted' 
SET @TargetAttributeName= 'IsDeleted'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'assigned_user_id' 
SET @TargetAttributeName= 'OwnerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'account_type' 
SET @TargetAttributeName= 'CustomerTypeCode'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,1, N'Competitor')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,2, N'Consultant')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,3, N'Customer')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,4, N'Investor')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,5, N'Partner')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,6, N'Influencer')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,7, N'Press')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,8, N'Prospect')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,9, N'Reseller')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,10, N'Supplier')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,11, N'Vendor')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,12, N'Other')

SET @SourceAttributeName = 'industry' 
SET @TargetAttributeName= 'IndustryCode'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,1, N'Accounting')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,2, N'Agriculture and Non-petrol Natural Resource Extraction')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,3, N'Broadcasting Printing and Publishing')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,4, N'Brokers')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,5, N'Building Supply Retail')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,6, N'Technology')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,7, N'Consulting')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,8, N'Consumer Services')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,9, N'Design, Direction and Creative Management')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,10, N'Distributors, Dispatchers and Processors')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,11, N'Doctor''s Offices and Clinics')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,12, N'Durable Manufacturing')
SET @SourceAttributeName = 'annual_revenue' 
SET @TargetAttributeName= 'Revenue'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'billing_address_city' 
SET @TargetAttributeName= 'City'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'billing_address_country' 
SET @TargetAttributeName= 'Country'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
--SET @SourceAttributeName = 'rating' 
--SET @TargetAttributeName= 'AccountRatingCode'
--SET	@ColumnMappingId	= NEWID()
--INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'phone_office' 
SET @TargetAttributeName= 'Telephone1'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)


SET @SourceAttributeName = 'phone_alternate' 
SET @TargetAttributeName= 'Telephone2'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'website' 
SET @TargetAttributeName= 'WebSiteURL'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
--SET @SourceAttributeName = 'ownership' 
--SET @TargetAttributeName= 'OwnershipCode'
--INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'employees' 
SET @TargetAttributeName= 'NumberOfEmployees'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'ticker_symbol' 
SET @TargetAttributeName= 'TickerSymbol'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'parent_id' 
SET @TargetAttributeName= 'ParentAccountId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'sic_code' 
SET @TargetAttributeName= 'SIC'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'email1' 
SET @TargetAttributeName= 'EMailAddress1'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

-----------------------------------------------------------------------------------------
SET @SourceEntityName = 'Contacts' 
SET @TargetEntityName= 'Contact'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'id' 
SET @TargetAttributeName= 'ContactId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'date_entered' 
SET @TargetAttributeName= 'CreatedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'date_modified' 
SET @TargetAttributeName= 'ModifiedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'modified_user_id' 
SET @TargetAttributeName= 'ModifiedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'created_by' 
SET @TargetAttributeName= 'CreatedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'description' 
SET @TargetAttributeName= 'Description'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'deleted' 
SET @TargetAttributeName= 'IsDeleted'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'assigned_user_id' 
SET @TargetAttributeName= 'OwnerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'salutation' 
SET @TargetAttributeName= 'Suffix'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'first_name' 
SET @TargetAttributeName= 'FirstName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'last_name' 
SET @TargetAttributeName= 'LastName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'title' 
SET @TargetAttributeName= 'JobTitle'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'department' 
SET @TargetAttributeName= 'Department'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'phone_home' 
SET @TargetAttributeName= 'Telephone1'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'phone_mobile' 
SET @TargetAttributeName= 'MobilePhone'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'phone_work' 
SET @TargetAttributeName= 'Telephone2'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'phone_other' 
SET @TargetAttributeName= 'Telephone3'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'phone_fax' 
SET @TargetAttributeName= 'Fax'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'assistant' 
SET @TargetAttributeName= 'AssistantName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'assistant_phone' 
SET @TargetAttributeName= 'AssistantPhone'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'email1' 
SET @TargetAttributeName= 'EMailAddress1'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

-----------------------------------------------------------------------------------------
SET @SourceEntityName = 'Contracts' 
SET @TargetEntityName= 'Contract'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'id' 
SET @TargetAttributeName= 'ContractId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'date_entered' 
SET @TargetAttributeName= 'CreatedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'date_modified' 
SET @TargetAttributeName= 'ModifiedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'modified_user_id' 
SET @TargetAttributeName= 'ModifiedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'created_by' 
SET @TargetAttributeName= 'CreatedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'description' 
SET @TargetAttributeName= 'Description'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'deleted' 
SET @TargetAttributeName= 'IsDeleted'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'assigned_user_id' 
SET @TargetAttributeName= 'OwnerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'name' 
SET @TargetAttributeName= 'Title'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'billing_date' 
SET @TargetAttributeName= 'ActiveOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'company_signed_date' 
SET @TargetAttributeName= 'CompanySignedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'account_id' 
SET @TargetAttributeName= 'BillingCustomerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'opportunity_id' 
SET @TargetAttributeName= 'OpportunityId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'customer_signed_date' 
SET @TargetAttributeName= 'CustomerSignedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'expiry_date' 
SET @TargetAttributeName= 'ExpiresOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'start_date' 
SET @TargetAttributeName= 'BillingStartOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'status' 
SET @TargetAttributeName= 'StatusCode'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,1, N'Prepare')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,2, N'Working')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,3, N'Finished')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,4, N'Closed')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,5, N'Failed')

SET @SourceAttributeName = 'amount' 
SET @TargetAttributeName= 'TotalPrice'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)


-----------------------------------------------------------------------------------------
SET @SourceEntityName = 'Leads' 
SET @TargetEntityName= 'Lead'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'id' 
SET @TargetAttributeName= 'LeadId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'date_entered' 
SET @TargetAttributeName= 'CreatedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'date_modified' 
SET @TargetAttributeName= 'ModifiedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'modified_user_id' 
SET @TargetAttributeName= 'ModifiedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'created_by' 
SET @TargetAttributeName= 'CreatedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'description' 
SET @TargetAttributeName= 'Description'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'deleted' 
SET @TargetAttributeName= 'IsDeleted'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'assigned_user_id' 
SET @TargetAttributeName= 'OwnerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'first_name' 
SET @TargetAttributeName= 'FirstName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'last_name' 
SET @TargetAttributeName= 'LastName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'title' 
SET @TargetAttributeName= 'Subject'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'phone_home' 
SET @TargetAttributeName= 'Telephone2'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'phone_mobile' 
SET @TargetAttributeName= 'MobilePhone'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'phone_work' 
SET @TargetAttributeName= 'Telephone1'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'phone_fax' 
SET @TargetAttributeName= 'Fax'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'primary_address_city' 
SET @TargetAttributeName= 'City'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'country_c' 
SET @TargetAttributeName= 'Country'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'primary_address_street' 
SET @TargetAttributeName= 'Address'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'primary_address_postalcode' 
SET @TargetAttributeName= 'ZIP'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'lead_source' 
SET @TargetAttributeName= 'LeadSourceCode'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,1, N'Web Site')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,2, N'Head Office')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,3, N'Existing Customer')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,4, N'Cold Call')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,5, N'Partner')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,6, N'Self Generated')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,7, N'Employee')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,8, N'Email')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,9, N'Other')

SET @SourceAttributeName = 'status' 
SET @TargetAttributeName= 'StatusCode'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,1, N'New')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,2, N'Assigned')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,3, N'In Process')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,4, N'Converted')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,5, N'Recycled')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,6, N'Dead')

SET @SourceAttributeName = 'account_name' 
SET @TargetAttributeName= 'CompanyName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'department_c' 
SET @TargetAttributeName= 'DepartmentId'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[LookupMapping]([LookupMappingId],[ColumnMappingId],[LookupEntityName],[ValueAttributeName],[LookupAttributeName])
VALUES(NEWID(),@ColumnMappingId,'Department','DepartmentId','Name')

SET @SourceAttributeName = 'original_message_c' 
SET @TargetAttributeName= 'OriginalMessage'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'importance_c' 
SET @TargetAttributeName= 'PriorityCode'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,1, N'Very High')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,2, N'High')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,3, N'Normal')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,4, N'Worthy of a Try')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,5, N'Hopeless')

SET @SourceAttributeName = 'email1' 
SET @TargetAttributeName= 'EmailAddress'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

-----------------------------------------------------------------------------------------
SET @SourceEntityName = 'Nova_Invoice' 
SET @TargetEntityName= 'Invoice'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'id' 
SET @TargetAttributeName= 'InvoiceId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'date_entered' 
SET @TargetAttributeName= 'CreatedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'date_modified' 
SET @TargetAttributeName= 'ModifiedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'modified_user_id' 
SET @TargetAttributeName= 'ModifiedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'created_by' 
SET @TargetAttributeName= 'CreatedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'description' 
SET @TargetAttributeName= 'Description'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'assigned_user_id' 
SET @TargetAttributeName= 'OwnerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'deleted' 
SET @TargetAttributeName= 'IsDeleted'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'name' 
SET @TargetAttributeName= 'Name'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'name' 
SET @TargetAttributeName= 'InvoiceNumber'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'sent_date' 
SET @TargetAttributeName= 'DateDelivered'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'received_date' 
SET @TargetAttributeName= 'ReceivedDate'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'receivable' 
SET @TargetAttributeName= 'TotalAmount'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'paid_up' 
SET @TargetAttributeName= 'PaidAmount'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'invoice_status' 
SET @TargetAttributeName= 'StatusCode'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,1, N'Sent')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,2, N'Paid')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,3, N'In Arrear')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,4, N'Bad Debts')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,5, N'Plan')

-----------------------------------------------------------------------------------------
SET @SourceEntityName = 'Opportunities' 
SET @TargetEntityName= 'Opportunity'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'id' 
SET @TargetAttributeName= 'OpportunityId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'date_entered' 
SET @TargetAttributeName= 'CreatedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'date_modified' 
SET @TargetAttributeName= 'ModifiedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'modified_user_id' 
SET @TargetAttributeName= 'ModifiedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'created_by' 
SET @TargetAttributeName= 'CreatedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'description' 
SET @TargetAttributeName= 'Description'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'deleted' 
SET @TargetAttributeName= 'IsDeleted'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'assigned_user_id' 
SET @TargetAttributeName= 'OwnerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'name' 
SET @TargetAttributeName= 'Name'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'opportunity_type' 
SET @TargetAttributeName= 'OpportunityTypeCode'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,1, N'Existing Business')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,2, N'New Business')

SET @SourceAttributeName = 'lead_source' 
SET @TargetAttributeName= 'LeadSourceCode'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,1, N'Web Site')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,2, N'Head Office')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,3, N'Existing Customer')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,4, N'Cold Call')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,5, N'Partner')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,6, N'Self Generated')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,7, N'Employee')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,8, N'Email')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,9, N'Other')

SET @SourceAttributeName = 'amount' 
SET @TargetAttributeName= 'EstimatedValue'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'amount_usdollar' 
SET @TargetAttributeName= 'ActualValue'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'date_closed' 
SET @TargetAttributeName= 'EstimatedCloseDate'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'next_step' 
SET @TargetAttributeName= 'StepName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'account_id' 
SET @TargetAttributeName= 'CustomerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'sales_stage' 
SET @TargetAttributeName= 'SalesStageCode'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,1, N'Prospecting')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,2, N'Qualification')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,3, N'Needs Analysis')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,4, N'Value Proposition')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,5, N'Id. Decision Makers')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,6, N'Perception Analysis')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,7, N'Proposal/Price Quote')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,8, N'Negotiation/Review')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,9, N'Closed Won')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,10, N'Closed Lost')

SET @SourceAttributeName = 'probability' 
SET @TargetAttributeName= 'CloseProbability'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'department_c' 
SET @TargetAttributeName= 'DepartmentId'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[LookupMapping]([LookupMappingId],[ColumnMappingId],[LookupEntityName],[ValueAttributeName],[LookupAttributeName])
VALUES(NEWID(),@ColumnMappingId,'Department','DepartmentId','Name')

-----------------------------------------------------------------------------------------
SET @SourceEntityName = 'Products' 
SET @TargetEntityName= 'Product'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'id' 
SET @TargetAttributeName= 'ProductId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'date_entered' 
SET @TargetAttributeName= 'CreatedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'date_modified' 
SET @TargetAttributeName= 'ModifiedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'modified_user_id' 
SET @TargetAttributeName= 'ModifiedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'created_by' 
SET @TargetAttributeName= 'CreatedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'description' 
SET @TargetAttributeName= 'Description'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'deleted' 
SET @TargetAttributeName= 'IsDeleted'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'name' 
SET @TargetAttributeName= 'Name'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'cost' 
SET @TargetAttributeName= 'CurrentCost'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'price' 
SET @TargetAttributeName= 'Price'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'name' 
SET @TargetAttributeName= 'ProductNumber'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

-----------------------------------------------------------------------------------------
SET @SourceEntityName = 'ProductQuotes' 
SET @TargetEntityName= 'QuoteLineItem'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'id' 
SET @TargetAttributeName= 'QuoteLineItemId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'quote_id' 
SET @TargetAttributeName= 'QuoteId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'product_id' 
SET @TargetAttributeName= 'ProductId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'product_qty' 
SET @TargetAttributeName= 'Quantity'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'product_unit_price' 
SET @TargetAttributeName= 'UnitPrice'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'product_total_price' 
SET @TargetAttributeName= 'TotalPrice'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

-----------------------------------------------------------------------------------------
SET @SourceEntityName = 'Quotes' 
SET @TargetEntityName= 'Quote'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'id' 
SET @TargetAttributeName= 'QuoteId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'date_entered' 
SET @TargetAttributeName= 'CreatedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'date_modified' 
SET @TargetAttributeName= 'ModifiedOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'modified_user_id' 
SET @TargetAttributeName= 'ModifiedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'created_by' 
SET @TargetAttributeName= 'CreatedBy'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'description' 
SET @TargetAttributeName= 'Description'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'deleted' 
SET @TargetAttributeName= 'IsDeleted'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'name' 
SET @TargetAttributeName= 'Name'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'assigned_user_id' 
SET @TargetAttributeName= 'OwnerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

--SET @SourceAttributeName = 'approval_status' 
--SET @TargetAttributeName= 'StatusCode'
--INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
--VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'billing_account_id' 
SET @TargetAttributeName= 'CustomerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'billing_contact' 
SET @TargetAttributeName= 'BillTo_ContactName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'expiration' 
SET @TargetAttributeName= 'ExpiresOn'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'number' 
SET @TargetAttributeName= 'QuoteNumber'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'opportunity_id' 
SET @TargetAttributeName= 'OpportunityId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'billing_state' 
SET @TargetAttributeName= 'StatusCode'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,1, N'Approved')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,2, N'Not Approved')

SET @SourceAttributeName = 'stage' 
SET @TargetAttributeName= 'StageCode'
SET	@ColumnMappingId	= NEWID()
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (@ColumnMappingId, @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,1, N'Draft')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,2, N'Negotiation')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,3, N'Delivered')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,4, N'On Hold')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,5, N'Confirmed')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,6, N'Closed Accepted')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,7, N'Closed Lost')
INSERT INTO [dbo].[PickListMapping]([PickListMappingId],[ColumnMappingId],[TargetValue],[SourceValue]) VALUES(NEWID(),@ColumnMappingId,8, N'Closed Dead')

--SET @SourceAttributeName = 'term' 
--SET @TargetAttributeName= 'PaymentTermsCode'
--INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
--VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'subtotal_amount' 
SET @TargetAttributeName= 'TotalLineItemAmount'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'tax_amount' 
SET @TargetAttributeName= 'TotalTax'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

SET @SourceAttributeName = 'total_amount' 
SET @TargetAttributeName= 'TotalAmount'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
--------------------------------------------------------转换功能----------------------------------------------------------------------
SET @ImportMapId = N'75720961-a26a-4d25-b3e5-1978322b3650'
INSERT INTO [dbo].[ImportMap] ([ImportMapId], [Name], [Source]) VALUES (@ImportMapId, N'KatrinCRM', NULL)

---------------------------------------convert lead to Opportunity
SET @SourceEntityName = N'Lead' 
SET @TargetEntityName= N'Opportunity'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'Subject' 
SET @TargetAttributeName= 'Name'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'LeadId' 
SET @TargetAttributeName= 'OriginatingLeadId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'DepartmentId' 
SET @TargetAttributeName= 'DepartmentId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
------------------------------------convert lead  to Account
SET @SourceEntityName = N'Lead' 
SET @TargetEntityName= N'Account'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'LeadId' 
SET @TargetAttributeName= 'OriginatingLeadId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'Telephone2' 
SET @TargetAttributeName= 'Telephone2'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'Telephone1' 
SET @TargetAttributeName= 'Telephone1'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'City' 
SET @TargetAttributeName= 'City'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'NumberOfEmployees' 
SET @TargetAttributeName= 'NumberOfEmployees'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'Country' 
SET @TargetAttributeName= 'Country'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'WebSiteUrl' 
SET @TargetAttributeName= 'WebSiteUrl'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'CompanyName' 
SET @TargetAttributeName= 'Name'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
----------------------------------convert lead  to Contact
SET @SourceEntityName = N'Lead' 
SET @TargetEntityName= N'Contact'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'LeadId' 
SET @TargetAttributeName= 'OriginatingLeadId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'WebSiteUrl' 
SET @TargetAttributeName= 'WebSiteUrl'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'FirstName' 
SET @TargetAttributeName= 'FirstName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'FullName' 
SET @TargetAttributeName= 'FullName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'MiddleName' 
SET @TargetAttributeName= 'MiddleName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'Telephone2' 
SET @TargetAttributeName= 'Telephone2'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'Telephone1' 
SET @TargetAttributeName= 'Telephone1'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'Fax' 
SET @TargetAttributeName= 'Fax'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'MobilePhone' 
SET @TargetAttributeName= 'MobilePhone'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'LastName' 
SET @TargetAttributeName= 'LastName'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
---------------------------------------------convert Opportunity to Contract
SET @SourceEntityName = N'Opportunity' 
SET @TargetEntityName= N'Contract'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'OpportunityId' 
SET @TargetAttributeName= 'OpportunityId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'TransactionCurrencyId' 
SET @TargetAttributeName= 'TransactionCurrencyId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'DepartmentId' 
SET @TargetAttributeName= 'DepartmentId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'Name' 
SET @TargetAttributeName= 'Title'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'CustomerId' 
SET @TargetAttributeName= 'BillingCustomerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
--------------------------------------convert Contract to Invoice
SET @SourceEntityName = N'Contract' 
SET @TargetEntityName= N'Invoice'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'ContractId' 
SET @TargetAttributeName= 'ContractId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'ContractId' 
SET @TargetAttributeName= 'ContractId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'ExchangeRate' 
SET @TargetAttributeName= 'ExchangeRate'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'TransactionCurrencyId' 
SET @TargetAttributeName= 'TransactionCurrencyId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'Description' 
SET @TargetAttributeName= 'Description'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'BillingCustomerId' 
SET @TargetAttributeName= 'BillingCustomerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'TotalPrice' 
SET @TargetAttributeName= 'TotalAmount'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)

---------------------------------------convert Opportunity to Quote
SET @SourceEntityName = N'Opportunity' 
SET @TargetEntityName= N'Quote'
INSERT INTO [dbo].[ImportEntityMapping] ([ImportEntityMappingId], [SourceEntityName], [TargetEntityName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @TargetEntityName, @ImportMapId)
SET @SourceAttributeName = 'OpportunityId' 
SET @TargetAttributeName= 'OpportunityId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'TransactionCurrencyId' 
SET @TargetAttributeName= 'TransactionCurrencyId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'Name' 
SET @TargetAttributeName= 'Name'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)
SET @SourceAttributeName = 'CustomerId' 
SET @TargetAttributeName= 'CustomerId'
INSERT INTO [dbo].[ColumnMapping] ([ColumnMappingId], [SourceEntityName], [SourceAttributeName], [TargetEntityName], [TargetAttributeName], [ImportMapId]) 
VALUES (NEWID(), @SourceEntityName, @SourceAttributeName, @TargetEntityName, @TargetAttributeName, @ImportMapId)